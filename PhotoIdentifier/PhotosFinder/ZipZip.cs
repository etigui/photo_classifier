using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotosFinder {
    class ZipZip {

        public ZipZip() {}

        /// <summary>
        ///  Compresse data
        /// </summary>
        /// <param name="files"></param>
        /// <param name="zip_dest_path"></param>
        public void compress(List<string> files, string zip_dest_path) {
            try {

                // Get all files
                List<FileInfo> fi = convert(files);

                // Create an instance of a ZipArchive object by calling the
                // ZipFile.Open method with a ZipArchiveMode of Create
                using (ZipArchive zip = ZipFile.Open(zip_dest_path, ZipArchiveMode.Create)) {

                    // Iterate the filesToArchive string array
                    foreach (FileInfo file in fi) {
                        zip.CreateEntryFromFile(file.FullName, file.Name, CompressionLevel.Optimal);
                    }
                }
            } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        /// <summary>
        /// Convert file string to FileInfo
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        private List<FileInfo> convert(List<string> files) {
            List<FileInfo> fi = new List<FileInfo>();
            foreach (string file in files) {

                // Check if file exist and convert to FileInfo
                if (File.Exists(file)) {
                    fi.Add(new FileInfo(file));
                }
            }
            return fi;
        }

        /// <summary>
        /// Decompress datas
        /// </summary>
        /// <param name="extract_path"></param>
        /// <param name="zip_src_path"></param>
        public void decompress(string extract_path, string zip_src_path) {

            try {

                // Instantiate a ZipArchive object via the ZipFile.OpenRead method
                ZipArchive zipArchive = ZipFile.OpenRead(zip_src_path);

                // Get the entries in the zip archive
                if (zipArchive.Entries != null && zipArchive.Entries.Count > 0) {

                    // iterate through the Entries collection and extract each file
                    // To the extraction folder

                    foreach (ZipArchiveEntry entry in zipArchive.Entries) {

                        // Extract the entry to the output folder
                        entry.ExtractToFile(Path.Combine(extract_path, entry.FullName));
                    }
                }
            } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        public void ss() {
            //string startPath = @"C:\Users\Etienne\Pictures";
            string zipPath = @"C:\Users\Etienne\Desktop\dd\result.zip";
            string extractPath = @"C:\Users\Etienne\Pictures\sss";

            //ZipFile.CreateFromDirectory(startPath, zipPath);
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
