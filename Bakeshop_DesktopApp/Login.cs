using Bakeshop_Common;
using BakeshopManagement.Business;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                MessageBox.Show("Welcome Admin! ദ്ദി(˵ •̀ ᴗ - ˵ ) ✧", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Admin_Menu admin = new Admin_Menu();
                admin.Show();
                this.Hide();
            }
            else if (process.ValidateCustomer(username, password))
            {
                CustomerAccount customer = process.GetCustomer(username);

                MessageBox.Show($"୨୧ *:・ﾟ🍓 Hello {customer.Name}! ・ﾟ:* ୨୧\nEnjoy your time in the bakeshop! 🎀", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Customer_Menu user = new Customer_Menu(process, customer);
                user.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }



        private void btnHidePass_Click_1(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*'; // Hide the password
            btnUnhidePass.Visible = true;
            btnHidePass.Visible = false;
        }

        private void btnUnhidePass_Click(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '\0'; // Show the password
            btnUnhidePass.Visible = false;
            btnHidePass.Visible = true;
        }
    }

}

