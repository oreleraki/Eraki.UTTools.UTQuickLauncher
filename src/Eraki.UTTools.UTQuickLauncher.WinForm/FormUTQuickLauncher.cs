using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eraki.UTTools.UTQuickLauncher.WinForm
{
    public partial class FormUTQuickLauncher : Form
    {
        private static UTServerQuery _utServerQuery;
        private static UTQuickLauncher _utQuickLauncher;
        private static FormUTQuickLauncherAbout _aboutForm;
        private BindingList<UTFavoriteViewItem> _bindingListFavorites = new BindingList<UTFavoriteViewItem>();
        private Dictionary<string, UTFavoriteItem> _favoritesAsDict;

        public FormUTQuickLauncher()
        {
            InitializeComponent();
        }

        private async void FormUTQuickLauncher_Load(object sender, EventArgs e)
        {
            _utServerQuery = new UTServerQuery();
            _utQuickLauncher = new UTQuickLauncher();

            tbName.Text = _utQuickLauncher.GetName();
            cbAsSpectator.Checked = _utQuickLauncher.IsSpectator();

            _favoritesAsDict = _utQuickLauncher.GetFavorites().ToDictionary(f => f.Address, f => f);
            SetDataGridViewFavorites();
            await RefreshAsync();
        }

        protected void SetDataGridViewFavorites()
        {
            foreach (var item in _favoritesAsDict)
            {
                _bindingListFavorites.Add(new UTFavoriteViewItem(item.Value));
            }
            _bindingListFavorites.RaiseListChangedEvents = true;
            dgvFavorites.DataSource = _bindingListFavorites;
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

        private void btnAbout_Click(object sender, EventArgs e)
        {
            _aboutForm = new FormUTQuickLauncherAbout();
            _aboutForm.ShowInTaskbar = false;
            _aboutForm.Show();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshAsync();
        }

        private void FormUTQuickLauncher_FormClosing(object sender, FormClosingEventArgs e)
        {
            _aboutForm?.Close();
            _utServerQuery.Close();
        }

        private void PrintStatus(string message)
        {
            tsslStatus.Text = message;
        }

        private IEnumerable<Task> QueryFavoritesAsync(UTFavoriteItem[] favorites)
        {
            return favorites.Select(item =>
                Task.Run(() =>
                {
                    var response = _utServerQuery.Query(new IPEndPoint(item.IpAddress, item.QueryPort));
                    if (response != null)
                    {
                        item.NumberOfPlayers = response.NumberOfPlayers.Value;
                        item.MaxPlayers = response.MaxPlayers.Value;
                    }
                })
            );
        }

        public void Launch(string serverInfo = "")
        {
            _utQuickLauncher.SetPlayer(tbName.Text, cbAsSpectator.Checked);
            _utQuickLauncher.Launch(serverInfo);
            Application.Exit();
        }

        public async Task RefreshAsync()
        {
            var favorites = _favoritesAsDict.Values.ToArray();
            var stopWatch = Stopwatch.StartNew();
            PrintStatus($"Refreshing... {_bindingListFavorites.Count} servers.");
            await Task.WhenAll(QueryFavoritesAsync(favorites));
            //await Task.Run(() => QueryFavoritesAsync(favorites));
            foreach (var item in _bindingListFavorites)
            {
                var r = _favoritesAsDict.TryGetValue(item.Address, out UTFavoriteItem ufi);
                item.Name = ufi.Name;
                item.Players = $"[{ufi.NumberOfPlayers}/{ufi.MaxPlayers}]";
            }
            stopWatch.Stop();
            PrintStatus($"Finish: {_bindingListFavorites.Count} servers. Elapsed: {stopWatch.Elapsed}");
        }

        private void dgvFavorites_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //dgvFavorites.Sort(dgvFavorites.Columns[e.ColumnIndex], ListSortDirection.Ascending);
        }
    }
}