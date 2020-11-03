using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Drawing.Drawing2D;
using DevExpress.XtraCharts;
using DevExpress.XtraGauges.Core.Model;
using System.Globalization;


//using Microsoft.VisualBasic.PowerPacks;
//using C1.Win.C1FlexGrid;

namespace FORM
{
    public partial class FRM_MGL_INVENTORY : Form
    {
        public FRM_MGL_INVENTORY()
        {
            InitializeComponent();
        }

        Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        int indexScreen;
        #region Variable       
        int _icount = 0;
        string _line_cd = ComVar.Var._strValue1;
        string _mline_cd = ComVar.Var._strValue2;
        string Lang;
        private MyCellMergeHelper _Helper;
        bool first = true;
        #endregion
           
        int _iTime;
        public FRM_MGL_INVENTORY(string Title, int _indexScreen, string wh_cd, string mline_cd, string _Lang)
        {
            InitializeComponent(); 
            Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
            indexScreen = _indexScreen;           
            Lang = _Lang;
            timer1.Stop();
            lblTitle.Text = Title;
        }         
       
        #region Func

        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }        

        private void BindingData( string _line_cd)
        {
            try
            {
                //if (first)
                //{
                //    _Helper = new MyCellMergeHelper(gridView1);
                //    first = false;
                //}
                grid.Refresh();
                DataTable dtsource = null;
                grid.DataSource = dtsource;
                gridView1.Columns.Clear();
                dtsource = SEL_INVENTORY_SHORTAGE(_line_cd);
                grid.DataSource = dtsource;
                gridView1.Columns[0].Width = 60;
                gridView1.Columns[1].Width = 90;
                gridView1.Columns[2].Width = 190;
                gridView1.Columns[3].Width = 93;
                gridView1.Columns[4].Width = 120;
                gridView1.OptionsView.AllowCellMerge = true;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    if (i <= 4)
                    {
                        gridView1.Columns[i].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    }
                }
                gridView1.TopRowIndex = gridView1.RowCount - 1;
                //gridView1.Columns[0].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                //gridView1.Columns[1].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                //gridView1.Columns[2].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (i < 5)
                    {
                        gridView1.Columns[i].Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(gridView1.Columns[i].GetCaption().Replace("_", " ").ToLower());
                        gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    }
                    else
                    {
                        gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    }
                }
                //_Helper.removeMerged();
                //if (first)
                //    _Helper = new MyCellMergeHelper(gridView1);
                //_Helper.AddMergedCell(gridView1.RowCount - 1, 0, 1, "");
                //_Helper.AddMergedCell(gridView1.RowCount - 1, 1, 2, "");
                //_Helper.AddMergedCell(gridView1.RowCount - 1, 2, 3, "");

                //_Helper.AddMergedCell(gridView1.RowCount - 2, 0, 1, "");
                //_Helper.AddMergedCell(gridView1.RowCount - 2, 1, 2, "");
                //_Helper.AddMergedCell(gridView1.RowCount - 2, 2, 3, "");

