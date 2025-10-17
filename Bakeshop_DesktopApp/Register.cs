using Bakeshop_Common;
using BakeshopManagement.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Bakeshop_DesktopApp
{
    public partial class Register : Form
    {
        private BakeshopProcess process = new BakeshopProcess();

        public Register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            Login login = new Login(process);
            login.Show();

            this.Hide();

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPass.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill out all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newAccount = new CustomerAccount
            {
                Name = name,
                Email = email,
                Username = username,
                Password = password
            };

            string errorMessage;
            bool success = process.RegisterCustomer(newAccount, out errorMessage);

            if (!success)
            {
                MessageBox.Show(errorMessage, "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 🟢 Step 1: Configure Mailtrap
            var emailSettings = new Bakeshop_BusinessLogic.Services.EmailSettings
            {
                SmtpHost = "sandbox.smtp.mailtrap.io",
                SmtpPort = 2525,
                SmtpUser = "d26d19e651a5b4",
                SmtpPass = "ee99e69d51f070",
                FromName = "Bakeshop Management",
                FromEmail = "no-reply@bakeshop.test"
            };

            // 🟢 Step 2: Create the email message
            var message = new Bakeshop_BusinessLogic.Services.EmailMessage
            {
                Subject = "Welcome to Bakeshop Management!",
                BodyHtml = $@"
                    <!DOCTYPE html>
                    <html lang='en'>
                    <head>
                        <meta charset='UTF-8'>
                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                        <title>Welcome to Bakeshop Management</title>
                        <style>
                            body {{
                                font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                                background-color: #fdf6f0;
                                margin: 0;
                                padding: 0;
                            }}
                            .container {{
                                max-width: 600px;
                                margin: 40px auto;
                                background: #ffffff;
                                border-radius: 10px;
                                box-shadow: 0 4px 10px rgba(0,0,0,0.1);
                                overflow: hidden;
                            }}
                            .header {{
                                background-color: #f8c291;
                                padding: 20px;
                                text-align: center;
                            }}
                            .header h1 {{
                                color: #5d4037;
                                font-size: 24px;
                                margin: 0;
                            }}
                            .content {{
                                padding: 30px;
                                color: #333333;
                                line-height: 1.6;
                            }}
                            .content h2 {{
                                color: #6d4c41;
                            }}
                            .btn {{
                                display: inline-block;
                                padding: 10px 20px;
                                margin-top: 20px;
                                background-color: #f8c291;
                                color: #5d4037;
                                text-decoration: none;
                                border-radius: 5px;
                                font-weight: bold;
                                transition: background-color 0.3s ease;
                            }}
                            .btn:hover {{
                                background-color: #f5b97d;
                            }}
                            .footer {{
                                background-color: #f3e5ab;
                                text-align: center;
                                padding: 15px;
                                font-size: 13px;
                                color: #5d4037;
                            }}
                        </style>
                    </head>
                    <body>
                        <div class='container'>
                            <div class='header'>
                                <h1>🥐 Welcome to Bakeshop Management!</h1>
                            </div>
                            <div class='content'>
                                <h2>Hello, {name}!</h2>
                                <p>We’re thrilled to have you as part of the <strong>Bakeshop Family</strong>! 🍰</p>
                                <p>With your new account, you can now order delicious pastries, manage your favorite treats, and track your orders effortlessly.</p>
                                <a href='#' class='btn'>Explore the Menu</a>
                            </div>
                            <div class='footer'>
                                © {DateTime.Now.Year} Bakeshop Management. All Rights Reserved.<br/>
                                <small>This is an automated message. Please do not reply.</small>
                            </div>
                        </div>
                    </body>
                    </html>"
                    ,
                BodyText = $"Hello {name}! Thank you for signing up for Bakeshop Management."
            };
            message.To.Add(email);

            // 🟢 Step 3: Send it asynchronously
            try
            {
                var mailService = new Bakeshop_BusinessLogic.Services.MailtrapEmailService(emailSettings);
                await mailService.SendAsync(message);

                MessageBox.Show("Welcome email sent successfully!", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration successful, but failed to send email.\n\nError: {ex.Message}",
                    "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // 🟢 Step 4: Redirect to Login form
            Login login = new Login(process);
            login.Show();
            this.Hide();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

