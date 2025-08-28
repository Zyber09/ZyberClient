//program.cs
using System;
using System.Drawing;
using System.Windows.Forms;
using ZyberClient.Main;

namespace ZyberClient
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LauncherForm skibidi242 = new LauncherForm();
            skibidi242.Icon = new Icon("MoonIcon.ico");
            Application.Run(skibidi242);
        }
    }
}