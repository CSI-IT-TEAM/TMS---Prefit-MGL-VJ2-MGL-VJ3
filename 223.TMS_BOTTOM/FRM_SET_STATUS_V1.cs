using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM
{
    public partial class FRM_SET_STATUS_V1 : Form
    {
        public FRM_SET_STATUS_V1()
        {
            InitializeComponent();
        }
        int iCount = 0, _start_column;
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (ComVar.Var._bValue1)
                ComVar.Var.callForm = "342";
            else
                ComVar.Var.callForm = "223";
        }
        string Qtype = "Q";
        private void FRM_SET_STATUS_V1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                //splashScreenManager1.ShowWaitForm();

                lblTitle.Text = ComVar.Var._strValue5.ToUpper() + " TMS - " + ComVar.Var._strValue2 + " SET BALANCE STATUS";
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
                Qtype = "Q";
                isUpperClick = false;
                lblSetRatio.Text = string.Concat("Set Ratio: ", ComVar.Var._dValue1 > 0 ? ComVar.Var._dValue1 : 0, "%");
                btnUpper.Text = "UPPER";
                lblSetRatio.Visible = true;
                if (!ComVar.Var._bValue1)
                {
                    switch (ComVar.Var._strValue1)
                    {
                        case "001":
                        case "002":
                        case "003":
                        case "004":
                        case "005":
                        case "006":
                        case "099":
                            gbbE_Upper.Enabled = true;
                            break;
                        default:
                            gbbE_Upper.Enabled = false;
                            break;
                    }
                }
                else
                {
                    gbbE_Upper.Visible = false;
                    lblSetRatio.Visible = false;
                }
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
                    if (distinct_row != string.Concat(dtTemp.Rows[i]["MLINE_CD"].ToString(), dtTemp.Rows[i]["STYLE_CD"].ToString(), dtTemp.Rows[i]["INFO_NM"].ToString()))
                    {
                        dtSource.Rows.Add();
                    }
                    distinct_row = string.Concat(dtTemp.Rows[i]["MLINE_CD"].ToString(), dtTemp.Rows[i]["STYLE_CD"].ToString(), dtTemp.Rows[i]["INFO_NM"].ToString());
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
            DatabaseTMS db = new DatabaseTMS();
            try
            {
                while (gridView1.Columns.Count > 0)
                {
                    gridView1.Columns.RemoveAt(0);
                }
                DataTable dtSource = new DataTable();
                DataTable dt1 = db.getSetStatus(Qtype, ComVar.Var._strValue3, ComVar.Var._strValue4, "", ComVar.Var._strValue1);
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
                    splashScreenManager1.SetWaitFormCaption("Load " + ComVar.Var._strValue2);
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
                    if (i < 4)
                    {
                        if (i == 0 || i == 1 || i == 2)
                        {
                            gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                           // gridView1.Columns[i].Width = i == 0 ? 80 : 150;
                            if (i == 0 || i == 1)
                                gridView1.Columns[i].Width = 80;
                            else
                                gridView1.Columns[i].Width = 150;
                        }
                        else
                        {
                            gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                            gridView1.Columns[i].Width = 200;

                            //gvwView1.Columns[i].Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(gvw_style.Columns[i].GetCaption().Replace("_", " ").ToLower());
                        }
                        gridView1.Columns[i].Caption = gridView1.Columns[i].ToString().Replace("MLINE_CD", "Line").Replace("STYLE_CD", "Style Code").Replace("INFO_NM", "DIV").Replace("LINE_NM","Plant");
                        gridView1.Columns[i].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

                    }
                    else if (i == 4)
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
            string tomau_row_g = gridView1.GetRowCellDisplayText(e.RowHandle, "INFO_NM");

            //
            if (e.Column.ColumnHandle < 3) return;

            if (tomau_row_g.Contains("SET"))
            {
                e.Appearance.BackColor = Color.FromArgb(255, 198, 158);

            }
            else if (tomau_row_g.Contains("UPPER"))
            {
                e.Appearance.BackColor = Color.FromArgb(208, 255, 158);
            }
        }

        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                if (e.RowHandle1 < 0 || gridView1.RowCount == 0)
                    return;
                e.Merge = false;
                e.Handled = true;

                if (e.Column.FieldName.Contains("LINE_NM"))
                {
                    string ymd1 = gridView1.GetRowCellDisplayText(e.RowHandle1, e.Column.FieldName).Trim();
                    string ymd2 = gridView1.GetRowCellDisplayText(e.RowHandle2, e.Column.FieldName).Trim();

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
                    string ymd1 = gridView1.GetRowCellDisplayText(e.RowHandle1, "LINE_NM").Trim() + gridView1.GetRowCellDisplayText(e.RowHandle1, e.Column.FieldName).Trim();
                    string ymd2 = gridView1.GetRowCellDisplayText(e.RowHandle2, "LINE_NM").Trim() + gridView1.GetRowCellDisplayText(e.RowHandle2, e.Column.FieldName).Trim();

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
                    string ymd1 = gridView1.GetRowCellDisplayText(e.RowHandle1, "LINE_NM").Trim() + gridView1.GetRowCellDisplayText(e.RowHandle1, "MLINE_CD").Trim() + gridView1.GetRowCellDisplayText(e.RowHandle1, e.Column.FieldName).Trim();
                    string ymd2 = gridView1.GetRowCellDisplayText(e.RowHandle2, "LINE_NM").Trim() + gridView1.GetRowCellDisplayText(e.RowHandle2, "MLINE_CD").Trim() + gridView1.GetRowCellDisplayText(e.RowHandle2,  e.Column.FieldName).Trim();

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
        bool isUpperClick = false;
        private void btnUpper_Click(object sender, EventArgs e)
        {
            try
            {
                //Qbutton Click thì load lại lưới và cho phép click xem chi tiết.
                if (!isUpperClick)
                {
                    //Bấm nút Upper
                    Qtype = "QUpper";
                    lblSetRatio.Visible = false;
                    isUpperClick = true;
                    btnUpper.Text = ComVar.Var._strValue5.ToUpper();
                }
                else
                {
                    //Bấm nút Outsole
                    Qtype = "Q";
                    isUpperClick = false;
                    btnUpper.Text = "UPPER";
                    lblSetRatio.Visible = true;
                }
                // MessageBox.Show(Qtype);
                splashScreenManager1.ShowWaitForm();
                BindingData(Qtype);
                iCount = 0;
                splashScreenManager1.CloseWaitForm();
            }
            catch
            {
                iCount = 0;
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (Qtype.Equals("QUpper"))
            {
                if (e.Column.AbsoluteIndex > 3 && gridView1.GetRowCellValue(e.RowHandle, "INFO_NM").ToString().Equals("SET") &&
                     (!string.IsNullOrEmpty(gridView1.GetRowCellValue(e.RowHandle, e.Column.FieldName.ToString()).ToString())))
                {
                    string Style_cd = gridView1.GetRowCellValue(e.RowHandle, "STYLE_CD").ToString().Replace("-", "");
                    string Cs_Size = e.Column.FieldName.ToString();
                    string Line_Cd = ComVar.Var._strValue1;
                    POPUP_PCARD_DETAIL POPUP = new POPUP_PCARD_DETAIL();
                    POPUP.BingdingData(Style_cd, Cs_Size, Line_Cd);
                    tmrDate.Stop();
                    POPUP.ShowDialog();
                    tmrDate.Start();
                }
            }

        }
    }
}
