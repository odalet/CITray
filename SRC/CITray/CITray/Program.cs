using System;
using System.Windows.Forms;

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

#if DEBUG
            try
            {
                This.TestLoadSettings();
                This.TestSaveSettings();
                This.TestLoadSettings();
            }
            catch (Exception ex)
            {
                var debugEx = ex;
            }
#endif

            This.Bootstrap();

            Application.Run(new MainForm());
        }
    }
}
