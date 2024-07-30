using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CryptoUI
{
    internal static class Program
    {
        static Splash splash_ptr = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // http://stackoverflow.com/questions/13228185/how-to-configure-an-app-to-run-correctly-on-a-machine-with-a-high-dpi-setting-e
            if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();
            // 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            ShowSplash();
            Application.Run(new App(splash_ptr));
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        private static void ShowSplash()
        {
            Splash sp = new Splash();
            splash_ptr = sp;
            sp.Show();
            Application.DoEvents();

            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler((sender, ea) =>
            {
                sp.BeginInvoke(new Action(() =>
                {
                    if (sp != null && Application.OpenForms.Count > 1)
                    {
                        sp.Close();
                        sp.Dispose();
                        sp = null;
                        t.Stop();
                        t.Dispose();
                        t = null;
                    }
                }));
            });
            t.Start();
        }
    }
}
