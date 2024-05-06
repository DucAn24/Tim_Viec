namespace TimViec
{
    partial class FAppointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAppointment));
            label5 = new Label();
            dtpApointment = new DateTimePicker();
            btnSend = new MaterialSkin.Controls.MaterialButton();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            txtContent = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Nirmala UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.LightGreen;
            label5.Location = new Point(104, 97);
            label5.Name = "label5";
            label5.Size = new Size(455, 54);
            label5.TabIndex = 25;
            label5.Text = "Appointment Schedule";
            // 
            // dtpApointment
            // 
            dtpApointment.Location = new Point(125, 217);
            dtpApointment.Name = "dtpApointment";
            dtpApointment.Size = new Size(248, 27);
            dtpApointment.TabIndex = 26;
            // 
            // btnSend
            // 
            btnSend.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSend.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSend.Depth = 0;
            btnSend.HighEmphasis = true;
            btnSend.Icon = null;
            btnSend.Location = new Point(125, 455);
            btnSend.Margin = new Padding(4, 6, 4, 6);
            btnSend.MouseState = MaterialSkin.MouseState.HOVER;
            btnSend.Name = "btnSend";
            btnSend.NoAccentTextColor = Color.Empty;
            btnSend.Size = new Size(64, 36);
            btnSend.TabIndex = 27;
            btnSend.Text = "Send";
            btnSend.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSend.UseAccentColor = false;
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(16, 79);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(82, 81);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 28;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(125, 186);
            label1.Name = "label1";
            label1.Size = new Size(54, 28);
            label1.TabIndex = 30;
            label1.Text = "Time";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label2.ForeColor = SystemColors.MenuHighlight;
            label2.Location = new Point(125, 271);
            label2.Name = "label2";
            label2.Size = new Size(82, 28);
            label2.TabIndex = 31;
            label2.Text = "Content";
            // 
            // txtContent
            // 
            txtContent.AnimateReadOnly = false;
            txtContent.BackgroundImageLayout = ImageLayout.None;
            txtContent.CharacterCasing = CharacterCasing.Normal;
            txtContent.Depth = 0;
            txtContent.HideSelection = true;
            txtContent.Location = new Point(125, 302);
            txtContent.MaxLength = 32767;
            txtContent.MouseState = MaterialSkin.MouseState.OUT;
            txtContent.Name = "txtContent";
            txtContent.PasswordChar = '\0';
            txtContent.ReadOnly = false;
            txtContent.ScrollBars = ScrollBars.None;
            txtContent.SelectedText = "";
            txtContent.SelectionLength = 0;
            txtContent.SelectionStart = 0;
            txtContent.ShortcutsEnabled = true;
            txtContent.Size = new Size(329, 120);
            txtContent.TabIndex = 32;
            txtContent.TabStop = false;
            txtContent.TextAlign = HorizontalAlignment.Left;
            txtContent.UseSystemPasswordChar = false;
            // 
            // FAppointment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 535);
            Controls.Add(txtContent);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(btnSend);
            Controls.Add(dtpApointment);
            Controls.Add(label5);
            Name = "FAppointment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Appointment";
            Load += Appointment_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private DateTimePicker dtpApointment;
        private MaterialSkin.Controls.MaterialButton btnSend;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtContent;
    }
}