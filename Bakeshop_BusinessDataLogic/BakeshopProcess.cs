using System;
using System.Collections.Generic;
using BakeshopManagement.Data;
using Bakeshop_Common;

namespace BakeshopManagement.Business
{
    public static class BakeshopProcess
    {
       
        public static string adminUsername = "admin";
        public static string adminPin = "123";
        public static string customerUsername = "Xanne";
        public static string customerPin = "heehee";

        public static void AddProduct(string product, decimal price)
        {
            BakeshopRepository.AddProduct(product, price);
        }

        public static bool DeleteProduct(string product)
        {
            return BakeshopRepository.DeleteProduct(product);
        }
    
        public static List<(string Name, decimal Price)> GetMenu()
        {
            return BakeshopRepository.GetMenu();
        }

        public static decimal? SearchProduct(string product)
        {
            return BakeshopRepository.SearchProduct(product);
        }

        public static bool IsProductAvailable(string product, out decimal price)
        {
            return BakeshopRepository.TryGetPrice(product, out price);
        }

       
        public static List<OrderItem> ProcessMultipleOrders(List<(string product, int quantity)> orders)
        {
            var result = new List<OrderItem>();

            foreach (var order in orders)
            {
                if (IsProductAvailable(order.product, out decimal unitPrice))
                {
                    result.Add(new OrderItem
                    {
                        ProductName = order.product,
                        Quantity = order.quantity,
                        UnitPrice = unitPrice
                    });
                }
            }

            return result;
        }

        public static void SaveOrder(List<OrderItem> items)
        {
            var order = new Order(items);
            BakeshopRepository.SaveOrder(order);
        }

        public static List<Order> GetOrders()
        {
            return BakeshopRepository.GetOrders();
        }
    }
}
