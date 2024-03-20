namespace TimViec
{
    partial class WorkerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerList));
            imageList1 = new ImageList(components);
            label7 = new Label();
            materialButton14 = new MaterialSkin.Controls.MaterialButton();
            materialComboBox2 = new MaterialSkin.Controls.MaterialComboBox();
            materialTextBox25 = new MaterialSkin.Controls.MaterialTextBox2();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label18 = new Label();
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
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label7.ForeColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(1061, 172);
            label7.Name = "label7";
            label7.Size = new Size(86, 31);
            label7.TabIndex = 16;
            label7.Text = "Sort by";
            // 
            // materialButton14
            // 
            materialButton14.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton14.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton14.Depth = 0;
            materialButton14.HighEmphasis = true;
            materialButton14.Icon = (Image)resources.GetObject("materialButton14.Icon");
            materialButton14.Location = new Point(722, 166);
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
            // materialComboBox2
            // 
            materialComboBox2.AutoResize = false;
            materialComboBox2.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBox2.Depth = 0;
            materialComboBox2.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBox2.DropDownHeight = 174;
            materialComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox2.DropDownWidth = 121;
            materialComboBox2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBox2.FormattingEnabled = true;
            materialComboBox2.IntegralHeight = false;
            materialComboBox2.ItemHeight = 43;
            materialComboBox2.Items.AddRange(new object[] { "Latest", "Oldest", "Lowest Price", "Highest Price" });
            materialComboBox2.Location = new Point(1188, 154);
            materialComboBox2.MaxDropDownItems = 4;
            materialComboBox2.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox2.Name = "materialComboBox2";
            materialComboBox2.Size = new Size(151, 49);
            materialComboBox2.StartIndex = 0;
            materialComboBox2.TabIndex = 14;
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
            materialTextBox25.Location = new Point(129, 154);
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
            materialTextBox25.Size = new Size(542, 48);
            materialTextBox25.TabIndex = 13;
            materialTextBox25.TabStop = false;
            materialTextBox25.TextAlign = HorizontalAlignment.Left;
            materialTextBox25.TrailingIcon = null;
            materialTextBox25.UseSystemPasswordChar = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(129, 239);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1304, 694);
            flowLayoutPanel1.TabIndex = 17;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Nirmala UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.LightGreen;
            label18.Location = new Point(129, 74);
            label18.Name = "label18";
            label18.Size = new Size(229, 54);
            label18.TabIndex = 23;
            label18.Text = "Find Talent";
            // 
            // WorkerList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 950);
            Controls.Add(label18);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label7);
            Controls.Add(materialButton14);
            Controls.Add(materialComboBox2);
            Controls.Add(materialTextBox25);
            Name = "WorkerList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WorkerList";
            Load += WorkerList_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ImageList imageList1;
        private Label label7;
        private MaterialSkin.Controls.MaterialButton materialButton14;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox2;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox25;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label18;
    }
}