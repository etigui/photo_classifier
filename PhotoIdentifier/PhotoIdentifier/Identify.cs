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
    public partial class Identify : Form {

        #region Vars
        //private const string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\GitHub\semester_project\PhotoIdentifier\PhotoIdentifier\photos.mdf;Persist Security Info=True;Connect Timeout=30";
        private readonly IFaceServiceClient face_service_client = new FaceServiceClient(Resources.face_api_key.ToString(), "https://westeurope.api.cognitive.microsoft.com/face/v1.0");
        private readonly IVisionServiceClient vision_client = new VisionServiceClient(Resources.visio_api_key.ToString(), "https://westeurope.api.cognitive.microsoft.com/vision/v1.0");
        private string conf_file_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "app_conf.xml");
        public ImageListView photos_to_identify;
        private DateTime date = DateTime.Now;
        private Person preson;
        private Conf conf;
        private int progress = 0;
        #endregion

        #region Init

        public Identify() {
            InitializeComponent();
        }

        private async void Identify_Load(object sender, EventArgs e) {
            init();

            //#pragma warning disable 4014
            await identify_async();
            //#pragma warning restore 4014   

            // PROGRESS
            update_progress("Identify finised", "", ++progress);

            this.Close();
        }


        private void init() {

            // Get person
            preson = new Person();
            //preson.

            // Get conf
            conf = new Conf(conf_file_path);

            // Set max progress
            set_max_progress();

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
            if (await add_person_async(person_group_id)) {

                // Get all photos from imagelistview
                foreach (ImageListViewItem item in photos_to_identify.Items) {

                    // Check if file existe
                    if (File.Exists(item.FileName)) {

                        // PROGRESS
                        update_progress("Identify photo", $"Process photo: {Path.GetFileName(item.FileName).ToString()}", ++progress);


                        /*// Get file size (Image file size: Less than 4 MB)
                        if (new FileInfo(item.FileName).Length >= 4000000) {
                            continue;
                        }

                        // Get image dimention (Image dimension: Greater than 50 x 50 pixels.)
                        Image img = null;
                        img = Image.FromFile(item.FileName);
                        if ((img.Width > 50) && (img.Height > 50)) {
                            continue;
                        }*/

                        // Identify person in the photos
                        IdentifyInfos ii = await identify_person_async(item.FileName, person_group_id);
                        if (ii != null) {
                            infos_list.Add(ii);
                        }
                    }
                }

                // Add infos to db
                if (!add_photos_db(infos_list)) {
                    //TODO ERROR
                    MessageBox.Show("DB error");
                }

                // Add infos to db and copy photos to identify dir
                //if(!add_photos(infos_list)) {
                //TODO ERROR
                //}
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
                using (Stream stream = File.OpenRead(path)) {

                    infos.faces = await face_service_client.DetectAsync(stream, returnFaceId: true, returnFaceLandmarks: false, returnFaceAttributes: faceAttributes);

                    // If face identified in the photo
                    if (infos.faces.Length != 0) {
                        Guid[] faceIds = infos.faces.Select(face => face.FaceId).ToArray();

                        IdentifyResult[] results = await face_service_client.IdentifyAsync(person_group_id, faceIds);

                        // Process face detected
                        foreach (var identifyResult in results) {
                            Debug.WriteLine("Result of face: {0}", identifyResult.FaceId);
                            if (identifyResult.Candidates.Length == 0) {
                                Debug.WriteLine("No one identified");
                                infos.person.Add(identifyResult.FaceId.ToString(), "not identified");
                            } else {

                                // Get top 1 among all candidates returned
                                var candidateId = identifyResult.Candidates[0].PersonId;
                                var person = await face_service_client.GetPersonAsync(person_group_id, candidateId);
                                Debug.WriteLine("Identified as {0}", person.Name);
                                infos.person.Add(identifyResult.FaceId.ToString(), person.Name.ToString());
                            }
                        }
                    } else {
                        // No face identified
                    }
                }

                // If error during person identify
                //if(infos != null) {
                // If error during person identify or no person identified
                if (infos.faces.Length != 0) {

                    //Identify things in the photo
                    infos.info = await identify_image_async(path);
                }

                // If error during photo identify
                if (infos.info.ImageType != null) {
                    return infos;
                } else {
                    return null;
                }
            } catch (Exception ex) { infos = null; return null; } // MessageBox.Show(ex.ToString());
        }

        private async Task<AnalysisResult> identify_image_async(string path) {
            Debug.WriteLine("Start visio");

            // The list of Visual Features to return
            VisualFeature[] features = new VisualFeature[] { VisualFeature.Tags, VisualFeature.Description, VisualFeature.Adult, VisualFeature.Categories, VisualFeature.Color, VisualFeature.ImageType };
            AnalysisResult ar = new AnalysisResult();
            try {

                // Read file
                using (Stream stream = File.OpenRead(path)) {
                    ar = await vision_client.AnalyzeImageAsync(stream, features);
                }
            } catch { ar = null; }
            return ar;
        }
        #endregion

        #region Add person

        private async Task<bool> add_person_async(string person_group_id) {
            try {

                // Check if group already exist
                // If yes => delete
                PersonGroup[] person_groups = await face_service_client.ListPersonGroupsAsync();
                foreach (PersonGroup pg in person_groups) {
                    if (pg.PersonGroupId == person_group_id) {
                        await face_service_client.DeletePersonGroupAsync(person_group_id);
                    }
                }

                // Create group
                await face_service_client.CreatePersonGroupAsync(person_group_id, person_group_id);

                // Get all directory in "person dir"
                foreach (string person_name_dir_path in preson.get_all_person_dir()) {

                    // Get only last directory
                    string dir_person_name = person_name_dir_path.Split(Path.DirectorySeparatorChar).Last();//.Replace("_","");

                    //Create person with current groupe
                    CreatePersonResult cpr = await face_service_client.CreatePersonAsync(person_group_id, dir_person_name);

                    // TODO Add "*.id" file
                    //add_person_id_file(person_name_dir_path, cpr.PersonId.ToString());

                    // Get all photos
                    foreach (string person_photo in Directory.EnumerateFiles(person_name_dir_path, "*.*", SearchOption.AllDirectories).Where(n => Path.GetExtension(n) != ".id").ToList()) {
                        if (File.Exists(person_photo)) {
                            Debug.WriteLine($"Add person photo: {person_photo}"); //TODO

                            // PROGRESS
                            update_progress("Add person", $"Process person: {dir_person_name.Split('_')[0]}", ++progress);
                            using (Stream stream = File.OpenRead(person_photo)) {

                                // If the person photo containe no face => throw error
                                try {
                                    // Detect faces in the image and add to Anna
                                    await face_service_client.AddPersonFaceAsync(person_group_id, cpr.PersonId, stream);
                                } catch { Console.WriteLine("Person photo containe no face"); }
                            }
                        }
                    }
                }

                // PROGRESS
                update_progress("Training group", $"Process group: {person_group_id}", progress);

                // Training person group
                await face_service_client.TrainPersonGroupAsync(person_group_id);
                TrainingStatus trainingStatus = null;
                while (true) {
                    trainingStatus = await face_service_client.GetPersonGroupTrainingStatusAsync(person_group_id);

                    if (trainingStatus.Status.ToString() != "running") {
                        break;
                    }

                    await Task.Delay(1000);
                }

                Debug.WriteLine("Training ok");
            } catch (Exception ex) { MessageBox.Show(ex.ToString()); return false; }
            return true;
        }

        private bool add_person_id_file(string path, string person_id) {
            try {
                string person_id_file_path = Path.Combine(path, $"{person_id}.id");
                if (!File.Exists(person_id_file_path)) {
                    //File.Delete(person_id_file_path);
                    File.Create(person_id_file_path);
                }
            } catch { return false; }
            return true;
        }
        #endregion

        #region Add photos

        /*private bool add_photos(List<IdentifyInfos> infos_list) {

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
        }*/


        /// <summary>
        /// Add all identifed photo to the db
        /// </summary>
        /// <param name="infos"></param>
        /// <returns></returns>
        private bool add_photos_db(List<IdentifyInfos> infos) {

            // PROGRESS
            update_progress("Add infos to database", $"Process infos...", progress);
            DataSet data = new DataSet();
            return data.add_identified_photos(infos);
            /*Data data = new Data();
            data.infos_list = infos;
            return data.process_photos();*/
        }


        #endregion

        #region Copy photo

        private bool copy_photos(string path) {
            try {
                string source = path;
                string dest = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "identify", Path.GetFileName(path));
                if (File.Exists(path)) {
                    if (!File.Exists(dest)) {
                        File.Copy(source, dest);
                    }
                }
            } catch { return false; }
            return true;
        }
        #endregion

        #region Progress bar

        /// <summary>
        /// Update label and progress bar
        /// </summary>
        /// <param name="up"></param>
        /// <param name="down"></param>
        /// <param name="value"></param>
        private void update_progress(string up, string down, int value) {
            LB_status_up.Invoke((Action)(() => LB_status_up.Text = up));
            Lb_status_down.Invoke((Action)(() => Lb_status_down.Text = down));
            PB_status.Invoke((Action)(() => PB_status.Value = value));
        }

        /// <summary>
        /// Get max progress to set progress bar max value
        /// </summary>
        /// <returns></returns>
        private void set_max_progress() {
            int photos = 0;
            int per = 0;


            // Get all photos from imagelistview
            foreach (ImageListViewItem item in photos_to_identify.Items) {

                // Check if file existe
                if (File.Exists(item.FileName)) {
                    photos++;
                }
            }


            // Get all dir
            foreach (string p in preson.get_all_person_dir()) {

                // Get all photos
                foreach (string person_photo in Directory.EnumerateFiles(p, "*.*", SearchOption.AllDirectories).Where(n => Path.GetExtension(n) != ".id").ToList()) {
                    if (File.Exists(person_photo)) {
                        per++;
                    }
                }
            }

            // Set max value
            // +1 = database
            PB_status.Value = 0;
            PB_status.Maximum = photos + per + 1;
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
