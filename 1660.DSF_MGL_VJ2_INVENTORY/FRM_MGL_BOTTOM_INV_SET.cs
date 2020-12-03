using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using System.Data.OracleClient;
using System.Runtime.InteropServices;

namespace FORM
{
    public partial class FRM_MGL_BOTTOM_INV_SET : Form
    {
        public FRM_MGL_BOTTOM_INV_SET()
        {
            InitializeComponent();
        }
        
        string line, mline,Lang;
        int _start_column = 0;
        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);
        const int AW_SLIDE = 0X40000;
        const int AW_HOR_POSITIVE = 0X4;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_BLEND = 0X80000;
        const int AW_HIDE = 0x00010000;
       

        int int_count = 0;
        //int i_col_cur = 0;
        Color BackColor1 = Color.FromArgb(232, 246, 247);
        Color BackColor2 = Color.White;

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
        private void FRM_SMT_MON_PROD_STATUS_Load(object sender, EventArgs e)
        {
            //ClassLib.ComCtl.Form_Maximized(this, indexScreen); //2 man hinh tro len
            GoFullscreen(true);
            setConfigForm();
           // axfpSpread.SetText(1, 1, "Month");
          //  axfpSpread.Hide();
            //load_data();
           // ClearGrid(axfpSpread);
           //showAnimation(axfpSpread);
            //CreateChart();
        }
                
       

