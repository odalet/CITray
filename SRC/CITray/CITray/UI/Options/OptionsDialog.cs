using System;
using System.Windows.Forms;
using CITray.Controllers;

namespace CITray.UI.Options
{
    internal partial class OptionsDialog : Form
    {
        private IServiceProvider services = null;
        private IOptionsController controller = null;

        public OptionsDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes this instance with the specified service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public void Initialize(IServiceProvider serviceProvider)
        {
            services = serviceProvider ?? This.Services; 
            controller = services.GetService<IOptionsController>(true);

            optionsTreeControl.SectionSelected += (s, e) =>
            {
                var panel = e.Panel;
                placeHolderPanel.Controls.Clear();
                placeHolderPanel.Controls.Add(panel);
            };

            optionsTreeControl.Initialize(services);
        }
    }
}
