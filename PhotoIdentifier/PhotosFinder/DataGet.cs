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
        private string connection_string = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "photos.db");
        private string identify_dir_path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        #endregion

        #region Get one type

        /// <summary>
        /// Get data from type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<string> get_one_type(string type) {

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

        #region Get two type

        public List<string> get_two_type(string type1, string value1, string type2) {

            List<string> res = new List<string>();

            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(connection_string)) {

                // Get a collection (or create, if doesn't exist)
                var persons = db.GetCollection<TPerson>("persons");

                // Get all data
                var query = persons.Find(Query.Where(type1, t1 => t1 == value1));
                foreach (var data in query) {
                    string value = string.Empty;
                    if (type2 == "Age") {
                        value = data.Age.ToString();
                    } else if (type2 == "Emotion") {
                        value = data.Emotion.ToString();
                    } else if (type2 == "Gender") {
                        value = data.Gender.ToString();
                    } else if (type2 == "Name") {
                        value = data.Name.ToString();
                    } else if (type2 == "Smile") {
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

        #endregion

        #region Get one value

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

                // Check if the value is numeric (smile, age)
                // TODO if too complicated change (smile, age) from int to string in DB
                IEnumerable<TPerson> query;
                if (int.TryParse(value, out int n)) {
                    query = persons.Find(Query.Where(type, t => t == n));
                } else {
                    query = persons.Find(Query.Where(type, t => t == value));
                }

                // Get by type
                //var query = persons.Find(Query.Where(type, t => t == value));
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

        #region Get two value

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

                // Check if the value is numeric (smile, age)    
                // TODO if too complicated change (smile, age) from int to string in DB
                IEnumerable<TPerson> query;
                if (int.TryParse(value2, out int n)) {
                    query = persons.Find(Query.And(Query.Where(type1, t1 => t1 == value1), Query.Where(type2, t2 => t2 == n)));
                } else {
                    query = persons.Find(Query.And(Query.Where(type1, t1 => t1 == value1), Query.Where(type2, t2 => t2 == value2)));
                }

                // Get data by two type
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

        #region Locate

        public List<Tuple<string, string>> get_hash_from_name(string name) {
            List<Tuple<string, string>> files = new List<Tuple<string, string>>();

            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(connection_string)) {

                // Get a collection (or create, if doesn't exist)
                var photos = db.GetCollection<TPhoto>("photos");

                // Get tag
                var query = photos.Find(Query.Where("Name", n => n == name));
                foreach (var data in query) {
                    files.Add(Tuple.Create(data.Hash, data.Name));
                }
            }
            return files;
        }


        #endregion

        #region Export

        /// <summary>
        ///  Get all file in the db to export
        /// </summary>
        public List<string> get_all_photo() {
            List<string> files = new List<string>();

            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(connection_string)) {

                // Get a collection (or create, if doesn't exist)
                var photos = db.GetCollection<TPhoto>("photos");

                // Get all photos
                var query = photos.Find(Query.All());
                foreach(var data in query) {

                    // Check if file exist
                    string file = identify_dir_path + data.Path;
                    if (File.Exists(file)) {
                        files.Add(file);
                    }
                }
            }
            return files;
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
                    string ff = photos.FindOne(x => x.Id == id).Path.ToString();
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
