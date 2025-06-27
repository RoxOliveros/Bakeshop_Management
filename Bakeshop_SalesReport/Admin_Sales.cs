using Bakeshop_Common;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using System.Linq;



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
    }
}
