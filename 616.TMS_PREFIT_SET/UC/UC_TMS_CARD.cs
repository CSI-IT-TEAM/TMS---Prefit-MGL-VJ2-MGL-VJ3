using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGauges.Core.Model;

namespace FORM.UC
{
    public partial class UC_TMS_CARD : UserControl
    {
        public UC_TMS_CARD()
        {
            InitializeComponent();
        }


        public void BindingArc(float value, int arcScaleComponent)
        {
            if (arcScaleComponent == 1)
            {
                //arcScaleComponent2.EnableAnimation = false;
                //arcScaleComponent2.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseIn;
                //arcScaleComponent2.EasingFunction = new BackEase();
                //arcScaleComponent2.MinValue = 0;
                //arcScaleComponent2.Value = 0;

                arcScaleComponent2.EnableAnimation = true;
                arcScaleComponent2.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                arcScaleComponent2.EasingFunction = new BackEase();
                arcScaleComponent2.Value = value;
                labelComponent2.Text = string.Concat(value, "%");
            }
            else {
                //arcScaleComponent3.EnableAnimation = false;
                //arcScaleComponent3.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseIn;
                //arcScaleComponent3.EasingFunction = new BackEase();
                //arcScaleComponent3.MinValue = 0;
                //arcScaleComponent3.Value = 0;

                arcScaleComponent3.EnableAnimation = true;
                arcScaleComponent3.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                arcScaleComponent3.EasingFunction = new BackEase();
                arcScaleComponent3.Value = value;
                labelComponent3.Text = string.Concat(value, "%");
            }
        }
        private void btnEnter_MouseEnter(object sender, EventArgs e)
        {
            btnEnter.BackgroundImage = Properties.Resources.go_hover;
        }

        private void btnEnter_MouseLeave(object sender, EventArgs e)
        {
            btnEnter.BackgroundImage = Properties.Resources.go;
        }

        public void BindingData(tmsHomeModel model)
        {
            lblProcNM.Text = model.PROC_NAME_CARD;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_MouseEnter(object sender, EventArgs e)
        {
            btnHome.BackgroundImage = Properties.Resources.shop_hover;
        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            btnHome.BackgroundImage = Properties.Resources.shop;
        }

    }
}
