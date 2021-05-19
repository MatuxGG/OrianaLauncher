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

        public Version version;

        public InstalledApp(string name, Version version)
        {
            this.name = name;
            this.version = version;
        }
    }
}
