//ModProvider.cs
using ZyberClient.Models;
using System.Collections.Generic;

namespace ZyberClient.Core
{
    public class ModProvider
    {
        public List<Mod> GetMods()
        {
            return new List<Mod>
            {
                new Mod
                {
                    skibidi75 = "II's Stupid Menu",
                    skibidi76 = "Highly customizable mod Menu Developed by IIDK.",
                    skibidi77 = "https://repository-images.githubusercontent.com/742545374/2b0ee91a-c21d-4f92-b2fb-5e2304ffa94f",
                    skibidi78 = "https://github.com/iiDk-the-actual/iis.Stupid.Menu/releases/download/6.9.1/iis_Stupid_Menu.dll"
                },
                new Mod
                {
                    skibidi75 = "K-ID Bypasser",
                    skibidi76 = "Removes K-ID. From the game",
                    skibidi77 = "https://raw.githubusercontent.com/Zyber09/Icons-For-Gorilla-Tag-Client/refs/heads/main/KIDBypasser.jpg",
                    skibidi78 = "https://github.com/Zyber09/Icons-For-Gorilla-Tag-Client/raw/refs/heads/main/KID_Bypasser.dll"
                },
                new Mod
                {
                    skibidi75 = "Sodium",
                    skibidi76 = "A mod for Gorilla Tag which gives you good FPS with no cost of graphics. Allows for ReShade to be used too. No cost of graphics are made!",
                    skibidi77 = "https://raw.githubusercontent.com/Zyber09/Icons-For-Gorilla-Tag-Client/refs/heads/main/Sodium.png",
                    skibidi78 = "https://github.com/JuanLeoson/Sodium/releases/download/1.6.0/Sodium.dll"
                },
                new Mod
                {
                    skibidi75 = "Gorilla Media",
                    skibidi76 = "GorillaMedia is a mod for Gorilla Tag that lets you see and control any media that is playing on your computer. This mod supports any media that can show through the Windows Media API, including Spotify, VLC Media Player, YouTube Music, and iTunes.",
                    skibidi77 = "https://raw.githubusercontent.com/Zyber09/Icons-For-Gorilla-Tag-Client/refs/heads/main/GorillaMediaLogo.png",
                    skibidi78 = "https://github.com/iiDk-the-actual/GorillaMedia/releases/download/1.0.0/GorillaMedia.dll"
                },
                new Mod
                {
                    skibidi75 = "Asteroid Lite",
                    skibidi76 = "A sleek, simple GUI designed for Gorilla Tag to give you an edge in competitive and ranked gameplay. With this menu, reaching Sapphire rank is a breeze. It's fully undetected, meaning you’re safe unless reported.",
                    skibidi77 = "https://raw.githubusercontent.com/Zyber09/Icons-For-Gorilla-Tag-Client/refs/heads/main/Asteriod.png",
                    skibidi78 = "https://github.com/Ventern-gtr/Asteroid-Lite/releases/download/1.0/AsteroidLite.dll"
                },
                new Mod
                {
                    skibidi75 = "Pokruk's camera mod",
                    skibidi76 = "Silly Camera mod made by pokruk!",
                    skibidi77 = "https://raw.githubusercontent.com/Zyber09/Icons-For-Gorilla-Tag-Client/refs/heads/main/PokRukCamModLogo.png",
                    skibidi78 = "https://github.com/Pokruk/CameraMod/releases/download/2.8.1/Pokruk.sCameraMod.dll"
                },
            };
        }
    }
}