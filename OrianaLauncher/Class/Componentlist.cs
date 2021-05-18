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

            PictureBox ChallengerPic = new System.Windows.Forms.PictureBox();
            ChallengerPic.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ChallengerPic.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(20 * ratioY));
            ChallengerPic.BackgroundImage = global::OrianaLauncher.Properties.Resources.challenger;
            ChallengerPic.BackgroundImageLayout = ImageLayout.Stretch;
            ChallengerPic.Name = "ChallengerPic";
            ChallengerPic.Size = new System.Drawing.Size((int)(100 * ratioX), (int)(100 * ratioY));
            ChallengerPic.Cursor = Cursors.Hand;
            ChallengerPic.TabStop = false;
            //AppHeaderFR.Click += new EventHandler(this.events.saveAndStart);
            MenuPanel.Controls.Add(ChallengerPic);

            PictureBox ChallengerLitePic = new System.Windows.Forms.PictureBox();
            ChallengerLitePic.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ChallengerLitePic.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(140 * ratioY));
            ChallengerLitePic.BackgroundImage = global::OrianaLauncher.Properties.Resources.challenger;
            ChallengerLitePic.BackgroundImageLayout = ImageLayout.Stretch;
            ChallengerLitePic.Name = "ChallengerLitePic";
            ChallengerLitePic.Size = new System.Drawing.Size((int)(100 * ratioX), (int)(100 * ratioY));
            ChallengerLitePic.Cursor = Cursors.Hand;
            ChallengerLitePic.TabStop = false;
            //AppHeaderFR.Click += new EventHandler(this.events.saveAndStart);
            MenuPanel.Controls.Add(ChallengerLitePic);

            PictureBox ChallengerBetaPic = new System.Windows.Forms.PictureBox();
            ChallengerBetaPic.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ChallengerBetaPic.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(260 * ratioY));
            ChallengerBetaPic.BackgroundImage = global::OrianaLauncher.Properties.Resources.challenger;
            ChallengerBetaPic.BackgroundImageLayout = ImageLayout.Stretch;
            ChallengerBetaPic.Name = "ChallengerBetaPic";
            ChallengerBetaPic.Size = new System.Drawing.Size((int)(100 * ratioX), (int)(100 * ratioY));
            ChallengerBetaPic.Cursor = Cursors.Hand;
            ChallengerBetaPic.TabStop = false;
            //AppHeaderFR.Click += new EventHandler(this.events.saveAndStart);
            MenuPanel.Controls.Add(ChallengerBetaPic);

            this.components.Add(c);

            c = new Component("AppHeader");

            Panel AppHeaderPanel = new Panel();
            AppHeaderPanel.Location = new System.Drawing.Point((int)(140 * ratioX), (int)(0 * ratioY));
            AppHeaderPanel.Name = "MenuPanel";
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
            //AppHeaderFR.Click += new EventHandler(this.events.saveAndStart);
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
            //AppHeaderFR.Click += new EventHandler(this.events.saveAndStart);
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
            //AppHeaderFR.Click += new EventHandler(this.events.saveAndStart);
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
            //AppHeaderFR.Click += new EventHandler(this.events.saveAndStart);
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
            AppInfoLabel.Text = "Superbe texte ici...";
            AppInfoPanel.Controls.Add(AppInfoLabel);

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
            AppChangelogVersion.Name = "AppInfoLabel";
            AppChangelogVersion.Text = "Version 1.0.0";
            AppChangelogPanel.Controls.Add(AppChangelogVersion);

            System.Windows.Forms.Label AppChangelogContent = new System.Windows.Forms.Label();
            AppChangelogContent.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppChangelogContent.ForeColor = System.Drawing.SystemColors.Control;
            AppChangelogContent.TextAlign = ContentAlignment.TopLeft;
            AppChangelogContent.BackColor = Color.Transparent;
            AppChangelogContent.Location = new System.Drawing.Point((int)(10 * ratioX), (int)(110 * ratioY));
            AppChangelogContent.Size = new System.Drawing.Size((int)(585 * ratioX), (int)(540 * ratioY));
            AppChangelogContent.Name = "AppChangelogContent";
            AppChangelogContent.Text = "- change 1\n- change 2";
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
            AppDownloadCredits.Text = "Oriana Launcher by Matux - Designed by Someone - Mods & Content by Lunastellia";
            AppDownloadPanel.Controls.Add(AppDownloadCredits);

            Button AppDownloadUpdateButton = new System.Windows.Forms.Button();
            AppDownloadUpdateButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppDownloadUpdateButton.Location = new System.Drawing.Point((int)(5 * ratioX), (int)(40 * ratioY));
            AppDownloadUpdateButton.Name = "AppDownloadUpdateButton";
            AppDownloadUpdateButton.TextAlign = ContentAlignment.MiddleCenter;
            AppDownloadUpdateButton.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(30 * ratioY));
            AppDownloadUpdateButton.Text = "Update";
            AppDownloadUpdateButton.TabStop = false;
            //AppDownloadUpdateButton.Click += new EventHandler(this.events.addMod);
            AppDownloadUpdateButton.UseVisualStyleBackColor = true;
            AppDownloadPanel.Controls.Add(AppDownloadUpdateButton);

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
