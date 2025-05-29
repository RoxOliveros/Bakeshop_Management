using System;
using BakeshopManagement.Business;
using BakeshopManagement.UI;
using Bakeshop_Common;

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
           
            string usernameInput, pinInput;

            Console.WriteLine("== LOGIN ==");

            do
            {
                Console.Write("Enter Username: ");
                usernameInput = Console.ReadLine();

                Console.Write("Enter Password: ");
                pinInput = Console.ReadLine();

                if (usernameInput == sharedProcess.adminUsername && pinInput == sharedProcess.adminPin)
                {
                    Console.WriteLine("\n== WELCOME TO XANNE'S BAKESHOP (ADMIN) ==");
                    Program.Admin(sharedProcess);
                    break; 
                }

                else if (sharedProcess.ValidateCustomer(usernameInput, pinInput))
                {
                    var customer = sharedProcess.GetCustomer(usernameInput);  
                    Console.WriteLine($"\n== Welcome, {customer.Name}! ==");
                    var ui = new Order_UI();
                    ui.Customer(customer, sharedProcess);
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }

            } while (true);
        }
    }
}
