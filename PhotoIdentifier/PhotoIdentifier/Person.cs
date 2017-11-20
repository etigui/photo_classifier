using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Manina.Windows.Forms;
using System.IO;
using System.Windows.Forms;

namespace PhotoIdentifier {
    class Person {

        #region Vars
        private const string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\GitHub\semester_project\PhotoIdentifier\PhotoIdentifier\photos.mdf;Persist Security Info=True;Connect Timeout=30";
        private static Random rnd = new Random();
        private string exec_path = Path.GetDirectoryName(Application.ExecutablePath);
        private string dir_path = "";
        public ImageListView ILV_photos;
        #endregion

        #region Add person

        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="name">Name of the person to add</param>
        public bool add_person(string name) {
            if(!add_name_db(name)) 
                return false;
            
            if(!add_image_db()) 
                return false;
            return true;
        }

        /// <summary>
        /// Add image of person to database
        /// </summary>
        /// <returns></returns>
        private bool add_image_db() {
            try {
                if(!copy_files())
                    return false;

                // Get id from path
                string id = "";
                using(SqlConnection conn = new SqlConnection(connection_string)) {
                    conn.Open();
                    string query = "SELECT id FROM person WHERE path=@path";
                    using(SqlCommand cmd = new SqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@path", dir_path.ToString());
                        using(SqlDataReader reader = cmd.ExecuteReader()) {
                            if(reader.Read()) {
                                id = reader["id"].ToString();
                            }
                        }
                    }
                }

                // Add photo to database. Get all photos from imagelistview
                foreach(ImageListViewItem item in ILV_photos.Items) {
                    using(SqlConnection conn = new SqlConnection(connection_string)) {
                        string query = "INSERT INTO dbo.personPhotos (name, path, id_person) VALUES (@name, @path, @id)";
                        using(SqlCommand cmd = new SqlCommand(query, conn)) {

                            // Param to add
                            cmd.Parameters.AddWithValue("@name", (Path.GetFileName(item.FileName)).ToString());
                            cmd.Parameters.AddWithValue("@path", (Path.Combine(exec_path, "person", dir_path, Path.GetFileName(item.FileName))).ToString());
                            cmd.Parameters.AddWithValue("@id", id);

                            // No close cause "using"
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                return true;
            } catch (Exception ex){ MessageBox.Show(ex.ToString()); return false; }
            
        }

        /// <summary>
        /// Add user to the database
        /// </summary>
        /// <param name="name">Name of the person to add</param>
        /// <returns></returns>
        private bool add_name_db(string name) {
            try {

                // Dir will be created to stock the photos
                dir_path = $"{name}_{get_random(10)}";

                // Create specific directory
                string dir = Path.Combine(exec_path, "person", dir_path);
                if(!Directory.Exists(dir)) {
                    Directory.CreateDirectory(dir);
                } else {

                    // If fail create new dir
                    dir_path = $"{name}_{get_random(20)}";
                    Directory.CreateDirectory(Path.Combine(exec_path, "person", dir_path));
                }

                using(SqlConnection conn = new SqlConnection(connection_string)) {
                    string query = "INSERT INTO dbo.person (name, path, date) VALUES (@name, @path, @date)";
                    using(SqlCommand cmd = new SqlCommand(query, conn)) {

                        // Param to add
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@path", dir_path);
                        cmd.Parameters.AddWithValue("@date", (get_date_sql()).ToString());

                        // No close cause "using"
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            } catch (Exception ex) { MessageBox.Show(ex.ToString());  return false;}
        }

        private bool copy_files() {
            try {

                // Get all photos from imagelistview
                foreach(ImageListViewItem item in ILV_photos.Items) {

                    // Get source/dest file
                    string source = item.FileName;
                    string dest = Path.Combine(exec_path, "person", dir_path, Path.GetFileName(item.FileName));

                    // Copy photo to specific directory
                    if(File.Exists(source)) {
                        File.Copy(source, dest, true);
                    }
                }
                return true;
            }catch (Exception ex){ MessageBox.Show(ex.ToString()); return false; }
        }
        #endregion

        /// <summary>
        /// Get formatted date to sql DB
        /// </summary>
        /// <returns>date</returns>
        private string get_date_sql() {
            DateTime myDateTime = DateTime.Now;
            return myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
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
        /// Hash string to SHA256
        /// </summary>
        /// <param name="input">String to hash</param>
        /// <returns></returns>
        private string get_sha256(string input) {
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            System.Text.StringBuilder hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input), 0, Encoding.UTF8.GetByteCount(input));
            foreach(byte theByte in crypto) {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
