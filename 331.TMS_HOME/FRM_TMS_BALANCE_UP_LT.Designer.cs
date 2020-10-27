namespace FORM
{
    partial class FRM_TMS_BALANCE_UP_LT
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
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tmrDate = new System.Windows.Forms.Timer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdBase = new DevExpress.XtraGrid.GridControl();
            this.gvwBase1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gvwBase = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::FORM.WaitForm1), true, true);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwBase1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwBase)).BeginInit();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
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
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(86, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1268, 65);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "COMPONENT NOT YET INCOMING";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmrDate
            // 
            this.tmrDate.Enabled = true;
            this.tmrDate.Interval = 1000;
            this.tmrDate.Tick += new System.EventHandler(this.tmrDate_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.grdBase, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnTop, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1904, 1041);
            this.tableLayoutPanel1.TabIndex = 37;
            // 
            // grdBase
            // 
            this.grdBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBase.Location = new System.Drawing.Point(3, 103);
            this.grdBase.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdBase.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.grdBase.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdBase.MainView = this.gvwBase1;
            this.grdBase.Name = "grdBase";
            this.grdBase.Size = new System.Drawing.Size(1898, 935);
            this.grdBase.TabIndex = 37;
            this.grdBase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwBase1,
            this.gridView,
            this.gvwBase});
            // 
            // gvwBase1
            // 
            this.gvwBase1.Appearance.BandPanel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvwBase1.Appearance.BandPanel.Options.UseFont = true;
            this.gvwBase1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvwBase1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvwBase1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvwBase1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.SkyBlue;
            this.gvwBase1.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.PowderBlue;
            this.gvwBase1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gvwBase1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvwBase1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvwBase1.Appearance.Row.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gvwBase1.Appearance.Row.Options.UseFont = true;
            this.gvwBase1.Appearance.Row.Options.UseTextOptions = true;
            this.gvwBase1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvwBase1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvwBase1.BandPanelRowHeight = 50;
            this.gvwBase1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2});
            this.gvwBase1.ColumnPanelRowHeight = 80;
            this.gvwBase1.GridControl = this.grdBase;
            this.gvwBase1.Name = "gvwBase1";
            this.gvwBase1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvwBase1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvwBase1.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.False;
            this.gvwBase1.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.gvwBase1.OptionsBehavior.Editable = false;
            this.gvwBase1.OptionsCustomization.AllowBandMoving = false;
            this.gvwBase1.OptionsCustomization.AllowBandResizing = false;
            this.gvwBase1.OptionsCustomization.AllowColumnMoving = false;
            this.gvwBase1.OptionsCustomization.AllowColumnResizing = false;
            this.gvwBase1.OptionsCustomization.AllowFilter = false;
            this.gvwBase1.OptionsCustomization.AllowGroup = false;
            this.gvwBase1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gvwBase1.OptionsDetail.EnableMasterViewMode = false;
            this.gvwBase1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvwBase1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvwBase1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvwBase1.OptionsView.EnableAppearanceEvenRow = true;
            this.gvwBase1.OptionsView.ShowGroupPanel = false;
            this.gvwBase1.OptionsView.ShowIndicator = false;
            this.gvwBase1.RowHeight = 50;
            this.gvwBase1.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.gridView1_CellMerge);
            this.gvwBase1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvwBase1_RowCellStyle);
            // 
            // gridBand2
            // 
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 0;
            // 
            // gridView
            // 
            this.gridView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView.Appearance.EvenRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView.Appearance.HeaderPanel.BackColor = System.Drawing.Color.SkyBlue;
            this.gridView.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.PowderBlue;
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Appearance.Row.Options.UseTextOptions = true;
            this.gridView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView.ColumnPanelRowHeight = 80;
            this.gridView.GridControl = this.grdBase;
            this.gridView.Name = "gridView";
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.RowHeight = 50;
            // 
            // gvwBase
            // 
            this.gvwBase.Appearance.BandPanel.BackColor = System.Drawing.Color.SkyBlue;
            this.gvwBase.Appearance.BandPanel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gvwBase.Appearance.BandPanel.Options.UseBackColor = true;
            this.gvwBase.Appearance.BandPanel.Options.UseFont = true;
            this.gvwBase.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvwBase.Appearance.EvenRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvwBase.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvwBase.Appearance.HeaderPanel.BackColor = System.Drawing.Color.SkyBlue;
            this.gvwBase.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.PowderBlue;
            this.gvwBase.Appearance.HeaderPanel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gvwBase.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvwBase.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvwBase.Appearance.Row.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gvwBase.Appearance.Row.Options.UseFont = true;
            this.gvwBase.Appearance.Row.Options.UseTextOptions = true;
            this.gvwBase.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvwBase.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvwBase.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.gvwBase.ColumnPanelRowHeight = 80;
            this.gvwBase.GridControl = this.grdBase;
            this.gvwBase.Name = "gvwBase";
            this.gvwBase.OptionsCustomization.AllowBandMoving = false;
            this.gvwBase.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvwBase.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvwBase.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvwBase.OptionsView.EnableAppearanceEvenRow = true;
            this.gvwBase.OptionsView.ShowGroupPanel = false;
            this.gvwBase.OptionsView.ShowIndicator = false;
            this.gvwBase.RowHeight = 50;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.White;
            this.pnTop.Controls.Add(this.lblDate);
            this.pnTop.Controls.Add(this.lblTitle);
            this.pnTop.Controls.Add(this.btnBack);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTop.Location = new System.Drawing.Point(3, 3);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1898, 94);
            this.pnTop.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(1692, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(206, 98);
            this.lblDate.TabIndex = 36;
            this.lblDate.Text = "2019-09-16\r\n00:00:00";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // FRM_TMS_BALANCE_UP_LT
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_TMS_BALANCE_UP_LT";
            this.Text = "FRM_TMS_HOME_UP_LT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_TMS_BALANCE_UP_LT_Load);
            this.VisibleChanged += new System.EventHandler(this.FRM_TMS_BALANCE_UP_LT_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwBase1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwBase)).EndInit();
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Timer tmrDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grdBase;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gvwBase1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gvwBase;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Label lblDate;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}