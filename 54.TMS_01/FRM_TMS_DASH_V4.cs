using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;
using System.Data.OracleClient;
using DevExpress.XtraCharts;
using DevExpress.LookAndFeel;
using System.Drawing.Drawing2D;
using DevExpress.Utils;

namespace FORM
{
    public partial class FRM_TMS_DASH_V4 : Form
    {
        public FRM_TMS_DASH_V4()
        {
            InitializeComponent();

        }
        DataSet dsToday;
        int cCount = 0, NRatioYes = 0, inTavgRatioToday, inTavgRatioYes, NRatioToDay = 0;
        bool flag1, flag2, isToday = false;
        string _LINE = "001", _MLINE = "001", _DATE = DateTime.Now.ToString("yyyyMMdd"); //default
        #region Db
        private DataSet Sel_Data_Chart(string Proc_Name, string V_P_LINE, string V_P_MLINE, string V_P_DATE)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = Proc_Name;
                MyOraDB.ReDim_Parameter(8);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "V_P_LINE";
                MyOraDB.Parameter_Name[1] = "V_P_MLINE";
                MyOraDB.Parameter_Name[2] = "V_P_YMD";
                MyOraDB.Parameter_Name[3] = "CV_1";
                MyOraDB.Parameter_Name[4] = "CV_2";
                MyOraDB.Parameter_Name[5] = "CV_3";
                MyOraDB.Parameter_Name[6] = "CV_4";
                MyOraDB.Parameter_Name[7] = "CV_5";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[5] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[6] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[7] = (char)OracleType.Cursor;


                MyOraDB.Parameter_Values[0] = V_P_LINE;
                MyOraDB.Parameter_Values[1] = V_P_MLINE;
                MyOraDB.Parameter_Values[2] = V_P_DATE;
                MyOraDB.Parameter_Values[3] = "";
                MyOraDB.Parameter_Values[4] = "";
                MyOraDB.Parameter_Values[5] = "";
                MyOraDB.Parameter_Values[6] = "";
                MyOraDB.Parameter_Values[7] = "";

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
        #endregion

