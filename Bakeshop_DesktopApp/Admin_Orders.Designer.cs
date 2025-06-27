namespace Bakeshop_DesktopApp
{
    partial class Admin_Orders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_Orders));
            btnSales = new Button();
            button2 = new Button();
            btnMenu = new Button();
            flowLayoutOrders = new FlowLayoutPanel();
            label1 = new Label();
            cmbSortOrders = new ComboBox();
            SuspendLayout();
            // 
            // btnSales
            // 
            btnSales.BackColor = Color.FromArgb(255, 241, 236);
            btnSales.FlatAppearance.BorderSize = 0;
            btnSales.FlatStyle = FlatStyle.Flat;
            btnSales.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSales.ForeColor = Color.FromArgb(153, 78, 36);
            btnSales.Location = new Point(260, 61);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(85, 23);
            btnSales.TabIndex = 61;
            btnSales.Text = "📈 SALES";
            btnSales.UseVisualStyleBackColor = false;
            btnSales.Click += btnSales_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(243, 229, 219);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(153, 78, 36);
            button2.Location = new Point(142, 61);
            button2.Name = "button2";
            button2.Size = new Size(85, 23);
            button2.TabIndex = 60;
            button2.Text = "📄 ORDER";
            button2.UseVisualStyleBackColor = false;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.FromArgb(255, 241, 236);
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu.ForeColor = Color.FromArgb(153, 78, 36);
            btnMenu.Location = new Point(28, 61);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(85, 23);
            btnMenu.TabIndex = 59;
            btnMenu.Text = "☰  MENU";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // flowLayoutOrders
            // 
            flowLayoutOrders.AutoScroll = true;
            flowLayoutOrders.BackColor = Color.FromArgb(246, 218, 196);
            flowLayoutOrders.FlowDirection = FlowDirection.TopDown;
            flowLayoutOrders.Location = new Point(31, 162);
            flowLayoutOrders.Name = "flowLayoutOrders";
            flowLayoutOrders.Size = new Size(835, 321);
            flowLayoutOrders.TabIndex = 62;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(153, 78, 36);
            label1.Location = new Point(31, 121);
            label1.Name = "label1";
            label1.Size = new Size(117, 28);
            label1.TabIndex = 20;
            label1.Text = "PENDING";
            // 
            // cmbSortOrders
            // 
            cmbSortOrders.BackColor = Color.FromArgb(243, 229, 219);
            cmbSortOrders.FlatStyle = FlatStyle.Flat;
            cmbSortOrders.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSortOrders.ForeColor = Color.FromArgb(153, 78, 36);
            cmbSortOrders.FormattingEnabled = true;
            cmbSortOrders.Items.AddRange(new object[] { "Newest First", "Oldest First", "Total Amount (High to Low)", "Total Amount (Low to High)" });
            cmbSortOrders.Location = new Point(740, 129);
            cmbSortOrders.Name = "cmbSortOrders";
            cmbSortOrders.Size = new Size(126, 24);
            cmbSortOrders.TabIndex = 63;
            cmbSortOrders.Text = "Sort  by";
            cmbSortOrders.SelectedIndexChanged += cmbSortOrders_SelectedIndexChanged;
            // 
            // Admin_Orders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(899, 532);
            Controls.Add(cmbSortOrders);
            Controls.Add(label1);
            Controls.Add(flowLayoutOrders);
            Controls.Add(btnSales);
            Controls.Add(button2);
            Controls.Add(btnMenu);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Admin_Orders";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Dashboard";
            Load += Admin_Orders_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSales;
        private Button button2;
        private Button btnMenu;
        private FlowLayoutPanel flowLayoutOrders;
        private Label label1;
        private ComboBox cmbSortOrders;
    }
}