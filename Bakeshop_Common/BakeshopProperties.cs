using System.Collections.Generic;
using System.Linq;

namespace Bakeshop_Common
{
    public class OrderItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total => UnitPrice * Quantity;
    }

    public class Order
    {
        private static int nextOrderId = 1;

        public int OrderId { get; private set; }
        public List<OrderItem> Items { get; set; }
        public decimal TotalAmount => Items.Sum(item => item.Total);

        public Order(List<OrderItem> items)
        {
            OrderId = nextOrderId++;
            Items = items;
        }
    }
}
