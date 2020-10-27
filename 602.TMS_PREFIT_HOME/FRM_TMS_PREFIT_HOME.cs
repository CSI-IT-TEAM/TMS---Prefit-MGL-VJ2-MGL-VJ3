using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Globalization;

namespace FORM
{
    public partial class FRM_TMS_PREFIT_HOME : Form
    {
        public FRM_TMS_PREFIT_HOME()
        {
            InitializeComponent();
        }

        #region Variable
        int iCount = 0;
        int PlanQty = 0, InvQty = 0;
        string LineCD_TEMP;
        string LINE = "ALL";
        DataTable dtUCTemp = new DataTable();
        UC.UC_WS_INFO[] UC = null ;
        #endregion

        #region ora
        public DataSet GetPlant(string ARG_TYPE, string ARG_FACTORY, string ARG_PROC_CD, string ARG_IS_BOTTOM)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_PREFIT.TMS_HOME_PREFIT_SELECT";
                MyOraDB.ReDim_Parameter(7);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_FACTORY";
                MyOraDB.Parameter_Name[2] = "ARG_PROC_CD";
                MyOraDB.Parameter_Name[3] = "ARG_IS_BOTTOM";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR1";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR2";
                MyOraDB.Parameter_Name[6] = "OUT_CURSOR3";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[5] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[6] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_TYPE;
                MyOraDB.Parameter_Values[1] = ARG_FACTORY;
                MyOraDB.Parameter_Values[2] = ARG_PROC_CD;
                MyOraDB.Parameter_Values[3] = ARG_IS_BOTTOM;
                MyOraDB.Parameter_Values[4] = "";
                MyOraDB.Parameter_Values[5] = "";
                MyOraDB.Parameter_Values[6] = "";

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
        #endregion

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
                iCount++;
                if (iCount >= 30)
                {
                    splashScreenManager1.ShowWaitForm();
                    BindingData();
                    iCount = 0;
                    splashScreenManager1.CloseWaitForm();
                }
            }
            catch
            {
                iCount = 0; splashScreenManager1.CloseWaitForm();
            }
        }

        private void FRM_TMS_BT_Load(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("Prepairing...");
                LoadLayoutWS();
                splashScreenManager1.CloseWaitForm();
            }
            catch (Exception)
            {
                iCount = 0; splashScreenManager1.CloseWaitForm();
            }
        }        

        private void BindingOutScnByDay(DataTable dt)
        {
            try
            {
                lblO_SCN_OVER.Text = "";
                lblO_SCN_D2.Text = "";
                lblO_SCN_D1.Text = "";
                lblO_SCN_DD.Text = "";
                lblTotalDelivery_ByDay.Text = "";
                chartControl5.DataSource = null;
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblO_SCN_OVER.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[0]["O_QTY"])) + " Prs";
                    lblO_SCN_D2.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[1]["O_QTY"])) + " Prs";
                    lblO_SCN_D1.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[2]["O_QTY"])) + " Prs";
                    lblO_SCN_DD.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[3]["O_QTY"])) + " Prs";
                    lblTotalDelivery_ByDay.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[4]["O_QTY"])) + " Prs";

                    //CHART
                    chartControl5.DataSource = dt;
                    chartControl5.Series[0].ArgumentDataMember = "DAYDAY";
                    chartControl5.Series[0].ValueDataMembers.AddRange(new string[] { "O_QTY" });
                }
                else
                {

                }
            }
            catch (Exception ex)
            { }
        }

        private void BindingOutScanByTrip(DataTable dt)
        {
            try
            {
                lbl_O_TRIP1.Text = "0 Prs";
                lbl_O_TRIP2.Text = "0 Prs";
                lbl_O_TRIP3.Text = "0 Prs";
                lbl_O_TRIP4.Text = "0 Prs";
                lbl_O_TRIP5.Text = "0 Prs";
                lbl_O_TRIP6.Text = "0 Prs";
                lbl_O_TRIP7.Text = "0 Prs";
                lbl_O_TRIP8.Text = "0 Prs";
                lblTotalTodayDeli.Text = "0 Prs";
                lblRatioDelivery.Text = "0%";
                if (dt != null && dt.Rows.Count > 0)
                {
                    lbl_O_TRIP1.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[0]["O_QTY"])) + " Prs";
                    lbl_O_TRIP2.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[1]["O_QTY"])) + " Prs";
                    lbl_O_TRIP3.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[2]["O_QTY"])) + " Prs";
                    lbl_O_TRIP4.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[3]["O_QTY"])) + " Prs";
                    lbl_O_TRIP5.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[4]["O_QTY"])) + " Prs";
                    lbl_O_TRIP6.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[5]["O_QTY"])) + " Prs";
                    lbl_O_TRIP7.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[6]["O_QTY"])) + " Prs";
                    lbl_O_TRIP8.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[7]["O_QTY"])) + " Prs";
                    lblTotalTodayDeli.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[8]["O_QTY"])) + " Prs";
                    double RateDelivery = Math.Round(Convert.ToDouble(lblTotalTodayDeli.Text.Replace("Prs", "").Replace(",", "").Trim()) / Convert.ToDouble(lblPlanTot.Text.Replace("Prs", "").Replace(",", "").Replace("Plan: ", "").Trim()) * 100, 1);
                    lblRatioDelivery.Text = RateDelivery.ToString() + "%";
                }
            }
            catch { }
        }

        private void BindingDataUC(DataTable dt)
        {
            try
            {
                lblPlanTot.Text = "";
                lblInvTot.Text = "";
                lblLeadTimeTot.Text = "";
                PlanQty = 0;
                InvQty = 0;
                if (dt != null && dt.Rows.Count > 0)
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        UC[i].BindingData(dt.Rows[i]["LINE_CD"].ToString(), dt.Rows[i]["LINE_NAME"].ToString(), dt.Rows[i]["PLAN_QTY"].ToString(), dt.Rows[i]["WIP_QTY"].ToString(), dt.Rows[i]["RATE"].ToString(), double.Parse(dt.Rows[i]["LT"].ToString()), dt.Rows[i]["SHOW_YN"].ToString());
                        //if (dt.Rows[i]["SHOW_YN"].ToString().Equals("N"))
                        //    UC[i].Enabled = false;
                        //else
                        //    UC[i].Enabled = true;
                        PlanQty += string.IsNullOrEmpty(dt.Rows[i]["PLAN_QTY"].ToString()) ? 0 : Convert.ToInt32(dt.Rows[i]["PLAN_QTY"]);
                        InvQty += string.IsNullOrEmpty(dt.Rows[i]["WIP_QTY"].ToString()) ? 0 : Convert.ToInt32(dt.Rows[i]["WIP_QTY"]);
                    }
                else
                {
                    for (int i = 0; i < UC.Length; i++)
                    {
                        UC[i].BindingData("", "", "", "", "", 0,"Y");
                    }
                }
                lblPlanTot.Text = "Plan: " + string.Format("{0:n0}", PlanQty) + " Prs";
                lblInvTot.Text = "Inv: " + string.Format("{0:n0}", InvQty) + " Prs";
                double LeadTime = Math.Round(Convert.ToDouble(InvQty) / Convert.ToDouble(PlanQty), 1);
                lblLeadTimeTot.Text = LeadTime.ToString() + " Day(s)";
            }
            catch
            {

            }
        }

        private void LoadLayoutWS()
        {
            try
            {
                tblMain.Visible = false;
                int iTable = 1;
                int iDx = 0;
                UC = new UC.UC_WS_INFO[24];
                //Khởi tạo 
                for (int k = 0; k < tblMain.RowCount; k++)
                {
                    for (int i = 0; i < tblMain.ColumnCount; i++)
                    {
                        if (k == tblMain.RowCount - 1 && i == tblMain.ColumnCount - 1) UC[iDx] = null;
                        else
                        {
                            UC.UC_WS_INFO Card = new UC.UC_WS_INFO();
                            //Card.OnButtonClick += OnbuttonUCClick;
                            //Card.OnLabelPlantClick += OnLabelPlantClick;
                            tblMain.Controls.Add(Card, i, k);
                            UC[iDx] = Card;
                            iDx++;
                        }
                    }
                }
                tblMain.Visible = true;
            }
            catch (Exception ex)
            { }
        }

        int layOutCount = 1;
        private void BindingData()
        {
            try
            {
                DataSet ds = GetPlant("Q1", ComVar.Var._strValue1, ComVar.Var._strValue2, ComVar.Var._bValue1 == true ? "1" : "0");
                if (ds != null)
                {
                    //TRACKING
                    DataTable dt = ds.Tables[0];
                    BindingOutScnByDay(dt);                    

                    //LEADTIME
                    dt = ds.Tables[2];
                    BindingDataUC(dt);
                    //BY TRIP
                    dt = ds.Tables[1];
                    BindingOutScanByTrip(dt);
                }
                else
                {
                    //TRACKING
                    BindingOutScnByDay(null);

                    //BY TRIP
                    BindingOutScanByTrip(null);

                    //LEADTIME
                    BindingDataUC(null);
                }
            }
            catch
            { }
        }

        void OnLabelPlantClick(Label label, string LINE_CD, string LINE_NM, int PLANT_QTY)
        {
            try
            {
                int iTable = 1;
                if (!LINE_CD.Equals(LineCD_TEMP))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (iTable <= layOutCount)
                            {
                                UC.UC_WS_INFO UC_WS = (UC.UC_WS_INFO)tblMain.GetControlFromPosition(j, i);
                                UC_WS.ChangeColor(true);
                            }
                            iTable++;
                        }
                    }
                    LineCD_TEMP = LINE_CD;
                }

                lbl_O_TRIP1.Text = "0 Prs";
                lbl_O_TRIP2.Text = "0 Prs";
                lbl_O_TRIP3.Text = "0 Prs";
                lbl_O_TRIP4.Text = "0 Prs";
                lblTotalTodayDeli.Text = "0 Prs";
                if (label.BackColor == Color.Yellow)
                {

                    label.BackColor = Color.FromArgb(0, 102, 204);
                    label.ForeColor = Color.White;
                    lblDeliveryWS.Text = string.Concat(ComVar.Var._strValue5, " Delivery");

                    //Data Trip
                    DataTable dt = null; //GetOutScnByTrip(DateTime.Now.ToString("yyyyMMdd"), ComVar.Var._strValue3, ComVar.Var._strValue4, "ALL");
                    lbl_O_TRIP1.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[0]["O_QTY"])) + " Prs";
                    lbl_O_TRIP2.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[1]["O_QTY"])) + " Prs";
                    lbl_O_TRIP3.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[2]["O_QTY"])) + " Prs";
                    lbl_O_TRIP4.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[3]["O_QTY"])) + " Prs";
                    lblTotalTodayDeli.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[4]["O_QTY"])) + " Prs";
                    double RateDelivery = Math.Round(Convert.ToDouble(lblTotalTodayDeli.Text.Replace("Prs", "").Replace(",", "").Trim()) / Convert.ToDouble(lblPlanTot.Text.Replace("Prs", "").Replace(",", "").Replace("Plan: ", "").Trim()) * 100, 1);

                    lblRatioDelivery.Text = RateDelivery.ToString() + "%";
                    //LINE = "ALL";
                }
                else
                {
                    label.BackColor = Color.Yellow;
                    label.ForeColor = Color.Black;
                    lblDeliveryWS.Text = string.Concat(LINE_NM, " Delivery");
                    //Data Trip
                    DataTable dt = null;//GetOutScnByTrip("20190918", ComVar.Var._strValue3, ComVar.Var._strValue4, LINE_CD);
                    lbl_O_TRIP1.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[0]["O_QTY"])) + " Prs";
                    lbl_O_TRIP2.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[1]["O_QTY"])) + " Prs";
                    lbl_O_TRIP3.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[2]["O_QTY"])) + " Prs";
                    lbl_O_TRIP4.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[3]["O_QTY"])) + " Prs";
                    lblTotalTodayDeli.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[4]["O_QTY"])) + " Prs";

                    // double RateDelivery = Math.Round(Convert.ToDouble(lblTotalTodayDeli.Text.Replace("Prs", "").Replace(",", "").Trim()) / Convert.ToDouble(lblPlanTot.Text.Replace("Prs", "").Replace(",", "").Replace("Plan: ", "").Trim()) * 100, 1);
                    double RateDelivery = Math.Round(Convert.ToDouble(lblTotalTodayDeli.Text.Replace("Prs", "").Replace(",", "").Trim()) / Convert.ToDouble(PLANT_QTY) * 100, 1);
                    lblRatioDelivery.Text = RateDelivery.ToString() + "%";
                    //LINE = LINE_CD;
                }

            }
            catch (Exception ex)
            { }
        }

        void OnbuttonUCClick(DevExpress.XtraEditors.SimpleButton button, string button_tag, string LINE_CD, string LINE_NM, double Set_rate)
        {
            ComVar.Var._dValue1 = Set_rate;
            ComVar.Var._strValue1 = LINE_CD;
            ComVar.Var._strValue2 = LINE_NM;
            ComVar.Var.callForm = button_tag;
            ComVar.Var._bValue1 = false;
        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelControl1_DoubleClick(object sender, EventArgs e)
        {
            //iCount = 30;
            ComVar.Var.callForm = "minimized";
        }

        private void FRM_TMS_BT_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                lblDeliveryWS.Text = string.Concat(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ComVar.Var._strValue3.ToLower()), " Delivery");
                lblTitle.Text = "Transportation Management System"; //string.Concat(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ComVar.Var._strValue3.ToLower()), " Leadtime/Inventory MNGT");
                iCount = 30;
                tmrDate.Start();
            }
            else
                tmrDate.Stop();
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "600";
        }
    }
}
