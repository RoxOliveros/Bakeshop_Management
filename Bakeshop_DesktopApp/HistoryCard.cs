using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Bakeshop_Common;

namespace Bakeshop_DesktopApp
{
    public partial class HistoryCard : UserControl
    {
        public HistoryCard()
        {
            InitializeComponent();
        }

        public void LoadOrder(DbOrder order, List<OrderDetail> details)
        {

            lblOrderID.Text = $"Order #{order.OrderID}";
            StringBuilder sb = new StringBuilder();
            foreach (var item in details)
            {
                sb.AppendLine($"{item.Quantity} x {item.ProductName}");
            }
            lblOrderedItem.Text = sb.ToString().Trim();


            string dateFormatted = order.OrderDate.ToString("MMM dd, yyyy");
            string statusText = "";

            if (order.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase))
            {
                statusText = $"COMPLETED ON:\n {dateFormatted}";
            }
            else if (order.Status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
            {
                statusText = $"CANCELLED ON:\n {dateFormatted}";
            }
            else
            {
                statusText = $"STATUS: \n {order.Status.ToUpper()}";
            }

            lblStatus.Text = statusText;
            lblTotal.Text = $"TOTAL: ₱{order.TotalAmount:0.00}";
        }


        private void HistoryCard_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
