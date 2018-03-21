using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotosFinder {
    public partial class CopyFiles : Form {

        #region Vars
        private string identify_dir_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "identify");
        private string person_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "person");
        private List<string> files = null;
        private string db_path = string.Empty;
        private string dest = string.Empty;
        private int type = 0;
        private string source_path = string.Empty;
        BackgroundWorker bw = null;

        #endregion

        #region Init

        public CopyFiles(List<string> files, string db_path, string dest) {
            InitializeComponent();
            this.files = files;
            this.db_path = db_path;
            this.dest = dest;
            type = 2;
        }

        public CopyFiles(string source) {
            InitializeComponent();
            type = 1;
            source_path = source;
        }

        private void CopyFiles_Load(object sender, EventArgs e) {
            if (type == 1) {

                // Import
                import();
            } else if (type == 2) {

                // Export
                export();
            }
        }

        private void init_bw() {
            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_process_changed);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_worker_completed);
        }

        #endregion

        #region Controls

        private void BT_cancel_Click(object sender, EventArgs e) {
            this.Close();
        }
        #endregion

        #region Import

        private void import() {
            init_bw();
            bw.DoWork += new DoWorkEventHandler(bw_import);
            PB_status.Maximum = 5;
            bw.RunWorkerAsync();
        }

        private void bw_import(object sender, DoWorkEventArgs e) {
            string extract_path = string.Empty;
            try {

                // Clean up if import error
                extract_path = Path.Combine(Path.GetDirectoryName(source_path), "__tmp");
                if (Directory.Exists(extract_path)) {
                    Directory.Delete(extract_path, true);
                }

                // Create path to extract the data (current directory)
                if (LB_status_up.InvokeRequired) { Invoke((MethodInvoker)(() => LB_status_up.Text = "Unzip files")); }
                if (Lb_status_down.InvokeRequired) { Invoke((MethodInvoker)(() => Lb_status_down.Text = $"Process file: {source_path}")); }
                bw.ReportProgress(1);
                Directory.CreateDirectory(extract_path);

                // Extract ZIP in current directory
                ZipFile.ExtractToDirectory(source_path, extract_path);

                // Move DB
                if (LB_status_up.InvokeRequired) { Invoke((MethodInvoker)(() => LB_status_up.Text = "Move database file")); }
                if (Lb_status_down.InvokeRequired) { Invoke((MethodInvoker)(() => Lb_status_down.Text = $"Process file: {Path.Combine(extract_path, "__photos.db")}")); }
                bw.ReportProgress(2);
                string db_dest = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "photos.db");
                if (File.Exists(db_dest)) {
                    File.Delete(db_dest);
                }
                File.Move(Path.Combine(extract_path, "__photos.db"), db_dest);


                // Move exe config file
                string conf_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "app_conf.xml");
                if (File.Exists(conf_path)) {
                    File.Delete(conf_path);
                }
                File.Move(Path.Combine(extract_path, "__app_conf.xml"), conf_path);

                // Move prog conf file
                string conf_exe_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "PhotoIdentifier.exe.config");
                if (File.Exists(conf_exe_path)) {
                    File.Delete(conf_exe_path);
                }
                File.Move(Path.Combine(extract_path, "__PhotoIdentifier.exe.config"), conf_exe_path);

                // Move person photo
                bw.ReportProgress(3);
                string temp_person = Path.Combine(extract_path, "__person");
                if (Directory.Exists(temp_person)) {
                    if (LB_status_up.InvokeRequired) { Invoke((MethodInvoker)(() => LB_status_up.Text = "Move person photos")); }
                    if (Lb_status_down.InvokeRequired) { Invoke((MethodInvoker)(() => Lb_status_down.Text = $"Process directory: {Path.Combine(extract_path, "__person")}")); }
                    if (Directory.Exists(person_path)) {
                        Directory.Delete(person_path, true);
                    }
                    Directory.Move(temp_person, person_path);
                }

                // Move photo directory to SpecialFolder => MyPictures
                string[] directories = Directory.GetDirectories(extract_path);
                bw.ReportProgress(4);
                foreach (string dir in directories) {
                    if (LB_status_up.InvokeRequired) { Invoke((MethodInvoker)(() => LB_status_up.Text = "Move identified photos")); }
                    if (Lb_status_down.InvokeRequired) { Invoke((MethodInvoker)(() => Lb_status_down.Text = $"Process directory: {dir}")); }
                    string id_path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + $"\\{Path.GetFileName(dir)}";
                    if (Directory.Exists(id_path)) {
                        Directory.Delete(id_path, true);
                    }
                    Directory.Move(dir, id_path);
                }

                // Delete the rest
                //Directory.Delete(extract_path);
                bw.ReportProgress(5);
            } catch (Exception ex) { Console.WriteLine(ex.ToString()); MessageBox.Show("Fatal error. Try to import again.", "Import error", MessageBoxButtons.OK, MessageBoxIcon.Error); } finally {
                Directory.Delete(extract_path, true);
            }

        }
        #endregion

        #region Export

        private void export() {
            init_bw();
            bw.DoWork += new DoWorkEventHandler(bw_export);
            PB_status.Maximum = files.Count() * 2;
            bw.RunWorkerAsync();
        }

        private void bw_export(object sender, DoWorkEventArgs e) {
            try {

                // Check if path exist
                if (File.Exists(db_path) && Directory.Exists(dest) && Directory.Exists(person_path)) {

                    // Invoke label
                    if (LB_status_up.InvokeRequired) { Invoke((MethodInvoker)(() => LB_status_up.Text = "Copy files")); }

                    // Create new directory destination
                    dest = Path.Combine(dest, $"export_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}");
                    Directory.CreateDirectory(dest);

                    // Copy DB file
                    File.Copy(db_path, Path.Combine(dest, $"__{Path.GetFileName(db_path)}"), true);

                    // Copy conf file
                    string conf_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "app_conf.xml");
                    if (File.Exists(conf_path)) {
                        File.Copy(conf_path, Path.Combine(dest, "__app_conf.xml"));
                    }

                    // Copy PhotoIdentifier.exe.config file
                    string conf_exe_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "PhotoIdentifier.exe.config");
                    if (File.Exists(conf_exe_path)) {
                        File.Copy(conf_exe_path, Path.Combine(dest, "__PhotoIdentifier.exe.config"));
                    }

                    // Copy person directory
                    export_person(dest);

                    // Copy photo directory
                    export_photo(dest);

                    // Zip the directory
                    if (LB_status_up.InvokeRequired) { Invoke((MethodInvoker)(() => LB_status_up.Text = "Zip files")); }
                    if (Lb_status_down.InvokeRequired) { Invoke((MethodInvoker)(() => Lb_status_down.Text = $"Process file: {Path.GetFileName(dest)}.zip")); }
                    ZipFile.CreateFromDirectory(dest, Path.Combine(Path.GetDirectoryName(dest), $"{Path.GetFileName(dest)}.zip"));

                    bw.ReportProgress((files.Count() * 2) - 2);

                    // Delete destination directory (recursive)
                    if (LB_status_up.InvokeRequired) { Invoke((MethodInvoker)(() => LB_status_up.Text = "Delete files")); }
                    if (Lb_status_down.InvokeRequired) { Invoke((MethodInvoker)(() => Lb_status_down.Text = $"Process directory: {dest}")); }
                    Directory.Delete(dest, true);
                } else {
                    MessageBox.Show("DB path, destination path or person path not exist", "Export error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch { MessageBox.Show("Fatal error. Try to export again.", "Export error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void export_photo(string dst) {

            // Copy files
            int i = 1;
            foreach (string file in files) {

                // Invoke label
                if (Lb_status_down.InvokeRequired) { Invoke((MethodInvoker)(() => Lb_status_down.Text = $"Process file: {Path.GetFileName(file)}")); }
                bw.ReportProgress(i);
                if (File.Exists(file)) {

                    // Dont copy if hidden file
                    FileInfo info = new FileInfo(file);
                    if (!info.Attributes.HasFlag(FileAttributes.Hidden)) {

                        // Get path where the file is
                        string add = Path.GetDirectoryName(file).Replace(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), string.Empty);

                        // Remove \\ at first to be able to combine path
                        if (add.StartsWith(@"\")) {
                            add = add.TrimStart('\\');
                        }

                        // Create directory if not exist
                        Directory.CreateDirectory(Path.Combine(dst, add));

                        // Copy file
                        File.Copy(file, Path.Combine(dst, add, Path.GetFileName(file)), true);
                    }
                }
                i++;
            }
        }

        private void export_person(string dst) {

            if (Directory.Exists(person_path)) {

                // Get recursive person file
                string[] ps = Directory.GetFiles($"{person_path}\\", "*.*", SearchOption.AllDirectories);

                // Create __person directory
                string new_person_dest = Path.Combine(dst, "__person");
                Directory.CreateDirectory(new_person_dest);

                // Get all person file
                foreach (string p in ps) {
                    if (File.Exists(p)) {

                        // Dont copy if hidden file
                        FileInfo info = new FileInfo(p);
                        if (!info.Attributes.HasFlag(FileAttributes.Hidden)) {

                            // Get curretn directory
                            string add = Path.GetDirectoryName(p).Replace(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "person"), string.Empty);

                            // Remove \\ at first to be able to combine path
                            if (add.StartsWith(@"\")) {
                                add = add.TrimStart('\\');
                            }

                            // Create directory if not exist
                            Directory.CreateDirectory(Path.Combine(new_person_dest, add));

                            // Copy person directory
                            File.Copy(p, Path.Combine(new_person_dest, add, Path.GetFileName(p)), true);

                        }
                    }
                }
            }
        }
        #endregion

        #region Backgroudwroker function

        private void bw_worker_completed(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                //lblStatus.Text = "Process was cancelled";
            } else if (e.Error != null) {
                //lblStatus.Text = "There was an error running the process. The thread aborted";
            } else {
                //lblStatus.Text = "Process was completed";
                this.Close();
            }
        }

        private void bw_process_changed(object sender, ProgressChangedEventArgs e) {
            PB_status.Value = e.ProgressPercentage;
        }
        #endregion
    }
}
