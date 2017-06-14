namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.trendsControl3 = new EleSy.CV.ActiveX.TrendsControl();
            this.SuspendLayout();
            // 
            // trendsControl3
            // 
            this.trendsControl3.AutoActivate = true;
            this.trendsControl3.AutoRunTime = false;
            this.trendsControl3.AutoScroll = true;
            this.trendsControl3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.trendsControl3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.trendsControl3.CheckBoxSize = false;
            this.trendsControl3.Host = null;
            this.trendsControl3.Location = new System.Drawing.Point(62, 69);
            this.trendsControl3.MineInfoList = ((System.ComponentModel.BindingList<EleSy.CV.ActiveX.Model.MineInfo>)(resources.GetObject("trendsControl3.MineInfoList")));
            this.trendsControl3.MinesInfoXml = null;
            this.trendsControl3.Name = "trendsControl3";
            this.trendsControl3.OpcServer = null;
            this.trendsControl3.Size = new System.Drawing.Size(928, 518);
            this.trendsControl3.SyncRoot = ((object)(resources.GetObject("trendsControl3.SyncRoot")));
            this.trendsControl3.TabIndex = 0;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1202, 770);
            this.Controls.Add(this.trendsControl3);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private EleSy.CV.ActiveX.TrendsControl trendsControl3;
    }
}

