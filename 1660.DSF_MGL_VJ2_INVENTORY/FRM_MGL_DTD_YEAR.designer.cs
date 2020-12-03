namespace FORM
{
    partial class FRM_MGL_DTD_YEAR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_MGL_DTD_YEAR));
            DevExpress.XtraCharts.XYDiagram xyDiagram5 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series5 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel3 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView3 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle5 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.XYDiagram xyDiagram6 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series6 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel3 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.ChartTitle chartTitle6 = new DevExpress.XtraCharts.ChartTitle();
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
            ((System.ComponentModel.ISupportInitialize)(xyDiagram5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel3)).BeginInit();
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
            this.lblTitle.Text = "Dock To Dock (DTD) By Year";
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
            this.splitMain.SplitterDistance = 156;
            this.splitMain.TabIndex = 14;
            // 
            // axfpDTD
            // 
            this.axfpDTD.DataSource = null;
            this.axfpDTD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axfpDTD.Location = new System.Drawing.Point(0, 0);
            this.axfpDTD.Name = "axfpDTD";
            this.axfpDTD.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfpDTD.OcxState")));
            this.axfpDTD.Size = new System.Drawing.Size(1904, 156);
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
            this.splitChart.Size = new System.Drawing.Size(1904, 772);
            this.splitChart.SplitterDistance = 934;
            this.splitChart.TabIndex = 0;
            // 
            // chartWIP
            // 
            this.chartWIP.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartWIP.DataBindings = null;
            xyDiagram5.AxisX.Label.ResolveOverlappingOptions.AllowHide = false;
            xyDiagram5.AxisX.Label.ResolveOverlappingOptions.MinIndent = 1;
            xyDiagram5.AxisX.MinorCount = 1;
            xyDiagram5.AxisX.Title.Text = "Date";
            xyDiagram5.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram5.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram5.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram5.AxisY.Title.Text = "Days";
            xyDiagram5.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram5.AxisY.VisibleInPanesSerializable = "-1";
            this.chartWIP.Diagram = xyDiagram5;
            this.chartWIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartWIP.Legend.Name = "Default Legend";
            this.chartWIP.Location = new System.Drawing.Point(0, 0);
            this.chartWIP.Name = "chartWIP";
            pointSeriesLabel3.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.JustifyAroundPoint;
            series5.Label = pointSeriesLabel3;
            series5.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series5.Name = "Days";
            lineSeriesView3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            lineSeriesView3.LineMarkerOptions.Kind = DevExpress.XtraCharts.MarkerKind.Star;
            lineSeriesView3.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series5.View = lineSeriesView3;
            this.chartWIP.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series5};
            this.chartWIP.Size = new System.Drawing.Size(934, 772);
            this.chartWIP.TabIndex = 0;
            chartTitle5.Text = "WIP";
            this.chartWIP.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle5});
            this.chartWIP.CustomDrawAxisLabel += new DevExpress.XtraCharts.CustomDrawAxisLabelEventHandler(this.CustomDrawAxisLabel);
            // 
            // chartLT
            // 
            this.chartLT.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartLT.DataBindings = null;
            xyDiagram6.AxisX.Title.Text = "True";
            xyDiagram6.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram6.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram6.AxisY.Title.Text = "Days";
            xyDiagram6.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram6.AxisY.VisibleInPanesSerializable = "-1";
            this.chartLT.Diagram = xyDiagram6;
            this.chartLT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartLT.Legend.Name = "Default Legend";
            this.chartLT.Location = new System.Drawing.Point(0, 0);
            this.chartLT.Name = "chartLT";
            sideBySideBarSeriesLabel3.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;
            sideBySideBarSeriesLabel3.TextOrientation = DevExpress.XtraCharts.TextOrientation.TopToBottom;
            series6.Label = sideBySideBarSeriesLabel3;
            series6.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series6.Name = "LeadTime";
            this.chartLT.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series6};
            this.chartLT.Size = new System.Drawing.Size(966, 772);
            this.chartLT.TabIndex = 0;
            chartTitle6.Text = "DTD (Dock To Dock)";
            chartTitle6.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartLT.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle6});
            this.chartLT.CustomDrawAxisLabel += new DevExpress.XtraCharts.CustomDrawAxisLabelEventHandler(this.CustomDrawAxisLabel);
            // 
            // pnYMD
            // 
            this.pnYMD.Location = new System.Drawing.Point(1183, 6);
            this.pnYMD.Name = "pnYMD";
            this.pnYMD.Size = new System.Drawing.Size(450, 96);
            this.pnYMD.TabIndex = 55;
            // 
            // FRM_MGL_DTD_YEAR
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1904, 1042);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnHeader);
            this.Name = "FRM_MGL_DTD_YEAR";
            this.Text = "FRM_SMT_DTD_YEAR";
            this.Load += new System.EventHandler(this.FRM_SMT_DTD_YEAR_Load);
            this.VisibleChanged += new System.EventHandler(this.FRM_SMT_DTD_YEAR_VisibleChanged);
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
            ((System.ComponentModel.ISupportInitialize)(xyDiagram5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartWIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).EndInit();
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