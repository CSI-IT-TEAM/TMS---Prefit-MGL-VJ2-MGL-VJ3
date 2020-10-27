using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
//using CefSharp;
//using CefSharp.WinForms;
namespace FORM
{
    public partial class MapsF : Form
    {
        public MapsF()
        {
            InitializeComponent();
            tmrCarRun.Stop();
            // InitBrowser();
        }
        int iCount = 0;
        int distance = 1;
        int angle = 0;
        int rotSpeed = 1;
        string LTDepartTime = "";
        int minutes = 0;
        Point origin = new Point(133, 310);  // my origin

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

        private DataTable Select_VC_LT_Ora_Grid_Total()
        {

            try
            {

                COM.OraDB MyOraDB = new COM.OraDB(1); //lmes
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




        //public ChromiumWebBrowser browser;
        //public void InitBrowser()
        //{

        //    Cef.Initialize(new CefSettings());
        //    browser = new ChromiumWebBrowser("www.google.com");
        //    this.Controls.Add(browser);
        //    browser.Dock = DockStyle.Fill;
        //}
        string _Code = "";
        public void LoadMaps(string ButtonCode)
        {
            //string url = "http://basemaps.cartocdn.com/#13/40.7062/-74.0045";
            //  webBrowser1.Navigate(url);
            _Code = ButtonCode;
            switch (ButtonCode)
            {
                case "1":
                    panel2.BackgroundImage = Properties.Resources.VJ2_VJ1_MAPS;
                    break;
                case "2":
                    panel2.BackgroundImage = Properties.Resources.VJ1_VJ2_maps;
                    break;
                case "3":

                    break;
                case "4":
                    break;
            }
        }
        public void GetDepartTime(string ButtonCode)
        {
            DataTable dt = new DataTable();
            DataTable dtQua = new DataTable();
            switch (ButtonCode)
            {
                case "1":
                    dt = Select_Train_Time();
                    dtQua = Select_LT_VC_Total_Trip();
                    if (dt.Rows.Count > 0 && dt != null)
                        LTDepartTime = dt.Rows[0]["LT_DEPART"].ToString();
                    if (dtQua.Rows.Count > 0 && dtQua != null)
                        if (dtQua.Select("TRIP = '" + dtQua.Rows[0]["CUR_TRIP"].ToString() + "'").Count() > 0)
                        {
                            string Qty = string.Concat("Trip: ", dtQua.Rows[0]["CUR_TRIP"].ToString(), "\n", string.Format("{0:n0}", dtQua.Select("TRIP = '" + dtQua.Rows[0]["CUR_TRIP"].ToString() + "'").CopyToDataTable().Rows[0]["QTY"]), " Prs");
                            btnCar.Text = Qty;
                        }
                        else
                            btnCar.Text = "VJ2->VJ1";
                    break;
                case "2":
                    dt = Select_VC_LT_Ora_Grid_Realtime();
                    dtQua = Select_VC_LT_Ora_Grid_Total();
                    if (dt.Rows.Count > 0 && dt != null)
                        LTDepartTime = dt.Rows[0]["TIME_DEPART"].ToString();
                    if (dtQua.Rows.Count > 0 && dtQua != null)
                        if (dtQua.Select("TRIP = '" + dtQua.Rows[0]["CUR_TRIP"].ToString() + "'").Count() > 0)
                        {
                            string Qty = string.Concat("Trip: ", dtQua.Rows[0]["CUR_TRIP"].ToString(), "\n", string.Format("{0:n0}", dtQua.Select("TRIP = '" + dtQua.Rows[0]["CUR_TRIP"].ToString() + "'").CopyToDataTable().Rows[0]["QTY"]), " Prs");
                            btnCar.Text = Qty ;
                        }
                        else
                            btnCar.Text = "VJ2->VJ1";
                    break;
                case "3":

                    break;
                case "4":
                    break;
            }
            tmrCarRun.Start();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtQua = new DataTable();
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

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (btnCar.InvokeRequired == true)
                btnCar.Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        angle += rotSpeed;
                        int y = 310, x = 130;//1272;
                        y = (int)(origin.Y + distance * Math.Sin(angle * Math.PI / 5)); //
                        if (!LTDepartTime.Equals("") && !LTDepartTime.Equals("0"))
                        // x = (int)(origin.X + angle);
                        //else
                        {
                            switch (_Code)
                            {
                                case "1":
                                    DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(LTDepartTime.Substring(0, 2)), Convert.ToInt32(LTDepartTime.Substring(3, 2)), 00);
                                    DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                    Convert.ToInt32(DateTime.Now.ToString("HH")), Convert.ToInt32(DateTime.Now.ToString("mm")), 00);
                                    TimeSpan span = endTime.Subtract(startTime);
                                    minutes = Convert.ToInt32(span.TotalMinutes);
                                    if (minutes >= 60)
                                    {
                                        x = 1272;
                                        btnCar.Text = "VJ2->VJ1";
                                    }
                                    else
                                        x = 130 + minutes * 19;
                                    break;
                                case "2":
                                    if (Convert.ToInt32(LTDepartTime) >= 60 || LTDepartTime.Equals("0"))
                                    {
                                        x = 1272;
                                        btnCar.Text = "VJ1->VJ2";
                                    }
                                    else
                                        x = 130 + Convert.ToInt32(LTDepartTime) * 10;
                                    break;
                                default:
                                    break;
                            }

                        }
                        btnCar.Location = new Point(x, y);
                        if (angle >= 1100)
                            angle = 0;

                    }
                    catch { }
                }
                );
        }

        private void tmrCarRun_Tick(object sender, EventArgs e)
        {
            if (!bgWorker.IsBusy)
            {
                bgWorker.RunWorkerAsync();
            }
        }

        private void MapsF_Load(object sender, EventArgs e)
        {

        }
        private void tmrGetDepart_Tick(object sender, EventArgs e)
        {
            iCount++;
            if (iCount >= 180)
            {
                GetDepartTime(_Code);
                iCount = 0;
            }
        }

    }
}
