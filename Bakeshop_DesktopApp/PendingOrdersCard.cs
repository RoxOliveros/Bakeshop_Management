using Bakeshop_Common;
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
    public partial class PendingOrdersCard : UserControl
    {
        public PendingOrdersCard()
        {
            InitializeComponent();
        }

        private int _orderId;
        private string _orderStatus; // store status for validation

        public event Action<int> OrderMarkedComplete;
        public event Action<int> OrderMarkedCancelled;




        public void LoadOrderDetails(DbOrder order, List<OrderDetail> orderItems, CustomerAccount customer)
        {
            _orderId = order.OrderID;
            _orderStatus = order.Status; // e.g., "Pending"

            lblOrderID.Text = $"Order #{order.OrderID}";
            lblCustomerName.Text = $"👤 {customer.Name}";
            lblDateOfOrder.Text = $"🗓️ {order.OrderDate:MMM dd, yyyy hh:mm tt}";
            lblTotal.Text = $"TOTAL: ₱{order.TotalAmount:0.00}";

            StringBuilder sb = new StringBuilder();
            foreach (var item in orderItems)
            {
                sb.AppendLine($"• {item.ProductName} ({item.SelectedOption})");
                sb.AppendLine($"   - Qty: {item.Quantity}");
                if (!string.IsNullOrWhiteSpace(item.Instructions))
                    sb.AppendLine($"   - Instruction: {item.Instructions}");
            }

            lblOrderedItem.Text = sb.ToString();
        }


        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (_orderStatus != "Pending")
            {
                MessageBox.Show("Only pending orders can be marked as complete.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to mark this order as COMPLETE?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                OrderMarkedComplete?.Invoke(_orderId);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_orderStatus != "Pending")
            {
                MessageBox.Show("Only pending orders can be cancelled.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to CANCEL this order?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                OrderMarkedCancelled?.Invoke(_orderId);
            }
        }
    }
}
