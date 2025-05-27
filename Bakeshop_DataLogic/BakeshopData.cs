using Bakeshop_Common;

namespace Bakeshop_DataLogic
{
    public class BakeshopDataService
    {
        IBakeshopDataService bakeshopDataService;

        public BakeshopDataService()
        {
            // You can switch between data sources here:
            // bakeshopDataService = new TextFileBakeshopDataSource();
            bakeshopDataService = new InMemoryBakeshopDataSource();
            // bakeshopDataService = new JsonFileBakeshopDataSource();
           // bakeshopDataService = new DBBakeshopDataSource(); 
        }

        public List<(string Name, decimal Price)> GetMenu()
        {
            return bakeshopDataService.GetMenu();
        }

        public void AddProduct(string name, decimal price)
        {
            bakeshopDataService.AddProduct(name, price);
        }

        public bool UpdateProduct(string name, decimal newPrice)
        {
            return bakeshopDataService.UpdateProduct(name, newPrice);
        }

        public bool DeleteProduct(string name)
        {
            return bakeshopDataService.DeleteProduct(name);
        }

        public decimal? SearchProduct(string name)
        {
            return bakeshopDataService.SearchProduct(name);
        }

        public void SaveOrder(Order order)
        {
            bakeshopDataService.SaveOrder(order);
        }

        public List<Order> GetOrders()
        {
            return bakeshopDataService.GetOrders();
        }

        public bool ValidateCustomer(string username, string password)
        {
            return bakeshopDataService.ValidateCustomer(username, password);
        }

        public CustomerAccount GetCustomer(string username)
        {
            return bakeshopDataService.GetCustomer(username);
        }
    }
}
