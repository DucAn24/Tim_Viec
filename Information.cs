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
    public partial class Information : MaterialForm
    {
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        public Information()
        {
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

        private void Information_Load(object sender, EventArgs e)
        {
            AddPanelToFlowLayout();
        }

        private void AddControlsToPanel(Image image, string label1Text, string label4Text)
        {

            //create and configure picture box
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Set this to Zoom
            pictureBox.Size = new Size(70, 70); // Set this to desired size
            pictureBox.Location = new Point(20, 20);



            // Create and configure label 1
            Label label1 = new Label();
            label1.Text = label1Text;
            label1.AutoSize = true;
            label1.ForeColor = Color.Chocolate;
            label1.Font = new Font("Nirmala UI", 12, FontStyle.Bold);
            label1.Location = new Point(120, 10);


            Label label4 = new Label();
            label4.Text = label4Text;
            label4.AutoSize = false; // Set AutoSize to false
            label4.Width = 1300;
            label4.Height = 90;
            label4.Location = new Point(120, 40); // Set the location
            label4.TextAlign = ContentAlignment.TopLeft;

            // Create a new panel
            MaterialCard card = new MaterialCard();
            card.Width = 1450; // Set panel width as needed
            card.Height = 120;
            card.BackColor = Color.White; // Set panel background color if needed



            // add controls to the card
            card.Controls.Add(label1);

            card.Controls.Add(label4);

            card.Controls.Add(pictureBox);



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
                AddControlsToPanel(image, labels[i].Item1, labels[i].Item4);


            }
        }
    }
}
