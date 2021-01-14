using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Threading.Tasks;
using System.Threading;

namespace FORM
{
    public partial class FRM_TMS_HOME : Form
    {
        public FRM_TMS_HOME()
        {
            InitializeComponent();
        }
        #region Variable
        int counter = 0;
        int len = 0;
        string txt;
        Random r = new Random();
        UC.UC_TMS_CARD_V3[] UC = new UC.UC_TMS_CARD_V3[15];
        int iCount = 0;
        #endregion
        #region Ora
        private DataTable TMS_HOME_SELECT(string ARG_TYPE, string ARG_YMD)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_PREFIT.TMS_HOME_SELECT";
                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_YMD";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_TYPE;
                MyOraDB.Parameter_Values[1] = ARG_YMD;
                MyOraDB.Parameter_Values[2] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private DataSet TMS_HOME_RATIO_SELECT(string ARG_TYPE, string ARG_YMD, string ARG_PLANT)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_PREFIT.TMS_HOME_RATIO";
                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_YMD";
                MyOraDB.Parameter_Name[2] = "ARG_PLANT";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR1";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR2";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_TYPE;
                MyOraDB.Parameter_Values[1] = ARG_YMD;
                MyOraDB.Parameter_Values[2] = ARG_PLANT;
                MyOraDB.Parameter_Values[3] = "";
                MyOraDB.Parameter_Values[4] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        private void tblMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InitUC_Card(DataTable dt, DataTable dtRatioPlant, DataTable dtRatioAll)
        {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataTable dtVJ1 = dt.Select("FACTORY = '1'", "PROC_ID").CopyToDataTable(); //Layout VJ1
                    DataTable dtVJ2 = dt.Select("FACTORY = '2'", "PROC_ID").CopyToDataTable(); //Layout VJ2
                    DataTable dtVJ3 = dt.Select("FACTORY = '3'", "PROC_ID").CopyToDataTable(); //Layout VJ3
                    DataTable _dtRatioPlantVJ1 = null;// dtRatioPlant.Select("FACTORY = '1'", "FACTORY,PROC_ID").CopyToDataTable();
                    DataTable _dtRatioPlantVJ2 = null;// dtRatioPlant.Select("FACTORY = '2'", "FACTORY,PROC_ID").CopyToDataTable();
                    DataTable _dtRatioPlantVJ3 = null;// dtRatioPlant.Select("FACTORY = '3'", "FACTORY,PROC_ID").CopyToDataTable();
                    DataTable _dtRatioAllVJ1 = dtRatioAll.Select("FACTORY = '1'", "FACTORY,PROC_ID").CopyToDataTable();
                    DataTable _dtRatioAllVJ2 = dtRatioAll.Select("FACTORY = '2'", "FACTORY,PROC_ID").CopyToDataTable();
                    DataTable _dtRatioAllVJ3 = dtRatioAll.Select("FACTORY = '3'", "FACTORY,PROC_ID").CopyToDataTable();
                    int iDx = 0, RATIOPLANT = 0, RATIOALL = 0;
                    //Khởi tạo card VJ1
                    for (int i = 0; i < tblMainVJ1.ColumnCount; i++)
                    {
                        tmsHomeModel model = new tmsHomeModel();
                        UC.UC_TMS_CARD_V3 Card = new UC.UC_TMS_CARD_V3();
                        model.PROC_NAME_CARD = dtVJ1.Rows[i]["PROC_NAME"].ToString();
                        model.PROC_CODE_CARD = dtVJ1.Rows[i]["PROC_CODE"].ToString();
                        model.FACTORY = "1";
                        model.IS_BOTTOM = Convert.ToBoolean(dtVJ1.Rows[i]["REMARKS"].ToString().Equals("BOTTOM") ? 1 : 0);
                        model.USE_YN = dtVJ1.Rows[i]["USE_YN"].ToString();
                        model.PART_SHOW_YN = Convert.ToBoolean(dtVJ1.Rows[i]["PART_SHOW_YN"].ToString().Equals("Y") ? 1 : 0);
                        Card.BindingData(model);
                        //RATIOPLANT = Convert.ToInt32(_dtRatioPlantVJ1.Rows[i]["RATIO"]);
                        RATIOALL = Convert.ToInt32(_dtRatioAllVJ1.Rows[i]["RATIO"]);
                        //  Card.BindingArc(RATIOPLANT, 1);
                        Card.BindingArc(RATIOALL, 2);
                        tblMainVJ1.Controls.Add(Card, i, 0);
                        UC[iDx] = Card;
                        iDx++;
                    }
                    //Khởi tạo card VJ2
                    for (int i = 0; i < tblMainVJ2.ColumnCount; i++)
                    {
                        tmsHomeModel model = new tmsHomeModel();
                        UC.UC_TMS_CARD_V3 Card = new UC.UC_TMS_CARD_V3();
                        model.PROC_NAME_CARD = dtVJ2.Rows[i]["PROC_NAME"].ToString();
                        model.PROC_CODE_CARD = dtVJ2.Rows[i]["PROC_CODE"].ToString();
                        model.FACTORY = "2";
                        model.IS_BOTTOM = Convert.ToBoolean(dtVJ2.Rows[i]["REMARKS"].ToString().Equals("BOTTOM") ? 1 : 0);
                        model.USE_YN = dtVJ2.Rows[i]["USE_YN"].ToString();
                        model.PART_SHOW_YN = Convert.ToBoolean(dtVJ2.Rows[i]["PART_SHOW_YN"].ToString().Equals("Y") ? 1 : 0);
                        Card.BindingData(model);
                        // RATIOPLANT = Convert.ToInt32(_dtRatioPlantVJ2.Rows[i]["RATIO"]);
                        RATIOALL = Convert.ToInt32(_dtRatioAllVJ2.Rows[i]["RATIO"]);
                        //Card.BindingArc(RATIOPLANT, 1);
                        Card.BindingArc(RATIOALL, 2);
                        tblMainVJ2.Controls.Add(Card, i, 0);
                        UC[iDx] = Card;
                        iDx++;
                    }
                    //Khởi tạo card VJ3
                    for (int i = 0; i < tblMainVJ3.ColumnCount; i++)
                    {
                        tmsHomeModel model = new tmsHomeModel();
                        UC.UC_TMS_CARD_V3 Card = new UC.UC_TMS_CARD_V3();
                        model.PROC_NAME_CARD = dtVJ3.Rows[i]["PROC_NAME"].ToString();
                        model.PROC_CODE_CARD = dtVJ3.Rows[i]["PROC_CODE"].ToString();
                        model.FACTORY = "3";
                        model.IS_BOTTOM = Convert.ToBoolean(dtVJ3.Rows[i]["REMARKS"].ToString().Equals("BOTTOM") ? 1 : 0);
                        model.USE_YN = dtVJ3.Rows[i]["USE_YN"].ToString();
                        model.PART_SHOW_YN = Convert.ToBoolean(dtVJ3.Rows[i]["PART_SHOW_YN"].ToString().Equals("Y") ? 1 : 0);
                        Card.BindingData(model);
                        // RATIOPLANT = Convert.ToInt32(_dtRatioPlantVJ3.Rows[i]["RATIO"]);
                        RATIOALL = Convert.ToInt32(_dtRatioAllVJ3.Rows[i]["RATIO"]);
                        //Card.BindingArc(RATIOPLANT, 1);
                        Card.BindingArc(RATIOALL, 2);
                        tblMainVJ3.Controls.Add(Card, i, 0);
                        UC[iDx] = Card;
                        iDx++;
                    }
                }
            }
            catch
            {
            }
        }
        private void FRM_TMS_HOME_Load(object sender, EventArgs e)
        {
            txt = label1.Text;
            len = txt.Length;
            label1.Text = "";
            tmrTitle.Start();
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
            DataTable dt = TMS_HOME_SELECT("Q1", DateTime.Now.ToString()); //Lấy dữ liệu từ DB
            //  DataTable dtRatioPlant = TMS_HOME_RATIO_SELECT("Q", DateTime.Now.ToString("yyyyMMdd"), ComVar.Var._strValue1).Tables[0];
            DataTable dtRatioAll = TMS_HOME_RATIO_SELECT("Q", DateTime.Now.ToString("yyyyMMdd"), ComVar.Var._strValue1).Tables[1];
            InitUC_Card(dt, null, dtRatioAll);
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
            ComVar.Var.callForm = "minimized";
        }
        private void BindingRatioData()
        {
            // DataTable dtRatioPlant = TMS_HOME_RATIO_SELECT("Q", DateTime.Now.ToString("yyyyMMdd"), ComVar.Var._strValue1).Tables[0];
            DataTable dtRatioAll = TMS_HOME_RATIO_SELECT("Q", DateTime.Now.ToString("yyyyMMdd"), ComVar.Var._strValue1).Tables[1];
            for (int i = 0; i < UC.Length; i++)
            {
                //UC[i].BindingArc(string.IsNullOrEmpty(dtRatioPlant.Rows[i]["RATIO"].ToString()) ? 0 : Convert.ToInt32(dtRatioPlant.Rows[i]["RATIO"]), 1);
                UC[i].BindingArc(string.IsNullOrEmpty(dtRatioAll.Rows[i]["RATIO"].ToString()) ? 0 : Convert.ToInt32(dtRatioAll.Rows[i]["RATIO"]), 2);
            }
        }
        private void tmrDate_Tick(object sender, EventArgs e)
        {
            iCount++;
            try
            {
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
                if (iCount >= 10)
                {
                    iCount = 0;
                    Thread t = new Thread(BindingRatioData);
                    t.Start();
                }
                else if (iCount >= 5)
                {
                    tmrTitle.Start();
                }
            }
            catch { iCount = 0; }
        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tmrTitle_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter > len)
            {
                counter = 0;
                tmrTitle.Stop();
                //label1.Text = "";
            }
            else
            {
                label1.Text = txt.Substring(0, counter);
                if (label1.ForeColor == Color.Black)
                    label1.ForeColor = Color.Blue;
                else
                    label1.ForeColor = Color.Black;
            }
        }

        bool iback = false;
        private void FRM_TMS_HOME_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                iback = ComVar.Var._IsBack;
                if (!string.IsNullOrEmpty(ComVar.Var._Frm_Back))
                    if (ComVar.Var._Frm_Back.Equals("300") || ComVar.Var._Frm_Back.Equals("375"))
                        btnBack.Visible = true;
                    else
                        btnBack.Visible = false;
                else
                    btnBack.Visible = ComVar.Var._IsBack; //false;
                tmrDate.Start();
            }
            else
                tmrDate.Stop();
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ComVar.Var._Frm_Back))
            {
                if (!ComVar.Var._Frm_Back.Contains("SMT_I_TMS_MAIN"))
                    ComVar.Var.callForm = ComVar.Var._Frm_Back;
                else
                    ComVar.Var.callForm = "back";
            }
            else
            {
                ComVar.Var.callForm = "back";
            }
        }
    }
}
