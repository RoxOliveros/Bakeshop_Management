using System;
using Bakeshop_Common;
using BakeshopManagement.Business;


namespace BakeshopManagement.UI
{
    public class Order_UI
    {
        public void Customer (CustomerAccount customer, BakeshopProcess process)
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
                            Program.Menu(process);
                            break;

                        case 2: // Place Order

                            var orders = new List<(string, int)>();

                            do
                            {
                                Console.Write("\nEnter product name: ");
                                string product = Console.ReadLine();

                                Console.Write("Enter quantity: ");
                                if (int.TryParse(Console.ReadLine(), out int qty) && qty > 0)
                                {
                                    orders.Add((product, qty));
                                }
                                else
                                {
                                    Console.WriteLine("Invalid quantity.");
                                }

                                Console.Write("\nDo you want to add another order? (yes/no): ");
                            } while (Console.ReadLine().Trim().ToLower() == "yes");

                            // Process all orders
                            var receipt = process.ProcessMultipleOrders(orders);

                            if (receipt.Count > 0)
                            {
                                var order = new Order(receipt, customer.Name);  
                                process.SaveOrder(order);

                                Console.WriteLine("\n\t XANNE'S BAKESHOP");
                                Console.WriteLine("Address: Somewhere in Grandline");
                                Console.WriteLine("Tel: 123-456-789");
                                Console.WriteLine("------------------------------------------");

                                Console.WriteLine($"Date: {DateTime.Now.ToString("MMMM dd, yyyy")} \t Time: {DateTime.Now.ToString("hh:mm tt")}");

                                Console.WriteLine("------------------------------------------\n");



                                decimal grandTotal = 0;
                                foreach (var item in receipt)
                                {
                                    Console.WriteLine($"{item.Quantity}x {item.ProductName} \t @ P{item.UnitPrice}");
                                    grandTotal += item.Total;
                                }
                                Console.WriteLine("\n------------------------------------------\n");
                                Console.WriteLine($"TOTAL: P{grandTotal}");
                                Console.WriteLine("\nThank you for ordering!");
                            }
                            else
                            {
                                Console.WriteLine("No valid products found in your order.");
                            }
                            break;

                        case 3: // Logout
                            Console.WriteLine("Logging out... Returning to login.\n");
                            Program.RestartLogin(process);
                            // Go back to the login screen
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
