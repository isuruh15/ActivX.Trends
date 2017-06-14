using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EleSy.ActiveX.Controls;
using System;
using System.Runtime.InteropServices;
using EleSy.CV.ActiveX.Forms;

using EleSy.CV.ActiveX.Model;
using EleSy.CV.ActiveX.Model.OpcClients;
using EleSy.CV.ActiveX.Model.Trends;
using EleSy.CV.ActiveX.Presenters;

using EleSy.CV.ActiveX.Views;

using Opc.Da;
using OxyPlot;

using Server = Opc.Da.Server;
using Timer = System.Windows.Forms.Timer;


namespace EleSy.CV.ActiveX
{
    [ComVisible(true)]
    [ProgId("PLAControl")]
    [Guid("7502B697-B936-48BE-A55D-F5B16B89616B")]
    //old [Guid("6BE084A4-C681-48C2-A592-25F88D41BA61")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof (IEmergensyResponcePlanControl))]
    [ComSourceInterfaces(typeof (IEmergensyResponcePlanControlEvent))]
    public sealed partial class TrendsControl : ActiveXControlBase, IEmergensyResponcePlanControl, ITrendView
    {
        private readonly Dictionary<string, Control> _dictionary = new Dictionary<string, Control>();
        private readonly BackgroundWorker _connectionWorker = new BackgroundWorker();
        private readonly BackgroundWorker _repConnectionWorker = new BackgroundWorker();
        private Server _server;
        private bool _status;
        private readonly Timer _timer1 = new Timer();
        private readonly Timer _timer2 = new Timer();
        private readonly ProgressForm _progressForm = new ProgressForm();
        private bool flag;
        private readonly OpcValueResult distanveEnd = new OpcValueResult();
        private List<string> _listTag;
        private Settings PathTag;
       

       
        public TrendsControl()
        {

            //System.Diagnostics.Debugger.Launch();
            InitializeComponent();

            //var trendPresenter = new TrendPresenter(new TrendsForm(), new TrendsService());
            
            //_trendView =  TrendsControl();
            //var test = new TrendsControl();

            DisplayPanel.Visible = Status;
            //Run();

            _listTag = new List<string>();
            //var lines = System.IO.File.ReadAllLines(PathTag.Path);
            //foreach (string s in lines)
            //{
            //  _listTag.Add(s);
            //}
            
            //Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            

            MineInfoList = new Serializer().DeserializeObject<BindingList<MineInfo>>(MinesInfoXml) ??
                           new BindingList<MineInfo>();
            _timer1.Tick += Timer1OnTick;
            //_timer2.Tick += Timer2OnTick;
            _timer2.Interval = 10000;
            _timer1.Interval = 1000;
            AutoActivate = true;
            VisionX = true;
             VisionY = true;
           VisionTitleX = true;
           VisionTitleY = true;
            _connectionWorker.DoWork += ConnectionWorkerDoWork;
            _connectionWorker.RunWorkerCompleted += ConnectionWorkerRunWorkerCompleted;
            _connectionWorker.WorkerSupportsCancellation = true;
            _repConnectionWorker.DoWork += RepConnectionWorkerDoWork;
            _repConnectionWorker.RunWorkerCompleted += RepConnectionWorkerRunWorkerCompleted;
            _repConnectionWorker.WorkerSupportsCancellation = true;

            Trends.Paint += PaintingDgPla;
            Trends.MouseDown += MouseClickHideTableError;
            Trends.KeyDown += KeyPressHideTableError;
            Trends.EditingControlShowing += EditingControlShowingDgPla;
            
            Trends.Visible = false;
            TrendsView.Visible = false;
            DisplayPanel.Visible = false;
            DisplayPanelWatch.Visible = false;
            OnConnectionDisplayPanelIndicator.Visible = false;
            DisplayPanelCounterDelay.Visible = false;
            OffConnectionDisplayPanelIndicator.Visible = false;
            DisplayPanelTableError.Visible = false;
            DisplayPanelServerError.Visible = false;
            flag = false;
        }


        

        #region Connection Configurator

