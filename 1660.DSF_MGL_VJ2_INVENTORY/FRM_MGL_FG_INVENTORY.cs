using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGauges.Core.Model;
using DevExpress.XtraCharts;
using System.Data.OracleClient;

namespace FORM
{
    public partial class FRM_MGL_FG_INVENTORY : Form
    {
        public FRM_MGL_FG_INVENTORY()
        {
            InitializeComponent();
        }
       
        string Mline, Line,Lang;
        Color Row_Default = Color.White;
        Color Row_Extend = Color.FromArgb(244, 248, 255);
       // init strinit = new init();
       
      
        private static readonly object syncLock = new object();
        private static readonly Random getrandom = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }


        public DataTable SEL_FG_INV_MONTHLY_CHART(string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_MGL_VJ2.MGL_FG_INV";

                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[1] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[1] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[2] = "";


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

        public DataTable SEL_FG_INV_DAILY_INCOM_CHART(string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_MGL_VJ2.MGL_FG_INCOMING";

                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[1] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;
                switch (ARG_LINE_CD)
                {
                    case "001":
                    case "002":
                    case "003":
                    case "004":
                    case "005":
                    case "006":
                        ARG_LINE_CD = "000";
                        break;
                }

                MyOraDB.Parameter_Values[0] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[1] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[2] = "";


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

        public DataTable SEL_FG_DAYS_INV(string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_MGL_VJ2.MGL_FG_DAYS_INV";

                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[1] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[1] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[2] = "";


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

        public DataTable SEL_FG_BY_MODEL(string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_PHUOC.SP_SMT_FG_BY_MODEL";

                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[1] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[1] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[2] = "";


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

        private DataTable SEL_DATA(string ARG_LINE)
        {
            try
            {
                System.Data.DataSet retDS;
                COM.OraDB MyOraDB = new COM.OraDB();

                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = "MES.PKG_MGL_VJ2.MGL_DELIVERY_TRACKING";

                switch ( ARG_LINE)
                {
                    case "001":
                    case "002":
                    case "003":
                    case "004":
                    case "005":
                    case "006":
                        ARG_LINE = "000";
                        break;
                }

                MyOraDB.Parameter_Name[0] = "V_P_LINE";
                MyOraDB.Parameter_Name[1] = "CV_1";


                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_LINE;
                MyOraDB.Parameter_Values[1] = "";

                MyOraDB.Add_Select_Parameter(true);

                retDS = MyOraDB.Exe_Select_Procedure();

                if (retDS == null) return null;

                return retDS.Tables[MyOraDB.Process_Name];
            }
            catch 
            { return null; }
        }


        private void CreateDailyChart()
        {
            //Reset Chart beforce biding Data
            Dailychart.Series.Clear();
            Dailychart.Titles.Clear();




            // Create an empty chart. (No need).
            Dailychart.AppearanceNameSerializable = "Slipstream";
            //create New object
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();
            DevExpress.XtraCharts.PowerEasingFunction powerEasingFunction1 = new DevExpress.XtraCharts.PowerEasingFunction();

            // Create the first side-by-side bar series and add points to it.
            Series series1 = new Series("Inv", ViewType.Bar);
            // Create the second side-by-side bar series and add points to it.
            Series series2 = new Series("Amount", ViewType.Line);

            DataTable dt = SEL_FG_INV_MONTHLY_CHART(Line, Mline);
            try
            {
                string YM = null;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        YM = dt.Rows[i]["YM"].ToString();

                        series1.Points.Add(new SeriesPoint(YM, dt.Rows[i]["INV"]));
                        series2.Points.Add(new SeriesPoint(YM, dt.Rows[i]["AMT"]));
                    }
                }
                series1.ArgumentScaleType = ScaleType.Qualitative;
                series2.ArgumentScaleType = ScaleType.Qualitative;
                //for (int i = 0; i <= 30; i++)
                //{
                //    series1.Points.Add(new SeriesPoint(i.ToString(), GetRandomNumber(10, 1000)));
                //    series2.Points.Add(new SeriesPoint(i.ToString(), GetRandomNumber(1000, 10000)));
                //}


                //marker
                lineSeriesView1.LineMarkerOptions.Color = System.Drawing.Color.Gold;
                lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                series2.View = lineSeriesView1;
                // Add the series to the chart.

                Dailychart.SeriesSerializable = new Series[] { series1, series2 };
                //Dailychart.Series.Add(series1);
                //Dailychart.Series.Add(series2);
                // Create two secondary axes, and add them to the chart's Diagram.
                SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");
                ((XYDiagram)Dailychart.Diagram).SecondaryAxesY.Clear();
                ((XYDiagram)Dailychart.Diagram).SecondaryAxesY.Add(myAxisY);
                myAxisY.Label.TextPattern = "{V:#,#}";
                myAxisY.Title.TextColor = System.Drawing.Color.OrangeRed;
                myAxisY.Title.Font = new Font("Calibri", 16, FontStyle.Italic);
                myAxisY.Title.Text = "Money";
                myAxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
                // myAxisY.Label.Font = new System.Drawing.Font("Calibri", 12F);

                ((LineSeriesView)series2.View).AxisY = myAxisY;


                // Hide the legend (if necessary).
                Dailychart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

                // Rotate the diagram (if necessary).
                ((XYDiagram)Dailychart.Diagram).Rotated = false;

                //ScaleBreak NUmber
                ((XYDiagram)Dailychart.Diagram).AxisX.NumericScaleOptions.AutoGrid = false;

                //Title
                ((XYDiagram)Dailychart.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                ((XYDiagram)Dailychart.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                ((XYDiagram)Dailychart.Diagram).AxisX.Title.Text = "Monthly";
                ((XYDiagram)Dailychart.Diagram).AxisY.Title.Text = "Inventory (Prs)";

                //Animation Series
                lineSeriesView1.Color = System.Drawing.Color.DeepPink;
                xySeriesUnwindAnimation1.EasingFunction = powerEasingFunction1;
                lineSeriesView1.SeriesAnimation = xySeriesUnwindAnimation1;


                ((XYDiagram)Dailychart.Diagram).AxisY.Label.TextPattern = "{V:#,#}";
                //Label
                series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                series1.Label.TextPattern = "{V:#,#}";
                (series1.Label as SideBySideBarSeriesLabel).Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Center;
                series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                series2.Label.TextPattern = "{V:#,#}";
                // Add a title to the chart (if necessary).
                Dailychart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

                ChartTitle chartTitle1 = new ChartTitle();
                chartTitle1.Text = "Inventory";
                Dailychart.Titles.Add(chartTitle1);

                // Add the chart to the form.
                Dailychart.Dock = DockStyle.Fill;
                splMainV.Panel1.Controls.Add(Dailychart);
            }
            catch
            { }
        }

        //Grid
        private void ClearData()
        {
            for (int irow = 2; irow <= axfpView.MaxRows; irow++)
            {
                for (int icol = 3; icol <= axfpView.MaxCols; icol++)
                {
                    axfpView.SetText(icol, irow, "");
                    axfpView.Row = irow;
                    axfpView.Col = icol;
                    switch (irow % 2)
                    {
                        case 0:
                            axfpView.BackColor = Row_Default;
                            break;
                        case 1:
                            axfpView.BackColor = Row_Default;
                            break;
                    }
                }
            }
        }

        private string GetText(AxFPUSpreadADO.AxfpSpread spread, int col, int row)
        {
            try
            {
                object data = null;
                spread.GetText(col, row, ref data);
                return data.ToString();
            }
            catch
            {

                return null;
            }

        }
        private void BindDingData(DataTable dt)
        {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    axfpView.MaxRows = 1;
                    axfpView.MaxRows = dt.Rows.Count + 1;

                   // ClearData();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        axfpView.Row = i + 2;
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            axfpView.Col = j + 1;
                            switch (j + 1)
                            {
                                case 1:
                                  //  axfpView.TypeHAlign = FPSpreadADO.TypeHAlignConstants.TypeHAlignLeft;

                                    break;
                                case 7:
                                case 8:
                                  //  axfpView.TypeHAlign = FPSpreadADO.TypeHAlignConstants.TypeHAlignRight;
                                   // axfpView.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber;
                                  //  axfpView.TypeNumberDecPlaces = 0;
                                    axfpView.TypeNumberShowSep = true;
                                    break;
                                case 9:
                                    if (Convert.ToInt32(dt.Rows[i][j]) != 0)
                                    {
                                        axfpView.BackColor = Color.Red;
                                        axfpView.ForeColor = Color.White;
                                    }
                                    else
                                        axfpView.ForeColor = Color.Black;

                                  //  axfpView.TypeHAlign = FPSpreadADO.TypeHAlignConstants.TypeHAlignRight;
                                  //  axfpView.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber;
                                    axfpView.TypeNumberDecPlaces = 0;
                                    axfpView.TypeNumberShowSep = true;
                                    break;
                                default:
                                  //  axfpView.TypeHAlign = FPSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                                    break;
                            }

                            axfpView.SetText(j + 1, i + 2, dt.Rows[i][j].ToString());




                           // axfpView.Font = new Font("Calibri", 11, FontStyle.Bold);
                          //  axfpView.TypeVAlign = FPSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                           // axfpView.set_RowHeight(i + 2, 20);
                        }

                    }
                    CreateGridSpan();




                }
            }
            catch
            { }
        }

