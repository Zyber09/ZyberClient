//BepInExManager.cs
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace ZyberClient.Core
{
    public class BepInExManager
    {
        private readonly string _skibidi1;
        private readonly string _skibidi2;
        private readonly string _skibidi3;
        private const string skibidi4 = "https://raw.githubusercontent.com/Zyber09/Icons-For-Gorilla-Tag-Client/main/BepInEx_win_x64_5.4.23.3.zip";
        public BepInExManager(string skibidi5)
        {
            _skibidi1 = skibidi5;
            _skibidi2 = Path.Combine(_skibidi1, "BepInEx");
            _skibidi3 = Path.Combine(_skibidi2, "config", "BepInEx.cfg");
        }

        public void DoBepinexStuff()
        {
            try
            {
                if (!Directory.Exists(_skibidi2))
                {
                    string skibidi6 = Path.Combine(Path.GetTempPath(), "bepinex.zip");
                    using (WebClient skibidi7 = new WebClient()) { skibidi7.DownloadFile(skibidi4, skibidi6); }
                    ZipFile.ExtractToDirectory(skibidi6, _skibidi1);
                    File.Delete(skibidi6);
                    MessageBox.Show("BepInEx installed successfully!", "BepInEx", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                string[] skibidi8 = { "config", "plugins", "patchers", "core" };
                foreach (string skibidi9 in skibidi8)
                {
                    string skibidi10 = Path.Combine(_skibidi2, skibidi9);
                    if (!Directory.Exists(skibidi10)) Directory.CreateDirectory(skibidi10);
                }
                if (!File.Exists(_skibidi3))
                {
                    File.WriteAllText(_skibidi3, GetDefaultConfig());
                }
            }
            catch (Exception skibidi11) { MessageBox.Show("Failed to install/setup BepInEx:\n" + skibidi11.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public Dictionary<string, bool> GTS() //stands for "GetTogglableSettings" :3
        {
            var skibidi12 = new Dictionary<string, bool>();
            if (!File.Exists(_skibidi3)) return skibidi12;
            string[] skibidi13 = File.ReadAllLines(_skibidi3);
            string skibidi14 = "";
            foreach (string skibidi15 in skibidi13)
            {
                if (skibidi15.Trim().StartsWith("[") && skibidi15.Trim().EndsWith("]")) { skibidi14 = skibidi15.Trim().Trim('[', ']'); }
                else if (skibidi15.Contains("="))
                {
                    string[] skibidi16 = skibidi15.Split('=');
                    string skibidi17 = skibidi16[0].Trim();
                    string skibidi18 = skibidi16[1].Trim().ToLower();
                    if (skibidi18 == "true" || skibidi18 == "false") { skibidi12[$"{skibidi14}.{skibidi17}"] = bool.Parse(skibidi18); }
                }
            }
            return skibidi12;
        }

        public void UpdateSetting(string skibidi19, bool skibidi20)
        {
            if (!File.Exists(_skibidi3)) return;
            string[] skibidi21 = skibidi19.Split('.');
            string skibidi22 = string.Join(".", skibidi21.Take(skibidi21.Length - 1));
            string skibidi23 = skibidi21.Last();
            string[] skibidi24 = File.ReadAllLines(_skibidi3);
            string skibidi25 = $@"^\s*{Regex.Escape(skibidi23)}\s*=\s*(true|false)";
            bool skibidi26 = false;
            for (int skibidi27 = 0; skibidi27 < skibidi24.Length; skibidi27++)
            {
                if (skibidi24[skibidi27].Trim() == $"[{skibidi22}]") skibidi26 = true;
                else if (skibidi24[skibidi27].Trim().StartsWith("[")) skibidi26 = false;
                if (skibidi26 && Regex.IsMatch(skibidi24[skibidi27], skibidi25, RegexOptions.IgnoreCase))
                {
                    skibidi24[skibidi27] = $"{skibidi23} = {skibidi20.ToString().ToLower()}";
                    break;
                }
            }
            File.WriteAllLines(_skibidi3, skibidi24);
        }

        private string GetDefaultConfig()
        {
            return @"
[Caching]
EnableAssemblyCache = true
[Chainloader]
HideManagerGameObject = false
[Logging]
UnityLogListening = true
LogConsoleToUnityLog = false
[Logging.Console]
Enabled = false
PreventClose = false
ShiftJisEncoding = false
[Logging.Disk]
WriteUnityLog = false
AppendLog = false
Enabled = true
[Preloader]
ApplyRuntimePatches = true
DumpAssemblies = false
LoadDumpedAssemblies = false
BreakBeforeLoadAssemblies = false
";
        }
    }
}