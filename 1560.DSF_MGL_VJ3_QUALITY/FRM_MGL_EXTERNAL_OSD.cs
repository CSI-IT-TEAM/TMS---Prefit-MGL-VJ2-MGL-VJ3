﻿using DevExpress.Utils;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM
{
    public partial class FRM_MGL_EXTERNAL_OSD : Form
    {
        public FRM_MGL_EXTERNAL_OSD()
        {
            InitializeComponent();
        }

        private void splMain_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private DataTable MGL_E_QSD_DATA_SELECT(string ARG_TYPE, string ARG_FROM, string ARG_TO)
        {
            System.Data.DataSet retDS;
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(8);
            MyOraDB.Process_Name = "MES.PKG_MGL_VJ3.MGL_E_QSD_DATA_SELECT";
            //  for (int i = 0; i < intParm; i++)

            MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[5] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[6] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[7] = (int)OracleType.Cursor;

            //V_P_TYPE,V_P_OPTION
            MyOraDB.Parameter_Name[0] = "ARG_TYPE";
            MyOraDB.Parameter_Name[1] = "ARG_FROM";
            MyOraDB.Parameter_Name[2] = "ARG_TO";
            MyOraDB.Parameter_Name[3] = "ARG_PLANT";
            MyOraDB.Parameter_Name[4] = "ARG_PROCESS";
            MyOraDB.Parameter_Name[5] = "ARG_MLINE";
            MyOraDB.Parameter_Name[6] = "ARG_LANG";
            MyOraDB.Parameter_Name[7] = "OUT_CURSOR";

            MyOraDB.Parameter_Values[0] = ARG_TYPE;
            MyOraDB.Parameter_Values[1] = ARG_FROM;
            MyOraDB.Parameter_Values[2] = ARG_TO;
            MyOraDB.Parameter_Values[3] = ComVar.Var._strValue1;
            MyOraDB.Parameter_Values[4] = "UPSVJ3";
            MyOraDB.Parameter_Values[5] = "";
            MyOraDB.Parameter_Values[6] = "";
            MyOraDB.Parameter_Values[7] = "";

            MyOraDB.Add_Select_Parameter(true);
            retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;
            return retDS.Tables[MyOraDB.Process_Name];
        }
        private void BindingDataChart()
        {
            string DATE_FROM = UC_MONTH.GetValue() + "01", DATE_TO = UC_MONTH.GetValue() + DateTime.DaysInMonth(Convert.ToInt32(UC_MONTH.GetValue().Substring(0, 4)), Convert.ToInt32(UC_MONTH.GetValue().Substring(4, 2))).ToString();
            loadTopLeft(MGL_E_QSD_DATA_SELECT("CHART1", DATE_FROM, DATE_TO));
            bindingDataGrid(DATE_FROM, DATE_TO);
        }
        private bool loadTopLeft(DataTable DTF)
        {
            try
            {
                chartControl1.Series[0].Points.Clear();
                chartControl1.Series[1].Points.Clear();
                chartControl1.Series[2].Points.Clear();
                for (int i = 0; i < DTF.Rows.Count; i++)
                {
                    chartControl1.Series[0].Points.Add(new SeriesPoint(DTF.Rows[i]["YMD"].ToString(), DTF.Rows[i]["OSD_QTY"]));
                    chartControl1.Series[1].Points.Add(new SeriesPoint(DTF.Rows[i]["YMD"].ToString(), DTF.Rows[i]["RETURN_QTY"]));
                    chartControl1.Series[2].Points.Add(new SeriesPoint(DTF.Rows[i]["YMD"].ToString(), DTF.Rows[i]["PER"]));

                    if (Convert.ToDouble(DTF.Rows[i]["OSD_QTY"]) == Convert.ToDouble(DTF.Rows[i]["RETURN_QTY"]))
                    {

                        chartControl1.Series[0].Points[i].Color = Color.Green;
                        chartControl1.Series[1].Points[i].Color = Color.Green;
                    }
                    else
                    {
                        chartControl1.Series[0].Points[i].Color = System.Drawing.Color.FromArgb(255, 128, 0);
                        chartControl1.Series[1].Points[i].Color = System.Drawing.Color.DodgerBlue;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        DataTable dtf = null;
        private void bindingDataGrid(string DATE_FROM, string DATE_TO)
        {
            grdBase.Refresh();
            gvwBase.Columns.Clear();
            DataTable dt = dtf = MGL_E_QSD_DATA_SELECT("GRID", DATE_FROM, DATE_TO);
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
                    gvwBase.Columns[i].Width = 200;
                else
                    gvwBase.Columns[i].Width = 75;
            }
        }
        private void FRM_MGL_EXTERNAL_OSD_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
                lbltitle.Text = ComVar.Var._strValue1.Equals("TOT") ? "VJ1,VJ2 Support External OS&&D by Month" : ComVar.Var._strValue1 + " Support External OS&&D by Month";
                cCount = 60;
            }
            else
            {
                //Stop stb
            }
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

        private void UC_MONTH_ValueChangeEvent(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                cCount = 0;
                string DATE_FROM = UC_MONTH.GetValue() + "01", DATE_TO = UC_MONTH.GetValue() + DateTime.DaysInMonth(Convert.ToInt32(UC_MONTH.GetValue().Substring(0, 4)), Convert.ToInt32(UC_MONTH.GetValue().Substring(4, 2))).ToString();
                loadTopLeft(MGL_E_QSD_DATA_SELECT("CHART1", DATE_FROM, DATE_TO));
                bindingDataGrid(DATE_FROM, DATE_TO);
                this.Cursor = Cursors.Default;
            }
            catch { this.Cursor = Cursors.Default; }
        }
        int cCount = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cCount >= 60)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    string DATE_FROM = UC_MONTH.GetValue() + "01", DATE_TO = UC_MONTH.GetValue() + DateTime.DaysInMonth(Convert.ToInt32(UC_MONTH.GetValue().Substring(0, 4)), Convert.ToInt32(UC_MONTH.GetValue().Substring(4, 2))).ToString();
                    loadTopLeft(MGL_E_QSD_DATA_SELECT("CHART1", DATE_FROM, DATE_TO));
                    bindingDataGrid(DATE_FROM, DATE_TO);
                    this.Cursor = Cursors.Default;
                    cCount = 0;
                }
                catch { this.Cursor = Cursors.Default; cCount = 0; }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void gvwBase_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.ColumnHandle < 2 || e.Clicks <= 1) return;
            string DateF = string.Concat(UC_MONTH.GetValue(), dtf.Columns[e.Column.ColumnHandle].ColumnName.ToString().Replace("'", ""));
            string DateT = string.Concat(UC_MONTH.GetValue(), dtf.Columns[e.Column.ColumnHandle].ColumnName.ToString().Replace("'", ""));
            DataTable dtF = new DataTable();
            if (e.RowHandle == gvwBase.RowCount - 2 && e.Column.ColumnHandle != 2)
            {
                dtF = MGL_E_QSD_DATA_SELECT("POPUP1", DateF, DateT);
                Popup.FRM_SMT_EXTERNAL_POPUP_1 POPUP_1 = new Popup.FRM_SMT_EXTERNAL_POPUP_1(dtF);
                POPUP_1.ShowDialog();
            }

            if (e.RowHandle == gvwBase.RowCount - 1 && e.Column.ColumnHandle != 2)
            {
                dtF = MGL_E_QSD_DATA_SELECT("POPUP2", DateF, DateT);
                Popup.FRM_SMT_EXTERNAL_POPUP_2 POPUP_2 = new Popup.FRM_SMT_EXTERNAL_POPUP_2(dtF);
                POPUP_2.ShowDialog();
            }
        }
    }
}
