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
            string path = orianaLauncher.appDataPath + "\\config.json";
            if (File.Exists(path))
            {
                string json = System.IO.File.ReadAllText(path);
                Config config = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(json);
                this.installedApp = config.installedApp;
                this.language = config.language;
                this.resX = config.resX;
                this.resY = config.resY;
                this.update(orianaLauncher);
            } else
            {
                this.installedApp = new List<InstalledApp>();
                this.language = "en_US";

                this.resX = 1920;
                this.resY = 1080;
                foreach (int[] size in this.getResolutions())
                {
                    if (Screen.PrimaryScreen.Bounds.Width > size[0]+100 && Screen.PrimaryScreen.Bounds.Height > size[1]+100)
                    {
                        this.resX = size[0];
                        this.resY = size[1];
                        break;
                    }
                }

                

                this.update(orianaLauncher);
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
            List<int[]> res = new List<int[]>();
            res.Add(new int[] { 1920, 1080 });
            res.Add(new int[] { 1600, 900 });
            res.Add(new int[] { 1368, 768 });
            res.Add(new int[] { 1280, 720 });
            res.Add(new int[] { 960, 540 });
            res.Add(new int[] { 854, 480 });
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
