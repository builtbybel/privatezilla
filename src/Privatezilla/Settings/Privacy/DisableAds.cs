using Microsoft.Win32;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableAds : SettingBase
    {
        private const string AdsKey = @"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return "Disable Advertising ID for Relevant Ads";
        }

        public override string Info()
        {
            return "Windows 10 comes integrated with advertising. Microsoft assigns a unique identificator to track your activity in the Microsoft Store and on UWP apps to target you with relevant ads.";
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(AdsKey, "Enabled", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(AdsKey, "Enabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(AdsKey, "Enabled", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}