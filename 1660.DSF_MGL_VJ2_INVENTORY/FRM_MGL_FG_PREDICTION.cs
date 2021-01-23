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
    public partial class FRM_MGL_FG_PREDICTION : Form
    {
        const int ViewportPointCount = 15;
        bool isLoop = false;
        //ObservableCollection<DataPoint> dataPoints = new ObservableCollection<DataPoint>();
        ObservableCollection<DataRealPoint> dataPoints = new ObservableCollection<DataRealPoint>();
        DataTable dt = new DataTable();
        public DataTable SEL_SMT_ISB_PREDICTION_CHART(string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_MGL_VJ2.SP_SMT_ISB_PREDICTION"; //2020-09-18

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
        public FRM_MGL_FG_PREDICTION()
        {
            InitializeComponent();
            timer1.Stop();
        }

        private void FRM_SMT_FG_PREDICTION_Load(object sender, EventArgs e)
        {


        }
        private void BindingChartISB()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                chartControl2.DataSource = null;
                DataTable dtISB = SEL_SMT_ISB_PREDICTION_CHART(ComVar.Var._strValue1, ComVar.Var._strValue2);
                string _str1 = "", _str2 = "";
                if (dtISB != null && dtISB.Rows.Count > 0)
                {
                    for (int i = 0; i < dtISB.Rows.Count; i++)
                    {
                        if (dtISB.Rows[i]["DIV"].ToString().Equals("Present"))
                        {
                            _str1 = dtISB.Rows[i]["HH"].ToString();
                        }
                        if (dtISB.Rows[i]["DIV"].ToString().Equals("Present + Prediction"))
                        {
                            _str2 = dtISB.Rows[i]["HH"].ToString();
                        }
                    }
                    chartControl2.DataSource = dtISB;
                    chartControl2.Series[0].ArgumentDataMember = "HH";
                    chartControl2.Series[0].ValueDataMembers.AddRange(new string[] { "VAL2" });
                    chartControl2.Series[1].ArgumentDataMember = "HH";
                    chartControl2.Series[1].ValueDataMembers.AddRange(new string[] { "VAL1" });

                    ((XYDiagram)chartControl2.Diagram).AxisX.ConstantLines[0].AxisValue = _str1;
                    ((XYDiagram)chartControl2.Diagram).AxisX.ConstantLines[1].AxisValue = _str2;
                    ((XYDiagram)chartControl2.Diagram).AxisY.ConstantLines[0].AxisValue = 90;
                    ((XYDiagram)chartControl2.Diagram).AxisY.ConstantLines[1].AxisValue = 60;
                    ((XYDiagram)chartControl2.Diagram).AxisY.WholeRange.AlwaysShowZeroLevel = false;
                    //((XYDiagram)chartControl2.Diagram).AxisY.WholeRange.MaxValue = 90;
                    //((XYDiagram)chartControl2.Diagram).AxisY.WholeRange.MinValue = 30;
                    //((XYDiagram)chartControl2.Diagram).AxisY.WholeRange.SideMarginsValue = 30;
                }

                //TrendLineCollection colorizer = new TrendLineCollection();
                //colorizer.FallingTrendColor = Color.RoyalBlue;
                //colorizer.RisingTrendColor = Color.Firebrick;
                //colorizer.FallingTrendLegendText = "Temperature Decrease";
                //colorizer.RisingTrendLegendText = "Temperature Rise";
                //colorizer.ShowInLegend = true;
                //LineSeriesView lineSeriesView = chartControl.Series[0].View as LineSeriesView;
                //lineSeriesView.SegmentColorizer = colorizer;


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
                    BindingChartISB();
                }
                catch
                {

                }
            }
        }

        private void FRM_SMT_FG_PREDICTION_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = ComVar.Var._strValue1.Equals("TOTAL1") ? "VJ1 ISB Prediction" : ComVar.Var._strValue2 + " ISB Prediction";
                if (this.Visible)
                    iCounter = 30;
            }
            catch { }
        }
    }

}
