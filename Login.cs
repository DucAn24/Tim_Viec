using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimViec
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Register().Show();
            this.Hide();
        }

        DbConnection conn = new DbConnection();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            conn.GetSqlConnection().Open();
            string login = "SELECT * FROM Account WHERE Username= '" + txtUserName.Text + "' and Password = '" + txtPassword.Text + "'";
            SqlCommand cmd = new SqlCommand(login, conn.GetSqlConnection());
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() == true)
            {
                new FUser().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password, Please Try Again");
            }
            conn.GetSqlConnection().Close();
        }

        private void checkbxPassworld_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxPassworld.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }
    }
}
