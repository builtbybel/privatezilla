namespace Privatezilla
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.TvwSettings = new System.Windows.Forms.TreeView();
            this.LblMainMenu = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Help = new System.Windows.Forms.ToolStripMenuItem();
            this.CommunityPkg = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckRelease = new System.Windows.Forms.ToolStripMenuItem();
            this.Info = new System.Windows.Forms.ToolStripMenuItem();
            this.PnlNav = new System.Windows.Forms.Panel();
            this.LblPS = new System.Windows.Forms.LinkLabel();
            this.LblSettings = new System.Windows.Forms.LinkLabel();
            this.LstPS = new System.Windows.Forms.CheckedListBox();
            this.PnlSettings = new System.Windows.Forms.Panel();
            this.PicOpenGitHubPage = new System.Windows.Forms.PictureBox();
            this.BtnSettingsUndo = new System.Windows.Forms.Button();
            this.LvwStatus = new System.Windows.Forms.ListView();
            this.Setting = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PBar = new System.Windows.Forms.ProgressBar();
            this.BtnSettingsDo = new System.Windows.Forms.Button();
            this.BtnSettingsAnalyze = new System.Windows.Forms.Button();
            this.LblStatus = new System.Windows.Forms.Label();
            this.PnlPS = new System.Windows.Forms.Panel();
            this.BtnMenuPS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ChkCodePS = new System.Windows.Forms.CheckBox();
            this.BtnDoPS = new System.Windows.Forms.Button();
            this.TxtPSInfo = new System.Windows.Forms.TextBox();
            this.TxtConsolePS = new System.Windows.Forms.TextBox();
            this.TxtOutputPS = new System.Windows.Forms.TextBox();
            this.PSMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PSImport = new System.Windows.Forms.ToolStripMenuItem();
            this.PSSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.PSMarketplace = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MainMenu.SuspendLayout();
            this.PnlNav.SuspendLayout();
            this.PnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicOpenGitHubPage)).BeginInit();
            this.PnlPS.SuspendLayout();
            this.PSMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TvwSettings
            // 
            this.TvwSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TvwSettings.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TvwSettings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TvwSettings.CheckBoxes = true;
            this.TvwSettings.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TvwSettings.LineColor = System.Drawing.Color.DarkOrchid;
            this.TvwSettings.Location = new System.Drawing.Point(12, 88);
            this.TvwSettings.Name = "TvwSettings";
            this.TvwSettings.ShowLines = false;
            this.TvwSettings.ShowNodeToolTips = true;
            this.TvwSettings.ShowPlusMinus = false;
            this.TvwSettings.Size = new System.Drawing.Size(355, 749);
            this.TvwSettings.TabIndex = 18;
            this.TvwSettings.TabStop = false;
            this.TvwSettings.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TvwSetting_AfterCheck);
            // 
            // LblMainMenu
            // 
            this.LblMainMenu.AutoSize = true;
            this.LblMainMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LblMainMenu.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.LblMainMenu.FlatAppearance.BorderSize = 0;
            this.LblMainMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.HotPink;
            this.LblMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblMainMenu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMainMenu.ForeColor = System.Drawing.Color.Black;
            this.LblMainMenu.Location = new System.Drawing.Point(0, 0);
            this.LblMainMenu.Name = "LblMainMenu";
            this.LblMainMenu.Size = new System.Drawing.Size(48, 51);
            this.LblMainMenu.TabIndex = 21;
            this.LblMainMenu.UseVisualStyleBackColor = false;
            this.LblMainMenu.Click += new System.EventHandler(this.LblMainMenu_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Help,
            this.CommunityPkg,
            this.CheckRelease,
            this.Info});
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MainMenu.Size = new System.Drawing.Size(271, 116);
            // 
            // Help
            // 
            this.Help.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(270, 28);
            this.Help.Text = "Short Guide";
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // CommunityPkg
            // 
            this.CommunityPkg.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommunityPkg.Image = ((System.Drawing.Image)(resources.GetObject("CommunityPkg.Image")));
            this.CommunityPkg.Name = "CommunityPkg";
            this.CommunityPkg.Size = new System.Drawing.Size(270, 28);
            this.CommunityPkg.Text = "Get community package";
            this.CommunityPkg.Click += new System.EventHandler(this.CommunityPkg_Click);
            // 
            // CheckRelease
            // 
            this.CheckRelease.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckRelease.Name = "CheckRelease";
            this.CheckRelease.Size = new System.Drawing.Size(270, 28);
            this.CheckRelease.Text = "Check for updates";
            this.CheckRelease.Click += new System.EventHandler(this.CheckRelease_Click);
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(270, 28);
            this.Info.Text = "Info";
            this.Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // PnlNav
            // 
            this.PnlNav.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PnlNav.Controls.Add(this.LblPS);
            this.PnlNav.Controls.Add(this.LblSettings);
            this.PnlNav.Controls.Add(this.LblMainMenu);
            this.PnlNav.Controls.Add(this.TvwSettings);
            this.PnlNav.Controls.Add(this.LstPS);
            this.PnlNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlNav.Location = new System.Drawing.Point(0, 0);
            this.PnlNav.Name = "PnlNav";
            this.PnlNav.Size = new System.Drawing.Size(367, 837);
            this.PnlNav.TabIndex = 26;
            // 
            // LblPS
            // 
            this.LblPS.ActiveLinkColor = System.Drawing.Color.DeepPink;
            this.LblPS.AutoEllipsis = true;
            this.LblPS.AutoSize = true;
            this.LblPS.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblPS.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LblPS.LinkColor = System.Drawing.Color.Black;
            this.LblPS.Location = new System.Drawing.Point(104, 54);
            this.LblPS.Name = "LblPS";
            this.LblPS.Size = new System.Drawing.Size(60, 21);
            this.LblPS.TabIndex = 25;
            this.LblPS.TabStop = true;
            this.LblPS.Text = "Scripts";
            this.LblPS.Visible = false;
            this.LblPS.VisitedLinkColor = System.Drawing.Color.DimGray;
            this.LblPS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblPS_LinkClicked);
            // 
            // LblSettings
            // 
            this.LblSettings.ActiveLinkColor = System.Drawing.Color.DeepPink;
            this.LblSettings.AutoEllipsis = true;
            this.LblSettings.AutoSize = true;
            this.LblSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblSettings.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LblSettings.LinkColor = System.Drawing.Color.Black;
            this.LblSettings.Location = new System.Drawing.Point(12, 54);
            this.LblSettings.Name = "LblSettings";
            this.LblSettings.Size = new System.Drawing.Size(70, 21);
            this.LblSettings.TabIndex = 24;
            this.LblSettings.TabStop = true;
            this.LblSettings.Text = "Settings";
            this.LblSettings.VisitedLinkColor = System.Drawing.Color.DimGray;
            this.LblSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblSettings_LinkClicked);
            // 
            // LstPS
            // 
            this.LstPS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstPS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LstPS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LstPS.Font = new System.Drawing.Font("Segoe UI Semilight", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstPS.ForeColor = System.Drawing.Color.Black;
            this.LstPS.FormattingEnabled = true;
            this.LstPS.Location = new System.Drawing.Point(16, 88);
            this.LstPS.Name = "LstPS";
            this.LstPS.Size = new System.Drawing.Size(351, 700);
            this.LstPS.Sorted = true;
            this.LstPS.TabIndex = 112;
            this.LstPS.ThreeDCheckBoxes = true;
            this.LstPS.Visible = false;
            this.LstPS.SelectedIndexChanged += new System.EventHandler(this.LstPS_SelectedIndexChanged);
            // 
            // PnlSettings
            // 
            this.PnlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlSettings.Controls.Add(this.PicOpenGitHubPage);
            this.PnlSettings.Controls.Add(this.BtnSettingsUndo);
            this.PnlSettings.Controls.Add(this.LvwStatus);
            this.PnlSettings.Controls.Add(this.PBar);
            this.PnlSettings.Controls.Add(this.BtnSettingsDo);
            this.PnlSettings.Controls.Add(this.BtnSettingsAnalyze);
            this.PnlSettings.Controls.Add(this.LblStatus);
            this.PnlSettings.Location = new System.Drawing.Point(366, 0);
            this.PnlSettings.Name = "PnlSettings";
            this.PnlSettings.Size = new System.Drawing.Size(716, 837);
            this.PnlSettings.TabIndex = 113;
            // 
            // PicOpenGitHubPage
            // 
            this.PicOpenGitHubPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PicOpenGitHubPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicOpenGitHubPage.Image = ((System.Drawing.Image)(resources.GetObject("PicOpenGitHubPage.Image")));
            this.PicOpenGitHubPage.Location = new System.Drawing.Point(681, 7);
            this.PicOpenGitHubPage.Name = "PicOpenGitHubPage";
            this.PicOpenGitHubPage.Size = new System.Drawing.Size(24, 24);
            this.PicOpenGitHubPage.TabIndex = 32;
            this.PicOpenGitHubPage.TabStop = false;
            this.ToolTip.SetToolTip(this.PicOpenGitHubPage, "github/privatezilla");
            this.PicOpenGitHubPage.Click += new System.EventHandler(this.PicOpenGitHubPage_Click);
            // 
            // BtnSettingsUndo
            // 
            this.BtnSettingsUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSettingsUndo.BackColor = System.Drawing.Color.Gainsboro;
            this.BtnSettingsUndo.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.BtnSettingsUndo.FlatAppearance.BorderSize = 0;
            this.BtnSettingsUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSettingsUndo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSettingsUndo.Location = new System.Drawing.Point(298, 794);
            this.BtnSettingsUndo.Name = "BtnSettingsUndo";
            this.BtnSettingsUndo.Size = new System.Drawing.Size(196, 32);
            this.BtnSettingsUndo.TabIndex = 30;
            this.BtnSettingsUndo.Text = "Revert selected";
            this.BtnSettingsUndo.UseVisualStyleBackColor = false;
            this.BtnSettingsUndo.Click += new System.EventHandler(this.BtnSettingsUndo_Click);
            // 
            // LvwStatus
            // 
            this.LvwStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LvwStatus.BackColor = System.Drawing.Color.White;
            this.LvwStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LvwStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Setting,
            this.State});
            this.LvwStatus.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LvwStatus.FullRowSelect = true;
            this.LvwStatus.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LvwStatus.HideSelection = false;
            this.LvwStatus.Location = new System.Drawing.Point(9, 50);
            this.LvwStatus.Name = "LvwStatus";
            this.LvwStatus.Size = new System.Drawing.Size(704, 723);
            this.LvwStatus.TabIndex = 31;
            this.LvwStatus.TileSize = new System.Drawing.Size(1, 1);
            this.LvwStatus.UseCompatibleStateImageBehavior = false;
            this.LvwStatus.View = System.Windows.Forms.View.Details;
            this.LvwStatus.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvwStatus_ColumnClick);
            // 
            // Setting
            // 
            this.Setting.Text = "Setting";
            this.Setting.Width = 550;
            // 
            // State
            // 
            this.State.Text = "State";
            this.State.Width = 150;
            // 
            // PBar
            // 
            this.PBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PBar.Location = new System.Drawing.Point(12, 41);
            this.PBar.Name = "PBar";
            this.PBar.Size = new System.Drawing.Size(814, 5);
            this.PBar.TabIndex = 27;
            this.PBar.Visible = false;
            // 
            // BtnSettingsDo
            // 
            this.BtnSettingsDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSettingsDo.BackColor = System.Drawing.Color.Gainsboro;
            this.BtnSettingsDo.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.BtnSettingsDo.FlatAppearance.BorderSize = 0;
            this.BtnSettingsDo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSettingsDo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSettingsDo.Location = new System.Drawing.Point(509, 794);
            this.BtnSettingsDo.Name = "BtnSettingsDo";
            this.BtnSettingsDo.Size = new System.Drawing.Size(196, 32);
            this.BtnSettingsDo.TabIndex = 26;
            this.BtnSettingsDo.Text = "Apply selected";
            this.BtnSettingsDo.UseVisualStyleBackColor = false;
            this.BtnSettingsDo.Click += new System.EventHandler(this.BtnSettingsDo_Click);
            // 
            // BtnSettingsAnalyze
            // 
            this.BtnSettingsAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnSettingsAnalyze.BackColor = System.Drawing.Color.Gainsboro;
            this.BtnSettingsAnalyze.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.BtnSettingsAnalyze.FlatAppearance.BorderSize = 0;
            this.BtnSettingsAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSettingsAnalyze.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSettingsAnalyze.Location = new System.Drawing.Point(13, 794);
            this.BtnSettingsAnalyze.Name = "BtnSettingsAnalyze";
            this.BtnSettingsAnalyze.Size = new System.Drawing.Size(196, 32);
            this.BtnSettingsAnalyze.TabIndex = 28;
            this.BtnSettingsAnalyze.Text = "Analyze";
            this.BtnSettingsAnalyze.UseVisualStyleBackColor = false;
            this.BtnSettingsAnalyze.Click += new System.EventHandler(this.BtnSettingsAnalyze_Click);
            // 
            // LblStatus
            // 
            this.LblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblStatus.AutoEllipsis = true;
            this.LblStatus.BackColor = System.Drawing.Color.White;
            this.LblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStatus.Location = new System.Drawing.Point(9, 7);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(704, 40);
            this.LblStatus.TabIndex = 29;
            this.LblStatus.Text = "Press Analyze to check for configured settings.";
            // 
            // PnlPS
            // 
            this.PnlPS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlPS.BackColor = System.Drawing.Color.White;
            this.PnlPS.Controls.Add(this.BtnMenuPS);
            this.PnlPS.Controls.Add(this.label1);
            this.PnlPS.Controls.Add(this.ChkCodePS);
            this.PnlPS.Controls.Add(this.BtnDoPS);
            this.PnlPS.Controls.Add(this.TxtPSInfo);
            this.PnlPS.Controls.Add(this.TxtConsolePS);
            this.PnlPS.Controls.Add(this.TxtOutputPS);
            this.PnlPS.Location = new System.Drawing.Point(366, 0);
            this.PnlPS.Name = "PnlPS";
            this.PnlPS.Size = new System.Drawing.Size(716, 837);
            this.PnlPS.TabIndex = 113;
            this.PnlPS.Visible = false;
            // 
            // BtnMenuPS
            // 
            this.BtnMenuPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMenuPS.BackColor = System.Drawing.Color.Gainsboro;
            this.BtnMenuPS.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.BtnMenuPS.FlatAppearance.BorderSize = 0;
            this.BtnMenuPS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.BtnMenuPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMenuPS.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMenuPS.ForeColor = System.Drawing.Color.Black;
            this.BtnMenuPS.Location = new System.Drawing.Point(671, 0);
            this.BtnMenuPS.Name = "BtnMenuPS";
            this.BtnMenuPS.Size = new System.Drawing.Size(45, 45);
            this.BtnMenuPS.TabIndex = 118;
            this.BtnMenuPS.Text = ". . .";
            this.BtnMenuPS.UseVisualStyleBackColor = false;
            this.BtnMenuPS.Click += new System.EventHandler(this.BtnMenuPS_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(716, 45);
            this.label1.TabIndex = 116;
            this.label1.Text = "Apply PowerShell Script";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChkCodePS
            // 
            this.ChkCodePS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChkCodePS.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkCodePS.BackColor = System.Drawing.Color.Gainsboro;
            this.ChkCodePS.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ChkCodePS.FlatAppearance.BorderSize = 0;
            this.ChkCodePS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChkCodePS.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkCodePS.ForeColor = System.Drawing.Color.Black;
            this.ChkCodePS.Location = new System.Drawing.Point(13, 794);
            this.ChkCodePS.Margin = new System.Windows.Forms.Padding(2);
            this.ChkCodePS.Name = "ChkCodePS";
            this.ChkCodePS.Size = new System.Drawing.Size(196, 32);
            this.ChkCodePS.TabIndex = 113;
            this.ChkCodePS.Text = "View code";
            this.ChkCodePS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkCodePS.UseVisualStyleBackColor = false;
            this.ChkCodePS.CheckedChanged += new System.EventHandler(this.ChkCodePS_CheckedChanged);
            // 
            // BtnDoPS
            // 
            this.BtnDoPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDoPS.BackColor = System.Drawing.Color.Gainsboro;
            this.BtnDoPS.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.BtnDoPS.FlatAppearance.BorderSize = 0;
            this.BtnDoPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDoPS.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDoPS.Location = new System.Drawing.Point(509, 794);
            this.BtnDoPS.Name = "BtnDoPS";
            this.BtnDoPS.Size = new System.Drawing.Size(196, 32);
            this.BtnDoPS.TabIndex = 112;
            this.BtnDoPS.Text = "Apply selected";
            this.BtnDoPS.UseVisualStyleBackColor = false;
            this.BtnDoPS.Click += new System.EventHandler(this.BtnDoPS_Click);
            // 
            // TxtPSInfo
            // 
            this.TxtPSInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtPSInfo.BackColor = System.Drawing.Color.White;
            this.TxtPSInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtPSInfo.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPSInfo.ForeColor = System.Drawing.Color.Black;
            this.TxtPSInfo.Location = new System.Drawing.Point(3, 48);
            this.TxtPSInfo.Multiline = true;
            this.TxtPSInfo.Name = "TxtPSInfo";
            this.TxtPSInfo.ReadOnly = true;
            this.TxtPSInfo.Size = new System.Drawing.Size(238, 778);
            this.TxtPSInfo.TabIndex = 110;
            this.TxtPSInfo.Text = resources.GetString("TxtPSInfo.Text");
            // 
            // TxtConsolePS
            // 
            this.TxtConsolePS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtConsolePS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TxtConsolePS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.TxtConsolePS.BackColor = System.Drawing.Color.PaleTurquoise;
            this.TxtConsolePS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtConsolePS.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConsolePS.ForeColor = System.Drawing.Color.Black;
            this.TxtConsolePS.Location = new System.Drawing.Point(242, 48);
            this.TxtConsolePS.Multiline = true;
            this.TxtConsolePS.Name = "TxtConsolePS";
            this.TxtConsolePS.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtConsolePS.Size = new System.Drawing.Size(474, 740);
            this.TxtConsolePS.TabIndex = 111;
            this.TxtConsolePS.Visible = false;
            this.TxtConsolePS.WordWrap = false;
            // 
            // TxtOutputPS
            // 
            this.TxtOutputPS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtOutputPS.BackColor = System.Drawing.Color.White;
            this.TxtOutputPS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtOutputPS.Font = new System.Drawing.Font("Consolas", 9F);
            this.TxtOutputPS.ForeColor = System.Drawing.Color.Black;
            this.TxtOutputPS.Location = new System.Drawing.Point(242, 48);
            this.TxtOutputPS.Multiline = true;
            this.TxtOutputPS.Name = "TxtOutputPS";
            this.TxtOutputPS.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtOutputPS.Size = new System.Drawing.Size(474, 740);
            this.TxtOutputPS.TabIndex = 10;
            this.TxtOutputPS.Text = "PS";
            this.TxtOutputPS.WordWrap = false;
            // 
            // PSMenu
            // 
            this.PSMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PSMenu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.PSMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PSImport,
            this.PSSaveAs,
            this.PSMarketplace});
            this.PSMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.PSMenu.Name = "contextHostsMenu";
            this.PSMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.PSMenu.Size = new System.Drawing.Size(353, 82);
            // 
            // PSImport
            // 
            this.PSImport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PSImport.Name = "PSImport";
            this.PSImport.Size = new System.Drawing.Size(352, 26);
            this.PSImport.Text = "Import script";
            this.PSImport.Click += new System.EventHandler(this.PSImport_Click);
            // 
            // PSSaveAs
            // 
            this.PSSaveAs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PSSaveAs.Name = "PSSaveAs";
            this.PSSaveAs.Size = new System.Drawing.Size(352, 26);
            this.PSSaveAs.Text = "Save current script as new preset script";
            this.PSSaveAs.Click += new System.EventHandler(this.PSSaveAs_Click);
            // 
            // PSMarketplace
            // 
            this.PSMarketplace.BackColor = System.Drawing.Color.Transparent;
            this.PSMarketplace.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PSMarketplace.ForeColor = System.Drawing.Color.Black;
            this.PSMarketplace.Image = ((System.Drawing.Image)(resources.GetObject("PSMarketplace.Image")));
            this.PSMarketplace.Name = "PSMarketplace";
            this.PSMarketplace.Size = new System.Drawing.Size(352, 26);
            this.PSMarketplace.Text = "Visit Marketplace";
            this.PSMarketplace.Click += new System.EventHandler(this.PSMarketplace_Click);
            // 
            // ToolTip
            // 
            this.ToolTip.AutomaticDelay = 0;
            this.ToolTip.UseAnimation = false;
            this.ToolTip.UseFading = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1083, 837);
            this.Controls.Add(this.PnlNav);
            this.Controls.Add(this.PnlSettings);
            this.Controls.Add(this.PnlPS);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1019, 550);
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Privatezilla";
            this.MainMenu.ResumeLayout(false);
            this.PnlNav.ResumeLayout(false);
            this.PnlNav.PerformLayout();
            this.PnlSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicOpenGitHubPage)).EndInit();
            this.PnlPS.ResumeLayout(false);
            this.PnlPS.PerformLayout();
            this.PSMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView TvwSettings;
        private System.Windows.Forms.Button LblMainMenu;
        private System.Windows.Forms.ContextMenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem Info;
        private System.Windows.Forms.ToolStripMenuItem CheckRelease;
        private System.Windows.Forms.ToolStripMenuItem Help;
        private System.Windows.Forms.Panel PnlNav;
        private System.Windows.Forms.LinkLabel LblSettings;
        private System.Windows.Forms.LinkLabel LblPS;
        private System.Windows.Forms.CheckedListBox LstPS;
        private System.Windows.Forms.Panel PnlSettings;
        private System.Windows.Forms.ListView LvwStatus;
        private System.Windows.Forms.ColumnHeader Setting;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.Button BtnSettingsUndo;
        private System.Windows.Forms.ProgressBar PBar;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.Button BtnSettingsDo;
        private System.Windows.Forms.Button BtnSettingsAnalyze;
        private System.Windows.Forms.Panel PnlPS;
        private System.Windows.Forms.TextBox TxtPSInfo;
        private System.Windows.Forms.TextBox TxtOutputPS;
        private System.Windows.Forms.TextBox TxtConsolePS;
        private System.Windows.Forms.CheckBox ChkCodePS;
        private System.Windows.Forms.Button BtnDoPS;
        private System.Windows.Forms.ContextMenuStrip PSMenu;
        private System.Windows.Forms.ToolStripMenuItem PSImport;
        private System.Windows.Forms.ToolStripMenuItem PSSaveAs;
        private System.Windows.Forms.ToolStripMenuItem PSMarketplace;
        private System.Windows.Forms.ToolStripMenuItem CommunityPkg;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Button BtnMenuPS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PicOpenGitHubPage;
    }
}

