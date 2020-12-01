using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.OracleClient;
using System.Data;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid;

namespace FORM
{
    public partial class frm_msg_detail_set : Form
    {
        //public IPEX_Monitor.ClassLib.Class_Sound sound = new IPEX_Monitor.ClassLib.Class_Sound("waterdrop.wav");
       
        public frm_msg_detail_set()
        {
            InitializeComponent();
        }

        public frm_msg_detail_set(string _sDate, string _sLineCD, string _sUPCMLineCD, string _sUPSMLineCD, string _sStyleCD, string _sCS_Size, string _sPrio_Input, string _sQty, string _sOPCD)
        {
            InitializeComponent();
            sDate = _sDate;
            sLineCD = _sLineCD;
            sUPCMLineCD = _sUPCMLineCD;
            sUPSMLineCD = _sUPSMLineCD;
            sStyleCD = _sStyleCD;
            sCS_Size = _sCS_Size;
            sPrio_Input = _sPrio_Input;
            Prod = _sQty;
            sOPCD = _sOPCD;            
        }
        private static int iTotalPC =  20;
        private bool sSearchAgain = false;
        int START_COLUMN = 0;
        DataTable dataSource = new DataTable();

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        #region variable
        //string Style, Size ;
        private CellColorHelper _CellColorHelper;
        DataTable dt_color, dt_save;
        
        public delegate void ButtonCloseHandler(bool sSearchAgain);
        public delegate void ButtonOKHandler(DataTable dt);
        public delegate void ButtonReasonHandler(DataTable dt);
        public delegate void ButtonTransferHandler(DataTable dt);
        string sDate, sOPCD, sLineCD, sUPCMLineCD, sUPSMLineCD, sStyleCD, sCS_Size, sPrio_Input, Prod, sReason = "";
        #endregion
        public event ButtonCloseHandler OnClosing = null;
        public event ButtonOKHandler OnConfirm = null;
        public event ButtonReasonHandler OnConfirmReason = null;
        public event ButtonTransferHandler OnConfirmTransfer = null;
        private void frm_msg_Load(object sender, EventArgs e)
        {            
            _CellColorHelper = new CellColorHelper(gvwView);            
        }

        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
        

        public void BingDingData(DataTable dt)
        {
            try
            {
                START_COLUMN = int.Parse(dt.Rows[0]["START_COLUMN"].ToString());
                createGrid(dt, grdView, gvwView);
                if (binding_detail(dataSource, dt))
                {
                    grdView.DataSource = dataSource;
                    formatgrid2();
                }                
            }
            catch
            {
            }
            finally
            {
            }

        }

        private void formatgrid2()
        {
            for (int i = 0; i < gvwView.Columns.Count; i++)
            {
                gvwView.Columns[i].OptionsColumn.ReadOnly = true;
                gvwView.Columns[i].OptionsColumn.AllowEdit = false;
                gvwView.Columns[i].OptionsFilter.AllowFilter = false;
                gvwView.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvwView.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gvwView.Columns[i].AppearanceHeader.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
                gvwView.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

                gvwView.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Regular);
                gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvwView.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                if (i < START_COLUMN)
                {
                    gvwView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    gvwView.Columns[i].Width = 100;
                    if (gvwView.Columns[i].FieldName.Equals("Part Name"))
                        gvwView.Columns[i].Width = 150;
                    if (i == 0)
                        gvwView.Columns[i].OwnerBand.Visible = false;
                }
                else
                {
                    gvwView.Columns[i].Width = 70;
                    gvwView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    gvwView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gvwView.Columns[i].DisplayFormat.FormatString = "#,#";

                }
            }
            //gvwView.BestFitColumns();
        }

