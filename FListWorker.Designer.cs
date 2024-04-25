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
            flowLayoutPanel1 = new FlowLayoutPanel();
            label18 = new Label();
            cbxPrice = new MaterialSkin.Controls.MaterialComboBox();
            txtSearch = new MaterialSkin.Controls.MaterialTextBox2();
            btnSearch = new MaterialSkin.Controls.MaterialButton();
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(24, 238);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1521, 706);
            flowLayoutPanel1.TabIndex = 17;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Nirmala UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.LightGreen;
            label18.Location = new Point(58, 74);
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
            cbxPrice.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbxPrice.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbxPrice.FormattingEnabled = true;
            cbxPrice.Hint = "Price";
            cbxPrice.IntegralHeight = false;
            cbxPrice.ItemHeight = 43;
            cbxPrice.Items.AddRange(new object[] { "ASC", "DESC" });
            cbxPrice.Location = new Point(632, 152);
            cbxPrice.MaxDropDownItems = 4;
            cbxPrice.MouseState = MaterialSkin.MouseState.OUT;
            cbxPrice.Name = "cbxPrice";
            cbxPrice.Size = new Size(151, 49);
            cbxPrice.StartIndex = 0;
            cbxPrice.TabIndex = 24;
            // 
            // txtSearch
            // 
            txtSearch.AnimateReadOnly = false;
            txtSearch.BackgroundImageLayout = ImageLayout.None;
            txtSearch.CharacterCasing = CharacterCasing.Normal;
            txtSearch.Depth = 0;
            txtSearch.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSearch.HideSelection = true;
            txtSearch.Hint = "Search for skill";
            txtSearch.LeadingIcon = null;
            txtSearch.Location = new Point(58, 152);
            txtSearch.MaxLength = 32767;
            txtSearch.MouseState = MaterialSkin.MouseState.OUT;
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.PrefixSuffixText = null;
            txtSearch.ReadOnly = false;
            txtSearch.RightToLeft = RightToLeft.No;
            txtSearch.SelectedText = "";
            txtSearch.SelectionLength = 0;
            txtSearch.SelectionStart = 0;
            txtSearch.ShortcutsEnabled = true;
            txtSearch.Size = new Size(520, 48);
            txtSearch.TabIndex = 26;
            txtSearch.TabStop = false;
            txtSearch.TextAlign = HorizontalAlignment.Left;
            txtSearch.TrailingIcon = null;
            txtSearch.UseSystemPasswordChar = false;
            // 
            // btnSearch
            // 
            btnSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSearch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSearch.Depth = 0;
            btnSearch.HighEmphasis = true;
            btnSearch.Icon = (Image)resources.GetObject("btnSearch.Icon");
            btnSearch.Location = new Point(829, 164);
            btnSearch.Margin = new Padding(4, 6, 4, 6);
            btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            btnSearch.Name = "btnSearch";
            btnSearch.NoAccentTextColor = Color.Empty;
            btnSearch.Size = new Size(106, 36);
            btnSearch.TabIndex = 27;
            btnSearch.Text = "search";
            btnSearch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSearch.UseAccentColor = false;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // FListWorker
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 950);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(cbxPrice);
            Controls.Add(label18);
            Controls.Add(flowLayoutPanel1);
            Name = "FListWorker";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WorkerList";
            Load += WorkerList_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ImageList imageList1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label18;
        private MaterialSkin.Controls.MaterialComboBox cbxPrice;
        private MaterialSkin.Controls.MaterialTextBox2 txtSearch;
        private MaterialSkin.Controls.MaterialButton btnSearch;
    }
}