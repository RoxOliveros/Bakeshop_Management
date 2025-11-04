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
using Email;



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

            // ✅ Simplified registration — skip validation for now
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

            // ✅ Send Welcome Email using your MailKit EmailService
            try
            {
                var emailService = new EmailService();
                emailService.SendEmail(username, email);
                MessageBox.Show("Welcome email sent successfully!", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Email sending failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // ✅ Redirect to Login form
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

