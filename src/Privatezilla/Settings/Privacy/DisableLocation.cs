using Microsoft.Win32;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableLocation : SettingBase
    {
        private const string LocationKey = @"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location";
        private const string DesiredValue = @"Deny";

        public override string ID()
        {
            return "Disable Location tracking";
        }

        public override string Info()
        {
            return "Wherever you go, Windows 10 knows you're there. When Location Tracking is turned on, Windows and its apps are allowed to detect the current location of your computer or device.";
        }

        public override bool CheckSetting()
        {
            return !(
                RegistryHelper.StringEquals(LocationKey, "Value", DesiredValue)
            );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(LocationKey, "Value", DesiredValue, RegistryValueKind.String);
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
                Registry.SetValue(LocationKey, "Value", "Allow", RegistryValueKind.String);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}