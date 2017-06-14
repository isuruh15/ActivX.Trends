namespace EleSy.CV.ActiveX
{
    partial class TrendsControl
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
            if (disposing)
                if (components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DisplayPanel = new System.Windows.Forms.StatusStrip();
            this.DisplayPanelWatch = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSS_slash = new System.Windows.Forms.ToolStripStatusLabel();
            this.OnConnectionDisplayPanelIndicator = new System.Windows.Forms.ToolStripStatusLabel();
            this.OffConnectionDisplayPanelIndicator = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSS_slash2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.DisplayPanelServerError = new System.Windows.Forms.ToolStripStatusLabel();
            this.DisplayPanelCounterDelay = new System.Windows.Forms.ToolStripStatusLabel();
            this.DisplayPanelTableError = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTipSaveBut = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipUpdateBut = new System.Windows.Forms.ToolTip(this.components);
            this.Trends = new System.Windows.Forms.DataGridView();
            this.TrendsView = new OxyPlot.WindowsForms.PlotView();
            this.DisplayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Trends)).BeginInit();
            this.SuspendLayout();
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.DisplayPanel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DisplayPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DisplayPanelWatch,
            this.TSS_slash,
            this.OnConnectionDisplayPanelIndicator,
            this.OffConnectionDisplayPanelIndicator,
            this.TSS_slash2,
            this.DisplayPanelServerError,
            this.DisplayPanelCounterDelay,
            this.DisplayPanelTableError});
            this.DisplayPanel.Location = new System.Drawing.Point(0, 496);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.DisplayPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DisplayPanel.ShowItemToolTips = true;
            this.DisplayPanel.Size = new System.Drawing.Size(928, 22);
            this.DisplayPanel.TabIndex = 3;
            this.DisplayPanel.Text = "TableStatusStrip";
            this.DisplayPanel.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DisplayPanel_ItemClicked);
            // 
            // DisplayPanelWatch
            // 
            this.DisplayPanelWatch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayPanelWatch.Name = "DisplayPanelWatch";
            this.DisplayPanelWatch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DisplayPanelWatch.Size = new System.Drawing.Size(41, 20);
            this.DisplayPanelWatch.Text = "Время";
            this.DisplayPanelWatch.Visible = false;
            // 
            // TSS_slash
            // 
            this.TSS_slash.Name = "TSS_slash";
            this.TSS_slash.Size = new System.Drawing.Size(13, 20);
            this.TSS_slash.Text = "|";
            this.TSS_slash.Visible = false;
            // 
            // OnConnectionDisplayPanelIndicator
            // 
            this.OnConnectionDisplayPanelIndicator.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.OnConnectionDisplayPanelIndicator.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.OnConnectionDisplayPanelIndicator.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OnConnectionDisplayPanelIndicator.Name = "OnConnectionDisplayPanelIndicator";
            this.OnConnectionDisplayPanelIndicator.Size = new System.Drawing.Size(147, 20);
            this.OnConnectionDisplayPanelIndicator.Text = "Соединение установлено";
            this.OnConnectionDisplayPanelIndicator.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.OnConnectionDisplayPanelIndicator.ToolTipText = "Статус соединения: установленно";
            this.OnConnectionDisplayPanelIndicator.Visible = false;
            // 
            // OffConnectionDisplayPanelIndicator
            // 
            this.OffConnectionDisplayPanelIndicator.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.OffConnectionDisplayPanelIndicator.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.OffConnectionDisplayPanelIndicator.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OffConnectionDisplayPanelIndicator.Name = "OffConnectionDisplayPanelIndicator";
            this.OffConnectionDisplayPanelIndicator.Size = new System.Drawing.Size(139, 20);
            this.OffConnectionDisplayPanelIndicator.Text = "Соединение отсутствует";
            this.OffConnectionDisplayPanelIndicator.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.OffConnectionDisplayPanelIndicator.ToolTipText = "Статус соединения: не установленно";
            this.OffConnectionDisplayPanelIndicator.Visible = false;
            // 
            // TSS_slash2
            // 
            this.TSS_slash2.Name = "TSS_slash2";
            this.TSS_slash2.Size = new System.Drawing.Size(13, 20);
            this.TSS_slash2.Text = "|";
            this.TSS_slash2.Visible = false;
            // 
            // DisplayPanelServerError
            // 
            this.DisplayPanelServerError.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayPanelServerError.Name = "DisplayPanelServerError";
            this.DisplayPanelServerError.Size = new System.Drawing.Size(119, 17);
            this.DisplayPanelServerError.Text = "Строка уведомлений";
            this.DisplayPanelServerError.Visible = false;
            // 
            // DisplayPanelCounterDelay
            // 
            this.DisplayPanelCounterDelay.Name = "DisplayPanelCounterDelay";
            this.DisplayPanelCounterDelay.Size = new System.Drawing.Size(0, 17);
            this.DisplayPanelCounterDelay.Visible = false;
            // 
            // DisplayPanelTableError
            // 
            this.DisplayPanelTableError.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayPanelTableError.Name = "DisplayPanelTableError";
            this.DisplayPanelTableError.Size = new System.Drawing.Size(125, 17);
            this.DisplayPanelTableError.Text = "Строка уведомлений2";
            this.DisplayPanelTableError.Visible = false;
            // 
            // toolTipSaveBut
            // 
            this.toolTipSaveBut.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTipSaveBut_Popup);
            // 
            // toolTipUpdateBut
            // 
            this.toolTipUpdateBut.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTipUpdateBut_Popup);
            // 
            // Trends
            // 
            this.Trends.AllowUserToAddRows = false;
            this.Trends.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Trends.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Trends.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Trends.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Trends.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Trends.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.Trends.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Trends.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Trends.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Trends.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Trends.DefaultCellStyle = dataGridViewCellStyle3;
            this.Trends.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Trends.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Trends.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Trends.Location = new System.Drawing.Point(0, 0);
            this.Trends.Name = "Trends";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Trends.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Trends.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Trends.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Trends.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Trends.Size = new System.Drawing.Size(928, 518);
            this.Trends.TabIndex = 4;
            this.Trends.Visible = false;
            this.Trends.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablel_CellContentClick);
            // 
            // TrendsView
            // 
            this.TrendsView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(92)))), ((int)(((byte)(130)))));
            this.TrendsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrendsView.Location = new System.Drawing.Point(0, 0);
            this.TrendsView.Name = "TrendsView";
            this.TrendsView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.TrendsView.Size = new System.Drawing.Size(928, 496);
            this.TrendsView.TabIndex = 5;
            this.TrendsView.Text = "plot1";
            this.TrendsView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.TrendsView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.TrendsView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // TrendsControl
            // 
            this.AutoActivate = true;

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Controls.Add(this.TrendsView);
            this.Controls.Add(this.DisplayPanel);
            this.Controls.Add(this.Trends);
            this.Name = "TrendsControl";
            this.Size = new System.Drawing.Size(928, 518);
            this.DoubleClick += new System.EventHandler(this.LoadPropertiesForm);
            this.DisplayPanel.ResumeLayout(false);
            this.DisplayPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Trends)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.StatusStrip DisplayPanel;
        private System.Windows.Forms.ToolStripStatusLabel OnConnectionDisplayPanelIndicator;
        private System.Windows.Forms.ToolStripStatusLabel OffConnectionDisplayPanelIndicator;
        private System.Windows.Forms.ToolTip toolTipSaveBut;
        private System.Windows.Forms.ToolTip toolTipUpdateBut;
        private System.Windows.Forms.ToolStripStatusLabel DisplayPanelServerError;
        private System.Windows.Forms.ToolStripStatusLabel DisplayPanelCounterDelay;
        private System.Windows.Forms.ToolStripStatusLabel DisplayPanelWatch;
        private System.Windows.Forms.ToolStripStatusLabel DisplayPanelTableError;
        private System.Windows.Forms.ToolStripStatusLabel TSS_slash;
        private System.Windows.Forms.ToolStripStatusLabel TSS_slash2;
        //private OxyPlot.WindowsForms.PlotView Trends;
        private System.Windows.Forms.DataGridView Trends;
        private OxyPlot.WindowsForms.PlotView TrendsView;

        //private Vlc.DotNet.Forms.VlcControl _vlcControl;
    }
}
