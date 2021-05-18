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
            this.pages.Add(new Page("Main", new string[] { "Menu", "AppHeader", "AppInfo", "AppChangelog", "AppDownload" })) ;
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
