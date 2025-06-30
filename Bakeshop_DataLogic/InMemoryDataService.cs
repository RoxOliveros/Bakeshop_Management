using Bakeshop_Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bakeshop_DataLogic
{
    public class InMemoryBakeshopDataSource : IBakeshopDataService
    {
        private List<string> Menu = new List<string>();
        private List<decimal> Prices = new List<decimal>();
        private List<Order> Orders = new List<Order>();
        private List<CustomerAccount> Accounts = new List<CustomerAccount>();

        public InMemoryBakeshopDataSource()
        {
            try
            {
                CreateDummyCustomerAccounts();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Init Error] {ex.Message}");
            }
        }

        private void CreateDummyCustomerAccounts()
        {
            Accounts.Add(new CustomerAccount { Name = "Roxanne Oliveros", Username = "Xanne", Password = "456", Email = "roxanneoliveros12@gmail.com" });
            Accounts.Add(new CustomerAccount { Name = "Taz Skylar", Username = "taz", Password = "bibiko", Email = "tazskylar@gmail.com" });
            Accounts.Add(new CustomerAccount { Name = "Dracule Mihawk", Username = "Hawkeye", Password = "yoru", Email = "hawkeye12@gmail.com" });
            Accounts.Add(new CustomerAccount { Name = "Charlotte Katakuri", Username = "Kuri", Password = "donut", Email = "katakuri48@gmail.com" });
            Accounts.Add(new CustomerAccount { Name = "Sanji", Username = "SanjiPogi", Password = "allblue", Email = "sanji@gmail.com" });
        }

        public bool ValidateCustomer(string username, string password)
        {
            try
            {
                return Accounts.Any(a => a.Username == username && a.Password == password);
            }
            catch
            {
                return false;
            }
        }

        public CustomerAccount GetCustomer(string username)
        {
            try
            {
                return Accounts.FirstOrDefault(a => a.Username == username);
            }
            catch
            {
                return null;
            }
        }

        public void AddProduct(string product, decimal price)
        {
            try
            {
                Menu.Add(product);
                Prices.Add(price);
            }
            catch { }
        }

        public bool UpdateProduct(string name, decimal newPrice)
        {
            try
            {
                int index = Menu.IndexOf(name);
                if (index != -1)
                {
                    Prices[index] = newPrice;
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        //public bool DeleteProduct(string product)
        //{
        //    try
        //    {
        //        int index = Menu.IndexOf(product);
        //        if (index != -1)
        //        {
        //            Menu.RemoveAt(index);
        //            Prices.RemoveAt(index);
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public decimal? SearchProduct(string product)
        //{
        //    try
        //    {
        //        int index = Menu.IndexOf(product);
        //        if (index != -1)
        //            return Prices[index];
        //        return null;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        public List<(string Name, decimal Price)> GetMenu()
        {
            try
            {
                var menuList = new List<(string, decimal)>();
                for (int i = 0; i < Menu.Count; i++)
                {
                    menuList.Add((Menu[i], Prices[i]));
                }
                return menuList;
            }
            catch
            {
                return new List<(string, decimal)>();
            }
        }

        public void SaveOrder(Order order)
        {
            try
            {
                Orders.Add(order);
            }
            catch { }
        }

        public List<Order> GetOrders()
        {
            try
            {
                return Orders;
            }
            catch
            {
                return new List<Order>();
            }
        }

        // ============ STUBS for missing methods ============

        public bool RegisterCustomerAccount(CustomerAccount account)
        {
            try
            {
                Accounts.Add(account);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public CustomerAccount GetCustomerById(int userId)
        {
            return Accounts.ElementAtOrDefault(userId); 
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
            newOrderId = 1001;
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
