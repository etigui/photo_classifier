using Manina.Windows.Forms;
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
    public partial class AddPerson:Form {
        public AddPerson() {
            InitializeComponent();
        }

        private void AddPerson_Load(object sender, EventArgs e) {
            ImageListView myImageListView = new ImageListView();

            myImageListView.SetRenderer(new ImageListViewRenderers.TilesRenderer(180));
        }
    }
}
