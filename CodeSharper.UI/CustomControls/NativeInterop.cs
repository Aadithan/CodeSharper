
using System;
using System.Runtime.InteropServices;

namespace CodeSharper.UI.CustomControls
{
   
    /// <summary>
    /// Class that contains native methods and properties for interoperability
    /// </summary>
    public class NativeInterop
    {
        public const int WM_PRINTCLIENT = 0x0318;
        public const int PRF_CLIENT = 0x00000004;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public static bool IsWinXp
        {
            get
            {
                OperatingSystem os = Environment.OSVersion;
                return (os.Platform == PlatformID.Win32NT) &&
                    ((os.Version.Major > 5) || ((os.Version.Major == 5) && (os.Version.Minor == 1)));
            }
        }

        public static bool IsWinVista
        {
            get
            {
                OperatingSystem os = Environment.OSVersion;
                return (os.Platform == PlatformID.Win32NT) && (os.Version.Major >= 6);
            }
        }
    }
}
