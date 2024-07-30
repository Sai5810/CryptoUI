using DevExpress.XtraBars.Docking;
using System.Threading;

namespace CryptoUI
{
    public partial class App : DevExpress.XtraEditors.XtraForm
    {
        public App(Splash splash)
        {
            splash.Update("Starting Python Reference data");
            Network.IronPythonConfiguration.run(splash);
            splash.Update("Starting UI Component Load");
            this.InitializeComponent();
            this.InitializeComponentOrderManagement();
            this.InitializeComponentEventManager();
            this.InitializeComponentParamManagement();
            this.em.setParamManager();
            splash.Update("Starting Network Stack");
            this.StartEventManager();
            this.InitializeOrderManagementClOrdId();
        }
        public void soundThread(string url)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = url;
                player.Play();
            }).Start();
        }
        bool IsPanelAutoHiddenBottom(DockPanel panel)
        {
            AutoHideContainer bottomContainer =
              panel.DockManager.AutoHideContainers[DevExpress.XtraBars.Docking.DockingStyle.Bottom];
            if (bottomContainer == null) return false;
            return bottomContainer.Contains(panel);
        }
        private void dockManagerRavenMain_ClosingPanel(object sender, DevExpress.XtraBars.Docking.DockPanelCancelEventArgs e)
        {
            // Cancel the default closing mechanism.
            e.Cancel = true;
            if (IsPanelAutoHiddenBottom(e.Panel)) return;
            // Disable the auto-hide functionality if the panel is auto-hidden.
            if (e.Panel.Visibility == DockVisibility.AutoHide)
                e.Panel.Visibility = DockVisibility.Visible;
            // Dock the panel to the bottom edge of the form and enable its auto-hide functionality.
            e.Panel.DockTo(DevExpress.XtraBars.Docking.DockingStyle.Bottom);
            e.Panel.Visibility = DockVisibility.AutoHide;
        }

        private void orderManagementPanelSymbolBox_EditValueChanged(object sender, System.EventArgs e)
        {

        }
    }
}
