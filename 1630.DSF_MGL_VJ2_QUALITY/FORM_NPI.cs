using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OracleClient;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.Linq;

namespace FORM
{
	/// <summary>
	/// Form1에 대한 요약 설명입니다.
	/// </summary>
	public class FORM_NPI : System.Windows.Forms.Form
    {

        private Panel panel2;
        private SplitContainer splitContainer1;
        private AxFPUSpreadADO.AxfpSpread axfpSpread2;
        private AxFPUSpreadADO.AxfpSpread axfpSpread1;
        private AxFPUSpreadADO.AxfpSpread axfpSpread3;
        private PictureBox ptb1;
        private PictureBox ptb4;
        private PictureBox ptb3;
        private PictureBox ptb2;
        private string sLine_CD = "H";
        private Label label7;
        private Label label6;
        private Label label5;
        private AxFPUSpreadADO.AxfpSpread fgrid_main;
        const int AW_SLIDE = 0X40000;
        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);
        

		private System.ComponentModel.IContainer components;

        private DataTable vDtD1 = null,
                          vDtD2 = null,
                          vDtM1 = null,
                          vDtM2 = null;
        private Label lblTitle;
        private Label lblDate;
        private System.Windows.Forms.Timer timer1;
        private Button cmdBack;
        int cnt = 0;