        private void Timer1OnTick(object sender, EventArgs e)
        {
            DisplayPanelWatch.Text = DateTime.Now.ToShortTimeString();
            DisplayPanelWatch.ForeColor = Color.Black;
            DisplayPanelWatch.Visible = true;
            DisplayPanelWatch.Font = new Font("Segoe UI Symbo", 12F, FontStyle.Regular);
            try
            {
                _server.GetStatus();
                DisplayPanelServerError.Text = string.Empty;
                if (!Trends.Visible)
                {
                    DisplayPanelWatch.Visible = true;
                    Trends.Visible = true;
                    //Toolbar.Visible = true;
                    DisplayPanel.Visible = Status;
                    DisplayPanelServerError.Visible = false;
                    _status = true;
                }
                if (_repConnectionWorker.IsBusy)
                    _repConnectionWorker.CancelAsync();
            }
            catch (Exception)
            {
                CheckTheConnectionStatus();
                _status = false;
                if (Trends.Visible)
                {
                    Trends.Visible = false;
                    //Toolbar.Visible = false;
                    DisplayPanel.Visible = Status;
                    DisplayPanelServerError.Visible = false;
                    DisplayPanelWatch.Visible = false;
                }
            }
            try
            {
                if (_status)
                {
                    //Toolbar.Visible = true;
                    Trends.Visible = true;
                    DisplayPanel.Visible = Status;
                    OffConnectionDisplayPanelIndicator.Visible = false;
                    OnConnectionDisplayPanelIndicator.Visible = true;
                    OnConnectionDisplayPanelIndicator.ForeColor = Color.Black;
                    OnConnectionDisplayPanelIndicator.Font = new Font("Segoe UI Symbo", 12F, FontStyle.Regular);
                    DisplayPanelServerError.Visible = false;
                    DisplayPanelServerError.Text = string.Empty;
                }
                else
                {
                    OffConnectionDisplayPanelIndicator.Visible = true;
                    DisplayPanelServerError.Visible = true;
                    OnConnectionDisplayPanelIndicator.Visible = false;
                    DisplayPanelServerError.Font = new Font("Segoe UI Symbo", 12F, FontStyle.Regular);
                    OffConnectionDisplayPanelIndicator.Font = new Font("Segoe UI Symbo", 12F, FontStyle.Regular);
                    DisplayPanelServerError.Text = @"|  Ошибка соединения: Идет попытка востановления соединения, пожалуйста подождите";
                    DisplayPanel.ForeColor = Color.PaleVioletRed;
                    OffConnectionDisplayPanelIndicator.ForeColor = Color.PaleVioletRed;
                }
            }
            catch (Exception)
            {
                
            }
        }

      
        public void CheckTheConnectionStatus()
        {
            try
            {
                if (!_status)
                {
                    if (_repConnectionWorker.IsBusy)
                        _repConnectionWorker.CancelAsync();
                    DisplayPanelServerError.Visible = true;
                    Trends.Visible = false;
                    DisplayPanel.Visible = Status;
                    if (_server.IsConnected)
                        _server.Disconnect();
                    if (!_repConnectionWorker.IsBusy)
                        _repConnectionWorker.RunWorkerAsync();
                }
                else if (_server.GetStatus().ServerState == serverState.running)
                {
                    //Toolbar.Visible = false;
                    Trends.Visible = false;
                    DisplayPanel.Visible = Status;
                    OffConnectionDisplayPanelIndicator.Visible = false;
                    OnConnectionDisplayPanelIndicator.Visible = false;
                    DisplayPanelServerError.Visible = true;
                    DisplayPanelServerError.Text = string.Format(@"|  Нет соединения с шахтой {0}");
                    DisplayPanelServerError.Font = new Font("Segoe UI Symbo", 12F, FontStyle.Regular);
                    DisplayPanel.ForeColor = Color.PaleVioletRed;                
                }
            }
            catch (Exception)
            {
                //Toolbar.Visible = false;
                Trends.Visible = false;
                DisplayPanel.Visible = Status;
                DisplayPanelServerError.Visible = true;
                OffConnectionDisplayPanelIndicator.Visible = true;
                OnConnectionDisplayPanelIndicator.Visible = false;
                DisplayPanelServerError.Text = @"|  Ошибка соединения: Не удалось установить соединение с OPC-сервером";
                DisplayPanel.ForeColor = Color.PaleVioletRed;
                DisplayPanelServerError.Font = new Font("Segoe UI Symbo", 12F, FontStyle.Regular);
            }
        }

