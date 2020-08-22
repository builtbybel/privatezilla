using Microsoft.Win32;

namespace Privatezilla.Setting.Edge
{
    internal class DisableAutoFillCredits : SettingBase
    {
        private const string EdgeKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return "Disable AutoFill for credit cards";
        }

        public override string Info()
        {
            return "Microsoft Edge's AutoFill feature lets users auto complete credit card information in web forms using previously stored information.";
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(EdgeKey, "AutofillCreditCardEnabled", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(EdgeKey, "AutofillCreditCardEnabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(EdgeKey, "AutofillCreditCardEnabled", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}