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
    public partial class Admin_Orders : Form
    {
        private BakeshopProcess process;
        public Admin_Orders()
        {
            InitializeComponent();

            this.process = new BakeshopProcess();
        }

//        private void LoadPendingOrders()
//        {
//            flowLayoutOrders.Controls.Clear(); // Optional: clear previous

            
//            List<Order> pendingOrders = process.GetAllPendingOrders(); 

//            foreach (var order in pendingOrders)
//            {
               
//                List<OrderDetail> details = process.GetOrderDetails(order.OrderID);
//                CustomerAccount customer = process.GetCustomerById(order.UserID);

                
//                var card = new PendingOrdersCard();
//                card.LoadOrderDetails(order, details, customer);

//                flowLayoutOrders.Controls.Add(card);
//            }
        
//}

        private void Admin_Orders_Load(object sender, EventArgs e)
        {

        }
    }
}
