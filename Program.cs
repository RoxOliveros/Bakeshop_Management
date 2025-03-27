using System;
using BakeshopManagement.Business;
using BakeshopManagement.UI;

namespace BakeshopManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LogIn_UI loginUI = new LogIn_UI();
            loginUI.DisplayLogin();

            // Admin menu after successful login
            AdminMenu();
        }

        static void AdminMenu()
        {
            int userAction;

            do
            {
                Console.WriteLine("\nChoose an Action");
                Console.WriteLine("[1] Add Product");
                Console.WriteLine("[2] Delete Product");
                Console.WriteLine("[3] Search Product");
                Console.WriteLine("[4] View Menu");
                Console.WriteLine("[5] Exit");

                Console.Write("Enter Action: ");

                if (int.TryParse(Console.ReadLine(), out userAction))
                {
                    ChooseAction(userAction);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

            } while (userAction != 5);
        }

        static void ChooseAction(int action)
        {
            switch (action)
            {
                case 1: // Add product
                    Console.Write("Enter a product: ");
                    string product = Console.ReadLine();

                    Console.Write("Enter the price: P");

                    if (decimal.TryParse(Console.ReadLine(), out decimal price) && price >= 0)
                    {
                        if (!string.IsNullOrEmpty(product))
                        {
                            BakeshopProcess.AddProduct(product, price);
                            Console.WriteLine($"{product} [ P{price} ] has been added to the menu.");
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid product name.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid price. Please enter a valid number.");
                    }
                    break;

                case 2: // Delete product
                    Console.Write("Enter product to delete: ");
                    string productDelete = Console.ReadLine();

                    if (BakeshopProcess.DeleteProduct(productDelete))
                    {
                        Console.WriteLine($"{productDelete} has been removed from the menu.");
                    }
                    else
                    {
                        Console.WriteLine($"{productDelete} was not found in the menu.");
                    }
                    break;

                case 3: // Search product
                    Console.Write("Enter product name to search: ");
                    string searchItem = Console.ReadLine();

                    var result = BakeshopProcess.SearchProduct(searchItem);

                    if (result.HasValue)
                    {
                        Console.WriteLine($"{searchItem} is available in the menu for P{result}.");
                    }
                    else
                    {
                        Console.WriteLine($"{searchItem} is not in the menu.");
                    }
                    break;

                case 4: // Display the menu
                    Console.WriteLine("\n===== MENU ITEMS =====");
                    var menu = BakeshopProcess.GetMenu();

                    if (menu.Count == 0)
                    {
                        Console.WriteLine("No products in the menu.");
                    }
                    else
                    {
                        for (int i = 0; i < menu.Count; i++)
                        {
                            // Display in your preferred format
                            Console.WriteLine($"{i + 1}. {menu[i].Name} [ P{menu[i].Price} ]");
                        }
                    }
                    break;

                case 5: // Exit
                    Console.WriteLine("Exiting program. Thank you!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a number between 1-5.");
                    break;
            }
        }
    }
}
