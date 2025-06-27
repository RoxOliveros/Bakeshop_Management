using System;
using System.Collections.Generic;
using Bakeshop_Common;
using BakeshopManagement.Business;

namespace BakeshopManagement.UI
{
    public class Order_UI
    {
        public void Customer(CustomerAccount customer, BakeshopProcess process)
        {
            int customerAction;

            do
            {
                Console.WriteLine($"\n== Welcome, {customer.Name}! ==");
                Console.WriteLine("Choose an action:");
                Console.WriteLine("[1] View Menu");
                Console.WriteLine("[2] Place Order");
                Console.WriteLine("[3] Logout");
                Console.Write("Enter Action: ");

                if (int.TryParse(Console.ReadLine(), out customerAction))
                {
                    switch (customerAction)
                    {
                        case 1: // View Menu
                            var products = process.GetAllProducts();
                            Console.WriteLine("\n--- MENU ---");
                            foreach (var p in products)
                            {
                                Console.WriteLine($"- {p.ProductName} [₱{p.Price1:0.00}]");
                            }
                            break;


                        case 2: // Place Order
                            var cartItems = new List<Cart>();

                            do
                            {
                                Console.Write("\nEnter product name: ");
                                string productName = Console.ReadLine()?.Trim();

                                if (string.IsNullOrEmpty(productName))
                                {
                                    Console.WriteLine(" Product name cannot be empty.");
                                    continue;
                                }

                                var matched = process.SearchProducts(productName);

                                if (matched == null || matched.Count == 0)
                                {
                                    Console.WriteLine(" Product not found.");
                                    continue;
                                }

                                var selected = matched[0]; // pick first match

                                Console.Write($"Enter quantity for {selected.ProductName}: ");
                                if (int.TryParse(Console.ReadLine(), out int qty) && qty > 0)
                                {
                                    Console.Write($"Enter option (default: {selected.Option1 ?? "Regular"}): ");
                                    string optionInput = Console.ReadLine()?.Trim();
                                    string option = string.IsNullOrWhiteSpace(optionInput) ? (selected.Option1 ?? "Regular") : optionInput;

                                    cartItems.Add(new Cart
                                    {
                                        ProductID = selected.ProductId,
                                        ProductName = selected.ProductName,
                                        Quantity = qty,
                                        UnitPrice = selected.Price1,
                                        TotalPrice = qty * selected.Price1,
                                        SelectedOption = option,
                                        Instructions = ""       
                                    });

                                    Console.WriteLine($" Added: {qty} x {selected.ProductName} (Option: {option})");
                                }
                                else
                                {
                                    Console.WriteLine(" Invalid quantity.");
                                }

                                Console.Write("Add another product? (yes/no): ");
                            } while (Console.ReadLine().Trim().ToLower() == "yes");

                            if (cartItems.Count > 0)
                            {
                                try
                                {
                                    Console.WriteLine("\n Attempting to save order...");
                                    Console.WriteLine($"CustomerID: {customer.UserID}");

                                    foreach (var item in cartItems)
                                    {
                                        Console.WriteLine($"- {item.ProductName} (ID: {item.ProductID}), Qty: {item.Quantity}, Option: {item.SelectedOption}, Total: ₱{item.TotalPrice:0.00}");
                                    }

                                    bool success = process.SaveOrder(customer.UserID, cartItems, out int newOrderId);
                                    Console.WriteLine($" SaveOrder result: {success}, New Order ID: {newOrderId}");

                                    if (success)
                                    {
                                        Console.WriteLine("\n Order Saved Successfully!");
                                        Console.WriteLine("\n--- RECEIPT ---");
                                        Console.WriteLine("XANNE'S BAKESHOP");
                                        Console.WriteLine($"Date: {DateTime.Now:MMMM dd, yyyy hh:mm tt}");
                                        Console.WriteLine("------------------------------");

                                        decimal total = 0;
                                        foreach (var item in cartItems)
                                        {
                                            Console.WriteLine($"{item.Quantity}x {item.ProductName} ({item.SelectedOption}) @ ₱{item.UnitPrice:0.00}");
                                            total += item.TotalPrice;
                                        }

                                        Console.WriteLine("------------------------------");
                                        Console.WriteLine($"TOTAL: ₱{total:0.00}");
                                        Console.WriteLine("Thank you for your order!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("❌ Failed to save order. The data may be invalid or incomplete.");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"❌ Exception occurred while saving order: {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("❌ No items in cart.");
                            }
                            break;



                        case 3: // Logout
                            Console.WriteLine(" Logging out...");
                            Program.RestartLogin(process); 
                            return;

                        default:
                            Console.WriteLine("❌ Invalid action.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("❌ Please enter a number.");
                }

            } while (true);
        }
    }
}
