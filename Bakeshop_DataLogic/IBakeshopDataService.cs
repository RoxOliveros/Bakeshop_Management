using Bakeshop_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakeshop_DataLogic
{
    public interface IBakeshopDataService
    {
        void AddProduct(string name, decimal price);
        bool UpdateProduct(string name, decimal newPrice);
        bool DeleteProduct(string name);
        decimal? SearchProduct(string name);
        List<(string Name, decimal Price)> GetMenu();

        void SaveOrder (Order order);
        List<Order> GetOrders();

        bool ValidateCustomer(string username, string password);
        CustomerAccount GetCustomer(string username);

    }
}
