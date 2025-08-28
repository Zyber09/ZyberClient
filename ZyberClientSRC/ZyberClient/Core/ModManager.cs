//ModManager.cs
using ZyberClient.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
namespace ZyberClient.Core
{
    public class ModManager
    {
        private readonly string _skibidi41;
        private readonly string _skibidi42;
        public ModManager(string skibidi43)
        {
            _skibidi41 = Path.Combine(skibidi43, "BepInEx", "plugins");
            _skibidi42 = Path.Combine(skibidi43, "DisabledPlugins");

            if (!Directory.Exists(_skibidi41)) Directory.CreateDirectory(_skibidi41);
            if (!Directory.Exists(_skibidi42)) Directory.CreateDirectory(_skibidi42);
        }

        public List<InstalledMod> GetInstalledMods(List<Mod> skibidi44)
        {
            var skibidi45 = new List<InstalledMod>();
            const string skibidi46 = "https://raw.githubusercontent.com/Zyber09/Icons-For-Gorilla-Tag-Client/refs/heads/main/QuestionMark.png";

            Action<string, bool> skibidi47 = (skibidi48, skibidi49) =>
            {
                if (!Directory.Exists(skibidi48)) return;

                var skibidi50 = Directory.GetFiles(skibidi48, "*.dll");
                var skibidi51 = skibidi50.Select(skibidi52 =>
                {
                    string skibidi53 = Path.GetFileName(skibidi52);
                    var skibidi54 = skibidi44.FirstOrDefault(d =>
                        !string.IsNullOrEmpty(d.skibidi78) && d.skibidi78.EndsWith("/" + skibidi53, StringComparison.OrdinalIgnoreCase));

                    return new InstalledMod
                    {
                        skibidi69 = skibidi53,
                        skibidi70 = skibidi49,
                        skibidi71 = skibidi54?.skibidi75,
                        skibidi72 = skibidi54?.skibidi77 ?? skibidi46,
                        skibidi73 = skibidi54?.skibidi76 ?? "A custom mod"
                    };
                });
                skibidi45.AddRange(skibidi51);
            };

            skibidi47(_skibidi41, true);
            skibidi47(_skibidi42, false);

            return skibidi45.OrderBy(m => m.skibidi71 ?? m.skibidi69).ToList();
        }

        public void EnableMod(string skibidi55)
        {
            try
            {
                string skibidi56 = Path.Combine(_skibidi42, skibidi55);
                string skibidi57 = Path.Combine(_skibidi41, skibidi55);
                if (File.Exists(skibidi56))
                {
                    File.Move(skibidi56, skibidi57);
                }
            }
            catch (Exception skibidi58)
            {
                MessageBox.Show($"Stupid Program Failed to enable mod{skibidi55}:\n{skibidi58.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DisableMod(string skibidi59)
        {
            try
            {
                string skibidi60 = Path.Combine(_skibidi41, skibidi59);
                string skibidi61 = Path.Combine(_skibidi42, skibidi59);
                if (File.Exists(skibidi60))
                {
                    File.Move(skibidi60, skibidi61);
                }
            }
            catch (Exception skibidi62)
            {
                MessageBox.Show($"Failed to disable mod for some stupid reason {skibidi59}:\n{skibidi62.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteMod(string skibidi63, bool skibidi64)
        {
            try
            {
                string skibidi65 = skibidi64
                    ? Path.Combine(_skibidi41, skibidi63)
                    : Path.Combine(_skibidi42, skibidi63);

                if (File.Exists(skibidi65))
                {
                    File.Delete(skibidi65);
                }
            }
            catch (Exception skibidi66)
            {
                MessageBox.Show($"Failed to delete mod {skibidi63}:\n{skibidi66.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddCustomMod(string skibidi67)
        {
            try
            {
                string skibidi68 = Path.GetFileName(skibidi67);
                string skibidi69 = Path.Combine(_skibidi41, skibidi68);

                if (File.Exists(skibidi69))
                {
                    MessageBox.Show($"A mod named {skibidi68} already exists, you dingus.", "Duplicate Mod", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                File.Copy(skibidi67, skibidi69);
                MessageBox.Show($"Successfully added your sigma mod: {skibidi68}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception skibidi70)
            {
                MessageBox.Show($"Whoops, couldn't add that mod. Skill issue?\n{skibidi70.Message}", "Total Stupidity :lauggh:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void DownloadMod(string skibidi71)
        {
            try
            {
                using (WebClient skibidi72 = new WebClient())
                {
                    Uri skibidi73 = new Uri(skibidi71);
                    string skibidi74 = Path.GetFileName(skibidi73.LocalPath);
                    string skibidi75 = Path.Combine(_skibidi41, skibidi74);

                    skibidi72.Headers.Add("user-agent", "GorillaTagLauncher");
                    skibidi72.DownloadFile(skibidi73, skibidi75);
                    MessageBox.Show($"Successfully downloaded and enabled {skibidi74}!", "Mod Downloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception skibidi76)
            {
                MessageBox.Show("Failed to download mod :/ | \n" + skibidi76.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}