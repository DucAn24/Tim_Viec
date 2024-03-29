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

namespace TimViec
{
    public partial class WorkerList : MaterialForm
    {
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        private DbConnection dbConnection;
        private string category;

        public WorkerList(string category)
        {
            InitializeComponent();
            dbConnection = new DbConnection();
            this.category = category;



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
                decimal? salary = string.IsNullOrEmpty(materialTextBox21.Text) ? (decimal?)null : decimal.Parse(materialTextBox21.Text);

                // Search for workers
                SearchWorkers(jobTitle, salary);
            };


        }


        private void WorkerList_Load(object sender, EventArgs e)
        {
            LoadDataAndAddPanels(category);
        }

        private void AddControlsToPanel(Image image, string label1Text, string label2Text, string label3Text, string label4Text)
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
            label4.Width = 1310; 
            label4.Height = 100;
            label4.Location = new Point(120, 100); // Set the location
            label4.TextAlign = ContentAlignment.TopLeft;
            label4.Click += (sender, e) => OpenInformationForm();

            // Create a new panel
            MaterialCard card = new MaterialCard();
            card.Width = 1460; // Set panel width as needed
            card.Height = 250;
            card.BackColor = Color.White; // Set panel background color if needed
            card.Click += (sender, e) => OpenInformationForm();

            MaterialButton btnHire = new MaterialButton();
            btnHire.Text = "Hire Talent";
            btnHire.Location = new Point(120, 200);

            MaterialButton btnFavourite = new MaterialButton();
            btnFavourite.Text = "Add To Favourite";
            btnFavourite.Location = new Point(450, 200);

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


            string query = "SELECT * FROM JobInformation WHERE Category = @Category";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Category", category);
            DataTable dataTable = dbConnection.ExecuteQuery(command);

            foreach (DataRow row in dataTable.Rows)
            {
                // Process the data from the row

                var imagePath = row["ImagePath"] as string;
                var image = !string.IsNullOrEmpty(imagePath) ? Image.FromFile(imagePath) : null;

                string label1Text = row["CraftsmanID"].ToString();
                string label2Text = row["JobTitle"].ToString();
                string label3Text = row["MaxPrice"].ToString();
                string label4Text = row["JobDescription"].ToString();
                
                AddControlsToPanel(image, label1Text, label2Text, label3Text, label4Text);
            }
        }


        public void SearchWorkers(string jobTitle, decimal? salary)
        {
            // Clear the existing panels
            flowLayoutPanel1.Controls.Clear();

            // Start building the query
            string query = "SELECT * FROM JobInformation WHERE ";
            SqlCommand command = new SqlCommand();
            command.Connection = dbConnection.Connection;

            // Add conditions to the query based on the provided parameters
            if (!string.IsNullOrEmpty(jobTitle))
            {
                query += "JobTitle LIKE @JobTitle ";
                command.Parameters.AddWithValue("@JobTitle", "%" + jobTitle + "%");
            }
            if (salary.HasValue)
            {
                // Add an AND if there are multiple conditions
                if (command.Parameters.Count > 0)
                {
                    query += "AND ";
                }
                query += "MinPrice >= @salary ";
                command.Parameters.AddWithValue("@Salary", salary.Value);
            }

            // Set the command text
            command.CommandText = query;

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
                var label1Text = reader["CraftsmanID"].ToString();
                var label2Text = reader["JobTitle"].ToString();
                var label3Text = reader["MinPrice"].ToString();
                var label4Text = reader["JobDescription"].ToString();

                // Add a panel with the data
                AddControlsToPanel(image, label1Text, label2Text, label3Text, label4Text);
            }

            // Close the reader and the connection
            reader.Close();
            dbConnection.Close();
        }



        private void OpenInformationForm()
        {
            // Open the Information form
            Information informationForm = new Information();
            informationForm.Show();
        }

        private void OpenAppointmentForm()
        {
            // Open the Appointment form
            Appointment appointmentForm = new Appointment();
            appointmentForm.Show();
        }



    }
}