        private void createGrid(DataTable dt, GridControl gridControl, BandedGridView gridView)
        {
            try
            {
                gridControl.BeginUpdate();
                gridView.OptionsView.ShowGroupPanel = false;
                gridView.OptionsView.AllowCellMerge = true;
                gridView.BandPanelRowHeight = 35;
                gridView.Bands.Clear();
                gridView.OptionsView.ShowColumnHeaders = false;
                GridBand band = null;
                GridBand bandchlid = null;
                for (int i = 0; i < START_COLUMN; i++)
                {
                    band = new GridBand() { Caption = dt.Columns[i].ColumnName };
                    gridView.Bands.Add(band);
                    dataSource.Columns.Add(dt.Columns[i].ColumnName, typeof(string));
                    band.Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName, Visible = true, Caption = dt.Columns[i].ColumnName });                    
                }
                if (dt.Select("STT = 99", "SIZE_NUM ASC").Length > 0)
                {
                    DataTable dttemp = dt.Select("STT = 99", "SIZE_NUM ASC").CopyToDataTable();
                    for (int i = 0; i < dttemp.Rows.Count; i++)
                    {
                        band = new GridBand() { Caption = dttemp.Rows[i]["SIZE_CD"].ToString() };
                        gridView.Bands.Add(band);
                        //plan
                        bandchlid = new GridBand() { Caption = "Plan" };
                        band.Children.Add(bandchlid);
                        bandchlid.Columns.Add(new BandedGridColumn() { FieldName = "Plan" + dttemp.Rows[i]["SIZE_CD"].ToString(), Visible = true, Caption = "Plan" + dttemp.Rows[i]["SIZE_CD"].ToString() });

                        dataSource.Columns.Add("Plan" + dttemp.Rows[i]["SIZE_CD"].ToString(), typeof(decimal));
                        //prod
                        bandchlid = new GridBand() { Caption = "Prod" };
                        band.Children.Add(bandchlid);
                        bandchlid.Columns.Add(new BandedGridColumn() { FieldName = "Prod" + dttemp.Rows[i]["SIZE_CD"].ToString(), Visible = true, Caption = "Prod" + dttemp.Rows[i]["SIZE_CD"].ToString() });

                        dataSource.Columns.Add("Prod" + dttemp.Rows[i]["SIZE_CD"].ToString(), typeof(decimal));

                    }
                    foreach (GridBand gb in gridView.Bands)
                    {
                        FormatBand(gb);

                    }
                    gridControl.EndUpdate();
                }
            }
            catch (Exception EX) { }
        }

        private bool binding_detail(DataTable dtSource, DataTable dtTemp)
        {
            try
            {
                int[] rowtotal = new int[dtSource.Columns.Count];
                string distinct_row = "";
                int temp1, temp2;
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if (distinct_row != dtTemp.Rows[i]["DISTINCTROW"].ToString())
                    {
                        dtSource.Rows.Add();
                    }
                    distinct_row = dtTemp.Rows[i]["DISTINCTROW"].ToString();
                    for (int j = 0; j < START_COLUMN; j++)
                    {
                        dtSource.Rows[dtSource.Rows.Count - 1][j] = dtTemp.Rows[i][j];
                    }
                    int.TryParse(dtTemp.Rows[i]["Plan"].ToString(), out temp1);
                    if (dtSource.Columns["Plan" + dtTemp.Rows[i]["SIZE_CD"].ToString()].ColumnName.Contains(dtTemp.Rows[i]["SIZE_CD"].ToString()))
                    {
                        dtSource.Rows[dtSource.Rows.Count - 1]["Plan" + dtTemp.Rows[i]["SIZE_CD"].ToString()] = temp1;
                    }
                    int.TryParse(dtTemp.Rows[i]["Prod"].ToString(), out temp1);
                    if (dtSource.Columns["Prod" + dtTemp.Rows[i]["SIZE_CD"].ToString()].ColumnName.Contains(dtTemp.Rows[i]["SIZE_CD"].ToString()))
                    {
                        dtSource.Rows[dtSource.Rows.Count - 1]["Prod" + dtTemp.Rows[i]["SIZE_CD"].ToString()] = temp1;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void FormatBand(GridBand root)
        {
            root.AppearanceHeader.Options.UseTextOptions = true;
            root.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            root.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            root.AppearanceHeader.Font = new Font("Calibri", 14, FontStyle.Bold);
            root.OptionsBand.FixedWidth = true;
            if (root.Children.Count > 0)
            {
                foreach (GridBand child in root.Children)
                {
                    FormatBand(child);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvwView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (gvwView.GetRowCellValue(e.RowHandle, "Process").ToString().Equals("SET TOTAL"))
            {
                e.Appearance.BackColor = Color.FromArgb(92, 207, 249);
            }
        }

        private void gvwView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.FieldName.Contains("CONFIRM_YN") && e.CellValue.ToString() != "")
            {
                if (sOPCD.Equals("UPS"))
                {
                    if (dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"].ToString().Contains("_B"))
                    {
                        dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"] = gvwView.GetRowCellDisplayText(e.RowHandle, e.Column.FieldName.Substring(0, 3) + "QTY").Replace("_B", "_O");
                        _CellColorHelper.SetCellColor(e.RowHandle, gvwView.Columns[e.Column.FieldName.Substring(0, 3) + "QTY"], Color.Orange);
                    }
                    else if (dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"].ToString().Contains("_O")
                        && dt_save.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"].ToString().Contains("_O"))
                    {
                        dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"] = gvwView.GetRowCellDisplayText(e.RowHandle, e.Column.FieldName.Substring(0, 3) + "QTY").Replace("_O", "_B");
                        _CellColorHelper.SetCellColor(e.RowHandle, gvwView.Columns[e.Column.FieldName.Substring(0, 3) + "QTY"], Color.DodgerBlue);

                    }
                    else if (dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"].ToString().Contains("_O")
                            && dt_save.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"].ToString().Contains("_B"))
                    {
                        dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"] = gvwView.GetRowCellDisplayText(e.RowHandle, e.Column.FieldName.Substring(0, 3) + "QTY").Replace("_O", "_B");
                        _CellColorHelper.SetCellColor(e.RowHandle, gvwView.Columns[e.Column.FieldName.Substring(0, 3) + "QTY"], Color.DodgerBlue);

                    }
                    else if (dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"].ToString().Contains("_O")
                        && dt_save.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"].ToString().Contains("_R"))
                    {
                        dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"] = gvwView.GetRowCellDisplayText(e.RowHandle, e.Column.FieldName.Substring(0, 3) + "QTY").Replace("_O", "_R");
                        _CellColorHelper.SetCellColor(e.RowHandle, gvwView.Columns[e.Column.FieldName.Substring(0, 3) + "QTY"], Color.Red);

                    }
                    else if (dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"].ToString().Contains("_R"))
                    {
                        dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"] = gvwView.GetRowCellDisplayText(e.RowHandle, e.Column.FieldName.Substring(0, 3) + "QTY").Replace("_R", "_O");
                        _CellColorHelper.SetCellColor(e.RowHandle, gvwView.Columns[e.Column.FieldName.Substring(0, 3) + "QTY"], Color.Orange);
                    }
                }
                else
                {
                    if (dt_color.Rows[e.RowHandle][e.Column.FieldName].ToString().Contains("N"))
                    {
                        dt_color.Rows[e.RowHandle][e.Column.FieldName] = gvwView.GetRowCellValue(e.RowHandle, e.Column.FieldName).ToString().Replace("N", "I");
                        _CellColorHelper.SetCellColor(e.RowHandle, gvwView.Columns[e.Column.FieldName.Substring(0, 3) + "QTY"], Color.Orange);
                    }
                    else if (dt_color.Rows[e.RowHandle][e.Column.FieldName].ToString().Contains("I"))
                    {
                        dt_color.Rows[e.RowHandle][e.Column.FieldName] = gvwView.GetRowCellDisplayText(e.RowHandle, e.Column.FieldName).ToString().Replace("I", "N");
                        _CellColorHelper.SetCellColor(e.RowHandle, gvwView.Columns[e.Column.FieldName.Substring(0, 3) + "QTY"], Color.DodgerBlue);

                    }
                }
            }
        }

        private void gvwView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (e.Column.FieldName.Contains("CONFIRM_YN"))
            //{
            //e.Appearance.FillRectangle(e.Cache, e.Bounds) ; 
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo  cellInfo = new DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo(); 
            
            //DevExpress.Utils.ImageCollection.DrawImageListImage(e.Cache, ImageCollection32onSoftwareXtraForm, index, cellInfo.CellValueRect)  
            //e.Handled = True  
       
            //}
        }

        private void AddUnboundColumn(DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            view.Columns["C1_CONFIRM_YN"].UnboundType = DevExpress.Data.UnboundColumnType.Object;
            RepositoryItemPictureEdit ri1 = new RepositoryItemPictureEdit();
            ri1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            view.Columns["C1_CONFIRM_YN"].ColumnEdit = ri1;

            view.Columns["C2_CONFIRM_YN"].UnboundType = DevExpress.Data.UnboundColumnType.Object;
            RepositoryItemPictureEdit ri2 = new RepositoryItemPictureEdit();
            ri2.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            view.Columns["C2_CONFIRM_YN"].ColumnEdit = ri2;
            //DevExpress.XtraGrid.Columns.GridColumn col1 = view.Columns.AddVisible("C1_CONFIRM_YN");
            //col1.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            //RepositoryItemPictureEdit ri1 = new RepositoryItemPictureEdit();
            //ri1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            //col1.ColumnEdit = ri1;

            //DevExpress.XtraGrid.Columns.GridColumn col2 = view.Columns.AddVisible("C2_CONFIRM_YN");
            //col2.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            //RepositoryItemPictureEdit ri2 = new RepositoryItemPictureEdit();
            //ri2.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            //col2.ColumnEdit = ri2;
        }
    }
}
