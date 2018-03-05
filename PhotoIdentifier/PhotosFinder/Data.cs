using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoIdentifier;

namespace PhotosFinder {
    class Data {

        #region Vars
        public string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\GitHub\semester_project\PhotoIdentifier\PhotoIdentifier\photos.mdf;Persist Security Info=True;Connect Timeout=30";
        #endregion

        #region Init
        public Data() {
            init();
        }

        private void init() {
        }
        #endregion

        #region Request

        private List<string> get_info() {
            return new List<string>();
        }


        public List<string> get_type(string type) {
            try {
                string query = string.Empty;
                List<string> res = new List<string>();

                // Convert the type to lowercas
                type = type.ToLower();

                // Check if we want the tag or the other options
                if(type != "tag") {
                    query = $"SELECT {type} FROM dbo.person";
                } else {
                    query = $"SELECT {type} FROM dbo.image";
                }

                using(SqlConnection conn = new SqlConnection(connection_string)) {
                    using(SqlCommand cmd = new SqlCommand(query, conn)) {

                        // Execute query
                        conn.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader()) {

                            // Check if data
                            if(reader.HasRows) {
                                while(reader.Read()) {

                                    // Check if the result value not existe in the list
                                    string value = reader[$"{type}"].ToString();
                                    if(!res.Contains(value)) {
                                        res.Add(value.ToString());
                                    }
                                }
                            }
                        }
                    }
                    return res;
                }
            } catch { return null; }
        }

        public List<string> get_value_one(string type, string value) {
            try {
                string query = string.Empty;
                List<string> ids = new List<string>();

                // Convert value and type to lowercas
                value = value.ToLower();
                type = type.ToLower();

                // Check if we want the tag or the other options
                if(type != "tag") {
                    query = $"SELECT photo_id FROM dbo.person WHERE {type}='{value}'";
                } else {
                    query = $"SELECT photo_id FROM dbo.image WHERE {type}='{value}'";
                }

                using(SqlConnection conn = new SqlConnection(connection_string)) {
                    using(SqlCommand cmd = new SqlCommand(query, conn)) {

                        // Execute query
                        conn.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader()) {

                            // Check if data
                            if(reader.HasRows) {
                                while(reader.Read()) {

                                    // Check if the result id not existe in the list
                                    string id = reader["photo_id"].ToString();
                                    if(!ids.Contains(id)) {
                                        ids.Add(id.ToString());
                                    }
                                }
                            }
                        }
                    }
                }

                return get_photo_path(ids);
            } catch(Exception ex) { Console.WriteLine(ex.ToString()); return null; }
        }

        public List<string> get_value_two(string type1, string type2, string value1, string value2) {
            try {
                List<string> ids = new List<string>();

                // Convert value and type to lowercas
                value1 = value1.ToLower();
                type1 = type1.ToLower();
                value2 = value2.ToLower();
                type2 = type2.ToLower();

                using(SqlConnection conn = new SqlConnection(connection_string)) {

                    string query = $"SELECT photo_id FROM dbo.person WHERE {type1}='{value1}' AND {type2}='{value2}'";
                    using(SqlCommand cmd = new SqlCommand(query, conn)) {

                        // Execute query
                        conn.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader()) {

                            // Check if data
                            if(reader.HasRows) {
                                while(reader.Read()) {

                                    // Check if the result id not existe in the list
                                    string id = reader["photo_id"].ToString();
                                    if(!ids.Contains(id)) {
                                        ids.Add(id.ToString());
                                    }
                                }
                            }
                        }
                    }
                }

                return get_photo_path(ids);
            } catch(Exception ex) { Console.WriteLine(ex.ToString()); return null; }
        }


        private List<string> get_photo_path(List<string> ids) {
            try {

                List<string> paths = new List<string>();

                // Walk throw all ids
                foreach(string id in ids) {
                    string query = $"SELECT path FROM dbo.photo WHERE id='{id}'";

                    using(SqlConnection conn = new SqlConnection(connection_string)) {
                        using(SqlCommand cmd = new SqlCommand(query, conn)) {

                            // Execute query
                            conn.Open();
                            using(SqlDataReader reader = cmd.ExecuteReader()) {

                                // Check if data
                                if(reader.HasRows) {
                                    while(reader.Read()) {
                                        paths.Add(reader["path"].ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                return paths;
            } catch(Exception ex) { Console.WriteLine(ex.ToString()); return null; }
        }




        #endregion

    }
}
