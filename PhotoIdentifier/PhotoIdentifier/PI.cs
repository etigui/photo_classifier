using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Manina.Windows.Forms;
using System.Net.NetworkInformation;
using PhotoIdentifier.Properties;

namespace PhotoIdentifier {
    public partial class PI : Form {

        #region vars
        private readonly IFaceServiceClient faceServiceClient = new FaceServiceClient(Resources.face_api_key.ToString(), "https://westeurope.api.cognitive.microsoft.com/face/v1.0");
        private string conf_file_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "app_conf.xml");
        private bool internet_connection = false;
        private Conf conf;
        string identify_dir_path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

        #endregion

        #region Init

        public PI() {
            InitializeComponent();
            init();
            //string pathss = @"C:\Users\Admin\GitHub\semester_project\PhotoIdentifier\PhotoIdentifier\bin\Debug\person\obama_vjkfesnbkjld";
            //IEnumerable<string> ss = Directory.GetFiles(pathss, "*.*").Where(file => !string.Equals(file, ".zip", StringComparison.InvariantCultureIgnoreCase));//.Where(name => !name.EndsWith(".id"));
            //List<string> files = Directory.EnumerateFiles(pathss, "*.*",SearchOption.AllDirectories).Where(n => Path.GetExtension(n) != ".id").ToList();
        }

        private void init() {

            // Set from size
            this.Width = 750;
            this.Height = 555;

            //Init thumbnails size tick
            x96ToolStripMenuItem.Checked = true;

            // Add all details
            foreach (ImageListView.ImageListViewColumnHeader c in ILV_photos.Columns) {
                c.Visible = true;
            }

            // Check internet
            check_internet();

            // Create config file
            conf = new Conf(conf_file_path);

            // Creat person dir if not exist
            string person_dir_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "person");
            if (!Directory.Exists(person_dir_path)) {
                Directory.CreateDirectory(person_dir_path);
            }

            // Create identify if not exist
            //string identify_dir_path = conf.read_identify_path();
            //if(!Directory.Exists(identify_dir_path)) {
            //   Directory.CreateDirectory(identify_dir_path);
            //}
        }

        #endregion

        #region Controls


        private void TSB_person_Click(object sender, EventArgs e) {
            AddPerson ap = new AddPerson();
            ap.ShowDialog();
        }

        private void TSB_manage_person_Click(object sender, EventArgs e) {
            ManagePerson mp = new ManagePerson();
            mp.ShowDialog();
        }

        private void TSB_search_Click(object sender, EventArgs e) {
            string photos_finder_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"PhotosFinder.exe");
            if (File.Exists(photos_finder_path)) {

                //Lunch or not the PhotoFinder program
                if (MessageBox.Show("Do you want to lunch PhotoFinder ?", "Lunch", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    Process.Start(photos_finder_path);
                }
            }
        }
        #endregion

        #region Add/remove/clear images

        private void TSB_add_Click(object sender, EventArgs e) {

            // Add photos to the list
            //conf.read_identify_path()
            OpenFileDialog ofd = new OpenFileDialog {
                Multiselect = true,
                InitialDirectory = identify_dir_path,
                Filter = "JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|GIF files (*.gif)|*.gif|BMP files (*.bmp)|*.bmp|JPEG files (*.jpeg)|*.jpeg|All files (*.*)|*.*"
            };
            if (ofd.ShowDialog() == DialogResult.OK) {

                // Check if the photo prive from Picture directory
                if (check_picture_directory(ofd.FileNames)) {

                    // Check no error in type, dimention, size
                    if (!check_file_type(ofd.FileNames)) {
                        ILV_photos.Items.AddRange(ofd.FileNames);
                        TSB_clear.Enabled = true;
                        TSB_remove.Enabled = true;
                        update_status();
                    } else {
                        MessageBox.Show($"Files size must be lower than 4Mb.{Environment.NewLine + Environment.NewLine}File dimension must be greater than 50x50 and lower than 4000x4000.{Environment.NewLine + Environment.NewLine}Only format jpg, jpeg, png, gif and bmp are allowed.", "Files error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    MessageBox.Show("All the photo must be provied from the Windows Picture directory", "Photo error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Check if the photo are from Picture directory
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        private bool check_picture_directory(string[] files) {
            foreach (string file in files) {
                if (!file.Contains(identify_dir_path)) {
                    return false;
                }
            }
            return true;
        }
        private void TSB_remove_Click(object sender, EventArgs e) {

            // Suspend the layout logic while we are removing items. Otherwise the control will be refreshed after each item is removed.
            ILV_photos.SuspendLayout();

            // Remove selected items
            foreach (var item in ILV_photos.SelectedItems)
                ILV_photos.Items.Remove(item);

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

        #region Change thumbnails style

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

        #region Rotate image right/left

        /*private void TSB_left_Click(object sender, EventArgs e) {
            if(ILV_photos.SelectedItems.Count != 0) {
                if(MessageBox.Show("Rotating will overwrite original images. Are you sure you want to continue?", "Rotate left", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
                    foreach(ImageListViewItem item in ILV_photos.SelectedItems) {
                        item.BeginEdit();
                        using(Image img = Image.FromFile(item.FileName)) {
                            img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            img.Save(item.FileName);
                        }
                        item.Update();
                        item.EndEdit();
                    }
                }
            }
        }

        private void TSB_right_Click(object sender, EventArgs e) {
            if(ILV_photos.SelectedItems.Count != 0) {
                if(MessageBox.Show("Rotating will overwrite original images. Are you sure you want to continue?", "Rotate right", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
                    foreach(ImageListViewItem item in ILV_photos.SelectedItems) {
                        item.BeginEdit();
                        using(Image img = Image.FromFile(item.FileName)) {
                            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            img.Save(item.FileName);
                        }
                        item.Update();
                        item.EndEdit();
                    }
                }
            }
        }*/

        #endregion

        #region Photos identify

        private void TSB_identify_Click(object sender, EventArgs e) {

            //Lunch the identification ?
            if (MessageBox.Show("Do you want to identify the current photos ?", "Identify", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                // Check if the list is not empty
                if (ILV_photos.Items.Count != 0) {

                    // Check internet connection
                    if (internet_connection) {

                        // Start identification
                        Identify identify = new Identify {
                            photos_to_identify = ILV_photos
                        };
                        identify.ShowDialog();
                        ILV_photos.Items.Clear();
                        update_status();
                        TSB_clear.Enabled = false;
                        TSB_remove.Enabled = false;

                        //TODO clear ILV_photos (The current identification is already done) ?
                    } else {
                        MessageBox.Show("No Internet connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    MessageBox.Show("No photos to identify", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Check internet

        /// <summary>
        /// Callback for check_internet function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ping_completed_callback(object sender, PingCompletedEventArgs e) {
            if (e.Cancelled) {
                MessageBox.Show("No internet connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            } else if (e.Error != null) {
                MessageBox.Show("No internet connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            } else if (e.Reply.Status == IPStatus.Success) {
                internet_connection = true;
                TSB_identify.Enabled = true;
            }
        }

        /// <summary>
        /// Check connection (ping google for 3 sec)
        /// </summary>
        private void check_internet() {
            Ping myPing = new Ping();
            myPing.PingCompleted += new PingCompletedEventHandler(ping_completed_callback);
            try {

                //Ping google for 3 sec
                myPing.SendAsync("google.com", 3000, new byte[32], new PingOptions(64, true));
            } catch {
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