		public FORM_NPI()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();
            sLine_CD = ComVar.Var._strValue1;
			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
		}

        public FORM_NPI(string line_cd)
        {
            //
            // Windows Form 디자이너 지원에 필요합니다.
            //
            InitializeComponent();
            sLine_CD = line_cd;

            //
            // TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
            //
        }

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

        private void MergeRowGroupCol(AxFPUSpreadADO.AxfpSpread gridObject, int iStartCol, int iRow, int iNumCol)
        {
            try
            {

                for (int i = iStartCol; i < gridObject.MaxCols + 4; i++)
                {

                    gridObject.AddCellSpan(iStartCol, iRow, 1, iNumCol);

                    i += iNumCol;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_NPI));
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdBack = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fgrid_main = new AxFPUSpreadADO.AxfpSpread();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ptb4 = new System.Windows.Forms.PictureBox();
            this.ptb3 = new System.Windows.Forms.PictureBox();
            this.ptb2 = new System.Windows.Forms.PictureBox();
            this.ptb1 = new System.Windows.Forms.PictureBox();
            this.axfpSpread3 = new AxFPUSpreadADO.AxfpSpread();
            this.axfpSpread1 = new AxFPUSpreadADO.AxfpSpread();
            this.axfpSpread2 = new AxFPUSpreadADO.AxfpSpread();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgrid_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.cmdBack);
            this.panel2.Controls.Add(this.lblDate);
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1916, 115);
            this.panel2.TabIndex = 29;
            // 
            // cmdBack
            // 
            this.cmdBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cmdBack.BackgroundImage = global::FORM.Properties.Resources.Back_Icon;
            this.cmdBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdBack.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.cmdBack.FlatAppearance.BorderSize = 0;
            this.cmdBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBack.Location = new System.Drawing.Point(1505, 8);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(108, 101);
            this.cmdBack.TabIndex = 54;
            this.cmdBack.UseVisualStyleBackColor = false;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblDate.Font = new System.Drawing.Font("Calibri", 32.25F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(1647, 3);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(266, 109);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "label1";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(-4, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(909, 109);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "New Product Introduction";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(4, 121);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fgrid_main);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.ptb4);
            this.splitContainer1.Panel2.Controls.Add(this.ptb3);
            this.splitContainer1.Panel2.Controls.Add(this.ptb2);
            this.splitContainer1.Panel2.Controls.Add(this.ptb1);
            this.splitContainer1.Panel2.Controls.Add(this.axfpSpread3);
            this.splitContainer1.Panel2.Controls.Add(this.axfpSpread1);
            this.splitContainer1.Panel2.Controls.Add(this.axfpSpread2);
            this.splitContainer1.Size = new System.Drawing.Size(1914, 921);
            this.splitContainer1.SplitterDistance = 419;
            this.splitContainer1.TabIndex = 31;
            // 
            // fgrid_main
            // 
            this.fgrid_main.DataSource = null;
            this.fgrid_main.Location = new System.Drawing.Point(4, 3);
            this.fgrid_main.Name = "fgrid_main";
            this.fgrid_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("fgrid_main.OcxState")));
            this.fgrid_main.Size = new System.Drawing.Size(1907, 413);
            this.fgrid_main.TabIndex = 0;
            this.fgrid_main.ClickEvent += new AxFPUSpreadADO._DSpreadEvents_ClickEventHandler(this.fgrid_main_ClickEvent);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(1088, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 21);
            this.label7.TabIndex = 66;
            this.label7.Text = "Late 2 days && Up";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Yellow;
            this.label6.Location = new System.Drawing.Point(989, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 21);
            this.label6.TabIndex = 65;
            this.label6.Text = "Late 1 day";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(889, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 21);
            this.label5.TabIndex = 64;
            this.label5.Text = "Ontime";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptb4
            // 
            this.ptb4.BackgroundImage = global::FORM.Properties.Resources.ip_icon_05_sample5e;
            this.ptb4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptb4.Location = new System.Drawing.Point(1315, 486);
            this.ptb4.Name = "ptb4";
            this.ptb4.Size = new System.Drawing.Size(77, 79);
            this.ptb4.TabIndex = 6;
            this.ptb4.TabStop = false;
            // 
            // ptb3
            // 
            this.ptb3.BackgroundImage = global::FORM.Properties.Resources.ip_icon_05_sample5e;
            this.ptb3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptb3.Location = new System.Drawing.Point(1315, 369);
            this.ptb3.Name = "ptb3";
            this.ptb3.Size = new System.Drawing.Size(77, 79);
            this.ptb3.TabIndex = 5;
            this.ptb3.TabStop = false;
            // 
            // ptb2
            // 
            this.ptb2.BackgroundImage = global::FORM.Properties.Resources.ip_icon_05_sample5e;
            this.ptb2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptb2.Location = new System.Drawing.Point(1314, 239);
            this.ptb2.Name = "ptb2";
            this.ptb2.Size = new System.Drawing.Size(77, 79);
            this.ptb2.TabIndex = 4;
            this.ptb2.TabStop = false;
            // 
            // ptb1
            // 
            this.ptb1.BackgroundImage = global::FORM.Properties.Resources.ip_icon_05_sample5e;
            this.ptb1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptb1.Location = new System.Drawing.Point(1315, 114);
            this.ptb1.Name = "ptb1";
            this.ptb1.Size = new System.Drawing.Size(77, 79);
            this.ptb1.TabIndex = 3;
            this.ptb1.TabStop = false;
            // 
            // axfpSpread3
            // 
            this.axfpSpread3.DataSource = null;
            this.axfpSpread3.Location = new System.Drawing.Point(1401, 101);
            this.axfpSpread3.Name = "axfpSpread3";
            this.axfpSpread3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfpSpread3.OcxState")));
            this.axfpSpread3.Size = new System.Drawing.Size(497, 394);
            this.axfpSpread3.TabIndex = 2;
            // 
            // axfpSpread1
            // 
            this.axfpSpread1.DataSource = null;
            this.axfpSpread1.Location = new System.Drawing.Point(4, 3);
            this.axfpSpread1.Name = "axfpSpread1";
            this.axfpSpread1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfpSpread1.OcxState")));
            this.axfpSpread1.Size = new System.Drawing.Size(1893, 76);
            this.axfpSpread1.TabIndex = 1;
            // 
            // axfpSpread2
            // 
            this.axfpSpread2.DataSource = null;
            this.axfpSpread2.Location = new System.Drawing.Point(3, 101);
            this.axfpSpread2.Name = "axfpSpread2";
            this.axfpSpread2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfpSpread2.OcxState")));
            this.axfpSpread2.Size = new System.Drawing.Size(1303, 394);
            this.axfpSpread2.TabIndex = 0;
            // 
            // FORM_NPI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 15);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1916, 1054);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FORM_NPI";
            this.Text = "Form_SMT_NPI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_NPI_MR_Man_Inquiry_Load);
            this.VisibleChanged += new System.EventHandler(this.Form_SMT_NPI_VisibleChanged);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fgrid_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		/// <summary>
		/// 즐겨찾기 추가
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>


		/// <summary>
		/// 툴바 버튼 권한 설정
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Form_NPI_MR_Man_Inquiry_Load(object sender, System.EventArgs e)
		{
            setConfigForm();
            Init_Form();            
          
            showAnimation(fgrid_main);

            //showAnimation(axfpSpread2);
        }

        private void showAnimation(Control flg)
        {
            
            this.Cursor = Cursors.WaitCursor;            
            flg.Hide();
            SearchData("S");
            AnimateWindow(flg.Handle, 300, AW_SLIDE | 0X4); //IPEX_Monitor.ClassLib.WinAPI.getSlidType("2")
            flg.Show();
            this.Cursor = Cursors.Default;
        }

        private void getData()
        {
            //ComVar.vDt2 = SEL_DATA("A","","");
        }

        private void Init_Form()
        {
            timer1.Interval = 1000;
            timer1.Start();                     

            ptb1.Visible = false;
            ptb2.Visible = false;
            ptb3.Visible = false;
            ptb4.Visible = false;
            
          
        }

        
        private DataTable SEL_DATA(string div, string arg_line_cd, string arg_season_cd,string arg_td_code, string arg_model_cd)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "PKG_SQA_NPI_PROJECT_2.SEL_NPI_MR_MAN_DISPLAY_V2";

                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_DIV";
                MyOraDB.Parameter_Name[1] = "ARG_PLANT";
                MyOraDB.Parameter_Name[2] = "ARG_MODEL_CD";
                MyOraDB.Parameter_Name[3] = "ARG_TD_CODE";
                MyOraDB.Parameter_Name[4] = "ARG_SEASON";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = div;
                MyOraDB.Parameter_Values[1] =  "202";// arg_line_cd;
                MyOraDB.Parameter_Values[2] = arg_model_cd;
                MyOraDB.Parameter_Values[3] = arg_td_code;
                MyOraDB.Parameter_Values[4] = arg_season_cd;
                MyOraDB.Parameter_Values[5] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }

        }

        private DataTable SEL_FILE(string arg_file, string arg_plant, string arg_model, string arg_td_code, string arg_season)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "PKG_SQA_NPI_PROJECT_2.SEL_NPI_MR_FILE";

                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_FILE";
                MyOraDB.Parameter_Name[1] = "ARG_PLANT";
                MyOraDB.Parameter_Name[2] = "ARG_MODEL_CD";
                MyOraDB.Parameter_Name[3] = "ARG_TD_CODE";
                MyOraDB.Parameter_Name[4] = "ARG_SEASON";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = arg_file;
                MyOraDB.Parameter_Values[1] = arg_plant;
                MyOraDB.Parameter_Values[2] = arg_model;
                MyOraDB.Parameter_Values[3] = arg_td_code;
                MyOraDB.Parameter_Values[4] = arg_season;
                MyOraDB.Parameter_Values[5] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }

        }

        private void SearchData(string div)
        {
            try
            {
                int fgCol = 7;

               // fgrid_main.Rows.Fixed = 4;

               // Clear_FlexGrid(fgrid_main);
                string plant = "",
                       tdcode = "",
                       season = "",
                       model = "";
                DataTable vDt1, vDtM2;
                vDt1 = null;
                vDtM2 = null;


                if (plant == "" && tdcode == "" && season == "" && model == "")
                {

                    vDtM2 = SEL_DATA("M", sLine_CD, "", "", "");
                }


                // Search Total
                vDt1 = SEL_DATA("T", sLine_CD, "", "", "");

                if (vDt1 == null || vDt1.Rows.Count < 1) return;    
                if (vDtM2 == null || vDtM2.Rows.Count < 1) return;               

                DataTable dt_temp = new DataTable();
                dt_temp = vDt1.Copy();       

                foreach (DataRow dr in vDtM2.Rows)
                {

                    dt_temp.Rows.Add(dr.ItemArray);
                }

                if (dt_temp != null && dt_temp.Rows.Count > 0)
                {
                    if (dt_temp.Rows.Count > 5) fgrid_main.ScrollBars = FPUSpreadADO.ScrollBarsConstants.ScrollBarsVertical;
                    else fgrid_main.ScrollBars = FPUSpreadADO.ScrollBarsConstants.ScrollBarsNone;
                    for(int iRow = 0; iRow < dt_temp.Rows.Count; iRow++)
                    {
                        fgrid_main.set_RowHeight(iRow, 33);
                        fgrid_main.SetText(1, iRow + 4, dt_temp.Rows[iRow]["PLANT"].ToString());
                        fgrid_main.SetText(2, iRow + 4, dt_temp.Rows[iRow]["SEASON_NAME"].ToString());
                        fgrid_main.SetText(3, iRow + 4, dt_temp.Rows[iRow]["MODEL_NAME"].ToString());
                        fgrid_main.SetText(4, iRow + 4, dt_temp.Rows[iRow]["MR2_NM"].ToString());
                        fgrid_main.SetText(5, iRow + 4, dt_temp.Rows[iRow]["MR2_S"].ToString());
                        Set_Condition_Color(fgrid_main, iRow + 4,  5, dt_temp.Rows[iRow]["MR2_NM"].ToString(), dt_temp.Rows[iRow]["MR2_S"].ToString());

                        if (dt_temp.Rows[iRow]["MR2_FILE_NM"].ToString().Contains(".ppt") || dt_temp.Rows[iRow]["MR2_FILE_NM"].ToString().Contains(".pptx"))
                        {
                            fgrid_main.SetText(6, iRow + 4, dt_temp.Rows[iRow]["MR2_FILE_NM"].ToString());

                            fgrid_main.Row = iRow + 4;
                            fgrid_main.Col = 6;
                            fgrid_main.CellType = FPUSpreadADO.CellTypeConstants.CellTypePicture;
                            fgrid_main.TypePictPicture = fgrid_main.LoadPicture(Application.StartupPath + "\\Icon" + "\\PowerPoint.jpg", FPUSpreadADO.PictureTypeConstants.PictureTypeJPEG);

                           // fgrid_main.TypePictStretch = true;
                            fgrid_main.TypePictCenter = true;


                        }
                        else if (dt_temp.Rows[iRow]["MR2_FILE_NM"].ToString().Contains(".xls") || dt_temp.Rows[iRow]["MR2_FILE_NM"].ToString().Contains(".xlsx"))
                        {
                            fgrid_main.SetText(6, iRow + 4, dt_temp.Rows[iRow]["MR2_FILE_NM"].ToString());

                            fgrid_main.Row = iRow + 4;
                            fgrid_main.Col = 6;
                            fgrid_main.CellType = FPUSpreadADO.CellTypeConstants.CellTypePicture;
                            fgrid_main.TypePictPicture = fgrid_main.LoadPicture(Application.StartupPath + "\\Icon" + "\\Excel.jpg", FPUSpreadADO.PictureTypeConstants.PictureTypeJPEG);

                           // fgrid_main.TypePictStretch = true;
                            fgrid_main.TypePictCenter = true;
                        }
                        {

                        }
                        fgrid_main.SetText(7, iRow + 4, dt_temp.Rows[iRow]["MR31_NM"].ToString());
                        fgrid_main.SetText(8, iRow + 4, dt_temp.Rows[iRow]["MR31_S"].ToString());

                        Set_Condition_Color(fgrid_main, iRow + 4, 8, dt_temp.Rows[iRow]["MR31_NM"].ToString(), dt_temp.Rows[iRow]["MR31_S"].ToString());


                        if (dt_temp.Rows[iRow]["MR31_FILE_NM"].ToString().Contains(".ppt") || dt_temp.Rows[iRow]["MR31_FILE_NM"].ToString().Contains(".pptx"))
                        {
                            fgrid_main.SetText(9, iRow + 4, dt_temp.Rows[iRow]["MR31_FILE_NM"].ToString());

                            fgrid_main.Row = iRow + 4;
                            fgrid_main.Col = 9;
                            fgrid_main.CellType = FPUSpreadADO.CellTypeConstants.CellTypePicture;
                            fgrid_main.TypePictPicture = fgrid_main.LoadPicture(Application.StartupPath + "\\Icon" + "\\PowerPoint.jpg", FPUSpreadADO.PictureTypeConstants.PictureTypeJPEG);

                           // fgrid_main.TypePictStretch = true;
                            fgrid_main.TypePictCenter = true;


                        } else if (dt_temp.Rows[iRow]["MR31_FILE_NM"].ToString().Contains(".xls") || dt_temp.Rows[iRow]["MR31_FILE_NM"].ToString().Contains(".xlsx"))
                            {
                                fgrid_main.SetText(9, iRow + 4, dt_temp.Rows[iRow]["MR31_FILE_NM"].ToString());
                                fgrid_main.Row = iRow + 4;
                                fgrid_main.Col = 9;
                                fgrid_main.CellType = FPUSpreadADO.CellTypeConstants.CellTypePicture;
                                fgrid_main.TypePictPicture = fgrid_main.LoadPicture(Application.StartupPath + "\\Icon" + "\\Excel.jpg", FPUSpreadADO.PictureTypeConstants.PictureTypeJPEG);

                               // fgrid_main.TypePictStretch = true;
                                fgrid_main.TypePictCenter = true;


                            }
                        
                        fgrid_main.SetText(10, iRow + 4, dt_temp.Rows[iRow]["MR32_NM"].ToString());
                        fgrid_main.SetText(11, iRow + 4, dt_temp.Rows[iRow]["MR32_S"].ToString());
                        Set_Condition_Color(fgrid_main, iRow + 4, 11, dt_temp.Rows[iRow]["MR32_NM"].ToString(), dt_temp.Rows[iRow]["MR32_S"].ToString());
                        if (dt_temp.Rows[iRow]["MR32_FILE_NM"].ToString().Contains(".ppt") || dt_temp.Rows[iRow]["MR32_FILE_NM"].ToString().Contains(".pptx"))
                        {
                            fgrid_main.SetText(12, iRow + 4, dt_temp.Rows[iRow]["MR32_FILE_NM"].ToString());

                            fgrid_main.Row = iRow + 4;
                            fgrid_main.Col = 12;
                            fgrid_main.CellType = FPUSpreadADO.CellTypeConstants.CellTypePicture;
                            fgrid_main.TypePictPicture = fgrid_main.LoadPicture(Application.StartupPath + "\\Icon" + "\\PowerPoint.jpg", FPUSpreadADO.PictureTypeConstants.PictureTypeJPEG);

                           // fgrid_main.TypePictStretch = true;
                            fgrid_main.TypePictCenter = true;


                        }
                        else if (dt_temp.Rows[iRow]["MR32_FILE_NM"].ToString().Contains(".xls") || dt_temp.Rows[iRow]["MR32_FILE_NM"].ToString().Contains(".xlsx"))
                        {
                            fgrid_main.SetText(12, iRow + 4, dt_temp.Rows[iRow]["MR32_FILE_NM"].ToString());

                            fgrid_main.Row = iRow + 4;
                            fgrid_main.Col = 12;
                            fgrid_main.CellType = FPUSpreadADO.CellTypeConstants.CellTypePicture;
                            fgrid_main.TypePictPicture = fgrid_main.LoadPicture(Application.StartupPath + "\\Icon" + "\\Excel.jpg", FPUSpreadADO.PictureTypeConstants.PictureTypeJPEG);

                           // fgrid_main.TypePictStretch = true;
                            fgrid_main.TypePictCenter = true;


                        }
                        
                        fgrid_main.SetText(13, iRow + 4, dt_temp.Rows[iRow]["MR33_NM"].ToString());
                        fgrid_main.SetText(14, iRow + 4, dt_temp.Rows[iRow]["MR33_S"].ToString());
                        Set_Condition_Color(fgrid_main, iRow + 4, 14, dt_temp.Rows[iRow]["MR33_NM"].ToString(), dt_temp.Rows[iRow]["MR33_S"].ToString());
                        if (dt_temp.Rows[iRow]["MR33_FILE_NM"].ToString().Contains(".ppt") || dt_temp.Rows[iRow]["MR33_FILE_NM"].ToString().Contains(".pptx"))
                        {
                            fgrid_main.SetText(15, iRow + 4, dt_temp.Rows[iRow]["MR33_FILE_NM"].ToString());

                            fgrid_main.Row = iRow + 4;
                            fgrid_main.Col = 15;
                            fgrid_main.CellType = FPUSpreadADO.CellTypeConstants.CellTypePicture;
                            fgrid_main.TypePictPicture = fgrid_main.LoadPicture(Application.StartupPath + "\\Icon" + "\\PowerPoint.jpg", FPUSpreadADO.PictureTypeConstants.PictureTypeJPEG);

                           // fgrid_main.TypePictStretch = true;
                            fgrid_main.TypePictCenter = true;


                        }
                        else if (dt_temp.Rows[iRow]["MR33_FILE_NM"].ToString().Contains(".xls") || dt_temp.Rows[iRow]["MR33_FILE_NM"].ToString().Contains(".xlsx"))
                        {
                            fgrid_main.SetText(15, iRow + 4, dt_temp.Rows[iRow]["MR33_FILE_NM"].ToString());

                            fgrid_main.Row = iRow + 4;
                            fgrid_main.Col = 15;
                            fgrid_main.CellType = FPUSpreadADO.CellTypeConstants.CellTypePicture;
                            fgrid_main.TypePictPicture = fgrid_main.LoadPicture(Application.StartupPath + "\\Icon" + "\\Excel.jpg", FPUSpreadADO.PictureTypeConstants.PictureTypeJPEG);

                           // fgrid_main.TypePictStretch = true;
                            fgrid_main.TypePictCenter = true;


                        }
                        //fgrid_main.SetText(14, iRow + 4, dt_temp.Rows[iRow]["MR33_FILE_NM"].ToString());
                        fgrid_main.SetText(16, iRow + 4, dt_temp.Rows[iRow]["MAJOR"].ToString());
                        fgrid_main.SetText(17, iRow + 4, dt_temp.Rows[iRow]["MINOR"].ToString());

                        if (dt_temp.Rows[iRow]["TRIAL_FILE_NM"].ToString().Contains(".ppt") || dt_temp.Rows[iRow]["TRIAL_FILE_NM"].ToString().Contains(".pptx"))
                        {
                            fgrid_main.SetText(18, iRow + 4, dt_temp.Rows[iRow]["TRIAL_FILE_NM"].ToString());

                            fgrid_main.Row = iRow + 4;
                            fgrid_main.Col = 18;
                            fgrid_main.CellType = FPUSpreadADO.CellTypeConstants.CellTypePicture;
                            fgrid_main.TypePictPicture = fgrid_main.LoadPicture(Application.StartupPath + "\\Icon" + "\\PowerPoint.jpg", FPUSpreadADO.PictureTypeConstants.PictureTypeJPEG);

                           // fgrid_main.TypePictStretch = true;
                            fgrid_main.TypePictCenter = true;


                        }
                        else if (dt_temp.Rows[iRow]["TRIAL_FILE_NM"].ToString().Contains(".xls") || dt_temp.Rows[iRow]["TRIAL_FILE_NM"].ToString().Contains(".xlsx"))
                        {
                            fgrid_main.SetText(18, iRow + 4, dt_temp.Rows[iRow]["TRIAL_FILE_NM"].ToString());

                            fgrid_main.Row = iRow + 4;
                            fgrid_main.Col = 18;
                            fgrid_main.CellType = FPUSpreadADO.CellTypeConstants.CellTypePicture;
                            fgrid_main.TypePictPicture = fgrid_main.LoadPicture(Application.StartupPath + "\\Icon" + "\\Excel.jpg", FPUSpreadADO.PictureTypeConstants.PictureTypeJPEG);

                           // fgrid_main.TypePictStretch = true;
                            fgrid_main.TypePictCenter = true;


                        }
                       // fgrid_main.SetText(17, iRow + 4, dt_temp.Rows[iRow]["TRIAL_FILE_NM"].ToString());
                        if (dt_temp.Rows[iRow]["EX_FILE_NM"].ToString().Contains(".ppt") || dt_temp.Rows[iRow]["EX_FILE_NM"].ToString().Contains(".pptx"))
                        {
                            fgrid_main.SetText(19, iRow + 4, dt_temp.Rows[iRow]["EX_FILE_NM"].ToString());

                            fgrid_main.Row = iRow + 4;
                            fgrid_main.Col = 19;
                            fgrid_main.CellType = FPUSpreadADO.CellTypeConstants.CellTypePicture;
                            fgrid_main.TypePictPicture = fgrid_main.LoadPicture(Application.StartupPath + "\\Icon" + "\\PowerPoint.jpg", FPUSpreadADO.PictureTypeConstants.PictureTypeJPEG);

                            //fgrid_main.TypePictStretch = true;
                            fgrid_main.TypePictCenter = true;


                        }
                        else if (dt_temp.Rows[iRow]["EX_FILE_NM"].ToString().Contains(".xls") || dt_temp.Rows[iRow]["EX_FILE_NM"].ToString().Contains(".xlsx"))
                        {
                            fgrid_main.SetText(19, iRow + 4, dt_temp.Rows[iRow]["EX_FILE_NM"].ToString());

                            fgrid_main.Row = iRow + 4;
                            fgrid_main.Col = 19;
                            fgrid_main.CellType = FPUSpreadADO.CellTypeConstants.CellTypePicture;
                            fgrid_main.TypePictPicture = fgrid_main.LoadPicture(Application.StartupPath + "\\Icon" + "\\Excel.jpg", FPUSpreadADO.PictureTypeConstants.PictureTypeJPEG);

                            //fgrid_main.TypePictStretch = true;
                            fgrid_main.TypePictCenter = true;


                        }
                        //fgrid_main.SetText(18, iRow + 4, dt_temp.Rows[iRow]["EX_FILE_NM"].ToString());
                        fgrid_main.SetText(20, iRow + 4, dt_temp.Rows[iRow]["MR4_NM"].ToString());
                        fgrid_main.SetText(21, iRow + 4, dt_temp.Rows[iRow]["MR4_S"].ToString());
                        Set_Condition_Color(fgrid_main, iRow + 4, 21, dt_temp.Rows[iRow]["MR4_NM"].ToString(), dt_temp.Rows[iRow]["MR4_S"].ToString());
                        if (dt_temp.Rows[iRow]["MR4_FILE_NM"].ToString().Contains(".ppt") || dt_temp.Rows[iRow]["MR4_FILE_NM"].ToString().Contains(".pptx"))
                        {
                            fgrid_main.SetText(22, iRow + 4, dt_temp.Rows[iRow]["MR4_FILE_NM"].ToString());

                            fgrid_main.Row = iRow + 4;
                            fgrid_main.Col = 22;
                            fgrid_main.CellType = FPUSpreadADO.CellTypeConstants.CellTypePicture;
                            fgrid_main.TypePictPicture = fgrid_main.LoadPicture(Application.StartupPath + "\\Icon" + "\\PowerPoint.jpg", FPUSpreadADO.PictureTypeConstants.PictureTypeJPEG);

                            //fgrid_main.TypePictStretch = true;
                            fgrid_main.TypePictCenter = true;


                        }
                        else if (dt_temp.Rows[iRow]["MR4_FILE_NM"].ToString().Contains(".xls") || dt_temp.Rows[iRow]["MR4_FILE_NM"].ToString().Contains(".xlsx"))
                        {
                            fgrid_main.SetText(22, iRow + 4, dt_temp.Rows[iRow]["MR4_FILE_NM"].ToString());

                            fgrid_main.Row = iRow + 4;
                            fgrid_main.Col = 22;
                            fgrid_main.CellType = FPUSpreadADO.CellTypeConstants.CellTypePicture;
                            fgrid_main.TypePictPicture = fgrid_main.LoadPicture(Application.StartupPath + "\\Icon" + "\\Excel.jpg", FPUSpreadADO.PictureTypeConstants.PictureTypeJPEG);

                            //fgrid_main.TypePictStretch = true;
                            fgrid_main.TypePictCenter = true;


                        }                        
                        fgrid_main.SetText(23, iRow + 4, dt_temp.Rows[iRow]["DPA"].ToString());
                        fgrid_main.SetText(24, iRow + 4, dt_temp.Rows[iRow]["MODEL_CD"].ToString());
                        fgrid_main.SetText(25, iRow + 4, dt_temp.Rows[iRow]["TD_CD"].ToString());
                        fgrid_main.SetText(26, iRow + 4, dt_temp.Rows[iRow]["SEASON"].ToString());
                        fgrid_main.SetText(27, iRow + 4, dt_temp.Rows[iRow]["PLANT"].ToString());

                    }
                }

                vDtM2.Dispose();       

                fgrid_main.BringToFront();

                fgrid_main.Row = 5;
                fgrid_main.Col = 23;
                string sDPA = fgrid_main.Value;

                fgrid_main.Row = 5;
                fgrid_main.Col = 26;
                string sSeason = fgrid_main.Value;
                fgrid_main.Row = 5;
                fgrid_main.Col = 25;
                string sTD_CD = fgrid_main.Value;

                fgrid_main.Row = 5;
                fgrid_main.Col = 24;
                string sModel_CD = fgrid_main.Value;

                fgrid_main.Row = 5;
                fgrid_main.Col = 27;
                string sPlant = fgrid_main.Value;

                for (int iRow = dt_temp.Rows.Count + 4; iRow < fgrid_main.MaxRows+1; iRow++)
                {
                    fgrid_main.set_RowHeight(iRow, 0);
                }

                Search_Tail(sPlant, sSeason, sTD_CD, sModel_CD);
               
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        

        private void Search_Tail(string arg_line, string arg_season, string arg_tcode, string arg_model)
        {
            int i = 0;
            int c = 0;
            try
            {
                
                axfpSpread2.Hide();
                Clear_Grid(axfpSpread2);
                //DataTable dtHeader = SEL_DATA("H",arg_line, arg_season,arg_tcode, arg_model);
                DataTable dt = SEL_DATA("V",arg_line, arg_season,arg_tcode, arg_model);
                int iRow = 1;
             


                if (dt != null)
                {
                    
                    for (i = 0; i < dt.Rows.Count; i++)
                    {
                        bool bRun = false;
                       
                        for (c = 0; c < dt.Columns.Count; c++)
                        {
                            if (c == 0)
                            {
                                axfpSpread2.SetText(c + 1, i + iRow, dt.Rows[i]["MODEL_NAME"].ToString());
                                axfpSpread2.set_RowHeight(i + iRow, 27);
                            }
                            else
                            {

                                axfpSpread2.SetText(c, i + 1 + iRow, dt.Columns[c].Caption.ToString().Substring(0 , dt.Columns[c].Caption.ToString().IndexOf('(')));
                                axfpSpread2.set_RowHeight(i + 1 + iRow, 22);
                                double sVal = 0 ;
                                if (dt.Rows[i][c].ToString().Trim() != "")
                                {
                                    sVal = Convert.ToDouble(dt.Rows[i][c].ToString());
                                    bRun = true;
                                }
                                axfpSpread2.Col = c;
                                axfpSpread2.Row = i + 2 + iRow;

                                if (sVal == 5 )
                                {
                                    axfpSpread2.BackColor = Color.Green;
                                    axfpSpread2.ForeColor = Color.White;
                                }
                                else if (sVal == 4 )
                                {
                                    axfpSpread2.BackColor = Color.Yellow;
                                    axfpSpread2.ForeColor = Color.Black;
                                }
                                else if (sVal > 0)
                                {
                                    axfpSpread2.BackColor = Color.Red;
                                    axfpSpread2.ForeColor = Color.White;
                                }
                                else
                                {
                                    axfpSpread2.BackColor = Color.White;
                                    axfpSpread2.ForeColor = Color.Black;
                                }
                                if (sVal != 0)
                                {
                                    sVal = 5 - sVal;
                                    if (sVal != 0)
                                    {
                                        axfpSpread2.SetText(c, i + 2 + iRow, "+" + sVal.ToString());
                                    }
                                    else
                                    {
                                        axfpSpread2.SetText(c, i + 2 + iRow, "");
                                    }
                                }
                                else
                                {
                                    axfpSpread2.SetText(c, i + 2 + iRow, "NA");
                                }
                                axfpSpread2.set_RowHeight(i + 2 + iRow, 22);
                            }
                        }

                        if (!bRun)
                        {
                            axfpSpread2.AddCellSpan(1, i + 2 + iRow, axfpSpread2.MaxCols, 1);
                            axfpSpread2.Row = i + 2 + iRow;
                            axfpSpread2.Col = 1;
                            axfpSpread2.BackColor = Color.DeepSkyBlue;
                            axfpSpread2.SetText(1, i + 2 + iRow, "Not Run");

                        }
                        axfpSpread2.Col = 1;
                        axfpSpread2.Row = i + iRow;
                        axfpSpread2.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignLeft;
                        axfpSpread2.AddCellSpan(1, i + iRow, 31, 1);
                        axfpSpread2.AddCellSpan(1, i + 3 + iRow, 31, 1);
                        axfpSpread2.set_RowHeight(i + 3 + iRow, 21);
                        iRow += 3;

                    }
                    for (i = dt.Rows.Count + iRow - 1 ; i < 31; i++)
                    {
                        axfpSpread2.set_RowHeight(i , 0);
                    }

                }

                AnimateWindow(axfpSpread2.Handle, 300, AW_SLIDE | 0X4);
                axfpSpread2.Show();

                Search_Result(arg_line, arg_season, arg_tcode, arg_model);
            }
            catch (Exception ex)
            {
                MessageBox.Show("i:" + i + " - c:" + c);
            }
        }

        private void Search_Result(string arg_line, string arg_season, string arg_tcode, string arg_model)
        {
            int i = 0;
            int c = 0;
            try
            {

               axfpSpread3.Hide();
                Clear_Grid(axfpSpread3);
                //DataTable dtHeader = SEL_DATA("H",arg_line, arg_season,arg_tcode, arg_model);
                DataTable dt = SEL_DATA("K", arg_line, arg_season, arg_tcode, arg_model);
                int iRow = 0;



                if (dt != null)
                {
                    ptb1.Visible = false;
                    ptb2.Visible = false;
                    ptb3.Visible = false;
                    ptb4.Visible = false;

                    i = 0;
                    iRow = 0;
                    int iRowIndex = 0;
                    for (i = 0; i < dt.Rows.Count; i++)
                    {
               
                        if (dt.Rows[i]["TAIL_CD"].ToString() != "01")
                        {

                            axfpSpread3.SetText(2, iRowIndex + 1, dt.Rows[i]["TAIL_NM"].ToString());
                            axfpSpread3.SetText(3, iRowIndex + 1, dt.Rows[i]["VALUE1"].ToString());
                            axfpSpread3.SetText(4, iRowIndex + 1, dt.Rows[i]["VALUE2"].ToString());
                            //axfpSpread3.SetText(5, iRowIndex + 1, dt.Rows[i]["VALUE3"].ToString());
                            //axfpSpread3.SetText(6, iRowIndex + 1, dt.Rows[i]["VALUE4"].ToString());
                            //axfpSpread3.SetText(7, iRowIndex + 1, dt.Rows[i]["VALUE5"].ToString());

                            //axfpSpread3.SetText(8, iRowIndex + 1, dt.Rows[i]["VALUE6"].ToString());
                            //axfpSpread3.SetText(9, iRowIndex + 1, dt.Rows[i]["VALUE7"].ToString());
                            //axfpSpread3.SetText(10, iRowIndex + 1, dt.Rows[i]["VALUE8"].ToString());
                            //axfpSpread3.SetText(11, iRowIndex + 1, dt.Rows[i]["VALUE9"].ToString());
                            //axfpSpread3.SetText(12, iRowIndex + 1, dt.Rows[i]["VALUE10"].ToString());

                            //axfpSpread3.SetText(13, iRowIndex + 1, dt.Rows[i]["VALUE11"].ToString());
                            //axfpSpread3.SetText(14, iRowIndex + 1, dt.Rows[i]["VALUE12"].ToString());
                            axfpSpread3.set_RowHeight(iRowIndex + 1, 19);
                            if (dt.Rows[i]["TAIL_CD"].ToString() == "04")
                            {
                                
                                if (dt.Rows[i]["VALUE1"].ToString().Trim() != "")
                                {
                                    double dRate = 0;
                                    dRate = Convert.ToDouble(dt.Rows[i]["VALUE1"].ToString().Trim());
                                    axfpSpread3.Row = iRowIndex + 1;
                                    axfpSpread3.Col = 3;
                                    if (dRate < 90)
                                    {
                                        axfpSpread3.BackColor = Color.Red;
                                    }
                                    else if (dRate < 95)
                                    {
                                        axfpSpread3.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        axfpSpread3.BackColor = Color.Green;
                                    }
                                }

                                if (dt.Rows[i]["VALUE2"].ToString().Trim() != "")
                                {
                                    double dRate = 0;
                                    dRate = Convert.ToDouble(dt.Rows[i]["VALUE2"].ToString().Trim());
                                    axfpSpread3.Row = iRowIndex + 1;
                                    axfpSpread3.Col = 4;
                                    if (dRate < 90)
                                    {
                                        axfpSpread3.BackColor = Color.Red;
                                    }
                                    else if (dRate < 95)
                                    {
                                        axfpSpread3.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        axfpSpread3.BackColor = Color.Green;
                                    }
                                }


                                axfpSpread3.AddCellSpan(1, iRowIndex + 2, 14, 1);
                                axfpSpread3.set_RowHeight(iRowIndex + 2, 16.2);
                                
                                
                            }
                        }
                        else
                        {
                            if (iRowIndex != 0)
                            {
                                iRowIndex++;
                            }

                            axfpSpread3.SetText(3, iRowIndex + 1, "1st RR");
                            axfpSpread3.SetText(4, iRowIndex + 1, "Aver RR");
                            //axfpSpread3.SetText(5, iRowIndex + 1, "D+3");
                            //axfpSpread3.SetText(6, iRowIndex + 1, "D+4");
                            //axfpSpread3.SetText(7, iRowIndex + 1, "D+5");
                            //axfpSpread3.SetText(8, iRowIndex + 1, "D+6");
                            //axfpSpread3.SetText(9, iRowIndex + 1, "D+7");
                            //axfpSpread3.SetText(10, iRowIndex + 1, "D+8");
                            //axfpSpread3.SetText(11, iRowIndex + 1, "D+9");
                            //axfpSpread3.SetText(12, iRowIndex + 1, "D+10");
                            //axfpSpread3.SetText(13, iRowIndex + 1, "D+11");
                            //axfpSpread3.SetText(14, iRowIndex + 1, "D+12");

                            axfpSpread3.SetText(1, iRowIndex + 1, dt.Rows[i]["VALUE1"].ToString());
                            axfpSpread3.AddCellSpan(1, iRowIndex + 1, 1, 4);
                            axfpSpread3.Row = iRowIndex + 1;
                            axfpSpread3.Col = 1;
                            axfpSpread3.BackColor = Color.DodgerBlue;
                            axfpSpread3.ForeColor = Color.White;
                            iRow++;
                        }
                        if (iRow == 1)
                        {
                            ptb1.Visible = true;
                        }
                        if (iRow == 2)
                        {
                            ptb2.Visible = true;
                        }
                        if (iRow == 3)
                        {
                            ptb3.Visible = true;

                        }

                        if (iRow == 4)
                        {
                            ptb4.Visible = true;
                        }
                        iRowIndex++;
                    }
                    for (i = iRowIndex + 1; i < 31; i++)
                    {
                        axfpSpread3.set_RowHeight(i, 0);
                    }
                    AnimateWindow(axfpSpread3.Handle, 300, AW_SLIDE | 0X4);
                    axfpSpread3.Show();

                    for (int k = axfpSpread3.MaxCols; k >= 1; k--)
                    {
                        axfpSpread3.Row = 1;
                        axfpSpread3.Col = k;
                        if (axfpSpread3.Text != "")
                        {
                            axfpSpread3.MaxCols = k ;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("i:" + i + " - c:" + c);
            }
        }
        
        private void Clear_Grid(AxFPUSpreadADO.AxfpSpread axfpSpread)
        {
            for (int iCol = 1; iCol < axfpSpread.MaxCols +1; iCol++)
            {
                for (int iRow = 1; iRow < axfpSpread.MaxRows; iRow++)
                {
                    axfpSpread.SetText(iCol, iRow, "");
                    axfpSpread.Row = iRow;
                    axfpSpread.Col = iCol;
                    axfpSpread.BackColor = Color.White;
                }
            }
        }


        private void Set_Condition_Color(AxFPUSpreadADO.AxfpSpread axfpSpread, int _iRow, int _iCol, string _sCondition, string _sValue)
        {
            if (_iRow > 5)
            {
                if (_sValue != _sCondition)
                {


                    axfpSpread.Row = _iRow;
                    axfpSpread.Col = _iCol;
                    axfpSpread.BackColor = Color.Red;
                    axfpSpread.ForeColor = Color.White;

                }

                else
                {
                    axfpSpread.Row = _iRow;
                    axfpSpread.Col = _iCol;
                    axfpSpread.BackColor = Color.White;
                    axfpSpread.ForeColor = Color.Black;
                }
            }
            
        }

      

        public enum G : int
        {            
            IxMR2_FILE = 6,
            IxMR31_FILE = 9,
            IxMR32_FILE = 12,
            IxMR33_FILE = 15,
            IxTRIAL_FILE = 18,
            IxEX_FILE = 19,           
            IxMR4_FILE = 22,

        }

        private string get_file_name(int arg_col)
        {
            switch (arg_col)
            {
                case (int)G.IxMR2_FILE:
                    return "MR2";
                case (int)G.IxMR31_FILE:
                    return "MR31";
                case (int)G.IxMR32_FILE:
                    return "MR32";
                case (int)G.IxMR33_FILE:
                    return "MR33";
                case (int)G.IxEX_FILE:
                    return "EX";
                case (int)G.IxTRIAL_FILE:
                    return "TRIAL";
                case (int)G.IxMR4_FILE:
                    return "MR4";
                default:
                    return "";
            }
        }

       
        
         
        private string NullToBlank(object obj)
        {
            if (obj == null)
                return string.Empty;
            return obj.ToString();
        }
        

        private void lblTitle_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "Minimized";
            //this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cnt++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cnt >= 120)
            {
                //showAnimation(fgrid_main);
                cnt = 0;
            }
        }

        private void cmd_Click(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            ComVar.Var.callForm = cnt.Tag == null ? "" : cnt.Tag.ToString();
            //this.Hide();
        }

        private void fgrid_main_ClickEvent(object sender, AxFPUSpreadADO._DSpreadEvents_ClickEvent e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int iCol = e.col;
                if (iCol == 6 || iCol == 9 || iCol == 12 || iCol == 15 || iCol == 18 || iCol == 19 || iCol == 22)
                {

                    string File_nm = "", file_path = "";
                    fgrid_main.Row = e.row;
                    fgrid_main.Col = e.col;
                    string sValue = fgrid_main.Value.ToString();
                    string sDPA = "";
                    string sModel_CD = "";
                    string sTD_CD = "";
                    string sSeason = "";
                    //MessageBox.Show(sValue);
                    if (sValue == "" || sValue == null) return;
                    File_nm = sValue;
                    fgrid_main.Row = e.row;
                    fgrid_main.Col = 23;
                    sDPA = fgrid_main.Value.ToString();

                    fgrid_main.Row = e.row;
                    fgrid_main.Col = 24;
                    sModel_CD = fgrid_main.Value.ToString();

                    fgrid_main.Row = e.row;
                    fgrid_main.Col = 25;
                    sTD_CD = fgrid_main.Value.ToString();

                    fgrid_main.Row = e.row;
                    fgrid_main.Col = 26;
                    sSeason = fgrid_main.Value.ToString();


                    byte[] MyData = new byte[0];
                    DataTable dt = SEL_FILE(get_file_name(e.col), sDPA
                                                 , sModel_CD
                                                 , sTD_CD
                                                 , sSeason);
                    if (dt == null || dt.Rows[0]["MR_FILE"].ToString() == "" || dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Can't show file .! ");
                        return;
                    }
                    MyData = (byte[])dt.Rows[0]["MR_FILE"];

                    int ArraySize = new int();
                    ArraySize = MyData.GetUpperBound(0) + 1;

                    file_path = Directory.GetCurrentDirectory() + @"\file\";

                    if (!File.Exists(file_path + File_nm))
                    {
                        FileStream fs = new FileStream(file_path + File_nm, FileMode.OpenOrCreate, FileAccess.Write);

                        fs.Write(MyData, 0, ArraySize);
                        fs.Close();
                    }
                    // Open File

                    Process myProcess = new Process();
                    myProcess.StartInfo.FileName = file_path + File_nm; //Here you use your own application file,uninstaller or something else
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                    //  this.TopMost = false;
                    myProcess.Start();

                    //  myProcess.WaitForExit();

                    // this.TopMost = true;


                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            //Control cnt = (Control)sender;
            ComVar.Var.callForm = "back";
            // this.Hide();
        }

        #region  Get Config Data From Database
        /// <summary>
        /// Declare _dtnInit
        /// Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        /// </summary>
        private void setConfigForm()
        {
            try
            {
                System.Collections.Generic.Dictionary<string, string> dtnInit = new System.Collections.Generic.Dictionary<string, string>();
                dtnInit = ComVar.Func.getInitForm(this.GetType().Assembly.GetName().Name, this.GetType().Name);
               // dtnInit = ComVar.Func.getInitForm(ComVar.Var._Area + this.GetType().Assembly.GetName().Name, this.GetType().Name);

                for (int i = 0; i < dtnInit.Count; i++)
                {
                    setComValue(dtnInit.ElementAt(i).Key, dtnInit.ElementAt(i).Value);
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setConfigForm-->Err:    " + ex.ToString());
            }
        }
        private void setComValue(string obj, string obj_value)
        {
            try
            {
                if (obj.Contains('.'))
                {
                    string[] strSplit = obj.Split('.');
                    Control[] cnt = this.Controls.Find(strSplit[0], true);

                    for (int i = 0; i < cnt.Length; i++)
                    {
                        System.Reflection.PropertyInfo propertyInfo = cnt[i].GetType().GetProperty(strSplit[1]);
                        propertyInfo.SetValue(cnt[i], Convert.ChangeType(obj_value, propertyInfo.PropertyType), null);
                    }
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setComValue (" + obj + ", " + obj_value + ") Err:    " + ex.ToString());
            }

        }
        #endregion 

        private void Form_SMT_NPI_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cmdBack.Tag = "538";// ComVar.Var._Frm_Back;
            //    this.TopMost = true;
            //    this.TopMost = false;
            }
        }

        
	}
}
