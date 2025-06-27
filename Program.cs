using System;
using BakeshopManagement.Business;
using Bakeshop_Common;
using System.Collections.Generic;

namespace BakeshopManagement
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sharedProcess = new BakeshopProcess();
            LogIn_UI login = new LogIn_UI(sharedProcess);
            login.DisplayLogin();

        }

        public static void Admin(BakeshopProcess process)
        {
            int adminAction;

            do
            {
                Console.WriteLine("\n===== ADMIN DASHBOARD =====");
                string[] actions = new string[] {
                    "[1] Add Product",
                    "[2] Delete Product",
                    "[3] Search Product",
                    "[4] View Menu",
                    "[5] View Orders",
                    "[6] Logout"
                };

                foreach (var action in actions)
                {
                    Console.WriteLine(action);
                }

                Console.Write("Enter Action: ");

                if (int.TryParse(Console.ReadLine(), out adminAction))
                {
                    Console.Clear();
                    switch (adminAction)
                    {
                       
                        case 1: // Add product

                            Console.Write("Enter product name: ");
                            string name = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(name))
                            {
                                Console.WriteLine("❌ Product name cannot be empty.");
                                break;
                            }

                            Console.Write("Enter price: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal price) && price >= 0)


                            {
                                try
                                {
                                    var product = new Product
                                    {
                                        ProductName = name,
                                        Price1 = price,
                                        Option1 = "Regular", // basic default
                                        Category = "General",
                                       ProductImage = null  // important to avoid the varbinary error
                                    };



                                    if (process.AddProduct(product, out string errorMsg))
                                        Console.WriteLine($" {name} added successfully!");
                                    else
                                        Console.WriteLine($" Error: {errorMsg}");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($" Unexpected error occurred: {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine(" Invalid price input.");
                            }
                            break;


                        case 2: // Delete product
                            Console.Write("Enter product name to delete: ");
                            string toDelete = Console.ReadLine();

                            if (process.DeleteProduct(toDelete))
                                Console.WriteLine($" {toDelete} deleted.");
                            else
                                Console.WriteLine($" {toDelete} not found.");
                            break;

                        case 3: // Search product
                            Console.Write("Enter keyword to search: ");
                            string keyword = Console.ReadLine();

                            var found = process.SearchProducts(keyword);
                            if (found != null && found.Count > 0)
                            {
                                Console.WriteLine("\n Search Results:");
                                foreach (var p in found)
                                    Console.WriteLine($"- {p.ProductName} (₱{p.Price1:0.00})");
                            }
                            else
                            {
                                Console.WriteLine(" No matching product found.");
                            }
                            break;

                        case 4: // View menu
                            Menu(process);
                            break;

                        case 5: // View orders (pending and completed)
                            DisplayOrders(process);
                            break;

                        case 6:
                            Console.WriteLine(" Logging out...");
                            RestartLogin(process);
                            break;

                        default:
                            Console.WriteLine(" Invalid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("❌ Please enter a valid number.");
                }

            } while (adminAction != 6);
        }

        public static void Menu(BakeshopProcess process)
        {
            Console.WriteLine("\n===== MENU ITEMS =====");
            var menu = process.GetAllProducts();

            if (menu == null || menu.Count == 0)
            {
                Console.WriteLine("No products available.");
            }
            else
            {
                foreach (var p in menu)
                {
                    Console.WriteLine($"- {p.ProductName} (₱{p.Price1:0.00})");
                }
            }
        }

        public static void RestartLogin(BakeshopProcess process)
        {
            var loginUI = new LogIn_UI(process);
            loginUI.DisplayLogin();
        }


        public static void DisplayOrders(BakeshopProcess process)
        {
            Console.WriteLine("\n===== PENDING ORDERS =====");
            var orders = process.GetAllPendingOrders();

            if (orders == null || orders.Count == 0)
            {
                Console.WriteLine("No orders yet.");
            }
            else
            {
                foreach (var order in orders)
                {
                    Console.WriteLine($"\n Order ID: {order.OrderID} | User ID: {order.UserID} | Status: {order.Status}");

                    var details = process.GetOrderDetails(order.OrderID);

                    foreach (var item in details)
                    {
                        Console.WriteLine($" - {item.ProductName} x{item.Quantity} = ₱{item.TotalPrice:0.00}");
                    }

                    Console.WriteLine($"Total: {order.TotalAmount:0.00}");
                    Console.WriteLine("--------------------------------------");
                }
            }
        }
    }
}
