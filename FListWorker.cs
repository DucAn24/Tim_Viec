using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class FListWorker : MaterialForm
    {
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        private DbConnection dbConnection;
        private string category;
        private int userId;

        public FListWorker(string category, int userID)
        {
            InitializeComponent();
            dbConnection = new DbConnection();
            this.category = category;
            this.userId = userID;
            System.Diagnostics.Debug.WriteLine($"FCWorker form: userId = {this.userId}");




            materialSkinManager.EnforceBackcolorOnAllComponents = false;

            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightGreen900,
                                                                Primary.LightGreen700,
                                                                Primary.LightGreen500,
                                                                Accent.LightGreen200,
                                                                TextShade.WHITE);

        }


        private void WorkerList_Load(object sender, EventArgs e)
        {
            LoadDataAndAddPanels(category);
        }

        private void AddControlsToPanel(Image image, string label1Text, string label2Text, string label3Text, string label4Text, string salary, object userId, object Worker_id)
        {
            // Create a new panel
            MaterialCard card = new MaterialCard();
            card.Width = 700; // Set panel width as needed
            card.Height = 250;
            card.BackColor = Color.White;
            card.Tag = new { UserId = this.userId, WorkerId = Worker_id };
            card.Click += (sender, e) => OpenInformationForm((int)userId, (int)Worker_id);

            //create and configure picture box
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Set this to Zoom
            pictureBox.Size = new Size(90, 90); // Set this to desired size
            pictureBox.Location = new Point(20, 20);

            // Create and configure labels
            Label label1 = CreateLabel(label1Text, new Point(120, 20), new Font("Nirmala UI", 12, FontStyle.Bold), Color.Chocolate);
            Label label2 = CreateLabel(label2Text, new Point(120, 50), new Font("Nirmala UI", 16, FontStyle.Bold), Color.LightGreen);
            Label label3 = CreateLabel("Age: " + label3Text, new Point(20, 120));
            Label label4 = CreateLabel("Bio: " + label4Text, new Point(120, 100));
            Label salaryLabel = CreateLabel("Salary: " + salary, new Point(120, 120));

            // Create and configure buttons
            MaterialButton btnHire = CreateButton("Hire Talent", new Point(120, 200), card, HireWorker);
            MaterialButton btnFavourite = CreateButton("Add To Favourite", new Point(450, 200), card, AddWorkerToFavourites);
            MaterialButton btnAppointment = CreateButton("Make An Appointment", new Point(240, 200), null, (sender, e) => OpenAppointmentForm( (int)userId , (int)Worker_id));

            // add controls to the card
            card.Controls.AddRange(new Control[] { label1, label2, label3, label4, salaryLabel, pictureBox, btnHire, btnFavourite, btnAppointment });

            flowLayoutPanel1.Controls.Add(card);
        }

        private Label CreateLabel(string text, Point location, Font font = null, Color? color = null)
        {
            Label label = new Label();
            label.Text = text;
            label.AutoSize = true;
            label.Location = location;
            if (font != null) label.Font = font;
            if (color.HasValue) label.ForeColor = color.Value;
            return label;
        }

        private MaterialButton CreateButton(string text, Point location, MaterialCard card, EventHandler clickEvent)
        {
            MaterialButton button = new MaterialButton();
            button.Text = text;
            button.Location = location;
            if (card != null) button.Tag = card;
            button.Click += clickEvent;
            return button;
        }

        private void HireWorker(object sender, EventArgs e)
        {
            // Get the panel from the Hire button's Tag property
            MaterialCard card = (MaterialCard)((MaterialButton)sender).Tag;

            // Get the user ID and worker ID from the panel's Tag property
            var userId = ((dynamic)card.Tag).UserId;
            var workerId = ((dynamic)card.Tag).WorkerId;

            ClientDAO clientDAO = new ClientDAO();
            if (clientDAO.HireWorker(userId, workerId))
            {
                MessageBox.Show("Hire successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("You have already hired this worker.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddWorkerToFavourites(object sender, EventArgs e)
        {
            // Get the panel from the Hire button's Tag property
            MaterialCard card = (MaterialCard)((MaterialButton)sender).Tag;

            // Get the user ID and worker ID from the panel's Tag property
            var userId = ((dynamic)card.Tag).UserId;
            var workerId = ((dynamic)card.Tag).WorkerId;

            ClientDAO clientDAO = new ClientDAO();
            if (clientDAO.AddWorkerToFavourites(userId, workerId))
            {
                MessageBox.Show("Like successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("You have already like this worker.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadDataAndAddPanels(string category)
        {
            WorkerDAO workerDAO = new WorkerDAO();
            List<Worker> workers = workerDAO.GetWorkersByCategory(category);

            foreach (Worker worker in workers)
            {
                var imagePath = worker.ImagePath;
                var image = !string.IsNullOrEmpty(imagePath) ? Image.FromFile(imagePath) : null;

                string label1Text = worker.Name;
                string label2Text = worker.Skills;

                // Calculate age from date of birth
                int age = DateTime.Now.Year - worker.DateOfBirth.Year;
                if (DateTime.Now.DayOfYear < worker.DateOfBirth.DayOfYear)
                    age = age - 1;

                string label3Text = age.ToString();

                string label4Text = worker.Bio;

                string salary = worker.Salary;

                AddControlsToPanel(image, label1Text, label2Text, label3Text, label4Text, salary, this.userId, worker.WorkerId);
            }
        }

        public void SearchWorkers(string skills, string orderByPrice)
        {
            WorkerDAO workerDAO = new WorkerDAO();
            List<Worker> workers = workerDAO.SearchWorkers(skills, orderByPrice);

            // Clear the existing panels
            flowLayoutPanel1.Controls.Clear();

            foreach (Worker worker in workers)
            {
                var imagePath = worker.ImagePath;
                var image = !string.IsNullOrEmpty(imagePath) ? Image.FromFile(imagePath) : null;

                string label1Text = worker.Name;
                string label2Text = worker.Skills;

                // Calculate age from date of birth
                int age = DateTime.Now.Year - worker.DateOfBirth.Year;
                if (DateTime.Now.DayOfYear < worker.DateOfBirth.DayOfYear)
                    age = age - 1;

                string label3Text = age.ToString();

                string label4Text = worker.Bio;

                string salary = worker.Salary;

                AddControlsToPanel(image, label1Text, label2Text, label3Text, label4Text, salary, this.userId, worker.WorkerId);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchWorkers(txtSearch.Text, cbxPrice.SelectedItem.ToString());
        }


        private void OpenInformationForm(int userId, int workerId)
        {
            FInformation informationForm = new FInformation(userId, workerId);
            informationForm.Show();
        }


        private void OpenAppointmentForm(int userId, int workerId)
        {
            // Open the Appointment form
            FAppointment appointmentForm = new FAppointment(userId, workerId);
            appointmentForm.Show();
        }
    }
}







