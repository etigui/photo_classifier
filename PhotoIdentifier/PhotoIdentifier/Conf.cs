using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PhotoIdentifier {
    public class Conf {

        #region Vars
        private string path = string.Empty;
        private string xml_file_id = "1a30ed961f81b1d86bad52343c93e738d8844095491d3f2d7bbc022ccd6b9512";
        private static Random random = new Random();
        private int attribute_nb = 6;
        #endregion

        #region Constructor

        public Conf(string path) {
            this.path = path;
            if(string.IsNullOrEmpty(path)) {
                throw new Conf_exception("File path is null or empty.");
            }

            // Create xml file if not existe
            if(!file_existe(path)) {
                create();
            }
        }
        #endregion

        #region Create

        /// <summary>
        /// Create conf file with specific path
        /// </summary>
        private void create() {
            XmlDocument create_doc = new XmlDocument();

            // Root node
            XmlNode root = create_doc.CreateElement("config");
            create_doc.AppendChild(root);

            // Xml settings
            XmlWriterSettings settings = new XmlWriterSettings {
                Encoding = Encoding.UTF8,
                ConformanceLevel = ConformanceLevel.Document,
                OmitXmlDeclaration = false,
                CloseOutput = true,
                Indent = true,
                IndentChars = "  ",
                NewLineHandling = NewLineHandling.Replace
            };

            // Create file
            using(XmlWriter writer = XmlWriter.Create(path, settings)) {
                create_doc.WriteContentTo(writer);
                writer.Close();
            }

            // Create the base identify directory
            string identify_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "identify");
            if(!Directory.Exists(identify_path)) {
                Directory.CreateDirectory(identify_path);
            }

            // Write conf in conf xml file
            write_config(identify_path);
        }
        #endregion

        #region Load

        /// <summary>
        /// Load xml file
        /// </summary>
        /// <param name="config">true=create config; false=read, write</param>
        /// <returns></returns>
        private XmlDocument load(bool config) {

            // Check if xml file exist
            if(!file_existe(path)) {
                throw new Conf_exception("File Not exist.");
            }

            // Load xml file
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            // Check if all attribute are present
            if(!config) {
                if(!check_integrity(doc)) {
                    throw new Conf_exception("XML file bad integrity");
                }
            }

            return doc;
        }

        /// <summary>
        ///  Check if all attribute are present in the root node
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private bool check_integrity(XmlDocument doc) {

            //Go through child log
            int nb = 0;
            foreach(XmlNode child_node in doc.GetElementsByTagName("config")[0]) {
                nb++;
            }
            
            /// Check attribute number
            if(nb != attribute_nb) {
                return false;
            }
            return true;
        }
        #endregion

        #region Write

        /// <summary>
        /// Write conf in xml file
        /// </summary>
        private void write_config(string identify_path) {

            //Load xml file
            XmlDocument doc = load(true);

            // Get app name, version and date
            string app = Assembly.GetExecutingAssembly().GetName().Name;
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            DateTime date = DateTime.Now;

            // Get root node
            XmlNode root_node = doc.DocumentElement;

            // Write config to root node
            write_config(doc, root_node, "app", app);
            write_config(doc, root_node, "version", version);
            write_config(doc, root_node, "cdate", date.ToString("dd.MM.yyy HH:mm:ss"));
            write_config(doc, root_node, "xmlfiletype", xml_file_id);
            write_config(doc, root_node, "group", "hepia");//random_string(20)
            write_config(doc, root_node, "path", identify_path);
            doc.Save(path);
        }

        private void write_config(XmlDocument doc, XmlNode parent_node, string node_name, string node_value) {

            // Create new child node
            XmlNode new_node = doc.CreateElement(node_name);
            new_node.AppendChild(doc.CreateTextNode(node_value));

            // Add child node to parent noce
            parent_node.AppendChild(new_node);
        }
        #endregion

        #region Read

        public string read_group() {

            // Load xml file
            XmlDocument doc = load(false);

            // get group attribute
            string group = doc.GetElementsByTagName("config")[0].ChildNodes[4].InnerText;

            // Group attribute not found
            if(string.IsNullOrEmpty(group)) {
                throw new Conf_exception("Group attribute cannot be found.");
            }
            return group;
        }

        public string read_path() {

            // Load xml file
            XmlDocument doc = load(false);

            // get group attribute
            string identify_path = doc.GetElementsByTagName("config")[0].ChildNodes[5].InnerText;

            // Group attribute not found
            if(string.IsNullOrEmpty(identify_path)) {
                throw new Conf_exception("Identify path attribute cannot be found.");
            }
            return identify_path;
        } 
        #endregion

        #region Others

        /// <summary>
        /// Check if xml file existe
        /// </summary>
        /// <returns></returns>
        private bool file_existe(string path) {
            if(File.Exists(path)) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Generate random string
        /// </summary>
        /// <param name="length">eg: 10</param>
        /// <returns>radom string</returns>
        public static string random_string(int length) {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        #endregion

        #region Exception

        class Conf_exception:Exception {

            #region constructor

            /// <summary>
            /// Default constructor
            /// </summary>
            public Conf_exception() { }
            public Conf_exception(String message) : base(message) { }
            public Conf_exception(String message, Exception innerException) : base(message, innerException) { }
            #endregion

        }
        #endregion
    }
}
