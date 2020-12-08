using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using DevExpress.Utils;
using System.Globalization;
using DevExpress.XtraCharts;
using System.Collections;

namespace FORM
{
    public partial class FRM_MGL_INTERNAL_OSD : Form
    {
        public FRM_MGL_INTERNAL_OSD()
        {
            InitializeComponent();
            timer1.Stop();
        }
        int indexScreen;
        string line, Mline, Lang;
        int cCount = 0;
        public FRM_MGL_INTERNAL_OSD(string Caption, int indexScreen, string Line_cd, string Mline_cd, string Lang)
        {
            InitializeComponent();
            timer1.Stop();
            this.indexScreen = indexScreen;
            this.Mline = Mline_cd;
            this.line = Line_cd;
            this.Lang = Lang;
            this.lblTitle.Text = Caption;
        }

        #region DB
        private DataTable SEL_DATA_OSD(string ARG_TYPE,string ARG_FROM,string ARG_TO)
        {
            System.Data.DataSet retDS;
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(6);
            MyOraDB.Process_Name = "MES.PKG_MGL_VJ2.MGL_I_OSD_DATA";
            //  for (int i = 0; i < intParm; i++)

            MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;


            //V_P_TYPE,V_P_OPTION
            MyOraDB.Parameter_Name[0] = "P_TYPE";
            MyOraDB.Parameter_Name[1] = "P_FROM";
            MyOraDB.Parameter_Name[2] = "P_TO";
            MyOraDB.Parameter_Name[3] = "P_PLANT";
            MyOraDB.Parameter_Name[4] = "P_PROCESS";
            MyOraDB.Parameter_Name[5] = "CV_1";

            MyOraDB.Parameter_Values[0] = ARG_TYPE;
            MyOraDB.Parameter_Values[1] = ARG_FROM;
            MyOraDB.Parameter_Values[2] = ARG_TO;
            MyOraDB.Parameter_Values[3] = ComVar.Var._strValue1;
            MyOraDB.Parameter_Values[4] = "ALL";
            MyOraDB.Parameter_Values[5] = "";

            MyOraDB.Add_Select_Parameter(true);
            retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;
            return retDS.Tables[MyOraDB.Process_Name];
        }


        private DataTable SEL_DATA_OSD_POP1(string ARG_TYPE, string ARG_FROM)
        {
            System.Data.DataSet retDS;
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(12);
            MyOraDB.Process_Name = "MES.SP_GMES0280_POP";

            MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[5] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[6] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[7] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[8] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[9] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[10] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[11] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Name[0] = "V_P_TYPE";
            MyOraDB.Parameter_Name[1] = "V_P_DATE";
            MyOraDB.Parameter_Name[2] = "V_P_PLANT";
            MyOraDB.Parameter_Name[3] = "V_P_PROCESS";
            MyOraDB.Parameter_Name[4] = "V_P_ERROR_CODE";
            MyOraDB.Parameter_Name[5] = "V_P_ROW_COUNT";
            MyOraDB.Parameter_Name[6] = "V_P_ERROR_NOTE";
            MyOraDB.Parameter_Name[7] = "V_P_RETURN_STR";
            MyOraDB.Parameter_Name[8] = "V_P_ERROR_STR";
            MyOraDB.Parameter_Name[9] = "V_ERRORSTATE";
            MyOraDB.Parameter_Name[10] = "V_ERRORPROCEDURE";
            MyOraDB.Parameter_Name[11] = "CV_1";

            MyOraDB.Parameter_Values[0] = ARG_TYPE;
            MyOraDB.Parameter_Values[1] = ARG_FROM.Replace(",","").Replace("'","");
            MyOraDB.Parameter_Values[2] = ComVar.Var._strValue1;
            MyOraDB.Parameter_Values[3] = "ALL";
            MyOraDB.Parameter_Values[4] = "";
            MyOraDB.Parameter_Values[5] = "";
            MyOraDB.Parameter_Values[6] = "";
            MyOraDB.Parameter_Values[7] = "";
            MyOraDB.Parameter_Values[8] = "";
            MyOraDB.Parameter_Values[9] = "";
            MyOraDB.Parameter_Values[10] = "";
            MyOraDB.Parameter_Values[11] = "";

            MyOraDB.Add_Select_Parameter(true);
            retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;
            return retDS.Tables[MyOraDB.Process_Name];
        }
        #endregion