        private void PivotTable(DataTable dataTable)
        {
            var pivotedDataTable = new DataTable();
            var firstColumnName = "TRIP";
            var pivotColumnName = "CMP_CD";
            pivotedDataTable.Columns.Add(firstColumnName);
            pivotedDataTable.Columns.AddRange(dataTable.Rows.Cast<DataRow>().Select(x => new DataColumn(x[pivotColumnName].ToString())).ToArray());
            for (var index = 1; index < dataTable.Columns.Count; index++)
            {
                pivotedDataTable.Rows.Add(new List<object> { dataTable.Columns[index].ColumnName }.Concat(dataTable.Rows.Cast<DataRow>().Select(x => x[dataTable.Columns[index].ColumnName])).ToArray());
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
            for (int i = 0; i < 5; i++)
            {
                table.Rows.Add(r.Next(10, 100), r.Next(10, 100), r.Next(10, 100), r.Next(10, 100), "TRIP " + (i + 1).ToString());
            }

            return table;
        }

        private void windowsUIView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {

        }



        private void BindingChart1_nOuSE(DataSet dt, int isToday) //1 today , 2 yesterday, 3 all
        {
            try
            {
                dsToday = dt;
                inTavgRatioToday = 0; inTavgRatioYes = 0;
                if (isToday == 1)
                    if (dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "TODAY").Count() > 0)
                    {
                        gridControl1.DataSource = dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "TODAY").CopyToDataTable();
                        inTavgRatioToday = Convert.ToInt32(dt.Tables[0].Compute("AVG(RATIO)", "YT='TODAY'"));
                        if (dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "YESTERDAY").Count() > 0)
                            inTavgRatioYes = Convert.ToInt32(dt.Tables[0].Compute("AVG(RATIO)", "YT='YESTERDAY'"));
                    }
                    else
                        gridControl1.DataSource = null;
                else if (isToday == 2)
                    if (dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "YESTERDAY").Count() > 0)
                    {
                        gridControl1.DataSource = dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "YESTERDAY").CopyToDataTable();
                        inTavgRatioYes = Convert.ToInt32(dt.Tables[0].Compute("AVG(RATIO)", "YT='YESTERDAY'"));
                        if (dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "TODAY").Count() > 0)
                            inTavgRatioToday = Convert.ToInt32(dt.Tables[0].Compute("AVG(RATIO)", "YT='TODAY'"));

                    }
                    else
                        gridControl1.DataSource = null;
                else
                {

                    if (dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "YESTERDAY").Count() > 0)
                    {
                        gridControl1.DataSource = dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "YESTERDAY").CopyToDataTable();
                        inTavgRatioYes = Convert.ToInt32(dt.Tables[0].Compute("AVG(RATIO)", "YT='YESTERDAY'"));
                        if (dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "TODAY").Count() > 0)
                            inTavgRatioToday = Convert.ToInt32(dt.Tables[0].Compute("AVG(RATIO)", "YT='TODAY'"));

                        lblToday_Label.BackColor = Color.Transparent;
                        btnYesterday.Appearance.BackColor = Color.Orange;
                        btnYesterday.Appearance.BackColor2 = Color.Orange;
                        btnToday.Appearance.BackColor = Color.LightSteelBlue;
                        btnToday.Appearance.BackColor2 = Color.LightSteelBlue;
                    }
                    if (dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "TODAY").Count() > 0)
                    {
                        gridControl1.DataSource = dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "TODAY").CopyToDataTable();
                        inTavgRatioToday = Convert.ToInt32(dt.Tables[0].Compute("AVG(RATIO)", "YT='TODAY'"));
                        if (dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "YESTERDAY").Count() > 0)
                            inTavgRatioYes = Convert.ToInt32(dt.Tables[0].Compute("AVG(RATIO)", "YT='YESTERDAY'"));

                        lblYesterday_Label.BackColor = Color.Transparent;
                        btnToday.Appearance.BackColor = Color.Orange;
                        btnToday.Appearance.BackColor2 = Color.Orange;
                        btnYesterday.Appearance.BackColor = Color.LightSteelBlue;
                        btnYesterday.Appearance.BackColor2 = Color.LightSteelBlue;
                    }
                }


                DifferentRepositoriesProgressBar drHelper = new DifferentRepositoriesProgressBar(bandedGridView1.Columns["RATIO"]);
                for (int i = 0; i < bandedGridView1.Columns.Count; i++)
                {
                    bandedGridView1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    bandedGridView1.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                    bandedGridView1.Columns[i].OptionsColumn.ReadOnly = true;
                    bandedGridView1.Columns[i].OptionsColumn.AllowEdit = false;
                    bandedGridView1.Columns[i].OptionsFilter.AllowFilter = false;
                    bandedGridView1.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    bandedGridView1.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 12f, FontStyle.Regular);
                    bandedGridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    if (i <= 1)
                    {
                        bandedGridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    }
                    else if (i == 3 || i == 4)
                    {
                        bandedGridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        bandedGridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        bandedGridView1.Columns[i].DisplayFormat.FormatString = "#,#.#";
                        bandedGridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    }
                    else
                        bandedGridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;


                }

                //Reset Number
                NRatioYes = 0;
                NRatioToDay = 0;
                flag1 = false; flag2 = false;
                tmrNumber.Enabled = true;
                tmrNumber.Start();
                //=================

                // if (inTavgRatioToday != 0)
                //     lblRatioToday.Text = "Ratio: " + inTavgRatioToday.ToString();
                //else
                //    lblRatioToday.Text = "Ratio: 0%";
                // if (inTavgRatioYes != 0)
                //     lblRatioYes.Text = "Ratio: " + inTavgRatioYes.ToString();
                //else
                //    lblRatioYes.Text = "Ratio: 0%";

                //chartControl1.Series[0].ArgumentDataMember = "TRIP";
                //chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "UP_QTY" });

                //chartControl1.SeriesDataMember = "CMP_CD";
                //chartControl1.SeriesTemplate.ArgumentDataMember = "TRIP";
                //chartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "QTY" });
                //chartControl1.SeriesTemplate.Label.TextPattern = "{V:#,#}";
                //chartControl1.CrosshairOptions.CrosshairLabelMode = CrosshairLabelMode.ShowForNearestSeries;
                //chartControl1.SeriesTemplate.CrosshairLabelPattern = "{S}: {V}";
                //  chartControl1.SeriesTemplate.ChangeView(DevExpress.XtraCharts.ViewType.Spline);
                //  SplineSeriesView view = (SplineSeriesView)chartControl1.SeriesTemplate.View;
                // view.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;

            }
            catch (Exception ex) { }


        }

        private void BindingChart1(DataSet dt, int isToday) //1 today , 2 yesterday, 3 all
        {
            try
            {
                dsToday = dt;
                inTavgRatioToday = 0; inTavgRatioYes = 0;
                if (isToday == 1)
                    if (dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "TODAY").Count() > 0)
                    {
                        chartControl1.DataSource = dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "TODAY").CopyToDataTable();
                        inTavgRatioToday = Convert.ToInt32(dt.Tables[0].Compute("AVG(RATIO)", "YT='TODAY'"));
                        if (dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "YESTERDAY").Count() > 0)
                            inTavgRatioYes = Convert.ToInt32(dt.Tables[0].Compute("AVG(RATIO)", "YT='YESTERDAY'"));
                    }
                    else
                        chartControl1.DataSource = null;
                else if (isToday == 2)
                    if (dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "YESTERDAY").Count() > 0)
                    {
                        chartControl1.DataSource = dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "YESTERDAY").CopyToDataTable();
                        inTavgRatioYes = Convert.ToInt32(dt.Tables[0].Compute("AVG(RATIO)", "YT='YESTERDAY'"));
                        if (dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "TODAY").Count() > 0)
                            inTavgRatioToday = Convert.ToInt32(dt.Tables[0].Compute("AVG(RATIO)", "YT='TODAY'"));

                    }
                    else
                        chartControl1.DataSource = null;
                else
                {

                    if (dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "YESTERDAY").Count() > 0)
                    {
                        chartControl1.DataSource = dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "YESTERDAY").CopyToDataTable();
                        inTavgRatioYes = Convert.ToInt32(dt.Tables[0].Compute("AVG(RATIO)", "YT='YESTERDAY'"));
                        if (dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "TODAY").Count() > 0)
                            inTavgRatioToday = Convert.ToInt32(dt.Tables[0].Compute("AVG(RATIO)", "YT='TODAY'"));

                        lblToday_Label.BackColor = Color.Transparent;
                        btnYesterday.Appearance.BackColor = Color.Orange;
                        btnYesterday.Appearance.BackColor2 = Color.Orange;
                        btnToday.Appearance.BackColor = Color.LightSteelBlue;
                        btnToday.Appearance.BackColor2 = Color.LightSteelBlue;
                    }
                    if (dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "TODAY").Count() > 0)
                    {
                        chartControl1.DataSource = dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "TODAY").CopyToDataTable();
                        inTavgRatioToday = Convert.ToInt32(dt.Tables[0].Compute("AVG(RATIO)", "YT='TODAY'"));
                        if (dt.Tables[0].AsEnumerable().Where(r => r.Field<string>("YT") == "YESTERDAY").Count() > 0)
                            inTavgRatioYes = Convert.ToInt32(dt.Tables[0].Compute("AVG(RATIO)", "YT='YESTERDAY'"));

                        lblYesterday_Label.BackColor = Color.Transparent;
                        btnToday.Appearance.BackColor = Color.Orange;
                        btnToday.Appearance.BackColor2 = Color.Orange;
                        btnYesterday.Appearance.BackColor = Color.LightSteelBlue;
                        btnYesterday.Appearance.BackColor2 = Color.LightSteelBlue;
                    }
                }
                //Reset Number
                NRatioYes = 0;
                NRatioToDay = 0;
                flag1 = false; flag2 = false;
                tmrNumber.Enabled = true;
                tmrNumber.Start();
                //=================

                // if (inTavgRatioToday != 0)
                //     lblRatioToday.Text = "Ratio: " + inTavgRatioToday.ToString();
                //else
                //    lblRatioToday.Text = "Ratio: 0%";
                // if (inTavgRatioYes != 0)
                //     lblRatioYes.Text = "Ratio: " + inTavgRatioYes.ToString();
                //else
                //    lblRatioYes.Text = "Ratio: 0%";

                //chartControl1.Series[0].ArgumentDataMember = "TRIP";
                //chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "UP_QTY" });

                chartControl1.SeriesDataMember = "CMP_CD";
                chartControl1.SeriesTemplate.ArgumentDataMember = "TRIP";
                chartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "RATIO" });
                chartControl1.SeriesTemplate.Label.TextPattern = "{V}";
                chartControl1.CrosshairOptions.CrosshairLabelMode = CrosshairLabelMode.ShowForNearestSeries;
                chartControl1.SeriesTemplate.CrosshairLabelPattern = "{S}: {V}";
                chartControl1.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                ((XYDiagram)chartControl1.Diagram).AxisY.Title.Visibility = DefaultBoolean.True;
                ((XYDiagram)chartControl1.Diagram).AxisY.Title.Text = "Percentage";
                //  chartControl1.SeriesTemplate.ChangeView(DevExpress.XtraCharts.ViewType.Spline);
                //  SplineSeriesView view = (SplineSeriesView)chartControl1.SeriesTemplate.View;
                // view.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;

            }
            catch (Exception ex) { }


        }


        //Chart Component Shortage Today
        private void BindingChart2(DataSet dt, bool isToday)
        {
            try
            {
                lblSQMToday.Text = lblSQMYesterday.Text = "0 Prs";
                if (dt.Tables[1].Select("YT = 'TODAY'").Count() > 0)
                {
                    lblSQMToday.Text = string.Format("{0:n0}", dt.Tables[1].Compute("SUM(QTY)", "YT='TODAY'")) + " Prs";
                    chartControl5.DataSource = dt.Tables[1].Select("YT = 'TODAY'").CopyToDataTable(); ;
                    chartControl5.Series[0].ArgumentDataMember = "DAYDAY";
                    chartControl5.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                    chartControl5.Series[1].ArgumentDataMember = "DAYDAY";
                    chartControl5.Series[1].ValueDataMembers.AddRange(new string[] { "QTY" });
                }
                else
                    chartControl5.DataSource = null;

                if (dt.Tables[1].Select("YT = 'YESTERDAY'").Count() > 0)
                {
                    lblSQMYesterday.Text = string.Format("{0:n0}", dt.Tables[1].Compute("SUM(QTY)", "YT='YESTERDAY'")) + " Prs";
                    chartControl4.DataSource = dt.Tables[1].Select("YT = 'YESTERDAY'").CopyToDataTable();
                    chartControl4.Series[0].ArgumentDataMember = "DAYDAY";
                    chartControl4.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                    chartControl4.Series[1].ArgumentDataMember = "DAYDAY";
                    chartControl4.Series[1].ValueDataMembers.AddRange(new string[] { "QTY" });
                }
                else
                    chartControl4.DataSource = null;


            }
            catch (Exception) { }
        }

        //Chart Component Shortage Yesterday
        private void BindingChart5(DataSet dt)
        {
            try
            {
                lblTotalTodaySet.Text = "0 Prs"; lblTotalTodayDeli.Text = "0 Prs";
                lblTotalTodaySet.Text = string.Format("{0:n0}", dt.Tables[3].Rows[0]["TOT_SET"]) + " Prs";
                lblTotalTodayDeli.Text = string.Format("{0:n0}", dt.Tables[3].Rows[0]["TOT_UP"]) + " Prs";
                DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();
                chartControl2.DataSource = dt.Tables[3];
                chartControl2.Series[0].ArgumentDataMember = "TRIP";
                chartControl2.Series[0].ValueDataMembers.AddRange(new string[] { "RATE_UP_SET" });

                //==================
                constantLine1.AxisValueSerializable = "10";
                constantLine1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(208)))), ((int)(((byte)(80)))));
                constantLine1.LineStyle.Thickness = 3;
                constantLine1.Name = "Average";
                constantLine1.Title.Alignment = DevExpress.XtraCharts.ConstantLineTitleAlignment.Far;
                constantLine1.Title.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                constantLine1.AxisValue = dt.Tables[3].Rows[0]["TOT_UP"].ToString() != "0" ? (Convert.ToDouble(dt.Tables[3].Rows[0]["TOT_SET"]) / Convert.ToDouble(dt.Tables[3].Rows[0]["TOT_UP"]) * 100).ToString() : "0";
                ((XYDiagram)chartControl2.Diagram).AxisY.ConstantLines.Clear();
                ((XYDiagram)chartControl2.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { constantLine1 });
                //==================

                //chartControl2.Series[1].ArgumentDataMember = "TRIP";
                //chartControl2.Series[1].ValueDataMembers.AddRange(new string[] { "RATIO_TOT_UP" });
                chartControl3.DataSource = dt.Tables[3];
                chartControl3.Series[0].ArgumentDataMember = "TRIP";
                chartControl3.Series[0].ValueDataMembers.AddRange(new string[] { "UP" });
                chartControl3.Series[1].ArgumentDataMember = "TRIP";
                chartControl3.Series[1].ValueDataMembers.AddRange(new string[] { "SET" });
                chartControl3.Series[2].ArgumentDataMember = "TRIP";
                chartControl3.Series[2].ValueDataMembers.AddRange(new string[] { "RATE_UP_SET" });

                //chartControl3.SeriesDataMember = "CMP_CD";
                //chartControl3.SeriesTemplate.ArgumentDataMember = "TRIP";
                //chartControl3.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "QTY" });
                //chartControl3.SeriesTemplate.Label.TextPattern = "{V:#,#}";
                //chartControl1.SeriesTemplate.ChangeView(DevExpress.XtraCharts.ViewType.Spline);
                //chartControl1.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            }
            catch (Exception) { }
        }

        private void BindingChart4(DataTable dt)
        {

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
            }
            catch { }

            try
            {
                //chartControl3.DataSource = GetTable();
                //chartControl3.Series[0].ArgumentDataMember = "Name";
                //chartControl3.Series[0].ValueDataMembers.AddRange(new string[] { "Value1" });

            }
            catch { }
            try
            {
                //chartControl4.DataSource = GetTable();
                //chartControl4.Series[0].ArgumentDataMember = "Name";
                //chartControl4.Series[0].ValueDataMembers.AddRange(new string[] { "Value1" });

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

        private void FRM_TMS_DASH_Load(object sender, EventArgs e)
        {
            // Access the Default ToolTipController. 
            ToolTipController defController = ToolTipController.DefaultController;
            // Customize the controller's settings. 
            defController.Appearance.BackColor = Color.AntiqueWhite;
            defController.ShowBeak = true;
            // Set a tooltip for the TextBox control. 
            defController.SetToolTip(chartControl4, "Click vào đây để xem theo chuyến");
            defController.SetToolTip(chartControl5, "Click vào đây để xem theo chuyến");

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //cCount = 60;
                //BindingChart();
                //BindingChart1(Sel_Data_Chart("MES.SP_TMS_DASHBOARD_Q1", _LINE, _DATE), true);
                //BindingChart2(Sel_Data_Chart("MES.SP_TMS_DASHBOARD_Q2", _LINE, _DATE), true);
                //BindingChart5(Sel_Data_Chart("MES.SP_TMS_DASHBOARD_Q5", _LINE, _DATE));
                if (ComVar.Var._bValue1)
                    ComVar.Var.callForm = "342";
                else
                    ComVar.Var.callForm = "179";
                this.Cursor = Cursors.Default;
            }
            catch { }
        }


        DataTable dtPopup;
        private void tmrLoad_Tick(object sender, EventArgs e)
        {
            cCount++;
            if (cCount >= 60)
            {
                this.Cursor = Cursors.WaitCursor;
                splashScreenManager2.ShowWaitForm();
                //BindingChart();
                DataSet ds = Sel_Data_Chart("MES.SP_TMS_DASHBOARD_Q3", _LINE, _MLINE, _DATE);
                BindingChart1(ds, 3);
                BindingChart2(ds, true);
                BindingChart5(ds);
                dtPopup = ds.Tables[4];
                cCount = 0;
                splashScreenManager2.CloseWaitForm();
                this.Cursor = Cursors.Default;
            }
        }

        private void tmrNumber_Tick(object sender, EventArgs e)
        {
            NRatioYes++;
            NRatioToDay++;

            if (NRatioYes >= inTavgRatioYes)
            {
                lblRatioYes.Text = "Ratio: " + inTavgRatioYes + "%"; flag1 = true;
            }
            else
            { lblRatioYes.Text = "Ratio: " + NRatioYes.ToString() + "%"; flag1 = false; }

            if (NRatioToDay >= inTavgRatioToday)
            { lblRatioToday.Text = "Ratio: " + inTavgRatioToday + "%"; flag2 = true; }
            else
            { lblRatioToday.Text = "Ratio: " + NRatioToDay.ToString() + "%"; flag2 = false; }
            if (flag1 && flag2)
            {
                tmrNumber.Enabled = false;
                tmrNumber.Stop();
            }

        }

        private void btnYesterday_Click(object sender, EventArgs e)
        {

            isToday = false;
            lblToday_Label.BackColor = Color.Transparent;
            btnYesterday.Appearance.BackColor = Color.Orange;
            btnYesterday.Appearance.BackColor2 = Color.Orange;
            btnToday.Appearance.BackColor = Color.LightSteelBlue;
            btnToday.Appearance.BackColor2 = Color.LightSteelBlue;
            this.Cursor = Cursors.WaitCursor;
            splashScreenManager2.ShowWaitForm();
            BindingChart1(dsToday, 2);
            cCount = 0;
            splashScreenManager2.CloseWaitForm();
            this.Cursor = Cursors.Default;
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            isToday = true;
            lblYesterday_Label.BackColor = Color.Transparent;
            btnToday.Appearance.BackColor = Color.Orange;
            btnToday.Appearance.BackColor2 = Color.Orange;
            btnYesterday.Appearance.BackColor = Color.LightSteelBlue;
            btnYesterday.Appearance.BackColor2 = Color.LightSteelBlue;
            this.Cursor = Cursors.WaitCursor;
            splashScreenManager2.ShowWaitForm();
            BindingChart1(dsToday, 1);
            cCount = 0;
            splashScreenManager2.CloseWaitForm();
            this.Cursor = Cursors.Default;
        }

        private void FRM_TMS_DASH_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                try
                {
                    isToday = true;
                    btnToday.Appearance.BackColor = Color.Orange;
                    btnToday.Appearance.BackColor2 = Color.Orange;
                    //ComVar.Var._strValue1 = "VJ1";
                    _LINE = string.IsNullOrEmpty(ComVar.Var._strValue1) ? "099" : ComVar.Var._strValue1;
                    _MLINE = string.IsNullOrEmpty(ComVar.Var._strValue2) ? "000" : ComVar.Var._strValue2;
                    if (_LINE.Equals("VJ1"))
                        lblLine.Text = "VINH CUU";
                    else if (_LINE.Equals("FTY01"))
                        lblLine.Text = "FACTORY 1";
                    else
                    {
                        if (Convert.ToInt32(_LINE) < 6)
                            lblLine.Text = "LINE " + Convert.ToInt32(_LINE).ToString() + " - FACTORY 1";
                        else if (_LINE.Equals("099"))
                            lblLine.Text = "PLANT N - FACTORY 3";
                        else
                            lblLine.Text = "--";
                    }
                    cCount = 60;
                    tmrLoad.Start();
                }
                catch { }
            }
            else
                tmrLoad.Stop();
        }

        private void chartControl1_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            e.LegendText = e.LegendText + " : " + ((DataRowView)e.SeriesPoint.Tag)["CMP_CD"].ToString() + " : " + ((DataRowView)e.SeriesPoint.Tag)["RATIO"].ToString();
        }
        private void tmrBlinking_Tick(object sender, EventArgs e)
        {
            Label[] lbl = { lblTimeTrip1, lblTimeTrip2, lblTimeTrip3, lblTimeTrip4, lblTimeTrip5 };
            for (int i = 0; i < lbl.Length; i++)
            {
                if (lbl[i].Text.IndexOf(":") > 0)
                    lbl[i].Text = lbl[i].Text.Replace(":", " ");
                else
                    lbl[i].Text = lbl[i].Text.Replace(" ", ":");
            }

            if (isToday)
            {
                if (lblToday_Label.BackColor == Color.Yellow)
                    lblToday_Label.BackColor = Color.Transparent;
                else
                    lblToday_Label.BackColor = Color.Yellow;
            }
            else
            {
                if (lblYesterday_Label.BackColor == Color.Yellow)
                    lblYesterday_Label.BackColor = Color.Transparent;
                else
                    lblYesterday_Label.BackColor = Color.Yellow;
            }

        }

        private void ControlMouseHover(object sender, EventArgs e)
        {
            //cCount = 0;
            //MessageBox.Show("Test");
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn) // Plant N
            {
                _LINE = "099";
                _MLINE = "001";
                cCount = 59;
            }
            else //F1
            {
                _LINE = "001";
                _MLINE = "000";
                cCount = 59;
            }
        }

        private void lblLine_DoubleClick(object sender, EventArgs e)
        {
            // FRM_LINE FRM_LINE = new FRM_LINE();
            // FRM_LINE.OnMenuSelect += MenuSel;
            // FRM_LINE.ShowDialog();
        }

        private void chartControl4_Click(object sender, EventArgs e)
        {
            try
            {
                bool isToday;
                if (((DevExpress.XtraCharts.ChartControl)sender).Name.ToString().Equals("chartControl4"))
                    isToday = false;
                else
                    isToday = true;
                FRM_POPUP_SQM_TRACKING POPUP = new FRM_POPUP_SQM_TRACKING(((DevExpress.XtraCharts.ChartControl)sender), dtPopup, isToday);
                tmrLoad.Stop();
                // POPUP.ShowDialog();
                POPUP.ShowBeakForm();
                cCount = 0;
                tmrLoad.Start();
            }
            catch (Exception)
            {
                cCount = 0;
                tmrLoad.Start();
            }



        }




        public void ShowBeakForm()
        {

            //documentViewer1.DocumentSource = report;
            //flyoutPanel1.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Left;
            //Cursor = new Cursor(Cursor.Current.Handle);
            //Cursor.Position = new Point(Cursor.Position.X + 40, Cursor.Position.Y);
            //flyoutPanel1.ShowBeakForm(Cursor.Position);
            //Cursor.Position = new Point(Cursor.Position.X - 40, Cursor.Position.Y);

        }


    }
}
