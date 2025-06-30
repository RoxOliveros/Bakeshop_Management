using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bakeshop_Common;

namespace Bakeshop_DataLogic
{
    public class TextFileBakeshopDataSource : IBakeshopDataService
    {
        private readonly string accountsFile = "accounts.txt";
        private readonly string productFile = "menu.txt";
        private readonly string orderFile = "orders.txt";

        private List<CustomerAccount> Accounts = new List<CustomerAccount>();
        private List<Product> Products = new List<Product>();
        private List<Order> Orders = new List<Order>();

        public TextFileBakeshopDataSource()
        {
            LoadAccounts();
            LoadProducts();
            LoadOrders();
        }

        private void LoadAccounts()
        {
            if (!File.Exists(accountsFile)) return;
            Accounts = File.ReadAllLines(accountsFile)
                .Select(line => line.Split('|'))
                .Select(parts => new CustomerAccount { Name = parts[0], Username = parts[1], Password = parts[2], Email = parts[3] })
                .ToList();
        }

        private void SaveAccounts()
        {
            var lines = Accounts.Select(a => $"{a.Name}|{a.Username}|{a.Password}|{a.Email}");
            File.WriteAllLines(accountsFile, lines);
        }

        private void LoadProducts()
        {
            if (!File.Exists(productFile)) return;

            var lines = File.ReadAllLines(productFile);

            Products = lines
                .Where(line => !string.IsNullOrWhiteSpace(line) && !line.StartsWith("=") && !line.StartsWith("Product Name"))
                .Select(line =>
                {
                    var parts = line.Split('|');
                    if (parts.Length < 13) return null;

                    return new Product
                    {
                        ProductId = int.TryParse(parts[0], out int id) ? id : 0,
                        ProductImage = null,
                        ProductName = parts[1],
                        Category = parts[2],
                        Option1 = parts[3],
                        Price1 = decimal.TryParse(parts[4], out var p1) ? p1 : 0,
                        Option2 = parts[5],
                        Price2 = decimal.TryParse(parts[6], out var p2) ? p2 : null,
                        Option3 = parts[7],
                        Price3 = decimal.TryParse(parts[8], out var p3) ? p3 : null,
                        Option4 = parts[9],
                        Price4 = decimal.TryParse(parts[10], out var p4) ? p4 : null,
                        Description = parts[11]
                    };
                })
                .Where(p => p != null)
                .ToList();
        }


        private void SaveProducts()
        {
            var lines = Products.Select(p =>
                $"{p.ProductId}|{p.ProductName}|{p.Category}|{p.Option1}|{p.Price1}|{p.Description}");
            File.WriteAllLines(productFile, lines);
        }

        private void LoadOrders()
        {
            if (!File.Exists(orderFile)) return;

            var lines = File.ReadAllLines(orderFile);

            Orders = lines
                .Where(line => !string.IsNullOrWhiteSpace(line) && !line.StartsWith("="))
                .Select(line =>
                {
                    var parts = line.Split('|');
                    if (parts.Length < 5) return null; // Expecting: OrderId|UserID|CustomerName|Timestamp|ProductName1,Qty,Price;ProductName2,...

                    try
                    {
                        int orderId = int.Parse(parts[0]);
                        int userId = int.Parse(parts[1]);
                        string customerName = parts[2];
                        DateTime timestamp = DateTime.Parse(parts[3]);

                        // Parse order items
                        var items = new List<OrderItem>();
                        var itemTokens = parts[4].Split(';', StringSplitOptions.RemoveEmptyEntries);

                        foreach (var token in itemTokens)
                        {
                            var itemParts = token.Split(',', StringSplitOptions.RemoveEmptyEntries);
                            if (itemParts.Length == 3 &&
                                !string.IsNullOrWhiteSpace(itemParts[0]) &&
                                int.TryParse(itemParts[1], out int qty) &&
                                decimal.TryParse(itemParts[2], out decimal price))
                            {
                                items.Add(new OrderItem
                                {
                                    ProductName = itemParts[0],
                                    Quantity = qty,
                                    UnitPrice = price
                                });
                            }
                        }

                        return new Order(items, customerName)
                        {
                            OrderId = orderId,
                            UserID = userId,
                            Timestamp = timestamp
                        };
                    }
                    catch
                    {
                        return null;
                    }
                })
                .Where(o => o != null)
                 .ToList();
        }


