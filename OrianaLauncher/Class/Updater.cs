using Octokit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrianaLauncher.Class
{
    public class Updater
    {
        public OrianaLauncher orianaLauncher { get; set; }
        public Version latestVersion { get; set; }
        public Release latestRelease { get; set; }
        public Updater(OrianaLauncher orianaLauncher)
        {
            this.orianaLauncher = orianaLauncher;
            this.latestVersion = null;
            this.latestRelease = null;
        }

        public async Task checkUpdate()
        {
            this.orianaLauncher.logs.log("\nUpdater : Check update");
            await this.GetGithubVersion();

            if (this.latestVersion > this.orianaLauncher.version)
            {
                this.orianaLauncher.logs.log("Update found");
                string installerPath = this.orianaLauncher.tempPath + "\\OrianaInstaller.exe";
                DialogResult userAction = MessageBox.Show("There is a new version of Oriana Launcher available. Oriana Launcher will auto update.\n\n" +
                    "Press OK to continue.", "Oriana Launcher Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (userAction == DialogResult.OK)
                {
                    this.orianaLauncher.utils.FileDelete(installerPath);
                    foreach (ReleaseAsset ra in this.latestRelease.Assets)
                    {
                        if (ra.Name == "OrianaInstaller.exe")
                        {
                            try
                            {
                                using (WebClient client = new WebClient())
                                {
                                    client.DownloadFile(ra.BrowserDownloadUrl, installerPath);
                                }
                            }
                            catch
                            {
                                this.orianaLauncher.logs.log("Error during download of new version");
                                MessageBox.Show("Error : Can't download new version of Oriana Launcher.\n" +
                                    "\n" +
                                    "There are many possible reasons for this :\n" +
                                    "- You are disconnected from internet\n" +
                                    "- Your antivirus blocks Oriana\n", "Can't download update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Environment.Exit(0);
                            }
                            this.orianaLauncher.logs.log("Processing update");
                            Process.Start(installerPath);
                            Environment.Exit(0);
                        }
                    }
                }
                Environment.Exit(0);

            }
            else
            {
                this.orianaLauncher.logs.log("No update available");
            }
        }

        public async Task GetGithubVersion()
        {
            var client = new GitHubClient(new ProductHeaderValue("OrianaLauncher"));
            var tokenAuth = new Credentials(this.orianaLauncher.token);
            client.Credentials = tokenAuth;
            this.latestVersion = null;
            Release r = await client.Repository.Release.GetLatest("MatuxGG", "OrianaLauncher");
            this.latestRelease = r;
            this.latestVersion = Version.Parse(r.TagName);
        }
    }
}
