namespace FORM
{
    partial class FRM_SMT_MGL_DSF_VJ2
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
            this.splMain = new System.Windows.Forms.SplitContainer();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnPrefit_Cockpit = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::FORM.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.Panel1.SuspendLayout();
            this.splMain.Panel2.SuspendLayout();
            this.splMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splMain
            // 
            this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMain.Location = new System.Drawing.Point(0, 0);
            this.splMain.Name = "splMain";
            this.splMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splMain.Panel1
            // 
            this.splMain.Panel1.BackColor = System.Drawing.Color.Turquoise;
            this.splMain.Panel1.Controls.Add(this.btnBack);
            this.splMain.Panel1.Controls.Add(this.btnPrefit_Cockpit);
            this.splMain.Panel1.Controls.Add(this.lblDate);
            this.splMain.Panel1.Controls.Add(this.lblTitle);
            this.splMain.Panel1.DoubleClick += new System.EventHandler(this.splMain_Panel1_DoubleClick);
            // 
            // splMain.Panel2
            // 
            this.splMain.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splMain.Panel2.Controls.Add(this.tblLayout);
            this.splMain.Size = new System.Drawing.Size(1920, 1080);
            this.splMain.SplitterDistance = 104;
            this.splMain.TabIndex = 0;
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
            this.btnBack.Location = new System.Drawing.Point(1430, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(111, 107);
            this.btnBack.TabIndex = 39;
            this.btnBack.Tag = "minimized";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnPrefit_Cockpit
            // 
            this.btnPrefit_Cockpit.BackgroundImage = global::FORM.Properties.Resources.FtyButton;
            this.btnPrefit_Cockpit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrefit_Cockpit.FlatAppearance.BorderSize = 0;
            this.btnPrefit_Cockpit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrefit_Cockpit.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrefit_Cockpit.ForeColor = System.Drawing.Color.Blue;
            this.btnPrefit_Cockpit.Location = new System.Drawing.Point(1547, 3);
            this.btnPrefit_Cockpit.Name = "btnPrefit_Cockpit";
            this.btnPrefit_Cockpit.Size = new System.Drawing.Size(101, 99);
            this.btnPrefit_Cockpit.TabIndex = 36;
            this.btnPrefit_Cockpit.Text = "Prefit\r\nCockpit";
            this.btnPrefit_Cockpit.UseVisualStyleBackColor = true;
            this.btnPrefit_Cockpit.Click += new System.EventHandler(this.btnPrefit_Cockpit_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(1714, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(206, 98);
            this.lblDate.TabIndex = 35;
            this.lblDate.Text = "2019-09-16\r\n00:00:00";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDate.DoubleClick += new System.EventHandler(this.lblDate_DoubleClick);
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.Turquoise;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Calibri", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Options.UseBackColor = true;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.LineVisible = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1233, 82);
            this.lblTitle.TabIndex = 34;
            this.lblTitle.Text = "UPSTREAM DIGITAL SHOP FLOOR (PLANT B) ";
            this.lblTitle.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.lblTitle.DoubleClick += new System.EventHandler(this.lblTitle_DoubleClick);
            // 
            // tblLayout
            // 
            this.tblLayout.BackColor = System.Drawing.SystemColors.Control;
            this.tblLayout.ColumnCount = 5;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayout.Location = new System.Drawing.Point(8, 48);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 1;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Size = new System.Drawing.Size(1904, 859);
            this.tblLayout.TabIndex = 70;
            // 
            // tmr
            // 
            this.tmr.Enabled = true;
            this.tmr.Interval = 1000;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // FRM_SMT_MGL_DSF_VJ2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.splMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_SMT_MGL_DSF_VJ2";
            this.Text = "s";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_SMT_MGL_DSF_VJ2cs_Load);
            this.VisibleChanged += new System.EventHandler(this.FRM_SMT_MGL_DSF_VJ2_VisibleChanged);
            this.splMain.Panel1.ResumeLayout(false);
            this.splMain.Panel1.PerformLayout();
            this.splMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splMain;
        private System.Windows.Forms.Label lblDate;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.TableLayoutPanel tblLayout;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.Windows.Forms.Button btnPrefit_Cockpit;
        private System.Windows.Forms.Button btnBack;
        //   private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;

    }
}