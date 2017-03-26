using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CodeSharper.UI
{
    internal static class NativeMethods
    {
        internal const int HDF_BITMAP_ON_RIGHT = 0x1000;
        internal const int HDF_CENTER = 2;
        internal const int HDF_IMAGE = 0x800;
        internal const int HDF_JUSTIFYMASK = 3;
        internal const int HDF_LEFT = 0;
        internal const int HDF_RIGHT = 1;
        internal const int HDF_SORTDOWN = 0x200;
        internal const int HDF_SORTUP = 0x400;
        internal const int HDF_STRING = 0x4000;
        internal const int HDI_BITMAP = 0x10;
        internal const int HDI_DI_SETITEM = 0x40;
        internal const int HDI_FORMAT = 4;
        internal const int HDI_HEIGHT = 1;
        internal const int HDI_IMAGE = 0x20;
        internal const int HDI_LPARAM = 8;
        internal const int HDI_ORDER = 0x80;
        internal const int HDI_TEXT = 2;
        internal const int HDI_WIDTH = 1;
        internal const int HDM_FIRST = 0x1200;
        internal const int HDM_GETIMAGELIST = 0x1209;
        internal const int HDM_GETITEM = 0x120b;
        internal const int HDM_GETORDERARRAY = 0x1211;
        internal const int HDM_SETIMAGELIST = 0x1208;
        internal const int HDM_SETITEM = 0x120c;
        internal const int HDM_SETORDERARRAY = 0x1212;
        internal const int HDN_ENDDRAG = -311;
        internal const int HDN_ENDTRACKW = -327;
        internal const int HDN_ITEMCHANGEDW = -321;
        internal const int LVM_FIRST = 0x1000;
        internal const int LVM_GETHEADER = 0x101f;
        internal const int LVM_GETTOOLTIPS = 0x104e;
        internal const int SW_HIDE = 0;
        internal const int SW_RESTORE = 9;
        internal const int SW_SHOWDEFAULT = 10;
        internal const int SW_SHOWMAXIMIZED = 3;
        internal const int SW_SHOWMINIMIZED = 2;
        internal const int SW_SHOWNOACTIVATE = 4;
        internal const int SW_SHOWNORMAL = 1;
        internal const int TTM_ADDTOOLW = 0x432;
        internal const int WM_ACTIVATEAPP = 0x1c;
        internal const int WM_NOTIFY = 0x4e;

        [return: MarshalAs( UnmanagedType.Bool )]
        [DllImport( "user32.dll" )]
        internal static extern bool IsIconic ( IntPtr hWnd );
        [DllImport( "user32" )]
        internal static extern IntPtr SendMessage ( IntPtr Handle, int msg, IntPtr wParam, ref HDITEM lParam );
        [DllImport( "user32" )]
        internal static extern IntPtr SendMessage ( IntPtr Handle, int msg, IntPtr wParam, ref TOOLINFO lParam );
        [DllImport( "user32" )]
        internal static extern IntPtr SendMessage ( IntPtr Handle, int msg, IntPtr wParam, IntPtr lParam );
        [return: MarshalAs( UnmanagedType.Bool )]
        [DllImport( "user32.dll" )]
        internal static extern bool SetForegroundWindow ( IntPtr hWnd );
        [return: MarshalAs( UnmanagedType.Bool )]
        [DllImport( "user32.dll" )]
        internal static extern bool ShowWindowAsync ( IntPtr hWnd, int nCmdShow );

        [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Auto )]
        internal struct HDITEM
        {
            internal int mask;
            internal int cxy;
            internal IntPtr pszText;
            internal IntPtr hbm;
            internal int cchTextMax;
            internal int fmt;
            internal IntPtr lParam;
            internal int iImage;
            internal int iOrder;
        }

        [StructLayout( LayoutKind.Sequential )]
        internal struct NMHDR
        {
            internal IntPtr hwndFrom;
            internal int idFrom;
            internal int code;
        }

        [StructLayout( LayoutKind.Sequential )]
        internal struct NMHEADER
        {
            internal IntPtr hwndFrom;
            internal int idFrom;
            internal int code;
            internal int iItem;
            internal int iButton;
            internal IntPtr pItem;
        }

        [StructLayout( LayoutKind.Sequential ), SuppressMessage( "Microsoft.Design", "CA1049:TypesThatOwnNativeResourcesShouldBeDisposable" )]
        internal struct TOOLINFO
        {
            internal int cbSize;
            internal uint uFlags;
            [SuppressMessage( "Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources" )]
            internal IntPtr hWnd;
            internal UIntPtr uID;
            internal Rectangle rect;
            internal IntPtr hinst;
            [MarshalAs( UnmanagedType.LPTStr )]
            internal string pszText;
            internal IntPtr lParam;
        }
    }
}
