using Microsoft.Win32;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableCEIP : SettingBase
    {
        private const string CEIPKey = @"HKEY_LOCAL_MACHINE\Software\Microsoft\SQMClient\Windows";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return "Disable Customer Experience Program";
        }

        public override string Info()
        {
            return "The Customer Experience Improvement Program (CEIP) is a feature that comes enabled by default on Windows 10, and it secretly collects and submits hardware and software usage information to Microsoft.";
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(CEIPKey, "CEIPEnable", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(CEIPKey, "CEIPEnable", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(CEIPKey, "CEIPEnable", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}