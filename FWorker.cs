using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class FWorker : MaterialForm
    {
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        private DbConnection dbConnection;

        JobDAO jobDAO = new JobDAO();
        WorkerDAO workerDAO = new WorkerDAO();
        private int userId;
        
        public FWorker(int userId)
        {
            this.userId = userId;
            dbConnection = new DbConnection();

            InitializeComponent();
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightGreen900,
                                                                Primary.LightGreen700,
                                                                Primary.LightGreen500,
                                                                Accent.LightGreen200,
                                                                TextShade.WHITE);
        }

        private void Worker_Load(object sender, EventArgs e)
        {
            AddPanelToFlowLayoutAppointment(flowLayoutPanel2);
        }

        private void materialTabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.materialTabControl1.SelectedIndex == 5) // Assuming the "Log out" tab is at index 5
            {
                this.Hide(); // Hide the current form
                new Login().Show(); // Show the Login form
            }
        }

        private MaterialCard AddControlsToPanelAppointment(Image image, string label1Text, string label2Text, string label3Text, string label4Text)
        {

            //create and configure picture box
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Set this to Zoom
            pictureBox.Size = new Size(40, 40); // Set this to desired size
            pictureBox.Location = new Point(20, 20);



            // Create and configure label 1
            Label label1 = new Label();
            label1.Text = label1Text;
            label1.AutoSize = true;
            label1.ForeColor = Color.Chocolate;
            label1.Font = new Font("Nirmala UI", 16, FontStyle.Bold);
            label1.Location = new Point(10, 70);



            // Create and configure label 2
            Label label2 = new Label();
            label2.Text = label2Text;
            label2.AutoSize = true;
            label2.ForeColor = Color.LightGreen;
            label2.Font = new Font("Nirmala UI", 10, FontStyle.Bold);
            label2.Location = new Point(10, 120);



            // Create a new panel
            MaterialCard card = new MaterialCard();
            card.Width = 310; // Set panel width as needed
            card.Height = 220;
            card.BackColor = Color.White; // Set panel background color if needed

            MaterialButton btnAccpet = new MaterialButton();
            btnAccpet.Text = "Accept";
            btnAccpet.Location = new Point(10, 170);

            MaterialButton btnDecline = new MaterialButton();
            btnDecline.Text = "Decline";
            btnDecline.Location = new Point(100, 170);

            // add controls to the card
            card.Controls.Add(label1);
            card.Controls.Add(label2);
            card.Controls.Add(pictureBox);
            card.Controls.Add(btnAccpet);
            card.Controls.Add(btnDecline);

            return card;

        }

        private void AddPanelToFlowLayoutAppointment(FlowLayoutPanel flowLayoutPanel)
        {
            // Example data for panels
            List<(string, string, string, string)> labels = new List<(string, string, string, string)>
            {
                ("Duc AN Nbguyen ", "Python Developer : Django - Flask - RESTful APIs - Automation Scripts", "$10.00/hr", "Are you looking for a versatile Python Developer to help you with your Project? I'm a Python developer driven by a profound passion for technology. Offering a diverse range of services, I specialize in web scraping, data mining, data wrangling, data analysis, automation, and cloud services."),
                ("Tijani-Ahmed O. t", "Python Programmer", "$5.00/hr", "I am a junior Python developer. I'm good at using Python to solve your use cases, be it web development, API development, machine learning, data analysis, scripting, web automation, etc.I am good at building backend applications and RESTful APIs using the Django Framework. I can. also build full-stack web applications.Apart from this, I'm also an automation expert in python. I can scrape, automate processes, manipulate different files, classify and predict data using ML, speed up applications with asynchronous programming etc."),
                ("Akshay V.", "c", "Label 3-3", "👋 Hey there! I'm akshay vayak, a seasoned Python and Machine Learning enthusiast with a passion for turning data into actionable insights. I'm here to supercharge your projects with cutting-edge technology and data-driven solutions.\r\n\r\nKey Skills:\r\n\r\n🐍 Python Expertise: I'm fluent in Python, leveraging its versatility to build robust applications, web scrapers, and automate tasks.\r\n🤖 Machine Learning Wizardry: I specialize in creating predictive models, natural language processing, computer vision, and recommendation systems.\r\n📊 Data Analysis & Visualization: I'll transform your data into meaningful insights using pandas, Matplotlib, and Seaborn.\r\n\U0001f9e0 Deep Learning: I have experience with TensorFlow and PyTorch for developing neural networks.\r\n💻 Full-Stack Familiarity: I can seamlessly integrate ML models into web apps, giving your users intelligent experiences.\r\n🌐 API Integration: I'll connect your applications with external APIs to fetch or deliver data.\r\n📈 Optimization: I optimize code and models for speed, scalability, and cost-effectiveness."),
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


                // Get the card from the AddControlsToPanel method

                MaterialCard cardAppointment = AddControlsToPanelAppointment(image, labels[i].Item1, labels[i].Item2, labels[i].Item3, labels[i].Item4);

                // Add the card to the flowLayoutPanel
                flowLayoutPanel.Controls.Add(cardAppointment);

            }

        }

        private string imagePath;
        private void btnImportImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imagePath = ofd.FileName;
                    picBoxUser.Image = new Bitmap(imagePath);
                }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Worker worker = new Worker(txtName.Text, txtEmail.Text, dtpBirth.Value, imagePath, txtPhone.Text, txtAddress.Text, gender, txtBio.Text, txtSkill.Text,cbxCategory2.Text);
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
    }
}
