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
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.btnUpstream = new System.Windows.Forms.Button();
            this.btnDSF = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.splContent = new System.Windows.Forms.SplitContainer();
            this.tblContent = new System.Windows.Forms.TableLayoutPanel();
            this.tblChart = new System.Windows.Forms.TableLayoutPanel();
            this.tmrDate = new System.Windows.Forms.Timer(this.components);
            this.tblMain.SuspendLayout();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splContent)).BeginInit();
            this.splContent.Panel1.SuspendLayout();
            this.splContent.Panel2.SuspendLayout();
            this.splContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.pnHeader, 0, 0);
            this.tblMain.Controls.Add(this.splContent, 0, 1);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 2;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Size = new System.Drawing.Size(1904, 1041);
            this.tblMain.TabIndex = 0;
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
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
            this.btnUpstream.Location = new System.Drawing.Point(1419, -2);
            this.btnUpstream.Name = "btnUpstream";
            this.btnUpstream.Size = new System.Drawing.Size(101, 99);
            this.btnUpstream.TabIndex = 37;
            this.btnUpstream.Text = "Upstream\r\nPlant A";
            this.btnUpstream.UseVisualStyleBackColor = true;
            this.btnUpstream.Click += new System.EventHandler(this.btnUpstream_Click);
            this.btnUpstream.MouseEnter += new System.EventHandler(this.btnUpstream_MouseEnter);
            this.btnUpstream.MouseLeave += new System.EventHandler(this.btnUpstream_MouseLeave);
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
            this.btnDSF.Location = new System.Drawing.Point(1526, -1);
            this.btnDSF.Name = "btnDSF";
            this.btnDSF.Size = new System.Drawing.Size(101, 99);
            this.btnDSF.TabIndex = 37;
            this.btnDSF.Text = "DSF\r\nPlant B";
            this.btnDSF.UseVisualStyleBackColor = true;
            this.btnDSF.Click += new System.EventHandler(this.btnDSF_Click);
            this.btnDSF.MouseEnter += new System.EventHandler(this.btnPrefit_Cockpit_MouseEnter);
            this.btnDSF.MouseLeave += new System.EventHandler(this.btnPrefit_Cockpit_MouseLeave);
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
            this.lblTitle.Text = "DIGITAL SHOP FLOOR FOR MGL (VJ3) ";
            this.lblTitle.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.lblTitle.DoubleClick += new System.EventHandler(this.lblTitle_DoubleClick);
            // 
            // splContent
            // 
            this.splContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splContent.Location = new System.Drawing.Point(3, 106);
            this.splContent.Name = "splContent";
            this.splContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splContent.Panel1
            // 
            this.splContent.Panel1.Controls.Add(this.tblContent);
            // 
            // splContent.Panel2
            // 
            this.splContent.Panel2.Controls.Add(this.tblChart);
            this.splContent.Size = new System.Drawing.Size(1898, 932);
            this.splContent.SplitterDistance = 402;
            this.splContent.TabIndex = 1;
            // 
            // tblContent
            // 
            this.tblContent.BackColor = System.Drawing.Color.White;
            this.tblContent.ColumnCount = 3;
            this.tblContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblContent.Location = new System.Drawing.Point(0, 0);
            this.tblContent.Name = "tblContent";
            this.tblContent.RowCount = 1;
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 402F));
            this.tblContent.Size = new System.Drawing.Size(1898, 402);
            this.tblContent.TabIndex = 2;
            // 
            // tblChart
            // 
            this.tblChart.BackColor = System.Drawing.Color.White;
            this.tblChart.ColumnCount = 3;
            this.tblChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblChart.Location = new System.Drawing.Point(0, 0);
            this.tblChart.Name = "tblChart";
            this.tblChart.RowCount = 1;
            this.tblChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 526F));
            this.tblChart.Size = new System.Drawing.Size(1898, 526);
            this.tblChart.TabIndex = 0;
            // 
            // tmrDate
            // 
            this.tmrDate.Enabled = true;
            this.tmrDate.Interval = 1000;
            this.tmrDate.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.tblMain.ResumeLayout(false);
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.splContent.Panel1.ResumeLayout(false);
            this.splContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splContent)).EndInit();
            this.splContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.Panel pnHeader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer tmrDate;
        private System.Windows.Forms.SplitContainer splContent;
        private System.Windows.Forms.TableLayoutPanel tblContent;
        private System.Windows.Forms.TableLayoutPanel tblChart;
        private System.Windows.Forms.Button btnDSF;
        private System.Windows.Forms.Button btnUpstream;

    }
}