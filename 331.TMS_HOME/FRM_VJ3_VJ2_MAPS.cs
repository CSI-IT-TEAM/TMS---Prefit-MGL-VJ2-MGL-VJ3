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
    public partial class FRM_VJ3_VJ2_MAPS : Form
    {
        public FRM_VJ3_VJ2_MAPS()
        {
            InitializeComponent();
        }
        int iCount = 0;
        int distance = 1;
        int angle = 0;
        int rotSpeed = 1;
        string LTDepartTime = "";
        int minutes = 0;
        Point A = new Point(82, 322);  // my origin
        Point B = new Point(1250, 322);  // my origin
        int xMove = 0;

        private DataTable Select_Train_Time(string Qtype,string Factory)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;
                string process_name = "MES.PKG_TMS_HOME.TMS_GET_DEPART_TIME";
                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_FAC";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = Qtype;
                MyOraDB.Parameter_Values[1] = Factory;
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
        private DataTable Select_qty_Trip()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.SP_TMS_LT_TOTAL_TRIP";
                //ARGMODE
                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "V_P_YMD";
                MyOraDB.Parameter_Name[1] = "V_P_LOCATION";
                MyOraDB.Parameter_Name[2] = "CV_1";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = DateTime.Now.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[1] = "VJ3";
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

        private DataTable SELECT_TMS_VJ3_TRIP_TIME()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.SP_VJ3_TMS_TRIP_TIME";
                MyOraDB.ReDim_Parameter(1);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = "";

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
        private void tmrCarRun_Tick(object sender, EventArgs e)
        {
            if (!bgWorker.IsBusy)
            {
                bgWorker.RunWorkerAsync();
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            angle += rotSpeed;
            int y = A.Y;
            y = (int)(A.Y + distance * Math.Sin(angle * Math.PI / 5));
            DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(LTDepartTime.Substring(0, 2)), Convert.ToInt32(LTDepartTime.Substring(3, 2)), 00);
            DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
            Convert.ToInt32(DateTime.Now.ToString("HH")), Convert.ToInt32(DateTime.Now.ToString("mm")), 00);
            TimeSpan span = endTime.Subtract(startTime);
            minutes = Convert.ToInt32(span.TotalMinutes);
            xMove = A.X + minutes * 6;
            if (xMove >= B.X || minutes >= 180)
            {
                btnCar.Location = new Point(B.X, B.Y);
                xMove = 0;
                tmrCarRun.Stop();
                tmrGetDepart.Stop();
            }
            else
            {
                btnCar.Location = new Point(A.X + xMove, y);
            }
        }
        public void GetDepartTime(string ButtonCode)
        {
            DataTable dt = new DataTable();
            DataTable dtQua = new DataTable();
            dt = Select_Train_Time("Q", ButtonCode);
            dtQua = Select_qty_Trip();
            if (dt.Rows.Count > 0 && dt != null)
                LTDepartTime = dt.Rows[0]["DP_TIME"].ToString();
            if (dtQua.Rows.Count > 0 && dtQua != null)
            {
                string Qty = string.Concat("Trip: 1", "\n", string.Format("{0:n0}", dtQua.Rows[0]["QTY"]), " Prs");
                btnCar.Text = Qty;
            }
            else
                btnCar.Text = "";
        }
        private void tmrGetDepart_Tick(object sender, EventArgs e)
        {
            iCount++;
            if (iCount >= 180)
            {
                GetDepartTime("VJ3");
                iCount = 0;
            }
        }

        private void FRM_VJ3_VJ1_MAPS_Load(object sender, EventArgs e)
        {
            GetDepartTime("VJ3");
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            
        }
        private void btnCar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtQua = new DataTable();
            dt = SELECT_TMS_VJ3_TRIP_TIME();
            dtQua = Select_qty_Trip();

            if (dt.Rows.Count > 0 && dt != null)
            {
                FRM_POPUP_CAR_INFO_2 f_car_info = new FRM_POPUP_CAR_INFO_2();
                f_car_info.BindingData("3", ComVar.Var._strValue1, dt, dtQua);
                f_car_info.ShowDialog();
            }
        }


    }
}
