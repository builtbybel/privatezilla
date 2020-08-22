﻿using Microsoft.Win32;

namespace Privatezilla.Setting.Apps
{
    internal class Email : SettingBase
    {
        private const string AppKey = @"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\email";
        private const string DesiredValue ="Deny";

        public override string ID()
        {
            return "Disable app access to email";
        }

        public override string Info()
        {
            return "";
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.StringEquals(AppKey, "Value", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(AppKey, "Value", DesiredValue, RegistryValueKind.String);
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
                Registry.SetValue(AppKey, "Value", "Allow", RegistryValueKind.String);
                return true;
            }
            catch
            { }

            return false;
        }
    }
}