using Bakeshop_Common;
using BakeshopManagement.Business;
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

namespace Bakeshop_DesktopApp
{
    public partial class User_Menu : SharedFunction
    {
        private CustomerAccount customer;
        private BakeshopProcess process;



        public User_Menu(BakeshopProcess process, CustomerAccount customer)
        {
            InitializeComponent();

            this.customer = customer;
            this.process = process;

            flowLayoutPanelProducts = flowLayoutPanelUser;
            txtSearch = txtSearchUser;

            LoadProducts();
            LoadCheckoutArea();
        }


        private void User_Menu_Load(object sender, EventArgs e)
        {

        }

        protected override void DisplayProduct(Product product)
        {
            addToCartCard card = new addToCartCard();
            card.SetUserId(customer.UserID);     
            card.SetProcess(process);            
            card.SetProduct(product);
            flowLayoutPanelProducts.Controls.Add(card);

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
            LoadCategory("🥤 Coffee");

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            SearchProduct();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            ReloadProducts();
            LoadCheckoutArea();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();

        }

        private void LoadCheckoutArea()
        {
            flowLayoutCheckout.Controls.Clear();

            List<Cart> cartItems = process.GetCartItems(customer.UserID);

            decimal grandTotal = 0;

            foreach (var cart in cartItems)
            {
                var card = new CheckOutCard();
                card.LoadCartItem(cart);
                card.QuantityChanged += OnQuantityChanged;
                card.CartDeleted += OnCartDeleted;
                flowLayoutCheckout.Controls.Add(card);

                grandTotal += cart.TotalPrice; // Accumulate total
            }

            lblTotalAmount.Text = $"₱{grandTotal:0.00}"; //  Update label

        }

        private void OnCartDeleted(Cart cart)
        {
            bool success = process.DeleteCartItem(cart.CartID); // Pass only cartID

            Debug.WriteLine($"Attempting to delete CartID: {cart.CartID}"); // <--- ADD THIS

            if (success)
            {
                LoadCheckoutArea(); // Refresh the display
            }
            else
            {
                MessageBox.Show("Failed to delete cart item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void OnQuantityChanged(Cart updatedItem)
        {
            process.UpdateCartItem(updatedItem);
            LoadCheckoutArea();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            var cartItems = process.GetCartItems(customer.UserID);

            if (cartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool success = process.SaveOrder (customer.UserID, cartItems, out int orderId);
            if (success)
            {
                MessageBox.Show($"Order #{orderId} placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCheckoutArea(); // Refresh cart area
            }
            else
            {
                MessageBox.Show("Failed to process checkout.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
