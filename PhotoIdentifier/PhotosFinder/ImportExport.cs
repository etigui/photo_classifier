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

        #region Vars
        private string identify_dir_path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        private string connection_string = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "photos.db");
        private string person_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "person");
        DataGet data_get;
        #endregion

        #region Init

        public ImportExport() {
            InitializeComponent();
            data_get = new DataGet();
        }
        #endregion

        #region Import

        private void BT_import_Click(object sender, EventArgs e) {

            string source = TB_source.Text;
            if (File.Exists(source)) {

                // TODO Background Worker copy
                // Copy db_path => connection_string
                // Copy files => identify_dir_path
                //Import or not
                if (MessageBox.Show($"Do you want to import the new data ? {Environment.NewLine}Warning: All the current data will be overwritten, so think to backup them before to import.", "Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    CopyFiles cpf = new CopyFiles(source);
                    cpf.ShowDialog();
                    this.Hide();
                }
            } else {
                MessageBox.Show("Import paths error");
            }
        }

        private void BT_database_import_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK) {
                TB_source.Text = ofd.FileName;
                TB_source.Focus();
                TB_source.SelectionStart = TB_source.Text.Length;
            }
        }
        #endregion

        #region Export

        private void BT_export_Click(object sender, EventArgs e) {

            string db_path = connection_string;
            //string photo_path = TB_photo_export.Text;
            string dest = TB_dest.Text;

            if (File.Exists(db_path)) {

                // Get all files from db
                List<string> files = data_get.get_all_photo();

                // ZIP all data or save in directory
                CopyFiles cpf = new CopyFiles(files.ToList(), db_path, dest);
                cpf.ShowDialog();
                this.Hide();
            } else {
                MessageBox.Show("Export or photo paths error");
            }
        }

        /// <summary>
        /// Get save destination
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_dest_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK) {
                TB_dest.Text = fbd.SelectedPath;
                TB_dest.Focus();
                TB_dest.SelectionStart = TB_dest.Text.Length;
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
