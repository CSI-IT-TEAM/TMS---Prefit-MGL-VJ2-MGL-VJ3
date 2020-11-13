using DevExpress.Data.Utils;
using DevExpress.Utils;
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
    public partial class FRM_MGL_DAILY_PRODUCTIVITY_S : Form
    {
        public FRM_MGL_DAILY_PRODUCTIVITY_S()
        {
            InitializeComponent();
        }
        private DataTable MGL_PRODUCTIVITY_DATA_SELECT(string V_P_TYPE, string V_P_LINE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_MGL_VJ2.MGL_PRODUCTIVITY_DAY_SUPPORT";
                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";
                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = V_P_TYPE;
                MyOraDB.Parameter_Values[1] = V_P_LINE;
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
        #region UC
        UC.UC_DWMY uc = new UC.UC_DWMY(1, ""); //Hiển thị 4 Button, Button Day thì Disable
        #endregion
        Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        DataTable dt = null;
        string lang = "";
        int cCount = 0;
        private void FRM_MGL_DAILY_PRODUCTIVITY_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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
                    ComVar.Var.callForm = "1610";
                    break;
                case "W":
                    ComVar.Var.callForm = "1611";
                    break;
                case "M":
                    ComVar.Var.callForm = "1612";
                    break;
                case "Y":
                    ComVar.Var.callForm = "1613";
                    break;
            }
        }
        private void BindingData4Grid()
        {
            try
            {
                dt = MGL_PRODUCTIVITY_DATA_SELECT("Q", ComVar.Var._strValue1);
                grdBase.DataSource = dt;
                for (int i = 0; i < bdgrdView.Columns.Count; i++)
                {
                    bdgrdView.Columns[i].OptionsColumn.ReadOnly = true;
                    bdgrdView.Columns[i].OptionsColumn.AllowEdit = false;
                    bdgrdView.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 20f);
                    bdgrdView.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    //if (bdgrdView.Columns[i].FieldName.Contains("TAR") || bdgrdView.Columns[i].FieldName.Contains("ACT"))
                    //{
                    //    bdgrdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    //    bdgrdView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    //    bdgrdView.Columns[i].DisplayFormat.FormatString = "#,#.#";
                    //    bdgrdView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    //}
                }
                BindingChart();
            }
            catch { }
        }
        private void BindingChart()
        {
            InitChart("UPC", dt, chartUPC); InitChart("UPS1", dt, chartUPS1); InitChart("UPS2", dt, chartUPS2); InitChart("UPS3", dt, chartUPS3);
        }

        private void InitChart(string sChart, DataTable dt, DevExpress.XtraCharts.ChartControl chartControl)
        {
            try
            {

                DevExpress.XtraCharts.ChartTitle chartTitle = new DevExpress.XtraCharts.ChartTitle();
                chartControl.DataSource = dt.Select("HMS <>'TOTAL'").CopyToDataTable();
                chartControl.Series[0].ArgumentDataMember = "HMS";
                chartControl.Series[0].ValueDataMembers.AddRange(new string[] { sChart + "_RATE1" });
                ((DevExpress.XtraCharts.XYDiagram)chartControl.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                //if (!sChart.Equals("UPC"))
                //{
                //    chartTitle.Text = sTitle[Convert.ToInt32(sChart.Substring(3, 1)) - 1];
                //    chartControl.Titles.Clear();
                //    chartControl.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle });
                //}
            }
            catch { }
            finally
            {
                BindingGauge(dt);
            }
        }
        private void BindingGauge(DataTable arg_dt)
        {
            lblTitleProd.Text = "POD: 0";
            arcScaleComponent1.EnableAnimation = false;

            arcScaleComponent1.Value = 0;
            if (arg_dt != null && arg_dt.Rows.Count > 0)
            {
                try
                {
                    //arcScaleComponent1.Ranges[0].StartValue = 6;
                    //arcScaleComponent1.Ranges[0].EndValue = 8;
                    //arcScaleComponent1.Ranges[1].EndValue = 9;
                    //arcScaleComponent1.Ranges[2].EndValue = 12;
                    arcScaleComponent1.MinValue = 1;
                    arcScaleComponent1.MaxValue = 15;
                    DataTable dt = arg_dt.Select("HMS = 'TOTAL'").CopyToDataTable();
                    arcScaleComponent1.EnableAnimation = true;
                    arcScaleComponent1.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                    double num = Convert.ToDouble(dt.Rows[0]["POD"]);
                    arcScaleComponent1.Value = (float)num;

                    lblRed.Text = "<" + arg_dt.Rows[0]["R_MIN"].ToString();
                    lblYellow.Text = arg_dt.Rows[0]["R_MIN"].ToString() + " ~ " + arg_dt.Rows[0]["R_MAX"].ToString();
                    lblGreen.Text = ">" + arg_dt.Rows[0]["R_MAX"].ToString();
                    lblTitleProd.Text = "POD: " + num.ToString();
                }
                catch (Exception ex)
                { }
            }
        }
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

        private void FRM_MGL_DAILY_PRODUCTIVITY_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                lbltitle.Text = ComVar.Var._strValue1.Equals("TOTAL1") ? "VJ1 Support Productivity Status by Day" : ComVar.Var._strValue2 + " Productivity  Status by Day";
                cCount = 60;
                lang = ComVar.Var._strValue3;
                uc.YMD_Change(1, lang);
                switch (ComVar.Var._strValue1)
                {
                    case "099":
                        grdBandStit3.Visible = false;
                        tblChartStit.ColumnStyles[0].Width = 38.00F;
                        tblChartStit.ColumnStyles[0].SizeType = SizeType.Percent;
                        tblChartStit.ColumnStyles[1].Width = 38.00F;
                        tblChartStit.ColumnStyles[1].SizeType = SizeType.Percent;
                        tblChartStit.ColumnStyles[2].Width = 0;
                        tblChartStit.ColumnStyles[2].SizeType = SizeType.Percent;
                        break;
                    default:
                        grdBandStit3.Visible = true;
                        tblChartStit.ColumnStyles[0].Width = 25.00F;
                        tblChartStit.ColumnStyles[0].SizeType = SizeType.Percent;
                        tblChartStit.ColumnStyles[1].Width = 25.00F;
                        tblChartStit.ColumnStyles[1].SizeType = SizeType.Percent;
                        tblChartStit.ColumnStyles[2].Width = 25.00F;
                        tblChartStit.ColumnStyles[2].SizeType = SizeType.Percent;
                        break;
                }
                tmr.Start();
            }
            else
                tmr.Stop();
        }
        private void bdgrdView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {


                if (bdgrdView.GetRowCellValue(e.RowHandle, "HMS").ToString().Contains("CURR"))
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.ForeColor = Color.White;
                }

                if (e.Column.FieldName.Contains("RATE"))
                {
                    if (e.CellValue.ToString().Contains("G"))
                    {
                        e.Appearance.BackColor = Color.LimeGreen;
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
                if (bdgrdView.GetRowCellValue(e.RowHandle, "HMS").ToString().Contains("TOTAL"))
                {
                    e.Appearance.BackColor = Color.FromArgb(254, 255, 198);
                    e.Appearance.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
