using Microsoft.Win32;

namespace Privatezilla.Setting.Cortana
{
    internal class DisableBing : SettingBase
    {
        private const string BingKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\Windows Search";
        private const string Bing2004Key = @"HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\Explorer"; // Disable Websearch on Windows 10, version >=2004
        private const int DesiredValue = 0;

        public override string ID()
        {
            return "Disable Bing in Windows Search";
        }

        public override string Info()
        {
            return "Windows 10, by default, sends everything you search for in the Start Menu to their servers to give you results from Bing search.";
        }

        public override bool CheckSetting()

        {
            string releaseid = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", "").ToString();

            if (releaseid != "2004")
               return !(RegistryHelper.IntEquals(BingKey, "BingSearchEnabled", DesiredValue));

            else
                return !(RegistryHelper.IntEquals(Bing2004Key, "DisableSearchBoxSuggestions", 1));

        }


        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(BingKey, "BingSearchEnabled", DesiredValue, RegistryValueKind.DWord);
                Registry.SetValue(Bing2004Key, "DisableSearchBoxSuggestions", 1, RegistryValueKind.DWord);
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
                Registry.SetValue(BingKey, "BingSearchEnabled", 1, RegistryValueKind.DWord);
                Registry.SetValue(Bing2004Key, "DisableSearchBoxSuggestions", 0, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}