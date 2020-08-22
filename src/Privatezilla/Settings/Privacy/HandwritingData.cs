using Microsoft.Win32;

namespace Privatezilla.Setting.Privacy
{
    internal class HandwritingData : SettingBase
    {
        private const string AllowInputPersonalization = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\InputPersonalization";
        private const string RestrictImplicitInkCollection = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\InputPersonalization";
        private const string RestrictImplicitTextCollection = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\InputPersonalization";
        private const string PreventHandwritingErrorReports = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\HandwritingErrorReports";
        private const string PreventHandwritingDataSharing = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\TabletPC";
        private const int DesiredValue = 1;

        public override string ID()
        {
            return "Prevent using handwriting data";
        }

        public override string Info()
        {
            return "If you don’t want Windows to know and record all unique words that you use, like names and professional jargon, just enable this setting.";
        }

        public override bool CheckSetting()
        {
            return !(
                 RegistryHelper.IntEquals(AllowInputPersonalization, "AllowInputPersonalization", 0) &&
                 RegistryHelper.IntEquals(RestrictImplicitInkCollection, "RestrictImplicitInkCollection", DesiredValue) &&
                 RegistryHelper.IntEquals(RestrictImplicitTextCollection, "RestrictImplicitTextCollection", DesiredValue) &&
                 RegistryHelper.IntEquals(PreventHandwritingErrorReports, "PreventHandwritingErrorReports", DesiredValue) &&
                 RegistryHelper.IntEquals(PreventHandwritingDataSharing, "PreventHandwritingDataSharing", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(AllowInputPersonalization, "AllowInputPersonalization", 0, RegistryValueKind.DWord);
                Registry.SetValue(RestrictImplicitInkCollection, "RestrictImplicitInkCollection", DesiredValue, RegistryValueKind.DWord);
                Registry.SetValue(RestrictImplicitTextCollection, "RestrictImplicitTextCollection", DesiredValue, RegistryValueKind.DWord);
                Registry.SetValue(PreventHandwritingErrorReports, "PreventHandwritingErrorReports", DesiredValue, RegistryValueKind.DWord);
                Registry.SetValue(PreventHandwritingDataSharing, "PreventHandwritingDataSharing", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(AllowInputPersonalization, "AllowInputPersonalization", 1, RegistryValueKind.DWord);
                Registry.SetValue(RestrictImplicitInkCollection, "RestrictImplicitInkCollection", 0, RegistryValueKind.DWord);
                Registry.SetValue(RestrictImplicitTextCollection, "RestrictImplicitTextCollection", 0, RegistryValueKind.DWord);
                Registry.SetValue(PreventHandwritingErrorReports, "PreventHandwritingErrorReports", 0, RegistryValueKind.DWord);
                Registry.SetValue(PreventHandwritingDataSharing, "PreventHandwritingDataSharing", 0, RegistryValueKind.DWord); ;
                return true;
            }
            catch
            { }

            return false;
        }


    }
}