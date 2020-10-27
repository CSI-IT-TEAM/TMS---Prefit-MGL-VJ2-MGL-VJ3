namespace FORM
{
    partial class FRM_VJ3_VJ1_MAPS
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
            this.btnCar = new System.Windows.Forms.Button();
            this.tmrGetDepart = new System.Windows.Forms.Timer();
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
            // btnCar
            // 
            this.btnCar.BackColor = System.Drawing.Color.Transparent;
            this.btnCar.BackgroundImage = global::FORM.Properties.Resources.car;
            this.btnCar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCar.FlatAppearance.BorderSize = 0;
            this.btnCar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCar.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Italic);
            this.btnCar.ForeColor = System.Drawing.Color.Blue;
            this.btnCar.Location = new System.Drawing.Point(82, 322);
            this.btnCar.Name = "btnCar";
            this.btnCar.Size = new System.Drawing.Size(93, 50);
            this.btnCar.TabIndex = 174;
            this.btnCar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCar.UseVisualStyleBackColor = false;
            this.btnCar.Click += new System.EventHandler(this.btnCar_Click);
            // 
            // tmrGetDepart
            // 
            this.tmrGetDepart.Enabled = true;
            this.tmrGetDepart.Interval = 1000;
            this.tmrGetDepart.Tick += new System.EventHandler(this.tmrGetDepart_Tick);
            // 
            // FRM_VJ3_VJ1_MAPS
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::FORM.Properties.Resources.VJ3_VJ1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1480, 687);
            this.Controls.Add(this.btnCar);
            this.Name = "FRM_VJ3_VJ1_MAPS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_VJ3_VJ1_MAPS";
            this.Load += new System.EventHandler(this.FRM_VJ3_VJ1_MAPS_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCar;
        private System.Windows.Forms.Timer tmrCarRun;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Timer tmrGetDepart;
    }
}