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
    public partial class UC_YEAR_SELECTION : UserControl
    {
        public int iValue = DateTime.Now.Year;
        [Browsable(true)]   
        public event EventHandler ValueChangeEvent;

        public UC_YEAR_SELECTION()
        {
            InitializeComponent();
            lblYear.Text = iValue.ToString();
            btnNext.Enabled = false;
        }
        public UC_YEAR_SELECTION(int _iValue)
        {
            InitializeComponent();
            iValue = _iValue;
            lblYear.Text = iValue.ToString();
            btnNext.Enabled = false;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
            iValue = iValue - 1;
            SetValue();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
           
            iValue = iValue + 1;
            SetValue();
            if (DateTime.Now.Year == iValue)
            {
                btnNext.Enabled = false;
            }
        }
        private void SetValue()
        {
            lblYear.Text = iValue.ToString();
        }
        public void EnableControl(bool _b)
        {
            btnPrev.Enabled = _b;
            btnNext.Enabled = _b;
        }
        public void SetValue(string _iValue)
        {
            iValue = Convert.ToInt32(_iValue);
            lblYear.Text = iValue.ToString();
        }
        public int GetValue()
        {
            return iValue;
        }

        private void lblYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EnableControl(false);
                if (this.ValueChangeEvent != null)
                {
                    this.ValueChangeEvent(this, e);
                }
                EnableControl(true);
            } catch(Exception ex)
            {
                EnableControl(true);
            }

        }
    }
}
