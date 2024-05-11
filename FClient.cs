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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.DataFormats;
using Font = System.Drawing.Font;
using Image = System.Drawing.Image;


namespace TimViec
{
    public partial class FClient : MaterialForm
    {

        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        private DbConnection dbConnection;

        ClientDAO clientDAO = new ClientDAO();
        JobDAO jobDAO = new JobDAO();


        private int userId;

        private Dictionary<MaterialCard, string> cardToCategoryMap;
        private Dictionary<PictureBox, string> pictureToCategoryMap;



        public FClient(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            System.Diagnostics.Debug.WriteLine($"FClient form: userId = {this.userId}");


            dbConnection = new DbConnection();

            materialSkinManager.EnforceBackcolorOnAllComponents = false;

            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightGreen900,
                                                                Primary.LightGreen700,
                                                                Primary.LightGreen500,
                                                                Accent.LightGreen200,
                                                                TextShade.WHITE);


            cardToCategoryMap = new Dictionary<MaterialCard, string>
            {
                { materialCard6, "Devlopment-IT" },
                { materialCard14, "AI-Services" },
                { materialCard12, "Design-Creative" },
                { materialCard10, "Sales-Marketing" },
                { materialCard15, "Writing-Traslation" },
                { materialCard16, "Admin-Custome Support" },
                { materialCard17, "Finance-Accounting" },
                { materialCard18, "Engineering-Architecture" },
            };

            pictureToCategoryMap = new Dictionary<PictureBox, string>
            {
                { pictureBox2, "Devlopment-IT" },
                { pictureBox3, "AI-Services" },
                { pictureBox4, "Design-Creative" },
                { pictureBox5, "Sales-Marketing" },
                { pictureBox6, "Engineering-Architecture" },
                { pictureBox7, "Finance-Accounting" },
                { pictureBox8, "Admin-Custome-Support" },
                { pictureBox9, "Writing-Traslation" },
            };

            foreach (var pair in cardToCategoryMap)
            {
                pair.Key.Click += MaterialCard_Click;
            }

            foreach (var pair in pictureToCategoryMap)
            {
                pair.Key.Click += PictureBox_Click;
            }


            //FListWorker.WorkerAddedToFavourites += RefreshData;
            //FListWorker.WorkerHired += RefreshData;

        }

        private void Home_Load(object sender, EventArgs e)
        {

            LoadDataHired();
            LoadDataFavourite();
            LoadUserData();
            LoadDataAppointment();

        }

        public void RefreshData()
        {
            LoadDataHired();
            LoadDataFavourite();
            LoadUserData();
            LoadDataAppointment();
        }

