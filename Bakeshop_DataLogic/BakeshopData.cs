using System;
using System.Linq;
using System.Collections.Generic;
using Bakeshop_Common;

namespace BakeshopManagement.Data
{

    public static class BakeshopRepository
    {
        
        private static List<string> Menu = new List<string>(); // store product name
        private static List<decimal> Prices = new List<decimal>(); // store price
        private static List<Order> Orders = new List<Order>(); // store customers orders
        private static List<CustomerAccount> Accounts = new List<CustomerAccount>(); // store customers account

        static BakeshopRepository()
        {
            CreateDummyCustomerAccounts();
        }

        private static void CreateDummyCustomerAccounts()
        {
            Accounts.Add(new CustomerAccount
            {
                Name = "Roxanne Oliveros",
                Username = "Xanne",
                Password = "456",
                Email = "roxanneoliveros12@gmail.com"
            });

            Accounts.Add(new CustomerAccount
            {
                Name = "Taz Skylar",
                Username = "taz",
                Password = "bibiko",
                Email = "tazskylar@gmail.com"
            });

            Accounts.Add(new CustomerAccount
            {
                Name = "Dracule Mihawk",
                Username = "Hawkeye",
                Password = "yoru",
                Email = "hawkeye12@gmail.com"
            });

            Accounts.Add(new CustomerAccount
            {
                Name = "Charlotte Katakuri",
                Username = "Kuri",
                Password = "donut",
                Email = "katakuri48@gmail.com"
            });

            Accounts.Add(new CustomerAccount
            {
                Name = "Sanji",
                Username = "SanjiPogi",
                Password = "allblue",
                Email = "sanji@gmail.com"
            });
        }

        public static bool ValidateCustomer(string username, string password)
        {
            return Accounts.Any(a => a.Username == username && a.Password == password);
        }

        public static CustomerAccount GetCustomer(string username)
        {
            return Accounts.FirstOrDefault(a => a.Username == username);
        }


        public static void AddProduct(string product, decimal price)
        {
            Menu.Add(product);
            Prices.Add(price);
        }

        public static bool DeleteProduct(string product)
        {
            int index = Menu.IndexOf(product);
            if (index != -1)
            {
                Menu.RemoveAt(index);
                Prices.RemoveAt(index);
                return true;
            }
            return false;
        }

        public static decimal? SearchProduct(string product)
        {
            int index = Menu.IndexOf(product);
            if (index != -1)
                return Prices[index];

            return null;
        }

        public static List<(string Name, decimal Price)> GetMenu()
        {
            var menuList = new List<(string, decimal)>();
            for (int i = 0; i < Menu.Count; i++)
            {
                menuList.Add((Menu[i], Prices[i]));
            }
            return menuList;
        }

       
        public static bool TryGetPrice(string product, out decimal price)
        {
            int index = Menu.IndexOf(product);
            if (index != -1)
            {
                price = Prices[index];
                return true;
            }

            price = 0;
            return false;
        }

       
        public static void SaveOrder(Order order)
        {
            Orders.Add(order);
        }

        
        public static List<Order> GetOrders()
        {
            return Orders;
        }
    }
}
