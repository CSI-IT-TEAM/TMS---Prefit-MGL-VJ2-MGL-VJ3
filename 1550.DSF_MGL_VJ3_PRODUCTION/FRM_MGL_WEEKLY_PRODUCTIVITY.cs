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
using DevExpress.XtraGauges.Core.Model;
using DevExpress.XtraCharts;

namespace FORM
{
    public partial class FRM_MGL_WEEKLY_PRODUCTIVITY : Form
    {
        public FRM_MGL_WEEKLY_PRODUCTIVITY()
        {
            InitializeComponent();
        }
        string line, mline, lang;
        #region db
        Database db = new Database();
        DataTable _dtXML = null;
        DataTable dt = null;
        #endregion
        #region UC
        UC.UC_DWMY uc = new UC.UC_DWMY(2,""); //Hiển thị 4 Button, Button Day thì Disable
        #endregion
        Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        int cCount = 0;

        public DataTable SMT_PROD_WEEKLY_SELECT(string ARG_DATE, string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_MGL_VJ3.SMT_PRODUCTIVITY_WEEKLY_SELECT";
                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_DATE";
                MyOraDB.Parameter_Name[2] = "ARG_LINE";
                MyOraDB.Parameter_Name[3] = "ARG_MLINE";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";
                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = "Q";
                MyOraDB.Parameter_Values[1] = ARG_DATE;
                MyOraDB.Parameter_Values[2] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[3] = "003";
                MyOraDB.Parameter_Values[4] = "";


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

        private void FRM_PROD_STATUS_DAILY_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            _dtnInit = ComVar.Func.getInitForm(this.GetType().Assembly.GetName().Name, this.GetType().Name);
            pnYMD.Controls.Add(uc);
            uc.OnDWMYClick += DWMYClick;
            line = ComVar.Var._strValue1; mline = ComVar.Var._strValue2; lang = ComVar.Var._strValue3;

        }

        void DWMYClick(string ButtonCap, string ButtonCD)
        {
            switch (ButtonCD)
            {
                case "C":
                    ComVar.Var.callForm = "back";
                    break;
                case "D":
                    ComVar.Var.callForm = "1560";
                    break;
                case "W":
                    ComVar.Var.callForm = "1561";
                    break;
                case "M":
                    ComVar.Var.callForm = "1564";
                    break;
                case "Y":
                    ComVar.Var.callForm = "1563";
                    break;
            }
        }

        private void BindingGauge(DataTable arg_dt)
        {
            lblTitleProd.Text = "POD: 0";
            arcScale.EnableAnimation = false;
            arcScale.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseIn;
            arcScale.EasingFunction = new BackEase();
            arcScale.Value = 0;
            if (arg_dt != null && arg_dt.Rows.Count > 0)
            {
                try
                {

                    //arcScale.MinValue = Convert.ToSingle(arg_dt.Rows[0]["MIN_VALUE"]);
                   //arcScale.MaxValue = Convert.ToSingle(arg_dt.Rows[0]["MAX_VALUE"]);
                    arcScale.Ranges[0].StartValue = 6;
                    arcScale.Ranges[0].EndValue = arcScale.Ranges[1].StartValue = Convert.ToSingle(arg_dt.Rows[0]["R_MIN"]); ;
                    arcScale.Ranges[1].EndValue = arcScale.Ranges[2].StartValue = Convert.ToSingle(arg_dt.Rows[0]["R_MAX"]); ;
                    arcScale.Ranges[2].EndValue = 12;

                    DataTable dt = arg_dt.Select("Day = 'AVG'").CopyToDataTable();
                    arcScale.EnableAnimation = true;
                    arcScale.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                    arcScale.EasingFunction = new BackEase();
                    double num = Convert.ToDouble(dt.Rows[0]["POD"]); 
                    arcScale.Value = (float)num;

                    lblRed.Text = "<" + arg_dt.Rows[0]["R_MIN"].ToString();
                    lblYellow.Text = arg_dt.Rows[0]["R_MIN"].ToString() + " ~ " + arg_dt.Rows[0]["R_MAX"].ToString();
                    lblGreen.Text = ">" + arg_dt.Rows[0]["R_MAX"].ToString();

                    lblTitleProd.Text = "POD: " + num.ToString();
                }
                catch(Exception ex)
                { }
            }
        }

        private void BindingChart()
        {
            dt = SMT_PROD_WEEKLY_SELECT(DateTime.Now.ToString("yyyyMMdd"), line, mline);
            InitChart("UPC", dt, chartUPC); InitChart("UPS1", dt, chartUPS1); InitChart("UPS2", dt, chartUPS2); InitChart("UPS3", dt, chartUPS3);
            
        }

