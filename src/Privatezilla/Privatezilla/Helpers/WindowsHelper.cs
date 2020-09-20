using Microsoft.Win32; 

namespace Privatezilla
{
    internal static class WindowsHelper
    {
        internal static string GetOS()
        {
     
            string releaseID = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", "").ToString();
            return releaseID;

        }

    }
}
