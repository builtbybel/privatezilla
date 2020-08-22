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
            return "Block major Windows updates";
        }

        public override string Info()
        {
            return "This setting called \"TargetReleaseVersionInfo\" prevents Windows 10 feature updates from being installed until the specified version reaches the end of support.\nIt will specify your currently used Windows 10 version as the target release version of Windows 10 that you wish the system to be on (supports only Pro and enterprise versions).";
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