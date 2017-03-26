
using System;
using System.Windows.Forms;

namespace CodeSharper.UI.CustomControls
{
    /// <summary>
    /// Non-flickering ListView control
    /// </summary>
    public class NfListView : ListView
    {
        public NfListView()
        {
            // Enable internal ListView double-buffering
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            // Disable default CommCtrl painting on non-XP systems
            if (!NativeInterop.IsWinXp)
                SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint))
            {
                var m = new Message
                            {
                                HWnd = Handle,
                                Msg = NativeInterop.WM_PRINTCLIENT,
                                WParam = e.Graphics.GetHdc(),
                                LParam = (IntPtr) NativeInterop.PRF_CLIENT
                            };
                DefWndProc(ref m);
                e.Graphics.ReleaseHdc(m.WParam);
            }
            base.OnPaint(e);
        }
    }
}
