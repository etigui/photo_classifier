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

            Debug.WriteLine(obama_image);
            Debug.WriteLine(obama_family_image);
            int test = 5;

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
            string img = Path.Combine(obama_family_image, "3.jpg");
            using(Stream s = File.OpenRead(img)) {
                var faces = await faceServiceClient.DetectAsync(s);
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
    }
}
