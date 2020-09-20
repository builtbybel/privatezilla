using Microsoft.Win32;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableHEIP: SettingBase
    {
        private const string HEIPKey = @"HKEY_CURRENT_USER\Software\Microsoft\Assistance\Client\1.0\Settings";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Properties.Resources.settingsPrivacyDisableHEIP;
        }

        public override string Info()
        {
            return Properties.Resources.settingsPrivacyDisableHEIPInfo;
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(HEIPKey, "ImplicitFeedback", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(HEIPKey, "ImplicitFeedback", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(HEIPKey, "ImplicitFeedback", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}