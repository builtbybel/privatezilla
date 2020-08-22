using Microsoft.Win32;

namespace Privatezilla.Setting.Apps
{
    internal class CellularData : SettingBase
    {
        private const string AppKey = @"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\cellularData";
        private const string DesiredValue = "Deny";

        public override string ID()
        {
            return "Disable app access to cellular data";
        }

        public override string Info()
        {
            return "Some Windows 10 devices have a SIM card and/or eSIM in them that lets you connect to a cellular data network (aka: LTE or Broadband), so you can get online in more places by using a cellular signal.\nIf you do not want any apps to be allowed to use cellular data, you can disable it with this setting.";
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