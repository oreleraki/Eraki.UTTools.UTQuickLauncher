using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Eraki.UTTools.UTQuickLauncher.WinForm
{
    public class UTQuickLauncher
    {
        public string CurrentDirectory;
        public static readonly string Executor = "UnrealTournament.exe";
        public string ExecutorFullPath
        {
            get
            {
                return Path.Combine(CurrentDirectory, Executor);
            }
        }

        public string UserIni
        {
            get
            {
                return Path.Combine(CurrentDirectory, "User.ini");
            }
        }

        public string UnrealTournamentIni
        {
            get
            {
                return Path.Combine(CurrentDirectory, "UnrealTournament.ini");
            }
        }

        public UTQuickLauncher()
        {
            CurrentDirectory = Environment.CurrentDirectory;
#if DEBUG
            CurrentDirectory = @"C:\Games\UnrealTournament\System\";
#endif
            //var favorites = GetFavorites();
        }

        public string GetName()
        {
            var iniFile = new IniFile(UserIni);
            return iniFile.Read("Name", "DefaultPlayer");
        }

        public bool IsSpectator()
        {
            var iniFile = new IniFile(UserIni);
            return iniFile.Read("OverrideClass", "DefaultPlayer") == "Botpack.CHSpectator";
        }

        public UTFavoriteItem[] GetFavorites()
        {
            var iniFile = new IniFile(UnrealTournamentIni);
            var favoriteCounter = int.Parse(iniFile.Read("FavoriteCount", "UBrowser.UBrowserFavoritesFact"));

            var result = new UTFavoriteItem[favoriteCounter];
            for (int i = 0; i < favoriteCounter; i++)
            {
                var favoriteValue = iniFile.Read($"Favorites[{i}]", "UBrowser.UBrowserFavoritesFact");
                var chunks = favoriteValue.Split('\\');
                if (chunks[1].StartsWith("unreal://", StringComparison.OrdinalIgnoreCase))
				{
                    chunks[1] = chunks[1].ToLower().Replace("unreal://", "");
				}
                if (!IPAddress.TryParse(chunks[1], out IPAddress ip))
                {
                    try
					{
                        ip = Dns.GetHostEntry(chunks[1]).AddressList[0];
					}
                    catch (Exception ex)
					{
						Console.WriteLine($"Problem while DnsHostEntry resolving of {chunks[1]}, Exception: {ex}");
					}
                }
                result[i] = new UTFavoriteItem
                {
                    Name = chunks[0],
                    QueryPort = int.Parse(chunks[2]),
                    GamePort = int.Parse(chunks[2]) - 1,
                    IpAddress = ip
                };
            }

            return result;
        }

        internal void SetPlayer(string name, bool? isSpectator = null)
        {
            var iniFile = new IniFile(UserIni);
            iniFile.Write("Name", name, "DefaultPlayer");
            if (isSpectator.HasValue)
            {
                iniFile.Write("OverrideClass", isSpectator.Value ? "Botpack.CHSpectator" : "", "DefaultPlayer");
            }
        }

        internal void Launch(string serverInfo = "")
        {
            Process.Start(ExecutorFullPath, serverInfo);
        }
    }
}