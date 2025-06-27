namespace Bakeshop_SalesReport
{
    partial class Admin_Sales
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_Sales));
            button3 = new Button();
            btnOrder = new Button();
            btnMenu = new Button();
            chartSales = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            cmbSortSales = new ComboBox();
            panel1 = new Panel();
            lblChartTitle = new Label();
            panel2 = new Panel();
            lblSales = new Label();
            label1 = new Label();
            panel3 = new Panel();
            lblBuyers = new Label();
            label4 = new Label();
            panel4 = new Panel();
            lblOrders = new Label();
            label6 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(243, 229, 219);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(153, 78, 36);
            button3.Location = new Point(263, 65);
            button3.Name = "button3";
            button3.Size = new Size(85, 26);
            button3.TabIndex = 69;
            button3.Text = "📈 SALES";
            button3.UseVisualStyleBackColor = false;
            // 
            // btnOrder
            // 
            btnOrder.BackColor = Color.FromArgb(255, 241, 236);
            btnOrder.FlatAppearance.BorderSize = 0;
            btnOrder.FlatStyle = FlatStyle.Flat;
            btnOrder.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOrder.ForeColor = Color.FromArgb(153, 78, 36);
            btnOrder.Location = new Point(145, 65);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(85, 26);
            btnOrder.TabIndex = 68;
            btnOrder.Text = "📄 ORDER";
            btnOrder.UseVisualStyleBackColor = false;
            btnOrder.Click += btnOrder_Click;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.FromArgb(255, 241, 236);
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu.ForeColor = Color.FromArgb(153, 78, 36);
            btnMenu.Location = new Point(28, 65);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(85, 26);
            btnMenu.TabIndex = 67;
            btnMenu.Text = "☰  MENU";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // chartSales
            // 
            chartSales.AutoScroll = true;
            chartSales.BackColor = Color.FromArgb(246, 218, 196);
            chartSales.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chartSales.ForeColor = Color.FromArgb(153, 78, 36);
            chartSales.Location = new Point(3, 73);
            chartSales.MatchAxesScreenDataRatio = false;
            chartSales.Name = "chartSales";
            chartSales.Size = new Size(813, 198);
            chartSales.TabIndex = 71;
            chartSales.Load += chartSales_Load;
            // 
            // cmbSortSales
            // 
            cmbSortSales.BackColor = Color.FromArgb(243, 229, 219);
            cmbSortSales.FlatStyle = FlatStyle.Flat;
            cmbSortSales.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSortSales.ForeColor = Color.FromArgb(153, 78, 36);
            cmbSortSales.FormattingEnabled = true;
            cmbSortSales.Items.AddRange(new object[] { "Day", "Week", "Month", "Year" });
            cmbSortSales.Location = new Point(46, 193);
            cmbSortSales.Name = "cmbSortSales";
            cmbSortSales.Size = new Size(76, 24);
            cmbSortSales.TabIndex = 72;
            cmbSortSales.Text = "Sort  by";
            cmbSortSales.SelectedIndexChanged += cmbSortSales_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(246, 218, 196);
            panel1.Controls.Add(lblChartTitle);
            panel1.Controls.Add(chartSales);
            panel1.Location = new Point(43, 223);
            panel1.Name = "panel1";
            panel1.Size = new Size(819, 274);
            panel1.TabIndex = 74;
            // 
            // lblChartTitle
            // 
            lblChartTitle.AutoSize = true;
            lblChartTitle.BackColor = Color.Transparent;
            lblChartTitle.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChartTitle.ForeColor = Color.FromArgb(153, 78, 36);
            lblChartTitle.Location = new Point(318, 11);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Size = new Size(216, 23);
            lblChartTitle.TabIndex = 75;
            lblChartTitle.Text = "SALES REPORT BY WEEK";
            lblChartTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(247, 183, 147);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblSales);
            panel2.Controls.Add(label1);
            panel2.ForeColor = Color.FromArgb(153, 78, 36);
            panel2.Location = new Point(744, 127);
            panel2.Name = "panel2";
            panel2.Size = new Size(115, 52);
            panel2.TabIndex = 77;
            // 
            // lblSales
            // 
            lblSales.AutoSize = true;
            lblSales.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSales.ForeColor = Color.FromArgb(64, 64, 64);
            lblSales.Location = new Point(8, 21);
            lblSales.Name = "lblSales";
            lblSales.Size = new Size(52, 18);
            lblSales.TabIndex = 79;
            lblSales.Text = "12,000";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 8F, FontStyle.Bold);
            label1.Location = new Point(20, 1);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 78;
            label1.Text = "TOTAL SALES:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(247, 183, 147);
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblBuyers);
            panel3.Controls.Add(label4);
            panel3.ForeColor = Color.FromArgb(153, 78, 36);
            panel3.Location = new Point(462, 127);
            panel3.Name = "panel3";
            panel3.Size = new Size(115, 52);
            panel3.TabIndex = 80;
            // 
            // lblBuyers
            // 
            lblBuyers.AutoSize = true;
            lblBuyers.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuyers.ForeColor = Color.FromArgb(64, 64, 64);
            lblBuyers.Location = new Point(42, 21);
            lblBuyers.Name = "lblBuyers";
            lblBuyers.Size = new Size(24, 18);
            lblBuyers.TabIndex = 79;
            lblBuyers.Text = "12";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 8F, FontStyle.Bold);
            label4.Location = new Point(16, 1);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 78;
            label4.Text = "TOTAL BUYERS:";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(247, 183, 147);
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(lblOrders);
            panel4.Controls.Add(label6);
            panel4.ForeColor = Color.FromArgb(153, 78, 36);
            panel4.Location = new Point(600, 127);
            panel4.Name = "panel4";
            panel4.Size = new Size(115, 52);
            panel4.TabIndex = 80;
            // 
            // lblOrders
            // 
            lblOrders.AutoSize = true;
            lblOrders.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrders.ForeColor = Color.FromArgb(64, 64, 64);
            lblOrders.Location = new Point(43, 21);
            lblOrders.Name = "lblOrders";
            lblOrders.Size = new Size(24, 18);
            lblOrders.TabIndex = 79;
            lblOrders.Text = "00";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 8F, FontStyle.Bold);
            label6.Location = new Point(15, 1);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 78;
            label6.Text = "TOTAL ORDERS:";
            // 
            // Admin_Sales
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(899, 532);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(cmbSortSales);
            Controls.Add(button3);
            Controls.Add(btnOrder);
            Controls.Add(btnMenu);
            DoubleBuffered = true;
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Admin_Sales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cozy Crust";
            Load += Admin_Sales_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button3;
        private Button btnOrder;
        private Button btnMenu;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart chartSales;
        private ComboBox cmbSortSales;
        private Panel panel1;
        private Label lblChartTitle;
        private Button button1;
        private Panel panel2;
        private Label lblSales;
        private Label label1;
        private Panel panel3;
        private Label lblBuyers;
        private Label label4;
        private Panel panel4;
        private Label lblOrders;
        private Label label6;
    }
}
