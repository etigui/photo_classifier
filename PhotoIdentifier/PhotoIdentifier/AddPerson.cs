using Manina.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoIdentifier {
    public partial class AddPerson:Form {
        public AddPerson() {
            InitializeComponent();
        }

        private void AddPerson_Load(object sender, EventArgs e) {
        }

        private void x48ToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void x96ToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void x120ToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void x150ToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void x200ToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void TSB_add_Click(object sender, EventArgs e) {

        }

        private void TSB_remove_Click(object sender, EventArgs e) {

        }

        private void TSB_clear_Click(object sender, EventArgs e) {

        }

        private void BT_add_Click(object sender, EventArgs e) {

            // Check if only letter in the textbox
            if(TB_name.Text.All(Char.IsLetter)) {

                //SqlCredential d = new SqlCredential("Admin", ConvertToSecureString("Admin-7415e"));
                using(SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\GitHub\semester_project\PhotoIdentifier\PhotoIdentifier\photos.mdf;Persist Security Info=True;Connect Timeout=30")) {
                    String query = "INSERT INTO dbo.person ( name,hash, date) VALUES (@name,@hash, @date)";
                    using(SqlCommand command = new SqlCommand(query, connection)) {
                        DateTime myDateTime = DateTime.Now;
                        string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        command.Parameters.AddWithValue("@name", "sdfs");
                        command.Parameters.AddWithValue("@hash", "sdfdsf");
                        command.Parameters.AddWithValue("@date", sqlFormattedDate);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if(result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                    }
                }
            } else {
                MessageBox.Show("The name must me only letter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private SecureString ConvertToSecureString(string password) {
            if(password == null)
                throw new ArgumentNullException("password");

            var securePassword = new SecureString();

            foreach(char c in password)
                securePassword.AppendChar(c);

            securePassword.MakeReadOnly();
            return securePassword;
        }

        private string GetConnectionString() {
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file, using the 
            // System.Configuration.ConfigurationSettings.AppSettings property 
            return "Data Source=photos.mdf; Integrated Security=SSPI;" + "Initial Catalog=Northwind";
        }

        private void TB_name_TextChanged(object sender, EventArgs e) {

            // Check if only letter in the textbox
            if(!TB_name.Text.All(Char.IsLetter)) {
                TB_name.BackColor = Color.Red;
            } else {
                TB_name.BackColor = Color.White; ;
            }
        }
    }
}
