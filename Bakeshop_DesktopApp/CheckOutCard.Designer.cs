namespace Bakeshop_DesktopApp
{
    partial class CheckOutCard
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
            picCart = new PictureBox();
            lblProduct = new Label();
            lblVariation = new Label();
            lblTotalPrice = new Label();
            btnAdd = new Button();
            btnMinus = new Button();
            lblQuantity = new Label();
            ((System.ComponentModel.ISupportInitialize)picCart).BeginInit();
            SuspendLayout();
            // 
            // picCart
            // 
            picCart.Location = new Point(11, 10);
            picCart.Name = "picCart";
            picCart.Size = new Size(31, 30);
            picCart.TabIndex = 0;
            picCart.TabStop = false;
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.BackColor = Color.Transparent;
            lblProduct.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProduct.ForeColor = Color.FromArgb(153, 78, 36);
            lblProduct.Location = new Point(48, 8);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(42, 16);
            lblProduct.TabIndex = 47;
            lblProduct.Text = "NAME";
            // 
            // lblVariation
            // 
            lblVariation.AutoSize = true;
            lblVariation.BackColor = Color.Transparent;
            lblVariation.Font = new Font("Century Gothic", 7F);
            lblVariation.ForeColor = Color.FromArgb(153, 78, 36);
            lblVariation.Location = new Point(49, 25);
            lblVariation.Name = "lblVariation";
            lblVariation.Size = new Size(61, 15);
            lblVariation.TabIndex = 49;
            lblVariation.Text = "VARIATION";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.BackColor = Color.Transparent;
            lblTotalPrice.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPrice.ForeColor = Color.FromArgb(153, 78, 36);
            lblTotalPrice.Location = new Point(207, 28);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(32, 16);
            lblTotalPrice.TabIndex = 50;
            lblTotalPrice.Text = "0.00";
            // 
            // btnAdd
            // 
            btnAdd.BackgroundImage = Properties.Resources.add;
            btnAdd.BackgroundImageLayout = ImageLayout.Stretch;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.FromArgb(153, 78, 36);
            btnAdd.Location = new Point(172, 25);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(20, 19);
            btnAdd.TabIndex = 59;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnMinus
            // 
            btnMinus.BackgroundImage = Properties.Resources.minus2;
            btnMinus.BackgroundImageLayout = ImageLayout.Stretch;
            btnMinus.FlatAppearance.BorderSize = 0;
            btnMinus.FlatStyle = FlatStyle.Flat;
            btnMinus.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinus.ForeColor = Color.FromArgb(153, 78, 36);
            btnMinus.Location = new Point(125, 25);
            btnMinus.Margin = new Padding(4, 3, 4, 3);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(20, 19);
            btnMinus.TabIndex = 60;
            btnMinus.UseVisualStyleBackColor = true;
            btnMinus.Click += btnMinus_Click;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.BackColor = Color.Transparent;
            lblQuantity.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuantity.ForeColor = Color.FromArgb(153, 78, 36);
            lblQuantity.Location = new Point(152, 27);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(13, 15);
            lblQuantity.TabIndex = 61;
            lblQuantity.Text = "0";
            // 
            // CheckOutCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 252, 252);
            Controls.Add(lblQuantity);
            Controls.Add(btnMinus);
            Controls.Add(btnAdd);
            Controls.Add(lblTotalPrice);
            Controls.Add(lblVariation);
            Controls.Add(lblProduct);
            Controls.Add(picCart);
            Name = "CheckOutCard";
            Size = new Size(270, 52);
            ((System.ComponentModel.ISupportInitialize)picCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picCart;
        private Label lblProduct;
        private Label lblVariation;
        private Label lblTotalPrice;
        private Button btnAdd;
        private Button btnMinus;
        private Label lblQuantity;
    }
}