        private void CreateGridSpan()
        {
            try
            {

                for (int i = 0; i <= 2; i++)
                {
                    axfpView.Col = i;
                    axfpView.ColMerge = FPSpreadADO.MergeConstants.MergeAlways;
                }


            }
            catch 
            { }
        }

        private void BindingGauges()
        {
            DataTable dt = SEL_FG_DAYS_INV(Line, Mline);
            arcScaleGauges.EnableAnimation = false;
            arcScaleGauges.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseIn;
            arcScaleGauges.EasingFunction = new BackEase();
            arcScaleGauges.MinValue = 0;
            arcScaleGauges.MaxValue = Convert.ToInt32(dt.Rows[0]["DAYS"]) + 2;
            //arcScaleGauges.Ranges[0].EndValue = arcScaleGauges.Ranges[1].StartValue = Convert.ToSingle(10);
            //arcScaleGauges.Ranges[1].EndValue = arcScaleGauges.Ranges[2].StartValue = Convert.ToSingle(15);
            //arcScaleGauges.Ranges[2].EndValue = Convert.ToSingle(20);
            arcScaleGauges.Value = 0;
            labelGauges.Text = "0";
            //if (dt != null && dt.Rows.Count > 0)
            //{
            try
            {

                arcScaleGauges.MinValue = 0;
                arcScaleGauges.MaxValue = Convert.ToInt32(dt.Rows[0]["DAYS"]) + 2;
                //arcScaleGauges.Ranges[0].EndValue = arcScaleGauges.Ranges[1].StartValue = Convert.ToSingle(Convert.ToSingle(dt.Rows[0][0]) - 2);
                //arcScaleGauges.Ranges[1].EndValue = arcScaleGauges.Ranges[2].StartValue = Convert.ToSingle(Convert.ToSingle(dt.Rows[0][0]) + 2);
                //arcScaleGauges.Ranges[2].EndValue = Convert.ToSingle(Convert.ToSingle(dt.Rows[0][0]) + 5);

                arcScaleGauges.EnableAnimation = true;
                arcScaleGauges.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                arcScaleGauges.EasingFunction = new BackEase();
                double num = Convert.ToDouble(dt.Rows[0]["DAYS"]); //Convert.ToDouble(GetRandomNumber(20, 999));
                arcScaleGauges.Value = (float)num;
                labelGauges.Text = num.ToString();
                lblTar.Text = dt.Rows[0]["TARGET"].ToString();
                lblProd.Text = dt.Rows[0]["PROD_QTY"].ToString();
            }
            catch
            { }
            // }
        }



