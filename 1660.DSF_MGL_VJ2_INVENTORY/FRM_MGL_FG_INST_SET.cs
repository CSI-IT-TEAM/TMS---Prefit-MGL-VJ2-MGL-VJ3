using DevExpress.Utils;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM
{
    public partial class FRM_MGL_FG_INST_SET : Form
    {
        const int ViewportPointCount = 15;
        bool isLoop = false;
        //ObservableCollection<DataPoint> dataPoints = new ObservableCollection<DataPoint>();
        ObservableCollection<DataRealPoint> dataPoints = new ObservableCollection<DataRealPoint>();
        DataTable dt = new DataTable();
        public DataTable SEL_SMT_INST_SET_CHART(string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_MGL_VJ2.SP_SMT_INST_SET"; //2020-09-18

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
        public FRM_MGL_FG_INST_SET()
        {
            InitializeComponent();
            timer1.Stop();
        }

        private void FRM_SMT_FG_INST_SET_Load(object sender, EventArgs e)
        {


        }
        private void BindingGridData(DataTable dt)
        {
            DataView view = new DataView(dt);
            view.Sort = "SET_TIME DESC";
            gridControl1.DataSource = view.ToTable();
            formatGrid();
        }
        private void formatGrid()
        {
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].AppearanceHeader.Font = new Font("Calibri", 12F, FontStyle.Regular);
                gridView1.Columns[i].AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
                gridView1.Columns[i].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gridView1.Columns[i].Caption = gridView1.Columns[i].GetCaption().Replace("SET_TIME", "Set Time").Replace("UP_QTY", "Upper Qty").Replace("FS_QTY", "Finish Sole Qty").Replace("SET_QTY", "Set Qty").Replace("SET_RATIO", "Set Ratio([Set Qty * 2 / (Upper + Finish sole) * 100])");
                gridView1.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                gridView1.Columns[i].OptionsColumn.ReadOnly = true;
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                gridView1.Columns[i].OptionsFilter.AllowFilter = false;
                gridView1.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView1.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                if (i >= 3)
                {
                    gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    gridView1.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView1.Columns[i].DisplayFormat.FormatString = "#,#.#";
                }
            }
            gridView1.Columns["SET_FAKE_TIME"].Visible = false;
            gridView1.Columns["FA_WC_CD"].Visible = false;
            //gridView1.Columns[3].Visible = false;
        }
        private void BindingChartData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                // chartControl1.Titles.Add(new ChartTitle { Text = "Real-Time Charting" });
                dataPoints.Clear();
                dt = SEL_SMT_INST_SET_CHART(ComVar.Var._strValue1, ComVar.Var._strValue2);

                BindingGridData(dt);

                DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
                DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
                DevExpress.XtraCharts.LineSeriesView lineSeriesView3 = new DevExpress.XtraCharts.LineSeriesView();
                DevExpress.XtraCharts.LineSeriesView lineSeriesView4 = new DevExpress.XtraCharts.LineSeriesView();
                DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel4 = new DevExpress.XtraCharts.PointSeriesLabel();

                Series series = new Series("Upper", ViewType.Line);
                series.ChangeView(ViewType.Line);
                series.DataSource = dataPoints;
                series.ArgumentDataMember = "sArgument";
                series.ValueDataMembers.AddRange("UP_QTY");
                series.CrosshairLabelPattern = "{V:#,#} Prs";
                //format
                //lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                lineSeriesView1.LineStyle.Thickness = 2;
                series.View = lineSeriesView1;
                Series series2 = new Series("Finish Sole", ViewType.Line);
                series2.ChangeView(ViewType.Line);
                series2.DataSource = dataPoints;
                series2.ArgumentDataMember = "sArgument";
                series2.ValueDataMembers.AddRange("FS_QTY");
                series2.CrosshairLabelPattern = "{V:#,#} Prs";
                //format
                //  lineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                lineSeriesView2.Color = Color.Gray;
                lineSeriesView2.LineStyle.Thickness = 2;
                series2.View = lineSeriesView2;

                Series series3 = new Series("Set Balance", ViewType.Line);
                series3.ChangeView(ViewType.Line);
                series3.DataSource = dataPoints;
                series3.ArgumentDataMember = "sArgument";
                series3.ValueDataMembers.AddRange("SET_QTY");
                series3.CrosshairLabelPattern = "{V:#,#} Prs";
                //format
                // lineSeriesView3.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                lineSeriesView3.LineStyle.Thickness = 2;
                series3.View = lineSeriesView3;

                Series series4 = new Series("Set Ratio", ViewType.Line);
                series4.ChangeView(ViewType.Line);
                series4.DataSource = dataPoints;
                series4.ArgumentDataMember = "sArgument";
                series4.ValueDataMembers.AddRange("RATIO");
                series4.CrosshairLabelPattern = "{V:#.0}%";
                //pointSeriesLabel4.TextPattern = "{V:#.0}%";
                series4.LabelsVisibility = DefaultBoolean.True;
                //format
                lineSeriesView4.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                lineSeriesView4.LineStyle.Thickness = 4;
                lineSeriesView4.Color = Color.Orange;
                series4.View = lineSeriesView4;

                XYDiagram diagram = (XYDiagram)chartControl1.Diagram;

                diagram.AxisX.Label.ResolveOverlappingOptions.AllowRotate = false;
                diagram.AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
                diagram.AxisX.WholeRange.SideMarginsValue = 0;
                diagram.DependentAxesYRange = DefaultBoolean.True;
                diagram.AxisY.WholeRange.AlwaysShowZeroLevel = false;
                diagram.AxisY.Title.Text = "Qty (Prs)";
                diagram.AxisY.Title.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                diagram.AxisY.Title.TextColor = Color.Blue;
                diagram.AxisY.Title.Visibility = DefaultBoolean.True;
                diagram.AxisY.Color = Color.DodgerBlue;
                diagram.AxisY.Label.TextPattern = "{V:#,#}";
                diagram.AxisY.Label.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                diagram.AxisY.Interlaced = true;
                chartControl1.Series.Clear();
                chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series, series2, series3, series4 };

                //ADD SECONDARY AXISY
                SecondaryAxisY myAxisY = new SecondaryAxisY("my X-Axis");
                ((XYDiagram)chartControl1.Diagram).SecondaryAxesY.Clear();
                ((XYDiagram)chartControl1.Diagram).SecondaryAxesY.Add(myAxisY);
                ((LineSeriesView)series4.View).AxisY = myAxisY;
                myAxisY.WholeRange.SideMarginsValue = 0;
                myAxisY.WholeRange.MinValue = 0;
                myAxisY.WholeRange.MaxValue = 100;
                myAxisY.Title.Text = "Set Ratio (%)";
                myAxisY.Title.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                myAxisY.Title.TextColor = Color.Orange;
                myAxisY.Title.Visibility = DefaultBoolean.True;
                myAxisY.Label.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                myAxisY.Color = Color.Orange;

                //legend
                chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
                chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
                chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
                chartControl1.Legend.Name = "Default Legend";
                chartControl1.Legend.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                chartControl1.Legend.Visibility = DefaultBoolean.True;

                if (dt != null && dt.Rows.Count <= ViewportPointCount)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string setTime1 = dt.Rows[i]["SET_TIME"].ToString();
                        int UP_QTY1 = Convert.ToInt32(dt.Rows[i]["UP_QTY"]);
                        int FS_QTY1 = Convert.ToInt32(dt.Rows[i]["FS_QTY"]);
                        int SET_QTY1 = Convert.ToInt32(dt.Rows[i]["SET_QTY"]);
                        double RATIO1 = Convert.ToDouble(dt.Rows[i]["SET_RATIO"]);
                        dataPoints.Add(new DataRealPoint(setTime1, UP_QTY1, FS_QTY1, SET_QTY1, RATIO1));
                    }
                    isLoop = true;
                    tmrDelay.Start();
                }
                else
                { isLoop = false;
                    timer1.Start(); }


                this.Cursor = Cursors.Default;
            }
            catch { this.Cursor = Cursors.Default; }
        }

        Random r = new Random();
        double GenerateValue(double x)
        {
            //return Math.Sin(x) * 3 + x / 2 + 5;
            //return r.NextDouble();

            return 2 * Math.Cos(x * 2 * Math.PI)
                          + Math.Sin((double)x * 2 * Math.PI)
                          + 4 * Math.Cos(2 * x * 2 * Math.PI)
                          + 5 * Math.Sin(2 * x * 2 * Math.PI)
                          + 0.6 * r.NextDouble() - 0.3;
        }
        int iCount = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dt == null) return;

            if (iCount >= dt.Rows.Count)
            {
                iCount = 0;
            }
            if (dataPoints.Count < ViewportPointCount)
            {
                for (int i = 0; i < ViewportPointCount; i++)
                {
                    string setTime1 = dt.Rows[i]["SET_TIME"].ToString();
                    int UP_QTY1 = Convert.ToInt32(dt.Rows[i]["UP_QTY"]);
                    int FS_QTY1 = Convert.ToInt32(dt.Rows[i]["FS_QTY"]);
                    int SET_QTY1 = Convert.ToInt32(dt.Rows[i]["SET_QTY"]);
                    double RATIO1 = Convert.ToDouble(dt.Rows[i]["SET_RATIO"]);
                    dataPoints.Add(new DataRealPoint(setTime1, UP_QTY1, FS_QTY1, SET_QTY1, RATIO1));
                }
                iCount = ViewportPointCount;
            }
            string setTime = dt.Rows[iCount]["SET_TIME"].ToString();
            int UP_QTY = Convert.ToInt32(dt.Rows[iCount]["UP_QTY"]);
            int FS_QTY = Convert.ToInt32(dt.Rows[iCount]["FS_QTY"]);
            int SET_QTY = Convert.ToInt32(dt.Rows[iCount]["SET_QTY"]);
            double RATIO = Convert.ToDouble(dt.Rows[iCount]["SET_RATIO"]);
            dataPoints.Add(new DataRealPoint(setTime, UP_QTY, FS_QTY, SET_QTY, RATIO));
            iCount++;
            if (dataPoints.Count > ViewportPointCount)
            {
                dataPoints.RemoveAt(0);
            }
            if (iCount >= dt.Rows.Count)
            {
                isLoop = false;
                iCount = 0;
                timer1.Stop();
                tmrDelay.Start();
            }
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        int iCounter = 0;
        private void tmr_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
        }
        private void tmrDelay_Tick(object sender, EventArgs e)
        {
            iCounter++;
            if (iCounter >= 30)
            {
                try
                {
                    iCounter = 0;
                    BindingChartData();
                    if (!isLoop)
                        tmrDelay.Stop();
                }
                catch
                {

                }
            }
        }

        private void FRM_SMT_FG_INST_SET_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = ComVar.Var._strValue1.Equals("TOTAL1") ? "VJ1 Instant Set Balance" : ComVar.Var._strValue2 + " Instant Set Balance";
                if (this.Visible)
                {
                    isLoop = false;
                    iCounter = 30;
                    tmrDelay.Start();
                }
                }
            catch { }
        }

        private void btnPrediction_Click(object sender, EventArgs e)
        {
            ComVar.Var._IsBack = true;
            ComVar.Var.callForm = "1669";
        }
    }

    public class DataRealPoint
    {
        //public DateTime Argument { get; set; }
        public string sArgument { get; set; }
        public int uP_QTY { get; set; }
        public int fS_QTY { get; set; }
        public int sET_QTY { get; set; }
        public double rATIO { get; set; }
        //public DataPoint(DateTime argument, double value)
        //{
        //    Argument = argument;
        //    Value = value;
        //}
        public DataRealPoint(string argument, int UP_QTY, int FS_QTY, int SET_QTY, double RATIO)
        {
            sArgument = argument;
            uP_QTY = UP_QTY;
            fS_QTY = FS_QTY;
            sET_QTY = SET_QTY;
            rATIO = RATIO; //Ratio 
        }
    }

    public class DataPoint
    {
        //public DateTime Argument { get; set; }
        public string sArgument { get; set; }
        public double Value { get; set; }
        public double Value2 { get; set; }
        public double Value3 { get; set; }
        public double Value4 { get; set; }
        //public DataPoint(DateTime argument, double value)
        //{
        //    Argument = argument;
        //    Value = value;
        //}
        public DataPoint(string argument, double value, double value2, double value3, double value4)
        {
            sArgument = argument;
            Value = value;
            Value2 = value2;
            Value3 = value3;
            Value4 = value4; //Ratio example
        }
    }


}
