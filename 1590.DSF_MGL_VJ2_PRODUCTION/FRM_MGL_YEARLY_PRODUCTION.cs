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
    public partial class FRM_MGL_YEARLY_PRODUCTION : Form
    {
        public FRM_MGL_YEARLY_PRODUCTION()
        {
            InitializeComponent();
        }
        int indexScreen;
        string line, mline;
        Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        UC.UC_DWMY uc = new UC.UC_DWMY(3, "");//Hiển thị 4 Button, Button Day thì Disable
        public FRM_MGL_YEARLY_PRODUCTION(string title, int _indexScreen, string _line, string _mline)
        {
            InitializeComponent();
            indexScreen = _indexScreen;
            line = _line;
            mline = _mline;
            lbltitle.Text = title;
        }

        int int_count = 0;
        int i_col_cur = 0;
        Color BackColor1 = Color.FromArgb(232, 246, 247);
        Color BackColor2 = Color.White;

        private void FRM_SMT_YEAR_PROD_V2_Load(object sender, EventArgs e)
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
            if (circularGauge.Scales.Count <= 0)
            {
                return;
            }
            circularGauge.Scales[0].EnableAnimation = false;
            circularGauge.Scales[0].MinValue = iMin;
            circularGauge.Scales[0].MaxValue = iMax;
            circularGauge.Scales[0].Value = 90;
            if (circularGauge.Scales[0].Ranges.Count >= 3)
            {
                circularGauge.Scales[0].Ranges[0].StartValue = (float)(iMin);
                circularGauge.Scales[0].Ranges[0].EndValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].StartValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].EndValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].StartValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].EndValue = (float)(iMax);
            }
            try
            {

                circularGauge.Scales[0].MinValue = iMin;
                circularGauge.Scales[0].MaxValue = iMax;

                circularGauge.Scales[0].EnableAnimation = true;
                circularGauge.Scales[0].EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                circularGauge.Scales[0].Value = (float)num;
            }
            catch (Exception ex)
            { }
        }

        
        private void load_data()
        {
            try
            {
                load_head();
                DataTable dt = SEL_SMT_YEAR_PROD_STATUS("Q", line, "");
                DataTable dt_chart = SEL_SMT_YEAR_PROD_STATUS("C", line,"");
                //DataTable dt1 = SEL_SMT_MON_PROD_STATUS("C1", line, mline, "");
                if (dt != null && dt.Rows.Count > 0)
                {
                   
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    for (int j = 1; j < dt.Columns.Count; j++)
                    //    {
                    //        if (j > 2)
                    //        {
                    //            if (dt.Columns[j].ColumnName.Replace("'", "") == "RATE")
                    //                axfpSpread.SetText(j, i + 3, dt.Rows[i][j].ToString() == "" ? "" : Convert.ToDouble(dt.Rows[i][j].ToString()).ToString() + "%");
                    //            else
                    //                axfpSpread.SetText(j, i + 3, dt.Rows[i][j].ToString() == "" ? "" : Convert.ToDouble(dt.Rows[i][j].ToString()).ToString("###,###,###"));
                    //        }
                    //        else
                    //        {
                    //            axfpSpread.SetText(j, i + 3, dt.Rows[i][j].ToString());
                    //        }
                    //        if (j == dt.Columns.Count - 1)
                    //        {
                    //            axfpSpread.Row = i + 3;
                    //            axfpSpread.Col = j;
                    //            if (Convert.ToDouble(GetText(axfpSpread, j, i + 3).Replace("%", "").Trim()) < 95)
                    //            {
                    //                axfpSpread.BackColor = Color.Red;
                    //                axfpSpread.ForeColor = Color.White;
                    //            }
                    //            else if (Convert.ToDouble(GetText(axfpSpread, j, i + 3).Replace("%", "").Trim()) > 98)
                    //            {
                    //                axfpSpread.BackColor = Color.Green;
                    //                axfpSpread.ForeColor = Color.White;
                    //            }
                    //            else
                    //            {
                    //                axfpSpread.BackColor = Color.Yellow;
                    //                axfpSpread.ForeColor = Color.Black;
                    //            }

                    //        }
                    //    }
                    //}

                }
                bindingdatachart(chartControl1, dt_chart, "UPC_QTY", "UPC_TAR");
                bindingdatachart(chartControl2, dt_chart, "UPS1_QTY", "UPS1_TAR");
                bindingdatachart(chartControl3, dt_chart, "UPS2_QTY", "UPS2_TAR");
                bindingdatachart(chartControl4, dt_chart, "FSS_QTY", "FSS_TAR");
                bindingdatachart(chartControl5, dt_chart, "FGA_QTY", "FGA_TAR");
                int i_min = 0, i_max = 100;
                if (dt != null && dt.Rows.Count > 0)
                {
                    //if (GetText(axfpSpread, dt.Columns.Count - 1, 7).Replace("%", "").Trim() != "")
                    //{

                    //    if (Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1,7).Replace("%", "").Trim()) > 90 && Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 7).Replace("%", "").Trim()) < 100)
                    //    {
                    //        i_min = 90;
                    //        i_max = 100;
                    //    }
                    //    else if (Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 7).Replace("%", "").Trim()) < 90)
                    //    {
                    //        i_min = 90 - 3;
                    //        i_max = 100;
                    //    }
                    //    else if (Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 7).Replace("%", "").Trim()) > 100)
                    //    {
                    //        i_min = 90;
                    //        i_max = 100 + 3;
                    //    }
                    //    else if (Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 7).Replace("%", "").Trim()) == 0)
                    //    {
                    //        i_min = 0;
                    //        i_max = 100;
                    //    }
                    //    BindingGauges(circularGauge1, Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 7).Replace("%", "").Trim()), i_min, i_max, 95, 98);
                    //    lblRate.Text = Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 7).Replace("%", "").Trim()) + "%";
                    //}
                }
                else
                {
                    BindingGauges(circularGauge1, 0, 0, 100, 95, 98);
                    lblRate.Text = "0%";
                }
            }
            catch(Exception ex)
            {
                return;
            }
        }
        private void load_head()
        {
            try
            {
                DataTable dt = SEL_SMT_YEAR_PROD_STATUS("H", line, "");
                int i;
                if (dt != null && dt.Rows.Count > 0)
                {                    
                   
                    for (i = 0; i < dt.Rows.Count; i++)
                    {

                       
                    }
                }
                
            }
            catch
            {
            }
        }

        public DataTable SEL_SMT_YEAR_PROD_STATUS(string ARG_QTYPE, string ARG_LINE, string ARG_DATE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_MGL.SP_PROD_YEAR";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_FAC";
                MyOraDB.Parameter_Name[2] = "V_P_MLINE";
                MyOraDB.Parameter_Name[3] = "V_P_DATE";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_LINE;
                MyOraDB.Parameter_Values[2] = ARG_DATE;
                MyOraDB.Parameter_Values[3] = uc_year.GetValue().ToString();
                MyOraDB.Parameter_Values[4] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];


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
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            try
            {
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

        private void FRM_SMT_YEAR_PROD_V2_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                int_count = 19;
                timer2.Start();
            }
            else
                timer2.Stop();
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

        private void uc_year_ValueChangeEvent(object sender, EventArgs e)
        {
            load_data();
        }

    }
}
