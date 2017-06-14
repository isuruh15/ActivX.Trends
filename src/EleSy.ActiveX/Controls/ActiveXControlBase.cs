using EleSy.ActiveX.Interop;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DISPPARAMS = System.Runtime.InteropServices.ComTypes.DISPPARAMS;
using EXCEPINFO = System.Runtime.InteropServices.ComTypes.EXCEPINFO;

namespace EleSy.ActiveX.Controls
{
    //[ComVisible(true)]
    //[ProgId("")]
    //[Guid()]
    //[ClassInterface(ClassInterfaceType.None)]
    //[ComDefaultInterface(typeof(IActiveXControl))]
    //[ComSourceInterfaces(typeof(IActiveXEvent))]

    public partial class ActiveXControlBase : UserControl, IActiveXControl
    {
        public event Action OnActivate;
        public event Action OnDeactivate;
        public event Action<ErrorType, string> OnError;

        protected bool IsActive;
        protected bool IsStarted;
        protected bool IsPaused;
        protected bool IsRuntime;
        protected bool IsError;

        //private EventHandler _loadPropertiesFormDelegate;

        private IDispatch _site;

        protected ActiveXControlBase()
        {
            SyncRoot = new object();

            InitializeComponent();

            IsActive = false;
            IsStarted = false;
            IsRuntime = false;
            IsPaused = false;
        }

        public object SyncRoot { get; set; }


        #region ComReg

