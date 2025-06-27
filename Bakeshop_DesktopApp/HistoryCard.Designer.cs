namespace Bakeshop_DesktopApp
{
    partial class HistoryCard
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
            lblOrderedItem = new Label();
            panel1 = new Panel();
            lblTotal = new Label();
            lblStatus = new Label();
            lblOrderID = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblOrderedItem
            // 
            lblOrderedItem.AutoSize = true;
            lblOrderedItem.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOrderedItem.ForeColor = Color.FromArgb(64, 64, 64);
            lblOrderedItem.Location = new Point(15, 13);
            lblOrderedItem.Name = "lblOrderedItem";
            lblOrderedItem.Size = new Size(142, 17);
            lblOrderedItem.TabIndex = 73;
            lblOrderedItem.Text = "1 x Chocolate  Cake\r\n";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(lblOrderedItem);
            panel1.Location = new Point(13, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(173, 117);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.Transparent;
            lblTotal.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.FromArgb(153, 78, 36);
            lblTotal.Location = new Point(13, 163);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(88, 16);
            lblTotal.TabIndex = 68;
            lblTotal.Text = "TOTAL:      0.00";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.FromArgb(64, 64, 64);
            lblStatus.Location = new Point(91, 195);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(95, 30);
            lblStatus.TabIndex = 69;
            lblStatus.Text = "COMPLETED ON:\r\n JUN 6, 2025";
            // 
            // lblOrderID
            // 
            lblOrderID.AutoSize = true;
            lblOrderID.BackColor = Color.Transparent;
            lblOrderID.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrderID.ForeColor = Color.FromArgb(153, 78, 36);
            lblOrderID.Location = new Point(59, 10);
            lblOrderID.Name = "lblOrderID";
            lblOrderID.Size = new Size(86, 19);
            lblOrderID.TabIndex = 70;
            lblOrderID.Text = "ORDER: #1";
            // 
            // HistoryCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 229, 219);
            Controls.Add(lblOrderID);
            Controls.Add(lblTotal);
            Controls.Add(lblStatus);
            Controls.Add(panel1);
            Name = "HistoryCard";
            Size = new Size(200, 240);
            Load += HistoryCard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblOrderedItem;
        private Panel panel1;
        private Label lblTotal;
        private Label lblStatus;
        private Label lblOrderID;
    }
}
