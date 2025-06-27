
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Bakeshop_Common;

namespace Bakeshop_DataLogic
{
    public class JsonFileBakeshopDataService : IBakeshopDataService
    {
        private string accountsFile = "accounts.json";
        private string menuFile = "menu.json";
        private string orderFile = "orders.json";

        private List<CustomerAccount> Accounts = new List<CustomerAccount>();
        private List<(string Name, decimal Price)> Menu = new List<(string, decimal)>();
        private List<Order> Orders = new List<Order>();

        public JsonFileBakeshopDataService()
        {
            try { LoadAccounts(); } catch { Accounts = new List<CustomerAccount>(); }
            try { LoadMenu(); } catch { Menu = new List<(string, decimal)>(); }
            try { LoadOrders(); } catch { Orders = new List<Order>(); }
        }

        // ========== Load / Save Logic ==========

        private void LoadAccounts()
        {
            if (File.Exists(accountsFile))
            {
                var json = File.ReadAllText(accountsFile);
                Accounts = JsonSerializer.Deserialize<List<CustomerAccount>>(json) ?? new List<CustomerAccount>();
            }
        }

        private void SaveAccounts()
        {
            try
            {
                var json = JsonSerializer.Serialize(Accounts, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(accountsFile, json);
            }
            catch { }
        }

        private void LoadMenu()
        {
            if (File.Exists(menuFile))
            {
                var json = File.ReadAllText(menuFile);
                var menuItems = JsonSerializer.Deserialize<List<MenuItem>>(json);
                if (menuItems != null)
                {
                    Menu = menuItems.Select(m => (m.Name, m.Price)).ToList();
                }
            }
        }

        private void SaveMenu()
        {
            try
            {
                var menuItems = Menu.Select(m => new MenuItem { Name = m.Name, Price = m.Price }).ToList();
                var json = JsonSerializer.Serialize(menuItems, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(menuFile, json);
            }
            catch { }
        }

        private void LoadOrders()
        {
            if (File.Exists(orderFile))
            {
                var json = File.ReadAllText(orderFile);
                Orders = JsonSerializer.Deserialize<List<Order>>(json) ?? new List<Order>();
            }
        }

        private void SaveOrders()
        {
            try
            {
                var json = JsonSerializer.Serialize(Orders, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(orderFile, json);
            }
            catch { }
        }

        // ========== Core Methods ==========

        public void AddProduct(string product, decimal price)
        {
            try
            {
                Menu.Add((product, price));
                SaveMenu();
            }
            catch { }
        }

        public bool UpdateProduct(string name, decimal newPrice)
        {
            try
            {
                int index = Menu.FindIndex(m => m.Name == name);
                if (index != -1)
                {
                    Menu[index] = (name, newPrice);
                    SaveMenu();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        //public bool DeleteProduct(string product)
        //{
        //    try
        //    {
        //        int index = Menu.FindIndex(m => m.Name == product);
        //        if (index != -1)
        //        {
        //            Menu.RemoveAt(index);
        //            SaveMenu();
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch { return false; }
        //}

        //public decimal? SearchProduct(string product)
        //{
        //    try
        //    {
        //        var match = Menu.FirstOrDefault(m => m.Name == product);
        //        return match != default ? match.Price : (decimal?)null;
        //    }
        //    catch { return null; }
        //}

        public List<(string Name, decimal Price)> GetMenu()
        {
            try { return new List<(string, decimal)>(Menu); }
            catch { return new List<(string, decimal)>(); }
        }

        public bool ValidateCustomer(string username, string password)
        {
            try
            {
                return Accounts.Any(a => a.Username == username && a.Password == password);
            }
            catch { return false; }
        }

        public CustomerAccount GetCustomer(string username)
        {
            try { return Accounts.FirstOrDefault(a => a.Username == username); }
            catch { return null; }
        }

        public void SaveOrder(Order order)
        {
            try
            {
                Orders.Add(order);
                SaveOrders();
            }
            catch { }
        }

        public List<Order> GetOrders()
        {
            try { return Orders; }
            catch { return new List<Order>(); }
        }

        private class MenuItem
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        // ========== STUB METHODS for Interface ==========

        public bool RegisterCustomerAccount(CustomerAccount account)
        {
            try
            {
                Accounts.Add(account);
                SaveAccounts();
                return true;
            }
            catch { return false; }
        }

        public CustomerAccount GetCustomerById(int userId)
        {
            try
            {
                return Accounts.ElementAtOrDefault(userId);
            }
            catch { return null; }
        }

        public bool AddProduct(Product product) => true;
        public bool UpdateProduct(Product product) => true;
        public bool DeleteProduct(string productName) => true;
        public List<Product> GetAllProducts() => new List<Product>();
        public List<Product> GetProductsByCategory(string category) => new List<Product>();
        public List<Product> SearchProduct(string keyword) => new List<Product>();

        public bool AddToCartProduct(Cart cart) => true;
        public List<Cart> GetCartItems(int userId) => new List<Cart>();
        public bool UpdateCartItem(Cart cart) => true;
        public bool DeleteCartItem(int cartId) => true;

        public bool SaveOrder(int userId, List<Cart> cartItems, out int newOrderId)
        {
            newOrderId = 999;
            return true;
        }

        public List<DbOrder> GetAllPendingOrders() => new List<DbOrder>();
        public List<DbOrder> GetAllCompletedOrders() => new List<DbOrder>();
        public List<OrderDetail> GetOrderDetails(int orderId) => new List<OrderDetail>();
        public bool MarkOrderAsComplete(int orderId) => true;
        public bool MarkOrderAsCancelled(int orderId) => true;

        public bool AddToFavorites(int userId, int productId) => true;
        public bool RemoveFromFavorites(int userId, int productId) => true;
        public bool IsFavorite(int userId, int productId) => true;
    }
}










//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text.Json;
//using Bakeshop_Common;

//namespace Bakeshop_DataLogic
//{
//    public class JsonFileBakeshopDataService : IBakeshopDataService
//    {
//        private string accountsFile = "accounts.json";
//        private string menuFile = "menu.json";
//        private string orderFile = "orders.json";

//        private List<CustomerAccount> Accounts = new List<CustomerAccount>();
//        private List<(string Name, decimal Price)> Menu = new List<(string, decimal)>();
//        private List<Order> Orders = new List<Order>();

//        public JsonFileBakeshopDataService()
//        {
//            LoadAccounts();
//            LoadMenu();
//            LoadOrders();
//        }

//        // Load/Save Accounts
//        private void LoadAccounts()
//        {
//            if (File.Exists(accountsFile))
//            {
//                Accounts = JsonSerializer.Deserialize<List<CustomerAccount>>(File.ReadAllText(accountsFile)) ?? new List<CustomerAccount>();
//            }
//        }

//        private void SaveAccounts()
//        {
//            File.WriteAllText(accountsFile, JsonSerializer.Serialize(Accounts, new JsonSerializerOptions { WriteIndented = true }));
//        }

//        // Load/Save Menu
//        private void LoadMenu()
//        {
//            if (File.Exists(menuFile))
//            {
//                var menuItems = JsonSerializer.Deserialize<List<MenuItem>>(File.ReadAllText(menuFile));
//                if (menuItems != null)
//                {
//                    Menu = menuItems.Select(m => (m.Name, m.Price)).ToList();
//                }
//            }
//        }

//        private void SaveMenu()
//        {
//            var menuItems = Menu.Select(m => new MenuItem { Name = m.Name, Price = m.Price }).ToList();
//            File.WriteAllText(menuFile, JsonSerializer.Serialize(menuItems, new JsonSerializerOptions { WriteIndented = true }));
//        }

//        // Load/Save Orders
//        private void LoadOrders()
//        {
//            if (File.Exists(orderFile))
//            {
//                Orders = JsonSerializer.Deserialize<List<Order>>(File.ReadAllText(orderFile)) ?? new List<Order>();
//            }
//        }

//        private void SaveOrders()
//        {
//            File.WriteAllText(orderFile, JsonSerializer.Serialize(Orders, new JsonSerializerOptions { WriteIndented = true }));
//        }

//        public void AddProduct(string product, decimal price)
//        {
//            Menu.Add((product, price));
//            SaveMenu();
//        }

//        public bool UpdateProduct(string name, decimal newPrice)
//        {
//            int index = Menu.FindIndex(m => m.Name == name);
//            if (index != -1)
//            {
//                Menu[index] = (name, newPrice);
//                SaveMenu();
//                return true;
//            }
//            return false;
//        }

//        public bool DeleteProduct(string product)
//        {
//            int index = Menu.FindIndex(m => m.Name == product);
//            if (index != -1)
//            {
//                Menu.RemoveAt(index);
//                SaveMenu();
//                return true;
//            }
//            return false;
//        }

//        public decimal? SearchProduct(string product)
//        {
//            var match = Menu.FirstOrDefault(m => m.Name == product);
//            return match != default ? match.Price : (decimal?)null;
//        }

//        public List<(string Name, decimal Price)> GetMenu()
//        {
//            return new List<(string, decimal)>(Menu);
//        }

//        public bool ValidateCustomer(string username, string password)
//        {
//            return Accounts.Any(a => a.Username == username && a.Password == password);
//        }

//        public CustomerAccount GetCustomer(string username)
//        {
//            return Accounts.FirstOrDefault(a => a.Username == username);
//        }

//        public void SaveOrder(Order order)
//        {
//            Orders.Add(order);
//            SaveOrders();
//        }

//        public List<Order> GetOrders()
//        {
//            return Orders;
//        }

//        private class MenuItem
//        {
//            public string Name { get; set; }
//            public decimal Price { get; set; }
//        }
//    }
//}
