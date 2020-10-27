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

namespace FORM
{
    public partial class FRM_TMS_BALANCE_UP_LT : Form
    {
        public FRM_TMS_BALANCE_UP_LT()
        {
            InitializeComponent();
            tmrDate.Stop();

        }
        int iCount = 0;

        public DataTable getTMSBalanceUpperLT(string ARG_LINE, string ARG_MLINE, string ARG_YMD, string ARG_TRIP, string ARG_STYLE)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_HOME.TMS_HOME_UP_BALANCE";
                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_LINE";
                MyOraDB.Parameter_Name[1] = "ARG_MLINE";
                MyOraDB.Parameter_Name[2] = "ARG_YMD";
                MyOraDB.Parameter_Name[3] = "ARG_TRIP";
                MyOraDB.Parameter_Name[4] = "ARG_STYLE";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_LINE;
                MyOraDB.Parameter_Values[1] = ARG_MLINE;
                MyOraDB.Parameter_Values[2] = ARG_YMD;
                MyOraDB.Parameter_Values[3] = ARG_TRIP;
                MyOraDB.Parameter_Values[4] = ARG_STYLE;
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


        private void btnBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "342";
        }

        private void FRM_TMS_BALANCE_UP_LT_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
        }

        private void BindingData()
        {
            DataTable dt = getTMSBalanceUpperLT(ComVar.Var._strValue1, "000", DateTime.Now.ToString("yyyyMMdd"), "ALL", "");
            CreateSizeGrid(grdBase, gvwBase1, dt);
            grdBase.DataSource = dt;
            gvwBase1.Columns[0].OwnerBand.Width = 100;
            gvwBase1.Columns[1].OwnerBand.Width = 100;
            gvwBase1.Columns[2].OwnerBand.Width = 200;
            gvwBase1.Columns[3].OwnerBand.Width = 200;

            gvwBase1.Columns[0].OwnerBand.AppearanceHeader.BackColor = Color.FromArgb(128, 128, 128);
            gvwBase1.Columns[0].OwnerBand.AppearanceHeader.BackColor2 = Color.FromArgb(128, 128, 128);
            gvwBase1.Columns[0].OwnerBand.AppearanceHeader.ForeColor = Color.White;
            gvwBase1.Columns[1].OwnerBand.AppearanceHeader.BackColor = Color.FromArgb(128, 128, 128);
            gvwBase1.Columns[1].OwnerBand.AppearanceHeader.BackColor2 = Color.FromArgb(128, 128, 128);
            gvwBase1.Columns[1].OwnerBand.AppearanceHeader.ForeColor = Color.White;



            for (int i = 0; i < gvwBase1.Columns.Count; i++)
            {
                gvwBase1.Columns[i].OptionsColumn.AllowEdit = false;
                gvwBase1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvwBase1.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gvwBase1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvwBase1.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gvwBase1.Columns[i].OwnerBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvwBase1.Columns[i].OwnerBand.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gvwBase1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;

                if (i > 3)
                {
                    gvwBase1.Columns[i].OwnerBand.AppearanceHeader.BackColor = Color.FromArgb(57, 190, 29);
                    gvwBase1.Columns[i].OwnerBand.AppearanceHeader.BackColor2 = Color.FromArgb(57, 190, 29);
                    gvwBase1.Columns[i].OwnerBand.AppearanceHeader.ForeColor = Color.White;


                    gvwBase1.Columns[i].OwnerBand.AppearanceHeader.BackColor = Color.FromArgb(255, 127, 0);
                    gvwBase1.Columns[i].OwnerBand.AppearanceHeader.BackColor2 = Color.FromArgb(255, 127, 0);
                    gvwBase1.Columns[i].OwnerBand.AppearanceHeader.ForeColor = Color.White;


                    //  gvwBase1.Columns[i].OwnerBand.
                    gvwBase1.Columns[i].Width = (grdBase.Width - gvwBase1.Columns[0].OwnerBand.Width) / (gvwBase1.Columns.Count - 1);
                    gvwBase1.Columns[i].OwnerBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvwBase1.Columns[i].OwnerBand.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gvwBase1.Columns[i].OwnerBand.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                }
                else if (i <= 3)
                {
                    gvwBase1.Columns[i].OwnerBand.AppearanceHeader.BackColor = Color.FromArgb(128, 128, 128);
                    gvwBase1.Columns[i].OwnerBand.AppearanceHeader.BackColor2 = Color.FromArgb(128, 128, 128);
                    gvwBase1.Columns[i].OwnerBand.AppearanceHeader.ForeColor = Color.White;
                    gvwBase1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    gvwBase1.Columns[i].OwnerBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                }
            }
            gvwBase1.Columns[0].OwnerBand.Caption = "Plant";
            gvwBase1.Columns[1].OwnerBand.Caption = "Line";
            gvwBase1.Columns[2].OwnerBand.Caption = "Style Code";
            gvwBase1.Columns[3].OwnerBand.Caption = "DIV";

            gvwBase1.Columns[0].OwnerBand.Width = 100;
            gvwBase1.Columns[1].OwnerBand.Width = 100;
            gvwBase1.Columns[2].OwnerBand.Width = 200;
            gvwBase1.Columns[3].OwnerBand.Width = 200;

        }

        public void CreateSizeGrid(DevExpress.XtraGrid.GridControl gridControl, BandedGridView gridView, DataTable dt)
        {
            //gridControl.Hide();
            gridView.BeginDataUpdate();
            try
            {
                bool flag = false;
                gridView.OptionsView.ShowGroupPanel = false;
                gridView.OptionsView.AllowCellMerge = true;
                gridView.Columns.Clear();
                gridView.Bands.Clear();
                gridView.OptionsView.ShowColumnHeaders = false;
                gridView.OptionsView.ColumnAutoWidth = false;
                DevExpress.XtraGrid.Views.BandedGrid.GridBand[] band_parent = new DevExpress.XtraGrid.Views.BandedGrid.GridBand[dt.Columns.Count];
                DevExpress.XtraGrid.Views.BandedGrid.GridBand[] band_child = new DevExpress.XtraGrid.Views.BandedGrid.GridBand[dt.Columns.Count - 2];
                int i_arr = 0;
                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    band_parent[i] = new GridBand() { Caption = dt.Columns[i].ColumnName.ToString() };
                    gridView.Bands.Add(band_parent[i]);
                    band_parent[i].Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName.ToString(), Visible = true, Caption = band_parent[i].Caption });


                }
                band_parent[0].RowCount = 2;
                gridView.OptionsView.ColumnAutoWidth = false;

            }
            catch (Exception EX)
            {
                //throw EX;
            }
            gridView.EndDataUpdate();
            gridView.ExpandAllGroups();
        }
        private void gvwBase1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

            try
            {
                //if (e.RowHandle % 2 == 0)
                //    e.Appearance.BackColor = Color.FromArgb(219, 251, 255);
                string DIV = gvwBase1.GetRowCellValue(e.RowHandle, gvwBase1.Columns["SIZE"]).ToString();
                if (DIV.ToUpper().Equals("UPPER") && e.Column.AbsoluteIndex > 2)
                    e.Appearance.BackColor = Color.FromArgb(128, 221, 255);
                if (e.Column.ColumnHandle > 3)
                {
                    string c = gvwBase1.GetRowCellValue(e.RowHandle, e.Column).ToString();
                    if (c.Contains("R"))
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }

            }
            catch (Exception ex) { }
        }
        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                if (e.RowHandle1 < 0 || gvwBase1.RowCount == 0)
                    return;
                e.Merge = false;
                e.Handled = true;

                if (e.Column.FieldName.Contains("LINE_CD"))
                {
                    string ymd1 = gvwBase1.GetRowCellDisplayText(e.RowHandle1, e.Column.FieldName).Trim();
                    string ymd2 = gvwBase1.GetRowCellDisplayText(e.RowHandle2, e.Column.FieldName).Trim();

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
                    string ymd1 = gvwBase1.GetRowCellDisplayText(e.RowHandle1, "LINE_CD").Trim() + gvwBase1.GetRowCellDisplayText(e.RowHandle1, e.Column.FieldName).Trim();
                    string ymd2 = gvwBase1.GetRowCellDisplayText(e.RowHandle2, "LINE_CD").Trim() + gvwBase1.GetRowCellDisplayText(e.RowHandle2, e.Column.FieldName).Trim();

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
                    string ymd1 = gvwBase1.GetRowCellDisplayText(e.RowHandle1, "LINE_CD").Trim() + gvwBase1.GetRowCellDisplayText(e.RowHandle1, "MLINE_CD").Trim() + gvwBase1.GetRowCellDisplayText(e.RowHandle1, e.Column.FieldName).Trim();
                    string ymd2 = gvwBase1.GetRowCellDisplayText(e.RowHandle2, "LINE_CD").Trim() + gvwBase1.GetRowCellDisplayText(e.RowHandle2, "MLINE_CD").Trim() + gvwBase1.GetRowCellDisplayText(e.RowHandle2, e.Column.FieldName).Trim();

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

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
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



        private void FRM_TMS_BALANCE_UP_LT_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (ComVar.Var._strValue1.Equals("FTY01"))
                    lblTitle.Text = "FACTORY 1 - COMPONENT NOT YET INCOMING";
                else if (ComVar.Var._strValue1.Equals("099"))
                    lblTitle.Text = "NOS N - COMPONENT NOT YET INCOMING";
                iCount = 50;
                tmrDate.Start();
            }
            else
                tmrDate.Stop();

        }

    }
}