        //  Log out
        private void materialTabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.materialTabControl1.SelectedIndex == 5)
            {
                this.Hide();
                new FLogin().Show();
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedPictureBox && pictureToCategoryMap.TryGetValue(clickedPictureBox, out string category))
            {
                OpenWokerListForm(category, userId);
            }
        }

        private void MaterialCard_Click(object sender, EventArgs e)
        {
            if (sender is MaterialCard clickedCard && cardToCategoryMap.TryGetValue(clickedCard, out string category))
            {
                OpenWokerListForm(category, userId);
            }
        }

        private void OpenWokerListForm(string category, int userID)
        {
            FListWorker workerList = new FListWorker(category, userID);
            workerList.Show();
        }

        private string imagePath;
        private string imageJob;

        private string SelectImageFile(PictureBox pictureBox)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = new Bitmap(ofd.FileName);
                    return ofd.FileName;
                }
            }
            return null;
        }

        private void btnImportImage_Click(object sender, EventArgs e)
        {
            imagePath = SelectImageFile(picBoxUser);
        }

        private void btnImportJob_Click(object sender, EventArgs e)
        {
            imageJob = SelectImageFile(pictureBoxJob);
        }

        private string gender;

        private void ckbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFemale.Checked == true)
            {
                ckbMale.Checked = false;
                gender = "Female";
            }
        }

        private void ckbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMale.Checked == true)
            {
                ckbFemale.Checked = false;
                gender = "Male";
            }
        }

        private void LoadUserData()
        {
            Client client = clientDAO.LoadUserData(this.userId);

            if (client != null)
            {
                // Assign the data to the text boxes
                txtName.Text = client.Name;
                txtEmail.Text = client.Email;
                txtPhoneNumber.Text = client.Phone;
                txtLocation.Text = client.Address;

                if (!string.IsNullOrEmpty(client.ImagePath) && File.Exists(client.ImagePath))
                {
                    picBoxUser.Image = Image.FromFile(client.ImagePath);
                }
                else
                {
                    picBoxUser.Image = null;
                }

                ckbMale.Checked = client.Gender == "Male";
                ckbFemale.Checked = client.Gender == "Female";
                if (client.DateOfBirth >= dtpBirth.MinDate && client.DateOfBirth <= dtpBirth.MaxDate)
                {
                    dtpBirth.Value = client.DateOfBirth;
                }
                else
                {
                    dtpBirth.Value = DateTime.Now;
                }
            }
        }

        private void AddControlsToPanelHIred(Image image, string label1Text, string label2Text, string email, string phone)
        {
            var pictureBox = new PictureBox
            {
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(80, 80),
                Location = new Point(10, 10)
            };

            var label1 = new Label
            {
                Text = label1Text,
                AutoSize = true,
                ForeColor = Color.Chocolate,
                Font = new Font("Nirmala UI", 16, FontStyle.Bold),
                Location = new Point(20, 90)
            };

            var label2 = new Label
            {
                Text = label2Text,
                AutoSize = true,
                ForeColor = Color.LightGreen,
                Font = new Font("Nirmala UI", 14, FontStyle.Bold),
                Location = new Point(20, 150),
                TextAlign = ContentAlignment.TopLeft
            };

            var emailLabel = new Label
            {
                Text = "Email: " + email,
                AutoSize = true,
                ForeColor = Color.DarkGray,
                Font = new Font("Nirmala UI", 12, FontStyle.Bold),
                Location = new Point(20, 200),
                TextAlign = ContentAlignment.TopLeft
            };

            var phoneLabel = new Label
            {
                Text = "Phone: " + phone,
                AutoSize = true,
                ForeColor = Color.DarkGray,
                Font = new Font("Nirmala UI", 12, FontStyle.Bold),
                Location = new Point(20, 220),
                TextAlign = ContentAlignment.TopLeft
            };

            var card = new MaterialCard
            {
                Width = 300,
                Height = 290,
                BackColor = Color.White
            };

            card.Controls.Add(label1);
            card.Controls.Add(label2);
            card.Controls.Add(pictureBox);
            card.Controls.Add(emailLabel);
            card.Controls.Add(phoneLabel);

            flowLayoutPanel1.Controls.Add(card);
        }

        private Dictionary<MaterialCard, int> cardToWorkerIdMap = new Dictionary<MaterialCard, int>();


        private void AddControlsToPanelFavourite(Image image, string FullName, string PhoneNumber, string Address, string Email, string age, int workerId)
        {
            var pictureBox = new PictureBox
            {
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(60, 60),
                Location = new Point(10, 10)
            };

            var label1 = new Label
            {
                Text = FullName,
                AutoSize = true,
                ForeColor = Color.Chocolate,
                Font = new Font("Nirmala UI", 14, FontStyle.Bold),
                Location = new Point(80, 10)
            };

            var label2 = new Label
            {
                Text = "phone: " + PhoneNumber,
                AutoSize = true,
                ForeColor = Color.LightGreen,
                Font = new Font("Nirmala UI", 12, FontStyle.Bold),
                Location = new Point(20, 90),
                TextAlign = ContentAlignment.TopLeft
            };

            var label3 = new Label
            {
                Text = "Address: " + Address,
                AutoSize = true,
                ForeColor = Color.LightGreen,
                Font = new Font("Nirmala UI", 12, FontStyle.Bold),
                Location = new Point(20, 120),
                TextAlign = ContentAlignment.TopLeft
            };

            var label4 = new Label
            {
                Text = "email: " + Email,
                AutoSize = true,
                ForeColor = Color.LightGreen,
                Font = new Font("Nirmala UI", 12, FontStyle.Bold),
                Location = new Point(20, 150),
                TextAlign = ContentAlignment.TopLeft
            };

            var label5 = new Label
            {
                Text = "Age " + age,
                AutoSize = true,
                ForeColor = Color.LightGreen,
                Font = new Font("Nirmala UI", 12, FontStyle.Bold),
                Location = new Point(20, 180),
                TextAlign = ContentAlignment.TopLeft
            };

            MaterialButton btnUnLike = new MaterialButton();
            btnUnLike.Text = "Unlike";
            btnUnLike.Location = new Point(20, 220);

            btnUnLike.Click += (sender, e) =>
            {
                var card = ((Control)sender).Parent as MaterialCard;

                if (card != null && cardToWorkerIdMap.TryGetValue(card, out int workerId))
                {

                    bool success = clientDAO.RemoveWorkerToFavourites(this.userId, workerId: workerId);

                    if (success)
                    {
                        flowLayoutPanel4.Controls.Remove(card);
                        MessageBox.Show( "Success");
                    }
                    else
                    {

                    }
                }
            };

            var card = new MaterialCard
            {
                Width = 300,
                Height = 270,
                BackColor = Color.White
            };

            card.Controls.Add(label1);
            card.Controls.Add(label2);
            card.Controls.Add(label3);
            card.Controls.Add(label4);
            card.Controls.Add(label5);
            card.Controls.Add(pictureBox);
            card.Controls.Add(btnUnLike);
            cardToWorkerIdMap[card] = workerId;

            flowLayoutPanel4.Controls.Add(card);
        }


        public void AddControlsToAppointment(Image workerImage, string workerName, string content, string date, string status)
        {
            var pictureBox = new PictureBox
            {
                Image = workerImage,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(100, 100),
                Location = new Point(10, 10)
            };

            var labelWorkerName = new Label
            {
                Text = workerName,
                AutoSize = true,
                ForeColor = Color.Chocolate,
                Font = new Font("Nirmala UI", 16, FontStyle.Bold),
                Location = new Point(130, 10)
            };

            var labelStatus = new Label
            {
                Text = status,
                AutoSize = true,
                ForeColor = Color.LightGreen,
                Font = new Font("Nirmala UI", 14, FontStyle.Bold),
                Location = new Point(130, 50),
                TextAlign = ContentAlignment.TopLeft
            };

            var labelContent = new Label
            {
                Text = "Content: " + content,
                AutoSize = true,
                ForeColor = Color.DarkGray,
                Font = new Font("Nirmala UI", 12, FontStyle.Bold),
                Location = new Point(20, 150),
                TextAlign = ContentAlignment.TopLeft
            };

            var labelDate = new Label
            {
                Text = "Date: " + date,
                AutoSize = true,
                ForeColor = Color.DarkGray,
                Font = new Font("Nirmala UI", 12, FontStyle.Bold),
                Location = new Point(20, 200),
                TextAlign = ContentAlignment.TopLeft
            };

            var card = new MaterialCard
            {
                Width = 420,
                Height = 250,
                BackColor = Color.White
            };

            card.Controls.Add(pictureBox);
            card.Controls.Add(labelWorkerName);
            card.Controls.Add(labelStatus);
            card.Controls.Add(labelContent);
            card.Controls.Add(labelDate);
            card.Controls.Add(labelContent);

            panelAppointment.Controls.Add(card);

        }

        private void LoadDataAppointment()
        {
            AppointmentDAO appointmentDAO = new AppointmentDAO();
            List<Appointment> appointments = appointmentDAO.AppointmentsForClient(this.userId);

            foreach (var appointment in appointments)
            {
                var workerImage = !string.IsNullOrEmpty(appointment.WorkerImagePath) ? Image.FromFile(appointment.WorkerImagePath) : null;

                AddControlsToAppointment(workerImage, appointment.WorkerName, appointment.Content, appointment.DateTime.ToString(), appointment.Status);
            }

        }

        private void LoadDataHired()
        {
            DataTable dataTable = clientDAO.LoadDataHired(this.userId);

            foreach (DataRow row in dataTable.Rows)
            {

                var imagePath = row["ImagePath"] as string;
                var image = !string.IsNullOrEmpty(imagePath) ? Image.FromFile(imagePath) : null;

                string label1Text = row["Name"].ToString();
                string label2Text = row["Category"].ToString();
                string email = row["Email"].ToString();
                string phone = row["PhoneNumber"].ToString();

                AddControlsToPanelHIred(image, label1Text, label2Text, email, phone);
            }
        }

        private void LoadDataFavourite()
        {
            DataTable dataTable = clientDAO.LoadDataFavourite(this.userId);

            foreach (DataRow row in dataTable.Rows)
            {

                var imagePath = row["ImagePath"] as string;
                var image = !string.IsNullOrEmpty(imagePath) ? Image.FromFile(imagePath) : null;

                string label1Text = row["Name"].ToString();
                string label2Text = row["PhoneNumber"].ToString();
                string label3Text = row["Category"].ToString();
                string label4Text = row["Email"].ToString();
                int workerId = Convert.ToInt32(row["Worker_id"]);

                // Calculate age from date of birth
                DateTime dateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
                int age = DateTime.Now.Year - dateOfBirth.Year;
                if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                    age = age - 1;

                string label5Text = age.ToString();

                AddControlsToPanelFavourite(image, label1Text, label2Text, label3Text, label4Text, label5Text, workerId);
            }
        }

        private void SearchAppointment(int userId)
        {
            string statusPick = cbxStatus.SelectedItem.ToString();
            AppointmentDAO appointmentDAO = new AppointmentDAO();
            List<Appointment> appointments = appointmentDAO.SearchForClient(userId, statusPick);
            panelAppointment.Controls.Clear();
            foreach (var appointment in appointments)
            {
                var workerImage = !string.IsNullOrEmpty(appointment.WorkerImagePath) ? Image.FromFile(appointment.WorkerImagePath) : null;

                AddControlsToAppointment(workerImage, appointment.WorkerName, appointment.Content, appointment.DateTime.ToString(), appointment.Status);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            // Email validation
            var emailRegex = new System.Text.RegularExpressions.Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
            if (!emailRegex.IsMatch(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Phone validation
            var phoneRegex = new System.Text.RegularExpressions.Regex(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
            if (!phoneRegex.IsMatch(txtPhoneNumber.Text))
            {
                MessageBox.Show("Please enter a valid phone number.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Client client = new Client(txtName.Text, txtEmail.Text, dtpBirth.Value, imagePath, txtPhoneNumber.Text, txtLocation.Text, gender);
            bool isUpdated = clientDAO.UpdateInformation(client, this.userId);
            if (isUpdated)
            {
                MessageBox.Show("Client information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update client information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSumitJob_Click(object sender, EventArgs e)
        {
            JobInfor jobInfor = new JobInfor(txtTitle.Text, txtDescription.Text, cbxCategory.Text, txtPrice.Text, imageJob);
            bool isUpdated = jobDAO.AddJobList(jobInfor, this.userId);
            if (isUpdated)
            {
                MessageBox.Show("Client information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update client information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchAppointment(this.userId);
        }
    }

}
