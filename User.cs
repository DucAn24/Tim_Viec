using MaterialSkin;
using MaterialSkin.Controls;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.DataFormats;
using Font = System.Drawing.Font;
using Image = System.Drawing.Image;


namespace TimViec
{
    public partial class User : MaterialForm
    {

        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        public User()
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


            List<MaterialCard> materialCards = new List<MaterialCard> { materialCard6, materialCard14, materialCard12, materialCard10, materialCard15, materialCard16, materialCard17, materialCard18 };
            List<PictureBox> pictureBoxes = new List<PictureBox> { pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9 };
            // Attach a click event handler to each MaterialCard
            foreach (var materialCard in materialCards)
            {
                materialCard.Click += MaterialCard_Click;
            }
            foreach (var pictureBox in pictureBoxes)
            {
                pictureBox.Click += PictureBox_Click;
            }



        }

        private void Home_Load(object sender, EventArgs e)
        {
            AddPanelToFlowLayoutHired(flowLayoutPanel1);
            AddPanelToFlowLayoutWait(flowLayoutPanel3);

        }

        private void materialSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            if (switchTheme.Checked)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                switchTheme.Text = "DARK   ";
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                switchTheme.Text = "LIGHT   ";
            }
        }

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton1.Checked)
            {
                materialLabel4.Text = "per hour ";
            }
        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton2.Checked)
            {
                materialLabel4.Text = "per project";
            }
        }

        private Dictionary<string, string> pictureToCategoryMap = new Dictionary<string, string>
        {
            { "pictureBox2", "AI Services" },
            { "pictureBox3", "Design - Creative" },
            { "pictureBox4", "Sales -Marketing" },
            { "pictureBox5", "Writing - Traslation" },
            { "pictureBox6", "Admin - Custome Support" },
            { "pictureBox7", "Finance - Accounting" },
            { "pictureBox8", "Engineering - Architecture" },
            // Add more if needed
        };

        private void PictureBox_Click(object sender, EventArgs e)
        {
            // Determine which PictureBox was clicked
            PictureBox clickedPictureBox = sender as PictureBox;

            // Create and show the appropriate form based on the clicked PictureBox
            if (clickedPictureBox != null && pictureToCategoryMap.TryGetValue(clickedPictureBox.Name, out string category))
            {
                OpenWokerListForm(/*category*/);
            }
        }

        private Dictionary<string, string> cardToCategoryMap = new Dictionary<string, string>
        {
            { "materialCard6", "AI Services" },
            { "materialCard14", "Design - Creative" },
            { "materialCard12", "Sales -Marketing" },
            { "materialCard10", "Writing - Traslation" },
            { "materialCard15", "Admin - Custome Support" },
            { "materialCard16", "Finance - Accounting" },
            { "materialCard17", "Engineering - Architecture" },
            // Add more if needed
        };

        private void MaterialCard_Click(object sender, EventArgs e)
        {
            // Determine which MaterialCard was clicked
            MaterialCard clickedCard = sender as MaterialCard;

            // Fetch the data for the category of the clicked card
            if (clickedCard != null && cardToCategoryMap.TryGetValue(clickedCard.Name, out string category))
            {
                OpenWokerListForm(/*category*/);
            }
        }

        private void OpenWokerListForm(/*string category*/)
        {
            WorkerList workerList = new WorkerList(/*category*/);
            workerList.Show();
        }


        private void btnImportImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picBoxUser.Image = new Bitmap(ofd.FileName);
                }
            }

        }

        private void ckbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFemale.Checked)
            {
                ckbMale.Checked = false;
            }

        }

        private void ckbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMale.Checked)
            {
                ckbFemale.Checked = false;
            }
        }

        private MaterialCard AddControlsToPanelDashBoard(Image image, string label1Text, string label2Text)
        {
            var pictureBox = new PictureBox
            {
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(40, 40),
                Location = new Point(20, 20)
            };

            var label1 = new Label
            {
                Text = label1Text,
                AutoSize = true,
                ForeColor = Color.Chocolate,
                Font = new Font("Nirmala UI", 18, FontStyle.Bold),
                Location = new Point(20, 70)
            };

            var label2 = new Label
            {
                Text = label2Text,
                AutoSize = false,
                ForeColor = Color.LightGreen,
                Font = new Font("Nirmala UI", 12, FontStyle.Bold),
                Width = 300,
                Height = 70,
                Location = new Point(20, 120),
                TextAlign = ContentAlignment.TopLeft
            };

            var card = new MaterialCard
            {
                Width = 300,
                Height = 220,
                BackColor = Color.White
            };

            card.Controls.Add(label1);
            card.Controls.Add(label2);
            card.Controls.Add(pictureBox);

            return card;
        }

        private MaterialCard AddControlsToPanelWait(Image image, string label1Text, string label2Text)
        {
            var pictureBox = new PictureBox
            {
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(40, 40),
                Location = new Point(20, 20)
            };

            var label1 = new Label
            {
                Text = label1Text,
                AutoSize = true,
                ForeColor = Color.Chocolate,
                Font = new Font("Nirmala UI", 18, FontStyle.Bold),
                Location = new Point(10, 70)
            };

            var label2 = new Label
            {
                Text = label2Text,
                AutoSize = true,
                ForeColor = Color.LightGreen,
                Font = new Font("Nirmala UI", 12, FontStyle.Bold),
                Location = new Point(10, 120)
            };

            var btnChange = new MaterialButton
            {
                Text = "Change Time",
                Location = new Point(10, 170)
            };
            btnChange.Click += (sender, e) => OpenAppointmentForm();

            var btnCancel = new MaterialButton
            {
                Text = "Cancel",
                Location = new Point(140, 170)
            };

            var card = new MaterialCard
            {
                Width = 310,
                Height = 220,
                BackColor = Color.White
            };

            card.Controls.Add(label1);
            card.Controls.Add(label2);
            card.Controls.Add(pictureBox);
            card.Controls.Add(btnChange);
            card.Controls.Add(btnCancel);

            return card;
        }

        private void AddPanelToFlowLayout(FlowLayoutPanel flowLayoutPanel, Func<Image, string, string, MaterialCard> addControlsToPanel)
        {
            var labels = new List<(string, string)>
            {
                ("Duc AN Nbguyen ", "Python Developer : Django - Flask - RESTful APIs - Automation Scripts"),
                ("Tijani-Ahmed O. t", "Python Programmer"),
                ("Akshay V.", "Python Machine Learning Developer | Expert in Flask & Django"),
                ("Ismail P. ", "Mobile App Developer / Python Developer"),
                ("code web", "Label 3-2"),
                ("code web", "Label 3-2")
            };

            var imageIndices = new List<int> { 0, 1, 2, 3, 4, 5 };

            for (int i = 0; i < 6; i++)
            {
                var image = imageList1.Images[imageIndices[i]];
                var card = addControlsToPanel(image, labels[i].Item1, labels[i].Item2);
                flowLayoutPanel.Controls.Add(card);
            }
        }

        private void AddPanelToFlowLayoutHired(FlowLayoutPanel flowLayoutPanel)
        {
            AddPanelToFlowLayout(flowLayoutPanel, AddControlsToPanelDashBoard);
        }

        private void AddPanelToFlowLayoutWait(FlowLayoutPanel flowLayoutPanel)
        {
            AddPanelToFlowLayout(flowLayoutPanel, AddControlsToPanelWait);
        }



