namespace FORM.UC
{
    partial class UC_MENU
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
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.nbQua = new DevExpress.XtraNavBar.NavBarGroup();
            this.nBI_PFC = new DevExpress.XtraNavBar.NavBarItem();
            this.nBI_NPI = new DevExpress.XtraNavBar.NavBarItem();
            this.nBI_Qua = new DevExpress.XtraNavBar.NavBarItem();
            this.nBI_External = new DevExpress.XtraNavBar.NavBarItem();
            this.nBI_Market = new DevExpress.XtraNavBar.NavBarItem();
            this.nbProd = new DevExpress.XtraNavBar.NavBarGroup();
            this.nb_Prod_Result = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_Productivity = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_BTS = new DevExpress.XtraNavBar.NavBarItem();
            this.nbEquip = new DevExpress.XtraNavBar.NavBarGroup();
            this.nb_Equip = new DevExpress.XtraNavBar.NavBarItem();
            this.nbInv = new DevExpress.XtraNavBar.NavBarGroup();
            this.nb_Leadtime = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_Inv = new DevExpress.XtraNavBar.NavBarItem();
            this.nbHuman = new DevExpress.XtraNavBar.NavBarGroup();
            this.nb_Absent = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_Multiskill = new DevExpress.XtraNavBar.NavBarItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRate_Per = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.lblActual_Qty = new System.Windows.Forms.Label();
            this.lblActual = new System.Windows.Forms.Label();
            this.lblRplan_Qty = new System.Windows.Forms.Label();
            this.lblRplan = new System.Windows.Forms.Label();
            this.lblDplan_Qty = new System.Windows.Forms.Label();
            this.lblDplan = new System.Windows.Forms.Label();
            this.btnPlant = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.nbQua;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbQua,
            this.nbProd,
            this.nbEquip,
            this.nbInv,
            this.nbHuman});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nBI_PFC,
            this.nBI_NPI,
            this.nBI_Qua,
            this.nBI_External,
            this.nBI_Market,
            this.nb_Prod_Result,
            this.nb_Productivity,
            this.nb_BTS,
            this.nb_Equip,
            this.nb_Leadtime,
            this.nb_Inv,
            this.nb_Absent,
            this.nb_Multiskill});
            this.navBarControl1.Location = new System.Drawing.Point(3, 71);
            this.navBarControl1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.navBarControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 298;
            this.navBarControl1.Size = new System.Drawing.Size(298, 383);
            this.navBarControl1.StoreDefaultPaintStyleName = true;
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.navBarControl1_MouseDown);
            // 
            // nbQua
            // 
            this.nbQua.Appearance.Font = new System.Drawing.Font("Tahoma", 17F, System.Drawing.FontStyle.Bold);
            this.nbQua.Appearance.Options.UseFont = true;
            this.nbQua.Caption = "Quality";
            this.nbQua.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nBI_PFC),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nBI_NPI),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nBI_Qua),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nBI_External),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nBI_Market)});
            this.nbQua.Name = "nbQua";
            this.nbQua.SmallImage = global::FORM.Properties.Resources.Qual;
            // 
            // nBI_PFC
            // 
            this.nBI_PFC.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nBI_PFC.Appearance.Options.UseFont = true;
            this.nBI_PFC.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nBI_PFC.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.nBI_PFC.AppearanceHotTracked.Options.UseFont = true;
            this.nBI_PFC.AppearanceHotTracked.Options.UseForeColor = true;
            this.nBI_PFC.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nBI_PFC.AppearancePressed.Options.UseFont = true;
            this.nBI_PFC.Caption = "PFC Files";
            this.nBI_PFC.Name = "nBI_PFC";
            this.nBI_PFC.SmallImage = global::FORM.Properties.Resources.PFC;
            this.nBI_PFC.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBI_LinkPressed);
            // 
            // nBI_NPI
            // 
            this.nBI_NPI.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nBI_NPI.Appearance.Options.UseFont = true;
            this.nBI_NPI.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nBI_NPI.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.nBI_NPI.AppearanceHotTracked.Options.UseFont = true;
            this.nBI_NPI.AppearanceHotTracked.Options.UseForeColor = true;
            this.nBI_NPI.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nBI_NPI.AppearancePressed.Options.UseFont = true;
            this.nBI_NPI.Caption = "NPI";
            this.nBI_NPI.Name = "nBI_NPI";
            this.nBI_NPI.SmallImage = global::FORM.Properties.Resources.NPI;
            this.nBI_NPI.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBI_LinkPressed);
            // 
            // nBI_Qua
            // 
            this.nBI_Qua.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nBI_Qua.Appearance.Options.UseFont = true;
            this.nBI_Qua.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nBI_Qua.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.nBI_Qua.AppearanceHotTracked.Options.UseFont = true;
            this.nBI_Qua.AppearanceHotTracked.Options.UseForeColor = true;
            this.nBI_Qua.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nBI_Qua.AppearancePressed.Options.UseFont = true;
            this.nBI_Qua.Caption = "Quality Rate";
            this.nBI_Qua.Name = "nBI_Qua";
            this.nBI_Qua.SmallImage = global::FORM.Properties.Resources.Qual_Rate;
            this.nBI_Qua.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBI_LinkPressed);
            // 
            // nBI_External
            // 
            this.nBI_External.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nBI_External.Appearance.Options.UseFont = true;
            this.nBI_External.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nBI_External.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.nBI_External.AppearanceHotTracked.Options.UseFont = true;
            this.nBI_External.AppearanceHotTracked.Options.UseForeColor = true;
            this.nBI_External.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nBI_External.AppearancePressed.Options.UseFont = true;
            this.nBI_External.Caption = "External OS&D";
            this.nBI_External.Name = "nBI_External";
            this.nBI_External.SmallImage = global::FORM.Properties.Resources.def;
            this.nBI_External.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBI_LinkPressed);
            // 
            // nBI_Market
            // 
            this.nBI_Market.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nBI_Market.Appearance.Options.UseFont = true;
            this.nBI_Market.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nBI_Market.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.nBI_Market.AppearanceHotTracked.Options.UseFont = true;
            this.nBI_Market.AppearanceHotTracked.Options.UseForeColor = true;
            this.nBI_Market.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nBI_Market.AppearancePressed.Options.UseFont = true;
            this.nBI_Market.Caption = "Market Quality";
            this.nBI_Market.Name = "nBI_Market";
            this.nBI_Market.SmallImage = global::FORM.Properties.Resources.osd;
            this.nBI_Market.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBI_LinkPressed);
            // 
            // nbProd
            // 
            this.nbProd.Appearance.Font = new System.Drawing.Font("Tahoma", 17F, System.Drawing.FontStyle.Bold);
            this.nbProd.Appearance.Options.UseFont = true;
            this.nbProd.Caption = "Production";
            this.nbProd.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_Prod_Result),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_Productivity),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_BTS)});
            this.nbProd.Name = "nbProd";
            this.nbProd.SmallImage = global::FORM.Properties.Resources.prod;
            // 
            // nb_Prod_Result
            // 
            this.nb_Prod_Result.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Prod_Result.Appearance.Options.UseFont = true;
            this.nb_Prod_Result.AppearanceHotTracked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.nb_Prod_Result.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Prod_Result.AppearanceHotTracked.ForeColor = System.Drawing.Color.Blue;
            this.nb_Prod_Result.AppearanceHotTracked.Options.UseBackColor = true;
            this.nb_Prod_Result.AppearanceHotTracked.Options.UseFont = true;
            this.nb_Prod_Result.AppearanceHotTracked.Options.UseForeColor = true;
            this.nb_Prod_Result.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Prod_Result.AppearancePressed.Options.UseFont = true;
            this.nb_Prod_Result.Caption = "Production Result";
            this.nb_Prod_Result.Name = "nb_Prod_Result";
            this.nb_Prod_Result.SmallImage = global::FORM.Properties.Resources.prodresult;
            this.nb_Prod_Result.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBI_LinkPressed);
            // 
            // nb_Productivity
            // 
            this.nb_Productivity.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Productivity.Appearance.Options.UseFont = true;
            this.nb_Productivity.AppearanceHotTracked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.nb_Productivity.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Productivity.AppearanceHotTracked.ForeColor = System.Drawing.Color.Blue;
            this.nb_Productivity.AppearanceHotTracked.Options.UseBackColor = true;
            this.nb_Productivity.AppearanceHotTracked.Options.UseFont = true;
            this.nb_Productivity.AppearanceHotTracked.Options.UseForeColor = true;
            this.nb_Productivity.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Productivity.AppearancePressed.Options.UseFont = true;
            this.nb_Productivity.Caption = "Productivity";
            this.nb_Productivity.Name = "nb_Productivity";
            this.nb_Productivity.SmallImage = global::FORM.Properties.Resources.prodtivity;
            this.nb_Productivity.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBI_LinkPressed);
            // 
            // nb_BTS
            // 
            this.nb_BTS.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_BTS.Appearance.Options.UseFont = true;
            this.nb_BTS.AppearanceHotTracked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.nb_BTS.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_BTS.AppearanceHotTracked.ForeColor = System.Drawing.Color.Blue;
            this.nb_BTS.AppearanceHotTracked.Options.UseBackColor = true;
            this.nb_BTS.AppearanceHotTracked.Options.UseFont = true;
            this.nb_BTS.AppearanceHotTracked.Options.UseForeColor = true;
            this.nb_BTS.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_BTS.AppearancePressed.Options.UseFont = true;
            this.nb_BTS.Caption = "BTS";
            this.nb_BTS.Name = "nb_BTS";
            this.nb_BTS.SmallImage = global::FORM.Properties.Resources.bts;
            this.nb_BTS.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBI_LinkPressed);
            // 
            // nbEquip
            // 
            this.nbEquip.Appearance.Font = new System.Drawing.Font("Tahoma", 17F, System.Drawing.FontStyle.Bold);
            this.nbEquip.Appearance.Options.UseFont = true;
            this.nbEquip.Caption = "Equipment";
            this.nbEquip.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_Equip)});
            this.nbEquip.Name = "nbEquip";
            this.nbEquip.SmallImage = global::FORM.Properties.Resources.equip;
            // 
            // nb_Equip
            // 
            this.nb_Equip.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Equip.Appearance.Options.UseFont = true;
            this.nb_Equip.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Equip.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nb_Equip.AppearanceHotTracked.Options.UseFont = true;
            this.nb_Equip.AppearanceHotTracked.Options.UseForeColor = true;
            this.nb_Equip.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Equip.AppearancePressed.Options.UseFont = true;
            this.nb_Equip.Caption = "Smart Andon Analysis";
            this.nb_Equip.Name = "nb_Equip";
            this.nb_Equip.SmallImage = global::FORM.Properties.Resources.ANDON;
            this.nb_Equip.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBI_LinkPressed);
            // 
            // nbInv
            // 
            this.nbInv.Appearance.Font = new System.Drawing.Font("Tahoma", 17F, System.Drawing.FontStyle.Bold);
            this.nbInv.Appearance.Options.UseFont = true;
            this.nbInv.Caption = "Inventory";
            this.nbInv.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_Leadtime),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_Inv)});
            this.nbInv.Name = "nbInv";
            this.nbInv.SmallImage = global::FORM.Properties.Resources.inv;
            // 
            // nb_Leadtime
            // 
            this.nb_Leadtime.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Leadtime.Appearance.Options.UseFont = true;
            this.nb_Leadtime.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Leadtime.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.nb_Leadtime.AppearanceHotTracked.Options.UseFont = true;
            this.nb_Leadtime.AppearanceHotTracked.Options.UseForeColor = true;
            this.nb_Leadtime.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Leadtime.AppearancePressed.Options.UseFont = true;
            this.nb_Leadtime.Caption = "Lead Time";
            this.nb_Leadtime.Name = "nb_Leadtime";
            this.nb_Leadtime.SmallImage = global::FORM.Properties.Resources.leadtime;
            this.nb_Leadtime.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBI_LinkPressed);
            // 
            // nb_Inv
            // 
            this.nb_Inv.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Inv.Appearance.Options.UseFont = true;
            this.nb_Inv.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Inv.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.nb_Inv.AppearanceHotTracked.Options.UseFont = true;
            this.nb_Inv.AppearanceHotTracked.Options.UseForeColor = true;
            this.nb_Inv.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Inv.AppearancePressed.Options.UseFont = true;
            this.nb_Inv.Caption = "Inventory";
            this.nb_Inv.Name = "nb_Inv";
            this.nb_Inv.SmallImage = global::FORM.Properties.Resources.invtorySub;
            this.nb_Inv.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBI_LinkPressed);
            // 
            // nbHuman
            // 
            this.nbHuman.Appearance.Font = new System.Drawing.Font("Tahoma", 17F, System.Drawing.FontStyle.Bold);
            this.nbHuman.Appearance.Options.UseFont = true;
            this.nbHuman.Caption = "H.Resource";
            this.nbHuman.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_Absent),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_Multiskill)});
            this.nbHuman.Name = "nbHuman";
            this.nbHuman.SmallImage = global::FORM.Properties.Resources.human;
            // 
            // nb_Absent
            // 
            this.nb_Absent.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Absent.Appearance.Options.UseFont = true;
            this.nb_Absent.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Absent.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.nb_Absent.AppearanceHotTracked.Options.UseFont = true;
            this.nb_Absent.AppearanceHotTracked.Options.UseForeColor = true;
            this.nb_Absent.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Absent.AppearancePressed.Options.UseFont = true;
            this.nb_Absent.Caption = "Absenteeism";
            this.nb_Absent.Name = "nb_Absent";
            this.nb_Absent.SmallImage = global::FORM.Properties.Resources.absent;
            this.nb_Absent.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBI_LinkPressed);
            // 
            // nb_Multiskill
            // 
            this.nb_Multiskill.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Multiskill.Appearance.Options.UseFont = true;
            this.nb_Multiskill.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Multiskill.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.nb_Multiskill.AppearanceHotTracked.Options.UseFont = true;
            this.nb_Multiskill.AppearanceHotTracked.Options.UseForeColor = true;
            this.nb_Multiskill.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_Multiskill.AppearancePressed.Options.UseFont = true;
            this.nb_Multiskill.Caption = "MultiSkill";
            this.nb_Multiskill.Name = "nb_Multiskill";
            this.nb_Multiskill.SmallImage = global::FORM.Properties.Resources.multiskill;
            this.nb_Multiskill.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBI_LinkPressed);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.39009F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.60991F));
            this.tableLayoutPanel1.Controls.Add(this.lblRate_Per, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblRate, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblActual_Qty, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblActual, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblRplan_Qty, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblRplan, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDplan_Qty, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDplan, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 55);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(323, 384);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblRate_Per
            // 
            this.lblRate_Per.BackColor = System.Drawing.Color.White;
            this.lblRate_Per.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRate_Per.Font = new System.Drawing.Font("Calibri", 26.75F);
            this.lblRate_Per.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblRate_Per.Location = new System.Drawing.Point(126, 288);
            this.lblRate_Per.Name = "lblRate_Per";
            this.lblRate_Per.Size = new System.Drawing.Size(194, 96);
            this.lblRate_Per.TabIndex = 7;
            this.lblRate_Per.Text = "Rate";
            this.lblRate_Per.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRate_Per.UseCompatibleTextRendering = true;
            // 
            // lblRate
            // 
            this.lblRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(234)))));
            this.lblRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRate.Font = new System.Drawing.Font("Calibri", 27F, System.Drawing.FontStyle.Bold);
            this.lblRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblRate.Location = new System.Drawing.Point(3, 288);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(117, 96);
            this.lblRate.TabIndex = 6;
            this.lblRate.Text = "Rate";
            this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRate.UseCompatibleTextRendering = true;
            // 
            // lblActual_Qty
            // 
            this.lblActual_Qty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActual_Qty.Font = new System.Drawing.Font("Calibri", 26.75F);
            this.lblActual_Qty.ForeColor = System.Drawing.Color.Blue;
            this.lblActual_Qty.Location = new System.Drawing.Point(126, 192);
            this.lblActual_Qty.Name = "lblActual_Qty";
            this.lblActual_Qty.Size = new System.Drawing.Size(194, 96);
            this.lblActual_Qty.TabIndex = 5;
            this.lblActual_Qty.Text = "Actual";
            this.lblActual_Qty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblActual_Qty.UseCompatibleTextRendering = true;
            // 
            // lblActual
            // 
            this.lblActual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(234)))));
            this.lblActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActual.Font = new System.Drawing.Font("Calibri", 27F, System.Drawing.FontStyle.Bold);
            this.lblActual.ForeColor = System.Drawing.Color.Blue;
            this.lblActual.Location = new System.Drawing.Point(3, 192);
            this.lblActual.Name = "lblActual";
            this.lblActual.Size = new System.Drawing.Size(117, 96);
            this.lblActual.TabIndex = 4;
            this.lblActual.Text = "Actual";
            this.lblActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblActual.UseCompatibleTextRendering = true;
            // 
            // lblRplan_Qty
            // 
            this.lblRplan_Qty.BackColor = System.Drawing.Color.White;
            this.lblRplan_Qty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRplan_Qty.Font = new System.Drawing.Font("Calibri", 26.75F);
            this.lblRplan_Qty.ForeColor = System.Drawing.Color.Purple;
            this.lblRplan_Qty.Location = new System.Drawing.Point(126, 96);
            this.lblRplan_Qty.Name = "lblRplan_Qty";
            this.lblRplan_Qty.Size = new System.Drawing.Size(194, 96);
            this.lblRplan_Qty.TabIndex = 3;
            this.lblRplan_Qty.Text = "R.Plan";
            this.lblRplan_Qty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRplan_Qty.UseCompatibleTextRendering = true;
            // 
            // lblRplan
            // 
            this.lblRplan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(234)))));
            this.lblRplan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRplan.Font = new System.Drawing.Font("Calibri", 27F, System.Drawing.FontStyle.Bold);
            this.lblRplan.ForeColor = System.Drawing.Color.Purple;
            this.lblRplan.Location = new System.Drawing.Point(3, 96);
            this.lblRplan.Name = "lblRplan";
            this.lblRplan.Size = new System.Drawing.Size(117, 96);
            this.lblRplan.TabIndex = 2;
            this.lblRplan.Text = "R.Plan";
            this.lblRplan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRplan.UseCompatibleTextRendering = true;
            // 
            // lblDplan_Qty
            // 
            this.lblDplan_Qty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDplan_Qty.Font = new System.Drawing.Font("Calibri", 26.75F);
            this.lblDplan_Qty.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblDplan_Qty.Location = new System.Drawing.Point(126, 0);
            this.lblDplan_Qty.Name = "lblDplan_Qty";
            this.lblDplan_Qty.Size = new System.Drawing.Size(194, 96);
            this.lblDplan_Qty.TabIndex = 1;
            this.lblDplan_Qty.Text = "D.Plan";
            this.lblDplan_Qty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDplan_Qty.UseCompatibleTextRendering = true;
            // 
            // lblDplan
            // 
            this.lblDplan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(234)))));
            this.lblDplan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDplan.Font = new System.Drawing.Font("Calibri", 27F, System.Drawing.FontStyle.Bold);
            this.lblDplan.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblDplan.Location = new System.Drawing.Point(3, 0);
            this.lblDplan.Name = "lblDplan";
            this.lblDplan.Size = new System.Drawing.Size(117, 96);
            this.lblDplan.TabIndex = 0;
            this.lblDplan.Text = "D.Plan";
            this.lblDplan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDplan.UseCompatibleTextRendering = true;
            // 
            // btnPlant
            // 
            this.btnPlant.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnPlant.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPlant.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlant.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold);
            this.btnPlant.ForeColor = System.Drawing.Color.Yellow;
            this.btnPlant.Location = new System.Drawing.Point(7, 3);
            this.btnPlant.Name = "btnPlant";
            this.btnPlant.Size = new System.Drawing.Size(294, 62);
            this.btnPlant.TabIndex = 2;
            this.btnPlant.Text = "TEXTBUTTON";
            this.btnPlant.UseVisualStyleBackColor = false;
            this.btnPlant.Click += new System.EventHandler(this.btnPlant_Click);
            // 
            // UC_MENU
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnPlant);
            this.Controls.Add(this.navBarControl1);
            this.Name = "UC_MENU";
            this.Size = new System.Drawing.Size(304, 460);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup nbQua;
        private System.Windows.Forms.Button btnPlant;
        private DevExpress.XtraNavBar.NavBarGroup nbProd;
        private DevExpress.XtraNavBar.NavBarGroup nbEquip;
        private DevExpress.XtraNavBar.NavBarGroup nbInv;
        private DevExpress.XtraNavBar.NavBarGroup nbHuman;
        private DevExpress.XtraNavBar.NavBarItem nBI_PFC;
        private DevExpress.XtraNavBar.NavBarItem nBI_NPI;
        private DevExpress.XtraNavBar.NavBarItem nBI_Qua;
        private DevExpress.XtraNavBar.NavBarItem nBI_External;
        private DevExpress.XtraNavBar.NavBarItem nBI_Market;
        private DevExpress.XtraNavBar.NavBarItem nb_Prod_Result;
        private DevExpress.XtraNavBar.NavBarItem nb_Productivity;
        private DevExpress.XtraNavBar.NavBarItem nb_BTS;
        private DevExpress.XtraNavBar.NavBarItem nb_Equip;
        private DevExpress.XtraNavBar.NavBarItem nb_Leadtime;
        private DevExpress.XtraNavBar.NavBarItem nb_Inv;
        private DevExpress.XtraNavBar.NavBarItem nb_Absent;
        private DevExpress.XtraNavBar.NavBarItem nb_Multiskill;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblRate_Per;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblActual_Qty;
        private System.Windows.Forms.Label lblActual;
        private System.Windows.Forms.Label lblRplan_Qty;
        private System.Windows.Forms.Label lblRplan;
        private System.Windows.Forms.Label lblDplan_Qty;
        private System.Windows.Forms.Label lblDplan;
    }
}
