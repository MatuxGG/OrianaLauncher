using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrianaLauncher.Class
{
    public class App
    {
        public string name;

        public string author;

        public string github;

        public App(string name, string author, string github)
        {
            this.name = name;
            this.author = author;
            this.github = github;
        }
        
    }
}
