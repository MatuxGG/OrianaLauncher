using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OrianaLauncher.Class
{
    public class Config
    {
        public List<InstalledApp> installedApp { get; set; }
        public string language;

        public Config()
        {
            this.installedApp = new List<InstalledApp>();
            this.language = "en_US";
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
                this.update(orianaLauncher);
            } else
            {
                this.installedApp = new List<InstalledApp>();
                this.language = "en_US";
                this.update(orianaLauncher);
            }
            return;
        }

        public void update(OrianaLauncher orianaLauncher)
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(orianaLauncher.appDataPath + "\\config.json", json);
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
