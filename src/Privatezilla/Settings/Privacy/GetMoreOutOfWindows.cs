using Microsoft.Win32;

namespace Privatezilla.Setting.Privacy
{
    internal class GetMoreOutOfWindows: SettingBase
    {
        private const string GetKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\UserProfileEngagement";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return "Disable Get Even More Out of Windows";
        }

        public override string Info()
        {
            return "Recent Windows 10 versions occasionally display a nag screen \"Get Even More Out of Windows\" when you sign-in to your user account. If you find it annoying, you can disable it with this setting.";
        }

        public override bool CheckSetting()
        {
            return !(
            RegistryHelper.IntEquals(GetKey, "ScoobeSystemSettingEnabled", DesiredValue)

            );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(GetKey, "ScoobeSystemSettingEnabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(GetKey, "ScoobeSystemSettingEnabled", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}