namespace FORM.UC
{
    partial class UC_WS_INFO
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
            this.a1Panel1 = new OS_DSF.A1Panel();
            this.lblLT = new System.Windows.Forms.Label();
            this.lblPlantName = new System.Windows.Forms.Label();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.sBtnDetail = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPlantQty = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWip_Qty = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRateInv_Plan = new System.Windows.Forms.Label();
            this.a1Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // a1Panel1
            // 
            this.a1Panel1.BackColor = System.Drawing.Color.White;
            this.a1Panel1.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel1.Controls.Add(this.lblLT);
            this.a1Panel1.Controls.Add(this.lblPlantName);
            this.a1Panel1.Controls.Add(this.progressBarControl1);
            this.a1Panel1.Controls.Add(this.sBtnDetail);
            this.a1Panel1.Controls.Add(this.simpleButton2);
            this.a1Panel1.Controls.Add(this.flowLayoutPanel1);
            this.a1Panel1.GradientEndColor = System.Drawing.Color.White;
            this.a1Panel1.GradientStartColor = System.Drawing.Color.White;
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(3, 3);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.RoundCornerRadius = 6;
            this.a1Panel1.ShadowOffSet = 6;
            this.a1Panel1.Size = new System.Drawing.Size(187, 228);
            this.a1Panel1.TabIndex = 0;
            // 
            // lblLT
            // 
            this.lblLT.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLT.ForeColor = System.Drawing.Color.Black;
            this.lblLT.Location = new System.Drawing.Point(5, 132);
            this.lblLT.Name = "lblLT";
            this.lblLT.Size = new System.Drawing.Size(169, 24);
            this.lblLT.TabIndex = 11;
            this.lblLT.Text = "Leadtime: 0.0 Days";
            this.lblLT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlantName
            // 
            this.lblPlantName.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblPlantName.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlantName.ForeColor = System.Drawing.Color.White;
            this.lblPlantName.Location = new System.Drawing.Point(3, 2);
            this.lblPlantName.Name = "lblPlantName";
            this.lblPlantName.Size = new System.Drawing.Size(175, 43);
            this.lblPlantName.TabIndex = 7;
            this.lblPlantName.Text = "Plant Name";
            this.lblPlantName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlantName.Click += new System.EventHandler(this.lblPlantName_Click);
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(6, 160);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.EndColor = System.Drawing.Color.Khaki;
            this.progressBarControl1.Properties.LookAndFeel.SkinName = "Office 2013";
            this.progressBarControl1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.progressBarControl1.Properties.Maximum = 5;
            this.progressBarControl1.Properties.StartColor = System.Drawing.Color.HotPink;
            this.progressBarControl1.Size = new System.Drawing.Size(169, 18);
            this.progressBarControl1.TabIndex = 10;
            // 
            // sBtnDetail
            // 
            this.sBtnDetail.Appearance.BackColor = System.Drawing.Color.Gold;
            this.sBtnDetail.Appearance.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.sBtnDetail.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.sBtnDetail.Appearance.Options.UseBackColor = true;
            this.sBtnDetail.Appearance.Options.UseFont = true;
            this.sBtnDetail.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.sBtnDetail.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.sBtnDetail.AppearanceHovered.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.sBtnDetail.AppearanceHovered.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.sBtnDetail.AppearanceHovered.Options.UseBackColor = true;
            this.sBtnDetail.AppearanceHovered.Options.UseFont = true;
            this.sBtnDetail.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.sBtnDetail.Location = new System.Drawing.Point(6, 185);
            this.sBtnDetail.Name = "sBtnDetail";
            this.sBtnDetail.Size = new System.Drawing.Size(168, 30);
            this.sBtnDetail.TabIndex = 9;
            this.sBtnDetail.Tag = "227";
            this.sBtnDetail.Text = "Detail";
          //  this.sBtnDetail.Click += new System.EventHandler(this.sBtnDetail_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButton2.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.simpleButton2.Appearance.Options.UseBackColor = true;
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.simpleButton2.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.simpleButton2.AppearanceHovered.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.simpleButton2.AppearanceHovered.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.simpleButton2.AppearanceHovered.Options.UseBackColor = true;
            this.simpleButton2.AppearanceHovered.Options.UseFont = true;
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton2.Location = new System.Drawing.Point(91, 184);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(88, 50);
            this.simpleButton2.TabIndex = 9;
            this.simpleButton2.Tag = "234";
            this.simpleButton2.Text = "Set Status";
            this.simpleButton2.Visible = false;
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.lblPlantQty);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.lblWip_Qty);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.lblRateInv_Plan);
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 46);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(175, 84);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlantQty
            // 
            this.lblPlantQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPlantQty.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            this.lblPlantQty.ForeColor = System.Drawing.Color.Green;
            this.lblPlantQty.Location = new System.Drawing.Point(64, 0);
            this.lblPlantQty.Name = "lblPlantQty";
            this.lblPlantQty.Size = new System.Drawing.Size(107, 35);
            this.lblPlantQty.TabIndex = 1;
            this.lblPlantQty.Text = "0 Prs";
            this.lblPlantQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "Current";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWip_Qty
            // 
            this.lblWip_Qty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblWip_Qty.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            this.lblWip_Qty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblWip_Qty.Location = new System.Drawing.Point(83, 35);
            this.lblWip_Qty.Name = "lblWip_Qty";
            this.lblWip_Qty.Size = new System.Drawing.Size(88, 35);
            this.lblWip_Qty.TabIndex = 3;
            this.lblWip_Qty.Text = "0 Prs";
            this.lblWip_Qty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkOrange;
            this.label5.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(3, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 3);
            this.label5.TabIndex = 4;
            this.label5.Text = "Rate";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRateInv_Plan
            // 
            this.lblRateInv_Plan.BackColor = System.Drawing.Color.DarkOrange;
            this.lblRateInv_Plan.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.lblRateInv_Plan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRateInv_Plan.Location = new System.Drawing.Point(63, 70);
            this.lblRateInv_Plan.Name = "lblRateInv_Plan";
            this.lblRateInv_Plan.Size = new System.Drawing.Size(108, 3);
            this.lblRateInv_Plan.TabIndex = 5;
            this.lblRateInv_Plan.Text = "0%";
            this.lblRateInv_Plan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UC_WS_INFO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.a1Panel1);
            this.Name = "UC_WS_INFO";
            this.Size = new System.Drawing.Size(193, 237);
            this.a1Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OS_DSF.A1Panel a1Panel1;
        private DevExpress.XtraEditors.SimpleButton sBtnDetail;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPlantQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblWip_Qty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRateInv_Plan;
        private System.Windows.Forms.Label lblPlantName;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private System.Windows.Forms.Label lblLT;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;

    }
}
