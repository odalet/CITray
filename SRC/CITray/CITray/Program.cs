using System;
using System.Windows.Forms;
using System.Threading;

using CITray.UI;
using CITray.Controllers;

namespace CITray
{
    // fake check-in: testing git push
    internal static class Program
    {
        private const string mutexName = "CITrayMutex";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //#if DEBUG
            //            try
            //            {
            //                This.TestLoadSettings();
            //                This.TestSaveSettings();
            //                This.TestLoadSettings();
            //            }
            //            catch (Exception ex)
            //            {
            //                var debugEx = ex;
            //            }
            //#endif

            Action nop = () => { };

            InitializeSingleInstanceApplication(
                icon =>
                {
                    // Initializes the core engine & adds core services
                    This.Bootstrap();

                    // Add required application services
                    This.Services.AddService<IApplicationController>(
                        new ApplicationController(This.Services));
                    
                    // Initialize the tray icon
                    icon.Initialize(This.Services);
                    icon.Visible = true;

                    // Run the windows application messages loop
                    Application.Run();
                },
                nop);
        }

        /// <summary>
        /// Initializes the application by alowing only a single instance.
        /// </summary>
        /// <param name="ifFirstInstance">Action to execute if this is the first instance.</param>
        /// <param name="ifNotFirstInstance">Action to execute if this is not the first instance.</param>
        private static void InitializeSingleInstanceApplication(
            Action<TrayIcon> ifFirstInstance, Action ifNotFirstInstance)
        {
            bool isFirstInstance;
            using (var mutex = new Mutex(true, mutexName, out isFirstInstance))
            {
                if (isFirstInstance)
                {
                    using (var trayIcon = new TrayIcon())
                        ifFirstInstance(trayIcon);
                }
                else
                {
                    NativeWindowHelper.RestoreMainWindow();
                    ifNotFirstInstance();
                }
            }
        }
    }
}
