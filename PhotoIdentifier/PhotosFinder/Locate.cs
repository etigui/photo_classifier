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
        string identify_path = string.Empty;
        #endregion


        #region Init

        public Locate() {
            init();
        }

        private void init() {
            // identify_path = conf.get_path....
            // TODO get conf paath 
        }

        #endregion

        #region Locate file

        public string locate_file(string path, string hash) {
            string file_found = process_files(path, hash);
            if(file_found != string.Empty) {
                // TODO update database with the new path (file_found) as hash as key
                return file_found;
            }
            return string.Empty;
        }

        private Dictionary<string, string> get_all_files() {
            Dictionary<string, string> images = new Dictionary<string, string>();

            // Get list of files in the specific directory.
            // ... Please change the first argument.
            string[] files = Directory.GetFiles(identify_path, "*.*", SearchOption.AllDirectories);

            // Get all the files.
            foreach(string file in files) {
                images.Add(get_md5_file(file), file);
            }
            return images;
        }

        private string process_files(string path, string hash) {

            // Getfile name from path
            string file_name = Path.GetFileName(path);

            // Get all file path and the hash ascociate
            Dictionary<string, string> files = get_all_files();

            // Check if we can find the file by his name
            // Then compare with the hash
            string file_found = process_files_path(files, path, hash);
            if(file_found != string.Empty) {
                return file_found;
            } else {

                // Check if we can find the file by his hash
                file_found = process_files_hash(files, hash);
                if(file_found != string.Empty) {
                    return file_found;
                }
            }
            return string.Empty;
        }

        private string process_files_path(Dictionary<string, string> files, string path, string hash) {

            List<string> found = new List<string>();

            // Process all files
            foreach(KeyValuePair<string, string> file in files) {

                // Check if a file name match
                if(Path.GetFileName(file.Value) == path) {

                    // Check if the hash match
                    // Means is the good file and not a file with the same name
                    if(conpare_hash(hash, file.Key)) {
                        return file.Value;
                    }
                }
            }
            return string.Empty;
        }

        private string process_files_hash(Dictionary<string, string> files, string hash) {

            // Process all files
            foreach(KeyValuePair<string, string> file in files) {
                if(conpare_hash(hash, file.Key)) {
                    return file.Value;
                }
            }
            return string.Empty;
        }

        private bool conpare_hash(string hash_base, string hash_file_found) {
            if(hash_base == hash_file_found) {
                return true;
            }
            return false;
        }

        private string get_md5_file(string path) {
            string hash = "";
            try {
                using(var md5 = MD5.Create()) {
                    using(var stream = File.OpenRead(path)) {
                        hash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", String.Empty).ToLowerInvariant();
                    }
                }

                return hash;
            } catch { return ""; }
        }

        #endregion
    }
}
