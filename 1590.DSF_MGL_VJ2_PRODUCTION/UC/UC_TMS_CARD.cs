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
        #region Variable
        tmsHomeModel TMSUCmodel = null;
        #endregion

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
            else
            {
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
            
            TMSUCmodel = model;
            if (model.USE_YN.Equals("N"))
            {
                this.Enabled = false;
                lblProcNM.BackColor = Color.Gray;
                lblProcNM.ForeColor = Color.White;
            }
        }

       

        private void btnHome_MouseEnter(object sender, EventArgs e)
        {
            btnHome.BackgroundImage = Properties.Resources.shop_hover;
        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            btnHome.BackgroundImage = Properties.Resources.shop;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ComVar.Var._strValue1 = TMSUCmodel.FACTORY;// Biến lưu trữ code factory
            ComVar.Var._strValue2 = TMSUCmodel.PROC_CODE_CARD; // Biến lưu trữ Process code
            ComVar.Var._strValue3 = TMSUCmodel.PROC_NAME_CARD; // Biến lưu trữ Process name
            ComVar.Var._bValue2 = TMSUCmodel.PART_SHOW_YN;  //Biến lưu trữ column part no, part name show or hidden.
            ComVar.Var._bValue1 = TMSUCmodel.IS_BOTTOM; //Biến lưu trữ kiểm tra có phải là bottom hay không?.
            ComVar.Var._Value = "Button Enter Click";
            ComVar.Var.callForm = "601"; // outgoing form
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            ComVar.Var._strValue1 = TMSUCmodel.FACTORY;// Biến lưu trữ code factory
            ComVar.Var._strValue2 = TMSUCmodel.PROC_CODE_CARD; // Biến lưu trữ Process code
            ComVar.Var._strValue3 = TMSUCmodel.PROC_NAME_CARD; // Biến lưu trữ Process name
            ComVar.Var._bValue2 = TMSUCmodel.PART_SHOW_YN;  //Biến lưu trữ column part no, part name show or hidden.
            ComVar.Var._bValue1 = TMSUCmodel.IS_BOTTOM; //Biến lưu trữ kiểm tra có phải là bottom hay không?.
            ComVar.Var._Value = "Button Enter Click";
            ComVar.Var.callForm = "602"; // outgoing form
        }

        private void gaugeControl1_Click(object sender, EventArgs e)
        {
            //By Nos Line Click
            ComVar.Var._strValue1 = TMSUCmodel.FACTORY;// Biến lưu trữ code factory
            ComVar.Var._strValue2 = TMSUCmodel.PROC_CODE_CARD; // Biến lưu trữ Process code
            ComVar.Var._strValue3 = TMSUCmodel.PROC_NAME_CARD; // Biến lưu trữ Process name
            ComVar.Var._bValue2 = TMSUCmodel.PART_SHOW_YN;  //Biến lưu trữ column part no, part name show or hidden.
            ComVar.Var._bValue1 = TMSUCmodel.IS_BOTTOM; //Biến lưu trữ kiểm tra có phải là bottom hay không?.
            ComVar.Var.callForm = "615";
        }

        private void gaugeControl2_Click(object sender, EventArgs e)
        {
            //By All Factory Click
            //By Nos Line Click
            ComVar.Var._strValue1 = TMSUCmodel.FACTORY;// Biến lưu trữ code factory
            ComVar.Var._strValue2 = TMSUCmodel.PROC_CODE_CARD; // Biến lưu trữ Process code
            ComVar.Var._strValue3 = TMSUCmodel.PROC_NAME_CARD; // Biến lưu trữ Process name
            ComVar.Var._bValue2 = TMSUCmodel.PART_SHOW_YN;  //Biến lưu trữ column part no, part name show or hidden.
            ComVar.Var._bValue1 = TMSUCmodel.IS_BOTTOM; //Biến lưu trữ kiểm tra có phải là bottom hay không?.
            ComVar.Var.callForm = "616";
        }

        private void gaugeControl2_MouseEnter(object sender, EventArgs e)
        {
            //By Nos Line Mouse Hover
            arcScaleRangeBarComponent2.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:Red;Style2:Red]");
        }

        private void gaugeControl1_MouseLeave(object sender, EventArgs e)
        {
            arcScaleRangeBarComponent2.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:Yellow;Style2:Yellow]");
        }

    }
}
