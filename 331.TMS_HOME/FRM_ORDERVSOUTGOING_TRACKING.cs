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
using DevExpress.XtraGrid.Views.Grid;

namespace FORM
{
    public partial class FRM_ORDERVSOUTGOING_TRACKING : Form
    {
        public FRM_ORDERVSOUTGOING_TRACKING()
        {
            InitializeComponent();
        }
        #region Variable
        string VDateF, VDateT, VLine, VTrip;
        int currhour = 0;
        private MyCellMergeHelper _Helper;
        #endregion
        private DataSet SELECT_DATA(string WorkType, string DateF, string DateT, string Line, string Trip)
        {
            System.Data.DataSet retDS;
            COM.OraDB MyOraDB = new COM.OraDB(1); //1.LMES , 2.SEPHIROTH

            MyOraDB.ReDim_Parameter(14);
            MyOraDB.Process_Name = "P_GMES0262_Q_PHUOCTEST";

            MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[5] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[6] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[7] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[8] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[9] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[10] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[11] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[12] = (char)OracleType.Cursor;
            MyOraDB.Parameter_Type[13] = (char)OracleType.Cursor;

            MyOraDB.Parameter_Name[0] = "V_P_WORK_TYPE";
            MyOraDB.Parameter_Name[1] = "V_P_DATEF";
            MyOraDB.Parameter_Name[2] = "V_P_DATET";
            MyOraDB.Parameter_Name[3] = "V_P_LINE_CD";
            MyOraDB.Parameter_Name[4] = "V_P_TRIP";
            MyOraDB.Parameter_Name[5] = "V_P_ERROR_CODE";
            MyOraDB.Parameter_Name[6] = "V_P_ROW_COUNT";
            MyOraDB.Parameter_Name[7] = "V_P_ERROR_NOTE";
            MyOraDB.Parameter_Name[8] = "V_P_RETURN_STR";
            MyOraDB.Parameter_Name[9] = "V_P_ERROR_STR";
            MyOraDB.Parameter_Name[10] = "V_ERRORSTATE";
            MyOraDB.Parameter_Name[11] = "V_ERRORPROCEDURE";
            MyOraDB.Parameter_Name[12] = "OUT_CURSOR";
            MyOraDB.Parameter_Name[13] = "OUT_CURSOR1";

            MyOraDB.Parameter_Values[0] = WorkType;
            MyOraDB.Parameter_Values[1] = DateF;
            MyOraDB.Parameter_Values[2] = DateT;
            MyOraDB.Parameter_Values[3] = Line;
            MyOraDB.Parameter_Values[4] = Trip;
            MyOraDB.Parameter_Values[5] = "";
            MyOraDB.Parameter_Values[6] = "";
            MyOraDB.Parameter_Values[7] = "";
            MyOraDB.Parameter_Values[8] = "";
            MyOraDB.Parameter_Values[9] = "";
            MyOraDB.Parameter_Values[10] = "";
            MyOraDB.Parameter_Values[11] = "";
            MyOraDB.Parameter_Values[12] = "";
            MyOraDB.Parameter_Values[13] = "";

            MyOraDB.Add_Select_Parameter(true);
            retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;
            return retDS;
        }
        private void MarkTripButton()
        {
            foreach (DevExpress.XtraEditors.SimpleButton btn in pnTrip.Controls)
            {
                if (btn.Tag.ToString().Equals(VTrip))
                    btn.Appearance.ForeColor = Color.Blue;
            }
        }
        private void Trip_set()
        {
            foreach (DevExpress.XtraEditors.SimpleButton btn in pnTrip.Controls)
            {
                btn.Appearance.ForeColor = Color.Black;
            }
            currhour = Int32.Parse(DateTime.Now.ToString("HHmm"));
            if ((currhour >= 545) && (currhour < 745))
            {
                VTrip = "001";
                lblTripTime.Text = "05:45";

            }
            else if ((currhour >= 730) && (currhour < 945))
            {
                VTrip = "002";
                lblTripTime.Text = "07:30";
            }
            else if ((currhour >= 945) && (currhour < 1145))
            {
                VTrip = "003";
                lblTripTime.Text = "09:45";

            }
            else if (currhour >= 1145)
            {
                VTrip = "004";
                lblTripTime.Text = "11:45";
            }
            MarkTripButton();
        }
        private void LoadControl()
        {
            VDateF = DateTime.Now.AddDays(-6).ToString("yyyyMMdd");
            VDateT = DateTime.Now.ToString("yyyyMMdd");
            VLine = "201";
            VTrip = "001";
        }

