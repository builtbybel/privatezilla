using Microsoft.Win32;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableTimeline : SettingBase
    {
        private const string EnableActivityFeed = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\System";
        private const string PublishUserActivities = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\System";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return "Disable Timeline feature";
        }

        public override string Info()
        {
            return "This collects a history of activities you've performed, including files you've opened and web pages you've viewed in Edge.\nIf Timeline isn’t for you, or you simply don’t want Windows 10 collecting your sensitive activities and information, you can disable Timeline completely with this setting.\nNote: A system reboot is required for the changes to take effect.";
        }

        public override bool CheckSetting()
        {
            return !(
                RegistryHelper.IntEquals(EnableActivityFeed, "EnableActivityFeed", DesiredValue) &&
                RegistryHelper.IntEquals(PublishUserActivities, "PublishUserActivities", DesiredValue)
            );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(EnableActivityFeed, "EnableActivityFeed", DesiredValue, RegistryValueKind.DWord);
                Registry.SetValue(PublishUserActivities, "PublishUserActivities", DesiredValue, RegistryValueKind.DWord);
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
                var RegKey = Registry.LocalMachine.OpenSubKey(@"Software\Policies\Microsoft\Windows\System", true);
                RegKey.DeleteValue("EnableActivityFeed");
                RegKey.DeleteValue("PublishUserActivities");

                return true;
            }
            catch
            { }

            return false;
        }

    }
}