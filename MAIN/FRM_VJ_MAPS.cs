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
    public partial class FRM_VJ_MAPS : Form
    {
        public FRM_VJ_MAPS()
        {
            InitializeComponent();
        }

        //Info Car
        int iCount = 0;
        int distance = 5;
        int angle1 = 0, angleY = 491;
        int angle2 = 0, angleY2 = 491;
        int rotSpeed = 5;
        int minutes = 0;
        Point origin = new Point(789, 491);  // my origin
        Point origin2 = new Point(789, 491);  // my origin

        //info car new
        int X_Car1, Y_Car1, X_Car2, Y_Car2;
        Point ORI_CAR1 = new Point(789, 491);  // car vc
        Point ORI_CAR2 = new Point(941, 802);  // car lt


        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (btnCar.InvokeRequired == true)
                btnCar.Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        //Xuất phát từ Vĩnh Cửu ->Long Thành
                        Y_Car1 -= rotSpeed * 2;
                        X_Car1 += rotSpeed;
                        if (!VC_LT_DepartTime.Equals("0"))
                        {
                            if (Convert.ToInt32(VC_LT_DepartTime) >= 60)
                            { X_Car1 = 0; Y_Car1 = 0; }
                            else
                            {
                                Y_Car1 = -1 * Convert.ToInt32(VC_LT_DepartTime) * 3;
                                X_Car1 = Convert.ToInt32(VC_LT_DepartTime) * 3;
                            }
                        }
                        else
                        { X_Car1 = 0; Y_Car1 = 0; }

                        btnCar.Location = new Point(ORI_CAR1.X + X_Car1, ORI_CAR1.Y - Y_Car1);
                        if (btnCar.Location.X >= 941 && btnCar.Location.Y >= 802)  //941, 802
                        { Y_Car1 = 0; X_Car1 = 0; }
                        //======================================================================

                        //Xuất phát từ Long Thành -> Vĩnh Cửu
                        //Y_Car2 += rotSpeed * 2;
                        //X_Car2 -= rotSpeed;

                        if (!string.IsNullOrEmpty(LT_VC_DepartTime))
                        {
                            DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(LT_VC_DepartTime.Substring(0, 2)), Convert.ToInt32(LT_VC_DepartTime.Substring(3, 2)), 00);
                            DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                            Convert.ToInt32(DateTime.Now.ToString("HH")), Convert.ToInt32(DateTime.Now.ToString("mm")), 00);
                            TimeSpan span = endTime.Subtract(startTime);
                            minutes = Convert.ToInt32(span.TotalMinutes);
                            Y_Car2 = (minutes * 3) * 2;
                            X_Car2 = -1 * minutes * 3;
                        }
                        else
                        {
                            X_Car2 = 0;
                            X_Car2 = 0;
                        }
                        btnCar2.Location = new Point(ORI_CAR2.X + X_Car2, ORI_CAR2.Y - Y_Car2);
                        if (btnCar2.Location.X <= 789 && btnCar2.Location.Y <= 491)  //789, 491
                        { Y_Car2 = 0; X_Car2 = 0; }

                    }
                    catch { }
                });
        }

        private void tmrCarRun_Tick(object sender, EventArgs e)
        {
            if (!bgWorker.IsBusy)
            {
                bgWorker.RunWorkerAsync();
            }
        }
        private DataTable Select_Train_Time()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;
                string process_name = "MES.SP_TMS_TRAIN_TIME";
                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "V_P_YMD";
                MyOraDB.Parameter_Name[1] = "CV_1";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = DateTime.Now.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[1] = "";

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
        private DataTable Select_Train_Real_Time()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;
                string process_name = "MES.SP_TMS_TRAIN_REAL_TIME";
                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "V_P_YMD";
                MyOraDB.Parameter_Name[1] = "CV_1";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = DateTime.Now.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[1] = "";

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
        private DataTable Select_VC_LT_Ora_Grid_Realtime()
        {

            try
            {

                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_VC_TO_LT.SP_TMS_REAL_TIME";
                //ARGMODE
                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "CV_1";


                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.Cursor;
                // MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = "";
                MyOraDB.Parameter_Values[1] = "";
                // MyOraDB.Parameter_Values[3] = "";
                // MyOraDB.Parameter_Values[3] = "";


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
        string LT_VC_DepartTime = "", VC_LT_DepartTime = "";
        public void GetDepartTime()
        {
            DataTable dtLTVC = new DataTable();
            DataTable dtVCLT = new DataTable();

            dtLTVC = Select_Train_Time();
            if (dtLTVC.Rows.Count > 0 && dtLTVC != null)
                LT_VC_DepartTime = dtLTVC.Rows[0]["LT_DEPART"].ToString();


            dtVCLT = Select_VC_LT_Ora_Grid_Realtime();
            if (dtVCLT.Rows.Count > 0 && dtVCLT != null)
                VC_LT_DepartTime = dtVCLT.Rows[0]["TIME_DEPART"].ToString();


            tmrCarRun.Start();

        }
        private void FRM_VJ_MAPS_Load(object sender, EventArgs e)
        {
            GetDepartTime();
        }

        private void tmrGetDepart_Tick(object sender, EventArgs e)
        {
            iCount++;
            if (iCount >= 180)
            {
                GetDepartTime();
                iCount = 0;
            }
        }




    }
}
