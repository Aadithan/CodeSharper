// -------------------------------------------------------------------------------------------------------------------------
// Extended styles for the default ListView control of the Framework Control Library
// This enumeration is part of code that makes the report ListView non-flickering.
// Solution provided by Brian Gillespie as posted by Jonas in stackoverflow
// http://stackoverflow.com/questions/87795/how-to-prevent-flickering-in-listview-when-updating-a-single-listviewitems-text
// Based on Giovanni Montrone's article on http://www.codeproject.com/KB/list/listviewxp.aspx
// Important: Code is modified by Aadithan to suit coding standard and other requirements for the project
//            in which this code is being used.
// -------------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CodeSharper.UI.ListViewExtensions
{
    /// <summary>
    /// Contains helper methods to change extended styles on ListView, including enabling double buffering.
    /// </summary>
    public class ListViewHelper
    {
        private ListViewHelper()
        {
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr handle, int messg, int wparam, int lparam);

        public static void SetExtendedStyle(Control control, ListViewExtendedStyles exStyle)
        {
            var styles = (ListViewExtendedStyles)SendMessage(control.Handle, (int)ListViewMessages.GetExtendedStyle, 0, 0);
            styles |= exStyle;
            SendMessage(control.Handle, (int)ListViewMessages.SetExtendedStyle, 0, (int)styles);
        }

        public static void EnableDoubleBuffer(Control control)
        {
            // read current style
            var styles = (ListViewExtendedStyles)SendMessage(control.Handle, (int)ListViewMessages.GetExtendedStyle, 0, 0);
            // enable double buffer and border select
            styles |= ListViewExtendedStyles.DoubleBuffer | ListViewExtendedStyles.BorderSelect;
            // write new style
            SendMessage(control.Handle, (int)ListViewMessages.SetExtendedStyle, 0, (int)styles);
        }
        public static void DisableDoubleBuffer(Control control)
        {
            // read current style
            var styles = (ListViewExtendedStyles)SendMessage(control.Handle, (int)ListViewMessages.GetExtendedStyle, 0, 0);
            // disable double buffer and border select
            styles -= styles & ListViewExtendedStyles.DoubleBuffer;
            styles -= styles & ListViewExtendedStyles.BorderSelect;
            // write new style
            SendMessage(control.Handle, (int)ListViewMessages.SetExtendedStyle, 0, (int)styles);
        }
    }
}