        public void setData(string Caption, int indexScreen, string Line_cd, string Mline_cd,string Lang)
        {
            this.indexScreen = indexScreen;
            this.Mline = Mline_cd;
            this.line = Line_cd;
            this.Lang = Lang;
            this.lblTitle.Text = Caption;
        }

        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }

        private void FRM_SMT_OSD_INTERNAL_PHUOC_Load(object sender, EventArgs e)
        {
            GoFullscreen();
            setConfigForm();
            //string DATE_FROM = UC_MONTH.GetValue() + "01", DATE_TO =UC_MONTH.GetValue() + DateTime.DaysInMonth(Convert.ToInt32(UC_MONTH.GetValue().Substring(0, 4)), Convert.ToInt32(UC_MONTH.GetValue().Substring(4, 2))).ToString();
            
            //loadTopLeft(SEL_DATA_OSD("CHART", DATE_FROM, DATE_TO)); bindingDataGrid(DATE_FROM, DATE_TO);
        }
        DataTable dtf = null;
        private void bindingDataGrid(string DATE_FROM, string DATE_TO)
        {
            grdBase.Refresh();
            gvwBase.Columns.Clear();
            DataTable dt =  dtf= SEL_DATA_OSD("GRID", DATE_FROM, DATE_TO);
            grdBase.DataSource = dt;

            gvwBase.OptionsView.ColumnAutoWidth = false;
            for (int i = 0; i < gvwBase.Columns.Count; i++)
            {
                gvwBase.Columns[i].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gvwBase.Columns[i].AppearanceHeader.BackColor = System.Drawing.Color.Gray;
                gvwBase.Columns[i].AppearanceHeader.BackColor2 = System.Drawing.Color.Gray;
                gvwBase.Columns[i].AppearanceHeader.ForeColor = System.Drawing.Color.White;
                 gvwBase.Columns[i].AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
                gvwBase.Columns[i].OptionsColumn.ReadOnly = true;
                gvwBase.Columns[i].OptionsColumn.AllowEdit = false;
                gvwBase.Columns[i].OptionsColumn.ReadOnly = true;
                gvwBase.Columns[i].OptionsColumn.AllowEdit = false;
                gvwBase.Columns[i].OptionsFilter.AllowFilter = false;
                gvwBase.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                if (i < 2)
                {
                    gvwBase.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    gvwBase.Columns[i].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    //gvwBase.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                }
                else
                {
                    gvwBase.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    gvwBase.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gvwBase.Columns[i].DisplayFormat.FormatString = "#,0.##";
                }

                gvwBase.Columns[i].Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(gvwBase.Columns[i].GetCaption().Replace("_", " ").Replace("'", " ").ToLower()).Split(',')[0];
                gvwBase.Columns[0].Visible = false;
                if (gvwBase.Columns[i].FieldName == "TOTAL")
                {
                    gvwBase.Columns[i].VisibleIndex = 999;
                }
                if (i == 1)
                    gvwBase.Columns[i].Width = 250;
                else
                    gvwBase.Columns[i].Width = 80;
            }
           // gvwBase.BestFitColumns();
            //gvwBase.TopRowIndex = 0;

           
               
        }

        private void BindingChart()
        {
            try
            {
                string DATE_FROM = UC_MONTH.GetValue();
                DataTable dt = SEL_DATA_OSD("CHART2", DATE_FROM, DATE_FROM);
                chartCutting.DataSource = null;
                chartNosew.DataSource = null;
                chartHF.DataSource = null;
                chartStit.DataSource = null;
                chartStock.DataSource = null;
                chartTotal.DataSource = null;
                InitDataChart("UPC", chartCutting, dt);
                InitDataChart("UPN", chartNosew, dt);
                InitDataChart("UPF", chartHF, dt);
                InitDataChart("UPS",chartStit, dt);
                InitDataChart("FSS",chartStock, dt);
                InitDataChart("TOT",chartTotal, dt);
            }
            catch { }
        }


        private void InitDataChart(string sChart,DevExpress.XtraCharts.ChartControl ChartControl,DataTable dt)
        {
            try
            {
                DataTable dtChart;

                switch (sChart)
                {
                    case "TOT":
                        dtChart = dt.Select("SUP_CD = 'TOT'").CopyToDataTable();
                        break;
                    default:
                        dtChart = dt.Select("SUP_CD = '" + sChart + "'").CopyToDataTable();
                        break;
                }


                Series series1 = new Series("REPLENISHMENT", ViewType.Bar);
                Series series2 = new Series("C.GRADE RETURN", ViewType.Bar);
                Series series3 = new Series("%", ViewType.Spline);

                for (int i = 0; i < dtChart.Rows.Count; i++)
                {
                    series1.Points.Add(new SeriesPoint(dtChart.Rows[i]["STYLE_NAME"].ToString(), dtChart.Rows[i]["QTY"]));
                    series2.Points.Add(new SeriesPoint(dtChart.Rows[i]["STYLE_NAME"].ToString(), dtChart.Rows[i]["R_QTY"]));
                    series3.Points.Add(new SeriesPoint(dtChart.Rows[i]["STYLE_NAME"].ToString(), dtChart.Rows[i]["RATE"]));
                    if (Convert.ToDouble(dtChart.Rows[i]["QTY"]) == Convert.ToDouble(dtChart.Rows[i]["R_QTY"]))
                    {
                       
                        series1.Points[i].Color = Color.Green;
                        series2.Points[i].Color = Color.Green;
                    }
                    else
                    {
                        series1.Points[i].Color = System.Drawing.Color.FromArgb(255, 128, 0);
                        series2.Points[i].Color = System.Drawing.Color.DodgerBlue;
                    }

                }
                ChartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1, series2, series3 };
                

                //ChartControl.DataSource = dtChart;
                //ChartControl.Series[0].ArgumentDataMember = "STYLE_NAME";
                //ChartControl.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                //ChartControl.Series[1].ArgumentDataMember = "STYLE_NAME";
                //ChartControl.Series[1].ValueDataMembers.AddRange(new string[] { "R_QTY" });
                //ChartControl.Series[2].ArgumentDataMember = "STYLE_NAME";
                //ChartControl.Series[2].ValueDataMembers.AddRange(new string[] { "RATE" });


            }
            catch { }
        }


