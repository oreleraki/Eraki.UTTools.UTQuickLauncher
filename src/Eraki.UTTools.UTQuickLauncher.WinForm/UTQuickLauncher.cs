using System;
using System.Diagnostics;
using System.IO;

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
                result[i] = new UTFavoriteItem
                {
                    Name = chunks[0],
                    Address = $"{chunks[1]}:{int.Parse(chunks[2])-1}",
                    //Port = int.Parse(chunks[2])
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