using Bakeshop_Common;
using BakeshopManagement.Business;
using BakeshopManagement.UI;
using System;

namespace BakeshopManagement
{
    public class LogIn_UI
    {
        private BakeshopProcess sharedProcess;

        public LogIn_UI(BakeshopProcess process)
        {
            sharedProcess = process;
        }

        public void DisplayLogin()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("== XANNE'S BAKESHOP LOGIN ==");
                Console.Write("Enter Username: ");
                string usernameInput = Console.ReadLine();

                Console.Write("Enter Password: ");
                string pinInput = Console.ReadLine();

                // ADMIN LOGIN
                if (usernameInput == sharedProcess.adminUsername && pinInput == sharedProcess.adminPin)
                {
                    Console.Clear();
                    Console.WriteLine("\n== WELCOME ADMIN TO XANNE'S BAKESHOP ==");
                    Program.Admin(sharedProcess);
                    break;
                }

                // CUSTOMER LOGIN
                else if (sharedProcess.ValidateCustomer(usernameInput, pinInput))
                {
                    var customer = sharedProcess.GetCustomer(usernameInput);
                    Console.Clear();
                    Console.WriteLine($"\n== Welcome, {customer.Name}! ==");

                    var orderUI = new Order_UI();
                    orderUI.Customer(customer, sharedProcess);

                    break;
                }

                // INVALID LOGIN
                else
                {
                    Console.WriteLine("\n❌ Invalid username or password. Press Enter to try again.");
                    Console.ReadLine();
                }
            }
        }
    }
}
