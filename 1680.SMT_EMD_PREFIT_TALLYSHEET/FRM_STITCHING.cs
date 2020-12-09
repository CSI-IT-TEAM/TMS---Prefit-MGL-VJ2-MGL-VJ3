using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Collections;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Reflection;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace FORM
{
    public partial class FRM_STITCHING : Form
    {
        public FRM_STITCHING()
        {
            InitializeComponent();

        }
        private int cCount = 0;
        DataTable _dtXML = null;
        const int TimeRefresh = 180; //60 sec
        string _PLANT_CD = "", _LINE = "", _LINENAME = "", _MLINE = "", _OPCD = "", _DIV = "", _COL = "", _CUR_COL1 = "", _CUR_COL2 = "";
        public string _lang = "";
        bool _sSearchAgain = true, flag = false;
        #region DB
        private DataTable SELECT_CBO_LINE(string ARG_TYPE, string ARG_PLANT, string ARG_LINE, string ARG_DIV)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_MGL_VJ2.MGL_STIT_LINE";
                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_PLANT";
                MyOraDB.Parameter_Name[2] = "ARG_LINE";
                MyOraDB.Parameter_Name[3] = "ARG_DIV";
                MyOraDB.Parameter_Name[4] = "CV_1";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_TYPE;
                MyOraDB.Parameter_Values[1] = ARG_PLANT;
                MyOraDB.Parameter_Values[2] = ARG_LINE;
                MyOraDB.Parameter_Values[3] = ARG_DIV;
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

        public DataSet SELECT_STITCHING(string ARG_DATE, string ARG_PLANT, string ARG_LINE, string ARG_OP_CD, string ARG_DATE_YN)
        {
            System.Data.DataSet retDS;
            COM.OraDB MyOraDB = new COM.OraDB();
            MyOraDB.ReDim_Parameter(5);
            MyOraDB.Process_Name = "MES.PKG_MGL_VJ2.MGL_STITCHING_SET";

            MyOraDB.Parameter_Name[0] = "ARG_DATE";
            MyOraDB.Parameter_Name[1] = "ARG_PLANT";
            MyOraDB.Parameter_Name[2] = "ARG_LINE";
            MyOraDB.Parameter_Name[3] = "ARG_DATE_YN";
            MyOraDB.Parameter_Name[4] = "CV_1";

            MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = ARG_DATE;
            MyOraDB.Parameter_Values[1] = ARG_PLANT;
            MyOraDB.Parameter_Values[2] = ARG_LINE;
            MyOraDB.Parameter_Values[3] = ARG_DATE_YN;
            MyOraDB.Parameter_Values[4] = "";

            MyOraDB.Add_Select_Parameter(true);

            retDS = MyOraDB.Exe_Select_Procedure();

            if (retDS == null) return null;
            return retDS;
        }

        public DataTable SELECT_STITCHING_DETAIL(string ARG_DATE, string ARG_PLANT, string ARG_UPC_MLINE, string ARG_UPS_MLINE,
                                                 string ARG_STYLE_CD, string ARG_CS_SIZE, string ARG_PRIO_INPUT, string ARG_OP_CD)
        {
            System.Data.DataSet retDS;
            COM.OraDB MyOraDB = new COM.OraDB();
            MyOraDB.ReDim_Parameter(8);
            MyOraDB.Process_Name = "MES.PKG_MGL_VJ2.SELECT_STITCHING_TAIL";

            MyOraDB.Parameter_Name[0] = "ARG_DATE";
            MyOraDB.Parameter_Name[1] = "ARG_PLANT";
            MyOraDB.Parameter_Name[2] = "ARG_FGA_MLINE";
            MyOraDB.Parameter_Name[3] = "ARG_UPS_MLINE";
            MyOraDB.Parameter_Name[4] = "ARG_STYLE_CD";
            MyOraDB.Parameter_Name[5] = "ARG_SIZE_CD";
            MyOraDB.Parameter_Name[6] = "ARG_HH";
            MyOraDB.Parameter_Name[7] = "CV_1";

            MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[5] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[6] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[7] = (char)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = ARG_DATE;
            MyOraDB.Parameter_Values[1] = ARG_PLANT;
            MyOraDB.Parameter_Values[2] = ARG_UPC_MLINE;
            MyOraDB.Parameter_Values[3] = ARG_UPS_MLINE;
            MyOraDB.Parameter_Values[4] = ARG_STYLE_CD;
            MyOraDB.Parameter_Values[5] = ARG_CS_SIZE;
            MyOraDB.Parameter_Values[6] = ARG_PRIO_INPUT;
            MyOraDB.Parameter_Values[7] = "";

            MyOraDB.Add_Select_Parameter(true);

            retDS = MyOraDB.Exe_Select_Procedure();

            if (retDS == null) return null;

            return retDS.Tables[MyOraDB.Process_Name];
        }

        public Boolean UPDATE_STITCHING(DataTable dt)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            int cnt = 11;
            MyOraDB.ReDim_Parameter(cnt);
            MyOraDB.Process_Name = "MES.PKG_MGL_VJ2.UPDATE_STITCHING";

            MyOraDB.Parameter_Name[0] = "ARG_TYPE";
            MyOraDB.Parameter_Name[1] = "ARG_DATE";
            MyOraDB.Parameter_Name[2] = "ARG_PLANT";
            MyOraDB.Parameter_Name[3] = "ARG_FGA_MLINE";
            MyOraDB.Parameter_Name[4] = "ARG_UPS_MLINE";
            MyOraDB.Parameter_Name[5] = "ARG_STYLE_CD";
            MyOraDB.Parameter_Name[6] = "ARG_SIZE_CD";
            MyOraDB.Parameter_Name[7] = "ARG_PCARD_NAME";
            MyOraDB.Parameter_Name[8] = "ARG_PCARD_QTY";
            MyOraDB.Parameter_Name[9] = "ARG_REASON_PAUSE";
            MyOraDB.Parameter_Name[10] = "ARG_USER";

            for (int i = 0; i < cnt; i++)
                MyOraDB.Parameter_Type[i] = (char)OracleType.VarChar;

            ArrayList vModifyList = new ArrayList();
            string ARS_USER = "E-SCAN";//Dns.GetHostAddresses(Environment.MachineName)[1].ToString() + "/" + Environment.MachineName;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                vModifyList.Add(dt.Rows[i]["ITPO_TYPE"]);
                vModifyList.Add(dt.Rows[i]["FA_DATE"]);
                vModifyList.Add(dt.Rows[i]["PLANT_CD"]);
                vModifyList.Add(dt.Rows[i]["FGA_MLINE"]);
                vModifyList.Add(dt.Rows[i]["UPS_MLINE"]);
                vModifyList.Add(dt.Rows[i]["STYLE_CD"]);
                vModifyList.Add(dt.Rows[i]["SIZE_CD"]);
                vModifyList.Add(dt.Rows[i]["PCARD_NAME"]);
                vModifyList.Add(dt.Rows[i]["PCARD_QTY"]);
                vModifyList.Add(dt.Rows[i]["REASON_PAUSE"]);
                vModifyList.Add(ARS_USER);
            }
            if (vModifyList.Count == 0) return false;
            MyOraDB.Parameter_Values = new string[vModifyList.Count];
            for (int j = 0; j < vModifyList.Count; j++)
            {
                MyOraDB.Parameter_Values[j] = vModifyList[j].ToString().Trim();
            }

            MyOraDB.Add_Modify_Parameter(true);

            if (MyOraDB.Exe_Modify_Procedure() == null)
                return false;
            else
                return true;
        }

        public Boolean UPDATE_STITCHING_LINE(DataTable dt)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            int cnt = 10;
            MyOraDB.ReDim_Parameter(cnt);
            MyOraDB.Process_Name = "MES.PKG_MGL_VJ2.UPDATE_STITCHING_LINE";

            MyOraDB.Parameter_Name[0] = "ARG_TYPE";
            MyOraDB.Parameter_Name[1] = "ARG_DATE";
            MyOraDB.Parameter_Name[2] = "ARG_PLANT";
            MyOraDB.Parameter_Name[3] = "ARG_FGA_MLINE";
            MyOraDB.Parameter_Name[4] = "ARG_UPS_MLINE";
            MyOraDB.Parameter_Name[5] = "ARG_STYLE_CD";
            MyOraDB.Parameter_Name[6] = "ARG_SIZE_CD";
            MyOraDB.Parameter_Name[7] = "ARG_PCARD_NAME";
            MyOraDB.Parameter_Name[8] = "ARG_LINE_CHANGE";
            MyOraDB.Parameter_Name[9] = "ARG_USER";

            for (int i = 0; i < cnt; i++)
                MyOraDB.Parameter_Type[i] = (char)OracleType.VarChar;

            ArrayList vModifyList = new ArrayList();
            string ARS_USER = "E-SCAN";//Dns.GetHostAddresses(Environment.MachineName)[1].ToString();// +"/" + Environment.MachineName;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                vModifyList.Add(dt.Rows[i]["ITPO_TYPE"]);
                vModifyList.Add(dt.Rows[i]["FA_DATE"]);
                vModifyList.Add(dt.Rows[i]["PLANT_CD"]);
                vModifyList.Add(dt.Rows[i]["FGA_MLINE"]);
                vModifyList.Add(dt.Rows[i]["UPS_MLINE"]);
                vModifyList.Add(dt.Rows[i]["STYLE_CD"]);
                vModifyList.Add(dt.Rows[i]["SIZE_CD"]);
                vModifyList.Add(dt.Rows[i]["PCARD_NAME"]);
                vModifyList.Add(dt.Rows[i]["LINE_CHANGE"]);
                vModifyList.Add(ARS_USER);
            }
            if (vModifyList.Count == 0) return false;
            MyOraDB.Parameter_Values = new string[vModifyList.Count];
            for (int j = 0; j < vModifyList.Count; j++)
            {
                MyOraDB.Parameter_Values[j] = vModifyList[j].ToString().Trim();
            }

            MyOraDB.Add_Modify_Parameter(true);

            if (MyOraDB.Exe_Modify_Procedure() == null)
                return false;
            else
                return true;
        }

        public Boolean UPDATE_STITCHING_REASON(DataTable dt)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            int cnt = 10;
            MyOraDB.ReDim_Parameter(cnt);
            MyOraDB.Process_Name = "MES.PKG_MGL_VJ2.UPDATE_STITCHING_REASON";

            MyOraDB.Parameter_Name[0] = "ARG_TYPE";
            MyOraDB.Parameter_Name[1] = "ARG_DATE";
            MyOraDB.Parameter_Name[2] = "ARG_PLANT";
            MyOraDB.Parameter_Name[3] = "ARG_FGA_MLINE";
            MyOraDB.Parameter_Name[4] = "ARG_UPS_MLINE";
            MyOraDB.Parameter_Name[5] = "ARG_STYLE_CD";
            MyOraDB.Parameter_Name[6] = "ARG_SIZE_CD";
            MyOraDB.Parameter_Name[7] = "ARG_PCARD_NAME";
            MyOraDB.Parameter_Name[8] = "ARG_REASON";
            MyOraDB.Parameter_Name[9] = "ARG_USER";

            for (int i = 0; i < cnt; i++)
                MyOraDB.Parameter_Type[i] = (char)OracleType.VarChar;

            ArrayList vModifyList = new ArrayList();
            string ARS_USER = "E-SCAN";//Dns.GetHostAddresses(Environment.MachineName)[1].ToString() + "/" + Environment.MachineName;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                vModifyList.Add(dt.Rows[i]["ITPO_TYPE"]);
                vModifyList.Add(dt.Rows[i]["FA_DATE"]);
                vModifyList.Add(dt.Rows[i]["PLANT_CD"]);
                vModifyList.Add(dt.Rows[i]["FGA_MLINE"]);
                vModifyList.Add(dt.Rows[i]["UPS_MLINE"]);
                vModifyList.Add(dt.Rows[i]["STYLE_CD"]);
                vModifyList.Add(dt.Rows[i]["SIZE_CD"]);
                vModifyList.Add(dt.Rows[i]["PCARD_NAME"]);
                vModifyList.Add(dt.Rows[i]["REASON_CD"]);
                vModifyList.Add(ARS_USER);
            }
            if (vModifyList.Count == 0) return false;
            MyOraDB.Parameter_Values = new string[vModifyList.Count];
            for (int j = 0; j < vModifyList.Count; j++)
            {
                MyOraDB.Parameter_Values[j] = vModifyList[j].ToString().Trim();
            }

            MyOraDB.Add_Modify_Parameter(true);

            if (MyOraDB.Exe_Modify_Procedure() == null)
                return false;
            else
                return true;
        }

        public DataTable SELECT_COMP_DETAIL(string ARG_DATE, string ARG_PLANT, string ARG_UPC_MLINE, string ARG_UPS_MLINE,
                                                 string ARG_STYLE_CD, string ARG_CS_SIZE, string ARG_PRIO_INPUT, string ARG_COMP)
        {
            System.Data.DataSet retDS;
            COM.OraDB MyOraDB = new COM.OraDB();
            MyOraDB.ReDim_Parameter(9);
            MyOraDB.Process_Name = "MES.PKG_MGL_VJ2.MGL_SET_BALANCE_TAIL";

            MyOraDB.Parameter_Name[0] = "ARG_DATE";
            MyOraDB.Parameter_Name[1] = "ARG_PLANT";
            MyOraDB.Parameter_Name[2] = "ARG_FGA_MLINE";
            MyOraDB.Parameter_Name[3] = "ARG_UPS_MLINE";
            MyOraDB.Parameter_Name[4] = "ARG_STYLE_CD";
            MyOraDB.Parameter_Name[5] = "ARG_SIZE_CD";
            MyOraDB.Parameter_Name[6] = "ARG_HH";
            MyOraDB.Parameter_Name[7] = "ARG_COMP";
            MyOraDB.Parameter_Name[8] = "CV_1";

            MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[5] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[6] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[7] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[8] = (char)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = ARG_DATE;
            MyOraDB.Parameter_Values[1] = ARG_PLANT;
            MyOraDB.Parameter_Values[2] = ARG_UPC_MLINE;
            MyOraDB.Parameter_Values[3] = ARG_UPS_MLINE;
            MyOraDB.Parameter_Values[4] = ARG_STYLE_CD;
            MyOraDB.Parameter_Values[5] = ARG_CS_SIZE;
            MyOraDB.Parameter_Values[6] = ARG_PRIO_INPUT;
            MyOraDB.Parameter_Values[7] = ARG_COMP;
            MyOraDB.Parameter_Values[8] = "";

            MyOraDB.Add_Select_Parameter(true);

            retDS = MyOraDB.Exe_Select_Procedure();

            if (retDS == null) return null;

            return retDS.Tables[MyOraDB.Process_Name];
        }

        #endregion

        #region delegate   
        void mgs_OnConfirm(DataTable dt)
        {
            //bool rtn = false;
            //rtn = UPDATE_STITCHING(dt);
            //if (rtn)
            //{
            //}
            //else
            //{
            //    MessageBox.Show(" Có lỗi trong lúc ghi dữ liệu", " Thông báo", MessageBoxButtons.OK);
            //}
        }

        void mgs_OnConfirmTransfer(DataTable dt)
        {
            //bool rtn = false; ;
            //rtn = UPDATE_STITCHING_LINE(dt);
            //if (rtn)
            //{
            //}
            //else
            //{
            //    MessageBox.Show(" Có lỗi trong lúc ghi dữ liệu", " Thông báo", MessageBoxButtons.OK);
            //}
        }

        void mgs_OnConfirm_Reason(DataTable dt)
        {
            //bool rtn = false; ;
            //if (_OPCD.Equals("UPS"))
            //    rtn = UPDATE_STITCHING_REASON(dt);
            //if (rtn)
            //{
            //}
            //else
            //{
            //    MessageBox.Show(" Có lỗi trong lúc ghi dữ liệu", " Thông báo", MessageBoxButtons.OK);
            //}
        }

        void mgs_OnClosing(bool sSearchAgain)
        {
            if (sSearchAgain)
            {
                cCount = 0;
                _sSearchAgain = true;
                BindingData();
            }
            else
            {

            }

        }
        #endregion

        public void getConfigInfor()
        {
            try
            {
                _dtXML = ComVar.Func.ReadXML(Application.StartupPath + "\\Config.XML", "MAIN");

                string sFocus = "";
                _PLANT_CD = "2120"; //_dtXML.Rows[0]["PLANT"].ToString();
                _LINE = "ALL";// _dtXML.Rows[0]["LINECD"].ToString();
                _LINENAME = "ALL";// _dtXML.Rows[0]["LINENAME"].ToString();
                _MLINE = "ALL";//_dtXML.Rows[0]["MLINECD"].ToString();
                sFocus = "STIT"; // _dtXML.Rows[0]["FOCUS"].ToString();
                _DIV = "1";// _dtXML.Rows[0]["DIV"].ToString();
                _lang = "EN";
                _OPCD = "UPS";
            }
            catch
            {
            }
        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "minimized";
        }
        
        DataTable Pivot(DataTable dt, DataColumn pivotColumn, DataColumn pivotValue)
        {
            // find primary key columns 
            //(i.e. everything but pivot column and pivot value)
            DataTable temp = dt.Copy();
            temp.Columns.Remove(pivotColumn.ColumnName);
            temp.Columns.Remove(pivotValue.ColumnName);
            string[] pkColumnNames = temp.Columns.Cast<DataColumn>()
            .Select(c => c.ColumnName)
            .ToArray();

            // prep results table
            DataTable result = temp.DefaultView.ToTable(true, pkColumnNames).Copy();
            result.PrimaryKey = result.Columns.Cast<DataColumn>().ToArray();
            dt.AsEnumerable()
            .Select(r => r[pivotColumn.ColumnName].ToString())
            .Distinct().ToList()
            .ForEach(c => result.Columns.Add(c, pivotValue.DataType));
            //.ForEach(c => result.Columns.Add(c, pivotColumn.DataType));

            // load it
            foreach (DataRow row in dt.Rows)
            {
                // find row to update
                DataRow aggRow = result.Rows.Find(
                pkColumnNames
                .Select(c => row[c])
                .ToArray());
                // the aggregate used here is LATEST 
                // adjust the next line if you want (SUM, MAX, etc...)
                aggRow[row[pivotColumn.ColumnName].ToString()] = row[pivotValue.ColumnName];


            }

            return result;
        }

        private void load_combo(string ARG_TYPE)
        {
            try
            {
                DataTable dt = SELECT_CBO_LINE(ARG_TYPE, _LINE, _MLINE, _DIV);
                if (dt == null || dt.Rows.Count < 1) return;
                if (ARG_TYPE.Equals("Q1"))
                {                    
                    cboPlant.Properties.Columns.Clear();
                    cboPlant.Properties.DataSource = dt;
                    cboPlant.Properties.ValueMember = dt.Columns[0].ColumnName;
                    cboPlant.Properties.DisplayMember = dt.Columns[1].ColumnName;
                    cboPlant.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(dt.Columns[0].ColumnName));
                    cboPlant.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(dt.Columns[1].ColumnName));
                    cboPlant.Properties.Columns[dt.Columns[0].ColumnName].Visible = false;
                    cboPlant.Properties.Columns[dt.Columns[1].ColumnName].Caption = "Plant";
                    cboPlant.ItemIndex = 1;
                }
            }
            catch { }
        }

        private void BindingData()
        {
            try
            {
                tmr.Stop();
                _OPCD = ComVar.Var._strValue1;
                if (!_OPCD.Equals("UPS")) return;
                if (_MLINE == "") return;
                cCount = 0;
                splashScreenManager1.ShowWaitForm();
                DataSet ds = SELECT_STITCHING(dtpDate.DateTime.ToString("yyyyMMdd"), _PLANT_CD,  _LINE, _OPCD, chkDate.Checked ? "Y" : "N");
                DataTable dt1 = null;
                if (ds != null)
                {
                    dt1 = ds.Tables[0];
                    bingdinggrid(_lang, dt1);
                }
                else
                {
                    bingdinggrid(_lang, null);
                }
                //flag = true;
                tmr.Start();
                splashScreenManager1.CloseWaitForm();
            }
            catch (Exception ex)
            {
                splashScreenManager1.CloseWaitForm();
                cCount = 0;
                //flag = true;
                tmr.Start();
            }
        }

        public void langue_chang(string str_lang)
        {
            try
            {
                if (str_lang == "VN")
                {
                    lbl1.Text = "Đang sản xuất";
                    lbl3.Text = "Sản xuất hôm qua";
                    lbl4.Text = "Sản xuất hôm nay";
                    lbl5.Text = "Sản xuất trễ";
                }
                else
                {
                    lbl1.Text = "Working";
                    lbl3.Text = "Yesterday Production";
                    lbl4.Text = "Today Production";
                    lbl5.Text = "Late Production";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        DataTable GetDataTable(GridView view)
        {
            DataTable dt = new DataTable();
            foreach (GridColumn c in view.Columns)
                dt.Columns.Add(c.FieldName, c.ColumnType);
            for (int r = 0; r < view.RowCount; r++)
            {
                object[] rowValues = new object[dt.Columns.Count];
                for (int c = 0; c < dt.Columns.Count; c++)
                    rowValues[c] = view.GetRowCellValue(r, dt.Columns[c].ColumnName);
                dt.Rows.Add(rowValues);
            }
            return dt;
        }  

        private DataTable LINQResultToDataTable<T>(IEnumerable<T> Linqlist)
        {
            DataTable dt = new DataTable();


            PropertyInfo[] columns = null;

            if (Linqlist == null) return dt;

            foreach (T Record in Linqlist)
            {

                if (columns == null)
                {
                    columns = ((Type)Record.GetType()).GetProperties();
                    foreach (PropertyInfo GetProperty in columns)
                    {
                        Type colType = GetProperty.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
                    }
                }

                DataRow dr = dt.NewRow();

                foreach (PropertyInfo pinfo in columns)
                {
                    dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
                    (Record, null);
                }

                dt.Rows.Add(dr);
            }
            return dt;
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

        private bool createGrid(DataTable dt, GridControl gridControl, BandedGridView gridView)
        {
            try
            {
                gridControl.BeginUpdate();
                gridView.OptionsView.ShowGroupPanel = false;
                gridView.OptionsView.AllowCellMerge = true;
                gridView.BandPanelRowHeight = 35;
                gridView.Bands.Clear();
                gridView.Columns.Clear();
                gridControl.DataSource = null;
                gridView.OptionsView.ShowColumnHeaders = false;
                GridBand band = null;
                GridBand bandchlid1 = null;
                GridBand bandchlid2 = null;
                GridBand bandchlid3 = null;
                string distinct_row = "", sCol = "";


                var distinctValues = dt.AsEnumerable()
                                   .Select(row => new
                                   {
                                       FA_DATE = row.Field<string>("FA_DATE"),
                                       COL = row.Field<string>("COL"),
                                       DATE_CAPTION = row.Field<string>("DATE_CAPTION")
                                   })
                                   .Distinct().OrderBy(r => r.FA_DATE + r.COL);
                DataTable dttmp = LINQResultToDataTable(distinctValues);

                //band = new GridBand() { Caption = "" };
                //gridView.Bands.Add(band);
                //band.Name = "bandTitle1";
                //band.AppearanceHeader.BackColor = Color.Blue;
                //band.AppearanceHeader.ForeColor = Color.White;
                //band.AppearanceHeader.Font = new Font("Calibri", 16f , FontStyle.Bold);
                

                for (int i = 0; i < 3; i++)
                {
                    bandchlid1 = new GridBand() { Caption = "" };
                    gridView.Bands.Add(bandchlid1);
                    bandchlid1.Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName, Visible = true, Caption = "" });
                    bandchlid1.AppearanceHeader.BackColor = Color.Gray;
                    bandchlid1.AppearanceHeader.ForeColor = Color.Black;
                    bandchlid1.Width = 65;
                    bandchlid1.Fixed = FixedStyle.Left;
                    if (i < 2)
                        bandchlid1.Visible = false;
                    //dtSource.Columns.Add(dt.Columns[i].ColumnName);
                }
                int cnt = -1;
                for (int i = 0; i < dttmp.Rows.Count; i++)
                {
                    if (!distinct_row.Equals(dttmp.Rows[i]["FA_DATE"].ToString()))
                    {
                        cnt++;
                        distinct_row = dttmp.Rows[i]["FA_DATE"].ToString();
                        bandchlid1 = new GridBand() { Caption = dttmp.Rows[i]["DATE_CAPTION"].ToString() };
                        gridView.Bands.Add(bandchlid1);

                        if (cnt % 2 == 0)
                        {
                            bandchlid1.AppearanceHeader.BackColor = Color.DodgerBlue;
                            bandchlid1.AppearanceHeader.ForeColor = Color.White;
                        }
                        else
                        {
                            bandchlid1.AppearanceHeader.BackColor = Color.FromArgb(0, 192, 192);
                            bandchlid1.AppearanceHeader.ForeColor = Color.White;
                        }

                        bandchlid2 = new GridBand() { Caption = "Style" };
                        bandchlid1.Children.Add(bandchlid2);

                        if (cnt % 2 == 0)
                        {
                            bandchlid2.AppearanceHeader.BackColor = Color.DodgerBlue;
                            bandchlid2.AppearanceHeader.ForeColor = Color.White;
                        }
                        else
                        {
                            bandchlid2.AppearanceHeader.BackColor = Color.FromArgb(0, 192, 192);
                            bandchlid2.AppearanceHeader.ForeColor = Color.White;
                        }

                        bandchlid3 = new GridBand() { Caption = "" };
                        bandchlid2.Children.Add(bandchlid3);
                        bandchlid3.Columns.Add(new BandedGridColumn() { FieldName = string.Concat(dttmp.Rows[i]["COL"].ToString().Split('_')[0], "STYLE_CD"), Visible = true, Caption = "Style" });
                        bandchlid3.AppearanceHeader.BackColor = Color.FromArgb(255, 224, 192);
                        bandchlid3.AppearanceHeader.ForeColor = Color.Blue;
                        bandchlid3.Width = 119;
                        bandchlid3.AppearanceHeader.Font = new Font("Calibri", 10F, FontStyle.Bold);
                        
                        bandchlid2 = new GridBand() { Caption = "Size" };
                        bandchlid1.Children.Add(bandchlid2);

                        if (cnt % 2 == 0)
                        {
                            bandchlid2.AppearanceHeader.BackColor = Color.DodgerBlue;
                            bandchlid2.AppearanceHeader.ForeColor = Color.White;
                        }
                        else
                        {
                            bandchlid2.AppearanceHeader.BackColor = Color.FromArgb(0, 192, 192);
                            bandchlid2.AppearanceHeader.ForeColor = Color.White;
                        }

                        bandchlid3 = new GridBand() { Caption = "" };
                        bandchlid2.Children.Add(bandchlid3);
                        bandchlid3.Columns.Add(new BandedGridColumn() { FieldName = string.Concat(dttmp.Rows[i]["COL"].ToString().Split('_')[0], "SIZE_CD"), Visible = true, Caption = "Size" });
                        bandchlid3.AppearanceHeader.BackColor = Color.FromArgb(255, 224, 192);
                        bandchlid3.AppearanceHeader.ForeColor = Color.Blue;
                        bandchlid3.Width = 92;
                        bandchlid3.AppearanceHeader.Font = new Font("Calibri", 10F, FontStyle.Bold);
                    }
                    if (!sCol.Equals(dttmp.Rows[i]["COL"].ToString()))
                    {
                        sCol = dttmp.Rows[i]["COL"].ToString();
                        bandchlid2 = new GridBand() { Caption = string.Concat(dttmp.Rows[i]["COL"].ToString().Split('_')[1], "H") };
                        bandchlid1.Children.Add(bandchlid2);

                        if (cnt % 2 == 0)
                        {
                            bandchlid2.AppearanceHeader.BackColor = Color.DodgerBlue;
                            bandchlid2.AppearanceHeader.ForeColor = Color.White;
                        }
                        else
                        {
                            bandchlid2.AppearanceHeader.BackColor = Color.FromArgb(0, 192, 192);
                            bandchlid2.AppearanceHeader.ForeColor = Color.White;
                        }

                        bandchlid3 = new GridBand() { Caption = "" };
                        bandchlid2.Children.Add(bandchlid3);
                        bandchlid3.Columns.Add(new BandedGridColumn() { FieldName = dttmp.Rows[i]["COL"].ToString(), Visible = true, Caption = string.Concat(dttmp.Rows[i]["COL"].ToString().Split('_')[1], "H") });
                        bandchlid3.AppearanceHeader.BackColor = Color.FromArgb(255, 224, 192);
                        bandchlid3.AppearanceHeader.ForeColor = Color.Blue;
                        bandchlid3.Width = 86;
                        bandchlid3.AppearanceHeader.Font = new Font("Calibri", 10F, FontStyle.Bold);
                    }                    
                }

                foreach (GridBand gb in gridView.Bands)
                {
                    FormatBand(gb);
                }
                gridControl.EndUpdate();                
                return true;
            }
            catch (Exception EX) { return false; }
        }

        private bool bindingDataSource_detail(DataTable dtSource, DataTable dt)
        {
            int cnt = 0;
            try
            {
                int[] rowtotal = new int[dtSource.Columns.Count];
                string distinct_row = "";                
                int temp1, temp2;

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (!distinct_row.Equals(dt.Rows[i]["STT"].ToString()))
                    {
                        dtSource.Rows.Add();
                    }
                    distinct_row = dt.Rows[i]["STT"].ToString();

                    dtSource.Rows[dtSource.Rows.Count - 1]["STT"] = dt.Rows[i]["STT"].ToString();
                    dtSource.Rows[dtSource.Rows.Count - 1]["UPS_LINE"] = dt.Rows[i]["UPS_LINE"].ToString();
                    dtSource.Rows[dtSource.Rows.Count - 1]["DIV"] = dt.Rows[i]["DIV"].ToString();

                    dtSource.Rows[dtSource.Rows.Count - 1][string.Concat(dt.Rows[i]["COL"].ToString().Split('_')[0], "STYLE_CD")] = dt.Rows[i]["STYLE_CD"].ToString();
                    dtSource.Rows[dtSource.Rows.Count - 1][string.Concat(dt.Rows[i]["COL"].ToString().Split('_')[0], "SIZE_CD")] = dt.Rows[i]["SIZE_CD"].ToString();

                    dtSource.Rows[dtSource.Rows.Count - 1][dt.Rows[i]["COL"].ToString()] = dt.Rows[i]["QTY"].ToString();



                    //for (int j = 0; j < _start_column - 1; j++)
                    //{
                    //    dtSource.Rows[dtSource.Rows.Count - 1][j] = dtTemp.Rows[i][j];
                    //}

                    //int.TryParse(dtTemp.Rows[i]["QTY"].ToString(), out temp1);
                    //int.TryParse(dtSource.Rows[dtSource.Rows.Count - 1][dtTemp.Rows[i]["CS_SIZE"].ToString()].ToString(), out temp2);
                    //dtSource.Rows[dtSource.Rows.Count - 1][dtTemp.Rows[i]["CS_SIZE"].ToString()] = Convert.ToDecimal(temp1 + temp2);
                    //int.TryParse(dtSource.Rows[dtSource.Rows.Count - 1][_start_column - 1].ToString(), out temp2);
                    //dtSource.Rows[dtSource.Rows.Count - 1][_start_column - 1] = (temp1 + temp2).ToString();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool createGrid2(DataTable dt, GridControl gridControl, BandedGridView gridView)
        {
            try
            {
                gridControl.BeginUpdate();
                gridView.OptionsView.ShowGroupPanel = false;
                gridView.OptionsView.AllowCellMerge = true;
                gridView.BandPanelRowHeight = 35;
                gridView.Bands.Clear();
                gridView.Columns.Clear();
                gridControl.DataSource = null;
                gridView.OptionsView.ShowColumnHeaders = false;
                GridBand band = null;
                GridBand bandchlid1 = null;
                string distinct_row = "", sCol = "";

                var distinctValues = dt.AsEnumerable()
                                   .Select(row => new
                                   {
                                       FA_DATE = row.Field<string>("FA_DATE"),
                                       COL = row.Field<string>("COL"),
                                       DATE_CAPTION = row.Field<string>("DATE_CAPTION")
                                   })
                                   .Distinct().OrderBy(r => r.FA_DATE + r.COL);
                DataTable dttmp = LINQResultToDataTable(distinctValues);

                for (int i = 0; i < 8; i++)
                {                    
                    
                    if (i == 4)
                    {
                        band = new GridBand() { Caption = "Line" };
                        gridView.Bands.Add(band);
                        band.Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName, Visible = true, Caption = "" });
                    }
                    else if (i == 5)
                    {
                        band = new GridBand() { Caption = "Style" };
                        gridView.Bands.Add(band);
                        band.Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName, Visible = true, Caption = "Style" });
                    }
                    else if (i == 6)
                    {
                        band = new GridBand() { Caption = "Division" };
                        gridView.Bands.Add(band);
                        band.Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName, Visible = true, Caption = "Division" });
                    }
                    else if (i == 7)
                    {
                        band = new GridBand() { Caption = "Component" };
                        gridView.Bands.Add(band);
                        band.Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName, Visible = true, Caption = "Component" });
                    }
                    else
                    {
                        band = new GridBand() { Caption = "" };
                        gridView.Bands.Add(band);
                        band.Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName, Visible = true, Caption = "" });
                    }
                    band.AppearanceHeader.BackColor = Color.Gray;
                    band.AppearanceHeader.ForeColor = Color.Black;
                    band.Fixed = FixedStyle.Left;
                    band.AppearanceHeader.Font = new Font("Calibri", 16f, FontStyle.Bold);
                    if (i < 4)
                        band.Visible = false;
                }
                int cnt = -1;
                for (int i = 0; i < dttmp.Rows.Count; i++)
                {
                    if (!distinct_row.Equals(dttmp.Rows[i]["FA_DATE"].ToString()))
                    {
                        cnt++;
                        distinct_row = dttmp.Rows[i]["FA_DATE"].ToString();
                        band = new GridBand() { Caption = dttmp.Rows[i]["DATE_CAPTION"].ToString() };
                        gridView.Bands.Add(band);
                        if (cnt % 2 == 0)
                        {
                            band.AppearanceHeader.BackColor = Color.DodgerBlue;
                            band.AppearanceHeader.ForeColor = Color.White;
                        }
                        else
                        {
                            band.AppearanceHeader.BackColor = Color.FromArgb(0, 192, 192);
                            band.AppearanceHeader.ForeColor = Color.White;
                        }                        
                    }
                    if (!sCol.Equals(dttmp.Rows[i]["COL"].ToString()))
                    {
                        sCol = dttmp.Rows[i]["COL"].ToString();
                        if (dttmp.Rows[i]["COL"].ToString().Split('_')[1].Equals("0"))
                        {
                            bandchlid1 = new GridBand() { Caption = "Total" };
                            band.Children.Add(bandchlid1);
                            bandchlid1.Columns.Add(new BandedGridColumn() { FieldName = dttmp.Rows[i]["COL"].ToString(), Visible = true, Caption = string.Concat(dttmp.Rows[i]["COL"].ToString().Split('_')[1], "H") });
                            bandchlid1.AppearanceHeader.BackColor = Color.LightYellow;
                            bandchlid1.AppearanceHeader.ForeColor = Color.Black;
                        }
                        else
                        {
                            bandchlid1 = new GridBand() { Caption = string.Concat(dttmp.Rows[i]["COL"].ToString().Split('_')[1], "H") };
                            band.Children.Add(bandchlid1);
                            bandchlid1.Columns.Add(new BandedGridColumn() { FieldName = dttmp.Rows[i]["COL"].ToString(), Visible = true, Caption = string.Concat(dttmp.Rows[i]["COL"].ToString().Split('_')[1], "H") });
                            if (cnt % 2 == 0)
                            {
                                bandchlid1.AppearanceHeader.BackColor = Color.DodgerBlue;
                                bandchlid1.AppearanceHeader.ForeColor = Color.White;
                            }
                            else
                            {
                                bandchlid1.AppearanceHeader.BackColor = Color.FromArgb(0, 192, 192);
                                bandchlid1.AppearanceHeader.ForeColor = Color.White;
                            }
                        }
                        bandchlid1.AppearanceHeader.Font = new Font("Calibri", 16, FontStyle.Bold);
                    }
                }

                foreach (GridBand gb in gridView.Bands)
                {
                    FormatBand(gb);
                }
                gridControl.EndUpdate();
                return true;
            }
            catch (Exception EX) { return false; }
        }

        private bool bindingDataSource_detail2(DataTable dtSource, DataTable dt)
        {
            int cnt = 0;
            try
            {
                int[] rowtotal = new int[dtSource.Columns.Count];
                string distinct_row = "";
                int temp1, temp2;

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (!distinct_row.Equals(string.Concat(dt.Rows[i]["FGA_LINE"].ToString(), dt.Rows[i]["UPS_LINE"].ToString(), dt.Rows[i]["COMP_CD"].ToString(), dt.Rows[i]["STYLE_CD"].ToString())))
                    {
                        dtSource.Rows.Add();
                    }
                    distinct_row = string.Concat(dt.Rows[i]["FGA_LINE"].ToString(), dt.Rows[i]["UPS_LINE"].ToString(), dt.Rows[i]["COMP_CD"].ToString(), dt.Rows[i]["STYLE_CD"].ToString());
                    for (int col = 0; col < 8; col++)
                    {
                        dtSource.Rows[dtSource.Rows.Count - 1][dt.Columns[col].ColumnName] = dt.Rows[i][dt.Columns[col].ColumnName].ToString();
                    } 
                    dtSource.Rows[dtSource.Rows.Count - 1][dt.Rows[i]["COL"].ToString()] = dt.Rows[i]["QTY"].ToString();
                    dtSource.Rows[dtSource.Rows.Count - 1]["CUR_COL"] = dt.Rows[i]["CUR_COL"].ToString();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void bingdinggrid(string str_lang, DataTable dt1)
        {
            try
            {
                DataTable dt_tmp = null; 
                DataTable dtSource = new DataTable();                
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    _CUR_COL2 = dt1.Rows[0]["CUR_COL"].ToString();                    
                    if (createGrid2(dt1, grdBase, gvwBase))
                    {
                        vScrollBar2.Value = 0;
                        hScrollBar2.Value = hScrollBar2.Maximum;
                        gvwBase.LeftCoord = 0;
                        dtSource = GetDataTable(gvwBase);
                        dtSource.Columns.Add("CUR_COL");

                        if (bindingDataSource_detail2(dtSource, dt1))
                        {
                            if (dtSource.Select("STT > '0'", "FGA_LINE, UPS_LINE, STYLE_CD, STT").Count() > 0)
                            {
                                grdBase.DataSource = dtSource.Select("STT > '0'", "FGA_LINE, UPS_LINE, STYLE_CD, STT").CopyToDataTable();
                            }
                            else grdBase.DataSource = dtSource;
                            for (int i_col = 0; i_col < gvwBase.Columns.Count; i_col++)
                            {
                                gvwBase.Columns[i_col].AppearanceCell.Font = new System.Drawing.Font("Calibri", 12, FontStyle.Regular);
                                gvwBase.Columns[i_col].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                                gvwBase.Columns[i_col].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                                if (i_col == 4)
                                {
                                    gvwBase.Columns[i_col].OwnerBand.Width = 91;
                                }
                                else if (i_col == 5)
                                {
                                    gvwBase.Columns[i_col].OwnerBand.Width = 120;
                                }
                                else if (i_col == 6)
                                {
                                    gvwBase.Columns[i_col].OwnerBand.Width = 95;
                                }
                                else if (i_col == 7)
                                {
                                    gvwBase.Columns[i_col].OwnerBand.Width = 120;
                                }
                                else if (i_col > 7)
                                {
                                    if (gvwBase.Columns[i_col].FieldName.Contains("_0"))
                                    {
                                        gvwBase.Columns[i_col].OwnerBand.Width = 95;
                                    }
                                    else
                                    {
                                        gvwBase.Columns[i_col].OwnerBand.Width = 78;
                                    }
                                }
                                gvwBase.Columns[i_col].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                                //if (i_col < 7)
                                //    gvwBase.Columns[i_col].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                                //else
                                //    gvwBase.Columns[i_col].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                            }
                            gvwBase.FocusedColumn = gvwBase.Columns[gvwBase.Columns.Count - 10];
                        }
                    }  
                }
                else
                {
                }

            }
            catch { }
        }

        private void FRM_STITCHING_Load(object sender, EventArgs e)
        {
            try
            {
                dtpDate.EditValue = DateTime.Now;
                getConfigInfor();
                flag = false;
                _lang = ComVar.Var._Area;
                load_combo("Q1");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            try
            {
                cCount++;
                if (cCount >= TimeRefresh)
                {
                    cCount = 0;
                    //BindingData();
                }
            }
            catch
            {
                cCount = 0;
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void FRM_STITCHING_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                _OPCD = ComVar.Var._strValue1;
                _lang = ComVar.Var._Area;
                if (flag)
                {
                    cCount = TimeRefresh - 2;
                }
                else
                {
                    cCount = 0;
                    flag = true;
                }
                tmr.Start();
            }
            else
                tmr.Stop();
        }

        private void cboPlant_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                cCount = 0;
                if (cboPlant.EditValue != null)
                    _LINE = cboPlant.EditValue.ToString();
                BindingData();
            }
            catch { }
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (gvwBase.DataRowCount > 0)
            {
                gvwBase.TopRowIndex = (int)(
                          (gvwBase.RowCount)
                          *
                          (1 + (1.0 * vScrollBar2.LargeChange / vScrollBar2.Maximum)) * vScrollBar2.Value / vScrollBar2.Maximum
                         );
            }
        }

        private void gvwBase_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.CellValue == null) return;
            if (e.Column.FieldName.Contains("D") || e.Column.FieldName.Contains("D"))
            {

                if (e.CellValue.ToString().Contains("GR"))
                {
                    e.Appearance.BackColor = Color.Gray;
                    e.Appearance.ForeColor = Color.Black;
                } 
                else if (e.CellValue.ToString().Contains("R"))
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (e.CellValue.ToString().Contains("O"))
                {
                    e.Appearance.BackColor = Color.Orange;
                    e.Appearance.ForeColor = Color.Black;
                }
                else if (e.CellValue.ToString().Contains("G"))
                {
                    e.Appearance.BackColor = Color.LimeGreen;
                    e.Appearance.ForeColor = Color.Black;
                }
                else if (e.CellValue.ToString().Contains("W"))
                {
                    e.Appearance.BackColor = Color.White;
                    e.Appearance.ForeColor = Color.Black;
                }
                if (e.Column.FieldName.Contains("_0"))
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 255, 192);
                    e.Appearance.ForeColor = Color.Black;
                }
            }
            if (e.Column.ColumnHandle > 5)
            {
                if (gvwBase.GetRowCellValue (e.RowHandle, "COMP_CD").ToString() == "SET")
                {
                    e.Appearance.BackColor = Color.FromArgb(254, 255, 230);
                    e.Appearance.ForeColor = Color.Brown;
                }
                if (gvwBase.GetRowCellValue(e.RowHandle, "COMP_CD").ToString() == "INPUT")
                {
                    e.Appearance.BackColor = Color.LightCyan;
                    e.Appearance.ForeColor = Color.Black;
                }
                if (gvwBase.GetRowCellValue(e.RowHandle, "COMP_CD").ToString() == "INVSET")
                {
                    e.Appearance.BackColor = Color.FromArgb(254, 255, 230);// Color.LightPink; ;
                    e.Appearance.ForeColor = Color.Brown;
                }
                if (gvwBase.GetRowCellValue(e.RowHandle, "COMP_CD").ToString() == "PROD")
                {
                    e.Appearance.BackColor = Color.FromArgb(254, 255, 230);// Color.LightPink; ;
                    e.Appearance.ForeColor = Color.Brown;
                }
                if (gvwBase.GetRowCellValue(e.RowHandle, "COMP_CD").ToString() == "OUT")
                {
                    e.Appearance.BackColor = Color.LightCyan;
                    e.Appearance.ForeColor = Color.Black;
                }


                if (gvwBase.GetRowCellValue(e.RowHandle, "GRP").ToString() == "Balance" && gvwBase.GetRowCellValue(e.RowHandle, "COMP_CD").ToString() != "BALANCE")
                {
                    if (!e.Column.FieldName.Contains("TOT") && e.Column.ColumnHandle > 6)
                    {
                        if (gvwBase.GetRowCellValue(e.RowHandle, e.Column.FieldName).ToString().IndexOf('/') < 1 && !gvwBase.GetRowCellValue(e.RowHandle, e.Column.FieldName).ToString().Contains("-"))
                        {

                            e.Appearance.BackColor = Color.FromArgb(168, 252, 151);
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }

                if (gvwBase.GetRowCellValue(e.RowHandle, "COMP_CD").ToString() == "BALANCE")
                {
                    if (gvwBase.GetRowCellValue(e.RowHandle, e.Column.FieldName).ToString().Equals("0") && !e.Column.FieldName.Contains("TOT"))
                    {
                        if (gvwBase.GetRowCellValue(e.RowHandle - 2, e.Column.FieldName).ToString().IndexOf('/') < 1 && !gvwBase.GetRowCellValue(e.RowHandle - 2, e.Column.FieldName).ToString().Contains("-"))
                        {

                            e.Appearance.BackColor = Color.FromArgb(168, 252, 151);
                            e.Appearance.ForeColor = Color.Black;
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.LightCyan;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.LightCyan;
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void gvwBase_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (!e.Column.FieldName.Substring(0, 1).Equals("D")) return;
                if ((e.Column.FieldName.Contains("D") && !e.Column.FieldName.Contains("_0")) && e.CellValue.ToString() != "")
                {
                    if (e.CellValue.ToString() == "") return;
                    if (!gvwBase.GetRowCellValue(e.RowHandle, "GRP").ToString().Contains("Cutting") && !gvwBase.GetRowCellValue(e.RowHandle, "GRP").ToString().Contains("Upstream")) return;
                    if (e.Column.FieldName.Contains("TOT")) return;
                    //if (!dataGrid2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains("L") && !dataGrid2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains("E")) return;
                    string sCellValue, sStyleCD = "", sComp = "", sPrio_Input = "", sLineCD = "", sUPSMLineCD = "", sUPCMLineCD = "", sDate = "";
                    sLineCD = _LINE;
                    sUPCMLineCD = gvwBase.GetRowCellValue(e.RowHandle, "FGA_LINE").ToString();
                    sUPSMLineCD = gvwBase.GetRowCellValue(e.RowHandle, "UPS_LINE").ToString();
                    sDate = gvwBase.Columns[e.Column.ColumnHandle].OwnerBand.ParentBand.Caption.Replace("-", "");
                    sPrio_Input = gvwBase.Columns[e.Column.ColumnHandle].OwnerBand.Caption.Substring(0, 1);
                    sStyleCD = gvwBase.GetRowCellValue(e.RowHandle, "STYLE_CD").ToString();
                    sComp = gvwBase.GetRowCellValue(e.RowHandle, "COMP_CD").ToString();

                    cCount = 0;
                    splashScreenManager1.ShowWaitForm();
                    frm_msg_detail_set frm = new frm_msg_detail_set();
                    DataTable dt = null;
                    dt = SELECT_COMP_DETAIL(sDate, sLineCD, sUPCMLineCD, sUPSMLineCD, sStyleCD, sComp, sPrio_Input, sComp);                    
                    frm.BingDingData(dt);
                    splashScreenManager1.CloseWaitForm();
                    frm.ShowDialog();
                }
            }
            catch { splashScreenManager1.CloseWaitForm(); }
        }

        private void gvwBase_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gvwBase.GetRowCellValue(e.RowHandle,e.Column.FieldName).ToString() == "") return;

            Rectangle rect = e.Bounds;
            rect.Inflate(new Size(1, 1));

            Brush brush = new SolidBrush(e.Appearance.BackColor);
            e.Graphics.FillRectangle(brush, rect);
            Pen pen_horizental = new Pen(Color.Blue, 3F);
            Pen pen_vertical = new Pen(Color.Blue, 4F);
            Pen pen_horizental1 = new Pen(Color.Yellow, 3F);
            Pen pen_vertical1 = new Pen(Color.Yellow, 4F);

            if (gvwBase.GetRowCellValue(e.RowHandle, e.Column.FieldName).ToString().Contains("L") && e.Column.ColumnHandle > 6)
            {
                // draw right
                e.Graphics.DrawLine(pen_vertical1, rect.X + rect.Width - 1, rect.Y - 1, rect.X + rect.Width - 1, rect.Y + rect.Height);
                // draw left
                e.Graphics.DrawLine(pen_horizental1, rect.X + 1, rect.Y, rect.X + 1, rect.Y + rect.Height);
                //draw top
                e.Graphics.DrawLine(pen_horizental1, rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                //draw bottom
                e.Graphics.DrawLine(pen_horizental1, rect.X, rect.Y + rect.Height - 2, rect.X + rect.Width, rect.Y + rect.Height - 2);
                string[] ls = e.DisplayText.Split('\n');


                if (e.Appearance.BackColor == Color.Red || e.Appearance.BackColor == Color.Green)
                {
                    e.Graphics.DrawString(ls[0], new System.Drawing.Font("Calibri", 12, FontStyle.Regular), new SolidBrush(Color.White), rect, e.Appearance.GetStringFormat());
                }
                else if (e.Appearance.ForeColor == Color.LightGray)
                {
                    e.Graphics.DrawString(ls[0], new System.Drawing.Font("Calibri", 12, FontStyle.Regular), new SolidBrush(Color.LightGray), rect, e.Appearance.GetStringFormat());
                }
                else
                {
                    e.Graphics.DrawString(ls[0], new System.Drawing.Font("Calibri", 12, FontStyle.Regular), new SolidBrush(Color.Black), rect, e.Appearance.GetStringFormat());
                }
                e.Handled = true;
            }

            if (gvwBase.GetRowCellValue(e.RowHandle, e.Column.FieldName).ToString().Contains("E") && e.Column.ColumnHandle > 6)
            {
                // draw right
                e.Graphics.DrawLine(pen_vertical1, rect.X + rect.Width - 1, rect.Y - 1, rect.X + rect.Width - 1, rect.Y + rect.Height);
                // draw left
                e.Graphics.DrawLine(pen_horizental1, rect.X + 1, rect.Y, rect.X + 1, rect.Y + rect.Height);
                //draw top
                e.Graphics.DrawLine(pen_horizental1, rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                //draw bottom
                e.Graphics.DrawLine(pen_horizental1, rect.X, rect.Y + rect.Height - 2, rect.X + rect.Width, rect.Y + rect.Height - 2);

                string[] ls = e.DisplayText.Split('\n');


                if (e.Appearance.BackColor == Color.Red || e.Appearance.BackColor == Color.Green)
                {
                    e.Graphics.DrawString(ls[0], new System.Drawing.Font("Calibri", 12, FontStyle.Regular), new SolidBrush(Color.White), rect, e.Appearance.GetStringFormat());
                }
                else if (e.Appearance.ForeColor == Color.LightGray)
                {
                    e.Graphics.DrawString(ls[0], new System.Drawing.Font("Calibri", 12, FontStyle.Regular), new SolidBrush(Color.LightGray), rect, e.Appearance.GetStringFormat());
                }
                else
                {
                    e.Graphics.DrawString(ls[0], new System.Drawing.Font("Calibri", 12, FontStyle.Regular), new SolidBrush(Color.Black), rect, e.Appearance.GetStringFormat());
                }
                e.Handled = true;
            }

            if (e.Column.FieldName == gvwBase.GetRowCellValue(e.RowHandle,"CUR_COL").ToString())
            {                
                if (e.RowHandle == 0)
                {
                    //draw top
                    e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                    if (!gvwBase.GetRowCellValue(e.RowHandle, "CUR_COL").ToString().Equals(gvwBase.GetRowCellValue(e.RowHandle + 1, "CUR_COL").ToString()))
                    {
                        //draw bottom
                        e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y + rect.Height - 2, rect.X + rect.Width, rect.Y + rect.Height - 2);
                    }
                }
                else if (e.RowHandle > 0 && e.RowHandle < gvwBase.RowCount - 1)
                {
                    if (!gvwBase.GetRowCellValue(e.RowHandle, "CUR_COL").ToString().Equals(gvwBase.GetRowCellValue(e.RowHandle - 1, "CUR_COL").ToString()))
                    {
                        //draw top 
                        e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                    }
                    if (!gvwBase.GetRowCellValue(e.RowHandle, "CUR_COL").ToString().Equals(gvwBase.GetRowCellValue(e.RowHandle + 1, "CUR_COL").ToString()))
                    {
                        //draw bottom 
                        e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y + rect.Height - 2, rect.X + rect.Width, rect.Y + rect.Height - 2);
                    }
                }
                // draw right
                e.Graphics.DrawLine(pen_vertical, rect.X + rect.Width - 1, rect.Y - 1, rect.X + rect.Width - 1, rect.Y + rect.Height);
                // draw left
                e.Graphics.DrawLine(pen_horizental, rect.X + 1, rect.Y, rect.X + 1, rect.Y + rect.Height);
                string[] ls = e.DisplayText.Split('\n');
                if (e.Appearance.BackColor == Color.Red || e.Appearance.BackColor == Color.Green)
                {
                    e.Graphics.DrawString(ls[0], new System.Drawing.Font("Calibri", 12, FontStyle.Regular), new SolidBrush(Color.White), rect, e.Appearance.GetStringFormat());
                }
                else if (e.Appearance.ForeColor == Color.LightGray)
                {
                    e.Graphics.DrawString(ls[0], new System.Drawing.Font("Calibri", 12, FontStyle.Regular), new SolidBrush(Color.LightGray), rect, e.Appearance.GetStringFormat());
                }
                else
                {
                    e.Graphics.DrawString(ls[0], new System.Drawing.Font("Calibri", 12, FontStyle.Regular), new SolidBrush(Color.Black), rect, e.Appearance.GetStringFormat());
                }
                e.Handled = true;
            }
        }

        private void dtpDate_EditValueChanged(object sender, EventArgs e)
        {
            BindingData();
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (gvwBase.Columns.Count  > 0)
            {
                gvwBase.LeftCoord = (int)(
                          (gvwBase.Columns.Count)
                          *
                          (70 + (1.0 * hScrollBar2.LargeChange / hScrollBar2.Maximum)) * hScrollBar2.Value / hScrollBar2.Maximum
                         );
            }
        }

        private void gvwBase_CellMerge(object sender, CellMergeEventArgs e)
        {
            try
            {
                if (e.RowHandle1 < 0 || gvwBase.RowCount == 0)
                    return;
                e.Merge = false;
                e.Handled = true;

                if (e.Column.FieldName == "LINE")
                {
                    string line1 = gvwBase.GetRowCellDisplayText(e.RowHandle1, "LINE").Trim();
                    string line2 = gvwBase.GetRowCellDisplayText(e.RowHandle2, "LINE").Trim();

                    if (line1 == line2)
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }

                if (e.Column.FieldName == "STYLE_CD")
                {
                    string line1 = gvwBase.GetRowCellDisplayText(e.RowHandle1, "LINE").Trim();
                    string line2 = gvwBase.GetRowCellDisplayText(e.RowHandle2, "LINE").Trim();

                    string style1 = gvwBase.GetRowCellDisplayText(e.RowHandle1, "STYLE_CD").Trim();
                    string style2 = gvwBase.GetRowCellDisplayText(e.RowHandle2, "STYLE_CD").Trim();

                    if (line1 == line2 && style1 == style2)
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }

                if (e.Column.FieldName == "GRP")
                {
                    string grp1 = gvwBase.GetRowCellDisplayText(e.RowHandle1, "GRP").Trim();
                    string grp2 = gvwBase.GetRowCellDisplayText(e.RowHandle2, "GRP").Trim();

                    string line1 = gvwBase.GetRowCellDisplayText(e.RowHandle1, "LINE").Trim();
                    string line2 = gvwBase.GetRowCellDisplayText(e.RowHandle2, "LINE").Trim();

                    string style1 = gvwBase.GetRowCellDisplayText(e.RowHandle1, "STYLE_CD").Trim();
                    string style2 = gvwBase.GetRowCellDisplayText(e.RowHandle2, "STYLE_CD").Trim();

                    if (grp1 == grp1 && line1 == line2 && style1 == style2)
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }

                if (e.Column.FieldName == "COMP_NM")
                {
                    string comp1 = gvwBase.GetRowCellDisplayText(e.RowHandle1, "COMP_NM").Trim();
                    string comp2 = gvwBase.GetRowCellDisplayText(e.RowHandle2, "COMP_NM").Trim();

                    string grp1 = gvwBase.GetRowCellDisplayText(e.RowHandle1, "GRP").Trim();
                    string grp2 = gvwBase.GetRowCellDisplayText(e.RowHandle2, "GRP").Trim();

                    string line1 = gvwBase.GetRowCellDisplayText(e.RowHandle1, "LINE").Trim();
                    string line2 = gvwBase.GetRowCellDisplayText(e.RowHandle2, "LINE").Trim();

                    string style1 = gvwBase.GetRowCellDisplayText(e.RowHandle1, "STYLE_CD").Trim();
                    string style2 = gvwBase.GetRowCellDisplayText(e.RowHandle2, "STYLE_CD").Trim();

                    if (comp1 == comp2 && grp1 == grp1 && line1 == line2 && style1 == style2)
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
