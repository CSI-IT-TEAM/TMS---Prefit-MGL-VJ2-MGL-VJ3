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
    public partial class FRM_TMS_HOME : Form
    {
        public FRM_TMS_HOME()
        {
            InitializeComponent();
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
            initUserControl();
            txt = label1.Text;
            len = txt.Length;
            label1.Text = "";
            tmrTitle.Start();
        }



        // The Label controls we will animate and their properties.
        int counter = 0;
        int len = 0;
        string txt;

        int cCount = 0;
        #region Ora
        public DataTable getTMSHomeRATIO(string ARG_LINE, string ARG_MLINE, string ARG_YMD, string ARG_TRIP, string ARG_LOC)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_HOME.TMS_HOME_RATIO";
                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_LINE";
                MyOraDB.Parameter_Name[1] = "ARG_MLINE";
                MyOraDB.Parameter_Name[2] = "ARG_YMD";
                MyOraDB.Parameter_Name[3] = "ARG_TRIP";
                MyOraDB.Parameter_Name[4] = "ARG_LOCATION";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_LINE;
                MyOraDB.Parameter_Values[1] = ARG_MLINE;
                MyOraDB.Parameter_Values[2] = ARG_YMD;
                MyOraDB.Parameter_Values[3] = ARG_TRIP;
                MyOraDB.Parameter_Values[4] = ARG_LOC;
                MyOraDB.Parameter_Values[5] = "";

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


        #endregion

        private void initUserControl()
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                string[] tit = new string[] { "F1", "PLANT N", "VJ3", "BOTTOM", "OUTSOLE", "IP", "PHYLON", "PU", "DMP" };
                //string[] tit = new string[] { "F1", "PLANT N", "UPPER", "BOTTOM", "OUTSOLE", "IP", "PHYLON", "PU", "DMP" };
                //string[] code = new string[] { "F1", "99", "UP", "BT", "OS", "IP", "PH", "PU", "DMP" };
                string[] code = new string[] { "F1", "99", "VJ3", "BT", "OS", "IP", "PH", "PU", "DMP" };
                string[] desc = new string[] { "VJ2->F1", "VJ2->Plant N", "VJ3->VJ1", "VJ1->VJ2", "Outsole->VJ1,VJ2", "IP->VJ1,VJ2", "Phylon->VJ1,VJ2", "PU->VJ1,VJ2", "DMP->VJ1,VJ2" };
                //  DataTable dt = getTMSHomeRATIO("", "", DateTime.Now.ToString("yyyyMMdd"), "", "SYHONG");
                for (int i = 0; i < tblCard.ColumnCount; i++)
                {
                    UC.UC_TMS_CARD_V2 TMS_CARD = new UC.UC_TMS_CARD_V2();
                    tblCard.Controls.Add(TMS_CARD, i, 0);
                    TMS_CARD.InitLabel(tit[i], code[i], desc[i]);
                    // TMS_CARD.BindingRatio(dt);
                    TMS_CARD.Dock = DockStyle.Fill;
                    //-----Reg Event here!
                }
                splashScreenManager1.CloseWaitForm();
            }
            catch { splashScreenManager1.CloseWaitForm(); }
        }

        private void tmrLoad_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
            if (cCount >= 300)
            {
                try
                {
                    splashScreenManager1.ShowWaitForm();
                    //loadding
                    DataTable dt = getTMSHomeRATIO("", "", DateTime.Now.ToString("yyyyMMdd"), "", "SYHONG");

                    for (int j = 0; j < 9; j++)
                    {
                        UC.UC_TMS_CARD_V2 TMS_CARD = (UC.UC_TMS_CARD_V2)tblCard.GetControlFromPosition(j, 0);
                        TMS_CARD.BindingRatio(dt);
                    }
                    cCount = 0;
                    splashScreenManager1.CloseWaitForm();
                }
                catch { splashScreenManager1.CloseWaitForm(); }
            }
            else if (cCount % 10 ==0)
            {
                tmrTitle.Start();
            }
        }
        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void label1_DoubleClick(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "minimized";
        }
        private void btnMaps_Click(object sender, EventArgs e)
        {
            //=======================================
            //1. VJ2 -> VJ1
            //2. VJ1 -> VJ2
            //3. VJ3 -> VJ1
            //4. VJ3 -> VJ2
            //=======================================
            try
            {
                this.Cursor = Cursors.WaitCursor;
                MapsF m = new MapsF();
                FRM_VJ_MAPS vj_m = new FRM_VJ_MAPS();

                switch (((Button)sender).Tag.ToString())
                {
                    case "1":
                        m.LoadMaps("1");
                        m.GetDepartTime("1");
                        m.ShowDialog();
                        break;
                    case "2":
                        m.LoadMaps("2");
                        m.GetDepartTime("2");
                        m.ShowDialog();
                        break;
                    case "3_1":
                        FRM_VJ3_VJ1_MAPS vj3_1m = new FRM_VJ3_VJ1_MAPS();
                        vj3_1m.ShowDialog();
                        break;
                    case "3_2":
                        FRM_VJ3_VJ2_MAPS vj3_2m = new FRM_VJ3_VJ2_MAPS();
                        vj3_2m.ShowDialog();
                        break;
                    case "4":
                        vj_m.ShowDialog();
                        break;
                }
                this.Cursor = Cursors.Default;
            }
            catch { this.Cursor = Cursors.Default; }

        }
        private int xPos1 = 165, YPos1 = 5, xPos2 = 398, YPos2 = 5, xPos3 = 682, YPos3 = 4;
        bool isLeft1 = false, isLeft2 = false, isLeft3 = false;
        private void FRM_TMS_HOME_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
               


                // Move left 40 pixels in 2 seconds.
                cCount = 300;
                tmrLoad.Start();
                lblVinhCuu.Text = "Vĩnh Cửu";
                xPos1 = lblVinhCuu.Location.X;
                YPos1 = lblVinhCuu.Location.Y;
                xPos2 = lblLongThanh.Location.X;
                YPos2 = lblLongThanh.Location.Y;
                xPos3 = lblTanPhu.Location.X;
                YPos3 = lblTanPhu.Location.Y;
                // timer1.Start();
            }
            else
                tmrLoad.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (!bgWorker.IsBusy)
            //     bgWorker.RunWorkerAsync();
            //label 1 vinh cuu
            if (!isLeft1)
            {
                if (xPos1 <= 11) { xPos1 = 11; isLeft1 = true; }
                this.lblVinhCuu.Location = new System.Drawing.Point(xPos1, YPos1);
                xPos1 -= 1;

            }
            else
            {
                if (xPos1 >= 165) { xPos1 = 165; isLeft1 = false; }
                this.lblVinhCuu.Location = new System.Drawing.Point(xPos1, YPos1);
                xPos1 += 1;

            }
            //label 2 Long Thanh
            if (!isLeft2)
            {
                if (xPos2 <= 263) { xPos2 = 263; isLeft2 = true; }
                this.lblLongThanh.Location = new System.Drawing.Point(xPos2, YPos2);
                xPos2 -= 1;

            }
            else
            {
                if (xPos2 >= 398) { xPos2 = 398; isLeft2 = false; }
                this.lblLongThanh.Location = new System.Drawing.Point(xPos2, YPos2);
                xPos2 += 1;

            }

            //label 3 Tân Phú
            if (!isLeft3)
            {
                if (xPos3 <= 515) { xPos3 = 515; isLeft3 = true; }
                this.lblTanPhu.Location = new System.Drawing.Point(xPos3, YPos3);
                xPos3 -= 1;

            }
            else
            {
                if (xPos3 >= 682) { xPos3 = 682; isLeft3 = false; }
                this.lblTanPhu.Location = new System.Drawing.Point(xPos3, YPos3);
                xPos3 += 1;
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //ComVar.Var.callForm = "345";
            //  FRM_TMS_BALANCE_ORDER F = new FRM_TMS_BALANCE_ORDER();
            FRM_MILKRUN_ORDER F = new FRM_MILKRUN_ORDER("201");
            this.Cursor = Cursors.Default;
            F.ShowDialog();

        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            switch (((PictureBox)sender).Tag.ToString())
            {
                case "VINHCUU":
                    lblVinhCuu.BackColor = Color.Orange;
                    lblVinhCuu.ForeColor = Color.Black;
                    break;
                case "LONGTHANH":
                    //============================================
                    lblLongThanh.BackColor = Color.Orange;
                    lblLongThanh.ForeColor = Color.Black;
                    break;
                case "TANPHU":
                    lblTanPhu.BackColor = Color.Orange;
                    lblTanPhu.ForeColor = Color.Black;
                    break;
                default:
                    break;
            }

        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            switch (((PictureBox)sender).Tag.ToString())
            {
                case "VINHCUU":
                    lblVinhCuu.BackColor = Color.FromArgb(24, 33, 60);
                    lblVinhCuu.ForeColor = Color.White;
                    break;
                case "LONGTHANH":
                    //============================================
                    lblLongThanh.BackColor = Color.FromArgb(24, 33, 60);
                    lblLongThanh.ForeColor = Color.White;
                    break;
                case "TANPHU":
                    lblTanPhu.BackColor = Color.FromArgb(24, 33, 60);
                    lblTanPhu.ForeColor = Color.White;
                    break;
                //default:
                //    break;
            }

        }

        private void lblLongThanh_Click(object sender, EventArgs e)
        {

        }

        private void btnVJ2_VJ1_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Properties.Resources.carcsi;
        }

        private void btnVJ2_VJ1_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Properties.Resources.car;
        }

        private void btnSQM_Click(object sender, EventArgs e)
        {
            FRM_SQM_TRACKING F = new FRM_SQM_TRACKING();
            F.ShowDialog();
        }

        private void tmrTitle_Tick(object sender, EventArgs e)
        {
            counter++;

            if(counter > len)
            {

                counter = 0;
                tmrTitle.Stop();
                //label1.Text = "";
            }
            else {
                label1.Text = txt.Substring(0, counter);
                if (label1.ForeColor == Color.Black)
                    label1.ForeColor = Color.Blue;
                else
                    label1.ForeColor = Color.Black;
            }
            
        }

        private void btnTrackRPT_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FRM_ORDERVSOUTGOING_TRACKING f = new FRM_ORDERVSOUTGOING_TRACKING();
            this.Cursor = Cursors.Default;
            f.ShowDialog();
        }
    }
}
