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
        Random r = new Random();
        public delegate void OnbtnClickhandle(DevExpress.XtraEditors.SimpleButton button, string buttonTag, string LINE_CD, string LINE_NM, double SET_TATE); //buttonTag : Number SEQ of form
        public OnbtnClickhandle OnButtonClick;

        public delegate void OnLabelChangeColorhandle(Label label, string LINE_CD, string LINE_NM, int PLANT_QTY);
        public OnLabelChangeColorhandle OnLabelPlantClick;
        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (OnButtonClick != null)
                OnButtonClick(((DevExpress.XtraEditors.SimpleButton)sender),((DevExpress.XtraEditors.SimpleButton)sender).Tag.ToString(), _LINE_CD,lblPlantName.Text, 0);
        }
        public void BindingData(string LINE_CD, string LINE_NM, string PLANT_QTY,string WIP_QTY,string Rate, double LT,string Enable_YN)
        {
            try
            {
                if (Enable_YN.Equals("Y"))
                {
                    label1.Text = "Plant";
                    label3.Text = "Current";
                    lblPlantName.BackColor =  Color.DarkTurquoise;
                    sBtnDetail.BackColor = Color.Gold;
                    label1.ForeColor = lblPlantQty.ForeColor = Color.Green;
                    label3.ForeColor = lblWip_Qty.ForeColor = Color.FromArgb(192, 64, 0);
                    sBtnDetail.Appearance.BackColor = Color.Gold;
                    sBtnDetail.Enabled = true;
                    //sBtnDetail.Visible = true;
                    //lblPlantName.Visible = true;
                    //flowLayoutPanel1.Visible = true;
                    //lblLT.Visible = true;
                    //progressBarControl1.Visible = true;

                    int LTProgress = 0;
                    //lblProgress.Text = "";
                    lblPlantQty.Text = "0 Prs";
                    lblWip_Qty.Text = "0 Prs";
                    lblRateInv_Plan.Text = "0%";
                    lblPlantName.Text = LINE_NM;
                    _LINE_CD = LINE_CD;
                    _PLANT_QTY = string.IsNullOrEmpty(PLANT_QTY) ? 0 : Convert.ToInt32(PLANT_QTY);
                    lblPlantQty.Text = string.IsNullOrEmpty(PLANT_QTY) ? "0 Prs" : String.Format("{0:n0}", Convert.ToInt32(PLANT_QTY)) + " Prs";
                    lblWip_Qty.Text = string.IsNullOrEmpty(WIP_QTY) ? "0 Prs" : String.Format("{0:n0}", Convert.ToInt32(WIP_QTY)) + " Prs";
                    double r = string.IsNullOrEmpty(Rate) ? 0 : Convert.ToDouble(Rate);
                    //if (r > 100)
                    //{
                    //    lblRateInv_Plan.Text = "100%⇗";
                    //    lblRateInv_Plan.BackColor = Color.Green;
                    //    lblRateInv_Plan.ForeColor = Color.White;
                    //}
                    //else if (r >= 80)
                    //{
                    //    lblRateInv_Plan.BackColor = Color.Yellow;
                    //    lblRateInv_Plan.ForeColor = Color.Black;
                    //    lblRateInv_Plan.Text = Rate + "%";
                    //}
                    //else
                    //{
                    //    lblRateInv_Plan.BackColor = Color.Red;
                    //    lblRateInv_Plan.ForeColor = Color.White;
                    //    lblRateInv_Plan.Text = Rate + "%";
                    //}
                    //for (int i = 0; i < (Convert.ToInt32(LT) > 5 ? 10 : Convert.ToInt32(LT)) * 2; i++)
                    //{
                    //    lblProgress.Text += "█";
                    //}
                    lblLT.Text = "Inventory: " + LT.ToString();
                    progressBarControl1.EditValue = LT > 5 ? 5 : LT;
                    if (LT > 0.5 && LT < 2.5) // && LT < 1.0
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
                }
                else
                {
                    lblPlantName.BackColor =sBtnDetail.BackColor= Color.Gray;
                    lblPlantName.Text = LINE_NM;
                    progressBarControl1.EditValue = 0;
                    lblPlantQty.Text = "";
                    lblPlantQty.ForeColor = Color.Gray;
                    lblWip_Qty.Text = "";
                    lblWip_Qty.ForeColor = Color.Gray;
                    label1.Text = "Plant";
                    label1.ForeColor = Color.Gray;
                    label3.Text = "Current";
                    label3.ForeColor = Color.Gray;
                    lblLT.BackColor = Color.Gray;
                    lblLT.Text = "";
                    sBtnDetail.Appearance.BackColor = Color.Gray;
                    sBtnDetail.Enabled = false;
                    //sBtnDetail.Visible = false;
                    //lblPlantName.Visible = false;
                    //flowLayoutPanel1.Visible = false;
                    //lblLT.Visible = false;
                    //progressBarControl1.Visible = false;

                }

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
        }

        private void simpleButton1_MouseHover(object sender, EventArgs e)
        {
            ((DevExpress.XtraEditors.SimpleButton)sender).Text = "Open Detail";
        }

        private void simpleButton1_MouseLeave(object sender, EventArgs e)
        {
            ((DevExpress.XtraEditors.SimpleButton)sender).Text = "Detail";
        }

        private void sBtnDetail_Click(object sender, EventArgs e)
        {
            ComVar.Var._strValue4 = _LINE_CD;
            ComVar.Var.callForm = "640";
        }
    }
}
