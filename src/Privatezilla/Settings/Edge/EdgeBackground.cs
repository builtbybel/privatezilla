using Microsoft.Win32;

namespace Privatezilla.Setting.Edge
{
    internal class EdgeBackground : SettingBase
    {
        private const string EdgeKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return "Prevent Edge running in background";
        }

        public override string Info()
        {
            return "On the new Chromium version of Microsoft Edge, extensions and other services can keep the browser running in the background even after it's closed.";
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