using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimViec
{
    public partial class FLogin : MaterialForm
    {
        public FLogin()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;

            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightGreen900,
                                                                Primary.LightGreen700,
                                                                Primary.LightGreen500,
                                                                Accent.LightGreen200,
                                                                TextShade.WHITE);


        }

        private void label6_Click(object sender, EventArgs e)
        {
            new FResgister().Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassWord.Text;

            var (userId, role) = GetUserIdAndRoleFromDatabase(username, password);
            System.Diagnostics.Debug.WriteLine($"Login form: userId = {userId}");



            if (userId > 0)
            {
                if (role == 0)
                {
                    new FClient(userId).Show();
                    this.Hide(); // Hide the login form
                }
                else if (role == 1)
                {
                    new FWorker(userId).Show();
                    this.Hide(); // Hide the login form
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
                // Don't close the form, let the user try again
            }
        }


        private void Login_Load(object sender, EventArgs e)
        {

        }


        private (int UserId, int Role) GetUserIdAndRoleFromDatabase(string username, string password)
        {
            // Create an instance of DbConnection
            DbConnection dbConnection = new DbConnection();

            // Open the connection
            dbConnection.Open();

            // Create a SQL command to get the role based on the username and password
            using (SqlCommand command = new SqlCommand("SELECT user_id, Role FROM Users WHERE Username = @Username AND Password = @Password", dbConnection.Connection))

            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password); // Consider hashing this!

                // Execute the command
                DataTable result = dbConnection.ExecuteQuery(command);

                // Close the connection
                dbConnection.Close();


                // If the result contains rows, return the user id and role
                if (result.Rows.Count > 0)
                {
                    return (Convert.ToInt32(result.Rows[0]["user_id"]), Convert.ToInt32(result.Rows[0]["Role"]));
                }
                else
                {
                    // If the result does not contain any rows, return -1 to indicate an error
                    return (-1, -1);
                }
            }
        }




        private void ckbShowPassWord_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ckbShowPassWord.Checked)
            {
                txtPassWord.PasswordChar = '\0';
            }
            else
            {
                txtPassWord.PasswordChar = '*';
            }

        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassWord.Text = "";

        }
    }
}
