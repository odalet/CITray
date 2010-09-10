using System;
using System.Windows.Forms;
using CITray.UI;

namespace CITray
{
    internal partial class MainForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows the options dialog.
        /// </summary>
        private void ShowOptions()
        {
            new OptionsDialog().ShowDialog(this);
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        private void Exit()
        {
            Close();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOptions();
        }

        private void exitAction_Run(object sender, EventArgs e)
        {
            Exit();
        }
    }
}
