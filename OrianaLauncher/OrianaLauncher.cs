using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrianaLauncher.Class;

namespace OrianaLauncher
{
    public partial class OrianaLauncher : Form
    {
        public Utils utils;
        public Translator translator;
        public Applist appList;
        public Componentlist componentList;
        public Pagelist pageList;
        public Config config;
        public AppWorker appWorker;
        public Updater updater;

        public string token;
        public string appDataPath;
        public string tempPath;
        public string appPath;
        public Version version;

        public int activeApp;
        public bool downloadInProgress;
        public string currentGithub; 
        public OrianaLauncher()
        {

            InitializeComponent();

            this.Size = new Size(1, 1);
            this.CenterToScreen();

            _ = this.Start();
        }

        public async Task Start()
        {
            this.appPath = System.AppDomain.CurrentDomain.BaseDirectory;
            this.appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OrianaLauncher";
            this.tempPath = Path.GetTempPath() + "\\OrianaLauncher";

            this.utils = new Utils();
            this.translator = new Translator(this);
            this.version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.token = System.IO.File.ReadAllText(this.appPath + "\\token.txt");

            Directory.CreateDirectory(this.appDataPath + "\\OrianaApps");
            Directory.CreateDirectory(this.appDataPath);
            Directory.CreateDirectory(this.tempPath);

            if (System.Diagnostics.Process.GetProcessesByName("OrianaLauncher").Length > 1)
            {
                MessageBox.Show("Oriana Launcher is already running.", "Oriana Launcher already opened", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }

            //Check update
            this.updater = new Updater(this);
            await this.updater.checkUpdate();

            this.downloadInProgress = false;

            this.config = new Config();
            this.config.load(this);


            this.Size = new Size(this.config.resX, this.config.resY);
            this.CenterToScreen();

            this.appList = new Applist(this);
            await this.appList.load();
            this.activeApp = 0;

            this.componentList = new Componentlist(this);
            this.componentList.load();

            this.pageList = new Pagelist(this);
            this.pageList.load();

            this.appWorker = new AppWorker(this);

            this.BackgroundImage = null;

            this.componentList.events.openHomeWorker();
        }

        public void centerToScreenPub()
        {
            this.CenterToScreen();
        }

    }
}
