using Microsoft.Win32;

namespace Privatezilla.Setting.Apps
{
    internal class EyeGaze : SettingBase
    {
        private const string AppKey = @"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\gazeInput";
        private const string DesiredValue = "Deny";

        public override string ID()
        {
            return "Disable app access to eye tracking";
        }

        public override string Info()
        {
            return "Disable app access to eye-gaze-based interaction";
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.StringEquals(AppKey, "Value", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(AppKey, "Value", DesiredValue, RegistryValueKind.String);
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
                Registry.SetValue(AppKey, "Value", "Allow", RegistryValueKind.String);
                return true;
            }
            catch
            { }

            return false;
        }
    }
}