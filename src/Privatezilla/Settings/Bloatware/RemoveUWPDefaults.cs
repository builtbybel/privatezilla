using System;
using System.Management.Automation;
using System.IO;
using Privatezilla.Locales;
using System.Linq;
using System.Text.RegularExpressions;

namespace Privatezilla.Setting.Bloatware
{
    internal class RemoveUWPDefaults : SettingBase
    {
        private readonly PowerShell powerShell = PowerShell.Create();

        public override string ID()
        {
            return Locale.settingsBloatwareRemoveUWPDefaults;
        }

        public override string Info()
        {
            return Locale.settingsBloatwareRemoveUWPDefaultsInfo.Replace("\\n", "\n");
        }

        private void RemoveApps(string str)
        {
            using (PowerShell script = PowerShell.Create())
            {
                script.AddScript("Get-AppxPackage " + str + " | Remove-AppxPackage");

                script.Invoke();
            }


            return;
        }

        public override bool CheckSetting()
        {
            var apps = BloatwareList.GetList();

            powerShell.Commands.Clear();
            powerShell.AddCommand("get-appxpackage");
            powerShell.AddCommand("Select").AddParameter("property", "name");


            foreach (PSObject result in powerShell.Invoke())
            {
                string current = result.ToString();

                if (!apps.Contains(Regex.Replace(current, "(@{Name=)|(})", ""))) continue;
            }

            return true;
        }

        public override bool DoSetting()
        {
            var apps = BloatwareList.GetList();

            foreach (var str in apps)
            {
                RemoveApps(str);
            }

            return true;
        }

        public override bool UndoSetting()
        {
            using (PowerShell script = PowerShell.Create())
            {
                script.AddScript("Get-AppxPackage -AllUsers| Foreach {Add-AppxPackage -DisableDevelopmentMode -Register “$($_.InstallLocation)\\AppXManifest.xml”}");

                try
                {
                    script.Invoke();
                    return true;
                }
                catch
                { }

                return false;
            }
        }

    }
}