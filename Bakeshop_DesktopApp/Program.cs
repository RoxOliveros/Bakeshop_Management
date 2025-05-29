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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var process = new BakeshopProcess();
            Application.Run(new Login(process));
        }
    }
}
