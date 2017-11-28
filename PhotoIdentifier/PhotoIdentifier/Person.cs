using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Manina.Windows.Forms;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace PhotoIdentifier {
    class Person {

        #region Vars
        private string person_app_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "person");
        private string name_path = "";
        private static Random rnd = new Random();
        public ImageListView ILV_photos;
        #endregion

        #region Add person

        /// <summary>
        /// Add person
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool add_person(string name) {
            if(!add_dir_name(name))
                return false;
            if(!copy_photos())
                return false;
            return true;
        }

        /// <summary>
        /// Create directory to store the person photos
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Copy photos
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get 256 hash from file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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

        #region Get files/directory

        /// <summary>
        /// Get photos path from person name
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string[] get_person_photos(string path) {
            return Directory.GetFiles(path, "*.*");
        }

        /// <summary>
        /// Get name and path from person directory
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> get_all_person() {
            Dictionary<string, string> person_name = new Dictionary<string, string>();
            string[] names = Directory.GetDirectories(person_app_path);
            foreach(string name in names) {
                string tmp_name = Path.GetFileName(name);
                if(tmp_name.Contains("_")) {
                    string[] parts = tmp_name.Split('_');
                    person_name.Add(tmp_name, parts[0]);
                }
            }
            return person_name;
        }
        #endregion

        #region Update person

        /// <summary>
        /// Update person photos
        /// </summary>
        /// <param name="lst_photos_add"></param>
        /// <param name="lst_photos_remove"></param>
        /// <returns></returns>
        public bool process_photos(List<string> lst_photos_add, List<string> lst_photos_remove, string name) {

            // Process addded photos
            foreach(string photo in lst_photos_add) {
                if(!add_photos(photo, name)) {
                    return false;
                }
            }

            // Process removed photos
            foreach(string photo in lst_photos_remove) {
                if(!remove_photos(photo)) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Add person photos
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool add_photos(string path, string name) {
            try {
                if(File.Exists(path)) {

                    // Get hash from file
                    string hash = get_hsah256_file(path);

                    // Check if hash could be calculated
                    if(hash != "") {

                        // Dest file
                        string dest = Path.Combine(person_app_path, name, (hash + Path.GetExtension(path)));
                        if(!File.Exists(dest)) {
                            File.Copy(path, dest, true);
                        }
                    } else {
                        return false;
                    }
                }
                return true;
            } catch { return false; }
        }

        /// <summary>
        /// Remove person photos
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool remove_photos(string path) {
            try {
                if(File.Exists(path)) {
                    File.Delete(path);
                }
                return true;
            } catch { return false; }
        }
        #endregion
    }
}
