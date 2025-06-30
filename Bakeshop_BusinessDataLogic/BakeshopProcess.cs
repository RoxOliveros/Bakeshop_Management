using Bakeshop_Common;
using Bakeshop_DataLogic;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BakeshopManagement.Business
{
    public class BakeshopProcess
    {
        private BakeshopDataService dataService = new BakeshopDataService();

        public string adminUsername = "admin";
        public string adminPin = "roxy";

        public bool ValidateCustomer(string username, string password)
        {
            return dataService.ValidateCustomer(username, password);
        }

        public CustomerAccount GetCustomer(string username)
        {
            return dataService.GetCustomer(username);
        }

        public bool RegisterCustomer(CustomerAccount account, out string errorMessage)
        {
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(account.Email) ||
                !account.Email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                errorMessage = "Email must end with @gmail.com.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(account.Password) || account.Password.Length < 8)
            {
                errorMessage = "Password must be at least 8 characters long.";
                return false;
            }

            return dataService.RegisterCustomerAccount(account);
        }



        public bool AddProduct(Product product, out string errorMessage)
        {
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(product.ProductName))
            {
                errorMessage = "Product name is required.";
                return false;
            }

            try
            {
                return dataService.AddProduct(product);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) // Unique constraint violation
                {
                    errorMessage = "Product name already exists.";
                    return false;
                }

                errorMessage = "An unexpected error occurred: " + ex.Message;
                return false;
            }
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


        public CustomerAccount GetCustomerById(int userId) {

            return dataService.GetCustomerById(userId);
        }


        public bool MarkOrderAsComplete(int orderId)
        {

            return dataService.MarkOrderAsComplete(orderId);
        }

        public bool MarkOrderAsCancelled(int orderId)
        {
            return dataService.MarkOrderAsCancelled(orderId);

        }

        public List<DbOrder> GetAllCompletedOrders()
        {

            return dataService.GetAllCompletedOrders();
        }


        public List<Product> SearchProducts(string keyword)
        {
            return dataService.SearchProduct(keyword);
        }




    }
}
