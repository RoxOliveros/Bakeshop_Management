using System;
using BakeshopManagement.Business;

namespace BakeshopManagement.UI
{
    public class LogIn_UI
    {
        public void DisplayLogin()
        {
            string usernameInput;
            string pinInput;

            Console.WriteLine("== LOGIN ==");

            do
            {
                Console.Write("Enter Username: ");
                usernameInput = Console.ReadLine();

                Console.Write("Enter Pin: ");
                pinInput = Console.ReadLine();

                if (BakeshopProcess.ValidateAdmin(usernameInput, pinInput))
                {
                    Console.WriteLine("\n== WELCOME TO XANNE'S BAKESHOP (ADMIN) == ");
                    return;  // Proceed to admin menu
                }
                else if (BakeshopProcess.ValidateCustomer(usernameInput, pinInput))
                {
                    Console.WriteLine("\n== WELCOME TO XANNE'S BAKESHOP (CUSTOMER) == ");
                    return;  // to be added later
                }
                else
                {
                    Console.WriteLine("Invalid username or pin. Please try again.");
                }

            } while (true);
        }
    }
}
