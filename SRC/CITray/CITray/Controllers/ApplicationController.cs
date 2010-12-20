using System;
using System.Windows.Forms;

using CITray.UI;

namespace CITray.Controllers
{
    internal class ApplicationController : BaseController, IApplicationController
    {
        private MainForm mainForm = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationController"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public ApplicationController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        #region IApplicationController Members

        /// <summary>
        /// Gets the application's main window instance.
        /// </summary>
        public MainForm MainWindow
        {
            get
            {
                if (mainForm == null)
                {
                    mainForm = new MainForm();
                    mainForm.Initialize(base.Services);
                }
                return mainForm;
            }
        }

        public void ExitApplication()
        {
            if (mainForm != null)
            {
                mainForm.Close();
                mainForm.Dispose();
                mainForm = null;
            }

            Application.Exit();
        }

        public void AboutApplication()
        {
            ShowDialog<AboutBox>();
        }

        public void ShowMainWindow()
        {
            var form = MainWindow;
            if (!form.Visible)
            {
                form.Show();
                form.BringToFront();
            }
        }

        public void HideMainWindow()
        {
            var form = MainWindow;
            if (form.Visible) form.Hide();
        }

        public void ShowOptions()
        {
            var optionsService = base.GetService<IOptionsController>(true);     
            using (var form = optionsService.GetOptionsDialog())
                ShowDialog(form);
        }

        #endregion

        private IWin32Window CurrentOwner
        {
            get
            {
                if (mainForm == null) return null;
                if (!mainForm.Visible) return null;
                if (mainForm.WindowState == FormWindowState.Minimized) return null;

                return mainForm;
            }
        }

        private DialogResult ShowDialog<T>() where T : Form, new()
        {
            var form = new T();
            return ShowDialog(form);
        }

        private DialogResult ShowDialog(Form form)
        {
            var owner = CurrentOwner;

            form.ShowIcon = owner == null;
            form.ShowInTaskbar = owner == null;
            form.StartPosition = owner == null ?
                FormStartPosition.CenterScreen : FormStartPosition.CenterParent;

            return form.ShowDialog(owner);
        }
    }
}
