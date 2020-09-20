using Microsoft.Win32;

namespace Privatezilla.Setting.Updates
{
    internal class BlockMajorUpdates : SettingBase
    {
        private const string TargetReleaseVersion = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\WindowsUpdate";
        private const string TargetReleaseVersionInfo = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\WindowsUpdate";
        private const int DesiredValue = 1;

        public override string ID()
        {
            return Properties.Resources.settingsUpdatesBlockMajorUpdates;
        }

        public override string Info()
        {
            return Properties.Resources.settingsUpdatesBlockMajorUpdatesInfo.Replace("\\n", "\n");
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(TargetReleaseVersion, "TargetReleaseVersion", DesiredValue) &&
               RegistryHelper.StringEquals(TargetReleaseVersionInfo, "TargetReleaseVersionInfo", WindowsHelper.GetOS())
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(TargetReleaseVersion, "TargetReleaseVersion", DesiredValue, RegistryValueKind.DWord);
                Registry.SetValue(TargetReleaseVersionInfo, "TargetReleaseVersionInfo", WindowsHelper.GetOS(), RegistryValueKind.String);
                return true;
            }
            catch
            { }

            return false;
        }

        public override bool UndoSetting()
        {
            try
            {
                var RegKey = Registry.LocalMachine.OpenSubKey(@"Software\Policies\Microsoft\Windows\WindowsUpdate", true);
                RegKey.DeleteValue("TargetReleaseVersion");
                RegKey.DeleteValue("TargetReleaseVersionInfo");
                return true;
            }
            catch
            { }

            return false;
        }

    }
}