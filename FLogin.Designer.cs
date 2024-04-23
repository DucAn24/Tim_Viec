namespace TimViec
{
    partial class FLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLogin));
            label6 = new Label();
            label5 = new Label();
            btnClear = new Button();
            btnLogin = new Button();
            ckbShowPassWord = new CheckBox();
            txtPassWord = new TextBox();
            label3 = new Label();
            txtUserName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Turquoise;
            label6.Location = new Point(766, 602);
            label6.Name = "label6";
            label6.Size = new Size(132, 23);
            label6.TabIndex = 31;
            label6.Text = "Create Account";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(747, 560);
            label5.Name = "label5";
            label5.Size = new Size(183, 23);
            label5.TabIndex = 30;
            label5.Text = "Dont have an account";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.White;
            btnClear.ForeColor = Color.LightSeaGreen;
            btnClear.Location = new Point(676, 472);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(316, 58);
            btnClear.TabIndex = 29;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click_1;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Turquoise;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(676, 386);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(316, 58);
            btnLogin.TabIndex = 28;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // ckbShowPassWord
            // 
            ckbShowPassWord.AutoSize = true;
            ckbShowPassWord.Cursor = Cursors.Hand;
            ckbShowPassWord.FlatStyle = FlatStyle.Flat;
            ckbShowPassWord.Location = new Point(836, 318);
            ckbShowPassWord.Name = "ckbShowPassWord";
            ckbShowPassWord.Size = new Size(156, 27);
            ckbShowPassWord.TabIndex = 27;
            ckbShowPassWord.Text = "Show Passworld";
            ckbShowPassWord.UseVisualStyleBackColor = true;
            ckbShowPassWord.CheckedChanged += ckbShowPassWord_CheckedChanged_1;
            // 
            // txtPassWord
            // 
            txtPassWord.BackColor = Color.FromArgb(230, 231, 233);
            txtPassWord.BorderStyle = BorderStyle.None;
            txtPassWord.Font = new Font("MS UI Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassWord.Location = new Point(676, 285);
            txtPassWord.Name = "txtPassWord";
            txtPassWord.PasswordChar = '*';
            txtPassWord.Size = new Size(316, 27);
            txtPassWord.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(676, 259);
            label3.Name = "label3";
            label3.Size = new Size(89, 23);
            label3.TabIndex = 23;
            label3.Text = "Passworld";
            // 
            // txtUserName
            // 
            txtUserName.BackColor = Color.FromArgb(230, 231, 233);
            txtUserName.BorderStyle = BorderStyle.None;
            txtUserName.Font = new Font("MS UI Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUserName.Location = new Point(676, 203);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(316, 27);
            txtUserName.TabIndex = 22;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(676, 177);
            label2.Name = "label2";
            label2.Size = new Size(94, 23);
            label2.TabIndex = 21;
            label2.Text = "User name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Turquoise;
            label1.Location = new Point(676, 109);
            label1.Name = "label1";
            label1.Size = new Size(194, 34);
            label1.TabIndex = 20;
            label1.Text = "Get Started";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 64);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(623, 599);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // FLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1070, 666);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnClear);
            Controls.Add(btnLogin);
            Controls.Add(ckbShowPassWord);
            Controls.Add(txtPassWord);
            Controls.Add(label3);
            Controls.Add(txtUserName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Label label5;
        private Button btnClear;
        private Button btnLogin;
        private CheckBox ckbShowPassWord;
        private TextBox txtPassWord;
        private Label label3;
        private TextBox txtUserName;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
    }
}