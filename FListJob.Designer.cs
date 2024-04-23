namespace TimViec
{
    partial class FListJob
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FListJob));
            cbxPrice = new MaterialSkin.Controls.MaterialComboBox();
            label18 = new Label();
            btnSearch = new MaterialSkin.Controls.MaterialButton();
            txtSearch = new MaterialSkin.Controls.MaterialTextBox2();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
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
            cbxPrice.Location = new Point(632, 163);
            cbxPrice.MaxDropDownItems = 4;
            cbxPrice.MouseState = MaterialSkin.MouseState.OUT;
            cbxPrice.Name = "cbxPrice";
            cbxPrice.Size = new Size(151, 49);
            cbxPrice.StartIndex = 0;
            cbxPrice.TabIndex = 28;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Nirmala UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.LightGreen;
            label18.Location = new Point(56, 92);
            label18.Name = "label18";
            label18.Size = new Size(182, 54);
            label18.TabIndex = 27;
            label18.Text = "Find Job";
            // 
            // btnSearch
            // 
            btnSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSearch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSearch.Depth = 0;
            btnSearch.HighEmphasis = true;
            btnSearch.Icon = (Image)resources.GetObject("btnSearch.Icon");
            btnSearch.Location = new Point(821, 176);
            btnSearch.Margin = new Padding(4, 6, 4, 6);
            btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            btnSearch.Name = "btnSearch";
            btnSearch.NoAccentTextColor = Color.Empty;
            btnSearch.Size = new Size(106, 36);
            btnSearch.TabIndex = 26;
            btnSearch.Text = "search";
            btnSearch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSearch.UseAccentColor = false;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.AnimateReadOnly = false;
            txtSearch.BackgroundImageLayout = ImageLayout.None;
            txtSearch.CharacterCasing = CharacterCasing.Normal;
            txtSearch.Depth = 0;
            txtSearch.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSearch.HideSelection = true;
            txtSearch.Hint = "Search for project";
            txtSearch.LeadingIcon = null;
            txtSearch.Location = new Point(56, 163);
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
            txtSearch.TabIndex = 25;
            txtSearch.TabStop = false;
            txtSearch.TextAlign = HorizontalAlignment.Left;
            txtSearch.TrailingIcon = null;
            txtSearch.UseSystemPasswordChar = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(29, 243);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1526, 685);
            flowLayoutPanel1.TabIndex = 29;
            // 
            // FListJob
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 950);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(cbxPrice);
            Controls.Add(label18);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Name = "FListJob";
            Text = "FListJob";
            Load += FListJob_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox cbxPrice;
        private Label label18;
        private MaterialSkin.Controls.MaterialButton btnSearch;
        private MaterialSkin.Controls.MaterialTextBox2 txtSearch;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}