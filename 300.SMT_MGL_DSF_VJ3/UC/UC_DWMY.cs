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
    public partial class UC_DWMY : UserControl
    {
        //int _btnisDisable = 0;
        public UC_DWMY()
        {
            InitializeComponent();
        }
        public delegate void ButtonDWMYHandler(string ButtonCap, string ButtonCD);
        public ButtonDWMYHandler OnDWMYClick = null;

        public void YMD_Change(int btnisDisable)
        {
            switch (btnisDisable)
            {
                case 1:
                    btnDay.Enabled = false;
                    break;
                case 2:
                    btnWeek.Enabled = false;
                    break;
                case 3:
                    btnMonth.Enabled = false;
                    break;
                case 4:
                    btnYear.Enabled = false;
                    break;
                case 5:
                    btnYear.Visible = false;
                    btnMonth.Visible = false;
                    btnWeek.Visible = false;
                    btnDay.Visible = false;
                    break;
                case 6:
                    btnYear.Visible = true;
                    btnMonth.Visible = true;
                    btnWeek.Visible = false;
                    btnDay.Visible = true;
                    break;
                case 7:
                    btnYear.Visible = true;
                    btnMonth.Enabled = true;
                    btnWeek.Visible = false;
                    btnDay.Visible = false;
                    break;
                case 8:
                    btnYear.Enabled = false;
                    btnMonth.Visible = true;
                    btnWeek.Visible = false;
                    btnDay.Visible = false;
                    break;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            if (OnDWMYClick != null)
                OnDWMYClick(cnt.Name.ToString(), cnt.Tag.ToString());
        }


    }
}
