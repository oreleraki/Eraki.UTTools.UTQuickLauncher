using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eraki.UTTools.UTQuickLauncher.WinForm
{
    public partial class FormUTQuickLauncherAbout : Form
    {
        public FormUTQuickLauncherAbout()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
