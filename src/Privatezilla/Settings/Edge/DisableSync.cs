using Microsoft.Win32;

namespace Privatezilla.Setting.Edge
{
    internal class DisableSync : SettingBase
    {
        private const string EdgeKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const int DesiredValue = 1;

        public override string ID()
        {
            return "Disable synchronization of data";
        }

        public override string Info()
        {
            return "This setting will disable synchronization of data using Microsoft sync services.";
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(EdgeKey, "SyncDisabled", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(EdgeKey, "SyncDisabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(EdgeKey, "SyncDisabled", 0, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}