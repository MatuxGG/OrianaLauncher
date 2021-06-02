using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrianaLauncher.Class
{
    public class AppWorker
    {
        public OrianaLauncher orianaLauncher;
        public BackgroundWorker backgroundWorker;

        public AppWorker(OrianaLauncher orianaLauncher)
        {
            this.orianaLauncher = orianaLauncher;
        }

        public void installApp()
        {
            this.backgroundWorker = new BackgroundWorker();
            this.backgroundWorker.WorkerReportsProgress = true;
            this.InitializeBackgroundWorker();
            this.orianaLauncher.downloadInProgress = true;
            this.orianaLauncher.componentList.changeButtons();

            this.backgroundWorker.RunWorkerAsync();
        }

        private void InitializeBackgroundWorker()
        {

            this.backgroundWorker.DoWork += new DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            this.backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
        }

        public void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorkerCode = sender as BackgroundWorker;

            App activeApp = this.orianaLauncher.appList.apps[this.orianaLauncher.activeApp];
            this.orianaLauncher.logs.log("\nApp Installer : Starting installation for app " + activeApp.name);

            ReleaseAsset asset = new ReleaseAsset();

            backgroundWorker.ReportProgress(0);

            foreach (ReleaseAsset ra in this.orianaLauncher.appList.apps[0].releases.First().Assets)
            {
                if (ra.Name.Contains("zip"))
                {
                    asset = ra;
                    break;
                }
            }

            string path = this.orianaLauncher.tempPath + "\\" + asset.Name;
            this.orianaLauncher.utils.FileDelete(path);


            this.orianaLauncher.logs.log("Downloading client version " + this.orianaLauncher.appList.apps[0].releases.First().Name + " (file : " + asset.Name + ")");
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(asset.BrowserDownloadUrl, path);
                }
            }
            catch
            {
                this.orianaLauncher.logs.log("Error : Error when downloading client\n");
                MessageBox.Show("Error : Can't download client.\n" +
                                    "\n" +
                                    "There are many possible reasons for this :\n" +
                                    "- You are disconnected from internet\n" +
                                    "- Your antivirus blocks Oriana\n", "Can't download client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
            backgroundWorker.ReportProgress(25);
            this.orianaLauncher.logs.log("Client downloaded");
            this.orianaLauncher.logs.log("Extracting client");

            string appPath = this.orianaLauncher.appDataPath + "\\OrianaApps\\" + activeApp.name;

            this.orianaLauncher.utils.DirectoryDelete(appPath);
            Directory.CreateDirectory(appPath);

            ZipFile.ExtractToDirectory(path, appPath);

            backgroundWorker.ReportProgress(50);
            this.orianaLauncher.logs.log("Client extracted");

            foreach (ReleaseAsset ra in activeApp.releases.First().Assets)
            {
                if (ra.Name.Contains("zip"))
                {
                    asset = ra;
                    break;
                }
            }

            path = this.orianaLauncher.tempPath + "\\" + asset.Name;
            this.orianaLauncher.utils.FileDelete(path);

            this.orianaLauncher.logs.log("Downloading app version " + activeApp.releases.First().Name + " (file : " + asset.Name + ")");
            
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(asset.BrowserDownloadUrl, path);
                }
            }
            catch
            {
                this.orianaLauncher.logs.log("Error : Error when downloading app\n");
                MessageBox.Show("Error : Can't download mod.\n" +
                                    "\n" +
                                    "There are many possible reasons for this :\n" +
                                    "- You are disconnected from internet\n" +
                                    "- Your antivirus blocks Oriana\n", "Can't download app", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
            backgroundWorker.ReportProgress(75);

            this.orianaLauncher.logs.log("App downloaded");
            this.orianaLauncher.logs.log("Extracting app");

            ZipFile.ExtractToDirectory(path, appPath);

            this.orianaLauncher.logs.log("App extracted");

            if (this.orianaLauncher.config.containsApp(activeApp.name))
            {
                this.orianaLauncher.config.removeApp(activeApp.name);
            }
            this.orianaLauncher.config.installedApp.Add(new InstalledApp(activeApp.name, activeApp.releases.First().TagName, this.orianaLauncher.appList.apps[0].releases.First().TagName));
            this.orianaLauncher.config.update(this.orianaLauncher);

            backgroundWorker.ReportProgress(100);
            this.orianaLauncher.logs.log("App installed successfully");
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Panel AppDownloadPanel = (Panel) this.orianaLauncher.componentList.get("AppDownload").getControl("AppDownloadPanel");
            ProgressBar AppDownloadBar = (ProgressBar)AppDownloadPanel.Controls["AppDownloadBar"];
            AppDownloadBar.Value = e.ProgressPercentage;
            System.Windows.Forms.Label AppDownloadPercent = (System.Windows.Forms.Label)AppDownloadPanel.Controls["AppDownloadPercent"];
            AppDownloadPercent.Text = e.ProgressPercentage + "%";

            System.Windows.Forms.Label AppDownloadStatus = (System.Windows.Forms.Label)AppDownloadPanel.Controls["AppDownloadStatus"];
            
            if (e.ProgressPercentage == 0)
            {
                AppDownloadStatus.Text = this.orianaLauncher.translator.lg("Downloading Client ...");
            }

            if (e.ProgressPercentage == 25)
            {
                AppDownloadStatus.Text = this.orianaLauncher.translator.lg("Extracting Client ...");
            }
            if (e.ProgressPercentage == 50)
            {
                AppDownloadStatus.Text = this.orianaLauncher.translator.lg("Downloading Mod ...");
            }

            if (e.ProgressPercentage == 75)
            {
                AppDownloadStatus.Text = this.orianaLauncher.translator.lg("Extracting Mod ...");
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Panel AppDownloadPanel = (Panel)this.orianaLauncher.componentList.get("AppDownload").getControl("AppDownloadPanel");
            ProgressBar AppDownloadBar = (ProgressBar)AppDownloadPanel.Controls["AppDownloadBar"];
            AppDownloadBar.Value = 100;
            System.Windows.Forms.Label AppDownloadPercent = (System.Windows.Forms.Label)AppDownloadPanel.Controls["AppDownloadPercent"];
            AppDownloadPercent.Text = "100%";
            System.Windows.Forms.Label AppDownloadStatus = (System.Windows.Forms.Label)AppDownloadPanel.Controls["AppDownloadStatus"];
            AppDownloadStatus.Text = this.orianaLauncher.translator.lg("Completed !");

            this.orianaLauncher.downloadInProgress = false;

            this.orianaLauncher.componentList.changeButtons();
        }
    }
}
