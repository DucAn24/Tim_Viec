﻿namespace TimViec
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            txtUserName = new TextBox();
            label3 = new Label();
            txtPassworld = new TextBox();
            label4 = new Label();
            txtConfirmPassworld = new TextBox();
            checkbxPassworld = new CheckBox();
            btnResgister = new Button();
            btnClear = new Button();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(506, 653);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Turquoise;
            label1.Location = new Point(620, 20);
            label1.Name = "label1";
            label1.Size = new Size(194, 34);
            label1.TabIndex = 7;
            label1.Text = "Get Started";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(620, 91);
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
            txtUserName.Location = new Point(620, 117);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(316, 27);
            txtUserName.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(620, 173);
            label3.Name = "label3";
            label3.Size = new Size(89, 23);
            label3.TabIndex = 10;
            label3.Text = "Passworld";
            // 
            // txtPassworld
            // 
            txtPassworld.BackColor = Color.FromArgb(230, 231, 233);
            txtPassworld.BorderStyle = BorderStyle.None;
            txtPassworld.Font = new Font("MS UI Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassworld.Location = new Point(620, 199);
            txtPassworld.Name = "txtPassworld";
            txtPassworld.Size = new Size(316, 27);
            txtPassworld.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(620, 263);
            label4.Name = "label4";
            label4.Size = new Size(160, 23);
            label4.TabIndex = 12;
            label4.Text = "Confirm Passworld";
            // 
            // txtConfirmPassworld
            // 
            txtConfirmPassworld.BackColor = Color.FromArgb(230, 231, 233);
            txtConfirmPassworld.BorderStyle = BorderStyle.None;
            txtConfirmPassworld.Font = new Font("MS UI Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPassworld.Location = new Point(620, 289);
            txtConfirmPassworld.Name = "txtConfirmPassworld";
            txtConfirmPassworld.Size = new Size(316, 27);
            txtConfirmPassworld.TabIndex = 13;
            // 
            // checkbxPassworld
            // 
            checkbxPassworld.AutoSize = true;
            checkbxPassworld.Cursor = Cursors.Hand;
            checkbxPassworld.FlatStyle = FlatStyle.Flat;
            checkbxPassworld.Location = new Point(780, 322);
            checkbxPassworld.Name = "checkbxPassworld";
            checkbxPassworld.Size = new Size(156, 27);
            checkbxPassworld.TabIndex = 14;
            checkbxPassworld.Text = "Show Passworld";
            checkbxPassworld.UseVisualStyleBackColor = true;
            // 
            // btnResgister
            // 
            btnResgister.BackColor = Color.Turquoise;
            btnResgister.FlatAppearance.BorderSize = 0;
            btnResgister.ForeColor = Color.White;
            btnResgister.Location = new Point(620, 364);
            btnResgister.Name = "btnResgister";
            btnResgister.Size = new Size(316, 58);
            btnResgister.TabIndex = 15;
            btnResgister.Text = "Resgister";
            btnResgister.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.White;
            btnClear.ForeColor = Color.LightSeaGreen;
            btnClear.Location = new Point(620, 448);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(316, 58);
            btnClear.TabIndex = 16;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(681, 534);
            label5.Name = "label5";
            label5.Size = new Size(205, 23);
            label5.TabIndex = 17;
            label5.Text = "Already have an account";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Turquoise;
            label6.Location = new Point(717, 567);
            label6.Name = "label6";
            label6.Size = new Size(126, 23);
            label6.TabIndex = 18;
            label6.Text = "Back to LOGIN";
            label6.Click += label6_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 653);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnClear);
            Controls.Add(btnResgister);
            Controls.Add(checkbxPassworld);
            Controls.Add(txtConfirmPassworld);
            Controls.Add(label4);
            Controls.Add(txtPassworld);
            Controls.Add(label3);
            Controls.Add(txtUserName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
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
        private TextBox txtPassworld;
        private Label label4;
        private TextBox txtConfirmPassworld;
        private CheckBox checkbxPassworld;
        private Button btnResgister;
        private Button btnClear;
        private Label label5;
        private Label label6;
    }
}