using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PhotosFinder {
    class Locate {

        #region Vars
        private string identify_dir_path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        DataGet data;
        #endregion

        #region Init

        public Locate() {
            init();
        }

        private void init() {
            data = new DataGet();
        }

        #endregion

        #region Locate file

        /// <summary>
        /// Locate lost file (moved)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string locate_file(string path) {

            // Check if the file is found
            Tuple<string, string> file_found = get_file(path);
            if (file_found != null) {
                if (File.Exists(file_found.Item2)) {
                    
                    // Copy founded file where it missed
                    File.Copy(file_found.Item2, identify_dir_path + path);
                    return file_found.Item2;
                }
            } else {
                 // TODO no file found (maybe delete from DB ?)
            }
            return string.Empty;
        }

        /// <summary>
        /// Compare from db and Picture
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private Tuple<string, string> get_file(string path) {
            string file_name = Path.GetFileName(path);

            // Get list of files in the specific directory.
            string[] files = Directory.GetFiles(identify_dir_path, "*.*", SearchOption.AllDirectories);
            List<Tuple<string, string>> db = data.get_hash_from_name(file_name);

            // Get all the files.
            foreach (string file in files) {

                // If found in Picture a same filename
                if (file_name == Path.GetFileName(file)) {

                    string hash = get_md5_file(file);

                    // Search in the db if tuple <hash, file_name>
                    // Tuple => hash, file, id
                    foreach (Tuple<string, string> f in db) {
                        if ((hash == f.Item1) && (file_name == f.Item2)) {
                            return Tuple.Create(f.Item1, file);
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Get MD5 hash from file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string get_md5_file(string path) {
            string hash = "";
            try {
                using (var md5 = MD5.Create()) {
                    using (var stream = File.OpenRead(path)) {
                        hash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", String.Empty).ToLowerInvariant();
                    }
                }

                return hash;
            } catch { return ""; }
        }

        #endregion
    }
}
