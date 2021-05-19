using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrianaLauncher.Class
{

    public class Componentlist
    {
        public List<Component> components;

        public OrianaLauncher orianaLauncher;

        public Events events;

        public Componentlist(OrianaLauncher orianaLauncher)
        {
            this.orianaLauncher = orianaLauncher;
            this.components = new List<Component>();
            this.events = new Events(this.orianaLauncher);
        }

        public void load()
        {
            this.orianaLauncher.Controls.Clear();

            double ratioX = (double) 1920 / 1920.0;
            double ratioY = (double) 1080 / 1080.0;

            Component c = new Component("Menu");

            Panel MenuPanel = new Panel();
            MenuPanel.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(0 * ratioY));
            MenuPanel.Name = "MenuPanel";
            MenuPanel.BackColor = Color.Transparent;
            MenuPanel.BorderStyle = BorderStyle.None;
            MenuPanel.Size = new System.Drawing.Size((int)(140 * ratioX), (int)(1040 * ratioY));
            MenuPanel.TabStop = false;
            MenuPanel.Visible = false;
            this.orianaLauncher.Controls.Add(MenuPanel);
            c.addControl(MenuPanel);

            int offset = 0;
            foreach(App a in this.orianaLauncher.appList.apps)
            {
                PictureBox AppPic = new System.Windows.Forms.PictureBox();
                AppPic.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                AppPic.Location = new System.Drawing.Point((int)(20 * ratioX), (int)((20 + 120*offset) * ratioY));
                if (offset == 0 || offset > 2)
                {
                    AppPic.BackgroundImage = global::OrianaLauncher.Properties.Resources.challenger;
                } else if (offset == 1)
                {
                    AppPic.BackgroundImage = global::OrianaLauncher.Properties.Resources.challengerLite;
                } else if (offset == 2)
                {
                    AppPic.BackgroundImage = global::OrianaLauncher.Properties.Resources.challengerBeta;
                }

                AppPic.BackgroundImageLayout = ImageLayout.Stretch;
                AppPic.Name = "AppPic="+offset;
                AppPic.Size = new System.Drawing.Size((int)(100 * ratioX), (int)(100 * ratioY));
                AppPic.Cursor = Cursors.Hand;
                AppPic.TabStop = false;
                AppPic.Click += new EventHandler(this.events.changeApp);
                MenuPanel.Controls.Add(AppPic);
                offset++;
            }

            this.components.Add(c);

            c = new Component("AppHeader");

            Panel AppHeaderPanel = new Panel();
            AppHeaderPanel.Location = new System.Drawing.Point((int)(140 * ratioX), (int)(0 * ratioY));
            AppHeaderPanel.Name = "AppHeaderPanel";
            AppHeaderPanel.BackColor = Color.Transparent;
            AppHeaderPanel.BorderStyle = BorderStyle.None;
            AppHeaderPanel.Size = new System.Drawing.Size((int)(1765 * ratioX), (int)(150 * ratioY));
            AppHeaderPanel.TabStop = false;
            AppHeaderPanel.Visible = false;
            this.orianaLauncher.Controls.Add(AppHeaderPanel);
            c.addControl(AppHeaderPanel);

            System.Windows.Forms.Label AppHeaderTitle = new System.Windows.Forms.Label();
            AppHeaderTitle.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppHeaderTitle.ForeColor = System.Drawing.SystemColors.Control;
            AppHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;
            AppHeaderTitle.BorderStyle = BorderStyle.Fixed3D;
            AppHeaderTitle.Location = new System.Drawing.Point((int)(10 * ratioX), (int)(10 * ratioY));
            AppHeaderTitle.Name = "AppHeaderTitle";
            AppHeaderTitle.Size = new System.Drawing.Size((int)(1470 * ratioX), (int)(130 * ratioY));
            AppHeaderTitle.Text = "Challenger";
            AppHeaderPanel.Controls.Add(AppHeaderTitle);

            PictureBox AppHeaderFR = new System.Windows.Forms.PictureBox();
            AppHeaderFR.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppHeaderFR.Location = new System.Drawing.Point((int)(1550 * ratioX), (int)(15 * ratioY));
            AppHeaderFR.BackgroundImage = global::OrianaLauncher.Properties.Resources.fr;
            AppHeaderFR.BackgroundImageLayout = ImageLayout.Stretch;
            AppHeaderFR.Name = "AppHeaderFR";
            AppHeaderFR.Size = new System.Drawing.Size((int)(50 * ratioX), (int)(50 * ratioY));
            AppHeaderFR.Cursor = Cursors.Hand;
            AppHeaderFR.TabStop = false;
            AppHeaderFR.Click += new EventHandler(this.events.changeLgToFR);
            AppHeaderPanel.Controls.Add(AppHeaderFR);

            PictureBox AppHeaderUS = new System.Windows.Forms.PictureBox();
            AppHeaderUS.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppHeaderUS.Location = new System.Drawing.Point((int)(1650 * ratioX), (int)(15 * ratioY));
            AppHeaderUS.BackgroundImage = global::OrianaLauncher.Properties.Resources.us;
            AppHeaderUS.BackgroundImageLayout = ImageLayout.Stretch;
            AppHeaderUS.Name = "AppHeaderUS";
            AppHeaderUS.Size = new System.Drawing.Size((int)(50 * ratioX), (int)(50 * ratioY));
            AppHeaderUS.Cursor = Cursors.Hand;
            AppHeaderUS.TabStop = false;
            AppHeaderUS.Click += new EventHandler(this.events.changeLgToUS);
            AppHeaderPanel.Controls.Add(AppHeaderUS);

            PictureBox AppHeaderDiscord = new System.Windows.Forms.PictureBox();
            AppHeaderDiscord.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppHeaderDiscord.Location = new System.Drawing.Point((int)(1550 * ratioX), (int)(85 * ratioY));
            AppHeaderDiscord.BackgroundImage = global::OrianaLauncher.Properties.Resources.discord;
            AppHeaderDiscord.BackgroundImageLayout = ImageLayout.Stretch;
            AppHeaderDiscord.Name = "AppHeaderDiscord";
            AppHeaderDiscord.Size = new System.Drawing.Size((int)(50 * ratioX), (int)(50 * ratioY));
            AppHeaderDiscord.Cursor = Cursors.Hand;
            AppHeaderDiscord.TabStop = false;
            AppHeaderDiscord.Click += new EventHandler(this.events.openDiscord);
            AppHeaderPanel.Controls.Add(AppHeaderDiscord);

            PictureBox AppHeaderGithub = new System.Windows.Forms.PictureBox();
            AppHeaderGithub.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppHeaderGithub.Location = new System.Drawing.Point((int)(1650 * ratioX), (int)(85 * ratioY));
            AppHeaderGithub.BackgroundImage = global::OrianaLauncher.Properties.Resources.github;
            AppHeaderGithub.BackgroundImageLayout = ImageLayout.Stretch;
            AppHeaderGithub.Name = "AppHeaderGithub";
            AppHeaderGithub.Size = new System.Drawing.Size((int)(50 * ratioX), (int)(50 * ratioY));
            AppHeaderGithub.Cursor = Cursors.Hand;
            AppHeaderGithub.TabStop = false;
            AppHeaderGithub.Click += new EventHandler(this.events.openGithub);
            AppHeaderPanel.Controls.Add(AppHeaderGithub);

            this.components.Add(c);

            c = new Component("AppInfo");

            Panel AppInfoPanel = new Panel();
            AppInfoPanel.Location = new System.Drawing.Point((int)(145 * ratioX), (int)(155 * ratioY));
            AppInfoPanel.Name = "AppInfoPanel";
            AppInfoPanel.BackColor = Color.Transparent;
            AppInfoPanel.BorderStyle = BorderStyle.Fixed3D;
            AppInfoPanel.Size = new System.Drawing.Size((int)(1140 * ratioX), (int)(740 * ratioY));
            AppInfoPanel.TabStop = false;
            AppInfoPanel.Visible = false;
            AppInfoPanel.AutoScroll = false;
            AppInfoPanel.HorizontalScroll.Enabled = false;
            AppInfoPanel.HorizontalScroll.Visible = false;
            AppInfoPanel.HorizontalScroll.Maximum = 0;
            AppInfoPanel.AutoScroll = true;
            this.orianaLauncher.Controls.Add(AppInfoPanel);
            c.addControl(AppInfoPanel);

            System.Windows.Forms.Label AppInfoLabel = new System.Windows.Forms.Label();
            AppInfoLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppInfoLabel.ForeColor = System.Drawing.SystemColors.Control;
            AppInfoLabel.TextAlign = ContentAlignment.TopLeft;
            AppInfoLabel.Location = new System.Drawing.Point((int)(5 * ratioX), (int)(5 * ratioY));
            AppInfoLabel.Name = "AppInfoLabel";
            AppInfoLabel.AutoSize = true;
            AppInfoLabel.Text = "Info lite";
            AppInfoPanel.Controls.Add(AppInfoLabel);

            this.components.Add(c);

            c = new Component("AppInfoLarge");

            Panel AppInfoLargePanel = new Panel();
            AppInfoLargePanel.Location = new System.Drawing.Point((int)(145 * ratioX), (int)(155 * ratioY));
            AppInfoLargePanel.Name = "AppInfoLargePanel";
            AppInfoLargePanel.BackColor = Color.Transparent;
            AppInfoLargePanel.BorderStyle = BorderStyle.Fixed3D;
            AppInfoLargePanel.Size = new System.Drawing.Size((int)(1755 * ratioX), (int)(740 * ratioY));
            AppInfoLargePanel.TabStop = false;
            AppInfoLargePanel.Visible = false;
            AppInfoLargePanel.AutoScroll = false;
            AppInfoLargePanel.HorizontalScroll.Enabled = false;
            AppInfoLargePanel.HorizontalScroll.Visible = false;
            AppInfoLargePanel.HorizontalScroll.Maximum = 0;
            AppInfoLargePanel.AutoScroll = true;
            this.orianaLauncher.Controls.Add(AppInfoLargePanel);
            c.addControl(AppInfoLargePanel);

            System.Windows.Forms.Label AppInfoLargeLabel = new System.Windows.Forms.Label();
            AppInfoLargeLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppInfoLargeLabel.ForeColor = System.Drawing.SystemColors.Control;
            AppInfoLargeLabel.TextAlign = ContentAlignment.TopLeft;
            AppInfoLargeLabel.Location = new System.Drawing.Point((int)(5 * ratioX), (int)(5 * ratioY));
            AppInfoLargeLabel.Name = "AppInfoLargeLabel";
            AppInfoLargeLabel.AutoSize = true;
            AppInfoLargeLabel.Text = "Info large";
            AppInfoLargePanel.Controls.Add(AppInfoLargeLabel);

            this.components.Add(c);

            c = new Component("AppChangelog");

            Panel AppChangelogPanel = new Panel();
            AppChangelogPanel.Location = new System.Drawing.Point((int)(1290 * ratioX), (int)(155 * ratioY));
            AppChangelogPanel.Name = "AppChangelogPanel";
            AppChangelogPanel.BorderStyle = BorderStyle.Fixed3D;
            AppChangelogPanel.BackColor = Color.Transparent;
            AppChangelogPanel.Size = new System.Drawing.Size((int)(610 * ratioX), (int)(740 * ratioY));
            AppChangelogPanel.TabStop = false;
            AppChangelogPanel.Visible = false;
            this.orianaLauncher.Controls.Add(AppChangelogPanel);
            c.addControl(AppChangelogPanel);

            System.Windows.Forms.Label AppChangelogVersion = new System.Windows.Forms.Label();
            AppChangelogVersion.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppChangelogVersion.ForeColor = System.Drawing.SystemColors.Control;
            AppChangelogVersion.BackColor = Color.Transparent;
            AppChangelogVersion.TextAlign = ContentAlignment.MiddleCenter;
            AppChangelogVersion.Location = new System.Drawing.Point((int)(10 * ratioX), (int)(10 * ratioY));
            AppChangelogVersion.Size = new System.Drawing.Size((int)(585 * ratioX), (int)(90 * ratioY));
            AppChangelogVersion.Name = "AppChangelogVersion";
            AppChangelogVersion.Text = "";
            AppChangelogPanel.Controls.Add(AppChangelogVersion);

            System.Windows.Forms.Label AppChangelogContent = new System.Windows.Forms.Label();
            AppChangelogContent.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppChangelogContent.ForeColor = System.Drawing.SystemColors.Control;
            AppChangelogContent.TextAlign = ContentAlignment.TopLeft;
            AppChangelogContent.BackColor = Color.Transparent;
            AppChangelogContent.Location = new System.Drawing.Point((int)(10 * ratioX), (int)(110 * ratioY));
            AppChangelogContent.Size = new System.Drawing.Size((int)(585 * ratioX), (int)(540 * ratioY));
            AppChangelogContent.Name = "AppChangelogContent";
            AppChangelogContent.Text = "";
            AppChangelogPanel.Controls.Add(AppChangelogContent);

            PictureBox AppChangelogPrevious = new System.Windows.Forms.PictureBox();
            AppChangelogPrevious.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppChangelogPrevious.Location = new System.Drawing.Point((int)(10 * ratioX), (int)(665 * ratioY));
            AppChangelogPrevious.BackgroundImage = global::OrianaLauncher.Properties.Resources.previous;
            AppChangelogPrevious.BackgroundImageLayout = ImageLayout.Stretch;
            AppChangelogPrevious.Name = "AppChangelogPrevious";
            AppChangelogPrevious.Size = new System.Drawing.Size((int)(50 * ratioX), (int)(50 * ratioY));
            AppChangelogPrevious.Cursor = Cursors.Hand;
            AppChangelogPrevious.TabStop = false;
            //AppChangelogPrevious.Click += new EventHandler(this.events.saveAndStart);
            AppChangelogPanel.Controls.Add(AppChangelogPrevious);

            PictureBox AppChangelogNext = new System.Windows.Forms.PictureBox();
            AppChangelogNext.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppChangelogNext.Location = new System.Drawing.Point((int)(545 * ratioX), (int)(665 * ratioY));
            AppChangelogNext.BackgroundImage = global::OrianaLauncher.Properties.Resources.next;
            AppChangelogNext.BackgroundImageLayout = ImageLayout.Stretch;
            AppChangelogNext.Name = "AppChangelogNext";
            AppChangelogNext.Size = new System.Drawing.Size((int)(50 * ratioX), (int)(50 * ratioY));
            AppChangelogNext.Cursor = Cursors.Hand;
            AppChangelogNext.TabStop = false;
            //AppChangelogNext.Click += new EventHandler(this.events.saveAndStart);
            AppChangelogPanel.Controls.Add(AppChangelogNext);

            this.components.Add(c);

            c = new Component("AppDownload");

            Panel AppDownloadPanel = new Panel();
            AppDownloadPanel.Location = new System.Drawing.Point((int)(140 * ratioX), (int)(900 * ratioY));
            AppDownloadPanel.Name = "AppDownloadPanel";
            AppDownloadPanel.BackColor = Color.Transparent;
            AppDownloadPanel.BorderStyle = BorderStyle.None;
            AppDownloadPanel.Size = new System.Drawing.Size((int)(1765 * ratioX), (int)(150 * ratioY));
            AppDownloadPanel.TabStop = false;
            AppDownloadPanel.Visible = false;
            this.orianaLauncher.Controls.Add(AppDownloadPanel);
            c.addControl(AppDownloadPanel);

            ProgressBar AppDownloadBar = new ProgressBar();
            AppDownloadBar.Location = new System.Drawing.Point((int)(5 * ratioX), (int)(5 * ratioY));
            AppDownloadBar.Size = new System.Drawing.Size((int)(1755 * ratioX), (int)(30 * ratioY));
            AppDownloadBar.Name = "AppDownloadBar";
            AppDownloadBar.Maximum = 100;
            AppDownloadBar.Minimum = 0;
            AppDownloadBar.Step = 1;
            AppDownloadPanel.Controls.Add(AppDownloadBar);

            System.Windows.Forms.Label AppDownloadPercent = new System.Windows.Forms.Label();
            AppDownloadPercent.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppDownloadPercent.ForeColor = System.Drawing.SystemColors.Control;
            AppDownloadPercent.BackColor = Color.Transparent;
            AppDownloadPercent.TextAlign = ContentAlignment.MiddleRight;
            AppDownloadPercent.Location = new System.Drawing.Point((int)(1660 * ratioX), (int)(40 * ratioY));
            AppDownloadPercent.Size = new System.Drawing.Size((int)(100 * ratioX), (int)(30 * ratioY));
            AppDownloadPercent.Name = "AppDownloadPercent";
            AppDownloadPercent.Text = "70%";
            AppDownloadPanel.Controls.Add(AppDownloadPercent);

            System.Windows.Forms.Label AppDownloadStatus = new System.Windows.Forms.Label();
            AppDownloadStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppDownloadStatus.ForeColor = System.Drawing.SystemColors.Control;
            AppDownloadStatus.BackColor = Color.Transparent;
            AppDownloadStatus.TextAlign = ContentAlignment.MiddleRight;
            AppDownloadStatus.Location = new System.Drawing.Point((int)(1350 * ratioX), (int)(40 * ratioY));
            AppDownloadStatus.Size = new System.Drawing.Size((int)(300 * ratioX), (int)(30 * ratioY));
            AppDownloadStatus.Name = "AppDownloadStatus";
            AppDownloadStatus.Text = "Download in Progress ...";
            AppDownloadPanel.Controls.Add(AppDownloadStatus);

            System.Windows.Forms.Label AppDownloadCredits = new System.Windows.Forms.Label();
            AppDownloadCredits.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppDownloadCredits.ForeColor = System.Drawing.SystemColors.Control;
            AppDownloadCredits.TextAlign = ContentAlignment.MiddleLeft;
            AppDownloadCredits.Location = new System.Drawing.Point((int)(5 * ratioX), (int)(110 * ratioY));
            AppDownloadCredits.Size = new System.Drawing.Size((int)(800 * ratioX), (int)(30 * ratioY));
            AppDownloadCredits.Name = "AppDownloadCredits";
            AppDownloadCredits.UseMnemonic = false;
            AppDownloadCredits.Text = this.orianaLauncher.translator.lg("Oriana Launcher by Matux - Designed by Asman - Mods & Content by Lunastellia");
            AppDownloadPanel.Controls.Add(AppDownloadCredits);

            Button AppDownloadUpdateButton = new System.Windows.Forms.Button();
            AppDownloadUpdateButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppDownloadUpdateButton.Location = new System.Drawing.Point((int)(5 * ratioX), (int)(40 * ratioY));
            AppDownloadUpdateButton.Name = "AppDownloadUpdateButton";
            AppDownloadUpdateButton.TextAlign = ContentAlignment.MiddleCenter;
            AppDownloadUpdateButton.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(30 * ratioY));
            AppDownloadUpdateButton.Text = "Update";
            AppDownloadUpdateButton.TabStop = false;
            AppDownloadUpdateButton.Click += new EventHandler(this.events.installApp);
            AppDownloadUpdateButton.UseVisualStyleBackColor = true;
            AppDownloadPanel.Controls.Add(AppDownloadUpdateButton);

            Button AppDownloadUStartButton = new System.Windows.Forms.Button();
            AppDownloadUStartButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppDownloadUStartButton.Location = new System.Drawing.Point((int)(5 * ratioX), (int)(40 * ratioY));
            AppDownloadUStartButton.Name = "AppDownloadUStartButton";
            AppDownloadUStartButton.TextAlign = ContentAlignment.MiddleCenter;
            AppDownloadUStartButton.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(30 * ratioY));
            AppDownloadUStartButton.Text = "Start";
            AppDownloadUStartButton.TabStop = false;
            AppDownloadUStartButton.Click += new EventHandler(this.events.startApp);
            AppDownloadUStartButton.UseVisualStyleBackColor = true;
            AppDownloadPanel.Controls.Add(AppDownloadUStartButton);

            this.components.Add(c);

        }

        public void renderComponents(string[] components)
        {
            foreach (Component c in this.components)
            {
                if (components.Contains(c.name))
                {
                    c.show();
                }
                else
                {
                    c.hide();
                }
            }
        }

        public void changeApp()
        {
            App activeApp = this.orianaLauncher.appList.apps[this.orianaLauncher.activeApp];

            Label AppHeaderTitle = (Label) this.get("AppHeader").getControl("AppHeaderPanel").Controls["AppHeaderTitle"];
            AppHeaderTitle.Text = activeApp.name;



            Panel MenuPanel = (Panel)this.get("Menu").getControl("MenuPanel");
            int i = 0;
            foreach(Control c in MenuPanel.Controls)
            {
                if (c is PictureBox)
                {
                    if (i == this.orianaLauncher.activeApp)
                    {
                        c.BackColor = Color.Yellow;
                    } else
                    {
                        c.BackColor = Color.Transparent;

                    }
                    i++;
                }
            }

            Panel AppChangelogPanel = (Panel)this.get("AppChangelog").getControl("AppChangelogPanel");

            Label AppChangelogVersion = (Label)AppChangelogPanel.Controls["AppChangelogVersion"];
            AppChangelogVersion.Text = activeApp.release.Name;

            Label AppChangelogContent = (Label)AppChangelogPanel.Controls["AppChangelogContent"];

            string tag = "[" + this.orianaLauncher.config.language.Substring(0, 2).ToUpper() + "]";
            string content = activeApp.release.Body;

            if (activeApp.release.Body.IndexOf(tag) != -1)
            {
                content = activeApp.release.Body.Substring(activeApp.release.Body.IndexOf(tag) + 6);
            }
            if (content.IndexOf("[") != -1)
            {
                content = content.Substring(0, content.IndexOf("["));
            }

            AppChangelogContent.Text = content;
            
            Panel AppDownloadPanel = (Panel)this.get("AppDownload").getControl("AppDownloadPanel");

            ProgressBar AppDownloadBar = (ProgressBar) AppDownloadPanel.Controls["AppDownloadBar"];
            AppDownloadBar.Value = 0;

            Label AppDownloadPercent = (Label)AppDownloadPanel.Controls["AppDownloadPercent"];
            AppDownloadPercent.Text = "0%";

            Label AppDownloadStatus = (Label)AppDownloadPanel.Controls["AppDownloadStatus"];
            AppDownloadStatus.Text = "";

            Button AppDownloadUpdateButton = (Button)AppDownloadPanel.Controls["AppDownloadUpdateButton"];
            Button AppDownloadUStartButton = (Button)AppDownloadPanel.Controls["AppDownloadUStartButton"];

            string remoteVersion = activeApp.release.TagName;
            InstalledApp installedApp = this.orianaLauncher.config.getApp(activeApp.name);

            if (installedApp == null)
            {
                AppDownloadUpdateButton.Visible = true;
                AppDownloadUpdateButton.Text = this.orianaLauncher.translator.lg("Install");
                AppDownloadUStartButton.Visible = false;
            }
            else
            {
                string installedVersion = installedApp.version.ToString();
                if (remoteVersion == installedVersion)
                {
                    AppDownloadUpdateButton.Visible = false;
                    AppDownloadUStartButton.Visible = true;
                } else
                {
                    AppDownloadUpdateButton.Visible = true;
                    AppDownloadUpdateButton.Text = this.orianaLauncher.translator.lg("Update");
                    AppDownloadUStartButton.Visible = false;
                }
            }
            this.orianaLauncher.pageList.renderPage("Main-" + this.orianaLauncher.appList.apps[this.orianaLauncher.activeApp].name);
        }

        public void refresh()
        {
            this.components = new List<Component>();
            this.load();
            this.changeApp();
        }

        public Component get(string name)
        {
            foreach (Component c in this.components)
            {
                if (c.name == name)
                {
                    return c;
                }
            }
            return null;
        }
    }
}
