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
        private const string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\GitHub\semester_project\PhotoIdentifier\PhotoIdentifier\photos.mdf;Persist Security Info=True;Connect Timeout=30";
        private readonly IFaceServiceClient face_service_client = new FaceServiceClient(Resources.face_api_key.ToString(), "https://westeurope.api.cognitive.microsoft.com/face/v1.0");
        private readonly IVisionServiceClient vision_client = new VisionServiceClient(Resources.visio_api_key.ToString(), "https://westeurope.api.cognitive.microsoft.com/vision/v1.0");
        private string conf_file_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "app_conf.xml");
        public ImageListView photos_to_identify;
        private DateTime date = DateTime.Now;
        private Person preson;
        private Conf conf;
        #endregion

        #region Init

        public Identify() {
            InitializeComponent();
        }

        private void Identify_Load(object sender, EventArgs e) {
            init();
#pragma warning disable 4014
            identify_async();
#pragma warning restore 4014
        }


        private void init() {

            // Get person
            preson = new Person();

            // Get conf
            conf = new Conf(conf_file_path);

            // Write log
            //LB_log.Items.Add($"[{date.ToString("dd.MM.yyy HH: mm:ss")}] Identification started");
        }
        #endregion

        #region Controls
        private void BT_cancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        #endregion

        #region Identify

        private async Task identify_async() {

            // List of photos infos
            List<IdentifyInfos> infos_list = new List<IdentifyInfos>();

            // Get current group id
            string person_group_id = conf.read_group();

            // Add person for identification
            if(await add_person_async(person_group_id)) {

                // Get all photos from imagelistview
                foreach(ImageListViewItem item in photos_to_identify.Items) {

                    // Check if file existe
                    if(File.Exists(item.FileName)) {

                        // Identify person in the photos
                        IdentifyInfos ii = await identify_person_async(item.FileName, person_group_id);
                        if(ii != null) {
                            infos_list.Add(ii);
                        }
                    }
                }

                // Add infos to db and copy photos to identify dir
                if(!add_photos(infos_list)) {
                    //TODO ERROR
                }
            }
        }
        private async Task<IdentifyInfos> identify_person_async(string path, string person_group_id) {
            Debug.WriteLine($"Identify photo: {path}"); //TODO

            // Init class
            IdentifyInfos infos = new IdentifyInfos {
                person = new Dictionary<string, string>(),
                info = new AnalysisResult()
            };

            //Get current photo
            infos.path = path;

            // The list of Face attributes to return.
            IEnumerable<FaceAttributeType> faceAttributes = new FaceAttributeType[] { FaceAttributeType.Gender, FaceAttributeType.Age, FaceAttributeType.Smile, FaceAttributeType.Emotion, FaceAttributeType.Glasses, FaceAttributeType.Hair, FaceAttributeType.Accessories, FaceAttributeType.Blur, FaceAttributeType.Exposure, FaceAttributeType.FacialHair, FaceAttributeType.HeadPose, FaceAttributeType.Makeup, FaceAttributeType.Noise, FaceAttributeType.Occlusion };
            try {

                // Read file
                using(Stream stream = File.OpenRead(path)) {

                    infos.faces = await face_service_client.DetectAsync(stream, returnFaceId: true, returnFaceLandmarks: false, returnFaceAttributes: faceAttributes);
                    Guid[] faceIds = infos.faces.Select(face => face.FaceId).ToArray();
                    IdentifyResult[] results = await face_service_client.IdentifyAsync(person_group_id, faceIds);

                    // Process face detected
                    foreach(var identifyResult in results) {
                        Debug.WriteLine("Result of face: {0}", identifyResult.FaceId);
                        if(identifyResult.Candidates.Length == 0) {
                            Debug.WriteLine("No one identified");
                            infos.person.Add(identifyResult.FaceId.ToString(), "No one identified");
                        } else {

                            // Get top 1 among all candidates returned
                            var candidateId = identifyResult.Candidates[0].PersonId;
                            var person = await face_service_client.GetPersonAsync(person_group_id, candidateId);
                            Debug.WriteLine("Identified as {0}", person.Name);
                            infos.person.Add(identifyResult.FaceId.ToString(), person.Name.ToString());
                        }
                    }
                }
            } catch { infos = null; }

            // If error during person identify
            if(infos != null) {

                //Identify things in the photo
                infos.info = await identify_image_async(path);
            }

            // If error during photo identify
            if(infos.info != null) {
                return infos;
            } else {
                return null;
            }
        }

        private async Task<AnalysisResult> identify_image_async(string path) {
            Debug.WriteLine("Start visio");

            // The list of Visual Features to return
            VisualFeature[] features = new VisualFeature[] { VisualFeature.Tags, VisualFeature.Description, VisualFeature.Adult, VisualFeature.Categories, VisualFeature.Color, VisualFeature.ImageType };
            AnalysisResult ar = new AnalysisResult();
            try {

                // Read file
                using(Stream stream = File.OpenRead(path)) {
                    ar = await vision_client.AnalyzeImageAsync(stream, features);
                }
            } catch { ar = null; }
            return ar;
        }
        #endregion

        #region Add person

        private async Task<bool> add_person_async(string person_group_id) {
            try {

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
            } catch { return false; }
            return true;
        }

        private bool add_person_id_file(string path, string person_id) {
            try {
                string person_id_file_path = Path.Combine(path, $"{person_id}.id");
                if(!File.Exists(person_id_file_path)) {
                    //File.Delete(person_id_file_path);
                    File.Create(person_id_file_path);
                }
            } catch { return false; }
            return true;
        }
        #endregion

        #region Add photos

        private bool add_photos(List<IdentifyInfos> infos_list) {

            // Get all photos from IdentifyInfos
            foreach(IdentifyInfos info in infos_list) {

                // Copy photo to indentify directory
                if(copy_photos(info.path)) {

                    // add photo info in database
                    if(!add_photos_db(info)) {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool add_photos_db(IdentifyInfos info) {
            return true;
        }


        #endregion

        #region Copy photo

        private bool copy_photos(string path) {
            try {
                string source = path;
                string dest = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "identify", Path.GetFileName(path));
                if(File.Exists(path)) {
                    if(!File.Exists(dest)) {
                        File.Copy(source, dest);
                    }
                }
            } catch { return false; }
            return true;
        }
        #endregion
    }

    #region Class Identify

    public class IdentifyInfos {
        public string path { get; set; }
        public Dictionary<string, string> person { get; set; }
        public Microsoft.ProjectOxford.Face.Contract.Face[] faces { get; set; }
        public AnalysisResult info { get; set; }
    }
    #endregion
}
