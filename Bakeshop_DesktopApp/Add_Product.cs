
using Bakeshop_Common;
using BakeshopManagement.Business;
using System.Globalization;

namespace Bakeshop_DesktopApp
{
    public partial class Add_Product : Form
    {
        private BakeshopProcess process;
        private Product editingProduct;
        public event EventHandler ProductUpdated;

        public Add_Product()
        {
            InitializeComponent();

            process = new BakeshopProcess();
        }
        public Add_Product(Product productToEdit) : this()
        {
            editingProduct = productToEdit;
            PopulateFieldsForEdit(productToEdit);
        }

        private Image CropToSquareAndResize(Image original, int size)
        {
            int cropSize = Math.Min(original.Width, original.Height);
            int x = (original.Width - cropSize) / 2;
            int y = (original.Height - cropSize) / 2;

            Rectangle cropArea = new Rectangle(x, y, cropSize, cropSize);
            Bitmap squareImage = new Bitmap(cropSize, cropSize);

            using (Graphics g = Graphics.FromImage(squareImage))
            {
                g.DrawImage(original, new Rectangle(0, 0, cropSize, cropSize), cropArea, GraphicsUnit.Pixel);
            }

            // Resize to match PictureBox size
            return new Bitmap(squareImage, new Size(size, size));
        }


        //Useer add image to picturebox
        private void productImageBox_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Product Image";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Image originalImage = Image.FromFile(ofd.FileName);

                    // Crop and resize the image
                    Image croppedAndResized = CropToSquareAndResize(originalImage, productImageBox.Width);

                    productImageBox.Image = croppedAndResized;
                    productImageBox.SizeMode = PictureBoxSizeMode.StretchImage; // Or Zoom
                }
            }
        }

        //add limitation to word count in description 
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            string[] words = txtDescription.Text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = words.Length;

            // Optional: display word count in a label
            lblWordCount.Text = $"Words: {wordCount}";

           
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Product name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(cmbCategory.Text))
                {
                    MessageBox.Show("Product category is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    MessageBox.Show("Product description is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (productImageBox.Image == null)
                {
                    MessageBox.Show("Product image is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate at least one option and price
                bool hasAtLeastOneOption =
                    (!string.IsNullOrWhiteSpace(txtOption1.Text) && decimal.TryParse(txtPrice1.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out _)) ||
                    (!string.IsNullOrWhiteSpace(txtOption2.Text) && decimal.TryParse(txtPrice2.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out _)) ||
                    (!string.IsNullOrWhiteSpace(txtOption3.Text) && decimal.TryParse(txtPrice3.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out _)) ||
                    (!string.IsNullOrWhiteSpace(txtOption4.Text) && decimal.TryParse(txtPrice4.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out _));

                if (!hasAtLeastOneOption)
                {
                    MessageBox.Show("At least one Option and its valid Price is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parse prices
                decimal? p1 = TryParseDecimalNullable(txtPrice1.Text);
                decimal? p2 = TryParseDecimalNullable(txtPrice2.Text);
                decimal? p3 = TryParseDecimalNullable(txtPrice3.Text);
                decimal? p4 = TryParseDecimalNullable(txtPrice4.Text);

                // Create Product instance
                Product newProduct = new Product
                {
                    ProductName = txtName.Text.Trim(),
                    Category = cmbCategory.Text.Trim(),
                    Option1 = txtOption1.Text.Trim(),
                    Price1 = p1 ?? 0,
                    Option2 = txtOption2.Text.Trim(),
                    Price2 = p2,
                    Option3 = txtOption3.Text.Trim(),
                    Price3 = p3,
                    Option4 = txtOption4.Text.Trim(),
                    Price4 = p4,
                    Description = txtDescription.Text.Trim(),
                    ProductImage = ImageToByteArray(productImageBox.Image)
                };

                bool success;

                if (editingProduct == null)
                {
                    // Add mode
                    string errorMessage;
                     success = process.AddProduct(newProduct, out errorMessage);

                    if (success)
                    {
                        MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Or refresh product list, etc.
                    }
                    else
                    {
                        MessageBox.Show(errorMessage, "Add Product Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else
                {
                    // Edit mode
                    success = process.UpdateProduct(newProduct);
                    if (success)
                        MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        MessageBox.Show("Failed to update product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Refresh product list in Admin_Menu
                foreach (Form form in Application.OpenForms)
                {
                    if (form is Admin_Menu dashboard)
                    {
                        dashboard.LoadProducts();
                        break;
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal? TryParseDecimalNullable(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            if (decimal.TryParse(input.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
                return result;

            return null;
        }


        // saving image
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        // loaidng image
        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }


        private void PopulateFieldsForEdit(Product product)
        {
            editingProduct = product;
            txtName.Text = product.ProductName;
            cmbCategory.Text = product.Category;
            txtOption1.Text = product.Option1;
            txtPrice1.Text = product.Price1.ToString("0.00");
            txtOption2.Text = product.Option2;
            txtPrice2.Text = product.Price2?.ToString("0.00");
            txtOption3.Text = product.Option3;
            txtPrice3.Text = product.Price3?.ToString("0.00");
            txtOption4.Text = product.Option4;
            txtPrice4.Text = product.Price4?.ToString("0.00");
            txtDescription.Text = product.Description;
            productImageBox.Image = ByteArrayToImage(product.ProductImage);

            txtName.Enabled = false; 
        }
        private void Add_Product_Load(object sender, EventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
