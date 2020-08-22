using Microsoft.Win32;

namespace Privatezilla.Setting.Privacy
{
    internal class InventoryCollector : SettingBase
    {
        private const string InventoryKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\AppCompat";
        private const string AppTelemetryKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\AppCompat";
        private const int DesiredValue = 1;

        public override string ID()
        {
            return "Disable Inventory Collector";
        }

        public override string Info()
        {
            return "The Inventory Collector inventories applications files devices and drivers on the system and sends the information to Microsoft. This information is used to help diagnose compatibility problems.\nNote: This setting setting has no effect if the Customer Experience Improvement Program is turned off. The Inventory Collector will be off.";
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(InventoryKey, "DisableInventory", DesiredValue) &&
               RegistryHelper.IntEquals(AppTelemetryKey, "AITEnable", 0)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(InventoryKey, "DisableInventory", DesiredValue, RegistryValueKind.DWord);
                Registry.SetValue(AppTelemetryKey, "AITEnable", 0, RegistryValueKind.DWord);
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
                Registry.SetValue(InventoryKey, "DisableInventory", 0, RegistryValueKind.DWord);
                Registry.SetValue(AppTelemetryKey, "AITEnable", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}