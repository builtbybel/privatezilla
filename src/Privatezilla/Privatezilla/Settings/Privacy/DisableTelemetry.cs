using Microsoft.Win32;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableTelemetry : SettingBase
    {
        private const string TelemetryKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\DataCollection";
        private const string DiagTrack = @"HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Services\DiagTrack";
        private const string dmwappushservice = @"HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Services\dmwappushservice";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Properties.Resources.settingsPrivacyDisableTelemetry;
        }

        public override string Info()
        {
            return Properties.Resources.settingsPrivacyDisableTelemetryInfo.Replace("\\n", "\n");
        }

        public override bool CheckSetting()
        {
            return !(
                 RegistryHelper.IntEquals(TelemetryKey, "AllowTelemetry", DesiredValue) &&
                 RegistryHelper.IntEquals(DiagTrack, "Start", 4) &&
                 RegistryHelper.IntEquals(dmwappushservice, "Start", 4)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(TelemetryKey, "AllowTelemetry", DesiredValue, RegistryValueKind.DWord);
                Registry.SetValue(DiagTrack, "Start", 4, RegistryValueKind.DWord);
                Registry.SetValue(dmwappushservice, "Start", 4, RegistryValueKind.DWord);
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
                Registry.SetValue(TelemetryKey, "AllowTelemetry", 3, RegistryValueKind.DWord);
                Registry.SetValue(DiagTrack, "Start", 2, RegistryValueKind.DWord);
                Registry.SetValue(dmwappushservice, "Start", 2, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}