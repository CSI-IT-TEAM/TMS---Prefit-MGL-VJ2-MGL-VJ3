namespace FORM.Popup
{
    partial class FRM_SMT_EXTERNAL_POPUP_1
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
            this.LINE_NAME = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.MLINE_CD = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.MODEL_NAME = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.STYLE_CD = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TYPE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.REASON = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.SIZE_CD = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.LR = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.C_Qty = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Re_Qty = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand11 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
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
            this.gridBand1,
            this.gridBand11,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand5,
            this.gridBand6,
            this.gridBand7,
            this.gridBand8,
            this.gridBand9});
            this.bgGrdView.ColumnPanelRowHeight = 30;
            this.bgGrdView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.LINE_NAME,
            this.MLINE_CD,
            this.MODEL_NAME,
            this.STYLE_CD,
            this.TYPE,
            this.REASON,
            this.SIZE_CD,
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
            // LINE_NAME
            // 
            this.LINE_NAME.Caption = "LINE_NAME";
            this.LINE_NAME.FieldName = "LINE_NAME";
            this.LINE_NAME.Name = "LINE_NAME";
            this.LINE_NAME.Visible = true;
            this.LINE_NAME.Width = 90;
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
            this.MLINE_CD.Width = 79;
            // 
            // MODEL_NAME
            // 
            this.MODEL_NAME.Caption = "MODEL_NAME";
            this.MODEL_NAME.FieldName = "MODEL_NAME";
            this.MODEL_NAME.Name = "MODEL_NAME";
            this.MODEL_NAME.Visible = true;
            this.MODEL_NAME.Width = 300;
            // 
            // STYLE_CD
            // 
            this.STYLE_CD.Caption = "STYLE_CD";
            this.STYLE_CD.FieldName = "STYLE_CD";
            this.STYLE_CD.Name = "STYLE_CD";
            this.STYLE_CD.Visible = true;
            this.STYLE_CD.Width = 130;
            // 
            // TYPE
            // 
            this.TYPE.Caption = "TYPE";
            this.TYPE.FieldName = "TYPE";
            this.TYPE.Name = "TYPE";
            this.TYPE.Visible = true;
            this.TYPE.Width = 120;
            // 
            // REASON
            // 
            this.REASON.Caption = "REASON";
            this.REASON.FieldName = "REASON";
            this.REASON.Name = "REASON";
            this.REASON.Visible = true;
            this.REASON.Width = 224;
            // 
            // SIZE_CD
            // 
            this.SIZE_CD.Caption = "SIZE_CD";
            this.SIZE_CD.FieldName = "SIZE_CD";
            this.SIZE_CD.Name = "SIZE_CD";
            this.SIZE_CD.Visible = true;
            this.SIZE_CD.Width = 70;
            // 
            // LR
            // 
            this.LR.Caption = "L/R";
            this.LR.FieldName = "L/R";
            this.LR.Name = "LR";
            this.LR.Visible = true;
            this.LR.Width = 94;
            // 
            // C_Qty
            // 
            this.C_Qty.Caption = "C_Qty";
            this.C_Qty.FieldName = "C_Qty";
            this.C_Qty.Name = "C_Qty";
            this.C_Qty.Visible = true;
            this.C_Qty.Width = 171;
            // 
            // Re_Qty
            // 
            this.Re_Qty.Caption = "Re_Qty";
            this.Re_Qty.FieldName = "Re_Qty";
            this.Re_Qty.Name = "Re_Qty";
            this.Re_Qty.Visible = true;
            this.Re_Qty.Width = 176;
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
            this.gridBand1.Columns.Add(this.LINE_NAME);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 90;
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
            this.gridBand11.Width = 79;
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
            this.gridBand2.Columns.Add(this.MODEL_NAME);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 2;
            this.gridBand2.Width = 300;
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
            this.gridBand3.Columns.Add(this.STYLE_CD);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 3;
            this.gridBand3.Width = 130;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand4.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand4.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand4.AppearanceHeader.Options.UseFont = true;
            this.gridBand4.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand4.Caption = "Type";
            this.gridBand4.Columns.Add(this.TYPE);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 4;
            this.gridBand4.Width = 120;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.gridBand5.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand5.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.gridBand5.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand5.AppearanceHeader.Options.UseFont = true;
            this.gridBand5.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand5.Caption = "Reason";
            this.gridBand5.Columns.Add(this.REASON);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 5;
            this.gridBand5.Width = 224;
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
            this.gridBand6.Columns.Add(this.SIZE_CD);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 6;
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
            this.gridBand7.VisibleIndex = 7;
            this.gridBand7.Width = 94;
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
            this.gridBand8.VisibleIndex = 8;
            this.gridBand8.Width = 171;
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
            this.gridBand9.VisibleIndex = 9;
            this.gridBand9.Width = 176;
            // 
            // FRM_SMT_EXTERNAL_POPUP_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1458, 661);
            this.Controls.Add(this.grdBase);
            this.Name = "FRM_SMT_EXTERNAL_POPUP_1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRM_SMT_EXTERNAL_POPUP_1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgGrdView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdBase;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bgGrdView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn LINE_NAME;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn MODEL_NAME;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn STYLE_CD;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn C_Qty;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn LR;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn SIZE_CD;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Re_Qty;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn MLINE_CD;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TYPE;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn REASON;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand11;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand9;
    }
}