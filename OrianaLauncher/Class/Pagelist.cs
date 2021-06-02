using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrianaLauncher.Class
{
    public class Pagelist
    {
        public OrianaLauncher orianaLauncher;

        public List<Page> pages;
        public Pagelist(OrianaLauncher orianaLauncher)
        {
            this.orianaLauncher = orianaLauncher;
            this.pages = new List<Page>();
        }

        public void load()
        {
            this.orianaLauncher.logs.log("\nPagelist : loading");
            this.pages.Add(new Page("Home", new string[] { "Menu", "AppHeader", "Home", "AppDownload" }));

            foreach (App a in this.orianaLauncher.appList.apps)
            {
                if (a.name != "Origin")
                {
                    if (a.changelogEnabled)
                    {
                        this.pages.Add(new Page("Main-" + a.name, new string[] { "Menu", "AppHeader", "AppInfo", "AppChangelog", "AppDownload" }));
                    }
                    else
                    {
                        this.pages.Add(new Page("Main-" + a.name, new string[] { "Menu", "AppHeader", "AppInfoLarge", "AppDownload" }));
                    }
                }
            }

            this.pages.Add(new Page("Settings", new string[] { "Menu", "AppHeader", "Settings", "AppDownload" }));
            this.orianaLauncher.logs.log("Pagelist loaded");

        }

        public void clear()
        {
            this.pages.Clear();
        }

        public void renderPage(string name)
        {
            foreach (Page p in this.pages)
            {
                if (p.name == name)
                {
                    
                    this.orianaLauncher.componentList.renderComponents(p.components);
                }
                else
                {

                }
            }
        }
    }
}
