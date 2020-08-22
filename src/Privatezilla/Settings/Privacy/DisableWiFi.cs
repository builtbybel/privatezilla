using Microsoft.Win32;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableWiFi : SettingBase
    {
        private const string WiFiKey = @"HKEY_LOCAL_MACHINE\Software\Microsoft\WcmSvc\wifinetworkmanager\config";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return "Disable Wi-Fi Sense";
        }

        public override string Info()
        {
            return "You should at least stop your PC from sending your Wi-Fi password.";
        }

        public override bool CheckSetting()
        {
            return !(
            RegistryHelper.IntEquals(WiFiKey, "AutoConnectAllowedOEM", DesiredValue)

            );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(WiFiKey, "AutoConnectAllowedOEM", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(WiFiKey, "AutoConnectAllowedOEM", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}