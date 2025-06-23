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
    public partial class CheckOutCard : UserControl
    {
        private Cart cartItem;

        public event Action<Cart> QuantityChanged;
        public event Action<Cart> CartDeleted;


        public CheckOutCard()
        {
            InitializeComponent();
        }

        public void LoadCartItem(Cart cart)
        {
            this.cartItem = cart;

            lblProduct.Text = cart.ProductName;
            lblVariation.Text = cart.SelectedOption;
            lblQuantity.Text = cart.Quantity.ToString();
            lblTotalPrice.Text = $"₱{cart.TotalPrice:0.00}";

            if (cart.ProductImage != null)
            {
                using (var ms = new MemoryStream(cart.ProductImage))
                {
                    picCart.Image = Image.FromStream(ms);
                    picCart.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }



        private void UpdateTotal()
        {
            cartItem.TotalPrice = cartItem.UnitPrice * cartItem.Quantity;
            lblQuantity.Text = cartItem.Quantity.ToString();
            lblTotalPrice.Text = $"₱{cartItem.TotalPrice:0.00}";

            QuantityChanged?.Invoke(cartItem); // Notify main form

        }

        public Cart GetUpdatedCartItem() => cartItem;

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
                UpdateTotal();
            }
            else
            {
                // Quantity is 1, prompt delete
                var confirm = MessageBox.Show("Remove this item from cart?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    CartDeleted?.Invoke(cartItem); // Let User_Menu handle removal from DB and UI
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cartItem.Quantity++;
            UpdateTotal();
        }
    }
}
