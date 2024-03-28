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
        public WorkerList(/* string category */)
        {
            InitializeComponent();
            dbConnection = new DbConnection();

            materialSkinManager.EnforceBackcolorOnAllComponents = false;

            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightGreen900,
                                                                Primary.LightGreen700,
                                                                Primary.LightGreen500,
                                                                Accent.LightGreen200,
                                                                TextShade.WHITE);

            //LoadDataAndAddPanels(string category);

/*            materialButton14.Click += (sender, e) =>
            {
                // Get the job title and salary from the text boxes
                string jobTitle = string.IsNullOrEmpty(materialTextBox25.Text) ? null : materialTextBox25.Text;
                decimal? salary = string.IsNullOrEmpty(materialTextBox21.Text) ? (decimal?)null : decimal.Parse(materialTextBox21.Text);

                // Search for workers
                SearchWorkers(jobTitle, salary);
            };*/


        }


        private void WorkerList_Load(object sender, EventArgs e)
        {
            AddPanelToFlowLayout();
        }

        private void AddControlsToPanel(Image image, string label1Text, string label2Text, string label3Text, string label4Text)
        {

            //create and configure picture box
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Set this to Zoom
            pictureBox.Size = new Size(90,90); // Set this to desired size
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


        private void AddPanelToFlowLayout()
        {
            // Example data for panels
            List<(string, string, string, string)> labels = new List<(string, string, string, string)>
            {
                ("Duc AN Nbguyen ", "Python Developer : Django - Flask - RESTful APIs - Automation Scripts", "$10.00/hr", "Are you looking for a versatile Python Developer to help you with your Project? I'm a Python developer driven by a profound passion for technology. Offering a diverse range of services, I specialize in web scraping, data mining, data wrangling, data analysis, automation, and cloud services."),
                ("Tijani-Ahmed O. t", "Python Programmer", "$5.00/hr", "I am a junior Python developer. I'm good at using Python to solve your use cases, be it web development, API development, machine learning, data analysis, scripting, web automation, etc.I am good at building backend applications and RESTful APIs using the Django Framework. I can. also build full-stack web applications.Apart from this, I'm also an automation expert in python. I can scrape, automate processes, manipulate different files, classify and predict data using ML, speed up applications with asynchronous programming etc."),
                ("Akshay V.", "Python Machine Learning Developer | Expert in Flask & Django", "Label 3-3", "👋 Hey there! I'm akshay vayak, a seasoned Python and Machine Learning enthusiast with a passion for turning data into actionable insights. I'm here to supercharge your projects with cutting-edge technology and data-driven solutions.\r\n\r\nKey Skills:\r\n\r\n🐍 Python Expertise: I'm fluent in Python, leveraging its versatility to build robust applications, web scrapers, and automate tasks.\r\n🤖 Machine Learning Wizardry: I specialize in creating predictive models, natural language processing, computer vision, and recommendation systems.\r\n📊 Data Analysis & Visualization: I'll transform your data into meaningful insights using pandas, Matplotlib, and Seaborn.\r\n\U0001f9e0 Deep Learning: I have experience with TensorFlow and PyTorch for developing neural networks.\r\n💻 Full-Stack Familiarity: I can seamlessly integrate ML models into web apps, giving your users intelligent experiences.\r\n🌐 API Integration: I'll connect your applications with external APIs to fetch or deliver data.\r\n📈 Optimization: I optimize code and models for speed, scalability, and cost-effectiveness."),
                ("Ismail P. ", "Mobile App Developer / Python Developer", "Label 3-3", "Label 3-4"),
                ("code web", "Label 3-2", "Label 3-3", "Label 3-4"),
                ("code web", "Label 3-2", "Label 3-3", "Label 3-4")
            };



            // Example data for image indices in the ImageList
            List<int> imageIndices = new List<int> { 0, 1, 2, 3, 4, 5 };

            //loop all labels and images
            for (int i = 0; i < 6; i++)
            {

                // Get image from ImageList by index
                Image image = imageList1.Images[imageIndices[i]];

                // Add controls to the panel with corresponding information
                AddControlsToPanel(image, labels[i].Item1, labels[i].Item2, labels[i].Item3, labels[i].Item4);

                
            }
        }

        /*        private void LoadDataAndAddPanels(string category)
                {
                    string query = "SELECT * FROM YourTableName WHERE Category = @Category";
                    DataTable dataTable = dbConnection.ExecuteQuery(query);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Process the data from the row
                        var image = Image.FromFile(row["ImagePath"].ToString()); // Replace "ImagePath" with the actual column name for the image path
                        var label1Text = row["Label1"].ToString(); // Replace "Label1" with the actual column name for the label1 text
                        var label2Text = row["Label2"].ToString(); // Replace "Label2" with the actual column name for the label2 text
                        var label3Text = row["Label3"].ToString(); // Replace "Label3" with the actual column name for the label3 text
                        var label4Text = row["Label4"].ToString(); // Replace "Label4" with the actual column name for the label4 text

                        var card = AddControlsToPanel(image, label1Text, label2Text, label3Text, label4Text);
                        flowLayoutPanel1.Controls.Add(card);
                    }
                }*/

        /*        public void SearchWorkers(string jobTitle, decimal? salary)
                {
                    // Clear the existing panels
                    flowLayoutPanel1.Controls.Clear();

                    // Start building the query
                    string query = "SELECT * FROM Workers WHERE ";
                    SqlCommand command = new SqlCommand();
                    command.Connection = dbConnection;

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
                        query += "Salary >= @Salary ";
                        command.Parameters.AddWithValue("@Salary", salary.Value);
                    }

                    // Set the command text
                    command.CommandText = query;

                    // Execute the query and get the results
                    SqlDataReader reader = command.ExecuteReader();

                    // Loop through the results
                    while (reader.Read())
                    {
                        // Get the data from the row
                        var image = Image.FromFile(reader["ImagePath"].ToString());
                        var label1Text = reader["Label1"].ToString();
                        var label2Text = reader["Label2"].ToString();
                        var label3Text = reader["Label3"].ToString();
                        var label4Text = reader["Label4"].ToString();

                        // Add a panel with the data
                        AddControlsToPanel(image, label1Text, label2Text, label3Text, label4Text);
                    }

                    // Close the reader and the connection
                    reader.Close();
                    dbConnection.Close();


                }*/





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
