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
            this.orianaLauncher.logs.log("\nEvent : Changing language to " + selectedLg);
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
            this.orianaLauncher.logs.log("\nEvent : Installing app");
            this.orianaLauncher.appWorker.installApp();
        }

        public void startApp(object sender, EventArgs e)
        {
            App activeApp = this.orianaLauncher.appList.apps[this.orianaLauncher.activeApp];
            this.orianaLauncher.logs.log("\nEvent : Starting app " + activeApp.name);
            string appPath = this.orianaLauncher.appDataPath + "\\OrianaApps\\" + activeApp.name + "\\" + activeApp.appFile;
            Process.Start("explorer", appPath);
        }

        public void openDiscord(object sender, EventArgs e)
        {
            this.orianaLauncher.logs.log("\nEvent : Opening discord");
            Process.Start("explorer", "https://discord.gg/j674KwNG6M");
        }

        public void openGithub(object sender, EventArgs e)
        {
            this.orianaLauncher.logs.log("\nEvent : Opening github");
            Process.Start("explorer", this.orianaLauncher.currentGithub);
        }

        public void openHome(object sender, EventArgs e)
        {
            this.openHomeWorker();
        }

        public void openHomeWorker()
        {
            this.orianaLauncher.logs.log("\nEvent : Opening home page");
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
            this.orianaLauncher.logs.log("\nEvent : Changing resolution to " + selectedRes);
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
            this.orianaLauncher.logs.log("\nEvent : Opening settings page");
            this.orianaLauncher.currentGithub = "https://github.com/MatuxGG/OrianaLauncher";
            this.orianaLauncher.activeApp = this.orianaLauncher.appList.apps.Count();
            this.orianaLauncher.componentList.changeMenu();
            this.orianaLauncher.componentList.changeButtons();
            this.orianaLauncher.componentList.changeTitle("Settings");
            this.orianaLauncher.pageList.renderPage("Settings");
        }

        public void showPreviousRelease(object sender, EventArgs e)
        {
            this.orianaLauncher.logs.log("\nEvent : Showing previous release");
            App a = this.orianaLauncher.appList.apps[this.orianaLauncher.activeApp];
            if (a.currentRelease > 0)
            {
                a.currentRelease--;
                this.orianaLauncher.componentList.changeRelease(a.releases[a.currentRelease]);
            }
            
        }

        public void showNextRelease(object sender, EventArgs e)
        {
            this.orianaLauncher.logs.log("\nEvent : Showing next release");
            App a = this.orianaLauncher.appList.apps[this.orianaLauncher.activeApp];
            if (a.currentRelease < a.releases.Count)
            {
                a.currentRelease++;
                this.orianaLauncher.componentList.changeRelease(a.releases[a.currentRelease]);
            }
        }

        public void changeApp(object sender, EventArgs e)
        {
            this.orianaLauncher.logs.log("\nEvent : Changing app");
            PictureBox clickedLink = ((PictureBox)sender);
            this.orianaLauncher.activeApp = int.Parse(clickedLink.Name.Substring(clickedLink.Name.IndexOf("=") + 1));
            this.orianaLauncher.componentList.changeApp();
        }
    }
}
