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
using Font = System.Drawing.Font;
using Image = System.Drawing.Image;

namespace TimViec
{
    public partial class FInformation : MaterialForm
    {
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        private DbConnection dbConnection;

        private int workerId;
        private int userId;
        public FInformation(int userId, int workerId)
        {
            InitializeComponent();
            dbConnection = new DbConnection();

            this.workerId = workerId;
            this.userId = userId;
            System.Diagnostics.Debug.WriteLine($"FInfor form: workerId = {this.workerId}");
            System.Diagnostics.Debug.WriteLine($"FInfor form: userId = {this.userId}");

            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightGreen900,
                                                                Primary.LightGreen700,
                                                                Primary.LightGreen500,
                                                                Accent.LightGreen200,
                                                                TextShade.WHITE);
        }

        private void Information_Load(object sender, EventArgs e)
        {
            LoadWorkHistory(workerId);
            LoadInformationWorker(workerId);
            LoadWorkerReview(workerId);
        }

        private Label CreateLabel(string text, Font font, Point location)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = font;
            label.AutoSize = true;
            label.Location = location;
            label.TextAlign = ContentAlignment.TopLeft;
            return label;
        }

        private void AddControlsToPanel(Image image, string label1Text, string label4Text, string category, string price)
        {
            // Create and configure picture box
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(170, 170);
            pictureBox.Location = new Point(610, 20);

            // Create and configure labels
            Label label1 = CreateLabel(label1Text, new Font("Nirmala UI", 14, FontStyle.Bold), new Point(35, 10));
            label1.ForeColor = Color.Chocolate;

            Label label4 = CreateLabel(label4Text, new Font("Nirmala UI", 12), new Point(35, 50));

            Label lableCategory = CreateLabel("Category: " + category, new Font("Nirmala UI", 12), new Point(35, 90));

            Label labelPrice = CreateLabel("Price: " + price, new Font("Nirmala UI", 12), new Point(35, 130));

            // Create a new panel
            MaterialCard card = new MaterialCard();
            card.Width = 800;
            card.Height = 250;
            card.BackColor = Color.White;

            // Add controls to the card
            card.Controls.Add(label1);
            card.Controls.Add(label4);
            card.Controls.Add(pictureBox);
            card.Controls.Add(lableCategory);
            card.Controls.Add(labelPrice);

            flowLayoutPanel1.Controls.Add(card);
        }

        public void AddControlsToReview(Image userImage, string userName, string comment)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = userImage;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(80, 80);
            pictureBox.Location = new Point(10, 20);

            Label labelUserName = CreateLabel(userName, new Font("Nirmala UI", 14, FontStyle.Bold), new Point(110, 30));

            Label labelComment = CreateLabel(comment, new Font("Nirmala UI", 12), new Point(110, 70));

            MaterialCard card = new MaterialCard();
            card.Width = 640;
            card.Height = 150;
            card.BackColor = Color.White;

            card.Controls.Add(pictureBox);
            card.Controls.Add(labelUserName);
            card.Controls.Add(labelComment);

            panelReview.Controls.Add(card);
        }


        public void LoadWorkerReview(int workerId)
        {
            WorkerDAO workerDAO = new WorkerDAO();
            List<Ratings> reviews = workerDAO.LoadRatingInfo(workerId);

            foreach (Ratings review in reviews)
            {
                var imagePath = review.UserImagePath;
                var image = !string.IsNullOrEmpty(imagePath) ? Image.FromFile(imagePath) : null;

                string userName = review.UserName;
                string comment = review.Comment;

                // Debug output
                System.Diagnostics.Debug.WriteLine($"userName: {userName}, imagePath: {imagePath}");

                AddControlsToReview(image, userName, comment);
            }
        }


        private void LoadWorkHistory(int workerId)
        {
            JobDAO jobDAO = new JobDAO();
            List<JobInfor> jobs = jobDAO.LoadWorkHistory(workerId);

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

        private void materialButton5_Click(object sender, EventArgs e)
        {
            FReview reviewForm = new FReview(this.userId, this.workerId);
            reviewForm.Show();
        }


        private void LoadInformationWorker(int workerId)
        {
            WorkerDAO workerDAO = new WorkerDAO();
            Worker worker = workerDAO.LoadInformationWorker(workerId);

            if (worker != null)
            {
                // Process the data from the worker
                var imagePath = worker.ImagePath;
                var image = !string.IsNullOrEmpty(imagePath) ? Image.FromFile(imagePath) : null;
                if (image != null)
                {
                    picBoxWorker.Image = image;
                }

                lbName.Text = worker.Name;
                lbGender.Text = worker.Gender;
                lbAddress.Text = worker.Address;
                lbPhone.Text = worker.Phone;
                lbEmail.Text = worker.Email;
                lbSalary.Text = worker.Salary;
                lbRate.Text = worker.AvgStars.ToString();
            }
        }

        private void btnHire_Click(object sender, EventArgs e)
        {
            ClientDAO clientDAO = new ClientDAO();
            if (clientDAO.HireWorker(userId, workerId))
            {
                MessageBox.Show("Hire successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("You have already hired this worker.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
