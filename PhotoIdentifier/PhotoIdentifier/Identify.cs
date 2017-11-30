using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using PhotoIdentifier.Properties;
using System.IO;
using Manina.Windows.Forms;
using System.Collections;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;

namespace PhotoIdentifier {
    public partial class Identify:Form {

        #region Vars
        public ImageListView photos_to_identify;
        private DateTime date = DateTime.Now;
        private readonly IFaceServiceClient face_service_client = new FaceServiceClient(Resources.api_key.ToString(), "https://westeurope.api.cognitive.microsoft.com/face/v1.0");
        private readonly IVisionServiceClient vision_client = new VisionServiceClient("e3ca2a08abfb4957aee13ee0989798be", "https://westeurope.api.cognitive.microsoft.com/vision/v1.0");
        private string conf_file_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "app_conf.xml");
        private Person preson;
        private Conf conf;
        #endregion

        #region Init

        public Identify() {
            InitializeComponent();
        }

        private void Identify_Load(object sender, EventArgs e) {
           // Init();

            //identify_async();
        }

        private void Init() {

            // Get person
            preson = new Person();

            // Get conf
            conf = new Conf(conf_file_path);

            // Write log
            LB_log.Items.Add($"[{date.ToString("dd.MM.yyy HH: mm:ss")}] Identification started");
        }
        #endregion

        #region controls

        private void BT_show_Click(object sender, EventArgs e) {
            if(BT_show.Text == "˅") {
                BT_show.Text = "˄";
                LB_log.Visible = true;
                LB_log.Location = new System.Drawing.Point(12, 66);
                this.Width = 450;
                this.Height = 355;
            } else if(BT_show.Text == "˄") {
                BT_show.Text = "˅";
                LB_log.Visible = false;
                LB_log.Location = new System.Drawing.Point(12, 36);
                this.Width = 450;
                this.Height = 130;

            } else {
                throw new NotImplementedException("button log error");
            }
        }
        #endregion

        #region Identify

        private async Task identify_async() {
            await add_person_async();
            PersonIdentified pi = await identify_person_async();
            List<AnalysisResult> ar = await identify_image_async();

            //TODO get datas
        }

        private async Task<PersonIdentified> identify_person_async() {

            // Init class
            PersonIdentified pi = new PersonIdentified {
                all_faces = new List<Microsoft.ProjectOxford.Face.Contract.Face[]>(),
                dico_person = new Dictionary<string, string>()
            };

            // Get current group id
            string person_group_id = conf.read_group();

            // The list of Face attributes to return.
            IEnumerable<FaceAttributeType> faceAttributes = new FaceAttributeType[] { FaceAttributeType.Gender, FaceAttributeType.Age, FaceAttributeType.Smile, FaceAttributeType.Emotion, FaceAttributeType.Glasses, FaceAttributeType.Hair };

            // Get all photos from imagelistview
            foreach(ImageListViewItem item in photos_to_identify.Items) {
                if(File.Exists(item.FileName)) {
                    Debug.WriteLine($"Identify photo: {item.FileName}"); //TODO

                    // Read file
                    using(Stream stream = File.OpenRead(item.FileName)) {

                        Microsoft.ProjectOxford.Face.Contract.Face[] faces = await face_service_client.DetectAsync(stream, returnFaceId: true, returnFaceLandmarks: false, returnFaceAttributes: faceAttributes);
                        Guid[] faceIds = faces.Select(face => face.FaceId).ToArray();
                        IdentifyResult[] results = await face_service_client.IdentifyAsync(person_group_id, faceIds);
                        pi.all_faces.Add(faces);

                        // Process face detected
                        foreach(var identifyResult in results) {
                            Debug.WriteLine("Result of face: {0}", identifyResult.FaceId);
                            if(identifyResult.Candidates.Length == 0) {
                                Debug.WriteLine("No one identified");
                                pi.dico_person.Add(identifyResult.FaceId.ToString(), "No one identified");
                            } else {

                                // Get top 1 among all candidates returned
                                var candidateId = identifyResult.Candidates[0].PersonId;
                                var person = await face_service_client.GetPersonAsync(person_group_id, candidateId);
                                Debug.WriteLine("Identified as {0}", person.Name);
                                pi.dico_person.Add(identifyResult.FaceId.ToString(), person.Name.ToString());
                            }
                        }
                    }
                }
            }
            return pi;
        }

