using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace FORM.UC
{
    public partial class UC_DSF : UserControl
    {
        public UC_DSF()
        {
            InitializeComponent();
        }
        DataTable dt_laser = null;
        DataTable dt_printing = null;
        DataTable dt_hf = null;
        int i_count = 0;

        public void BindingData(DataTable dt)
        {

            if (dt.Select("TYPE =   '" + btnTitle.Text.Replace("LASER CUTTING", "LASER") + "'", "").Count() > 0)
            {
                DataTable dt_printing = dt.Select("TYPE = '" + btnTitle.Text.Replace("LASER CUTTING","LASER") + "'", "").CopyToDataTable();
                if (dt_printing.Rows.Count > 0 && dt_printing != null)
                {
                    pBindingData(dt_printing);
                }
            }
            


        }
        public delegate void ButtonMenuhandler(string TitleCD);
        public ButtonMenuhandler OnTitleClick = null;
    
        private void pBindingData(DataTable _dt)
        {
            try
            {
                DataTable dt = _dt;
                label1.Text = "0 Prs";
                label2.Text = "0 Prs";
                label3.Text = "0 Prs";
                label4.Text = "0 %";
                if (dt.Rows.Count > 0 && dt != null)
                {
                    label1.Text = Convert.ToDouble(dt.Rows[0]["COMP_SPLAN"]).ToString("#,#0") + " Prs";
                    label2.Text = Convert.ToDouble(dt.Rows[0]["COMP_RPLAN"]).ToString("#,#0") + " Prs";
                    label3.Text = Convert.ToDouble(dt.Rows[0]["COMP_ACTUAL"]).ToString("#,#0") + " Prs";
                    label4.Text = Convert.ToDouble(dt.Rows[0]["COMP_RATE"]).ToString("#,0") + " %";
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void LoadImage(int iDx)
        {
            btnTitle.TabIndex = iDx;
            switch (iDx)
            {
                case 0:

                    //this.pbDSF.Image = global::FORM.Properties.Resources.prod2;
                    btnTitle.Text = "PRINTING";
                    //dt_printing = PRINTING_OS_PRODUCTION_DATA("Q");
                    if (dt_printing.Rows.Count > 0)
                    {
                        label1.Text = Convert.ToDouble(dt_printing.Rows[0]["COMP_SPLAN"]).ToString("#,#0") + " Prs";
                        label2.Text = Convert.ToDouble(dt_printing.Rows[0]["COMP_RPLAN"]).ToString("#,#0") + " Prs";
                        label3.Text = Convert.ToDouble(dt_printing.Rows[0]["COMP_ACTUAL"]).ToString("#,#0") + " Prs";
                        label4.Text = Convert.ToDouble(dt_printing.Rows[0]["COMP_RATE"]).ToString("#,0") + " %";

                    }

                    break;

                case 1:
                    //this.pbDSF.Image = global::FORM.Properties.Resources._1;
                    btnTitle.Text = "H/F";
                   // dt_hf = HF_OS_PRODUCTION_DATA("Q");
                    if (dt_hf.Rows.Count > 0)
                    {
                        label1.Text = Convert.ToDouble(dt_hf.Rows[0]["COMP_SPLAN"]).ToString("#,#0") + " Prs";
                        label2.Text = Convert.ToDouble(dt_hf.Rows[0]["COMP_RPLAN"]).ToString("#,#0") + " Prs";
                        label3.Text = Convert.ToDouble(dt_hf.Rows[0]["COMP_ACTUAL"]).ToString("#,#0") + " Prs";
                        label4.Text = Convert.ToDouble(dt_hf.Rows[0]["COMP_RATE"]).ToString("#,0") + " %";

                    }

                    break;
                case 2:
                    // this.pbDSF.Image = global::FORM.Properties.Resources._4;
                    btnTitle.Text = "LASER";
                  //  dt_laser = LASER_OS_PRODUCTION_DATA("Q");
                    if (dt_laser.Rows.Count > 0) 
                    {
                        label1.Text = Convert.ToDouble(dt_laser.Rows[0]["COMP_SPLAN"]).ToString("#,#0") + " Prs";
                        label2.Text = Convert.ToDouble(dt_laser.Rows[0]["COMP_RPLAN"]).ToString("#,#0") + " Prs";
                        label3.Text = Convert.ToDouble(dt_laser.Rows[0]["COMP_ACTUAL"]).ToString("#,#0") + " Prs";
                        label4.Text = Convert.ToDouble(dt_laser.Rows[0]["COMP_RATE"]).ToString("#,0") + " %";

                    }
                    break;
                case 3:
                    // this.pbDSF.Image = global::FORM.Properties.Resources._5;
                    btnTitle.Text = "CUT-NOSEW";

                    break;
                case 4:
                    // this.pbDSF.Image = global::FORM.Properties.Resources._6;
                    btnTitle.Text = "EMB";

                    break;
                case 5:
                    // this.pbDSF.Image = global::FORM.Properties.Resources._7;

                    break;
                default:
                    break;


            }

           // LoadImage_final(iDx);





            this.pbDSF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

        }
        string _Title = "";
        public void LoadImage_final(int iDx)
        {
            switch (iDx)
            {
                case 0:
                    btnTitle.Text = "PRINTING";
                    _Title  = "PRINTING";
                    break;
                case 1:
                    btnTitle.Text = "HF";
                    _Title = "HF";
                    break;
                case 2:
                    btnTitle.Text = "LASER CUTTING";
                    _Title = "LASER";
                    break;
                case 3:
                    btnTitle.Text = "NOSEW";
                    _Title = "NOSEW";
                    break;
                case 4:
                    btnTitle.Text = "EMB";
                    _Title = "EMB";
                    break;
                case 5:
                    this.pbDSF.Image = global::FORM.Properties.Resources._7;
                    break;

            } 
        }
        public void image_name(int iDx)
        {
            switch (iDx)
            {
                case 0:
                    this.pbDSF.Image = global::FORM.Properties.Resources.prod2;
                    break;
                case 1:
                    this.pbDSF.Image = global::FORM.Properties.Resources._1;
                    break;
                case 2:
                    this.pbDSF.Image = global::FORM.Properties.Resources._4;
                    break;
                case 3:
                    this.pbDSF.Image = global::FORM.Properties.Resources._5;
                    break;
                case 4:
                    this.pbDSF.Image = global::FORM.Properties.Resources._6;
                    break;
                case 5:
                    this.pbDSF.Image = global::FORM.Properties.Resources._7;
                    break;

            }
        }

        private void lblTitle_MouseHover(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.Black;
            ((Label)sender).ForeColor = Color.Yellow;
        }

        private void lblTitle_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.Yellow;
            ((Label)sender).ForeColor = Color.Blue;
        }
        int i = 0;
        private void tmr_Tick(object sender, EventArgs e)
        {
            //i++;
            //if (i >= 255) i = 0;
            //a1Panel1.GradientStartColor = Color.FromArgb(i, 255, 255);
            //a1Panel1.GradientEndColor = Color.FromArgb(222, 255, 255);
            //groupBoxEx1.GroupBorderColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            //groupBoxEx2.GroupBorderColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            //groupBoxEx3.GroupBorderColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            //groupBoxEx4.GroupBorderColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            //lbl.ForeColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
        }
        
        private void btnTitle_Click(object sender, EventArgs e)
        {
            if (OnTitleClick != null)
                OnTitleClick( _Title);

            //FRM_SMT_EMD_UNDER u = new FRM_SMT_EMD_UNDER();
            //switch (((DevExpress.XtraEditors.SimpleButton)sender).TabIndex)
            //{

            //    case 0:
            //        ComVar.Var.callForm = "301";
            //        break;
            //    case 1:
            //        ComVar.Var.callForm = "332";

            //        break;
            //    case 2:
            //        ComVar.Var.callForm = "310";
            //        break;
            //    case 3:
            //        u.ShowDialog();
            //        break;
            //    case 4:
            //        u.ShowDialog();
            //        break;
            //    default:
            //        break;
            //}

        }
       
    }
}
