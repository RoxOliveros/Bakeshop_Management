using Bakeshop_Common;
using BakeshopManagement.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bakeshop_DesktopApp
{
    public partial class SharedFunction : Form
    {
        protected BakeshopProcess process = new BakeshopProcess();
        protected FlowLayoutPanel flowLayoutPanelProducts;
        protected TextBox txtSearch;

        protected Color _originalColor = Color.FromArgb(254, 218, 188);
        protected Color _activeColor = Color.FromArgb(229, 152, 155);
        protected Button _activeButton = null;
        // Protected: I don’t want external classes to use these,
        // but I do want my child forms (Admin_Menu, User_Menu) to use them.

        public SharedFunction()
        {
            InitializeComponent();
        }
        protected void ChangeButtonColor(Button btn)
        {
            if (_activeButton != null && _activeButton != btn)
                _activeButton.BackColor = _originalColor;

            btn.BackColor = _activeColor;
            _activeButton = btn;
        }

        protected void ReloadProducts()
        {
            txtSearch.Clear();
            LoadProducts();
        }

        protected void SearchProduct()
        {
            if (txtSearch == null)
            {
                MessageBox.Show("Search textbox is not initialized.");
                return;
            }

            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please enter a product name.", "Empty Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var results = process?.SearchProduct(searchTerm);

            if (flowLayoutPanelProducts == null)
            {
                MessageBox.Show("Product panel not initialized.");
                return;
            }

            flowLayoutPanelProducts.Controls.Clear();

            if (results != null && results.Count > 0 && results[0] != null)
            {
                DisplayProduct(results[0]); // Only show one result
            }
            else
            {
                MessageBox.Show("No product found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        protected void LoadCategory(string category)
        {
            var products = category == "All" ? process.GetAllProducts() : process.GetProductsByCategory(category);
            flowLayoutPanelProducts.Controls.Clear();

            foreach (var product in products)
            {
                DisplayProduct(product);
            }
        }

        internal void LoadProducts()
        {
            var products = process.GetAllProducts() ?? new List<Product>();
            flowLayoutPanelProducts.Controls.Clear();

            foreach (var product in products)
            {
                DisplayProduct(product);
            }
        }

        protected void Logout()
        {

            DialogResult result = MessageBox.Show(
           "Are you sure you want to logout?",
           "Confirm Logout",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Assuming this is inside your Main or Dashboard form
                this.Hide(); // Or this.Close(); if you're OK closing it

                Login loginForm = new Login(process); // Replace with your actual login form class name
                loginForm.Show();
            }

        }

        protected virtual void DisplayProduct(Product product)
        {
            // to be overridden in Admin_Menu and User_Menu
        }

        private void SharedFunction_Load(object sender, EventArgs e)
        {

        }
    }
}