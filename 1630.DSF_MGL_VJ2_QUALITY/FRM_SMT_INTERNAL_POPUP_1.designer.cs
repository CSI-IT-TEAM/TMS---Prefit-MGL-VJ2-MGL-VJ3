namespace FORM.Popup
{
    partial class FRM_SMT_INTERNAL_POPUP_1
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
            this.gridBand10 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.LINE_CD = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.Line_Name = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand11 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.MLINE_CD = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.Model_Name = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.style_code = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.Size = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.LR = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.C_Qty = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.Re_Qty = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
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
            this.grdBase.Size = new System.Drawing.Size(1458, 661);
            this.grdBase.TabIndex = 0;
            this.grdBase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bgGrdView});
            // 
            // bgGrdView
            // 
            this.bgGrdView.Appearance.Row.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.bgGrdView.Appearance.Row.Options.UseFont = true;
            this.bgGrdView.BandPanelRowHeight = 60;
            this.bgGrdView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand10,
            this.gridBand1,
            this.gridBand11,
            this.gridBand2,
            this.gridBand3,
            this.gridBand6,
            this.gridBand7,
            this.gridBand8,
            this.gridBand9});
            this.bgGrdView.ColumnPanelRowHeight = 30;
            this.bgGrdView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.LINE_CD,
            this.Line_Name,
            this.MLINE_CD,
            this.Model_Name,
            this.style_code,
            this.Size,
            this.LR,
            this.C_Qty,
            this.Re_Qty});
            this.bgGrdView.GridControl = this.grdBase;
            this.bgGrdView.Name = "bgGrdView";
            this.bgGrdView.OptionsBehavior.Editable = false;
            this.bgGrdView.OptionsView.AllowCellMerge = true;
            this.bgGrdView.OptionsView.ShowColumnHeaders = false;
            this.bgGrdView.OptionsView.ShowGroupPanel = false;
            this.bgGrdView.OptionsView.ShowIndicator = false;
            this.bgGrdView.PaintStyleName = "Flat";
            this.bgGrdView.RowHeight = 40;
            this.bgGrdView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.bgGrdView_RowCellStyle);
            // 
            // gridBand10
            // 
            this.gridBand10.Caption = "gridBand10";
            this.gridBand10.Columns.Add(this.LINE_CD);
            this.gridBand10.Name = "gridBand10";
            this.gridBand10.Visible = false;
            this.gridBand10.VisibleIndex = -1;
            this.gridBand10.Width = 75;
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
            this.gridBand1.Width = 147;
            // 
            // Line_Name
            // 
            this.Line_Name.Caption = "Line_Name";
            this.Line_Name.FieldName = "Line_Name";
            this.Line_Name.Name = "Line_Name";
            this.Line_Name.Visible = true;
            this.Line_Name.Width = 147;
            // 
            // gridBand11
            // 
            this.gridBand11.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.gridBand11.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand11.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand11.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand11.AppearanceHeader.Options.UseFont = true;
            this.gridBand11.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand11.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand11.Caption = "Line";
            this.gridBand11.Columns.Add(this.MLINE_CD);
            this.gridBand11.Name = "gridBand11";
            this.gridBand11.VisibleIndex = 1;
            this.gridBand11.Width = 97;
            // 
            // MLINE_CD
            // 
            this.MLINE_CD.AppearanceCell.Options.UseTextOptions = true;
            this.MLINE_CD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MLINE_CD.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.MLINE_CD.Caption = "MLINE_CD";
            this.MLINE_CD.FieldName = "MLINE_CD";
            this.MLINE_CD.Name = "MLINE_CD";
            this.MLINE_CD.Visible = true;
            this.MLINE_CD.Width = 97;
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
            this.gridBand2.Columns.Add(this.Model_Name);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 2;
            this.gridBand2.Width = 411;
            // 
            // Model_Name
            // 
            this.Model_Name.Caption = "Model_Name";
            this.Model_Name.FieldName = "Model_Name";
            this.Model_Name.Name = "Model_Name";
            this.Model_Name.Visible = true;
            this.Model_Name.Width = 411;
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
            this.gridBand3.Columns.Add(this.style_code);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 3;
            this.gridBand3.Width = 191;
            // 
            // style_code
            // 
            this.style_code.Caption = "style_code";
            this.style_code.FieldName = "Style_Code";
            this.style_code.Name = "style_code";
            this.style_code.Visible = true;
            this.style_code.Width = 191;
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
            this.gridBand6.Caption = "Size";
            this.gridBand6.Columns.Add(this.Size);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 4;
            this.gridBand6.Width = 92;
            // 
            // Size
            // 
            this.Size.Caption = "Size";
            this.Size.FieldName = "Size";
            this.Size.Name = "Size";
            this.Size.Visible = true;
            this.Size.Width = 92;
            // 
            // gridBand7
            // 
            this.gridBand7.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.gridBand7.AppearanceHeader.BackColor2 = System.Drawing.Color.Gray;
            this.gridBand7.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand7.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand7.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand7.AppearanceHeader.Options.UseFont = true;
            this.gridBand7.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand7.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand7.Caption = "Division";
            this.gridBand7.Columns.Add(this.LR);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 5;
            this.gridBand7.Width = 109;
            // 
            // LR
            // 
            this.LR.Caption = "L/R";
            this.LR.FieldName = "L/R";
            this.LR.Name = "LR";
            this.LR.Visible = true;
            this.LR.Width = 109;
            // 
            // gridBand8
            // 
            this.gridBand8.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.gridBand8.AppearanceHeader.BackColor2 = System.Drawing.Color.Gray;
            this.gridBand8.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand8.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand8.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand8.AppearanceHeader.Options.UseFont = true;
            this.gridBand8.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand8.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand8.Caption = "OS&D Qty(Pcs)";
            this.gridBand8.Columns.Add(this.C_Qty);
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.VisibleIndex = 6;
            this.gridBand8.Width = 194;
            // 
            // C_Qty
            // 
            this.C_Qty.Caption = "C_Qty";
            this.C_Qty.FieldName = "C_Qty";
            this.C_Qty.Name = "C_Qty";
            this.C_Qty.Visible = true;
            this.C_Qty.Width = 194;
            // 
            // gridBand9
            // 
            this.gridBand9.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.gridBand9.AppearanceHeader.BackColor2 = System.Drawing.Color.Gray;
            this.gridBand9.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand9.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand9.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand9.AppearanceHeader.Options.UseFont = true;
            this.gridBand9.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand9.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand9.Caption = "Re Qty(Pcs)";
            this.gridBand9.Columns.Add(this.Re_Qty);
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.VisibleIndex = 7;
            this.gridBand9.Width = 213;
            // 
            // Re_Qty
            // 
            this.Re_Qty.Caption = "Re_Qty";
            this.Re_Qty.FieldName = "Re_Qty";
            this.Re_Qty.Name = "Re_Qty";
            this.Re_Qty.Visible = true;
            this.Re_Qty.Width = 213;
            // 
            // FRM_SMT_INTERNAL_POPUP_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1458, 661);
            this.Controls.Add(this.grdBase);
            this.Name = "FRM_SMT_INTERNAL_POPUP_1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRM_SMT_INTERNAL_POPUP_1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgGrdView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdBase;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bgGrdView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Line_Name;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Model_Name;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn style_code;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn C_Qty;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn LR;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Size;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Re_Qty;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn LINE_CD;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand11;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn MLINE_CD;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand9;
    }
}