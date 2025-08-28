//GameLocator.cs
using Microsoft.Win32;
using System.IO;
namespace ZyberClient.Core
{
    public class GameLocator
    {
        public string skibidi28 { get; private set; }
        public string skibidi29 { get; private set; }
        public bool FindGame()
        {
            try
            {
                using (RegistryKey skibidi30 = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam"))
                {
                    if (skibidi30?.GetValue("SteamPath") != null)
                        skibidi28 = Path.Combine(skibidi30.GetValue("SteamPath").ToString(), "steam.exe");
                }
                if (string.IsNullOrEmpty(skibidi28) || !File.Exists(skibidi28)) return false;

                string skibidi31 = Path.Combine(Path.GetDirectoryName(skibidi28), "steamapps", "libraryfolders.vdf");
                if (!File.Exists(skibidi31)) return false;

                foreach (var skibidi32 in File.ReadAllLines(skibidi31))
                {
                    if (skibidi32.Contains("\"path\""))
                    {
                        string skibidi33 = skibidi32.Split('"')[3].Replace(@"\\", @"\");
                        string skibidi34 = Path.Combine(skibidi33, "steamapps", "common", "Gorilla Tag");
                        if (Directory.Exists(skibidi34))
                        {
                            skibidi29 = skibidi34;
                            break;
                        }
                    }
                }
                return !string.IsNullOrEmpty(skibidi29) && Directory.Exists(skibidi29);
            }
            catch
            {
                return false;
            }
        }
    }
}