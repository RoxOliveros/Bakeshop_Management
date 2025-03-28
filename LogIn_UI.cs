using System;
using BakeshopManagement.Business;
using BakeshopManagement.UI;

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

                Console.Write("Enter Pin: ");
                pinInput = Console.ReadLine();

                if (usernameInput == BakeshopProcess.adminUsername && pinInput == BakeshopProcess.adminPin)
                {
                    Console.WriteLine("\n== WELCOME TO XANNE'S BAKESHOP (ADMIN) == ");
                    Program.Admin();  
                    break;
                }
                else if (usernameInput == BakeshopProcess.customerUsername && pinInput == BakeshopProcess.customerPin)
                {
                    Console.WriteLine("\n== WELCOME TO XANNE'S BAKESHOP (CUSTOMER) == ");

                    Order_UI orderUI = new Order_UI();
                    orderUI.Customer();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid username or pin. Please try again.");
                }

            } while (true);
        }
    }
}
