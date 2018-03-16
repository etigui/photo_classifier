using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace PhotoIdentifier {
    class DataSet {

        #region Vars
        private string connection_string = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "photos.db");
        #endregion

        #region Add info in DB

        /// <summary>
        /// Add photo info to the photp table
        /// </summary>
        /// <param name="infos_list"></param>
        public bool add_identified_photos(List<IdentifyInfos> infos_list) {

            try {

                // Process all photos
                foreach (IdentifyInfos info in infos_list) {

                    // Commun id for 3 entree
                    int photo_id = 0;

                    // Get file hash
                    string hash = get_md5_file(info.path);
                    if (!String.IsNullOrEmpty(hash)) {

                        // Check if the photo not exist
                        if (!check_photo_exist(hash)) {

                            // Add info about the photo in the photo table
                            photo_id = add_photo(info, photo_id, hash);

                            // Add info about the person in the person table
                            add_person(info, photo_id);

                            // Add image info in image table
                            add_image(info, photo_id);
                        }
                    } else {
                        // TODO hash error
                        MessageBox.Show("hash error");
                        return false;
                    }
                }
                return true;
            } catch (Exception ex) { MessageBox.Show(ex.ToString()); return false; }
        }

        private int add_photo(IdentifyInfos info, int photo_id, string hash) {

            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(connection_string)) {

                // Get a collection (or create, if doesn't exist)
                var photos = db.GetCollection<TPhoto>("photos");

                // Create your new Photo instance
                var photo = new TPhoto {
                    Hash = hash,
                    Name = Path.GetFileName(info.path),
                    Path = info.path,
                    Width = info.info.Metadata.Width,
                    Height = info.info.Metadata.Height,
                    Date = DateTime.Now
                };

                // Insert new photo in DB (Id will be auto-incremented) and get inserted Id
                photo_id = photos.Insert(photo).AsInt32;
            }
            return photo_id;
        }

        /// <summary>
        /// Add person info in person table
        /// </summary>
        /// <param name="info"></param>
        /// <param name="photo_id"></param>
        private void add_person(IdentifyInfos info, int photo_id) {

            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(connection_string)) {

                // Get a collection (or create, if doesn't exist)
                var persons = db.GetCollection<TPerson>("persons");

                int face = 0;
                foreach (KeyValuePair<string, string> p in info.person) {

                    var person = new TPerson {
                        Name = get_name(p.Value),
                        Gender = info.faces[face].FaceAttributes.Gender,
                        Smile = get_smile(info.faces[face].FaceAttributes.Smile),
                        Age = Convert.ToInt32(info.faces[face].FaceAttributes.Age),
                        Emotion = get_emotion(info.faces[face].FaceAttributes.Emotion),
                        Photo_id = photo_id
                    };

                    // Insert new person in DB (Id will be auto-incremented)
                    persons.Insert(person);
                    face++;
                }
            }
        }

        /// <summary>
        /// Add person info in image table
        /// </summary>
        /// <param name="info"></param>
        /// <param name="photo_idv"></param>
        private void add_image(IdentifyInfos info, int photo_id) {

            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(connection_string)) {

                // Get a collection (or create, if doesn't exist)
                var images = db.GetCollection<TImage>("images");

                // Get all tag
                foreach (string tag in info.info.Description.Tags) {
                    var image = new TImage {
                        Tag = tag,
                        Photo_id = photo_id
                    };

                    // Insert new image in DB (Id will be auto-incremented)
                    images.Insert(image);
                }
            }
        }

        /// <summary>
        /// Check if the photo already exist in the DB
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        private bool check_photo_exist(string hash) {

            // Open and get collection DB
            using (var db = new LiteDatabase(connection_string)) {

                // Compare hash
                var res = db.GetCollection<TPhoto>("photos").Find(Query.EQ("Hash", hash));

                int found = 0;
                foreach(var data in res) {
                    found++;
                }

                // Check if find something (hash)
                if (found > 0) {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Get photo info

        /// <summary>
        /// Split to get the real name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string get_name(string name) {
            int index = name.LastIndexOf("_");
            if (index > 0) {
                return name.Substring(0, index);
            }
            return name;
        }

        /// <summary>
        /// Get if the person smile or not
        /// If more than 0.5 => smiling
        /// If less then 0.5 => not smiling
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int get_smile(double value) {
            if (value > 0.5) {
                return 1;
            } else {
                return 0;
            }
        }

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
        /// Calc file MD5
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string get_md5_file(string path) {
            string hash = string.Empty;
            try {
                if (File.Exists(path)) {
                    using (var md5 = MD5.Create()) {
                        using (var stream = File.OpenRead(path)) {
                            hash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", String.Empty).ToLowerInvariant();
                        }
                    }
                    return hash;
                }
                return hash;
            } catch { return hash; }
        }

        #endregion
    }

    #region DB class

    public class TPhoto {
        public int Id { get; set; }
        public string Hash { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public DateTime Date { get; set; }
    }

    public class TImage {
        public int Id { get; set; }
        public string Tag { get; set; }
        public int Photo_id { get; set; }
    }
    public class TPerson {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Smile { get; set; }
        public int Age { get; set; }
        public string Emotion { get; set; }
        public int Photo_id { get; set; }
    }
    #endregion
}
