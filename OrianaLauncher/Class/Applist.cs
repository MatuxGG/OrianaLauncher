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
            this.apps.Add(new App("Origin", "Lunastellia", "Challenger-Among-Us", new string[] { "C" }, new string[] { "B", "L" }, "Among Us.exe", false));
            this.apps.Add(new App("Challenger", "Lunastellia", "Challenger-Among-Us", new string[] { }, new string[] { "B", "L", "C", "A" }, "Among Us.exe", true));
            this.apps.Add(new App("Challenger Lite", "Lunastellia", "Challenger-Among-Us", new string[] { "L" }, new string[] { "B", "C", "A" }, "Among Us.exe", false));
            this.apps.Add(new App("Challenger Beta", "Lunastellia", "Challenger-Among-Us", new string[] { "B" }, new string[] { "L", "C", "A" }, "Among Us.exe", false));

            foreach(App a in this.apps)
            {
                await a.getGithubRelease(this.orianaLauncher.token);
            }
        }

        
    }
}
