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

        public void LoadOrderDetails(Order order, List<OrderDetail> orderItems, CustomerAccount customer)
        {
            lblOrderID.Text = $"Order #{order.OrderId}";
            lblCustomerName.Text = $" 👤   {customer.Name}";
            lblDateOfOrder.Text = $"🗓️{ order.Timestamp.ToString("MMM dd, yyyy hh:mm tt")}";
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
    }
}
