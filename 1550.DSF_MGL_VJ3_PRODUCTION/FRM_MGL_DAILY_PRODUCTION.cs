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
        private DataTable SP_MGL_PRODUCTION_DATA_SELECT(string V_P_TYPE, string V_P_LINE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_MGL_VJ3.MGL_PRODUCTION_DATA_SELECT";
                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE_CD";
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
                    ComVar.Var.callForm = "1550";
                    break;
                case "W":
                    ComVar.Var.callForm = "1551";
                    break;
                case "M":
                    ComVar.Var.callForm = "1552";
                    break;
                case "Y":
                    ComVar.Var.callForm = "1553";
                    break;
            }
        }

        private void FRM_MGL_DAILY_PRODUCTION_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    lbltitle.Text = ComVar.Var._strValue1.Equals("TOT") ? "VJ1,VJ2 Support Production Status by Day" : ComVar.Var._strValue1 + " Support Production Status by Day";
                    cCount = 60;
                    switch (ComVar.Var._strValue1)
                    {
                        case "VJ2":
                            grdBandStit3.Visible = false;

                            tableLayoutPanel1.ColumnStyles[0].Width = 38.00F;
                            tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Percent;
                            tableLayoutPanel1.ColumnStyles[1].Width = 38.00F;
                            tableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.Percent;
                            tableLayoutPanel1.ColumnStyles[2].Width = 38.00F;
                            tableLayoutPanel1.ColumnStyles[2].SizeType = SizeType.Percent;
                            tableLayoutPanel1.ColumnStyles[3].Width = 0;
                            tableLayoutPanel1.ColumnStyles[3].SizeType = SizeType.Percent;
                            break;
                        default:
                            grdBandStit3.Visible = true;
                            tableLayoutPanel1.ColumnStyles[0].Width = 25.00F;
                            tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Percent;
                            tableLayoutPanel1.ColumnStyles[1].Width = 25.00F;
                            tableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.Percent;
                            tableLayoutPanel1.ColumnStyles[2].Width = 25.00F;
                            tableLayoutPanel1.ColumnStyles[2].SizeType = SizeType.Percent;
                            tableLayoutPanel1.ColumnStyles[3].Width = 25.00F;
                            tableLayoutPanel1.ColumnStyles[3].SizeType = SizeType.Percent;
                            break;
                    }
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
                dt = SP_MGL_PRODUCTION_DATA_SELECT("Q", ComVar.Var._strValue1);
                grdBase.DataSource = dt;
                for (int i = 0; i < bdgrdView.Columns.Count; i++)
                {
                    bdgrdView.Columns[i].OptionsColumn.ReadOnly = true;
                    bdgrdView.Columns[i].OptionsColumn.AllowEdit = false;
                    bdgrdView.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 18f, FontStyle.Regular);
                    bdgrdView.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    if (bdgrdView.Columns[i].FieldName.Contains("TAR") || bdgrdView.Columns[i].FieldName.Contains("ACT"))
                    {
                        bdgrdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        bdgrdView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        bdgrdView.Columns[i].DisplayFormat.FormatString = "#,#.#";
                        bdgrdView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    }
                }
                BindingChart();
            }
            catch
            {
            }
        }

        private void BindingChart()
        {
            InitChart("UPC", dt, chartUPC); InitChart("UPS1", dt, chartUPS1); InitChart("UPS2", dt, chartUPS2); InitChart("UPS3", dt, chartUPS3);
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
                if (bdgrdView.GetRowCellValue(e.RowHandle, "HMS").ToString().Contains("TOTAL"))
                {
                    e.Appearance.BackColor = Color.Orange;
                    e.Appearance.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            { }
        }

    }
}