        private async Task<List<AnalysisResult>> identify_image_async() {

            Debug.WriteLine("Start visio");

            // The list of Visual Features to return
            VisualFeature[] features = new VisualFeature[] { VisualFeature.Tags, VisualFeature.Description, VisualFeature.Adult, VisualFeature.Categories, VisualFeature.Color, VisualFeature.ImageType };
            List<AnalysisResult> analysisResult = new List<AnalysisResult>();

            // Get all photos from imagelistview
            foreach(ImageListViewItem item in photos_to_identify.Items) {
                if(File.Exists(item.FileName)) {

                    // Read file
                    using(Stream stream = File.OpenRead(item.FileName)) {
                        analysisResult.Add(await vision_client.AnalyzeImageAsync(stream, features));
                    }
                }
            }
            return analysisResult;
        }
        #endregion

        #region Add person

        private async Task add_person_async() {

            // Get current group id
            string person_group_id = conf.read_group();

            //TEMPORARY Delete current group (dmhbfikfavpxw)
            PersonGroup ifsc = await face_service_client.GetPersonGroupAsync("dmhbfikfavpxw");
            if(ifsc.Name.ToString() == "dmhbfikfavpxw") {
                await face_service_client.DeletePersonGroupAsync("dmhbfikfavpxw");
            }

            // Create group
            await face_service_client.CreatePersonGroupAsync(person_group_id, person_group_id);

            // Get all directory in "person dir"
            foreach(string person_name_dir_path in preson.get_all_person_dir()) {

                // Get only last directory
                string dir_person_name = person_name_dir_path.Split(Path.DirectorySeparatorChar).Last();//.Replace("_","");

                //Create person with current groupe
                CreatePersonResult person = await face_service_client.CreatePersonAsync(person_group_id, dir_person_name);

                // TODO Add "*.id" file
                add_person_id_file(person_name_dir_path, person.PersonId.ToString());

                // Get all photos
                foreach(string person_photo in Directory.EnumerateFiles(person_name_dir_path, "*.*", SearchOption.AllDirectories).Where(n => Path.GetExtension(n) != ".id").ToList()) {
                    if(File.Exists(person_photo)) {
                        Debug.WriteLine($"Add person photo: {person_photo}"); //TODO
                        using(Stream stream = File.OpenRead(person_photo)) {

                            // Detect faces in the image and add to Anna
                            await face_service_client.AddPersonFaceAsync(person_group_id, person.PersonId, stream);
                        }
                    }
                }
            }

            // Training person group
            await face_service_client.TrainPersonGroupAsync(person_group_id);
            TrainingStatus trainingStatus = null;
            while(true) {
                trainingStatus = await face_service_client.GetPersonGroupTrainingStatusAsync(person_group_id);

                if(trainingStatus.Status.ToString() != "running") {
                    break;
                }

                await Task.Delay(1000);
            }

            Debug.WriteLine("Training ok");
        }

        private void add_person_id_file(string path, string person_id) {
            string person_id_file_path = Path.Combine(path, $"{person_id}.id");
            if(!File.Exists(person_id_file_path)) {
                //File.Delete(person_id_file_path);
                File.Create(person_id_file_path);
            }
        }
        #endregion
    }

    public class PersonIdentified {
        public Dictionary<string, string> dico_person { get; set; }
        public List<Microsoft.ProjectOxford.Face.Contract.Face[]> all_faces { get; set; }
    }
}
