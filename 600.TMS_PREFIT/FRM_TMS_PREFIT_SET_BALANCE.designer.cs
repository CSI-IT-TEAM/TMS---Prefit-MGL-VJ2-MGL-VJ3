namespace FORM
{
    partial class FRM_TMS_PREFIT_SET_BALANCE
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::FORM.SplashScreen1), true, true);
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_TMS_PREFIT_SET_BALANCE));
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblDate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdBase = new DevExpress.XtraGrid.GridControl();
            this.gvwBase = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.separatorControl4 = new DevExpress.XtraEditors.SeparatorControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tmrDate = new System.Windows.Forms.Timer(this.components);
            this.btnBack = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl4)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager2
            // 
            splashScreenManager2.ClosingDelay = 500;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Times New Roman", 45F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblTitle.LineVisible = true;
            this.lblTitle.Location = new System.Drawing.Point(98, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1594, 67);
            this.lblTitle.TabIndex = 36;
            this.lblTitle.Text = "TRANSPORTATION BOARD";
            this.lblTitle.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(1749, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(155, 74);
            this.lblDate.TabIndex = 38;
            this.lblDate.Text = "2019-09-16\r\n00:00:00";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chartControl1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.separatorControl4);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1898, 990);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            // 
            // chartControl1
            // 
            this.chartControl1.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartControl1.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.DataBindings = null;
            xyDiagram1.AxisX.Label.Font = new System.Drawing.Font("Calibri", 12F);
            xyDiagram1.AxisX.Reverse = true;
            xyDiagram1.AxisX.Tickmarks.MinorVisible = false;
            xyDiagram1.AxisX.Title.Text = "Plant";
            xyDiagram1.AxisX.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.GridLines.Visible = false;
            xyDiagram1.AxisY.Label.Font = new System.Drawing.Font("Calibri", 12F);
            xyDiagram1.AxisY.Label.TextPattern = "{V:#,#}";
            xyDiagram1.AxisY.Title.Text = "Set Percent";
            xyDiagram1.AxisY.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.DefaultPane.BorderVisible = false;
            xyDiagram1.Rotated = true;
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.Location = new System.Drawing.Point(1082, 55);
            this.chartControl1.Name = "chartControl1";
            series1.CrosshairLabelPattern = "{V:#,#}";
            sideBySideBarSeriesLabel1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sideBySideBarSeriesLabel1.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;
            sideBySideBarSeriesLabel1.TextPattern = "{V:#,#.0}";
            series1.Label = sideBySideBarSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Series 1";
            sideBySideBarSeriesView1.ColorEach = true;
            series1.View = sideBySideBarSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.Size = new System.Drawing.Size(777, 852);
            this.chartControl1.TabIndex = 74;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdBase);
            this.panel1.Controls.Add(this.vScrollBar1);
            this.panel1.Controls.Add(this.hScrollBar1);
            this.panel1.Location = new System.Drawing.Point(1, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1047, 852);
            this.panel1.TabIndex = 73;
            // 
            // grdBase
            // 
            this.grdBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBase.Location = new System.Drawing.Point(0, 0);
            this.grdBase.MainView = this.gvwBase;
            this.grdBase.Name = "grdBase";
            this.grdBase.Size = new System.Drawing.Size(1021, 826);
            this.grdBase.TabIndex = 1;
            this.grdBase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwBase});
            // 
            // gvwBase
            // 
            this.gvwBase.BandPanelRowHeight = 30;
            this.gvwBase.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.gvwBase.GridControl = this.grdBase;
            this.gvwBase.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.gvwBase.Name = "gvwBase";
            this.gvwBase.OptionsBehavior.Editable = false;
            this.gvwBase.OptionsBehavior.ReadOnly = true;
            this.gvwBase.OptionsView.AllowCellMerge = true;
            this.gvwBase.OptionsView.ShowGroupPanel = false;
            this.gvwBase.OptionsView.ShowIndicator = false;
            this.gvwBase.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.gvwBase.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvwBase_RowCellStyle);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(1021, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(26, 826);
            this.vScrollBar1.TabIndex = 312;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 826);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(1047, 26);
            this.hScrollBar1.TabIndex = 313;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // separatorControl4
            // 
            this.separatorControl4.LineColor = System.Drawing.SystemColors.ButtonShadow;
            this.separatorControl4.LineOrientation = System.Windows.Forms.Orientation.Vertical;
            this.separatorControl4.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.separatorControl4.LineThickness = 3;
            this.separatorControl4.Location = new System.Drawing.Point(1054, 0);
            this.separatorControl4.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
            this.separatorControl4.Name = "separatorControl4";
            this.separatorControl4.Size = new System.Drawing.Size(24, 919);
            this.separatorControl4.TabIndex = 71;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(1082, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(849, 39);
            this.labelControl2.TabIndex = 40;
            this.labelControl2.Text = "★  UPSTREAM SET BALANCE CHART";
            this.labelControl2.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(11, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(996, 39);
            this.labelControl1.TabIndex = 40;
            this.labelControl1.Text = "★  UPSTREAM SET BALANCE";
            this.labelControl1.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // tmrDate
            // 
            this.tmrDate.Enabled = true;
            this.tmrDate.Interval = 1000;
            this.tmrDate.Tick += new System.EventHandler(this.tmrDate_Tick);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(6, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(86, 80);
            this.btnBack.TabIndex = 81;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Green;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1727, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 39);
            this.label7.TabIndex = 427;
            this.label7.Text = "> 90 %";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1551, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 39);
            this.label2.TabIndex = 426;
            this.label2.Text = "70 % ~ 90 %";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1375, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 39);
            this.label1.TabIndex = 426;
            this.label1.Text = "< 70%";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FRM_TMS_PREFIT_SET_BALANCE
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_TMS_PREFIT_SET_BALANCE";
            this.Text = "FRM_TMS_PREFIT_OUTGOING";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.VisibleChanged += new System.EventHandler(this.FRM_TMS_PREFIT_SET_BALANCE_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SeparatorControl separatorControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.Windows.Forms.Timer tmrDate;
        private System.Windows.Forms.Button btnBack;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl grdBase;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gvwBase;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}