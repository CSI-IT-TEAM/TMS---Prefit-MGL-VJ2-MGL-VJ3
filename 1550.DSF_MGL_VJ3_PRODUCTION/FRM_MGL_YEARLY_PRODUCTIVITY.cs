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
using DevExpress.XtraCharts;
using DevExpress.XtraGauges.Core.Model;

namespace FORM
{
    public partial class FRM_MGL_YEARLY_PRODUCTIVITY : Form
    {
        public FRM_MGL_YEARLY_PRODUCTIVITY()
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
        UC.UC_DWMY uc = new UC.UC_DWMY(4,""); //Hiển thị 4 Button, Button Day thì Disable
        #endregion
        Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        int cCount = 0;

        public DataTable SMT_PROD_YEARLY_SELECT(string ARG_TYPE, string ARG_DATE, string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_MGL_VJ3.SMT_PRODUCTIVITY_YEARLY_SELECT";
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
                MyOraDB.Parameter_Values[0] = ARG_TYPE;
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
                    ComVar.Var.callForm = "1562";
                    break;
                case "Y":
                    ComVar.Var.callForm = "1563";
                    break;
            }
        }

        private void BindingData()
        {
            //formatband();
            bandYear.Caption = DateTime.Now.ToString("yyyy"); string curr_month = DateTime.Now.ToString("MM");
            dt = SMT_PROD_YEARLY_SELECT("Q", uc_year.GetValue().ToString(), line, mline);
            grdView.DataSource = dt;
            foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand band in gvwView.Bands[1].Children)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (band.Name.Contains(curr_month))
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

                }
            }
            for (int i = 0; i < gvwView.Columns.Count; i++)
            {
                if (i == 0)
                {
                    gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                }

                if (i > 0 && i < gvwView.Columns.Count - 1)
                {
                    gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    gvwView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gvwView.Columns[i].DisplayFormat.FormatString = "#,0.##";
                }

            }
        }

        private void BindingChart()
        {
            DataTable dt = SMT_PROD_YEARLY_SELECT("C", uc_year.GetValue().ToString(), line, mline);
            InitChart("UPC", dt, chartUPC); InitChart("UPS1", dt, chartUPS1); InitChart("UPS2", dt, chartUPS2); InitChart("UPS3", dt, chartUPS3);
        }

        private void InitChart(string sChart, DataTable dt, DevExpress.XtraCharts.ChartControl chartControl)
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
                chartControl.DataSource = dt.Select("DAY <>'AVG'").CopyToDataTable();
                chartControl.Series[1].ArgumentDataMember = "DAY";
                chartControl.Series[1].ValueDataMembers.AddRange(new string[] { sChart + "_TAR" });
                chartControl.Series[0].ArgumentDataMember = "DAY";
                chartControl.Series[0].ValueDataMembers.AddRange(new string[] { sChart + "_ACT" });
                ((DevExpress.XtraCharts.XYDiagram)chartControl.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                if (!sChart.Equals("UPC"))
                {
                    chartTitle.Text = sTitle[Convert.ToInt32(sChart.Substring(3, 1)) - 1];
                    chartControl.Titles.Clear();
                    chartControl.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle });
                }

            }
            catch { }
            finally { BindingGauge(dt); }
        }
        private void BindingGauge(DataTable dt)
        {
            lblTitleProd.Text = "POD: 0";
            arcScale.EnableAnimation = false;
            arcScale.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseIn;
            arcScale.EasingFunction = new BackEase();
            arcScale.Value = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    arcScale.Ranges[0].StartValue = 6;
                    arcScale.Ranges[0].EndValue = arcScale.Ranges[1].StartValue = Convert.ToSingle(dt.Rows[0]["R_MIN"]); ;
                    arcScale.Ranges[1].EndValue = arcScale.Ranges[2].StartValue = Convert.ToSingle(dt.Rows[0]["R_MAX"]); ;
                    arcScale.Ranges[2].EndValue = 12;

                    DataTable dtG = dt.Select("Day = 'AVG'").CopyToDataTable();
                    arcScale.EnableAnimation = true;
                    arcScale.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                    arcScale.EasingFunction = new BackEase();
                    double num = Convert.ToDouble(dtG.Rows[0]["POD"]);
                    arcScale.Value = (float)num;

                    lblRed.Text = "<" + dt.Rows[0]["R_MIN"].ToString();
                    lblYellow.Text = dt.Rows[0]["R_MIN"].ToString() + " ~ " + dt.Rows[0]["R_MAX"].ToString();
                    lblGreen.Text = ">" + dt.Rows[0]["R_MAX"].ToString();
                    lblTitleProd.Text = "POD: " + num.ToString();
                    
                }
                catch
                { }
            }
        }
        private void tmr_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cCount++;
            if (cCount >= 30)
            {
                this.Cursor = Cursors.WaitCursor;
                BindingData();
                BindingChart();
                cCount = 0;
                this.Cursor = Cursors.Default;
            }
        }

        private void FRM_PROD_STATUS_DAILY_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                lbltitle.Text = ComVar.Var._strValue1.Equals("TOT") ? "VJ1,VJ2 Support Productivity Status by Year" : ComVar.Var._strValue1 + " Support Productivity  Status by Year";
                lang = ComVar.Var._strValue3;
                uc.YMD_Change(4,lang);
                cCount = 30 - 1;
                line = ComVar.Var._strValue1; mline = ComVar.Var._strValue2; 
                //line = "001"; mline = ComVar.Var._strValue1;
                switch (line)
                {
                    case "VJ2":
                        // grdBandStit3.Visible = false;
                        //chartUPS3.Visible = false;
                        tblMain2.ColumnStyles[0].Width = 38.00F;
                        tblMain2.ColumnStyles[0].SizeType = SizeType.Percent;
                        tblMain2.ColumnStyles[1].Width = 38.00F;
                        tblMain2.ColumnStyles[1].SizeType = SizeType.Percent;
                        tblMain2.ColumnStyles[2].Width = 0;
                        tblMain2.ColumnStyles[2].SizeType = SizeType.Percent;
                        break;
                    default:
                        // grdBandStit3.Visible = true;
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
                //        lbltitle.Text = "Tình trạng năng suất theo năm";
                //        break;
                //    case "En":
                //        lang = "En";
                //        lbltitle.Text = "Productivity Status by Year";
                //        break;
                //    default:
                //        lbltitle.Text = "Productivity Status by Year";
                //        break;

                //}
                tmr.Start();
            }
            else
                tmr.Stop();

        }

        private void bdgrdView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {


                if (gvwView.GetRowCellValue(e.RowHandle, "DIV").ToString().Contains("POD"))
                {
                    e.Appearance.BackColor = Color.FromArgb(254, 255, 198);
                    e.Appearance.ForeColor = Color.Black;
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
               
            }
            catch (Exception ex)
            { }
        }

        private void formatband()
        {
            try
            {
                int n;
                DataTable dtsource = null;
                dtsource = SMT_PROD_YEARLY_SELECT("H", uc_year.GetValue().ToString(), line, mline); ;
                if (dtsource != null && dtsource.Rows.Count > 0)
                {
                    string name;
                    bandYear.Caption = dtsource.Rows[0]["MON"].ToString();
                    if (dtsource.Rows.Count > 0)
                    {
                        foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand band in gvwView.Bands[1].Children)
                        {
                            double num;
                            if (double.TryParse(band.Caption, out num))
                            {
                                for (int i = 0; i < dtsource.Rows.Count; i++)
                                {
                                    if (band.Name.Contains(dtsource.Rows[i][0].ToString().Substring(dtsource.Rows[i][0].ToString().Length - 2)))
                                    {
                                        band.Visible = true;
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
                    //bandDate.Width = 140;
                    //bandAVG.Width = 80;
                    //bandMon.Width = (grdView.Width - 220) / dtsource.Rows.Count;
                    //gvwView.OptionsView.ColumnAutoWidth = false;
                }
            }
            catch
            {
                return;
            }
        }



        private void chart_CustomDrawAxisLabel(object sender, DevExpress.XtraCharts.CustomDrawAxisLabelEventArgs e)
        {
            try
            {
                AxisBase axis = e.Item.Axis;
                if (axis is AxisX)
                {
                    e.Item.Text = e.Item.Text.Substring(0, 1);
                    e.Item.TextColor = Color.Green;
                    e.Item.EnableAntialiasing = DefaultBoolean.True;
                }
            }
            catch { }
        }

        private void uc_month_ValueChangeEvent(object sender, EventArgs e)
        {

        }
    }
}
