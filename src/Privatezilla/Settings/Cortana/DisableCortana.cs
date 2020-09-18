using Microsoft.Win32;

namespace Privatezilla.Setting.Cortana
{
    internal class DisableCortana : SettingBase
    {
        private const string CortanaKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\Windows Search";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Properties.Resources.settingsCortanaDisableCortana;
        }

        public override string Info()
        {
            return Properties.Resources.settingsCortanaDisableCortanaInfo.Replace("\\n", "\n");
        }

        public override bool CheckSetting()
        {
            return !(
                    RegistryHelper.IntEquals(CortanaKey, "AllowCortana", DesiredValue)
                );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(CortanaKey, "AllowCortana", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(CortanaKey, "AllowCortana", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}