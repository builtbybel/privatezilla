using Microsoft.Win32;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableBiometrics : SettingBase
    {
        private const string BiometricsKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Biometrics";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return "Disable Windows Hello Biometrics";
        }

        public override string Info()
        {
            return "Windows Hello biometrics lets you sign in to your devices, apps, online services, and networks using your face, iris, or fingerprint";
        }

        public override bool CheckSetting()
        {
            return !(
                RegistryHelper.IntEquals(BiometricsKey, "Enabled", DesiredValue)
              );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(BiometricsKey, "Enabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(BiometricsKey, "Enabled", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }


    }
}