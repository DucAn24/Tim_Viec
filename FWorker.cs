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

        private Dictionary<MaterialCard, string> cardToCategoryMap;
        private Dictionary<PictureBox, string> pictureToCategoryMap;


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

            cardToCategoryMap = new Dictionary<MaterialCard, string>
            {
                { materialCard6, "Devlopment-IT" },
                { materialCard14, "AI-Services" },
                { materialCard12, "Design-Creative" },
                { materialCard10, "Sales-Marketing" },
                { materialCard15, "Writing-Traslation" },
                { materialCard16, "Admin-Custome Support" },
                { materialCard17, "Finance-Accounting" },
                { materialCard18, "Engineering-Architecture" },
            };

            pictureToCategoryMap = new Dictionary<PictureBox, string>
            {
                { pictureBox2, "Devlopment-IT" },
                { pictureBox3, "AI-Services" },
                { pictureBox4, "Design-Creative" },
                { pictureBox5, "Sales-Marketing" },
                { pictureBox6, "Engineering-Architecture" },
                { pictureBox7, "Finance-Accounting" },
                { pictureBox8, "Admin-Custome-Support" },
                { pictureBox9, "Writing-Traslation" },
            };

            foreach (var pair in cardToCategoryMap)
            {
                pair.Key.Click += MaterialCard_Click;
            }

            foreach (var pair in pictureToCategoryMap)
            {
                pair.Key.Click += PictureBox_Click;
            }

        }

        private void Worker_Load(object sender, EventArgs e)
        {
            AddPanelToWorkDone(worker_id);
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


        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedPictureBox && pictureToCategoryMap.TryGetValue(clickedPictureBox, out string category))
            {
                OpenFListJob(category, userId);
            }
        }

        private void MaterialCard_Click(object sender, EventArgs e)
        {
            if (sender is MaterialCard clickedCard && cardToCategoryMap.TryGetValue(clickedCard, out string category))
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
            if (this.materialTabControl1.SelectedIndex == 5) 
            {
                this.Hide(); 
                new FLogin().Show(); 
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


        private Label CreateLabel(string text, Font font, Point location)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = font;
            label.AutoSize = true;
            label.MaximumSize = new Size(440, 0);
            label.Location = location;
            label.TextAlign = ContentAlignment.TopLeft;
            return label;
        }

        private void AddControlsToPanel(Image image, string label1Text, string label4Text, string category, string price)
        {
            // Create and configure picture box
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(150, 150);
            pictureBox.Location = new Point(500, 20);

            // Create and configure labels
            Label label1 = CreateLabel(label1Text, new Font("Nirmala UI", 14, FontStyle.Bold), new Point(40, 10));
            label1.ForeColor = Color.Chocolate;

            Label label4 = CreateLabel(label4Text, new Font("Nirmala UI", 12), new Point(40, 50));

            Label lableCategory = CreateLabel("Category: " + category, new Font("Nirmala UI", 12), new Point(40, 130));

            Label labelPrice = CreateLabel("Price: " + price, new Font("Nirmala UI", 12), new Point(40, 190));

            // Create a new panel
            MaterialCard card = new MaterialCard();
            card.Width = 680;
            card.Height = 250;
            card.BackColor = Color.White;

            // Add controls to the card
            card.Controls.Add(label1);
            card.Controls.Add(label4);
            card.Controls.Add(pictureBox);
            card.Controls.Add(lableCategory);
            card.Controls.Add(labelPrice);

            flpWorkDone.Controls.Add(card);
        }


        private void AddPanelToWorkDone(int workerId)
        {
            dbConnection.Open();
            string query = @"
                            SELECT J.JobTitle,
		                            J.JobDescription,
		                            J.Price,
		                            J.Category,
		                            J.ImagesJob
                            FROM JobHistory J
                            WHERE J.Worker_id = @workerId
                            ";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@workerId", workerId);
            DataTable dataTable = dbConnection.ExecuteQuery(command);

            foreach (DataRow row in dataTable.Rows)
            {

                var imagePath = row["ImagesJob"] as string;
                var image = !string.IsNullOrEmpty(imagePath) ? Image.FromFile(imagePath) : null;

                string label1Text = row["JobTitle"].ToString();
                string label2Text = row["JobDescription"].ToString();
                string category = row["Category"].ToString();
                string price = row["Price"].ToString();


                AddControlsToPanel(image, label1Text, label2Text, category, price);
            }
            dbConnection.Close();
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
