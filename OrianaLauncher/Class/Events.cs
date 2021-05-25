using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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

        public void changeLg(object sender, EventArgs e)
        {
            ComboBox comboBox = ((ComboBox)sender);
            string selectedLg = comboBox.Text;
            if (selectedLg == "Français")
            {
                this.orianaLauncher.config.language = "fr_FR";
            } else
            {
                this.orianaLauncher.config.language = "en_US";
            }
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
            Process.Start("explorer", appPath);
        }

        public void openDiscord(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://discord.gg/j674KwNG6M");
        }

        public void openGithub(object sender, EventArgs e)
        {
            Process.Start("explorer", this.orianaLauncher.currentGithub);
        }

        public void openHome(object sender, EventArgs e)
        {
            this.openHomeWorker();
        }

        public void openHomeWorker()
        {
            this.orianaLauncher.currentGithub = "https://github.com/MatuxGG/OrianaLauncher";
            this.orianaLauncher.activeApp = 0;
            this.orianaLauncher.componentList.changeMenu();
            this.orianaLauncher.componentList.changeButtons();
            this.orianaLauncher.componentList.changeTitle("Home");
            this.orianaLauncher.pageList.renderPage("Home");
        }

        public void openSettings(object sender, EventArgs e)
        {
            this.openSettingsWorker();
        }

        public void changeResolution(object sender, EventArgs e)
        {
            ComboBox comboBox = ((ComboBox)sender);
            string selectedRes = comboBox.Text;
            int resX = int.Parse(selectedRes.Substring(0, selectedRes.IndexOf("x")));
            int resY = int.Parse(selectedRes.Substring(selectedRes.IndexOf("x") + 1));
            this.orianaLauncher.config.resX = resX;
            this.orianaLauncher.config.resY = resY;
            this.orianaLauncher.config.update(this.orianaLauncher);
            this.orianaLauncher.componentList = new Componentlist(this.orianaLauncher);
            this.orianaLauncher.componentList.load();
            this.orianaLauncher.Size = new Size(resX, resY);
            this.orianaLauncher.centerToScreenPub();
            this.openSettingsWorker();
        }

        public void openSettingsWorker()
        {
            this.orianaLauncher.currentGithub = "https://github.com/MatuxGG/OrianaLauncher";
            this.orianaLauncher.activeApp = this.orianaLauncher.appList.apps.Count();
            this.orianaLauncher.componentList.changeMenu();
            this.orianaLauncher.componentList.changeButtons();
            this.orianaLauncher.componentList.changeTitle("Settings");
            this.orianaLauncher.pageList.renderPage("Settings");
        }

        public void showPreviousRelease(object sender, EventArgs e)
        {
            App a = this.orianaLauncher.appList.apps[this.orianaLauncher.activeApp];
            if (a.currentRelease > 0)
            {
                a.currentRelease--;
                this.orianaLauncher.componentList.changeRelease(a.releases[a.currentRelease]);
            }
            
        }

        public void showNextRelease(object sender, EventArgs e)
        {
            App a = this.orianaLauncher.appList.apps[this.orianaLauncher.activeApp];
            if (a.currentRelease < a.releases.Count)
            {
                a.currentRelease++;
                this.orianaLauncher.componentList.changeRelease(a.releases[a.currentRelease]);
            }
        }

        public void changeApp(object sender, EventArgs e)
        {
            PictureBox clickedLink = ((PictureBox)sender);
            this.orianaLauncher.activeApp = int.Parse(clickedLink.Name.Substring(clickedLink.Name.IndexOf("=") + 1));
            this.orianaLauncher.componentList.changeApp();
        }
    }
}
