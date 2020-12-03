using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using DevExpress.XtraCharts;
using FORM;

namespace FORM
{
    public partial class FRM_MGL_DTD_YEAR : Form
    {
        public FRM_MGL_DTD_YEAR()
        {
            InitializeComponent();
        }

        int indexScreen;
        string Line, Mline, Lang;
        DataTable dt = null;
        Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        UC.UC_DWMY uc = new UC.UC_DWMY(3, "");//Hiển thị 4 Button, Button Day thì Disable
        public FRM_MGL_DTD_YEAR(string Title, int _indexScreen, string _Line, string _Mline, string _Lang)
        {
            InitializeComponent();
            indexScreen = _indexScreen;
            Mline = _Mline;
            Line = _Line;
            lblTitle.Text = Title;
        }
        #region PKG
        public DataTable SEL_DATA_DTD_YEAR(string Qtype, string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_PHUOC.SP_SMT_DTD_YEAR";

                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[2] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = Qtype;
                MyOraDB.Parameter_Values[1] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[2] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[3] = "";


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

        #endregion
        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }


        private void BindingDataGrid()
        {
            try
            {
                dt = SEL_DATA_DTD_YEAR("Q", Line, Mline);
                if (dt == null && dt.Rows.Count < 1) return;
                axfpDTD.Hide();
                int rowWIP = 2;
                int colWIP = 3;
                int colDTD = 9;
                for (int iCol = 2; iCol <= axfpDTD.MaxCols; iCol++)
                {
                    axfpDTD.Row = rowWIP;
                    axfpDTD.Col = iCol;
                    axfpDTD.Text = dt.Rows[iCol - 2][colWIP].ToString();
                    axfpDTD.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                    axfpDTD.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                    if (dt.Rows[iCol - 2][0].ToString().IndexOf('_') > 0)
                    {
                        axfpDTD.Row = 1;
                        axfpDTD.Col = iCol;
                        axfpDTD.BackColor = Color.Orange;
                        axfpDTD.ForeColor = Color.Black;
                    }
                }
                for (int iCol = 2; iCol <= axfpDTD.MaxCols; iCol++)
                {
                    axfpDTD.Row = rowWIP + 1;
                    axfpDTD.Col = iCol;
                    axfpDTD.Text = dt.Rows[iCol - 2][colDTD].ToString();
                    axfpDTD.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                    axfpDTD.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                }
                axfpDTD.Show();
            }
            catch (Exception ex)
            { }

        }


        private void BindingChartWIP()
        {
            try
            {
                chartWIP.DataSource = dt;
                chartWIP.Series[0].ArgumentDataMember = "YM";
                chartWIP.Series[0].ValueDataMembers.AddRange(new string[] { "WIP_DAYS" });
            }
            catch (Exception ex)
            { }
        }


        private void BindingChartLT()
        {
            try
            {

                chartLT.DataSource = dt;
                chartLT.Series[0].ArgumentDataMember = "YM";
                chartLT.Series[0].ValueDataMembers.AddRange(new string[] { "LT_DAYS" });

            }
            catch (Exception ex)
            { }
        }
        private void FRM_SMT_DTD_YEAR_Load(object sender, EventArgs e)
        {
            GoFullscreen();
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            pnYMD.Controls.Add(uc);
            uc.OnDWMYClick += DWMYClick;

        }

        void DWMYClick(string ButtonCap, string ButtonCD)
        {
            switch (ButtonCD)
            {
                case "C":
                    ComVar.Var.callForm = "back";
                    break;
                case "D":
                    ComVar.Var.callForm = "1661";
                    break;
                //case "W":
                //    ComVar.Var.callForm = "1662";
                //    break;
                case "M":
                    ComVar.Var.callForm = "1662";
                    break;
                case "Y":
                    ComVar.Var.callForm = "1663";
                    break;
            }
        }


        int cCount = 0;
        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (cCount >= 30)
            {
                BindingDataGrid();
                BindingChartWIP();
                BindingChartLT();
                cCount = 0;
            }
        }

        private void CustomDrawAxisLabel(object sender, DevExpress.XtraCharts.CustomDrawAxisLabelEventArgs e)
        {
            try
            {
                if (e.Item.Axis is AxisX)
                {
                    e.Item.Text = e.Item.Text.Replace("_N", "").Replace("\n", "");
                }
            }
            catch
            {

            }
        }

        private void btnDay_Click(object sender, EventArgs e)
        {
            this.Hide();
            string Caption = "Lead Time";
            Form fc = Application.OpenForms["FRM_SMT_LEADTIME"];
            if (fc != null)
                fc.Close();



            switch (Lang)
            {
                case "Vn":
                    Caption = "Lead Time";
                    break;
                default:
                    Caption = "Doanh Thu";
                    break;
            }
            FRM_MGL_LEADTIME f = new FRM_MGL_LEADTIME(Caption, 1, Line, Mline, Lang);
            f.Show();
        }

        private void btnYear_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //string Caption = "DTD (Dock To Dock) by Month";
            //Form fc = Application.OpenForms["FRM_SMT_DTD_MONTH"];
            //if (fc != null)
            //    fc.Close();



            //switch (Lang)
            //{
            //    case "Vn":
            //        Caption = "DTD (Dock To Dock) by Month";
            //        break;
            //    default:
            //        Caption = "DTD (Dock To Dock) by Month";
            //        break;
            //}
            //FRM_SMT_DTD_MONTH f = new FRM_SMT_DTD_MONTH(Caption, 1, _wh_cd, _mline_cd, Lang);
            //f.Show();
        }

        private void FRM_SMT_DTD_YEAR_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                uc.YMD_Change(4, "");
                //uc.YMD_Change(2, "");
                Line = ComVar.Var._strValue1;
                Mline = "000";
                lblTitle.Text = ComVar.Var._strValue1.Equals("TOTAL2") ? "VJ2 Dock To Dock (DTD) By Year" : ComVar.Var._strValue2 + " Dock To Dock (DTD) By Year";
                tmrDate.Start();
                cCount = 28;

            }
            else
                tmrDate.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            this.Hide();
            string Caption = "DTD (Dock To Dock) by Month";
            Form fc = Application.OpenForms["FRM_SMT_DTD_MONTH"];
            if (fc != null)
                fc.Close();



            switch (Lang)
            {
                case "Vn":
                    Caption = "DTD (Dock To Dock) by Month";
                    break;
                default:
                    Caption = "DTD (Dock To Dock) by Month";
                    break;
            }
            FRM_MGL_DTD_MONTH f = new FRM_MGL_DTD_MONTH(Caption, 1, Line, Mline, Lang);
            f.Show();
        }
    }
}
