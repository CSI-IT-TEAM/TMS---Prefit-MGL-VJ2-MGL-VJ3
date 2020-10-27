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
        int X_Car1, Y_Car1, X_Car2, Y_Car2, X_Car3, Y_Car3;
        Point ORI_CAR1 = new Point(789, 491);  // car vc
        Point ORI_CAR2 = new Point(988, 752); // new Point(941, 802);  // car lt
        Point ORI_CAR3 = new Point(1518, 134);  // car tp

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (btnCar.InvokeRequired == true)
                btnCar.Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        //Xuất phát từ Vĩnh Cửu ->Long Thành
                        if (!string.IsNullOrEmpty(btnCar.Text))
                        {
                            Y_Car1 -= rotSpeed * 2;
                            X_Car1 += rotSpeed;
                            if (!VC_LT_DepartTime.Equals("0"))
                            {

                                if (Convert.ToInt32(VC_LT_DepartTime) >= 60)
                                {
                                    X_Car1 = 958;
                                    Y_Car1 = 832;
                                    btnCar.Text = "VJ1->VJ2";
                                    btnCar.Location = new Point(X_Car1, Y_Car1);
                                }
                                else
                                {
                                    Y_Car1 = (-1 * Convert.ToInt32(VC_LT_DepartTime) * (5 / 2)) * 2;
                                    X_Car1 = Convert.ToInt32(VC_LT_DepartTime) * (5 / 2);
                                    btnCar.Location = new Point(ORI_CAR1.X + X_Car1, ORI_CAR1.Y - Y_Car1);
                                }
                            }
                            else
                            {
                                X_Car1 = 152; Y_Car1 = -311;
                                btnCar.Text = "VJ1->VJ2";
                              //  btnCar.Location = new Point(X_Car1, Y_Car1);
                                btnCar.Location = new Point(ORI_CAR1.X, ORI_CAR1.Y);
                            }

                            if (btnCar.Location.X >= 941 && btnCar.Location.Y >= 802)  //941, 802
                            {
                                X_Car1 = 958;
                                Y_Car1 = 832;
                                btnCar.Location = new Point(X_Car1, Y_Car1);
                            }

                        }
                        else
                        {
                            btnCar.Location = new Point(ORI_CAR1.X, ORI_CAR1.Y);
                            btnCar.Text = "VJ1->VJ2";
                            btnCar.Location = new Point(X_Car1, Y_Car1);
                        }


                        //======================================================================

                        //Xuất phát từ Long Thành -> Vĩnh Cửu
                        if (!string.IsNullOrEmpty(btnCar2.Text))
                        {
                            if (!string.IsNullOrEmpty(LT_VC_DepartTime))
                            {
                                DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(LT_VC_DepartTime.Substring(0, 2)), Convert.ToInt32(LT_VC_DepartTime.Substring(3, 2)), 00);
                                DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                Convert.ToInt32(DateTime.Now.ToString("HH")), Convert.ToInt32(DateTime.Now.ToString("mm")), 00);
                                TimeSpan span = endTime.Subtract(startTime);
                                minutes = Convert.ToInt32(span.TotalMinutes);
                                Y_Car2 = (minutes * (5 / 2)) * 2;
                                X_Car2 = (-1 * (minutes * (5 / 2)));
                                if (minutes >= 60)
                                {
                                    Y_Car2 = 311;
                                    X_Car2 = -152;
                                    btnCar2.Text = "VJ2->VJ1";
                                }
                                btnCar2.Location = new Point(ORI_CAR2.X + X_Car2, ORI_CAR2.Y - Y_Car2);
                            }
                            else
                            {
                                //868, 667

                                Y_Car2 = 746;// 311;
                                X_Car2 = 975;// -152;
                                btnCar2.Text = "VJ2->VJ1";
                                btnCar2.Location = new Point(X_Car2, Y_Car2);
                            }

                            if (btnCar2.Location.X <= 789 && btnCar2.Location.Y <= 491)  //VC: 789, 491  LT: 941, 802
                            {
                                Y_Car2 = 746;// 311;
                                X_Car2 = 975;// -152;
                                btnCar2.Text = "VJ2->VJ1";
                                btnCar2.Location = new Point(X_Car2, Y_Car2);
                            }
                        }
                        else
                        { btnCar2.Location = new Point(ORI_CAR2.X, ORI_CAR2.Y); btnCar2.Text = ""; }

                        //Xuất phát từ TÂN PHÚ -> Vĩnh Cửu
                        if (!string.IsNullOrEmpty(btnCar3.Text))
                        {
                            if (!string.IsNullOrEmpty(TP_VC_Departtime))
                            {
                                DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(TP_VC_Departtime.Substring(0, 2)), Convert.ToInt32(TP_VC_Departtime.Substring(3, 2)), 00);
                                DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                Convert.ToInt32(DateTime.Now.ToString("HH")), Convert.ToInt32(DateTime.Now.ToString("mm")), 00);
                                TimeSpan span = endTime.Subtract(startTime);
                                minutes = Convert.ToInt32(span.TotalMinutes);

                                if (minutes >= 180 || TP_VC_Arr.Equals("1"))
                                {
                                    Y_Car3 = 499;
                                    X_Car3 = 792;
                                    btnCar3.Location = new Point(X_Car3, Y_Car3);
                                    btnCar3.Text = "VJ3->VJ1";
                                    return;
                                }
                                else
                                {
                                    Y_Car3 = minutes * (5 / 2);
                                    X_Car3 = minutes * (5 / 2);
                                    btnCar3.Location = new Point(ORI_CAR3.X - X_Car3 * 2, ORI_CAR3.Y + Y_Car3);
                                }
                            }
                            else
                            {
                                Y_Car3 = 499;
                                X_Car3 = 792;
                                btnCar3.Location = new Point(ORI_CAR3.X, ORI_CAR3.Y);
                                btnCar3.Text = "VJ3->VJ1";
                            }

                            if (btnCar3.Location.X <= 792 && btnCar3.Location.Y >= 499)  //VC: 789, 491  LT: 941, 802
                            {
                                Y_Car3 = 510;// 499;
                                X_Car3 = 800;// 792;
                                btnCar3.Text = "VJ3->VJ1";
                                btnCar3.Location = new Point(X_Car3, Y_Car3);
                            }
                        }
                        else
                        { btnCar3.Location = new Point(ORI_CAR3.X, ORI_CAR3.Y); btnCar3.Text = "VJ3->VJ1"; }
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

        private DataTable Select_VC_LT_Ora_Grid_Realtime()
        {

            try
            {

                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_VC_TO_LT_V1.SP_TMS_REAL_TIME";
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
        private DataTable Select_Train_Time(string Qtype, string Factory)
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

        string LT_VC_DepartTime = "", VC_LT_DepartTime = "", TP_VC_Departtime,TP_VC_Arr;
        public void GetDepartTime()
        {
            DataTable dtLTVC = new DataTable();
            DataTable dtVCLT = new DataTable();
            DataTable dtTPVC = new DataTable();
            DataTable dtQuaLTVC = new DataTable();
            DataTable dtQuaVCLT = new DataTable();
            DataTable dtQuaTPVC = new DataTable();

            dtLTVC = Select_Train_Time();
            dtQuaLTVC = Select_LT_VC_Total_Trip();
            dtQuaVCLT = Select_VC_LT_Ora_Grid_Total();
            dtTPVC = Select_Train_Time("Q", "VJ3");
            dtQuaTPVC = Select_qty_Trip();

            if (dtLTVC.Rows.Count > 0 && dtLTVC != null)
            {
                LT_VC_DepartTime = dtLTVC.Rows[0]["LT_DEPART"].ToString();
                if (dtQuaLTVC.Rows.Count > 0 && dtQuaLTVC != null)
                    if (dtQuaLTVC.Select("TRIP = '" + dtQuaLTVC.Rows[0]["CUR_TRIP"].ToString() + "'").Count() > 0)
                    {
                        string Qty = string.Concat("Trip: ", dtQuaLTVC.Rows[0]["CUR_TRIP"].ToString(), "\n", string.Format("{0:n0}", dtQuaLTVC.Select("TRIP = '" + dtQuaLTVC.Rows[0]["CUR_TRIP"].ToString() + "'").CopyToDataTable().Rows[0]["QTY"]), " Prs");
                        btnCar2.Text = Qty + "\nVJ2->VJ1";
                    }
                    else
                        btnCar2.Text = "VJ2->VJ1";
            }

            dtVCLT = Select_VC_LT_Ora_Grid_Realtime();
            if (dtVCLT.Rows.Count > 0 && dtVCLT != null)
            {
                VC_LT_DepartTime = dtVCLT.Rows[0]["TIME_DEPART"].ToString();
                if (dtQuaVCLT.Rows.Count > 0 && dtQuaVCLT != null)
                    if (dtQuaVCLT.Select("TRIP = '" + dtQuaVCLT.Rows[0]["CUR_TRIP"].ToString() + "'").Count() > 0)
                    {
                        string Qty = string.Concat("Trip: ", dtQuaVCLT.Rows[0]["CUR_TRIP"].ToString(), "\n", string.Format("{0:n0}", dtQuaVCLT.Select("TRIP = '" + dtQuaVCLT.Rows[0]["CUR_TRIP"].ToString() + "'").CopyToDataTable().Rows[0]["QTY"]), " Prs");
                        btnCar.Text = Qty + "\nVJ1->VJ2";
                    }
                    else
                        btnCar.Text = "VJ1->VJ2";
            }

            if (dtTPVC.Rows.Count > 0 && dtTPVC != null)
            {
                TP_VC_Departtime = dtTPVC.Rows[0]["DP_TIME"].ToString();
                TP_VC_Arr = dtTPVC.Rows[0]["ARR_YN"].ToString();
            }
            if (dtQuaTPVC.Rows.Count > 0 && dtQuaTPVC != null)
            {
                if (dtQuaTPVC.Rows[0]["QTY"].Equals("0") || dtQuaTPVC.Rows[0]["CUR_TRIP"].Equals("0"))
                    btnCar3.Text = "";
                else
                {
                    string Qty = string.Concat("Trip: 1", "\n", string.Format("{0:n0}", dtQuaTPVC.Rows[0]["QTY"]), " Prs");
                    btnCar3.Text = Qty + "\nVJ3->VJ1";
                }
            }
            else
                btnCar3.Text = "VJ3->VJ1";
            tmrCarRun.Start();

        }
        private void FRM_VJ_MAPS_Load(object sender, EventArgs e)
        {
            GetDepartTime();
        }

        private void tmrGetDepart_Tick(object sender, EventArgs e)
        {
            iCount++;
            if (iCount >= 60)
            {
                GetDepartTime();
                iCount = 0;
            }

        }

        private void btnCar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtQua = new DataTable();
            string _Code = ((Button)sender).Tag.ToString();
            switch (_Code)
            {
                case "1":
                    dt = Select_Train_Real_Time();
                    dtQua = Select_LT_VC_Total_Trip();
                    break;
                case "2":
                    dt = Select_VC_LT_Ora_Grid_Realtime();
                    dtQua = Select_VC_LT_Ora_Grid_Total();
                    break;
                case "3":
                    dt = SELECT_TMS_VJ3_TRIP_TIME();
                    dtQua = Select_qty_Trip();
                    break;
                case "4":
                    break;
            }

            if (dt.Rows.Count > 0 && dt != null)
            {
                FRM_POPUP_CAR_INFO_2 f_car_info = new FRM_POPUP_CAR_INFO_2();
                f_car_info.BindingData(_Code, ComVar.Var._strValue1, dt, dtQua);
                f_car_info.ShowDialog();
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
        private DataTable Select_LT_VC_Total_Trip()
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
                MyOraDB.Parameter_Values[1] = "VJ1";
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

        private DataTable Select_VC_LT_Ora_Grid_Total()
        {

            try
            {

                COM.OraDB MyOraDB = new COM.OraDB(1);
                System.Data.DataSet ds_ret;

                string process_name = "SP_OUT_SCN_VJ1_VJ2";
                //ARGMODE
                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_TRIP";
                MyOraDB.Parameter_Name[2] = "CV_1";


                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.Cursor;
                // MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = "";
                MyOraDB.Parameter_Values[1] = "";
                MyOraDB.Parameter_Values[2] = "";
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
    }
}
