namespace FORM
{
    partial class FRM_MGL_HR_ABSENT
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
            DevExpress.XtraCharts.SimpleDiagram simpleDiagram1 = new DevExpress.XtraCharts.SimpleDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel1 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.PieFlyInAnimation pieFlyInAnimation1 = new DevExpress.XtraCharts.PieFlyInAnimation();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_MGL_HR_ABSENT));
            this.pnHeader = new System.Windows.Forms.Panel();
            this.pnYMD = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.tmrDate = new System.Windows.Forms.Timer(this.components);
            this.arcScaleComponent2 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.arcScaleBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent();
            this.arcScaleComponentRub = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent();
            this.labelComponent1 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.lblRubValueG = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.lblTitleGauges = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.arcScaleNeedleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent();
            this.arcScaleSpindleCapComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent();
            this.chartHrCmp = new DevExpress.XtraCharts.ChartControl();
            this.label21 = new System.Windows.Forms.Label();
            this.lblAbenst2 = new System.Windows.Forms.Label();
            this.lblAbenst1 = new System.Windows.Forms.Label();
            this.lblTotAbsent = new System.Windows.Forms.Label();
            this.uc_year = new FORM.UC.UC_YEAR_SELECTION();
            this.uc_month = new FORM.UC.UC_MONTH_SELECTION();
            this.cGauge1 = new DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge();
            this.axfpAbsent = new AxFPSpreadADO.AxfpSpread();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleComponent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleComponentRub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRubValueG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitleGauges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleSpindleCapComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHrCmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfpAbsent)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pnHeader.Controls.Add(this.pnYMD);
            this.pnHeader.Controls.Add(this.lblDate);
            this.pnHeader.Controls.Add(this.lblTitle);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1924, 110);
            this.pnHeader.TabIndex = 12;
            // 
            // pnYMD
            // 
            this.pnYMD.Location = new System.Drawing.Point(1183, 6);
            this.pnYMD.Name = "pnYMD";
            this.pnYMD.Size = new System.Drawing.Size(450, 96);
            this.pnYMD.TabIndex = 50;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblDate.Font = new System.Drawing.Font("Calibri", 32.25F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblDate.Location = new System.Drawing.Point(1660, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(273, 106);
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
            this.lblTitle.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblTitle.LineVisible = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1901, 107);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Human Absenteeism by Month";
            // 
            // tmrDate
            // 
            this.tmrDate.Interval = 1000;
            this.tmrDate.Tick += new System.EventHandler(this.tmrDate_Tick);
            // 
            // arcScaleComponent2
            // 
            this.arcScaleComponent2.AppearanceMajorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent2.AppearanceMajorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent2.AppearanceMinorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent2.AppearanceMinorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent2.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Gainsboro");
            this.arcScaleComponent2.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 165F);
            this.arcScaleComponent2.EndAngle = 0F;
            this.arcScaleComponent2.MajorTickCount = 7;
            this.arcScaleComponent2.MajorTickmark.FormatString = "{0:F0}";
            this.arcScaleComponent2.MajorTickmark.ShapeOffset = -2F;
            this.arcScaleComponent2.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style13_2;
            this.arcScaleComponent2.MajorTickmark.TextOffset = -15F;
            this.arcScaleComponent2.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
            this.arcScaleComponent2.MaxValue = 800F;
            this.arcScaleComponent2.MinorTickCount = 4;
            this.arcScaleComponent2.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style13_1;
            this.arcScaleComponent2.MinValue = 200F;
            this.arcScaleComponent2.Name = "scale2";
            this.arcScaleComponent2.RadiusX = 65F;
            this.arcScaleComponent2.RadiusY = 65F;
            this.arcScaleComponent2.StartAngle = -180F;
            this.arcScaleComponent2.Value = 300F;
            this.arcScaleComponent2.ZOrder = -1;
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.AutoLayout = false;
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.cGauge1});
            this.gaugeControl1.Location = new System.Drawing.Point(18, 677);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(929, 380);
            this.gaugeControl1.TabIndex = 18;
            // 
            // arcScaleBackgroundLayerComponent1
            // 
            this.arcScaleBackgroundLayerComponent1.ArcScale = this.arcScaleComponentRub;
            this.arcScaleBackgroundLayerComponent1.Name = "bg1";
            this.arcScaleBackgroundLayerComponent1.ScaleCenterPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.7F);
            this.arcScaleBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.CircularHalf_Style4;
            this.arcScaleBackgroundLayerComponent1.Size = new System.Drawing.SizeF(350F, 248F);
            this.arcScaleBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // arcScaleComponentRub
            // 
            this.arcScaleComponentRub.AppearanceMajorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponentRub.AppearanceMajorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponentRub.AppearanceMinorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponentRub.AppearanceMinorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponentRub.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.arcScaleComponentRub.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.arcScaleComponentRub.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(151F, 150F);
            this.arcScaleComponentRub.EndAngle = 0F;
            this.arcScaleComponentRub.MajorTickmark.FormatString = "{0:F0}";
            this.arcScaleComponentRub.MajorTickmark.ShapeOffset = -14F;
            this.arcScaleComponentRub.MajorTickmark.ShapeScale = new DevExpress.XtraGauges.Core.Base.FactorF2D(0.6F, 0.8F);
            this.arcScaleComponentRub.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style4_2;
            this.arcScaleComponentRub.MajorTickmark.TextOffset = -40F;
            this.arcScaleComponentRub.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
            this.arcScaleComponentRub.MaxValue = 10F;
            this.arcScaleComponentRub.MinorTickCount = 0;
            this.arcScaleComponentRub.MinorTickmark.ShapeOffset = -7F;
            this.arcScaleComponentRub.MinorTickmark.ShapeScale = new DevExpress.XtraGauges.Core.Base.FactorF2D(0.6F, 1F);
            this.arcScaleComponentRub.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style4_1;
            this.arcScaleComponentRub.MinorTickmark.ShowTick = false;
            this.arcScaleComponentRub.Name = "scale1";
            this.arcScaleComponentRub.RadiusX = 170F;
            this.arcScaleComponentRub.RadiusY = 170F;
            this.arcScaleComponentRub.StartAngle = -180F;
            this.arcScaleComponentRub.Value = 6F;
            // 
            // labelComponent1
            // 
            this.labelComponent1.Name = "labelComponent1";
            // 
            // lblRubValueG
            // 
            this.lblRubValueG.AppearanceText.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRubValueG.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.lblRubValueG.Name = "cGauge1_Label2";
            this.lblRubValueG.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(150.3F, 90.1F);
            this.lblRubValueG.Size = new System.Drawing.SizeF(125F, 50F);
            this.lblRubValueG.ZOrder = -1001;
            // 
            // lblTitleGauges
            // 
            this.lblTitleGauges.AppearanceText.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lblTitleGauges.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.lblTitleGauges.Name = "cGauge1_Label3";
            this.lblTitleGauges.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(160.4F, -50.7F);
            this.lblTitleGauges.Size = new System.Drawing.SizeF(300F, 25F);
            this.lblTitleGauges.Text = "Attendance AVG (%)";
            this.lblTitleGauges.ZOrder = -1001;
            // 
            // arcScaleNeedleComponent1
            // 
            this.arcScaleNeedleComponent1.ArcScale = this.arcScaleComponentRub;
            this.arcScaleNeedleComponent1.EndOffset = 5F;
            this.arcScaleNeedleComponent1.Name = "needle1";
            this.arcScaleNeedleComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.NeedleShapeType.CircularFull_Style4;
            this.arcScaleNeedleComponent1.StartOffset = -21F;
            this.arcScaleNeedleComponent1.ZOrder = -50;
            // 
            // arcScaleSpindleCapComponent1
            // 
            this.arcScaleSpindleCapComponent1.ArcScale = this.arcScaleComponentRub;
            this.arcScaleSpindleCapComponent1.Name = "cap1";
            this.arcScaleSpindleCapComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.SpindleCapShapeType.CircularFull_Style4;
            this.arcScaleSpindleCapComponent1.Size = new System.Drawing.SizeF(16F, 16F);
            this.arcScaleSpindleCapComponent1.ZOrder = -100;
            // 
            // chartHrCmp
            // 
            this.chartHrCmp.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartHrCmp.BackColor = System.Drawing.Color.Transparent;
            this.chartHrCmp.DataBindings = null;
            simpleDiagram1.LabelsResolveOverlappingMinIndent = 40;
            this.chartHrCmp.Diagram = simpleDiagram1;
            this.chartHrCmp.IndicatorsPaletteName = "Palette 1";
            this.chartHrCmp.IndicatorsPaletteRepository.Add("Palette 1", new DevExpress.XtraCharts.Palette("Palette 1", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Red, System.Drawing.Color.Red),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Green, System.Drawing.Color.Green)}));
            this.chartHrCmp.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;
            this.chartHrCmp.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Center;
            this.chartHrCmp.Legend.Font = new System.Drawing.Font("Tahoma", 12F);
            this.chartHrCmp.Legend.Name = "Default Legend";
            this.chartHrCmp.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartHrCmp.Location = new System.Drawing.Point(963, 677);
            this.chartHrCmp.Name = "chartHrCmp";
            this.chartHrCmp.PaletteName = "Absent_Red";
            this.chartHrCmp.PaletteRepository.Add("Absent_Blue", new DevExpress.XtraCharts.Palette("Absent_Blue", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.DodgerBlue, System.Drawing.Color.DodgerBlue),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Green, System.Drawing.Color.Green)}));
            this.chartHrCmp.PaletteRepository.Add("Absent_Red", new DevExpress.XtraCharts.Palette("Absent_Red", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Yellow, System.Drawing.Color.Yellow),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Red, System.Drawing.Color.Red),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Green, System.Drawing.Color.Green)}));
            pieSeriesLabel1.Border.Color = System.Drawing.Color.Black;
            pieSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
            pieSeriesLabel1.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
            pieSeriesLabel1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Gradient;
            pieSeriesLabel1.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            pieSeriesLabel1.LineLength = 0;
            pieSeriesLabel1.LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            pieSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
            pieSeriesLabel1.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.TwoColumns;
            pieSeriesLabel1.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
            pieSeriesLabel1.TextColor = System.Drawing.Color.Black;
            pieSeriesLabel1.TextPattern = "{V:#,0} Person(s)\n{VP:0.0%}\n";
            series1.Label = pieSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Series 1";
            pieSeriesView1.Animation = pieFlyInAnimation1;
            pieSeriesView1.MinAllowedSizePercentage = 10D;
            pieSeriesView1.Rotation = 90;
            series1.View = pieSeriesView1;
            this.chartHrCmp.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartHrCmp.Size = new System.Drawing.Size(941, 380);
            this.chartHrCmp.TabIndex = 19;
            chartTitle1.Font = new System.Drawing.Font("Tahoma", 20F);
            chartTitle1.Text = "Rubber";
            chartTitle1.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartHrCmp.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Green;
            this.label21.Font = new System.Drawing.Font("Calibri", 12.25F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(1375, 646);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(165, 28);
            this.label21.TabIndex = 57;
            this.label21.Text = "Attended";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAbenst2
            // 
            this.lblAbenst2.BackColor = System.Drawing.Color.Red;
            this.lblAbenst2.Font = new System.Drawing.Font("Calibri", 12.25F, System.Drawing.FontStyle.Bold);
            this.lblAbenst2.ForeColor = System.Drawing.Color.White;
            this.lblAbenst2.Location = new System.Drawing.Point(1711, 646);
            this.lblAbenst2.Name = "lblAbenst2";
            this.lblAbenst2.Size = new System.Drawing.Size(193, 28);
            this.lblAbenst2.TabIndex = 56;
            this.lblAbenst2.Text = "Unplanned Absenteeism";
            this.lblAbenst2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAbenst1
            // 
            this.lblAbenst1.BackColor = System.Drawing.Color.Yellow;
            this.lblAbenst1.Font = new System.Drawing.Font("Calibri", 12.25F, System.Drawing.FontStyle.Bold);
            this.lblAbenst1.ForeColor = System.Drawing.Color.Black;
            this.lblAbenst1.Location = new System.Drawing.Point(1542, 646);
            this.lblAbenst1.Name = "lblAbenst1";
            this.lblAbenst1.Size = new System.Drawing.Size(165, 28);
            this.lblAbenst1.TabIndex = 55;
            this.lblAbenst1.Text = "Plan Absenteeism";
            this.lblAbenst1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotAbsent
            // 
            this.lblTotAbsent.AutoSize = true;
            this.lblTotAbsent.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotAbsent.ForeColor = System.Drawing.Color.Black;
            this.lblTotAbsent.Location = new System.Drawing.Point(1751, 695);
            this.lblTotAbsent.Name = "lblTotAbsent";
            this.lblTotAbsent.Size = new System.Drawing.Size(109, 23);
            this.lblTotAbsent.TabIndex = 58;
            this.lblTotAbsent.Text = "Total Absent";
            this.lblTotAbsent.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // uc_year
            // 
            this.uc_year.AutoSize = true;
            this.uc_year.Location = new System.Drawing.Point(10, 121);
            this.uc_year.Name = "uc_year";
            this.uc_year.Size = new System.Drawing.Size(229, 47);
            this.uc_year.TabIndex = 60;
            // 
            // uc_month
            // 
            this.uc_month.AutoSize = true;
            this.uc_month.Location = new System.Drawing.Point(5, 118);
            this.uc_month.Name = "uc_month";
            this.uc_month.Size = new System.Drawing.Size(472, 46);
            this.uc_month.TabIndex = 59;
            this.uc_month.ValueChangeEvent += new System.EventHandler(this.uc_month_ValueChangeEvent);
            // 
            // cGauge1
            // 
            this.cGauge1.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent[] {
            this.arcScaleBackgroundLayerComponent1});
            this.cGauge1.Bounds = new System.Drawing.Rectangle(6, 6, 916, 370);
            this.cGauge1.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.labelComponent1,
            this.lblRubValueG,
            this.lblTitleGauges});
            this.cGauge1.Name = "cGauge1";
            this.cGauge1.Needles.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent[] {
            this.arcScaleNeedleComponent1});
            this.cGauge1.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent[] {
            this.arcScaleComponentRub});
            this.cGauge1.SpindleCaps.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent[] {
            this.arcScaleSpindleCapComponent1});
            // 
            // axfpAbsent
            // 
            this.axfpAbsent.DataSource = null;
            this.axfpAbsent.Location = new System.Drawing.Point(5, 170);
            this.axfpAbsent.Name = "axfpAbsent";
            this.axfpAbsent.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfpAbsent.OcxState")));
            this.axfpAbsent.Size = new System.Drawing.Size(1914, 473);
            this.axfpAbsent.TabIndex = 0;
            // 
            // FRM_MGL_HR_ABSENT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.uc_year);
            this.Controls.Add(this.uc_month);
            this.Controls.Add(this.lblTotAbsent);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lblAbenst2);
            this.Controls.Add(this.lblAbenst1);
            this.Controls.Add(this.chartHrCmp);
            this.Controls.Add(this.gaugeControl1);
            this.Controls.Add(this.pnHeader);
            this.Controls.Add(this.axfpAbsent);
            this.Name = "FRM_MGL_HR_ABSENT";
            this.Text = "FRM_SMT_HR_ABSENT";
            this.Load += new System.EventHandler(this.FRM_SMT_HR_ABSENT_Load);
            this.VisibleChanged += new System.EventHandler(this.FRM_SMT_HR_ABSENT_VisibleChanged);
            this.pnHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleComponent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleComponentRub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRubValueG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitleGauges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleSpindleCapComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHrCmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfpAbsent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Label lblDate;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private AxFPSpreadADO.AxfpSpread axfpAbsent;
        private System.Windows.Forms.Timer tmrDate;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent arcScaleComponent2;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge cGauge1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent arcScaleBackgroundLayerComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent arcScaleComponentRub;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent1;
        private DevExpress.XtraGauges.Win.Base.LabelComponent lblRubValueG;
        private DevExpress.XtraGauges.Win.Base.LabelComponent lblTitleGauges;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent arcScaleNeedleComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent arcScaleSpindleCapComponent1;
        private DevExpress.XtraCharts.ChartControl chartHrCmp;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblAbenst2;
        private System.Windows.Forms.Label lblAbenst1;
        private System.Windows.Forms.Label lblTotAbsent;
        private UC.UC_MONTH_SELECTION uc_month;
        private UC.UC_YEAR_SELECTION uc_year;
        private System.Windows.Forms.Panel pnYMD;
    }
}