using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrianaLauncher.Class
{
    public class Events
    {
        public OrianaLauncher orianaLauncher;

        public Events(OrianaLauncher orianaLauncher)
        {
            this.orianaLauncher = orianaLauncher;
        }

        public void changeLgToFR(object sender, EventArgs e)
        {
            this.orianaLauncher.config.language = "fr_FR";
            this.orianaLauncher.config.update(orianaLauncher);

            this.orianaLauncher.componentList.refresh();
            this.orianaLauncher.pageList.renderPage("Main-"+this.orianaLauncher.appList.apps[this.orianaLauncher.activeApp].name);
        }

        public void changeLgToUS(object sender, EventArgs e)
        {
            this.orianaLauncher.config.language = "en_US";
            this.orianaLauncher.config.update(orianaLauncher);
            this.orianaLauncher.componentList.refresh();
        }

        public void installApp(object sender, EventArgs e)
        {
            this.orianaLauncher.appWorker.installApp();
        }

        public void startApp(object sender, EventArgs e)
        {
            App activeApp = this.orianaLauncher.appList.apps[this.orianaLauncher.activeApp];
            string appPath = this.orianaLauncher.appPath + "OrianaApps\\" + activeApp.name + "\\" + activeApp.appFile;
            MessageBox.Show(appPath, "Oriana Launcher already opened", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start("explorer", appPath);
        }

        public void openDiscord(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://discord.gg/j674KwNG6M");
        }

        public void openGithub(object sender, EventArgs e)
        {
            //Process.Start("explorer", "https://discord.gg/j674KwNG6M");
        }

        public void changeApp(object sender, EventArgs e)
        {
            PictureBox clickedLink = ((PictureBox)sender);
            this.orianaLauncher.activeApp = int.Parse(clickedLink.Name.Substring(clickedLink.Name.IndexOf("=") + 1));
            this.orianaLauncher.componentList.changeApp();
        }
    }
}
