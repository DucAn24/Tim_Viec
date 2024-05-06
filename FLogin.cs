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

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            new FResgister().Show();
            this.Hide();
        }

        private (int UserId, int Role) GetUserIdAndRoleFromDatabase(string username, string password)
        {
            AccountDAO accountDAO = new AccountDAO();
            return accountDAO.GetUserIdAndRole(username, password);
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
                    this.Hide(); 
                }
                else if (role == 1)
                {
                    new FWorker(userId).Show();
                    this.Hide(); 
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
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
