using System.Collections.Generic;

namespace BakeshopManagement.Business
{
    public static class BakeshopProcess
    {
        // Admin and Customer Credentials
        private static string AdminUsername = "admin";
        private static string AdminPin = "123";
        private static string CustomerUsername = "Xanne";
        private static string CustomerPin = "uno";


        // Menu data
        private static List<string> Menu = new List<string>();
        private static List<decimal> Prices = new List<decimal>();

        // Admin login validation
        public static bool ValidateAdmin(string username, string pin)
        {
            return username == AdminUsername && pin == AdminPin;
        }

        // Customer login validation
        public static bool ValidateCustomer(string username, string pin)
        {
            return username == CustomerUsername && pin == CustomerPin;
        }

        // Add product
        public static void AddProduct(string product, decimal price)
        {
            Menu.Add(product);
            Prices.Add(price);
        }

        // Delete product
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

        // Search product
        public static decimal? SearchProduct(string product)
        {
            int index = Menu.IndexOf(product);
            return index != -1 ? Prices[index] : (decimal?)null;
        }

        // Get the menu
        public static List<(string Name, decimal Price)> GetMenu()
        {
            var menuList = new List<(string, decimal)>();

            for (int i = 0; i < Menu.Count; i++)
            {
                menuList.Add((Menu[i], Prices[i]));
            }

            return menuList;
        }
    }
}