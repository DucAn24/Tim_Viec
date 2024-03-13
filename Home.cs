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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.DataFormats;
using Font = System.Drawing.Font;

namespace TimViec
{
    public partial class Home : MaterialForm
    {

        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        public Home()
        {
            InitializeComponent();
            materialSkinManager.EnforceBackcolorOnAllComponents = false;

            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue900,
                                                                Primary.LightBlue700,
                                                                Primary.LightBlue500,
                                                                Accent.LightBlue200,
                                                                TextShade.WHITE);
        }

        private void Home_Load(object sender, EventArgs e)
        {
            AddCardToFlowLayout();
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

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddControlsToCard(MaterialCard card,System.Drawing.Image image, string label1Text, string label2Text, string label3Text, string label4Text)
        {

            //create and configure picture box
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(220, 150);
            pictureBox.Location = new Point(12, 35);
            pictureBox.Click += (sender, e) => OpenInformationForm();
            

            // Create and configure label 1
            Label label1 = new Label();
            label1.Text = label1Text;
            label1.AutoSize = true;
            label1.ForeColor = Color.LightSkyBlue;
            label1.Font = new Font("Nirmala UI", 12, FontStyle.Bold);
            label1.Location = new Point(12, 1);
            label1.Click += (sender, e) => OpenInformationForm();

            // Create and configure label 2
            Label label2 = new Label();
            label2.Text = label2Text;
            label2.AutoSize = true;
            label2.Location = new Point(12,200);
            

            // Create and configure label 3
            Label label3 = new Label();
            label3.Text = label3Text;
            label3.AutoSize = true;
            label3.Location = new Point(12, 230);
            

            // Create and configure label 4
            Label label4 = new Label();
            label4.Text = label4Text;
            label4.AutoSize = true;
            label4.Location = new Point(12, 260);

            // add label to the card
            card.Controls.Add(label1);
            card.Controls.Add(label2);
            card.Controls.Add(label3);
            card.Controls.Add(label4);
            card.Controls.Add(pictureBox);
        }

        private void AddCardToFlowLayout()
        {
            // Example data for cards
            List<(string, string, string, string)> labels = new List<(string, string, string, string)>
            {
                ("sua quat", "Label 1-2", "Label 1-3", "Label 1-4"),
                ("sua may giat", "Label 2-2", "Label 2-3", "Label 2-4"),
                ("code web", "Label 3-2", "Label 3-3", "Label 3-4")
            };

            // Example data for image indices in the ImageList
            List<int> imageIndices = new List<int> { 0, 1, 2 };

            //loop all label and image
            for (int i = 0; i < labels.Count; i++)
            {
                // Create a new card
                MaterialCard card = new MaterialCard();
                card.Width = 250; // Set card width as needed
                card.Height = 320;
                card.Margin = new Padding(10);

                // Get image from ImageList by index
                System.Drawing.Image image = imageList2.Images[imageIndices[i]];

                // Add controls to the card with corresponding information
                AddControlsToCard(card, image, labels[i].Item1, labels[i].Item2, labels[i].Item3, labels[i].Item4);

                // Add the card to the flow layout panel
                flowLayoutPanel1.Controls.Add(card);
            }

        }
        private void OpenInformationForm()
        {
            // Open the Information form
            Information informationForm = new Information();
            informationForm.Show();
        }



    }
}
