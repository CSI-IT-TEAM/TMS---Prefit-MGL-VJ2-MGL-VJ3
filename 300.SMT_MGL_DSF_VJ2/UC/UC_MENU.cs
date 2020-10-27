using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraNavBar;

namespace FORM.UC
{
    public partial class UC_MENU : UserControl
    {
        public UC_MENU(string Title)
        {
            InitializeComponent();
        }

        #region Variable
        string _ButtonCap = null, _ButtonCD = null,_ProdCap = null;
        public delegate void ButtonPlantHandler(string ButtonCap,string ButtonCD);
        public ButtonPlantHandler OnClick = null;

        //===menu click
        public delegate void MenuHandler(string MenuName, string ButtonCD,string ButtonCap);
        public MenuHandler OnMenuClick = null;


        #endregion

        public UC_MENU(string ButtonCap,string Button_CD)
        {
            InitializeComponent();
            this.btnPlant.Text = ButtonCap;
            _ButtonCD = Button_CD;
            _ButtonCap = ButtonCap;
        }


     

        public void BindingData(DataTable dt)
        {
            try
            {
                lblDplan_Qty.Text = dt.Rows[0]["PLAN_QTY"].ToString();
                lblRplan_Qty.Text = dt.Rows[0]["RPLAN"].ToString();
                lblActual_Qty.Text = dt.Rows[0]["PROD_QTY"].ToString();
                lblRate_Per.Text = dt.Rows[0]["RATE"].ToString();
            }
            catch { }
        }


        private void navBarControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
             
                NavBarControl navBar = sender as NavBarControl;
                NavBarHitInfo hitInfo = navBar.CalcHitInfo(new Point(e.X, e.Y));
                if (hitInfo.InGroupCaption && !hitInfo.InGroupButton)
                    hitInfo.Group.Expanded = !hitInfo.Group.Expanded;
               
            }
        }

        private void btnPlant_Click(object sender, EventArgs e)
        {
            if (OnClick != null)
                OnClick(btnPlant.Text,_ButtonCD);
        }

        private void nBI_LinkPressed(object sender, NavBarLinkEventArgs e)
        {
            if (OnMenuClick != null)
                OnMenuClick(e.Link.ItemName.ToString(),_ButtonCD,_ButtonCap);
        }
    }
}
