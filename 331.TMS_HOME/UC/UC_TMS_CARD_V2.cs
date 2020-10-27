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
    public partial class UC_TMS_CARD_V2 : UserControl
    {
        public UC_TMS_CARD_V2()
        {
            InitializeComponent();

        }
        string _code = "";
        private void BindingArc(float value)
        {
            arcScaleComponent1.EnableAnimation = false;
            arcScaleComponent1.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseIn;
            arcScaleComponent1.EasingFunction = new BackEase();
            arcScaleComponent1.MinValue = 0;
            arcScaleComponent1.Value = 0;

            arcScaleComponent1.EnableAnimation = true;
            arcScaleComponent1.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
            arcScaleComponent1.EasingFunction = new BackEase();
            arcScaleComponent1.Value = value;
            labelComponent1.Text = string.Concat(value, "%");
        }

        public void BindingRatio(DataTable dt)
        {
            try
            {
                BindingArc(0);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["LINE_CD"].Equals(_code))
                    {
                        if (!string.IsNullOrEmpty(dr["RATIO"].ToString()))
                            BindingArc(float.Parse(dr["RATIO"].ToString()));
                        //  arcScaleComponent1.Value = );
                    }
                }
            }
            catch { }

        }

        public void InitLabel(string label, string code,string desc)
        {
            lblTitle.Text = label;
            lblDesc.Text = desc;
            _code = code;
        }

        int cCount = 0;

        private void tmrTest_Tick(object sender, EventArgs e)
        {
            cCount++;
            if (cCount == 3)
            {
                Random r = new Random();
                if (!_code.Equals("F1") || !_code.Equals("99") || !_code.Equals("BT"))
                    BindingArc(r.Next(1, 100));
                cCount = 0;
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ComVar.Var._bValue2 = true;
            switch (_code)
            {
                case "F1":
                    ComVar.Var._strValue1 = "FTY01";
                    ComVar.Var.callForm = "179";
                    break;
                case "99":
                    ComVar.Var._strValue1 = "099";
                    ComVar.Var.callForm = "179";
                    break;
                case "UP":
                    //ComVar.Var._strValue1 = "014";
                    //ComVar.Var.callForm = "54";
                    ComVar.Var._strValue1 = "VJ1";
                    ComVar.Var.callForm = "179";
                    break;
                case "VJ3":
                    //ComVar.Var._strValue1 = "014";
                    //ComVar.Var.callForm = "54";
                    ComVar.Var._strValue1 = "VJ3";
                    ComVar.Var._strValue2 = "000";
                    ComVar.Var.callForm = "400";
                    break;
                case "BT":
                    ComVar.Var._strValue1 = "VJ1";
                    ComVar.Var.callForm = "231";
                    break;
                case "OS":

                    ComVar.Var._strValue3 = "OSP";
                    ComVar.Var._strValue4 = "OS";
                    ComVar.Var._strValue5 = "Outsole";
                    ComVar.Var.callForm = "223";
                    break;
                case "IP":
                    ComVar.Var._strValue3 = "IPP";
                    ComVar.Var._strValue4 = "IP";
                    ComVar.Var._strValue5 = "IP";
                    ComVar.Var.callForm = "223";
                    break;
                case "PH":
                    ComVar.Var._strValue3 = "PHP";
                    ComVar.Var._strValue4 = "PH";
                    ComVar.Var._strValue5 = "Phylon";
                    ComVar.Var.callForm = "223";
                    break;
                case "PU":
                    ComVar.Var._strValue3 = "PUP";
                    ComVar.Var._strValue4 = "PU";
                    ComVar.Var._strValue5 = "PU";
                    ComVar.Var.callForm = "223";
                    break;
                case "DMP":
                    ComVar.Var._strValue3 = "DMP";
                    ComVar.Var._strValue4 = "DMP";
                    ComVar.Var._strValue5 = "DMP";
                    ComVar.Var.callForm = "223";
                    break;
                default:
                    break;
            }
        }

        private void btnEnter_MouseHover(object sender, EventArgs e)
        {
            // btnEnter.BackgroundImage = Properties.Resources.go_hover;
        }
        private void btnEnter_MouseEnter(object sender, EventArgs e)
        {
            btnEnter.BackgroundImage = Properties.Resources.go_hover1;
        }

        private void btnEnter_MouseLeave(object sender, EventArgs e)
        {
            btnEnter.BackgroundImage = Properties.Resources.go;
        }

        private void btnHOME_MouseEnter(object sender, EventArgs e)
        {
            btnHOME.BackgroundImage = Properties.Resources.home_hover;
        }

        private void btnHOME_MouseLeave(object sender, EventArgs e)
        {
            btnHOME.BackgroundImage = Properties.Resources.home1;
        }

        private void btnHOME_Click(object sender, EventArgs e)
        {
            ComVar.Var._bValue1 = true; //Sử dụng biến này để back về lại form này.
            switch (_code)
            {
                case "F1":
                    ComVar.Var._strValue1 = "FTY01";
                    ComVar.Var._strValue2 = "000";
                    ComVar.Var.callForm = "178";
                    break;
                case "99":
                    ComVar.Var._strValue1 = "099";
                    ComVar.Var._strValue2 = "000";
                    ComVar.Var.callForm = "178";
                    break;
                case "UP":
                    //ComVar.Var._strValue1 = "014";
                    //ComVar.Var.callForm = "54";
                    ComVar.Var._strValue1 = "VJ1";
                    ComVar.Var._strValue2 = "000";
                    ComVar.Var.callForm = "178";
                    break;
                case "VJ3":

                    //ComVar.Var._strValue1 = "014";
                    //ComVar.Var.callForm = "54";
                    ComVar.Var._strValue1 = "VJ3";
                    ComVar.Var._strValue2 = "000";
                    ComVar.Var.callForm = "401";
                    break;
                case "BT":
                    ComVar.Var._strValue1 = "VJ1";
                    ComVar.Var.callForm = "230";
                    break;
                case "OS":
                    ComVar.Var._strValue1 = "ALL";
                    ComVar.Var._strValue2 = "ALL";
                    ComVar.Var._strValue3 = "OSP";
                    ComVar.Var._strValue4 = "OS";
                    ComVar.Var._strValue5 = "Outsole";
                    ComVar.Var.callForm = "227";

                    break;
                case "IP":
                    ComVar.Var._strValue1 = "ALL";
                    ComVar.Var._strValue2 = "ALL";
                    ComVar.Var._strValue3 = "IPP";
                    ComVar.Var._strValue4 = "IP";
                    ComVar.Var._strValue5 = "IP";
                    ComVar.Var.callForm = "227";
                    break;
                case "PH":
                    ComVar.Var._strValue1 = "ALL";
                    ComVar.Var._strValue2 = "ALL";

                    ComVar.Var._strValue3 = "PHP";
                    ComVar.Var._strValue4 = "PH";
                    ComVar.Var._strValue5 = "Phylon";
                    ComVar.Var.callForm = "227";
                    break;
                case "PU":
                    ComVar.Var._strValue1 = "ALL";
                    ComVar.Var._strValue2 = "ALL";

                    ComVar.Var._strValue3 = "PUP";
                    ComVar.Var._strValue4 = "PU";
                    ComVar.Var._strValue5 = "PU";
                    ComVar.Var.callForm = "227";
                    break;
                case "DMP":
                    ComVar.Var._strValue1 = "ALL";
                    ComVar.Var._strValue2 = "ALL";
                    ComVar.Var._strValue3 = "DMP";
                    ComVar.Var._strValue4 = "DMP";
                    ComVar.Var._strValue5 = "DMP";
                    ComVar.Var.callForm = "227";
                    break;
                default:
                    break;
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            //234
            ComVar.Var._bValue1 = true;
            switch (_code)
            {
                case "F1":
                    ComVar.Var._strValue1 = "FTY01";
                    ComVar.Var.callForm = "343";
                    break;
                case "99":
                    ComVar.Var._strValue1 = "099";
                    ComVar.Var.callForm = "343";
                    break;
                case "UP":
                    //ComVar.Var._strValue1 = "014";
                    ComVar.Var._strValue1 = "VJ1";
                    ComVar.Var.callForm = "343";
                    break;
                case "VJ3":
                    //ComVar.Var._strValue1 = "014";
                    //ComVar.Var.callForm = "54";
                    ComVar.Var._strValue1 = "VJ3";
                    ComVar.Var._strValue2 = "000";
                    ComVar.Var.callForm = "343";
                    break;
                case "BT":
                    ComVar.Var._strValue1 = "VJ1";
                    ComVar.Var.callForm = "345";
                    break;
                case "OS":
                    ComVar.Var._strValue1 = "ALL";
                    ComVar.Var._strValue2 = "ALL";
                    ComVar.Var._strValue3 = "OSP";
                    ComVar.Var._strValue4 = "OS";
                    ComVar.Var._strValue5 = "Outsole";
                    ComVar.Var.callForm = "344";
                    break;
                case "IP":
                    ComVar.Var._strValue1 = "ALL";
                    ComVar.Var._strValue2 = "ALL";
                    ComVar.Var._strValue3 = "IPP";
                    ComVar.Var._strValue4 = "IP";
                    ComVar.Var._strValue5 = "IP";
                    ComVar.Var.callForm = "344";
                    break;
                case "PH":
                    ComVar.Var._strValue1 = "ALL";
                    ComVar.Var._strValue2 = "ALL";

                    ComVar.Var._strValue3 = "PHP";
                    ComVar.Var._strValue4 = "PH";
                    ComVar.Var._strValue5 = "Phylon";
                    ComVar.Var.callForm = "344";
                    break;
                case "PU":
                    ComVar.Var._strValue1 = "ALL";
                    ComVar.Var._strValue2 = "ALL";

                    ComVar.Var._strValue3 = "PUP";
                    ComVar.Var._strValue4 = "PU";
                    ComVar.Var._strValue5 = "PU";
                    ComVar.Var.callForm = "344";
                    break;
                case "DMP":
                    ComVar.Var._strValue1 = "ALL";
                    ComVar.Var._strValue2 = "ALL";

                    ComVar.Var._strValue3 = "DMP";
                    ComVar.Var._strValue4 = "DMP";
                    ComVar.Var._strValue5 = "DMP";
                    ComVar.Var.callForm = "344";
                    break;
                default:
                    break;
            }
        }

        private void UC_TMS_CARD_V2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void UC_TMS_CARD_V2_MouseLeave(object sender, EventArgs e)
        {

        }

        private void advancedPanel1_MouseEnter(object sender, EventArgs e)
        {
            //MessageBox.Show("Enter");
        }

        private void advancedPanel1_MouseLeave(object sender, EventArgs e)
        {
            // MessageBox.Show("Leave");
        }
    }
}
