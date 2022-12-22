namespace FORM.Popup
{
    partial class FRM_SMT_INTERNAL_POPUP_2
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
            this.grdBase = new DevExpress.XtraGrid.GridControl();
            this.bgGrdView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.LINE_CD = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.Line_Name = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand10 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.MLINE_CD = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.STYLE_NAME = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.STYLE_CODE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.PROD = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.OSD = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.RATE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgGrdView)).BeginInit();
            this.SuspendLayout();
            // 
            // grdBase
            // 
            this.grdBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBase.Location = new System.Drawing.Point(0, 0);
            this.grdBase.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdBase.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdBase.MainView = this.bgGrdView;
            this.grdBase.Name = "grdBase";
            this.grdBase.Size = new System.Drawing.Size(1393, 661);
            this.grdBase.TabIndex = 0;
            this.grdBase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bgGrdView});
            // 
            // bgGrdView
            // 
            this.bgGrdView.Appearance.Row.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bgGrdView.Appearance.Row.Options.UseFont = true;
            this.bgGrdView.BandPanelRowHeight = 60;
            this.bgGrdView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand7,
            this.gridBand1,
            this.gridBand10,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand5,
            this.gridBand6});
            this.bgGrdView.ColumnPanelRowHeight = 30;
            this.bgGrdView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.LINE_CD,
            this.Line_Name,
            this.MLINE_CD,
            this.STYLE_NAME,
            this.STYLE_CODE,
            this.PROD,
            this.OSD,
            this.RATE});
            this.bgGrdView.GridControl = this.grdBase;
            this.bgGrdView.Name = "bgGrdView";
            this.bgGrdView.OptionsView.AllowCellMerge = true;
            this.bgGrdView.OptionsView.ShowColumnHeaders = false;
            this.bgGrdView.OptionsView.ShowGroupPanel = false;
            this.bgGrdView.OptionsView.ShowIndicator = false;
            this.bgGrdView.PaintStyleName = "Flat";
            this.bgGrdView.RowHeight = 40;
            this.bgGrdView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.bgGrdView_RowCellStyle);
            // 
            // gridBand7
            // 
            this.gridBand7.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand7.AppearanceHeader.Options.UseFont = true;
            this.gridBand7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand7.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand7.Caption = "LINE_CD";
            this.gridBand7.Columns.Add(this.LINE_CD);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.Visible = false;
            this.gridBand7.VisibleIndex = -1;
            this.gridBand7.Width = 75;
            // 
            // LINE_CD
            // 
            this.LINE_CD.Caption = "LINE_CD";
            this.LINE_CD.FieldName = "LINE_CD";
            this.LINE_CD.Name = "LINE_CD";
            this.LINE_CD.Visible = true;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.gridBand1.AppearanceHeader.BackColor2 = System.Drawing.Color.Gray;
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand1.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand1.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand1.Caption = "Plant";
            this.gridBand1.Columns.Add(this.Line_Name);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 84;
            // 
            // Line_Name
            // 
            this.Line_Name.Caption = "Line_Name";
            this.Line_Name.FieldName = "LINE_NAME";
            this.Line_Name.Name = "Line_Name";
            this.Line_Name.Visible = true;
            this.Line_Name.Width = 84;
            // 
            // gridBand10
            // 
            this.gridBand10.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.gridBand10.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand10.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand10.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand10.AppearanceHeader.Options.UseFont = true;
            this.gridBand10.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand10.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand10.Caption = "Line";
            this.gridBand10.Columns.Add(this.MLINE_CD);
            this.gridBand10.Name = "gridBand10";
            this.gridBand10.VisibleIndex = 1;
            this.gridBand10.Width = 75;
            // 
            // MLINE_CD
            // 
            this.MLINE_CD.Caption = "MLINE_CD";
            this.MLINE_CD.FieldName = "MLINE_CD";
            this.MLINE_CD.Name = "MLINE_CD";
            this.MLINE_CD.Visible = true;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.gridBand2.AppearanceHeader.BackColor2 = System.Drawing.Color.Gray;
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand2.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand2.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand2.Caption = "Style Name";
            this.gridBand2.Columns.Add(this.STYLE_NAME);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 2;
            this.gridBand2.Width = 249;
            // 
            // STYLE_NAME
            // 
            this.STYLE_NAME.Caption = "STYLE_NAME";
            this.STYLE_NAME.FieldName = "STYLE_NAME";
            this.STYLE_NAME.Name = "STYLE_NAME";
            this.STYLE_NAME.Visible = true;
            this.STYLE_NAME.Width = 249;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.gridBand3.AppearanceHeader.BackColor2 = System.Drawing.Color.Gray;
            this.gridBand3.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand3.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand3.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand3.AppearanceHeader.Options.UseFont = true;
            this.gridBand3.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand3.Caption = "Style Code";
            this.gridBand3.Columns.Add(this.STYLE_CODE);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 3;
            this.gridBand3.Width = 150;
            // 
            // STYLE_CODE
            // 
            this.STYLE_CODE.Caption = "STYLE_CODE";
            this.STYLE_CODE.FieldName = "STYLE_CODE";
            this.STYLE_CODE.Name = "STYLE_CODE";
            this.STYLE_CODE.Visible = true;
            this.STYLE_CODE.Width = 150;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.gridBand4.AppearanceHeader.BackColor2 = System.Drawing.Color.Gray;
            this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand4.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand4.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand4.AppearanceHeader.Options.UseFont = true;
            this.gridBand4.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand4.Caption = "Prod Qty (Prs)";
            this.gridBand4.Columns.Add(this.PROD);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 4;
            this.gridBand4.Width = 159;
            // 
            // PROD
            // 
            this.PROD.Caption = "PROD";
            this.PROD.FieldName = "PROD";
            this.PROD.Name = "PROD";
            this.PROD.Visible = true;
            this.PROD.Width = 159;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.gridBand5.AppearanceHeader.BackColor2 = System.Drawing.Color.Gray;
            this.gridBand5.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand5.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand5.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand5.AppearanceHeader.Options.UseFont = true;
            this.gridBand5.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand5.Caption = "OS&D Qty (Pcs)";
            this.gridBand5.Columns.Add(this.OSD);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 5;
            this.gridBand5.Width = 160;
            // 
            // OSD
            // 
            this.OSD.Caption = "OSD";
            this.OSD.FieldName = "OSD";
            this.OSD.Name = "OSD";
            this.OSD.Visible = true;
            this.OSD.Width = 160;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.gridBand6.AppearanceHeader.BackColor2 = System.Drawing.Color.Gray;
            this.gridBand6.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand6.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand6.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand6.AppearanceHeader.Options.UseFont = true;
            this.gridBand6.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand6.Caption = "OS&D Rate (%)";
            this.gridBand6.Columns.Add(this.RATE);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 6;
            this.gridBand6.Width = 148;
            // 
            // RATE
            // 
            this.RATE.Caption = "RATE";
            this.RATE.FieldName = "RATE";
            this.RATE.Name = "RATE";
            this.RATE.Visible = true;
            this.RATE.Width = 148;
            // 
            // FRM_SMT_INTERNAL_POPUP_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1393, 661);
            this.Controls.Add(this.grdBase);
            this.Name = "FRM_SMT_INTERNAL_POPUP_2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRM_SMT_INTERNAL_POPUP_1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgGrdView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdBase;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bgGrdView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn LINE_CD;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Line_Name;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn STYLE_NAME;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn STYLE_CODE;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn RATE;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn OSD;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn PROD;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn MLINE_CD;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
    }
}