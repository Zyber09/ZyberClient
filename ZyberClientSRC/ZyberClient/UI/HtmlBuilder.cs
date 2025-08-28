//HtmlBuilder.cs
using ZyberClient.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZyberClient.UI
{
    public class HtmlBuilder
    {
        public string DoHtmlShit(Dictionary<string, bool> skibidi79, List<Mod> skibidi80, List<InstalledMod> skibidi81, string skibidi82 = "home", bool skibidi83 = false, string skibidi84 = "N/A")
        {
            const string skibidi85 = "https://raw.githubusercontent.com/Zyber09/Icons-For-Gorilla-Tag-Client/refs/heads/main/QuestionMark.png";
            string skibidi86(string skibidi87) => skibidi82 == skibidi87 ? "active" : "";
            string skibidi88(string skibidi89) => skibidi82 == skibidi89 ? "active" : "";
            string skibidi90() => !skibidi83 ? "launch-state-container" : "launch-state-container\" style=\"display:none;\"";
            string skibidi91() => skibidi83 ? "launch-state-container" : "launch-state-container\" style=\"display:none;\"";

            var skibidi92 = new StringBuilder();
            skibidi92.Append($@"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Gorilla Tag Client</title>
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css"">
    <link href=""https://fonts.googleapis.com/css2?family=Poppins:wght@400;600;700&display=swap"" rel=""stylesheet"">
    <style>
        :root {{
            --primary-color-rgb: 52, 152, 219;
            --danger-color-rgb: 231, 76, 60;
            --light-color: #f0f0f0;
        }}
        @keyframes aurora {{ 0% {{ background-position: 0% 50%; }} 50% {{ background-position: 100% 50%; }} 100% {{ background-position: 0% 50%; }} }}
        body {{ margin: 0; font-family: 'Poppins', sans-serif; height: 100vh; width: 100vw; color: var(--light-color); overflow: hidden; background: linear-gradient(-45deg, #0f0c29, #302b63, #24243e, #0f0c29); background-size: 400% 400%; animation: aurora 15s ease infinite; user-select: none; }}
        ::-webkit-scrollbar {{ width: 8px; }}
        ::-webkit-scrollbar-track {{ background: rgba(0,0,0,0.1); border-radius: 4px; }}
        ::-webkit-scrollbar-thumb {{ background: rgba(var(--primary-color-rgb), 0.4); border-radius: 4px; }}
        ::-webkit-scrollbar-thumb:hover {{ background: rgba(var(--primary-color-rgb), 0.6); }}
        .main-container {{ display: flex; height: 100%; box-sizing: border-box; }}
        .sidebar {{ width: 70px; flex-shrink: 0; background: rgba(0,0,0,0.1); backdrop-filter: blur(15px); border-right: 1px solid rgba(255,255,255,0.1); display: flex; flex-direction: column; align-items: center; padding-top: 20px; gap: 15px; }}
        .nav-item {{ width: 50px; height: 50px; display: flex; justify-content: center; align-items: center; font-size: 1.5rem; color: rgba(255,255,255,0.5); border-radius: 15px; cursor: pointer; transition: all 0.3s ease; }}
        .nav-item:hover {{ background: rgba(var(--primary-color-rgb), 0.3); color: #fff; }}
        .nav-item.active {{ background: rgba(var(--primary-color-rgb), 0.5); color: #fff; box-shadow: 0 0 15px rgba(var(--primary-color-rgb), 0.4); }}
        .content-area {{ flex-grow: 1; position: relative; }}
        .content-page {{ position: absolute; top: 0; left: 0; width: 100%; height: 100%; display: flex; flex-direction: column; justify-content: center; align-items: center; opacity: 0; visibility: hidden; transition: opacity 0.5s ease; pointer-events: none; }}
        .content-page.active {{ opacity: 1; visibility: visible; pointer-events: auto; }}
        .glass-card {{ background: rgba(0, 0, 0, 0.15); border-radius: 25px; box-shadow: 0 15px 35px rgba(0, 0, 0, 0.5); backdrop-filter: blur(25px); border: 1.5px solid rgba(255, 255, 255, 0.1); padding: 2rem; box-sizing: border-box; display: flex; flex-direction: column; overflow: hidden; }}
        .content-card {{ width: 95%; height: 90%; max-width: 1400px; }}
        .home-layout-container {{ display: grid; grid-template-columns: 2fr 1fr; grid-template-rows: 1fr; gap: 25px; width: 95%; height: 90%; }}
        #launch-card {{ justify-content: center; align-items: center; }}
        .home-sidebar {{ display: flex; flex-direction: column; gap: 25px; min-width: 250px; }}
        .home-sidebar > .glass-card {{ min-height: 0; padding: 1.25rem; }}
        #clock-card {{ justify-content: center; align-items: center; text-align: center; flex: 2; }}
        #gpu-card {{ flex: 3; }}
        #gpu-card h3 {{ white-space: nowrap; overflow: hidden; text-overflow: ellipsis; font-size: 1.1rem; margin-bottom: 0.5rem; }}
        .gpu-stats-container {{ display: flex; justify-content: space-around; font-size: 1.25rem; font-weight: 600; margin-bottom: 1rem; }}
        .graph-container {{ flex-grow: 1; width: 100%; }}
        .graph-container svg {{ width: 100%; height: 100%; }}
        .clock-time {{ font-size: clamp(1.5rem, 10vh, 3.5rem); font-weight: 600; }}
        .clock-date {{ font-size: clamp(0.9rem, 3vh, 1.1rem); opacity: 0.8; }}
        h1 {{ font-size: clamp(2.5rem, 8vw, 4.5rem); margin: 0 0 1.5rem 0; color: rgba(255, 255, 255, 0.95); text-shadow: 2px 2px 10px rgba(0,0,0,0.5); text-align: center; }}
        .page-header {{ display: flex; justify-content: space-between; align-items: center; width: 100%; padding-bottom: 1.5rem; }}
        .page-header h2 {{ padding-bottom: 0; text-align: left; }}
        h2 {{ margin: 0; padding-bottom: 1.5rem; color: rgba(255,255,255,0.85); text-align: center; width:100%; }}
        h3 {{ font-size: 1.25rem; font-weight: 600; margin-top: 0; margin-bottom: 1rem; color: rgba(255,255,255,0.9); text-align: left; flex-shrink: 0; width: 100%; padding-bottom: 5px; border-bottom: 1px solid rgba(255,255,255,0.1); }}
        .settings-content h3:first-of-type {{ margin-top: 0; }}
        .settings-content h4 {{ font-size: 1rem; font-weight: 600; margin-top: 20px; margin-bottom: 10px; color: rgba(255,255,255,0.8); width: 100%; text-align: left; }}
        .styled-button {{ display: inline-flex; align-items: center; justify-content: center; padding: 12px 28px; font-size: 1rem; font-weight: 600; color: #fff; background: rgba(var(--primary-color-rgb), 0.35); border: 1px solid rgba(var(--primary-color-rgb), 0.5); border-radius: 12px; cursor: pointer; transition: all 0.3s ease-out; }}
        .styled-button:hover {{ background: rgba(var(--primary-color-rgb), 0.5); transform: translateY(-3px); box-shadow: 0 8px 20px rgba(0, 0, 0, 0.3); }}
        .styled-button:disabled {{ opacity: 0.6; cursor: not-allowed; }}
        .styled-button:disabled:hover {{ transform: none; box-shadow: none; }}
        .launch-button {{ padding: 16px 40px; font-size: 1.2rem; min-width: 280px; box-sizing: border-box; }}
        .launch-state-container {{ display: flex; flex-direction: column; align-items: center; justify-content: center; width: 100%; height: 100%; }}
        .quit-button {{ background: rgba(var(--danger-color-rgb), 0.4); border-color: rgba(var(--danger-color-rgb), 0.6); }}
        .quit-button:hover {{ background: rgba(var(--danger-color-rgb), 0.6); }}
        .scrollable-content {{ width: 100%; height: 100%; text-align: left; overflow-y: auto; }}
        .mods-grid {{ display: grid; grid-template-columns: repeat(auto-fit, 250px); gap: 20px; justify-content: start; }}
        .mod-card {{ background: rgba(0,0,0,0.25); border-radius: 15px; padding: 15px; border: 1px solid rgba(255,255,255,0.1); text-align: center; display: flex; flex-direction: column; transition: transform 0.3s ease; }}
        .mod-card:hover {{ transform: translateY(-5px); }}
        .mod-card img {{ width: 100%; height: 120px; object-fit: cover; border-radius: 10px; margin-bottom: 10px; }}
        .mod-card h3 {{ margin: 0 0 5px; text-align:center; border-bottom: none; }}
        .mod-card p {{ font-size: 0.9rem; color: rgba(255,255,255,0.7); flex-grow: 1; margin-bottom: 15px; }}
        .mod-card .styled-button {{ width: 100%; box-sizing: border-box; }}
        .setting-item {{ display: flex; justify-content: space-between; align-items: center; padding: 15px 5px; border-bottom: 1px solid rgba(255,255,255,0.1); }}
        .setting-item > div {{ display: flex; align-items: center; gap: 10px; }}
        .toggle-switch {{ position: relative; display: inline-block; width: 60px; height: 34px; }}
        .toggle-switch input {{ opacity: 0; width: 0; height: 0; }}
        .slider {{ position: absolute; cursor: pointer; top: 0; left: 0; right: 0; bottom: 0; background-color: rgba(0,0,0,0.3); border-radius: 34px; transition: .4s; }}
        .slider:before {{ position: absolute; content: ''; height: 26px; width: 26px; left: 4px; bottom: 4px; background-color: white; border-radius: 50%; transition: .4s; }}
        input:checked + .slider {{ background-color: rgba(var(--primary-color-rgb), 0.7); }}
        input:checked + .slider:before {{ transform: translateX(26px); }}
        .mod-actions-footer {{ display: flex; justify-content: space-between; align-items: center; width: 100%; }}
        .delete-button {{ background: none; border: none; font-size: 1.2rem; color: rgba(var(--danger-color-rgb), 0.7); cursor: pointer; transition: color 0.3s; padding: 5px; }}
        .delete-button:hover {{ color: rgba(var(--danger-color-rgb), 1.0); }}
        .icon-button {{ background-color: transparent; border: none; width: 35px; height: 35px; cursor: pointer; background-image: url('https://raw.githubusercontent.com/Zyber09/Icons-For-Gorilla-Tag-Client/refs/heads/main/FileIcon.png'); background-size: contain; background-repeat: no-repeat; background-position: center; transition: transform 0.2s ease, filter 0.2s ease; filter: brightness(0.8); }}
        .icon-button:hover {{ transform: scale(1.1); filter: brightness(1); }}
    </style>
</head>
<body>
    <div class=""main-container"">
        <div class=""sidebar"">
            <div class=""nav-item {skibidi86("home")}"" data-page=""home""><i class=""fa-solid fa-gamepad""></i></div>
            <div class=""nav-item {skibidi86("library")}"" data-page=""library""><i class=""fa-solid fa-swatchbook""></i></div>
            <div class=""nav-item {skibidi86("mods")}"" data-page=""mods""><i class=""fa-solid fa-puzzle-piece""></i></div>
            <div class=""nav-item {skibidi86("settings")}"" data-page=""settings""><i class=""fa-solid fa-cog""></i></div>
        </div>
        <div class=""content-area"">
            <div id=""home-page"" class=""content-page {skibidi88("home")}"">
                <div class=""home-layout-container"">
                    <div id=""launch-card"" class=""glass-card"">
                        <div id=""launch-default-state"" class=""{skibidi90()}""><h1>Zyber client</h1><button class=""styled-button launch-button"" onclick=""skibidi102(); skibidi100('launchGame');""><i class=""fas fa-play""></i>&nbsp;&nbsp;<span>LAUNCH GAME</span></button></div>
                        <div id=""launch-intermediate-state"" class=""launch-state-container"" style=""display:none;""><h1>Zyber client</h1><button class=""styled-button launch-button"" disabled><i class=""fa-solid fa-spinner fa-spin""></i>&nbsp;&nbsp;<span>LAUNCHING...</span></button></div>
                        <div id=""launch-active-state"" class=""{skibidi91()}""><h1>Zyber client</h1><button class=""styled-button launch-button quit-button"" onclick=""skibidi100('quitGameProcess')"">Quit Gorilla Tag</button></div>
                    </div>
                    <div class=""home-sidebar"">
                        <div id=""clock-card"" class=""glass-card""><div id=""time-display"" class=""clock-time"">12:00:00 PM</div><div id=""date-display"" class=""clock-date"">Monday, January 1, 2024</div></div>
                        <div id=""gpu-card"" class=""glass-card""><h3 id=""gpu-name-display"" style=""text-align:center;border-bottom:none;"">{skibidi84}</h3><div class=""gpu-stats-container""><span><i class=""fa-solid fa-gauge""></i> <span id=""gpu-util-value"">0</span>%</span><span><i class=""fa-solid fa-temperature-half""></i> <span id=""gpu-temp-value"">0</span>°C</span></div><div class=""graph-container""><svg viewBox=""0 0 100 50"" preserveAspectRatio=""none""><path id=""gpu-util-graph"" fill=""none"" stroke=""rgba(var(--primary-color-rgb), 0.8)"" stroke-width=""2"" d=""""/></svg></div></div>
                    </div>
                </div>
            </div>
            <div id=""library-page"" class=""content-page {skibidi88("library")}""><div class=""glass-card content-card""><div class=""page-header""><h2>Mod Library</h2><button class=""icon-button"" title=""Add custom mod from file"" onclick=""skibidi100('addCustomMod')""></button></div><div class=""scrollable-content""><div class=""mods-grid"">");
            if (skibidi81.Count == 0) { skibidi92.Append(@"<p style='text-align:center; grid-column: 1 / -1;'>No mods found. Go to the Download Mods page to add some!</p>"); }
            else
            {
                foreach (var skibidi93 in skibidi81)
                {
                    string skibidi94 = !string.IsNullOrEmpty(skibidi93.skibidi72) ? skibidi93.skibidi72 : skibidi85;
                    string skibidi95 = !string.IsNullOrEmpty(skibidi93.skibidi71) ? skibidi93.skibidi71 : skibidi93.skibidi69;
                    string skibidi96 = !string.IsNullOrEmpty(skibidi93.skibidi73) ? skibidi93.skibidi73 : "custom mod";
                    string skibidi97 = skibidi93.skibidi70 ? "checked" : "";
                    skibidi92.Append($@"<div class=""mod-card""><img src=""{skibidi94}"" alt=""{skibidi95}""><h3>{skibidi95}</h3><p>{skibidi96}</p><div class=""mod-actions-footer""><label class=""toggle-switch""><input type=""checkbox"" {skibidi97} onchange=""skibidi101('toggleMod:{skibidi93.skibidi69}')""><span class=""slider""></span></label><button class=""delete-button"" onclick=""skibidi101('deleteMod:{skibidi93.skibidi69}:{skibidi93.skibidi70}')""><i class=""fa-solid fa-trash""></i></button></div></div>");
                }
            }
            skibidi92.Append($@"</div></div></div></div>
            <div id=""mods-page"" class=""content-page {skibidi88("mods")}""><div class=""glass-card content-card""><h2>Download Mods</h2><div class=""scrollable-content""><div class=""mods-grid"">");
            foreach (var skibidi98 in skibidi80) { skibidi92.Append($@"<div class=""mod-card""><img src=""{skibidi98.skibidi77}"" alt=""{skibidi98.skibidi75}""><h3>{skibidi98.skibidi75}</h3><p>{skibidi98.skibidi76}</p><button class=""styled-button"" onclick=""skibidi101('downloadMod:{skibidi98.skibidi78}')""><i class=""fa-solid fa-download""></i> Download</button></div>"); }
            skibidi92.Append($@"</div></div></div></div>
            <div id=""settings-page"" class=""content-page {skibidi88("settings")}""><div class=""glass-card content-card""><h2>Settings</h2><div class=""scrollable-content settings-content"">");
            skibidi92.Append($@"<h3>BepInEx Settings</h3>");
            string skibidi99 = null;
            foreach (var skibidi100 in skibidi79.OrderBy(s => s.Key))
            {
                var skibidi101 = skibidi100.Key.Split('.');
                string skibidi102 = string.Join(".", skibidi101.Take(skibidi101.Length - 1));
                string skibidi103 = skibidi101.Last();
                if (skibidi102 != skibidi99) { skibidi99 = skibidi102; skibidi92.Append($@"<h4>{skibidi99}</h4>"); }
                string skibidi104 = skibidi100.Value ? "checked" : "";
                skibidi92.Append($@"<div class=""setting-item""><span>{skibidi103}</span><label class=""toggle-switch""><input type=""checkbox"" {skibidi104} onchange=""skibidi101('updateSetting:{skibidi100.Key}:' + this.checked)""><span class=""slider""></span></label></div>");
            }

            skibidi92.Append($@"</div></div></div></div></div>
    <script>
        const skibidi100 = (skibidi101) => window.chrome?.webview?.postMessage(skibidi101);
        function skibidi101(skibidi102) {{ const skibidi103 = document.querySelector('.nav-item.active')?.dataset.page || 'home'; skibidi100(`${{skibidi102}}:${{skibidi103}}`); }}
        const skibidi104 = document.getElementById('launch-default-state'), skibidi105 = document.getElementById('launch-intermediate-state'), skibidi106 = document.getElementById('launch-active-state');
        const skibidi107 = document.getElementById('gpu-util-value');
        const skibidi108 = document.getElementById('gpu-temp-value');
        const skibidi109 = document.getElementById('gpu-util-graph');
        const skibidi110 = Array(50).fill(0);
        const skibidi111 = 50;

        function skibidi112() {{ skibidi106.style.display = 'none'; skibidi105.style.display = 'none'; skibidi104.style.display = 'flex'; }}
        function skibidi102() {{ skibidi104.style.display = 'none'; skibidi106.style.display = 'none'; skibidi105.style.display = 'flex'; }}
        function skibidi113() {{ skibidi104.style.display = 'none'; skibidi105.style.display = 'none'; skibidi106.style.display = 'flex'; }}

        function skibidi114(skibidi115, skibidi116) {{
            skibidi107.textContent = skibidi115;
            skibidi108.textContent = skibidi116;
            skibidi110.push(skibidi115);
            if (skibidi110.length > skibidi111) {{ skibidi110.shift(); }}
            const skibidi117 = skibidi110.map((skibidi118, skibidi119) => `${{(skibidi119 / (skibidi111 - 1)) * 100}},${{50 - (skibidi118 / 100) * 50}}`);
            skibidi109.setAttribute('d', 'M ' + skibidi117.join(' L '));
        }}

        function skibidi120(skibidi121, skibidi122, skibidi123) {{
            skibidi114(skibidi122, skibidi123);
        }}

        document.querySelectorAll('.nav-item').forEach(skibidi124 => {{
            skibidi124.addEventListener('click', () => {{
                if (skibidi124.classList.contains('active')) return;
                document.querySelector('.nav-item.active')?.classList.remove('active');
                document.querySelector('.content-page.active')?.classList.remove('active');
                skibidi124.classList.add('active');
                document.getElementById(skibidi124.dataset.page + '-page').classList.add('active');
            }});
        }});
        
        const skibidi125 = document.getElementById('time-display'), skibidi126 = document.getElementById('date-display');
        function skibidi127() {{ const skibidi128 = new Date(); skibidi125.textContent = skibidi128.toLocaleTimeString(); skibidi126.textContent = skibidi128.toLocaleDateString(undefined, {{ weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' }}); }}
        setInterval(skibidi127, 1000); skibidi127();
    </script>
</body>
</html>");
            return skibidi92.ToString();
        }
    }
}