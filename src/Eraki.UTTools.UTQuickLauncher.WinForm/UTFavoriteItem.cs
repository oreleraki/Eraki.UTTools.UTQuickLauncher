using System.Net;

namespace Eraki.UTTools.UTQuickLauncher.WinForm
{
	public class UTFavoriteItem
    {
        public string Name { get; set; }
        public string Address
        {
            get
            {
                return $"{IpAddress}:{GamePort}";
            }
        }
        public int NumberOfPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public IPAddress IpAddress { get; set; }
        public int GamePort { get; set; }
        public int QueryPort { get; internal set; }
    }
}