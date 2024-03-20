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
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightGreen900,
                                                                Primary.LightGreen700,
                                                                Primary.LightGreen500,
                                                                Accent.LightGreen200,
                                                                TextShade.WHITE);

            List<MaterialCard> materialCards = new List<MaterialCard> { materialCard6, materialCard14, materialCard12, materialCard10, materialCard15, materialCard16, materialCard17, materialCard18 };

            // Attach a click event handler to each MaterialCard
            foreach (var materialCard in materialCards)
            {
                materialCard.Click += MaterialCard_Click;
            }


        }

        private void Home_Load(object sender, EventArgs e)
        {

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

        private void MaterialCard_Click(object sender, EventArgs e)
        {
            // Determine which MaterialCard was clicked
            MaterialCard clickedCard = sender as MaterialCard;

            // Create and show the appropriate form based on the clicked MaterialCard
            switch (clickedCard.Name)
            {
                case "materialCard6":
                case "materialCard14":
                case "materialCard12":
                case "materialCard10":
                case "materialCard15":
                case "materialCard16":
                case "materialCard17":
                case "materialCard18":
                    WorkerList form1 = new WorkerList();
                    form1.Show();
                    break;
            }
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
    }
}
