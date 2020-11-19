using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using System.Data.OracleClient;

namespace FORM
{
    public partial class FRM_MGL_MONTHLY_PRODUCTION : Form
    {
        public FRM_MGL_MONTHLY_PRODUCTION()
        {
            InitializeComponent();
        }
        int indexScreen;
        string line, mline;
        Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        UC.UC_DWMY uc = new UC.UC_DWMY(3, "");//Hiển thị 4 Button, Button Day thì Disable
        DataTable dt = null;

        int int_count = 0;
        int i_col_cur = 0;
        Color BackColor1 = Color.FromArgb(232, 246, 247);
        Color BackColor2 = Color.White;

        private void FRM_SMT_MON_PROD_V2_Load(object sender, EventArgs e)
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

        //private void CreateChart()
        //{
        //    try
        //    {
        //        stackedBarChart.Series.Clear();
        //        stackedBarChart.Titles.Clear();

        //        DevExpress.XtraCharts.RectangleGradientFillOptions rectangleGradientFillOptions1 = new DevExpress.XtraCharts.RectangleGradientFillOptions();
        //        DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView1 = new DevExpress.XtraCharts.StackedBarSeriesView();
        //        DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView2 = new DevExpress.XtraCharts.StackedBarSeriesView();
        //        DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView3 = new DevExpress.XtraCharts.StackedBarSeriesView();
        //        DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView4 = new DevExpress.XtraCharts.StackedBarSeriesView();
        //        DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView5 = new DevExpress.XtraCharts.StackedBarSeriesView();
        //        DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();
        //        DevExpress.XtraCharts.StackedBarSeriesLabel stackedBarSeriesLabel1 = new DevExpress.XtraCharts.StackedBarSeriesLabel();
        //        DevExpress.XtraCharts.StackedBarSeriesLabel stackedBarSeriesLabel2 = new DevExpress.XtraCharts.StackedBarSeriesLabel();
        //        DevExpress.XtraCharts.StackedBarSeriesLabel stackedBarSeriesLabel3 = new DevExpress.XtraCharts.StackedBarSeriesLabel();
        //        DevExpress.XtraCharts.StackedBarSeriesLabel stackedBarSeriesLabel4 = new DevExpress.XtraCharts.StackedBarSeriesLabel();
        //        DevExpress.XtraCharts.StackedBarSeriesLabel stackedBarSeriesLabel5 = new DevExpress.XtraCharts.StackedBarSeriesLabel();
        //        //Animation
        //        DevExpress.XtraCharts.BarGrowUpAnimation barWidenAnimation1 = new DevExpress.XtraCharts.BarGrowUpAnimation();
        //        Series series1 = new Series("Cutting", ViewType.StackedBar);
        //        //Series series2 = new Series("No-Sew", ViewType.StackedBar);
        //        Series series3 = new Series("Stitching", ViewType.StackedBar);
        //        Series series4 = new Series("Stockfit", ViewType.StackedBar);
        //        Series series5 = new Series("Assembly", ViewType.StackedBar);

        //        DataTable dt = SEL_SMT_MON_PROD_STATUS("C",line,mline,"");
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                double D = dt.Rows[i]["UPC"].ToString() == "" ? 0 : Convert.ToDouble(dt.Rows[i]["UPC"].ToString());
        //                series1.Points.Add(new SeriesPoint(dt.Rows[i]["DAY"].ToString(), D));

        //                //series2.Points.Add(new SeriesPoint(dt.Rows[i]["DAY"].ToString(), dt.Rows[i]["UPA"].ToString()));

        //                series3.Points.Add(new SeriesPoint(dt.Rows[i]["DAY"].ToString(), dt.Rows[i]["UPS"].ToString() == "" ? 0 : Convert.ToDouble(dt.Rows[i]["UPS"].ToString())));

        //                series4.Points.Add(new SeriesPoint(dt.Rows[i]["DAY"].ToString(), dt.Rows[i]["FSS"].ToString() == "" ? 0 : Convert.ToDouble(dt.Rows[i]["FSS"].ToString())));

        //                series5.Points.Add(new SeriesPoint(dt.Rows[i]["DAY"].ToString(), dt.Rows[i]["FGA"].ToString() == "" ? 0 : Convert.ToDouble(dt.Rows[i]["FGA"].ToString())));


        //            }
        //            //stackedBarChart.DataSource = dt;
        //            //stackedBarChart.SeriesDataMember = "OP_CD";
        //            //stackedBarChart.SeriesTemplate.ArgumentDataMember = "YMD";
        //            //stackedBarChart.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "QTY" });
        //            //stackedBarChart.SeriesTemplate.View = new StackedBarSeriesView();                    
        //        }

        //       stackedBarChart.AppearanceNameSerializable = "Light";
        //       stackedBarChart.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.False;
        //       //stackedBarChart.AppearanceName = "do";

        //       stackedBarSeriesView1.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        //       stackedBarSeriesView1.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
        //       stackedBarSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
        //       stackedBarSeriesView1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
        //       stackedBarSeriesView1.BarWidth = 0.6D;

