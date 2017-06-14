using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using EleSy.CV.ActiveX.Model;
using EleSy.CV.ActiveX.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using Opc;


namespace EleSy.CV.ActiveX.Forms
{
    public partial class ActiveXPropertiesForm : Form
    {
        public ActiveXPropertiesForm()
        {
            InitializeComponent();
            CreateMineObjectList();
            //MineInfoList = new Serializer().DeserializeObject<BindingList<MineInfo>>(MinesInfoXml); // <Diserialize from xml>
            
        }

        public BindingList<MineInfo> MineInfoList { get; set; }

        public string Host
        {
            get { return txtHostBox.Text; }
            set { txtHostBox.Text = @"localhost"; }
        }

        public string OpcServer
        {
            get { return txtOPCserverBox.Text; }
            set { txtOPCserverBox.Text = @"Infinity.OPCServer"; }
        }

        public bool CheckStatus
        {
            get { return checkStatus.Checked; }
            set { checkStatus.Checked = value; }
           
        }

        public bool CheckX
        {
            get { return checkValX.Checked; }
            set { checkValX.Checked = value; }
        }

        public bool CheckY
        {
            get { return checkValY.Checked; }
            set { checkValY.Checked = value; }
        }

        public bool CheckTitleX
        {
            get { return checkTitleX.Checked; }
            set { checkTitleX.Checked = value; }
        }
        public bool CheckTitleY
        {
            get { return checkTitleY.Checked; }
            set { checkTitleY.Checked = value; }
        }
        public bool AutoRunTime
        {
            get { return AutoRunTimBox.Checked; }
            set { AutoRunTimBox.Checked = value; }
        }
        public bool OkResult { get; set; }
        
        //public string MinesInfoXml { get; set; }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(Host) || !String.IsNullOrWhiteSpace(OpcServer))
            {
                
                DialogResult = DialogResult.OK;
                //MinesInfoXml = new Serializer().SerializeObject(MineInfoList); // <Serialize to xml>
                OkResult = true;
                Close();
            }
            else
            {
                MessageBox.Show(@"Укажите параметры подключения к OPC-серверу", @"Ошибка", MessageBoxButtons.OK);
                DialogResult = DialogResult.None; 
                OkResult = false;
            }
        }
        
        private void ActiveXPropertiesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sender != this)
                return;
            if (DialogResult == DialogResult.None)
                e.Cancel = true;
        }
        
        private void txtHost_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOPCserver_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

   

        public void CreateMineObjectList()
        {
            MineInfoList = new BindingList<MineInfo>();
        }
        
        public void MineTableInitialize()
        {  
            if (MineInfoList != null)
            {
                MineInfoList.AllowNew = true;
                MineInfoList.AllowRemove = true;
                MineInfoList.RaiseListChangedEvents = true;
                MineInfoList.AllowEdit = true;
            }
            else
            {
                MessageBox.Show(@"Ошибка заполнения. Список пуст.");
            }
        }

        private void AutoRunTimBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ActiveXPropertiesForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnAddMineClick(object sender, EventArgs e)
        {
           var settings = new Settings();
            settings.Show();
        }

        private void checkStatus_CheckedChanged(object sender, EventArgs e)
        {

        }
        }
}