using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotoIdentifier;

namespace PhotosFinder {
    public partial class PF : Form {

        #region Vars
        Data data;
        Conf conf;

        private string conf_file_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "app_conf.xml");
        #endregion

        #region Init
        public PF() {
            InitializeComponent();
            init();
        }

        private void init() {
            data = new Data();
            conf = new Conf(conf_file_path);

            // Add image path to xml file Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            // Add identify folder to photo dir
        }


        #endregion


        #region Controls

        private void CB_type1_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = true;
        }

        private void CB_value1_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = true;
        }

        private void CB_type2_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = true;
        }

        private void CB_value2_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = true;
        }

        private void BT_reset_Click(object sender, EventArgs e) {
            CB_type2.Enabled = false;
            CB_value2.Enabled = false;
            CB_type1.Text = "Select a type";
            CB_value1.Text = "Select a value";
            CB_type2.Text = "Select a type";
            CB_value2.Text = "Select a value";
        }

        #endregion

        #region Add Value

        private void CB_type1_SelectedIndexChanged(object sender, EventArgs e) {

            // Reset the AND if not => Name
            if(CB_type1.Text != "Name") {
                CB_type2.Enabled = false;
                CB_value2.Enabled = false;
                CB_type2.Text = "Select a type";
                CB_value2.Text = "Select a value";
            } else {
                CB_type2.Enabled = true;
                CB_value2.Enabled = true;
            }

            // Clear and add value from type
            CB_value1.Items.Clear();
            CB_value1.Text = "Select a value";
            string[] res = data.get_type(CB_type1.Text).ToArray();
            if(res != null) {
                CB_value1.Items.AddRange(res);
            } else {
                //TODO error db
            }
        }

        private void CB_type2_SelectedIndexChanged(object sender, EventArgs e) {

            // Clear and add value from type
            CB_value2.Items.Clear();
            CB_value2.Text = "Select a value";
            string[] res = data.get_type(CB_type2.Text).ToArray();
            if(res != null) {
                CB_value2.Items.AddRange(res);
            } else {
                //TODO error db
            }
        }

        #endregion

        #region Get files

        private void CB_value1_SelectedIndexChanged(object sender, EventArgs e) {

            List<string> files = new List<string>();

            // We have 2 value to select in the database
            if(CB_value2.Text != "Select a value") {
                // Slect 2 value
                files = data.get_value_two(CB_type1.Text, CB_type2.Text, CB_value1.Text, CB_value2.Text);

                // Add file to the ImageList
                add_files(files);
            } else {

                // Select one value
                files = data.get_value_one(CB_type1.Text, CB_value1.Text);


                // Add file to the ImageList
                add_files(files);
            }
        }

        private void CB_value2_SelectedIndexChanged(object sender, EventArgs e) {

            List<string> files = new List<string>();

            // We have 2 value to select in the database
            if(CB_value1.Text != "Select a value") {

                // Slect 2 value
                files = data.get_value_two(CB_type1.Text, CB_type2.Text, CB_value1.Text, CB_value2.Text);

                // Add file to the ImageList
                add_files(files);
            }
        }

        private void add_files(List<string> files) {

            // Db error
            if(files == null) {
                // TODO error
            } else if(files.Count() > 0) {
                // Add file to the ImageList
            } else {
                MessageBox.Show("No photo found.");
            }
        }

        #endregion
    }
}
