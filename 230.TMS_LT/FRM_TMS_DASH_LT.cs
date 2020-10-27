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
using DevExpress.Utils;

namespace FORM
{
    public partial class FRM_TMS_DASH_LT : Form
    {
        public FRM_TMS_DASH_LT()
        {
            InitializeComponent();
        }
        #region Variable
        int iCount = 0;
        DataSet ds = new DataSet();
        #endregion
        public DataSet TMS_DASHBOARD_LT_SEL(string PROC_NAME, string ARG_FAC, string ARG_YMD, string ARG_LINE)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = PROC_NAME;
                MyOraDB.ReDim_Parameter(9);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_FAC";
                MyOraDB.Parameter_Name[1] = "ARG_YMD";
                MyOraDB.Parameter_Name[2] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR1";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR2";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR3";
                MyOraDB.Parameter_Name[6] = "OUT_CURSOR4";
                MyOraDB.Parameter_Name[7] = "OUT_CURSOR5";
                MyOraDB.Parameter_Name[8] = "OUT_CURSOR6";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[5] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[6] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[7] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[8] = (char)OracleType.Cursor;


                MyOraDB.Parameter_Values[0] = ARG_FAC;
                MyOraDB.Parameter_Values[1] = ARG_YMD;
                MyOraDB.Parameter_Values[2] = ARG_LINE;
                MyOraDB.Parameter_Values[3] = "";
                MyOraDB.Parameter_Values[4] = "";
                MyOraDB.Parameter_Values[5] = "";
                MyOraDB.Parameter_Values[6] = "";
                MyOraDB.Parameter_Values[7] = "";
                MyOraDB.Parameter_Values[8] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret;
            }
            catch
            {
                return null;
            }
        }
        private DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Value1", typeof(int));
            table.Columns.Add("Value2", typeof(int));
            table.Columns.Add("Value3", typeof(int));
            table.Columns.Add("Value4", typeof(int));
            table.Columns.Add("Name", typeof(string));
            Random r = new Random();
            // Here we add DataRows.
            for (int i = 0; i < 9; i++)
            {
                table.Rows.Add(r.Next(10, 100), r.Next(10, 100), r.Next(10, 100), r.Next(10, 100), "TRIP " + (i + 1).ToString());
            }

            return table;
        }

        private void BindingDataIncoming()
        {
            try
            {
                int inTavgRatioToday = 0, inTavgRatioYes = 0;
                lblYesIncoming.Text = "0%";
                lblTodayIncoming.Text = "0%";

                ds = TMS_DASHBOARD_LT_SEL("MES.PKG_TMS_DASHBOARD.TMS_DASHBOARD_LT_SEL", "VJ", DateTime.Now.ToString("yyyyMMdd"), ComVar.Var._strValue1);


                if (ds.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "TODAY").Count() > 0)
                {
                    inTavgRatioToday = Convert.ToInt32(ds.Tables[0].Compute("AVG(RATIO_INCOMING)", "YT='TODAY'"));
                    lblTodayIncoming.Text = string.Format("{0:n0}", inTavgRatioToday) + "%";
                }
                if (ds.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "YESTERDAY").Count() > 0)
                {
                    inTavgRatioYes = Convert.ToInt32(ds.Tables[0].Compute("AVG(RATIO_INCOMING)", "YT='YESTERDAY'"));
                    lblYesIncoming.Text = string.Format("{0:n0}", inTavgRatioYes) + "%";
                }


                //BindingChartIncoming
                chartControl1.DataSource = ds.Tables[0];
                chartControl1.SeriesDataMember = "CMP_CD";
                chartControl1.SeriesTemplate.ArgumentDataMember = "YT";
                chartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "RATIO_INCOMING" });
                chartControl1.SeriesTemplate.Label.TextPattern = "{V:#,#}";
                chartControl1.CrosshairOptions.CrosshairLabelMode = CrosshairLabelMode.ShowForNearestSeries;
                chartControl1.SeriesTemplate.CrosshairLabelPattern = "{S}: {V}";
                chartControl1.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                ((XYDiagram)chartControl1.Diagram).AxisY.Title.Visibility = DefaultBoolean.True;
                ((XYDiagram)chartControl1.Diagram).AxisY.Title.Text = "Percentage";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private void BindingDataSetOut()
        {
            try
            {
                //BindingChartSetOut
                chartControl4.DataSource = ds.Tables[2];
                //chartControl4.Series[0].ArgumentDataMember = "STYLE_CD";
                //chartControl4.Series[0].ValueDataMembers.AddRange(new string[] { "OUT_QTY" });
                //chartControl4.Series[1].ArgumentDataMember = "STYLE_CD";
                //chartControl4.Series[1].ValueDataMembers.AddRange(new string[] { "BAL_QTY" });
                //chartControl3.DataSource = ds.Tables[2];
                //chartControl3.Series[0].ArgumentDataMember = "STYLE_CD";
                //chartControl3.Series[0].ValueDataMembers.AddRange(new string[] { "RATIO_SET" });
                if (ds.Tables[2].Select("LINE_CD = '201' AND LABEL_NM <> 'Ratio'").Count() > 0)
                {
                    chartControl3.DataSource = ds.Tables[2].Select("LINE_CD = '201' AND LABEL_NM <> 'Ratio'").CopyToDataTable();
                    chartControl3.SeriesDataMember = "LABEL_NM";
                    chartControl3.SeriesTemplate.ArgumentDataMember = "CMP_CD";
                    chartControl3.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "VAL" });
                    chartControl3.SeriesTemplate.Label.TextPattern = "{V}";
                    chartControl3.CrosshairOptions.CrosshairLabelMode = CrosshairLabelMode.ShowCommonForAllSeries;
                    chartControl3.SeriesTemplate.CrosshairLabelPattern = "{S}: {V}";
                    chartControl3.SeriesTemplate.Label.TextPattern = "{V:#,#}";
                    chartControl3.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                    chartControl3.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
                    ((XYDiagram)chartControl3.Diagram).AxisY.Label.TextPattern = "{V:#,#}";
                    ((XYDiagram)chartControl3.Diagram).DefaultPane.BorderVisible = false;
                    ((XYDiagram)chartControl3.Diagram).AxisY.GridLines.Visible = false;
                    ((XYDiagram)chartControl3.Diagram).AxisY.Title.Visibility = DefaultBoolean.True;
                    ((XYDiagram)chartControl3.Diagram).AxisY.Title.Text = "Prs";
                    ((XYDiagram)chartControl3.Diagram).DefaultPane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                }
                else
                    chartControl3.DataSource = null;
                if (ds.Tables[2].Select("LINE_CD = '202' AND LABEL_NM <> 'Ratio'").Count() > 0)
                {
                    chartControl4.DataSource = ds.Tables[2].Select("LINE_CD = '202' AND LABEL_NM <> 'Ratio'").CopyToDataTable();
                    chartControl4.SeriesDataMember = "LABEL_NM";
                    chartControl4.SeriesTemplate.ArgumentDataMember = "CMP_CD";
                    chartControl4.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "VAL" });
                    chartControl4.SeriesTemplate.Label.TextPattern = "{V}";
                    chartControl4.CrosshairOptions.CrosshairLabelMode = CrosshairLabelMode.ShowCommonForAllSeries;
                    chartControl4.SeriesTemplate.CrosshairLabelPattern = "{S}: {V}";
                    chartControl4.SeriesTemplate.Label.TextPattern = "{V:#,#}";
                    chartControl4.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                    chartControl4.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
                    ((XYDiagram)chartControl4.Diagram).AxisY.Label.TextPattern = "{V:#,#}";
                    ((XYDiagram)chartControl4.Diagram).DefaultPane.BorderVisible = false;
                    ((XYDiagram)chartControl4.Diagram).AxisY.GridLines.Visible = false;
                    ((XYDiagram)chartControl4.Diagram).AxisY.Title.Visibility = DefaultBoolean.True;
                    ((XYDiagram)chartControl4.Diagram).AxisY.Title.Text = "Prs";
                    ((XYDiagram)chartControl4.Diagram).DefaultPane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                }
                else
                    chartControl3.DataSource = null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void BindingChartShortage()
        {
            try
            {
                int SShort1 = 0, SShort2 = 0;
                lblShr1.Text = "0 Prs";
                lblShr2.Text = "0 Prs";
                if (ds.Tables[1].Select("LINE_CD = '201'", "DAYDAY").Count() > 0)
                {
                    SShort1 = Convert.ToInt32(ds.Tables[1].Compute("SUM(SHR_QTY)", "LINE_CD='201'"));
                    lblShr1.Text = string.Format("{0:n0}", SShort1) + " Prs";
                    chartControl2.DataSource = ds.Tables[1].Select("LINE_CD = '201'", "DD").CopyToDataTable();
                    chartControl2.SeriesDataMember = "MLINE_CD";
                    chartControl2.SeriesTemplate.ArgumentDataMember = "DAYDAY";
                    chartControl2.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "SHR_QTY" });
                    chartControl2.SeriesTemplate.Label.TextPattern = "{V}";
                    chartControl2.CrosshairOptions.CrosshairLabelMode = CrosshairLabelMode.ShowCommonForAllSeries;
                    chartControl2.SeriesTemplate.CrosshairLabelPattern = "{S}: {V}";
                    chartControl2.SeriesTemplate.Label.TextPattern = "{V:#,#}";
                    chartControl2.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                    chartControl2.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
                    ((XYDiagram)chartControl2.Diagram).AxisY.Label.TextPattern = "{V:#,#}";
                    ((XYDiagram)chartControl2.Diagram).DefaultPane.BorderVisible = false;
                    ((XYDiagram)chartControl2.Diagram).AxisY.GridLines.Visible = false;
                    ((XYDiagram)chartControl2.Diagram).AxisY.Title.Visibility = DefaultBoolean.True;
                    ((XYDiagram)chartControl2.Diagram).AxisY.Title.Text = "Prs";

                }
                else
                    chartControl2.DataSource = null;

                if (ds.Tables[1].Select("LINE_CD = '202'", "DAYDAY").Count() > 0)
                {
                    SShort2 = Convert.ToInt32(ds.Tables[1].Compute("SUM(SHR_QTY)", "LINE_CD='202'"));
                    lblShr2.Text = string.Format("{0:n0}", SShort2) + " Prs";
                    chartControl5.DataSource = ds.Tables[1].Select("LINE_CD = '202'", "DD").CopyToDataTable();

                    chartControl5.SeriesDataMember = "MLINE_CD";
                    chartControl5.SeriesTemplate.ArgumentDataMember = "DAYDAY";
                    chartControl5.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "SHR_QTY" });
                    chartControl5.SeriesTemplate.Label.TextPattern = "{V}";
                    chartControl5.CrosshairOptions.CrosshairLabelMode = CrosshairLabelMode.ShowCommonForAllSeries;
                    chartControl5.SeriesTemplate.CrosshairLabelPattern = "{S}: {V}";
                    chartControl5.SeriesTemplate.Label.TextPattern = "{V:#,#}";
                    chartControl5.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                    chartControl5.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
                    ((XYDiagram)chartControl5.Diagram).AxisY.Label.TextPattern = "{V:#,#}";
                    ((XYDiagram)chartControl5.Diagram).DefaultPane.BorderVisible = false;
                    ((XYDiagram)chartControl5.Diagram).AxisY.GridLines.Visible = false;
                    ((XYDiagram)chartControl5.Diagram).AxisY.Title.Visibility = DefaultBoolean.True;
                    ((XYDiagram)chartControl5.Diagram).AxisY.Title.Text = "Prs";
                }
                else
                    chartControl5.DataSource = null;

                //chartControl2.Series[0].ArgumentDataMember = "DAYDAY";
                //chartControl2.Series[0].ValueDataMembers.AddRange(new string[] { "SHR_QTY" });
                //chartControl2.Series[1].ArgumentDataMember = "DAYDAY";
                //chartControl2.Series[1].ValueDataMembers.AddRange(new string[] { "SHR_QTY" });
            }
            catch { }

        }


        private void BindingChart()
        {
            try
            {
                //XONG CHART 1
                //chartControl1.DataSource = GetTable();
                //chartControl1.Series[0].ArgumentDataMember = "Name";
                //chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "Value1" });
                //chartControl1.Series[1].ArgumentDataMember = "Name";
                //chartControl1.Series[1].ValueDataMembers.AddRange(new string[] { "Value2" });
                //chartControl1.Series[2].ArgumentDataMember = "Name";
                //chartControl1.Series[2].ValueDataMembers.AddRange(new string[] { "Value3" });
            }
            catch { }
            try
            {
                //chartControl2.DataSource = GetTable();
                //chartControl2.Series[0].ArgumentDataMember = "Name";
                //chartControl2.Series[0].ValueDataMembers.AddRange(new string[] { "Value1" });
                //chartControl2.Series[1].ArgumentDataMember = "Name";
                //chartControl2.Series[1].ValueDataMembers.AddRange(new string[] { "Value2" });

                //chartControl5.DataSource = GetTable();
                //chartControl5.Series[0].ArgumentDataMember = "Name";
                //chartControl5.Series[0].ValueDataMembers.AddRange(new string[] { "Value1" });
                //chartControl5.Series[1].ArgumentDataMember = "Name";
                //chartControl5.Series[1].ValueDataMembers.AddRange(new string[] { "Value2" });

            }
            catch { }

            try
            {
                //chartControl3.DataSource = GetTable();
                //chartControl3.Series[0].ArgumentDataMember = "Name";
                //chartControl3.Series[0].ValueDataMembers.AddRange(new string[] { "Value1" });
                //chartControl3.Series[1].ArgumentDataMember = "Name";
                //chartControl3.Series[1].ValueDataMembers.AddRange(new string[] { "Value2" });


            }
            catch { }
            try
            {
                //chartControl4.DataSource = GetTable();
                //chartControl4.Series[0].ArgumentDataMember = "Name";
                //chartControl4.Series[0].ValueDataMembers.AddRange(new string[] { "Value1" });
                //chartControl4.Series[1].ArgumentDataMember = "Name";
                //chartControl4.Series[1].ValueDataMembers.AddRange(new string[] { "Value2" });

            }
            catch { }

            try
            {
                //chartControl5.DataSource = GetTable();
                //chartControl5.Series[0].ArgumentDataMember = "Name";
                //chartControl5.Series[0].ValueDataMembers.AddRange(new string[] { "Value3" });
            }
            catch { }
        }

        private void tmrLoad_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
            iCount++;
            try
            {
                if (iCount > 60)
                {
                    // BindingChart();
                    splashScreenManager1.ShowWaitForm();
                    BindingDataIncoming();
                    BindingChartShortage();
                    BindingDataSetOut();
                    splashScreenManager1.CloseWaitForm();
                    iCount = 0;
                }
            }
            catch { iCount = 0; splashScreenManager1.CloseWaitForm(); }
        }

        private void FRM_TMS_DASH_LT_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                //DEBUG
                ComVar.Var._strValue1 = "014";

                iCount = 60;
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
                tmrLoad.Start();
            }
            else
                tmrLoad.Stop();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (ComVar.Var._bValue1)
                ComVar.Var.callForm = "342";
            else
                ComVar.Var.callForm = "231";
        }
    }
}
