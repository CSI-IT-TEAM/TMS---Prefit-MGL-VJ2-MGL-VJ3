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
    public partial class NavBar : UserControl
    {
        public NavBar()
        {
            InitializeComponent();
        }
        public NavBar(string Title)
        {
            InitializeComponent();
            this.lblTitle.Text = Title;
            switch(Title)
            {
                case "Factory":
                    this.lblTitle.Tag = "F"; //Factory
                    break;
                case "Bottom":
                    this.lblTitle.Tag = "B"; //Bottom
                    break;
            }
        }
        #region Variable
        public delegate void ButtonMenuHandler(string TitleCode, string MenuCode);
        public ButtonMenuHandler OnMenuClick = null;
        #endregion
        #region Event
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
        #endregion

        private void nvItem_LinkPressed(object sender, NavBarLinkEventArgs e)
        {
            if (OnMenuClick != null)
                OnMenuClick(lblTitle.Tag.ToString(), ((DevExpress.XtraNavBar.NavBarItem)sender).Tag.ToString());
        }
    }
}
