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
    public partial class FRM_TMS_CAR_LT_NEW : Form
    {
        int angle = 0;
        int rotSpeed = 1;
        Point origin = new Point(550, 65);  // my origin
        // Point origin = new Point(847, 622);  // my origin
        Point Lighting = new Point(556, 1011);
        int distance = 20;
        int _iStartText = 0;
        public FRM_TMS_CAR_LT_NEW()
        {
            InitializeComponent();
        }

        private void FRM_TMS_CAR_LT_NEW_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cbdate.DateTime = DateTime.Now;
            GoFullscreen();
            //   initForm();
          //  _Loc_X = pic_Car.Location.X;
            load_Data();
            runTextModel();
        }
        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }
        #region DB
        private System.Data.DataSet Select_Ora_Grid()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.SP_TMS_LT_VC";
                //ARGMODE
                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "V_P_LINE";
                MyOraDB.Parameter_Name[1] = "V_P_YMD";
                MyOraDB.Parameter_Name[2] = "CV_1";
                // MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                // MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;    
                MyOraDB.Parameter_Type[2] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = "001";
                MyOraDB.Parameter_Values[1] = cbdate.DateTime.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[2] = "";
                // MyOraDB.Parameter_Values[3] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret;
            }
            catch
            {
                return null;
            }
        }

        private System.Data.DataSet Select_Ora_Gauge()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS.TMS_SEQ_SUM_SEL";
                //ARGMODE
                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_DATE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE";
                MyOraDB.Parameter_Name[2] = "ARG_SEQ";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = DateTime.Now.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[1] = "014";
                MyOraDB.Parameter_Values[2] = "1";
                MyOraDB.Parameter_Values[3] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret;
            }
            catch
            {
                return null;
            }
        }

        public static Dictionary<string, Tuple<string, string, string, string, string, string>> getInitForm2(string dll_name, string class_name)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            DataTable dt;
            Dictionary<string, Tuple<string, string, string, string, string, string>> dtn = null;
            string process_name = "SEPHIROTH.PROC_STB_GET_FORM_INIT";

            MyOraDB.ReDim_Parameter(3);
            MyOraDB.Process_Name = process_name;

            MyOraDB.Parameter_Name[0] = "ARG_DLL_NM";
            MyOraDB.Parameter_Name[1] = "ARG_CLASS_NM";
            MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = dll_name;
            MyOraDB.Parameter_Values[1] = class_name;
            MyOraDB.Parameter_Values[2] = "";

            MyOraDB.Add_Select_Parameter(true);
            ds_ret = MyOraDB.Exe_Select_Procedure();

            if (ds_ret != null)
            {
                dt = ds_ret.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    dtn = new Dictionary<string, Tuple<string, string, string, string, string, string>>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dtn.Add(dt.Rows[i]["COM_NM"].ToString()
                               , new Tuple<string, string, string, string, string, string>(dt.Rows[i]["COM_VL"].ToString(), dt.Rows[i]["VALUE2"].ToString(), dt.Rows[i]["VALUE3"].ToString()
                                                                                         , dt.Rows[i]["VALUE4"].ToString(), dt.Rows[i]["VALUE5"].ToString(), dt.Rows[i]["VALUE6"].ToString()));
                    }
                }
            }
            return dtn;
        }
        #endregion DB

        private void load_Data()
        {
            try
            {
                DataTable data = null;
                data = Select_Ora_Grid().Tables[0];

                grdBase.DataSource = data;

                for (int i = 0; i < gvwBase.Columns.Count; i++)
                {
                    if (i == 0 || i == 4 || i == 3)
                    {
                        gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    }
                    else
                    {
                        gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    }
                    gvwBase.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvwBase.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gvwBase.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvwBase.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                    gvwBase.Columns["TRIP"].Width = 30;
                    gvwBase.Columns["START TIME"].Width = 50;
                    gvwBase.Columns["ARRIVAL TIME"].Width = 50;


                }
                gvwBase.OptionsView.AllowCellMerge = true;
            }
            catch
            { }
        }

        private void gvwBase_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (gvwBase.GetRowCellValue(e.RowHandle, gvwBase.Columns["DIVISION"]).ToString().Contains("GREEN"))
                
            {
                e.Appearance.BackColor = Color.LightSkyBlue;

            }
            if (gvwBase.GetRowCellValue(e.RowHandle, gvwBase.Columns["DIVISION"]).ToString().Contains("RED"))
            {
                e.Appearance.BackColor = Color.Red;

            }
            if (gvwBase.GetRowCellValue(e.RowHandle, gvwBase.Columns["DIVISION"]).ToString().Contains("YELLOW"))
            {
                e.Appearance.BackColor = Color.Yellow;

            }
            
        }

        private void bgw_ER_Check_DoWork(object sender, DoWorkEventArgs e)
        {
            if (pic_Car.InvokeRequired == true)
                pic_Car.Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        angle += rotSpeed;
                     //   int x = (int)(origin.X + distance * Math.Sin(angle * Math.PI / 100));
                      //  int y = (int)(origin.Y + distance * Math.Cos(angle * Math.PI / 300f));
                        int x = (int)(origin.X + distance + angle/200 );
                        int y = (int)(origin.Y  );
                        pic_Car.Location = new Point(x, y);
                        if (angle == 6000)
                        {
                            angle = 0;
                        }

                    }
                    catch { }
                });
        }

        private void cbdate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                load_Data();
            }
            catch
            {

            }
        }

        private void tmr_rotate_er_check_Tick(object sender, EventArgs e)
        {
            if (!bgw_ER_Check.IsBusy)
            {
                bgw_ER_Check.RunWorkerAsync();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            runTextModel();
        }
      
        private void runTextModel()
        {
            string blank = "          ";
            addTextGauge("Long Thanh going to Vinh Cuu" + blank, dtgestimate);
            _iStartText++;
        }

        private void addTextGauge(string arg_str, DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge gauge)
        {

            if (arg_str.Length <= 20)
            {
                arg_str = arg_str.PadRight(20, ' ');
            }

            if (_iStartText + 1 > arg_str.Length)
            {
                _iStartText = 0;
            }

            gauge.Text += arg_str.Substring(_iStartText, 1);
        }

        


        

    }

}
