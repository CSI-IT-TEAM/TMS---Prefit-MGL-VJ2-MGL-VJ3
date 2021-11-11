namespace FORM
{
    partial class FRM_TMS_PREFIT_OUTGOING
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
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView2 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDeTotal = new System.Windows.Forms.Label();
            this.lblDeDD = new System.Windows.Forms.Label();
            this.lblDeD1 = new System.Windows.Forms.Label();
            this.lblDeD2 = new System.Windows.Forms.Label();
            this.lblDeD3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.separatorControl4 = new DevExpress.XtraEditors.SeparatorControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.picVJ3 = new System.Windows.Forms.PictureBox();
            this.picVJ2 = new System.Windows.Forms.PictureBox();
            this.picVJ1 = new System.Windows.Forms.PictureBox();
            this.lblTanPhu = new System.Windows.Forms.Label();
            this.lblLongThanh = new System.Windows.Forms.Label();
            this.lblVinhCuu = new System.Windows.Forms.Label();
            this.tmrDate = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVJ3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVJ2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVJ1)).BeginInit();
            this.SuspendLayout();
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
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = global::FORM.Properties.Resources.back;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(5, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(86, 86);
            this.btnBack.TabIndex = 37;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
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
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl7.LineVisible = true;
            this.labelControl7.Location = new System.Drawing.Point(12, 120);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(831, 39);
            this.labelControl7.TabIndex = 64;
            this.labelControl7.Text = "★ OUTGOING BY ASSEMBLY DAY";
            this.labelControl7.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 29);
            this.label1.TabIndex = 68;
            this.label1.Text = "Total Delivery";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LimeGreen;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(148, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 29);
            this.label2.TabIndex = 68;
            this.label2.Text = "D-D";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(255, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 29);
            this.label3.TabIndex = 68;
            this.label3.Text = "D-1";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Red;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(362, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 29);
            this.label4.TabIndex = 68;
            this.label4.Text = "D-2";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(469, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 29);
            this.label5.TabIndex = 68;
            this.label5.Text = "D-3 (Over)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDeTotal
            // 
            this.lblDeTotal.BackColor = System.Drawing.Color.Gray;
            this.lblDeTotal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeTotal.ForeColor = System.Drawing.Color.White;
            this.lblDeTotal.Location = new System.Drawing.Point(9, 203);
            this.lblDeTotal.Name = "lblDeTotal";
            this.lblDeTotal.Size = new System.Drawing.Size(133, 29);
            this.lblDeTotal.TabIndex = 68;
            this.lblDeTotal.Text = "0 Prs";
            this.lblDeTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDeDD
            // 
            this.lblDeDD.BackColor = System.Drawing.Color.LimeGreen;
            this.lblDeDD.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeDD.ForeColor = System.Drawing.Color.White;
            this.lblDeDD.Location = new System.Drawing.Point(148, 203);
            this.lblDeDD.Name = "lblDeDD";
            this.lblDeDD.Size = new System.Drawing.Size(101, 29);
            this.lblDeDD.TabIndex = 68;
            this.lblDeDD.Text = "0 Prs";
            this.lblDeDD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDeD1
            // 
            this.lblDeD1.BackColor = System.Drawing.Color.Yellow;
            this.lblDeD1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeD1.ForeColor = System.Drawing.Color.Black;
            this.lblDeD1.Location = new System.Drawing.Point(255, 203);
            this.lblDeD1.Name = "lblDeD1";
            this.lblDeD1.Size = new System.Drawing.Size(101, 29);
            this.lblDeD1.TabIndex = 68;
            this.lblDeD1.Text = "0 Prs";
            this.lblDeD1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDeD2
            // 
            this.lblDeD2.BackColor = System.Drawing.Color.Red;
            this.lblDeD2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeD2.ForeColor = System.Drawing.Color.White;
            this.lblDeD2.Location = new System.Drawing.Point(362, 203);
            this.lblDeD2.Name = "lblDeD2";
            this.lblDeD2.Size = new System.Drawing.Size(101, 29);
            this.lblDeD2.TabIndex = 68;
            this.lblDeD2.Text = "0 Prs";
            this.lblDeD2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDeD3
            // 
            this.lblDeD3.BackColor = System.Drawing.Color.Black;
            this.lblDeD3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeD3.ForeColor = System.Drawing.Color.White;
            this.lblDeD3.Location = new System.Drawing.Point(469, 203);
            this.lblDeD3.Name = "lblDeD3";
            this.lblDeD3.Size = new System.Drawing.Size(101, 29);
            this.lblDeD3.TabIndex = 68;
            this.lblDeD3.Text = "0 Prs";
            this.lblDeD3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chartControl1);
            this.groupBox1.Controls.Add(this.separatorControl4);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.gridControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 242);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1898, 858);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            // 
            // chartControl1
            // 
            this.chartControl1.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartControl1.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.DataBindings = null;
            xyDiagram2.AxisX.Label.Font = new System.Drawing.Font("Calibri", 12F);
            xyDiagram2.AxisX.Tickmarks.MinorVisible = false;
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.GridLines.Visible = false;
            xyDiagram2.AxisY.Label.Font = new System.Drawing.Font("Calibri", 12F);
            xyDiagram2.AxisY.Label.TextPattern = "{V:#,#}";
            xyDiagram2.AxisY.Title.Text = "Outgoing Qty (Prs)";
            xyDiagram2.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram2.DefaultPane.BorderVisible = false;
            xyDiagram2.Rotated = true;
            this.chartControl1.Diagram = xyDiagram2;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.Location = new System.Drawing.Point(1043, 51);
            this.chartControl1.Name = "chartControl1";
            series2.CrosshairLabelPattern = "{V:#,#}";
            sideBySideBarSeriesLabel2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sideBySideBarSeriesLabel2.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;
            sideBySideBarSeriesLabel2.TextPattern = "{V:#,#}";
            series2.Label = sideBySideBarSeriesLabel2;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Name = "Series 1";
            sideBySideBarSeriesView2.ColorEach = true;
            series2.View = sideBySideBarSeriesView2;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.chartControl1.Size = new System.Drawing.Size(837, 748);
            this.chartControl1.TabIndex = 72;
            // 
            // separatorControl4
            // 
            this.separatorControl4.LineColor = System.Drawing.SystemColors.ButtonShadow;
            this.separatorControl4.LineOrientation = System.Windows.Forms.Orientation.Vertical;
            this.separatorControl4.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.separatorControl4.LineThickness = 3;
            this.separatorControl4.Location = new System.Drawing.Point(1013, 9);
            this.separatorControl4.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
            this.separatorControl4.Name = "separatorControl4";
            this.separatorControl4.Size = new System.Drawing.Size(24, 803);
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
            this.labelControl2.Location = new System.Drawing.Point(1043, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(849, 39);
            this.labelControl2.TabIndex = 40;
            this.labelControl2.Text = "★  OUTGOING TODAY CHART";
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
            this.labelControl1.Text = "★  OUTGOING TODAY";
            this.labelControl1.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(11, 51);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(996, 748);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.ColumnPanelRowHeight = 40;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 35;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "Plant";
            this.gridColumn1.FieldName = "LINE_NM";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 78;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "Model Name";
            this.gridColumn2.FieldName = "MODEL_NM";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 298;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "Style Code";
            this.gridColumn3.FieldName = "STYLE_CD";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 123;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.Caption = "PFC Part Name";
            this.gridColumn4.FieldName = "PFC_PART_NM";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 284;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn5.Caption = "PFC No.";
            this.gridColumn5.FieldName = "PFC_PART_NO";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 80;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn6.Caption = "Outgoing Qty";
            this.gridColumn6.FieldName = "PS_QTY";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 115;
            // 
            // picVJ3
            // 
            this.picVJ3.Image = global::FORM.Properties.Resources.VJ3;
            this.picVJ3.Location = new System.Drawing.Point(1452, 88);
            this.picVJ3.Name = "picVJ3";
            this.picVJ3.Size = new System.Drawing.Size(240, 122);
            this.picVJ3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVJ3.TabIndex = 72;
            this.picVJ3.TabStop = false;
            this.picVJ3.Tag = "3";
            this.picVJ3.Click += new System.EventHandler(this.picVJ_Click);
            // 
            // picVJ2
            // 
            this.picVJ2.Image = global::FORM.Properties.Resources.VJ2;
            this.picVJ2.Location = new System.Drawing.Point(1191, 88);
            this.picVJ2.Name = "picVJ2";
            this.picVJ2.Size = new System.Drawing.Size(240, 122);
            this.picVJ2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVJ2.TabIndex = 71;
            this.picVJ2.TabStop = false;
            this.picVJ2.Tag = "2";
            this.picVJ2.Click += new System.EventHandler(this.picVJ_Click);
            // 
            // picVJ1
            // 
            this.picVJ1.Image = global::FORM.Properties.Resources.VJ;
            this.picVJ1.Location = new System.Drawing.Point(934, 88);
            this.picVJ1.Name = "picVJ1";
            this.picVJ1.Size = new System.Drawing.Size(240, 122);
            this.picVJ1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVJ1.TabIndex = 70;
            this.picVJ1.TabStop = false;
            this.picVJ1.Tag = "1";
            this.picVJ1.Click += new System.EventHandler(this.picVJ_Click);
            // 
            // lblTanPhu
            // 
            this.lblTanPhu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(33)))), ((int)(((byte)(60)))));
            this.lblTanPhu.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanPhu.ForeColor = System.Drawing.Color.White;
            this.lblTanPhu.Location = new System.Drawing.Point(1610, 88);
            this.lblTanPhu.Name = "lblTanPhu";
            this.lblTanPhu.Size = new System.Drawing.Size(82, 26);
            this.lblTanPhu.TabIndex = 78;
            this.lblTanPhu.Text = "Tân Phú";
            this.lblTanPhu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLongThanh
            // 
            this.lblLongThanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(33)))), ((int)(((byte)(60)))));
            this.lblLongThanh.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongThanh.ForeColor = System.Drawing.Color.White;
            this.lblLongThanh.Location = new System.Drawing.Point(1318, 88);
            this.lblLongThanh.Name = "lblLongThanh";
            this.lblLongThanh.Size = new System.Drawing.Size(113, 26);
            this.lblLongThanh.TabIndex = 79;
            this.lblLongThanh.Text = "Long Thành";
            this.lblLongThanh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVinhCuu
            // 
            this.lblVinhCuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(33)))), ((int)(((byte)(60)))));
            this.lblVinhCuu.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVinhCuu.ForeColor = System.Drawing.Color.White;
            this.lblVinhCuu.Location = new System.Drawing.Point(1079, 88);
            this.lblVinhCuu.Name = "lblVinhCuu";
            this.lblVinhCuu.Size = new System.Drawing.Size(95, 26);
            this.lblVinhCuu.TabIndex = 80;
            this.lblVinhCuu.Text = "Vĩnh Cửu";
            this.lblVinhCuu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrDate
            // 
            this.tmrDate.Enabled = true;
            this.tmrDate.Interval = 1000;
            this.tmrDate.Tick += new System.EventHandler(this.tmrDate_Tick);
            // 
            // FRM_TMS_PREFIT_OUTGOING
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.lblVinhCuu);
            this.Controls.Add(this.lblLongThanh);
            this.Controls.Add(this.lblTanPhu);
            this.Controls.Add(this.picVJ3);
            this.Controls.Add(this.picVJ2);
            this.Controls.Add(this.picVJ1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDeD3);
            this.Controls.Add(this.lblDeD2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblDeD1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDeDD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDeTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_TMS_PREFIT_OUTGOING";
            this.Text = "FRM_TMS_PREFIT_OUTGOING";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.VisibleChanged += new System.EventHandler(this.FRM_TMS_PREFIT_OUTGOING_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVJ3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVJ2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVJ1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private System.Windows.Forms.Label lblDate;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDeTotal;
        private System.Windows.Forms.Label lblDeDD;
        private System.Windows.Forms.Label lblDeD1;
        private System.Windows.Forms.Label lblDeD2;
        private System.Windows.Forms.Label lblDeD3;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SeparatorControl separatorControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.PictureBox picVJ3;
        private System.Windows.Forms.PictureBox picVJ2;
        private System.Windows.Forms.PictureBox picVJ1;
        private System.Windows.Forms.Label lblTanPhu;
        private System.Windows.Forms.Label lblLongThanh;
        private System.Windows.Forms.Label lblVinhCuu;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.Windows.Forms.Timer tmrDate;
    }
}