namespace Bakeshop_DesktopApp
{
    partial class Customer_History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customer_History));
            button2 = new Button();
            btnOrder = new Button();
            flowLayoutHistory = new FlowLayoutPanel();
            btnCancel = new Button();
            btnComplete = new Button();
            btnPending = new Button();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(243, 229, 219);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(153, 78, 36);
            button2.Location = new Point(143, 60);
            button2.Name = "button2";
            button2.Size = new Size(85, 23);
            button2.TabIndex = 65;
            button2.Text = "📄 HISTORY";
            button2.UseVisualStyleBackColor = false;
            // 
            // btnOrder
            // 
            btnOrder.BackColor = Color.FromArgb(255, 241, 236);
            btnOrder.FlatAppearance.BorderSize = 0;
            btnOrder.FlatStyle = FlatStyle.Flat;
            btnOrder.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOrder.ForeColor = Color.FromArgb(153, 78, 36);
            btnOrder.Location = new Point(29, 60);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(85, 23);
            btnOrder.TabIndex = 64;
            btnOrder.Text = "☰  ORDER";
            btnOrder.UseVisualStyleBackColor = false;
            btnOrder.Click += btnOrder_Click_1;
            // 
            // flowLayoutHistory
            // 
            flowLayoutHistory.AutoScroll = true;
            flowLayoutHistory.BackColor = Color.FromArgb(246, 218, 196);
            flowLayoutHistory.FlowDirection = FlowDirection.TopDown;
            flowLayoutHistory.Location = new Point(43, 178);
            flowLayoutHistory.Name = "flowLayoutHistory";
            flowLayoutHistory.Size = new Size(843, 259);
            flowLayoutHistory.TabIndex = 69;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(254, 218, 188);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(167, 103, 84);
            btnCancel.Location = new Point(589, 130);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(103, 28);
            btnCancel.TabIndex = 72;
            btnCancel.Text = "❤️ FAVORITES";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnFavorite_Click;
            // 
            // btnComplete
            // 
            btnComplete.BackColor = Color.FromArgb(254, 218, 188);
            btnComplete.FlatStyle = FlatStyle.Flat;
            btnComplete.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);
            btnComplete.ForeColor = Color.FromArgb(167, 103, 84);
            btnComplete.Location = new Point(421, 130);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(103, 28);
            btnComplete.TabIndex = 71;
            btnComplete.Text = "✔️ COMPLETED";
            btnComplete.UseVisualStyleBackColor = false;
            btnComplete.Click += btnComplete_Click;
            // 
            // btnPending
            // 
            btnPending.BackColor = Color.FromArgb(254, 218, 188);
            btnPending.FlatStyle = FlatStyle.Flat;
            btnPending.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);
            btnPending.ForeColor = Color.FromArgb(167, 103, 84);
            btnPending.Location = new Point(251, 130);
            btnPending.Name = "btnPending";
            btnPending.Size = new Size(103, 28);
            btnPending.TabIndex = 70;
            btnPending.Text = "📝 PENDING";
            btnPending.UseVisualStyleBackColor = false;
            btnPending.Click += btnPending_Click;
            // 
            // Customer_History
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(930, 477);
            Controls.Add(btnCancel);
            Controls.Add(btnComplete);
            Controls.Add(btnPending);
            Controls.Add(flowLayoutHistory);
            Controls.Add(button2);
            Controls.Add(btnOrder);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Customer_History";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cozy Crust";
            Load += Customer_History_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button button2;
        private Button btnOrder;
        private FlowLayoutPanel flowLayoutHistory;
        private Button btnCancel;
        private Button btnComplete;
        private Button btnPending;
    }
}