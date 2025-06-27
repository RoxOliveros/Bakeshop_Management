namespace Bakeshop_DesktopApp
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            lblUsername = new Label();
            txtName = new TextBox();
            label1 = new Label();
            txtUsername = new TextBox();
            label2 = new Label();
            txtPass = new TextBox();
            label4 = new Label();
            txtEmail = new TextBox();
            button1 = new Button();
            label3 = new Label();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.FromArgb(153, 78, 36);
            lblUsername.Location = new Point(526, 115);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(46, 16);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Name:";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(247, 183, 147);
            txtName.BorderStyle = BorderStyle.None;
            txtName.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtName.ForeColor = Color.FromArgb(243, 229, 219);
            txtName.Location = new Point(526, 134);
            txtName.Multiline = true;
            txtName.Name = "txtName";
            txtName.Size = new Size(233, 23);
            txtName.TabIndex = 2;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(153, 78, 36);
            label1.Location = new Point(526, 183);
            label1.Name = "label1";
            label1.Size = new Size(72, 16);
            label1.TabIndex = 5;
            label1.Text = "Username: ";
            label1.Click += label1_Click;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(247, 183, 147);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.FromArgb(243, 229, 219);
            txtUsername.Location = new Point(526, 202);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(102, 23);
            txtUsername.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(153, 78, 36);
            label2.Location = new Point(526, 247);
            label2.Name = "label2";
            label2.Size = new Size(68, 16);
            label2.TabIndex = 7;
            label2.Text = "Password: ";
            // 
            // txtPass
            // 
            txtPass.BackColor = Color.FromArgb(247, 183, 147);
            txtPass.BorderStyle = BorderStyle.None;
            txtPass.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPass.ForeColor = Color.FromArgb(243, 229, 219);
            txtPass.Location = new Point(526, 266);
            txtPass.Multiline = true;
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(233, 23);
            txtPass.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(153, 78, 36);
            label4.Location = new Point(657, 183);
            label4.Name = "label4";
            label4.Size = new Size(41, 16);
            label4.TabIndex = 11;
            label4.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(247, 183, 147);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = Color.FromArgb(243, 229, 219);
            txtEmail.Location = new Point(657, 202);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(102, 23);
            txtEmail.TabIndex = 10;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 7F, FontStyle.Bold);
            button1.ForeColor = Color.FromArgb(247, 183, 147);
            button1.Location = new Point(638, 399);
            button1.Name = "button1";
            button1.Size = new Size(121, 30);
            button1.TabIndex = 14;
            button1.Text = "Click here to Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Century Gothic", 7F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(153, 78, 36);
            label3.Location = new Point(526, 408);
            label3.Name = "label3";
            label3.Size = new Size(125, 14);
            label3.TabIndex = 13;
            label3.Text = "Already have account? ";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(167, 103, 84);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.FromArgb(243, 229, 219);
            btnRegister.Location = new Point(684, 313);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 30);
            btnRegister.TabIndex = 12;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnLogin_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Register;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(btnRegister);
            Controls.Add(label4);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(txtPass);
            Controls.Add(label1);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(txtName);
            ForeColor = SystemColors.ControlLightLight;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cozy Crust";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private TextBox txtName;
        private Label label1;
        private TextBox txtUsername;
        private Label label2;
        private TextBox txtPass;
        private Label label4;
        private TextBox txtEmail;
        private Button button1;
        private Label label3;
        private Button btnRegister;
    }
}