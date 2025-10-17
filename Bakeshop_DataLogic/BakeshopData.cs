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
            //bakeshopDataService = new InMemoryBakeshopDataSource();
            // bakeshopDataService = new JsonFileBakeshopDataSource();
           bakeshopDataService = new DBBakeshopDataSource(); 
        }



        public List<Product> GetAllProducts()
        {
            return bakeshopDataService.GetAllProducts();
        }

        public bool AddProduct(Product product)
        {
            return bakeshopDataService.AddProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return bakeshopDataService.UpdateProduct(product);
        }


        public bool DeleteProduct(string productName)
        {
            return bakeshopDataService.DeleteProduct(productName);
        }

        public List<Product> SearchProduct(string searchName)
        {
            return bakeshopDataService.SearchProduct(searchName);
        }

       

        public bool ValidateCustomer(string username, string password)
        {
            return bakeshopDataService.ValidateCustomer(username, password);
        }

        public CustomerAccount GetCustomer(string username)
        {
            return bakeshopDataService.GetCustomer(username);
        }

        public bool RegisterCustomerAccount(CustomerAccount account)
        {
            return bakeshopDataService.RegisterCustomerAccount(account);
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return bakeshopDataService.GetProductsByCategory(category);
        }

        public bool AddToCartProduct(Cart cart) {

            return bakeshopDataService.AddToCartProduct(cart);
        
        }

        public List<Cart> GetCartItems(int userId) {

            return bakeshopDataService.GetCartItems(userId);
        
        }

        public bool UpdateCartItem(Cart cart) {

            return bakeshopDataService.UpdateCartItem(cart);
        }

        public bool DeleteCartItem(int cartId) {
            return bakeshopDataService.DeleteCartItem(cartId);
        
        }

        public bool SaveOrder(int userId, List<Cart> cartItems, out int newOrderId) { 
        
            return bakeshopDataService.SaveOrder(userId, cartItems, out newOrderId);
        }

        public bool AddToFavorites(int userId, int productId) {
            return bakeshopDataService.AddToFavorites(userId, productId);
        
        }

        public bool RemoveFromFavorites(int userId, int productId) {

            return bakeshopDataService.RemoveFromFavorites(userId, productId);
        }

        public bool IsFavorite(int userId, int productId) {

            return bakeshopDataService.IsFavorite(userId, productId);
        
        }

        public List<DbOrder> GetAllPendingOrders() {
            return bakeshopDataService.GetAllPendingOrders();
        
        }

        public List<OrderDetail> GetOrderDetails(int orderId) {

            return bakeshopDataService.GetOrderDetails(orderId);

        }

        public CustomerAccount GetCustomerById(int userId) {

            return bakeshopDataService.GetCustomerById(userId);
        }

        public bool MarkOrderAsComplete(int orderId) {

            return bakeshopDataService.MarkOrderAsComplete(orderId);
        }

        public bool MarkOrderAsCancelled(int orderId) {
            return bakeshopDataService.MarkOrderAsCancelled(orderId);
        
        }

        public List<DbOrder> GetAllCompletedOrders()
        {

            return bakeshopDataService.GetAllCompletedOrders();
        }

       
    }
}
