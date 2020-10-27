using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM
{
    public partial class FRM_TMS_BT : Form
    {
        public FRM_TMS_BT()
        {
            InitializeComponent();
        }

        #region Variable
        int iCount = 0;
        int PlanQty = 0, InvQty = 0;
        string LineCD_TEMP;
        string LINE = "ALL";
        DataTable dtUCTemp = new DataTable();
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
                    BindingDataUC();
                    BindingOutScnByDay(LINE);
                    BindingDeliveryChart();
                    BindingOutScanByTrip();
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
                /*
                BindingDataUC();
                BindingOutScnByDay(LINE);
                BindingDeliveryChart();
                BindingOutScanByTrip();
                 */
                splashScreenManager1.CloseWaitForm();
            }
            catch (Exception)
            {
                iCount = 0; splashScreenManager1.CloseWaitForm();
            }
        }

        private void BindingDeliveryChart()
        {
            chartControl5.DataSource = dtChartTemp;// GetTable();
            chartControl5.Series[0].ArgumentDataMember = "DAYDAY";
            chartControl5.Series[0].ValueDataMembers.AddRange(new string[] { "O_QTY" });
        }
        DataTable dtChartTemp = null;
        private DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Value1", typeof(int));
            table.Columns.Add("Value2", typeof(int));
            table.Columns.Add("Value3", typeof(int));
            table.Columns.Add("Value4", typeof(int));
            table.Columns.Add("Name", typeof(string));
            Random r = new Random();
            // Here we add DataRows.
            for (int i = 0; i < 5; i++)
            {
                table.Rows.Add(r.Next(10, 100), r.Next(10, 100), r.Next(10, 100), r.Next(10, 100), "D " + (i + 1).ToString());
            }
            return table;
        }

        private void BindingOutScnByDay(string LINE_CD)
        {
            try
            {
                DatabaseTMS db = new DatabaseTMS();
                DataTable dt = dtChartTemp = db.GetOutScnByDay("VJ", ComVar.Var._strValue3, ComVar.Var._strValue4, DateTime.Now.ToString("yyyyMMdd"), LINE_CD);
                lblO_SCN_OVER.Text = "";
                lblO_SCN_D2.Text = "";
                lblO_SCN_D1.Text = "";
                lblO_SCN_DD.Text = "";
                lblTotalDelivery_ByDay.Text = "";
                lblO_SCN_OVER.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[0]["O_QTY"])) + " Prs";
                lblO_SCN_D2.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[1]["O_QTY"])) + " Prs";
                lblO_SCN_D1.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[2]["O_QTY"])) + " Prs";
                lblO_SCN_DD.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[3]["O_QTY"])) + " Prs";
                lblTotalDelivery_ByDay.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[4]["O_QTY"])) + " Prs";
            }
            catch (Exception ex)
            { }
        }

        private void BindingOutScanByTrip()
        {
            try
            {
                lbl_O_TRIP1.Text = "0 Prs";
                lbl_O_TRIP2.Text = "0 Prs";
                lbl_O_TRIP3.Text = "0 Prs";
                lbl_O_TRIP4.Text = "0 Prs";
                lblTotalTodayDeli.Text = "0 Prs";
                DatabaseTMS db = new DatabaseTMS();
                DataTable dt = db.GetOutScnByTrip(DateTime.Now.ToString("yyyyMMdd"), ComVar.Var._strValue3, ComVar.Var._strValue4, "ALL");
                lbl_O_TRIP1.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[0]["O_QTY"])) + " Prs";
                lbl_O_TRIP2.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[1]["O_QTY"])) + " Prs";
                lbl_O_TRIP3.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[2]["O_QTY"])) + " Prs";
                lbl_O_TRIP4.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[3]["O_QTY"])) + " Prs";
                lblTotalTodayDeli.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[4]["O_QTY"])) + " Prs";
                double RateDelivery = Math.Round(Convert.ToDouble(lblTotalTodayDeli.Text.Replace("Prs", "").Replace(",", "").Trim()) / Convert.ToDouble(lblPlanTot.Text.Replace("Prs", "").Replace(",", "").Replace("Plan: ", "").Trim()) * 100, 1);
                lblRatioDelivery.Text = RateDelivery.ToString() + "%";
            }
            catch { }
        }

        private void LoadLayoutWS()
        {
            try
            {
                tblMain.Visible = false;
                int iTable = 1;
                DatabaseTMS db = new DatabaseTMS();
                DataTable dt = db.GetPlant("VJ", ComVar.Var._strValue3, ComVar.Var._strValue4, DateTime.Now.ToString("yyyyMMdd")); //GetPlant khi load lên xem cần khởi tạo bao nhiêu User Controls.
                for (int i = 0; i < 3; i++)               //loop dòng
                {
                    for (int j = 0; j < 8; j++)           //loop cột
                    {
                        if (iTable <= dt.Rows.Count)                //21 cell được load layout
                        {
                            UC.UC_WS_INFO UC_WS = new UC.UC_WS_INFO();
                            UC_WS.OnButtonClick += OnbuttonUCClick;
                            UC_WS.OnLabelPlantClick += OnLabelPlantClick;
                            tblMain.Controls.Add(UC_WS, j, i);
                        }
                        iTable++;
                    }
                }
                tblMain.Visible = true;
            }
            catch (Exception ex)
            {

            }
        }

        int layOutCount = 1;
        private void BindingDataUC()
        {
            int iTable = 1;
            lblPlanTot.Text = "";
            lblInvTot.Text = "";
            lblLeadTimeTot.Text = "";
            PlanQty = 0;
            InvQty = 0;
            DatabaseTMS db = new DatabaseTMS();
            DataTable dt = dtUCTemp = db.GetPlant("VJ", ComVar.Var._strValue3, ComVar.Var._strValue4, DateTime.Now.ToString("yyyyMMdd"));
            layOutCount = dt.Rows.Count;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (iTable <= dt.Rows.Count)                //21 cell được load layout
                    {
                        UC.UC_WS_INFO UC_WS = (UC.UC_WS_INFO)tblMain.GetControlFromPosition(j, i);
                        if (!string.IsNullOrEmpty(dt.Rows[iTable - 1]["LT"].ToString()))
                            UC_WS.BindingData(dt.Rows[iTable - 1]["LINE_CD"].ToString(), dt.Rows[iTable - 1]["LINE_NAME"].ToString(), dt.Rows[iTable - 1]["PLAN_QTY"].ToString(), dt.Rows[iTable - 1]["WIP_QTY"].ToString(), dt.Rows[iTable - 1]["RATE"].ToString(), Convert.ToDouble(dt.Rows[iTable - 1]["LT"]), Convert.ToDouble(dt.Rows[iTable - 1]["SET_RATIO"]));
                        else
                            UC_WS.BindingData(dt.Rows[iTable - 1]["LINE_CD"].ToString(), dt.Rows[iTable - 1]["LINE_NAME"].ToString(), dt.Rows[iTable - 1]["PLAN_QTY"].ToString(), dt.Rows[iTable - 1]["WIP_QTY"].ToString(), dt.Rows[iTable - 1]["RATE"].ToString(), 0, 0);

                        PlanQty += string.IsNullOrEmpty(dt.Rows[iTable - 1]["PLAN_QTY"].ToString()) ? 0 : Convert.ToInt32(dt.Rows[iTable - 1]["PLAN_QTY"]);
                        InvQty += string.IsNullOrEmpty(dt.Rows[iTable - 1]["WIP_QTY"].ToString()) ? 0 : Convert.ToInt32(dt.Rows[iTable - 1]["WIP_QTY"]);
                    }
                    iTable++;
                }
            }
            lblPlanTot.Text = "Plan: " + string.Format("{0:n0}", PlanQty) + " Prs";
            lblInvTot.Text = "Inv: " + string.Format("{0:n0}", InvQty) + " Prs";
            double LeadTime = Math.Round(Convert.ToDouble(InvQty) / Convert.ToDouble(PlanQty), 1);
            lblLeadTimeTot.Text = LeadTime.ToString() + " Day(s)";
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
                DatabaseTMS db = new DatabaseTMS();


                if (label.BackColor == Color.Yellow)
                {

                    label.BackColor = Color.FromArgb(0, 102, 204);
                    label.ForeColor = Color.White;
                    lblDeliveryWS.Text = string.Concat(ComVar.Var._strValue5, " Delivery");

                    //Data Trip
                    DataTable dt = db.GetOutScnByTrip(DateTime.Now.ToString("yyyyMMdd"), ComVar.Var._strValue3, ComVar.Var._strValue4, "ALL");
                    lbl_O_TRIP1.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[0]["O_QTY"])) + " Prs";
                    lbl_O_TRIP2.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[1]["O_QTY"])) + " Prs";
                    lbl_O_TRIP3.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[2]["O_QTY"])) + " Prs";
                    lbl_O_TRIP4.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[3]["O_QTY"])) + " Prs";
                    lblTotalTodayDeli.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[4]["O_QTY"])) + " Prs";
                    double RateDelivery = Math.Round(Convert.ToDouble(lblTotalTodayDeli.Text.Replace("Prs", "").Replace(",", "").Trim()) / Convert.ToDouble(lblPlanTot.Text.Replace("Prs", "").Replace(",", "").Replace("Plan: ", "").Trim()) * 100, 1);

                    lblRatioDelivery.Text = RateDelivery.ToString() + "%";
                    LINE = "ALL";
                    BindingOutScnByDay(LINE);
                    BindingDeliveryChart();
                }
                else
                {
                    label.BackColor = Color.Yellow;
                    label.ForeColor = Color.Black;
                    lblDeliveryWS.Text = string.Concat(LINE_NM, " Delivery");
                    //Data Trip
                    DataTable dt = db.GetOutScnByTrip("20190918", ComVar.Var._strValue3, ComVar.Var._strValue4, LINE_CD);
                    lbl_O_TRIP1.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[0]["O_QTY"])) + " Prs";
                    lbl_O_TRIP2.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[1]["O_QTY"])) + " Prs";
                    lbl_O_TRIP3.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[2]["O_QTY"])) + " Prs";
                    lbl_O_TRIP4.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[3]["O_QTY"])) + " Prs";
                    lblTotalTodayDeli.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Rows[4]["O_QTY"])) + " Prs";

                    // double RateDelivery = Math.Round(Convert.ToDouble(lblTotalTodayDeli.Text.Replace("Prs", "").Replace(",", "").Trim()) / Convert.ToDouble(lblPlanTot.Text.Replace("Prs", "").Replace(",", "").Replace("Plan: ", "").Trim()) * 100, 1);
                    double RateDelivery = Math.Round(Convert.ToDouble(lblTotalTodayDeli.Text.Replace("Prs", "").Replace(",", "").Trim()) / Convert.ToDouble(PLANT_QTY) * 100, 1);
                    lblRatioDelivery.Text = RateDelivery.ToString() + "%";
                    LINE = LINE_CD;
                    BindingOutScnByDay(LINE);
                    BindingDeliveryChart();
                }

            }
            catch (Exception ex)
            { }
        }

        void OnbuttonUCClick(DevExpress.XtraEditors.SimpleButton button, string button_tag, string LINE_CD, string LINE_NM, double Set_rate)
        {
            //FRM_POPUP_SQM_TRACKING_BT POPUP = new FRM_POPUP_SQM_TRACKING_BT(button);
            //POPUP.ShowBeakForm();
            // FRM_DELI_STATUS DELI_STATUS = new FRM_DELI_STATUS();
            //  DELI_STATUS.ShowDialog();
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
                lblDeliveryWS.Text = string.Concat(ComVar.Var._strValue5, " Delivery");
                if (ComVar.Var._bValue2)
                    cmdBack.Visible = true;
                else
                    cmdBack.Visible = false;
                iCount = 30;
                tmrDate.Start();
            }
            else
                tmrDate.Stop();
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "342";
        }
    }
}
