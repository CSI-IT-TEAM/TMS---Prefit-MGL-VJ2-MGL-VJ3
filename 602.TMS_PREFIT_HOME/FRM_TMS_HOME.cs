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
        UC.UC_TMS_CARD[] UC = new UC.UC_TMS_CARD[15];
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
            catch
            {
                return null;
            }
        }
        #endregion

        private void tblMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InitUC_Card(DataTable dt)
        {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataTable dtVJ1 = dt.Select("FACTORY = '1'", "PROC_ID").CopyToDataTable(); //Layout VJ1
                    DataTable dtVJ2 = dt.Select("FACTORY = '2'", "PROC_ID").CopyToDataTable(); //Layout VJ2
                    DataTable dtVJ3 = dt.Select("FACTORY = '3'", "PROC_ID").CopyToDataTable(); //Layout VJ3
                    
                    int iDx = 0;
                    //Khởi tạo card VJ1
                    for (int i = 0; i < tblMainVJ1.ColumnCount; i++)
                    {
                        tmsHomeModel model = new tmsHomeModel();
                        
                        UC.UC_TMS_CARD Card = new UC.UC_TMS_CARD();
                        model.PROC_NAME_CARD = dtVJ1.Rows[i]["PROC_NAME"].ToString();
                        Card.BindingData(model);
                        Card.BindingArc(r.Next(50, 100), 1);
                        Card.BindingArc(r.Next(50, 100), 2);
                        tblMainVJ1.Controls.Add(Card, i, 0);
                        
                        UC[iDx] = Card;
                        iDx++;
                    }

                    //Khởi tạo card VJ2
                    for (int i = 0; i < tblMainVJ2.ColumnCount; i++)
                    {
                        tmsHomeModel model = new tmsHomeModel();
                        UC.UC_TMS_CARD Card = new UC.UC_TMS_CARD();
                        model.PROC_NAME_CARD = dtVJ2.Rows[i]["PROC_NAME"].ToString();
                        Card.BindingData(model);
                        Card.BindingArc(r.Next(50, 100),1);
                        Card.BindingArc(r.Next(50, 100), 2);
                        tblMainVJ2.Controls.Add(Card, i, 0);
                        
                        UC[iDx] = Card;
                        iDx++;
                    }

                    //Khởi tạo card VJ3
                    for (int i = 0; i < tblMainVJ3.ColumnCount; i++)
                    {
                        tmsHomeModel model = new tmsHomeModel();
                        UC.UC_TMS_CARD Card = new UC.UC_TMS_CARD();
                        model.PROC_NAME_CARD = dtVJ3.Rows[i]["PROC_NAME"].ToString();
                        Card.BindingData(model);
                        Card.BindingArc(r.Next(50, 100),1);
                        Card.BindingArc(r.Next(50, 100), 2);
                        tblMainVJ3.Controls.Add(Card, i, 0);
                        UC[iDx] = Card;
                        
                        iDx++;
                    }
                }
            }
            catch {
               
            }
        }
        private void FRM_TMS_HOME_Load(object sender, EventArgs e)
        {
            txt = label1.Text;
            len = txt.Length;
            label1.Text = "";
            tmrTitle.Start();
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
            DataTable dt = TMS_HOME_SELECT("Q1",DateTime.Now.ToString()); //Lấy dữ liệu từ DB
            InitUC_Card(dt);
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            iCount++;

            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
            if (iCount >= 30)
            {
                iCount = 0;
                for (int i = 0; i < UC.Length; i++)
                {
                    UC[i].BindingArc(r.Next(20, 100), 1);
                    UC[i].BindingArc(r.Next(20, 100), 2);
                }
            }
            else if (iCount >= 5)
            {
                tmrTitle.Start();
            }
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
    }
}