        //       series1.Label.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //       series1.Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        //       series1.Label.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
        //       series1.Label.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
        //       stackedBarSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
        //       stackedBarSeriesLabel1.TextColor = Color.Black;
        //       series1.View = stackedBarSeriesView1;
        //       series1.Label.TextPattern = "{V:#,#}";
        //       series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

        //       stackedBarSeriesView3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
        //       stackedBarSeriesView3.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
        //       stackedBarSeriesView3.BarWidth = 0.6D;
        //       series3.View = stackedBarSeriesView3;
        //       series3.Label.TextPattern = "{V:#,#}";
        //       series3.Label.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));               
        //       series3.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

        //       stackedBarSeriesView4.Animation = barWidenAnimation1;
        //       stackedBarSeriesView4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        //       stackedBarSeriesView4.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
        //       stackedBarSeriesView4.BarWidth = 0.6D;
        //       series4.View = stackedBarSeriesView4;
        //       series4.Label.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //       series4.Label.TextPattern = "{V:#,#}";
        //       series4.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

        //       stackedBarSeriesView5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
        //       stackedBarSeriesView5.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
        //       stackedBarSeriesView5.BarWidth = 0.6D;
        //       series5.View = stackedBarSeriesView5;
        //       series5.Label.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //       series5.Label.TextPattern = "{V:#,#}";
        //       series5.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

        //        //// Add both series to the chart.
        //        stackedBarChart.Series.AddRange(new Series[] { series1, series3, series4, series5 });

        //        //Contanst Line

        //        //((XYDiagram)stackedBarChart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { constantLine1 });
        //        ((XYDiagram)stackedBarChart.Diagram).AxisX.Label.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        //title
        //        ((XYDiagram)stackedBarChart.Diagram).AxisY.Label.TextPattern = "{V:#,#}";
        //        ((XYDiagram)stackedBarChart.Diagram).AxisY.Title.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        ((XYDiagram)stackedBarChart.Diagram).AxisY.Title.Text = "Production (Prs)";
        //        ((XYDiagram)stackedBarChart.Diagram).AxisY.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
        //        ((XYDiagram)stackedBarChart.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

        //        ((XYDiagram)stackedBarChart.Diagram).AxisX.Title.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        ((XYDiagram)stackedBarChart.Diagram).AxisX.Title.Text = "Date";
        //        ((XYDiagram)stackedBarChart.Diagram).AxisX.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
        //        ((XYDiagram)stackedBarChart.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

        //        //Angle
        //        ((XYDiagram)stackedBarChart.Diagram).AxisX.Label.Angle = 0;
        //        ((XYDiagram)stackedBarChart.Diagram).AxisX.Label.ResolveOverlappingOptions.AllowRotate = false;
        //        ((XYDiagram)stackedBarChart.Diagram).AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;

        //        //legend
        //        stackedBarChart.Legend.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        stackedBarChart.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
        //        stackedBarChart.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
        //        stackedBarChart.Legend.Border.Color = System.Drawing.Color.Black;
        //        stackedBarChart.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
        //        stackedBarChart.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
        //        stackedBarChart.Legend.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;                
        //        stackedBarChart.Legend.MarkerOffset = 3;
        //        stackedBarChart.Legend.Name = "Default Legend";
        //        stackedBarChart.Legend.Shadow.Visible = true;
        //        stackedBarChart.Location = new System.Drawing.Point(0, 0);
        //        stackedBarChart.Name = "stackedBarChart";
        //        stackedBarChart.PaletteName = "Flow";

        //        ((XYDiagram)stackedBarChart.Diagram).EnableAxisXZooming = true;
        //        stackedBarChart.Dock = DockStyle.Fill;

        //    }
        //    catch(Exception EX )
        //    {                
        //    }
        //}

        private void bindingdatachart(DevExpress.XtraCharts.ChartControl _chart, DataTable dt, string col1, string col2)
        {
            _chart.DataSource = dt;
            _chart.Series[0].ArgumentDataMember = "DAY";
            _chart.Series[0].ValueDataMembers.AddRange(new string[] { col1 });
            //chartControl1.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            _chart.Series[1].ArgumentDataMember = "DAY";
            _chart.Series[1].ValueDataMembers.AddRange(new string[] { col2 });
            //chartControl1.Series[1].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
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
                //circularGauge.Scales[0].Ranges[0].AppearanceRange.ContentBrush.

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
            // }
        }

