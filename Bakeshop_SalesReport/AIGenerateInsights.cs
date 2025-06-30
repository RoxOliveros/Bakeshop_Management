using Bakeshop_Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bakeshop_SalesReport
{
    public partial class AIGenerateInsights : Form
    {
        private List<DbOrder> _orders;
        private List<OrderDetail> _orderDetails;

        public AIGenerateInsights(List<DbOrder> orders, List<OrderDetail> orderDetails)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _orders = orders;
            _orderDetails = orderDetails;
            this.Load += AIGenerateInsights_Load;
        }

        private async void AIGenerateInsights_Load(object sender, EventArgs e)
        {

            lblSummaryOutput.Text = "Generating insights, please wait...";

            try
            {
                var summary = await RequestAISummaryFromAPI();
                lblSummaryOutput.Text = string.IsNullOrWhiteSpace(summary)
                    ? "⚠️ No sales data to summarize."
                    : summary;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "❌ Failed to connect to the AI API:\n\n" + ex.Message,
                    "Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                lblSummaryOutput.Text = "Failed to generate insights.";

            }

        }
          private async Task<string> RequestAISummaryFromAPI()
          {
            // Group by product from details
            var productSales = _orderDetails
                .GroupBy(d => d.ProductName)
                .Select(g => new { Product = g.Key, Total = g.Sum(d => d.TotalPrice) })
                .OrderByDescending(x => x.Total)
                .ToList();

            if (!productSales.Any())
                return null;

            // Build raw data
            var rawData = string.Join("\n",
                productSales.Select(x => $"{x.Product}: ₱{x.Total:N2}"));

            // Call Web API
            var payload = new { RawData = rawData };
            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient(new HttpClientHandler
            {
                // for local dev only
                ServerCertificateCustomValidationCallback = (_, __, ___, ____) => true
            });

            var response = await client.PostAsync(
                "https://localhost:7019/api/SalesReport/generate",
                content);

            var body = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                throw new Exception($"API Error {response.StatusCode}: {body}");

            // Parse summary
            using var doc = JsonDocument.Parse(body);
            return doc.RootElement.GetProperty("summary").GetString();
        }
    




        private void label1_Click(object sender, EventArgs e)
        {

        }

      
    }
}
