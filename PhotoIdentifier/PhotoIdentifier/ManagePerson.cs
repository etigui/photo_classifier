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
    public partial class ManagePerson:Form {
        public ManagePerson() {
            InitializeComponent();
        }

        #region Vars
        private const string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\GitHub\semester_project\PhotoIdentifier\PhotoIdentifier\photos.mdf;Persist Security Info=True;Connect Timeout=30";
        private List<string> person_image = new List<string>();
        private string person_app_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "person");
        #endregion

        private void ManagePerson_Load(object sender, EventArgs e) {

            // Get name and path from person directory
            Dictionary<string, string> person_name = get_all_person();

            // Check if something in the dico
            if(person_name.Count() != 0) {

                // Add name to combobox
                CB_name.DataSource = new BindingSource(get_all_person(), null);
                CB_name.DisplayMember = "Value";
                CB_name.ValueMember = "Value";
                CB_name.ValueMember = "Key";
            } else {
                TSSL_infos.Text = "No person added";
                BT_validate.Enabled = false;
                CB_name.Enabled = false;
                TSB_add.Enabled = false;
                TSB_clear.Enabled = false;
                TSB_remove.Enabled = false;
            }
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

        #region Add/remove/clear photos

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

        #region Add person photos

        /// <summary>
        /// Add person of the selected photos
        /// </summary>
        private void add_person_photos() {
            ILV_photos.Items.Clear();
            KeyValuePair<string, string> item = (KeyValuePair<string, string>)CB_name.SelectedItem;
            string path = Path.Combine(person_app_path, item.Key);
            if(Directory.Exists(path)) {
                string[] files = get_person_photos(path);
                if(files != null) {
                    foreach(string file in files) {
                        if(File.Exists(file)) {
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

        #region Get files/directory

        /// <summary>
        /// Get photos path from person name
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string[] get_person_photos(string path) {
            return Directory.GetFiles(path, "*.*");
        }

        /// <summary>
        /// Get name and path from person directory
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> get_all_person() {
            Dictionary<string, string> person_name = new Dictionary<string, string>();
            string[] names = Directory.GetDirectories(person_app_path);
            foreach(string name in names) {
                string tmp_name = Path.GetFileName(name);
                if(tmp_name.Contains("_")) {
                    string[] parts = tmp_name.Split('_');
                    person_name.Add(tmp_name, parts[1]);
                }
            }
            return person_name;
        }
        #endregion

        #region Add/delete person photos

        private void BT_validate_Click(object sender, EventArgs e) {
        }

        private void process_delete_photos() {

        }

        private void preocess_add_photos() {

        }

        private void add_photo() {

        }

        private void delete_photo() {

        }
        #endregion

        /// <summary>
        /// Get all name and path from the person database
        /// </summary>
        /// <returns></returns>
        private void get_name_db() {

            // Get name + path
            using(SqlConnection conn = new SqlConnection(connection_string)) {
                conn.Open();
                string query = "SELECT name, path FROM person";
                using(SqlCommand cmd = new SqlCommand(query, conn)) {
                    using(SqlDataReader reader = cmd.ExecuteReader()) {

                        // Read all the name in the database
                        while(reader.Read()) {
                            //person_name.Add(reader["path"].ToString(), reader["name"].ToString());
                        }
                    }
                }
            }
        }
    }
}
