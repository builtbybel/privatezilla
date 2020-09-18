using Microsoft.Win32;

namespace Privatezilla.Setting.Apps
{
    internal class AppNotifications : SettingBase
    {
        private const string AppKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\PushNotifications";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Properties.Resources.settingsAppsAppNotifications;
        }

        public override string Info()
        {
            return Properties.Resources.settingsAppsAppNotificationsInfo.Replace("\\n", "\n");
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(AppKey, "ToastEnabled", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(AppKey, "ToastEnabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(AppKey, "ToastEnabled", "1", RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }
    }
}