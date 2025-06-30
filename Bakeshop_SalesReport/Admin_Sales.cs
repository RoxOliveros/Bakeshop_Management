using Bakeshop_Common;
using BakeshopManagement.Business;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using System.Linq;
using System.Text;
using System.Text.Json;



namespace Bakeshop_SalesReport
{
    public partial class Admin_Sales : Form
    {
        private BakeshopProcess _process = new BakeshopProcess();
        private List<DbOrder> _orders;
        private List<OrderDetail> _orderDetails;

        public Admin_Sales()
        {
            InitializeComponent();

            _orders = _process.GetAllCompletedOrders()
             ?? new List<DbOrder>();

            
            _orderDetails = _orders
                .SelectMany(o => _process.GetOrderDetails(o.OrderID))
                .ToList();


            Load += Admin_Sales_Load;
        }

        public Admin_Sales(List<DbOrder> orders) : this()
        {
            _orders = orders ?? _orders;

            _orderDetails = _orders
                .SelectMany(o => _process.GetOrderDetails(o.OrderID))
                .ToList();
        }

        private void LoadChart(CartesianChart chart, List<DbOrder> orders, string mode)
        {
            var filtered = orders
            .Where(o => o.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase))
            .ToList();


            var groupedSales = new List<(string Label, decimal Total)>();

            switch (mode)
            {
                case "Day":
                    groupedSales = filtered
                        .GroupBy(o => o.OrderDate.Date)
                        .Select(g => (g.Key.ToString("MMM dd"), g.Sum(o => o.TotalAmount)))
                        .OrderBy(g => g.Item1)
                        .ToList();
                    break;

                case "Week":
                    groupedSales = filtered
                        .GroupBy(o =>
                            System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                o.OrderDate,
                                System.Globalization.CalendarWeekRule.FirstFourDayWeek,
                                DayOfWeek.Monday))
                        .Select(g => ($"Week {g.Key}", g.Sum(o => o.TotalAmount)))
                        .OrderBy(g => g.Item1)
                        .ToList();
                    break;

                case "Month":
                    groupedSales = filtered
                        .GroupBy(o => o.OrderDate.ToString("yyyy-MM"))
                        .Select(g => (g.Key, g.Sum(o => o.TotalAmount)))
                        .OrderBy(g => g.Key)
                        .ToList();
                    break;

                case "Year":
                    groupedSales = filtered
                        .GroupBy(o => o.OrderDate.Year.ToString())
                        .Select(g => (g.Key, g.Sum(o => o.TotalAmount)))
                        .OrderBy(g => g.Key)
                        .ToList();
                    break;
            }

            var labels = groupedSales.Select(g => g.Label).ToArray();
            var values = groupedSales.Select(g => (double)g.Total).ToArray();


            lblChartTitle.Text = $"Sales Report by {mode}";

            chart.Series = new ISeries[]
            {
                new ColumnSeries<double>
                {
                    Values = values,
                    Name = "Sales (₱)"
                }
            };

            chart.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = labels,
                    LabelsRotation = 15,
                    Name = string.Empty,
                    IsVisible = true
                }
            };

            chart.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = string.Empty,
                    Labeler = value => "₱" + value.ToString("N0"),
                    IsVisible = true
                }
            };

            decimal totalSales = filtered.Sum(x => x.TotalAmount);
            int totalOrders = filtered.Count;
            int totalBuyers = filtered.Select(x => x.UserID).Distinct().Count();

            lblSales.Text = "₱" + totalSales.ToString("N2");
            lblOrders.Text = totalOrders.ToString();
            lblBuyers.Text = totalBuyers.ToString();
        }





        private void Admin_Sales_Load(object sender, EventArgs e)
        {
            cmbSortSales.SelectedIndex = 0;
            LoadChart(chartSales, _orders, "Day");
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbSortSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mode = cmbSortSales.SelectedItem.ToString();
            LoadChart(chartSales, _orders, mode);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chartSales_Load(object sender, EventArgs e)
        {

        }

        private async void btnAIInsights_Click(object sender, EventArgs e)
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


    }
}
