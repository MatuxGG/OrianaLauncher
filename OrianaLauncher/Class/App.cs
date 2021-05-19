﻿using Octokit;
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

        public Release release;

        public string[] strIncluded;

        public string[] strExcluded;

        public string appFile;

        public bool changelogEnabled;

        public App(string name, string author, string github, string[] strIncluded, string[] strExcluded, string appFile, bool changelogEnabled)
        {
            this.name = name;
            this.author = author;
            this.github = github;
            this.strIncluded = strIncluded;
            this.strExcluded = strExcluded;
            this.appFile = appFile;
            this.changelogEnabled = changelogEnabled;
            this.release = new Release();
        }

        public async Task getGithubRelease(string token)
        {
            var client = new GitHubClient(new ProductHeaderValue("OrianaLauncher"));
            var tokenAuth = new Credentials(token);
            client.Credentials = tokenAuth;
            IReadOnlyList<Release> releases = await client.Repository.Release.GetAll(this.author, this.github);
            foreach (Release r in releases)
            {
                Boolean isRelease = true;
                foreach (string strI in this.strIncluded)
                {
                    if (r.TagName.Contains(strI) == false)
                    {
                        isRelease = false;
                    }
                }

                foreach (string strE in this.strExcluded)
                {
                    if (r.TagName.Contains(strE) == true)
                    {
                        isRelease = false;
                    }
                }
                
                if (isRelease == true)
                {
                    this.release = r;
                    return;
                }
            }
            return;
        }
    }
}
