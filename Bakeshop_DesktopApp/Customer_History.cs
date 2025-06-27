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
    public partial class Customer_History : SharedFunction
    {
        private CustomerAccount customer;
        private BakeshopProcess process;

        public Customer_History(BakeshopProcess process, CustomerAccount customer)
        {
            InitializeComponent();

            this.process = process;
            this.customer = customer;
        }

        private void Customer_History_Load(object sender, EventArgs e)
        {
            LoadRecentOrders();
        }



        private void btnOrder_Click_1(object sender, EventArgs e)
        {
            Customer_Menu menu = new Customer_Menu(process, customer);
            menu.Show(this);
            this.Hide();
        }

        private void LoadRecentOrders()
        {
            var orders = process.GetAllPendingOrders()
                         .Where(o => o.UserID == customer.UserID)
                         .OrderByDescending(o => o.OrderDate)
                         .ToList();

            DisplayOrders(orders);
        }

        private void LoadCompleteOrder()
        {
            var orders = process.GetAllCompletedOrders()
                           .Where(o => o.UserID == customer.UserID)
                           .OrderByDescending(o => o.OrderDate)
                           .ToList();

            DisplayOrders(orders);
        }


        private void LoadFavorite()
        {

            var allProducts = process.GetAllProducts();
            var favoriteProducts = allProducts
                .Where(p => process.IsFavorite(customer.UserID, p.ProductId)) 
                .ToList();

            flowLayoutHistory.Controls.Clear();

            foreach (var product in favoriteProducts)
            {
                var card = new addToCartCard();        
                card.SetUserId(customer.UserID);       
                card.SetProcess(process);              
                card.SetProduct(product);               
                flowLayoutHistory.Controls.Add(card);
            }

            if (favoriteProducts.Count == 0)
            {
                MessageBox.Show("You have no favorite products yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DisplayOrders(List<DbOrder> orders)
        {
            flowLayoutHistory.Controls.Clear();

            foreach (var order in orders)
            {
                var orderDetails = process.GetOrderDetails(order.OrderID);

                var card = new HistoryCard();
                card.LoadOrder(order, orderDetails);
                flowLayoutHistory.Controls.Add(card);
            }
        }


        private void btnPending_Click(object sender, EventArgs e)
        {
            ChangeButtonColor(sender as Button);
            LoadRecentOrders();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            ChangeButtonColor(sender as Button);
            LoadCompleteOrder();
        }

        private void btnFavorite_Click(object sender, EventArgs e)
        {

            ChangeButtonColor(sender as Button);
            LoadFavorite();
        }
    }
}
