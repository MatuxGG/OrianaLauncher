using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrianaLauncher.Class;

namespace OrianaLauncher
{
    public partial class OrianaLauncher : Form
    {
        public string appPath;
        public Utils utils;
        public Applist appList;
        public Componentlist componentList;
        public Pagelist pageList;
        public string activeApp;

        public OrianaLauncher()
        {

            InitializeComponent();

            this.Size = new Size(1920, 1080);
            this.CenterToScreen();

            Start();
        }

        public void Start()
        {
            this.appPath = System.AppDomain.CurrentDomain.BaseDirectory;

            //this.appList = new Applist();
            //this.appList.load();

            this.utils = new Utils();

            this.componentList = new Componentlist(this);
            this.componentList.load();

            this.pageList = new Pagelist(this);
            this.pageList.load();

            this.pageList.renderPage("Main");
        }

    }
}
