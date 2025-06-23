using System.Collections.Generic;
using System.Linq;

namespace Bakeshop_Common
{

    public class Product
    {
        public int ProductId { get; set; }
        public byte[] ProductImage { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Option1 { get; set; }
        public decimal Price1 { get; set; }
        public string Option2 { get; set; }
        public decimal? Price2 { get; set; }
        public string Option3 { get; set; }
        public decimal? Price3 { get; set; }
        public string Option4 { get; set; }
        public decimal? Price4 { get; set; }
        public string Description { get; set; }
       // public string PicturePath { get; set; }

    }

    public class Cart { 

        public int CartID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public string SelectedOption { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public string Instructions { get; set; }
        public string Status { get; set; }

        public string ProductName { get; set; }
        public byte[] ProductImage { get; set; }


    }

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
        public int  userId { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal TotalAmount => Items.Sum(item => item.Total);
        public string CustomerName { get; set; }  
        public System.DateTime Timestamp { get; set; }  

        public Order(List<OrderItem> items, string customerName)
        {
            OrderId = nextOrderId++;
            Items = items;
            CustomerName = customerName;
            Timestamp = System.DateTime.Now;
        }
    }

    public class OrderDetail
    {
        public int DetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; } 
        public string SelectedOption { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
        public string Instructions { get; set; } 
    }

    public class DbOrder
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }




    public class CustomerAccount
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}


