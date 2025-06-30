using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Bakeshop_Common;

namespace Bakeshop_DataLogic
{
    public class JsonFileBakeshopDataSource : IBakeshopDataService
    {
        private readonly string accountsFile = "accounts.json";
        private readonly string productFile = "menu.json";
        private readonly string orderFile = "orders.json";

        private List<CustomerAccount> Accounts = new List<CustomerAccount>();
        private List<Product> Products = new List<Product>();
        private List<Order> Orders = new List<Order>();

        public JsonFileBakeshopDataSource()
        {
            try { LoadAccounts(); } catch { Accounts = new List<CustomerAccount>(); }
            try { LoadProducts(); } catch { Products = new List<Product>(); }
            try { LoadOrders(); } catch { Orders = new List<Order>(); }
        }

        // ========== Load / Save Methods ==========

        private void LoadAccounts()
        {
            if (File.Exists(accountsFile))
            {
                Accounts = JsonSerializer.Deserialize<List<CustomerAccount>>(File.ReadAllText(accountsFile)) ?? new List<CustomerAccount>();
            }
        }

        private void SaveAccounts()
        {
            File.WriteAllText(accountsFile, JsonSerializer.Serialize(Accounts, new JsonSerializerOptions { WriteIndented = true }));
        }

        private void LoadProducts()
        {
            if (File.Exists(productFile))
            {
                Products = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(productFile)) ?? new List<Product>();
            }
        }

        private void SaveProducts()
        {
            File.WriteAllText(productFile, JsonSerializer.Serialize(Products, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
        }


        private void LoadOrders()
        {
            if (File.Exists(orderFile))
            {
                Orders = JsonSerializer.Deserialize<List<Order>>(File.ReadAllText(orderFile)) ?? new List<Order>();
            }
        }

        private void SaveOrders()
        {
            File.WriteAllText(orderFile, JsonSerializer.Serialize(Orders, new JsonSerializerOptions { WriteIndented = true }));
        }

        // ========== Product Methods ==========

        public bool AddProduct(Product product)
        {
            try
            {
                product.ProductId = Products.Any() ? Products.Max(p => p.ProductId) + 1 : 1;
                product.Option1 ??= "";
                product.Option2 ??= "";
                product.Option3 ??= "";
                product.Option4 ??= "";
                product.Description ??= "";
                product.ProductImage ??= Array.Empty<byte>();

                Products.Add(product);
                SaveProducts();
                return true;
            }
            catch { return false; }
        }


        public bool UpdateProduct(Product product)
        {
            try
            {
                var existing = Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                if (existing != null)
                {
                    existing.ProductName = product.ProductName;
                    existing.Category = product.Category;
                    existing.Option1 = product.Option1;
                    existing.Option2 = product.Option2;
                    existing.Option3 = product.Option3;
                    existing.Option4 = product.Option4;
                    existing.Price1 = product.Price1;
                    existing.Price2 = product.Price2;
                    existing.Price3 = product.Price3;
                    existing.Price4 = product.Price4;
                    existing.Description = product.Description;
                    existing.ProductImage = product.ProductImage;

                    SaveProducts();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
        public bool DeleteProduct(string productName)
        {
            try
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
            catch { return false; }
        }


        public List<Product> GetAllProducts()
        {
            return new List<Product>(Products);
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return Products
                .Where(p => p.Category != null && p.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Product> SearchProduct(string keyword)
        {
            try
            {
                return Products.Where(p =>
                    (!string.IsNullOrEmpty(p.ProductName) && p.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(p.Option1) && p.Option1.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(p.Option2) && p.Option2.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(p.Option3) && p.Option3.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(p.Option4) && p.Option4.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                ).ToList();
            }
            catch { return new List<Product>(); }
        }


        // ========== Order Methods ==========

        public bool SaveOrder(int userId, List<Cart> cartItems, out int newOrderId)
        {
            newOrderId = 0;
            try
            {
                var customer = Accounts.FirstOrDefault(a => a.UserID == userId || a.Username == userId.ToString());
                if (customer == null) return false;

                var items = cartItems.Select(c => new OrderItem
                {
                    ProductName = c.ProductName,
                    Quantity = c.Quantity,
                    UnitPrice = c.UnitPrice
                }).ToList();

                var order = new Order(items, customer.Name)
                {
                    UserID = userId
                };

                Orders.Add(order);
                newOrderId = order.OrderId;
                SaveOrders();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<DbOrder> GetAllPendingOrders()
        {
            return Orders.Select(o => new DbOrder
            {
                OrderID = o.OrderId,
                UserID = o.UserID,
                OrderDate = o.Timestamp,
                TotalAmount = o.TotalAmount,
                Status = "Pending" 
            }).ToList();
        }

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            var order = Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null) return new List<OrderDetail>();

            return order.Items.Select((item, index) => new OrderDetail
            {
                DetailID = index + 1,
                OrderID = orderId,
                ProductName = item.ProductName,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                
            }).ToList();
        }

        public List<Order> GetOrders()
        {
            return new List<Order>(Orders);
        }

        // ========== Customer Methods ==========

        public bool RegisterCustomerAccount(CustomerAccount account)
        {
            Accounts.Add(account);
            SaveAccounts();
            return true;
        }

        public bool ValidateCustomer(string username, string password)
        {
            return Accounts.Any(a => a.Username == username && a.Password == password);
        }

        public CustomerAccount GetCustomer(string username)
        {
            return Accounts.FirstOrDefault(a => a.Username == username);
        }

        public CustomerAccount GetCustomerById(int userId)
        {
            return Accounts.ElementAtOrDefault(userId);
        }



        // ========== METHODS THAT ONLY WORKS IN GUI ==========

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
