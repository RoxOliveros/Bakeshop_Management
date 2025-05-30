using System;
using System.Windows.Forms;
using BakeshopManagement.Business;
using Bakeshop_Common;

namespace Bakeshop_DesktopApp
  
{
    public partial class Login : Form
    {
        private BakeshopProcess process;
        public Login(BakeshopProcess sharedProcess)
        {
            InitializeComponent();
            this.process = sharedProcess;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPass.Text;

            if (username == process.adminUsername && password == process.adminPin)
            {
                MessageBox.Show("Welcome Admin!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Admin admin = new Admin ();  
                admin.Show();
                this.Hide();
            }
            else if (process.ValidateCustomer(username, password))
            {
                CustomerAccount customer = process.GetCustomer(username);
                MessageBox.Show($"Welcome, {customer.Name}!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //OrderForm orderForm = new OrderForm(customer, process);  
                //orderForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}