/*        private void AddPanelToFlowLayout(FlowLayoutPanel flowLayoutPanel, Func<Image, string, string, MaterialCard> addControlsToPanel, string query)
        {
            string connectionString = "Data Source=(local);Initial Catalog=YourDatabaseName;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int imageIndex = reader.GetInt32(0); // Assuming the first column is the image index
                            string label1 = reader.GetString(1); // Assuming the second column is the first label
                            string label2 = reader.GetString(2); // Assuming the third column is the second label

                            var image = imageList1.Images[imageIndex];
                            var card = addControlsToPanel(image, label1, label2);
                            flowLayoutPanel.Controls.Add(card);
                        }
                    }
                }
            }
        }

        private void AddPanelToFlowLayoutHired(FlowLayoutPanel flowLayoutPanel)
        {
            string query = "SELECT ImageIndex, Label1, Label2 FROM YourHiredTableName";
            AddPanelToFlowLayout(flowLayoutPanel, AddControlsToPanelDashBoard, query);
        }

        private void AddPanelToFlowLayoutWait(FlowLayoutPanel flowLayoutPanel)
        {
            string query = "SELECT ImageIndex, Label1, Label2 FROM YourWaitTableName";
            AddPanelToFlowLayout(flowLayoutPanel, AddControlsToPanelWait, query);
        }
*/




        private void OpenAppointmentForm()
        {
            // Open the Appointment form
            Appointment appointmentForm = new Appointment();
            appointmentForm.Show();
        }

    }
}
