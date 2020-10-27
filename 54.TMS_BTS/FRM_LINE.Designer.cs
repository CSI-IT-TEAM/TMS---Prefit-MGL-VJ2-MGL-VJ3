namespace FORM
{
    partial class FRM_LINE
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            this.cboLine = new DevExpress.XtraEditors.LookUpEdit();
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.cboLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboLine
            // 
            this.cboLine.Location = new System.Drawing.Point(12, 66);
            this.cboLine.Name = "cboLine";
            this.cboLine.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.cboLine.Properties.Appearance.Options.UseFont = true;
            this.cboLine.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.cboLine.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboLine.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.cboLine.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cboLine.Properties.AppearanceFocused.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.cboLine.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboLine.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.cboLine.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboLine.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cboLine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)))});
            this.cboLine.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MLINE_NM", "LINE")});
            this.cboLine.Properties.DropDownRows = 10;
            this.cboLine.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.cboLine.Properties.LookAndFeel.SkinName = "Office 2016 Black";
            this.cboLine.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboLine.Properties.NullText = "SELECT LINE";
            this.cboLine.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.NoBorder;
            this.cboLine.Properties.ShowHeader = false;
            this.cboLine.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboLine.Size = new System.Drawing.Size(260, 38);
            this.cboLine.TabIndex = 0;
            this.cboLine.EditValueChanged += new System.EventHandler(this.cboLine_EditValueChanged);
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.Location = new System.Drawing.Point(12, 12);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleSwitch1.Properties.Appearance.Options.UseFont = true;
            this.toggleSwitch1.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.toggleSwitch1.Properties.LookAndFeel.SkinName = "Office 2016 Black";
            this.toggleSwitch1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.toggleSwitch1.Properties.OffText = "FACTORY 1";
            this.toggleSwitch1.Properties.OnText = "PLANT N";
            this.toggleSwitch1.Size = new System.Drawing.Size(260, 43);
            this.toggleSwitch1.TabIndex = 21;
            this.toggleSwitch1.Toggled += new System.EventHandler(this.toggleSwitch1_Toggled);
            // 
            // FRM_LINE
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(293, 120);
            this.Controls.Add(this.toggleSwitch1);
            this.Controls.Add(this.cboLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FRM_LINE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please select Plant";
            this.VisibleChanged += new System.EventHandler(this.FRM_LINE_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.cboLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cboLine;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
    }
}