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
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            flowLayoutOrders = new FlowLayoutPanel();
            label1 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 241, 236);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(153, 78, 36);
            button3.Location = new Point(260, 61);
            button3.Name = "button3";
            button3.Size = new Size(85, 23);
            button3.TabIndex = 61;
            button3.Text = "📈 SALES";
            button3.UseVisualStyleBackColor = false;
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
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 241, 236);
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
            // flowLayoutOrders
            // 
            flowLayoutOrders.AutoScroll = true;
            flowLayoutOrders.BackColor = Color.FromArgb(246, 218, 196);
            flowLayoutOrders.FlowDirection = FlowDirection.TopDown;
            flowLayoutOrders.Location = new Point(28, 162);
            flowLayoutOrders.Name = "flowLayoutOrders";
            flowLayoutOrders.Size = new Size(841, 335);
            flowLayoutOrders.TabIndex = 62;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(153, 78, 36);
            label1.Location = new Point(31, 126);
            label1.Name = "label1";
            label1.Size = new Size(117, 28);
            label1.TabIndex = 20;
            label1.Text = "PENDING";
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.FromArgb(243, 229, 219);
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.ForeColor = Color.FromArgb(153, 78, 36);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Number", "Date " });
            comboBox1.Location = new Point(800, 134);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(66, 24);
            comboBox1.TabIndex = 63;
            comboBox1.Text = "Sort  by";
            // 
            // Admin_Orders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(899, 532);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(flowLayoutOrders);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Admin_Orders";
            Text = "Admin Dashboard";
            Load += Admin_Orders_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Button button2;
        private Button button1;
        private FlowLayoutPanel flowLayoutOrders;
        private Label label1;
        private ComboBox comboBox1;
    }
}