namespace TimViec
{
    partial class FResgister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FResgister));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            txtUserName = new TextBox();
            label3 = new Label();
            txtPassWord = new TextBox();
            label4 = new Label();
            txtConfirmPassword = new TextBox();
            ckbShowPassWord = new CheckBox();
            btnResgister = new Button();
            btnClear = new Button();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ckbClient = new CheckBox();
            ckbWorker = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 64);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(613, 595);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Turquoise;
            label1.Location = new Point(687, 81);
            label1.Name = "label1";
            label1.Size = new Size(194, 34);
            label1.TabIndex = 7;
            label1.Text = "Get Started";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(687, 126);
            label2.Name = "label2";
            label2.Size = new Size(94, 23);
            label2.TabIndex = 8;
            label2.Text = "User name";
            // 
            // txtUserName
            // 
            txtUserName.BackColor = Color.FromArgb(230, 231, 233);
            txtUserName.BorderStyle = BorderStyle.None;
            txtUserName.Font = new Font("MS UI Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUserName.Location = new Point(687, 152);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(316, 27);
            txtUserName.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(687, 208);
            label3.Name = "label3";
            label3.Size = new Size(89, 23);
            label3.TabIndex = 10;
            label3.Text = "Passworld";
            // 
            // txtPassWord
            // 
            txtPassWord.BackColor = Color.FromArgb(230, 231, 233);
            txtPassWord.BorderStyle = BorderStyle.None;
            txtPassWord.Font = new Font("MS UI Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassWord.Location = new Point(687, 234);
            txtPassWord.Name = "txtPassWord";
            txtPassWord.PasswordChar = '*';
            txtPassWord.Size = new Size(316, 27);
            txtPassWord.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(687, 285);
            label4.Name = "label4";
            label4.Size = new Size(160, 23);
            label4.TabIndex = 12;
            label4.Text = "Confirm Passworld";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BackColor = Color.FromArgb(230, 231, 233);
            txtConfirmPassword.BorderStyle = BorderStyle.None;
            txtConfirmPassword.Font = new Font("MS UI Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPassword.Location = new Point(687, 311);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(316, 27);
            txtConfirmPassword.TabIndex = 13;
            // 
            // ckbShowPassWord
            // 
            ckbShowPassWord.AutoSize = true;
            ckbShowPassWord.Cursor = Cursors.Hand;
            ckbShowPassWord.FlatStyle = FlatStyle.Flat;
            ckbShowPassWord.Location = new Point(847, 347);
            ckbShowPassWord.Name = "ckbShowPassWord";
            ckbShowPassWord.Size = new Size(156, 27);
            ckbShowPassWord.TabIndex = 14;
            ckbShowPassWord.Text = "Show Passworld";
            ckbShowPassWord.UseVisualStyleBackColor = true;
            ckbShowPassWord.CheckedChanged += ckbShowPassWord_CheckedChanged_1;
            // 
            // btnResgister
            // 
            btnResgister.BackColor = Color.Turquoise;
            btnResgister.FlatAppearance.BorderSize = 0;
            btnResgister.ForeColor = Color.White;
            btnResgister.Location = new Point(687, 444);
            btnResgister.Name = "btnResgister";
            btnResgister.Size = new Size(316, 58);
            btnResgister.TabIndex = 15;
            btnResgister.Text = "Resgister";
            btnResgister.UseVisualStyleBackColor = false;
            btnResgister.Click += btnResgister_Click_1;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.White;
            btnClear.ForeColor = Color.LightSeaGreen;
            btnClear.Location = new Point(687, 508);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(316, 58);
            btnClear.TabIndex = 16;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(748, 583);
            label5.Name = "label5";
            label5.Size = new Size(205, 23);
            label5.TabIndex = 17;
            label5.Text = "Already have an account";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Turquoise;
            label6.Location = new Point(784, 616);
            label6.Name = "label6";
            label6.Size = new Size(126, 23);
            label6.TabIndex = 18;
            label6.Text = "Back to LOGIN";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(687, 398);
            label7.Name = "label7";
            label7.Size = new Size(45, 23);
            label7.TabIndex = 19;
            label7.Text = "Role";
            // 
            // ckbClient
            // 
            ckbClient.AutoSize = true;
            ckbClient.Cursor = Cursors.Hand;
            ckbClient.FlatStyle = FlatStyle.Flat;
            ckbClient.Location = new Point(748, 398);
            ckbClient.Name = "ckbClient";
            ckbClient.Size = new Size(75, 27);
            ckbClient.TabIndex = 20;
            ckbClient.Text = "Client";
            ckbClient.UseVisualStyleBackColor = true;
            ckbClient.CheckedChanged += ckbClient_CheckedChanged;
            // 
            // ckbWorker
            // 
            ckbWorker.AutoSize = true;
            ckbWorker.Cursor = Cursors.Hand;
            ckbWorker.FlatStyle = FlatStyle.Flat;
            ckbWorker.Location = new Point(847, 398);
            ckbWorker.Name = "ckbWorker";
            ckbWorker.Size = new Size(88, 27);
            ckbWorker.TabIndex = 21;
            ckbWorker.Text = "Worker";
            ckbWorker.UseVisualStyleBackColor = true;
            ckbWorker.CheckedChanged += ckbWorker_CheckedChanged;
            // 
            // FResgister
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1091, 662);
            Controls.Add(ckbWorker);
            Controls.Add(ckbClient);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnClear);
            Controls.Add(btnResgister);
            Controls.Add(ckbShowPassWord);
            Controls.Add(txtConfirmPassword);
            Controls.Add(label4);
            Controls.Add(txtPassWord);
            Controls.Add(label3);
            Controls.Add(txtUserName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FResgister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Resgister";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private TextBox txtUserName;
        private Label label3;
        private TextBox txtPassWord;
        private Label label4;
        private TextBox txtConfirmPassword;
        private CheckBox ckbShowPassWord;
        private Button btnResgister;
        private Button btnClear;
        private Label label5;
        private Label label6;
        private Label label7;
        private CheckBox ckbClient;
        private CheckBox ckbWorker;
    }
}