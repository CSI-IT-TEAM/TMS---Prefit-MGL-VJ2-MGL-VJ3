using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Runtime.InteropServices;
using DevExpress.XtraCharts;

namespace FORM
{
    public partial class FRM_MGL_EXTERNAL_OSD : Form
    {
        public FRM_MGL_EXTERNAL_OSD()
        {
            InitializeComponent();
            //tmrDate.Stop();
        }

        const int AW_SLIDE = 0X40000;
        const int AW_HOR_POSITIVE = 0X4;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_BLEND = 0X80000;
        const int AW_HIDE = 0x00010000;
      //  init strinit = new init();
        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);

        int indexScreen;
        string line, Mline, Lang;
        public FRM_MGL_EXTERNAL_OSD(string Title, int _indexScreen, string _Line, string _Mline, string _Lang)
        {
            InitializeComponent();
            indexScreen = _indexScreen;
            Mline = _Mline;
            line = _Line;
            Lang = _Lang;
            tmrDate.Stop();
            //arrForm[2] = new FRM_SMT_MON_PROD_STATS("Monthly Productivity Status", 1, _Line, _Mline); //Lenl
           // lblTitle.Text = Title;
        }

        public void SetData(string Title, int _indexScreen, string _Line, string _Mline, string _Lang)
        {
            indexScreen = _indexScreen;
            Mline = _Mline;
            line = _Line;
            Lang = _Lang;
            tmrDate.Stop();

            lblTitle.Text = Title;
        }
        public DataTable SP_SMT_OSD_DETAIL(string V_P_OSD_LINE, string V_P_MLINE_CD, string V_P_DATE_FROM, string V_P_DATE_TO, string V_P_OP_CD, string V_P_CONFIRM_CHK)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_PHUOC.SP_SMT_OSD_DETAIL";

