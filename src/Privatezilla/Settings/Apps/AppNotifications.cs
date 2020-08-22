using Microsoft.Win32;

namespace Privatezilla.Setting.Apps
{
    internal class AppNotifications : SettingBase
    {
        private const string AppKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\PushNotifications";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return "Disable app notifications";
        }

        public override string Info()
        {
            return "The Action Center in Windows 10 collects and shows notifications and alerts from traditional Windows applications and system notifications, alongside those generated from modern apps.\nNotifications are then grouped in the Action Center by app and time.\nThis setting will disable all notifications from apps and other senders in settings.";
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