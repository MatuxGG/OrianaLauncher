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

        public string clientVersion;

        public InstalledApp(string name, string version, string clientVersion)
        {
            this.name = name;
            this.version = version;
            this.clientVersion = clientVersion;
        }
    }
}