        private void SaveOrders()
        {
            var lines = Orders.SelectMany(o => o.Items.Select(i =>
                $"{o.OrderId}|{o.CustomerName}|{i.ProductName}|{i.Quantity}|{i.UnitPrice}|{o.UserID}|{o.Timestamp}"));
            File.WriteAllLines(orderFile, lines);
        }

        public bool AddProduct(Product product)
        {
            product.ProductId = Products.Any() ? Products.Max(p => p.ProductId) + 1 : 1;
            Products.Add(product);
            SaveProducts();
            return true;
        }

        public bool UpdateProduct(Product product)
        {
            var existing = Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existing != null)
            {
                existing.ProductName = product.ProductName;
                existing.Category = product.Category;
                existing.Option1 = product.Option1;
                existing.Price1 = product.Price1;
                existing.Description = product.Description;
                SaveProducts();
                return true;
            }
            return false;
        }

        public bool DeleteProduct(string productName)
        {
            var match = Products.FirstOrDefault(p => p.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (match != null)
            {
                Products.Remove(match);
                SaveProducts();
                return true;
            }
            return false;
        }

        public List<Product> GetAllProducts() => new List<Product>(Products);

        public List<Product> GetProductsByCategory(string category) =>
            Products.Where(p => p.Category?.Equals(category, StringComparison.OrdinalIgnoreCase) == true).ToList();

        public List<Product> SearchProduct(string keyword) =>
            Products.Where(p => p.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

        public bool SaveOrder(int userId, List<Cart> cartItems, out int newOrderId)
        {
            var customer = Accounts.FirstOrDefault(a => a.UserID == userId);
            newOrderId = 0;
            if (customer == null) return false;

            var items = cartItems.Select(c => new OrderItem
            {
                ProductName = c.ProductName,
                Quantity = c.Quantity,
                UnitPrice = c.UnitPrice
            }).ToList();

            var order = new Order(items, customer.Name) { UserID = userId };
            Orders.Add(order);
            newOrderId = order.OrderId;
            SaveOrders();
            return true;
        }

        public List<DbOrder> GetAllPendingOrders() =>
            Orders.Select(o => new DbOrder
            {
                OrderID = o.OrderId,
                UserID = o.UserID,
                OrderDate = o.Timestamp,
                TotalAmount = o.TotalAmount,
                Status = "Pending"
            }).ToList();

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            var order = Orders.FirstOrDefault(o => o.OrderId == orderId);
            return order?.Items.Select((i, idx) => new OrderDetail
            {
                DetailID = idx + 1,
                OrderID = orderId,
                ProductName = i.ProductName,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList() ?? new List<OrderDetail>();
        }

        public List<Order> GetOrders() => new List<Order>(Orders);

        public bool RegisterCustomerAccount(CustomerAccount account)
        {
            Accounts.Add(account);
            SaveAccounts();
            return true;
        }

        public bool ValidateCustomer(string username, string password) =>
            Accounts.Any(a => a.Username == username && a.Password == password);

        public CustomerAccount GetCustomer(string username) =>
            Accounts.FirstOrDefault(a => a.Username == username);

        public CustomerAccount GetCustomerById(int userId) =>
            Accounts.FirstOrDefault(a => a.UserID == userId);

        public bool AddToCartProduct(Cart cart) => true;
        public List<Cart> GetCartItems(int userId) => new List<Cart>();
        public bool UpdateCartItem(Cart cart) => true;
        public bool DeleteCartItem(int cartId) => true;
        public List<DbOrder> GetAllCompletedOrders() => new List<DbOrder>();
        public bool MarkOrderAsComplete(int orderId) => true;
        public bool MarkOrderAsCancelled(int orderId) => true;
        public bool AddToFavorites(int userId, int productId) => true;
        public bool RemoveFromFavorites(int userId, int productId) => true;
        public bool IsFavorite(int userId, int productId) => true;
    }
}
