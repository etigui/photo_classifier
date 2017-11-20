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
        private Dictionary<string, string> person_name = new Dictionary<string, string>();
        private List<string> person_image = new List<string>();
        private string exec_path = Path.GetDirectoryName(Application.ExecutablePath);
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

        private void BT_validate_Click(object sender, EventArgs e) {
        }

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
                            person_name.Add(reader["path"].ToString(), reader["name"].ToString());
                        }
                    }
                }
            }
        }
        
        private void ManagePerson_Load(object sender, EventArgs e) {

            //Get name and path from databse
            get_name_db();

            // Add name to combobox
            
            CB_name.DataSource = new BindingSource(person_name, null);
            CB_name.DisplayMember = "Value";
            CB_name.ValueMember = "Value";
            CB_name.ValueMember = "Key";
            CB_name.Text = "Select name";
        }

        private void CB_name_SelectionChangeCommitted(object sender, EventArgs e) {
            ILV_photos.Items.Clear();
            KeyValuePair<string, string> item = (KeyValuePair<string, string>)CB_name.SelectedItem;
            string path = Path.Combine(exec_path, "person", item.Key);

            foreach(string file in Directory.GetFiles(path, "*.*")) {
                ILV_photos.Items.Add(file);
            }
        }
    }
}
