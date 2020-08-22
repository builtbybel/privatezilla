using Microsoft.Win32;

namespace Privatezilla.Setting.Privacy
{
    internal class SuggestedApps : SettingBase
    {
        private const string SuggestedKey = @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return "Block suggested apps in Start";
        }

        public override string Info()
        {
            return "This will block the Suggested Apps that occasionally appear on the Start menu.";
        }

        public override bool CheckSetting()
        {
             return !(
            RegistryHelper.IntEquals(SuggestedKey, "SubscribedContent-338388Enabled", DesiredValue)
                );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(SuggestedKey, "SubscribedContent-338388Enabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(SuggestedKey, "SubscribedContent-338388Enabled", 1 , RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}