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
    public partial class FReview : MaterialForm
    {
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        RatingsDAO ratingDAO = new RatingsDAO();

        private int userId;
        private int workerId;

        public FReview(int userId, int workerId)
        {
            this.userId = userId;
            this.workerId = workerId;
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

        private void Review_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmitRatings_Click(object sender, EventArgs e)
        {
            Ratings ratings = new Ratings(txtReview.Text, Convert.ToDouble(cbxRate.Text));
            bool isUpdated;

            if (ratingDAO.RatingExists(this.workerId, this.userId))
            {
                isUpdated = ratingDAO.UpdateRatings(ratings, this.workerId, this.userId);
            }
            else
            {
                isUpdated = ratingDAO.AddRatings(ratings, this.workerId, this.userId);
            }

            if (isUpdated)
            {
                MessageBox.Show("Your rate updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update your rate information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearRate_Click(object sender, EventArgs e)
        {
            txtReview.Text = "";
        }


    }
}
