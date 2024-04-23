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

namespace TimViec
{
    public partial class FWorker : MaterialForm
    {
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        private DbConnection dbConnection;

        JobDAO jobDAO = new JobDAO();
        WorkerDAO workerDAO = new WorkerDAO();
        private int userId;
        private int worker_id;

        public FWorker(int userId)
        {
            this.userId = userId;
            dbConnection = new DbConnection();
            this.worker_id = GetWorkerIdFromUserId(userId);

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

        private void Worker_Load(object sender, EventArgs e)
        {
            AddPanelToFlowLayoutAppointment(flowLayoutPanel2);
        }

        public int GetWorkerIdFromUserId(int userId)
        {
            int workerId = -1; // Initialize to -1 to represent not found

            // Open the database connection
            dbConnection.Open();

            // Create the SQL command to get the worker_id
            string query = @"
                        SELECT W.Worker_id
                        FROM Users U
                        JOIN Worker W
                        ON U.user_id = W.user_id
                        WHERE U.user_id = @UserId
                    ";

            SqlCommand command = new SqlCommand(query, dbConnection.Connection);

            // Add the user_id parameter to the command
            command.Parameters.AddWithValue("@UserId", userId);

            // Execute the command and get the result
            object result = command.ExecuteScalar();

            // If a result was returned, set the workerId
            if (result != null)
            {
                workerId = (int)result;
            }

            // Close the database connection
            dbConnection.Close();

            return workerId;
        }

        private Dictionary<string, string> pictureToCategoryMap = new Dictionary<string, string>
        {
            { "pictureBox2", "Devlopment-IT" },
            { "pictureBox3", "AI-Services" },
            { "pictureBox4", "Design-Creative" },
            { "pictureBox5", "Sales-Marketing" },
            { "pictureBox6", "Engineering-Architecture" },
            { "pictureBox7", "Finance-Accounting" },
            { "pictureBox8", "Admin-Custome-Support" },
            { "pictureBox9", "Writing-Traslation" },
            // Add more if needed
        };


        private Dictionary<string, string> cardToCategoryMap = new Dictionary<string, string>
        {
            { "materialCard6", "Devlopment-IT" },
            { "materialCard14", "AI-Services" },
            { "materialCard12", "Design-Creative" },
            { "materialCard10", "Sales-Marketing" },
            { "materialCard15", "Writing-Traslation" },
            { "materialCard16", "Admin-Custome Support" },
            { "materialCard17", "Finance-Accounting" },
            { "materialCard18", "Engineering-Architecture" },
            // Add more if needed
        };

        private void PictureBox_Click(object sender, EventArgs e)
        {
            // Determine which PictureBox was clicked
            PictureBox clickedPictureBox = sender as PictureBox;

            // Create and show the appropriate form based on the clicked PictureBox
            if (clickedPictureBox != null && pictureToCategoryMap.TryGetValue(clickedPictureBox.Name, out string category))
            {
                OpenFListJob(category, userId);
            }
        }

        private void MaterialCard_Click(object sender, EventArgs e)
        {
            // Determine which MaterialCard was clicked
            MaterialCard clickedCard = sender as MaterialCard;

            // Fetch the data for the category of the clicked card
            if (clickedCard != null && cardToCategoryMap.TryGetValue(clickedCard.Name, out string category))
            {
                OpenFListJob(category, userId);
            }
        }


        private void OpenFListJob(string category, int userID)
        {
            FListJob jobList = new FListJob(category, userID);
            jobList.Show();
        }

        private void materialTabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.materialTabControl1.SelectedIndex == 5) // Assuming the "Log out" tab is at index 5
            {
                this.Hide(); // Hide the current form
                new FLogin().Show(); // Show the Login form
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

        private string imagePath;
        private string imageJob;

        private string SelectImageFile(PictureBox pictureBox)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = new Bitmap(ofd.FileName);
                    return ofd.FileName;
                }
            }
            return null;
        }

        private void btnImportImage_Click(object sender, EventArgs e)
        {
            imagePath = SelectImageFile(picBoxUser);
        }
        private void btnImportJob_Click_1(object sender, EventArgs e)
        {
            imageJob = SelectImageFile(pictureBoxJob);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Worker worker = new Worker(txtName.Text, txtEmail.Text, dtpBirth.Value, imagePath, txtPhone.Text, txtAddress.Text, gender, txtBio.Text, txtSkill.Text, cbxCategory2.Text, txtSalary.Text);
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

        private void btnSubmitJob_Click(object sender, EventArgs e)
        {
            JobInfor jobInfor = new JobInfor(txtTitle.Text, txtDescription.Text, cbxCategory.Text, txtPrice.Text, imageJob);
            bool isUpdated = jobDAO.AddJobHistory(jobInfor, this.worker_id);
            if (isUpdated)
            {
                MessageBox.Show("Job history information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update job history information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
