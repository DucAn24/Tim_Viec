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

namespace TimViec
{
    public partial class FListJob : Form
    {
        public FListJob()
        {
            InitializeComponent();
        }

        private void FListJob_Load(object sender, EventArgs e)
        {

        }
    }
}



/*
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class FListWorker : MaterialForm
    {
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        private DbConnection dbConnection;
        private string category;
        private int userId;

        public FListWorker(string category, int userID)
        {
            InitializeComponent();
            dbConnection = new DbConnection();
            this.category = category;
            this.userId = userID;
            System.Diagnostics.Debug.WriteLine($"FCWorker form: userId = {this.userId}");




            materialSkinManager.EnforceBackcolorOnAllComponents = false;

            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightGreen900,
                                                                Primary.LightGreen700,
                                                                Primary.LightGreen500,
                                                                Accent.LightGreen200,
                                                                TextShade.WHITE);



            materialButton14.Click += (sender, e) =>
            {
                // Get the job title and salary from the text boxes
                string jobTitle = string.IsNullOrEmpty(materialTextBox25.Text) ? null : materialTextBox25.Text;
                //decimal? salary = string.IsNullOrEmpty(materialTextBox21.Text) ? (decimal?)null : decimal.Parse(materialTextBox21.Text);

                // Search for workers
                //SearchWorkers(jobTitle, salary);
            };


        }


        private void WorkerList_Load(object sender, EventArgs e)
        {
            LoadDataAndAddPanels(category);
        }

        private void AddControlsToPanel(Image image, string label1Text, string label2Text, string label3Text, string label4Text, object userId, object jobId, object employerId)
        {


            //create and configure picture box
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Set this to Zoom
            pictureBox.Size = new Size(90, 90); // Set this to desired size
            pictureBox.Location = new Point(20, 20);
            pictureBox.Click += (sender, e) => OpenInformationForm();


            // Create and configure label 1
            Label label1 = new Label();
            label1.Text = label1Text;
            label1.AutoSize = true;
            label1.ForeColor = Color.Chocolate;
            label1.Font = new Font("Nirmala UI", 12, FontStyle.Bold);
            label1.Location = new Point(120, 20);
            label1.Click += (sender, e) => OpenInformationForm();


            // Create and configure label 2
            Label label2 = new Label();
            label2.Text = label2Text;
            label2.AutoSize = true;
            label2.ForeColor = Color.LightGreen;
            label2.Font = new Font("Nirmala UI", 16, FontStyle.Bold);
            label2.Location = new Point(120, 50);
            label2.Click += (sender, e) => OpenInformationForm();

            // Create and configure label 3
            Label label3 = new Label();
            label3.Text = label3Text;
            label3.AutoSize = true;
            label3.Location = new Point(20, 120);
            label3.Click += (sender, e) => OpenInformationForm();

            // Create and configure label 4
            Label label4 = new Label();
            label4.Text = label4Text;
            label4.AutoSize = false; // Set AutoSize to false
            label4.Width = 550;
            label4.Height = 100;
            label4.Location = new Point(120, 100); // Set the location
            label4.TextAlign = ContentAlignment.TopLeft;
            label4.Click += (sender, e) => OpenInformationForm();

            // Create a new panel
            MaterialCard card = new MaterialCard();
            card.Width = 700; // Set panel width as needed
            card.Height = 250;
            card.BackColor = Color.White; // Set panel background color if needed
            card.Click += (sender, e) => OpenInformationForm();
            card.BackColor = Color.White; // Set panel background color if needed
            card.Tag = new { JobId = jobId, UserId = this.userId, EmployerId = employerId };


            MaterialButton btnHire = new MaterialButton();
            btnHire.Text = "Hire Talent";
            btnHire.Location = new Point(120, 200);
            btnHire.Tag = card; // Store the panel in the Hire button's Tag property
            btnHire.Click += (sender, e) =>
            {
                // Get the panel from the Hire button's Tag property
                MaterialCard card = (MaterialCard)((MaterialButton)sender).Tag;

                // Get the job ID and user ID from the panel's Tag property
                var employerId = ((dynamic)card.Tag).EmployerId;
                var userId = ((dynamic)card.Tag).UserId;

                // Check if the user is trying to hire themselves
                if (this.userId == userId)
                {
                    MessageBox.Show("You cannot hire yourself.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Open the database connection
                dbConnection.Open();

                // Check if the status is already "Hired"
                string checkQuery = @"
                        SELECT status 
                        FROM Applications 
                        WHERE job_id = @JobId AND user_id = @UserId
                    ";

                SqlCommand checkCommand = new SqlCommand(checkQuery, dbConnection.Connection);
                checkCommand.Parameters.AddWithValue("@JobId", jobId);
                checkCommand.Parameters.AddWithValue("@UserId", userId);

                object status = checkCommand.ExecuteScalar();

                if (status != null && status.ToString() == "Hired")
                {
                    MessageBox.Show("This worker is already hired. Please choose another worker.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Create the SQL command to insert the data
                    string query = @"
                        INSERT INTO Applications (job_id, user_id, status)
                        VALUES (@JobId, @UserId, @Status)
                    ";

                    SqlCommand command = new SqlCommand(query, dbConnection.Connection);

                    // Add the parameters to the command
                    command.Parameters.AddWithValue("@JobId", jobId);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Status", "Hired");

                    // Execute the command
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Hire successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inserting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Close the database connection
                dbConnection.Close();
            };


            MaterialButton btnFavourite = new MaterialButton();
            btnFavourite.Text = "Add To Favourite";
            btnFavourite.Location = new Point(450, 200);
            btnFavourite.Tag = card; // Store the panel in the Favourite button's Tag property
            btnFavourite.Click += (sender, e) =>
            {
                // Get the panel from the Favourite button's Tag property
                MaterialCard card = (MaterialCard)((MaterialButton)sender).Tag;

                // Get the employer ID and user ID from the panel's Tag property
                var employerId = ((dynamic)card.Tag).EmployerId;
                var userId = ((dynamic)card.Tag).UserId;

                // Check if the user is trying to favorite themselves
                if (this.userId == userId)
                {
                    MessageBox.Show("You cannot add yourself to favourites.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Open the database connection
                dbConnection.Open();

                // Check if the user has already liked the job
                string checkQuery = @"
                                    SELECT status 
                                    FROM Favourite 
                                    WHERE employer_id = @EmployerId AND user_id = @UserId
                                ";

                SqlCommand checkCommand = new SqlCommand(checkQuery, dbConnection.Connection);
                checkCommand.Parameters.AddWithValue("@EmployerId", employerId);
                checkCommand.Parameters.AddWithValue("@UserId", userId);

                object liked = checkCommand.ExecuteScalar();

                if (liked != null)
                {
                    MessageBox.Show("You have already liked this job.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Create the SQL command to insert the data
                    string query = @"
                                    INSERT INTO Favourite (employer_id, user_id,status)
                                    VALUES (@EmployerId, @UserId,@Status)
                                ";

                    SqlCommand command = new SqlCommand(query, dbConnection.Connection);

                    // Add the parameters to the command
                    command.Parameters.AddWithValue("@EmployerId", employerId);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@status", "Liked");

                    // Execute the command
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Added to favourites successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inserting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Close the database connection
                dbConnection.Close();
            };





            MaterialButton btnAppointment = new MaterialButton();
            btnAppointment.Text = "Make An Appointment";
            btnAppointment.Location = new Point(240, 200);
            btnAppointment.Click += (sender, e) => OpenAppointmentForm();


            // add controls to the card
            card.Controls.Add(label1);
            card.Controls.Add(label2);
            card.Controls.Add(label3);
            card.Controls.Add(label4);
            card.Controls.Add(pictureBox);
            card.Controls.Add(btnHire);
            card.Controls.Add(btnFavourite);
            card.Controls.Add(btnAppointment);


            flowLayoutPanel1.Controls.Add(card);

        }
        private void LoadDataAndAddPanels(string category)
        {
            dbConnection.Open();
            string query = @"
                            SELECT U.Name,
		                            U.Email,
		                            U.ImagePath,
		                            U.DateOfBirth,
		                            W.Bio,
		                            W.Skills
                            FROM Users U
                            JOIN Worker W
                            ON U.user_id = w.user_id
                            WHERE W.Category = @Category
                            ";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Category", category);
            DataTable dataTable = dbConnection.ExecuteQuery(command);

            foreach (DataRow row in dataTable.Rows)
            {
                // Process the data from the row
                var userId = row["user_id"];
                var jobId = row["job_id"];
                var employerId = row["employer_id"];
                var imagePath = row["ImagePath"] as string;
                var image = !string.IsNullOrEmpty(imagePath) ? Image.FromFile(imagePath) : null;

                string label1Text = row["FullName"].ToString();
                string label2Text = row["JobTitle"].ToString();
                string label3Text = row["MaxPrice"].ToString();
                string label4Text = row["JobDescription"].ToString();

                // Calculate age from date of birth
                DateTime dateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
                int age = DateTime.Now.Year - dateOfBirth.Year;
                if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                    age = age - 1;

                string label5Text = age.ToString();

                AddControlsToPanel(image, label1Text, label2Text, label3Text, label4Text, userId, jobId, employerId);
            }
            dbConnection.Close();
        }



        public void SearchWorkers(string jobTitle, decimal? salary)
        {
            // Clear the existing panels
            flowLayoutPanel1.Controls.Clear();

            // Start building the query
            StringBuilder query = new StringBuilder(@"
                                            SELECT 
                                                J.employer_id,
                                                U.user_id,
                                                J.job_id,
                                                U.ImagePath, 
                                                U.FirstName + ' ' + U.LastName AS FullName, 
                                                J.JobTitle, 
                                                J.JobDescription, 
                                                J.MaxPrice
                                            FROM 
                                                Users U
                                            INNER JOIN 
                                                JobList J ON U.user_id = J.employer_id
                                            WHERE 
                                                J.Category = @Category
                                        ");

            SqlCommand command = new SqlCommand();
            command.Connection = dbConnection.Connection;
            command.Parameters.AddWithValue("@Category", category);

            // Add conditions to the query based on the provided parameters
            if (!string.IsNullOrEmpty(jobTitle))
            {
                query.Append("AND J.JobTitle LIKE @JobTitle ");
                command.Parameters.AddWithValue("@JobTitle", "%" + jobTitle + "%");
            }
            if (salary.HasValue)
            {
                query.Append("AND J.MaxPrice >= @Salary ");
                command.Parameters.AddWithValue("@Salary", salary.Value);
            }

            // Set the command text
            command.CommandText = query.ToString();

            // Ensure the connection is open before executing the reader
            if (command.Connection.State != ConnectionState.Open)
            {
                command.Connection.Open();
            }

            // Execute the query and get the results
            SqlDataReader reader = command.ExecuteReader();

            // Loop through the results
            while (reader.Read())
            {
                // Get the data from the row
                var image = Image.FromFile(reader["ImagePath"].ToString());
                var label1Text = reader["FullName"].ToString();
                var label2Text = reader["JobTitle"].ToString();
                var label3Text = reader["MaxPrice"].ToString();
                var label4Text = reader["JobDescription"].ToString();

                var userId = reader["user_id"];
                var jobId = reader["job_id"];
                var employerId = reader["employer_id"];

                // Add a panel with the data
                AddControlsToPanel(image, label1Text, label2Text, label3Text, label4Text, userId, jobId, employerId);
            }

            // Close the reader and the connection
            reader.Close();
            dbConnection.Close();
        }





        private void OpenInformationForm()
        {
            // Open the Information form
            FInformation informationForm = new FInformation();
            informationForm.Show();
        }

        private void OpenAppointmentForm()
        {
            // Open the Appointment form
            Appointment appointmentForm = new Appointment();
            appointmentForm.Show();
        }



    }
}*/








