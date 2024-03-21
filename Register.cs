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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        DbConnection conn = new DbConnection();
        private void checkbxPassworld_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxPassworld.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtConfirmPassword.PasswordChar = '*';
            }
        }

        private void btnResgister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                conn.GetSqlConnection().Open();
                string register = "INSERT INTO Account VALUES ('" + txtUserName.Text + "', '" + txtPassword.Text + "')";
                SqlCommand cmd = new SqlCommand(register, conn.GetSqlConnection());
                cmd.ExecuteNonQuery();
                conn.GetSqlConnection();

                MessageBox.Show("Your Account Has Been Created", "Registation Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password Doesn't Match, Please Re-enter", "Registation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }
    }
}
