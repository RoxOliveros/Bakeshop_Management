namespace Bakeshop_DesktopApp
{
    partial class User_Menu
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
            btnLoad = new Button();
            btnCookie = new Button();
            flowLayoutPanelUser = new FlowLayoutPanel();
            btnAll = new Button();
            btnCoffee = new Button();
            btnPastry = new Button();
            btnBread = new Button();
            btnCake = new Button();
            btnSearch = new Button();
            txtSearchUser = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            panel1 = new Panel();
            btnCheckout = new Button();
            lblTotalAmount = new Label();
            label4 = new Label();
            label3 = new Label();
            flowLayoutCheckout = new FlowLayoutPanel();
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.BackgroundImage = Properties.Resources.load;
            btnLoad.BackgroundImageLayout = ImageLayout.Stretch;
            btnLoad.FlatAppearance.BorderSize = 0;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoad.ForeColor = Color.FromArgb(153, 78, 36);
            btnLoad.Location = new Point(665, 99);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(34, 28);
            btnLoad.TabIndex = 55;
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnCookie
            // 
            btnCookie.BackColor = Color.FromArgb(254, 218, 188);
            btnCookie.FlatStyle = FlatStyle.Flat;
            btnCookie.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);
            btnCookie.ForeColor = Color.FromArgb(167, 103, 84);
            btnCookie.Location = new Point(489, 178);
            btnCookie.Name = "btnCookie";
            btnCookie.Size = new Size(85, 28);
            btnCookie.TabIndex = 54;
            btnCookie.Text = "\U0001f964 Cookie";
            btnCookie.UseVisualStyleBackColor = false;
            btnCookie.Click += btnCookie_Click;
            // 
            // flowLayoutPanelUser
            // 
            flowLayoutPanelUser.AutoScroll = true;
            flowLayoutPanelUser.BackColor = Color.FromArgb(255, 241, 236);
            flowLayoutPanelUser.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelUser.Location = new Point(24, 224);
            flowLayoutPanelUser.Name = "flowLayoutPanelUser";
            flowLayoutPanelUser.Size = new Size(675, 238);
            flowLayoutPanelUser.TabIndex = 45;
            // 
            // btnAll
            // 
            btnAll.BackColor = Color.FromArgb(254, 218, 188);
            btnAll.FlatStyle = FlatStyle.Flat;
            btnAll.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);
            btnAll.ForeColor = Color.FromArgb(167, 103, 84);
            btnAll.Location = new Point(42, 178);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(85, 28);
            btnAll.TabIndex = 53;
            btnAll.Text = "🍪 All";
            btnAll.UseVisualStyleBackColor = false;
            btnAll.Click += btnAll_Click;
            // 
            // btnCoffee
            // 
            btnCoffee.BackColor = Color.FromArgb(254, 218, 188);
            btnCoffee.FlatStyle = FlatStyle.Flat;
            btnCoffee.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);
            btnCoffee.ForeColor = Color.FromArgb(167, 103, 84);
            btnCoffee.Location = new Point(596, 178);
            btnCoffee.Name = "btnCoffee";
            btnCoffee.Size = new Size(85, 28);
            btnCoffee.TabIndex = 52;
            btnCoffee.Text = "\U0001f964 Coffee";
            btnCoffee.UseVisualStyleBackColor = false;
            btnCoffee.Click += btnCoffee_Click;
            // 
            // btnPastry
            // 
            btnPastry.BackColor = Color.FromArgb(254, 218, 188);
            btnPastry.FlatStyle = FlatStyle.Flat;
            btnPastry.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);
            btnPastry.ForeColor = Color.FromArgb(167, 103, 84);
            btnPastry.Location = new Point(380, 178);
            btnPastry.Name = "btnPastry";
            btnPastry.Size = new Size(85, 28);
            btnPastry.TabIndex = 51;
            btnPastry.Text = "\U0001f967 Pastry";
            btnPastry.UseVisualStyleBackColor = false;
            btnPastry.Click += btnPastry_Click;
            // 
            // btnBread
            // 
            btnBread.BackColor = Color.FromArgb(254, 218, 188);
            btnBread.FlatStyle = FlatStyle.Flat;
            btnBread.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);
            btnBread.ForeColor = Color.FromArgb(167, 103, 84);
            btnBread.Location = new Point(271, 178);
            btnBread.Name = "btnBread";
            btnBread.Size = new Size(85, 28);
            btnBread.TabIndex = 50;
            btnBread.Text = "🍞 Bread";
            btnBread.UseVisualStyleBackColor = false;
            btnBread.Click += btnBread_Click;
            // 
            // btnCake
            // 
            btnCake.BackColor = Color.FromArgb(254, 218, 188);
            btnCake.FlatStyle = FlatStyle.Flat;
            btnCake.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);
            btnCake.ForeColor = Color.FromArgb(167, 103, 84);
            btnCake.Location = new Point(157, 178);
            btnCake.Name = "btnCake";
            btnCake.Size = new Size(85, 28);
            btnCake.TabIndex = 49;
            btnCake.Text = "🍰 Cakes";
            btnCake.UseVisualStyleBackColor = false;
            btnCake.Click += btnCake_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImage = Properties.Resources.search1;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Location = new Point(626, 99);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(33, 28);
            btnSearch.TabIndex = 48;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click_1;
            // 
            // txtSearchUser
            // 
            txtSearchUser.BackColor = Color.FromArgb(255, 212, 181);
            txtSearchUser.BorderStyle = BorderStyle.None;
            txtSearchUser.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSearchUser.ForeColor = Color.FromArgb(64, 64, 64);
            txtSearchUser.Location = new Point(408, 99);
            txtSearchUser.Multiline = true;
            txtSearchUser.Name = "txtSearchUser";
            txtSearchUser.PlaceholderText = "  Search product name";
            txtSearchUser.Size = new Size(251, 28);
            txtSearchUser.TabIndex = 47;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(243, 229, 219);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(153, 78, 36);
            button1.Location = new Point(28, 57);
            button1.Name = "button1";
            button1.Size = new Size(85, 23);
            button1.TabIndex = 56;
            button1.Text = "☰  ORDER";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 241, 236);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(153, 78, 36);
            button2.Location = new Point(142, 57);
            button2.Name = "button2";
            button2.Size = new Size(85, 23);
            button2.TabIndex = 57;
            button2.Text = "📄 HISTORY";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 241, 236);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(153, 78, 36);
            button3.Location = new Point(260, 57);
            button3.Name = "button3";
            button3.Size = new Size(85, 23);
            button3.TabIndex = 58;
            button3.Text = "✦ HELP";
            button3.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(243, 229, 219);
            panel1.Controls.Add(btnCheckout);
            panel1.Controls.Add(lblTotalAmount);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(flowLayoutCheckout);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(725, 79);
            panel1.Name = "panel1";
            panel1.Size = new Size(314, 383);
            panel1.TabIndex = 59;
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.FromArgb(167, 103, 84);
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCheckout.ForeColor = Color.FromArgb(243, 229, 219);
            btnCheckout.Location = new Point(73, 336);
            btnCheckout.Margin = new Padding(4, 3, 4, 3);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(174, 32);
            btnCheckout.TabIndex = 65;
            btnCheckout.Text = "CHECKOUT";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.BackColor = Color.Transparent;
            lblTotalAmount.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalAmount.ForeColor = Color.Gray;
            lblTotalAmount.Location = new Point(240, 297);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(36, 18);
            lblTotalAmount.TabIndex = 66;
            lblTotalAmount.Text = "0.00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(27, 297);
            label4.Name = "label4";
            label4.Size = new Size(55, 18);
            label4.TabIndex = 64;
            label4.Text = "TOTAL:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(153, 78, 36);
            label3.Location = new Point(12, 36);
            label3.Name = "label3";
            label3.Size = new Size(290, 18);
            label3.TabIndex = 63;
            label3.Text = "-----------------------------------------------";
            // 
            // flowLayoutCheckout
            // 
            flowLayoutCheckout.AutoScroll = true;
            flowLayoutCheckout.Location = new Point(12, 63);
            flowLayoutCheckout.Name = "flowLayoutCheckout";
            flowLayoutCheckout.Size = new Size(295, 212);
            flowLayoutCheckout.TabIndex = 62;
            // 
            // panel2
            // 
            panel2.Location = new Point(18, 60);
            panel2.Name = "panel2";
            panel2.Size = new Size(0, 0);
            panel2.TabIndex = 61;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(153, 78, 36);
            label2.Location = new Point(12, 14);
            label2.Name = "label2";
            label2.Size = new Size(58, 23);
            label2.TabIndex = 60;
            label2.Text = "CART";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(153, 78, 36);
            label1.Location = new Point(24, 139);
            label1.Name = "label1";
            label1.Size = new Size(103, 19);
            label1.TabIndex = 46;
            label1.Text = "CATEGORIES";
            // 
            // User_Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1060, 494);
            Controls.Add(panel1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnLoad);
            Controls.Add(btnCookie);
            Controls.Add(flowLayoutPanelUser);
            Controls.Add(btnAll);
            Controls.Add(btnCoffee);
            Controls.Add(btnPastry);
            Controls.Add(btnBread);
            Controls.Add(btnCake);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchUser);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "User_Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User_Menu";
            Load += User_Menu_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoad;
        private Button btnCookie;
        private FlowLayoutPanel flowLayoutPanelUser;
        private Button btnAll;
        private Button btnCoffee;
        private Button btnPastry;
        private Button btnBread;
        private Button btnCake;
        private Button btnSearch;
        private TextBox txtSearchUser;
        private Button button1;
        private Button button2;
        private Button button3;
        private Panel panel1;
        private Label label2;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutCheckout;
        private Label label4;
        private Label label3;
        private Button btnCheckout;
        private Label lblTotalAmount;
        private Label label1;
    }
}