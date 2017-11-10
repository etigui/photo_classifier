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


        public Form1() {
            InitializeComponent();
        }

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

        private void Form1_Load(object sender, EventArgs e) {

            fillTree();


            foreach(string imagePath in Directory.GetFiles(obama_family_image, "*.jpg")) {
                ILV_photos.Items.Add(imagePath);
            }

            // Change the renderer
            Assembly assembly = Assembly.GetAssembly(typeof(ImageListView));
            //RendererItem item = (RendererItem)comboBox1.SelectedItem;
            ImageListView.ImageListViewRenderer renderer = assembly.CreateInstance("Manina.Windows.Forms.ImageListViewRenderers+XPRenderer") as ImageListView.ImageListViewRenderer;
            ILV_photos.SetRenderer(renderer);
            ILV_photos.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {


            // Change the renderer
            Assembly assembly = Assembly.GetAssembly(typeof(ImageListView));
            //RendererItem item = (RendererItem)comboBox1.SelectedItem;
            ImageListView.ImageListViewRenderer renderer = assembly.CreateInstance("Manina.Windows.Forms.ImageListViewRenderers+XPRenderer") as ImageListView.ImageListViewRenderer;
            ILV_photos.SetRenderer(renderer);
            ILV_photos.Focus();
        }
        /*ILV_photos.View = Manina.Windows.Forms.View.Gallery;
        ILV_photos.View = Manina.Windows.Forms.View.Thumbnails;
        ILV_photos.View = Manina.Windows.Forms.View.Details;
        ILV_photos.View = Manina.Windows.Forms.View.Pane;
        ILV_photos.ThumbnailSize = new Size(120, 120);
        ILV_photos.ThumbnailSize = new Size(96, 96);
        ILV_photos.ThumbnailSize = new Size(150, 150);
        ILV_photos.ThumbnailSize = new Size(200, 200);
        */

        private void fillTree() {
            string[] drives = Environment.GetLogicalDrives();
            foreach(string dr in drives) {
                TreeNode node = new TreeNode(dr);
                node.Tag = dr;
                node.ImageIndex = 0; // drive icon
                node.Tag = dr;
                TV_computer.Nodes.Add(node);
                node.Nodes.Add(new TreeNode("?"));
            }
            TV_computer.BeforeExpand += new TreeViewCancelEventHandler(treeView1_BeforeExpand);
        }

        void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
            if((e.Node.Nodes.Count == 1) && (e.Node.Nodes[0].Text == "?")) {
                RecursiveDirWalk(e.Node);
            }
        }

        private TreeNode RecursiveDirWalk(TreeNode node) {
            string path = (string)node.Tag;
            try {
                node.Nodes.Clear();


                string[] dirs = System.IO.Directory.GetDirectories(path);
                for(int t = 0; t < dirs.Length; t++) {
                    TreeNode n = new TreeNode(dirs[t].Substring(dirs[t].LastIndexOf('\\') + 1));
                    n.ImageIndex = 1; // dir icon
                    n.Tag = dirs[t];
                    node.Nodes.Add(n);
                    n.Nodes.Add(new TreeNode("?"));
                }

                // Optional if you want files as well:
                string[] files = System.IO.Directory.GetFiles(path);
                for(int t = 0; t < files.Length; t++) {
                    TreeNode tn = new TreeNode(System.IO.Path.GetFileName(files[t]));
                    tn.Tag = files[t];
                    tn.ImageIndex = 2; // file icon
                    node.Nodes.Add(tn);
                } // end of optional file part
                return node;
            } catch(UnauthorizedAccessException ex) {

            }
            return node;
        }
        public static bool CanRead(string path) {
            var readAllow = false;
            var readDeny = false;
            var accessControlList = Directory.GetAccessControl(path);
            if(accessControlList == null)
                return false;
            var accessRules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
            if(accessRules == null)
                return false;

            foreach(FileSystemAccessRule rule in accessRules) {
                if((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read) continue;

                if(rule.AccessControlType == AccessControlType.Allow)
                    readAllow = true;
                else if(rule.AccessControlType == AccessControlType.Deny)
                    readDeny = true;
            }

            return readAllow && !readDeny;
        }
    }
}
