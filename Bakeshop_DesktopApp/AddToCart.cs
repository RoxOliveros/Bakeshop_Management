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
    public partial class AddToCart : Form

    {
        private BakeshopProcess process;
        private Product selectedProduct;
        private int currentUserId;

        public AddToCart(BakeshopProcess processInstance, int userId)
        {
            InitializeComponent();
            this.process = processInstance;
            this.currentUserId = userId;
        }


        public void LoadProduct(Product product, int userId)
        {
            selectedProduct = product;
            currentUserId = userId;

            lblProductName.Text = product.ProductName;
            lblPrice.Text = $"₱{product.Price1:0.00}";
            txtDescription.Text = product.Description;

            if (product.ProductImage != null)
            {
                using (MemoryStream ms = new MemoryStream(product.ProductImage))
                {
                    pictureBoxCart.Image = Image.FromStream(ms);
                    pictureBoxCart.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            // Clear old radio buttons
            panelVariation.Controls.Clear();

            if (!string.IsNullOrWhiteSpace(product.Option1))
                AddVariation(product.Option1, product.Price1);

            if (!string.IsNullOrWhiteSpace(product.Option2))
                AddVariation(product.Option2, product.Price2.Value);

            if (!string.IsNullOrWhiteSpace(product.Option3))
                AddVariation(product.Option3, product.Price3.Value);

            if (!string.IsNullOrWhiteSpace(product.Option4))
                AddVariation(product.Option4, product.Price4.Value);
        }


        private void AddVariation(string optionName, decimal price)
        {
            Panel variationPanel = new Panel
            {
                Width = panelVariation.Width - 10,
                Height = 30,
                BackColor = Color.Transparent
            };

            RadioButton rb = new RadioButton
            {
                Text = optionName,
                AutoSize = true,
                Location = new Point(5, 5),
                Font = new Font("Century Gothic", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(153, 78, 36),
                Tag = new { Option = optionName, Price = price }
            };

            rb.CheckedChanged += (s, e) =>
            {
                if (rb.Checked)
                {
                    int quantity = int.Parse(lblQuantity.Text);
                    decimal total = price * quantity;
                    lblPrice.Text = $"₱{total:0.00}";
                }
            };

            Label lblOptionPrice = new Label
            {
                Text = $"₱{price:0.00}",
                AutoSize = true,
                Location = new Point(188, 6),
                Font = new Font("Century Gothic", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(153, 78, 36)
            };

            variationPanel.Controls.Add(rb);
            variationPanel.Controls.Add(lblOptionPrice);

            panelVariation.Controls.Add(variationPanel);
        }

        private void UpdateTotalPrice()
        {
            int quantity = int.Parse(lblQuantity.Text);
            decimal selectedPrice = 0;

            // Find the selected variation
            foreach (Control ctrl in panelVariation.Controls)
            {
                if (ctrl is Panel variationPanel)
                {
                    foreach (Control subCtrl in variationPanel.Controls)
                    {
                        if (subCtrl is RadioButton rb && rb.Checked)
                        {
                            // Get the price from the radio button's Tag
                            dynamic tag = rb.Tag;
                            selectedPrice = tag.Price;
                            break;
                        }
                    }
                }
            }

            decimal totalPrice = selectedPrice * quantity;
            lblPrice.Text = $"₱{totalPrice:0.00}";
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(lblQuantity.Text);
            quantity++;
            lblQuantity.Text = quantity.ToString();
            UpdateTotalPrice();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(lblQuantity.Text);
            if (quantity > 1)
            {
                quantity--;
                lblQuantity.Text = quantity.ToString();
                UpdateTotalPrice();
            }
        }

        private void btnAddtoCart_Click(object sender, EventArgs e)
        {


            string selectedOption = null;
            decimal unitPrice = 0;

            foreach (Control ctrl in panelVariation.Controls)
            {
                if (ctrl is Panel variationPanel)
                {
                    foreach (Control subCtrl in variationPanel.Controls)
                    {
                        if (subCtrl is RadioButton rb && rb.Checked)
                        {
                            dynamic tag = rb.Tag;
                            selectedOption = tag.Option;
                            unitPrice = tag.Price;
                            break;
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(selectedOption))
            {
                MessageBox.Show("Please select a variation.", "Missing Option", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantity = int.Parse(lblQuantity.Text);
            decimal total = unitPrice * quantity;


            Cart cartItem = new Cart
            {
                ProductID = selectedProduct.ProductId,
                UserID = currentUserId,
                SelectedOption = selectedOption,
                UnitPrice = unitPrice,
                Quantity = quantity,
                TotalPrice = total,
                Date = DateTime.Now,
                Instructions = txtInstructions.Text,
                Status = "Pending"
            };


          

            bool success = process.AddToCartProduct(cartItem);

            if (success)
            {
                MessageBox.Show("Product added to cart successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add product to cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToCart_Load(object sender, EventArgs e)
        {

        }
    }
}