        private void CreateModelChart()
        {
            //Reset Chart beforce biding Data
            Modelchart.Series.Clear();
            Modelchart.Titles.Clear();
            // Create an empty chart. (No need).
            Modelchart.AppearanceNameSerializable = "Slipstream";
            //create New object
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();
            DevExpress.XtraCharts.PowerEasingFunction powerEasingFunction1 = new DevExpress.XtraCharts.PowerEasingFunction();

            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();


            // Create the first side-by-side bar series and add points to it.
            Series series1 = new Series("Inv", ViewType.Bar);
            Series series2 = new Series("CTN", ViewType.Bar);
            // Create the second side-by-side bar series and add points to it.

            DataTable dt = SEL_FG_INV_DAILY_INCOM_CHART(Line, Mline);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    series1.Points.Add(new SeriesPoint(dt.Rows[i]["YMD"].ToString(), dt.Rows[i]["CTN"]));
                    series2.Points.Add(new SeriesPoint(dt.Rows[i]["YMD"].ToString(), dt.Rows[i]["PRS"]));
                }
            }
            series1.ArgumentScaleType = ScaleType.Qualitative;
            series2.ArgumentScaleType = ScaleType.Qualitative;
            //for (int i = 0; i <= 30; i++)
            //{
            //    series1.Points.Add(new SeriesPoint(i.ToString(), GetRandomNumber(10, 1000)));

            //}
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView2 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            (series1.Label as SideBySideBarSeriesLabel).Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;
            (series2.Label as SideBySideBarSeriesLabel).Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;
            sideBySideBarSeriesView1.ColorEach = false;
            sideBySideBarSeriesView2.ColorEach = false;
            sideBySideBarSeriesView1.Color = Color.SeaGreen; sideBySideBarSeriesView2.Color = Color.HotPink;
            series1.View = sideBySideBarSeriesView1;
            series2.View = sideBySideBarSeriesView2;
            //marker
            lineSeriesView1.LineMarkerOptions.Color = System.Drawing.Color.Gold;
            lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;



            lineSeriesView2.LineMarkerOptions.Color = System.Drawing.Color.Gold;
            lineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            // Add the series to the chart.

            Modelchart.SeriesSerializable = new Series[] { series1 };
            //Dailychart.Series.Add(series1);
            //Dailychart.Series.Add(series2);
            ((XYDiagram)Modelchart.Diagram).AxisX.Title.Text = "Date";
            ((XYDiagram)Modelchart.Diagram).AxisY.Title.Text = "Qty (Prs)";




            // Rotate the diagram (if necessary).
            ((XYDiagram)Modelchart.Diagram).Rotated = false;

            //ScaleBreak NUmber
            ((XYDiagram)Modelchart.Diagram).AxisX.NumericScaleOptions.AutoGrid = false;

            //Title
            ((XYDiagram)Modelchart.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram)Modelchart.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

            //legend
            Modelchart.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.RightOutside;
            Modelchart.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            Modelchart.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBoxAndMarker;
            Modelchart.Legend.Name = "Default Legend";
            Modelchart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

            ((XYDiagram)Dailychart.Diagram).AxisY.Label.TextPattern = "{V:#,#}";
            //Label
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Label.TextPattern = "{V:#,#}";
            (series1.Label as SideBySideBarSeriesLabel).Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;

            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Label.TextPattern = "{V:#,#}";
            (series2.Label as SideBySideBarSeriesLabel).Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;

            ((XYDiagram)Modelchart.Diagram).AxisY.Label.TextPattern = "{V:#,#}";

            // Add a title to the chart (if necessary).
            ChartTitle chartTitle1 = new ChartTitle();
            chartTitle1.Text = "Daily Incoming Status";
            Modelchart.Titles.Add(chartTitle1);

            // Add the chart to the form.
            Modelchart.Dock = DockStyle.Fill;
            splitChart_Detail.Panel1.Controls.Add(Modelchart);
        }




        private void CreateByModelChart()
        {
            //Reset Chart beforce biding Data
            ChartByModel.Series.Clear();
            ChartByModel.Titles.Clear();
            // Create an empty chart. (No need).
            ChartByModel.AppearanceNameSerializable = "Slipstream";
            //create New object
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();
            DevExpress.XtraCharts.PowerEasingFunction powerEasingFunction1 = new DevExpress.XtraCharts.PowerEasingFunction();
            DevExpress.XtraCharts.BarSlideAnimation barSlideAnimation1 = new DevExpress.XtraCharts.BarSlideAnimation();

            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();


            // Create the first side-by-side bar series and add points to it.
            Series series1 = new Series("Inv", ViewType.Bar);
            Series series2 = new Series("%", ViewType.Line);
            // Create the second side-by-side bar series and add points to it.

            DataTable dt = SEL_FG_BY_MODEL(Line, Mline);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    series1.Points.Add(new SeriesPoint(dt.Rows[i]["MODEL_NAME"].ToString(), dt.Rows[i]["INV"]));
                    series2.Points.Add(new SeriesPoint(dt.Rows[i]["MODEL_NAME"].ToString(), dt.Rows[i]["PAR"]));
                }
            }
            series1.ArgumentScaleType = ScaleType.Qualitative;
            series2.ArgumentScaleType = ScaleType.Qualitative;
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();

            (series1.Label as SideBySideBarSeriesLabel).Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;

            sideBySideBarSeriesView1.ColorEach = false;
            sideBySideBarSeriesView1.Animation = barSlideAnimation1;
            sideBySideBarSeriesView1.Color = Color.DarkOrange;
            series1.View = sideBySideBarSeriesView1;

            //marker
            lineSeriesView1.LineMarkerOptions.Color = System.Drawing.Color.Gold;
            lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;

            //fORMAT LINE
            lineSeriesView1.Color = Color.DeepPink;

            series2.View = lineSeriesView1;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            lineSeriesView2.LineMarkerOptions.Color = System.Drawing.Color.Gold;
            lineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            // Add the series to the chart.

            ChartByModel.SeriesSerializable = new Series[] { series1, series2 };
            //Dailychart.Series.Add(series1);
            //Dailychart.Series.Add(series2);

            // Create two secondary axes, and add them to the chart's Diagram.
            SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");
            ((XYDiagram)ChartByModel.Diagram).SecondaryAxesY.Clear();
            ((XYDiagram)ChartByModel.Diagram).SecondaryAxesY.Add(myAxisY);
            myAxisY.Label.TextPattern = "{V:#,#}";
            myAxisY.Title.TextColor = System.Drawing.Color.OrangeRed;
            myAxisY.Title.Font = new Font("Calibri", 16, FontStyle.Regular);
            myAxisY.Title.Text = "%";
            myAxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            // myAxisY.Label.Font = new System.Drawing.Font("Calibri", 12F);

            ((LineSeriesView)series2.View).AxisY = myAxisY;


            ((XYDiagram)ChartByModel.Diagram).AxisX.Title.Text = "Model";
            ((XYDiagram)ChartByModel.Diagram).AxisY.Title.Text = "Inv (Prs)";




            // Rotate the diagram (if necessary).
            ((XYDiagram)ChartByModel.Diagram).Rotated = false;

            //ScaleBreak NUmber
            ((XYDiagram)ChartByModel.Diagram).AxisX.NumericScaleOptions.AutoGrid = false;

            //Title
            ((XYDiagram)ChartByModel.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram)ChartByModel.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

            //legend
            ChartByModel.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.RightOutside;
            ChartByModel.Legend.Direction = DevExpress.XtraCharts.LegendDirection.TopToBottom;
            ChartByModel.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBoxAndMarker;
            ChartByModel.Legend.Name = "Default Legend";
            ChartByModel.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

            ((XYDiagram)Dailychart.Diagram).AxisY.Label.TextPattern = "{V:#,#}";
            //Label
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Label.TextPattern = "{V:#,#}";
            series2.Label.TextPattern = "{V}" + "%";
            (series1.Label as SideBySideBarSeriesLabel).Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;

            ((XYDiagram)ChartByModel.Diagram).AxisY.Label.TextPattern = "{V:#,#}";

            // Add a title to the chart (if necessary).
            ChartTitle chartTitle1 = new ChartTitle();
            chartTitle1.Text = "Inventory by Model";
            ChartByModel.Titles.Add(chartTitle1);

            // Add the chart to the form.
            ChartByModel.Dock = DockStyle.Fill;
            splitChart_Detail.Panel1.Controls.Add(ChartByModel);
        }

        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }


        private void FRM_SMT_FG_INV_V1_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
           // ClassLib.ComCtl.Form_Maximized(this, indexScreen); //2 man hinh tro len
            GoFullscreen();
            SetConfigForm();
            
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            CreateDailyChart();
            BindingGauges();

            CreateModelChart();
            // CreateByModelChart();
        }

        int cCount;
        private void tmrDate_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cCount++;
            if (cCount >= 30)
            {
                CreateDailyChart();
                BindingGauges();
                CreateModelChart();
                BindDingData(SEL_DATA(Line));
                //   CreateByModelChart();
                cCount = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Modelchart_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
        {
            try
            {
                if (e.Item.Axis is AxisX)
                {
                    e.Item.Text = e.Item.Text.Replace("_", "\n");
                }
            }
            catch
            {

            }
        }

        private void FRM_SMT_FG_INV_V1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                lblTitle.Text = ComVar.Var._strValue1.Equals("TOTAL2") ? "VJ2 FG Inventory Status" : ComVar.Var._strValue2 + " FG Inventory Status";
                cmdBack.Tag = ComVar.Var._Frm_Back;
                initForm();
                cCount = 29;
                
                tmrDate.Start();
                tmr_Blinking.Start();
            }
            else
            {
                tmr_Blinking.Stop();
                tmrDate.Stop();
            }
        }

        

        private void tmr_Blinking_Tick(object sender, EventArgs e)
        {

            axfpView.Col = 9;
            for (int ir = 1; ir <= axfpView.MaxRows; ir++)
            {
                axfpView.Row = ir;
                if (axfpView.BackColor == Color.Red)
                {
                    axfpView.BackColor = Color.WhiteSmoke;
                    axfpView.ForeColor = Color.Red;
                }
                else if (axfpView.BackColor == Color.WhiteSmoke)
                {
                    axfpView.BackColor = Color.Red;
                    axfpView.ForeColor = Color.White;
                }
            }

        }

        private void initForm()
        {
            Line = ComVar.Var._strValue1;
            Mline = ComVar.Var._strValue2;
            Lang = ComVar.Var._strValue3;
            //if (ComVar.Var._strValue1 == "Vn")
            //    lblTitle.Text = "Tồn thành phẩm";
            //else
            //    lblTitle.Text = "FG Inventory";
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void menu_Click(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            ComVar.Var.callForm = cnt.Tag == null ? "" : cnt.Tag.ToString();
        }

        #region  Get Config Data From Database
        /// <summary>
        /// Declare _dtnInit
        /// Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        /// </summary>
        private void SetConfigForm()
        {
            try
            {
                System.Collections.Generic.Dictionary<string, string> dtnInit = new System.Collections.Generic.Dictionary<string, string>();
                dtnInit = ComVar.Func.getInitForm(ComVar.Var._Area + this.GetType().Assembly.GetName().Name, this.GetType().Name);
                if (dtnInit == null) return;
                for (int i = 0; i < dtnInit.Count; i++)
                {
                    SetComValue(dtnInit.ElementAt(i).Key, dtnInit.ElementAt(i).Value);
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setConfigForm-->Err:    " + ex.ToString());
            }
        }

        private void SetComValue(string obj, string obj_value)
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
