namespace FORM.UC
{
    partial class UC_MONTH_SELECTION
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrevYear = new System.Windows.Forms.Button();
            this.lblYear = new System.Windows.Forms.Label();
            this.btnNextYear = new System.Windows.Forms.Button();
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.lblMonth = new System.Windows.Forms.Label();
            this.btnPrevMonth = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Turquoise;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Year";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrevYear
            // 
            this.btnPrevYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevYear.Location = new System.Drawing.Point(56, 1);
            this.btnPrevYear.Name = "btnPrevYear";
            this.btnPrevYear.Size = new System.Drawing.Size(42, 42);
            this.btnPrevYear.TabIndex = 1;
            this.btnPrevYear.Text = "<<";
            this.btnPrevYear.UseVisualStyleBackColor = true;
            this.btnPrevYear.Click += new System.EventHandler(this.btnPrevYear_Click);
            // 
            // lblYear
            // 
            this.lblYear.BackColor = System.Drawing.Color.Silver;
            this.lblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblYear.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.ForeColor = System.Drawing.Color.Black;
            this.lblYear.Location = new System.Drawing.Point(98, 2);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(86, 40);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "2018";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblYear.TextChanged += new System.EventHandler(this.lblYear_TextChanged);
            // 
            // btnNextYear
            // 
            this.btnNextYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextYear.Location = new System.Drawing.Point(184, 1);
            this.btnNextYear.Name = "btnNextYear";
            this.btnNextYear.Size = new System.Drawing.Size(42, 42);
            this.btnNextYear.TabIndex = 3;
            this.btnNextYear.Text = ">>";
            this.btnNextYear.UseVisualStyleBackColor = true;
            this.btnNextYear.Click += new System.EventHandler(this.btnNextYear_Click);
            // 
            // btnNextMonth
            // 
            this.btnNextMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextMonth.Location = new System.Drawing.Point(427, 1);
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.Size = new System.Drawing.Size(42, 42);
            this.btnNextMonth.TabIndex = 6;
            this.btnNextMonth.Text = ">>";
            this.btnNextMonth.UseVisualStyleBackColor = true;
            this.btnNextMonth.Click += new System.EventHandler(this.btnNextMonth_Click);
            // 
            // lblMonth
            // 
            this.lblMonth.BackColor = System.Drawing.Color.Silver;
            this.lblMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMonth.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.ForeColor = System.Drawing.Color.Black;
            this.lblMonth.Location = new System.Drawing.Point(341, 2);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(86, 40);
            this.lblMonth.TabIndex = 5;
            this.lblMonth.Text = "Jan";
            this.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMonth.TextChanged += new System.EventHandler(this.lblMonth_TextChanged);
            // 
            // btnPrevMonth
            // 
            this.btnPrevMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevMonth.Location = new System.Drawing.Point(299, 1);
            this.btnPrevMonth.Name = "btnPrevMonth";
            this.btnPrevMonth.Size = new System.Drawing.Size(42, 42);
            this.btnPrevMonth.TabIndex = 4;
            this.btnPrevMonth.Text = "<<";
            this.btnPrevMonth.UseVisualStyleBackColor = true;
            this.btnPrevMonth.Click += new System.EventHandler(this.btnPrevMonth_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Turquoise;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(232, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 40);
            this.label2.TabIndex = 7;
            this.label2.Text = "Month";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_MONTH_SELECTION
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNextMonth);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.btnPrevMonth);
            this.Controls.Add(this.btnNextYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.btnPrevYear);
            this.Controls.Add(this.label1);
            this.Name = "UC_MONTH_SELECTION";
            this.Size = new System.Drawing.Size(472, 46);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrevYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Button btnNextYear;
        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Button btnPrevMonth;
        private System.Windows.Forms.Label label2;

    }
}
