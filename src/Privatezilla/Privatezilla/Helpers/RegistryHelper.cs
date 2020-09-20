using Microsoft.Win32;
using Privatezilla.Setting;
using System;
using System.Windows.Forms;

namespace Privatezilla
{
    /// <summary>
    /// Check whether Registry values equal
    /// </summary>
    internal class RegistryHelper
    {
        public SettingBase Setting { get; }

        public static bool IntEquals(string keyName, string valueName, int expectedValue)
        {
            try
            {
                var value = Registry.GetValue(keyName, valueName, null);
                return (value != null && (int)value == expectedValue);
            }
            catch (Exception ex)

            {
                MessageBox.Show(keyName, ex.Message, MessageBoxButtons.OK);
                return false;
            }
        }

        public static bool StringEquals(string keyName, string valueName, string expectedValue)
        {
            try
            {
                var value = Registry.GetValue(keyName, valueName, null);
                return (value != null && (string)value == expectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(keyName, ex.Message, MessageBoxButtons.OK);
                return false;
            }
        }
    }
}