        [ComRegisterFunction]
        public static void RegisterClass(string key)
        {
            var trimedkey = TrimRegKey(key);
            RegistryKey k = null;
            try
            {
                // Открываем ключ CLSID\{guid} в режиме записи
                k = Registry.ClassesRoot.OpenSubKey(trimedkey, true);
                if (k == null)
                {
                    MessageBox.Show(@"Error HKEY_CLASSES_ROOT\CLSID\" + key);
                    return;
                }

                // Создаем ключ элемента управления ActiveX – это позволяет ему появиться
                //в контейнере элемента управления ActiveX
                RegistryKey ctrl = k.CreateSubKey("Control");
                ctrl.Close();

                RegistryKey insertb = k.CreateSubKey("Insertable");
                insertb.Close();

                // Создаем запись CodeBase
                RegistryKey inprocServer32 = k.OpenSubKey("InprocServer32", true);
                inprocServer32.SetValue("CodeBase", Assembly.GetExecutingAssembly().CodeBase);
                inprocServer32.Close();

                MessageBox.Show(key + "\r\n Reg OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(key + "\r\nUnReg Error\r\n" + ex);
                throw;
            }
            finally
            {
                if (k != null) k.Close();
            }
        }

        [ComVisible(false)]
        private static string TrimRegKey(string key)
        {
            // Удаляем HKEY_CLASSES_ROOT\ из переданного ключа
            return key.Replace(@"HKEY_CLASSES_ROOT\", "");
        }

        [ComUnregisterFunction]
        public static void UnregisterClass(string key)
        {
            var trimedkey = TrimRegKey(key);

            RegistryKey k = null;
            try
            {
                // Открываем ключ HKCR\CLSID\{guid} в режиме записи
                k = Registry.ClassesRoot.OpenSubKey(trimedkey, true);

                if (k == null)
                {
                    MessageBox.Show(@"Error HKEY_CLASSES_ROOT\CLSID\" + key);
                    return;
                }

                k.DeleteSubKey("Control", false);
                k.DeleteSubKey("Insertable", false);
                // Затем открываем ключ InprocServer32
                RegistryKey inprocServer32 = k.OpenSubKey("InprocServer32", true);

                // Удаляем ключ CodeBase
                k.DeleteSubKey("CodeBase", false);
                inprocServer32.Close();

                MessageBox.Show(key + "\r\nUnReg OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(key + "\r\nUnReg Error\r\n" + ex);
                throw;
            }
            finally
            {
                if (k != null) k.Close();
            }
        }

        #endregion


        #region IActiveX

        public bool AutoActivate { get; set; }

        public bool AutoRunTime { set; get; }

        protected virtual void OnControlSuspendUpdate()
        {
            throw new NotImplementedException();
        }

        public void SuspendUpdate()
        {
            try
            {
                if (IsStarted)
                {
                    lock (SyncRoot)
                    {
                        if (IsStarted)
                        {
                            if (IsPaused)
                                return;
                            SuspendLayout();
                            OnControlSuspendUpdate();
                            IsPaused = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                IsError = true;
                var handler = OnError;
                if (handler != null) handler.Invoke(ErrorType.SuspendUpdateError, e.ToString());
            }
        }

        protected virtual void OnControlResumeUpdate()
        {
            throw new NotImplementedException();
        }

        public void ResumeUpdate()
        {
            try
            {
                if (IsStarted)
                {
                    lock (SyncRoot)
                    {
                        if (IsStarted)
                        {
                            if (!IsPaused)
                                return;
                            OnControlResumeUpdate();
                            ResumeLayout(false);
                            IsPaused = false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                IsError = true;
                var handler = OnError;
                if (handler != null) handler.Invoke(ErrorType.ResumeUpdateError, e.ToString());
            }
        }

        protected virtual void OnControlStopRunTime()
        {
            throw new NotImplementedException();
        }

        public void StopRunTime()
        {
            try
            {
                if (IsStarted)
                {
                    lock (SyncRoot)
                    {
                        if (IsStarted)
                        {
                            OnControlStopRunTime();
                            IsStarted = false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.ToString(), "StartRunTime");
                IsError = true;
                var handler = OnError;
                if (handler != null) handler.Invoke(ErrorType.StopRunTimeError, e.ToString());
                throw;
            }
        }

        protected virtual void OnControlStartRunTime()
        {
            throw new NotImplementedException();
        }

        public void StartRunTime()
        {
            try
            {
                if (!IsStarted)
                {
                    lock (SyncRoot)
                    {
                        if (!IsStarted)
                        {
                            OnControlStartRunTime();
                            IsStarted = true;
                            IsPaused = false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.ToString(), "StartRunTime");
                IsError = true;
                var handler = OnError;
                if (handler != null) handler.Invoke(ErrorType.StartRunTimeError, e.ToString());
                throw;
            }
        }

        protected virtual void OnControlActivate()
        {
            throw new NotImplementedException();
        }

        public void Activate()
        {
            try
            {
                if (!IsActive)
                {
                    lock (SyncRoot)
                    {
                        if (!IsActive)
                        {
                            SuspendLayout();

                            OnControlActivate();

                            ResumeLayout(false);
                            IsActive = true;
                            var handler = OnActivate;
                            if (handler != null) handler.Invoke();
                            if (AutoRunTime)
                                StartRunTime();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.ToString(), "Activate");

                IsError = true;
                var handler = OnError;
                if (handler != null) handler.Invoke(ErrorType.ActivateError, e.ToString());
                throw;
            }
        }

        protected virtual void OnControlDeactivate()
        {
            throw new NotImplementedException();
        }

        public void Deactivate()
        {
            try
            {
                if (IsActive)
                {
                    lock (SyncRoot)
                    {
                        if (IsActive)
                        {
                            StopRunTime();
                            SuspendLayout();

                            OnControlDeactivate();

                            Invalidate();
                            ResumeLayout(false);
                            IsActive = false;
                            var handler = OnDeactivate;
                            if (handler != null) handler.Invoke();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.ToString(), "Activate");
                IsError = true;
                var handler = OnError;
                if (handler != null) handler.Invoke(ErrorType.DeactivateError, e.ToString());
                throw;
            }
        }

        public bool Status { get; set; }
        public bool VisionX { get; set; }
        public bool VisionY { get; set; }
        public bool VisionTitleX { get; set; }
        public bool VisionTitleY { get; set; }

        #endregion

        private bool ReflectUserMode()
        {
            Guid id = Guid.Empty;
            var prm = new DISPPARAMS();
            uint lcid = 0;
            ushort wFlags = 2;
            dynamic result;
            var ei = new EXCEPINFO();
            _site.Invoke(ActiveXConstants.DISPID_AMBIENT_USERMODE, ref id, lcid, wFlags, ref prm, out result, ref ei, null);
            return result;
        }

        private void CheckUserModeChanged(object sender, EventArgs e)
        {
            if (_site == null || IsError)
                return;

            try
            {
                IsRuntime = ReflectUserMode();

                if (IsRuntime)
                {
                    if (AutoActivate)
                        Activate();

                    if (AutoRunTime)
                        StartRunTime();
                }
                else
                {
                    StopRunTime();
                    Deactivate();
                }
            }
            catch
            {
            }
        }

        private static IDispatch GetClientSiteDispatch(Control control)
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

        private void Control_VisibleChanged(object sender, EventArgs e)
        {
            _site = GetClientSiteDispatch(this);
            if (_site != null && !_timer.Enabled)
                _timer.Start();
        }
    }
}
