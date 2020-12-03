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
    public partial class FRM_MGL_DTD_MONTH : Form
    {
        public FRM_MGL_DTD_MONTH()
        {
            InitializeComponent();
        }

        int indexScreen;
        string Line, Mline, Lang;
        DataTable dt = null;
        Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        UC.UC_DWMY uc = new UC.UC_DWMY(3, "");//Hiển thị 4 Button, Button Day thì Disable
        public FRM_MGL_DTD_MONTH(string Title, int _indexScreen, string _Line, string _Mline, string _Lang)
        {
            InitializeComponent();
            indexScreen = _indexScreen;
            Mline = _Mline;
            Line = _Line;
            lblTitle.Text = Title;
        }
        #region PKG
        public DataTable SEL_DATA_DTD_MONTH(string Qtype, string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_MGL_VJ2.MGL_DTD_MONTH";

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
                dt = SEL_DATA_DTD_MONTH("Q", Line, Mline);
                if (dt == null && dt.Rows.Count < 1) return;
                axfpDTD.Hide();
                string plant = "";
                switch (Line)
                { 
                    case "201":
                        plant = "LD";
                        break;
                    case "202":
                        plant = "LE";
                        break;
                    case "015":
                        plant = "I";
                        break;
                    case "016":
                        plant = "J";
                        break;
                    case "009":
                        plant = "K";
                        break;
                    case "TOTAL2":
                        plant = "VJ2";
                        break;
                }

                axfpDTD.MaxCols = dt.Rows.Count + 3;
                axfpDTD.RowsFrozen = 1;
                axfpDTD.SetText(1,2, plant);
                for (int iCol = 0; iCol < dt.Columns.Count; iCol++)
                {
                    for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                    {
                        axfpDTD.Row = iCol + 1;
                        axfpDTD.Col = iRow + 4;
                        if (dt.Rows[iRow][iCol].ToString().IndexOf('N') > 0)
                        {
                            axfpDTD.SetText(iRow + 4, iCol + 1, dt.Rows[iRow][iCol].ToString().Split('\n')[0]);

                        }
                        else
                            axfpDTD.SetText(iRow + 4, iCol + 1, dt.Rows[iRow][iCol].ToString());



                        axfpDTD.set_ColWidth(iRow + 4, (double)(217d) / axfpDTD.MaxCols);
                        axfpDTD.set_ColWidth(axfpDTD.MaxCols, 12d);

                        //else
                        if (iCol + 1 == 1)
                        {
                            if (dt.Rows[iRow][iCol].ToString().IndexOf('N') > 0)
                            {
                                axfpDTD.BackColor = Color.Orange;
                                axfpDTD.ForeColor = Color.Black;
                            }
                            else
                            {
                                axfpDTD.BackColor = Color.FromArgb(13, 186, 168);
                                axfpDTD.ForeColor = Color.White;
                            }
                        }
                        else if (iCol + 1 == 2)
                        {
                            axfpDTD.CellType = FPUSpreadADO.CellTypeConstants.CellTypeNumber;
                            axfpDTD.TypeNumberShowSep = true;
                            axfpDTD.TypeNumberDecPlaces = 0;
                            axfpDTD.BackColor = Color.FromArgb(209, 209, 209);
                            axfpDTD.ForeColor = Color.Black;
                        }
                        else if (iCol + 1 > 2)
                        {
                            axfpDTD.CellType = FPUSpreadADO.CellTypeConstants.CellTypeNumber;
                            axfpDTD.TypeNumberShowSep = true;
                            switch ((iCol + 1) % 2)
                            {
                                case 0:
                                    axfpDTD.TypeNumberDecPlaces = 1;
                                    axfpDTD.BackColor = Color.FromArgb(232, 253, 255);
                                    axfpDTD.ForeColor = Color.Black;
                                    break;
                                default:
                                    axfpDTD.TypeNumberDecPlaces = 0;
                                    axfpDTD.BackColor = Color.White;
                                    axfpDTD.ForeColor = Color.Black;
                                    break;
                            }

                            if (iCol + 1 == axfpDTD.MaxRows || iCol + 1 == axfpDTD.MaxRows - 1)
                            {
                                axfpDTD.BackColor = Color.FromArgb(235, 255, 137);
                                axfpDTD.ForeColor = Color.Black;
                            }

                        }
                        


                        if (iRow + 4 == axfpDTD.MaxCols)
                        {
                            axfpDTD.BackColor = Color.FromArgb(247, 255, 216);
                            axfpDTD.ForeColor = Color.Black;
                        }
                        axfpDTD.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                        axfpDTD.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                    }
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
                chartWIP.Series[0].ArgumentDataMember = "YMD";
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
                chartLT.Series[0].ArgumentDataMember = "YMD";
                chartLT.Series[0].ValueDataMembers.AddRange(new string[] { "LT_DAYS" });
              
            }
            catch (Exception ex)
            { }
        }
        private void FRM_SMT_DTD_MONTH_Load(object sender, EventArgs e)
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
                    e.Item.Text = e.Item.Text.Replace("N", "").Replace("\n","");
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
            this.Hide();
            string Caption = "DTD (Dock To Dock) by YEAR";
            Form fc = Application.OpenForms["FRM_SMT_DTD_YEAR"];
            if (fc != null)
                fc.Close();



            switch (Lang)
            {
                case "Vn":
                    Caption = "DTD (Dock To Dock) by Year";
                    break;
                default:
                    Caption = "DTD (Dock To Dock) by Year";
                    break;
            }
            FRM_MGL_DTD_YEAR f = new FRM_MGL_DTD_YEAR(Caption, 1, Line, Mline, Lang);
            f.Show();
        }

        private void FRM_SMT_DTD_MONTH_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                uc.YMD_Change(3, "");
                //uc.YMD_Change(2, "");
                Line = ComVar.Var._strValue1;
                Mline = "000";
                lblTitle.Text = ComVar.Var._strValue1.Equals("TOTAL2") ? "VJ2 Dock To Dock (DTD) By Month" : ComVar.Var._strValue2 + " Dock To Dock (DTD) By Month";
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
    }
}
