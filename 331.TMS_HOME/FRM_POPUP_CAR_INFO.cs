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
    public partial class FRM_POPUP_CAR_INFO : Form
    {
        public FRM_POPUP_CAR_INFO()
        {
            InitializeComponent();
        }
        public void BindingData(string Code, string LINE_CD, DataTable dt,DataTable dtQuality)
        {
            try
            {
                //=======================================
                //1. VJ2 -> VJ1
                //2. VJ1 -> VJ2
                //3. VJ3 -> VJ1
                //4. VJ3 -> VJ2
                //=======================================
                switch (Code)
                {
                    case "1": //VJ2 -> VJ1 (
                        lblDepart.Text = "LONG THANH";
                        lblArr.Text = "VINH CUU";
                        Lb_TL_trip4.Visible = true;
                        Lb_TL_trip5.Visible = true;
                        Lb_VC_trip4.Visible = true;
                        Lb_VC_trip5.Visible = true;
                        lblTrip4.Visible = true;
                        lblTrip5.Visible = true;
                        Lb_TL_trip1.Text = string.Concat(dt.Rows[0]["DP1"].ToString().Replace("H", ":").Replace("~", " - ")," (",dtQuality.Rows[0][0].ToString()," Prs)");
                        Lb_TL_trip2.Text = string.Concat(dt.Rows[0]["DP2"].ToString().Replace("H", ":").Replace("~", " - "), " (", dtQuality.Rows[1][0].ToString(), " Prs)");
                        Lb_TL_trip3.Text = string.Concat(dt.Rows[0]["DP3"].ToString().Replace("H", ":").Replace("~", " - "), " (", dtQuality.Rows[2][0].ToString(), " Prs)");
                        Lb_TL_trip4.Text = string.Concat(dt.Rows[0]["DP4"].ToString().Replace("H", ":").Replace("~", " - "), " (", dtQuality.Rows[3][0].ToString(), " Prs)");
                        Lb_TL_trip5.Text = string.Concat(dt.Rows[0]["DP5"].ToString().Replace("H", ":").Replace("~", " - "), " (", dtQuality.Rows[4][0].ToString(), " Prs)");
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
                        break;
                    case "2":
                        lblDepart.Text = "VINH CUU";
                        lblArr.Text = "LONG THANH";
                        Lb_TL_trip4.Visible = false;
                        Lb_TL_trip5.Visible = false;
                        Lb_VC_trip4.Visible = false;
                        Lb_VC_trip5.Visible = false;
                        lblTrip4.Visible = false;
                        lblTrip5.Visible = false;
                        Lb_TL_trip1.Text =  string.Concat(dt.Rows[0]["VC_DP_1"].ToString().Replace("H", ":").Replace("~", " - ")," (",dtQuality.Rows[0][0].ToString()," Prs)");;
                        Lb_TL_trip2.Text =  string.Concat(dt.Rows[0]["VC_DP_2"].ToString().Replace("H", ":").Replace("~", " - ")," (",dtQuality.Rows[1][0].ToString()," Prs)");;
                        Lb_TL_trip3.Text =  string.Concat(dt.Rows[0]["VC_DP_3"].ToString().Replace("H", ":").Replace("~", " - ")," (",dtQuality.Rows[2][0].ToString()," Prs)");;

                        Lb_VC_trip1.Text =dt.Rows[0]["LT_AR_1"].ToString().Replace("H", ":").Replace("~", " - ");
                        Lb_VC_trip2.Text =  dt.Rows[0]["LT_AR_2"].ToString().Replace("H", ":").Replace("~", " - ");
                        Lb_VC_trip3.Text =  dt.Rows[0]["LT_AR_3"].ToString().Replace("H", ":").Replace("~", " - ");
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex) { }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
