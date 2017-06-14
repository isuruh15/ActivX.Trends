using EleSy.ActiveX.Interop;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EleSy.ActiveX.Extensions
{
    public static class ControlEx
    {
        public static IDispatch GetClientSiteDispatch(this Control control)
        {
            var memberInfo = typeof(Control);
            var interfaces = memberInfo.GetInterfaces();
            var oleobj = interfaces.FirstOrDefault(t => t.GUID == ActiveXConstants.IID_IOleObject);
            if (oleobj == null)
                return null;

            var method = oleobj.GetMethod("GetClientSite");
            dynamic site = method.Invoke(control, null);
            return (IDispatch)site;
        }

        public static void RunInUIThread(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action);
                return;
            }
            action.Invoke();
        }

        public static void RunInUIThread(this Control control, Delegate action, params object[] args)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action, args);
                return;
            }
            action.DynamicInvoke(args);
        }

        public static void RunInUIInvoke(this Control control, Action code)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(code);
                return;
            }
            code.Invoke();
        }

        public static void RunInUIInvoke(this Control control, Delegate action, params object[] args)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action, args);
                return;
            }
            action.DynamicInvoke(args);
        }

        public static void RunInUIThread<T>(this Control control, Action<T> action, T param)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action, param);
                return;
            }
            action.Invoke(param);
        }

        public static void RunInUIThread<T1, T2>(this Control control, Action<T1, T2> action, T1 param1, T2 param2)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action, param1, param2);
                return;
            }
            action.Invoke(param1, param2);
        }
        public static void RunInUIThread<T1, T2, T3>(this Control control, Action<T1, T2, T3> action, T1 param1, T2 param2, T3 param3)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action, param1, param2, param3);
                return;
            }
            action.Invoke(param1, param2, param3);
        }
    }
}
