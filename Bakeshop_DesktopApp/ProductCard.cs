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
    public partial class ProductCard : UserControl
    {
        public ProductCard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public event EventHandler<Product> DeleteClicked;
        public event EventHandler<Product> EditClicked;

        private Product product;

        public void SetProduct(Product product)
        {
            this.product = product;
            lblName.Text = product.ProductName;
            lblPrice.Text = $"₱ {product.Price1.ToString("0.00")}";
            pictureBox.Image = ByteArrayToImage(product.ProductImage);
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void ProductCard_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, product);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EditClicked?.Invoke(this, product);
        }
    }
}