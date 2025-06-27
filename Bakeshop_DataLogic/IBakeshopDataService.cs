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
        bool AddProduct(Product product);
        List<Product> GetAllProducts();

        bool UpdateProduct(Product updatedProduct);
        bool DeleteProduct(string name);
        List<Product> SearchProduct(string searchTerm);

        bool ValidateCustomer(string username, string password);
        CustomerAccount GetCustomer(string username);
        bool RegisterCustomerAccount(CustomerAccount account);

        List<Product> GetProductsByCategory(string category);

        bool AddToCartProduct(Cart cart);
        List <Cart> GetCartItems(int userId);

        bool UpdateCartItem(Cart cart);

        bool DeleteCartItem(int cart);

        bool SaveOrder(int userId, List<Cart> cartItems, out int newOrderId);

        bool AddToFavorites(int userId, int productId);

        bool RemoveFromFavorites(int userId, int productId);

        bool IsFavorite(int userId, int productId);

        List<DbOrder> GetAllPendingOrders();

        List<OrderDetail> GetOrderDetails(int orderId);

        CustomerAccount GetCustomerById(int userId);

        bool MarkOrderAsComplete(int orderId);

        bool MarkOrderAsCancelled(int orderId);

        List<DbOrder> GetAllCompletedOrders();

      


    }
}
