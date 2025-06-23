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

        public bool RegisterCustomer(CustomerAccount newAccount)
        {
            return dataService.RegisterCustomerAccount(newAccount);
        }


        public bool AddProduct(Product product)
        {
            return dataService.AddProduct(product);
        }

   
        public List<Product> GetAllProducts()
        {
            return dataService.GetAllProducts();
        }


        public bool DeleteProduct(string productName)
        {
            return dataService.DeleteProduct(productName);
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return dataService.GetProductsByCategory(category);
        }

        public bool UpdateProduct(Product updatedProduct)
        {
            return dataService.UpdateProduct(updatedProduct);
        }


        public bool AddToCartProduct(Cart cart)
        {

            return dataService.AddToCartProduct(cart);

        }

        public List<Cart> GetCartItems(int userId)
        {

            return dataService.GetCartItems(userId);

        }

        public bool UpdateCartItem(Cart cart) {

            return dataService.UpdateCartItem(cart);
        
        }


        public bool DeleteCartItem(int cartId) {

            return dataService.DeleteCartItem(cartId);
        }

        public bool SaveOrder(int userId, List<Cart> cartItems, out int newOrderId) {

            return dataService.SaveOrder(userId, cartItems, out newOrderId);
        
        }

        public bool AddToFavorites(int userId, int productId)
        {
            return dataService.AddToFavorites(userId, productId);

        }

        public bool RemoveFromFavorites(int userId, int productId)
        {

            return dataService.RemoveFromFavorites(userId, productId);
        }

        public bool IsFavorite(int userId, int productId) {
            return dataService.IsFavorite(userId, productId);
        
        }

        public List<DbOrder> GetAllPendingOrders()
        {
            return dataService.GetAllPendingOrders();

        }

        public List<OrderDetail> GetOrderDetails(int orderId) {

            return dataService.GetOrderDetails(orderId);
        }

        // ----------------------------------------------------------
        public List<(string Name, decimal Price)> GetMenu()
        {
            return dataService.GetMenu();
        }

        public List<Product> SearchProduct(string searchName)
        {
            return dataService.SearchProduct(searchName);
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
