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
            dgvSalesSummary = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSalesSummary).BeginInit();
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
            button3.Text = "✦ SALES";
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
            chartSales.BackColor = Color.FromArgb(246, 218, 196);
            chartSales.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chartSales.ForeColor = Color.FromArgb(153, 78, 36);
            chartSales.Location = new Point(28, 235);
            chartSales.MatchAxesScreenDataRatio = false;
            chartSales.Name = "chartSales";
            chartSales.Size = new Size(841, 321);
            chartSales.TabIndex = 71;
            // 
            // cmbSortSales
            // 
            cmbSortSales.BackColor = Color.FromArgb(243, 229, 219);
            cmbSortSales.FlatStyle = FlatStyle.Flat;
            cmbSortSales.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSortSales.ForeColor = Color.FromArgb(153, 78, 36);
            cmbSortSales.FormattingEnabled = true;
            cmbSortSales.Items.AddRange(new object[] { "Day", "Week", "Month", "Year" });
            cmbSortSales.Location = new Point(28, 196);
            cmbSortSales.Name = "cmbSortSales";
            cmbSortSales.Size = new Size(126, 24);
            cmbSortSales.TabIndex = 72;
            cmbSortSales.Text = "Sort  by";
            cmbSortSales.SelectedIndexChanged += cmbSortSales_SelectedIndexChanged;
            // 
            // dgvSalesSummary
            // 
            dgvSalesSummary.AllowUserToAddRows = false;
            dgvSalesSummary.AllowUserToDeleteRows = false;
            dgvSalesSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalesSummary.BackgroundColor = Color.FromArgb(247, 183, 147);
            dgvSalesSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalesSummary.Location = new Point(570, 108);
            dgvSalesSummary.Name = "dgvSalesSummary";
            dgvSalesSummary.ReadOnly = true;
            dgvSalesSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSalesSummary.Size = new Size(299, 73);
            dgvSalesSummary.TabIndex = 73;
            dgvSalesSummary.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Admin_Sales
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(899, 603);
            Controls.Add(dgvSalesSummary);
            Controls.Add(cmbSortSales);
            Controls.Add(chartSales);
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
            Text = "Admin Dashboard";
            Load += Admin_Sales_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSalesSummary).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button3;
        private Button btnOrder;
        private Button btnMenu;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart chartSales;
        private ComboBox cmbSortSales;
        private DataGridView dgvSalesSummary;
    }
}