                MyOraDB.ReDim_Parameter(7);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_OSD_LINE";
                MyOraDB.Parameter_Name[1] = "V_P_MLINE_CD";
                MyOraDB.Parameter_Name[2] = "V_P_DATE_FROM";
                MyOraDB.Parameter_Name[3] = "V_P_DATE_TO";
                MyOraDB.Parameter_Name[4] = "V_P_OP_CD";
                MyOraDB.Parameter_Name[5] = "V_P_CONFIRM_CHK";
                MyOraDB.Parameter_Name[6] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[6] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = V_P_OSD_LINE;
                MyOraDB.Parameter_Values[1] = V_P_MLINE_CD;
                MyOraDB.Parameter_Values[2] = V_P_DATE_FROM;
                MyOraDB.Parameter_Values[3] = V_P_DATE_TO;
                MyOraDB.Parameter_Values[4] = V_P_OP_CD;
                MyOraDB.Parameter_Values[5] = V_P_CONFIRM_CHK;
                MyOraDB.Parameter_Values[6] = "";


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
        public DataTable SP_SMT_OSD_DAILY(string ARG_COMP_NAME, string ARG_LINE_CD, string ARG_MLINE_CD, string ARG_MONTH)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_DSF_NOS.SP_SMT_OSD_DAILY_DIV_V2";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_COMP_NAME";
                MyOraDB.Parameter_Name[1] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[2] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[3] = "ARG_MONTH";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_COMP_NAME;
                MyOraDB.Parameter_Values[1] = ComVar.Var._strValue1;
                MyOraDB.Parameter_Values[2] = ComVar.Var._strValue2;
                MyOraDB.Parameter_Values[3] = ARG_MONTH;
                MyOraDB.Parameter_Values[4] = "";


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

        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }

        private void FRM_SMT_OSD_DAILY_PHUOC_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            GoFullscreen();
            setConfigForm();
           // this.Cursor = Cursors.WaitCursor;
            //BindingOSDDaily();
          //  if (!bgw.IsBusy)
           //     bgw.RunWorkerAsync();
            //BindingOSDWeekly("IPPH");
            //BindingOSDWeekly("IN");
            //BindingOSDWeekly("DMPPU");
            //BindingOSDWeekly("OS");
            //load_data();
          //  this.Cursor = Cursors.Default;
        }

        private string GetText(AxFPSpreadADO.AxfpSpread spread, int col, int row)
        {
            try
            {
                object data = null;
                spread.GetText(col, row, ref data);
                return data.ToString();
            }
            catch 
            {
                //return "";
                //log.Error(ex);
                return null;
            }

        }


        private void CLearGrid()
        {
            for (int iRow = 2; iRow <= axfpOSD.MaxRows; iRow++)
            {
                for (int iCol = 2; iCol <= axfpOSD.MaxCols; iCol++)
                {
                    axfpOSD.SetText(iCol, iRow, "");
                    axfpOSD.Row = iRow;
                    axfpOSD.Col = iCol;
                    if (iRow < axfpOSD.MaxRows)
                    {

                        axfpOSD.BackColor = Color.White;
                        axfpOSD.ForeColor = Color.Black;
                    }
                    else
                    {
                        axfpOSD.BackColor = Color.FromArgb(251, 255, 209);
                        axfpOSD.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void Animation(AxFPSpreadADO.AxfpSpread Grid, DataTable dt)
        {
            Grid.Hide();
            this.Cursor = Cursors.WaitCursor;
            BindingGrid(dt);
            AnimateWindow(Grid.Handle, 500, AW_SLIDE | 0X4); //IPEX_Monitor.ClassLib.WinAPI.getSlidType("2")
            Grid.Show();
            this.Cursor = Cursors.Default;

        }

        private void BindingGrid(DataTable dt)
        {

            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {

                    axfpOSD.MaxCols = dt.Rows.Count + 3;
                    CLearGrid();

                    axfpOSD.set_ColWidth(1, 9d);


                    axfpOSD.SetText(1, 1, dt.Rows[0]["OSD_YMD"].ToString().Substring(0, 3));

                    for (int iCol = 2; iCol <= axfpOSD.MaxCols; iCol++)
                    {
                        axfpOSD.set_ColWidth(iCol, 123d / (axfpOSD.MaxCols - 1));
                        axfpOSD.Row = 1;
                        axfpOSD.Col = iCol;
                        axfpOSD.BackColor = Color.FromArgb(192, 192, 192);
                        axfpOSD.ForeColor = Color.Black;
                        axfpOSD.Font = new System.Drawing.Font("Calibri", 12, FontStyle.Bold);
                    }
                    axfpOSD.SetText(axfpOSD.MaxCols - 1, 1, "AVG");
                    axfpOSD.SetText(axfpOSD.MaxCols, 1, "TOT");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        // for (int iCol = 1; iCol < axfpOSD.MaxCols; iCol++)
                        // {
                        //if (dt.Rows[i]["OSD_YMD"].ToString().Substring(4, 2).Equals(GetText(this.axfpOSD,iCol,1)))
                        //  {

                        axfpOSD.SetText(i + 2, 1, dt.Rows[i]["OSD_YMD"].ToString().Substring(4, 2));
                        axfpOSD.SetText(i + 2, 2, dt.Rows[i]["IN"].ToString());
                        axfpOSD.SetText(i + 2, 3, dt.Rows[i]["OS"].ToString());
                        axfpOSD.SetText(i + 2, 4, dt.Rows[i]["IP"].ToString());
                        axfpOSD.SetText(i + 2, 5, dt.Rows[i]["PH"].ToString());
                        axfpOSD.SetText(i + 2, 6, dt.Rows[i]["DMP"].ToString());
                        axfpOSD.SetText(i + 2, 7, dt.Rows[i]["PU"].ToString());
                        axfpOSD.SetText(i + 2, 8, dt.Rows[i]["TOT"].ToString());


                        if (dt.Rows[i]["TODAY"].ToString().Equals(GetText(this.axfpOSD, i + 2, 1)))
                        {
                            axfpOSD.Col = i + 2;

                            for (int iRow = 2; iRow <= axfpOSD.MaxRows; iRow++)
                            {
                                axfpOSD.Row = iRow;
                                axfpOSD.BackColor = Color.Orange;
                            }

                        }

                        for (int iRow = 1; iRow <= 8; iRow++)
                        {
                            axfpOSD.Row = iRow + 1;
                            axfpOSD.Col = i + 2;
                            axfpOSD.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber;
                            axfpOSD.TypeNumberDecPlaces = 1;
                            axfpOSD.TypeNumberShowSep = true;
                            axfpOSD.Font = new System.Drawing.Font("Calibri", 11, FontStyle.Bold);
                            axfpOSD.SetCellBorder(1, 1, axfpOSD.MaxCols, axfpOSD.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexTop, 1, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                            axfpOSD.SetCellBorder(1, 1, axfpOSD.MaxCols, axfpOSD.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexRight, 1, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                            axfpOSD.SetCellBorder(1, 1, axfpOSD.MaxCols, axfpOSD.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 1, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                            axfpOSD.SetCellBorder(1, 1, axfpOSD.MaxCols, axfpOSD.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 1, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);


                        }


                        axfpOSD.Col = axfpOSD.MaxCols;
                        for (int iRow = 2; iRow <= axfpOSD.MaxRows; iRow++)
                        {
                            axfpOSD.Row = iRow;
                            axfpOSD.BackColor = Color.FromArgb(255, 255, 202);
                            axfpOSD.Font = new System.Drawing.Font("Calibri", 11, FontStyle.Bold);
                        }

                        axfpOSD.Col = axfpOSD.MaxCols - 1;
                        for (int iRow = 2; iRow <= axfpOSD.MaxRows; iRow++)
                        {
                            axfpOSD.Row = iRow;
                            axfpOSD.BackColor = Color.FromArgb(244, 212, 252);
                            axfpOSD.Font = new System.Drawing.Font("Calibri", 11, FontStyle.Bold);

                        }
                        //}
                        // }
                    }
                    //AVG
                    axfpOSD.SetText(axfpOSD.MaxCols - 1, 2, dt.Rows[0]["AVG_IN"].ToString());
                    axfpOSD.SetText(axfpOSD.MaxCols - 1, 3, dt.Rows[0]["AVG_OS"].ToString());
                    axfpOSD.SetText(axfpOSD.MaxCols - 1, 4, dt.Rows[0]["AVG_IP"].ToString());
                    axfpOSD.SetText(axfpOSD.MaxCols - 1, 5, dt.Rows[0]["AVG_PH"].ToString());
                    axfpOSD.SetText(axfpOSD.MaxCols - 1, 6, dt.Rows[0]["AVG_DMP"].ToString());
                    axfpOSD.SetText(axfpOSD.MaxCols - 1, 7, dt.Rows[0]["AVG_PU"].ToString());
                    axfpOSD.SetText(axfpOSD.MaxCols - 1, 8, dt.Rows[0]["AVG_TOT"].ToString());
                    //TOT
                    axfpOSD.SetText(axfpOSD.MaxCols, 2, dt.Rows[0]["TOT_IN"].ToString());
                    axfpOSD.SetText(axfpOSD.MaxCols, 3, dt.Rows[0]["TOT_OS"].ToString());
                    axfpOSD.SetText(axfpOSD.MaxCols, 4, dt.Rows[0]["TOT_IP"].ToString());
                    axfpOSD.SetText(axfpOSD.MaxCols, 5, dt.Rows[0]["TOT_PH"].ToString());
                    axfpOSD.SetText(axfpOSD.MaxCols, 6, dt.Rows[0]["TOT_DMP"].ToString());
                    axfpOSD.SetText(axfpOSD.MaxCols, 7, dt.Rows[0]["TOT_PU"].ToString());
                    axfpOSD.SetText(axfpOSD.MaxCols, 8, dt.Rows[0]["TOT_TOT"].ToString());

                }
                catch
                { }
            }
        }

        private void BindingOSDDaily()
        {
            try
            {
                DataTable dt = SP_SMT_OSD_DAILY("DAILY", line, Mline, UC_MONTH.GetValue());
                chartOSDDaily.DataSource = dt;

                Animation(axfpOSD, dt);
                //BindingGrid(dt);

                chartOSDDaily.Series[0].ArgumentDataMember = "OSD_YMD";
                chartOSDDaily.Series[0].ValueDataMembers.AddRange(new string[] { "IN" });
                chartOSDDaily.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

                chartOSDDaily.Series[1].ArgumentDataMember = "OSD_YMD";
                chartOSDDaily.Series[1].ValueDataMembers.AddRange(new string[] { "OS" });
                chartOSDDaily.Series[1].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

                chartOSDDaily.Series[2].ArgumentDataMember = "OSD_YMD";
                chartOSDDaily.Series[2].ValueDataMembers.AddRange(new string[] { "IP" });
                chartOSDDaily.Series[2].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

                chartOSDDaily.Series[3].ArgumentDataMember = "OSD_YMD";
                chartOSDDaily.Series[3].ValueDataMembers.AddRange(new string[] { "DMP" });
                chartOSDDaily.Series[3].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

                chartOSDDaily.Series[4].ArgumentDataMember = "OSD_YMD";
                chartOSDDaily.Series[4].ValueDataMembers.AddRange(new string[] { "PH" });
                chartOSDDaily.Series[4].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

                chartOSDDaily.Series[5].ArgumentDataMember = "OSD_YMD";
                chartOSDDaily.Series[5].ValueDataMembers.AddRange(new string[] { "PU" });
                chartOSDDaily.Series[5].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            }
            catch
            {

            }
        }

        private void BindingOSDWeekly(string Comp_Name)
        {
            try
            {
                switch (Comp_Name)
                {
                    case "IN":
                        chartIN.DataSource = SP_SMT_OSD_DAILY(Comp_Name, line, Mline, UC_MONTH.GetValue());
                        chartIN.Series[0].ArgumentDataMember = "STYLE_NAME";
                        chartIN.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                        chartIN.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

                        chartIN.Series[1].ArgumentDataMember = "STYLE_NAME";
                        chartIN.Series[1].ValueDataMembers.AddRange(new string[] { "PER" });
                        chartIN.Series[1].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
                        ((XYDiagram)chartIN.Diagram).AxisX.Label.Angle = -35;

                        break;
                    case "IP":
                        chartIPPH.DataSource = SP_SMT_OSD_DAILY(Comp_Name, line, Mline, UC_MONTH.GetValue());
                        chartIPPH.Series[0].ArgumentDataMember = "STYLE_NAME";
                        chartIPPH.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                        chartIPPH.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

                        chartIPPH.Series[1].ArgumentDataMember = "STYLE_NAME";
                        chartIPPH.Series[1].ValueDataMembers.AddRange(new string[] { "PER" });
                        chartIPPH.Series[1].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

                        ((XYDiagram)chartIPPH.Diagram).AxisX.Label.Angle = -35;
                        break;
                    case "PH":
                        chartPH.DataSource = SP_SMT_OSD_DAILY(Comp_Name, line, Mline, UC_MONTH.GetValue());
                        chartPH.Series[0].ArgumentDataMember = "STYLE_NAME";
                        chartPH.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                        chartPH.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

                        chartPH.Series[1].ArgumentDataMember = "STYLE_NAME";
                        chartPH.Series[1].ValueDataMembers.AddRange(new string[] { "PER" });
                        chartPH.Series[1].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

                        ((XYDiagram)chartPH.Diagram).AxisX.Label.Angle = -35;
                        break;
                    case "DMP":
                        chartDMPPU.DataSource = SP_SMT_OSD_DAILY(Comp_Name, line, Mline, UC_MONTH.GetValue());
                        chartDMPPU.Series[0].ArgumentDataMember = "STYLE_NAME";
                        chartDMPPU.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                        chartDMPPU.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

                        chartDMPPU.Series[1].ArgumentDataMember = "STYLE_NAME";
                        chartDMPPU.Series[1].ValueDataMembers.AddRange(new string[] { "PER" });
                        chartDMPPU.Series[1].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

                        ((XYDiagram)chartDMPPU.Diagram).AxisX.Label.Angle = -35;
                        break;
                    case "PU":
                        chartPU.DataSource = SP_SMT_OSD_DAILY(Comp_Name, line, Mline, UC_MONTH.GetValue());
                        chartPU.Series[0].ArgumentDataMember = "STYLE_NAME";
                        chartPU.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                        chartPU.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

                        chartPU.Series[1].ArgumentDataMember = "STYLE_NAME";
                        chartPU.Series[1].ValueDataMembers.AddRange(new string[] { "PER" });
                        chartPU.Series[1].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
                        ((XYDiagram)chartPU.Diagram).AxisX.Label.Angle = -35;
                        break;
                    case "OS":
                        chartOS.DataSource = SP_SMT_OSD_DAILY(Comp_Name, line, Mline, UC_MONTH.GetValue());
                        chartOS.Series[0].ArgumentDataMember = "STYLE_NAME";
                        chartOS.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                        chartOS.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

                        chartOS.Series[1].ArgumentDataMember = "STYLE_NAME";
                        chartOS.Series[1].ValueDataMembers.AddRange(new string[] { "PER" });
                        chartOS.Series[1].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
                        ((XYDiagram)chartOS.Diagram).AxisX.Label.Angle = -35;
                        break;

                }
            }
            catch 
            { }
        }

        private void load_data()
        {
            try
            {
                splitMain.Visible = false;
                BindingOSDDaily();
                BindingOSDWeekly("IP");
                BindingOSDWeekly("PH");
                BindingOSDWeekly("OS");
                BindingOSDWeekly("DMP");
                BindingOSDWeekly("PU");
                BindingOSDWeekly("IN");
            }
            catch
            {
            }
            finally
            {
                splitMain.Visible = true;
            }
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // return;
                if (this.chartOSDDaily.InvokeRequired)
                    this.chartOSDDaily.Invoke((MethodInvoker)delegate
                    {
                        BindingOSDDaily();
                    });
                else
                    BindingOSDDaily();

                if (this.chartIPPH.InvokeRequired)
                    this.chartIPPH.Invoke((MethodInvoker)delegate
                    {
                        BindingOSDWeekly("IP");
                        BindingOSDWeekly("PH");
                    });
                else
                {
                    BindingOSDWeekly("IP");
                    BindingOSDWeekly("PH");
                }

                if (this.chartOS.InvokeRequired)
                    this.chartOS.Invoke((MethodInvoker)delegate
                    {
                        BindingOSDWeekly("OS");
                    });
                else
                    BindingOSDWeekly("OS");


                if (this.chartDMPPU.InvokeRequired)
                    this.chartDMPPU.Invoke((MethodInvoker)delegate
                    {
                        BindingOSDWeekly("DMP");
                        BindingOSDWeekly("PU");
                    });
                else
                {
                    BindingOSDWeekly("PU");
                    BindingOSDWeekly("DMP");
                }
                if (this.chartIN.InvokeRequired)
                    this.chartIN.Invoke((MethodInvoker)delegate
                    {
                        BindingOSDWeekly("IN");
                    });
                else
                    BindingOSDWeekly("IN");
            }
            catch 
            { }
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //BindingOSDDaily();
            if (!bgw.IsBusy)
                bgw.RunWorkerAsync();

            this.Cursor = Cursors.Default;
        }
        int cCount = 0;
        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (cCount >= 30)
            {
                this.Cursor = Cursors.WaitCursor;
                //   // BindingOSDDaily();
                if (!bgw.IsBusy)
                    bgw.RunWorkerAsync();
                // load_data();
                cCount = 0;
                this.Cursor = Cursors.Default;
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void FRM_SMT_OSD_DAILY_PHUOC_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cmdBack.Tag = ComVar.Var._Frm_Back;
                line = ComVar.Var._strValue1;
                lblTitle.Text = ComVar.Var._strValue1.Equals("TOTAL2") ? "VJ2 External OS&&D by Day" : ComVar.Var._strValue2 + " External OS&&D by Day";
                initForm();
                cCount = 30;
                tmrDate.Start();
            }
            else
                tmrDate.Stop();
        }

        private void UC_MONTH_ValueChangeEvent(object sender, EventArgs e)
        {

            cCount = 30;
            tmrDate.Start();
            //line = strinit.line;
            //Mline = strinit.mline;
            //Lang = strinit.lang;
        }

        private void axfpOSD_ClickEvent(object sender, AxFPSpreadADO._DSpreadEvents_ClickEvent e)
        {
            string sCellValue = "";
            axfpOSD.Row = 1;
            axfpOSD.Col = e.col;
            sCellValue = axfpOSD.Value.ToString();

            string date = UC_MONTH.GetValue() + sCellValue;
            //MessageBox.Show(date);
            //this.TopMost = false;
            DataTable dt = SP_SMT_OSD_DETAIL(line, Mline, date, date, "", "Y");
            Popup.FRM_SMT_EXTERNAL_POPUP_1 frm_pop = new Popup.FRM_SMT_EXTERNAL_POPUP_1(dt);
           // FRM_EXTERNAL_OSND_POP frm_pop = new FRM_EXTERNAL_OSND_POP(line, Mline, date, date);
            frm_pop.ShowDialog();
           // frm_pop.TopMost = true;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void initForm()
        {
            this.Mline = ComVar.Var._strValue2;
            this.line = ComVar.Var._strValue1;
            this.Lang = ComVar.Var._strValue3;
            if (ComVar.Var._strValue3 == "Vn")
            {
                this.lblTitle.Text = "Hàng C trả về bottom theo tháng";
            }
            else
            {
                this.lblTitle.Text = "External OS&&D by Month";
            }
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void menu_Click(object sender, EventArgs e)
        {
            //Control cnt = (Control)sender;
            ComVar.Var.callForm = "1634";
        }

        private void UC_MONTH_Load(object sender, EventArgs e)
        {

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
                dtnInit = ComVar.Func.getInitForm(ComVar.Var._Area + this.GetType().Assembly.GetName().Name, this.GetType().Name);
                if (dtnInit == null) return;
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

        

    }
}
