using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace PhotosFinder {
    class DataGet {

        #region Vars
        private string connection_string = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "MyData.db");
        #endregion

        #region Get type

        /// <summary>
        /// Get data from type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<string> get_type(string type) {

            // Get info in DB
            if (type != "Tag") {
                return get_person_type(type);
            } else {
                return get_image_type();
            }
        }

        /// <summary>
        /// Get data from person table
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private List<string> get_person_type(string type) {

            List<string> res = new List<string>();

            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(connection_string)) {

                // Get a collection (or create, if doesn't exist)
                var persons = db.GetCollection<TPerson>("persons");

                // Get all data
                var query = persons.Find(Query.All());
                foreach (var data in query) {
                    string value = string.Empty;
                    if (type == "Age") {
                        value = data.Age.ToString();
                    } else if (type == "Emotion") {
                        value = data.Emotion.ToString();
                    } else if (type == "Gender") {
                        value = data.Gender.ToString();
                    } else if (type == "Name") {
                        value = data.Name.ToString();
                    } else if (type == "Smile") {
                        value = data.Smile.ToString();
                    }

                    // Add to list
                    if ((!res.Contains(value)) && (value != string.Empty)) {
                        res.Add(value);
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// Get data from image table
        /// </summary>
        /// <returns></returns>
        private List<string> get_image_type() {

            List<string> res = new List<string>();

            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(connection_string)) {

                // Get a collection (or create, if doesn't exist)
                var images = db.GetCollection<TImage>("images");

                // Get all data
                var query = images.Find(Query.All());
                foreach (var data in query) {

                    // Add to list
                    string value = data.Tag.ToString();
                    if ((!res.Contains(value)) && (value != string.Empty)) {
                        res.Add(value);
                    }
                }
            }
            return res;
        }
        #endregion

        #region Get value one

        /// <summary>
        /// Get photo path by id
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<string> get_one_value(string type, string value) {

            // Get info in DB
            if (type != "Tag") {
                return get_person_one_value(type, value);
            } else {
                return get_image_one_value(value);
            }
        }

        /// <summary>
        /// Get photo_id by type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private List<string> get_person_one_value(string type, string value) {
            List<int> ids = new List<int>();

            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(connection_string)) {

                // Get a collection (or create, if doesn't exist)
                var persons = db.GetCollection<TPerson>("persons");

                // Get by type
                var query = persons.Find(Query.Where(type, t => t == value));
                foreach (var data in query) {

                    // Add value in list
                    int val = data.Photo_id;
                    if (!ids.Contains(val)) {
                        ids.Add(val);
                    }
                }
            }

            // Get path from id
            return get_photo_path(ids);
        }

        /// <summary>
        /// Get photo_id by tag
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private List<string> get_image_one_value(string value) {

            List<int> ids = new List<int>();

            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(connection_string)) {

                // Get a collection (or create, if doesn't exist)
                var images = db.GetCollection<TImage>("images");

                // Get tag
                var query = images.Find(Query.Where("Tag", tag => tag == value));
                foreach (var data in query) {

                    // Add value in list
                    int val = data.Photo_id;
                    if (!ids.Contains(val)) {
                        ids.Add(val);
                    }
                }
            }

            // Get path from id
            return get_photo_path(ids);
        }

        #endregion

        #region Get value two

        /// <summary>
        /// Get all file path from two type
        /// </summary>
        /// <param name="type1"></param>
        /// <param name="value1"></param>
        /// <param name="type2"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public List<string> get_two_value(string type1, string value1, string type2, string value2) {

            List<int> ids = new List<int>();

            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(connection_string)) {

                // Get a collection (or create, if doesn't exist)
                var persons = db.GetCollection<TPerson>("persons");

                // Get data by two type
                var query = persons.Find(Query.And(Query.Where(type1, t1 => t1 == value1), Query.Where(type2, t2 => t2 == value2)));
                foreach (var data in query) {

                    // Add value in list
                    int val = data.Photo_id;
                    if (!ids.Contains(val)) {
                        ids.Add(val);
                    }
                }
            }

            // Get path from id
            return get_photo_path(ids);
        }

        #endregion

        #region Other

        /// <summary>
        /// Get all file path from ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        private List<string> get_photo_path(List<int> ids) {

            List<string> res = new List<string>();

            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(connection_string)) {

                // Get a collection (or create, if doesn't exist)
                var photos = db.GetCollection<TPhoto>("photos");

                // Get path from all ids
                foreach (int id in ids) {

                    // Add path in list
                    res.Add(photos.FindOne(x => x.Id == id).Path.ToString());
                }
            }
            return res;
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
