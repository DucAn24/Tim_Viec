using MaterialSkin.Controls;
using MaterialSkin;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data.Common;

namespace TimViec
{
    public partial class FListJob : MaterialForm
    {
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        private DbConnection dbConnection;
        private string category;
        private int worker_id;


        public FListJob(string category, int userID)
        {
            InitializeComponent();
            dbConnection = new DbConnection();
            WorkerDAO workerDAO = new WorkerDAO();
            this.worker_id = workerDAO.GetWorkerIdFromUserId(userID);
            this.category = category; 


            materialSkinManager.EnforceBackcolorOnAllComponents = false;

            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightGreen900,
                                                                Primary.LightGreen700,
                                                                Primary.LightGreen500,
                                                                Accent.LightGreen200,
                                                                TextShade.WHITE);
        }

        private void FListJob_Load(object sender, EventArgs e)
        {
            LoadDataAndAddPanels(category);
        }

        public static event Action OnJobApplied;
        private void AddControlsToPanel(Image image, string label1Text, string label2Text, string label3Text, object job_id, object worker_id)
        {
            // Create a new panel
            MaterialCard card = new MaterialCard();
            card.Width = 700; 
            card.Height = 250;
            card.BackColor = Color.White; 
            card.Tag = new { WorkerId = this.worker_id, JobId = job_id };

            PictureBox pictureBox = CreatePictureBox(image);

            Label label1 = CreateLabel(label1Text, new Point(120, 20), new Font("Nirmala UI", 12, FontStyle.Bold), Color.Chocolate);
            Label label2 = CreateLabel(label2Text, new Point(120, 50), new Font("Nirmala UI", 16, FontStyle.Bold), Color.LightGreen);
            Label label3 = CreateLabel(label3Text, new Point(20, 120));

            // Create and configure button
            MaterialButton btnAcceptJob = CreateButton("Accept Job", new Point(20, 200));
            btnAcceptJob.Click += (sender, e) =>
            {
                var jobId = ((dynamic)card.Tag).JobId;
                var workerId = ((dynamic)card.Tag).WorkerId;

                WorkerDAO workerDAO = new WorkerDAO();
                bool success = workerDAO.ApplyForJob(jobId, workerId);

                if (success)
                {
                    MessageBox.Show("Job application successfully submitted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnJobApplied?.Invoke();
                }
                else
                {
                    MessageBox.Show("You have already applied for this job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            card.Controls.AddRange(new Control[] { label1, label2, label3, pictureBox, btnAcceptJob });

            flowLayoutPanel1.Controls.Add(card);
        }

        private PictureBox CreatePictureBox(Image image)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; 
            pictureBox.Size = new Size(90, 90); 
            pictureBox.Location = new Point(20, 20);
            return pictureBox;
        }

        private Label CreateLabel(string text, Point location, Font font = null, Color? color = null)
        {
            Label label = new Label();
            label.Text = text;
            label.AutoSize = true;
            label.Location = location;
            if (font != null) label.Font = font;
            if (color.HasValue) label.ForeColor = color.Value;
            return label;
        }

        private MaterialButton CreateButton(string text, Point location)
        {
            MaterialButton button = new MaterialButton();
            button.Text = text;
            button.Location = location;
            return button;
        }


        private void LoadDataAndAddPanels(string category)
        {
            JobDAO jobDAO = new JobDAO();
            List<JobInfor> jobs = jobDAO.GetJobsByCategory(category);

            foreach (JobInfor job in jobs)
            {
                var imagePath = job.ImageJob;
                var image = !string.IsNullOrEmpty(imagePath) ? Image.FromFile(imagePath) : null;

                string label1Text = job.JobTitle;
                string label2Text = job.Price;
                string label3Text = job.JobDescription;

                AddControlsToPanel(image, label1Text, label2Text, label3Text, job.JobId, this.worker_id);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            JobDAO jobDAO = new JobDAO();
            List<JobInfor> jobs = jobDAO.SearchJobs(txtSearch.Text, cbxPrice.SelectedItem.ToString());

            // Clear the existing panels
            flowLayoutPanel1.Controls.Clear();

            foreach (JobInfor job in jobs)
            {
                var imagePath = job.ImageJob;
                var image = !string.IsNullOrEmpty(imagePath) ? Image.FromFile(imagePath) : null;

                string label1Text = job.JobTitle;
                string label2Text = job.Price;
                string label3Text = job.JobDescription;

                AddControlsToPanel(image, label1Text, label2Text, label3Text, job.JobId, this.worker_id);
            }
        }


    }
}









