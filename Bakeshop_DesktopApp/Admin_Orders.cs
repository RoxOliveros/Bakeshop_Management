using Bakeshop_Common;
using BakeshopManagement.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bakeshop_DesktopApp
{
    public partial class Admin_Orders : SharedFunction
    {
        private BakeshopProcess process;
        public Admin_Orders()
        {
            InitializeComponent();

            this.process = new BakeshopProcess();
            LoadPendingOrders();
        }

        private void LoadPendingOrders(string sortOption = "Newest First")
        {
            flowLayoutOrders.Controls.Clear();


            List<DbOrder> pendingOrders = process.GetAllPendingOrders()
                                          .Where(o => o.Status == "Pending")
                                          .ToList();

            // Sorting logic
            switch (sortOption)
            {
                case "Oldest First":
                    pendingOrders = pendingOrders.OrderBy(o => o.OrderDate).ToList();
                    break;
                case "Total Amount (High to Low)":
                    pendingOrders = pendingOrders.OrderByDescending(o => o.TotalAmount).ToList();
                    break;
                case "Total Amount (Low to High)":
                    pendingOrders = pendingOrders.OrderBy(o => o.TotalAmount).ToList();
                    break;
                default:
                    pendingOrders = pendingOrders.OrderByDescending(o => o.OrderDate).ToList();
                    break;
            }


            foreach (var order in pendingOrders)
            {
                List<OrderDetail> details = process.GetOrderDetails(order.OrderID);
                CustomerAccount customer = process.GetCustomerById(order.UserID);

                var card = new PendingOrdersCard();
                card.LoadOrderDetails(order, details, customer);
                card.OrderMarkedComplete += OnOrderMarkedComplete;
                card.OrderMarkedCancelled += OnOrderMarkedCancelled;

                card.Tag = order.OrderID;
                flowLayoutOrders.Controls.Add(card);
            }

        }

        private void OnOrderMarkedComplete(int orderId)
        {
            bool success = process.MarkOrderAsComplete(orderId);
            if (success)
            {
                MessageBox.Show($"Order #{orderId} marked as COMPLETE.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Find and remove the card with the matching orderID
                var cardToRemove = flowLayoutOrders.Controls
                    .OfType<PendingOrdersCard>()
                    .FirstOrDefault(c => c.Tag != null && (int)c.Tag == orderId);

                if (cardToRemove != null)
                {
                    flowLayoutOrders.Controls.Remove(cardToRemove);
                    cardToRemove.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Failed to update order status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnOrderMarkedCancelled(int orderId)
        {
            bool success = process.MarkOrderAsCancelled(orderId);
            if (success)
            {
                MessageBox.Show($"Order #{orderId} has been cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var cardToRemove = flowLayoutOrders.Controls
                    .OfType<PendingOrdersCard>()
                    .FirstOrDefault(c => c.Tag != null && (int)c.Tag == orderId);

                if (cardToRemove != null)
                {
                    flowLayoutOrders.Controls.Remove(cardToRemove);
                    cardToRemove.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Failed to cancel the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Admin_Orders_Load(object sender, EventArgs e)
        {
            LoadPendingOrders(cmbSortOrders.SelectedItem?.ToString() ?? "Newest First");

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }


        private void cmbSortOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSort = cmbSortOrders.SelectedItem.ToString();
            LoadPendingOrders(selectedSort);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Admin_Menu menuForm = new Admin_Menu();
            menuForm.Show();
            this.Hide();
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

                
                salesChartForm.StartPosition = FormStartPosition.CenterScreen;
                salesChartForm.TopMost = true;

                salesChartForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying sales chart: " + ex.Message);
            }
        }
    }
}
