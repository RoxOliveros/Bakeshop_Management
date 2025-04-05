using System.Collections.Generic;

namespace BakeshopManagement.Business
{
    public static class BakeshopProcess
    {
        // Admin and Customer Credentials
        public static string adminUsername = "admin";
        public static string adminPin = "123";
        public static string customerUsername = "Xanne";
        public static string customerPin = "heehee";


        // Menu data
        private static List<string> Menu = new List<string>();
        private static List<decimal> Prices = new List<decimal>();



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

            if (index != -1)  
            {
                return Prices[index];  
            }
            else  
            {
                return null; 
            }
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

        public static (bool isAvailable, decimal totalPrice) ProcessOrder(string product, int quantity)
        {
            decimal? price = SearchProduct(product);

            if (price != null)
            {
                decimal totalPrice = (decimal)price * quantity;  // Calculate total price
                return (true, totalPrice);
            }

            return (false, 0);
        }

    }
}