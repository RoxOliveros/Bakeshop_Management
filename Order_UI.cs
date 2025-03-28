using System;
using BakeshopManagement.Business;

namespace BakeshopManagement.UI
{
    public class Order_UI
    {
        public void Customer()
        {
            int customerAction;

            do
            {
                string[] actions = new string[]
                {
                    "[1] View Menu",
                    "[2] Place Order",
                    "[3] Logout"
                };

                Console.WriteLine("\nChoose an Action");

                foreach (var action in actions)
                {
                    Console.WriteLine(action);
                }

                Console.Write("Enter Action: ");

                if (int.TryParse(Console.ReadLine(), out customerAction))
                {
                    switch (customerAction)
                    {
                        case 1: // View Menu
                            Console.WriteLine("\n===== MENU ITEMS =====");

                            var menu = BakeshopProcess.GetMenu();  // Retrieve menu from business logic

                            if (menu.Count == 0)
                            {
                                Console.WriteLine("No products in the menu.");
                            }
                            else
                            {
                                for (int i = 0; i < menu.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {menu[i].Name} [ P{menu[i].Price} ]");
                                }
                            }
                            break;

                        case 2: // Place Order

                            Console.WriteLine("\n===== PLACE ORDER =====");

                            Console.Write("Enter product name: ");
                            string product = Console.ReadLine();

                            Console.Write("Enter quantity: ");
                            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                            {
                                // Call business logic method
                                var result = BakeshopProcess.ProcessOrder(product, quantity);

                                if (result.isAvailable)
                                {
                                    Console.WriteLine($"You ordered {quantity} x {product} for a total of P{result.totalPrice}.");
                                }
                                else
                                {
                                    Console.WriteLine($"{product} is not available in the menu.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid quantity. Please enter a positive number.");
                            }
                            break;

                        case 3: // Logout
                            Console.WriteLine("Logging out... Returning to login.\n");
                            Program.Main(null);  // Go back to the login screen
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please select a number between 1-3.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

            } while (customerAction != 3);
        }
       
    }
}
