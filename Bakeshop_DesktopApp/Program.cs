using System;
using System.Windows.Forms;
using BakeshopManagement.Business;

namespace Bakeshop_DesktopApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var process = new BakeshopProcess();
                Application.Run(new Login(process));

                //taskkill /IM Bakeshop_DesktopApp.exe /F

             
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Startup error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}