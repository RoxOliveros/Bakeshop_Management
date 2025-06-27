namespace Bakeshop_DesktopApp
{
    partial class Admin_Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_Menu));
            label1 = new Label();
            txtSearchAdmin = new TextBox();
            btnSearch = new Button();
            btnCake = new Button();
            btnBread = new Button();
            btnPastry = new Button();
            btnCoffee = new Button();
            btnAll = new Button();
            btnAdd = new Button();
            flowLayoutPanelAdmin = new FlowLayoutPanel();
            btnCookie = new Button();
            btnLoad = new Button();
            btnSales = new Button();
            btnOrder = new Button();
            button1 = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(153, 78, 36);
            label1.Location = new Point(28, 147);
            label1.Name = "label1";
            label1.Size = new Size(103, 19);
            label1.TabIndex = 19;
            label1.Text = "CATEGORIES";
            // 
            // txtSearchAdmin
            // 
            txtSearchAdmin.BackColor = Color.FromArgb(255, 212, 181);
            txtSearchAdmin.BorderStyle = BorderStyle.None;
            txtSearchAdmin.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSearchAdmin.ForeColor = Color.FromArgb(64, 64, 64);
            txtSearchAdmin.Location = new Point(543, 93);
            txtSearchAdmin.Multiline = true;
            txtSearchAdmin.Name = "txtSearchAdmin";
            txtSearchAdmin.PlaceholderText = "  Search product name";
            txtSearchAdmin.Size = new Size(285, 28);
            txtSearchAdmin.TabIndex = 22;
            txtSearchAdmin.TextChanged += txtSearchAdmin_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImage = Properties.Resources.search1;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Location = new Point(795, 93);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(33, 28);
            btnSearch.TabIndex = 23;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click_1;
            // 
            // btnCake
            // 
            btnCake.BackColor = Color.FromArgb(254, 218, 188);
            btnCake.FlatStyle = FlatStyle.Flat;
            btnCake.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCake.ForeColor = Color.FromArgb(167, 103, 84);
            btnCake.Location = new Point(192, 182);
            btnCake.Name = "btnCake";
            btnCake.Size = new Size(95, 28);
            btnCake.TabIndex = 24;
            btnCake.Text = "🍰 Cakes";
            btnCake.UseVisualStyleBackColor = false;
            btnCake.Click += btnCake_Click;
            // 
            // btnBread
            // 
            btnBread.BackColor = Color.FromArgb(254, 218, 188);
            btnBread.FlatStyle = FlatStyle.Flat;
            btnBread.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBread.ForeColor = Color.FromArgb(167, 103, 84);
            btnBread.Location = new Point(327, 182);
            btnBread.Name = "btnBread";
            btnBread.Size = new Size(95, 28);
            btnBread.TabIndex = 25;
            btnBread.Text = "🍞 Bread";
            btnBread.UseVisualStyleBackColor = false;
            btnBread.Click += btnBread_Click;
            // 
            // btnPastry
            // 
            btnPastry.BackColor = Color.FromArgb(254, 218, 188);
            btnPastry.FlatStyle = FlatStyle.Flat;
            btnPastry.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPastry.ForeColor = Color.FromArgb(167, 103, 84);
            btnPastry.Location = new Point(462, 182);
            btnPastry.Name = "btnPastry";
            btnPastry.Size = new Size(95, 28);
            btnPastry.TabIndex = 26;
            btnPastry.Text = "\U0001f967 Pastry";
            btnPastry.UseVisualStyleBackColor = false;
            btnPastry.Click += btnPastry_Click;
            // 
            // btnCoffee
            // 
            btnCoffee.BackColor = Color.FromArgb(254, 218, 188);
            btnCoffee.FlatStyle = FlatStyle.Flat;
            btnCoffee.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCoffee.ForeColor = Color.FromArgb(167, 103, 84);
            btnCoffee.Location = new Point(732, 182);
            btnCoffee.Name = "btnCoffee";
            btnCoffee.Size = new Size(95, 28);
            btnCoffee.TabIndex = 27;
            btnCoffee.Text = "\U0001f964 Beverage";
            btnCoffee.UseVisualStyleBackColor = false;
            btnCoffee.Click += btnCoffee_Click;
            // 
            // btnAll
            // 
            btnAll.BackColor = Color.FromArgb(254, 218, 188);
            btnAll.FlatStyle = FlatStyle.Flat;
            btnAll.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAll.ForeColor = Color.FromArgb(167, 103, 84);
            btnAll.Location = new Point(57, 182);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(95, 28);
            btnAll.TabIndex = 28;
            btnAll.Text = "🍪 All";
            btnAll.UseVisualStyleBackColor = false;
            btnAll.Click += btnAll_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(167, 103, 84);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.FromArgb(243, 229, 219);
            btnAdd.Location = new Point(782, 481);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(64, 30);
            btnAdd.TabIndex = 34;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // flowLayoutPanelAdmin
            // 
            flowLayoutPanelAdmin.AutoScroll = true;
            flowLayoutPanelAdmin.BackColor = Color.FromArgb(255, 241, 236);
            flowLayoutPanelAdmin.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelAdmin.Location = new Point(28, 228);
            flowLayoutPanelAdmin.Name = "flowLayoutPanelAdmin";
            flowLayoutPanelAdmin.Size = new Size(840, 238);
            flowLayoutPanelAdmin.TabIndex = 0;
            // 
            // btnCookie
            // 
            btnCookie.BackColor = Color.FromArgb(254, 218, 188);
            btnCookie.FlatStyle = FlatStyle.Flat;
            btnCookie.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCookie.ForeColor = Color.FromArgb(167, 103, 84);
            btnCookie.Location = new Point(597, 182);
            btnCookie.Name = "btnCookie";
            btnCookie.Size = new Size(95, 28);
            btnCookie.TabIndex = 39;
            btnCookie.Text = "\U0001f964 Cookie";
            btnCookie.UseVisualStyleBackColor = false;
            btnCookie.Click += btnCookie_Click;
            // 
            // btnLoad
            // 
            btnLoad.BackgroundImage = Properties.Resources.load;
            btnLoad.BackgroundImageLayout = ImageLayout.Stretch;
            btnLoad.FlatAppearance.BorderSize = 0;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoad.ForeColor = Color.FromArgb(153, 78, 36);
            btnLoad.Location = new Point(834, 93);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(34, 28);
            btnLoad.TabIndex = 44;
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
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
            btnSales.Text = "✦ SALES";
            btnSales.UseVisualStyleBackColor = false;
            btnSales.Click += btnSales_Click;
            // 
            // btnOrder
            // 
            btnOrder.BackColor = Color.FromArgb(255, 241, 236);
            btnOrder.FlatAppearance.BorderSize = 0;
            btnOrder.FlatStyle = FlatStyle.Flat;
            btnOrder.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOrder.ForeColor = Color.FromArgb(153, 78, 36);
            btnOrder.Location = new Point(142, 61);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(85, 23);
            btnOrder.TabIndex = 60;
            btnOrder.Text = "📄 ORDER";
            btnOrder.UseVisualStyleBackColor = false;
            btnOrder.Click += btnOrder_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(243, 229, 219);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(153, 78, 36);
            button1.Location = new Point(28, 61);
            button1.Name = "button1";
            button1.Size = new Size(85, 23);
            button1.TabIndex = 59;
            button1.Text = "☰  MENU";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Transparent;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.FromArgb(167, 103, 84);
            btnLogout.Location = new Point(6, 493);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(41, 39);
            btnLogout.TabIndex = 62;
            btnLogout.Text = "↩";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click_1;
            // 
            // Admin_Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 183, 147);
            BackgroundImage = Properties.Resources.bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(899, 532);
            Controls.Add(btnLogout);
            Controls.Add(btnSales);
            Controls.Add(btnOrder);
            Controls.Add(button1);
            Controls.Add(btnLoad);
            Controls.Add(btnCookie);
            Controls.Add(flowLayoutPanelAdmin);
            Controls.Add(btnAdd);
            Controls.Add(btnAll);
            Controls.Add(btnCoffee);
            Controls.Add(btnPastry);
            Controls.Add(btnBread);
            Controls.Add(btnCake);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchAdmin);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Admin_Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cozy Crust";
            Load += Admin_Menu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox txtSearchAdmin;
        private Button btnSearch;
        private Button btnCake;
        private Button btnBread;
        private Button btnPastry;
        private Button btnCoffee;
        private Button btnAll;
        private Button btnAdd;
        private FlowLayoutPanel flowLayoutPanelAdmin;
        private Button btnCookie;
        private Button btnLoad;
        private Button btnSales;
        private Button btnOrder;
        private Button button1;
        private Button btnLogout;
    }
}