                //_Helper.AddMergedCell(gridView1.RowCount - 3, 0, 1, "");
                //_Helper.AddMergedCell(gridView1.RowCount - 3, 1, 2, "");
                //_Helper.AddMergedCell(gridView1.RowCount - 3, 2, 3, "");
            }
            catch(Exception ex)
            {

            }
        }      

        private void load_data()
        {  
            _dtnInit = ComVar.Func.getInitForm(this.GetType().Assembly.GetName().Name, this.GetType().Name);
            _line_cd = ComVar.Var._strValue1;
            BindingData(_line_cd);        
            pn_body.Visible = true;  
        }
        #endregion Func

        #region DB
        public DataTable SEL_INVENTORY_SHORTAGE(string ARG_LINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_MGL_VJ3.MGL_INVENTORY_DATA_SELECT";

                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = "Q1";
                MyOraDB.Parameter_Values[1] = ARG_LINE_CD;
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
        #endregion DB

        #region event
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                _icount++;
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
                _iTime = DateTime.Now.Hour;
                if (_icount == 60)
                {
                    load_data();
                    _icount = 0;
                }
            }
            catch (Exception)
            { }
        }

        private void FRM_MGL_INVENTORY_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    _line_cd = ComVar.Var._strValue1;
                    Lang = ComVar.Var._strValue3;
                    BindingData(_line_cd);
                    lblTitle.Text = "Outgoing Area Shortage";
                    //switch (Lang)
                    //{
                    //    case "Vi":
                    //        lblTitle.Text = "Hàng thiếu khu vực xuất hàng";
                    //        break;
                    //    default:
                    //        lblTitle.Text = "Outgoing Area Shortage";
                    //        break;
                    //}
                    _icount = 59;
                    timer1.Start();
                }
                else
                {
                    timer1.Stop();
                }
            }
            catch (Exception)
            { }
        }
        private void FRM_MGL_INVENTORY_Load(object sender, EventArgs e)
        {
            try
            {
                GoFullscreen(true);
                pn_body.Visible = false;
                //ClassLib.ComCtl.Form_Maximized(this, indexScreen); //2 man hinh tro len
                _dtnInit = ComVar.Func.getInitForm(this.GetType().Assembly.GetName().Name, this.GetType().Name);
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
                string _line_cd = ComVar.Var._strValue1;
                BindingData(_line_cd);
                switch (Lang)
                {
                    case "Vi":
                        simpleButton4.Text = "Ngày";
                        simpleButton3.Text = "Tháng";
                        simpleButton2.Text = "Tuần";
                        simpleButton1.Text = "Năm";
                        break;
                    case "En":
                        simpleButton4.Text = "Day";
                        simpleButton3.Text = "Month";
                        simpleButton2.Text = "Week";
                        simpleButton1.Text = "Year";
                        break;
                }  
            }
            catch (Exception)
            { }
        }       

        #endregion event      

        private void button1_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";// _dtnInit["frmHome"];
        }        

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception)
            { }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.ColumnHandle < 4)
            {
                return;
            }
            if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns[4]).ToString() == "Plan (Prs)")
            {
                e.Appearance.ForeColor = Color.Blue;
            }
            if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns[4]).ToString() == "Shortage (Prs)")
            {
                e.Appearance.ForeColor = Color.Red;
            }
            if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns[4]).ToString() == "Finish Rate (%)")
            {
                e.Appearance.BackColor = Color.PaleGreen;
            }
            if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns[4]).ToString() == "Total Outgoing (Prs)")
            {
                e.Appearance.BackColor = Color.PaleTurquoise;
            }
            if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns[4]).ToString() == "Total Plan (Prs)")
            {
                e.Appearance.BackColor = Color.LemonChiffon;
            }
            if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns[4]).ToString() == "Total Shortage (Prs)")
            {
                e.Appearance.BackColor = Color.BlanchedAlmond;
                e.Appearance.ForeColor = Color.Red;
            }
            if (e.Column.ColumnHandle == gridView1.Columns.Count-1)
            {
                e.Appearance.BackColor = Color.Coral;
                e.Appearance.ForeColor = Color.White;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                if (e.RowHandle1 < 0 || gridView1.RowCount == 0)
                    return;
                e.Merge = false;
                e.Handled = true;

                if (e.Column.FieldName == "LINE")
                {
                    string line1 = gridView1.GetRowCellDisplayText(e.RowHandle1, "LINE").Trim();
                    string line2 = gridView1.GetRowCellDisplayText(e.RowHandle2, "LINE").Trim();

                    if (line1 == line2)
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }

                if (e.Column.FieldName == "MINI_LINE")
                {
                    string line1 = gridView1.GetRowCellDisplayText(e.RowHandle1, "LINE").Trim();
                    string line2 = gridView1.GetRowCellDisplayText(e.RowHandle2, "LINE").Trim();

                    string mline1 = gridView1.GetRowCellDisplayText(e.RowHandle1, "MINI_LINE").Trim();
                    string mline2 = gridView1.GetRowCellDisplayText(e.RowHandle2, "MINI_LINE").Trim();

                    if (line1 == line2 && mline1 == mline2)
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }

                if (e.Column.FieldName == "STYLE_CODE")
                {
                    string line1 = gridView1.GetRowCellDisplayText(e.RowHandle1, "LINE").Trim();
                    string line2 = gridView1.GetRowCellDisplayText(e.RowHandle2, "LINE").Trim();

                    string mline1 = gridView1.GetRowCellDisplayText(e.RowHandle1, "MINI_LINE").Trim();
                    string mline2 = gridView1.GetRowCellDisplayText(e.RowHandle2, "MINI_LINE").Trim();

                    string style1 = gridView1.GetRowCellDisplayText(e.RowHandle1, "STYLE_CODE").Trim();
                    string style2 = gridView1.GetRowCellDisplayText(e.RowHandle2, "STYLE_CODE").Trim();

                    if (line1 == line2 && mline1 == mline2 && style1 == style2)
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }

                if (e.Column.FieldName == "STYLE_NAME")
                {
                    string line1 = gridView1.GetRowCellDisplayText(e.RowHandle1, "LINE").Trim();
                    string line2 = gridView1.GetRowCellDisplayText(e.RowHandle2, "LINE").Trim();

                    string mline1 = gridView1.GetRowCellDisplayText(e.RowHandle1, "MINI_LINE").Trim();
                    string mline2 = gridView1.GetRowCellDisplayText(e.RowHandle2, "MINI_LINE").Trim();

                    string style1 = gridView1.GetRowCellDisplayText(e.RowHandle1, "STYLE_NAME").Trim();
                    string style2 = gridView1.GetRowCellDisplayText(e.RowHandle2, "STYLE_NAME").Trim();

                    if (line1 == line2 && mline1 == mline2 && style1 == style2 )
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }

            }
            catch { }
        }
    }
}
