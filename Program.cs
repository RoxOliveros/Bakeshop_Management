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
                        "[6] Update Product",
                        "[7] Logout"
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

                            Console.Write("Enter category: ");
                            string category = Console.ReadLine();

                            Console.Write("Enter description: ");
                            string desc = Console.ReadLine();

                            Console.Write("Enter price: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal price) && price >= 0)
                            {
                                var product = new Product
                                {
                                    ProductName = name,
                                    Price1 = price,
                                    Option1 = "Regular",
                                    Category = category,
                                    Description = desc
                                };

                                if (process.AddProduct(product, out string errorMsg))
                                    Console.WriteLine($"{name} added successfully!");
                                else
                                    Console.WriteLine($"Error: {errorMsg}");
                            }
                            else
                            {
                                Console.WriteLine("Invalid price input.");
                            }
                            break;

                        case 2: // Delete product
                            Console.Write("Enter product name to delete: ");
                            string toDelete = Console.ReadLine();

                            if (process.DeleteProduct(toDelete))
                                Console.WriteLine($"{toDelete} deleted.");
                            else
                                Console.WriteLine($"{toDelete} not found.");
                            break;

                        case 3: // Search product
                            Console.Write("Enter keyword to search: ");
                            string keyword = Console.ReadLine();

                            var found = process.SearchProducts(keyword);
                            if (found != null && found.Count > 0)
                            {
                                Console.WriteLine("\nSearch Results:");
                                foreach (var p in found)
                                    Console.WriteLine($"- {p.ProductName} (Php{p.Price1:0.00})");
                            }
                            else
                            {
                                Console.WriteLine("No matching product found.");
                            }
                            break;

                        case 4: // View menu
                            Menu(process);
                            break;

                        case 5: // View orders (pending and completed)
                            DisplayOrders(process);
                            break;

                        case 6: // Update product
                            Console.Write("Enter product name to update: ");
                            string updateName = Console.ReadLine();

                            var existing = process.SearchProducts(updateName)?.FirstOrDefault();

                            if (existing == null)
                            {
                                Console.WriteLine("Product not found.");
                                break;
                            }

                            Console.WriteLine($"Editing: {existing.ProductName}");
                            Console.Write($"New name [{existing.ProductName}]: ");
                            string newName = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newName))
                                existing.ProductName = newName;

                            Console.Write($"New category [{existing.Category}]: ");
                            string newCategory = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newCategory))
                                existing.Category = newCategory;

                            Console.Write($"New description [{existing.Description}]: ");
                            string newDesc = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newDesc))
                                existing.Description = newDesc;

                            Console.Write($"New price [{existing.Price1}]: ");
                            string priceInput = Console.ReadLine();
                            if (decimal.TryParse(priceInput, out decimal newPrice) && newPrice >= 0)
                                existing.Price1 = newPrice;

                            if (process.UpdateProduct(existing))
                                Console.WriteLine("Product updated successfully.");
                            else
                                Console.WriteLine("Failed to update product.");
                            break;


                        case 7:
                            Console.WriteLine("Logging out...");
                            RestartLogin(process);
                            break;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }

            } while (adminAction != 7);
        }

        public static void Menu(BakeshopProcess process)
        {
            Console.WriteLine("\n===== MENU ITEMS =====\n");

            var menu = process.GetAllProducts();

            if (menu == null || menu.Count == 0)
            {
                Console.WriteLine("No products available.\n");
            }
            else
            {
                foreach (var p in menu)
                {
                    Console.WriteLine($"Product Name : {p.ProductName}");
                    Console.WriteLine($"Category     : {p.Category}");
                    Console.WriteLine($"Price        : Php {p.Price1:0.00}");
                    Console.WriteLine($"Description  : {p.Description}");
                    Console.WriteLine(new string('-', 40));
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
            var pendingOrders = process.GetAllPendingOrders();

            if (pendingOrders == null || pendingOrders.Count == 0)
            {
                Console.WriteLine("No pending orders.");
                return;
            }

            foreach (var order in pendingOrders)
            {
                Console.WriteLine($"\nOrder ID   : {order.OrderID}");
                Console.WriteLine($"User ID    : {order.UserID}");
                Console.WriteLine($"Date       : {order.OrderDate:MMMM dd, yyyy hh:mm tt}");
                Console.WriteLine($"Total      : ₱{order.TotalAmount:0.00}");
                Console.WriteLine($"Status     : {order.Status}");

                // Get order details
                var details = process.GetOrderDetails(order.OrderID);
                if (details.Count > 0)
                {
                    Console.WriteLine("Items:");
                    foreach (var item in details)
                    {
                        Console.WriteLine($" - {item.ProductName} x{item.Quantity} @ ₱{item.UnitPrice:0.00} = ₱{item.TotalPrice:0.00}");
                    }
                }
                else
                {
                    Console.WriteLine("No items found.");
                }

                Console.WriteLine(new string('-', 40));
            }
        }

    }
}

