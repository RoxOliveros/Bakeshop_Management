using Bakeshop_Common;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bakeshop_DataLogic
{
    class DBBakeshopDataSource : IBakeshopDataService
    {
        private List<string> Menu = new List<string>();
        private List<decimal> Prices = new List<decimal>();
        private List<Order> Orders = new List<Order>();
        private List<CustomerAccount> Accounts = new List<CustomerAccount>();


        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DBBakeshop;Integrated Security=True;TrustServerCertificate=True;";
        static SqlConnection sqlConnection;

        public DBBakeshopDataSource()
        {
            sqlConnection = new SqlConnection(connectionString);
            Accounts = GetCustomerAccounts(); // Load on startup
        }

        public List<CustomerAccount> GetCustomerAccounts()
        {
            var customerAccounts = new List<CustomerAccount>();
            string query = "SELECT * FROM UserAccounts";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                customerAccounts.Add(new CustomerAccount
                {
                    UserID = Convert.ToInt32(reader["userID"]),
                    Name = reader["Name"].ToString().Trim(),
                    Email = reader["Email"].ToString().Trim(),
                    Username = reader["Username"].ToString().Trim(),
                    Password = reader["Password"].ToString().Trim()

                });
            }

            reader.Close();
            sqlConnection.Close();

            return customerAccounts;
        }

        public bool ValidateCustomer(string username, string password)
        {
            string query = $"SELECT COUNT(*) FROM UserAccounts WHERE Username = '{username}' AND Password = '{password}'";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();

            int count = (int)command.ExecuteScalar();
            sqlConnection.Close();

            return count > 0;
        }

        public CustomerAccount GetCustomer(string username)
        {
            string query = $"SELECT * FROM UserAccounts WHERE Username = '{username}'";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();

            SqlDataReader reader = command.ExecuteReader();
            CustomerAccount account = null;

            if (reader.Read())
            {
                account = new CustomerAccount
                {
                    UserID = Convert.ToInt32(reader["userID"]),
                    Name = reader["Name"].ToString().Trim(),
                    Username = reader["Username"].ToString().Trim(),
                    Password = reader["Password"].ToString().Trim(),
                    Email = reader["Email"].ToString().Trim()
                };
            }

            reader.Close();
            sqlConnection.Close();

            return account;
        }

        public bool RegisterCustomerAccount(CustomerAccount newAccount)
        {
            string query = "INSERT INTO UserAccounts (Name, Email, Username, Password) VALUES (@Name, @Email, @Username, @Password)";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@Name", newAccount.Name);
            command.Parameters.AddWithValue("@Email", newAccount.Email);
            command.Parameters.AddWithValue("@Username", newAccount.Username);
            command.Parameters.AddWithValue("@Password", newAccount.Password);

            sqlConnection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            sqlConnection.Close();

            return rowsAffected > 0;
        }


        public bool AddProduct(Product product)
        {
            string query = @"INSERT INTO Menu (productName, category, option1, price1, option2, price2, option3, price3, option4, price4, description, productImage)
                     VALUES (@ProductName, @Category, @Option1, @Price1, @Option2, @Price2, @Option3, @Price3, @Option4, @Price4, @Description, @ProductImage)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                    cmd.Parameters.AddWithValue("@Category", product.Category);
                    cmd.Parameters.AddWithValue("@Option1", product.Option1);
                    cmd.Parameters.AddWithValue("@Price1", product.Price1);

                    cmd.Parameters.AddWithValue("@Option2", string.IsNullOrEmpty(product.Option2) ? (object)DBNull.Value : product.Option2);
                    cmd.Parameters.AddWithValue("@Price2", product.Price2.HasValue ? (object)product.Price2.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Option3", string.IsNullOrEmpty(product.Option3) ? (object)DBNull.Value : product.Option3);
                    cmd.Parameters.AddWithValue("@Price3", product.Price3.HasValue ? (object)product.Price3.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Option4", string.IsNullOrEmpty(product.Option4) ? (object)DBNull.Value : product.Option4);
                    cmd.Parameters.AddWithValue("@Price4", product.Price4.HasValue ? (object)product.Price4.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(product.Description) ? (object)DBNull.Value : product.Description);
                    cmd.Parameters.Add(new SqlParameter("@ProductImage", System.Data.SqlDbType.VarBinary, -1)
                    {
                        Value = product.ProductImage ?? (object)DBNull.Value
                    });

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }




        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            string query = "SELECT * FROM Menu";

            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product
                        {
                            ProductId = Convert.ToInt32(reader["productID"]),
                            ProductImage = reader["productImage"] as byte[],
                            ProductName = reader["productName"].ToString().Trim(),
                            Category = reader["category"].ToString().Trim(),
                            Option1 = reader["option1"].ToString().Trim(),
                            Price1 = (decimal)reader["price1"],

                            Option2 = reader["option2"] == DBNull.Value ? null : reader["option2"].ToString().Trim(),
                            Price2 = reader["price2"] == DBNull.Value ? null : (decimal?)reader["price2"],
                            Option3 = reader["option3"] == DBNull.Value ? null : reader["option3"].ToString().Trim(),
                            Price3 = reader["price3"] == DBNull.Value ? null : (decimal?)reader["price3"],
                            Option4 = reader["option4"] == DBNull.Value ? null : reader["option4"].ToString().Trim(),
                            Price4 = reader["price4"] == DBNull.Value ? null : (decimal?)reader["price4"],

                            Description = reader["description"] == DBNull.Value ? null : reader["description"].ToString().Trim()
                        };

                        products.Add(product);
                    }
                }
                sqlConnection.Close();
            }

            return products;
        }



        public bool UpdateProduct(Product updatedProduct)
        {
            string query = @"UPDATE Menu SET 
                        category = @Category,
                        option1 = @Option1,
                        price1 = @Price1,
                        option2 = @Option2,
                        price2 = @Price2,
                        option3 = @Option3,
                        price3 = @Price3,
                        option4 = @Option4,
                        price4 = @Price4,
                        description = @Description,
                        productImage = @ProductImage
                     WHERE productName = @ProductName";

            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@ProductName", updatedProduct.ProductName);
                cmd.Parameters.AddWithValue("@Category", updatedProduct.Category);
                cmd.Parameters.AddWithValue("@Option1", updatedProduct.Option1);
                cmd.Parameters.AddWithValue("@Price1", updatedProduct.Price1);
                cmd.Parameters.AddWithValue("@Option2", (object)updatedProduct.Option2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Price2", (object)updatedProduct.Price2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Option3", (object)updatedProduct.Option3 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Price3", (object)updatedProduct.Price3 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Option4", (object)updatedProduct.Option4 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Price4", (object)updatedProduct.Price4 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", (object)updatedProduct.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ProductImage", (object)updatedProduct.ProductImage ?? DBNull.Value);

                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                return result > 0;
            }
        }


        public bool DeleteProduct(string productName)
        {
            string query = "DELETE FROM Menu WHERE productName = @ProductName";

            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@ProductName", productName);

                sqlConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                return rowsAffected > 0;
            }
        }

        public List<Product> SearchProduct(string searchName)
        {
            var products = new List<Product>();
            string query = "SELECT * FROM Menu WHERE LOWER(productName) LIKE @SearchTerm";

            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@SearchTerm", $"%{searchName.ToLower()}%");
                sqlConnection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product
                        {
                            ProductId = Convert.ToInt32(reader["productID"]),
                            ProductImage = reader["productImage"] as byte[],
                            ProductName = reader["productName"].ToString().Trim(),
                            Category = reader["category"].ToString().Trim(),
                            Option1 = reader["option1"].ToString().Trim(),
                            Price1 = (decimal)reader["price1"],
                            Option2 = reader["option2"] == DBNull.Value ? null : reader["option2"].ToString().Trim(),
                            Price2 = reader["price2"] == DBNull.Value ? null : (decimal?)reader["price2"],
                            Option3 = reader["option3"] == DBNull.Value ? null : reader["option3"].ToString().Trim(),
                            Price3 = reader["price3"] == DBNull.Value ? null : (decimal?)reader["price3"],
                            Option4 = reader["option4"] == DBNull.Value ? null : reader["option4"].ToString().Trim(),
                            Price4 = reader["price4"] == DBNull.Value ? null : (decimal?)reader["price4"],
                            Description = reader["description"] == DBNull.Value ? null : reader["description"].ToString().Trim()
                        };

                        products.Add(product);
                    }
                }

                sqlConnection.Close();
            }

            return products;
        }



        public List<Product> GetProductsByCategory(string category)
        {
            var products = new List<Product>();
            string query = "SELECT * FROM Menu WHERE category = @Category";

            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@Category", category);
                sqlConnection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product
                        {
                            ProductId = Convert.ToInt32(reader["productID"]),
                            ProductImage = reader["productImage"] as byte[],
                            ProductName = reader["productName"].ToString().Trim(),
                            Category = reader["category"].ToString().Trim(),
                            Option1 = reader["option1"].ToString().Trim(),
                            Price1 = (decimal)reader["price1"],
                           
                        };
                        products.Add(product);
                    }
                }

                sqlConnection.Close();
            }

            return products;
        }


        public bool AddToCartProduct(Cart cart)
        {
            string query = @"INSERT INTO CustomerCart 
                     (productID, userID, selectedOption, unitPrice, quantity, totalPrice, dateAdded, instructions, status)
                     VALUES  
                     (@ProductId, @UserId, @SelectedOption, @UnitPrice, @Quantity, @TotalPrice, @DateAdded, @Instructions, @Status)";

            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@ProductId", cart.ProductID);
                cmd.Parameters.AddWithValue("@UserId", cart.UserID);
                cmd.Parameters.AddWithValue("@SelectedOption", cart.SelectedOption);
                cmd.Parameters.AddWithValue("@UnitPrice", cart.UnitPrice);
                cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
                cmd.Parameters.AddWithValue("@TotalPrice", cart.TotalPrice);
                cmd.Parameters.AddWithValue("@DateAdded", cart.Date);
                cmd.Parameters.AddWithValue("@Instructions", cart.Instructions);
                cmd.Parameters.AddWithValue("@Status", cart.Status);

                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                return result > 0;
            }
        }

        public List<Cart> GetCartItems(int userId)
        {
            var items = new List<Cart>();
            string query = @"
        SELECT c.cartID, c.productID, c.userID, c.selectedOption, c.unitPrice, 
       c.quantity, c.totalPrice, c.dateAdded, c.instructions, c.status,
       m.productName, m.productImage
        FROM CustomerCart c
        INNER JOIN Menu m ON c.productID = m.productID
        WHERE c.userID = @UserId AND c.status = 'Pending'";

            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                sqlConnection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    items.Add(new Cart
                    {
                        CartID = (int)reader["cartID"],
                        ProductID = (int)reader["productID"],
                        UserID = (int)reader["userID"],
                        SelectedOption = reader["selectedOption"].ToString(),
                        UnitPrice = (decimal)reader["unitPrice"],
                        Quantity = (int)reader["quantity"],
                        TotalPrice = (decimal)reader["totalPrice"],
                        Date = Convert.ToDateTime(reader["dateAdded"]),
                        Instructions = reader["instructions"].ToString(),
                        Status = reader["status"].ToString(),

                        
                        ProductName = reader["productName"].ToString(),
                        ProductImage = reader["productImage"] as byte[]
                    });
                }

                sqlConnection.Close();
            }

            return items;
        }

        public bool UpdateCartItem(Cart cart)
        {
            string query = @"UPDATE CustomerCart SET quantity = @Quantity, totalPrice = @TotalPrice 
                     WHERE userID = @UserId AND productID = @ProductId AND selectedOption = @SelectedOption";

            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
                cmd.Parameters.AddWithValue("@TotalPrice", cart.TotalPrice);
                cmd.Parameters.AddWithValue("@UserId", cart.UserID);
                cmd.Parameters.AddWithValue("@ProductId", cart.ProductID);
                cmd.Parameters.AddWithValue("@SelectedOption", cart.SelectedOption);

                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                return result > 0;
            }
        }

        public bool DeleteCartItem(int cartId)
        {
            string query = "DELETE FROM CustomerCart WHERE cartID = @CartID";

            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@CartID", cartId);

                sqlConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                return rowsAffected > 0;
            }
        }
        public bool SaveOrder(int userId, List<Cart> cartItems, out int newOrderId)
        {
            newOrderId = 0;
            decimal grandTotal = cartItems.Sum(c => c.TotalPrice);

            string insertOrder = "INSERT INTO Orders (userID, orderDate, totalAmount, status) OUTPUT INSERTED.orderID VALUES (@UserID, @Date, @Total, @Status)";
            string insertDetail = @"INSERT INTO OrderDetails (orderID, productID, selectedOption, unitPrice, quantity, totalPrice, instructions) 
            VALUES (@OrderID, @ProductID, @Option, @UnitPrice, @Qty, @TotalPrice, @Instructions)";

            SqlTransaction transaction = null;

            try
            {
                sqlConnection.Open();
                transaction = sqlConnection.BeginTransaction();

                using (SqlCommand cmdOrder = new SqlCommand(insertOrder, sqlConnection, transaction))
                {
                    cmdOrder.Parameters.AddWithValue("@UserID", userId);
                    cmdOrder.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmdOrder.Parameters.AddWithValue("@Total", grandTotal);
                    cmdOrder.Parameters.AddWithValue("@Status", "Pending");


                    newOrderId = (int)cmdOrder.ExecuteScalar(); // Get inserted order ID
                }

                foreach (var item in cartItems)
                {
                    using (SqlCommand cmdDetail = new SqlCommand(insertDetail, sqlConnection, transaction))
                    {
                        cmdDetail.Parameters.AddWithValue("@OrderID", newOrderId);
                        cmdDetail.Parameters.AddWithValue("@ProductID", item.ProductID);
                        cmdDetail.Parameters.AddWithValue("@Option", item.SelectedOption);
                        cmdDetail.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                        cmdDetail.Parameters.AddWithValue("@Qty", item.Quantity);
                        cmdDetail.Parameters.AddWithValue("@TotalPrice", item.TotalPrice);
                        cmdDetail.Parameters.AddWithValue("@Instructions", item.Instructions ?? "");

                        cmdDetail.ExecuteNonQuery();
                    }
                }

                // Optionally mark cart items as "CheckedOut"
                string updateCartStatus = "UPDATE CustomerCart SET status = 'CheckedOut' WHERE userID = @UserID AND status = 'Pending'";
                using (SqlCommand cmdUpdate = new SqlCommand(updateCartStatus, sqlConnection, transaction))
                {
                    cmdUpdate.Parameters.AddWithValue("@UserID", userId);
                    cmdUpdate.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
              
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool AddToFavorites(int userId, int productId)
        {
            string query = @"INSERT INTO Favorites (userID, productID) VALUES (@UserID, @ProductID)";
            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                return result > 0;
            }
        }

        public bool RemoveFromFavorites(int userId, int productId)
        {
            string query = @"DELETE FROM Favorites WHERE userID = @UserID AND productID = @ProductID";
            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                return result > 0;
            }
        }

        public bool IsFavorite(int userId, int productId)
        {
            string query = "SELECT COUNT(*) FROM Favorites WHERE UserID = @UserID AND ProductID = @ProductID";

            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                sqlConnection.Open();
                int count = (int)cmd.ExecuteScalar();
                sqlConnection.Close();

                return count > 0;
            }
        }


        public List<DbOrder> GetAllPendingOrders()
        {
            var orders = new List<DbOrder>();
            string query = "SELECT * FROM Orders WHERE status = 'Pending'";

            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    orders.Add(new DbOrder
                    {
                        OrderID = (int)reader["orderID"],
                        UserID = (int)reader["userID"],
                        OrderDate = (DateTime)reader["orderDate"],
                        TotalAmount = (decimal)reader["totalAmount"],
                        Status = reader["status"].ToString()
                    });
                }

                sqlConnection.Close();
            }

            return orders;
        }



        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            var details = new List<OrderDetail>();
            string query = @"
            SELECT d.detailID, d.orderID, d.productID, d.selectedOption, d.unitPrice, d.quantity, d.totalPrice, d.instructions, m.productName
            FROM OrderDetails d
            JOIN Menu m ON d.productID = m.productID
            WHERE d.orderID = @OrderID";

            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                sqlConnection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    details.Add(new OrderDetail
                    {
                        ProductID = (int)reader["productID"],
                        ProductName = reader["productName"].ToString(),
                        SelectedOption = reader["selectedOption"].ToString(),
                        UnitPrice = (decimal)reader["unitPrice"],
                        Quantity = (int)reader["quantity"],
                        Instructions = reader["instructions"]?.ToString() ?? ""
                    });
                }

                sqlConnection.Close();
            }

            return details;
        }

        public CustomerAccount GetCustomerById(int userId)
        {
            CustomerAccount customer = null;
            string query = "SELECT * FROM UserAccounts WHERE userID = @UserID";

            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                sqlConnection.Open();
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    customer = new CustomerAccount
                    {
                        UserID = (int)reader["userID"],
                        Name = reader["Name"].ToString(),
                       
                    };
                }

                sqlConnection.Close();
            }

            return customer;
        }


        public bool MarkOrderAsComplete(int orderId)
        {
            string query = @"
        UPDATE Orders 
        SET status = 'Completed' 
        WHERE orderID = @OrderID AND status = 'Pending'";

            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@OrderID", orderId);

                sqlConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                return rowsAffected > 0;
            }
        }

        public bool MarkOrderAsCancelled(int orderId)
        {
            string query = "UPDATE Orders SET status = 'Cancelled' WHERE orderID = @OrderID";

            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return result > 0;
            }
        }


        public List<DbOrder> GetAllCompletedOrders()
        {
            List<DbOrder> orders = new List<DbOrder>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            SELECT OrderID, UserID, OrderDate, TotalAmount, Status
            FROM Orders
            WHERE Status = 'Completed'";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    orders.Add(new DbOrder
                    {
                        OrderID = reader.GetInt32(0),
                        UserID = reader.GetInt32(1),
                        OrderDate = reader.GetDateTime(2),
                        TotalAmount = reader.GetDecimal(3),
                        Status = reader.GetString(4)
                    });
                }
            }

            return orders;
        }
















       
    }
}
