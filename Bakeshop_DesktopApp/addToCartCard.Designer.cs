namespace Bakeshop_DesktopApp
{
    partial class addToCartCard
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
            btnCart = new Button();
            lblPrice = new Label();
            lblName = new Label();
            pictureBox = new PictureBox();
            btnUnheart = new Button();
            btnHeart = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // btnCart
            // 
            btnCart.BackgroundImage = Properties.Resources.cart1;
            btnCart.BackgroundImageLayout = ImageLayout.Stretch;
            btnCart.FlatAppearance.BorderSize = 0;
            btnCart.FlatStyle = FlatStyle.Flat;
            btnCart.Location = new Point(108, 157);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(32, 30);
            btnCart.TabIndex = 10;
            btnCart.UseVisualStyleBackColor = true;
            btnCart.Click += btnCart_Click;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Microsoft Sans Serif", 9F);
            lblPrice.ForeColor = Color.FromArgb(167, 103, 84);
            lblPrice.Location = new Point(13, 137);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(35, 15);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "Price";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.FromArgb(167, 103, 84);
            lblName.Location = new Point(13, 121);
            lblName.Name = "lblName";
            lblName.Size = new Size(43, 16);
            lblName.TabIndex = 7;
            lblName.Text = "Name";
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(13, 11);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(127, 107);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 6;
            pictureBox.TabStop = false;
            pictureBox.Click += pictureBox_Click;
            // 
            // btnUnheart
            // 
            btnUnheart.BackgroundImage = Properties.Resources._8;
            btnUnheart.BackgroundImageLayout = ImageLayout.Stretch;
            btnUnheart.FlatAppearance.BorderSize = 0;
            btnUnheart.FlatStyle = FlatStyle.Flat;
            btnUnheart.Location = new Point(70, 157);
            btnUnheart.Name = "btnUnheart";
            btnUnheart.Size = new Size(32, 30);
            btnUnheart.TabIndex = 11;
            btnUnheart.UseVisualStyleBackColor = true;
            btnUnheart.Click += btnUnheart_Click;
            // 
            // btnHeart
            // 
            btnHeart.BackgroundImage = Properties.Resources.heart;
            btnHeart.BackgroundImageLayout = ImageLayout.Stretch;
            btnHeart.FlatAppearance.BorderSize = 0;
            btnHeart.FlatStyle = FlatStyle.Flat;
            btnHeart.Location = new Point(70, 157);
            btnHeart.Name = "btnHeart";
            btnHeart.Size = new Size(32, 30);
            btnHeart.TabIndex = 12;
            btnHeart.UseVisualStyleBackColor = true;
            btnHeart.Visible = false;
            btnHeart.Click += btnHeart_Click;
            // 
            // addToCartCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 229, 219);
            Controls.Add(btnHeart);
            Controls.Add(btnUnheart);
            Controls.Add(btnCart);
            Controls.Add(lblPrice);
            Controls.Add(lblName);
            Controls.Add(pictureBox);
            Name = "addToCartCard";
            Size = new Size(152, 196);
            Load += addToCartCard_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCart;
        private Label lblPrice;
        private Label lblName;
        private PictureBox pictureBox;
        private Button btnUnheart;
        private Button btnHeart;
    }
}
