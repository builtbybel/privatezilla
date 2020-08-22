using Microsoft.Win32;

namespace Privatezilla.Setting.Privacy
{
    internal class InstalledApps : SettingBase
    {
        private const string InstalledKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return "Block automatic Installation of apps";
        }

        public override string Info()
        {
            return "When you sign-in to a new Windows 10 profile or device for the first time, chance is that you notice several third-party applications and games listed prominently in the Start menu.\nThis setting will block automatic Installation of suggested Windows 10 apps.";
        }

        public override bool CheckSetting()
        {

          return !(
          RegistryHelper.IntEquals(InstalledKey, "SilentInstalledAppsEnabled", DesiredValue)
              );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(InstalledKey, "SilentInstalledAppsEnabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(InstalledKey, "SilentInstalledAppsEnabled", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}