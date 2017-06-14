using System.ComponentModel;
using System.Windows.Forms;

namespace EleSy.CV.ActiveX.Forms
{
    public partial class ActiveXPropertiesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing = true)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActiveXPropertiesForm));
            this.ApplyButton = new System.Windows.Forms.Button();
            this.openCfgFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.AutoRunTimBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHostBox = new System.Windows.Forms.TextBox();
            this.txtOPCserverBox = new System.Windows.Forms.TextBox();
            this.configbox = new System.Windows.Forms.GroupBox();
            this.checkStatus = new System.Windows.Forms.CheckBox();
            this.pictureBoxBtnAdd = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkValX = new System.Windows.Forms.CheckBox();
            this.checkValY = new System.Windows.Forms.CheckBox();
            this.checkTitleX = new System.Windows.Forms.CheckBox();
            this.checkTitleY = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.activeXPropertiesFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mineInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.configbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBtnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeXPropertiesFormBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mineInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(303, 195);
            this.ApplyButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(85, 30);
            this.ApplyButton.TabIndex = 0;
            this.ApplyButton.Text = "Применить";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // openCfgFileDialog
            // 
            this.openCfgFileDialog.Filter = "XML file (*.xml)|*.xml";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Хост";
            // 
            // AutoRunTimBox
            // 
            this.AutoRunTimBox.AutoSize = true;
            this.AutoRunTimBox.Checked = true;
            this.AutoRunTimBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoRunTimBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AutoRunTimBox.Location = new System.Drawing.Point(6, 89);
            this.AutoRunTimBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AutoRunTimBox.Name = "AutoRunTimBox";
            this.AutoRunTimBox.Size = new System.Drawing.Size(115, 21);
            this.AutoRunTimBox.TabIndex = 6;
            this.AutoRunTimBox.Text = "Автоактивация";
            this.AutoRunTimBox.UseVisualStyleBackColor = true;
            this.AutoRunTimBox.CheckedChanged += new System.EventHandler(this.AutoRunTimBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "OPC-сервер";
            // 
            // txtHostBox
            // 
            this.txtHostBox.Location = new System.Drawing.Point(132, 22);
            this.txtHostBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHostBox.Name = "txtHostBox";
            this.txtHostBox.Size = new System.Drawing.Size(242, 25);
            this.txtHostBox.TabIndex = 8;
            this.txtHostBox.TextChanged += new System.EventHandler(this.txtHost_TextChanged);
            // 
            // txtOPCserverBox
            // 
            this.txtOPCserverBox.Location = new System.Drawing.Point(132, 56);
            this.txtOPCserverBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOPCserverBox.Name = "txtOPCserverBox";
            this.txtOPCserverBox.Size = new System.Drawing.Size(242, 25);
            this.txtOPCserverBox.TabIndex = 9;
            this.txtOPCserverBox.TextChanged += new System.EventHandler(this.txtOPCserver_TextChanged);
            // 
            // configbox
            // 
            this.configbox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.configbox.Controls.Add(this.label3);
            this.configbox.Controls.Add(this.checkTitleY);
            this.configbox.Controls.Add(this.checkTitleX);
            this.configbox.Controls.Add(this.checkValY);
            this.configbox.Controls.Add(this.checkValX);
            this.configbox.Controls.Add(this.checkStatus);
            this.configbox.Controls.Add(this.pictureBoxBtnAdd);
            this.configbox.Controls.Add(this.txtHostBox);
            this.configbox.Controls.Add(this.AutoRunTimBox);
            this.configbox.Controls.Add(this.txtOPCserverBox);
            this.configbox.Controls.Add(this.label1);
            this.configbox.Controls.Add(this.label2);
            this.configbox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.configbox.Location = new System.Drawing.Point(8, 9);
            this.configbox.Name = "configbox";
            this.configbox.Size = new System.Drawing.Size(380, 171);
            this.configbox.TabIndex = 10;
            this.configbox.TabStop = false;
            this.configbox.Text = "Конфигурация сервера";
            this.configbox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // checkStatus
            // 
            this.checkStatus.AutoSize = true;
            this.checkStatus.Location = new System.Drawing.Point(132, 89);
            this.checkStatus.Name = "checkStatus";
            this.checkStatus.Size = new System.Drawing.Size(138, 21);
            this.checkStatus.TabIndex = 14;
            this.checkStatus.Text = "Статус соединения";
            this.checkStatus.UseVisualStyleBackColor = true;
            this.checkStatus.CheckedChanged += new System.EventHandler(this.checkStatus_CheckedChanged);
            // 
            // pictureBoxBtnAdd
            // 
            this.pictureBoxBtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBtnAdd.Image")));
            this.pictureBoxBtnAdd.InitialImage = null;
            this.pictureBoxBtnAdd.Location = new System.Drawing.Point(342, 133);
            this.pictureBoxBtnAdd.Name = "pictureBoxBtnAdd";
            this.pictureBoxBtnAdd.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxBtnAdd.TabIndex = 13;
            this.pictureBoxBtnAdd.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxBtnAdd, "Добавить");
            this.pictureBoxBtnAdd.Click += new System.EventHandler(this.BtnAddMineClick);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(8, 186);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(93, 39);
            this.panel1.TabIndex = 13;
            this.toolTip1.SetToolTip(this.panel1, "\"ЭлеСи\"");
            // 
            // checkValX
            // 
            this.checkValX.AutoSize = true;
            this.checkValX.Checked = true;
            this.checkValX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkValX.Location = new System.Drawing.Point(6, 117);
            this.checkValX.Name = "checkValX";
            this.checkValX.Size = new System.Drawing.Size(120, 21);
            this.checkValX.TabIndex = 15;
            this.checkValX.Text = "Значения оси X";
            this.checkValX.UseVisualStyleBackColor = true;
            // 
            // checkValY
            // 
            this.checkValY.AutoSize = true;
            this.checkValY.Checked = true;
            this.checkValY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkValY.Location = new System.Drawing.Point(132, 116);
            this.checkValY.Name = "checkValY";
            this.checkValY.Size = new System.Drawing.Size(119, 21);
            this.checkValY.TabIndex = 16;
            this.checkValY.Text = "Значения оси Y";
            this.checkValY.UseVisualStyleBackColor = true;
            // 
            // checkTitleX
            // 
            this.checkTitleX.AutoSize = true;
            this.checkTitleX.Checked = true;
            this.checkTitleX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkTitleX.Location = new System.Drawing.Point(6, 144);
            this.checkTitleX.Name = "checkTitleX";
            this.checkTitleX.Size = new System.Drawing.Size(121, 21);
            this.checkTitleX.TabIndex = 17;
            this.checkTitleX.Text = "Название оси X";
            this.checkTitleX.UseVisualStyleBackColor = true;
            // 
            // checkTitleY
            // 
            this.checkTitleY.AutoSize = true;
            this.checkTitleY.Checked = true;
            this.checkTitleY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkTitleY.Location = new System.Drawing.Point(132, 144);
            this.checkTitleY.Name = "checkTitleY";
            this.checkTitleY.Size = new System.Drawing.Size(120, 21);
            this.checkTitleY.TabIndex = 18;
            this.checkTitleY.Text = "Название оси Y";
            this.checkTitleY.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Теги";
            // 
            // activeXPropertiesFormBindingSource
            // 
            this.activeXPropertiesFormBindingSource.DataSource = typeof(EleSy.CV.ActiveX.Forms.ActiveXPropertiesForm);
            // 
            // mineInfoBindingSource
            // 
            this.mineInfoBindingSource.DataSource = typeof(EleSy.CV.ActiveX.Model.MineInfo);
            // 
            // ActiveXPropertiesForm
            // 
            this.AcceptButton = this.ApplyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(394, 231);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.configbox);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(430, 620);
            this.MinimumSize = new System.Drawing.Size(400, 225);
            this.Name = "ActiveXPropertiesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Конфигурация подключения";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ActiveXPropertiesForm_FormClosing);
            this.Load += new System.EventHandler(this.ActiveXPropertiesForm_Load);
            this.configbox.ResumeLayout(false);
            this.configbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBtnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeXPropertiesFormBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mineInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button ApplyButton;
        private OpenFileDialog openCfgFileDialog;
        public Label label1;
        private CheckBox AutoRunTimBox;
        private Label label2;
        private TextBox txtHostBox;
        private TextBox txtOPCserverBox;
        private GroupBox configbox;
        private Panel panel1;
        private BindingSource mineInfoBindingSource;
        private BindingSource activeXPropertiesFormBindingSource;
        private ToolTip toolTip1;
        private PictureBox pictureBoxBtnAdd;
        private CheckBox checkStatus;
        private Label label3;
        private CheckBox checkTitleY;
        private CheckBox checkTitleX;
        private CheckBox checkValY;
        private CheckBox checkValX;
    }
}