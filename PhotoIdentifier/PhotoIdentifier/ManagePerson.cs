using Manina.Windows.Forms;
using PhotoIdentifier.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoIdentifier {
    public partial class ManagePerson : Form {

        #region Vars
        private string person_app_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "person");
        List<string> lst_photos_add = new List<string>();
        List<string> lst_photos_remove = new List<string>();
        Person person = null;
        #endregion

        #region Init

        public ManagePerson() {
            InitializeComponent();
        }

        private void ManagePerson_Load(object sender, EventArgs e) {

            person = new Person();

            // Get name and path from person directory
            Dictionary<string, string> person_name = person.get_all_person();

            // Check if something in the dico
            if (person_name.Count() != 0) {

                // Add name to combobox
                CB_name.DataSource = new BindingSource(person_name, null);
                CB_name.DisplayMember = "Value";
                CB_name.ValueMember = "Value";
                TSB_clear.Enabled = true;
                TSB_remove.Enabled = true;
            } else {
                TSSL_infos.Text = "No person added";
                BT_validate.Enabled = false;
                CB_name.Enabled = false;
                TSB_add.Enabled = false;
                TSB_clear.Enabled = false;
                TSB_remove.Enabled = false;
            }
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

        #region Add/remove/clear photos

        private void TSB_add_Click(object sender, EventArgs e) {

            // Add photos to the list
            OpenFileDialog ofd = new OpenFileDialog {
                Multiselect = true,
                Filter = "JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|GIF files (*.gif)|*.gif|BMP files (*.bmp)|*.bmp|JPEG files (*.jpeg)|*.jpeg|All files (*.*)|*.*"
            };
            if (ofd.ShowDialog() == DialogResult.OK) {

                // Check no error in type, dimention, size
                if (!check_file_type(ofd.FileNames)) {

                    // Photos added
                    ILV_photos.Items.AddRange(ofd.FileNames);
                    lst_photos_add.AddRange(ofd.FileNames);
                    TSB_clear.Enabled = true;
                    TSB_remove.Enabled = true;
                    update_status();
                } else {
                    MessageBox.Show($"Files size must be lower than 4Mb.{Environment.NewLine + Environment.NewLine}File dimension must be greater than 50x50 and lower than 4000x4000.{Environment.NewLine + Environment.NewLine}Only format jpg, jpeg, png, gif and bmp are allowed.", "Files error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TSB_remove_Click(object sender, EventArgs e) {

            // Suspend the layout logic while we are removing items. Otherwise the control will be refreshed after each item is removed.
            ILV_photos.SuspendLayout();

            // Remove selected items
            foreach (var item in ILV_photos.SelectedItems) {
                ILV_photos.Items.Remove(item);

                // Photos remove
                lst_photos_remove.Add(item.FileName);
            }

            // Resume layout logic.
            ILV_photos.ResumeLayout(true);
            update_status();
        }

        private void TSB_clear_Click(object sender, EventArgs e) {

            // Get all photos from imagelistview
            foreach (ImageListViewItem item in ILV_photos.Items) {

                // Photos remove all
                lst_photos_remove.Add(item.FileName);
            }
            ILV_photos.Items.Clear();
            update_status();
        }
        #endregion

        #region Update status bar

        /// <summary>
        /// Get how many photo selected
        /// </summary>
        private void update_status() {
            if (ILV_photos.Items.Count == 0) {
                update_status("No photos");
            } else if (ILV_photos.SelectedItems.Count == 0) {
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

        #region Add person photos

        /// <summary>
        /// Add person of the selected photos
        /// </summary>
        private void add_person_photos() {
            ILV_photos.Items.Clear();
            ILV_photos.ClearThumbnailCache();

            // Get current person name
            KeyValuePair<string, string> item = (KeyValuePair<string, string>)CB_name.SelectedItem;
            string path = Path.Combine(person_app_path, item.Key);
            if (Directory.Exists(path)) {
                string[] files = person.get_person_photos(path);
                if (files != null) {
                    foreach (string file in files) {
                        if (File.Exists(file)) {
                            ILV_photos.Items.Add(file);
                        }
                    }
                }
            }
        }

        private void CB_name_SelectedIndexChanged(object sender, EventArgs e) {
            add_person_photos();
        }
        #endregion

        #region Update photos

        private void BT_validate_Click(object sender, EventArgs e) {

            // Check if user modify something
            if ((lst_photos_add.Count() != 0) || (lst_photos_remove.Count() != 0)) {
                DialogResult dialogResult = MessageBox.Show("Are you sure you to save the modification ?", "Modify ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes) {

                    // Get current person name
                    KeyValuePair<string, string> item = (KeyValuePair<string, string>)CB_name.SelectedItem;

                    // Check if could update the person
                    if (!person.process_photos(lst_photos_add, lst_photos_remove, item.Key)) {
                        MessageBox.Show("The person could not be modified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else {
                        MessageBox.Show("Modification saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lst_photos_add.Clear();
                        lst_photos_remove.Clear();
                        add_person_photos();
                    }
                }
            }
        }
        #endregion

        #region Check files type

        /// <summary>
        /// Check file info
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        private bool check_file_type(string[] files) {

            // Get all drag and drop file
            bool error = false;
            foreach (string file in files) {
                if (!check_file_dim(file)) {
                    error = true;
                }
                if (!check_file_size(file)) {
                    error = true;
                }
                if (!check_file_ext(file)) {
                    error = true;
                }
            }
            return error;
        }

        /// <summary>
        /// Check file dimention size
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool check_file_dim(string file) {
            if (File.Exists(file)) {
                // Get image dimention (Image dimension: Greater than 50 x 50 pixels)
                Image img = null;
                img = Image.FromFile(file);
                if ((img.Width <= 50) || (img.Height <= 50)) {
                    return false;
                }

                // (Image dimension: Lower than 4096 x 4096 pixels)
                if ((img.Width >= 4000) || (img.Height >= 4000)) {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Get max file size
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool check_file_size(string file) {
            if (File.Exists(file)) {
                long size = new FileInfo(file).Length;
                // Get file size (Image file size: Less than 4 MB or Greater than 1Kb)
                if (size >= 4000000 || size <= 1000) {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check file extention
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool check_file_ext(string file) {
            string[] ext = new string[] { ".jpg", ".png", ".gif", ".bmp", ".jpeg", ".JPG", ".PNG", ".GIF", ".BMP", ".JPEG" };

            if (File.Exists(file)) {
                // Check if the droped file are with good extention
                if (!Array.Exists(ext, ex => ex == Path.GetExtension(file))) {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}