using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace CwordCommon.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void GoToSiteAction(object sender, EventArgs e)
        {
            Process.Start("http://mkornevich.net?from=cword_about");
        }

        private void GoToVkAction(object sender, EventArgs e)
        {
            Process.Start("http://vk.com/mkornevich");
        }

        private void OpenHelpAction(object sender, EventArgs e)
        {
            string helpFile = Application.StartupPath + "\\" + "CwordHelp.chm";

            if (!File.Exists(helpFile))
            {
                MessageBox.Show("Файл помощи не найден.", "Ошибка!");
                return;
            }

            Help.ShowHelp(this, helpFile);
        }
    }
}
