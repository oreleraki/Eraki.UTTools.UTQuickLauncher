using System;
using System.Windows.Forms;

namespace Eraki.UTTools.UTQuickLauncher.WinForm
{
    public partial class frmUTQuickLauncher : Form
    {
        private static UTQuickLauncher _utQuickLauncher;
        private BindingSource bindingSource1 = new BindingSource();


        public frmUTQuickLauncher()
        {
            InitializeComponent();
        }

        private void frmUTQuickLauncher_Load(object sender, EventArgs e)
        {
            dgvFavorites.DataSource = bindingSource1;
            _utQuickLauncher = new UTQuickLauncher();
            bindingSource1.DataSource = _utQuickLauncher.GetFavorites();

            tbName.Text = _utQuickLauncher.GetName();
            cbAsSpectator.Checked = _utQuickLauncher.IsSpectator();
        }

        private void dgvFavorites_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var row = ((DataGridView)sender).Rows[e.RowIndex];
            var serverInfo = $"unreal://{row.Cells[1].Value}";
            Launch(serverInfo);
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            Launch();
        }

        public void Launch(string serverInfo = "")
        {
            _utQuickLauncher.SetPlayer(tbName.Text, cbAsSpectator.Checked);
            _utQuickLauncher.Launch(serverInfo);
            Application.Exit();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            new FormUTQuickLauncherAbout().Show();
        }
    }
}