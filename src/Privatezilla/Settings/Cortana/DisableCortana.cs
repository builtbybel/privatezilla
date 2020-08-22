using Microsoft.Win32;

namespace Privatezilla.Setting.Cortana
{
    internal class DisableCortana : SettingBase
    {
        private const string CortanaKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\Windows Search";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return "Disable Cortana";
        }

        public override string Info()
        {
            return "Cortana is Microsoft's virtual assistant that comes integrated into Windows 10.\nThis setting will disable Cortana permanently and prevent it from recording and storing your search habits and history.";
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