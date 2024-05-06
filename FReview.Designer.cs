namespace TimViec
{
    partial class FReview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FReview));
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            pictureBox2 = new PictureBox();
            cbxRate = new ComboBox();
            lbRate = new Label();
            btnClearRate = new MaterialSkin.Controls.MaterialButton();
            btnSubmitRatings = new MaterialSkin.Controls.MaterialButton();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            lbReview = new Label();
            txtReview = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            materialCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(pictureBox2);
            materialCard2.Controls.Add(cbxRate);
            materialCard2.Depth = 0;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(922, 77);
            materialCard2.Margin = new Padding(14);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(14);
            materialCard2.Size = new Size(247, 130);
            materialCard2.TabIndex = 32;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(148, 32);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(60, 56);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 31;
            pictureBox2.TabStop = false;
            // 
            // cbxRate
            // 
            cbxRate.Font = new Font("Nirmala UI Semilight", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxRate.FormattingEnabled = true;
            cbxRate.Items.AddRange(new object[] { "5", "4", "3", "2", "1" });
            cbxRate.Location = new Point(28, 39);
            cbxRate.Name = "cbxRate";
            cbxRate.Size = new Size(79, 49);
            cbxRate.TabIndex = 30;
            cbxRate.Text = "5";
            // 
            // lbRate
            // 
            lbRate.AutoSize = true;
            lbRate.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbRate.ForeColor = Color.LightGreen;
            lbRate.Location = new Point(962, 17);
            lbRate.Name = "lbRate";
            lbRate.Size = new Size(110, 31);
            lbRate.TabIndex = 29;
            lbRate.Text = "Rate Star";
            // 
            // btnClearRate
            // 
            btnClearRate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClearRate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnClearRate.Depth = 0;
            btnClearRate.HighEmphasis = true;
            btnClearRate.Icon = null;
            btnClearRate.Location = new Point(156, 357);
            btnClearRate.Margin = new Padding(4, 6, 4, 6);
            btnClearRate.MouseState = MaterialSkin.MouseState.HOVER;
            btnClearRate.Name = "btnClearRate";
            btnClearRate.NoAccentTextColor = Color.Empty;
            btnClearRate.Size = new Size(66, 36);
            btnClearRate.TabIndex = 28;
            btnClearRate.Text = "clear";
            btnClearRate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnClearRate.UseAccentColor = true;
            btnClearRate.UseVisualStyleBackColor = true;
            btnClearRate.Click += btnClearRate_Click;
            // 
            // btnSubmitRatings
            // 
            btnSubmitRatings.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSubmitRatings.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSubmitRatings.Depth = 0;
            btnSubmitRatings.HighEmphasis = true;
            btnSubmitRatings.Icon = null;
            btnSubmitRatings.Location = new Point(56, 357);
            btnSubmitRatings.Margin = new Padding(4, 6, 4, 6);
            btnSubmitRatings.MouseState = MaterialSkin.MouseState.HOVER;
            btnSubmitRatings.Name = "btnSubmitRatings";
            btnSubmitRatings.NoAccentTextColor = Color.Empty;
            btnSubmitRatings.Size = new Size(75, 36);
            btnSubmitRatings.TabIndex = 27;
            btnSubmitRatings.Text = "submit ";
            btnSubmitRatings.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSubmitRatings.UseAccentColor = true;
            btnSubmitRatings.UseVisualStyleBackColor = true;
            btnSubmitRatings.Click += btnSubmitRatings_Click;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(materialCard2);
            materialCard1.Controls.Add(lbReview);
            materialCard1.Controls.Add(btnClearRate);
            materialCard1.Controls.Add(lbRate);
            materialCard1.Controls.Add(btnSubmitRatings);
            materialCard1.Controls.Add(txtReview);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(38, 100);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(1238, 459);
            materialCard1.TabIndex = 31;
            // 
            // lbReview
            // 
            lbReview.AutoSize = true;
            lbReview.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbReview.ForeColor = Color.LightGreen;
            lbReview.Location = new Point(14, 17);
            lbReview.Name = "lbReview";
            lbReview.Size = new Size(141, 31);
            lbReview.TabIndex = 25;
            lbReview.Text = "Post Review";
            // 
            // txtReview
            // 
            txtReview.AnimateReadOnly = false;
            txtReview.BackgroundImageLayout = ImageLayout.None;
            txtReview.CharacterCasing = CharacterCasing.Normal;
            txtReview.Depth = 0;
            txtReview.HideSelection = true;
            txtReview.Location = new Point(17, 60);
            txtReview.MaxLength = 32767;
            txtReview.MouseState = MaterialSkin.MouseState.OUT;
            txtReview.Name = "txtReview";
            txtReview.PasswordChar = '\0';
            txtReview.ReadOnly = false;
            txtReview.ScrollBars = ScrollBars.None;
            txtReview.SelectedText = "";
            txtReview.SelectionLength = 0;
            txtReview.SelectionStart = 0;
            txtReview.ShortcutsEnabled = true;
            txtReview.Size = new Size(778, 232);
            txtReview.TabIndex = 26;
            txtReview.TabStop = false;
            txtReview.TextAlign = HorizontalAlignment.Left;
            txtReview.UseSystemPasswordChar = false;
            // 
            // FReview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1344, 625);
            Controls.Add(materialCard1);
            Name = "FReview";
            Text = "Review";
            Load += Review_Load;
            materialCard2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard2;
        private PictureBox pictureBox2;
        private ComboBox cbxRate;
        private Label lbRate;
        private MaterialSkin.Controls.MaterialButton btnClearRate;
        private MaterialSkin.Controls.MaterialButton btnSubmitRatings;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Label lbReview;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtReview;
    }
}