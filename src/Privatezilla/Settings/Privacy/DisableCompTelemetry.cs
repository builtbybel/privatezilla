using Microsoft.Win32;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableCompTelemetry : SettingBase
    {
        private const string TelemetryKey = @"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\CompatTelRunner.exe";
        private const string DesiredValue = @"%windir%\System32\taskkill.exe";

        public override string ID()
        {
            return "Disable Compatibility Telemetry";
        }

        public override string Info()
        {
            return "This process is periodically collecting a variety of technical data about your computer and its performance and sending it to Microsoft for its Windows Customer Experience Improvement Program.";
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