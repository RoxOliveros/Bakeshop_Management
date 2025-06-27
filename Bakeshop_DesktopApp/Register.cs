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

        private void btnLogin_Click(object sender, EventArgs e)
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
            
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

