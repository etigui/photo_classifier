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
    public partial class AddPerson:Form {
        public AddPerson() {
            InitializeComponent();
        }

        #region Vars
        private Person person;
        private string person_app_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "person");
        private string name_path = "";
        private static Random rnd = new Random();
        #endregion

        private void AddPerson_Load(object sender, EventArgs e) {
            //person = new Person();
        }

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

        #region Add person

        private void BT_add_Click(object sender, EventArgs e) {

            add_person(TB_name.Text);

            /*// Check if only letter in the textbox
            if(TB_name.Text.All(Char.IsLetter)) {

                // Check if textbox is not empty
                if(!String.IsNullOrEmpty(TB_name.Text)) {

                    // Check if added photos
                    if(ILV_photos.Items.Count() != 0) {

                        // Add person to database
                        person.ILV_photos = ILV_photos;
                        if(person.add_person(TB_name.Text)) {
                            MessageBox.Show($"The person '{TB_name.Text}' has been created", "Person created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear fild for new person
                            TB_name.Text = "";
                            ILV_photos.Items.Clear();
                            update_status();
                        }
                    } else {
                        MessageBox.Show("You must add image to identify that person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    MessageBox.Show("You must add a name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("The name must me only letter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void TB_name_TextChanged(object sender, EventArgs e) {

            // Check if only letter in the textbox
            if(!TB_name.Text.All(Char.IsLetter)) {
                TB_name.BackColor = Color.Red;
            } else {
                TB_name.BackColor = Color.White; ;
            }
        }
        #endregion

        #region test

        public bool add_person(string name) {
            if(!add_dir_name(name))
                return false;
            if(!copy_photos())
                return false;
            return true;
        }

        private bool add_dir_name(string name) {
            try {

                // Dir will be created to store the photos
                name_path = $"{name}_{get_random(10)}";

                // Create specific directory
                string dir = Path.Combine(person_app_path, name_path);
                if(!Directory.Exists(dir)) {
                    Directory.CreateDirectory(dir);
                } else {

                    // If fail create new dir
                    name_path = $"{name}_{get_random(20)}";
                    Directory.CreateDirectory(Path.Combine(person_app_path, name_path));
                }
                return true;
            } catch { return false; }
        }

        private bool copy_photos() {
            try {
                // Get all photos from imagelistview
                foreach(ImageListViewItem item in ILV_photos.Items) {

                    // Get source file
                    string source = item.FileName;

                    // Copy photo to specific directory
                    if(File.Exists(source)) {

                        // Get hash from source file
                        string hash = get_hsah256_file(source);

                        // Dest file
                        string source_ext = Path.GetFileNameWithoutExtension(item.FileName);
                        string dest = Path.Combine(person_app_path, name_path, (hash + Path.GetExtension(item.FileName)));

                        // Check if hash could be calculated
                        if(hash != "") {
                            if(!File.Exists(dest))
                                File.Copy(source, dest, true);
                        } else {
                            return false;
                        }
                    } else {
                        return false;
                    }
                }
                return true;
            } catch { MessageBox.Show("ddd"); return false; }
        }

        /// <summary>
        /// Get random string
        /// </summary>
        /// <param name="length">Random length</param>
        /// <returns></returns>
        private string get_random(int length) {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

        private string get_hsah256_file(string path) {
            string hash = "";
            try {

                // Create a fileStream for the file.
                using(FileStream fs = new FileStream(path, FileMode.Open)) {

                    // Initialize a SHA256 hash object.
                    SHA256 hash_256 = SHA256Managed.Create();

                    // Be sure it's positioned to the beginning of the stream.
                    fs.Position = 0;

                    // Compute the hash of the fileStream.
                    hash = BitConverter.ToString(hash_256.ComputeHash(fs)).Replace("-", String.Empty);
                }
                return hash;
            } catch { return ""; }
        }
        #endregion
    }
}
