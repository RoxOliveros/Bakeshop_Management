namespace Bakeshop_DesktopApp
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            txtUsername = new TextBox();
            lblUsername = new Label();
            lblPass = new Label();
            txtPass = new TextBox();
            btnLogin = new Button();
            label1 = new Label();
            button1 = new Button();
            btnUnhidePass = new Button();
            btnHidePass = new Button();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(247, 183, 147);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.FromArgb(243, 229, 219);
            txtUsername.Location = new Point(530, 185);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(233, 25);
            txtUsername.TabIndex = 0;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.FromArgb(153, 78, 36);
            lblUsername.Location = new Point(530, 164);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(69, 16);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username:";
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.BackColor = Color.Transparent;
            lblPass.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPass.ForeColor = Color.FromArgb(153, 78, 36);
            lblPass.Location = new Point(530, 239);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(65, 16);
            lblPass.TabIndex = 3;
            lblPass.Text = "Password:";
            // 
            // txtPass
            // 
            txtPass.BackColor = Color.FromArgb(247, 183, 147);
            txtPass.BorderStyle = BorderStyle.None;
            txtPass.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPass.ForeColor = Color.FromArgb(243, 229, 219);
            txtPass.Location = new Point(530, 259);
            txtPass.Multiline = true;
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(233, 25);
            txtPass.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(167, 103, 84);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.FromArgb(243, 229, 219);
            btnLogin.Location = new Point(688, 311);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 32);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 7F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(153, 78, 36);
            label1.Location = new Point(530, 422);
            label1.Name = "label1";
            label1.Size = new Size(111, 14);
            label1.TabIndex = 5;
            label1.Text = "Don't have account? ";
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 7F, FontStyle.Bold);
            button1.ForeColor = Color.FromArgb(247, 183, 147);
            button1.Location = new Point(642, 413);
            button1.Name = "button1";
            button1.Size = new Size(121, 32);
            button1.TabIndex = 6;
            button1.Text = "Click here to register";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnUnhidePass
            // 
            btnUnhidePass.BackgroundImage = Properties.Resources._20;
            btnUnhidePass.BackgroundImageLayout = ImageLayout.Stretch;
            btnUnhidePass.FlatAppearance.BorderSize = 0;
            btnUnhidePass.FlatStyle = FlatStyle.Flat;
            btnUnhidePass.Location = new Point(730, 259);
            btnUnhidePass.Name = "btnUnhidePass";
            btnUnhidePass.Size = new Size(33, 25);
            btnUnhidePass.TabIndex = 24;
            btnUnhidePass.UseVisualStyleBackColor = true;
            btnUnhidePass.Click += btnUnhidePass_Click;
            // 
            // btnHidePass
            // 
            btnHidePass.BackgroundImage = Properties.Resources._19;
            btnHidePass.BackgroundImageLayout = ImageLayout.Stretch;
            btnHidePass.FlatAppearance.BorderSize = 0;
            btnHidePass.FlatStyle = FlatStyle.Flat;
            btnHidePass.Location = new Point(730, 261);
            btnHidePass.Name = "btnHidePass";
            btnHidePass.Size = new Size(33, 21);
            btnHidePass.TabIndex = 25;
            btnHidePass.UseVisualStyleBackColor = true;
            btnHidePass.Visible = false;
            btnHidePass.Click += btnHidePass_Click_1;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Login;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnHidePass);
            Controls.Add(btnUnhidePass);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Controls.Add(lblPass);
            Controls.Add(txtPass);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cozy Crust";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private Label lblUsername;
        private Label lblPass;
        private TextBox txtPass;
        private Button btnLogin;
        private Label label1;
        private Button button1;
        private Button btnUnhidePass;
        private Button btnHidePass;
    }
}
