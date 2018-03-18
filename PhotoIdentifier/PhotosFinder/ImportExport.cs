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

namespace PhotosFinder {
    public partial class ImportExport : Form {
        public ImportExport() {
            InitializeComponent();
        }

        #region Vars
        private string identify_dir_path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        private string connection_string = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "photos.db");
        #endregion

        #region Import

        private void BT_import_Click(object sender, EventArgs e) {

            string db_path = TB_database_import.Text;
            string photo_path = TB_photo_import.Text;
            if (File.Exists(db_path) && Directory.Exists(photo_path)) {

                // Get recursive files
                string[] files = Directory.GetFiles($"{photo_path}\\", "*.*", SearchOption.AllDirectories);

                // TODO Background Worker copy
                // Copy db_path => connection_string
                // Copy files => identify_dir_path
            } else {
                MessageBox.Show("Import paths error");
            }
        }

        private void BT_photo_import_Click(object sender, EventArgs e) {
            get_photo_directory(true);
        }

        private void BT_database_import_Click(object sender, EventArgs e) {
            get_database();
        }
        #endregion

        #region Export

        private void BT_export_Click(object sender, EventArgs e) {

            string db_path = connection_string;
            string photo_path = TB_photo_export.Text;
            string dest = TB_dest.Text;
            if (File.Exists(db_path) && Directory.Exists(photo_path)) {

                // Get recursive files
                string[] files = Directory.GetFiles($"{photo_path}\\", "*.*", SearchOption.AllDirectories);

                // ZIP all data or save in directory
                if (CB_zip.Checked) {
                    // TODO Background Worker copy
                } else {
                    // TODO Background Worker copy
                    foreach (string file in files) {

                    }
                }
            } else {
                MessageBox.Show("Export paths error");
            }
        }

        private void BT_photo_export_Click(object sender, EventArgs e) {
            get_photo_directory(false);
        }

        private void BT_dest_Click(object sender, EventArgs e) {
            get_destination();
        }
        #endregion

        #region Import/Export function

        /// <summary>
        /// Get save destination
        /// </summary>
        private void get_destination() {

            // If checked => ZIP
            if (CB_zip.Checked) {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "ZIP file (*.zip)|*.zip";
                if (sfd.ShowDialog() == DialogResult.OK) {
                    TB_dest.Text = sfd.FileName;
                    TB_dest.Focus();
                    TB_dest.SelectionStart = TB_dest.Text.Length;
                }
            } else {
                FolderBrowserDialog fbd = new FolderBrowserDialog();

                if (fbd.ShowDialog() == DialogResult.OK) {
                    TB_dest.Text = fbd.SelectedPath;
                    TB_dest.Focus();
                    TB_dest.SelectionStart = TB_dest.Text.Length;
                }
            }
        }

        /// <summary>
        /// Set db path
        /// </summary>
        private void get_database() {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK) {
                TB_database_import.Text = ofd.FileName;
                TB_database_import.Focus();
                TB_database_import.SelectionStart = TB_database_import.Text.Length;
            }
        }

        /// <summary>
        /// Set photo directory path
        /// </summary>
        /// <param name="import"></param>
        private void get_photo_directory(bool import) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK) {

                // Check if import or export tab
                if (import) {
                    TB_photo_import.Text = fbd.SelectedPath;
                    TB_photo_import.Focus();
                    TB_photo_import.SelectionStart = TB_photo_import.Text.Length;
                } else {
                    TB_photo_export.Text = fbd.SelectedPath;
                    TB_photo_export.Focus();
                    TB_photo_export.SelectionStart = TB_photo_export.Text.Length;
                }
            }
        }

        /// <summary>
        /// Get when tab index chnage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TC_switch_SelectedIndexChanged(object sender, EventArgs e) {

            // Auto fill export info
            if (TC_switch.SelectedTab.Text == "Export") {

                // Auto fill data
                TB_photo_export.Text = identify_dir_path;

                // Setting cursor at the end of any text of a textbox
                TB_photo_export.Focus();
                TB_photo_export.SelectionStart = TB_photo_export.Text.Length;
            }
        }
        #endregion

        #region Key press no effect

        private void TB_database_export_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = true;
        }

        private void TB_photo_export_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = true;
        }

        private void TB_database_import_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = true;
        }

        private void TB_photo_import_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = true;
        }
        private void TB_dest_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = true;
        }
        #endregion

    }
}