        private void showAnimation(Control flg)
        {
            flg.Hide();
            timer2.Stop();
            this.Cursor = Cursors.WaitCursor;
            load_data("MAIN");
            AnimateWindow(flg.Handle, 300, AW_SLIDE | 0X4); //IPEX_Monitor.ClassLib.WinAPI.getSlidType("2")
            flg.Show();
            timer2.Interval = 1000;
            timer2.Start();
            this.Cursor = Cursors.Default;
        }
        private void load_data(string arg_type)
        {
            try
            {
                DataTable dt = SEL_SMT_BOTTOM_INV_SET(arg_type, line, mline, "");

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataTable dtSource = new DataTable();
                    grdMain.DataSource = null;
                    while (gvwMain.Columns.Count > 0)
                    {
                        gvwMain.Columns.RemoveAt(0);
                    }
                    if (buildHeader_detail(dtSource, dt))
                    {
                        if (bindingDataSource_detail(dtSource, dt))
                        {
                            if (arg_type == "MAIN")
                            {
                                grdMain.DataSource = dtSource;
                                formatgrid1();
                            }

                        }
                    }
                }
                else
                {
                    grdMain.DataSource = null;
                }
            }
            catch 
            {
                
            }
        }

        private void formatgrid1()
        {
            try
            {
                gvwMain.BeginUpdate();
                gvwMain.RowHeight = 40;
                for (int i = 0; i < gvwMain.Columns.Count; i++)
                {
                    gvwMain.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvwMain.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gvwMain.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gvwMain.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    gvwMain.Columns[i].OptionsColumn.ReadOnly = true;
                    gvwMain.Columns[i].OptionsColumn.AllowEdit = false;
                    gvwMain.Columns[i].AppearanceHeader.Font = new Font("Calibri", 17, FontStyle.Bold);
                    gvwMain.Columns[i].AppearanceCell.Font = new Font("Calibri", 15, FontStyle.Regular);
                    if (i < 2)
                    {
                        gvwMain.Columns[i].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                        gvwMain.Columns[i].Visible = false;
                    }
                    else
                    {
                        if (i > 7)
                        {
                            gvwMain.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                            gvwMain.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                            gvwMain.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            gvwMain.Columns[i].DisplayFormat.FormatString = "#,#";
                            gvwMain.Columns[i].Width = 55;
                            if (i == 8)
                            {
                                gvwMain.Columns[i].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                                gvwMain.Columns[i].Width = 75;
                            }
                        }
                        else
                        {
                            gvwMain.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                            gvwMain.Columns[i].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                            if (i == 6)
                                gvwMain.Columns[i].Visible = false;
                            else if (i == 2 || i == 3 || i == 5)
                                gvwMain.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            else if (i == 5 || i == 6 || i == 7)
                                gvwMain.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                        }
                    }
                }
                gvwMain.Columns[2].Width = 80;
                gvwMain.Columns[3].Width = 65;
                gvwMain.Columns[4].Width = 220;
                gvwMain.Columns[5].Width = 120;
                gvwMain.Columns[7].Width = 220;
                gvwMain.EndUpdate();
            }
            catch { }
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
            catch 
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
                    if (distinct_row != dtTemp.Rows[i]["DISTINCTROW"].ToString())
                    {
                        dtSource.Rows.Add();
                    }
                    distinct_row = dtTemp.Rows[i]["DISTINCTROW"].ToString();
                    for (int j = 0; j < _start_column - 1; j++)
                    {
                        dtSource.Rows[dtSource.Rows.Count - 1][j] = dtTemp.Rows[i][j];
                    }

                    int.TryParse(dtTemp.Rows[i]["QTY"].ToString(), out temp1);
                    int.TryParse(dtSource.Rows[dtSource.Rows.Count - 1][dtTemp.Rows[i]["SIZE_CD"].ToString()].ToString(), out temp2);
                    dtSource.Rows[dtSource.Rows.Count - 1][dtTemp.Rows[i]["SIZE_CD"].ToString()] = Convert.ToDecimal(temp1 + temp2);
                    int.TryParse(dtSource.Rows[dtSource.Rows.Count - 1][_start_column - 1].ToString(), out temp2);
                    dtSource.Rows[dtSource.Rows.Count - 1][_start_column - 1] = (temp1 + temp2).ToString();
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }
        
        public DataTable SEL_SMT_BOTTOM_INV_SET(string ARG_QTYPE, string ARG_LINE, string ARG_MLINE, string ARG_DATE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_PROD.SP_SMT_BOTTOM_INV_SET";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_LINE";
                MyOraDB.Parameter_Name[2] = "V_P_MLINE";
                MyOraDB.Parameter_Name[3] = "V_P_DATE";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_LINE;
                MyOraDB.Parameter_Values[2] = ARG_MLINE;
                MyOraDB.Parameter_Values[3] = ARG_DATE;
                MyOraDB.Parameter_Values[4] = "";


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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void stackedBarChart_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
        {
            try
            {
                if (e.Item.Axis is AxisX)
                {                    
                    e.Item.Text = e.Item.Text.Replace("_", "\n"); 
                }
            }
            catch
            {

            }
        }

        
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (int_count < 30)
                    int_count++;
                else
                {
                    int_count = 0;
                    showAnimation(grdMain);
                }
            }
            catch
            {
            }
        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            load_data("MAIN");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FRM_SMT_MON_PROD_STATUS_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cmdBack.Tag = ComVar.Var._Frm_Back;
                mline = ComVar.Var._strValue2;
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                int_count = 29;
                initForm();
                timer1.Start();
                timer2.Start();
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
            }
        }

        private void initForm()
        {
            line = ComVar.Var._strValue1;
            mline = ComVar.Var._strValue2;
            Lang = ComVar.Var._strValue3;
            switch (Lang)
            {
                case "Vn":
                    lblTitle.Text = "Đế tồn đồng Set";
                    break;
                case "En":
                    lblTitle.Text = "Bottom Inventory Set Balance";
                    break;
            }
            
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {

            ComVar.Var.callForm = "back";
        }

        private void menu_Click(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            ComVar.Var.callForm = cnt.Tag == null ? "" : cnt.Tag.ToString();
        }

        #region  Get Config Data From Database
        /// <summary>
        /// Declare _dtnInit
        /// Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        /// </summary>
        private void setConfigForm()
        {
            try
            {
                System.Collections.Generic.Dictionary<string, string> dtnInit = new System.Collections.Generic.Dictionary<string, string>();
                dtnInit = ComVar.Func.getInitForm(ComVar.Var._Area + this.GetType().Assembly.GetName().Name, this.GetType().Name);

                for (int i = 0; i < dtnInit.Count; i++)
                {
                    setComValue(dtnInit.ElementAt(i).Key, dtnInit.ElementAt(i).Value);
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setConfigForm-->Err:    " + ex.ToString());
            }
        }

        private void setComValue(string obj, string obj_value)
        {
            try
            {
                if (obj.Contains('.'))
                {
                    string[] strSplit = obj.Split('.');
                    Control[] cnt = this.Controls.Find(strSplit[0], true);

                    for (int i = 0; i < cnt.Length; i++)
                    {
                        System.Reflection.PropertyInfo propertyInfo = cnt[i].GetType().GetProperty(strSplit[1]);
                        propertyInfo.SetValue(cnt[i], Convert.ChangeType(obj_value, propertyInfo.PropertyType), null);
                    }
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setComValue (" + obj + ", " + obj_value + ") Err:    " + ex.ToString());
            }

        }
        #endregion 

        private void gvwMain_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (gvwMain.GetRowCellValue(e.RowHandle, "Component").ToString() == "SET" && e.Column.ColumnHandle > 3)
            {
                e.Appearance.BackColor = Color.FromArgb(255, 224, 255, 255);
                e.Appearance.ForeColor = Color.FromArgb(255, 255, 127, 80);
            }
            if (gvwMain.GetRowCellValue(e.RowHandle, "Plant").ToString() == "TOTAL")
            {
                e.Appearance.BackColor = Color.FromArgb(255, 248, 255, 191);
                e.Appearance.ForeColor = Color.Black;
            }
        }
    }
}
