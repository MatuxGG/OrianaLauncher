using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrianaLauncher.Class
{
    public class Applist
    {
        public List<App> apps;

        public OrianaLauncher orianaLauncher;

        public Applist(OrianaLauncher orianaLauncher)
        {
            this.apps = new List<App>();
            this.orianaLauncher = orianaLauncher;
        }

        public async Task load()
        {
            this.apps.Add(new App("Challenger", "MatuxGG", "Challenger-Among-Us", new string[] { }, new string[] { "Beta", "Lite" }, "Among Us.exe", true));
            this.apps.Add(new App("Challenger Lite", "MatuxGG", "Challenger-Among-Us", new string[] { "Lite" }, new string[] { "Beta" }, "Among Us.exe", false));
            this.apps.Add(new App("Challenger Beta", "MatuxGG", "Challenger-Among-Us", new string[] { "Beta" }, new string[] { "Lite" }, "Among Us.exe", false));

            foreach(App a in this.apps)
            {
                await a.getGithubRelease(this.orianaLauncher.token);
            }
        }

        
    }
}