        private void RepConnectionWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs args)
        {
            try
            {
                switch ((Model.ServerStatus.ServerStatusENumSwitch) args.Result)
                {
                    case Model.ServerStatus.ServerStatusENumSwitch.ServerIsConnected:
                        _repConnectionWorker.CancelAsync();
                        _progressForm.Close();
                        _status = true;
                        break;
                    case Model.ServerStatus.ServerStatusENumSwitch.ConnectionFailed:
                        _progressForm.Close();
                        _repConnectionWorker.CancelAsync();
                        break;
                }
            }
            catch
            {
                DisplayPanelServerError.Text = @"|  Ошибка соединения: Произошел сбой при переподключении. Попробуйте переподключиться вручную.";
                DisplayPanel.ForeColor = Color.PaleVioletRed;
                DisplayPanelServerError.Font = new Font("Segoe UI Symbo", 12F, FontStyle.Regular);
            }
        }

        private void RepConnectionWorkerDoWork(object sender, DoWorkEventArgs args)
        {
            if (_server != null)
            {
                if (_repConnectionWorker.CancellationPending)
                    return;
                if (!_status)
                {
                    try
                    {
                        _server.Connect();
                        DisplayPanelServerError.Text = string.Empty;
                        args.Result = Model.ServerStatus.ServerStatusENumSwitch.ServerIsConnected;
                    }
                    catch
                    {
                        _status = false;
                        args.Result = Model.ServerStatus.ServerStatusENumSwitch.ConnectionFailed;
                    }
                }
                else
                {
                    DisplayPanelServerError.Text = string.Empty;
                    args.Result = Model.ServerStatus.ServerStatusENumSwitch.ConnectionFailed;
                }
            }
            else
            {
                args.Result = Model.ServerStatus.ServerStatusENumSwitch.ObjectPathNotExist;
            }
        }

