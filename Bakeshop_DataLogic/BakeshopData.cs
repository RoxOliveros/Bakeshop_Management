using System;
using System.Linq;
using System.Collections.Generic;
using Bakeshop_Common;

namespace BakeshopManagement.Data
{

    public static class BakeshopRepository
    {
        
        private static List<string> Menu = new List<string>();
        private static List<decimal> Prices = new List<decimal>();

       
        private static List<Order> Orders = new List<Order>();

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