        private bool loadchart(DataTable dtchart)
        {
            try
            {
                chart.DataSource = dtchart;
                chart.Series[0].ArgumentDataMember = "YMD";
                chart.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                for (int i = 0; i < dtchart.Rows.Count; i++)
                {
                    if (Convert.ToDouble(dtchart.Rows[i]["QTY"]) == 0)
                    {
                        chart.Series[0].Points[i].Color = Color.White;
                    }
                }
                ((XYDiagram)chart.Diagram).AxisX.Label.Staggered = false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        private void loadgrid(DataTable dtgrid)
        {
            grdBase.DataSource = dtgrid;
            Format_Grid();
        }
        private void Format_Grid()
        {
            try
            {
                gvwBase.BeginUpdate();
                #region replace
                for (int i = 0; i <= gvwBase.RowCount - 1; i++)
                {
                    if (gvwBase.GetRowCellValue(i, gvwBase.Columns["CMP1"]).ToString() == "SET_ORDER")
                    {
                        gvwBase.SetRowCellValue(i, gvwBase.Columns["CMP1"], "Order By Set (Prs)");
                    }
                    if (gvwBase.GetRowCellValue(i, gvwBase.Columns["CMP2"]).ToString() == "SET_ORDER")
                    {
                        gvwBase.SetRowCellValue(i, gvwBase.Columns["CMP2"], "Order By Set (Prs)");
                    }


                    if (gvwBase.GetRowCellValue(i, gvwBase.Columns["CMP1"]).ToString() == "SET_OUT")
                    {
                        gvwBase.SetRowCellValue(i, gvwBase.Columns["CMP1"], "Outgoing By Set (Prs)");
                    }
                    if (gvwBase.GetRowCellValue(i, gvwBase.Columns["CMP2"]).ToString() == "SET_OUT")
                    {
                        gvwBase.SetRowCellValue(i, gvwBase.Columns["CMP2"], "Outgoing By Set (Prs)");
                    }

                    if (gvwBase.GetRowCellValue(i, gvwBase.Columns["CMP1"]).ToString() == "PER")
                    {
                        gvwBase.SetRowCellValue(i, gvwBase.Columns["CMP1"], "%");
                    }
                    if (gvwBase.GetRowCellValue(i, gvwBase.Columns["CMP2"]).ToString() == "PER")
                    {
                        gvwBase.SetRowCellValue(i, gvwBase.Columns["CMP2"], "%");
                    }

                    if (gvwBase.GetRowCellValue(i, gvwBase.Columns["CMP1"]).ToString() == "OUT_IN_ORDER")
                    {
                        gvwBase.SetRowCellValue(i, gvwBase.Columns["CMP1"], "Detail (Out = Order) ");
                    }
                    if (gvwBase.GetRowCellValue(i, gvwBase.Columns["CMP1"]).ToString() == "OUT_NOT_ORDER")
                    {
                        gvwBase.SetRowCellValue(i, gvwBase.Columns["CMP1"], "Detail (Out <> Order)");
                    }
                    if (gvwBase.GetRowCellValue(i, gvwBase.Columns["CMP2"]).ToString().Contains("Y"))
                    {
                        gvwBase.SetRowCellValue(i, gvwBase.Columns["CMP2"], gvwBase.GetRowCellValue(i, gvwBase.Columns["CMP2"]).ToString().Replace("-Y", ""));
                    }

                    if (gvwBase.GetRowCellValue(i, gvwBase.Columns["CMP2"]).ToString().Contains("N"))
                    {
                        gvwBase.SetRowCellValue(i, gvwBase.Columns["CMP2"], gvwBase.GetRowCellValue(i, gvwBase.Columns["CMP2"]).ToString().Replace("-N", ""));
                    }


                }

                #endregion replace

                _Helper = new MyCellMergeHelper(gvwBase);
                _Helper.AddMergedCell(0, 0, 1, "Order By Set (Prs)");
                _Helper.AddMergedCell(1, 0, 1, "Outgoing By Set (Prs)");
                _Helper.AddMergedCell(2, 0, 1, "%");


                for (int i = 0; i < gvwBase.Columns.Count; i++)
                {
                    gvwBase.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                    gvwBase.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    gvwBase.Columns[i].OptionsFilter.AllowFilter = false;
                    gvwBase.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

                    gvwBase.ColumnPanelRowHeight = 25;
                    gvwBase.RowHeight = 25;
                    gvwBase.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    if (i <= 1)
                    {
                        gvwBase.Columns[i].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                        gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    }
                    else
                    {
                        gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                        gvwBase.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gvwBase.Columns[i].DisplayFormat.FormatString = "#,###.##";
                    }


                    gvwBase.Columns[i].Caption = gvwBase.Columns[i].FieldName.ToString().Replace("'", "");


                }
                gvwBase.Columns[0].Caption = gvwBase.Columns[0].FieldName.ToString().Replace("CMP1", "Item");
                gvwBase.Columns[1].Caption = gvwBase.Columns[1].FieldName.ToString().Replace("CMP2", "Div");

                gvwBase.Appearance.Row.Font = new System.Drawing.Font("DotumChe", 10F, System.Drawing.FontStyle.Regular);
                gvwBase.BestFitColumns();

                // gvwBase.OptionsView.ColumnAutoWidth = false;
                gvwBase.EndUpdate();
            }
            catch { }
        }
        private void gvwBase_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            double temp = 0.0;

            if (gvwBase.GetRowCellDisplayText(e.RowHandle, gvwBase.Columns["CMP1"]).ToString() == "%")
            {
                if (e.Column.AbsoluteIndex >= 2 && e.CellValue != null)
                {
                    double.TryParse(e.CellValue.ToString(), out temp); //out
                    if (temp > 0 && temp < 95)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else if (temp >= 95 && temp < 98)
                    {

                        e.Appearance.BackColor = Color.Yellow;
                        e.Appearance.ForeColor = Color.Black;
                    }
                    else if (temp >= 98)
                    {

                        e.Appearance.BackColor = Color.FromArgb(0, 192, 0);
                        e.Appearance.ForeColor = Color.White;
                    }
                }

            }
        }
        private void FRM_ORDERVSOUTGOING_TRACKING_Load(object sender, EventArgs e)
        {

            splashScreenManager1.ShowWaitForm();
            try
            {
                LoadControl();
                btnLD.BackColor = Color.Yellow;
                VLine = "201";
                Trip_set();
                DataSet ds = SELECT_DATA("Q", VDateF, VDateT, VLine, VTrip);
                DataTable dtGrid = new DataTable();
                DataTable dtChart = new DataTable();
                dtGrid = ds.Tables[0];
                loadgrid(dtGrid);
                dtChart = ds.Tables[1];
                loadchart(dtChart);
                splashScreenManager1.CloseWaitForm();
            }
            catch { splashScreenManager1.CloseWaitForm(); }

        }

        private void btnTrip_Click(object sender, EventArgs e)
        {
            VTrip = ((DevExpress.XtraEditors.SimpleButton)sender).Tag.ToString();
            switch (VTrip)
            {
                case "001":
                    lblTripTime.Text = "05:45";
                    break;
                case "002":
                    lblTripTime.Text = "07:30";
                    break;
                case "003":
                    lblTripTime.Text = "09:45";
                    break;
                case "004":
                    lblTripTime.Text = "11:45";
                    break;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                splashScreenManager1.ShowWaitForm();
                DataSet ds = SELECT_DATA("Q", VDateF, VDateT, VLine, VTrip);
                DataTable dtGrid = new DataTable();
                DataTable dtChart = new DataTable();
                dtGrid = ds.Tables[0];
                loadgrid(dtGrid);
                dtChart = ds.Tables[1];
                loadchart(dtChart);
                splashScreenManager1.CloseWaitForm();
                this.Cursor = Cursors.Default;
            }
            catch { splashScreenManager1.CloseWaitForm(); this.Cursor = Cursors.Default; }
            try
            {
                foreach (DevExpress.XtraEditors.SimpleButton btn in pnTrip.Controls)
                {
                    btn.Appearance.ForeColor = Color.Black;
                }
                ((DevExpress.XtraEditors.SimpleButton)sender).Appearance.ForeColor = Color.Blue;
            }
            catch { }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                btnLD.BackColor = Color.Silver;
                btnLE.BackColor = Color.Silver;
                this.Cursor = Cursors.WaitCursor;
                splashScreenManager1.ShowWaitForm();
                ((Button)sender).BackColor = Color.Yellow;
                VLine = ((Button)sender).Tag.ToString();
                DataSet ds = SELECT_DATA("Q", VDateF, VDateT, VLine, VTrip);
                DataTable dtGrid = new DataTable();
                DataTable dtChart = new DataTable();
                dtGrid = ds.Tables[0];
                loadgrid(dtGrid);
                dtChart = ds.Tables[1];
                loadchart(dtChart);
                splashScreenManager1.CloseWaitForm();
                this.Cursor = Cursors.Default;
            }
            catch {
                splashScreenManager1.CloseWaitForm();
                this.Cursor = Cursors.Default;
            }
        }


    }
}