        private bool loadTopLeft(DataTable DTF)
        {
            try
            {
                //chartControl1.DataSource = DTF;
                //chartControl1.Series[0].ArgumentDataMember = "YMD";
                //chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "OSD_QTY" });
                //chartControl1.Series[1].ArgumentDataMember = "YMD";
                //chartControl1.Series[1].ValueDataMembers.AddRange(new string[] { "RETURN_QTY" });
                //chartControl1.Series[2].ArgumentDataMember = "YMD";
                //chartControl1.Series[2].ValueDataMembers.AddRange(new string[] { "PER" });
                Series series1 = new Series("REPLENISHMENT", ViewType.Bar);
                Series series2 = new Series("C.GRADE RETURN", ViewType.Bar);
                Series series3 = new Series("%", ViewType.Spline);

                if (DTF == null) return false;
                for (int i = 0; i < DTF.Rows.Count; i++)
                {
                    series1.Points.Add(new SeriesPoint(DTF.Rows[i]["YMD"].ToString(), DTF.Rows[i]["OSD_QTY"]));
                    series2.Points.Add(new SeriesPoint(DTF.Rows[i]["YMD"].ToString(), DTF.Rows[i]["RETURN_QTY"]));
                    series3.Points.Add(new SeriesPoint(DTF.Rows[i]["YMD"].ToString(), DTF.Rows[i]["PER"]));

                    if (Convert.ToDouble(DTF.Rows[i]["OSD_QTY"]) == Convert.ToDouble(DTF.Rows[i]["RETURN_QTY"]))
                    {
                       
                        series1.Points[i].Color = Color.Green;
                        series2.Points[i].Color = Color.Green;
                    }
                    else
                    {
                        series1.Points[i].Color = System.Drawing.Color.FromArgb(255, 128, 0);
                        series2.Points[i].Color = System.Drawing.Color.DodgerBlue;
                    }

                }
                chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1, series2,series3 };

            }
            catch
            {
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void UC_MONTH_ValueChangeEvent(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string DATE_FROM = UC_MONTH.GetValue() + "01", DATE_TO = UC_MONTH.GetValue() + DateTime.DaysInMonth(Convert.ToInt32(UC_MONTH.GetValue().Substring(0, 4)), Convert.ToInt32(UC_MONTH.GetValue().Substring(4, 2))).ToString();
                loadTopLeft(SEL_DATA_OSD("CHART1", DATE_FROM, DATE_TO)); 
                bindingDataGrid(DATE_FROM, DATE_TO);
                BindingChart();
                this.Cursor = Cursors.Default;
            }
            catch { this.Cursor = Cursors.Default; }
        }

