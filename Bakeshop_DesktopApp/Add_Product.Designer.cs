namespace Bakeshop_DesktopApp
{
    partial class Add_Product
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Product));
            lblUsername = new Label();
            productImageBox = new PictureBox();
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            cmbCategory = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtOption2 = new TextBox();
            txtOption3 = new TextBox();
            txtOption4 = new TextBox();
            txtPrice4 = new TextBox();
            txtPrice3 = new TextBox();
            txtPrice2 = new TextBox();
            txtOption1 = new TextBox();
            label6 = new Label();
            lblWordCount = new Label();
            btnSave = new Button();
            txtDescription = new TextBox();
            txtPrice1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)productImageBox).BeginInit();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.FromArgb(153, 78, 36);
            lblUsername.Location = new Point(199, 9);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(120, 28);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "PRODUCT";
            // 
            // productImageBox
            // 
            productImageBox.BackColor = Color.FromArgb(167, 103, 84);
            productImageBox.BackgroundImage = Properties.Resources.image;
            productImageBox.BackgroundImageLayout = ImageLayout.Stretch;
            productImageBox.InitialImage = Properties.Resources.images1;
            productImageBox.Location = new Point(38, 61);
            productImageBox.Name = "productImageBox";
            productImageBox.Size = new Size(149, 142);
            productImageBox.TabIndex = 5;
            productImageBox.TabStop = false;
            productImageBox.WaitOnLoad = true;
            productImageBox.Click += productImageBox_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(153, 78, 36);
            label1.Location = new Point(213, 80);
            label1.Name = "label1";
            label1.Size = new Size(50, 16);
            label1.TabIndex = 7;
            label1.Text = "Name:";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(247, 183, 147);
            txtName.BorderStyle = BorderStyle.None;
            txtName.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtName.ForeColor = Color.Gray;
            txtName.Location = new Point(213, 99);
            txtName.Multiline = true;
            txtName.Name = "txtName";
            txtName.Size = new Size(257, 26);
            txtName.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(153, 78, 36);
            label2.Location = new Point(213, 142);
            label2.Name = "label2";
            label2.Size = new Size(82, 16);
            label2.TabIndex = 8;
            label2.Text = "Categories:";
            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = Color.FromArgb(247, 183, 147);
            cmbCategory.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "🍰 Cake", "🍞 Bread", "\U0001f967 Pastry", "🍪 Cookie", "\U0001f964 Coffee" });
            cmbCategory.Location = new Point(213, 161);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(209, 25);
            cmbCategory.TabIndex = 9;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(153, 78, 36);
            label3.Location = new Point(39, 216);
            label3.Name = "label3";
            label3.Size = new Size(0, 16);
            label3.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(153, 78, 36);
            label4.Location = new Point(35, 224);
            label4.Name = "label4";
            label4.Size = new Size(71, 16);
            label4.TabIndex = 11;
            label4.Text = "Variation:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(153, 78, 36);
            label5.Location = new Point(135, 224);
            label5.Name = "label5";
            label5.Size = new Size(43, 16);
            label5.TabIndex = 12;
            label5.Text = "Price:";
            // 
            // txtOption2
            // 
            txtOption2.BackColor = Color.FromArgb(246, 218, 196);
            txtOption2.BorderStyle = BorderStyle.FixedSingle;
            txtOption2.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtOption2.ForeColor = Color.FromArgb(64, 64, 64);
            txtOption2.Location = new Point(35, 276);
            txtOption2.Multiline = true;
            txtOption2.Name = "txtOption2";
            txtOption2.Size = new Size(81, 27);
            txtOption2.TabIndex = 14;
            // 
            // txtOption3
            // 
            txtOption3.BackColor = Color.FromArgb(246, 218, 196);
            txtOption3.BorderStyle = BorderStyle.FixedSingle;
            txtOption3.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtOption3.ForeColor = Color.FromArgb(64, 64, 64);
            txtOption3.Location = new Point(35, 309);
            txtOption3.Multiline = true;
            txtOption3.Name = "txtOption3";
            txtOption3.Size = new Size(81, 27);
            txtOption3.TabIndex = 15;
            // 
            // txtOption4
            // 
            txtOption4.BackColor = Color.FromArgb(246, 218, 196);
            txtOption4.BorderStyle = BorderStyle.FixedSingle;
            txtOption4.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtOption4.ForeColor = Color.FromArgb(64, 64, 64);
            txtOption4.Location = new Point(35, 342);
            txtOption4.Multiline = true;
            txtOption4.Name = "txtOption4";
            txtOption4.Size = new Size(81, 27);
            txtOption4.TabIndex = 16;
            // 
            // txtPrice4
            // 
            txtPrice4.BackColor = Color.FromArgb(247, 183, 147);
            txtPrice4.BorderStyle = BorderStyle.FixedSingle;
            txtPrice4.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            txtPrice4.ForeColor = Color.FromArgb(64, 64, 64);
            txtPrice4.Location = new Point(135, 342);
            txtPrice4.Multiline = true;
            txtPrice4.Name = "txtPrice4";
            txtPrice4.Size = new Size(67, 27);
            txtPrice4.TabIndex = 20;
            // 
            // txtPrice3
            // 
            txtPrice3.BackColor = Color.FromArgb(247, 183, 147);
            txtPrice3.BorderStyle = BorderStyle.FixedSingle;
            txtPrice3.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            txtPrice3.ForeColor = Color.FromArgb(64, 64, 64);
            txtPrice3.Location = new Point(135, 309);
            txtPrice3.Multiline = true;
            txtPrice3.Name = "txtPrice3";
            txtPrice3.Size = new Size(67, 27);
            txtPrice3.TabIndex = 19;
            // 
            // txtPrice2
            // 
            txtPrice2.BackColor = Color.FromArgb(247, 183, 147);
            txtPrice2.BorderStyle = BorderStyle.FixedSingle;
            txtPrice2.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            txtPrice2.ForeColor = Color.FromArgb(64, 64, 64);
            txtPrice2.Location = new Point(135, 276);
            txtPrice2.Multiline = true;
            txtPrice2.Name = "txtPrice2";
            txtPrice2.Size = new Size(67, 27);
            txtPrice2.TabIndex = 18;
            // 
            // txtOption1
            // 
            txtOption1.BackColor = Color.FromArgb(246, 218, 196);
            txtOption1.BorderStyle = BorderStyle.FixedSingle;
            txtOption1.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtOption1.ForeColor = Color.FromArgb(64, 64, 64);
            txtOption1.Location = new Point(35, 243);
            txtOption1.Multiline = true;
            txtOption1.Name = "txtOption1";
            txtOption1.Size = new Size(81, 27);
            txtOption1.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(153, 78, 36);
            label6.Location = new Point(235, 224);
            label6.Name = "label6";
            label6.Size = new Size(84, 16);
            label6.TabIndex = 22;
            label6.Text = "Description:";
            // 
            // lblWordCount
            // 
            lblWordCount.AutoSize = true;
            lblWordCount.BackColor = Color.Transparent;
            lblWordCount.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWordCount.ForeColor = Color.FromArgb(175, 121, 114);
            lblWordCount.Location = new Point(235, 366);
            lblWordCount.Name = "lblWordCount";
            lblWordCount.Size = new Size(0, 15);
            lblWordCount.TabIndex = 23;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(167, 103, 84);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.FromArgb(243, 229, 219);
            btnSave.Location = new Point(395, 392);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 30);
            btnSave.TabIndex = 24;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtDescription
            // 
            txtDescription.BackColor = Color.FromArgb(246, 218, 196);
            txtDescription.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDescription.ForeColor = Color.FromArgb(64, 64, 64);
            txtDescription.Location = new Point(235, 243);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(235, 120);
            txtDescription.TabIndex = 21;
            txtDescription.TextChanged += txtDescription_TextChanged;
            // 
            // txtPrice1
            // 
            txtPrice1.BackColor = Color.FromArgb(247, 183, 147);
            txtPrice1.BorderStyle = BorderStyle.FixedSingle;
            txtPrice1.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            txtPrice1.ForeColor = Color.FromArgb(64, 64, 64);
            txtPrice1.Location = new Point(135, 243);
            txtPrice1.Multiline = true;
            txtPrice1.Name = "txtPrice1";
            txtPrice1.Size = new Size(67, 27);
            txtPrice1.TabIndex = 17;
            // 
            // Add_Product
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 229, 219);
            ClientSize = new Size(504, 447);
            Controls.Add(btnSave);
            Controls.Add(lblWordCount);
            Controls.Add(label6);
            Controls.Add(txtDescription);
            Controls.Add(txtPrice4);
            Controls.Add(txtPrice3);
            Controls.Add(txtPrice2);
            Controls.Add(txtPrice1);
            Controls.Add(txtOption4);
            Controls.Add(txtOption3);
            Controls.Add(txtOption2);
            Controls.Add(txtOption1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cmbCategory);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(productImageBox);
            Controls.Add(lblUsername);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Add_Product";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Product";
            Load += Add_Product_Load;
            ((System.ComponentModel.ISupportInitialize)productImageBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private PictureBox productImageBox;
        private Label label1;
        private TextBox txtName;
        private Label label2;
        private ComboBox cmbCategory;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtOption2;
        private TextBox txtOption3;
        private TextBox txtOption4;
        private TextBox txtPrice4;
        private TextBox txtPrice3;
        private TextBox txtPrice2;
        private TextBox txtOption1;
        private Label label6;
        private Label lblWordCount;
        private Button btnSave;
        private TextBox txtDescription;
        private TextBox txtPrice1;
    }
}