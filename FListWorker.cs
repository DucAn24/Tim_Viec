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


        }


        private void WorkerList_Load(object sender, EventArgs e)
        {
            LoadDataAndAddPanels(category);
        }

        private void AddControlsToPanel(Image image, string label1Text, string label2Text, string label3Text, string label4Text, string salary, object userId, object Worker_id)
        {

            // Create a new panel
            MaterialCard card = new MaterialCard();
            card.Width = 700; // Set panel width as needed
            card.Height = 250;
            card.BackColor = Color.White;
            card.BackColor = Color.White;
            card.Tag = new { UserId = this.userId, WorkerId = Worker_id };
            card.Click += (sender, e) => OpenInformationForm((int)userId, (int)Worker_id);

            //create and configure picture box
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Set this to Zoom
            pictureBox.Size = new Size(90, 90); // Set this to desired size
            pictureBox.Location = new Point(20, 20);
            pictureBox.Click += (sender, e) => OpenInformationForm((int)userId, (int)Worker_id);


            // Create and configure label 1
            Label label1 = new Label();
            label1.Text = label1Text;
            label1.AutoSize = true;
            label1.ForeColor = Color.Chocolate;
            label1.Font = new Font("Nirmala UI", 12, FontStyle.Bold);
            label1.Location = new Point(120, 20);
            label1.Click += (sender, e) => OpenInformationForm((int)userId, (int)Worker_id);


            // Create and configure label 2
            Label label2 = new Label();
            label2.Text = label2Text;
            label2.AutoSize = true;
            label2.ForeColor = Color.LightGreen;
            label2.Font = new Font("Nirmala UI", 16, FontStyle.Bold);
            label2.Location = new Point(120, 50);
            label2.Click += (sender, e) => OpenInformationForm((int)userId, (int)Worker_id);

            // Create and configure label 3
            Label label3 = new Label();
            label3.Text = "Age: " + label3Text;
            label3.AutoSize = true;
            label3.Location = new Point(20, 120);
            label3.Click += (sender, e) => OpenInformationForm((int)userId, (int)Worker_id);

            // Create and configure label 4
            Label label4 = new Label();
            label4.Text = "Bio: " + label4Text;
            label4.AutoSize = true; // Set AutoSize to false
            label4.Location = new Point(120, 100); // Set the location
            label4.TextAlign = ContentAlignment.TopLeft;
            label4.Click += (sender, e) => OpenInformationForm((int)userId, (int)Worker_id);

            Label salaryLable = new Label();
            salaryLable.Text = "Salary: " + salary;
            salaryLable.AutoSize = true; // Set AutoSize to false
            salaryLable.Location = new Point(120, 120); // Set the location
            salaryLable.TextAlign = ContentAlignment.TopLeft;
            salaryLable.Click += (sender, e) => OpenInformationForm((int)userId, (int)Worker_id);

            MaterialButton btnHire = new MaterialButton();
            btnHire.Text = "Hire Talent";
            btnHire.Location = new Point(120, 200);
            btnHire.Tag = card; // Store the panel in the Hire button's Tag property
            btnHire.Click += (sender, e) =>
            {
                // Get the panel from the Hire button's Tag property
                MaterialCard card = (MaterialCard)((MaterialButton)sender).Tag;

                // Get the user ID and worker ID from the panel's Tag property
                var userId = ((dynamic)card.Tag).UserId;
                var workerId = ((dynamic)card.Tag).WorkerId;

                // Open the database connection
                dbConnection.Open();

                // Check if the user has already hired the worker
                string checkQuery = @"
                        SELECT COUNT(*)
                        FROM HiredWorkers
                        WHERE user_id = @UserId AND Worker_id = @WorkerId
                    ";

                SqlCommand checkCommand = new SqlCommand(checkQuery, dbConnection.Connection);
                checkCommand.Parameters.AddWithValue("@UserId", userId);
                checkCommand.Parameters.AddWithValue("@WorkerId", workerId);

                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("You have already hired this worker.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Create the SQL command to insert the data
                    string insertQuery = @"
                            INSERT INTO HiredWorkers (user_id, Worker_id)
                            VALUES (@UserId, @WorkerId)
                        ";

                    SqlCommand insertCommand = new SqlCommand(insertQuery, dbConnection.Connection);

                    // Add the parameters to the command
                    insertCommand.Parameters.AddWithValue("@UserId", userId);
                    insertCommand.Parameters.AddWithValue("@WorkerId", workerId);

                    // Execute the command
                    try
                    {
                        insertCommand.ExecuteNonQuery();
                        MessageBox.Show("Hire successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inserting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                dbConnection.Close();
            };


            MaterialButton btnFavourite = new MaterialButton();
            btnFavourite.Text = "Add To Favourite";
            btnFavourite.Location = new Point(450, 200);
            btnFavourite.Tag = card; // Store the panel in the Favourite button's Tag property
            btnFavourite.Click += (sender, e) =>
            {
                // Get the panel from the Hire button's Tag property
                MaterialCard card = (MaterialCard)((MaterialButton)sender).Tag;

                // Get the user ID and worker ID from the panel's Tag property
                var userId = ((dynamic)card.Tag).UserId;
                var workerId = ((dynamic)card.Tag).WorkerId;

                // Open the database connection
                dbConnection.Open();

                // Check if the user has already like the worker
                string checkQuery = @"
                        SELECT COUNT(*)
                        FROM Favourite
                        WHERE user_id = @UserId AND Worker_id = @WorkerId
                    ";

                SqlCommand checkCommand = new SqlCommand(checkQuery, dbConnection.Connection);
                checkCommand.Parameters.AddWithValue("@UserId", userId);
                checkCommand.Parameters.AddWithValue("@WorkerId", workerId);

                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("You have already like this worker.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Create the SQL command to insert the data
                    string insertQuery = @"
                            INSERT INTO Favourite (user_id, Worker_id, isFavourite)
                            VALUES (@UserId, @WorkerId, 'true')
                        ";

                    SqlCommand insertCommand = new SqlCommand(insertQuery, dbConnection.Connection);

                    // Add the parameters to the command
                    insertCommand.Parameters.AddWithValue("@UserId", userId);
                    insertCommand.Parameters.AddWithValue("@WorkerId", workerId);

                    // Execute the command
                    try
                    {
                        insertCommand.ExecuteNonQuery();
                        MessageBox.Show("Like successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            card.Controls.Add(salaryLable);
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
                            SELECT  W.Worker_id,
                                    U.Name,
		                            U.Email,
		                            U.ImagePath,
		                            U.DateOfBirth,
		                            W.Bio,
		                            W.Skills,
                                    W.Salary 
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
                var Worker_id = row["Worker_id"];
                var imagePath = row["ImagePath"] as string;
                var image = !string.IsNullOrEmpty(imagePath) ? Image.FromFile(imagePath) : null;

                string label1Text = row["Name"].ToString();
                string label2Text = row["Skills"].ToString();

                // Calculate age from date of birth
                DateTime dateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
                int age = DateTime.Now.Year - dateOfBirth.Year;
                if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                    age = age - 1;

                string label3Text = age.ToString();

                string label4Text = row["Bio"].ToString();

                string salary = row["Salary"].ToString();


                AddControlsToPanel(image, label1Text, label2Text, label3Text, label4Text, salary, this.userId, Worker_id);
            }
            dbConnection.Close();
        }

        public void SearchWorkers(string Skills, string orderByPrice)
        {
            dbConnection.Open();
            string query = @"
                            SELECT  W.Worker_id,
                                    U.Name,
		                            U.Email,
		                            U.ImagePath,
		                            U.DateOfBirth,
		                            W.Bio,
		                            W.Skills,
                                    W.Salary
                            FROM Users U
                            JOIN Worker W
                            ON U.user_id = w.user_id
                            WHERE W.Skills LIKE @Skills
                            ";

            if (!string.IsNullOrEmpty(orderByPrice))
            {
                query += $" ORDER BY W.Salary {orderByPrice}";
            }


            SqlCommand command = new SqlCommand(query, dbConnection.Connection);
            command.Parameters.AddWithValue("@Skills", "%" + Skills + "%");

            // Execute the command and get the result
            SqlDataReader reader = command.ExecuteReader();

            // Clear the existing panels
            flowLayoutPanel1.Controls.Clear();

            while (reader.Read())
            {
                // Process the data from the row
                var Worker_id = reader["Worker_id"];
                var imagePath = reader["ImagePath"] as string;
                var image = !string.IsNullOrEmpty(imagePath) ? Image.FromFile(imagePath) : null;

                string label1Text = reader["Name"].ToString();
                string label2Text = reader["Skills"].ToString();

                // Calculate age from date of birth
                DateTime dateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                int age = DateTime.Now.Year - dateOfBirth.Year;
                if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                    age = age - 1;

                string label3Text = age.ToString();

                string label4Text = reader["Bio"].ToString();

                string salary = reader["Salary"].ToString();


                AddControlsToPanel(image, label1Text, label2Text, label3Text, label4Text, salary, this.userId, Worker_id);
            }
            dbConnection.Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchWorkers(txtSearch.Text, cbxPrice.SelectedItem.ToString());
        }


        private void OpenInformationForm(int userId, int workerId)
        {
            FInformation informationForm = new FInformation(userId, workerId);
            informationForm.Show();
        }


        private void OpenAppointmentForm()
        {
            // Open the Appointment form
            FAppointment appointmentForm = new FAppointment();
            appointmentForm.Show();
        }
    }
}







