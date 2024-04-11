namespace TimViec
{
    partial class FListWorker
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FListWorker));
            imageList1 = new ImageList(components);
            materialButton14 = new MaterialSkin.Controls.MaterialButton();
            materialTextBox25 = new MaterialSkin.Controls.MaterialTextBox2();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label18 = new Label();
            cbxPrice = new MaterialSkin.Controls.MaterialComboBox();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "christopher-gower-m_HRfLhgABo-unsplash.jpg");
            imageList1.Images.SetKeyName(1, "icons8-bonds-96.png");
            imageList1.Images.SetKeyName(2, "icons8-support-96.png");
            imageList1.Images.SetKeyName(3, "icons8-gears-96.png");
            imageList1.Images.SetKeyName(4, "icons8-it-96.png");
            imageList1.Images.SetKeyName(5, "icons8-search-64.png");
            imageList1.Images.SetKeyName(6, "images.png");
            imageList1.Images.SetKeyName(7, "icons8-writing-96.png");
            imageList1.Images.SetKeyName(8, "people.png");
            imageList1.Images.SetKeyName(9, "icons8-save-48.png");
            // 
            // materialButton14
            // 
            materialButton14.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton14.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton14.Depth = 0;
            materialButton14.HighEmphasis = true;
            materialButton14.Icon = (Image)resources.GetObject("materialButton14.Icon");
            materialButton14.Location = new Point(823, 159);
            materialButton14.Margin = new Padding(4, 6, 4, 6);
            materialButton14.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton14.Name = "materialButton14";
            materialButton14.NoAccentTextColor = Color.Empty;
            materialButton14.Size = new Size(106, 36);
            materialButton14.TabIndex = 15;
            materialButton14.Text = "search";
            materialButton14.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton14.UseAccentColor = false;
            materialButton14.UseVisualStyleBackColor = true;
            // 
            // materialTextBox25
            // 
            materialTextBox25.AnimateReadOnly = false;
            materialTextBox25.BackgroundImageLayout = ImageLayout.None;
            materialTextBox25.CharacterCasing = CharacterCasing.Normal;
            materialTextBox25.Depth = 0;
            materialTextBox25.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox25.HideSelection = true;
            materialTextBox25.Hint = "Search for project";
            materialTextBox25.LeadingIcon = null;
            materialTextBox25.Location = new Point(58, 146);
            materialTextBox25.MaxLength = 32767;
            materialTextBox25.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox25.Name = "materialTextBox25";
            materialTextBox25.PasswordChar = '\0';
            materialTextBox25.PrefixSuffixText = null;
            materialTextBox25.ReadOnly = false;
            materialTextBox25.RightToLeft = RightToLeft.No;
            materialTextBox25.SelectedText = "";
            materialTextBox25.SelectionLength = 0;
            materialTextBox25.SelectionStart = 0;
            materialTextBox25.ShortcutsEnabled = true;
            materialTextBox25.Size = new Size(520, 48);
            materialTextBox25.TabIndex = 13;
            materialTextBox25.TabStop = false;
            materialTextBox25.TextAlign = HorizontalAlignment.Left;
            materialTextBox25.TrailingIcon = null;
            materialTextBox25.UseSystemPasswordChar = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(31, 212);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1521, 721);
            flowLayoutPanel1.TabIndex = 17;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Nirmala UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.LightGreen;
            label18.Location = new Point(58, 75);
            label18.Name = "label18";
            label18.Size = new Size(229, 54);
            label18.TabIndex = 23;
            label18.Text = "Find Talent";
            // 
            // cbxPrice
            // 
            cbxPrice.AutoResize = false;
            cbxPrice.BackColor = Color.FromArgb(255, 255, 255);
            cbxPrice.Depth = 0;
            cbxPrice.DrawMode = DrawMode.OwnerDrawVariable;
            cbxPrice.DropDownHeight = 174;
            cbxPrice.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxPrice.DropDownWidth = 121;
            cbxPrice.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbxPrice.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbxPrice.FormattingEnabled = true;
            cbxPrice.Hint = "Price";
            cbxPrice.IntegralHeight = false;
            cbxPrice.ItemHeight = 43;
            cbxPrice.Items.AddRange(new object[] { "ASC", "DES" });
            cbxPrice.Location = new Point(634, 146);
            cbxPrice.MaxDropDownItems = 4;
            cbxPrice.MouseState = MaterialSkin.MouseState.OUT;
            cbxPrice.Name = "cbxPrice";
            cbxPrice.Size = new Size(151, 49);
            cbxPrice.StartIndex = 0;
            cbxPrice.TabIndex = 24;
            // 
            // FList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 950);
            Controls.Add(cbxPrice);
            Controls.Add(label18);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(materialButton14);
            Controls.Add(materialTextBox25);
            Name = "FList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WorkerList";
            Load += WorkerList_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ImageList imageList1;
        private MaterialSkin.Controls.MaterialButton materialButton14;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox25;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label18;
        private MaterialSkin.Controls.MaterialComboBox cbxPrice;
    }
}