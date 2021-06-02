using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace OrianaLauncher.Class
{
    public class Config
    {
        public List<InstalledApp> installedApp { get; set; }
        public string language;
        public int resX;
        public int resY;

        public Config()
        {
            this.installedApp = new List<InstalledApp>();
            this.language = "en_US";
            this.resX = 1920;
            this.resY = 1080;
        }

        public void load(OrianaLauncher orianaLauncher)
        {
            orianaLauncher.logs.log("\nConfig : Loading");
            string path = orianaLauncher.appDataPath + "\\config.json";
            if (File.Exists(path))
            {
                orianaLauncher.logs.log("Config exists");
                string json = System.IO.File.ReadAllText(path);
                Config config = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(json);
                this.installedApp = config.installedApp;
                this.language = config.language;
                this.resX = config.resX;
                this.resY = config.resY;
                this.update(orianaLauncher);
            } else
            {
                orianaLauncher.logs.log("Config doesn't exist");
                this.installedApp = new List<InstalledApp>();
                this.language = "en_US";

                this.resX = 1920;
                this.resY = 1080;
                int[] size = this.getResolutions().First();
                this.resX = size[0];
                this.resY = size[1];

                this.update(orianaLauncher);
            }
            orianaLauncher.logs.log("Config loaded");
            orianaLauncher.logs.log("Config :");
            orianaLauncher.logs.log("- Language : " + this.language);
            orianaLauncher.logs.log("- Resolution : " + this.resX + "x" + this.resY);
            orianaLauncher.logs.log("- Installed app :");
            foreach (InstalledApp ia in this.installedApp)
            {
                orianaLauncher.logs.log("-- App : " + ia.name);
            }
            return;
        }

        public void update(OrianaLauncher orianaLauncher)
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(orianaLauncher.appDataPath + "\\config.json", json);
        }

        public List<int[]> getResolutions()
        {
            List<int[]> temp = new List<int[]>();
            temp.Add(new int[] { 1920, 1080 });
            temp.Add(new int[] { 1600, 900 });
            temp.Add(new int[] { 1368, 768 });
            temp.Add(new int[] { 1280, 720 });
            temp.Add(new int[] { 960, 540 });
            temp.Add(new int[] { 854, 480 });

            List<int[]> res = new List<int[]>();
            foreach (int[] r in temp)
            {
                if (r[0] + 100 < Screen.PrimaryScreen.Bounds.Width && r[1] + 100 < Screen.PrimaryScreen.Bounds.Height)
                {
                    res.Add(r);
                }
            }
            return res;
        }

        public InstalledApp getApp(string name)
        {
            foreach(InstalledApp a in this.installedApp)
            {
                if (a.name == name)
                {
                    return a;
                }
            }
            return null;
        }

        public bool containsApp(string name)
        {
            foreach (InstalledApp a in this.installedApp)
            {
                if (a.name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public void removeApp(string name)
        {
            foreach (InstalledApp a in this.installedApp)
            {
                if (a.name == name)
                {
                    this.installedApp.Remove(a);
                    return;
                }
            }
            return;
        }
    }
}
