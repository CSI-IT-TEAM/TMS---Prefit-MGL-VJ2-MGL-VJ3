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
            tmrUnder.Stop();
            pnUnder.Visible = false;
        }
        #region Variable
        bool isBack = false;
        int counter = 0;
        int len = 0;
        string txt;
        Random r = new Random();
        UC.UC_TMS_CARD_V3[] UC = new UC.UC_TMS_CARD_V3[15];
        int iCount = 0;
        DataTable dtSet = new DataTable();
        #endregion
        #region Ora
        private DataTable TMS_PREFIT_SET_HOME(string ARG_TYPE)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_PREFIT.TMS_PREFIT_SET_HOME";
                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_TYPE;
                MyOraDB.Parameter_Values[1] = "";

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
            isBack = ComVar.Var._IsBack;

            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
            DataTable dt = TMS_HOME_SELECT("Q1", DateTime.Now.ToString()); //Lấy dữ liệu từ DB
            //  DataTable dtRatioPlant = TMS_HOME_RATIO_SELECT("Q", DateTime.Now.ToString("yyyyMMdd"), ComVar.Var._strValue1).Tables[0];
            DataTable dtRatioAll = TMS_HOME_RATIO_SELECT("Q", DateTime.Now.ToString("yyyyMMdd"), ComVar.Var._strValue1).Tables[1];
            InitUC_Card(dt, null, dtRatioAll);


            lbl70.Visible = false;
            lbl7090.Visible = false;
            lbl90.Visible = false;

            dtSet = TMS_PREFIT_SET_HOME("Q"); //Lấy dữ liệu từ DB

            sbSet(dtSet);

            //lbl70.Visible = true;
            //lbl7090.Visible = true;
            //lbl90.Visible = true;



        }

        private void sbSet(DataTable dtset)
        {

            lbl70.Visible = true;
            lbl7090.Visible = true;
            lbl90.Visible = true;

            string strvalue = "";

            
            //           string factory = ((System.Windows.Forms.Label) sender).Tag.ToString();// 
            for (int i = 0; i <= dtset.Rows.Count - 1; i++)
            {
                strvalue = dtset.Rows[i]["SET_RATE"].ToString();
                if (strvalue.Contains("100."))
                {
                    strvalue = "100";
                }
                if (dtset.Rows[i]["FACTORY"].ToString() == "1")
                {
                    if (dtset.Rows[i]["LINE_FTY"].ToString() == "Factory 1")
                    {
                        lblF1.Text = strvalue + "%";
                        sbSet_Color(strvalue, "lblF1");
                    }
                    else if (dtset.Rows[i]["LINE_FTY"].ToString() == "Factory 2")
                    {
                        lblF2.Text = strvalue + "%";
                        sbSet_Color(strvalue, "lblF2");
                    }
                    else if (dtset.Rows[i]["LINE_FTY"].ToString() == "Factory 3")
                    {
                        lblF3.Text = strvalue + "%";
                        sbSet_Color(strvalue, "lblF3");
                    }
                    else if (dtset.Rows[i]["LINE_FTY"].ToString() == "Factory 4")
                    {
                        lblF4.Text = strvalue + "%";
                        sbSet_Color(strvalue, "lblF4");
                    }
                    else if (dtset.Rows[i]["LINE_FTY"].ToString() == "Factory 5")
                    {
                        lblF5.Text = strvalue + "%";
                        sbSet_Color(strvalue, "lblF5");
                    }
                }
                else if (dtset.Rows[i]["FACTORY"].ToString() == "2")
                {
                    lblLT.Text = strvalue + "%";
                    sbSet_Color(strvalue, "lblLT");
                }
                else if (dtset.Rows[i]["FACTORY"].ToString() == "3")
                {
                    lblTP.Text = strvalue + "%";
                    sbSet_Color(strvalue, "lblTP");
                }
            }
            
            
        }
        private void sbSet_Color(string label_percent, string label_name)
        {
            double per = 0;

            //((System.Windows.Forms.Label)sender).Tag.ToString()

            double.TryParse(label_percent,out per);
            if (per < 70)
            {
                if (label_name == "lblF1")
                {
                    lblF1.BackColor = Color.Red;
                    lblF1.ForeColor = Color.White;
                }
                else if (label_name == "lblF2")
                {
                    lblF2.BackColor = Color.Red;
                    lblF2.ForeColor = Color.White;
                }
                else if (label_name == "lblF3")
                {
                    lblF3.BackColor = Color.Red;
                    lblF3.ForeColor = Color.White;
                }
                else if (label_name == "lblF4")
                {
                    lblF4.BackColor = Color.Red;
                    lblF4.ForeColor = Color.White;
                }
                else if (label_name == "lblF5")
                {
                    lblF5.BackColor = Color.Red;
                    lblF5.ForeColor = Color.White;
                }
                else if (label_name == "lblLT")
                {
                    lblLT.BackColor = Color.Red;
                    lblLT.ForeColor = Color.White;
                }
                else if (label_name == "lblTP")
                {
                    lblTP.BackColor = Color.Red;
                    lblTP.ForeColor = Color.White;
                }
            }
            else if (per >= 70 && per <= 90)
            {
                if (label_name == "lblF1")
                {
                    lblF1.BackColor = Color.Yellow;
                    lblF1.ForeColor = Color.Black;
                }
                else if (label_name == "lblF2")
                {
                    lblF2.BackColor = Color.Yellow;
                    lblF2.ForeColor = Color.Black;
                }
                else if (label_name == "lblF3")
                {
                    lblF3.BackColor = Color.Yellow;
                    lblF3.ForeColor = Color.Black;
                }
                else if (label_name == "lblF4")
                {
                    lblF4.BackColor = Color.Yellow;
                    lblF4.ForeColor = Color.Black;
                }
                else if (label_name == "lblF5")
                {
                    lblF5.BackColor = Color.Yellow;
                    lblF5.ForeColor = Color.Black;
                }
                else if (label_name == "lblLT")
                {
                    lblLT.BackColor = Color.Yellow;
                    lblLT.ForeColor = Color.Black;
                }
                else if (label_name == "lblTP")
                {
                    lblTP.BackColor = Color.Yellow;
                    lblTP.ForeColor = Color.Black;
                }
            }
            else if (per > 90)
            {
                if (label_name == "lblF1")
                {
                    lblF1.BackColor = Color.Green;
                    lblF1.ForeColor = Color.Black;
                }
                else if (label_name == "lblF2")
                {
                    lblF2.BackColor = Color.Green;
                    lblF2.ForeColor = Color.Black;
                }
                else if (label_name == "lblF3")
                {
                    lblF3.BackColor = Color.Green;
                    lblF3.ForeColor = Color.Black;
                }
                else if (label_name == "lblF4")
                {
                    lblF4.BackColor = Color.Green;
                    lblF4.ForeColor = Color.Black;
                }
                else if (label_name == "lblF5")
                {
                    lblF5.BackColor = Color.Yellow;
                    lblF5.ForeColor = Color.Black;
                }
                else if (label_name == "lblLT")
                {
                    lblLT.BackColor = Color.Green;
                    lblLT.ForeColor = Color.Black;
                }
                else if (label_name == "lblTP")
                {
                    lblTP.BackColor = Color.Green;
                    lblTP.ForeColor = Color.Black;
                }

            
            }
            


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
              btnBack.Visible = isBack;
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

        private void button_Click(object sender, EventArgs e)
        {
            cCountUnder = 0;
            Screen screen = Screen.FromControl(this);
            Rectangle workingArea = screen.WorkingArea;
            pnUnder.Visible = true;
            pnUnder.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - 150, Screen.PrimaryScreen.WorkingArea.Height / 2 - 100);
            tmrUnder.Start();
        }
        int cCountUnder = 0;
        private void tmrUnder_Tick(object sender, EventArgs e)
        {
            cCountUnder++;
            if (cCountUnder >= 2)
            {
                cCountUnder = 0;
                pnUnder.Visible = false;
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            cCountUnder = 0;
            Screen screen = Screen.FromControl(this);
            Rectangle workingArea = screen.WorkingArea;
            pnUnder.Visible = true;
            pnUnder.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - 150, Screen.PrimaryScreen.WorkingArea.Height / 2 - 100);
            tmrUnder.Start();
        }

     

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void lbl_Click(object sender, EventArgs e)
        {
            try
            {
                string Factory = ((System.Windows.Forms.Label)sender).Tag.ToString();// ComVar.Var._strValue1;
                string Plant = "";//ComVar.Var._strValue2;
                string isBottom = "";//ComVar.Var._bValue1.ToString();

                if (Factory == "1" || Factory == "2" || Factory == "3" || Factory == "4" || Factory == "5")
                {
                    Plant = "1";
                }
                else if (Factory == "LT")
                {
                    Plant = "2";
                }
                else if (Factory == "TP")
                {
                    Plant = "3";
                }


                FRM_TMS_PREFIT_SET_BALANCE POPUP = new FRM_TMS_PREFIT_SET_BALANCE(Plant, Factory, isBottom);
                POPUP.ShowDialog();


            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
