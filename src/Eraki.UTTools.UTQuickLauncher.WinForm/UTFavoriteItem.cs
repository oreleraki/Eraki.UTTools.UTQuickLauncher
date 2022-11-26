using System;
using System.Diagnostics;
using System.Net;

namespace Eraki.UTTools.UTQuickLauncher.WinForm
{
	[DebuggerDisplay("[Address:{Address}|Host:{Host}|Name:{Name}")]
	public class UTFavoriteItem
	{
		public string Name { get; set; }
		public string Address
		{
			get
			{
				return $"{Host}:{GamePort}";
			}
		}
		public int NumberOfPlayers { get; set; }
		public int MaxPlayers { get; set; }
		public string Host { get; set; }
		public IPAddress IpAddressResolved
		{
			get
			{
				IPAddress ipAddress = null;
				if (Host != null && !IPAddress.TryParse(Host, out ipAddress))
				{
					try
					{
						ipAddress = Dns.GetHostEntry(Host).AddressList[0];
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Problem while DnsHostEntry resolving of {Host}, Exception: {ex}");
					}

				}
				return ipAddress;
			}
		}
		public int GamePort { get; set; }
		public int QueryPort { get; internal set; }
	}
}