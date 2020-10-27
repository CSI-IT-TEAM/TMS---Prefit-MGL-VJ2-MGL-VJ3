using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Globalization;

namespace FORM
{
    public partial class FRM_TMS_BALANCE_ORDER : Form
    {
        public FRM_TMS_BALANCE_ORDER()
        {
            InitializeComponent();
            tmrDate.Stop();

        }
        int iCount = 0;

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


        private void btnBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "342";
        }

        private void FRM_TMS_BALANCE_ORDER_Load(object sender, EventArgs e)
        {
            BindingData();
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
        private void BindingData()
        {
            try
            {
                DataTable dtSource = new DataTable();
                DataTable dtDays = new DataTable();
                DataTable dtData = new DataTable();
                DataTable dtQuantity = new DataTable();
                currhour = Int32.Parse(DateTime.Now.ToString("HHmm"));
                dateFrom = DateTime.Now.ToString("yyyyMMdd");


                if (DateTime.Now.AddDays(1).DayOfWeek.ToString() != "Sunday")
                {
                    dateTo = DateTime.Now.AddDays(2).ToString("yyyyMMdd");

                }
                else
                {
                    dateTo = DateTime.Now.AddDays(3).ToString("yyyyMMdd");
                }

                tripCD = null;

                


                DataTable dt = null;
                dt = getTMSMilkrunOrder("Q1", "", "", "");
                if (dt.Rows.Count > 0 && dt != null)
                {
                    dtQuantity = dt;
                    txtTripQty.Text = string.Format("{0:n0}", dtQuantity.Rows[0]["PRS_QTY"]);
                }

                if (tripCD == "001")
                {
                    txtTruck.Text = "4,300";
                }
                else if (tripCD == "002")
                {
                    txtTruck.Text = "4,300";
                }
                else if (tripCD == "003")
                {
                    txtTruck.Text = "4,800";
                }
                else if (tripCD == "004")
                {
                    txtTruck.Text = "4,300";
                }
                dt = null;
                dt = getTMSMilkrunOrder("QH", "", "", "");
                if (dt.Rows.Count > 0 && dt != null)
                {
                    dtDays = dt;
                    BuildHeader(dtSource, dtDays);

                    dtData = null;
                    dtData = getTMSMilkrunOrder("Q", "", "", "");
                    if (dtData.Rows.Count > 0 && dtData != null)
                    {
                        BindingDataSource(dtSource, dtDays, dtData);
                    }
                }

                grdBase.DataSource = dtSource;
                gvwBase.BeginUpdate();
                _Helper = new MyCellMergeHelper(gvwBase);
                string stripcd = "004";

                for (int i = 0; i <= gvwBase.RowCount - 1; i += 5)
                {
                    gvwBase.SetRowCellValue(i, "DIV0", "Plan");
                    _Helper.AddMergedCell(i, 1, 2, "Plan");

                    gvwBase.SetRowCellValue(i + 1, "DIV0", "Total Out");
                    _Helper.AddMergedCell(i + 1, 1, 2, "Total Out");

                    // gvwBase.SetRowCellValue(i + 2, "DIV0", "Pre Trip");


                    gvwBase.SetRowCellValue(i + 2, "DIV0", "Current Trip: " + stripcd);
                    gvwBase.SetRowCellValue(i + 3, "DIV0", "Current Trip: " + stripcd);
                    gvwBase.SetRowCellValue(i + 4, "DIV0", "Current Trip: " + stripcd);
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
                            //   gvwBase.Appearance.BandPanel.Font = new System.Drawing.Font("DotumChe", 7F, FontStyle.Regular);

                        }
                    }
                }
                gvwBase.Appearance.Row.Font = new System.Drawing.Font("Calibri", 11, System.Drawing.FontStyle.Regular);
                //  gvwBase.BestFitColumns();
                gvwBase.OptionsView.ColumnAutoWidth = false;
                gvwBase.EndUpdate();
                column_width();
            }

            catch (Exception ex)
            {

            }

        }

        private void column_width()
        {
            gvwBase.BandPanelRowHeight = 30;
            for (int i = 0; i < gvwBase.Columns.Count; i++)
            {
               
                gvwBase.Columns[i].OwnerBand.AppearanceHeader.BackColor = Color.Gray;
                gvwBase.Columns[i].OwnerBand.AppearanceHeader.ForeColor = Color.White;

                if (gvwBase.Columns[i].OwnerBand.Caption.Equals("Content"))
                    gvwBase.Columns[i].OwnerBand.AppearanceHeader.BackColor = Color.Orange;
                gvwBase.Columns[i].OwnerBand.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 11, System.Drawing.FontStyle.Bold);
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
                        gvwBase.Columns[i].OwnerBand.ParentBand.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 11, System.Drawing.FontStyle.Bold);
                    }
            }
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
                    band.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 12F,FontStyle.Bold);
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
        private DataTable buildTripDataSource()
        {
            DataTable table = new DataTable();
            table.Columns.Add("CODE", typeof(string));
            table.Columns.Add("NAME", typeof(string));
            for (int i = 1; i <= 4; i++)
            {
                table.Rows.Add();
                if (i == 0)
                {
                    table.Rows[table.Rows.Count - 1]["CODE"] = "";
                    table.Rows[table.Rows.Count - 1]["NAME"] = "";
                }
                else
                {
                    table.Rows[table.Rows.Count - 1]["CODE"] = string.Concat("00", i.ToString());
                    table.Rows[table.Rows.Count - 1]["NAME"] = string.Concat("00", i.ToString());
                }
            }

            return table;
        }
        private DataTable buildGroupDataSource()
        {
            DataTable table = new DataTable();
            table.Columns.Add("CODE", typeof(string));
            table.Columns.Add("NAME", typeof(string));
            for (int i = 1; i <= 2; i++)
            {
                table.Rows.Add();
                table.Rows[table.Rows.Count - 1]["CODE"] = i.ToString();
                table.Rows[table.Rows.Count - 1]["NAME"] = i.ToString();
            }

            return table;
        }


        private void tmrDate_Tick(object sender, EventArgs e)
        {
            iCount++;
            if (iCount >= 50)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    splashScreenManager1.ShowWaitForm();
                    BindingData();
                    iCount = 0;
                    splashScreenManager1.CloseWaitForm();
                    this.Cursor = Cursors.Default;
                }
                catch
                {
                    iCount = 0;
                    splashScreenManager1.CloseWaitForm();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void FRM_TMS_BALANCE_ORDER_VisibleChanged(object sender, EventArgs e)
        {
            //if (this.Visible)
            //{
            //    if (ComVar.Var._strValue1.Equals("FTY01"))
            //        lblTitle.Text = "FACTORY 1 - COMPONENT NOT YET INCOMING";
            //    else if (ComVar.Var._strValue1.Equals("099"))
            //        lblTitle.Text = "NOS N - COMPONENT NOT YET INCOMING";
            //    iCount = 50;
            //    tmrDate.Start();
            //}
            //else
            //    tmrDate.Stop();

        }

        private void gvwBase_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            double temp = 0.0;
            //       // Value of previous row.
            double temp2 = 0.0;
            //if (gvwBase.RowCount == 0) return;

            if (gvwBase.GetRowCellDisplayText(e.RowHandle, "DIV") == "Order")// && e.Column.FieldName.Contains("H"))
            {
                e.Appearance.ForeColor = Color.Blue;//to mau het dong
            }

            if (gvwBase.GetRowCellDisplayText(e.RowHandle, "DIV") == "JIT Plan" && e.Column.AbsoluteIndex>2)// && e.Column.FieldName.Contains("H"))
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

    }
}
