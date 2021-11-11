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
    public partial class FRM_TMS_PREFIT_SET : Form
    {
        public FRM_TMS_PREFIT_SET()
        {
            InitializeComponent();
        }
        #region Variable
        int iCount = 0, _start_column;
        #endregion
        private void btnBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "600";
        }
        #region Ora
        private DataTable TMS_HOME_SET_BY_SELECT(string ARG_TYPE, string ARG_FACTORY, string ARG_PLANT, string ARG_PROC_CD, string ARG_IS_BOTTOM)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;
               
                string process_name = "MES.PKG_TMS_PREFIT.TMS_HOME_SET_SELECT_NEW";
                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_FACTORY";
                MyOraDB.Parameter_Name[2] = "ARG_PLANT";
                MyOraDB.Parameter_Name[3] = "ARG_PROC_CD";
                MyOraDB.Parameter_Name[4] = "ARG_IS_BOTTOM";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_TYPE;
                MyOraDB.Parameter_Values[1] = ARG_FACTORY;
                MyOraDB.Parameter_Values[2] = ARG_PLANT;
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
                double temp1, temp2;
               
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if (distinct_row != string.Concat(dtTemp.Rows[i]["MLINE_CD"].ToString(), dtTemp.Rows[i]["STYLE_CD"].ToString(), dtTemp.Rows[i]["DIV"].ToString()))
                    {
                        dtSource.Rows.Add();
                    }
                    distinct_row = string.Concat(dtTemp.Rows[i]["MLINE_CD"].ToString(), dtTemp.Rows[i]["STYLE_CD"].ToString(), dtTemp.Rows[i]["DIV"].ToString());
                    for (int j = 0; j < _start_column - 1; j++)
                    {
                        dtSource.Rows[dtSource.Rows.Count - 1][j] = dtTemp.Rows[i][j];
                    }

                    double.TryParse(dtTemp.Rows[i]["QTY"].ToString(), out temp1);
                    double.TryParse(dtSource.Rows[dtSource.Rows.Count - 1][dtTemp.Rows[i]["CS_SIZE"].ToString()].ToString(), out temp2);
                    dtSource.Rows[dtSource.Rows.Count - 1][dtTemp.Rows[i]["CS_SIZE"].ToString()] = (temp1 + temp2).ToString();
                    double.TryParse(dtSource.Rows[dtSource.Rows.Count - 1][_start_column - 1].ToString(), out temp2);                    
                   
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
            try
            {

                double op_qty = 0;
                double op_set = 0;
                double op_set_per = 0;
                string set_rate = "";

                while (gridView1.Columns.Count > 0)
                {
                    gridView1.Columns.RemoveAt(0);
                }
                DataTable dtSource = new DataTable();
                DataTable dt1 = TMS_HOME_SET_BY_SELECT(Qtype, ComVar.Var._strValue1, "016", ComVar.Var._strValue2, ComVar.Var._bValue1 ? "1" : "0");
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


                //---tinh set_per cua cot total---

                for (int i = 0; i <= gridView1.RowCount - 1; i++)
                {
                    if (gridView1.GetRowCellDisplayText(i, gridView1.Columns["DIV"]).ToString().Contains(ComVar.Var._strValue3))
                    {
                        double.TryParse(gridView1.GetRowCellDisplayText(i, gridView1.Columns[_start_column - 1]).ToString().Replace(",", ""), out op_qty);//cot total

                    }
                    if (gridView1.GetRowCellDisplayText(i, gridView1.Columns["DIV"]).ToString().Equals("SET"))
                    {
                        double.TryParse(gridView1.GetRowCellDisplayText(i, gridView1.Columns[_start_column - 1]).ToString().Replace(",", ""), out op_set);//cot total

                    }
                    if (gridView1.GetRowCellDisplayText(i, gridView1.Columns["DIV"]).ToString().Equals("SET_PER"))
                    {
                        if (op_qty > 0)
                        {
                            op_set_per = Math.Round(op_set / op_qty * 100,2);
                            //set_rate = op_set_per + "%";
                            gridView1.SetRowCellValue(i, gridView1.Columns[_start_column - 1], op_set_per);
                        }
                        else
                        {
                            op_set_per = 0;
                            gridView1.SetRowCellValue(i, gridView1.Columns[_start_column - 1], "0");
                        }
                    }


                }

                for (int i = 0; i <= gridView1.RowCount - 1; i++)
                {
                    if (gridView1.GetRowCellDisplayText(i, gridView1.Columns["DIV"]).ToString() == "SET_PER")
                    {
                        gridView1.SetRowCellValue(i, gridView1.Columns["DIV"],"% SET");
                    }
                }


            }
            catch { }

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
                        if (i == 0 || i == 1 || i == 2 || i == 3)
                        {
                            gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                            // gridView1.Columns[i].Width = i == 0 ? 80 : 150;
                            if (i == 0 || i == 1)
                                gridView1.Columns[i].Width = 80;
                            else if (i == 2)
                                gridView1.Columns[i].Width = 300;
                            else
                                gridView1.Columns[i].Width = 130;
                        }
                        else
                        {
                            gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                            gridView1.Columns[i].Width = 120;

                            //gvwView1.Columns[i].Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(gvw_style.Columns[i].GetCaption().Replace("_", " ").ToLower());
                        }
                        gridView1.Columns[i].Caption = gridView1.Columns[i].ToString().Replace("MLINE_CD", "Line").Replace("STYLE_CD", "Style Code").Replace("MODEL_NM", "Model Name").Replace("LINE_NM", "Plant");
                        gridView1.Columns[i].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

                    }
                    else if (i == 5)
                    {
                        gridView1.Columns[i].Width = 80;
                        gridView1.Columns[i].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                        gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                        gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gridView1.Columns[i].DisplayFormat.FormatString = "#,#";
                    }
                    else
                    {
                        gridView1.Columns[i].Width = 60;
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

        private void FRM_TMS_PREFIT_SET_BY_PLANT_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                try
                {
                    //splashScreenManager1.ShowWaitForm();
                    lblTitle.Text = string.Concat(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ComVar.Var._strValue3.ToLower()), " Set Balance at Plant");
                    labelControl7.Text = "★ Balance " + ComVar.Var._strValue3 + " Component";
                    iCount = 118;
                    //BindingData("Q1");
                    //splashScreenManager1.CloseWaitForm();
                }
                catch { splashScreenManager1.CloseWaitForm(); }
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                string tomau_row_g = gridView1.GetRowCellDisplayText(e.RowHandle, "DIV");
                //
                if (e.Column.ColumnHandle < 4) return;

                if (tomau_row_g.Equals(ComVar.Var._strValue3))
                {
                    e.Appearance.BackColor = Color.FromArgb(141, 247, 230); //135, 255, 235

                }
                if (tomau_row_g.Equals("SET"))
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 222, 59);

                }
                if (tomau_row_g.Equals("% SET"))
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 222, 59);

                }

            }
            catch { }
        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            iCount++;
            if (iCount >= 120)
            {
                iCount = 0;
                splashScreenManager1.ShowWaitForm();
                BindingData("Q1");
                splashScreenManager1.CloseWaitForm();
            }
        }
    }
}
