using System;
using BakeshopManagement.Business;
using Bakeshop_Common;
using System.Collections.Generic;

namespace BakeshopManagement
{
    internal class Program
    {
        //public static void Main(string[] args)
        //{
        //    var sharedProcess = new BakeshopProcess();
        //    LogIn_UI login = new LogIn_UI(sharedProcess);
        //    login.DisplayLogin();
        //}

        public static void Main(string[] args)
        {
            // Test the signup email
            TestEmailSignup().GetAwaiter().GetResult();

            // Existing logic...
            // var sharedProcess = new BakeshopProcess();
            // LogIn_UI login = new LogIn_UI(sharedProcess);
            // login.DisplayLogin();
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

   

    //mailtrap

    public static async Task TestEmailSignup()
        {
            Console.Write("Enter user name: ");
            string name = Console.ReadLine();

            Console.Write("Enter user email: ");
            string email = Console.ReadLine();

            // 1️⃣ Configure Mailtrap credentials
            var settings = new Bakeshop_BusinessLogic.Services.EmailSettings
            {
                SmtpHost = "sandbox.smtp.mailtrap.io",
                SmtpPort = 2525,
                SmtpUser = "d26d19e651a5b4",
                SmtpPass = "ee99e69d51f070",
                FromName = "Bakeshop Management",
                FromEmail = "no-reply@bakeshop.test"
            };

            // 2️⃣ Create service instance
            var emailService = new Bakeshop_BusinessLogic.Services.MailtrapEmailService(settings);

            // 3️⃣ Create email message
            var message = new Bakeshop_BusinessLogic.Services.EmailMessage
            {
                To = { email },
                Subject = "Welcome to Cozy Crust!",
                BodyHtml = $@"
                    <!DOCTYPE html>
                    <html lang='en'>
                    <head>
                        <meta charset='UTF-8'>
                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                        <title>Welcome to Cozy Crust</title>
                        <style>
                            body {{
                                font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                                background-color: #fdf6f0;
                                margin: 0;
                                padding: 0;
                            }}
                            .container {{
                                max-width: 600px;
                                margin: 40px auto;
                                background: #ffffff;
                                border-radius: 10px;
                                box-shadow: 0 4px 10px rgba(0,0,0,0.1);
                                overflow: hidden;
                            }}
                            .header {{
                                background-color: #f8c291;
                                padding: 20px;
                                text-align: center;
                            }}
                            .header h1 {{
                                color: #5d4037;
                                font-size: 24px;
                                margin: 0;
                            }}
                            .content {{
                                padding: 30px;
                                color: #333333;
                                line-height: 1.6;
                            }}
                            .content h2 {{
                                color: #6d4c41;
                            }}
                            .btn {{
                                display: inline-block;
                                padding: 10px 20px;
                                margin-top: 20px;
                                background-color: #f8c291;
                                color: #5d4037;
                                text-decoration: none;
                                border-radius: 5px;
                                font-weight: bold;
                                transition: background-color 0.3s ease;
                            }}
                            .btn:hover {{
                                background-color: #f5b97d;
                            }}
                            .footer {{
                                background-color: #f3e5ab;
                                text-align: center;
                                padding: 15px;
                                font-size: 13px;
                                color: #5d4037;
                            }}
                        </style>
                    </head>
                    <body>
                        <div class='container'>
                            <div class='header'>
                                <h1>🥐 Welcome to Bakeshop Management!</h1>
                            </div>
                            <div class='content'>
                                <h2>Hello, {name}!</h2>
                                <p>We’re thrilled to have you as part of the <strong>Cozy Family</strong>! 🍰</p>
                                <p>With your new account, you can now order delicious pastries, manage your favorite treats, and track your orders effortlessly.</p>
                                <a href='#' class='btn'>Explore the Menu</a>
                            </div>
                            <div class='footer'>
                                © {DateTime.Now.Year} Cozy Crust. All Rights Reserved.<br/>
                                <small>This is an automated message. Please do not reply.</small>
                            </div>
                        </div>
                    </body>
                    </html>"
                    ,
                BodyText = $"Hello {name}! Your account has been successfully created."
            };

            // 4️⃣ Send it
            Console.WriteLine("Sending email...");
            await emailService.SendAsync(message);
            Console.WriteLine("✅ Email sent successfully! Check your Mailtrap inbox.");
        }

    }
}

