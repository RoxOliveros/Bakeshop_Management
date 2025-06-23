using Bakeshop_Common;
using BakeshopManagement.Business;
using Microsoft.VisualBasic.ApplicationServices;
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

    public partial class addToCartCard : UserControl
    {
        private BakeshopProcess process;


        public addToCartCard()
        {
            InitializeComponent();
        }

        private Product product;
        private int userId;

        public void SetUserId(int id)
        {
            userId = id;
        }

        public void SetProcess(BakeshopProcess p)
        {
            process = p;
        }



        public void SetProduct(Product product)
        {
            this.product = product;
            lblName.Text = product.ProductName;
            lblPrice.Text = $"₱ {product.Price1.ToString("0.00")}";
            pictureBox.Image = ByteArrayToImage(product.ProductImage);

            // Safe check before accessing database
            if (process != null && userId > 0)
            {
                try
                {
                    bool isFavorite = process.IsFavorite(userId, product.ProductId);
                    btnHeart.Visible = isFavorite;
                    btnUnheart.Visible = !isFavorite;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking favorites: " + ex.Message);
                    btnHeart.Visible = false;
                    btnUnheart.Visible = true;
                }
            }
            else
            {
                // default to unhearted if no user or process yet
                btnHeart.Visible = false;
                btnUnheart.Visible = true;
            }
        }


        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void btnUnheart_Click(object sender, EventArgs e)
        {
            bool added = process.AddToFavorites(userId, product.ProductId);

            if (added)
            {
                MessageBox.Show($"{product.ProductName} is added to favorite", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUnheart.Visible = false;
                btnHeart.Visible = true;
            }
            else
            {
                MessageBox.Show("Failed to add to favorites.");
            }

        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            if (product == null || userId == 0)
            {
                MessageBox.Show("User ID is not set. Cannot add to cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AddToCart cart = new AddToCart(process, userId);
            cart.LoadProduct(product, userId);
            cart.ShowDialog();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void addToCartCard_Load(object sender, EventArgs e)
        {

        }

        private void btnHeart_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Remove this product from favorites?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                bool removed = process.RemoveFromFavorites(userId, product.ProductId);

                if (removed)
                {
                    btnHeart.Visible = false;
                    btnUnheart.Visible = true;
                }
                else
                {
                    MessageBox.Show("Failed to remove from favorites.");
                }
            }
        }
    }
}
