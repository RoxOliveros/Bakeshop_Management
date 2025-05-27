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

        static string connectionString = "Data Source=SQLEXPRESS;Initial Catalog=DBBakeshop;Integrated Security=True;TrustServerCertificate=True;";
        static SqlConnection sqlConnection;

        public DBBakeshopDataSource()
        {
            sqlConnection = new SqlConnection(connectionString);
            Accounts = GetCustomerAccounts(); // Load accounts at start
        }

        public List<CustomerAccount> GetCustomerAccounts()
        {
            var customerAccounts = new List<CustomerAccount>();

            string query = "SELECT * FROM Accounts";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();

            SqlDataReader reader = command.ExecuteReader();
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

            reader.Close();
            sqlConnection.Close();

            return customerAccounts;
        }

        public bool ValidateCustomer(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM Accounts WHERE Username = @Username AND Password = @Password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }


        public CustomerAccount GetCustomer(string username)
        {
            string query = "SELECT * FROM Accounts WHERE Username = '" + username + "'";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();

            SqlDataReader reader = command.ExecuteReader();
            CustomerAccount account = null;

            if (reader.Read())
            {
                account = new CustomerAccount
                {
                    Name = reader["Name"].ToString(),
                    Username = reader["Username"].ToString(),
                    Password = reader["Password"].ToString(),
                    Email = reader["Email"].ToString()
                };
            }

            reader.Close();
            sqlConnection.Close();
            return account;
        }

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
        }

        public List<Order> GetOrders()
        {
            return Orders;
        }
    }
}