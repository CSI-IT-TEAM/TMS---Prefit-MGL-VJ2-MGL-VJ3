namespace FORM
{
    partial class FRM_MGL_BTS_YEARLY
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.XYMarkerSlideAnimation xyMarkerSlideAnimation1 = new DevExpress.XtraCharts.XYMarkerSlideAnimation();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.tmrDate = new System.Windows.Forms.Timer(this.components);
            this.pnHeader = new System.Windows.Forms.Panel();
            this.pnYMD = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnBody = new System.Windows.Forms.Panel();
            this.splMain = new System.Windows.Forms.SplitContainer();
            this.grdView = new DevExpress.XtraGrid.GridControl();
            this.gvwView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.DIV = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.COL01 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.COL02 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.COL03 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.COL04 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.COL05 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.COL06 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.COLAVG = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TARGET = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.RATE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.COL07 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.spl1 = new System.Windows.Forms.SplitContainer();
            this.spl2 = new System.Windows.Forms.SplitContainer();
            this.bgWork = new System.ComponentModel.BackgroundWorker();
            this.ChartVSM = new DevExpress.XtraCharts.ChartControl();
            this.bandDate = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.band01 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.band02 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.band03 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.band04 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.band05 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.band06 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.band07 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.pnHeader.SuspendLayout();
            this.pnBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.Panel1.SuspendLayout();
            this.splMain.Panel2.SuspendLayout();
            this.splMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spl1)).BeginInit();
            this.spl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spl2)).BeginInit();
            this.spl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartVSM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrDate
            // 
            this.tmrDate.Interval = 1000;
            this.tmrDate.Tick += new System.EventHandler(this.tmrDate_Tick);
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.DarkTurquoise;
            this.pnHeader.Controls.Add(this.pnYMD);
            this.pnHeader.Controls.Add(this.lblDate);
            this.pnHeader.Controls.Add(this.lblTitle);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1920, 110);
            this.pnHeader.TabIndex = 0;
            // 
            // pnYMD
            // 
            this.pnYMD.BackColor = System.Drawing.Color.Transparent;
            this.pnYMD.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnYMD.Location = new System.Drawing.Point(1227, 0);
            this.pnYMD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnYMD.Name = "pnYMD";
            this.pnYMD.Size = new System.Drawing.Size(420, 110);
            this.pnYMD.TabIndex = 53;
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 34F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(1647, 0);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(273, 110);
            this.lblDate.TabIndex = 2;
            this.lblDate.Tag = "Minimized";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDate.DoubleClick += new System.EventHandler(this.lblDate_DoubleClick);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 45F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(718, 110);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Tag = "Minimized";
            this.lblTitle.Text = "BTS By Year";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.DoubleClick += new System.EventHandler(this.lblTitle_DoubleClick);
            // 
            // pnBody
            // 
            this.pnBody.BackColor = System.Drawing.Color.White;
            this.pnBody.Controls.Add(this.splMain);
            this.pnBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBody.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.pnBody.Location = new System.Drawing.Point(0, 110);
            this.pnBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnBody.Name = "pnBody";
            this.pnBody.Size = new System.Drawing.Size(1920, 970);
            this.pnBody.TabIndex = 1;
            // 
            // splMain
            // 
            this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMain.Location = new System.Drawing.Point(0, 0);
            this.splMain.Name = "splMain";
            this.splMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splMain.Panel1
            // 
            this.splMain.Panel1.Controls.Add(this.grdView);
            this.splMain.Panel1.Controls.Add(this.panel1);
            // 
            // splMain.Panel2
            // 
            this.splMain.Panel2.Controls.Add(this.ChartVSM);
            this.splMain.Size = new System.Drawing.Size(1920, 970);
            this.splMain.SplitterDistance = 372;
            this.splMain.TabIndex = 3;
            // 
            // grdView
            // 
            this.grdView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdView.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdView.Location = new System.Drawing.Point(0, 48);
            this.grdView.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdView.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdView.MainView = this.gvwView;
            this.grdView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdView.Name = "grdView";
            this.grdView.Size = new System.Drawing.Size(1920, 324);
            this.grdView.TabIndex = 3;
            this.grdView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwView});
            // 
            // gvwView
            // 
            this.gvwView.Appearance.BandPanel.BackColor = System.Drawing.Color.Gray;
            this.gvwView.Appearance.BandPanel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvwView.Appearance.BandPanel.ForeColor = System.Drawing.Color.White;
            this.gvwView.Appearance.BandPanel.Options.UseBackColor = true;
            this.gvwView.Appearance.BandPanel.Options.UseFont = true;
            this.gvwView.Appearance.BandPanel.Options.UseForeColor = true;
            this.gvwView.Appearance.BandPanel.Options.UseTextOptions = true;
            this.gvwView.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvwView.Appearance.BandPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvwView.Appearance.Row.Font = new System.Drawing.Font("Calibri", 14F);
            this.gvwView.Appearance.Row.Options.UseFont = true;
            this.gvwView.Appearance.Row.Options.UseTextOptions = true;
            this.gvwView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvwView.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvwView.BandPanelRowHeight = 55;
            this.gvwView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.bandDate,
            this.band01,
            this.band02,
            this.band03,
            this.band04,
            this.band05,
            this.band06,
            this.band07,
            this.gridBand1,
            this.gridBand3});
            this.gvwView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.DIV,
            this.COL01,
            this.COL02,
            this.COL03,
            this.COL04,
            this.COL05,
            this.COL06,
            this.COL07,
            this.COLAVG,
            this.TARGET,
            this.RATE});
            this.gvwView.GridControl = this.grdView;
            this.gvwView.Name = "gvwView";
            this.gvwView.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.gvwView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvwView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvwView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvwView.OptionsView.ShowColumnHeaders = false;
            this.gvwView.OptionsView.ShowGroupPanel = false;
            this.gvwView.OptionsView.ShowIndicator = false;
            this.gvwView.PaintStyleName = "Flat";
            this.gvwView.RowHeight = 50;
            this.gvwView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvw_RowCellStyle);
            // 
            // DIV
            // 
            this.DIV.Caption = "DIV";
            this.DIV.FieldName = "DIV";
            this.DIV.Name = "DIV";
            this.DIV.Visible = true;
            this.DIV.Width = 298;
            // 
            // COL01
            // 
            this.COL01.Caption = "COL01";
            this.COL01.FieldName = "COL01";
            this.COL01.Name = "COL01";
            this.COL01.Visible = true;
            this.COL01.Width = 205;
            // 
            // COL02
            // 
            this.COL02.Caption = "COL02";
            this.COL02.FieldName = "COL02";
            this.COL02.Name = "COL02";
            this.COL02.Visible = true;
            this.COL02.Width = 205;
            // 
            // COL03
            // 
            this.COL03.Caption = "COL03";
            this.COL03.FieldName = "COL03";
            this.COL03.Name = "COL03";
            this.COL03.Visible = true;
            this.COL03.Width = 205;
            // 
            // COL04
            // 
            this.COL04.Caption = "COL04";
            this.COL04.FieldName = "COL04";
            this.COL04.Name = "COL04";
            this.COL04.Visible = true;
            this.COL04.Width = 205;
            // 
            // COL05
            // 
            this.COL05.Caption = "COL05";
            this.COL05.FieldName = "COL05";
            this.COL05.Name = "COL05";
            this.COL05.Visible = true;
            this.COL05.Width = 205;
            // 
            // COL06
            // 
            this.COL06.Caption = "COL06";
            this.COL06.FieldName = "COL06";
            this.COL06.Name = "COL06";
            this.COL06.Visible = true;
            this.COL06.Width = 205;
            // 
            // COLAVG
            // 
            this.COLAVG.Caption = "COLAVG";
            this.COLAVG.FieldName = "COLAVG";
            this.COLAVG.Name = "COLAVG";
            this.COLAVG.Visible = true;
            this.COLAVG.Width = 209;
            // 
            // TARGET
            // 
            this.TARGET.Caption = "TARGET";
            this.TARGET.FieldName = "TAR";
            this.TARGET.Name = "TARGET";
            this.TARGET.Visible = true;
            // 
            // RATE
            // 
            this.RATE.Caption = "%";
            this.RATE.FieldName = "RATE";
            this.RATE.Name = "RATE";
            this.RATE.Visible = true;
            // 
            // COL07
            // 
            this.COL07.Caption = "COL07";
            this.COL07.FieldName = "COL07";
            this.COL07.Name = "COL07";
            this.COL07.Width = 205;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 48);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1759, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 31);
            this.label5.TabIndex = 5;
            this.label5.Text = " BTS < 68%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Green;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1144, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 31);
            this.label4.TabIndex = 6;
            this.label4.Text = "BTS >=72%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1301, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "70% <=BTS <72%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Red;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1530, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "68% <=BTS <70%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(1035, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Unit: %";
            // 
            // spl1
            // 
            this.spl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spl1.Location = new System.Drawing.Point(0, 0);
            this.spl1.Name = "spl1";
            this.spl1.Size = new System.Drawing.Size(150, 100);
            this.spl1.TabIndex = 0;
            // 
            // spl2
            // 
            this.spl2.Location = new System.Drawing.Point(0, 0);
            this.spl2.Name = "spl2";
            this.spl2.Size = new System.Drawing.Size(150, 100);
            this.spl2.TabIndex = 0;
            // 
            // bgWork
            // 
            this.bgWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWork_DoWork);
            // 
            // ChartVSM
            // 
            this.ChartVSM.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.ChartVSM.AppearanceNameSerializable = "Pastel Kit";
            this.ChartVSM.DataBindings = null;
            xyDiagram1.AxisX.Title.Text = "Day";
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Title.Text = "BTS";
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.DefaultPane.Shadow.Visible = true;
            this.ChartVSM.Diagram = xyDiagram1;
            this.ChartVSM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartVSM.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.ChartVSM.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.ChartVSM.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.ChartVSM.Legend.Name = "Default Legend";
            this.ChartVSM.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.ChartVSM.Location = new System.Drawing.Point(0, 0);
            this.ChartVSM.Name = "ChartVSM";
            this.ChartVSM.PaletteName = "Pastel Kit";
            pointSeriesLabel1.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.JustifyAroundPoint;
            series1.Label = pointSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "VJ1";
            lineSeriesView1.LineStyle.Thickness = 3;
            lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            xyMarkerSlideAnimation1.Direction = DevExpress.XtraCharts.XYMarkerSlideAnimationDirection.FromBottomCenter;
            lineSeriesView1.SeriesPointAnimation = xyMarkerSlideAnimation1;
            series1.View = lineSeriesView1;
            this.ChartVSM.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.ChartVSM.Size = new System.Drawing.Size(1920, 594);
            this.ChartVSM.TabIndex = 1;
            chartTitle1.Font = new System.Drawing.Font("Tahoma", 14F);
            chartTitle1.Text = "VJ1";
            this.ChartVSM.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // bandDate
            // 
            this.bandDate.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.bandDate.AppearanceHeader.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.bandDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bandDate.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.bandDate.AppearanceHeader.Options.UseBackColor = true;
            this.bandDate.AppearanceHeader.Options.UseFont = true;
            this.bandDate.AppearanceHeader.Options.UseForeColor = true;
            this.bandDate.Caption = "Year";
            this.bandDate.Columns.Add(this.DIV);
            this.bandDate.Name = "bandDate";
            this.bandDate.VisibleIndex = 0;
            this.bandDate.Width = 298;
            // 
            // band01
            // 
            this.band01.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.band01.AppearanceHeader.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.band01.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.band01.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.band01.AppearanceHeader.Options.UseBackColor = true;
            this.band01.AppearanceHeader.Options.UseFont = true;
            this.band01.AppearanceHeader.Options.UseForeColor = true;
            this.band01.Caption = "2019";
            this.band01.Columns.Add(this.COL01);
            this.band01.Name = "band01";
            this.band01.VisibleIndex = 1;
            this.band01.Width = 205;
            // 
            // band02
            // 
            this.band02.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.band02.AppearanceHeader.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.band02.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.band02.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.band02.AppearanceHeader.Options.UseBackColor = true;
            this.band02.AppearanceHeader.Options.UseFont = true;
            this.band02.AppearanceHeader.Options.UseForeColor = true;
            this.band02.Caption = "2020";
            this.band02.Columns.Add(this.COL02);
            this.band02.Name = "band02";
            this.band02.VisibleIndex = 2;
            this.band02.Width = 205;
            // 
            // band03
            // 
            this.band03.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.band03.AppearanceHeader.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.band03.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.band03.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.band03.AppearanceHeader.Options.UseBackColor = true;
            this.band03.AppearanceHeader.Options.UseFont = true;
            this.band03.AppearanceHeader.Options.UseForeColor = true;
            this.band03.Caption = "2021";
            this.band03.Columns.Add(this.COL03);
            this.band03.Name = "band03";
            this.band03.VisibleIndex = 3;
            this.band03.Width = 205;
            // 
            // band04
            // 
            this.band04.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.band04.AppearanceHeader.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.band04.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.band04.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.band04.AppearanceHeader.Options.UseBackColor = true;
            this.band04.AppearanceHeader.Options.UseFont = true;
            this.band04.AppearanceHeader.Options.UseForeColor = true;
            this.band04.Caption = "2022";
            this.band04.Columns.Add(this.COL04);
            this.band04.Name = "band04";
            this.band04.VisibleIndex = 4;
            this.band04.Width = 205;
            // 
            // band05
            // 
            this.band05.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.band05.AppearanceHeader.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.band05.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.band05.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.band05.AppearanceHeader.Options.UseBackColor = true;
            this.band05.AppearanceHeader.Options.UseFont = true;
            this.band05.AppearanceHeader.Options.UseForeColor = true;
            this.band05.Caption = "2023";
            this.band05.Columns.Add(this.COL05);
            this.band05.Name = "band05";
            this.band05.VisibleIndex = 5;
            this.band05.Width = 205;
            // 
            // band06
            // 
            this.band06.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.band06.AppearanceHeader.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.band06.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.band06.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.band06.AppearanceHeader.Options.UseBackColor = true;
            this.band06.AppearanceHeader.Options.UseFont = true;
            this.band06.AppearanceHeader.Options.UseForeColor = true;
            this.band06.Caption = "2018";
            this.band06.Columns.Add(this.COL06);
            this.band06.Name = "band06";
            this.band06.VisibleIndex = 6;
            this.band06.Width = 205;
            // 
            // band07
            // 
            this.band07.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.band07.AppearanceHeader.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.band07.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.band07.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.band07.AppearanceHeader.Options.UseBackColor = true;
            this.band07.AppearanceHeader.Options.UseFont = true;
            this.band07.AppearanceHeader.Options.UseForeColor = true;
            this.band07.Caption = "AVG";
            this.band07.Columns.Add(this.COLAVG);
            this.band07.Name = "band07";
            this.band07.VisibleIndex = 7;
            this.band07.Width = 209;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.gridBand1.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand1.Caption = "Target";
            this.gridBand1.Columns.Add(this.TARGET);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Visible = false;
            this.gridBand1.VisibleIndex = -1;
            this.gridBand1.Width = 75;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.gridBand3.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand3.Caption = "%";
            this.gridBand3.Columns.Add(this.RATE);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Visible = false;
            this.gridBand3.VisibleIndex = -1;
            this.gridBand3.Width = 75;
            // 
            // FRM_MGL_BTS_YEARLY
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pnBody);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FRM_MGL_BTS_YEARLY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Load);
            this.VisibleChanged += new System.EventHandler(this.Form_VisibleChanged);
            this.pnHeader.ResumeLayout(false);
            this.pnBody.ResumeLayout(false);
            this.splMain.Panel1.ResumeLayout(false);
            this.splMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spl1)).EndInit();
            this.spl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spl2)).EndInit();
            this.spl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartVSM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrDate;
        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Panel pnBody;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.SplitContainer spl1;
        private System.Windows.Forms.SplitContainer spl2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnYMD;
        private System.Windows.Forms.SplitContainer splMain;
        private System.ComponentModel.BackgroundWorker bgWork;
        private DevExpress.XtraGrid.GridControl grdView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gvwView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn DIV;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL01;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL02;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL03;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL04;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL05;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL06;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COLAVG;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TARGET;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn RATE;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL07;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraCharts.ChartControl ChartVSM;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandDate;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band01;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band02;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band03;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band04;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band05;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band06;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band07;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
    }
}