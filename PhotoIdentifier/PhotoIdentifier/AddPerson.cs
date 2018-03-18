using Manina.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoIdentifier {
    public partial class AddPerson : Form {

        #region Vars
        private Person person = null;
        #endregion

        #region Init

        public AddPerson() {
            InitializeComponent();
        }
        private void AddPerson_Load(object sender, EventArgs e) {
            person = new Person();
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

        #region Add/remove/clear images

        private void TSB_add_Click(object sender, EventArgs e) {

            // Add photos to the list
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|GIF files (*.gif)|*.gif|BMP files (*.bmp)|*.bmp|JPEG files (*.jpeg)|*.jpeg";
            if (ofd.ShowDialog() == DialogResult.OK) {

                // Check no error in type, dimention, size
                if (!check_file_type(ofd.FileNames)) {
                    ILV_photos.Items.AddRange(ofd.FileNames);
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

                // Get file size (Image file size: Less than 4 MB)
                if (new FileInfo(file).Length >= 4000000) {
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
            string[] ext = new string[] { ".jpg", ".png", ".gif", ".bmp", ".jpeg" };

            if (File.Exists(file)) {
                // Check if the droped file are with good extention
                if (!Array.Exists(ext, ex => ex == Path.GetExtension(file))) {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Add person

        private void BT_add_Click(object sender, EventArgs e) {

            // Check if only letter in the textbox
            if (TB_name.Text.All(Char.IsLetter)) {

                // Check if textbox is not empty
                if (!String.IsNullOrEmpty(TB_name.Text)) {

                    // Check if added photos
                    if (ILV_photos.Items.Count() != 0) {

                        // Add person
                        person.ILV_photos = ILV_photos;
                        if (person.add_person(TB_name.Text)) {
                            MessageBox.Show($"The person '{TB_name.Text}' has been created", "Person created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear fild for new person
                            TB_name.Text = "";
                            ILV_photos.Items.Clear();
                            TSB_clear.Enabled = false;
                            TSB_remove.Enabled = false;
                            update_status();
                        } else {
                            MessageBox.Show("Fatal error. Creation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else {
                        MessageBox.Show("You must add image to identify that person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    MessageBox.Show("You must add a name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("The name must me only letter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TB_name_TextChanged(object sender, EventArgs e) {

            // Check if only letter in the textbox
            if (!TB_name.Text.All(Char.IsLetter)) {
                TB_name.BackColor = Color.Red;
            } else {
                TB_name.BackColor = Color.White; ;
            }
        }
        #endregion
    }
}
