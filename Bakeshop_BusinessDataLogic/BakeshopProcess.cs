using System;
using System.Collections.Generic;
using Bakeshop_DataLogic;
using Bakeshop_Common;

namespace BakeshopManagement.Business
{
    public class BakeshopProcess
    {
        private BakeshopDataService dataService = new BakeshopDataService();

        public string adminUsername = "admin";
        public string adminPin = "123";

        public bool ValidateCustomer(string username, string password)
        {
            return dataService.ValidateCustomer(username, password);
        }

        public CustomerAccount GetCustomer(string username)
        {
            return dataService.GetCustomer(username);
        }
    
        public void AddProduct(string product, decimal price)
        {
            dataService.AddProduct(product, price);
        }

        public bool DeleteProduct(string product)
        {
            return dataService.DeleteProduct(product);
        }
    
        public List<(string Name, decimal Price)> GetMenu()
        {
            return dataService.GetMenu();
        }

        public decimal? SearchProduct(string product)
        {
            return dataService.SearchProduct(product);
        }

        public bool IsProductAvailable(string product, out decimal price)
        {
            var menu = dataService.GetMenu();
            var item = menu.Find(p => p.Name.Equals(product, StringComparison.OrdinalIgnoreCase));
            if (item.Name != null)
            {
                price = item.Price;
                return true;
            }

            price = 0;
            return false;
        }

        public List<OrderItem> ProcessMultipleOrders(List<(string product, int quantity)> orders)
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

        public void SaveOrder(Order order)
        {
            dataService.SaveOrder(order); 
        }


        public List<Order> GetOrders()
        {
            return dataService.GetOrders();
        }
    }
}
