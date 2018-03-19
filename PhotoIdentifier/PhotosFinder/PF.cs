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
        private string conf_file_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "app_conf.xml");
        private string identify_dir_path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        private string item_path = string.Empty;
        DataGet data;
        Conf conf;
        Locate locate;
        #endregion

        #region Init
        public PF() {
            InitializeComponent();
            init();
        }

        private void init() {
            data = new DataGet();
            conf = new Conf(conf_file_path);
            locate = new Locate();

            //Init thumbnails size tick
            x96ToolStripMenuItem.Checked = true;

            // Add all details
            foreach (ImageListView.ImageListViewColumnHeader c in ILV_photos.Columns) {
                c.Visible = true;
            }
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
            update_status();

            // Reset the AND if not => Name
            if (CB_type1.Text != "Name") {
                CB_type2.Enabled = false;
                CB_value2.Enabled = false;
                CB_type2.Text = "Select a type";
                CB_value2.Text = "Select a value";
            }

            // Clear and add value from type
            CB_value1.Items.Clear();
            CB_value1.Text = "Select a value";
            string[] res = data.get_one_type(CB_type1.Text).ToArray();
            if (res != null) {
                CB_value1.Items.AddRange(res);
            } else {
                //TODO error db
            }
        }

        private void CB_type2_SelectedIndexChanged(object sender, EventArgs e) {
            ILV_photos.Items.Clear();
            update_status();

            // Clear and add value from type
            CB_value2.Items.Clear();
            CB_value2.Text = "Select a value";
            //string[] res = data.get_type(CB_type2.Text).ToArray();
            string[] res = data.get_two_type(CB_type1.Text, CB_value1.Text, CB_type2.Text).ToArray();

            if (res != null) {
                CB_value2.Items.AddRange(res);
            } else {
                //TODO error db
            }
        }

        #endregion

        #region Get files

        private void CB_value1_SelectedIndexChanged(object sender, EventArgs e) {

            // Reset the AND if not => Name
            // Set AND CB to enable = true if Name + value1
            if (CB_type1.Text == "Name" && CB_value1.Text != "Select a value") {
                CB_type2.Text = "Select a type";
                CB_value2.Text = "Select a value";
                CB_type2.Enabled = true;
                CB_value2.Enabled = true;
            } else {
                CB_type2.Enabled = false;
                CB_value2.Enabled = false;
                CB_type2.Text = "Select a type";
                CB_value2.Text = "Select a value";
            }

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
            update_status();
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
            update_status();
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
                            // Locate photo in Picture Windows folder
                            MessageBox.Show("locate");
                            string loc = locate.locate_file(file);
                            if (loc != string.Empty) {
                                ILV_photos.Items.Add(loc);
                            }
                        }
                    } else {

                        // If exist add it to the Image list
                        if (File.Exists(file)) {
                            ILV_photos.Items.Add(file);
                        } else {
                            // Locate photo in Picture Windows folder
                            MessageBox.Show("locate");
                            string loc = locate.locate_file(file);
                            if (loc != string.Empty) {
                                ILV_photos.Items.Add(loc);
                            }
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

        #region Save images

        /// <summary>
        /// Save current photos in ILV_photos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_save_all_Click(object sender, EventArgs e) {
            try {
                using (FolderBrowserDialog obd = new FolderBrowserDialog()) {

                    if (obd.ShowDialog() == DialogResult.OK) {
                        string dir = obd.SelectedPath;

                        // Get all photos from imagelistview
                        foreach (ImageListViewItem item in ILV_photos.Items) {

                            // Copy the files from the ILV to the selected directory
                            if (File.Exists(item.FileName)) {
                                File.Copy(item.FileName, $"{dir}\\{Path.GetFileName(item.FileName)}",true);
                            }
                        }
                        MessageBox.Show("Files saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            } catch { }
        }

        #endregion

        #region Open explorer and save

        /// <summary>
        /// Get items path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ILV_photos_ItemClick(object sender, ItemClickEventArgs e) {

            // Get file name when click
            item_path = e.Item.FileName;
        }

        /// <summary>
        /// Get items position and generate menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ILV_photos_MouseClick(object sender, MouseEventArgs e) {

            // Check right click
            if (e.Button == MouseButtons.Right) {

                // Get position hitted
                ImageListView.HitInfo hit_info;
                ILV_photos.HitTest(new Point(e.X, e.Y), out hit_info);
                int hitted = hit_info.ItemIndex;

                // Add the menu and check if an item is selected
                ContextMenuStrip cms = new ContextMenuStrip();
                if (hitted >= 0) {
                    cms.Items.Add("Open").Name = "open";
                    cms.Items.Add("Save").Name = "save";
                    cms.Show(ILV_photos, new Point(e.X, e.Y));
                    cms.ItemClicked += new ToolStripItemClickedEventHandler(cms_clicked);
                }
            }
        }

        /// <summary>
        /// Process menu items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cms_clicked(object sender, ToolStripItemClickedEventArgs e) {

            // Use sender to hide menu 
            ContextMenuStrip menu = (ContextMenuStrip)(sender);

            // Open in explorer or save file
            if (e.ClickedItem.Name == "open") {
                menu.Hide();
                explore_file(item_path);
            } else if (e.ClickedItem.Name == "save") {
                menu.Hide();
                save_one_photo(item_path);
            }
        }

        /// <summary>
        /// Open the Windows explorer and select a file
        /// </summary>
        /// <param name="path"></param>
        public void explore_file(string path) {
            if (File.Exists(path)) {

                //Clean up file path so it can be navigated OK
                path = Path.GetFullPath(path);
                System.Diagnostics.Process.Start("explorer.exe", string.Format("/select,\"{0}\"", path));
            }
        }

        /// <summary>
        /// Save one photo
        /// </summary>
        /// <param name="path"></param>
        private void save_one_photo(string path) {
            try {
                using (FolderBrowserDialog obd = new FolderBrowserDialog()) {
                    if (obd.ShowDialog() == DialogResult.OK) {

                        // Copy the files from the ILV to the selected directory
                        if (File.Exists(path)) {
                            File.Copy(path, $"{obd.SelectedPath}\\{Path.GetFileName(path)}");
                        }
                        MessageBox.Show("File saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            } catch { }
        }
        #endregion

        #region Export DB and image

        private void TSB_export_Click(object sender, EventArgs e) {
            ImportExport ie = new ImportExport();
            ie.ShowDialog();
        }
        #endregion
    }
}
