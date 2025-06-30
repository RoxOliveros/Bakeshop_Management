namespace Bakeshop_SalesReport
{
    partial class AIGenerateInsights
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AIGenerateInsights));
            lblChartTitle = new Label();
            panel1 = new Panel();
            lblSummaryOutput = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblChartTitle
            // 
            lblChartTitle.AutoSize = true;
            lblChartTitle.BackColor = Color.Transparent;
            lblChartTitle.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChartTitle.ForeColor = Color.FromArgb(153, 78, 36);
            lblChartTitle.Location = new Point(32, 32);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Size = new Size(218, 23);
            lblChartTitle.TabIndex = 76;
            lblChartTitle.Text = "✨ YOUR AI SUMMARY:";
            lblChartTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblSummaryOutput);
            panel1.Location = new Point(32, 69);
            panel1.Name = "panel1";
            panel1.Size = new Size(655, 311);
            panel1.TabIndex = 77;
            // 
            // lblSummaryOutput
            // 
            lblSummaryOutput.AutoSize = true;
            lblSummaryOutput.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSummaryOutput.Location = new Point(19, 18);
            lblSummaryOutput.Name = "lblSummaryOutput";
            lblSummaryOutput.Size = new Size(76, 34);
            lblSummaryOutput.TabIndex = 0;
            lblSummaryOutput.Text = "jnfnjneksjnf\r\n\r\n";
            lblSummaryOutput.UseCompatibleTextRendering = true;
            lblSummaryOutput.Click += label1_Click;
            // 
            // AIGenerateInsights
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 229, 219);
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(717, 414);
            Controls.Add(panel1);
            Controls.Add(lblChartTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AIGenerateInsights";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cozy Crust";
            Load += AIGenerateInsights_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblChartTitle;
        private Panel panel1;
        private Label lblSummaryOutput;
    }
}