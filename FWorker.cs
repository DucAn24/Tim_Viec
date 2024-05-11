﻿using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Image = System.Drawing.Image;
using Label = System.Windows.Forms.Label;
using ScottPlot;


namespace TimViec
{
    public partial class FWorker : MaterialForm
    {
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        private DbConnection dbConnection;

        JobDAO jobDAO = new JobDAO();
        WorkerDAO workerDAO = new WorkerDAO();
        private int userId;
        private int worker_id;

        private Dictionary<MaterialCard, string> cardToCategoryMap;
        private Dictionary<PictureBox, string> pictureToCategoryMap;


        public FWorker(int userId)
        {
            this.userId = userId;
            dbConnection = new DbConnection();
            WorkerDAO workerDAO = new WorkerDAO();
            this.worker_id = workerDAO.GetWorkerIdFromUserId(userId);

            InitializeComponent();
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


            FListJob.OnJobApplied += RefeshData;
        }

        private void Worker_Load(object sender, EventArgs e)
        {
            AddPanelToWorkDone(worker_id);
            LoadWorkerData();
            LoadAllDataAppointment();
            LoadPendingAppointment();
            CreatePieChart();
            LoadAnalytics();
        }

        private void RefeshData()
        {
            AddPanelToWorkDone(worker_id);
            LoadWorkerData();
            LoadAllDataAppointment();
            LoadPendingAppointment();
            CreatePieChart();
            LoadAnalytics();
        }

        private void LoadWorkerData()
        {
            Worker worker = workerDAO.LoadWorkerData(this.worker_id);

            if (worker != null)
            {
                // Assign the data to the text boxes
                txtName.Text = worker.Name;
                txtEmail.Text = worker.Email;
                txtPhone.Text = worker.Phone;
                txtAddress.Text = worker.Address;

                if (!string.IsNullOrEmpty(worker.ImagePath) && File.Exists(worker.ImagePath))
                {
                    picBoxUser.Image = Image.FromFile(worker.ImagePath);
                }
                else
                {
                    picBoxUser.Image = null;
                }


                txtBio.Text = worker.Bio;
                txtSkill.Text = worker.Skills;
                cbxCategory2.Text = worker.Category;
                txtSalary.Text = worker.Salary;

                ckbMale.Checked = worker.Gender == "Male";
                ckbFemale.Checked = worker.Gender == "Female";

                if (worker.DateOfBirth >= dtpBirth.MinDate && worker.DateOfBirth <= dtpBirth.MaxDate)
                {
                    dtpBirth.Value = worker.DateOfBirth;
                }
                else
                {
                    dtpBirth.Value = DateTime.Now;
                }
                imagePath = worker.ImagePath;
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedPictureBox && pictureToCategoryMap.TryGetValue(clickedPictureBox, out string category))
            {
                OpenFListJob(category, userId);
            }
        }

        private void MaterialCard_Click(object sender, EventArgs e)
        {
            if (sender is MaterialCard clickedCard && cardToCategoryMap.TryGetValue(clickedCard, out string category))
            {
                OpenFListJob(category, userId);
            }
        }

        private void OpenFListJob(string category, int userID)
        {
            FListJob jobList = new FListJob(category, userID);
            jobList.Show();
        }

        private void materialTabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.materialTabControl1.SelectedIndex == 6)
            {
                this.Hide();
                new FLogin().Show();
            }
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
        private void btnImportJob_Click_1(object sender, EventArgs e)
        {
            imageJob = SelectImageFile(pictureBoxJob);
        }

