using Microsoft.Win32;

namespace Privatezilla.Setting.Edge
{
    internal class EdgeBackground : SettingBase
    {
        private const string EdgeKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Properties.Resources.settingsEdgeBackground;
        }

        public override string Info()
        {
            return Properties.Resources.settingsEdgeBackgroundInfo;
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(EdgeKey, "BackgroundModeEnabled", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(EdgeKey, "BackgroundModeEnabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(EdgeKey, "BackgroundModeEnabled", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}