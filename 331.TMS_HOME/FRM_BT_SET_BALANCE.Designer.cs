namespace FORM
{
    partial class FRM_BT_SET_BALANCE
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdBase_set = new DevExpress.XtraGrid.GridControl();
            this.gvwBase_set = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.tmrLoad = new System.Windows.Forms.Timer();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBase_set)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwBase_set)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.grdBase_set, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnTop, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1904, 1041);
            this.tableLayoutPanel1.TabIndex = 38;
            // 
            // grdBase_set
            // 
            this.grdBase_set.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBase_set.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdBase_set.Location = new System.Drawing.Point(3, 103);
            this.grdBase_set.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.grdBase_set.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdBase_set.MainView = this.gvwBase_set;
            this.grdBase_set.Name = "grdBase_set";
            this.grdBase_set.Size = new System.Drawing.Size(1898, 935);
            this.grdBase_set.TabIndex = 188;
            this.grdBase_set.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwBase_set,
            this.gridView5});
            // 
            // gvwBase_set
            // 
            this.gvwBase_set.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gvwBase_set.Appearance.EvenRow.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.gvwBase_set.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvwBase_set.Appearance.EvenRow.Options.UseFont = true;
            this.gvwBase_set.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Gray;
            this.gvwBase_set.Appearance.HeaderPanel.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.gvwBase_set.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White;
            this.gvwBase_set.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvwBase_set.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvwBase_set.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gvwBase_set.Appearance.HorzLine.BackColor = System.Drawing.Color.Black;
            this.gvwBase_set.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvwBase_set.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gvwBase_set.Appearance.OddRow.Options.UseBackColor = true;
            this.gvwBase_set.Appearance.Row.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.gvwBase_set.Appearance.Row.Options.UseFont = true;
            this.gvwBase_set.Appearance.VertLine.BackColor = System.Drawing.Color.Black;
            this.gvwBase_set.Appearance.VertLine.Options.UseBackColor = true;
            this.gvwBase_set.ColumnPanelRowHeight = 50;
            this.gvwBase_set.GridControl = this.grdBase_set;
            this.gvwBase_set.Name = "gvwBase_set";
            this.gvwBase_set.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.gvwBase_set.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.gvwBase_set.OptionsBehavior.Editable = false;
            this.gvwBase_set.OptionsBehavior.ReadOnly = true;
            this.gvwBase_set.OptionsCustomization.AllowColumnMoving = false;
            this.gvwBase_set.OptionsCustomization.AllowColumnResizing = false;
            this.gvwBase_set.OptionsCustomization.AllowFilter = false;
            this.gvwBase_set.OptionsCustomization.AllowGroup = false;
            this.gvwBase_set.OptionsCustomization.AllowSort = false;
            this.gvwBase_set.OptionsDetail.EnableMasterViewMode = false;
            this.gvwBase_set.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvwBase_set.OptionsView.EnableAppearanceEvenRow = true;
            this.gvwBase_set.OptionsView.ShowGroupPanel = false;
            this.gvwBase_set.OptionsView.ShowIndicator = false;
            this.gvwBase_set.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.gvwBase_set.PaintStyleName = "Web";
            this.gvwBase_set.RowHeight = 30;
            // 
            // gridView5
            // 
            this.gridView5.GridControl = this.grdBase_set;
            this.gridView5.Name = "gridView5";
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
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(86, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1268, 65);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "BOTTOM SET BALANCE BY DAY";
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
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tmrLoad
            // 
            this.tmrLoad.Enabled = true;
            this.tmrLoad.Interval = 1000;
            this.tmrLoad.Tick += new System.EventHandler(this.tmrLoad_Tick);
            // 
            // FRM_BT_SET_BALANCE
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_BT_SET_BALANCE";
            this.Text = "FRM_BT_SET_BALANCE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.VisibleChanged += new System.EventHandler(this.FRM_BT_SET_BALANCE_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBase_set)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwBase_set)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBack;
        private DevExpress.XtraGrid.GridControl grdBase_set;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwBase_set;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private System.Windows.Forms.Timer tmrLoad;
    }
}