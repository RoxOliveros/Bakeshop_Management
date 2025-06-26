namespace Bakeshop_DesktopApp
{
    partial class AddToCart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddToCart));
            lblProductName = new Label();
            label1 = new Label();
            btnAddtoCart = new Button();
            btnAdd = new Button();
            lblQuantity = new Label();
            label7 = new Label();
            btnMinus = new Button();
            lblPrice = new Label();
            txtDescription = new TextBox();
            pictureBoxCart = new PictureBox();
            panel1 = new Panel();
            label3 = new Label();
            txtInstructions = new TextBox();
            label4 = new Label();
            label8 = new Label();
            panelVariation = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCart).BeginInit();
            SuspendLayout();
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.BackColor = Color.Transparent;
            lblProductName.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductName.ForeColor = Color.FromArgb(153, 78, 36);
            lblProductName.Location = new Point(22, 165);
            lblProductName.Margin = new Padding(4, 0, 4, 0);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(120, 28);
            lblProductName.TabIndex = 5;
            lblProductName.Text = "PRODUCT";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(153, 78, 36);
            label1.Location = new Point(22, 280);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(93, 19);
            label1.TabIndex = 17;
            label1.Text = "VARIATION";
            // 
            // btnAddtoCart
            // 
            btnAddtoCart.BackColor = Color.FromArgb(167, 103, 84);
            btnAddtoCart.FlatStyle = FlatStyle.Flat;
            btnAddtoCart.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddtoCart.ForeColor = Color.FromArgb(243, 229, 219);
            btnAddtoCart.Location = new Point(151, 533);
            btnAddtoCart.Margin = new Padding(4, 3, 4, 3);
            btnAddtoCart.Name = "btnAddtoCart";
            btnAddtoCart.Size = new Size(126, 32);
            btnAddtoCart.TabIndex = 25;
            btnAddtoCart.Text = "ADD TO CART";
            btnAddtoCart.UseVisualStyleBackColor = false;
            btnAddtoCart.Click += btnAddtoCart_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackgroundImage = Properties.Resources.plus;
            btnAdd.BackgroundImageLayout = ImageLayout.Stretch;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.FromArgb(153, 78, 36);
            btnAdd.Location = new Point(103, 538);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(30, 27);
            btnAdd.TabIndex = 58;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.BackColor = Color.Transparent;
            lblQuantity.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuantity.ForeColor = Color.FromArgb(153, 78, 36);
            lblQuantity.Location = new Point(75, 546);
            lblQuantity.Margin = new Padding(4, 0, 4, 0);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(14, 16);
            lblQuantity.TabIndex = 21;
            lblQuantity.Text = "1";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(153, 78, 36);
            label7.Location = new Point(26, 194);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(38, 17);
            label7.TabIndex = 21;
            label7.Text = "from ";
            // 
            // btnMinus
            // 
            btnMinus.BackgroundImage = Properties.Resources.minus;
            btnMinus.BackgroundImageLayout = ImageLayout.Stretch;
            btnMinus.FlatAppearance.BorderSize = 0;
            btnMinus.FlatStyle = FlatStyle.Flat;
            btnMinus.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinus.ForeColor = Color.FromArgb(153, 78, 36);
            btnMinus.Location = new Point(27, 538);
            btnMinus.Margin = new Padding(4, 3, 4, 3);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(30, 27);
            btnMinus.TabIndex = 59;
            btnMinus.UseVisualStyleBackColor = true;
            btnMinus.Click += btnMinus_Click;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.BackColor = Color.Transparent;
            lblPrice.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(153, 78, 36);
            lblPrice.Location = new Point(63, 194);
            lblPrice.Margin = new Padding(4, 0, 4, 0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(36, 17);
            lblPrice.TabIndex = 60;
            lblPrice.Text = "0.00";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.ForeColor = SystemColors.WindowText;
            txtDescription.Location = new Point(27, 223);
            txtDescription.Margin = new Padding(4, 3, 4, 3);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "description";
            txtDescription.ReadOnly = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(260, 43);
            txtDescription.TabIndex = 62;
            // 
            // pictureBoxCart
            // 
            pictureBoxCart.Location = new Point(27, 12);
            pictureBoxCart.Name = "pictureBoxCart";
            pictureBoxCart.Size = new Size(260, 136);
            pictureBoxCart.TabIndex = 63;
            pictureBoxCart.TabStop = false;
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 571);
            panel1.Name = "panel1";
            panel1.Size = new Size(303, 15);
            panel1.TabIndex = 64;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(153, 78, 36);
            label3.Location = new Point(27, 299);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(64, 16);
            label3.TabIndex = 65;
            label3.Text = "Select one";
            // 
            // txtInstructions
            // 
            txtInstructions.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtInstructions.ForeColor = SystemColors.WindowText;
            txtInstructions.Location = new Point(27, 474);
            txtInstructions.Margin = new Padding(4, 3, 4, 3);
            txtInstructions.Multiline = true;
            txtInstructions.Name = "txtInstructions";
            txtInstructions.PlaceholderText = "e.g no cream";
            txtInstructions.ScrollBars = ScrollBars.Vertical;
            txtInstructions.Size = new Size(260, 43);
            txtInstructions.TabIndex = 66;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Century Gothic", 8F);
            label4.ForeColor = Color.FromArgb(153, 78, 36);
            label4.Location = new Point(27, 440);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(269, 31);
            label4.TabIndex = 68;
            label4.Text = "please let us know if you are allergic to anything \r\nor if we need to avoid anything";
            label4.UseCompatibleTextRendering = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(153, 78, 36);
            label8.Location = new Point(22, 419);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(115, 19);
            label8.TabIndex = 67;
            label8.Text = "INSTRUCTIONS";
            // 
            // panelVariation
            // 
            panelVariation.AutoScroll = true;
            panelVariation.BackColor = SystemColors.Control;
            panelVariation.FlowDirection = FlowDirection.TopDown;
            panelVariation.Location = new Point(26, 318);
            panelVariation.Name = "panelVariation";
            panelVariation.Size = new Size(261, 89);
            panelVariation.TabIndex = 69;
            panelVariation.WrapContents = false;
            // 
            // AddToCart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(243, 229, 219);
            ClientSize = new Size(307, 300);
            Controls.Add(panelVariation);
            Controls.Add(label4);
            Controls.Add(label8);
            Controls.Add(txtInstructions);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(pictureBoxCart);
            Controls.Add(lblProductName);
            Controls.Add(txtDescription);
            Controls.Add(label7);
            Controls.Add(label1);
            Controls.Add(lblPrice);
            Controls.Add(btnMinus);
            Controls.Add(lblQuantity);
            Controls.Add(btnAdd);
            Controls.Add(btnAddtoCart);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "AddToCart";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddToCart";
            Load += AddToCart_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProductName;
        private Label label1;
        private Button btnAddtoCart;
        private Button btnAdd;
        private Label lblQuantity;
        private Label label7;
        private Button btnMinus;
        private Label lblPrice;
        private TextBox txtDescription;
        private PictureBox pictureBoxCart;
        private Panel panel1;
        private Label label3;
        private TextBox txtInstructions;
        private Label label4;
        private Label label8;
        private FlowLayoutPanel panelVariation;
    }
}