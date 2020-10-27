namespace FORM
{
    partial class FRM_MODEL_DETAIL_LW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_MODEL_DETAIL_LW));
            this.pnHeader = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnMain = new System.Windows.Forms.Panel();
            this.grdBase = new DevExpress.XtraGrid.GridControl();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.layoutViewColumn1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewColumn2 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.Item1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.tmr_scroll = new System.Windows.Forms.Timer();
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.pnHeader.SuspendLayout();
            this.pnMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.SeaGreen;
            this.pnHeader.Controls.Add(this.lblStatus);
            this.pnHeader.Controls.Add(this.lblTitle);
            this.pnHeader.Controls.Add(this.btnClose);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1052, 84);
            this.pnHeader.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.SeaGreen;
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(0, 70);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(92, 14);
            this.lblStatus.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(951, 72);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Model Name Detail";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.DoubleClick += new System.EventHandler(this.lblTitle_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.OrangeRed;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(960, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 84);
            this.btnClose.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnClose, "Close");
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.grdBase);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 84);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1052, 493);
            this.pnMain.TabIndex = 1;
            // 
            // grdBase
            // 
            this.grdBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBase.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.grdBase.Location = new System.Drawing.Point(0, 0);
            this.grdBase.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.grdBase.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.grdBase.MainView = this.layoutView1;
            this.grdBase.Name = "grdBase";
            this.grdBase.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit1});
            this.grdBase.Size = new System.Drawing.Size(1052, 493);
            this.grdBase.TabIndex = 0;
            this.grdBase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1});
            this.grdBase.Click += new System.EventHandler(this.grdBase_Click);
            // 
            // layoutView1
            // 
            this.layoutView1.Appearance.CardCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(57)))));
            this.layoutView1.Appearance.CardCaption.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(57)))));
            this.layoutView1.Appearance.CardCaption.ForeColor = System.Drawing.Color.White;
            this.layoutView1.Appearance.CardCaption.Options.UseBackColor = true;
            this.layoutView1.Appearance.CardCaption.Options.UseBorderColor = true;
            this.layoutView1.Appearance.CardCaption.Options.UseForeColor = true;
            this.layoutView1.Appearance.FieldCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.layoutView1.Appearance.FieldCaption.ForeColor = System.Drawing.Color.Black;
            this.layoutView1.Appearance.FieldCaption.Options.UseBackColor = true;
            this.layoutView1.Appearance.FieldCaption.Options.UseForeColor = true;
            this.layoutView1.Appearance.FieldValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(230)))));
            this.layoutView1.Appearance.FieldValue.ForeColor = System.Drawing.Color.Black;
            this.layoutView1.Appearance.FieldValue.Options.UseBackColor = true;
            this.layoutView1.Appearance.FieldValue.Options.UseForeColor = true;
            this.layoutView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.layoutView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.layoutView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.layoutView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.layoutView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.layoutView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.layoutView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.layoutView1.Appearance.FilterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.layoutView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.layoutView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.layoutView1.Appearance.FilterPanel.Options.UseBorderColor = true;
            this.layoutView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.layoutView1.Appearance.FocusedCardCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(114)))), ((int)(((byte)(50)))));
            this.layoutView1.Appearance.FocusedCardCaption.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(114)))), ((int)(((byte)(50)))));
            this.layoutView1.Appearance.FocusedCardCaption.ForeColor = System.Drawing.Color.White;
            this.layoutView1.Appearance.FocusedCardCaption.Options.UseBackColor = true;
            this.layoutView1.Appearance.FocusedCardCaption.Options.UseBorderColor = true;
            this.layoutView1.Appearance.FocusedCardCaption.Options.UseForeColor = true;
            this.layoutView1.Appearance.HideSelectionCardCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(158)))), ((int)(((byte)(64)))));
            this.layoutView1.Appearance.HideSelectionCardCaption.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(158)))), ((int)(((byte)(64)))));
            this.layoutView1.Appearance.HideSelectionCardCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.layoutView1.Appearance.HideSelectionCardCaption.Options.UseBackColor = true;
            this.layoutView1.Appearance.HideSelectionCardCaption.Options.UseBorderColor = true;
            this.layoutView1.Appearance.HideSelectionCardCaption.Options.UseForeColor = true;
            this.layoutView1.Appearance.SelectedCardCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(139)))), ((int)(((byte)(41)))));
            this.layoutView1.Appearance.SelectedCardCaption.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(139)))), ((int)(((byte)(41)))));
            this.layoutView1.Appearance.SelectedCardCaption.ForeColor = System.Drawing.Color.White;
            this.layoutView1.Appearance.SelectedCardCaption.Options.UseBackColor = true;
            this.layoutView1.Appearance.SelectedCardCaption.Options.UseBorderColor = true;
            this.layoutView1.Appearance.SelectedCardCaption.Options.UseForeColor = true;
            this.layoutView1.Appearance.SeparatorLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(37)))));
            this.layoutView1.Appearance.SeparatorLine.Options.UseBackColor = true;
            this.layoutView1.Appearance.ViewBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.layoutView1.Appearance.ViewBackground.BackColor2 = System.Drawing.Color.White;
            this.layoutView1.Appearance.ViewBackground.Options.UseBackColor = true;
            this.layoutView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.layoutView1.CardHorzInterval = 0;
            this.layoutView1.CardMinSize = new System.Drawing.Size(480, 276);
            this.layoutView1.CardVertInterval = 0;
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.layoutViewColumn1,
            this.layoutViewColumn2});
            this.layoutView1.GridControl = this.grdBase;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsBehavior.AllowRuntimeCustomization = false;
            this.layoutView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.layoutView1.OptionsBehavior.Editable = false;
            this.layoutView1.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.layoutView1.OptionsCarouselMode.BottomCardAlphaLevel = 1F;
            this.layoutView1.OptionsCarouselMode.BottomCardFading = 0.1F;
            this.layoutView1.OptionsCarouselMode.BottomCardScale = 0.3F;
            this.layoutView1.OptionsCarouselMode.CardCount = 10;
            this.layoutView1.OptionsCarouselMode.CenterOffset = new System.Drawing.Point(0, -20);
            this.layoutView1.OptionsCarouselMode.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            this.layoutView1.OptionsCarouselMode.PitchAngle = 0.9F;
            this.layoutView1.OptionsCarouselMode.Radius = 255;
            this.layoutView1.OptionsCarouselMode.RollAngle = 2.8F;
            this.layoutView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.layoutView1.OptionsItemText.AlignMode = DevExpress.XtraGrid.Views.Layout.FieldTextAlignMode.AutoSize;
            this.layoutView1.OptionsItemText.TextToControlDistance = 0;
            this.layoutView1.OptionsView.CardArrangeRule = DevExpress.XtraGrid.Views.Layout.LayoutCardArrangeRule.AllowPartialCards;
            this.layoutView1.OptionsView.ShowCardExpandButton = false;
            this.layoutView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.layoutView1.OptionsView.ShowHeaderPanel = false;
            this.layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Carousel;
            this.layoutView1.PaintStyleName = "Flat";
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            this.layoutView1.Click += new System.EventHandler(this.layoutView1_Click);
            // 
            // layoutViewColumn1
            // 
            this.layoutViewColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.layoutViewColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutViewColumn1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutViewColumn1.FieldName = "PIC";
            this.layoutViewColumn1.LayoutViewField = this.layoutViewField_layoutViewColumn1;
            this.layoutViewColumn1.Name = "layoutViewColumn1";
            this.layoutViewColumn1.OptionsColumn.ShowCaption = false;
            this.layoutViewColumn1.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            // 
            // layoutViewField_layoutViewColumn1
            // 
            this.layoutViewField_layoutViewColumn1.EditorPreferredWidth = 486;
            this.layoutViewField_layoutViewColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutViewField_layoutViewColumn1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn1.MaxSize = new System.Drawing.Size(468, 220);
            this.layoutViewField_layoutViewColumn1.MinSize = new System.Drawing.Size(468, 220);
            this.layoutViewField_layoutViewColumn1.Name = "layoutViewField_layoutViewColumn1";
            this.layoutViewField_layoutViewColumn1.Size = new System.Drawing.Size(490, 220);
            this.layoutViewField_layoutViewColumn1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_layoutViewColumn1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutViewField_layoutViewColumn1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_layoutViewColumn1.TextToControlDistance = 0;
            this.layoutViewField_layoutViewColumn1.TextVisible = false;
            // 
            // layoutViewColumn2
            // 
            this.layoutViewColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 30F);
            this.layoutViewColumn2.AppearanceCell.Options.UseFont = true;
            this.layoutViewColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.layoutViewColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutViewColumn2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutViewColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 30F);
            this.layoutViewColumn2.AppearanceHeader.Options.UseFont = true;
            this.layoutViewColumn2.Caption = "Model Name";
            this.layoutViewColumn2.FieldName = "MODEL";
            this.layoutViewColumn2.LayoutViewField = this.layoutViewField_layoutViewColumn2;
            this.layoutViewColumn2.Name = "layoutViewColumn2";
            // 
            // layoutViewField_layoutViewColumn2
            // 
            this.layoutViewField_layoutViewColumn2.EditorPreferredWidth = 486;
            this.layoutViewField_layoutViewColumn2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutViewField_layoutViewColumn2.Location = new System.Drawing.Point(0, 226);
            this.layoutViewField_layoutViewColumn2.Name = "layoutViewField_layoutViewColumn2";
            this.layoutViewField_layoutViewColumn2.Size = new System.Drawing.Size(490, 24);
            this.layoutViewField_layoutViewColumn2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_layoutViewColumn2.TextVisible = false;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_layoutViewColumn1,
            this.layoutViewField_layoutViewColumn2,
            this.Item1});
            this.layoutViewCard1.Name = "layoutViewTemplateCard";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 0;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // Item1
            // 
            this.Item1.AllowHotTrack = false;
            this.Item1.CustomizationFormText = "Item1";
            this.Item1.Location = new System.Drawing.Point(0, 220);
            this.Item1.Name = "Item1";
            this.Item1.Size = new System.Drawing.Size(490, 6);
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // tmr_scroll
            // 
            this.tmr_scroll.Interval = 2000;
            this.tmr_scroll.Tick += new System.EventHandler(this.tmr_scroll_Tick);
            // 
            // FRM_MODEL_DETAIL_LW
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1052, 577);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_MODEL_DETAIL_LW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_MODEL_DETAIL_LW";
            this.Load += new System.EventHandler(this.FRM_MODEL_DETAIL_LW_Load);
            this.VisibleChanged += new System.EventHandler(this.FRM_MODEL_DETAIL_LW_VisibleChanged);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.FRM_MODEL_DETAIL_LW_Layout);
            this.pnHeader.ResumeLayout(false);
            this.pnMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnMain;
        private DevExpress.XtraGrid.GridControl grdBase;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn layoutViewColumn1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn layoutViewColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Timer tmr_scroll;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblStatus;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraLayout.SimpleSeparator Item1;
    }
}