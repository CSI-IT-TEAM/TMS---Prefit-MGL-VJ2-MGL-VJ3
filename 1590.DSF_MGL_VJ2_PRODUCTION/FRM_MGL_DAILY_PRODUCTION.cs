using DevExpress.Utils;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM
{
    public partial class FRM_MGL_DAILY_PRODUCTION : Form
    {
        public FRM_MGL_DAILY_PRODUCTION()
        {
            InitializeComponent();
        }
        Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        UC.UC_DWMY uc = new UC.UC_DWMY(1, "");//Hiển thị 4 Button, Button Day thì Disable
        DataTable dt = null;
        #region Database
        private DataTable SP_MGL_PRODUCTION_DATA_SELECT(string V_P_TYPE, string V_P_LINE, string V_P_MLINE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_MGL_VJ2.MGL_PRODUCTION_DAILY";
                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE";
                MyOraDB.Parameter_Name[2] = "ARG_MLINE";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";
                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = V_P_TYPE;
                MyOraDB.Parameter_Values[1] = V_P_LINE;
                MyOraDB.Parameter_Values[2] = V_P_MLINE;
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

        private void FRM_MGL_DAILY_PRODUCTION_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            _dtnInit = ComVar.Func.getInitForm(this.GetType().Assembly.GetName().Name, this.GetType().Name);
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
                    ComVar.Var.callForm = "1640";
                    break;
                case "W":
                    ComVar.Var.callForm = "1641";
                    break;
                case "M":
                    ComVar.Var.callForm = "1642";
                    break;
                case "Y":
                    ComVar.Var.callForm = "1643";
                    break;
            }
        }

        private void FRM_MGL_DAILY_PRODUCTION_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    lbltitle.Text = ComVar.Var._strValue1.Equals("TOTAL1") ? "VJ1 Support Production Status by Day" : ComVar.Var._strValue2 + " Production Status by Day";
                    cCount = 60;
                    uc.YMD_Change(1, "");                    
                    tmr.Start();
                }
                else
                    tmr.Stop();
            }
            catch (Exception ex)
            {
                
                throw;
            }
            
        }
        int cCount = 0;
        private void tmr_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cCount >= 60)
            {
                cCount = 0;
                BindingData4Grid();
                
            }

        }

        private void BindingData4Grid()
        {
            try
            {
                dt = SP_MGL_PRODUCTION_DATA_SELECT("Q", ComVar.Var._strValue1,"");

                int iCurent = 0;
                int iNumberOfLine = 0;
                if (dt.Rows.Count > 0)
                {
                    iCurent = Convert.ToInt32(dt.Rows[0]["ITIME"].ToString());
                    iNumberOfLine = Convert.ToInt32(dt.Rows[0]["NUMBER_ROWS"].ToString());
                    iCurent = iCurent * iNumberOfLine;// Convert.ToString((Convert.ToInt32(iCurent) - 1) * iNumberOfLine);
                   
                }
                grdBase.DataSource = dt;
                for (int i = 0; i < bdgrdView.Columns.Count; i++)
                {
                    bdgrdView.Columns[i].OptionsColumn.ReadOnly = true;
                    bdgrdView.Columns[i].OptionsColumn.AllowEdit = false;
                    bdgrdView.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 18f, FontStyle.Regular);
                    bdgrdView.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    bdgrdView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    if (bdgrdView.Columns[i].FieldName.Contains("TAR") || bdgrdView.Columns[i].FieldName.Contains("ACT") || bdgrdView.Columns[i].FieldName.Contains("RATE"))
                    {
                        bdgrdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        bdgrdView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        bdgrdView.Columns[i].DisplayFormat.FormatString = "#,#";
                        bdgrdView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    }
                }
                bdgrdView.Columns["HMS"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                bdgrdView.TopRowIndex = iCurent - 8; //Math.Max(Convert.ToInt32(iCurent) - 4 + 2 + iNumberOfLine, 3);
                BindingChart();
            }
            catch
            {
            }
        }

        private void BindingChart()
        {
            //InitChart("UPC", dt, chart1); InitChart("UPS1", dt, chart2); InitChart("UPS2", dt, chart3); InitChart("UPS3", dt, chart4);
            if (ComVar.Var._strValue1 == "TOTAL2")
            {
                //chartControl3.Visible = true;
                CreateChart(ComVar.Var._strValue1, "201", "FGA", chart3, "LD");
                CreateChart(ComVar.Var._strValue1, "202", "FGA", chart4, "LE");
                tableLayoutPanel1.RowStyles[0].Height = 0;
                tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Percent;
            }
            else
            {
                tableLayoutPanel1.RowStyles[0].Height = 50F;
                tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Percent;
                CreateChart(ComVar.Var._strValue1, "001", "FGA", chart1, "Line 1");
                CreateChart(ComVar.Var._strValue1, "002", "FGA", chart2, "Line 2");
                CreateChart(ComVar.Var._strValue1, "003", "FGA", chart3, "Line 3");
                CreateChart(ComVar.Var._strValue1, "004", "FGA", chart4, "Line 4");
            }
            string Now = DateTime.Now.ToString("yyyyMMdd");
            DataTable dt = SP_MGL_PRODUCTION_DATA_SELECT("Q3", ComVar.Var._strValue1, ComVar.Var._strValue1);
            double num = 0; double iMin = 0; double iMax = 100; double iRangeMin = 95; double iRangeMax = 98;
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["RATE"].ToString() != "")
            {
                num = Convert.ToDouble(dt.Rows[0]["RATE"].ToString());
                if (num > 3)
                {
                    if (num < 92)
                    {
                        iMin = Math.Round(num, 0) - 3;
                        //iMax = 98;
                    }
                    else
                    {
                        iMin = 92;
                        //iMax = Math.Round(num, 0) + 3;
                    }
                    if (num > 101)
                    {
                        iMax = Math.Round(num, 0) + 3;

                    }
                    else
                    {
                        iMax = 101;
                    }
                }
                else
                {
                    iMin = 0;
                    iMax = 100;
                }
                //iMax = Math.Round(num,0) + 3;
                iRangeMin = 95;
                iRangeMax = 98;
                lblRPlan.Text = "R.Plan: " + Convert.ToDouble(dt.Rows[0]["TARGET"].ToString()).ToString("#,###") + "Prs";
                lblProd.Text = "Prod  : " + Convert.ToDouble(dt.Rows[0]["QTY"].ToString()).ToString("#,###") + "Prs";
                lblRate.Text = "Rate  : " + Convert.ToDouble(dt.Rows[0]["RATE"].ToString()).ToString("#,###.##") + "%";
                if (Convert.ToDouble(dt.Rows[0]["RATE"].ToString()) > 98)
                {
                    lblRate.BackColor = Color.Green;
                    lblRate.ForeColor = Color.White;

                }
                else if (Convert.ToDouble(dt.Rows[0]["RATE"].ToString()) > 95)
                {
                    lblRate.BackColor = Color.Yellow;
                    lblRate.ForeColor = Color.Black;
                }
                else
                {
                    lblRate.BackColor = Color.Red;
                    lblRate.ForeColor = Color.White;
                }

            }
            BindingGauges(circularRealTime, num, iMin, iMax, iRangeMin, iRangeMax);
        }

        private void CreateChart(string line_cd, string mline_cd, string op_cd, DevExpress.XtraCharts.ChartControl _chartControl, string _title)
        {
            // Create a new chart.
            _chartControl.Series.Clear();
            //DataSource
            DataTable dt = SP_MGL_PRODUCTION_DATA_SELECT("Q2", line_cd, mline_cd);
            string Now = DateTime.Now.ToString("yyyyMMdd");

            // Create two series.
            Series series1 = new Series("Target Qty", ViewType.Line);
            Series series2 = new Series("Prod. Qty", ViewType.Spline);

            DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView2 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.BarWidenAnimation barWidenAnimation1 = new DevExpress.XtraCharts.BarWidenAnimation();
            DevExpress.XtraCharts.ElasticEasingFunction elasticEasingFunction1 = new DevExpress.XtraCharts.ElasticEasingFunction();


            DevExpress.XtraCharts.XYSeriesBlowUpAnimation xySeriesBlowUpAnimation2 = new DevExpress.XtraCharts.XYSeriesBlowUpAnimation();
            DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation2 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();
            DevExpress.XtraCharts.XYSeriesUnwrapAnimation xySeriesUnwrapAnimation2 = new DevExpress.XtraCharts.XYSeriesUnwrapAnimation();

            DevExpress.XtraCharts.PowerEasingFunction powerEasingFunction2 = new DevExpress.XtraCharts.PowerEasingFunction();
            DevExpress.XtraCharts.SineEasingFunction sineEasingFunction2 = new DevExpress.XtraCharts.SineEasingFunction();
            // Add points to them, with their arguments different.
            if (dt != null && dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    series1.Points.Add(new SeriesPoint(dt.Rows[i]["HMS"].ToString(), dt.Rows[i]["TARGET"])); //GetRandomNumber(10, 50)
                    series2.Points.Add(new SeriesPoint(dt.Rows[i]["HMS"].ToString(), dt.Rows[i]["QTY"])); //dt.Rows[i]["HMS"]
                }
                //_chartControl1.Series[0].ArgumentScaleType = ScaleType.Qualitative;
            }
            else
            {
                for (int i = 1; i < 9; i++)
                {
                    //series1.Points.Add(new SeriesPoint(dt.Rows[i]["HMS"].ToString(), dt.Rows[i]["QTY"])); //GetRandomNumber(10, 50)
                    series1.Points.Add(new SeriesPoint(i + "H", 0));
                    series2.Points.Add(new SeriesPoint(i + "H", 0)); //dt.Rows[i]["HMS"]
                }
            }

            _chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1, series2 };
            ((XYDiagram)_chartControl.Diagram).AxisY.Title.Text = "Product Qty (Prs)";
            ((XYDiagram)_chartControl.Diagram).AxisY.Label.TextPattern = "{V:#,#}";
            ((XYDiagram)_chartControl.Diagram).AxisY.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            ((XYDiagram)_chartControl.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            ((XYDiagram)_chartControl.Diagram).AxisX.Title.Text = "Hour";
            ((XYDiagram)_chartControl.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            ((XYDiagram)_chartControl.Diagram).AxisX.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            _chartControl.Titles[0].Text = _title;
            

            splineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            splineSeriesView1.Shadow.Visible = false;
            splineSeriesView1.Color = System.Drawing.Color.Green;
            splineSeriesView1.LineMarkerOptions.BorderColor = System.Drawing.Color.DodgerBlue;
            splineSeriesView1.LineMarkerOptions.BorderVisible = false;

            splineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            splineSeriesView2.Shadow.Visible = false;
            splineSeriesView2.Color = System.Drawing.Color.DodgerBlue;
            splineSeriesView2.LineMarkerOptions.BorderColor = System.Drawing.Color.DodgerBlue;
            splineSeriesView2.LineMarkerOptions.BorderVisible = false;

            //splineSeriesView1.LineMarkerOptions.Color = System.Drawing.Color.Red;
            splineSeriesView2.LineMarkerOptions.Kind = DevExpress.XtraCharts.MarkerKind.Circle;
            splineSeriesView2.LineMarkerOptions.Color = System.Drawing.Color.DodgerBlue;
            splineSeriesView2.LineMarkerOptions.Size = 15;
            splineSeriesView2.LineStyle.Thickness = 3;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //pointSeriesLabel1.TextPattern = "{V:#,#}";

            series1.View = splineSeriesView1;

            series2.Label.TextPattern = "{V:#,#}";
            series2.View = splineSeriesView2;
            xySeriesUnwindAnimation2.EasingFunction = sineEasingFunction2; //powerEasingFunction1;
            splineSeriesView2.SeriesAnimation = xySeriesUnwindAnimation2;//xySeriesBlowUpAnimation1;//xySeriesUnwindAnimation1; // xySeriesUnwrapAnimation1;
            ((XYDiagram)_chartControl.Diagram).AxisX.VisualRange.Auto = true;
            ((XYDiagram)_chartControl.Diagram).AxisX.VisualRange.AutoSideMargins = false;
            ((XYDiagram)_chartControl.Diagram).AxisX.VisualRange.SideMarginsValue = 2;
            ((XYDiagram)_chartControl.Diagram).AxisX.Label.Angle = 0;
            ((XYDiagram)_chartControl.Diagram).AxisX.Label.Font = new System.Drawing.Font("Calibri", 12, System.Drawing.FontStyle.Bold);
            ((XYDiagram)_chartControl.Diagram).AxisX.NumericScaleOptions.ScaleMode = DevExpress.XtraCharts.ScaleMode.Automatic;
            ((XYDiagram)_chartControl.Diagram).AxisY.Label.Font = new System.Drawing.Font("Calibri", 12, System.Drawing.FontStyle.Bold);

            ((XYDiagram)_chartControl.Diagram).AxisX.Title.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((XYDiagram)_chartControl.Diagram).AxisY.Title.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((XYDiagram)_chartControl.Diagram).AxisY.Title.TextColor = Color.DarkOrange;
            ((XYDiagram)_chartControl.Diagram).AxisX.Title.TextColor = Color.DarkOrange;
        }

        private void BindingGauges(DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge circularGauge, double num, double iMin, double iMax, double iRangeMin, double iRangeMax)
        {

            if (circularGauge.Scales.Count <= 0)
            {
                return;
            }
            circularGauge.Scales[0].EnableAnimation = false;

            circularGauge.Scales[0].MinValue = (int)iMin;
            circularGauge.Scales[0].MaxValue = (int)iMax;

            circularGauge.Scales[0].Value = 0;

            if (circularGauge.Scales[0].Ranges.Count >= 3)
            {
                circularGauge.Scales[0].Ranges[0].StartValue = (float)iMin;
                circularGauge.Scales[0].Ranges[0].EndValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].StartValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].EndValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].StartValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].EndValue = (float)iMax;

            }

            try
            {

                circularGauge.Scales[0].MinValue = (int)iMin;
                circularGauge.Scales[0].MaxValue = (int)iMax;


                circularGauge.Scales[0].EnableAnimation = true;
                circularGauge.Scales[0].EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;



                circularGauge.Scales[0].Value = (float)num;


            }
            catch (Exception ex)
            { }
            // }
        }

        private void InitChart(string sChart, DataTable dt, DevExpress.XtraCharts.ChartControl chartControl)
        {
            try
            {
                var sTitle = new List<string>();
                DevExpress.XtraCharts.ChartTitle chartTitle = new DevExpress.XtraCharts.ChartTitle();
                chartControl.DataSource = dt.Select("HMS <>'TOTAL'").CopyToDataTable();
                chartControl.Series[1].ArgumentDataMember = "HMS";
                chartControl.Series[1].ValueDataMembers.AddRange(new string[] { sChart + "_TAR" });
                chartControl.Series[0].ArgumentDataMember = "HMS";
                chartControl.Series[0].ValueDataMembers.AddRange(new string[] { sChart + "_ACT" });
                chartTitle.Text = sTitle[Convert.ToInt32(sChart.Substring(3, 1)) - 1];
                chartControl.Titles.Clear();
                chartControl.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle });
                ((DevExpress.XtraCharts.XYDiagram)chartControl.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
            }
            catch { }
        }

        private void bdgrdView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {


                if (bdgrdView.GetRowCellValue(e.RowHandle, "HMS").ToString().Contains("CURR"))
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.ForeColor = Color.Black;
                }

                if (e.Column.FieldName.Contains("RATE"))
                {
                    if (e.CellValue.ToString().Contains("G"))
                    {
                        e.Appearance.BackColor = Color.Green;
                        e.Appearance.ForeColor = Color.Black;
                    }
                    else if (e.CellValue.ToString().Contains("R"))
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else if (e.CellValue.ToString().Contains("Y"))
                    {
                        e.Appearance.BackColor = Color.Yellow;
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
                if (bdgrdView.GetRowCellValue(e.RowHandle, "MLINE_CD").ToString().Contains("TOTAL"))
                {
                    e.Appearance.BackColor = Color.Orange;
                    e.Appearance.ForeColor = Color.Black;
                }
                if (bdgrdView.GetRowCellValue(e.RowHandle, "HMS").ToString().Contains("TOTAL"))
                {
                    e.Appearance.BackColor = Color.LightCyan;
                    e.Appearance.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            { }
        }

    }
}
