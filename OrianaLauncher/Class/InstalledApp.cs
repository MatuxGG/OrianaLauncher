using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrianaLauncher.Class
{
    public class InstalledApp
    {
        public string name;

        public string version;

        public InstalledApp(string name, string version)
        {
            this.name = name;
            this.version = version;
        }
    }
}
