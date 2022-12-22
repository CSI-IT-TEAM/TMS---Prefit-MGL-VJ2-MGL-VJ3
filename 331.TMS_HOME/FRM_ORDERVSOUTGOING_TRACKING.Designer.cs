namespace FORM
{
    partial class FRM_ORDERVSOUTGOING_TRACKING
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.BarGrowUpAnimation barGrowUpAnimation1 = new DevExpress.XtraCharts.BarGrowUpAnimation();
            DevExpress.XtraCharts.QuinticEasingFunction quinticEasingFunction1 = new DevExpress.XtraCharts.QuinticEasingFunction();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLE = new System.Windows.Forms.Button();
            this.btnLD = new System.Windows.Forms.Button();
            this.pnTrip = new System.Windows.Forms.Panel();
            this.btnTrip4 = new DevExpress.XtraEditors.SimpleButton();
            this.btnTrip3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnTrip2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnTríp1 = new DevExpress.XtraEditors.SimpleButton();
            this.lblTripTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chart = new DevExpress.XtraCharts.ChartControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grdBase = new DevExpress.XtraGrid.GridControl();
            this.gvwBase = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::FORM.WaitForm1), true, true);
            this.tableLayoutPanel1.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnTrip.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwBase)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.52978F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.47022F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1384, 900);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.White;
            this.pnTop.Controls.Add(this.lblTitle);
            this.pnTop.Controls.Add(this.btnBack);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTop.Location = new System.Drawing.Point(3, 3);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1378, 64);
            this.pnTop.TabIndex = 6;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 35F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(9, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(727, 58);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Order vs Outgoing Tracking Report";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnBack.Location = new System.Drawing.Point(10, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(70, 67);
            this.btnBack.TabIndex = 8;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLE);
            this.panel1.Controls.Add(this.btnLD);
            this.panel1.Controls.Add(this.pnTrip);
            this.panel1.Controls.Add(this.lblTripTime);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1378, 64);
            this.panel1.TabIndex = 2;
            // 
            // btnLE
            // 
            this.btnLE.BackColor = System.Drawing.Color.Silver;
            this.btnLE.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLE.Location = new System.Drawing.Point(586, 7);
            this.btnLE.Name = "btnLE";
            this.btnLE.Size = new System.Drawing.Size(63, 50);
            this.btnLE.TabIndex = 421;
            this.btnLE.Tag = "202";
            this.btnLE.Text = "LE";
            this.btnLE.UseVisualStyleBackColor = false;
            this.btnLE.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnLD
            // 
            this.btnLD.BackColor = System.Drawing.Color.Silver;
            this.btnLD.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLD.Location = new System.Drawing.Point(514, 7);
            this.btnLD.Name = "btnLD";
            this.btnLD.Size = new System.Drawing.Size(63, 50);
            this.btnLD.TabIndex = 421;
            this.btnLD.Tag = "201";
            this.btnLD.Text = "LD";
            this.btnLD.UseVisualStyleBackColor = false;
            this.btnLD.Click += new System.EventHandler(this.btn_Click);
            // 
            // pnTrip
            // 
            this.pnTrip.Controls.Add(this.btnTrip4);
            this.pnTrip.Controls.Add(this.btnTrip3);
            this.pnTrip.Controls.Add(this.btnTrip2);
            this.pnTrip.Controls.Add(this.btnTríp1);
            this.pnTrip.Location = new System.Drawing.Point(10, 1);
            this.pnTrip.Name = "pnTrip";
            this.pnTrip.Size = new System.Drawing.Size(295, 61);
            this.pnTrip.TabIndex = 420;
            // 
            // btnTrip4
            // 
            this.btnTrip4.Appearance.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrip4.Appearance.Options.UseFont = true;
            this.btnTrip4.Location = new System.Drawing.Point(212, 6);
            this.btnTrip4.Name = "btnTrip4";
            this.btnTrip4.Size = new System.Drawing.Size(56, 50);
            this.btnTrip4.TabIndex = 24;
            this.btnTrip4.Tag = "004";
            this.btnTrip4.Text = "4th";
            this.btnTrip4.Click += new System.EventHandler(this.btnTrip_Click);
            // 
            // btnTrip3
            // 
            this.btnTrip3.Appearance.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrip3.Appearance.Options.UseFont = true;
            this.btnTrip3.Location = new System.Drawing.Point(150, 6);
            this.btnTrip3.Name = "btnTrip3";
            this.btnTrip3.Size = new System.Drawing.Size(56, 50);
            this.btnTrip3.TabIndex = 25;
            this.btnTrip3.Tag = "003";
            this.btnTrip3.Text = "3rd";
            this.btnTrip3.Click += new System.EventHandler(this.btnTrip_Click);
            // 
            // btnTrip2
            // 
            this.btnTrip2.Appearance.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrip2.Appearance.Options.UseFont = true;
            this.btnTrip2.Location = new System.Drawing.Point(88, 6);
            this.btnTrip2.Name = "btnTrip2";
            this.btnTrip2.Size = new System.Drawing.Size(56, 50);
            this.btnTrip2.TabIndex = 22;
            this.btnTrip2.Tag = "002";
            this.btnTrip2.Text = "2nd";
            this.btnTrip2.Click += new System.EventHandler(this.btnTrip_Click);
            // 
            // btnTríp1
            // 
            this.btnTríp1.Appearance.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTríp1.Appearance.Options.UseFont = true;
            this.btnTríp1.Location = new System.Drawing.Point(26, 6);
            this.btnTríp1.Name = "btnTríp1";
            this.btnTríp1.Size = new System.Drawing.Size(56, 50);
            this.btnTríp1.TabIndex = 23;
            this.btnTríp1.Tag = "001";
            this.btnTríp1.Text = "1st";
            this.btnTríp1.Click += new System.EventHandler(this.btnTrip_Click);
            // 
            // lblTripTime
            // 
            this.lblTripTime.BackColor = System.Drawing.Color.MediumTurquoise;
            this.lblTripTime.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTripTime.Location = new System.Drawing.Point(311, 6);
            this.lblTripTime.Name = "lblTripTime";
            this.lblTripTime.Size = new System.Drawing.Size(104, 51);
            this.lblTripTime.TabIndex = 419;
            this.lblTripTime.Text = "07:30";
            this.lblTripTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Red;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1254, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 51);
            this.label7.TabIndex = 418;
            this.label7.Text = "< 95%";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1092, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 51);
            this.label2.TabIndex = 417;
            this.label2.Text = "95% ~ 98%";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(971, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 51);
            this.label1.TabIndex = 416;
            this.label1.Text = ">= 98%";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 143);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1378, 370);
            this.panel2.TabIndex = 4;
            // 
            // chart
            // 
            this.chart.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chart.DataBindings = null;
            xyDiagram1.AxisX.Title.Text = "Date";
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Title.Text = "%";
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chart.Diagram = xyDiagram1;
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Legend.Name = "Default Legend";
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            sideBySideBarSeriesLabel1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sideBySideBarSeriesLabel1.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;
            sideBySideBarSeriesLabel1.TextPattern = "{V}%";
            series1.Label = sideBySideBarSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Percent";
            barGrowUpAnimation1.Duration = System.TimeSpan.Parse("00:00:00.1000000");
            quinticEasingFunction1.EasingMode = DevExpress.XtraCharts.EasingMode.InOut;
            barGrowUpAnimation1.EasingFunction = quinticEasingFunction1;
            barGrowUpAnimation1.PointDelay = System.TimeSpan.Parse("00:00:01");
            sideBySideBarSeriesView1.Animation = barGrowUpAnimation1;
            series1.View = sideBySideBarSeriesView1;
            this.chart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chart.Size = new System.Drawing.Size(1378, 370);
            this.chart.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grdBase);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 519);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1378, 378);
            this.panel3.TabIndex = 5;
            // 
            // grdBase
            // 
            this.grdBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBase.Location = new System.Drawing.Point(0, 0);
            this.grdBase.MainView = this.gvwBase;
            this.grdBase.Name = "grdBase";
            this.grdBase.Size = new System.Drawing.Size(1378, 378);
            this.grdBase.TabIndex = 4;
            this.grdBase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwBase});
            // 
            // gvwBase
            // 
            this.gvwBase.Appearance.HeaderPanel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvwBase.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvwBase.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvwBase.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvwBase.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvwBase.GridControl = this.grdBase;
            this.gvwBase.Name = "gvwBase";
            this.gvwBase.OptionsBehavior.Editable = false;
            this.gvwBase.OptionsBehavior.ReadOnly = true;
            this.gvwBase.OptionsCustomization.AllowColumnMoving = false;
            this.gvwBase.OptionsCustomization.AllowFilter = false;
            this.gvwBase.OptionsCustomization.AllowGroup = false;
            this.gvwBase.OptionsView.AllowCellMerge = true;
            this.gvwBase.OptionsView.ShowGroupPanel = false;
            this.gvwBase.OptionsView.ShowIndicator = false;
            this.gvwBase.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvwBase_RowCellStyle);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // FRM_ORDERVSOUTGOING_TRACKING
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1384, 900);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "FRM_ORDERVSOUTGOING_TRACKING";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRM_ORDERVSOUTGOING_TRACKING_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnTrip.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTripTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraCharts.ChartControl chart;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraGrid.GridControl grdBase;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwBase;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnTrip;
        private DevExpress.XtraEditors.SimpleButton btnTrip4;
        private DevExpress.XtraEditors.SimpleButton btnTrip3;
        private DevExpress.XtraEditors.SimpleButton btnTrip2;
        private DevExpress.XtraEditors.SimpleButton btnTríp1;
        private System.Windows.Forms.Button btnLE;
        private System.Windows.Forms.Button btnLD;
    }
}