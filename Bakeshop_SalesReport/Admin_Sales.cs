using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using Bakeshop_Common;



namespace Bakeshop_SalesReport
{
    public partial class Admin_Sales : Form
    {
        private List<DbOrder> _orders;

        public Admin_Sales()
        {
            InitializeComponent();

        }

        public Admin_Sales(List<DbOrder> orders)
        {
            InitializeComponent();
            _orders = orders;
            cmbSortSales.SelectedIndex = 0; // Default to "Day"
            LoadChart(chartSales, _orders, "Day");
        }

        private void LoadChart(CartesianChart chart, List<DbOrder> orders, string mode)
        {
            var filtered = orders
                .Where(o => o.Status.Equals("Complete", StringComparison.OrdinalIgnoreCase));

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

            // Chart
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
            Name = mode
        }
            };

            chart.YAxes = new Axis[]
            {
        new Axis
        {
            Name = "Total Sales",
            Labeler = value => "₱" + value.ToString("N0")
        }
            };

            // DataGridView Table
            dgvSalesSummary.Columns.Clear();
            dgvSalesSummary.Rows.Clear();

            dgvSalesSummary.Columns.Add("Time", mode);
            dgvSalesSummary.Columns.Add("Total", "Total Sales (₱)");

            foreach (var item in groupedSales)
            {
                dgvSalesSummary.Rows.Add(item.Label, item.Total.ToString("N2"));
            }

            // Optional: Add grand total row
            if (groupedSales.Any())
            {
                decimal grandTotal = groupedSales.Sum(x => x.Total);
                dgvSalesSummary.Rows.Add("TOTAL", grandTotal.ToString("N2"));
            }

            // Optional: Style
            dgvSalesSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalesSummary.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSalesSummary.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }




        private void Admin_Sales_Load(object sender, EventArgs e)
        {

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
    }
}
