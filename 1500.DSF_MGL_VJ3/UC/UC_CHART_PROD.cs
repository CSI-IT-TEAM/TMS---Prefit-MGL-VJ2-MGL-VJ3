using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace FORM.UC
{
    public partial class UC_CHART_PROD : UserControl
    {
        public UC_CHART_PROD()
        {
            InitializeComponent();
        }
        string sFactory = null;
        private DataTable SP_MGL_HOME_CHART_DETAIL_SELECT(string V_P_TYPE, string V_P_FACTORY)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_MGL_VJ3.MGL_HOME_CHART_DETAIL_SELECT";
                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_FACTORY";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";
                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = V_P_TYPE;
                MyOraDB.Parameter_Values[1] = V_P_FACTORY;
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

        private DataTable SP_MGL_SET_TREELIST(string ARG_TYPE,string ARG_DATE, string ARG_PLANT)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_MGL_VJ3.SP_MGL_SET_TREELIST";
                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_DATE";
                MyOraDB.Parameter_Name[2] = "ARG_PLANT";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";
                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = ARG_TYPE;
                MyOraDB.Parameter_Values[1] = ARG_DATE;
                MyOraDB.Parameter_Values[2] = ARG_PLANT;
                MyOraDB.Parameter_Values[3] = "";
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
        private DataTable SP_MGL_TREELIST_CHART_DETAIL(string ARG_TYPE,string ARG_DATE, string ARG_PLANT)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_MGL_VJ3.SP_MGL_TREELIST_CHART_DETAIL";
                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_DATE";
                MyOraDB.Parameter_Name[2] = "ARG_PLANT";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";
                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = ARG_TYPE;
                MyOraDB.Parameter_Values[1] = ARG_DATE;
                MyOraDB.Parameter_Values[2] = ARG_PLANT;
                MyOraDB.Parameter_Values[3] = "";
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

        public void BindingData(DataTable dt)
        {
            chartControl1.DataSource = dt;
            chartControl1.Series[1].ArgumentDataMember = "LINE_CD";
            chartControl1.Series[1].ValueDataMembers.AddRange(new string[] { "PROD_QTY" });
            chartControl1.Series[0].ArgumentDataMember = "LINE_CD";
            chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "PLAN_QTY" });
            chartControl1.Series[2].ArgumentDataMember = "LINE_CD";
            chartControl1.Series[2].ValueDataMembers.AddRange(new string[] { "RATE" });

        }
        POPUP_PROD_BY_PLANT[] POPUP_TEMP = new POPUP_PROD_BY_PLANT[1];
        private void chartControl1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = SP_MGL_HOME_CHART_DETAIL_SELECT("Q", this.Tag.ToString());
                DataTable dtTree = SP_MGL_SET_TREELIST("Q",DateTime.Now.ToString("yyyyMMdd"), this.Tag.ToString());
                DataTable dtTreeDetailChart = SP_MGL_TREELIST_CHART_DETAIL("Q", DateTime.Now.ToString("yyyyMMdd"), this.Tag.ToString());
                POPUP_PROD_BY_PLANT POPUP = new POPUP_PROD_BY_PLANT(((DevExpress.XtraCharts.ChartControl)sender), dt, dtTreeDetailChart);
                POPUP_TEMP[0] = POPUP;
                POPUP.OnDateChange +=OnDateChanging;
                POPUP.BindingTreeView(dtTree);
                POPUP.BindingData();
                POPUP.ShowDialog();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
            }
        }
        void OnDateChanging(string date)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtTree = SP_MGL_SET_TREELIST("Q", date, this.Tag.ToString());
                DataTable dtTreeDetailChart = SP_MGL_TREELIST_CHART_DETAIL("Q", date, this.Tag.ToString());
                POPUP_TEMP[0].BindingTreeView(dtTree);
                POPUP_TEMP[0].BindingDataWhenDateChanged(dtTreeDetailChart);
                this.Cursor = Cursors.Default;
            }
            catch { this.Cursor = Cursors.Default; }
        }
    }
}
