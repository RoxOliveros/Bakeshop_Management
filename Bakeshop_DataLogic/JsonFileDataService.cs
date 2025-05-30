﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Bakeshop_Common;

namespace Bakeshop_DataLogic
{
    public class JsonFileBakeshopDataSource : IBakeshopDataService
    {
        private string accountsFile = "accounts.json";
        private string menuFile = "menu.json";
        private string orderFile = "orders.json";

        private List<CustomerAccount> Accounts = new List<CustomerAccount>();
        private List<(string Name, decimal Price)> Menu = new List<(string, decimal)>();
        private List<Order> Orders = new List<Order>();

        public JsonFileBakeshopDataSource()
        {
            LoadAccounts();
            LoadMenu();
            LoadOrders();
        }

        // Load/Save Accounts
        private void LoadAccounts()
        {
            if (File.Exists(accountsFile))
            {
                Accounts = JsonSerializer.Deserialize<List<CustomerAccount>>(File.ReadAllText(accountsFile)) ?? new List<CustomerAccount>();
            }
        }

        private void SaveAccounts()
        {
            File.WriteAllText(accountsFile, JsonSerializer.Serialize(Accounts, new JsonSerializerOptions { WriteIndented = true }));
        }

        // Load/Save Menu
        private void LoadMenu()
        {
            if (File.Exists(menuFile))
            {
                var menuItems = JsonSerializer.Deserialize<List<MenuItem>>(File.ReadAllText(menuFile));
                if (menuItems != null)
                {
                    Menu = menuItems.Select(m => (m.Name, m.Price)).ToList();
                }
            }
        }

        private void SaveMenu()
        {
            var menuItems = Menu.Select(m => new MenuItem { Name = m.Name, Price = m.Price }).ToList();
            File.WriteAllText(menuFile, JsonSerializer.Serialize(menuItems, new JsonSerializerOptions { WriteIndented = true }));
        }

        // Load/Save Orders
        private void LoadOrders()
        {
            if (File.Exists(orderFile))
            {
                Orders = JsonSerializer.Deserialize<List<Order>>(File.ReadAllText(orderFile)) ?? new List<Order>();
            }
        }

        private void SaveOrders()
        {
            File.WriteAllText(orderFile, JsonSerializer.Serialize(Orders, new JsonSerializerOptions { WriteIndented = true }));
        }

        public void AddProduct(string product, decimal price)
        {
            Menu.Add((product, price));
            SaveMenu();
        }

        public bool UpdateProduct(string name, decimal newPrice)
        {
            int index = Menu.FindIndex(m => m.Name == name);
            if (index != -1)
            {
                Menu[index] = (name, newPrice);
                SaveMenu();
                return true;
            }
            return false;
        }

        public bool DeleteProduct(string product)
        {
            int index = Menu.FindIndex(m => m.Name == product);
            if (index != -1)
            {
                Menu.RemoveAt(index);
                SaveMenu();
                return true;
            }
            return false;
        }

        public decimal? SearchProduct(string product)
        {
            var match = Menu.FirstOrDefault(m => m.Name == product);
            return match != default ? match.Price : (decimal?)null;
        }

        public List<(string Name, decimal Price)> GetMenu()
        {
            return new List<(string, decimal)>(Menu);
        }

        public bool ValidateCustomer(string username, string password)
        {
            return Accounts.Any(a => a.Username == username && a.Password == password);
        }

        public CustomerAccount GetCustomer(string username)
        {
            return Accounts.FirstOrDefault(a => a.Username == username);
        }

        public void SaveOrder(Order order)
        {
            Orders.Add(order);
            SaveOrders();
        }

        public List<Order> GetOrders()
        {
            return Orders;
        }

        private class MenuItem
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
    }
}
