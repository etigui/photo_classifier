using Microsoft.ProjectOxford.Face;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace PhotoIdentifier {
    public partial class Form1:Form {

        private readonly IFaceServiceClient faceServiceClient = new FaceServiceClient("aeb4502d493444c0bf75969ad78f9e99", "https://westeurope.api.cognitive.microsoft.com/face/v1.0");
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            
    }
    }
}
