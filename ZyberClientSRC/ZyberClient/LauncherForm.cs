//LauncherForm.cs
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using ZyberClient.Core;
using ZyberClient.Models;
using ZyberClient.UI;

namespace ZyberClient.Main
{
    public class LauncherForm : Form
    {
        private Rectangle skibidi129;
        private Panel skibidi130;
        private Label skibidi131;
        private Label skibidi132;
        private Label skibidi133;
        private Label skibidi134;
        private bool skibidi135 = false;
        private Point skibidi136;
        private WebView2 _skibidi137;
        private readonly GameLocator _skibidi138;
        private BepInExManager _skibidi139;
        private ModManager _skibidi140;
        private List<Mod> _skibidi141;
        private System.Windows.Forms.Timer _skibidi142;
        private bool _skibidi143 = false;
        private GPUManager _skibidi144;
        private Process _skibidi145;
        private PictureBox skibidi146;

        private const string skibidi147 = "https://raw.githubusercontent.com/Zyber09/Icons-For-Gorilla-Tag-Client/main/CloseIcon.png";
        private const string skibidi148 = "https://raw.githubusercontent.com/Zyber09/Icons-For-Gorilla-Tag-Client/main/MaximizeIcon.png";
        private const string skibidi149 = "https://raw.githubusercontent.com/Zyber09/Icons-For-Gorilla-Tag-Client/main/MinimizeIcon.png";
        private const string skibidi150 = "https://raw.githubusercontent.com/Zyber09/Icons-For-Gorilla-Tag-Client/refs/heads/main/MoonIcon.png";
        private readonly Size skibidi151 = new Size(20, 20);

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int skibidi152, int skibidi153, int skibidi154, int skibidi155, int skibidi156, int skibidi157);

        public LauncherForm()
        {
            _skibidi138 = new GameLocator();
            _skibidi144 = new GPUManager();
            Init();
            InitWebview();
            initUIUpd();
            this.FormClosing += (skibidi158, skibidi159) => _skibidi144.Dispose();
        }

        private void initUIUpd()
        {
            _skibidi142 = new System.Windows.Forms.Timer { Interval = 250 };
            _skibidi142.Tick += TickyWicky;
            _skibidi142.Start();
        }

        private void TickyWicky(object skibidi160, EventArgs skibidi161)
        {
            bool skibidi162 = _skibidi145 != null && !_skibidi145.HasExited;
            if (skibidi162 != _skibidi143)
            {
                _skibidi143 = skibidi162;
            }
            var skibidi163 = _skibidi144.GetGpuStats();
            _ = _skibidi137?.CoreWebView2?.ExecuteScriptAsync($"skibidi120({_skibidi143.ToString().ToLower()}, {skibidi163.skibidi35:F0}, {skibidi163.skibidi36:F0})");
        }

        private async void Init()
        {
            this.Text = "Zyber Client"; this.Width = 1024; this.Height = 576; this.MinimumSize = new Size(900, 500); this.StartPosition = FormStartPosition.CenterScreen; this.FormBorderStyle = FormBorderStyle.None; this.BackColor = Color.FromArgb(36, 36, 62); this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.Load += (skibidi164, skibidi165) => { skibidi129 = this.Bounds; }; this.Resize += (skibidi166, skibidi167) => { if (this.WindowState == FormWindowState.Normal) { this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); } };
            skibidi130 = new Panel { Dock = DockStyle.Top, Height = 50, BackColor = Color.Transparent };

            skibidi132 = CreateTitleBarButton("✕", "close"); skibidi133 = CreateTitleBarButton("🗖", "maximize"); skibidi134 = CreateTitleBarButton("—", "minimize");
            Image skibidi168 = await LoadImageFromUrlAsync(skibidi147); Image skibidi169 = await LoadImageFromUrlAsync(skibidi148); Image skibidi170 = await LoadImageFromUrlAsync(skibidi149);
            if (skibidi168 != null) { skibidi132.Image = ResizeImage(skibidi168, skibidi151); skibidi132.Text = ""; }
            if (skibidi169 != null) { skibidi133.Image = ResizeImage(skibidi169, skibidi151); skibidi133.Text = ""; }
            if (skibidi170 != null) { skibidi134.Image = ResizeImage(skibidi170, skibidi151); skibidi134.Text = ""; }
            skibidi132.Click += (skibidi171, skibidi172) => this.Close(); skibidi133.Click += (skibidi173, skibidi174) => ToggleMaximize(); skibidi134.Click += (skibidi175, skibidi176) => this.WindowState = FormWindowState.Minimized;

