using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using CodeSharper.UI.Analyzer;

//using EnvDTE;

namespace CodeSharper.UI
{
    public class VsHelper
    {
        internal static void LaunchSourceFile(IWin32Window owner, string fileAndDirectory, string line)
        {
            if (!System.IO.File.Exists(fileAndDirectory))
            {
                UiHelper.ShowErrorMessageBoxOnOwner(owner, String.Concat(ApplicationConstants.CouldNotLocateFileMessage, fileAndDirectory), ApplicationConstants.ErrorMessageTitle);
            }
            else
            {
                try
                {
                    LaunchInVisualStudio(fileAndDirectory, line);
                }
                catch (COMException)
                {
                    UiHelper.ShowErrorMessageBoxOnOwner(owner, ApplicationConstants.CouldNotLaunchVisualStudioMessage, ApplicationConstants.ErrorMessageTitle);
                    //Todo: Add other editor options to open the file and line in an alternative editor.
                }
            }
        }

        private static void LaunchInVisualStudio(string fileAndDirectory, string line)
        {
            try
            {
                object activeObject = Marshal.GetActiveObject("VisualStudio.DTE");
                LaunchInVisualStudio(activeObject, fileAndDirectory, line);
            }
            catch (COMException)
            {
                var typeFromProgId = Type.GetTypeFromProgID("VisualStudio.DTE");
                if (typeFromProgId == null)
                {
                    throw;
                }
                object o = Activator.CreateInstance(typeFromProgId);
                Marshal.GetIUnknownForObject(o);
                LaunchInVisualStudio(o, fileAndDirectory, line);
            }
        }

        private static void LaunchInVisualStudio(object dte, string fileAndDirectory, string line)
        {
            LateCall(dte, "ExecuteCommand", new object[] { "File.OpenFile", "\"" + fileAndDirectory + "\"" });
            LateCall(dte, "ExecuteCommand", new object[] { "Edit.Goto", line });
            BringVsForward(dte);
        }

        private static void BringVsForward(object dte)
        {
            object obj2 = LateGet(dte, "MainWindow");
            var hWnd = (IntPtr)((int)LateGet(obj2, "HWnd"));
            if (NativeMethods.IsIconic(hWnd))
            {
                NativeMethods.ShowWindowAsync(hWnd, 9);
            }
            NativeMethods.SetForegroundWindow(hWnd);
            Thread.Sleep(0x3e8);
            LateCall(obj2, "Activate", new object[0]);
            LateSet(obj2, "Visible", true);
        }

        private static void LateCall(object obj, string method, params object[] args)
        {
            LateInvoke(obj, BindingFlags.InvokeMethod, method, args);
        }

        private static object LateGet(object obj, string property)
        {
            return LateInvoke(obj, BindingFlags.GetProperty, property, new object[0]);
        }

        private static object LateInvoke(object obj, BindingFlags flags, string method, params object[] args)
        {
            object obj2;
            try
            {
                obj2 = obj.GetType().InvokeMember(method, flags, null, obj, args, CultureInfo.InvariantCulture);
            }
            catch (TargetInvocationException exception)
            {
                throw exception.InnerException;
            }
            return obj2;
        }

        private static void LateSet(object obj, string property, object value)
        {
            LateInvoke(obj, BindingFlags.SetProperty, property, new object[] { value });
        }
    }
}
