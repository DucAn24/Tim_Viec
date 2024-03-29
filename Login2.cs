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
    public partial class Login2 : Form
    {
        public Login2()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            new User().Show();
            this.Close();
        }


        /*        private void btnLogin_Click(object sender, EventArgs e)
                {
                    string username = txtUsername.Text; // assuming you have a textbox txtUsername for username input
                    string password = txtPassword.Text; // assuming you have a textbox txtPassword for password input

                    int role = GetRoleFromDatabase(username, password);

                    if (role == 0) // Client
                    {
                        new User().Show();
                    }
                    else if (role == 1) // Craftsman
                    {
                        new Worker().Show(); // assuming you have a Worker form for Craftsman
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }

                    this.Close();
                }
        */
/*        private int GetRoleFromDatabase(string username, string password)
        {
            // Create an instance of DbConnection
            DbConnection dbConnection = new DbConnection();

            // Open the connection
            dbConnection.Open();

            // Create a SQL query to get the role based on the username and password
            string query = $"SELECT Role FROM Account WHERE Username = '{username}' AND Password = '{password}'";

            // Execute the query
            DataTable result = dbConnection.ExecuteQuery(query);

            // Close the connection
            dbConnection.Close();

            // If the result contains rows, return the role
            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["Role"]);
            }
            else
            {
                // If the result does not contain any rows, return -1 to indicate an error
                return -1;
            }
        }
*/


    }
}