        private void load_data()
        {
            try
            {
                load_head();
                DataTable dt = SEL_SMT_MON_PROD_STATUS("Q", line, "");
                DataTable dt_chart = SEL_SMT_MON_PROD_STATUS("C", line, "");
                DataTable dt1 = SEL_SMT_MON_PROD_STATUS("C1", line, "");
                if (dt != null && dt.Rows.Count > 0)
                {
                    grdView.DataSource = dt;
                    for(int i=0; i<gvwView.Columns.Count; i++)
                    {
                        gvwView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                        if (gvwView.Columns[i].FieldName.Equals("LINE"))
                        {
                            gvwView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                        }
                        if (gvwView.Columns[i].FieldName.Equals("RATE"))
                        {
                            gvwView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            gvwView.Columns[i].DisplayFormat.FormatString = "#,#.#";
                        }
                    }
                   
                }
                bindingdatachart(chartControl1, dt_chart,  "UPC_QTY","UPC_TAR");
                bindingdatachart(chartControl2, dt_chart, "UPS1_QTY", "UPS1_TAR");
                bindingdatachart(chartControl3, dt_chart, "UPS2_QTY", "UPS2_TAR");
                bindingdatachart(chartControl4, dt_chart, "FSS_QTY", "FSS_TAR");
                bindingdatachart(chartControl5, dt_chart, "FGA_QTY", "FGA_TAR");

                int i_min = 0, i_max = 100;
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (gvwView.GetRowCellValue(4,"RATE").ToString().Replace("%","").Trim() != "")
                    {
                        double RATE = double.Parse(gvwView.GetRowCellValue(4, "RATE").ToString().Replace("%", "").Trim());
                        if (RATE > 90 && RATE < 100)
                        {
                            i_min = 90;
                            i_max = 100;
                        }
                        else if (RATE < 90)
                        {
                            i_min = 90 - 3;
                            i_max = 100;
                        }
                        else if (RATE >= 100)
                        {
                            i_min = 90;
                            i_max = 100 + 3;
                        }
                        else if (RATE == 0)
                        {
                            i_min = 0;
                            i_max = 100;
                        }
                        BindingGauges(circularGauge, RATE, i_min, i_max, 95, 98);
                        labelRate.Text = RATE + "%";
                    }
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
        private void load_head()
        {
            try
            {
                DataTable dtsource = SEL_SMT_MON_PROD_STATUS("H",line,"");
                if (dtsource != null && dtsource.Rows.Count > 0)
                {                    
                    if (dtsource != null && dtsource.Rows.Count > 0)
                    {
                        bandMon.Caption = dtsource.Rows[0]["MON"].ToString();
                        if (dtsource.Rows.Count > 0)
                        {
                            foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand band in gvwView.Bands[1].Children)
                            {
                                double num;

                                if (double.TryParse(band.Name.Substring(4, 2), out num))
                                {
                                    for (int i = 0; i < dtsource.Rows.Count; i++)
                                    {
                                        if (band.Name.Contains(dtsource.Rows[i][1].ToString()))
                                        {
                                            band.Visible = true;
                                            if (dtsource.Rows[i]["CUR"].ToString().Contains("1"))
                                            {
                                                band.AppearanceHeader.BackColor = Color.Salmon;
                                                band.AppearanceHeader.BackColor2 = Color.Salmon;
                                                band.AppearanceHeader.ForeColor = Color.White;
                                            }
                                            else
                                            {
                                                band.AppearanceHeader.BackColor = Color.DarkCyan;
                                                band.AppearanceHeader.BackColor2 = Color.DarkCyan;
                                                band.AppearanceHeader.ForeColor = Color.White;
                                            }
                                            band.Caption = dtsource.Rows[i]["DAY"].ToString()+ "\n" + dtsource.Rows[i]["DAY1"].ToString();
                                            break;
                                        }
                                        if (i == dtsource.Rows.Count - 1)
                                        {
                                            band.Visible = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
            }
        }

        public DataTable SEL_SMT_MON_PROD_STATUS(string ARG_QTYPE, string ARG_LINE, string ARG_DATE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_MGL_VJ2.MGL_PRODUCTION_MONTHLY";

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
                MyOraDB.Parameter_Values[2] = uc_month.GetValue();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void stackedBarChart_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
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
            catch
            {
            }
        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FRM_SMT_MON_PROD_V2_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                uc.YMD_Change(3, "");
                line = ComVar.Var._strValue1;
                lbltitle.Text = ComVar.Var._strValue1.Equals("TOTAL1") ? "VJ1 Support Production Status by Month" : ComVar.Var._strValue2 + " Production Status by Month";
                int_count = 19;
                timer2.Start();
            }
            else
            {
                
                timer2.Stop();
            }
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

        private void gvwView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.CellValue == DBNull.Value) return;
            if (e.Column.FieldName.Equals("RATE"))
                e.DisplayText = double.Parse(e.CellValue.ToString()).ToString("#,#.#") + "%";
        }

        private void gvwView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.ColumnHandle > 1)
            {
                if (e.RowHandle % 2 == 0 && e.Column.ColumnHandle > 1)
                {
                    e.Appearance.BackColor = Color.White;
                }
                else
                {
                    e.Appearance.BackColor = Color.LightCyan;
                }
                if (e.CellValue == DBNull.Value) return;
                if (e.Column.FieldName.Equals("RATE") && e.CellValue != DBNull.Value)
                {
                    if (double.Parse(e.CellValue.ToString()) > 98)
                    {
                        e.Appearance.BackColor = Color.Green;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else if (double.Parse(e.CellValue.ToString()) < 95)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.Yellow;
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void uc_month_ValueChangeEvent(object sender, EventArgs e)
        {
            load_data();
        }

    }
}
