using System;
using System.Windows.Forms;
using CITray.UI;

namespace CITray
{
    internal partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ShowOptions()
        {
            new OptionsDialog().ShowDialog(this);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOptions();
        }
    }
}
