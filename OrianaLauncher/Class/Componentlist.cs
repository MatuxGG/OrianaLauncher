using Octokit;
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

            float sizeM = 12F;
            float sizeL = 14F;
            float sizeXL = 20F;
            float sizeXXL = 36F;
            int temp = 0;
            if (this.orianaLauncher.config.resY == 900)
            {
                sizeM = 12F;
                sizeL = 14F;
                sizeXL = 20F;
                sizeXXL = 33F;
                temp = 0;
            }
            else if (this.orianaLauncher.config.resY == 768)
            {
                sizeM = 10F;
                sizeL = 12F;
                sizeXL = 18F;
                sizeXXL = 30F;
                temp = 10;
            }
            else if (this.orianaLauncher.config.resY == 720)
            {
                sizeM = 10F;
                sizeL = 12F;
                sizeXL = 18F;
                sizeXXL = 30F;
                temp = 10;
            } else if (this.orianaLauncher.config.resY == 540) {
                sizeM = 8F;
                sizeL = 10F;
                sizeXL = 16F;
                sizeXXL = 28F;
                temp = 20;
            }
            else if (this.orianaLauncher.config.resY == 480)
            {
                sizeM = 6F;
                sizeL = 8F;
                sizeXL = 14F;
                sizeXXL = 26F;
                temp = 22;
            }

            double ratioX = (double) this.orianaLauncher.config.resX / 1920.0;
            double ratioY = (double) (this.orianaLauncher.config.resY - temp) / 1080.0;

            

            Component c = new Component("Menu");

            Panel MenuPanel = new Panel();
            MenuPanel.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(0 * ratioY));
            MenuPanel.BackgroundImage = global::OrianaLauncher.Properties.Resources.BG_CLeft;
            MenuPanel.BackgroundImageLayout = ImageLayout.Stretch;
            MenuPanel.Name = "MenuPanel";
            MenuPanel.BackColor = Color.Transparent;
            MenuPanel.BorderStyle = BorderStyle.None;
            MenuPanel.Size = new System.Drawing.Size((int)(140 * ratioX), (int)(1040 * ratioY));
            MenuPanel.TabStop = false;
            MenuPanel.Visible = false;
            this.orianaLauncher.Controls.Add(MenuPanel);
            c.addControl(MenuPanel);

            Panel HomePicPanel = new Panel();
            HomePicPanel.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(0 * ratioY));
            HomePicPanel.Name = "HomePicPanel";
            HomePicPanel.BackColor = Color.Transparent;
            HomePicPanel.BorderStyle = BorderStyle.None;
            HomePicPanel.Size = new System.Drawing.Size((int)(140 * ratioX), (int)(140 * ratioY));
            HomePicPanel.TabStop = false;
            MenuPanel.Controls.Add(HomePicPanel);

            PictureBox HomePic = new System.Windows.Forms.PictureBox();
            HomePic.Font = new System.Drawing.Font("Arial", sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            HomePic.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(20 * ratioY));
            HomePic.BackgroundImage = global::OrianaLauncher.Properties.Resources.logo_Oriana;
            HomePic.BackgroundImageLayout = ImageLayout.Stretch;
            HomePic.BackColor = Color.Transparent;
            HomePic.Name = "HomePic";
            HomePic.Size = new System.Drawing.Size((int)(100 * ratioX), (int)(100 * ratioY));
            HomePic.Cursor = Cursors.Hand;
            HomePic.Click += new EventHandler(this.events.openHome);
            HomePic.TabStop = false;
            HomePicPanel.Controls.Add(HomePic);

            int offset = 0;
            foreach(App a in this.orianaLauncher.appList.apps)
            {
                if (a.name != "Origin")
                {
                    Panel AppPicPanel = new Panel();
                    AppPicPanel.Location = new System.Drawing.Point((int)(0 * ratioX), (int)((140 + 140 * offset) * ratioY));
                    AppPicPanel.BackColor = Color.Transparent;
                    AppPicPanel.BorderStyle = BorderStyle.None;
                    AppPicPanel.Size = new System.Drawing.Size((int)(140 * ratioX), (int)(140 * ratioY));
                    AppPicPanel.TabStop = false;
                    MenuPanel.Controls.Add(AppPicPanel);

                    PictureBox AppPic = new System.Windows.Forms.PictureBox();
                    AppPic.Font = new System.Drawing.Font("Arial", sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    AppPic.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(20 * ratioY));
                    AppPic.BackColor = Color.Transparent;
                    if (a.name == "Challenger Lite")
                    {
                        AppPic.BackgroundImage = global::OrianaLauncher.Properties.Resources.logo_Lite; 
                    }
                    else if (a.name == "Challenger Beta")
                    {
                        AppPic.BackgroundImage = global::OrianaLauncher.Properties.Resources.logo_Beta;
                    }
                    else
                    {
                        AppPic.BackgroundImage = global::OrianaLauncher.Properties.Resources.logo_Ch;
                    }
                    AppPic.BackgroundImageLayout = ImageLayout.Stretch;
                    AppPic.Size = new System.Drawing.Size((int)(100 * ratioX), (int)(100 * ratioY));
                    AppPic.Cursor = Cursors.Hand;
                    AppPic.Name = "AppPic=" + (offset + 1);
                    AppPic.Click += new EventHandler(this.events.changeApp);
                    AppPic.TabStop = false;
                    AppPicPanel.Controls.Add(AppPic);

                    offset++;
                }
            }

            Panel SettingsPicPanel = new Panel();
            SettingsPicPanel.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(900 * ratioY));
            SettingsPicPanel.BackColor = Color.Transparent;
            SettingsPicPanel.BorderStyle = BorderStyle.None;
            SettingsPicPanel.Size = new System.Drawing.Size((int)(140 * ratioX), (int)(140 * ratioY));
            SettingsPicPanel.TabStop = false;
            MenuPanel.Controls.Add(SettingsPicPanel);

            PictureBox SettingsPic = new System.Windows.Forms.PictureBox();
            SettingsPic.Font = new System.Drawing.Font("Arial", sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SettingsPic.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(20 * ratioY));
            SettingsPic.BackgroundImage = global::OrianaLauncher.Properties.Resources.settings;
            SettingsPic.BackColor = Color.Transparent;
            SettingsPic.BackgroundImageLayout = ImageLayout.Stretch;
            SettingsPic.Name = "SettingsPic";
            SettingsPic.Size = new System.Drawing.Size((int)(100 * ratioX), (int)(100 * ratioY));
            SettingsPic.Cursor = Cursors.Hand;
            SettingsPic.TabStop = false;
            SettingsPic.Click += new EventHandler(this.events.openSettings);
            SettingsPicPanel.Controls.Add(SettingsPic);

            this.components.Add(c);

            c = new Component("AppHeader");

            Panel AppHeaderPanel = new Panel();
            AppHeaderPanel.Location = new System.Drawing.Point((int)(140 * ratioX), (int)(0 * ratioY));
            AppHeaderPanel.Name = "AppHeaderPanel";
            AppHeaderPanel.BackgroundImage = global::OrianaLauncher.Properties.Resources.BG_Head;
            AppHeaderPanel.BackgroundImageLayout = ImageLayout.Stretch;
            AppHeaderPanel.BorderStyle = BorderStyle.None;
            AppHeaderPanel.Size = new System.Drawing.Size((int)(1765 * ratioX), (int)(150 * ratioY));
            AppHeaderPanel.TabStop = false;
            AppHeaderPanel.Visible = false;
            this.orianaLauncher.Controls.Add(AppHeaderPanel);
            c.addControl(AppHeaderPanel);

            System.Windows.Forms.Label AppHeaderTitle = new System.Windows.Forms.Label();
            AppHeaderTitle.Font = new System.Drawing.Font("Arial", sizeXXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppHeaderTitle.ForeColor = System.Drawing.SystemColors.Control;
            AppHeaderTitle.BackgroundImage = global::OrianaLauncher.Properties.Resources.BG_Title;
            AppHeaderTitle.BackgroundImageLayout = ImageLayout.Stretch;
            AppHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;
            AppHeaderTitle.Location = new System.Drawing.Point((int)(10 * ratioX), (int)(10 * ratioY));
            AppHeaderTitle.Name = "AppHeaderTitle";
            AppHeaderTitle.Size = new System.Drawing.Size((int)(1470 * ratioX), (int)(130 * ratioY));
            AppHeaderTitle.Text = "Challenger";
            AppHeaderPanel.Controls.Add(AppHeaderTitle);

            /*
            PictureBox AppHeaderFR = new System.Windows.Forms.PictureBox();
            AppHeaderFR.Font = new System.Drawing.Font("Arial", sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppHeaderFR.Location = new System.Drawing.Point((int)(1550 * ratioX), (int)(15 * ratioY));
            AppHeaderFR.BackgroundImage = global::OrianaLauncher.Properties.Resources.fr;
            AppHeaderFR.BackgroundImageLayout = ImageLayout.Stretch;
            AppHeaderFR.BackColor = Color.Transparent;
            AppHeaderFR.Name = "AppHeaderFR";
            AppHeaderFR.Size = new System.Drawing.Size((int)(50 * ratioX), (int)(50 * ratioY));
            AppHeaderFR.Cursor = Cursors.Hand;
            AppHeaderFR.TabStop = false;
            AppHeaderFR.Click += new EventHandler(this.events.changeLgToFR);
            AppHeaderPanel.Controls.Add(AppHeaderFR);

            PictureBox AppHeaderUS = new System.Windows.Forms.PictureBox();
            AppHeaderUS.Font = new System.Drawing.Font("Arial", sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppHeaderUS.Location = new System.Drawing.Point((int)(1650 * ratioX), (int)(15 * ratioY));
            AppHeaderUS.BackgroundImage = global::OrianaLauncher.Properties.Resources.us;
            AppHeaderUS.BackgroundImageLayout = ImageLayout.Stretch;
            AppHeaderUS.BackColor = Color.Transparent;
            AppHeaderUS.Name = "AppHeaderUS";
            AppHeaderUS.Size = new System.Drawing.Size((int)(50 * ratioX), (int)(50 * ratioY));
            AppHeaderUS.Cursor = Cursors.Hand;
            AppHeaderUS.TabStop = false;
            AppHeaderUS.Click += new EventHandler(this.events.changeLgToUS);
            AppHeaderPanel.Controls.Add(AppHeaderUS);
            */

            PictureBox AppHeaderDiscord = new System.Windows.Forms.PictureBox();
            AppHeaderDiscord.Font = new System.Drawing.Font("Arial", sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppHeaderDiscord.Location = new System.Drawing.Point((int)(1550 * ratioX), (int)(50 * ratioY));
            AppHeaderDiscord.BackgroundImage = global::OrianaLauncher.Properties.Resources.discord;
            AppHeaderDiscord.BackgroundImageLayout = ImageLayout.Stretch;
            AppHeaderDiscord.BackColor = Color.Transparent;
            AppHeaderDiscord.Name = "AppHeaderDiscord";
            AppHeaderDiscord.Size = new System.Drawing.Size((int)(50 * ratioX), (int)(50 * ratioY));
            AppHeaderDiscord.Cursor = Cursors.Hand;
            AppHeaderDiscord.TabStop = false;
            AppHeaderDiscord.Click += new EventHandler(this.events.openDiscord);
            AppHeaderPanel.Controls.Add(AppHeaderDiscord);

            PictureBox AppHeaderGithub = new System.Windows.Forms.PictureBox();
            AppHeaderGithub.Font = new System.Drawing.Font("Arial", sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppHeaderGithub.Location = new System.Drawing.Point((int)(1650 * ratioX), (int)(50 * ratioY));
            AppHeaderGithub.BackgroundImage = global::OrianaLauncher.Properties.Resources.github;
            AppHeaderGithub.BackgroundImageLayout = ImageLayout.Stretch;
            AppHeaderGithub.BackColor = Color.Transparent;
            AppHeaderGithub.Name = "AppHeaderGithub";
            AppHeaderGithub.Size = new System.Drawing.Size((int)(50 * ratioX), (int)(50 * ratioY));
            AppHeaderGithub.Cursor = Cursors.Hand;
            AppHeaderGithub.TabStop = false;
            AppHeaderGithub.Click += new EventHandler(this.events.openGithub);
            AppHeaderPanel.Controls.Add(AppHeaderGithub);

            this.components.Add(c);

            c = new Component("Home");

            Panel HomePanel = new Panel();
            HomePanel.Location = new System.Drawing.Point((int)(145 * ratioX), (int)(155 * ratioY));
            HomePanel.Name = "HomePanel";
            HomePanel.BackgroundImage = global::OrianaLauncher.Properties.Resources.BG_CenterMainPage;
            HomePanel.BackgroundImageLayout = ImageLayout.Stretch;
            HomePanel.BackColor = Color.Transparent;
            HomePanel.BorderStyle = BorderStyle.None;
            HomePanel.Size = new System.Drawing.Size((int)(1755 * ratioX), (int)(740 * ratioY));
            HomePanel.TabStop = false;
            HomePanel.Visible = false;
            HomePanel.AutoScroll = false;
            HomePanel.HorizontalScroll.Enabled = false;
            HomePanel.HorizontalScroll.Visible = false;
            HomePanel.HorizontalScroll.Maximum = 0;
            HomePanel.AutoScroll = true;
            this.orianaLauncher.Controls.Add(HomePanel);
            c.addControl(HomePanel);

            System.Windows.Forms.Label HomeLabel = new System.Windows.Forms.Label();
            HomeLabel.Font = new System.Drawing.Font("Arial", sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            HomeLabel.ForeColor = System.Drawing.SystemColors.Control;
            HomeLabel.TextAlign = ContentAlignment.TopLeft;
            HomeLabel.BackColor = Color.Transparent;
            HomeLabel.Location = new System.Drawing.Point((int)(10 * ratioX), (int)(10 * ratioY));
            HomeLabel.Name = "HomeLabel";
            HomeLabel.AutoSize = true;
            HomePanel.Controls.Add(HomeLabel);

            this.components.Add(c);

            c = new Component("Settings");

            Panel SettingsPanel = new Panel();
            SettingsPanel.Location = new System.Drawing.Point((int)(145 * ratioX), (int)(155 * ratioY));
            SettingsPanel.Name = "SettingsPanel";
            SettingsPanel.BackgroundImage = global::OrianaLauncher.Properties.Resources.BG_Center;
            SettingsPanel.BackgroundImageLayout = ImageLayout.Stretch;
            SettingsPanel.BackColor = Color.Transparent;
            SettingsPanel.BorderStyle = BorderStyle.None;
            SettingsPanel.Size = new System.Drawing.Size((int)(1755 * ratioX), (int)(740 * ratioY));
            SettingsPanel.TabStop = false;
            SettingsPanel.Visible = false;
            SettingsPanel.AutoScroll = false;
            SettingsPanel.HorizontalScroll.Enabled = false;
            SettingsPanel.HorizontalScroll.Visible = false;
            SettingsPanel.HorizontalScroll.Maximum = 0;
            SettingsPanel.AutoScroll = true;
            this.orianaLauncher.Controls.Add(SettingsPanel);
            c.addControl(SettingsPanel);

            System.Windows.Forms.Label ResolutionLabel = new System.Windows.Forms.Label();
            ResolutionLabel.Font = new System.Drawing.Font("Arial", sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ResolutionLabel.ForeColor = System.Drawing.SystemColors.Control;
            ResolutionLabel.TextAlign = ContentAlignment.TopLeft;
            ResolutionLabel.BackColor = Color.Transparent;
            ResolutionLabel.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(20 * ratioY));
            ResolutionLabel.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(30 * ratioY));
            ResolutionLabel.Name = "ResolutionLabel";
            ResolutionLabel.Text = this.orianaLauncher.translator.lg("Resolution :");
            SettingsPanel.Controls.Add(ResolutionLabel);

            ComboBox ResolutionComboBox = new ComboBox();
            ResolutionComboBox.Font = new System.Drawing.Font("Arial", sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ResolutionComboBox.Location = new System.Drawing.Point((int)(250 * ratioX), (int)(20 * ratioY));
            ResolutionComboBox.Name = "ResolutionComboBox";
            ResolutionComboBox.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(30 * ratioY));
            ResolutionComboBox.TabStop = false;
            ResolutionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (int[] res in this.orianaLauncher.config.getResolutions())
            {
                ResolutionComboBox.Items.Add(res[0] + "x" + res[1]);
            }

            string currentResolution = this.orianaLauncher.config.resX.ToString() + "x" + this.orianaLauncher.config.resY.ToString();

            ResolutionComboBox.SelectedIndex = ResolutionComboBox.FindStringExact(currentResolution);

            ResolutionComboBox.SelectedIndexChanged += new EventHandler(this.events.changeResolution);

            SettingsPanel.Controls.Add(ResolutionComboBox);

            System.Windows.Forms.Label LanguageLabel = new System.Windows.Forms.Label();
            LanguageLabel.Font = new System.Drawing.Font("Arial", sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LanguageLabel.ForeColor = System.Drawing.SystemColors.Control;
            LanguageLabel.TextAlign = ContentAlignment.TopLeft;
            LanguageLabel.BackColor = Color.Transparent;
            LanguageLabel.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(70 * ratioY));
            LanguageLabel.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(30 * ratioY));
            LanguageLabel.Name = "LanguageLabel";
            LanguageLabel.Text = this.orianaLauncher.translator.lg("Language :");
            SettingsPanel.Controls.Add(LanguageLabel);

            ComboBox LanguageComboBox = new ComboBox();
            LanguageComboBox.Font = new System.Drawing.Font("Arial", sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LanguageComboBox.Location = new System.Drawing.Point((int)(250 * ratioX), (int)(70 * ratioY));
            LanguageComboBox.Name = "LanguageComboBox";
            LanguageComboBox.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(30 * ratioY));
            LanguageComboBox.TabStop = false;
            LanguageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            LanguageComboBox.Items.Add("English");
            LanguageComboBox.Items.Add("Français");

            string currentLanguage = "English";

            if (this.orianaLauncher.config.language == "fr_FR")
            {
                currentLanguage = "Français";
            }

            LanguageComboBox.SelectedIndex = LanguageComboBox.FindStringExact(currentLanguage);

            LanguageComboBox.SelectedIndexChanged += new EventHandler(this.events.changeLg);

            SettingsPanel.Controls.Add(LanguageComboBox);

            this.components.Add(c);

            c = new Component("AppInfo");

            Panel AppInfoPanel = new Panel();
            AppInfoPanel.Location = new System.Drawing.Point((int)(145 * ratioX), (int)(155 * ratioY));
            AppInfoPanel.Name = "AppInfoPanel";
            AppInfoPanel.BackgroundImage = global::OrianaLauncher.Properties.Resources.BG_Left;
            AppInfoPanel.BackgroundImageLayout = ImageLayout.Stretch;
            AppInfoPanel.BackColor = Color.Transparent;
            AppInfoPanel.BorderStyle = BorderStyle.None;
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
            AppInfoLabel.Font = new System.Drawing.Font("Arial", sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppInfoLabel.ForeColor = System.Drawing.SystemColors.Control;
            AppInfoLabel.TextAlign = ContentAlignment.TopLeft;
            AppInfoLabel.BackColor = Color.Transparent;
            AppInfoLabel.Location = new System.Drawing.Point((int)(10 * ratioX), (int)(10 * ratioY));
            AppInfoLabel.Name = "AppInfoLabel";
            AppInfoLabel.AutoSize = true;
            AppInfoLabel.Text = this.orianaLauncher.translator.lg("Coming soon ...");
            AppInfoPanel.Controls.Add(AppInfoLabel);

            this.components.Add(c);

            c = new Component("AppInfoLarge");

            Panel AppInfoLargePanel = new Panel();
            AppInfoLargePanel.Location = new System.Drawing.Point((int)(145 * ratioX), (int)(155 * ratioY));
            AppInfoLargePanel.Name = "AppInfoLargePanel";
            AppInfoLargePanel.BackgroundImage = global::OrianaLauncher.Properties.Resources.BG_Center;
            AppInfoLargePanel.BackgroundImageLayout = ImageLayout.Stretch;
            AppInfoLargePanel.BackColor = Color.Transparent;
            AppInfoLargePanel.BorderStyle = BorderStyle.None;
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
            AppInfoLargeLabel.Font = new System.Drawing.Font("Arial", sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppInfoLargeLabel.ForeColor = System.Drawing.SystemColors.Control;
            AppInfoLargeLabel.TextAlign = ContentAlignment.TopLeft;
            AppInfoLargeLabel.BackColor = Color.Transparent;
            AppInfoLargeLabel.Location = new System.Drawing.Point((int)(10 * ratioX), (int)(10 * ratioY));
            AppInfoLargeLabel.Name = "AppInfoLargeLabel";
            AppInfoLargeLabel.AutoSize = true;
            AppInfoLargeLabel.Text = this.orianaLauncher.translator.lg("Coming soon ...");
            AppInfoLargePanel.Controls.Add(AppInfoLargeLabel);

            this.components.Add(c);

            c = new Component("AppChangelog");

            Panel AppChangelogPanel = new Panel();
            AppChangelogPanel.Location = new System.Drawing.Point((int)(1290 * ratioX), (int)(155 * ratioY));
            AppChangelogPanel.Name = "AppChangelogPanel";
            AppChangelogPanel.BorderStyle = BorderStyle.None;
            AppChangelogPanel.BackgroundImage = global::OrianaLauncher.Properties.Resources.BG_0;
            AppChangelogPanel.BackgroundImageLayout = ImageLayout.Stretch;
            AppChangelogPanel.Size = new System.Drawing.Size((int)(610 * ratioX), (int)(740 * ratioY));
            AppChangelogPanel.TabStop = false;
            AppChangelogPanel.Visible = false;
            this.orianaLauncher.Controls.Add(AppChangelogPanel);
            c.addControl(AppChangelogPanel);

            System.Windows.Forms.Label AppChangelogVersion = new System.Windows.Forms.Label();
            AppChangelogVersion.Font = new System.Drawing.Font("Arial", sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppChangelogVersion.ForeColor = System.Drawing.SystemColors.Control;
            AppChangelogVersion.BackgroundImage = global::OrianaLauncher.Properties.Resources.BG_Version;
            AppChangelogVersion.BackgroundImageLayout = ImageLayout.Stretch;
            AppChangelogVersion.TextAlign = ContentAlignment.MiddleCenter;
            AppChangelogVersion.Location = new System.Drawing.Point((int)(10 * ratioX), (int)(10 * ratioY));
            AppChangelogVersion.Size = new System.Drawing.Size((int)(585 * ratioX), (int)(90 * ratioY));
            AppChangelogVersion.Name = "AppChangelogVersion";
            AppChangelogVersion.Text = "";
            AppChangelogPanel.Controls.Add(AppChangelogVersion);

            Panel AppChangelogContentPanel = new Panel();
            AppChangelogContentPanel.Location = new System.Drawing.Point((int)(10 * ratioX), (int)(110 * ratioY));
            AppChangelogContentPanel.Name = "AppChangelogContentPanel";
            AppChangelogContentPanel.BorderStyle = BorderStyle.None;
            AppChangelogContentPanel.BackColor = Color.Transparent;
            AppChangelogContentPanel.BackgroundImage = global::OrianaLauncher.Properties.Resources.BG_Logs;
            AppChangelogContentPanel.BackgroundImageLayout = ImageLayout.Stretch;
            AppChangelogContentPanel.Size = new System.Drawing.Size((int)(585 * ratioX), (int)(540 * ratioY));
            AppChangelogContentPanel.TabStop = false;
            AppChangelogContentPanel.AutoScroll = true;
            AppChangelogPanel.Controls.Add(AppChangelogContentPanel);

            System.Windows.Forms.Label AppChangelogContent = new System.Windows.Forms.Label();
            AppChangelogContent.Font = new System.Drawing.Font("Arial", sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppChangelogContent.ForeColor = System.Drawing.SystemColors.Control;
            AppChangelogContent.TextAlign = ContentAlignment.TopLeft;
            AppChangelogContent.BackgroundImageLayout = ImageLayout.Stretch;
            AppChangelogContent.Location = new System.Drawing.Point((int)(10 * ratioX), (int)(10 * ratioY));
            AppChangelogContent.AutoSize = true;
            AppChangelogContent.MaximumSize = new Size((int)(550 * ratioX), 0);
            AppChangelogContent.Name = "AppChangelogContent";
            AppChangelogContentPanel.Controls.Add(AppChangelogContent);

            PictureBox AppChangelogPrevious = new System.Windows.Forms.PictureBox();
            AppChangelogPrevious.Font = new System.Drawing.Font("Arial", sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppChangelogPrevious.Location = new System.Drawing.Point((int)(10 * ratioX), (int)(665 * ratioY));
            AppChangelogPrevious.BackgroundImage = global::OrianaLauncher.Properties.Resources.Icon_Prev;
            AppChangelogPrevious.BackgroundImageLayout = ImageLayout.Stretch;
            AppChangelogPrevious.BackColor = Color.Transparent;
            AppChangelogPrevious.Name = "AppChangelogPrevious";
            AppChangelogPrevious.Size = new System.Drawing.Size((int)(50 * ratioX), (int)(50 * ratioY));
            AppChangelogPrevious.Cursor = Cursors.Hand;
            AppChangelogPrevious.TabStop = false;
            AppChangelogPrevious.Click += new EventHandler(this.events.showPreviousRelease);
            AppChangelogPanel.Controls.Add(AppChangelogPrevious);

            PictureBox AppChangelogNext = new System.Windows.Forms.PictureBox();
            AppChangelogNext.Font = new System.Drawing.Font("Arial", sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppChangelogNext.Location = new System.Drawing.Point((int)(545 * ratioX), (int)(665 * ratioY));
            AppChangelogNext.BackgroundImage = global::OrianaLauncher.Properties.Resources.Icon_next;
            AppChangelogNext.BackgroundImageLayout = ImageLayout.Stretch;
            AppChangelogNext.BackColor = Color.Transparent;
            AppChangelogNext.Name = "AppChangelogNext";
            AppChangelogNext.Size = new System.Drawing.Size((int)(50 * ratioX), (int)(50 * ratioY));
            AppChangelogNext.Cursor = Cursors.Hand;
            AppChangelogNext.TabStop = false;
            AppChangelogNext.Click += new EventHandler(this.events.showNextRelease);
            AppChangelogPanel.Controls.Add(AppChangelogNext);

            this.components.Add(c);

            c = new Component("AppDownload");

            Panel AppDownloadPanel = new Panel();
            AppDownloadPanel.Location = new System.Drawing.Point((int)(140 * ratioX), (int)(900 * ratioY));
            AppDownloadPanel.Name = "AppDownloadPanel";
            AppDownloadPanel.BorderStyle = BorderStyle.None;
            AppDownloadPanel.BackgroundImage = global::OrianaLauncher.Properties.Resources.BG_Bot;
            AppDownloadPanel.BackgroundImageLayout = ImageLayout.Stretch;
            AppDownloadPanel.Size = new System.Drawing.Size((int)(1765 * ratioX), (int)(140 * ratioY));
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
            AppDownloadPercent.Font = new System.Drawing.Font("Arial", sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppDownloadPercent.ForeColor = System.Drawing.SystemColors.Control;
            AppDownloadPercent.BackColor = Color.Transparent;
            AppDownloadPercent.TextAlign = ContentAlignment.MiddleRight;
            AppDownloadPercent.Location = new System.Drawing.Point((int)(1660 * ratioX), (int)(40 * ratioY));
            AppDownloadPercent.Size = new System.Drawing.Size((int)(100 * ratioX), (int)(30 * ratioY));
            AppDownloadPercent.Name = "AppDownloadPercent";
            AppDownloadPanel.Controls.Add(AppDownloadPercent);

            System.Windows.Forms.Label AppDownloadStatus = new System.Windows.Forms.Label();
            AppDownloadStatus.Font = new System.Drawing.Font("Arial", sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppDownloadStatus.ForeColor = System.Drawing.SystemColors.Control;
            AppDownloadStatus.BackColor = Color.Transparent;
            AppDownloadStatus.TextAlign = ContentAlignment.MiddleRight;
            AppDownloadStatus.Location = new System.Drawing.Point((int)(1350 * ratioX), (int)(40 * ratioY));
            AppDownloadStatus.Size = new System.Drawing.Size((int)(300 * ratioX), (int)(30 * ratioY));
            AppDownloadStatus.Name = "AppDownloadStatus";
            AppDownloadPanel.Controls.Add(AppDownloadStatus);

            System.Windows.Forms.Label AppDownloadCredits = new System.Windows.Forms.Label();
            AppDownloadCredits.Font = new System.Drawing.Font("Arial", sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppDownloadCredits.ForeColor = System.Drawing.SystemColors.Control;
            AppDownloadCredits.TextAlign = ContentAlignment.MiddleLeft;
            AppDownloadCredits.BackColor = Color.Transparent;
            AppDownloadCredits.Location = new System.Drawing.Point((int)(5 * ratioX), (int)(110 * ratioY));
            AppDownloadCredits.Size = new System.Drawing.Size((int)(800 * ratioX), (int)(30 * ratioY));
            AppDownloadCredits.Name = "AppDownloadCredits";
            AppDownloadCredits.UseMnemonic = false;

            string versionMsg = this.orianaLauncher.translator.lg("Oriana Launcher version %1 by Matux - Mods, Content & Design by Lunastellia");
            string version = this.orianaLauncher.version.ToString();
            version = version.Substring(0, version.Length - 2);
            versionMsg = versionMsg.Replace("%1", version);

            AppDownloadCredits.Text = versionMsg;
            AppDownloadPanel.Controls.Add(AppDownloadCredits);

            PictureBox AppDownloadUpdateButton = new System.Windows.Forms.PictureBox();
            AppDownloadUpdateButton.Font = new System.Drawing.Font("Arial", sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppDownloadUpdateButton.Location = new System.Drawing.Point((int)(800 * ratioX), (int)(50 * ratioY));
            AppDownloadUpdateButton.Name = "AppDownloadUpdateButton";
            AppDownloadUpdateButton.Cursor = Cursors.Hand;

            if (this.orianaLauncher.config.language == "fr_FR")
            {
                AppDownloadUpdateButton.BackgroundImage = global::OrianaLauncher.Properties.Resources.ENDownload;
            } else
            {
                AppDownloadUpdateButton.BackgroundImage = global::OrianaLauncher.Properties.Resources.FRtelecharger;
            }

            AppDownloadUpdateButton.BackgroundImageLayout = ImageLayout.Stretch;
            AppDownloadUpdateButton.BackColor = Color.Transparent;
            AppDownloadUpdateButton.Size = new System.Drawing.Size((int)(208 * ratioX), (int)(49 * ratioY));
            AppDownloadUpdateButton.TabStop = false;
            AppDownloadUpdateButton.Click += new EventHandler(this.events.installApp);
            AppDownloadPanel.Controls.Add(AppDownloadUpdateButton);

            PictureBox AppDownloadUStartButton = new System.Windows.Forms.PictureBox();
            AppDownloadUStartButton.Font = new System.Drawing.Font("Arial", sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AppDownloadUStartButton.Location = new System.Drawing.Point((int)(800 * ratioX), (int)(50 * ratioY));
            AppDownloadUStartButton.Name = "AppDownloadUStartButton";
            AppDownloadUStartButton.Cursor = Cursors.Hand;

            if (this.orianaLauncher.config.language == "fr_FR")
            {
                AppDownloadUStartButton.BackgroundImage = global::OrianaLauncher.Properties.Resources.ENplay;
            }
            else
            {
                AppDownloadUStartButton.BackgroundImage = global::OrianaLauncher.Properties.Resources.FRJouer;
            }

            AppDownloadUStartButton.BackgroundImageLayout = ImageLayout.Stretch;
            AppDownloadUStartButton.BackColor = Color.Transparent;
            AppDownloadUStartButton.Size = new System.Drawing.Size((int)(208 * ratioX), (int)(49 * ratioY));
            AppDownloadUStartButton.TabStop = false;
            AppDownloadUStartButton.Click += new EventHandler(this.events.startApp);
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

            this.changeTitle(activeApp.name);

            this.changeMenu();

            Release r = activeApp.releases[activeApp.currentRelease];

            this.changeRelease(r);

            Panel AppDownloadPanel = (Panel)this.get("AppDownload").getControl("AppDownloadPanel");

            if (this.orianaLauncher.downloadInProgress == false)
            {
                ProgressBar AppDownloadBar = (ProgressBar)AppDownloadPanel.Controls["AppDownloadBar"];
                AppDownloadBar.Value = 0;

                System.Windows.Forms.Label AppDownloadPercent = (System.Windows.Forms.Label)AppDownloadPanel.Controls["AppDownloadPercent"];
                AppDownloadPercent.Text = "0%";

                System.Windows.Forms.Label AppDownloadStatus = (System.Windows.Forms.Label)AppDownloadPanel.Controls["AppDownloadStatus"];
                AppDownloadStatus.Text = "";
            }

            this.orianaLauncher.currentGithub = "https://github.com/" + activeApp.author + "/" + activeApp.github;

            this.changeButtons();

            this.orianaLauncher.pageList.renderPage("Main-" + this.orianaLauncher.appList.apps[this.orianaLauncher.activeApp].name);
        }

        public void changeMenu()
        {
            Panel MenuPanel = (Panel)this.get("Menu").getControl("MenuPanel");
            int i = 0;
            foreach (Control c in MenuPanel.Controls)
            {
                if (c is Panel)
                {
                    if (i == this.orianaLauncher.activeApp)
                    {
                        c.BackColor = Color.FromArgb(100, 0, 0, 0);
                    }
                    else
                    {
                        c.BackColor = Color.Transparent;
                    }
                    i++;
                }
            }
        }

        public void changeTitle(string s)
        {
            System.Windows.Forms.Label AppHeaderTitle = (System.Windows.Forms.Label)this.get("AppHeader").getControl("AppHeaderPanel").Controls["AppHeaderTitle"];
            AppHeaderTitle.Text = s;
        }

        public void changeButtons()
        {
            if (this.orianaLauncher.activeApp == 0 || this.orianaLauncher.activeApp == this.orianaLauncher.appList.apps.Count())
            {
                Panel AppDownloadPanel = (Panel)this.get("AppDownload").getControl("AppDownloadPanel");

                PictureBox AppDownloadUpdateButton = (PictureBox)AppDownloadPanel.Controls["AppDownloadUpdateButton"];
                PictureBox AppDownloadUStartButton = (PictureBox)AppDownloadPanel.Controls["AppDownloadUStartButton"];

                AppDownloadUpdateButton.Visible = false;
                AppDownloadUStartButton.Visible = false;
            } else
            {
                App activeApp = activeApp = this.orianaLauncher.appList.apps[this.orianaLauncher.activeApp];

                Panel AppDownloadPanel = (Panel)this.get("AppDownload").getControl("AppDownloadPanel");

                PictureBox AppDownloadUpdateButton = (PictureBox)AppDownloadPanel.Controls["AppDownloadUpdateButton"];
                PictureBox AppDownloadUStartButton = (PictureBox)AppDownloadPanel.Controls["AppDownloadUStartButton"];

                string remoteVersion = activeApp.releases.First().TagName;
                InstalledApp installedApp = this.orianaLauncher.config.getApp(activeApp.name);

                if (installedApp == null)
                {
                    AppDownloadUpdateButton.Visible = true;
                    if (this.orianaLauncher.downloadInProgress == false)
                    {
                        AppDownloadUpdateButton.Enabled = true;
                    }
                    else
                    {
                        AppDownloadUpdateButton.Enabled = false;
                    }
                    //AppDownloadUpdateButton.Text = this.orianaLauncher.translator.lg("Install");
                    AppDownloadUStartButton.Visible = false;
                }
                else
                {
                    string installedVersion = installedApp.version.ToString();
                    if (remoteVersion == installedVersion)
                    {
                        AppDownloadUpdateButton.Visible = false;
                        AppDownloadUStartButton.Visible = true;
                    }
                    else
                    {
                        AppDownloadUpdateButton.Visible = true;
                        if (this.orianaLauncher.downloadInProgress == false)
                        {
                            AppDownloadUpdateButton.Enabled = true;
                        }
                        else
                        {
                            AppDownloadUpdateButton.Enabled = false;
                        }
                        //AppDownloadUpdateButton.Text = this.orianaLauncher.translator.lg("Update");
                        AppDownloadUStartButton.Visible = false;
                    }
                }

                AppDownloadUpdateButton.BackColor = Color.Transparent;
                AppDownloadUStartButton.BackColor = Color.Transparent;
            }
        }

        public void changeRelease(Release r)
        {
            Panel AppChangelogPanel = (Panel)this.get("AppChangelog").getControl("AppChangelogPanel");

            System.Windows.Forms.Label AppChangelogVersion = (System.Windows.Forms.Label)AppChangelogPanel.Controls["AppChangelogVersion"];
            AppChangelogVersion.Text = r.Name;

            System.Windows.Forms.Label AppChangelogContent = (System.Windows.Forms.Label)AppChangelogPanel.Controls["AppChangelogContentPanel"].Controls["AppChangelogContent"];

            string tag = "[" + this.orianaLauncher.config.language.Substring(0, 2).ToUpper() + "]";
            string content = r.Body;

            if (r.Body.IndexOf(tag) != -1)
            {
                content = r.Body.Substring(r.Body.IndexOf(tag) + 6);
            }
            if (content.IndexOf("[") != -1)
            {
                content = content.Substring(0, content.IndexOf("["));
            }

            AppChangelogContent.Text = content;


            App activeApp = activeApp = this.orianaLauncher.appList.apps[this.orianaLauncher.activeApp];

            PictureBox AppChangelogPrevious = (PictureBox)AppChangelogPanel.Controls["AppChangelogPrevious"];
            if (activeApp.currentRelease > 0)
            {
                AppChangelogPrevious.Visible = true;
            } else
            {
                AppChangelogPrevious.Visible = false;
            }
            PictureBox AppChangelogNext = (PictureBox)AppChangelogPanel.Controls["AppChangelogNext"];
            if (activeApp.currentRelease + 1 < activeApp.releases.Count())
            {
                AppChangelogNext.Visible = true;
            }
            else
            {
                AppChangelogNext.Visible = false;
            }
        }

        public void refresh()
        {
            this.components = new List<Component>();
            this.load();

            if (this.orianaLauncher.activeApp == 0)
            {
                this.events.openHomeWorker();
                
            }
            else if(this.orianaLauncher.activeApp == this.orianaLauncher.appList.apps.Count())
            {
                this.events.openSettingsWorker();
            } else
            {
                this.changeApp();
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
