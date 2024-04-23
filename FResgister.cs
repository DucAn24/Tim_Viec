
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimViec
{
    public partial class FResgister : MaterialForm
    {

        private DbConnection dbConnection;

        public FResgister()
        {
            InitializeComponent();

            dbConnection = new DbConnection();

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

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            new FLogin().Show();
            this.Hide();
        }

        private void btnResgister_Click_1(object sender, EventArgs e)
        {
            // Check if password and confirm password are the same
            if (txtPassWord.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password and confirm password do not match.");
                return;
            }

            // Check if a role is selected
            if (!ckbClient.Checked && !ckbWorker.Checked)
            {
                MessageBox.Show("Please select a role.");
                return;
            }

            // Open the connection
            dbConnection.Open();

            // Create a SQL command to insert a new user
            using (SqlCommand command = new SqlCommand("INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)", dbConnection.Connection))
            {
                command.Parameters.AddWithValue("@Username", txtUserName.Text);
                command.Parameters.AddWithValue("@Password", txtPassWord.Text); // Consider hashing this!
                command.Parameters.AddWithValue("@Role", ckbClient.Checked ? 0 : 1); // Assuming 0 is Client and 1 is Worker

                // Execute the command
                int result = dbConnection.ExecuteNonQuery(command);

                // If the result is 1, the user was inserted successfully
                if (result == 1)
                {
                    MessageBox.Show("User registered successfully.");
                }
                else
                {
                    MessageBox.Show("Error registering user.");
                }
            }
            dbConnection.Close();
        }


        private void ckbClient_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbClient.Checked == true)
            {
                ckbWorker.Checked = false;
            }
        }

        private void ckbWorker_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbWorker.Checked == true)
            {
                ckbClient.Checked = false;
            }
        }


        private void ckbShowPassWord_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ckbShowPassWord.Checked)
            {
                txtPassWord.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassWord.PasswordChar = '*';
                txtConfirmPassword.PasswordChar = '*';
            }

        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassWord.Text = "";
            txtConfirmPassword.Text = "";

        }





    }
}
