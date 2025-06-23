namespace Bakeshop_DesktopApp
{
    partial class PendingOrdersCard
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
            DETAILS = new Label();
            lblOrderID = new Label();
            lblCustomerName = new Label();
            lblDateOfOrder = new Label();
            label7 = new Label();
            label6 = new Label();
            label8 = new Label();
            btnCheckout = new Button();
            button1 = new Button();
            lblTotal = new Label();
            lblOrderedItem = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // DETAILS
            // 
            DETAILS.AutoSize = true;
            DETAILS.BackColor = Color.Transparent;
            DETAILS.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DETAILS.ForeColor = Color.FromArgb(153, 78, 36);
            DETAILS.Location = new Point(92, 7);
            DETAILS.Name = "DETAILS";
            DETAILS.Size = new Size(56, 16);
            DETAILS.TabIndex = 47;
            DETAILS.Text = "DETAILS";
            // 
            // lblOrderID
            // 
            lblOrderID.AutoSize = true;
            lblOrderID.BackColor = Color.Transparent;
            lblOrderID.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrderID.ForeColor = Color.FromArgb(64, 64, 64);
            lblOrderID.Location = new Point(77, 23);
            lblOrderID.Name = "lblOrderID";
            lblOrderID.Size = new Size(83, 15);
            lblOrderID.TabIndex = 48;
            lblOrderID.Text = "(Order # 1001)";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.BackColor = Color.Transparent;
            lblCustomerName.Font = new Font("Century Gothic", 8F);
            lblCustomerName.ForeColor = Color.FromArgb(64, 64, 64);
            lblCustomerName.Location = new Point(16, 61);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(23, 16);
            lblCustomerName.TabIndex = 49;
            lblCustomerName.Text = "👤 ";
            // 
            // lblDateOfOrder
            // 
            lblDateOfOrder.AutoSize = true;
            lblDateOfOrder.BackColor = Color.Transparent;
            lblDateOfOrder.Font = new Font("Century Gothic", 8F);
            lblDateOfOrder.ForeColor = Color.FromArgb(64, 64, 64);
            lblDateOfOrder.Location = new Point(16, 83);
            lblDateOfOrder.Name = "lblDateOfOrder";
            lblDateOfOrder.Size = new Size(21, 16);
            lblDateOfOrder.TabIndex = 50;
            lblDateOfOrder.Text = "🗓️";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(153, 78, 36);
            label7.Location = new Point(15, 40);
            label7.Name = "label7";
            label7.Size = new Size(224, 17);
            label7.TabIndex = 65;
            label7.Text = "------------------------------------------------------";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(153, 78, 36);
            label6.Location = new Point(15, 100);
            label6.Name = "label6";
            label6.Size = new Size(224, 17);
            label6.TabIndex = 66;
            label6.Text = "------------------------------------------------------";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(153, 78, 36);
            label8.Location = new Point(17, 117);
            label8.Name = "label8";
            label8.Size = new Size(41, 16);
            label8.TabIndex = 67;
            label8.Text = "Items:";
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.FromArgb(255, 212, 181);
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCheckout.ForeColor = Color.FromArgb(167, 103, 84);
            btnCheckout.Location = new Point(32, 269);
            btnCheckout.Margin = new Padding(4, 3, 4, 3);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(81, 23);
            btnCheckout.TabIndex = 69;
            btnCheckout.Text = "COMPLETE";
            btnCheckout.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(167, 103, 84);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(243, 229, 219);
            button1.Location = new Point(132, 269);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(81, 23);
            button1.TabIndex = 70;
            button1.Text = "CANCEL";
            button1.UseVisualStyleBackColor = false;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.Transparent;
            lblTotal.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.FromArgb(64, 64, 64);
            lblTotal.Location = new Point(23, 237);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(42, 15);
            lblTotal.TabIndex = 71;
            lblTotal.Text = "TOTAL:";
            // 
            // lblOrderedItem
            // 
            lblOrderedItem.AutoSize = true;
            lblOrderedItem.Font = new Font("Century Gothic", 7F);
            lblOrderedItem.ForeColor = Color.Gray;
            lblOrderedItem.Location = new Point(4, 3);
            lblOrderedItem.Name = "lblOrderedItem";
            lblOrderedItem.Size = new Size(175, 75);
            lblOrderedItem.TabIndex = 72;
            lblOrderedItem.Text = "• Chocolate Cake (Large) \r\n      - Qty: 1 \r\n      - Instruction: no sugar coshfjaf \r\n\r\n\r\n";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(lblOrderedItem);
            panel1.Location = new Point(17, 136);
            panel1.Name = "panel1";
            panel1.Size = new Size(219, 91);
            panel1.TabIndex = 73;
            // 
            // PendingOrdersCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 229, 219);
            Controls.Add(panel1);
            Controls.Add(lblTotal);
            Controls.Add(button1);
            Controls.Add(btnCheckout);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(lblDateOfOrder);
            Controls.Add(lblCustomerName);
            Controls.Add(lblOrderID);
            Controls.Add(DETAILS);
            Name = "PendingOrdersCard";
            Size = new Size(248, 305);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label DETAILS;
        private Label lblOrderID;
        private Label lblCustomerName;
        private Label lblDateOfOrder;
        private Label label7;
        private Label label6;
        private Label label8;
        private Button btnCheckout;
        private Button button1;
        private Label lblTotal;
        private Label lblOrderedItem;
        private Panel panel1;
    }
}
