using System.Diagnostics;
using System.Text;

namespace Eraki.UTTools.UTQuickLauncher.WinForm
{
    [DebuggerDisplay("[HostName: {HostName}] [{NumPlayers:{NumPlayers}] [{MaxPlayers:{NumMaxPlayersPlayers}")]
    public class UTServerResponse
    {
        public static string ConstantHostName = @"\hostname\";
        public static string ConstantNumPlayers = @"\numplayers\";
        public static string ConstantMaxPlayers = @"\maxplayers\";

        public string HostName { get; set; }
        public int? NumberOfPlayers { get; set; }
        public int? MaxPlayers { get; set; }

        public static UTServerResponse Parse(string response)
        {
            return new UTServerResponse
            {
                HostName = GetPropValue(response, ConstantHostName),
                NumberOfPlayers = GetPropValue<int>(response, ConstantNumPlayers),
                MaxPlayers = GetPropValue<int>(response, ConstantMaxPlayers)
            };
        }

        public static UTServerResponse Parse(byte[] response)
        {
            return Parse(Encoding.UTF8.GetString(response));
        }

        public static TType GetPropValue<TType>(string text, string propName)
        {
            int a1NumPlayersStartPos = text.IndexOf(propName);
            int startValuePos = a1NumPlayersStartPos + propName.Length;
            string propValue = text.Substring(startValuePos, text.IndexOf(@"\", startValuePos) - startValuePos);

            object result;
            switch (typeof(TType).ToString())
            {
                case "System.Int32":
                    result = int.Parse(propValue);
                    break;

                default:
                    result = propValue;
                    break;
            }
            return (TType)result;
        }

        public static string GetPropValue(string text, string propName)
        {
            return GetPropValue<string>(text, propName);
        }
    }
}