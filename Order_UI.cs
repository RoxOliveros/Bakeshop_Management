using System;
using System.Collections.Generic;
using System.Linq;
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
                            Program.Menu(process);
                            break;

                        case 2: // Place Order
                            PlaceOrder(customer, process);
                            break;

                        case 3: // Logout
                            Console.WriteLine("Logging out...");
                            Program.RestartLogin(process);
                            return;

                        default:
                            Console.WriteLine("Invalid action.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number.");
                }

            } while (true);
        }

       

        private void PlaceOrder(CustomerAccount customer, BakeshopProcess process)
        {
            var cartItems = new List<Cart>();

            do
            {
                Console.Write("\nEnter product name: ");
                string productName = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(productName))
                {
                    Console.WriteLine("Product name cannot be empty.");
                    continue;
                }

                var matched = process.SearchProducts(productName);

                if (matched == null || matched.Count == 0)
                {
                    Console.WriteLine("Product not found.");
                    continue;
                }

                var selected = matched[0];

                Console.Write($"Enter quantity for {selected.ProductName}: ");
                if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
                {
                    Console.WriteLine("Invalid quantity.");
                    continue;
                }

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

                Console.WriteLine($"Added: {qty} x {selected.ProductName} (Option: {option})");

                Console.Write("Add another product? (yes/no): ");
            } while (Console.ReadLine().Trim().ToLower() == "yes");

            if (cartItems.Count == 0)
            {
                Console.WriteLine("No items added to cart.");
                return;
            }

            Console.WriteLine("\nReviewing Order...");
            decimal total = 0;
            foreach (var item in cartItems)
            {
                Console.WriteLine($"{item.Quantity} x {item.ProductName} ({item.SelectedOption}) @ Php{item.UnitPrice:0.00}");
                total += item.TotalPrice;
            }

            Console.WriteLine($"TOTAL: Php{total:0.00}");
            Console.Write("Confirm order? (yes/no): ");
            string confirm = Console.ReadLine().Trim().ToLower();

            if (confirm == "yes")
            {
                if (process.SaveOrder(customer.UserID, cartItems, out int orderId))
                {
                    Console.WriteLine($"\nOrder #{orderId} saved successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to save order.");
                }
            }
            else
            {
                Console.WriteLine("Order cancelled.");
            }
        }
    }
}