        private void gvwBase_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (gvwBase.GetRowCellValue(e.RowHandle, gvwBase.Columns[1]).ToString().ToUpper().Contains("REPLENISHMENT RATE(%)") && e.Column.ColumnHandle > 1)
            {
                if (e.CellValue.ToString() != "")
                {
                    if (double.Parse(e.CellValue.ToString()) >= 100)
                        e.Appearance.ForeColor = Color.Blue;
                    else
                        e.Appearance.ForeColor = Color.Red;
                }
            }
            if (gvwBase.GetRowCellValue(e.RowHandle, gvwBase.Columns[1]).ToString().ToUpper().Contains("OS&D RATE(%)") && e.Column.ColumnHandle > 1)
            {
                if (e.CellValue.ToString() != "")
                {
                    if (double.Parse(e.CellValue.ToString()) < 1)
                        e.Appearance.ForeColor = Color.Blue;
                    else
                        e.Appearance.ForeColor = Color.Red;
                }
            }
            if (gvwBase.GetRowCellDisplayText(e.RowHandle, e.Column).ToString() == "")
            {
                // e.Column.Visible = false;
            }

            if (gvwBase.GetRowCellValue(e.RowHandle, gvwBase.Columns[1]).ToString().ToUpper().Contains("PRODUCTION QUANTITY (PRS)"))  //gvwBase.GetRowCellValue(e.RowHandle, "DIV").Equals("Production Quantity (Prs)"))
            {
                e.Appearance.BackColor = Color.Blue;
                e.Appearance.ForeColor = Color.White;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cCount >= 40)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    string DATE_FROM = UC_MONTH.GetValue() + "01", DATE_TO = UC_MONTH.GetValue() + DateTime.DaysInMonth(Convert.ToInt32(UC_MONTH.GetValue().Substring(0, 4)), Convert.ToInt32(UC_MONTH.GetValue().Substring(4, 2))).ToString();
                    loadTopLeft(SEL_DATA_OSD("CHART1", DATE_FROM, DATE_TO)); bindingDataGrid(DATE_FROM, DATE_TO);
                    BindingChart();
                    this.Cursor = Cursors.Default;
                    cCount = 0;
                }
                catch { this.Cursor = Cursors.Default; cCount = 0; }
            }
        }

        private void FRM_SMT_OSD_INTERNAL_PHUOC_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cmdBack.Tag = ComVar.Var._Frm_Back;
                cCount = 39;
                initForm();
                timer1.Start();

            }
            else
                timer1.Stop();
        }

        private void chartControl1_CustomDrawSeriesPoint(object sender, DevExpress.XtraCharts.CustomDrawSeriesPointEventArgs e)
        {
            
        }

        private void gvwBase_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.ColumnHandle < 2 || e.Clicks <= 1) return;
            DataTable dtF = new DataTable();
            if (e.RowHandle == gvwBase.RowCount - 2 && e.Column.ColumnHandle != 2)
            {
                dtF = SEL_DATA_OSD_POP1("Q1"+Mline, dtf.Columns[e.Column.ColumnHandle].ColumnName.ToString());
                Popup.FRM_SMT_INTERNAL_POPUP_1 POPUP_1 = new Popup.FRM_SMT_INTERNAL_POPUP_1(dtF);
                POPUP_1.ShowDialog();
            }

            if (e.RowHandle == gvwBase.RowCount - 1 && e.Column.ColumnHandle != 2)
            {
                dtF = SEL_DATA_OSD_POP1("Q2" + Mline, dtf.Columns[e.Column.ColumnHandle].ColumnName.ToString());
                Popup.FRM_SMT_INTERNAL_POPUP_2 POPUP_2 = new Popup.FRM_SMT_INTERNAL_POPUP_2(dtF);
                POPUP_2.ShowDialog();
            }
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            cCount = 39;
        }


        private void initForm()
        {
            this.Mline = ComVar.Var._strValue2;
            this.line = ComVar.Var._strValue2;
            this.Lang = ComVar.Var._strValue3;
            if (ComVar.Var._strValue3 == "Vn")
            {
                this.lblTitle.Text = "Hàng C nội bộ xưởng theo tháng";
            }
            else
            {
                this.lblTitle.Text = "Internal OS&&D by Month";
            }
        }

        private void menu_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "1633";
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
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
