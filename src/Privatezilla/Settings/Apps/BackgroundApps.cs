using Microsoft.Win32;

namespace Privatezilla.Setting.Apps
{
    internal class BackgroundApps: SettingBase
    {
        private const string AppKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications";
        private const int DesiredValue =1;

        public override string ID()
        {
            return "Disable apps running in background";
        }

        public override string Info()
        {
            return "Windows 10 apps have no more permission to run in the background so they can't update their live tiles, fetch new data, and receive notifications.";
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(AppKey, "GlobalUserDisabled", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(AppKey, "GlobalUserDisabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(AppKey, "GlobalUserDisabled", 0, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }
    }
}