using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Bakeshop_Common;
using BakeshopManagement.Business;
using Bakeshop_SalesReport;



namespace Bakeshop_DesktopApp
{
    public partial class Admin_Menu : SharedFunction
    {

        public Admin_Menu()
        {
            InitializeComponent();
            flowLayoutPanelProducts = flowLayoutPanelAdmin; 
            txtSearch = txtSearchAdmin;
            LoadProducts();


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Add_Product addProd = new Add_Product();
            addProd.Show();
        }

        protected override void DisplayProduct(Product product)
        {
            if (flowLayoutPanelAdmin == null)
            {
                MessageBox.Show("Error: flowLayoutPanelAdmin is not initialized.");
                return;
            }

            ProductCard card = new ProductCard();
            card.SetProduct(product);
            card.DeleteClicked += OnProductDeleteClicked;
            card.EditClicked += OnProductEditClicked;
            flowLayoutPanelProducts.Controls.Add(card);
        }

        private void OnProductDeleteClicked(object sender, Product product)
        {
            var confirm = MessageBox.Show($"Are you sure you want to delete '{product.ProductName}'?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (process.DeleteProduct(product.ProductName))
                {
                    MessageBox.Show("Product deleted successfully.");
                    LoadProducts(); // Refresh UI
                }
                else
                {
                    MessageBox.Show("Failed to delete product.");
                }
            }
        }

        private void OnProductEditClicked(object sender, Product product)
        {
            Add_Product editForm = new Add_Product(product);
            editForm.ProductUpdated += (s, e) => LoadProducts(); // refresh after edit
            editForm.ShowDialog();
        }



        private void btnAll_Click(object sender, EventArgs e)
        {

            ChangeButtonColor(sender as Button);
            LoadCategory("All");
        }

        private void btnCake_Click(object sender, EventArgs e)
        {
            ChangeButtonColor(sender as Button);
            LoadCategory("🍰 Cake");
        }

        private void btnBread_Click(object sender, EventArgs e)
        {
            ChangeButtonColor(sender as Button);
            LoadCategory("🍞 Bread");
        }

        private void btnPastry_Click(object sender, EventArgs e)
        {
            ChangeButtonColor(sender as Button);
            LoadCategory("🥧 Pastry");
        }

        private void btnCookie_Click(object sender, EventArgs e)
        {
            ChangeButtonColor(sender as Button);
            LoadCategory("🍪 Cookie");
        }

        private void btnCoffee_Click(object sender, EventArgs e)
        {
            ChangeButtonColor(sender as Button);
            LoadCategory("🥤 Beverage");
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {

            SearchProduct();

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            ReloadProducts();
        }



        private void btnOrder_Click(object sender, EventArgs e)
        {
            Admin_Orders orderForm = new Admin_Orders();
            orderForm.Show();
            this.Hide();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            Logout();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            try
            {
                BakeshopProcess process = new BakeshopProcess();
                List<DbOrder> completedOrders = process.GetAllCompletedOrders();

                if (completedOrders == null || completedOrders.Count == 0)
                {
                    MessageBox.Show("No completed sales found.");
                    return;
                }

                var salesChartForm = new Bakeshop_SalesReport.Admin_Sales(completedOrders);

                // These help make sure the form shows up
                salesChartForm.StartPosition = FormStartPosition.CenterScreen;
                salesChartForm.TopMost = true;

                salesChartForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying sales chart: " + ex.Message);
            }

        }

        private void txtSearchAdmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void Admin_Menu_Load(object sender, EventArgs e)
        {

        }
    }

}

