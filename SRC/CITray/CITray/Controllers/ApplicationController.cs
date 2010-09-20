using System;
using System.Windows.Forms;

using CITray.UI;

namespace CITray.Controllers
{
    internal class ApplicationController : IApplicationController
    {
        private MainForm mainForm = null;
        private IServiceProvider services = null;

        public ApplicationController(IServiceProvider serviceProvider)
        {
            services = serviceProvider ?? This.Services;
        }

        #region IApplicationController Members

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
            var form = GetMainForm();
            if (!form.Visible)
            {
                form.Show();
                form.BringToFront();
            }
        }

        public void HideMainWindow()
        {
            var form = GetMainForm();
            if (form.Visible) form.Hide();
        }

        public void ShowOptions()
        {
            ShowDialog<OptionsDialog>();
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

        private MainForm GetMainForm()
        {
            if (mainForm == null)
            {
                mainForm = new MainForm();
                mainForm.Initialize(services);
            }
            return mainForm;
        }

        private DialogResult ShowDialog<T>() where T : Form, new()
        {
            var owner = CurrentOwner;

            var form = new T();
            form.ShowIcon = owner == null;
            form.ShowInTaskbar = owner == null;
            form.StartPosition = owner == null ? 
                FormStartPosition.CenterScreen : FormStartPosition.CenterParent;

            return form.ShowDialog(owner);
        }
    }
}
