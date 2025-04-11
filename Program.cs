using System;
using BakeshopManagement.Business;
using BakeshopManagement.UI;

namespace BakeshopManagement
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            LogIn_UI loginUI = new LogIn_UI();
            loginUI.DisplayLogin();

            // Admin menu after successful login
            Admin();
        }

        public static void Admin()
        {
            int adminAction;

            do
            {
                string[] actions = new string[] { 
                    "[1] Add Product", 
                    "[2] Delete Product",
                    "[3] Search Product", 
                    "[4] View Menu",
                    "[5] View Orders",
                    "[6] Logout"  };

                Console.WriteLine("\n Choose an Action");

                foreach (var action in actions)
                {
                    Console.WriteLine(action);
                }

                Console.Write("Enter Action: ");
               
                if (int.TryParse(Console.ReadLine(), out adminAction))
                {
                    switch (adminAction)
                    {
                        case 1: // Add product
                            Console.Write("Enter a product: ");
                            string product = Console.ReadLine();

                            Console.Write("Enter the price: P");

                            if (decimal.TryParse(Console.ReadLine(), out decimal price) && price >= 0)
                            {
                                if (!string.IsNullOrEmpty(product))
                                {
                                    if (BakeshopProcess.SearchProduct(product).HasValue)
                                    {
                                        Console.WriteLine($"{product} already exists in the menu. Cannot add duplicates.");
                                    }
                                    else
                                    {
                                        BakeshopProcess.AddProduct(product, price);
                                        Console.WriteLine($"{product} [ P{price} ] has been added to the menu.");
                                    }
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
                            Menu();
                            break;

                        case 5: // View Orders
                            DisplayOrders();
                            break;

                        case 6: // Logout
                            Console.WriteLine("Logging out... Returning to login.\n");
                            Main(null);
                            break;


                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                } while (adminAction != 5) ;
            }

        public static void Menu() {
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
                    
                    Console.WriteLine($"{i + 1}. {menu[i].Name} [ P{menu[i].Price} ]");
                }
            }
        }

        public static void DisplayOrders()
        {

            Console.WriteLine("\n===== CUSTOMER ORDERS =====");
            var orders = BakeshopProcess.GetOrders();

            if (orders.Count == 0)
            {
                Console.WriteLine("No orders placed yet.");
            }
            else
            {
                foreach (var order in orders)
                {
                    Console.WriteLine($"\nOrder ID: {order.OrderId}");
                    foreach (var item in order.Items)
                    {
                        Console.WriteLine($" - {item.ProductName} x{item.Quantity} = P{item.Total}");
                    }
                    Console.WriteLine($"Total: P{order.TotalAmount}");
                    Console.WriteLine("---------------------------");
                }
            }
        }

    }
}