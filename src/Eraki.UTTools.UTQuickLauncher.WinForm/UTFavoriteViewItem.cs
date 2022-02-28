using System.ComponentModel;

namespace Eraki.UTTools.UTQuickLauncher.WinForm
{
    public class UTFavoriteViewItem : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {

                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        private string _address;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {

                _address = value;
                NotifyPropertyChanged(nameof(Address));
            }
        }

        private string _players;
        public string Players
        {
            get
            {
                return _players;
            }
            set
            {

                _players = value;
                NotifyPropertyChanged(nameof(Players));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }

        public UTFavoriteViewItem(UTFavoriteItem item)
        {
            Name = item.Name;
            Address = item.Address;
            Players = $"[{item.NumberOfPlayers}/{item.MaxPlayers}]";
        }
    }
}