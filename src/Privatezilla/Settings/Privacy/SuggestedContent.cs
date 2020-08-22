using Microsoft.Win32;

namespace Privatezilla.Setting.Privacy
{
    internal class SuggestedContent : SettingBase
    {
        private const string SubscribedContent338393 = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";
        private const string SubscribedContent353694 = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";
        private const string SubscribedContent353696 = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return "Block suggested content in Settings app";
        }

        public override string Info()
        {
            return "To help new Windows 10 users to learn new features of Windows 10, Microsoft has started showing suggested content via a huge banner in Windows 10 Setting Apps. ";
        }

        public override bool CheckSetting()
        {
            return !(
                 RegistryHelper.IntEquals(SubscribedContent338393, "SubscribedContent-338393Enabled", DesiredValue) &&
                 RegistryHelper.IntEquals(SubscribedContent353694, "SubscribedContent-353694Enabled", DesiredValue) &&
                 RegistryHelper.IntEquals(SubscribedContent353696, "SubscribedContent-353696Enabled", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(SubscribedContent338393, "SubscribedContent-338393Enabled", DesiredValue, RegistryValueKind.DWord);
                Registry.SetValue(SubscribedContent353694, "SubscribedContent-353694Enabled", DesiredValue, RegistryValueKind.DWord);
                Registry.SetValue(SubscribedContent353696, "SubscribedContent-353696Enabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(SubscribedContent338393, "SubscribedContent-338393Enabled", 1, RegistryValueKind.DWord);
                Registry.SetValue(SubscribedContent353694, "SubscribedContent-353694Enabled", 1, RegistryValueKind.DWord);
                Registry.SetValue(SubscribedContent353696, "SubscribedContent-353696Enabled", 1, RegistryValueKind.DWord);

                return true;
            }
            catch
            { }

            return false;
        }


    }
}