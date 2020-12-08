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
using DevExpress.XtraGauges.Core.Model;

namespace FORM
{
    public partial class FRM_MGL_WEEKLY_PRODUCTION : Form
    {
        public FRM_MGL_WEEKLY_PRODUCTION()
        {
            InitializeComponent();
        }
        int indexScreen;
        string line, mline;
        Form[] arrForm = new Form[3];
        Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        UC.UC_DWMY uc = new UC.UC_DWMY(2, "");//Hiển thị 4 Button, Button Day thì Disable
        DataTable dt = null;

        private void load_data()
        {
            try
            {
                DataTable dt = SEL_SMT_WEEK_PROD_STATUS("C", line, "");
                DataTable dt1 = SEL_SMT_WEEK_PROD_STATUS("C1", line, "");
                chartControl1.Series.Clear();
                chartControl2.Series.Clear();
                chartControl3.Series.Clear();
                chartControl4.Series.Clear();
                chartControl5.Series.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    CreateChart(chartControl1, dt.Select(" OP_CD = 'UPC' ").CopyToDataTable(), "UPC");
                    CreateChart(chartControl2, dt.Select(" OP_CD = 'UPS1' ").CopyToDataTable(), "UPS1");
                    CreateChart(chartControl3, dt.Select(" OP_CD = 'UPS2' ").CopyToDataTable(), "UPS2");
                    CreateChart(chartControl4, dt.Select(" OP_CD = 'FSS' ").CopyToDataTable(), "FSS");
                    CreateChart(chartControl5, dt.Select(" OP_CD = 'FGA' ").CopyToDataTable(), "FGA");
                    
                }

                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    BindingGauges(circularGauge, Convert.ToDouble(dt1.Rows[0]["RATE"]), Convert.ToInt32(dt1.Rows[0]["V_MIN"]), Convert.ToInt32(dt1.Rows[0]["V_MAX"]), Convert.ToDouble(dt1.Rows[0]["R_MIN"]), Convert.ToDouble(dt1.Rows[0]["R_MAX"]));
                    lblR.Text = "<" + dt1.Rows[0]["R_MIN"].ToString() + "%";
                    lblY.Text = ">=" + dt1.Rows[0]["R_MIN"].ToString() + "% && <=" + dt1.Rows[0]["R_MAX"].ToString() + "%";
                    lblG.Text = ">" + dt1.Rows[0]["R_MAX"].ToString() + "%";
                    lblRPlan.Text = "R.Plan: " + Convert.ToDouble(dt1.Rows[0]["RPLAN"]).ToString("#,#") + "Prs";
                    lblProd.Text = "Prod: " + Convert.ToDouble(dt1.Rows[0]["PROD"]).ToString("#,#") + "Prs";
                    lblRate.Text = "Rate: " + Convert.ToDouble(dt1.Rows[0]["RATE"]).ToString("#,#.#") + "%";
                    labelRate.Text = Convert.ToDouble(dt1.Rows[0]["RATE"]).ToString("#,0.0") + "%";

                    //arcScale.Ranges[0].StartValue = 90;
                    //arcScale.Ranges[0].EndValue = arcScale.Ranges[1].StartValue = Convert.ToSingle(dt1.Rows[0]["R_MIN"]); ;
                    //arcScale.Ranges[1].EndValue = arcScale.Ranges[2].StartValue = Convert.ToSingle(dt1.Rows[0]["R_MAX"]); ;
                    //arcScale.Ranges[2].EndValue = 100;
                    //arcScale.EnableAnimation = true;
                    //arcScale.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                    //arcScale.EasingFunction = new BackEase();
                    //double num = Convert.ToDouble(dt1.Rows[0]["RATE"]);
                    //arcScale.Value = (float)num;
                    //lblRed.Text = "<" + dt1.Rows[0]["R_MIN"].ToString();
                    //lblYellow.Text = dt1.Rows[0]["RMIN"].ToString() + " ~ " + dt1.Rows[0]["R_MAX"].ToString();
                    //lblGreen.Text = ">" + dt1.Rows[0]["R_MAX"].ToString();
                    //lblTitleProd.Text = "Weekly Assembly Production Average: " + num.ToString() + "%";

                }
                else
                {
                    BindingGauges(circularGauge, 0, 0, 100, 95, 98);
                    labelRate.Text = "0%";
                }
            }
            catch
            {
            }
        }

        private void BindingGauges(DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge circularGauge, double num, int iMin, int iMax, double iRangeMin, double iRangeMax)
        {
            // DataTable dt = SEL_POD("014", "001");
            if (circularGauge.Scales.Count <= 0)
            {
                return;
            }
            circularGauge.Scales[0].EnableAnimation = false;
            //arcScaleGauges.EasingFunction = new BackEase();
            circularGauge.Scales[0].MinValue = iMin;
            circularGauge.Scales[0].MaxValue = iMax;
            //arcScaleGauges.Ranges[0].EndValue = arcScaleGauges.Ranges[1].StartValue = Convert.ToSingle(10);
            //arcScaleGauges.Ranges[1].EndValue = arcScaleGauges.Ranges[2].StartValue = Convert.ToSingle(15);
            //arcScaleGauges.Ranges[2].EndValue = Convert.ToSingle(20);
            circularGauge.Scales[0].Value = 90;

            //circularGauge.Labels[0].Text = "90";
            if (circularGauge.Scales[0].Ranges.Count >= 3)
            {
                circularGauge.Scales[0].Ranges[0].StartValue = (float)(iMin);
                circularGauge.Scales[0].Ranges[0].EndValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].StartValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].EndValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].StartValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].EndValue = (float)(iMax);

            }
            //labelGauges.Text = "0";
            //if (dt != null && dt.Rows.Count > 0)
            //{
            try
            {

                circularGauge.Scales[0].MinValue = iMin;
                circularGauge.Scales[0].MaxValue = iMax;
                //arcScaleGauges.Ranges[0].EndValue = arcScaleGauges.Ranges[1].StartValue = Convert.ToSingle(Convert.ToSingle(dt.Rows[0][0]) - 2);
                //arcScaleGauges.Ranges[1].EndValue = arcScaleGauges.Ranges[2].StartValue = Convert.ToSingle(Convert.ToSingle(dt.Rows[0][0]) + 2);
                //arcScaleGauges.Ranges[2].EndValue = Convert.ToSingle(Convert.ToSingle(dt.Rows[0][0]) + 5);

                circularGauge.Scales[0].EnableAnimation = true;
                circularGauge.Scales[0].EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                //arcScaleGauges.EasingFunction = new BackEase();

                circularGauge.Scales[0].Value = (float)num;
                //circularGauge.Labels[0].Text = num.ToString();

            }
            catch (Exception ex)
            { }
        }
        

        private void CreateChart(DevExpress.XtraCharts.ChartControl Chart, DataTable dt, string col)
        {
            try
            {
                Chart.Series.Clear();
                //Chart.Titles.Clear();

                Chart.AppearanceNameSerializable = "Chameleon";
                Chart.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
                DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
                DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView = new DevExpress.XtraCharts.SideBySideBarSeriesView();
                lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                lineSeriesView1.Color = System.Drawing.Color.LimeGreen;
                lineSeriesView1.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(208)))), ((int)(((byte)(80)))));
                lineSeriesView1.LineStyle.Thickness = 3;               


                sideBySideBarSeriesView.ColorEach = false;
                sideBySideBarSeriesView.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
                string[] value = null;
                Chart.Series.Add("Target", ViewType.Line);
                Chart.Series[0].View = lineSeriesView1;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i_col = 3; i_col < dt.Columns.Count; i_col++)
                    {
                        Chart.Series.Add(line.Substring(0, 3) == "TOT" ? "Lean " + dt.Columns[i_col].ColumnName.Replace("'", "") : "Line " + dt.Columns[i_col].ColumnName.Replace("'", ""), ViewType.Bar);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Chart.Series[i_col - 2].View.Color = System.Drawing.Color.ForestGreen;
                            Chart.Series[i_col - 2].View = sideBySideBarSeriesView;
                            if (dt.Rows[i][i_col].ToString() != "")
                            {
                                value = dt.Rows[i][i_col].ToString().Split('/');
                                //Chart.Series[i - 1].Points.Add(new SeriesPoint(dt.Rows[i]["DAY"].ToString(), value[0]));
                                if (Convert.ToDouble(value[0]) > 0)
                                {
                                    Chart.Series[i_col - 2].Points.Add(new SeriesPoint(dt.Rows[i]["DAY"].ToString(), Convert.ToDouble(value[0])));
                                    Chart.Series[0].Points.Add(new SeriesPoint(dt.Rows[i]["DAY"].ToString(), Convert.ToDouble(value[1])));
                                }
                                else
                                {
                                    Chart.Series[i_col - 2].Points.Add(new SeriesPoint(dt.Rows[i]["DAY"].ToString()));
                                    Chart.Series[0].Points.Add(new SeriesPoint(dt.Rows[i]["DAY"].ToString(), Convert.ToDouble(value[1])));
                                }

                                if (Convert.ToDouble(value[0]) < Convert.ToDouble(value[1]))
                                {
                                    Chart.Series[i_col - 2].Points[i].Color = Color.Red;
                                }
                                else
                                {
                                    Chart.Series[i_col - 2].Points[i].Color = System.Drawing.Color.ForestGreen;
                                }
                            }
                            else
                            {
                                Chart.Series[i_col - 2].Points.Add(new SeriesPoint(dt.Rows[i]["DAY"].ToString()));
                                Chart.Series[0].Points.Add(new SeriesPoint(dt.Rows[i]["DAY"].ToString()));
                            }

                            Chart.Series[i_col - 2].LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                            Chart.Series[i_col - 2].Label.TextPattern = "{S}";
                            ((SideBySideBarSeriesLabel)Chart.Series[i_col - 2].Label).Position = BarSeriesLabelPosition.Top;
                            Chart.Series[i_col - 2].Label.TextOrientation = TextOrientation.BottomToTop;
                           

                        }

                       
                    }
                    //Chart.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1 };
                    //Chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

                    //((XYDiagram)Chart.Diagram).AxisX.Label.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //((XYDiagram)Chart.Diagram).AxisX.Title.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //((XYDiagram)Chart.Diagram).AxisY.Label.TextPattern = "{V:#,#}";
                    //((XYDiagram)Chart.Diagram).AxisY.Label.Font = new System.Drawing.Font("Tahoma", 14F);
                    //((XYDiagram)Chart.Diagram).AxisY.Title.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //((XYDiagram)Chart.Diagram).AxisY.Title.Text = "Production (Prs)";

                }   
            }
            catch (Exception EX)
            {
            }
        }

        public DataTable SEL_SMT_WEEK_PROD_STATUS(string ARG_QTYPE, string ARG_LINE,  string ARG_DATE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_MGL_VJ2.MGL_PRODUCTION_WEEKLY";

                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE";
                MyOraDB.Parameter_Name[2] = "ARG_DATE";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_LINE;
                MyOraDB.Parameter_Values[2] = ARG_DATE;
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

        private void FRM_SMT_WEEKLY_PROD_V2_Load(object sender, EventArgs e)
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

        int int_count = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                if (int_count < 20)
                    int_count++;
                else
                {
                    int_count = 0;
                    load_data();
                }
            }
            catch { }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lbltitle_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void chartControl1_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
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

        private void chartControl2_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
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

        private void chartControl4_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
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

        private void chartControl3_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
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

        private void FRM_SMT_WEEKLY_PROD_V2_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                uc.YMD_Change(2, "");
                lbltitle.Text = ComVar.Var._strValue1.Equals("TOTAL1") ? "VJ2 Production Status by Week" : ComVar.Var._strValue2 + " Production Status by Week";
                int_count = 19;
                line = ComVar.Var._strValue1;
                timer2.Start();

            }
            else
                timer2.Stop();
            
        }

        private void chartControl2_CustomDrawAxisLabel_1(object sender, CustomDrawAxisLabelEventArgs e)
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
    }
}
