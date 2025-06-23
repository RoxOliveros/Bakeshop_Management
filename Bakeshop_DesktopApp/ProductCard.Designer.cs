namespace Bakeshop_DesktopApp
{
    partial class ProductCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            lblName = new Label();
            lblPrice = new Label();
            details = new Label();
            btnDelete = new Button();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(12, 14);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(127, 107);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.FromArgb(167, 103, 84);
            lblName.Location = new Point(12, 124);
            lblName.Name = "lblName";
            lblName.Size = new Size(43, 16);
            lblName.TabIndex = 1;
            lblName.Text = "Name";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Microsoft Sans Serif", 9F);
            lblPrice.ForeColor = Color.FromArgb(167, 103, 84);
            lblPrice.Location = new Point(12, 140);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(35, 15);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "Price";
            // 
            // details
            // 
            details.AutoSize = true;
            details.Font = new Font("Microsoft Sans Serif", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            details.ForeColor = Color.FromArgb(247, 183, 147);
            details.Location = new Point(84, 143);
            details.Name = "details";
            details.Size = new Size(45, 12);
            details.TabIndex = 3;
            details.Text = "DETAIL +";
            // 
            // btnDelete
            // 
            btnDelete.BackgroundImage = Properties.Resources.delete;
            btnDelete.BackgroundImageLayout = ImageLayout.Stretch;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(113, 165);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(26, 24);
            btnDelete.TabIndex = 4;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackgroundImage = Properties.Resources.update;
            btnUpdate.BackgroundImageLayout = ImageLayout.Stretch;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(81, 165);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(26, 24);
            btnUpdate.TabIndex = 5;
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // ProductCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 235, 219);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(details);
            Controls.Add(lblPrice);
            Controls.Add(lblName);
            Controls.Add(pictureBox);
            Name = "ProductCard";
            Size = new Size(152, 196);
            Load += ProductCard_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Label lblName;
        private Label lblPrice;
        private Label details;
        private Button btnDelete;
        private Button btnUpdate;
    }
}
