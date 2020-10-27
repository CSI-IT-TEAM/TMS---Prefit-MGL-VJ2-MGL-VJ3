using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Globalization;
using System.Data.OracleClient;

namespace FORM
{
    public partial class FRM_MILKRUN_ORDER : Form
    {
        public FRM_MILKRUN_ORDER(string LINE_CD)
        {
            InitializeComponent();
            isInfo = true;
            tripCD = "000";
            V_Line = LINE_CD;
        }
        Int32 currhour = 0;
        private MyCellMergeHelper _Helper;
        string[] headNames = new string[] { "MLINE_CD", "DIV0", "DIV" };
        string[] divNames0 = new string[] { "Plan", "Total Out", "Pre-Trip", "Current Trip", "", "" };
        string[] divNames = new string[] { "JIT Plan", "Accumulated Out", "Set", "Order", "Out" };
        string dateFrom = "",
                  dateTo = "",
                  asyDate = "",
                  orderDate = "",
                  lineCD = "",
                  mlineCD = "",
                  tripCD = "";
        bool isInfo = true;
        private void btnChangePage_Click(object sender, EventArgs e)
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                this.Cursor = Cursors.WaitCursor;
                if (isInfo)
                {
                    navigationFrame1.SelectedPage = navigationPage2;
                    btnLD.Visible = false;
                    btnLE.Visible = false;
                    btnL.Visible = false;
                    lblTitle.Text = "Order Infomation";
                    isInfo = false;
                    btnChangePage.Text = "Back";
                    BindingData2();
                }
                else
                {
                    navigationFrame1.SelectedPage = navigationPage1;
                    btnLD.Visible = true;
                    btnLE.Visible = true;
                    btnL.Visible = true;
                    lblTitle.Text = "Automatic Milkrun Order";
                    isInfo = true;
                    btnChangePage.Text = "Result";
                    BindingData();
                }
                this.Cursor = Cursors.Default;
                splashScreenManager1.CloseWaitForm();
            }
            catch { this.Cursor = Cursors.Default; splashScreenManager1.CloseWaitForm(); }
        }
        public DataTable getTMSMilkrunOrder(string ARG_QTYPE, string ARG_LINE, string ARG_MLINE, string ARG_TRIP)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_HOME.TMS_MILKRUN_ORDER";
                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[2] = "ARG_MLINE";
                MyOraDB.Parameter_Name[3] = "ARG_TRIP";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_LINE;
                MyOraDB.Parameter_Values[2] = ARG_MLINE;
                MyOraDB.Parameter_Values[3] = ARG_TRIP;
                MyOraDB.Parameter_Values[4] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        //===================tab2
        public DataTable getTMSInfoOrder(string ARG_QTYPE, string ARG_DATE, string ARG_LINE, string ARG_TRIP)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_HOME.TMS_INFOR_ORDER";
                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_DATE";
                MyOraDB.Parameter_Name[2] = "ARG_LINE";
                MyOraDB.Parameter_Name[3] = "ARG_TRIP";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_DATE;
                MyOraDB.Parameter_Values[2] = ARG_LINE;
                MyOraDB.Parameter_Values[3] = ARG_TRIP;
                MyOraDB.Parameter_Values[4] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        //=====================================


        private void BindingData()
        {
            try
            {
                DataTable dtSource = new DataTable();
                DataTable dtDays = new DataTable();
                DataTable dtData = new DataTable();
                DataTable dtQuantity = new DataTable();

                DataTable dt = null;
                dt = getTMSMilkrunOrder("Q1", V_Line, "", tripCD);
                if (dt.Rows.Count > 0 && dt != null)
                {
                    dtQuantity = dt;
                    txtTripQty.Text = string.Format("{0:n0}", dtQuantity.Rows[0]["PRS_QTY"]);
                }
                dt = null;
                dt = getTMSMilkrunOrder("QH", V_Line, "", tripCD);
                if (dt.Rows.Count > 0 && dt != null)
                {
                    dtDays = dt;
                    BuildHeader(dtSource, dtDays);

                    dtData = null;

                    dtData = getTMSMilkrunOrder("Q", V_Line, "", tripCD);
                    if (dtData.Rows.Count > 0 && dtData != null)
                    {
                        tripCD = dtData.Rows[0]["CUR_TRIP"].ToString();
                        BindingDataSource(dtSource, dtDays, dtData);
                    }
                    txtTruck.Enabled = true;
                    if (V_Line.Equals("201"))
                    {
                        txtTruck.Text = "2,676";
                    }
                    else if (V_Line.Equals("202"))
                        txtTruck.Text = "1,308";
                    else
                    {
                        txtTruck.Text = "";
                        txtTruck.Enabled = false;
                    }
                }
                grdBase.DataSource = dtSource;
                gvwBase.BeginUpdate();
                _Helper = new MyCellMergeHelper(gvwBase);


                for (int i = 0; i <= gvwBase.RowCount - 1; i += 5)
                {
                    gvwBase.SetRowCellValue(i, "DIV0", "Plan");
                    _Helper.AddMergedCell(i, 1, 2, "Plan");

                    gvwBase.SetRowCellValue(i + 1, "DIV0", "Total Out");
                    _Helper.AddMergedCell(i + 1, 1, 2, "Total Out");

                    //gvwBase.SetRowCellValue(i + 2, "DIV0", "Pre Trip");

                    gvwBase.SetRowCellValue(i + 2, "DIV0", "Current Trip: " + tripCD);
                    gvwBase.SetRowCellValue(i + 3, "DIV0", "Current Trip: " + tripCD);
                    gvwBase.SetRowCellValue(i + 4, "DIV0", "Current Trip: " + tripCD);
                }

                for (int i = 0; i < gvwBase.Columns.Count; i++)
                {
                    gvwBase.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                    gvwBase.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    gvwBase.Columns[i].OptionsFilter.AllowFilter = false;
                    gvwBase.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    gvwBase.ColumnPanelRowHeight = 25;
                    gvwBase.RowHeight = 25;

                    if (i < 3)
                        gvwBase.Columns[i].OwnerBand.Width = 50;
                    else
                        if (i >= 3)
                        {
                            gvwBase.Columns[i].OwnerBand.Width = 30;
                        }


                    if (i <= Array.IndexOf(headNames, "DIV"))
                    {
                        gvwBase.Columns[i].OwnerBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                        gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    }
                    else
                    {
                        gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;




                        if (gvwBase.Columns[i].FieldName.Contains("H"))
                        {
                            gvwBase.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                            gvwBase.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            gvwBase.Columns[i].DisplayFormat.FormatString = "#,##0.##";
                            // gvwBase.Appearance.BandPanel.Font = new System.Drawing.Font("DotumChe", 7F, FontStyle.Regular);
                        }
                    }
                }
                gvwBase.Appearance.Row.Font = new System.Drawing.Font("Calibri", 11, System.Drawing.FontStyle.Regular);
                //  gvwBase.BestFitColumns();
                gvwBase.OptionsView.ColumnAutoWidth = false;
                gvwBase.EndUpdate();
                column_width();
                MarkTripButton();
            }
            catch (Exception ex)
            {

            }
        }

        private void MarkTripButton()
        {
            foreach (DevExpress.XtraEditors.SimpleButton btn in pnTrip.Controls)
            {
                if (btn.Tag.ToString().Equals(tripCD))
                    btn.Appearance.ForeColor = Color.Blue;
            }
        }

        private void column_width()
        {
            try
            {
                gvwBase.BandPanelRowHeight = 30;
                for (int i = 0; i < gvwBase.Columns.Count - 1; i++)
                {

                    gvwBase.Columns[i].OwnerBand.AppearanceHeader.BackColor = Color.Gray;
                    gvwBase.Columns[i].OwnerBand.AppearanceHeader.ForeColor = Color.White;

                    if (gvwBase.Columns[i].OwnerBand.Caption.Equals("Content"))
                        gvwBase.Columns[i].OwnerBand.AppearanceHeader.BackColor = Color.Orange;
                    if (gvwBase.Columns[i].OwnerBand.Caption.Equals("Line") || gvwBase.Columns[i].OwnerBand.Caption.Equals("Division"))
                        gvwBase.Columns[i].OwnerBand.AppearanceHeader.BackColor = Color.Green;
                    gvwBase.Columns[i].OwnerBand.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 14, System.Drawing.FontStyle.Bold);
                    if (i < 3)
                    {
                        gvwBase.Columns[0].OwnerBand.Width = 80;
                        gvwBase.Columns[1].OwnerBand.Width = 150;
                        gvwBase.Columns[2].OwnerBand.Width = 90;
                    }
                    else
                        if (i >= 3)
                        {
                            gvwBase.Columns[i].OwnerBand.Width = 40;
                            gvwBase.Columns[i].OwnerBand.ParentBand.AppearanceHeader.BackColor = Color.Gray;
                            gvwBase.Columns[i].OwnerBand.ParentBand.AppearanceHeader.ForeColor = Color.White;
                            gvwBase.Columns[i].OwnerBand.ParentBand.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 14, System.Drawing.FontStyle.Bold);
                        }
                }
            }
            catch (Exception ex)
            { }
        }
        void BuildHeader(DataTable dtSource, DataTable dtDays)
        {
            GridBand band, bandChild;
            string hour = "";
            try
            {
                // Reset band header.
                while (gvwBase.Bands.Count > 0)
                {
                    gvwBase.Bands.RemoveAt(0);
                }
                while (gvwBase.Columns.Count > 0)
                {
                    gvwBase.Columns.RemoveAt(0);
                }

                for (int i = 0; i < headNames.Length; i++)
                {
                    band = new GridBand();
                    band.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 12F, FontStyle.Bold);
                    if (headNames[i].Equals("MLINE_CD"))
                    {
                        band.Caption = "Line";
                    }
                    else if (headNames[i].Equals("DIV0"))
                    {
                        band.Caption = "Division";
                    }
                    else if (headNames[i].Equals("DIV"))
                    {
                        band.Caption = "Content";
                    }
                    else
                    {
                        band.Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(headNames[i].ToLower().Replace("_", " "));
                    }

                    //band.MinWidth = 80;//TextRenderer.MeasureText(band.Caption, band.AppearanceHeader.Font).Width;
                    band.AppearanceHeader.Options.UseTextOptions = true;
                    band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    gvwBase.Bands.Add(band);
                    AddColumn(band, headNames[i]);
                    dtSource.Columns.Add(headNames[i], typeof(string));
                }
                for (int i = 0; i < dtDays.Rows.Count; i++)
                {
                    band = new GridBand();
                    band.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 12F, FontStyle.Bold);
                    band.Caption = dtDays.Rows[i]["DATE_STRING"].ToString();
                    band.AppearanceHeader.Options.UseTextOptions = true;
                    band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    for (int j = 0; j < 8; j++)
                    {
                        hour = string.Concat(j + 1, "H");
                        bandChild = new GridBand();
                        bandChild.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 12F, FontStyle.Bold);
                        bandChild.Caption = hour;
                        //bandChild.MinWidth = 20;
                        bandChild.AppearanceHeader.Options.UseTextOptions = true;
                        bandChild.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        // TextRenderer.MeasureText(bandChild.Caption, bandChild.AppearanceHeader.Font).Width + 20;
                        band.Children.Add(bandChild);

                        AddColumn(bandChild, dtDays.Rows[i]["THEDATE"].ToString() + "_" + hour);
                        dtSource.Columns.Add(dtDays.Rows[i]["THEDATE"].ToString() + "_" + hour, typeof(double));
                    }
                    gvwBase.Bands.Add(band);
                }
                GridBand bandColor = new GridBand();
                bandColor.Caption = "GROUP_COLOR";
                bandColor.Visible = false;
                gvwBase.Bands.Add(bandColor);
                AddColumn(bandColor, "GROUP_COLOR");
                dtSource.Columns.Add("GROUP_COLOR");
            }
            catch (Exception ex)
            {
                MessageBox.Show("BuildHeader(): " + ex.Message);
            }
        }
        void BindingDataSource(DataTable dtSource, DataTable dtDays, DataTable dtData)
        {
            double temp = 0.0;
            // Disticnt vertical group.
            string distincVGroup = "";
            // K index of mini-line group.
            int k = 0;
            // Filter rows for individual mini-line group.

            DataRow[] drow = null;
            // Temp dataTable.
            DataTable dtTemp = new DataTable();
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    if (distincVGroup != dtData.Rows[i]["DISTINCT_V_GROUP"].ToString())
                    {
                        // Add rows.
                        for (int j = 0; j < divNames.Length; j++)
                        {
                            dtSource.Rows.Add();
                            dtSource.Rows[dtSource.Rows.Count - 1]["MLINE_CD"] = dtData.Rows[i]["DISTINCT_V_GROUP"].ToString();
                            dtSource.Rows[dtSource.Rows.Count - 1]["DIV"] = divNames[j];

                            dtSource.Rows[dtSource.Rows.Count - 1]["GROUP_COLOR"] = divNames[j].Equals("Out") ? "1" : "0";
                        }
                        // Filter data rows.
                        drow = dtData.Select("MLINE_CD=" + dtData.Rows[i]["MLINE_CD"].ToString());
                        if (drow.Any())
                        {
                            dtTemp = drow.CopyToDataTable();
                            // Loop dtDays.
                            for (int j = 0; j < dtTemp.Rows.Count; j++)
                            {
                                try
                                {
                                    // Bind data: Plan.
                                    double.TryParse(dtTemp.Rows[j]["PLAN_QTY"].ToString(), out temp);
                                    if (0 < temp)
                                    {
                                        dtSource.Rows[k * 5][dtTemp.Rows[j]["DATE_HOUR"].ToString()] = temp;
                                    }
                                    // Bind data: R_SET.
                                    double.TryParse(dtTemp.Rows[j]["OUT_QTY"].ToString(), out temp);
                                    if (0 < temp)
                                    {
                                        dtSource.Rows[k * 5 + 1][dtTemp.Rows[j]["DATE_HOUR"].ToString()] = temp;
                                    }

                                    // Bind data: PSET
                                    double.TryParse(dtTemp.Rows[j]["P_SET_QTY"].ToString(), out temp);
                                    if (0 < temp)
                                    {
                                        dtSource.Rows[k * 5 + 2][dtTemp.Rows[j]["DATE_HOUR"].ToString()] = temp;
                                    }
                                    // Bind data: ORDER
                                    double.TryParse(dtTemp.Rows[j]["ORDER_QTY"].ToString(), out temp);
                                    if (0 < temp)
                                    {
                                        dtSource.Rows[k * 5 + 3][dtTemp.Rows[j]["DATE_HOUR"].ToString()] = temp;
                                    }
                                    // Bind data: ORDEROUT
                                    double.TryParse(dtTemp.Rows[j]["ORDEROUT_QTY"].ToString(), out temp);
                                    if (0 < temp)
                                    {
                                        dtSource.Rows[k * 5 + 4][dtTemp.Rows[j]["DATE_HOUR"].ToString()] = temp;
                                    }
                                }
                                catch (Exception ex) { }
                            }
                        }
                        // Increase K.
                        k++;
                    }
                    distincVGroup = dtData.Rows[i]["DISTINCT_V_GROUP"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BindingDataSource(): " + ex.Message);
            }
        }
        private void AddColumn(GridBand band, string fieldName)
        {
            BandedGridColumn col = new BandedGridColumn();
            col.FieldName = fieldName;
            col.Visible = true;
            col.OptionsColumn.AllowEdit = false;
            col.OptionsColumn.ReadOnly = true;
            col.OptionsFilter.AllowFilter = false;
            col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gvwBase.Columns.Add(col);
            col.OwnerBand = band;
        }
        //=============tab 2=======================================================================
        private void BindingData2()
        {
            try
            {
                grdBase2.DataSource = getTMSInfoOrder("Q", "", V_Line, tripCD);
                FormatGrid();
            }
            catch (Exception ex)
            { }
        }

        private void FormatGrid()
        {
            for (int i = 0; i < gvwBase2.Columns.Count; i++)
            {
                gvwBase2.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                if (i > 4)
                {
                    gvwBase2.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    if (i == gvwBase2.Columns.Count - 1)
                    {
                        gvwBase2.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        gvwBase2.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gvwBase2.Columns[i].DisplayFormat.FormatString = "#,#";
                    }
                }
                else
                    gvwBase2.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            }
        }

        //=========================================================================================
        private void FRM_MILKRUN_ORDER_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                try
                {
                    splashScreenManager1.ShowWaitForm();
                    switch (V_Line)
                    {
                        case "201":
                            btnLD.BackColor = Color.Yellow;
                            break;
                        case "202":
                            btnLE.BackColor = Color.Yellow;
                            break;
                        default:
                            break;
                    }
                    BindingData();
                    splashScreenManager1.CloseWaitForm();
                }
                catch { splashScreenManager1.CloseWaitForm(); }
            }
        }

        private void gvwBase2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (gvwBase2.RowCount == 0) return;

                if (gvwBase2.GetRowCellDisplayText(e.RowHandle, "ASY_LINE").Equals("G-TOTAL") && e.Column.AbsoluteIndex > 0)
                {
                    e.Appearance.BackColor = Color.FromArgb(141, 205, 71);
                }

                if (gvwBase2.GetRowCellDisplayText(e.RowHandle, "MLINE_CD").Equals("TOTAL") && e.Column.AbsoluteIndex > 1)
                {
                    e.Appearance.BackColor = Color.FromArgb(252, 213, 180);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void gvwBase2_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                if (e.RowHandle1 < 0 || gvwBase2.RowCount == 0)
                    return;
                e.Merge = false;
                e.Handled = true;

                if (e.Column.FieldName.Contains("ASY_DATE"))
                {
                    string ymd1 = gvwBase2.GetRowCellDisplayText(e.RowHandle1, e.Column.FieldName).Trim();
                    string ymd2 = gvwBase2.GetRowCellDisplayText(e.RowHandle2, e.Column.FieldName).Trim();

                    if (ymd1 == ymd2)
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }

                if (e.Column.FieldName.Contains("ASY_LINE"))
                {
                    string ymd1 = gvwBase2.GetRowCellDisplayText(e.RowHandle1, "ASY_DATE").Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle1, e.Column.FieldName).Trim();
                    string ymd2 = gvwBase2.GetRowCellDisplayText(e.RowHandle2, "ASY_DATE").Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle2, e.Column.FieldName).Trim();

                    if (ymd1 == ymd2)
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }
                if (e.Column.FieldName.Contains("MLINE_CD"))
                {
                    string ymd1 = gvwBase2.GetRowCellDisplayText(e.RowHandle1, "ASY_DATE").Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle1, "ASY_LINE").Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle1, e.Column.FieldName).Trim();
                    string ymd2 = gvwBase2.GetRowCellDisplayText(e.RowHandle2, "ASY_DATE").Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle2, "ASY_LINE").Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle2, e.Column.FieldName).Trim();

                    if (ymd1 == ymd2)
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }
                if (e.Column.FieldName.Contains("HOURS"))
                {
                    string ymd1 = gvwBase2.GetRowCellDisplayText(e.RowHandle1, "ASY_DATE").Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle1, "ASY_LINE").Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle1, e.Column.FieldName).Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle1, "MLINE_CD").Trim();
                    string ymd2 = gvwBase2.GetRowCellDisplayText(e.RowHandle2, "ASY_DATE").Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle2, "ASY_LINE").Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle2, e.Column.FieldName).Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle2, "MLINE_CD").Trim();

                    if (ymd1 == ymd2)
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }
                if (e.Column.FieldName.Contains("STYLE_CD"))
                {
                    string ymd1 = gvwBase2.GetRowCellDisplayText(e.RowHandle1, "ASY_DATE").Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle1, "ASY_LINE").Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle1, e.Column.FieldName).Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle1, "MLINE_CD").Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle1, "HOURS").Trim();
                    string ymd2 = gvwBase2.GetRowCellDisplayText(e.RowHandle2, "ASY_DATE").Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle2, "ASY_LINE").Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle2, e.Column.FieldName).Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle2, "MLINE_CD").Trim() + gvwBase2.GetRowCellDisplayText(e.RowHandle1, "HOURS").Trim();

                    if (ymd1 == ymd2)
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }
            }
            catch
            {

            }
        }
        private void gvwBase_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                double temp = 0.0;
                //       // Value of previous row.
                double temp2 = 0.0;
                //if (gvwBase.RowCount == 0) return;

                if (gvwBase.GetRowCellDisplayText(e.RowHandle, "DIV") == "Order")// && e.Column.FieldName.Contains("H"))
                {
                    e.Appearance.ForeColor = Color.Blue;//to mau het dong
                }

                if (gvwBase.GetRowCellDisplayText(e.RowHandle, "DIV") == "JIT Plan" && e.Column.AbsoluteIndex > 2)// && e.Column.FieldName.Contains("H"))
                {
                    e.Appearance.BackColor = Color.Yellow;//to mau het dong

                }

                if (gvwBase.GetRowCellDisplayText(e.RowHandle, "DIV") == "Out" && e.Column.FieldName.Contains("H"))
                {
                    double.TryParse(e.CellValue.ToString(), out temp); //out
                    double.TryParse(gvwBase.GetRowCellValue(e.RowHandle - 1, e.Column.FieldName).ToString(), out temp2);//order


                    if (temp > 0 && temp == temp2) //if out = order
                    {
                        // Green.
                        e.Appearance.ForeColor = Color.Green;
                        // Black.
                        // e.Appearance.ForeColor = Color.FromArgb(0, 0, 0);
                    }
                    else if (temp > 0 && temp != temp2) //if out = order
                    {
                        // Green.
                        e.Appearance.ForeColor = Color.Red;
                        // Black.
                        // e.Appearance.ForeColor = Color.White;
                    }

                    if (e.Column.FieldName.Contains("H"))
                    {
                        e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold);

                    }

                }
            }
            catch { }
        }

        private void btnTrip_Click(object sender, EventArgs e)
        {
            tripCD = ((DevExpress.XtraEditors.SimpleButton)sender).Tag.ToString();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                splashScreenManager1.ShowWaitForm();
                BindingData();
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
        string V_Line = "201";
        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                btnLD.BackColor = Color.Silver;
                btnLE.BackColor = Color.Silver;

                this.Cursor = Cursors.WaitCursor;
                splashScreenManager1.ShowWaitForm();
                ((Button)sender).BackColor = Color.Yellow;
                V_Line = ((Button)sender).Tag.ToString();
                BindingData();
                splashScreenManager1.CloseWaitForm();
                this.Cursor = Cursors.Default;
            }
            catch
            {
                splashScreenManager1.CloseWaitForm();
                this.Cursor = Cursors.Default;
            }
        }
    }
}