            skibidi146 = new PictureBox
            {
                Dock = DockStyle.Left,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                Image = await LoadImageFromUrlAsync(skibidi150)
            };
            UpdateMoonIconSize();

            skibidi131 = new Label { Text = "Zyber Client", ForeColor = Color.FromArgb(220, 240, 240, 240), Font = new Font("Poppins", 10F, FontStyle.Bold), Dock = DockStyle.Left, TextAlign = ContentAlignment.MiddleLeft, AutoSize = false, Width = 200 };

            skibidi130.Controls.Add(skibidi134); skibidi130.Controls.Add(skibidi133); skibidi130.Controls.Add(skibidi132);
            skibidi130.Controls.Add(skibidi131);
            skibidi130.Controls.Add(skibidi146);
            this.Controls.Add(skibidi130);

            var skibidi177 = new Control[] { skibidi130, skibidi131, skibidi146 };
            foreach (var skibidi178 in skibidi177) { skibidi178.MouseDown += TitleBar_MouseDown; skibidi178.MouseUp += TitleBar_MouseUp; skibidi178.MouseMove += TitleBar_MouseMove; skibidi178.DoubleClick += (skibidi179, skibidi180) => ToggleMaximize(); }
        }

        private void UpdateMoonIconSize()
        {
            if (skibidi146 == null) return;
            int skibidi181 = 30;
            skibidi146.Width = skibidi181 + 20;
            int skibidi182 = (skibidi130.Height - skibidi181) / 2;
            skibidi146.Padding = new Padding(12, skibidi182, 4, skibidi182);
        }

        private async void InitWebview()
        {
            try
            {
                _skibidi137 = new WebView2 { Dock = DockStyle.Fill, DefaultBackgroundColor = Color.Transparent };
                this.Controls.Add(_skibidi137);
                skibidi130.BringToFront();
                await _skibidi137.EnsureCoreWebView2Async(null);
                _skibidi137.CoreWebView2.WebMessageReceived += WebMsgStuff;
                if (!_skibidi138.FindGame()) { MessageBox.Show("Could not find Steam or Gorilla Tag.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Close(); return; }
                _skibidi139 = new BepInExManager(_skibidi138.skibidi29);
                _skibidi140 = new ModManager(_skibidi138.skibidi29);
                _skibidi139.DoBepinexStuff();
                RefreshUI();
            }
            catch (Exception skibidi183) { MessageBox.Show("An error occurred during init (FUCK): " + skibidi183.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Close(); }
        }

        private void RefreshUI(string skibidi184 = "home")
        {
            var skibidi185 = new ModProvider();
            _skibidi141 = skibidi185.GetMods();
            var skibidi186 = _skibidi139.GTS();
            var skibidi187 = _skibidi140.GetInstalledMods(_skibidi141);
            var skibidi188 = new HtmlBuilder();
            if (_skibidi137 != null && _skibidi137.CoreWebView2 != null)
            {
                string skibidi189 = _skibidi144.GetGpuName();
                bool skibidi190 = _skibidi145 != null && !_skibidi145.HasExited;
                _skibidi137.CoreWebView2.NavigateToString(skibidi188.DoHtmlShit(skibidi186, _skibidi141, skibidi187, skibidi184, skibidi190, skibidi189));
            }
        }

        private void WebMsgStuff(object skibidi191, CoreWebView2WebMessageReceivedEventArgs skibidi192)
        {
            string skibidi193 = skibidi192.TryGetWebMessageAsString();
            var skibidi194 = skibidi193.Split(':');
            string skibidi195 = skibidi194[0];
            string skibidi196 = skibidi194.LastOrDefault() ?? "home";
            switch (skibidi195)
            {
                case "updateSetting": _skibidi139.UpdateSetting(skibidi194[1], bool.Parse(skibidi194[2])); RefreshUI(skibidi196); break;
                case "downloadMod": string skibidi197 = string.Join(":", skibidi194.Skip(1).Take(skibidi194.Length - 2)); _skibidi140.DownloadMod(skibidi197); RefreshUI(skibidi196); break;
                case "toggleMod": _skibidi140.GetInstalledMods(_skibidi141).FirstOrDefault(m => m.skibidi69 == skibidi194[1])?.Let(skibidi198 => { if (skibidi198.skibidi70) _skibidi140.DisableMod(skibidi194[1]); else _skibidi140.EnableMod(skibidi194[1]); }); RefreshUI(skibidi196); break;
                case "deleteMod": _skibidi140.DeleteMod(skibidi194[1], bool.Parse(skibidi194[2])); RefreshUI(skibidi196); break;
                case "launchGame": LaunchGorillaTag(); break;
                case "quitGameProcess": QuitGorillaTag(); break;
                case "addCustomMod": ImportTheGoodStuff(); break;
            }
        }

        private void ImportTheGoodStuff()
        {
            var skibidi199 = MessageBox.Show(
                "Do not trust any mods you get from strangers as they could include viruses. Are you sure you want to proceed?",
                "Hold Up cuhz",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (skibidi199 != DialogResult.OK) return;

            using (var skibidi200 = new OpenFileDialog())
            {
                skibidi200.Filter = "Mod files (*.dll)|*.dll";
                skibidi200.Multiselect = true;
                skibidi200.Title = "Select Your Sketchy DLLs";
                if (skibidi200.ShowDialog() == DialogResult.OK)
                {
                    foreach (string skibidi201 in skibidi200.FileNames)
                    {
                        _skibidi140.AddCustomMod(skibidi201);
                    }
                    RefreshUI("library");
                }
            }
        }

        private async void LaunchGorillaTag()
        {
            if (Process.GetProcessesByName("Gorilla Tag").Any())
            {
                MessageBox.Show("Gorilla Tag is already running cuh", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                await _skibidi137.CoreWebView2.ExecuteScriptAsync("skibidi102()");
                Process.Start(new ProcessStartInfo
                {
                    FileName = "steam://run/1533390",
                    UseShellExecute = true
                });

                await FinGorillaTagBattlePass();
            }
            catch (Exception skibidi202)
            {
                if (_skibidi137?.CoreWebView2 != null)
                {
                    await _skibidi137.CoreWebView2.ExecuteScriptAsync("skibidi112()");
                }
            }
        }
        private async Task FinGorillaTagBattlePass() // battlepass!?!?
        {
            for (int skibidi203 = 0; skibidi203 < 20; skibidi203++)
            {
                var skibidi204 = Process.GetProcessesByName("Gorilla Tag");
                if (skibidi204.Length > 0)
                {
                    _skibidi145 = skibidi204[0];
                    _skibidi145.EnableRaisingEvents = true;
                    _skibidi145.Exited += OnGorillaTagExited;
                    this.Invoke(new Action(() => _ = _skibidi137.CoreWebView2.ExecuteScriptAsync("skibidi113()")));
                    return;
                }
                await Task.Delay(1000);
            }
            MessageBox.Show("Could not find Gorilla Tag after launching.", "Process Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            await _skibidi137.CoreWebView2.ExecuteScriptAsync("skibidi112()");
        }

        private void QuitGorillaTag() 
        {
            try { _skibidi145?.Kill(); }
            catch (Exception skibidi205) { MessageBox.Show("Could not close Gorilla Tag:\n" + skibidi205.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void OnGorillaTagExited(object skibidi206, EventArgs skibidi207)
        {
            _skibidi145 = null;
            this.Invoke(new Action(() => _ = _skibidi137.CoreWebView2.ExecuteScriptAsync("skibidi112()")));
        }

        private void ToggleMaximize() { if (this.WindowState == FormWindowState.Maximized) { this.WindowState = FormWindowState.Normal; this.Bounds = skibidi129; this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); } else { skibidi129 = this.Bounds; this.WindowState = FormWindowState.Maximized; this.Region = null; } }
        private async Task<Image> LoadImageFromUrlAsync(string skibidi208) { try { using (HttpClient skibidi209 = new HttpClient()) { skibidi209.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0"); var skibidi210 = await skibidi209.GetAsync(skibidi208); skibidi210.EnsureSuccessStatusCode(); using (var skibidi211 = await skibidi210.Content.ReadAsStreamAsync()) { return Image.FromStream(skibidi211); } } } catch (Exception skibidi212) { Console.WriteLine($"Failed to load image from {skibidi208}: {skibidi212.Message}"); return null; } }

        private void TitleBar_MouseDown(object skibidi213, MouseEventArgs skibidi214) { if (skibidi214.Button == MouseButtons.Left) { skibidi135 = true; skibidi136 = new Point(skibidi214.X, skibidi214.Y); if (skibidi213 is Control skibidi215 && skibidi215.Parent == skibidi130) { skibidi136.X += skibidi215.Location.X; skibidi136.Y += skibidi215.Location.Y; } _skibidi142.Stop(); } }
        private void TitleBar_MouseMove(object skibidi216, MouseEventArgs skibidi217) { if (skibidi135) { Point skibidi218 = PointToScreen(skibidi217.Location); this.Location = new Point(skibidi218.X - skibidi136.X, skibidi218.Y - skibidi136.Y); } }
        private void TitleBar_MouseUp(object skibidi219, MouseEventArgs skibidi220) { skibidi135 = false; _skibidi142.Start(); }

        private Label CreateTitleBarButton(string skibidi221, string skibidi222) { var skibidi223 = new Label { Text = skibidi221, Name = skibidi222, Dock = DockStyle.Right, Size = new Size(50, 50), ForeColor = Color.FromArgb(220, 240, 240, 240), BackColor = Color.Transparent, Font = new Font("Segoe UI Symbol", 10F, FontStyle.Regular), TextAlign = ContentAlignment.MiddleCenter, ImageAlign = ContentAlignment.MiddleCenter }; skibidi223.MouseEnter += (skibidi224, skibidi225) => { if (skibidi223.Name == "close") skibidi223.BackColor = Color.FromArgb(200, 231, 76, 60); else skibidi223.BackColor = Color.FromArgb(38, 255, 255, 255); }; skibidi223.MouseLeave += (skibidi226, skibidi227) => skibidi223.BackColor = Color.Transparent; return skibidi223; }
        private Image ResizeImage(Image skibidi228, Size skibidi229) { var skibidi230 = new Bitmap(skibidi229.Width, skibidi229.Height); using (var skibidi231 = Graphics.FromImage(skibidi230)) { skibidi231.CompositingQuality = CompositingQuality.HighQuality; skibidi231.InterpolationMode = InterpolationMode.HighQualityBicubic; skibidi231.SmoothingMode = SmoothingMode.HighQuality; skibidi231.DrawImage(skibidi228, 0, 0, skibidi229.Width, skibidi229.Height); } return skibidi230; }
        protected override void WndProc(ref Message skibidi232) { const int skibidi233 = 0x84; const int skibidi234 = 13, skibidi235 = 14, skibidi236 = 16, skibidi237 = 17; if (skibidi232.Msg == skibidi233 && this.WindowState != FormWindowState.Maximized) { base.WndProc(ref skibidi232); Point skibidi238 = this.PointToClient(new Point(skibidi232.LParam.ToInt32())); int skibidi239 = 10; if (skibidi238.X < skibidi239 && skibidi238.Y < skibidi239) skibidi232.Result = (IntPtr)skibidi234; else if (skibidi238.X > this.ClientSize.Width - skibidi239 && skibidi238.Y < skibidi239) skibidi232.Result = (IntPtr)skibidi235; else if (skibidi238.X < skibidi239 && skibidi238.Y > this.ClientSize.Height - skibidi239) skibidi232.Result = (IntPtr)skibidi236; else if (skibidi238.X > this.ClientSize.Width - skibidi239 && skibidi238.Y > this.ClientSize.Height - skibidi239) skibidi232.Result = (IntPtr)skibidi237; return; } base.WndProc(ref skibidi232); }
    }

    public static class ObjectExtensions { public static void Let<T>(this T skibidi240, Action<T> skibidi241) { if (skibidi240 != null) { skibidi241(skibidi240); } } }
}