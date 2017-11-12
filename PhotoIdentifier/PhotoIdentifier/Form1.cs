using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
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
using System.IO;
using System.Reflection;
using Manina.Windows.Forms;
using System.Security.AccessControl;
using System.Net.NetworkInformation;

//Face Detect + Identifier
//https://docs.microsoft.com/en-us/azure/cognitive-services/face/face-api-how-to-topics/howtoidentifyfacesinimage

// Visio computer
//https://docs.microsoft.com/en-us/azure/cognitive-services/computer-vision/vision-api-how-to-topics/howtocallvisionapi

namespace PhotoIdentifier {
    public partial class Form1:Form {

        private readonly IFaceServiceClient faceServiceClient = new FaceServiceClient("aeb4502d493444c0bf75969ad78f9e99", "https://westeurope.api.cognitive.microsoft.com/face/v1.0");
        private string obama_image = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"person\obama\him\");
        private string obama_family_image = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"person\obama\family\");
        private string person_group_id = "president";
        //private string trump_image = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"\person\trump\him\");

        #region vars
        bool internet_connection = false;
        #endregion

        #region Init

        public Form1() {
            InitializeComponent();
            init();
        }

        private void init() {
            
            // Set from size
            this.Width = 750;
            this.Height = 555;

            //Init thumbnails size tick
            x96ToolStripMenuItem.Checked = true;

            // Check internet
            check_internet();
        }

        private void Form1_Load(object sender, EventArgs e) {
        }

        private void Form1_Shown(object sender, EventArgs e) {
        }

        #endregion

        #region Menu controls

        private void TSB_info_Click(object sender, EventArgs e) {

            // Lunch columns form
            ColumnsInfos form = new ColumnsInfos();
            form.ILV_photos = ILV_photos;
            form.ShowDialog();
        }

        private void TSB_person_Click(object sender, EventArgs e) {

        }

        private void TSB_group_Click(object sender, EventArgs e) {

        }

        private void TSB_search_Click(object sender, EventArgs e) {
            string photos_finder_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"PhotosFinder.exe");
            if(File.Exists(photos_finder_path)) {

                //Lunch or not the PhotoFinder program
                if(MessageBox.Show("Do you want to lunch PhotoFinder ?", "Lunch", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    Process.Start(photos_finder_path);
                }
            }
        }
        #endregion

        #region Add/remove/clear images

        private void TSB_add_Click(object sender, EventArgs e) {

            // Add photos to the list
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if(ofd.ShowDialog() == DialogResult.OK) {
                ILV_photos.Items.AddRange(ofd.FileNames);
                TSB_clear.Enabled = true;
                TSB_remove.Enabled = true;
                update_status();
            }
        }
        private void TSB_remove_Click(object sender, EventArgs e) {

            // Suspend the layout logic while we are removing items. Otherwise the control will be refreshed after each item is removed.
            ILV_photos.SuspendLayout();

            // Remove selected items
            foreach(var item in ILV_photos.SelectedItems) {
                ILV_photos.Items.Remove(item);
            }

            // Resume layout logic.
            ILV_photos.ResumeLayout(true);
            update_status();
        }

        private void TSB_clear_Click(object sender, EventArgs e) {
            ILV_photos.Items.Clear();
            update_status();
        }
        #endregion

        #region Update status bar

        /// <summary>
        /// Get how many photo selected
        /// </summary>
        private void update_status() {

            // 
            if(ILV_photos.Items.Count == 0) {
                update_status("No Photos");
            } else if(ILV_photos.SelectedItems.Count == 0) {
                update_status(string.Format("{0} Photos", ILV_photos.Items.Count));
            } else {
                update_status(string.Format("{0} Photos ({1} selected)", ILV_photos.Items.Count, ILV_photos.SelectedItems.Count));
            }
        }

        /// <summary>
        /// Add how many photo selected to label
        /// </summary>
        /// <param name="status"></param>
        private void update_status(string status) {
            TSSL_infos.Text = status;
        }

        private void ILV_photos_SelectionChanged(object sender, EventArgs e) {
            update_status();
        }
        #endregion

        #region Change thumbnails size
        /// <summary>
        /// Uncheck all the element in the drowp down menu size
        /// </summary>
        private void uncheck() {
            x48ToolStripMenuItem.Checked = false;
            x96ToolStripMenuItem.Checked = false;
            x120ToolStripMenuItem.Checked = false;
            x150ToolStripMenuItem.Checked = false;
            x200ToolStripMenuItem.Checked = false;
        }

        private void x48ToolStripMenuItem_Click(object sender, EventArgs e) {
            ILV_photos.ThumbnailSize = new Size(48, 48);
            uncheck();
            x48ToolStripMenuItem.Checked = true;
        }

        private void x96ToolStripMenuItem_Click(object sender, EventArgs e) {
            ILV_photos.ThumbnailSize = new Size(96, 96);
            uncheck();
            x96ToolStripMenuItem.Checked = true;
        }

        private void x120ToolStripMenuItem_Click(object sender, EventArgs e) {
            ILV_photos.ThumbnailSize = new Size(120, 120);
            uncheck();
            x120ToolStripMenuItem.Checked = true;
        }

