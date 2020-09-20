using Microsoft.Win32;

namespace Privatezilla.Setting.Updates
{
    internal class DisableUpdates : SettingBase
    {
        private const string NoAutoUpdate = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\WindowsUpdate\AU";
        private const string AUOptions = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\WindowsUpdate\AU";
        private const string ScheduledInstallDay = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\WindowsUpdate\AU";
        private const string ScheduledInstallTime = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\WindowsUpdate\AU";

        public override string ID()
        {
            return Properties.Resources.settingsUpdatesDisableUpdates;
        }

        public override string Info()
        {
            return Properties.Resources.settingsUpdatesDisableUpdatesInfo;
        }

        public override bool CheckSetting()
        {
            return !(
                    RegistryHelper.IntEquals(NoAutoUpdate, "NoAutoUpdate",0) &&
                    RegistryHelper.IntEquals(AUOptions, "AUOptions", 2) &&
                    RegistryHelper.IntEquals(ScheduledInstallDay, "ScheduledInstallDay", 0) &&
                    RegistryHelper.IntEquals(ScheduledInstallTime, "ScheduledInstallTime", 3)
                );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(NoAutoUpdate, "NoAutoUpdate", 0, RegistryValueKind.DWord);
                Registry.SetValue(AUOptions, "AUOptions", 2, RegistryValueKind.DWord);
                Registry.SetValue(ScheduledInstallDay, "ScheduledInstallDay", 0, RegistryValueKind.DWord);
                Registry.SetValue(ScheduledInstallTime, "ScheduledInstallTime", 3, RegistryValueKind.DWord);
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
                Registry.SetValue(NoAutoUpdate, "NoAutoUpdate", 1, RegistryValueKind.DWord);

                var RegKey = Registry.LocalMachine.OpenSubKey(@"Software\Policies\Microsoft\Windows\WindowsUpdate\AU", true);
                RegKey.DeleteValue("AUOptions");
                RegKey.DeleteValue("ScheduledInstallDay");
                RegKey.DeleteValue("ScheduledInstallTime");

                return true;
            }
            catch
            {}

            return false;
        }

    }
}