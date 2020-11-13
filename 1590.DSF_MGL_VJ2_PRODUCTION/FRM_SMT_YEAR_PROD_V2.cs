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
    public partial class FRM_SMT_YEAR_PROD_V2 : Form
    {
        public FRM_SMT_YEAR_PROD_V2()
        {
            InitializeComponent();
        }
        int indexScreen;
        string line, mline;
        public FRM_SMT_YEAR_PROD_V2(string title, int _indexScreen, string _line, string _mline)
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClassLib.ComCtl.Form_Maximized(this, indexScreen); //2 man hinh tro len
            //load_data();
            //CreateChart();
        }
       
        private void ClearGrid(AxFPSpreadADO.AxfpSpread Grid)
        {
            for (int irow = 3; irow <= Grid.MaxRows; irow++)
            {
                Grid.Row = irow;
                for (int icol = 1; icol <= Grid.MaxCols; icol++)
                {
                    Grid.Col = icol;
                    //Grid.SetText(icol, irow, "");
                    switch (irow % 2)
                    {
                        case 0:
                            Grid.BackColor = BackColor1;
                            Grid.ForeColor = Color.Black;
                            break;
                        case 1:
                            Grid.BackColor = BackColor2;
                            Grid.ForeColor = Color.Black;
                            break;
                    }
                    Grid.Font = new Font("Calibri", 14, FontStyle.Regular);
                }

                axfpSpread.set_RowHeight(irow, 30);
            }
            axfpSpread.RowsFrozen = 2;
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

        private string GetText(AxFPSpreadADO.AxfpSpread spread, int col, int row)
        {
            try
            {
                object data = null;
                spread.GetText(col, row, ref data);
                return data.ToString();
            }
            catch (Exception ex)
            {
                //return "";
                //log.Error(ex);
                return null;
            }

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
                    axfpSpread.MaxRows = dt.Rows.Count + 2;
                    ClearGrid(axfpSpread);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 1; j < dt.Columns.Count; j++)
                        {
                            if (j > 2)
                            {
                                if (dt.Columns[j].ColumnName.Replace("'", "") == "RATE")
                                    axfpSpread.SetText(j, i + 3, dt.Rows[i][j].ToString() == "" ? "" : Convert.ToDouble(dt.Rows[i][j].ToString()).ToString() + "%");
                                else
                                    axfpSpread.SetText(j, i + 3, dt.Rows[i][j].ToString() == "" ? "" : Convert.ToDouble(dt.Rows[i][j].ToString()).ToString("###,###,###"));
                            }
                            else
                            {
                                axfpSpread.SetText(j, i + 3, dt.Rows[i][j].ToString());
                            }
                            if (j == dt.Columns.Count - 1)
                            {
                                axfpSpread.Row = i + 3;
                                axfpSpread.Col = j;
                                if (Convert.ToDouble(GetText(axfpSpread, j, i + 3).Replace("%", "").Trim()) < 95)
                                {
                                    axfpSpread.BackColor = Color.Red;
                                    axfpSpread.ForeColor = Color.White;
                                }
                                else if (Convert.ToDouble(GetText(axfpSpread, j, i + 3).Replace("%", "").Trim()) > 98)
                                {
                                    axfpSpread.BackColor = Color.Green;
                                    axfpSpread.ForeColor = Color.White;
                                }
                                else
                                {
                                    axfpSpread.BackColor = Color.Yellow;
                                    axfpSpread.ForeColor = Color.Black;
                                }

                            }
                        }
                    }

                }
                bindingdatachart(chartControl1, dt_chart, "UPC_QTY", "UPC_TAR");
                bindingdatachart(chartControl2, dt_chart, "UPS1_QTY", "UPS1_TAR");
                bindingdatachart(chartControl3, dt_chart, "UPS2_QTY", "UPS2_TAR");
                bindingdatachart(chartControl4, dt_chart, "FSS_QTY", "FSS_TAR");
                bindingdatachart(chartControl5, dt_chart, "FGA_QTY", "FGA_TAR");
                int i_min = 0, i_max = 100;
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (GetText(axfpSpread, dt.Columns.Count - 1, 7).Replace("%", "").Trim() != "")
                    {

                        if (Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1,7).Replace("%", "").Trim()) > 90 && Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 7).Replace("%", "").Trim()) < 100)
                        {
                            i_min = 90;
                            i_max = 100;
                        }
                        else if (Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 7).Replace("%", "").Trim()) < 90)
                        {
                            i_min = 90 - 3;
                            i_max = 100;
                        }
                        else if (Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 7).Replace("%", "").Trim()) > 100)
                        {
                            i_min = 90;
                            i_max = 100 + 3;
                        }
                        else if (Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 7).Replace("%", "").Trim()) == 0)
                        {
                            i_min = 0;
                            i_max = 100;
                        }
                        BindingGauges(circularGauge1, Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 7).Replace("%", "").Trim()), i_min, i_max, 95, 98);
                        lblRate.Text = Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 7).Replace("%", "").Trim()) + "%";
                    }
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
                    //axfpSpread.SetText(1, 1, dt.Rows[0]["MON"].ToString());
                   // axfpSpread.set_ColWidth(1, 16.5);
                  //  axfpSpread.set_ColWidth(2, 226);
                    for (i = 0; i < dt.Rows.Count; i++)
                    {

                        if (dt.Rows[i]["CUR"].ToString() == "1")
                        {
                            axfpSpread.Row = 1;
                            axfpSpread.Col = i + 3;
                            axfpSpread.BackColor = Color.Salmon;
                            axfpSpread.Row = 2;
                            axfpSpread.Col = i + 3;
                            axfpSpread.BackColor = Color.Salmon;
                            
                        }
                        //axfpSpread.AddCellSpan(i + 2, 1, 1, 1);
                        axfpSpread.SetText(i + 3, 1, dt.Rows[i]["YEAR"].ToString());
                        axfpSpread.SetText(i + 3, 2, dt.Rows[i]["MON"].ToString());
                       // axfpSpread.set_ColWidth(i + 3, (double)221 / (double)(dt.Rows.Count));
                        //axfpSpread.set_ColWidth(i + 2, 240 / 27 + 0.3);
                        //axfpSpread.set_ColWidth(i + 2, (axfpSpread.Width-axfpSpread.get_ColWidth(1))/dt.Rows.Count);
                    }
                    //axfpSpread.set_ColWidth(1, 17.7 + 220 - axfpSpread.get_ColWidth(i + 1) * dt.Rows.Count);
                    axfpSpread.AddCellSpan(dt.Rows.Count + 2, 1, 1, 2);
                    axfpSpread.AddCellSpan(dt.Rows.Count + 1, 1, 1, 2);
                    axfpSpread.AddCellSpan(dt.Rows.Count, 1, 1, 2);
                    //axfpSpread.set_ColWidth(1, 16.4 + 0.1 * 25 / dt.Rows.Count ); 
                    for ( int j = i + 3; j<= axfpSpread.MaxCols;j++)
                    {
                        axfpSpread.set_ColWidth(j,0);
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form fc = Application.OpenForms["FORM_SMT_PROD_DAILY_MGL"];
            if (fc != null)
                fc.Close();


            string Caption = "Production Status by Day";
            //switch (Lang)
            //{
            //    case "Vn":
            //        Caption = "Trạng thái sản xuất theo Ngày";
            //        break;
            //    default:
            //        Caption = "Production Status by Day";
            //        break;
            //}


            FORM_SMT_PROD_DAILY_MGL f = new FORM_SMT_PROD_DAILY_MGL(Caption, 1, line, mline);
            f.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form fc = Application.OpenForms["FRM_SMT_WEEKLY_PROD_V2"];
            if (fc != null)
                fc.Close();

            string Caption = "Production Status by Week";
            //switch (Lang)
            //{
            //    case "Vn":
            //        Caption = "Trạng thái sản xuất theo Tuần";
            //        break;
            //    default:
            //        Caption = "Production Status by Week";
            //        break;
            //}

            FRM_SMT_WEEKLY_PROD_V2 f = new FRM_SMT_WEEKLY_PROD_V2(Caption, 1, line, mline);
            f.Show();
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form fc = Application.OpenForms["FRM_SMT_MON_PROD_V2"];
            if (fc != null)
                fc.Close();

            string Caption = "Production Status by Month";
            //switch (Lang)
            //{
            //    case "Vn":
            //        Caption = "Trạng thái sản xuất theo Tháng";
            //        break;
            //    default:
            //        Caption = "Production Status by Month";
            //        break;
            //}

            FRM_SMT_MON_PROD_V2 f = new FRM_SMT_MON_PROD_V2(Caption, 1, line, mline);
            f.Show();
        }

        private void uc_year_ValueChangeEvent(object sender, EventArgs e)
        {
            load_data();
        }

    }
}