        private void x150ToolStripMenuItem_Click(object sender, EventArgs e) {
            ILV_photos.ThumbnailSize = new Size(150, 150);
            uncheck();
            x150ToolStripMenuItem.Checked = true;
        }

        private void x200ToolStripMenuItem_Click(object sender, EventArgs e) {
            ILV_photos.ThumbnailSize = new Size(200, 200);
            uncheck();
            x200ToolStripMenuItem.Checked = true;
        }
        #endregion

        #region Change thumbnails style

        private void TSB_thumbnails_Click(object sender, EventArgs e) {
            ILV_photos.View = Manina.Windows.Forms.View.Thumbnails;
        }

        private void TSB_gallery_Click(object sender, EventArgs e) {
            ILV_photos.View = Manina.Windows.Forms.View.Gallery;
        }

        private void TSB_pane_Click(object sender, EventArgs e) {
            ILV_photos.View = Manina.Windows.Forms.View.Pane;
        }

        private void TSB_list_Click(object sender, EventArgs e) {
            ILV_photos.View = Manina.Windows.Forms.View.Details;
        }
        #endregion

        #region Photos identify

        private void TSB_identify_Click(object sender, EventArgs e) {

            // Check if the list is not empty
            if(ILV_photos.Items.Count != 0) {

                //Lunch the identification ?
                if(MessageBox.Show("Do you want to identify the current photos ?", "Identify", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                }
            } else {
                MessageBox.Show("No photos to identify", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Check internet

        /// <summary>
        /// Callback for check_internet function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ping_completed_callback(object sender, PingCompletedEventArgs e) {
            if(e.Reply.Status == IPStatus.Success) {
                internet_connection = true;
            }
            else if(e.Cancelled) {
                MessageBox.Show("No internet connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(e.Error != null) {
                MessageBox.Show("No internet connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Check connection (ping google for 3 sec)
        /// </summary>
        private void check_internet() {
            Ping myPing = new Ping();
            myPing.PingCompleted += new PingCompletedEventHandler(ping_completed_callback);
            try {
                //Ping google for 3 sec
                myPing.SendAsync("google.com", 3000, new byte[32], new PingOptions(64, true));
            } catch {
            }
        }
        #endregion

        async private void button1_Click(object sender, EventArgs e) {

            //TODO maybe add PersistedFaceIds to 

            // Create an empty person group
            //await faceServiceClient.GetPersonGroupAsync()
            // await faceServiceClient.CreatePersonGroupAsync(person_group_id, "president");

            // Define president obama and trump
            CreatePersonResult person_obama = await faceServiceClient.CreatePersonAsync(person_group_id, "obama");
            // CreatePersonResult person_trump = await faceServiceClient.CreatePersonAsync(person_group_id, "trump");

            foreach(string imagePath in Directory.GetFiles(obama_image, "*.jpg")) {
                using(Stream s = File.OpenRead(imagePath)) {

                    // Detect faces in the image and add to Anna
                    await faceServiceClient.AddPersonFaceAsync(person_group_id, person_obama.PersonId, s);
                }
            }

            await faceServiceClient.TrainPersonGroupAsync(person_group_id);
            TrainingStatus trainingStatus = null;
            while(true) {
                trainingStatus = await faceServiceClient.GetPersonGroupTrainingStatusAsync(person_group_id);

                if(trainingStatus.Status.ToString() != "running") {
                    break;
                }

                await Task.Delay(1000);
            }

            Debug.WriteLine("trainingStatus OK");
        }

        async private void button2_Click(object sender, EventArgs e) {

            // The list of Face attributes to return.
            IEnumerable<FaceAttributeType> faceAttributes = new FaceAttributeType[] { FaceAttributeType.Gender, FaceAttributeType.Age, FaceAttributeType.Smile, FaceAttributeType.Emotion, FaceAttributeType.Glasses, FaceAttributeType.Hair };

            string img = Path.Combine(obama_family_image, "0.jpg");
            using(Stream s = File.OpenRead(img)) {
                var faces = await faceServiceClient.DetectAsync(s, returnFaceId: true, returnFaceLandmarks: false, returnFaceAttributes: faceAttributes);

                var faceIds = faces.Select(face => face.FaceId).ToArray();

                var results = await faceServiceClient.IdentifyAsync(person_group_id, faceIds);

                foreach(var identifyResult in results) {
                    Debug.WriteLine("Result of face: {0}", identifyResult.FaceId);
                    if(identifyResult.Candidates.Length == 0) {
                        Debug.WriteLine("No one identified");
                    } else {
                        // Get top 1 among all candidates returned
                        var candidateId = identifyResult.Candidates[0].PersonId;
                        var person = await faceServiceClient.GetPersonAsync(person_group_id, candidateId);
                        Debug.WriteLine("Identified as {0}", person.Name);
                    }
                }
            }
        }
        /*
        // Change the renderer
        Assembly assembly = Assembly.GetAssembly(typeof(ImageListView));
        //RendererItem item = (RendererItem)comboBox1.SelectedItem;
        ImageListView.ImageListViewRenderer renderer = assembly.CreateInstance("Manina.Windows.Forms.ImageListViewRenderers+XPRenderer") as ImageListView.ImageListViewRenderer;
        ILV_photos.SetRenderer(renderer);
        ILV_photos.Focus();*/
    }
}
