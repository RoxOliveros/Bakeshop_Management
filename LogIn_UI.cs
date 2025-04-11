using System;
using BakeshopManagement.Business;
using BakeshopManagement.UI;
using Bakeshop_Common;

namespace BakeshopManagement
{
    public class LogIn_UI
    {
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

                if (usernameInput == BakeshopProcess.adminUsername && pinInput == BakeshopProcess.adminPin)
                {
                    Console.WriteLine("\n== WELCOME TO XANNE'S BAKESHOP (ADMIN) ==");
                    Program.Admin();
                    break;
                }

                else if (BakeshopProcess.ValidateCustomer(usernameInput, pinInput))
                {
                    CustomerAccount loggedInCustomer = BakeshopProcess.GetCustomer(usernameInput);
                    Console.WriteLine($"\n== WELCOME TO XANNE'S BAKESHOP, {loggedInCustomer.Name.ToUpper()}! ==");

                    Order_UI orderUI = new Order_UI();
                    orderUI.Customer(loggedInCustomer);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }

            } while (true);
        }
    }
}
