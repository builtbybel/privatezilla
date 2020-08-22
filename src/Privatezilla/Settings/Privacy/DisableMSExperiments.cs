using Microsoft.Win32;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableMSExperiments: SettingBase
    {
        private const string ExperimentationKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PolicyManager\current\device\System";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return "Disable Settings Experimentation";
  
        }

        public override string Info()
        {
            return "In certain builds of Windows 10, users could let Microsoft experiment with the system to study user preferences or device behavior. This allows Microsoft to “conduct experiments” with the settings on your PC and should be disabled with this setting.";
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(ExperimentationKey, "AllowExperimentation", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(ExperimentationKey, "AllowExperimentation", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(ExperimentationKey, "AllowExperimentation", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}