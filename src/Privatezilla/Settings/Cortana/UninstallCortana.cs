using System;
using System.Management.Automation;
using System.IO;

namespace Privatezilla.Setting.Cortana
{
    internal class UninstallCortana : SettingBase
    {
        public override string ID()
        {
            return "Uninstall Cortana";
        }

        public override string Info()
        {
            return "This will uninstall the new Cortana app on Windows 10, version 2004.";
        }

        public override bool CheckSetting()
        {
            // Cortana Package ID on Windows 10, version 2004 is *Microsoft.549981C3F5F10*
            var appPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Packages", "Microsoft.549981C3F5F10");

            if (Directory.Exists(appPath))
            {
                return true;
            }


            return false;
        }

        public override bool DoSetting()
        {
            using (PowerShell script = PowerShell.Create())
            {
                script.AddScript("Get-appxpackage *Microsoft.549981C3F5F10* | Remove-AppxPackage");

                try
                {
                    script.Invoke();
                }
                catch
                { }
            }

            return true;
        }

        public override bool UndoSetting()
        {
            using (PowerShell script = PowerShell.Create())
            {
                script.AddScript("Get-AppXPackage -Name Microsoft.Windows.Cortana | Foreach {Add-AppxPackage -DisableDevelopmentMode -Register \"$($_.InstallLocation)AppXManifest.xml}\"");

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