        private void InitChart(string sChart,DataTable dt, DevExpress.XtraCharts.ChartControl chartControl)
        {
            try
            {
                var sTitle = new List<string>();
                //int mLineStart = Convert.ToInt32(line.Equals("202") ? mline : line);
                //if (mLineStart == 3)
                //    mLineStart = 2;
                //else if (mLineStart == 2)
                //    mLineStart = 3;
                //if (!sChart.Equals("UPC"))
                //{
                //    switch (line)
                //    {
                //        case "001":
                //        case "002":
                //        case "003":
                //        case "004":
                //        case "005":
                //        case "006":
                //            for (int i = 1; i <= 3; i++)
                //                sTitle.Add("Stitching " + ((mLineStart - 1) * 3 + i).ToString());
                //            break;
                //        default:
                //            for (int i = 1; i <= 2; i++)
                //                sTitle.Add("Stitching " + ((mLineStart - 1) * 2 + i).ToString());
                //            break;
                //    }
                //}
                DevExpress.XtraCharts.ChartTitle chartTitle = new DevExpress.XtraCharts.ChartTitle();
                chartControl.DataSource = dt;
                chartControl.Series[0].ArgumentDataMember = "DAY";
                chartControl.Series[0].ValueDataMembers.AddRange(new string[] { sChart + "_TAR" });
                chartControl.Series[1].ArgumentDataMember = "DAY";
                chartControl.Series[1].ValueDataMembers.AddRange(new string[] { sChart + "_ACT" });
                ((DevExpress.XtraCharts.XYDiagram)chartControl.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                if (!sChart.Equals("UPC"))
                {
                    chartTitle.Text = sTitle[Convert.ToInt32(sChart.Substring(3, 1)) - 1];
                    chartControl.Titles.Clear();
                    chartControl.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle });
                }
            }
            catch(Exception ex) { }
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cCount++;
            if (cCount >= 30)
            {
                BindingChart(); BindingGauge(dt);
                cCount = 0;
            }
        }

        private void FRM_PROD_STATUS_DAILY_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                lang = ComVar.Var._strValue3;
                uc.YMD_Change(2,lang);
                lbltitle.Text = ComVar.Var._strValue1.Equals("TOT") ? "VJ1,VJ2 Support Productivity Status by Week" : ComVar.Var._strValue1 + " Support Productivity  Status by Week";
                cCount = 30-1;
               // line = "001"; mline = ComVar.Var._strValue1;
                line = ComVar.Var._strValue1; mline = ComVar.Var._strValue2;
               // line = "099"; mline = "001";
                switch (line)
                {
                    case "VJ2":
                        //grdBandStit3.Visible = false;
                        //chartUPS3.Visible = false;
                        tblMain2.ColumnStyles[0].Width = 38.00F;
                        tblMain2.ColumnStyles[0].SizeType = SizeType.Percent;
                        tblMain2.ColumnStyles[1].Width = 38.00F;
                        tblMain2.ColumnStyles[1].SizeType = SizeType.Percent;
                        tblMain2.ColumnStyles[2].Width = 0;
                        tblMain2.ColumnStyles[2].SizeType = SizeType.Percent;
                        break;
                    default:
                        //grdBandStit3.Visible = true;
                        //chartUPS3.Visible = true;
                        tblMain2.ColumnStyles[0].Width = 25.00F;
                        tblMain2.ColumnStyles[0].SizeType = SizeType.Percent;
                        tblMain2.ColumnStyles[1].Width = 25.00F;
                        tblMain2.ColumnStyles[1].SizeType = SizeType.Percent;
                        tblMain2.ColumnStyles[2].Width = 25.00F;
                        tblMain2.ColumnStyles[2].SizeType = SizeType.Percent;
                        break;
                }
                //switch (lang)
                //{
                //    case "Vi":
                //        lang = "Vi";
                //        lbltitle.Text = "Tình trạng năng suất theo tuần";
                //        break;
                //    case "En":
                //        lang = "En";
                //        lbltitle.Text = "Productivity Status by Week";
                //        break;
                //    default:
                //        lbltitle.Text = "Productivity Status by Week";
                //        break;

                //}
                tmr.Start();
            }
            else
                tmr.Stop();
            
        }

        private void chart_CustomDrawAxisLabel(object sender, DevExpress.XtraCharts.CustomDrawAxisLabelEventArgs e)
        {
            try
            {
                AxisBase axis = e.Item.Axis;
                if (axis is AxisX)
                {
                    e.Item.Text = e.Item.Text.Replace("_", "\n");
                    e.Item.TextColor = Color.Green;
                    e.Item.EnableAntialiasing = DefaultBoolean.True;
                }
            }
            catch { }
        }

       
    }
}
