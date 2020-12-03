namespace FORM
{
    partial class FRM_MGL_DTD_MONTH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_MGL_DTD_MONTH));
            DevExpress.XtraCharts.XYDiagram xyDiagram7 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series7 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel4 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView4 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle7 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.XYDiagram xyDiagram8 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series8 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel4 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.ChartTitle chartTitle8 = new DevExpress.XtraCharts.ChartTitle();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.tmrDate = new System.Windows.Forms.Timer();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.axfpDTD = new AxFPUSpreadADO.AxfpSpread();
            this.splitChart = new System.Windows.Forms.SplitContainer();
            this.chartWIP = new DevExpress.XtraCharts.ChartControl();
            this.chartLT = new DevExpress.XtraCharts.ChartControl();
            this.pnYMD = new System.Windows.Forms.Panel();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axfpDTD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitChart)).BeginInit();
            this.splitChart.Panel1.SuspendLayout();
            this.splitChart.Panel2.SuspendLayout();
            this.splitChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartWIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel4)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.DarkTurquoise;
            this.pnHeader.Controls.Add(this.pnYMD);
            this.pnHeader.Controls.Add(this.lblDate);
            this.pnHeader.Controls.Add(this.lblTitle);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1904, 110);
            this.pnHeader.TabIndex = 13;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.BackColor = System.Drawing.Color.DarkTurquoise;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 32.25F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblDate.Location = new System.Drawing.Point(1660, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(253, 106);
            this.lblDate.TabIndex = 49;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Calibri", 62F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Options.UseBackColor = true;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTitle.LineColor = System.Drawing.Color.DarkTurquoise;
            this.lblTitle.LineVisible = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1901, 107);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Dock To Dock (DTD) By Month";
            // 
            // tmrDate
            // 
            this.tmrDate.Interval = 1000;
            this.tmrDate.Tick += new System.EventHandler(this.tmrDate_Tick);
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 110);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.axfpDTD);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.splitChart);
            this.splitMain.Size = new System.Drawing.Size(1904, 932);
            this.splitMain.SplitterDistance = 376;
            this.splitMain.TabIndex = 14;
            // 
            // axfpDTD
            // 
            this.axfpDTD.DataSource = null;
            this.axfpDTD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axfpDTD.Location = new System.Drawing.Point(0, 0);
            this.axfpDTD.Name = "axfpDTD";
            this.axfpDTD.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfpDTD.OcxState")));
            this.axfpDTD.Size = new System.Drawing.Size(1904, 376);
            this.axfpDTD.TabIndex = 0;
            // 
            // splitChart
            // 
            this.splitChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitChart.Location = new System.Drawing.Point(0, 0);
            this.splitChart.Name = "splitChart";
            // 
            // splitChart.Panel1
            // 
            this.splitChart.Panel1.Controls.Add(this.chartWIP);
            // 
            // splitChart.Panel2
            // 
            this.splitChart.Panel2.Controls.Add(this.chartLT);
            this.splitChart.Size = new System.Drawing.Size(1904, 552);
            this.splitChart.SplitterDistance = 934;
            this.splitChart.TabIndex = 0;
            // 
            // chartWIP
            // 
            this.chartWIP.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartWIP.DataBindings = null;
            xyDiagram7.AxisX.Label.ResolveOverlappingOptions.AllowHide = false;
            xyDiagram7.AxisX.Label.ResolveOverlappingOptions.MinIndent = 1;
            xyDiagram7.AxisX.MinorCount = 1;
            xyDiagram7.AxisX.Title.Text = "Date";
            xyDiagram7.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram7.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram7.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram7.AxisY.Title.Text = "Days";
            xyDiagram7.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram7.AxisY.VisibleInPanesSerializable = "-1";
            this.chartWIP.Diagram = xyDiagram7;
            this.chartWIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartWIP.Legend.Name = "Default Legend";
            this.chartWIP.Location = new System.Drawing.Point(0, 0);
            this.chartWIP.Name = "chartWIP";
            pointSeriesLabel4.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.JustifyAroundPoint;
            series7.Label = pointSeriesLabel4;
            series7.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series7.Name = "Days";
            lineSeriesView4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            lineSeriesView4.LineMarkerOptions.Kind = DevExpress.XtraCharts.MarkerKind.Star;
            lineSeriesView4.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series7.View = lineSeriesView4;
            this.chartWIP.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series7};
            this.chartWIP.Size = new System.Drawing.Size(934, 552);
            this.chartWIP.TabIndex = 0;
            chartTitle7.Text = "WIP";
            this.chartWIP.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle7});
            this.chartWIP.CustomDrawAxisLabel += new DevExpress.XtraCharts.CustomDrawAxisLabelEventHandler(this.CustomDrawAxisLabel);
            // 
            // chartLT
            // 
            this.chartLT.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartLT.DataBindings = null;
            xyDiagram8.AxisX.Title.Text = "True";
            xyDiagram8.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram8.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram8.AxisY.Title.Text = "Days";
            xyDiagram8.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram8.AxisY.VisibleInPanesSerializable = "-1";
            this.chartLT.Diagram = xyDiagram8;
            this.chartLT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartLT.Legend.Name = "Default Legend";
            this.chartLT.Location = new System.Drawing.Point(0, 0);
            this.chartLT.Name = "chartLT";
            sideBySideBarSeriesLabel4.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;
            sideBySideBarSeriesLabel4.TextOrientation = DevExpress.XtraCharts.TextOrientation.TopToBottom;
            series8.Label = sideBySideBarSeriesLabel4;
            series8.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series8.Name = "LeadTime";
            this.chartLT.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series8};
            this.chartLT.Size = new System.Drawing.Size(966, 552);
            this.chartLT.TabIndex = 0;
            chartTitle8.Text = "DTD (Dock To Dock)";
            chartTitle8.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartLT.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle8});
            this.chartLT.CustomDrawAxisLabel += new DevExpress.XtraCharts.CustomDrawAxisLabelEventHandler(this.CustomDrawAxisLabel);
            // 
            // pnYMD
            // 
            this.pnYMD.Location = new System.Drawing.Point(1183, 6);
            this.pnYMD.Name = "pnYMD";
            this.pnYMD.Size = new System.Drawing.Size(450, 96);
            this.pnYMD.TabIndex = 54;
            // 
            // FRM_MGL_DTD_MONTH
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1904, 1042);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnHeader);
            this.Name = "FRM_MGL_DTD_MONTH";
            this.Text = "FRM_SMT_DTD_MONTH";
            this.Load += new System.EventHandler(this.FRM_SMT_DTD_MONTH_Load);
            this.VisibleChanged += new System.EventHandler(this.FRM_SMT_DTD_MONTH_VisibleChanged);
            this.pnHeader.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axfpDTD)).EndInit();
            this.splitChart.Panel1.ResumeLayout(false);
            this.splitChart.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitChart)).EndInit();
            this.splitChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartWIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Label lblDate;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private System.Windows.Forms.Timer tmrDate;
        private System.Windows.Forms.SplitContainer splitMain;
        private AxFPUSpreadADO.AxfpSpread axfpDTD;
        private System.Windows.Forms.SplitContainer splitChart;
        private DevExpress.XtraCharts.ChartControl chartWIP;
        private DevExpress.XtraCharts.ChartControl chartLT;
        private System.Windows.Forms.Panel pnYMD;
    }
}