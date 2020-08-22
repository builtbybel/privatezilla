using Microsoft.Win32;

namespace Privatezilla.Setting.Security
{
    internal class DisablePassword : SettingBase
    {
        private const string PasswordKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\CredUI";
        private const int DesiredValue = 1;

        public override string ID()
        {
            return "Disable password reveal button";
        }

        public override string Info()
        {
            return "The password reveal button can be used to display an entered password and should be disabled with this setting.";
        }

        public override bool CheckSetting()
        {
            return !(
             RegistryHelper.IntEquals(PasswordKey, "DisablePasswordReveal", DesiredValue)
             );

        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(PasswordKey, "DisablePasswordReveal", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(PasswordKey, "DisablePasswordReveal", 0, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}