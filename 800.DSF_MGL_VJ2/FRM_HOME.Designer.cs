namespace FORM
{
    partial class FRM_HOME
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
            this.tmrDate = new System.Windows.Forms.Timer(this.components);
            this.pnHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnPrefit = new System.Windows.Forms.Button();
            this.btnUpstream = new System.Windows.Forms.Button();
            this.btnDSF = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.tabData = new DevExpress.XtraTab.XtraTabPage();
            this.tblContent = new System.Windows.Forms.TableLayoutPanel();
            this.tabChart = new DevExpress.XtraTab.XtraTabPage();
            this.tblChart = new System.Windows.Forms.TableLayoutPanel();
            this.repositoryItemButtonEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.pnHeader.SuspendLayout();
            this.tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabData.SuspendLayout();
            this.tabChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrDate
            // 
            this.tmrDate.Enabled = true;
            this.tmrDate.Interval = 1000;
            this.tmrDate.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pnHeader.Controls.Add(this.btnBack);
            this.pnHeader.Controls.Add(this.btnPrefit);
            this.pnHeader.Controls.Add(this.btnUpstream);
            this.pnHeader.Controls.Add(this.btnDSF);
            this.pnHeader.Controls.Add(this.lblDate);
            this.pnHeader.Controls.Add(this.lblTitle);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnHeader.Location = new System.Drawing.Point(3, 3);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1898, 97);
            this.pnHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = global::FORM.Properties.Resources.Back_Icon;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(80)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Calibri", 35.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1184, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(103, 96);
            this.btnBack.TabIndex = 41;
            this.btnBack.Tag = "minimized";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnPrefit
            // 
            this.btnPrefit.BackgroundImage = global::FORM.Properties.Resources.FtyButton;
            this.btnPrefit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrefit.FlatAppearance.BorderSize = 0;
            this.btnPrefit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPrefit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPrefit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrefit.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrefit.ForeColor = System.Drawing.Color.White;
            this.btnPrefit.Location = new System.Drawing.Point(1293, 0);
            this.btnPrefit.Name = "btnPrefit";
            this.btnPrefit.Size = new System.Drawing.Size(101, 99);
            this.btnPrefit.TabIndex = 40;
            this.btnPrefit.Text = "Prefit Tally Sheet";
            this.btnPrefit.UseVisualStyleBackColor = true;
            this.btnPrefit.Click += new System.EventHandler(this.btnPrefit_Click);
            // 
            // btnUpstream
            // 
            this.btnUpstream.BackgroundImage = global::FORM.Properties.Resources.FtyButton;
            this.btnUpstream.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpstream.FlatAppearance.BorderSize = 0;
            this.btnUpstream.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpstream.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpstream.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpstream.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpstream.ForeColor = System.Drawing.Color.White;
            this.btnUpstream.Location = new System.Drawing.Point(1507, 0);
            this.btnUpstream.Name = "btnUpstream";
            this.btnUpstream.Size = new System.Drawing.Size(101, 99);
            this.btnUpstream.TabIndex = 38;
            this.btnUpstream.Text = "DSF \r\nPlant B";
            this.btnUpstream.UseVisualStyleBackColor = true;
            this.btnUpstream.Click += new System.EventHandler(this.btnUpstream_Click);
            // 
            // btnDSF
            // 
            this.btnDSF.BackgroundImage = global::FORM.Properties.Resources.FtyButton;
            this.btnDSF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDSF.FlatAppearance.BorderSize = 0;
            this.btnDSF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDSF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDSF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDSF.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnDSF.ForeColor = System.Drawing.Color.White;
            this.btnDSF.Location = new System.Drawing.Point(1400, 0);
            this.btnDSF.Name = "btnDSF";
            this.btnDSF.Size = new System.Drawing.Size(101, 99);
            this.btnDSF.TabIndex = 39;
            this.btnDSF.Text = "DSF\r\nPlant A";
            this.btnDSF.UseVisualStyleBackColor = true;
            this.btnDSF.Click += new System.EventHandler(this.btnDSF_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(1692, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(206, 98);
            this.lblDate.TabIndex = 36;
            this.lblDate.Text = "2019-09-16\r\n00:00:00";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDate.DoubleClick += new System.EventHandler(this.lblDate_DoubleClick);
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Calibri", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Options.UseBackColor = true;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.LineVisible = true;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1033, 97);
            this.lblTitle.TabIndex = 35;
            this.lblTitle.Text = "DIGITAL SHOP FLOOR FOR MGL (VJ2) ";
            this.lblTitle.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.lblTitle.DoubleClick += new System.EventHandler(this.lblTitle_DoubleClick);
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.tabControl, 0, 1);
            this.tblMain.Controls.Add(this.pnHeader, 0, 0);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 2;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.Size = new System.Drawing.Size(1904, 1041);
            this.tblMain.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.AppearancePage.Header.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.tabControl.AppearancePage.Header.Options.UseFont = true;
            this.tabControl.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Calibri", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.tabControl.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 106);
            this.tabControl.LookAndFeel.SkinName = "VS2010";
            this.tabControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tabControl.Name = "tabControl";
            this.tabControl.PaintStyleName = "PropertyView";
            this.tabControl.SelectedTabPage = this.tabData;
            this.tabControl.Size = new System.Drawing.Size(1898, 932);
            this.tabControl.TabIndex = 53;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabData,
            this.tabChart});
        
            // 
            // tabData
            // 
            this.tabData.Appearance.Header.Font = new System.Drawing.Font("Calibri", 35.25F, System.Drawing.FontStyle.Bold);
            this.tabData.Appearance.Header.Options.UseFont = true;
            this.tabData.Appearance.HeaderActive.Font = new System.Drawing.Font("Calibri", 40.25F, System.Drawing.FontStyle.Bold);
            this.tabData.Appearance.HeaderActive.Options.UseFont = true;
            this.tabData.Appearance.PageClient.BorderColor = System.Drawing.Color.White;
            this.tabData.Appearance.PageClient.Options.UseBorderColor = true;
            this.tabData.Controls.Add(this.tblContent);
            this.tabData.Name = "tabData";
            this.tabData.Size = new System.Drawing.Size(1896, 858);
            this.tabData.Text = "    Data       ";
            // 
            // tblContent
            // 
            this.tblContent.BackColor = System.Drawing.Color.White;
            this.tblContent.ColumnCount = 3;
            this.tblContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblContent.Location = new System.Drawing.Point(0, 0);
            this.tblContent.Name = "tblContent";
            this.tblContent.RowCount = 2;
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblContent.Size = new System.Drawing.Size(1896, 858);
            this.tblContent.TabIndex = 6;
            // 
            // tabChart
            // 
            this.tabChart.Appearance.Header.Font = new System.Drawing.Font("Calibri", 35.25F, System.Drawing.FontStyle.Bold);
            this.tabChart.Appearance.Header.Options.UseFont = true;
            this.tabChart.Appearance.HeaderActive.Font = new System.Drawing.Font("Calibri", 40.25F, System.Drawing.FontStyle.Bold);
            this.tabChart.Appearance.HeaderActive.Options.UseFont = true;
            this.tabChart.Appearance.PageClient.BorderColor = System.Drawing.Color.White;
            this.tabChart.Appearance.PageClient.Options.UseBorderColor = true;
            this.tabChart.Controls.Add(this.tblChart);
            this.tabChart.Name = "tabChart";
            this.tabChart.Size = new System.Drawing.Size(1896, 858);
            this.tabChart.Text = "     Chart      ";
            // 
            // tblChart
            // 
            this.tblChart.BackColor = System.Drawing.Color.White;
            this.tblChart.ColumnCount = 3;
            this.tblChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblChart.Location = new System.Drawing.Point(0, 0);
            this.tblChart.Name = "tblChart";
            this.tblChart.RowCount = 2;
            this.tblChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblChart.Size = new System.Drawing.Size(1896, 858);
            this.tblChart.TabIndex = 8;
            // 
            // repositoryItemButtonEdit3
            // 
            this.repositoryItemButtonEdit3.AutoHeight = false;
            this.repositoryItemButtonEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit3.Name = "repositoryItemButtonEdit3";
            // 
            // FRM_HOME
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.tblMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_HOME";
            this.Text = "FRM_HOME";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_HOME_Load);
            this.VisibleChanged += new System.EventHandler(this.FRM_HOME_VisibleChanged);
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.tblMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            this.tabChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrDate;
        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnPrefit;
        private System.Windows.Forms.Button btnUpstream;
        private System.Windows.Forms.Button btnDSF;
        private System.Windows.Forms.Label lblDate;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage tabData;
        private DevExpress.XtraTab.XtraTabPage tabChart;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit3;
        private System.Windows.Forms.TableLayoutPanel tblContent;
        private System.Windows.Forms.TableLayoutPanel tblChart;
    }
}