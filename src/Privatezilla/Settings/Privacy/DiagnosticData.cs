using Microsoft.Win32;

namespace Privatezilla.Setting.Privacy
{
    internal class DiagnosticData : SettingBase
    {
        private const string DiagnosticKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Privacy";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return "Prevent using diagnostic data";
        }

        public override string Info()
        {
            return "This will turn off tailored experiences with relevant tips and recommendations by using your diagnostics data. Many people would call this telemetry, or even spying.";
        }

        public override bool CheckSetting()
        {
            return !(
        RegistryHelper.IntEquals(DiagnosticKey, "TailoredExperiencesWithDiagnosticDataEnabled", DesiredValue)
             );

        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(DiagnosticKey, "TailoredExperiencesWithDiagnosticDataEnabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(DiagnosticKey, "TailoredExperiencesWithDiagnosticDataEnabled", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}