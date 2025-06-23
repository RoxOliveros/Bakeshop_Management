//using Bakeshop_Common;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Bakeshop_DataLogic
//{
//    public class InMemoryBakeshopDataSource : IBakeshopDataService
//    {
//        private List<string> Menu = new List<string>();
//        private List<decimal> Prices = new List<decimal>();
//        private List<Order> Orders = new List<Order>();
//        private List<CustomerAccount> Accounts = new List<CustomerAccount>();

//        public InMemoryBakeshopDataSource()
//        {
//            CreateDummyCustomerAccounts();
//        }

//        private void CreateDummyCustomerAccounts()
//        {
//            Accounts.Add(new CustomerAccount
//            {
//                Name = "Roxanne Oliveros",
//                Username = "Xanne",
//                Password = "456",
//                Email = "roxanneoliveros12@gmail.com"
//            });

//            Accounts.Add(new CustomerAccount
//            {
//                Name = "Taz Skylar",
//                Username = "taz",
//                Password = "bibiko",
//                Email = "tazskylar@gmail.com"
//            });

//            Accounts.Add(new CustomerAccount
//            {
//                Name = "Dracule Mihawk",
//                Username = "Hawkeye",
//                Password = "yoru",
//                Email = "hawkeye12@gmail.com"
//            });

//            Accounts.Add(new CustomerAccount
//            {
//                Name = "Charlotte Katakuri",
//                Username = "Kuri",
//                Password = "donut",
//                Email = "katakuri48@gmail.com"
//            });

//            Accounts.Add(new CustomerAccount
//            {
//                Name = "Sanji",
//                Username = "SanjiPogi",
//                Password = "allblue",
//                Email = "sanji@gmail.com"
//            });
//        }

//        public bool ValidateCustomer(string username, string password)
//        {
//            return Accounts.Any(a => a.Username == username && a.Password == password);
//        }

//        public CustomerAccount GetCustomer(string username)
//        {
//            return Accounts.FirstOrDefault(a => a.Username == username);
//        }

//        public void AddProduct(string product, decimal price)
//        {
//            Menu.Add(product);
//            Prices.Add(price);
//        }

//        public bool UpdateProduct(string name, decimal newPrice)
//        {
//            int index = Menu.IndexOf(name);
//            if (index != -1)
//            {
//                Prices[index] = newPrice;
//                return true;
//            }
//            return false;
//        }

//        public bool DeleteProduct(string product)
//        {
//            int index = Menu.IndexOf(product);
//            if (index != -1)
//            {
//                Menu.RemoveAt(index);
//                Prices.RemoveAt(index);
//                return true;
//            }
//            return false;
//        }

//        public decimal? SearchProduct(string product)
//        {
//            int index = Menu.IndexOf(product);
//            if (index != -1)
//                return Prices[index];

//            return null;
//        }

//        public List<(string Name, decimal Price)> GetMenu()
//        {
//            var menuList = new List<(string, decimal)>();
//            for (int i = 0; i < Menu.Count; i++)
//            {
//                menuList.Add((Menu[i], Prices[i]));
//            }
//            return menuList;
//        }

//        public void SaveOrder(Order order)
//        {
//            Orders.Add(order);
//        }

//        public List<Order> GetOrders()
//        {
//            return Orders;
//        }
//    }
//}
