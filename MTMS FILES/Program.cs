using System;
using System.Windows.Forms;

namespace Movie_Theater_Management_System
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Login()); 
        }
    }
}