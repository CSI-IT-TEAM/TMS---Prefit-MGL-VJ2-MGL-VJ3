using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace FORM
{
    public partial class FRM_SET_STATUS_DETAIL : Form
    {
        public FRM_SET_STATUS_DETAIL()
        {
            InitializeComponent();
        }
        int iCount = 0, _start_column;
        #region Oracle
        public DataTable DATA_SELECT(string ARG_TYPE, string ARG_FACTORY, string ARG_LINE_CD, string ARG_PROC_CD, string ARG_IS_BOTTOM)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_PREFIT.TMS_HOME_PREFIT_DETAIL";
                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_FACTORY";
                MyOraDB.Parameter_Name[2] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[3] = "ARG_PROC_CD";
                MyOraDB.Parameter_Name[4] = "ARG_IS_BOTTOM";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR1";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (char)OracleType.Cursor;


                MyOraDB.Parameter_Values[0] = ARG_TYPE;
                MyOraDB.Parameter_Values[1] = ARG_FACTORY;
                MyOraDB.Parameter_Values[2] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[3] = ARG_PROC_CD;
                MyOraDB.Parameter_Values[4] = ARG_IS_BOTTOM;
                MyOraDB.Parameter_Values[5] = "";


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
        #endregion

        private void btnBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "602";
        }
        string Qtype = "Q";
        private void FRM_SET_STATUS_V1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                //splashScreenManager1.ShowWaitForm();
                lblTitle.Text = string.Concat(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ComVar.Var._strValue3.ToLower()), " Inventory Detail");
                //ComVar.Var._strValue1 //Line code
                //ComVar.Var._strValue2 = TMSUCmodel.PROC_CODE_CARD;//Process code
                //ComVar.Var._bValue1 = //Is Bottom YN.

                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
                Qtype = "Q";
                iCount = 60;
                tmrDate.Start();
                // splashScreenManager1.CloseWaitForm();

            }
            else
            { tmrDate.Stop(); }
        }

        private bool buildHeader_detail(DataTable dtSource, DataTable dt)
        {
            try
            {
                int.TryParse(dt.Rows[0]["START_COLUMN"].ToString(), out _start_column);
                for (int i = 0; i < _start_column - 1; i++)
                {
                    dtSource.Columns.Add(dt.Columns[i].Caption);
                }
                dtSource.Columns.Add("Total", typeof(decimal));
                DataRow[] row = dt.Select("", "SIZE_NUM ASC");
                double min = 1, max = 22;
                double.TryParse(row[0]["SIZE_NUM"].ToString(), out min);
                double.TryParse(row[row.Length - 1]["SIZE_NUM"].ToString(), out max);
                for (double i = min; i <= max; i = i + 0.5)
                {
                    dtSource.Columns.Add(i.ToString().Replace(".5", "T"), typeof(decimal));
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool bindingDataSource_detail(DataTable dtSource, DataTable dtTemp)
        {
            try
            {
                int[] rowtotal = new int[dtSource.Columns.Count];
                string distinct_row = "";
                int temp1, temp2;
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if (distinct_row != string.Concat(dtTemp.Rows[i]["Mini Line"].ToString(), dtTemp.Rows[i]["Style Code"].ToString()))
                    {
                        dtSource.Rows.Add();
                    }
                    distinct_row = string.Concat(dtTemp.Rows[i]["Mini Line"].ToString(), dtTemp.Rows[i]["Style Code"].ToString());
                    for (int j = 0; j < _start_column - 1; j++)
                    {
                        dtSource.Rows[dtSource.Rows.Count - 1][j] = dtTemp.Rows[i][j];
                    }

                    int.TryParse(dtTemp.Rows[i]["QTY"].ToString(), out temp1);
                    int.TryParse(dtSource.Rows[dtSource.Rows.Count - 1][dtTemp.Rows[i]["CS_SIZE"].ToString()].ToString(), out temp2);
                    dtSource.Rows[dtSource.Rows.Count - 1][dtTemp.Rows[i]["CS_SIZE"].ToString()] = (temp1 + temp2).ToString();
                    int.TryParse(dtSource.Rows[dtSource.Rows.Count - 1][_start_column - 1].ToString(), out temp2);
                    dtSource.Rows[dtSource.Rows.Count - 1][_start_column - 1] = (temp1 + temp2).ToString();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void BindingData(string Qtype)
        {
            //  DatabaseTMS db = new DatabaseTMS();

            try
            {
                while (gridView1.Columns.Count > 0)
                {
                    gridView1.Columns.RemoveAt(0);
                }
                DataTable dtSource = new DataTable();
                DataTable dt1 = DATA_SELECT("Q", ComVar.Var._strValue1, ComVar.Var._strValue4, ComVar.Var._strValue2, ComVar.Var._bValue1 == true ? "1" : "0");
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    if (buildHeader_detail(dtSource, dt1))
                    {
                        if (bindingDataSource_detail(dtSource, dt1))
                        {
                            gridControl1.DataSource = dtSource;
                            formatgrid();
                        }
                    }
                }
                else
                {
                    gridControl1.DataSource = null;
                }
            }
            catch { }

        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
                iCount++;
                if (iCount >= 60)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormCaption("Loading " + ComVar.Var._strValue3 + "  Data");
                    BindingData(Qtype);
                    iCount = 0;
                    splashScreenManager1.CloseWaitForm();

                }
            }
            catch { iCount = 0; }
        }


        private void formatgrid()
        {
            try
            {
                gridView1.BeginUpdate();
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    gridView1.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 14);
                    gridView1.Columns[i].AppearanceHeader.Font = new System.Drawing.Font("Calibri", 14, FontStyle.Bold);
                    gridView1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridView1.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gridView1.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    if (i < 5)
                    {
                        if (i == 0)
                            gridView1.Columns[i].Visible = false;
                        else if (i <= 5)
                        {
                            gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                            gridView1.Columns[i].Width = i != 3 ? 120 : 250;
                            if (i==3)
                                gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                        }
                        else
                        {
                            gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                            gridView1.Columns[i].Width = 200;
                        }
                        gridView1.Columns[i].Caption = gridView1.Columns[i].ToString();
                        gridView1.Columns[i].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    }
                    else
                    {
                        gridView1.Columns[i].Width = 62;
                        gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                        gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gridView1.Columns[i].DisplayFormat.FormatString = "#,#";
                    }
                }
                gridView1.EndUpdate();
            }
            catch { }
        }




        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                string tomau_row_g = gridView1.GetRowCellDisplayText(e.RowHandle, "Plant");
                if (e.Column.ColumnHandle < 2) return;
                if (tomau_row_g.Contains("TOTAL"))
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 252, 153);
                }
            }
            catch
            {
            }
        }

        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                //if (e.RowHandle1 < 0 || gridView1.RowCount == 0)
                //    return;
                //e.Merge = false;
                //e.Handled = true;

                //if (e.Column.FieldName.Contains("LINE_CD"))
                //{
                //    string ymd1 = gridView1.GetRowCellDisplayText(e.RowHandle1, e.Column.FieldName).Trim();
                //    string ymd2 = gridView1.GetRowCellDisplayText(e.RowHandle2, e.Column.FieldName).Trim();

                //    if (ymd1 == ymd2)
                //    {
                //        e.Merge = true;
                //    }
                //    else
                //    {
                //        e.Merge = false;
                //    }
                //}

                //if (e.Column.FieldName.Contains("STYLE_CD"))
                //{
                //    string ymd1 = gridView1.GetRowCellDisplayText(e.RowHandle1, "MLINE_CD").Trim() + gridView1.GetRowCellDisplayText(e.RowHandle1, "STYLE_CD").Trim();
                //    string ymd2 = gridView1.GetRowCellDisplayText(e.RowHandle2, "MLINE_CD").Trim() + gridView1.GetRowCellDisplayText(e.RowHandle2, "STYLE_CD").Trim();

                //    if (ymd1 == ymd2)
                //    {
                //        e.Merge = true;
                //    }
                //    else
                //    {
                //        e.Merge = false;
                //    }
                //}

            }
            catch
            {

            }

        }
        private void btnUpper_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
        }
    }
}
