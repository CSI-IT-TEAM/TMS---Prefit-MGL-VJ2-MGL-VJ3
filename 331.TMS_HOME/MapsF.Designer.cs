namespace FORM
{
    partial class MapsF
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
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.tmrCarRun = new System.Windows.Forms.Timer();
            this.tmrGetDepart = new System.Windows.Forms.Timer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCar = new System.Windows.Forms.Button();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            // 
            // tmrCarRun
            // 
            this.tmrCarRun.Enabled = true;
            this.tmrCarRun.Interval = 1;
            this.tmrCarRun.Tick += new System.EventHandler(this.tmrCarRun_Tick);
            // 
            // tmrGetDepart
            // 
            this.tmrGetDepart.Enabled = true;
            this.tmrGetDepart.Interval = 1000;
            this.tmrGetDepart.Tick += new System.EventHandler(this.tmrGetDepart_Tick);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::FORM.Properties.Resources.VJ2_VJ1_MAPS;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.btnCar);
            this.panel2.Controls.Add(this.shapeContainer2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1480, 687);
            this.panel2.TabIndex = 4;
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
            this.btnCar.Location = new System.Drawing.Point(133, 308);
            this.btnCar.Name = "btnCar";
            this.btnCar.Size = new System.Drawing.Size(93, 50);
            this.btnCar.TabIndex = 173;
            this.btnCar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCar.UseVisualStyleBackColor = false;
            this.btnCar.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer2.Size = new System.Drawing.Size(1480, 687);
            this.shapeContainer2.TabIndex = 5;
            this.shapeContainer2.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lineShape1.BorderWidth = 3;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.Visible = false;
            this.lineShape1.X1 = 133;
            this.lineShape1.X2 = 1364;
            this.lineShape1.Y1 = 366;
            this.lineShape1.Y2 = 368;
            // 
            // MapsF
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1480, 687);
            this.Controls.Add(this.panel2);
            this.Name = "MapsF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TMS Maps";
            this.Load += new System.EventHandler(this.MapsF_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Timer tmrCarRun;
        private System.Windows.Forms.Timer tmrGetDepart;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCar;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;


    }
}