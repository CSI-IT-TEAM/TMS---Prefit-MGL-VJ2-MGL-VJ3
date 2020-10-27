namespace FORM.UC
{
    partial class NavBarTree
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavBarTree));
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.SEQ_FORM = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.PicMenuParent = new DevExpress.Utils.ImageCollection(this.components);
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicMenuParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.treeList1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.treeList1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeList1.Appearance.Row.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.treeList1.Appearance.Row.Options.UseFont = true;
            this.treeList1.BandPanelRowHeight = 50;
            this.treeList1.BestFitVisibleOnly = true;
            this.treeList1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treeList1.CaptionHeight = 20;
            this.treeList1.ColumnPanelRowHeight = 50;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.SEQ_FORM});
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Bold);
            this.treeList1.HorzScrollVisibility = DevExpress.XtraTreeList.ScrollVisibility.Never;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.AllowIndeterminateCheckState = true;
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.OptionsBehavior.ReadOnly = true;
            this.treeList1.OptionsBehavior.ResizeNodes = false;
            this.treeList1.OptionsCustomization.AllowBandMoving = false;
            this.treeList1.OptionsCustomization.AllowBandResizing = false;
            this.treeList1.OptionsCustomization.AllowChangeBandParent = true;
            this.treeList1.OptionsCustomization.AllowChangeColumnParent = true;
            this.treeList1.OptionsCustomization.AllowColumnMoving = false;
            this.treeList1.OptionsCustomization.AllowColumnResizing = false;
            this.treeList1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.treeList1.OptionsFilter.AllowFilterEditor = false;
            this.treeList1.OptionsFilter.AllowMRUFilterList = false;
            this.treeList1.OptionsView.AnimationType = DevExpress.XtraTreeList.TreeListAnimationType.AnimateAllContent;
            this.treeList1.OptionsView.AutoWidth = false;
            this.treeList1.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList1.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFocus;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.RowHeight = 50;
            this.treeList1.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowAlways;
            this.treeList1.Size = new System.Drawing.Size(313, 1034);
            this.treeList1.StateImageList = this.PicMenuParent;
            this.treeList1.TabIndex = 5;
            this.treeList1.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Dark;
            this.treeList1.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.treeList1_GetStateImage);
            this.treeList1.GetSelectImage += new DevExpress.XtraTreeList.GetSelectImageEventHandler(this.treeList1_GetSelectImage);
            this.treeList1.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeList1_NodeCellStyle);
            this.treeList1.CustomDrawNodeButton += new DevExpress.XtraTreeList.CustomDrawNodeButtonEventHandler(this.treeList1_CustomDrawNodeButton);
            this.treeList1.Click += new System.EventHandler(this.treeList1_Click);
            this.treeList1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseClick);
            this.treeList1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseDoubleClick);
            this.treeList1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseDown);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn1.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn1.Caption = "FACTORY - MENU";
            this.treeListColumn1.FieldName = "MENU_NM";
            this.treeListColumn1.MinWidth = 52;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 309;
            // 
            // SEQ_FORM
            // 
            this.SEQ_FORM.Caption = "SEQ";
            this.SEQ_FORM.FieldName = "SEQ_FORM";
            this.SEQ_FORM.Name = "SEQ_FORM";
            // 
            // PicMenuParent
            // 
            this.PicMenuParent.ImageSize = new System.Drawing.Size(32, 32);
            this.PicMenuParent.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("PicMenuParent.ImageStream")));
            this.PicMenuParent.Images.SetKeyName(0, "Qual.png");
            this.PicMenuParent.Images.SetKeyName(1, "prod.png");
            this.PicMenuParent.Images.SetKeyName(2, "equip.png");
            this.PicMenuParent.Images.SetKeyName(3, "inv.png");
            this.PicMenuParent.Images.SetKeyName(4, "user-icon.png");
            this.PicMenuParent.Images.SetKeyName(5, "NPI.png");
            this.PicMenuParent.Images.SetKeyName(6, "Qua.png");
            this.PicMenuParent.Images.SetKeyName(7, "osd.png");
            this.PicMenuParent.Images.SetKeyName(8, "prodresult.png");
            this.PicMenuParent.InsertGalleryImage("bopivotchart_32x32.png", "images/business%20objects/bopivotchart_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bopivotchart_32x32.png"), 9);
            this.PicMenuParent.Images.SetKeyName(9, "bopivotchart_32x32.png");
            this.PicMenuParent.InsertGalleryImage("chart2_32x32.png", "images/toolbox%20items/chart2_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/toolbox%20items/chart2_32x32.png"), 10);
            this.PicMenuParent.Images.SetKeyName(10, "chart2_32x32.png");
            this.PicMenuParent.InsertGalleryImage("piestyledonut_32x32.png", "images/chart/piestyledonut_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/chart/piestyledonut_32x32.png"), 11);
            this.PicMenuParent.Images.SetKeyName(11, "piestyledonut_32x32.png");
            this.PicMenuParent.Images.SetKeyName(12, "prodresult.png");
            this.PicMenuParent.Images.SetKeyName(13, "prodtivity.png");
            this.PicMenuParent.Images.SetKeyName(14, "bts.png");
            this.PicMenuParent.Images.SetKeyName(15, "predic.png");
            this.PicMenuParent.Images.SetKeyName(16, "analytics-icon.png");
            this.PicMenuParent.InsertGalleryImage("pielabelsdatalabels_32x32.png", "images/chart/pielabelsdatalabels_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/chart/pielabelsdatalabels_32x32.png"), 17);
            this.PicMenuParent.Images.SetKeyName(17, "pielabelsdatalabels_32x32.png");
            this.PicMenuParent.InsertGalleryImage("openhighlowclosecandlestick_32x32.png", "images/chart/openhighlowclosecandlestick_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/chart/openhighlowclosecandlestick_32x32.png"), 18);
            this.PicMenuParent.Images.SetKeyName(18, "openhighlowclosecandlestick_32x32.png");
            this.PicMenuParent.InsertGalleryImage("drilldownonseries_chart_32x32.png", "images/chart/drilldownonseries_chart_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/chart/drilldownonseries_chart_32x32.png"), 19);
            this.PicMenuParent.Images.SetKeyName(19, "drilldownonseries_chart_32x32.png");
            this.PicMenuParent.InsertGalleryImage("time2_32x32.png", "images/number%20formats/time2_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/number%20formats/time2_32x32.png"), 20);
            this.PicMenuParent.Images.SetKeyName(20, "time2_32x32.png");
            this.PicMenuParent.Images.SetKeyName(21, "ANDON.png");
            this.PicMenuParent.Images.SetKeyName(22, "leadtime.png");
            this.PicMenuParent.Images.SetKeyName(23, "invtorySub.png");
            this.PicMenuParent.InsertGalleryImage("boproductgroup_32x32.png", "images/business%20objects/boproductgroup_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/boproductgroup_32x32.png"), 24);
            this.PicMenuParent.Images.SetKeyName(24, "boproductgroup_32x32.png");
            this.PicMenuParent.InsertGalleryImage("packageproduct_32x32.png", "images/support/packageproduct_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/packageproduct_32x32.png"), 25);
            this.PicMenuParent.Images.SetKeyName(25, "packageproduct_32x32.png");
            this.PicMenuParent.Images.SetKeyName(26, "absent.png");
            this.PicMenuParent.Images.SetKeyName(27, "poto.png");
            this.PicMenuParent.InsertGalleryImage("employee_32x32.png", "images/people/employee_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/people/employee_32x32.png"), 28);
            this.PicMenuParent.Images.SetKeyName(28, "employee_32x32.png");
            this.PicMenuParent.InsertGalleryImage("team_32x32.png", "images/people/team_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/people/team_32x32.png"), 29);
            this.PicMenuParent.Images.SetKeyName(29, "team_32x32.png");
            // 
            // NavBarTree
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.treeList1);
            this.Name = "NavBarTree";
            this.Size = new System.Drawing.Size(313, 1034);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicMenuParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.Utils.ImageCollection PicMenuParent;
        private DevExpress.XtraTreeList.Columns.TreeListColumn SEQ_FORM;


    }
}
