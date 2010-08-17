using System;
using System.Windows.Forms;

using CITray.Core;

namespace CITray
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            This.Bootstrap();

            Application.Run(new MainForm());
        }
    }
}
