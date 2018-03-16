using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manina.Windows.Forms;
using PhotoIdentifier;

namespace PhotosFinder {
    public partial class PF : Form {

        #region Vars
        //Data data;
        DataGet data;
        Conf conf;

        private string conf_file_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "app_conf.xml");
        string identify_dir_path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        //string identify_dir_path = string.Empty;
        #endregion

        #region Init
        public PF() {
            InitializeComponent();
            init();
        }

        private void init() {
            //data = new Data();
            data = new DataGet();
            conf = new Conf(conf_file_path);

            // Create identify if not exist
            /*string identify_dir_path = conf.read_identify_path();
             if(!Directory.Exists(identify_dir_path)) {
                 Directory.CreateDirectory(identify_dir_path);
             }*/

            //Init thumbnails size tick
            x96ToolStripMenuItem.Checked = true;

            // Add all details
            foreach (ImageListView.ImageListViewColumnHeader c in ILV_photos.Columns) {
                c.Visible = true;
            }

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
            ILV_photos.Items.Clear();
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

            ILV_photos.Items.Clear();

            // Reset the AND if not => Name
            if (CB_type1.Text != "Name") {
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
            if (res != null) {
                CB_value1.Items.AddRange(res);
            } else {
                //TODO error db
            }
        }

        private void CB_type2_SelectedIndexChanged(object sender, EventArgs e) {

            ILV_photos.Items.Clear();

            // Clear and add value from type
            CB_value2.Items.Clear();
            CB_value2.Text = "Select a value";
            string[] res = data.get_type(CB_type2.Text).ToArray();
            if (res != null) {
                CB_value2.Items.AddRange(res);
            } else {
                //TODO error db
            }
        }

        #endregion

        #region Get files

        private void CB_value1_SelectedIndexChanged(object sender, EventArgs e) {

            List<string> files = new List<string>();
            ILV_photos.Items.Clear();

            // We have 2 value to select in the database
            if (CB_value2.Text != "Select a value") {
                // Slect 2 value
                files = data.get_two_value(CB_type1.Text, CB_value1.Text, CB_type2.Text, CB_value2.Text);

                // Add file to the ImageList
                add_files(files);
            } else {

                // Select one value
                files = data.get_one_value(CB_type1.Text, CB_value1.Text);


                // Add file to the ImageList
                add_files(files);
            }
        }

        private void CB_value2_SelectedIndexChanged(object sender, EventArgs e) {

            List<string> files = new List<string>();
            ILV_photos.Items.Clear();

            // We have 2 value to select in the database
            if (CB_value1.Text != "Select a value") {

                // Slect 2 value
                files = data.get_two_value(CB_type1.Text, CB_value1.Text, CB_type2.Text, CB_value2.Text);

                // Add file to the ImageList
                add_files(files);
            }
        }

        /// <summary>
        /// Add files in the image list view
        /// </summary>
        /// <param name="files"></param>
        private void add_files(List<string> files) {
            ILV_photos.ClearThumbnailCache();

            // Db error
            if (files == null) {
                // TODO error
            } else if (files.Count() > 0) {
                // Add file to the ImageList

                foreach (string file in files) {

                    // Check if full path
                    // Full => c:/
                    // Not full => /....
                    if (!check_path(file)) {

                        // Get photo path
                        //string photo = Path.Combine(id, file);
                        string photo = $"{identify_dir_path}{file}";

                        // If exist add it to the Image list
                        if (File.Exists(photo)) {
                            ILV_photos.Items.Add(photo);
                        } else {
                            // TODO locate
                            MessageBox.Show("locate");
                        }
                    } else {

                        // If exist add it to the Image list
                        if (File.Exists(file)) {
                            ILV_photos.Items.Add(file);
                        } else {
                            // TODO locate
                            MessageBox.Show("locate");
                        }
                    }
                }
            } else {
                MessageBox.Show("No photo found.");
            }
        }

        /// <summary>
        /// Check if full path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool check_path(string path) {
            if (path.Contains(":")) {
                return true;
            }
            return false;
        }

        #endregion

        #region View style

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
            x150ToolStripMenuItem.Checked = true;
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

        #region Update status bar

        /// <summary>
        /// Get how many photo selected
        /// </summary>
        private void update_status() {
            if (ILV_photos.Items.Count == 0)
                update_status("No photos");
            else if (ILV_photos.SelectedItems.Count == 0)
                update_status(string.Format("{0} Photos", ILV_photos.Items.Count));
            else
                update_status(string.Format("{0} Photos ({1} selected)", ILV_photos.Items.Count, ILV_photos.SelectedItems.Count));
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

        private void ILV_photos_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                // TODO right click (locate image) => open explorer with the image selected 

            }
        }

        private void BT_save_all_Click(object sender, EventArgs e) {
            //TODO get all phot from ILV sa save it where the user want (save_files_dialog)
            try {
                using (FolderBrowserDialog obd = new FolderBrowserDialog()) {

                    if (obd.ShowDialog() == DialogResult.OK) {
                        string dir = obd.SelectedPath;

                        // Get all photos from imagelistview
                        foreach (ImageListViewItem item in ILV_photos.Items) {

                            // Copy the files from the ILV to the selected directory
                            if (File.Exists(item.FileName)) {
                                File.Copy(item.FileName, $"{dir}\\{Path.GetFileName(item.FileName)}");
                            }
                        }
                    }
                }
                MessageBox.Show("File saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch { }
        }
    }
}