        private void ConnectionWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs args)
        {
            switch ((Model.ServerStatus.ServerStatusENumSwitch) args.Result)
            {
                case Model.ServerStatus.ServerStatusENumSwitch.ServerIsConnected:
                    _connectionWorker.CancelAsync();
                    _status = true;
                    DisplayPanel.Visible = Status;
                    ConstructDgPla();
                    break;
                case Model.ServerStatus.ServerStatusENumSwitch.ConnectionFailed:
                    _status = false;
                    DisplayPanelServerError.Text = @"|  Ошибка соединения: Не удалось подключиться к OPC-сервером";
                    DisplayPanel.ForeColor = Color.PaleVioletRed;
                    DisplayPanelServerError.Font = new Font("Segoe UI Symbo", 12F, FontStyle.Regular);
                    break;
                case Model.ServerStatus.ServerStatusENumSwitch.ObjectPathNotExist:
                    _status = false;
                    DisplayPanelServerError.Text = @"|  Ошибка соединения: Не указаны параметры соединения, либо указаны не верно";
                    DisplayPanel.ForeColor = Color.PaleVioletRed;
                    DisplayPanelServerError.Font = new Font("Segoe UI Symbo", 12F, FontStyle.Regular);
                    break;
            }
        }

        private void ConnectionWorkerDoWork(object sender, DoWorkEventArgs args)
        {
            try
            {
                try
                {
                    OpcServerSingleton.GetInstance(Host, OpcServer);
                }
                catch (Exception)
                {
                }
                _server = OpcServerSingleton.Instance;
            }
            catch (Exception)
            {
                args.Result = Model.ServerStatus.ServerStatusENumSwitch.ObjectPathNotExist;
                return;
            }

            if (_server != null)
            {
                if (_connectionWorker.CancellationPending)
                    return;
                if (!_status)
                {
                    try
                    {
                        _server.Connect();
                    }
                    catch (Exception)
                    {
                    }
                    args.Result = Model.ServerStatus.ServerStatusENumSwitch.ServerIsConnected;
                }
                else
                {
                    args.Result = Model.ServerStatus.ServerStatusENumSwitch.ConnectionFailed;
                }
            }
            else
            {
                args.Result = Model.ServerStatus.ServerStatusENumSwitch.ObjectPathNotExist;
            }
        }

        #endregion

        #region Fields

        public string Host { get; set; }
        public string OpcServer { get; set; }
        public bool CheckBoxSize { get; set; }
        public BindingList<MineInfo> MineInfoList { get; set; }
        public string MinesInfoXml { get; set; }
        public bool Status { get; set; }
        public bool VisionX { get; set; }
        public bool VisionY { get; set; }
        public bool VisionTitleX { get; set; }
        public bool VisionTitleY { get; set; }
       

        #endregion

        #region Construction & Interaction DgPLA

        private void PaintingDgPla(object sender, PaintEventArgs e) //объединение ячеек
        {
            try
            {
                var presenter = new TrendPresenter(this, new TrendsService(Host,OpcServer, VisionX, VisionY, VisionTitleX, VisionTitleY));
                presenter.Run();

            }
            catch
            {
                var presenter = new TrendPresenter(this, new TrendsService(Host, OpcServer, VisionX, VisionY, VisionTitleX, VisionTitleY));
                presenter.Run();
            }
            
        }

       




        public void ConstructDgPla() //загрузка данных в таблицу
        {

            //DeleteColumnsDgPla();
            _dictionary.Clear();
            Trends.Visible = true;
            TrendsView.Visible = true;
            //Toolbar.Visible = true;
            DisplayPanel.Visible = Status;
            
            if (!_status)
            {
                CheckTheConnectionStatus();
            }
        }

     
            public event EventHandler DataChanged;


     

       
        
        private void tablel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #endregion

        #region Management
        protected override void OnControlSuspendUpdate()
        {
            
        }

        protected override void OnControlResumeUpdate()
        {
            
        }

        protected override void OnControlStopRunTime()
        {
            if (_status)
            {
                _server.Disconnect();
                _server.Dispose();
            }
            _status = false;
            _connectionWorker.CancelAsync();
            _repConnectionWorker.CancelAsync();
            _timer1.Stop();
            _timer1.Dispose();
            _timer2.Stop();
            _timer2.Dispose();
            Trends.Visible = false;
            //Toolbar.Visible = false;
            DisplayPanel.Visible = false;
            //DeleteColumnsDgPla();
            _dictionary.Clear();
        }

        protected override void OnControlStartRunTime()
        {
            if (String.IsNullOrEmpty(Host) || String.IsNullOrEmpty(OpcServer))
            {
                //MessageBox.Show(@"Ошибка соединения: Укажите параметры сервера.");
                StopRunTime();
                _status = false;
                _connectionWorker.CancelAsync();
                //_progressForm.Close();
                Trends.Visible = true;
                //Toolbar.Visible = true;
                DisplayPanel.Visible = Status;
            }
            else
            {
                try
                {
                    _connectionWorker.RunWorkerAsync();
                }
                catch (Exception)
                {
                    //MessageBox.Show(e.Message);
                }
                _timer1.Start();
                _timer2.Start();
                //_progressForm.Show();
                //_progressForm.label1.Text = @"Подключение... Пожалуйста подождите.";
                Trends.Visible = true;
                //Toolbar.Visible = true;
                DisplayPanel.Visible = Status;
                //DeleteColumnsDgPla();
                _dictionary.Clear();
                //ToolbarBtnUpdate.Visible = true;
                //ToolbarBtnSave.Visible = true;
            }
        }

        protected override void OnControlActivate()
        {
            
        }

        protected override void OnControlDeactivate()
        {
            
        }

        public void LoadPropertiesForm(object sender, EventArgs e)
        {
            var propertiesForm = new ActiveXPropertiesForm()
            {
                Host = Host,
                OpcServer = OpcServer,
                AutoRunTime = AutoRunTime,
                //MineInfoList = MineInfoList

            };
           
            propertiesForm.MineTableInitialize();
            propertiesForm.Show();
            
            propertiesForm.Closed += (o, args) =>
            {
                Host = propertiesForm.Host;
                OpcServer = propertiesForm.OpcServer;
                AutoRunTime = propertiesForm.AutoRunTime;
                //MineInfoList = propertiesForm.MineInfoList;
                //MinesInfoXml = new Serializer().SerializeObject(MineInfoList);
                Status = propertiesForm.CheckStatus;
                VisionX = propertiesForm.CheckX;
                VisionY = propertiesForm.CheckY;
                VisionTitleX = propertiesForm.CheckTitleX;
                VisionTitleY = propertiesForm.CheckTitleY;
            };

            


           
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            StopRunTime();
            Deactivate();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            StopRunTime();
            Deactivate();
        }

        #endregion

        #region Events

        public bool KeyIsPress = false;
        private void ToolbarBtnSave_Click(object sender, EventArgs e)
        {
           
            Trends.Refresh();
            if (!_status)
            {
                CheckTheConnectionStatus();
            }
        }
        
        private void ToolbarBtnUpdate_Click(object sender, EventArgs e)
        {
            //FromOpcLoadDgPla();
            if (!_status)
            {
                CheckTheConnectionStatus();
            }
        }
        
        private void toolTipSaveBut_Popup(object sender, PopupEventArgs e)
        {

        }

        private void toolTipUpdateBut_Popup(object sender, PopupEventArgs e)
        {

        }
        
        private void MouseClickHideTableError(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DisplayPanelTableError.Text = string.Empty;
                DisplayPanelTableError.Visible = false;
            }
            else if (e.Button == MouseButtons.Right)
            {

            }
        }

        private void KeyPressHideTableError(object sender, KeyEventArgs e)
        {
           
        }

     

        private void ToolbarBtnConnection_Click(object sender, EventArgs e)
        {
            try
            {
                CheckTheConnectionStatus();

            }
            catch (Exception)
            {
                OffConnectionDisplayPanelIndicator.Visible = true;
                DisplayPanelServerError.Visible = true;
                OnConnectionDisplayPanelIndicator.Visible = false;
                DisplayPanelServerError.Font = new Font("Segoe UI Symbo", 12F, FontStyle.Regular);
                OffConnectionDisplayPanelIndicator.Font = new Font("Segoe UI Symbo", 12F, FontStyle.Regular);
                DisplayPanelServerError.Text = @"|  Ошибка соединения: Попытка соединения не удалась, сервер не доступен";
                DisplayPanel.ForeColor = Color.PaleVioletRed;
                OffConnectionDisplayPanelIndicator.ForeColor = Color.PaleVioletRed;
            }
        }

        private void EditingControlShowingDgPla(object sender,
            DataGridViewEditingControlShowingEventArgs exArgs)
        {
            TextBox tb = (TextBox) exArgs.Control;
            if (!KeyIsPress)
            {
                tb.KeyPress += DgPlaOnKeyPress;
            }
            else
            {
                tb.KeyPress -= DgPlaOnKeyPress;
                KeyIsPress = false;
            }
        }

        private void DgPlaOnKeyPress(object sender, KeyPressEventArgs exKeyPressArgs)
        {
            if (Trends.CurrentCell.RowIndex == 2 || Trends.CurrentCell.RowIndex == 3)
            {
                exKeyPressArgs.Handled = false;

                if (!Char.IsDigit(exKeyPressArgs.KeyChar))
                {
                    if (exKeyPressArgs.KeyChar != (char)Keys.Back)
                    {
                        if (exKeyPressArgs.KeyChar.ToString() != ".")
                        {
                            exKeyPressArgs.Handled = true;
                            KeyIsPress = true;
                        }
                    }
                } 
            }
            else
            {
                if (!Char.IsDigit(exKeyPressArgs.KeyChar))
                {
                    if (exKeyPressArgs.KeyChar != (char)Keys.Back)
                    {
                        exKeyPressArgs.Handled = true;
                        KeyIsPress = true;
                    }
                }
            }
        }
        
        #endregion

        public void Close()
        {
            throw new NotImplementedException();
        }

        public event Action ButtonClicked;
        public void DrawTrends(PlotModel plotModel)
        {
            TrendsView.Model = plotModel;
        }

        public void RefreshTrends()
        {
            try
            {
                TrendsView.Invoke(new MethodInvoker(() => TrendsView.Refresh())); 
            }
            catch (Exception)
            {
                
                
            }
              
        }

        private void DisplayPanel_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

           

        }
    }
}