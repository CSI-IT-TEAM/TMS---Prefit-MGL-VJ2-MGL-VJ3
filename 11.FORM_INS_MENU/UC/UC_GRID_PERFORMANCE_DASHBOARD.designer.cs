namespace FORM.UC
{
    partial class UC_GRID_PERFORMANCE_DASHBOARD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_GRID_PERFORMANCE_DASHBOARD));
            this.pnHeader = new System.Windows.Forms.Panel();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.lblTitile = new System.Windows.Forms.Label();
            this.axfpSpread1 = new AxFPSpreadADO.AxfpSpread();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnHeader.Controls.Add(this.progressPanel1);
            this.pnHeader.Controls.Add(this.lblTitile);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.ForeColor = System.Drawing.Color.White;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(628, 52);
            this.pnHeader.TabIndex = 1;
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.BarAnimationElementThickness = 2;
            this.progressPanel1.Location = new System.Drawing.Point(436, 3);
            this.progressPanel1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.progressPanel1.LookAndFeel.UseWindowsXPTheme = true;
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(189, 46);
            this.progressPanel1.TabIndex = 1;
            this.progressPanel1.Text = "progressPanel1";
            // 
            // lblTitile
            // 
            this.lblTitile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitile.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitile.Location = new System.Drawing.Point(0, 0);
            this.lblTitile.Name = "lblTitile";
            this.lblTitile.Size = new System.Drawing.Size(628, 52);
            this.lblTitile.TabIndex = 0;
            this.lblTitile.Text = "Production";
            this.lblTitile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // axfpSpread1
            // 
            this.axfpSpread1.DataSource = null;
            this.axfpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axfpSpread1.Location = new System.Drawing.Point(0, 52);
            this.axfpSpread1.Name = "axfpSpread1";
            this.axfpSpread1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfpSpread1.OcxState")));
            this.axfpSpread1.Size = new System.Drawing.Size(628, 252);
            this.axfpSpread1.TabIndex = 2;
            // 
            // UC_GRID_PERFORMANCE_DASHBOARD
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.axfpSpread1);
            this.Controls.Add(this.pnHeader);
            this.Name = "UC_GRID_PERFORMANCE_DASHBOARD";
            this.Size = new System.Drawing.Size(628, 304);
            this.pnHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private AxFPSpreadADO.AxfpSpread axfpSpread1;
        private System.Windows.Forms.Label lblTitile;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;

    }
}
