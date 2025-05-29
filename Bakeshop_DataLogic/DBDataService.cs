using Bakeshop_Common;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Bakeshop_DataLogic
{
    public class DBBakeshopDataSource : IBakeshopDataService
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DBBakeshop;Integrated Security=True;TrustServerCertificate=True;";
        private List<Order> Orders = new List<Order>();
        private List<string> Menu = new List<string>();
        private List<decimal> Prices = new List<decimal>();

        public DBBakeshopDataSource()
        {
            LoadCustomerAccounts(); // Loads into memory if needed
        }

        private void LoadCustomerAccounts()
        {
            try
            {
                Accounts = GetCustomerAccounts(); // Fills Accounts list from DB
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to load customer accounts: " + ex.Message);
            }
        }

        private List<CustomerAccount> Accounts = new List<CustomerAccount>();

        public List<CustomerAccount> GetCustomerAccounts()
        {
            var customerAccounts = new List<CustomerAccount>();

            using (var sqlConnection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("SELECT * FROM Accounts", sqlConnection))
            {
                sqlConnection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customerAccounts.Add(new CustomerAccount
                        {
                            Name = reader["Name"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Email = reader["Email"].ToString()
                        });
                    }
                }
            }

            return customerAccounts;
        }

        public bool ValidateCustomer(string username, string password)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("SELECT COUNT(*) FROM Accounts WHERE Username = @Username AND Password = @Password", sqlConnection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                sqlConnection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public CustomerAccount GetCustomer(string username)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("SELECT * FROM Accounts WHERE Username = @Username", sqlConnection))
            {
                command.Parameters.AddWithValue("@Username", username);

                sqlConnection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new CustomerAccount
                        {
                            Name = reader["Name"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Email = reader["Email"].ToString()
                        };
                    }
                }
            }

            return null;
        }

        // Other in-memory menu/product operations (for now)
        public void AddProduct(string product, decimal price)
        {
            Menu.Add(product);
            Prices.Add(price);
        }

        public bool UpdateProduct(string name, decimal newPrice)
        {
            int index = Menu.IndexOf(name);
            if (index != -1)
            {
                Prices[index] = newPrice;
                return true;
            }
            return false;
        }

        public bool DeleteProduct(string product)
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

        public decimal? SearchProduct(string product)
        {
            int index = Menu.IndexOf(product);
            if (index != -1)
                return Prices[index];

            return null;
        }

        public List<(string Name, decimal Price)> GetMenu()
        {
            var menuList = new List<(string, decimal)>();
            for (int i = 0; i < Menu.Count; i++)
            {
                menuList.Add((Menu[i], Prices[i]));
            }
            return menuList;
        }

        public void SaveOrder(Order order)
        {
            Orders.Add(order); 

        public List<Order> GetOrders()
        {
            return Orders;
        }
    }
}
