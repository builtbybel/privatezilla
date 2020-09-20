using Microsoft.Win32;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableCompTelemetry : SettingBase
    {
        private const string TelemetryKey = @"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\CompatTelRunner.exe";
        private const string DesiredValue = @"%windir%\System32\taskkill.exe";

        public override string ID()
        {
            return Properties.Resources.settingsPrivacyDisableCompTelemetry;
        }

        public override string Info()
        {
            return Properties.Resources.settingsPrivacyDisableCompTelemetryInfo;
        }

        public override bool CheckSetting()
        {
            return !(
           RegistryHelper.StringEquals(TelemetryKey, "Debugger", DesiredValue)
            );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(TelemetryKey, "Debugger", DesiredValue, RegistryValueKind.String);
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
               
                var RegKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\CompatTelRunner.exe", true);
                RegKey.DeleteValue("Debugger");

                return true;
            }
            catch
            { }

            return false;

        }

    }
}