        private Label CreateLabel(string text, Font font, Point location)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = font;
            label.AutoSize = true;
            label.MaximumSize = new Size(440, 0);
            label.Location = location;
            label.TextAlign = ContentAlignment.TopLeft;
            return label;
        }

        private void AddControlsToPanel(Image image, string label1Text, string label4Text, string category, string price)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(150, 150);
            pictureBox.Location = new Point(500, 20);

            Label label1 = CreateLabel(label1Text, new Font("Nirmala UI", 14, System.Drawing.FontStyle.Bold), new Point(40, 10));
            label1.ForeColor = Color.Chocolate;

            Label label4 = CreateLabel(label4Text, new Font("Nirmala UI", 12), new Point(40, 50));

            Label lableCategory = CreateLabel("Category: " + category, new Font("Nirmala UI", 12), new Point(40, 130));

            Label labelPrice = CreateLabel("Price: " + price, new Font("Nirmala UI", 12), new Point(40, 190));


            MaterialCard card = new MaterialCard();
            card.Width = 680;
            card.Height = 250;
            card.BackColor = Color.White;

            card.Controls.Add(label1);
            card.Controls.Add(label4);
            card.Controls.Add(pictureBox);
            card.Controls.Add(lableCategory);
            card.Controls.Add(labelPrice);

            flpWorkDone.Controls.Add(card);
        }

        private void AddPanelToWorkDone(int workerId)
        {
            List<JobInfor> jobs = jobDAO.LoadWorkDone(workerId);

            foreach (JobInfor job in jobs)
            {
                var imagePath = job.ImageJob;
                var image = !string.IsNullOrEmpty(imagePath) ? Image.FromFile(imagePath) : null;

                string label1Text = job.JobTitle;
                string label2Text = job.JobDescription;
                string category = job.Category;
                string price = job.Price;

                AddControlsToPanel(image, label1Text, label2Text, category, price);
            }
        }

        public void AddControlsToAppointment(Image userImagePath, string userName, string content, string date, string status)
        {
            var pictureBox = new PictureBox
            {
                Image = userImagePath,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(100, 100),
                Location = new Point(10, 10)
            };

            var labelWorkerName = new Label
            {
                Text = userName,
                AutoSize = true,
                ForeColor = Color.Chocolate,
                Font = new Font("Nirmala UI", 16, System.Drawing.FontStyle.Bold),
                Location = new Point(130, 10)
            };

            var labelStatus = new Label
            {
                Text = status,
                AutoSize = true,
                ForeColor = Color.LightGreen,
                Font = new Font("Nirmala UI", 14, System.Drawing.FontStyle.Bold),
                Location = new Point(130, 50),
                TextAlign = ContentAlignment.TopLeft
            };

            var labelContent = new Label
            {
                Text = "Content: " + content,
                AutoSize = true,
                ForeColor = Color.DarkGray,
                Font = new Font("Nirmala UI", 12, System.Drawing.FontStyle.Bold),
                Location = new Point(20, 120),
                TextAlign = ContentAlignment.TopLeft
            };

            var labelDate = new Label
            {
                Text = "Date: " + date,
                AutoSize = true,
                ForeColor = Color.DarkGray,
                Font = new Font("Nirmala UI", 12, System.Drawing.FontStyle.Bold),
                Location = new Point(20, 150),
                TextAlign = ContentAlignment.TopLeft
            };

            var card = new MaterialCard
            {
                Width = 420,
                Height = 220,
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

        public void AddControlsToAppointmentPending(Image userImagePath, string userName, string content, string date, string status, string appointmentId)
        {
            var pictureBox = new PictureBox
            {
                Image = userImagePath,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(100, 100),
                Location = new Point(10, 10)
            };

            var labelWorkerName = new Label
            {
                Text = userName,
                AutoSize = true,
                ForeColor = Color.Chocolate,
                Font = new Font("Nirmala UI", 16, System.Drawing.FontStyle.Bold),
                Location = new Point(130, 10)
            };

            var labelStatus = new Label
            {
                Text = status,
                AutoSize = true,
                ForeColor = Color.LightGreen,
                Font = new Font("Nirmala UI", 14, System.Drawing.FontStyle.Bold),
                Location = new Point(130, 50),
                TextAlign = ContentAlignment.TopLeft
            };

            var labelContent = new Label
            {
                Text = "Content: " + content,
                AutoSize = true,
                ForeColor = Color.DarkGray,
                Font = new Font("Nirmala UI", 12, System.Drawing.FontStyle.Bold),
                Location = new Point(20, 120),
                TextAlign = ContentAlignment.TopLeft
            };

            var labelDate = new Label
            {
                Text = "Date: " + date,
                AutoSize = true,
                ForeColor = Color.DarkGray,
                Font = new Font("Nirmala UI", 12, System.Drawing.FontStyle.Bold),
                Location = new Point(20, 150),
                TextAlign = ContentAlignment.TopLeft
            };

            var btnAccept = new MaterialButton
            {
                Text = "Accept",
                Location = new Point(20, 200),
                Size = new Size(100, 30),
                BackColor = Color.LightGreen,
                ForeColor = Color.White
            };

            var btnCancel = new MaterialButton
            {
                Text = "Cancel",
                Location = new Point(110, 200),
                Size = new Size(100, 30),
                BackColor = Color.LightGreen,
                ForeColor = Color.White
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
            card.Controls.Add(btnAccept);
            card.Controls.Add(btnCancel);

            btnAccept.Click += (sender, e) =>
            {
                AppointmentDAO appointmentDAO = new AppointmentDAO();
                bool isUpdated = appointmentDAO.UpdateAppointmentStatus(appointmentId, "Accepted");

                if (isUpdated)
                {
                    panelPending.Controls.Remove(card);
                    MessageBox.Show("Appointment status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update appointment status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };


            btnCancel.Click += (sender, e) =>
            {
                AppointmentDAO appointmentDAO = new AppointmentDAO();
                bool isUpdated = appointmentDAO.UpdateAppointmentStatus(appointmentId, "Cancel");

                if (isUpdated)
                {
                    panelPending.Controls.Remove(card);
                    MessageBox.Show("Appointment status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update appointment status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };


            panelPending.Controls.Add(card);

        }

        private void LoadAllDataAppointment()
        {
            AppointmentDAO appointmentDAO = new AppointmentDAO();
            List<Appointment> appointments = appointmentDAO.AppointmentsForWorker(this.worker_id);

            foreach (var appointment in appointments)
            {
                var userImage = !string.IsNullOrEmpty(appointment.UserImagePath) ? Image.FromFile(appointment.UserImagePath) : null;

                AddControlsToAppointment(userImage, appointment.UserName, appointment.Content, appointment.DateTime.ToString(), appointment.Status);
            }

        }

        private void LoadPendingAppointment()
        {
            AppointmentDAO appointmentDAO = new AppointmentDAO();
            List<Appointment> appointments = appointmentDAO.SearchForWorker(this.worker_id, "Pending");

            foreach (var appointment in appointments)
            {
                var userImage = !string.IsNullOrEmpty(appointment.UserImagePath) ? Image.FromFile(appointment.UserImagePath) : null;

                AddControlsToAppointmentPending(userImage, appointment.UserName, appointment.Content, appointment.DateTime.ToString(), appointment.Status, appointment.AppointmentId);
            }

        }

        private void SearchAppointment(int workerId)
        {
            string statusPick = cbxStatus.SelectedItem.ToString();
            AppointmentDAO appointmentDAO = new AppointmentDAO();
            List<Appointment> appointments = appointmentDAO.SearchForWorker(workerId, statusPick);
            panelAppointment.Controls.Clear();

            foreach (var appointment in appointments)
            {
                var usersImage = !string.IsNullOrEmpty(appointment.UserImagePath) ? Image.FromFile(appointment.UserImagePath) : null;

                AddControlsToAppointment(usersImage, appointment.UserName, appointment.Content, appointment.DateTime.ToString(), appointment.Status);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Worker worker = new Worker(txtName.Text, txtEmail.Text, dtpBirth.Value, imagePath, txtPhone.Text, txtAddress.Text, gender, txtBio.Text, txtSkill.Text, cbxCategory2.Text, txtSalary.Text);
            bool isUpdated = workerDAO.UpdateWorkerInformation(worker, this.userId);
            if (isUpdated)
            {
                MessageBox.Show("Worker information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update Worker information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmitJob_Click(object sender, EventArgs e)
        {
            JobInfor jobInfor = new JobInfor(txtTitle.Text, txtDescription.Text, cbxCategory.Text, txtPrice.Text, imageJob);
            bool isUpdated = jobDAO.AddJobHistory(jobInfor, this.worker_id);
            if (isUpdated)
            {
                MessageBox.Show("Job history information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update job history information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchAppointment(this.worker_id);
        }

        private void CreatePieChart()
        {
            WorkerDAO workerDAO = new WorkerDAO();

            Dictionary<string, int> jobCountPerCategory = workerDAO.GetJobCountPerCategory(this.worker_id);

            System.Drawing.Color[] colors = new System.Drawing.Color[] { System.Drawing.Color.Red, System.Drawing.Color.Orange, System.Drawing.Color.Yellow, System.Drawing.Color.Green, System.Drawing.Color.Blue, System.Drawing.Color.Indigo, System.Drawing.Color.Violet };

            List<PieSlice> slices = new List<PieSlice>();
            int colorIndex = 0;
            foreach (KeyValuePair<string, int> entry in jobCountPerCategory)
            {
                System.Drawing.Color systemColor = colors[colorIndex % colors.Length];
                ScottPlot.Color scottPlotColor = new ScottPlot.Color(systemColor.R, systemColor.G, systemColor.B);

                slices.Add(new PieSlice() { Value = entry.Value, FillColor = scottPlotColor, Label = $"{entry.Key} ({entry.Value})" });
                colorIndex++;
            }

            var pie = pieChartPlot.Plot.Add.Pie(slices);
            pie.DonutFraction = .5;
            pie.ShowSliceLabels = true;

            pieChartPlot.Refresh();
        }

        private void LoadAnalytics()
        {
            WorkerDAO workerDAO = new WorkerDAO();
            labelRevenue.Text ="$ " + workerDAO.GetTotalRevenue(this.worker_id).ToString();
            labelStar.Text = workerDAO.GetAverageRating(this.worker_id).ToString();
            labelWorkDone.Text = workerDAO.GetTotalWorkDone(this.worker_id).ToString();
        }





    }
}
