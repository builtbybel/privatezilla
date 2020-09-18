using Privatezilla.ITreeNode;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Privatezilla
{
    public partial class MainWindow : Form
    {
        private readonly string _successApply = Properties.Resources.statusSuccessApply;
        private readonly string _failedApply = Properties.Resources.statusFailedApply;
        private readonly string _successConfigure = Properties.Resources.statusSuccessConfigure;
        private readonly string _failedConfigure = Properties.Resources.statusFailedConfigure;
        private readonly string _finishApply = Properties.Resources.statusFinishApply;
        private readonly string _finishUndo = Properties.Resources.statusFinishUndo;
        private readonly string _finishAnalyze = Properties.Resources.statusFinishAnalyze;
        private readonly string _doWait = Properties.Resources.statusDoWait;
        private readonly string _undoSettings = Properties.Resources.statusDoSettings;

        private readonly string _helpApp = Properties.Resources.helpApp.Replace("\\r\\n", "\r\n");

        // Script strings (optional)
        private readonly string _psSelect = Properties.Resources.msgPSSelect;

        private readonly string _psInfo = Properties.Resources.PSInfo.Replace("\\r\\n", "\r\n");
        private readonly string _psSuccess = Properties.Resources.msgPSSuccess;
        private readonly string _psSave = Properties.Resources.msgPSSave;

        private readonly string _infoApp = "Privatezilla" + "\nVersion " + Program.GetCurrentVersionTostring() + " (Phoenix)\r\n" +
                                            Properties.Resources.infoApp.Replace("\\t", "\t");

        // Setting progress
        private int _progress = 0;

        private int _progressIncrement = 0;

        // Update
        private readonly string _releaseURL = "https://raw.githubusercontent.com/builtbybel/privatezilla/master/latest.txt";

        private readonly string _releaseUpToDate = Properties.Resources.releaseUpToDate;
        private readonly string _releaseUnofficial = Properties.Resources.releaseUnofficial;

        public Version CurrentVersion = new Version(Application.ProductVersion);
        public Version LatestVersion;

        private void CheckRelease_Click(object sender, EventArgs e)
        {
            try
            {
                WebRequest hreq = WebRequest.Create(_releaseURL);
                hreq.Timeout = 10000;
                hreq.Headers.Set("Cache-Control", "no-cache, no-store, must-revalidate");

                WebResponse hres = hreq.GetResponse();
                StreamReader sr = new StreamReader(hres.GetResponseStream());

                LatestVersion = new Version(sr.ReadToEnd().Trim());

                // Done and dispose!
                sr.Dispose();
                hres.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); // Update check failed!
            }

            var equals = LatestVersion.CompareTo(CurrentVersion);

            if (equals == 0)
            {
                MessageBox.Show(_releaseUpToDate, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information); // Up-to-date
            }
            else if (equals < 0)
            {
                MessageBox.Show(_releaseUnofficial, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); // Unofficial
            }
            else // New release available!
            {
                if (MessageBox.Show(Properties.Resources.releaseUpdateAvailable + LatestVersion + Properties.Resources.releaseUpdateYourVersion.Replace("\\r\\n", "\r\n") + CurrentVersion + Properties.Resources.releaseUpdateAvailableURL.Replace("\\r\\n", "\r\n\n"), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) // New release available!
                {
                    Process.Start("https://github.com/builtbybel/privatezilla/releases/tag/" + LatestVersion);
                }
            }
        }

        public void Globalization()
        {
            BtnDoPS.Text = Properties.Resources.BtnDoPS;
            BtnSettingsAnalyze.Text = Properties.Resources.BtnSettingsAnalyze;
            BtnSettingsDo.Text = Properties.Resources.BtnSettingsDo;
            BtnSettingsUndo.Text = Properties.Resources.BtnSettingsUndo;
            ChkCodePS.Text = Properties.Resources.ChkCodePS;
            LblPS.Text = Properties.Resources.LblPS;
            LblPSHeader.Text = Properties.Resources.LblPSHeader;
            LblSettings.Text = Properties.Resources.LblSettings;
            LblStatus.Text = Properties.Resources.LblStatus;
            TxtPSInfo.Text = Properties.Resources.TxtPSInfo;
            CheckRelease.Text = Properties.Resources.CheckRelease;
            CommunityPkg.Text = Properties.Resources.CommunityPkg;
            Help.Text = Properties.Resources.Help;
            Info.Text = Properties.Resources.Info;
            PSImport.Text = Properties.Resources.PSImport;
            PSMarketplace.Text = Properties.Resources.PSMarketplace;
            PSSaveAs.Text = Properties.Resources.PSSaveAs;
            Setting.Text = Properties.Resources.columnSetting; // Status column
            State.Text = Properties.Resources.columnState;     // Status column
        }

        public MainWindow()
        {
            InitializeComponent();

            // Initilize settings
            InitializeSettings();

            // Check if community package is installed
            CommunityPackageAvailable();

            // GUI options
            LblMainMenu.Text = "\ue700";    // Hamburger menu

            // GUI localization
            Globalization();
        }

        public void InitializeSettings()
        {
            TvwSettings.Nodes.Clear();

            // Root node
            TreeNode root = new TreeNode("Windows 10 (" + WindowsHelper.GetOS() + ")")
            {
                Checked = false
            };

            // Settings > Privacy
            TreeNode privacy = new TreeNode(Properties.Resources.rootSettingsPrivacy, new TreeNode[] {
                new SettingNode(new Setting.Privacy.DisableTelemetry()),
                new SettingNode(new Setting.Privacy.DisableCompTelemetry()),
                new SettingNode(new Setting.Privacy.DisableAds()),
                new SettingNode(new Setting.Privacy.DisableWiFi()),
                new SettingNode(new Setting.Privacy.DiagnosticData()),
                new SettingNode(new Setting.Privacy.HandwritingData()),
                new SettingNode(new Setting.Privacy.DisableBiometrics()),
                new SettingNode(new Setting.Privacy.DisableTimeline()),
                new SettingNode(new Setting.Privacy.DisableLocation()),
                new SettingNode(new Setting.Privacy.DisableFeedback()),
                new SettingNode(new Setting.Privacy.DisableTips()),
                new SettingNode(new Setting.Privacy.DisableTipsLockScreen()),
                new SettingNode(new Setting.Privacy.InstalledApps()),
                new SettingNode(new Setting.Privacy.SuggestedApps()),
                new SettingNode(new Setting.Privacy.SuggestedContent()),
                new SettingNode(new Setting.Privacy.DisableCEIP()),
                new SettingNode(new Setting.Privacy.DisableHEIP()),
                new SettingNode(new Setting.Privacy.DisableMSExperiments()),
                new SettingNode(new Setting.Privacy.InventoryCollector()),
                new SettingNode(new Setting.Privacy.GetMoreOutOfWindows()),
            })
            {
                //Checked = true,
                //ToolTipText = "Privacy settings"
            };

            // Policies > Cortana
            TreeNode cortana = new TreeNode(Properties.Resources.rootSettingsCortana, new TreeNode[] {
                new SettingNode(new Setting.Cortana.DisableCortana()),
                new SettingNode(new Setting.Cortana.DisableBing()),
                new SettingNode(new Setting.Cortana.UninstallCortana()),
            });

            // Settings > Bloatware
            TreeNode bloatware = new TreeNode(Properties.Resources.rootSettingsBloatware, new TreeNode[] {
                new SettingNode(new Setting.Bloatware.RemoveUWPAll()),
                new SettingNode(new Setting.Bloatware.RemoveUWPDefaults()),
            })
            {
                ToolTipText = Properties.Resources.rootSettingsBloatwareInfo
            };

            // Settings > App permissions
            TreeNode apps = new TreeNode(Properties.Resources.rootSettingsApps, new TreeNode[] {
                new SettingNode(new Setting.Apps.AppNotifications()),
                new SettingNode(new Setting.Apps.Camera()),
                new SettingNode(new Setting.Apps.Microphone()),
                new SettingNode(new Setting.Apps.Call()),
                new SettingNode(new Setting.Apps.Notifications()),
                new SettingNode(new Setting.Apps.AccountInfo()),
                new SettingNode(new Setting.Apps.Contacts()),
                new SettingNode(new Setting.Apps.Calendar()),
                new SettingNode(new Setting.Apps.CallHistory()),
                new SettingNode(new Setting.Apps.Email()),
                new SettingNode(new Setting.Apps.Tasks()),
                new SettingNode(new Setting.Apps.Messaging()),
                new SettingNode(new Setting.Apps.Motion()),
                new SettingNode(new Setting.Apps.OtherDevices()),
                new SettingNode(new Setting.Apps.BackgroundApps()),
                new SettingNode(new Setting.Apps.TrackingApps()),
                new SettingNode(new Setting.Apps.DiagnosticInformation()),
                new SettingNode(new Setting.Apps.Documents()),
                new SettingNode(new Setting.Apps.Pictures()),
                new SettingNode(new Setting.Apps.Videos()),
                new SettingNode(new Setting.Apps.Radios()),
                new SettingNode(new Setting.Apps.FileSystem()),
                new SettingNode(new Setting.Apps.EyeGaze()),
                new SettingNode(new Setting.Apps.CellularData()),
            });

            // Settings > Updates
            TreeNode updates = new TreeNode(Properties.Resources.rootSettingsUpdates, new TreeNode[] {
                new SettingNode(new Setting.Updates.DisableUpdates()),
                new SettingNode(new Setting.Updates.DisableUpdatesSharing()),
                new SettingNode(new Setting.Updates.BlockMajorUpdates()),
            });

            // Settings > Gaming
            TreeNode gaming = new TreeNode(Properties.Resources.rootSettingsGaming, new TreeNode[] {
                new SettingNode(new Setting.Gaming.DisableGameBar()),
            });

            // Settings > Windows Defender
            TreeNode defender = new TreeNode(Properties.Resources.rootSettingsDefender, new TreeNode[] {
                new SettingNode(new Setting.Defender.DisableSmartScreenStore()),
            });

            // Settings > Microsoft Edge
            TreeNode edge = new TreeNode(Properties.Resources.rootSettingsDefender, new TreeNode[] {
                new SettingNode(new Setting.Edge.DisableAutoFillCredits()),
                new SettingNode(new Setting.Edge.EdgeBackground()),
                new SettingNode(new Setting.Edge.DisableSync()),
                new SettingNode(new Setting.Edge.BlockEdgeRollout()),
            });

            // Settings > Security
            TreeNode security = new TreeNode(Properties.Resources.rootSettingsSecurity, new TreeNode[] {
                new SettingNode(new Setting.Security.DisablePassword()),
                new SettingNode(new Setting.Security.WindowsDRM()),
            });

            // Add root nodes
            root.Nodes.AddRange(new TreeNode[]
            {
                privacy,
                cortana,
                bloatware,
                apps,
                updates,
                gaming,
                defender,
                edge,
                security,
             });

            TvwSettings.Nodes.Add(root);
            TvwSettings.ExpandAll();

            // Preselect nodes
            CheckNodes(privacy);

            // Set up ToolTip text for TvwSettings
            ToolTip tooltip = new ToolTip();
            tooltip.AutoPopDelay = 15000;
            tooltip.IsBalloon = true;
            tooltip.SetToolTip(this.TvwSettings, Properties.Resources.LblSettings);
        }

        private List<SettingNode> CollectSettingNodes()
        {
            List<SettingNode> selectedSettings = new List<SettingNode>();

            foreach (TreeNode treeNode in TvwSettings.Nodes.All())
            {
                if (treeNode.Checked && treeNode.GetType() == typeof(SettingNode))
                {
                    selectedSettings.Add((SettingNode)treeNode);
                }
            }

            _progressIncrement = (int)Math.Floor(100.0f / selectedSettings.Count);

            return selectedSettings;
        }

        private void Reset()
        {
            _progress = 0;
            _progressIncrement = 0;

            PBar.Visible = true;
            PBar.Value = 0;
            LvwStatus.HeaderStyle = ColumnHeaderStyle.Clickable; // Add Header to ListView
            LvwStatus.Items.Clear();
            LvwStatus.Refresh();
        }

        private void IncrementProgress()
        {
            _progress += _progressIncrement;
            PBar.Value = _progress;
        }

        private void DoProgress(int value)
        {
            _progress = value;
            PBar.Value = _progress;
        }

        // Check favored parent node including all child nodes
        public void CheckNodes(TreeNode startNode)
        {
            startNode.Checked = true;

            foreach (TreeNode node in startNode.Nodes)

                CheckNodes(node);
        }

        /// <summary>
        ///  Auto check child nodes when parent node is checked
        /// </summary>
        private void TvwSetting_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TvwSettings.BeginUpdate();

            foreach (TreeNode child in e.Node.Nodes)
            {
                child.Checked = e.Node.Checked;
            }

            TvwSettings.EndUpdate();
        }

        /// <summary>
        ///  Method to auto. resize column and set the width to the width of the last item in ListView
        /// </summary>
        private void ResizeListViewColumns(ListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                column.Width = -2;
            }
        }

        /// <summary>
        /// Check system for configured settings
        /// </summary>
        private async void BtnSettingsAnalyze_Click(object sender, EventArgs e)
        {
            Reset();
            LblStatus.Text = _doWait;
            BtnSettingsAnalyze.Enabled = false;

            LvwStatus.BeginUpdate();

            List<SettingNode> selectedSettings = CollectSettingNodes();

            foreach (SettingNode node in selectedSettings)
            {
                var setting = node.Setting;
                ListViewItem state = new ListViewItem(node.Parent.Text + ": " + setting.ID());
                ConfiguredTaskAwaitable<bool> analyzeTask = Task<bool>.Factory.StartNew(() => setting.CheckSetting()).ConfigureAwait(true);

                bool shouldPerform = await analyzeTask;

                if (shouldPerform)
                {
                    state.SubItems.Add(_failedConfigure);
                    state.BackColor = Color.LavenderBlush;
                }
                else
                {
                    state.SubItems.Add(_successConfigure);
                    state.BackColor = Color.Honeydew;
                }

                state.Tag = setting;
                LvwStatus.Items.Add(state);
                IncrementProgress();
            }

            DoProgress(100);

            // Summary
            LblStatus.Text = _finishAnalyze;
            BtnSettingsAnalyze.Enabled = true;
            LvwStatus.EndUpdate();

            ResizeListViewColumns(LvwStatus);
        }

        /// <summary>
        /// Apply selected settings
        /// </summary>
        ///
        private async void ApplySettings(List<SettingNode> treeNodes)
        {
            BtnSettingsDo.Enabled = false;
            LvwStatus.BeginUpdate();

            foreach (SettingNode node in treeNodes)
            {
                // Add status info
                LblStatus.Text = _doWait + " (" + node.Text + ")";

                var setting = node.Setting;
                ConfiguredTaskAwaitable<bool> performTask = Task<bool>.Factory.StartNew(() => setting.DoSetting()).ConfigureAwait(true);

                var result = await performTask;

                var listItem = new ListViewItem(setting.ID());
                if (result)
                {
                    listItem.SubItems.Add(_successApply);
                    listItem.BackColor = Color.Honeydew;
                }
                else
                {
                    listItem.SubItems.Add(_failedApply);
                    listItem.BackColor = Color.LavenderBlush;
                }

                LvwStatus.Items.Add(listItem);
                IncrementProgress();
            }

            DoProgress(100);

            LblStatus.Text = _finishApply;
            BtnSettingsDo.Enabled = true;
            LvwStatus.EndUpdate();

            ResizeListViewColumns(LvwStatus);
        }

        /// <summary>
        ///  Revert selected settings
        /// </summary>
        private async void UndoSettings(List<SettingNode> treeNodes)
        {
            LblStatus.Text = _doWait;
            BtnSettingsUndo.Enabled = false;
            LvwStatus.BeginUpdate();

            foreach (SettingNode node in treeNodes)
            {
                var setting = node.Setting;
                ConfiguredTaskAwaitable<bool> performTask = Task<bool>.Factory.StartNew(() => setting.UndoSetting()).ConfigureAwait(true);

                var result = await performTask;

                var listItem = new ListViewItem(setting.ID());
                if (result)
                {
                    listItem.SubItems.Add(_successApply);
                    listItem.BackColor = Color.Honeydew;
                }
                else
                {
                    listItem.SubItems.Add(_failedApply);
                    listItem.BackColor = Color.LavenderBlush;
                }

                LvwStatus.Items.Add(listItem);
                IncrementProgress();
            }

            DoProgress(100);

            LblStatus.Text = _finishUndo;
            BtnSettingsUndo.Enabled = true;
            LvwStatus.EndUpdate();

            ResizeListViewColumns(LvwStatus);
        }

        private void BtnSettingsDo_Click(object sender, EventArgs e)
        {
            Reset();

            List<SettingNode> performNodes = CollectSettingNodes();
            ApplySettings(performNodes);
        }

        private void BtnSettingsUndo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(_undoSettings, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Reset();

                List<SettingNode> performNodes = CollectSettingNodes();
                UndoSettings(performNodes);
            }
        }

        private void Info_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_infoApp, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblMainMenu_Click(object sender, EventArgs e)
        {
            this.MainMenu.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_helpApp, Help.Text, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Populate Setting files to Navigation > settings > LstPopulatePS
        /// </summary>
        private void PopulatePS()
        {
            // Switch to More
            PnlPS.Visible = true;
            BtnDoPS.Visible = true;
            ChkCodePS.Visible = true;
            LstPS.Visible = true;

            PnlSettings.Visible = false;
            BtnSettingsAnalyze.Visible = false;
            BtnSettingsUndo.Visible = false;
            BtnSettingsDo.Visible = false;
            TvwSettings.Visible = false;

            // Clear list
            LstPS.Items.Clear();

            DirectoryInfo dirs = new DirectoryInfo(@"scripts");
            FileInfo[] listSettings = dirs.GetFiles("*.ps1");
            foreach (FileInfo fi in listSettings)
            {
                LstPS.Items.Add(Path.GetFileNameWithoutExtension(fi.Name));
                LstPS.Enabled = true;
            }
        }

        private void LblPS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Show Info about feature
            try
            {
                StreamReader OpenFile = new StreamReader(@"scripts\" + "readme.txt");
                MessageBox.Show(OpenFile.ReadToEnd(), "Info about this feature", MessageBoxButtons.OK);
                OpenFile.Close();
            }
            catch
            { }

            // Refresh
            PopulatePS();
        }

        private void LblSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Switch to Setting
            PnlSettings.Visible = true;
            BtnSettingsAnalyze.Visible = true;
            BtnSettingsUndo.Visible = true;
            BtnSettingsDo.Visible = true;
            TvwSettings.Visible = true;

            PnlPS.Visible = false;
            BtnDoPS.Visible = false;
            ChkCodePS.Visible = false;
            LstPS.Visible = false;
        }

        private void LstPS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string psdir = @"scripts\" + LstPS.Text + ".ps1";

            //Read PS content line by line
            try
            {
                using (StreamReader sr = new StreamReader(@"scripts\" + LstPS.Text + ".ps1", Encoding.Default))
                {
                    StringBuilder content = new StringBuilder();

                    // writes line by line to the StringBuilder until the end of the file is reached
                    while (!sr.EndOfStream)
                        content.AppendLine(sr.ReadLine());

                    // View Code
                    TxtConsolePS.Text = content.ToString();

                    // View Info
                    TxtPSInfo.Text = _psInfo + string.Join(Environment.NewLine, System.IO.File.ReadAllLines(psdir).Where(s => s.StartsWith("###")).Select(s => s.Substring(3).Replace("###", "\r\n\n")));
                }
            }
            catch { }
        }

        /// <summary>
        /// Run custom PowerShell scripts
        /// </summary>
        private void BtnDoPS_Click(object sender, EventArgs e)
        {
            if (LstPS.CheckedItems.Count == 0)
            {
                MessageBox.Show(_psSelect, BtnDoPS.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            for (int i = 0; i < LstPS.Items.Count; i++)
            {
                if (LstPS.GetItemChecked(i))
                {
                    LstPS.SelectedIndex = i;
                    BtnDoPS.Text = Properties.Resources.statusDoPSProcessing;
                    PnlPS.Enabled = false;

                    //TxtOutputPS.Clear();
                    using (PowerShell powerShell = PowerShell.Create())
                    {
                        powerShell.AddScript(TxtConsolePS.Text);
                        powerShell.AddCommand("Out-String");
                        Collection<PSObject> PSOutput = powerShell.Invoke();
                        StringBuilder stringBuilder = new StringBuilder();
                        foreach (PSObject pSObject in PSOutput)
                            stringBuilder.AppendLine(pSObject.ToString());

                        TxtOutputPS.Text = stringBuilder.ToString();

                        BtnDoPS.Text = Properties.Resources.statusDoPSApply;
                        PnlPS.Enabled = true;
                    }

                    // Done!
                    MessageBox.Show("Script " + "\"" + LstPS.Text + "\" " + _psSuccess, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Open PowerShell code view
        /// </summary>
        private void ChkCodePS_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkCodePS.Checked == true)
            {
                ChkCodePS.Text = Properties.Resources.PSBack;
                TxtConsolePS.Visible = true;
                TxtOutputPS.Visible = false;
            }
            else
            {
                ChkCodePS.Text = Properties.Resources.PSViewCode;
                TxtOutputPS.Visible = true;
                TxtConsolePS.Visible = false;
            }
        }

        /// <summary>
        /// Import PowerShell script files
        /// </summary>
        private void PSImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "*.txt|*.txt|*.ps1|*.ps1";
            ofd.DefaultExt = ".ps1";
            ofd.RestoreDirectory = true;
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.FilterIndex = 2;

            string strDestPath = Application.StartupPath + @"\scripts";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in ofd.FileNames)
                {
                    try
                    {
                        File.Copy(fileName, strDestPath + @"\" + Path.GetFileName(fileName));
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, this.Text); }
                }
            }

            // Refresh
            PopulatePS();
        }

        /// <summary>
        /// Save opened PowerShell script files as new preset script files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PSSaveAs_Click(object sender, EventArgs e)
        {
            if (ChkCodePS.Checked == false)
            {
                MessageBox.Show(_psSave, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "*.txt|*.txt|*.ps1|*.ps1";
                dlg.DefaultExt = ".ps1";
                dlg.RestoreDirectory = true;
                dlg.InitialDirectory = Application.StartupPath + @"\scripts";
                dlg.FilterIndex = 2;

                try
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(dlg.FileName, TxtConsolePS.Text, Encoding.UTF8);
                        //Refresh
                        PopulatePS();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void PSMarketplace_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.builtbybel.com/marketplace");
        }

        private void CommunityPkg_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/builtbybel/privatezilla#community-package");
        }

        // Check if community package installed
        private void CommunityPackageAvailable()
        {
            string path = @"scripts";
            if (Directory.Exists(path))
            {
                LblPS.Visible = true;
                CommunityPkg.Visible = false;
            }
        }

        private bool sortAscending = false;

        private void LvwStatus_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (!sortAscending)
            {
                sortAscending = true;
            }
            else
            {
                sortAscending = false;
            }
            this.LvwStatus.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
        }

        private void BtnMenuPS_Click(object sender, EventArgs e)
        {
            this.PSMenu.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void PicOpenGitHubPage_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/builtbybel/privatezilla");
        }
    }
}