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

        private void BindingArc(float value)
        {
            //arcScaleComponent1.EnableAnimation = false;
            //arcScaleComponent1.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseIn;
            //arcScaleComponent1.EasingFunction = new BackEase();
            //arcScaleComponent1.MinValue = 0;

            //arcScaleComponent1.Value = 0;

            arcScaleComponent1.EnableAnimation = true;
            arcScaleComponent1.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
            arcScaleComponent1.EasingFunction = new BackEase();

            arcScaleComponent1.Value = value;
            labelComponent1.Text = string.Concat(value,"%");
        }

        public void InitLabel(string label)
        {
            lblTitle.Text = label;
        }

        int cCount = 0;
        
        private void tmrTest_Tick(object sender, EventArgs e)
        {
            cCount++;
            if (cCount == 3)
            {
                Random r = new Random();
                BindingArc(r.Next(1, 100));
                cCount = 0;
            }
        }
    }
}
