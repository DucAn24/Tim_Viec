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
            this.category = category;
            this.worker_id = GetWorkerIdFromUserId(userID);

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


        public int GetWorkerIdFromUserId(int userId)
        {
            int workerId = -1; // Initialize to -1 to represent not found

            // Open the database connection
            dbConnection.Open();

            // Create the SQL command to get the worker_id
            string query = @"
                        SELECT W.Worker_id
                        FROM Users U
                        JOIN Worker W
                        ON U.user_id = W.user_id
                        WHERE U.user_id = @UserId
                    ";

            SqlCommand command = new SqlCommand(query, dbConnection.Connection);

            // Add the user_id parameter to the command
            command.Parameters.AddWithValue("@UserId", userId);

            // Execute the command and get the result
            object result = command.ExecuteScalar();

            // If a result was returned, set the workerId
            if (result != null)
            {
                workerId = (int)result;
            }

            // Close the database connection
            dbConnection.Close();

            return workerId;
        }



        private void AddControlsToPanel(Image image, string label1Text, string label2Text, string label3Text, object job_id, object worker_id)
        {

            System.Diagnostics.Debug.WriteLine($"Received job_id: {job_id}");
            //create and configure picture box
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Set this to Zoom
            pictureBox.Size = new Size(90, 90); // Set this to desired size
            pictureBox.Location = new Point(20, 20);


            // Create and configure label 1
            Label label1 = new Label();
            label1.Text = label1Text;
            label1.AutoSize = true;
            label1.ForeColor = Color.Chocolate;
            label1.Font = new Font("Nirmala UI", 12, FontStyle.Bold);
            label1.Location = new Point(120, 20);


            // Create and configure label 2
            Label label2 = new Label();
            label2.Text = label2Text;
            label2.AutoSize = true;
            label2.ForeColor = Color.LightGreen;
            label2.Font = new Font("Nirmala UI", 16, FontStyle.Bold);
            label2.Location = new Point(120, 50);


            // Create and configure label 3
            Label label3 = new Label();
            label3.Text = label3Text;
            label3.AutoSize = true;
            label3.Location = new Point(20, 120);

            // Create a new panel
            MaterialCard card = new MaterialCard();
            card.Width = 700; // Set panel width as needed
            card.Height = 250;
            card.BackColor = Color.White; // Set panel background color if needed
            card.Tag = new { WorkerId = this.worker_id, JobId = job_id };

            MaterialButton btnAcceptJob = new MaterialButton();
            btnAcceptJob.Text = "Accept Job";
            btnAcceptJob.Location = new Point(20, 200);
            btnAcceptJob.Tag = card; // Store the panel in the Hire button's Tag property
            btnAcceptJob.Click += (sender, e) =>
            {
                // Get the panel from the Hire button's Tag property
                MaterialCard card = (MaterialCard)((MaterialButton)sender).Tag;

                // Get the job ID and worker ID from the panel's Tag property
                var jobId = ((dynamic)card.Tag).JobId;
                System.Diagnostics.Debug.WriteLine($"Retrieved job_id: {jobId}");

                var workerId = ((dynamic)card.Tag).WorkerId;

                // Open the database connection
                dbConnection.Open();

                // Check if the worker has already applied for this job
                string checkQuery = @"
                                    SELECT COUNT(*) 
                                    FROM Applications 
                                    WHERE job_id = @JobId AND Worker_id = @WorkerId
                                ";

                SqlCommand checkCommand = new SqlCommand(checkQuery, dbConnection.Connection);
                checkCommand.Parameters.AddWithValue("@JobId", jobId);
                checkCommand.Parameters.AddWithValue("@WorkerId", workerId);

                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("You have already applied for this job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Create the SQL command to insert the data
                    string query = @"
                                    INSERT INTO Applications (job_id, Worker_id)
                                    VALUES (@JobId, @WorkerId)
                                ";

                    SqlCommand command = new SqlCommand(query, dbConnection.Connection);

                    // Add the parameters to the command
                    command.Parameters.AddWithValue("@JobId", jobId);
                    command.Parameters.AddWithValue("@WorkerId", workerId);

                    // Execute the command
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Job application successfully submitted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inserting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Close the database connection
                dbConnection.Close();
            };

            // add controls to the card
            card.Controls.Add(label1);
            card.Controls.Add(label2);
            card.Controls.Add(label3);
            card.Controls.Add(pictureBox);
            card.Controls.Add(btnAcceptJob);


            flowLayoutPanel1.Controls.Add(card);

        }
        private void LoadDataAndAddPanels(string category)
        {
            dbConnection.Open();
            string query = @"
                    SELECT J.JobTitle,
                            J.JobDescription,
                            J.Price,
                            J.ImagesJob,
                            J.job_id
                    FROM JobList J
                    WHERE J.Category = @Category
                    ";

            SqlCommand command = new SqlCommand(query, dbConnection.Connection);
            command.Parameters.AddWithValue("@Category", category);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var jobId = reader["job_id"];
                System.Diagnostics.Debug.WriteLine($"Read job_id: {jobId}");

                var imagePath = reader["ImagesJob"] as string;
                var image = !string.IsNullOrEmpty(imagePath) ? Image.FromFile(imagePath) : null;

                string label1Text = reader["JobTitle"].ToString();
                string label2Text = reader["Price"].ToString();
                string label3Text = reader["JobDescription"].ToString();

                AddControlsToPanel(image, label1Text, label2Text, label3Text, jobId, this.worker_id);
            }
            dbConnection.Close();
        }

        public void SearchJobs(string jobTitle, string orderByPrice)
        {
            // Open the database connection
            dbConnection.Open();

            // Create the SQL command to search for jobs
            string query = @"
                SELECT J.JobTitle, J.JobDescription, J.Price, J.ImagesJob, J.job_id
                FROM JobList J
                WHERE J.JobTitle LIKE @JobTitle
            ";

            if (!string.IsNullOrEmpty(orderByPrice))
            {
                query += $" ORDER BY J.Price {orderByPrice}";
            }

            SqlCommand command = new SqlCommand(query, dbConnection.Connection);

            // Add the jobTitle parameter to the command
            command.Parameters.AddWithValue("@JobTitle", "%" + jobTitle + "%");

            // Execute the command and get the result
            SqlDataReader reader = command.ExecuteReader();

            // Clear the existing panels
            flowLayoutPanel1.Controls.Clear();

            // Add a new panel for each job
            while (reader.Read())
            {
                var jobId = reader["job_id"];
                var imagePath = reader["ImagesJob"] as string;
                var image = !string.IsNullOrEmpty(imagePath) ? Image.FromFile(imagePath) : null;
                string label1Text = reader["JobTitle"].ToString();
                string label2Text = reader["Price"].ToString();
                string label3Text = reader["JobDescription"].ToString();

                AddControlsToPanel(image, label1Text, label2Text, label3Text, jobId, this.worker_id);
            }

            // Close the database connection
            dbConnection.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchJobs(txtSearch.Text, cbxPrice.SelectedItem.ToString());
        }



    }
}









