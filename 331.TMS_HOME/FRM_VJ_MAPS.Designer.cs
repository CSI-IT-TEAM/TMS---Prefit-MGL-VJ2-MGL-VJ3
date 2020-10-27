namespace FORM
{
    partial class FRM_VJ_MAPS
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
            this.tmrCarRun = new System.Windows.Forms.Timer();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.tmrGetDepart = new System.Windows.Forms.Timer();
            this.pnMain = new System.Windows.Forms.Panel();
            this.btnCar = new System.Windows.Forms.Button();
            this.btnCar3 = new System.Windows.Forms.Button();
            this.btnCar2 = new System.Windows.Forms.Button();
            this.pnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrCarRun
            // 
            this.tmrCarRun.Enabled = true;
            this.tmrCarRun.Interval = 1;
            this.tmrCarRun.Tick += new System.EventHandler(this.tmrCarRun_Tick);
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            // 
            // tmrGetDepart
            // 
            this.tmrGetDepart.Enabled = true;
            this.tmrGetDepart.Interval = 1000;
            this.tmrGetDepart.Tick += new System.EventHandler(this.tmrGetDepart_Tick);
            // 
            // pnMain
            // 
            this.pnMain.BackgroundImage = global::FORM.Properties.Resources.tms_vj_maps;
            this.pnMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnMain.Controls.Add(this.btnCar);
            this.pnMain.Controls.Add(this.btnCar3);
            this.pnMain.Controls.Add(this.btnCar2);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1884, 1061);
            this.pnMain.TabIndex = 0;
            // 
            // btnCar
            // 
            this.btnCar.BackColor = System.Drawing.Color.Transparent;
            this.btnCar.BackgroundImage = global::FORM.Properties.Resources.car;
            this.btnCar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCar.FlatAppearance.BorderSize = 0;
            this.btnCar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCar.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Italic);
            this.btnCar.ForeColor = System.Drawing.Color.Blue;
            this.btnCar.Location = new System.Drawing.Point(790, 486);
            this.btnCar.Name = "btnCar";
            this.btnCar.Size = new System.Drawing.Size(121, 70);
            this.btnCar.TabIndex = 174;
            this.btnCar.Tag = "2";
            this.btnCar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCar.UseVisualStyleBackColor = false;
            this.btnCar.Click += new System.EventHandler(this.btnCar_Click);
            // 
            // btnCar3
            // 
            this.btnCar3.BackColor = System.Drawing.Color.Transparent;
            this.btnCar3.BackgroundImage = global::FORM.Properties.Resources.car2;
            this.btnCar3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCar3.FlatAppearance.BorderSize = 0;
            this.btnCar3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCar3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Italic);
            this.btnCar3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCar3.Location = new System.Drawing.Point(1492, 120);
            this.btnCar3.Name = "btnCar3";
            this.btnCar3.Size = new System.Drawing.Size(121, 70);
            this.btnCar3.TabIndex = 176;
            this.btnCar3.Tag = "3";
            this.btnCar3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnCar3.UseVisualStyleBackColor = false;
            this.btnCar3.Click += new System.EventHandler(this.btnCar_Click);
            // 
            // btnCar2
            // 
            this.btnCar2.BackColor = System.Drawing.Color.Transparent;
            this.btnCar2.BackgroundImage = global::FORM.Properties.Resources.car2;
            this.btnCar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCar2.FlatAppearance.BorderSize = 0;
            this.btnCar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCar2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Italic);
            this.btnCar2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCar2.Location = new System.Drawing.Point(975, 746);
            this.btnCar2.Name = "btnCar2";
            this.btnCar2.Size = new System.Drawing.Size(121, 70);
            this.btnCar2.TabIndex = 175;
            this.btnCar2.Tag = "1";
            this.btnCar2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnCar2.UseVisualStyleBackColor = false;
            this.btnCar2.Click += new System.EventHandler(this.btnCar_Click);
            // 
            // FRM_VJ_MAPS
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1884, 1061);
            this.Controls.Add(this.pnMain);
            this.MaximizeBox = false;
            this.Name = "FRM_VJ_MAPS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VJ TMS MAPS";
            this.Load += new System.EventHandler(this.FRM_VJ_MAPS_Load);
            this.pnMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Button btnCar;
        private System.Windows.Forms.Timer tmrCarRun;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Button btnCar2;
        private System.Windows.Forms.Timer tmrGetDepart;
        private System.Windows.Forms.Button btnCar3;
    }
}