using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoIdentifier {
    class Data {

        #region Vars
        //private const string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\GitHub\semester_project\PhotoIdentifier\PhotoIdentifier\photos.mdf;Persist Security Info=True;Connect Timeout=30";
        private static string db_path = (Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "photos.mdf")).ToString();
        private string connection_string = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={db_path};Persist Security Info=True;Connect Timeout=30";
        string identify_dir_path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);


        private string conf_file_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "app_conf.xml");
        public List<IdentifyInfos> infos_list;
        Conf conf;

        #endregion

        #region Init

        public Data() {
            init();
        }

        private void init() {
            conf = new Conf(conf_file_path);

            // TODO remove
            //reset_pk();
        }

        #endregion

        #region Add photos
        /// <summary>
        /// Process all identified photo
        /// </summary>
        public bool process_photos() {
            try {
                // Process all photos
                foreach(IdentifyInfos info in infos_list) {
                    int photo_id = 0;

                    // Calculate file hash and check if no error.
                    // If error we dont the file into the database.
                    // If the photo is already in the database we dont add it.
                    // TODO  => if exist => delet db file entree and add the new one.
                    string hash = get_md5_file(info.path);
                    if(hash != "" && !check_photo_exist(hash)) {

                        // TODO check those value
                        string path = info.path;
                        string file_name = Path.GetFileName(path);
                        int width = info.info.Metadata.Width;
                        int height = info.info.Metadata.Height;
                        string date = get_date_time();

                        // Get last id
                        //photo_id = get_last_id();

                        // Add info about the photo in the photo table
                        photo_id = add_photo(hash, file_name, path, width, height, date);

                        int face = 0;
                        foreach(KeyValuePair<string, string> person in info.person) {

                            // TODO check those value
                            string name = get_name(person.Value);
                            string gender = info.faces[face].FaceAttributes.Gender;
                            int smile = get_smile(info.faces[face].FaceAttributes.Smile);
                            int age = Convert.ToInt32(info.faces[face].FaceAttributes.Age);
                            string emotion = get_emotion(info.faces[face].FaceAttributes.Emotion);

                            // Add info about the person in the person table
                            add_person(name, gender, smile, age, emotion, photo_id);
                            face++;
                        }

                        // TODO check those value
                        foreach(string tag in info.info.Description.Tags) {

                            // Add image info in image table
                            add_image(tag, photo_id);
                        }
                    }
                }
                return true;
            } catch(Exception ex) { Console.WriteLine(ex.ToString()); return false; }
        }


        /// <summary>
        /// Add photo info to the photp table
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        private int add_photo(string hash, string name, string path, int width, int height, string date) {
            int photo_id = 0;
            using(SqlConnection conn = new SqlConnection(connection_string)) {
                string query = "INSERT INTO dbo.photo (hash,name,path,width,height,date) VALUES (@hash,@name,@path,@width,@height,@date); SELECT SCOPE_IDENTITY();";
                using(SqlCommand cmd = new SqlCommand(query, conn)) {

                    // Add value to request
                    cmd.Parameters.AddWithValue("@hash", hash);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@path", path.Replace(identify_dir_path, string.Empty)); // conf.read_identify_path(
                    cmd.Parameters.AddWithValue("@width", width);
                    cmd.Parameters.AddWithValue("@height", height);
                    cmd.Parameters.AddWithValue("@date", date);

                    // Execute query and get last primary key
                    conn.Open();

                    //int result = cmd.ExecuteNonQuery();
                    photo_id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return photo_id;
        }

        private int get_last_id() {
            using(SqlConnection conn = new SqlConnection(connection_string)) {
                string query = "SELECT MAX(id) FROM dbo.photo";
                using(SqlCommand cmd = new SqlCommand(query, conn)) {
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                }
            }
        }

        /// <summary>
        /// Add person info in person table
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="smile"></param>
        /// <param name="age"></param>
        /// <param name="emotion"></param>
        /// <param name="photo_id"></param>
        private void add_person(string name, string gender, int smile, int age, string emotion, int photo_id) {
            using(SqlConnection conn = new SqlConnection(connection_string)) {
                string query = "INSERT INTO dbo.person (name,gender,smile,age,emotion,photo_id) VALUES (@name,@gender,@smile,@age,@emotion,@photo_id)";
                using(SqlCommand cmd = new SqlCommand(query, conn)) {

                    // Add value to request
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@smile", smile);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@emotion", emotion);
                    cmd.Parameters.AddWithValue("@photo_id", photo_id);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Add image info in image table
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="photo_id"></param>
        private void add_image(string tag, int photo_id) {
            using(SqlConnection conn = new SqlConnection(connection_string)) {
                string query = "INSERT INTO dbo.image (tag,photo_id) VALUES (@tag,@photo_id)";
                using(SqlCommand cmd = new SqlCommand(query, conn)) {

                    // Add value to request
                    cmd.Parameters.AddWithValue("@tag", tag);
                    cmd.Parameters.AddWithValue("@photo_id", photo_id);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Get photo info
        /// <summary>
        /// Get the dominant emotion
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string get_emotion(Microsoft.ProjectOxford.Common.Contract.EmotionScores value) {
            Dictionary<string, double> emotion = new Dictionary<string, double>();
            emotion.Add("Anger", value.Anger);
            emotion.Add("Contempt", value.Contempt);
            emotion.Add("Disgust", value.Disgust);
            emotion.Add("Fear", value.Fear);
            emotion.Add("Happiness", value.Happiness);
            emotion.Add("Neutral", value.Neutral);
            emotion.Add("Sadness", value.Sadness);
            emotion.Add("Surprise", value.Surprise);

            // Get max value for the dominant emotion
            double max = emotion.Values.Max();

            // Return the dominant emotion
            return emotion.FirstOrDefault(x => x.Value == max).Key;
        }

        /// <summary>
        /// Get if the person smile or not
        /// If more than 0.5 => smiling
        /// If less then 0.5 => not smiling
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int get_smile(double value) {
            if(value > 0.5) {
                return 1;
            } else {
                return 0;
            }
        }


        // Get current date time
        private string get_date_time() {
            DateTime time = DateTime.Now;
            return time.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// Split to get the real name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string get_name(string name) {
            int index = name.LastIndexOf("_");
            if(index > 0) {
                return name.Substring(0, index);
            }
            return name;
        }

        /// <summary>
        /// Calc MD5 file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string get_md5_file(string path) {
            string hash = "";
            try {
                if(File.Exists(path)) {
                    using(var md5 = MD5.Create()) {
                        using(var stream = File.OpenRead(path)) {
                            hash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", String.Empty).ToLowerInvariant();
                        }
                    }
                    return hash;
                }
                return "";
            } catch { return ""; }
        }
        #endregion

        #region Check hash
        private bool check_photo_exist(string hash) {
            bool found = false;
            using(SqlConnection conn = new SqlConnection(connection_string)) {
                string query = "SELECT COUNT(*) FROM dbo.photo WHERE hash=@hash";
                using(SqlCommand cmd = new SqlCommand(query, conn)) {

                    // Add value to request
                    cmd.Parameters.AddWithValue("@hash", hash);

                    conn.Open();
                    Int32 count = Convert.ToInt32(cmd.ExecuteScalar());

                    if(count > 0) {
                        found = true;
                    } else {
                        found = false;
                    }
                }
            }
            return found;
        }
        #endregion

        #region Reset PK

        /// <summary>
        /// Reset the primary key of each table
        /// </summary>
        private void reset_pk() {
            string[] tables = new string[] { "photo", "image", "person" };
            foreach(string table in tables) {
                using(SqlConnection conn = new SqlConnection(connection_string)) {
                    string query = $"DBCC CHECKIDENT ('dbo.{table}', RESEED, 0)";
                    using(SqlCommand cmd = new SqlCommand(query, conn)) {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        #endregion
    }
}
