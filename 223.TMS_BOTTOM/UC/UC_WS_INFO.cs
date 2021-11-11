using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM.UC
{
    public partial class UC_WS_INFO : UserControl
    {
        public UC_WS_INFO()
        {
            InitializeComponent();
        }
        #region Variable
        string _LINE_CD;
        int _PLANT_QTY = 0;
        double _Set_rate = 0;
        Random r = new Random();
        public delegate void OnbtnClickhandle(DevExpress.XtraEditors.SimpleButton button, string buttonTag, string LINE_CD, string LINE_NM,double Set_rate); //buttonTag : Number SEQ of form
        public OnbtnClickhandle OnButtonClick;

        public delegate void OnLabelChangeColorhandle(Label label, string LINE_CD, string LINE_NM, int PLANT_QTY);
        public OnLabelChangeColorhandle OnLabelPlantClick;
        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (OnButtonClick != null)
                OnButtonClick(((DevExpress.XtraEditors.SimpleButton)sender), ((DevExpress.XtraEditors.SimpleButton)sender).Tag.ToString(), _LINE_CD, lblPlantName.Text, _Set_rate);
        }
        public void BindingData(string LINE_CD, string LINE_NM, string PLANT_QTY,string WIP_QTY,string Rate,double LT,double Set_rate)
        {
            try
            {
                int LTProgress = 0 ;
                //lblProgress.Text = "";
                lblPlantQty.Text = "0 Prs";
                lblWip_Qty.Text = "0 Prs";
                lblRateInv_Plan.Text = "0%";
                lblPlantName.Text = LINE_NM;
                _LINE_CD = LINE_CD;
                if (string.IsNullOrEmpty(PLANT_QTY))
                    _PLANT_QTY = 0;
                else
                _PLANT_QTY = Convert.ToInt32(PLANT_QTY);

                lblPlantQty.Text = string.IsNullOrEmpty(PLANT_QTY) ? "0 Prs" : String.Format("{0:n0}", Convert.ToInt32(PLANT_QTY)) + " Prs";
                lblWip_Qty.Text = string.IsNullOrEmpty(WIP_QTY) ? "0 Prs" : String.Format("{0:n0}", Convert.ToInt32(WIP_QTY)) + " Prs";
                _Set_rate = Set_rate;
                //sBtnSet.Text = string.Concat("Set\n", String.Format("{0:n1}",Convert.ToDouble(Set_rate)),"%");
                if (string.IsNullOrEmpty(Rate))
                    Rate = "0";
                double r = Convert.ToDouble(Rate);
                if (r > 100)
                {
                    lblRateInv_Plan.Text = "100%⇗";
                    lblRateInv_Plan.BackColor = Color.Green;
                    lblRateInv_Plan.ForeColor = Color.White;
                }
                else if (r >= 80)
                {
                    lblRateInv_Plan.BackColor = Color.Yellow;
                    lblRateInv_Plan.ForeColor = Color.Black;
                    lblRateInv_Plan.Text = Rate + "%";
                }
                else
                {
                    lblRateInv_Plan.BackColor = Color.Red;
                    lblRateInv_Plan.ForeColor = Color.White;
                    lblRateInv_Plan.Text = Rate + "%";
                }

              
                //for (int i = 0; i < (Convert.ToInt32(LT) > 5 ? 10 : Convert.ToInt32(LT)) * 2; i++)
                //{
                //    lblProgress.Text += "█";
                //}
                lblLT.Text = "Inventory: " + LT.ToString();
                progressBarControl1.EditValue = LT>5?5:LT;
                if (LT > 0.5 && LT< 2.5) // && LT < 1.0
                {
                    lblLT.BackColor = Color.Green;
                    lblLT.ForeColor = Color.White;
                    progressBarControl1.Properties.StartColor = progressBarControl1.Properties.EndColor = Color.Green;
                    progressBarControl1.Properties.EndColor = progressBarControl1.Properties.EndColor = Color.Green;
                }
                else
                {
                    lblLT.BackColor = Color.Red;
                    lblLT.ForeColor = Color.White;
                    progressBarControl1.Properties.StartColor = progressBarControl1.Properties.EndColor = Color.Red;
                    progressBarControl1.Properties.EndColor = progressBarControl1.Properties.EndColor = Color.Red;
                }

                //switch (LT)
                //{
                //    case 1:
                //        lblProgress.ForeColor = Color.Green;
                //        break;
                //    case 2:
                //        lblProgress.ForeColor = Color.YellowGreen;
                //        break;
                //    case 3:
                //        lblProgress.ForeColor = Color.Gold;
                //        break;
                //    case 4:
                //        lblProgress.ForeColor = Color.OrangeRed;
                //        break;
                //    case 5:
                //        lblProgress.ForeColor = Color.Red;
                //        break;
                //}
              //  progressBarControl1.Properties.StartColor = progressBarControl1.Properties.EndColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), 0);
            }
            catch(Exception ex) { }
        }
        public void ChangeColor(bool isDefault)
        {
            if (isDefault)
            {
                if (lblPlantName.BackColor == Color.Yellow)
                {
                    lblPlantName.BackColor = Color.FromArgb(0, 102, 204);
                    lblPlantName.ForeColor = Color.White;
                }
            }
            else
            { lblPlantName.BackColor = Color.Yellow; 
              lblPlantName.ForeColor = Color.Black; }
        }

        private void lblPlantName_Click(object sender, EventArgs e)
        {
            if (OnLabelPlantClick != null)
                OnLabelPlantClick(((System.Windows.Forms.Label)sender), _LINE_CD,lblPlantName.Text, _PLANT_QTY);
                //((System.Windows.Forms.Label)sender).BackColor = Color.Yellow; ((System.Windows.Forms.Label)sender).ForeColor = Color.Black;
            
        }

        private void simpleButton1_MouseHover(object sender, EventArgs e)
        {
            ((DevExpress.XtraEditors.SimpleButton)sender).Text = "Open Detail";
        }

        private void simpleButton1_MouseLeave(object sender, EventArgs e)
        {
            ((DevExpress.XtraEditors.SimpleButton)sender).Text = "Detail";
        }
    }
}
