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
    public partial class FRM_POPUP_CAR_INFO_2 : Form
    {
        public FRM_POPUP_CAR_INFO_2()
        {
            InitializeComponent();
        }
        public void BindingData(string Code, string LINE_CD, DataTable dt, DataTable dtQuality)
        {
            try
            {
                //=======================================
                //1. VJ2 -> VJ1
                //2. VJ1 -> VJ2
                //3. VJ3 -> VJ1
                //4. VJ3 -> VJ2
                //=======================================
                int S = 0;
                DataColumnCollection column = dt.Columns;

                switch (Code)
                {
                    case "1": //VJ2 -> VJ1 (
                        lblDepart.Text = "LONG THANH";
                        lblArr.Text = "VINH CUU";
                        pnTrip45.Visible = true;
                        Lb_TL_trip1.Text = dt.Rows[0]["DP1"].ToString().Replace("H", ":").Replace("~", " - ");
                        Lb_TL_qty1.Text = string.Concat(dtQuality.Rows[0][0], " Prs");
                        Lb_TL_trip2.Text = dt.Rows[0]["DP2"].ToString().Replace("H", ":").Replace("~", " - ");
                        Lb_TL_qty2.Text = string.Concat(dtQuality.Rows[1][0], " Prs");
                        Lb_TL_trip3.Text = dt.Rows[0]["DP3"].ToString().Replace("H", ":").Replace("~", " - ");
                        Lb_TL_qty3.Text = string.Concat(dtQuality.Rows[2][0], " Prs");
                        Lb_TL_trip4.Text = dt.Rows[0]["DP4"].ToString().Replace("H", ":").Replace("~", " - ");
                        Lb_TL_qty4.Text = string.Concat(dtQuality.Rows[3][0], " Prs");
                        Lb_TL_trip5.Text = dt.Rows[0]["DP5"].ToString().Replace("H", ":").Replace("~", " - ");
                        Lb_TL_qty5.Text = string.Concat(dtQuality.Rows[4][0], " Prs");
                        if (LINE_CD == "FTY01")
                        {
                            Lb_VC_trip1.Text = dt.Rows[0]["AR_F1"].ToString().Replace("H", ":").Replace("~", " - ");
                            Lb_VC_trip2.Text = dt.Rows[0]["AR_F2"].ToString().Replace("H", ":").Replace("~", " - ");
                            Lb_VC_trip3.Text = dt.Rows[0]["AR_F3"].ToString().Replace("H", ":").Replace("~", " - ");
                            Lb_VC_trip4.Text = dt.Rows[0]["AR_F4"].ToString().Replace("H", ":").Replace("~", " - ");
                            Lb_VC_trip5.Text = dt.Rows[0]["AR_F5"].ToString().Replace("H", ":").Replace("~", " - ");
                        }
                        else if (LINE_CD == "VJ1")
                        {
                            Lb_VC_trip1.Text = dt.Rows[0]["LT_AR1"].ToString().Replace("H", ":").Replace("~", " - ");
                            Lb_VC_trip2.Text = dt.Rows[0]["LT_AR2"].ToString().Replace("H", ":").Replace("~", " - ");
                            Lb_VC_trip3.Text = dt.Rows[0]["LT_AR3"].ToString().Replace("H", ":").Replace("~", " - ");
                            Lb_VC_trip4.Text = dt.Rows[0]["LT_AR4"].ToString().Replace("H", ":").Replace("~", " - ");
                            Lb_VC_trip5.Text = dt.Rows[0]["LT_AR5"].ToString().Replace("H", ":").Replace("~", " - ");
                        }
                        else
                        {
                            Lb_VC_trip1.Text = dt.Rows[0]["AR_N1"].ToString().Replace("H", ":").Replace("~", " - ");
                            Lb_VC_trip2.Text = dt.Rows[0]["AR_N2"].ToString().Replace("H", ":").Replace("~", " - ");
                            Lb_VC_trip3.Text = dt.Rows[0]["AR_N3"].ToString().Replace("H", ":").Replace("~", " - ");
                            Lb_VC_trip4.Text = dt.Rows[0]["AR_N4"].ToString().Replace("H", ":").Replace("~", " - ");
                            Lb_VC_trip5.Text = dt.Rows[0]["AR_N5"].ToString().Replace("H", ":").Replace("~", " - ");
                        }

                        SetColorTrip(lblTrip1, Lb_TL_trip1, Lb_VC_trip1);
                        SetColorTrip(lblTrip2, Lb_TL_trip2, Lb_VC_trip2);
                        SetColorTrip(lblTrip3, Lb_TL_trip3, Lb_VC_trip3);
                        SetColorTrip(lblTrip4, Lb_TL_trip4, Lb_VC_trip4);
                        SetColorTrip(lblTrip5, Lb_TL_trip5, Lb_VC_trip5);
                        break;
                    case "2":
                        lblDepart.Text = "VINH CUU";
                        lblArr.Text = "LONG THANH";
                        pnTrip45.Visible = false;
                        Lb_TL_trip1.Text = dt.Rows[0]["VC_DP_1"].ToString().Replace("H", ":").Replace("~", " - ");
                        Lb_TL_qty1.Text = string.Concat(dtQuality.Rows[0][0], " Prs");
                        Lb_TL_trip2.Text = dt.Rows[0]["VC_DP_2"].ToString().Replace("H", ":").Replace("~", " - ");
                        Lb_TL_qty2.Text = string.Concat(dtQuality.Rows[1][0], " Prs");
                        Lb_TL_trip3.Text = dt.Rows[0]["VC_DP_3"].ToString().Replace("H", ":").Replace("~", " - ");
                        Lb_TL_qty3.Text = string.Concat(dtQuality.Rows[2][0], " Prs");
                        Lb_TL_trip4.Text = dt.Rows[0]["VC_DP_4"].ToString().Replace("H", ":").Replace("~", " - ");
                        Lb_TL_qty4.Text = string.Concat(dtQuality.Rows[3][0], " Prs");
                        Lb_VC_trip1.Text = dt.Rows[0]["LT_AR_1"].ToString().Replace("H", ":").Replace("~", " - ");
                        Lb_VC_trip2.Text = dt.Rows[0]["LT_AR_2"].ToString().Replace("H", ":").Replace("~", " - ");
                        Lb_VC_trip3.Text = dt.Rows[0]["LT_AR_3"].ToString().Replace("H", ":").Replace("~", " - ");
                        Lb_VC_trip4.Text = dt.Rows[0]["LT_AR_4"].ToString().Replace("H", ":").Replace("~", " - ");

                        SetColorTrip(lblTrip1, Lb_TL_trip1, Lb_VC_trip1);
                        SetColorTrip(lblTrip2, Lb_TL_trip2, Lb_VC_trip2);
                        SetColorTrip(lblTrip3, Lb_TL_trip3, Lb_VC_trip3);
                        SetColorTrip(lblTrip4, Lb_TL_trip4, Lb_VC_trip4);
                        SetColorTrip(lblTrip5, Lb_TL_trip5, Lb_VC_trip5);
                        break;
                    case "3":
                        lblDepart.Text = "TAN PHU";
                        lblArr.Text = "VINH CUU";
                        pnTrip45.Visible = false;
                        pnTrip234.Visible = false;
                        Lb_TL_trip1.Text = dt.Rows[0]["S_TIME"].ToString().Replace("H", ":").Replace("~", " - ");
                        Lb_TL_qty1.Text = string.Concat(dtQuality.Rows[0][0], " Prs");
                        Lb_VC_trip1.Text = dt.Rows[0]["E_TIME"].ToString().Replace("H", ":").Replace("~", " - ");
                        SetColorTrip(lblTrip1, Lb_TL_trip1, Lb_VC_trip1);
                        break;
                    default:
                        break;
                }
                foreach (DataRow dr in dtQuality.Rows)
                {
                    if (!string.IsNullOrEmpty(dr["QTY"].ToString()))
                        S += Convert.ToInt32(dr["QTY"].ToString().Replace(",", ""));
                }
                lblTotal.Text = string.Concat("Total: ", string.Format("{0:n0}", S), " Prs");

            }
            catch (Exception ex)
            {
                lblTotal.Text = "0 Prs";
            }
        }

        private void SetColorTrip(Label lblTrip, Label lblDpt, Label lblArr)
        {
            Color color = new Color();
            switch (Status(lblDpt, lblArr))
            {
                case 0:
                    color = Color.Yellow;
                    break;
                case 1:
                    color = Color.WhiteSmoke;
                    break;
                case 2:
                    color = Color.Silver;
                    break;
            }
            lblTrip.BackColor = color;
            lblTrip.ForeColor = Color.Black;
        }

        private int Status(Label lblDpt, Label lblArr)
        {
            if (lblDpt.Text.Length < lblArr.Text.Length)
                return 0; //On going
            else if (lblDpt.Text.Length > 5 && lblArr.Text.Length >= 5)
                return 1; //not yet go
            else
                return 2; //Finished
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
