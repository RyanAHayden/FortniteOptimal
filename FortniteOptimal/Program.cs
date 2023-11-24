using System.Net.Quic;
using System.Runtime.CompilerServices;

namespace FortniteOptimal
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            frmOptimal mainForm = new frmOptimal();
            mainForm.AllowDrop = true;
            if (!mainForm.IsDisposed)
            {
                Application.Run(mainForm);
            }
            else
                Application.Exit();
        }
    }
}