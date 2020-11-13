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
    //public partial class UC_MONTH_SELECTION : UserControl
    //{
    //    private string sValue = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00");
    //    private string sYearValue = DateTime.Now.Year.ToString();
    //    private string sMonthValue = DateTime.Now.Month.ToString("00");
    //    private string[] _arrMonthValue = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
    //    private string[] _arrMonthShortName = {"Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"};
    //    private string[] _arrMonthLongName = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "Novvember", "December" };

    //    [Browsable(true)]   
    //    public event EventHandler ValueChangeEvent;
    //   // public event EventHandler ValueYearChangeEvent;
    //   // public event EventHandler ValueMonthChangeEvent;
       

    //    public UC_MONTH_SELECTION()
    //    {
    //        InitializeComponent();
    //        lblYear.Text = sYearValue.ToString();
    //        lblMonth.Text = _arrMonthShortName[Convert.ToInt32(sMonthValue) - 1].ToString();
    //        btnNextYear.Enabled = false;
    //        btnNextMonth.Enabled = false;
    //    }
    //    public UC_MONTH_SELECTION(string _sYearValue, string _sMonthValue)
    //    {
    //        InitializeComponent();
    //        sValue = _sYearValue + _sMonthValue;
    //        lblYear.Text = _sYearValue.ToString();
    //        lblMonth.Text = _arrMonthShortName[Convert.ToInt32(sMonthValue) - 1].ToString();
    //    }
   
    //    private void SetValue()
    //    {
    //        lblYear.Text = sValue.ToString();
    //    }
    //    public void EnableControl(bool _b)
    //    {
    //        btnPrevYear.Enabled = _b;
    //        btnNextYear.Enabled = _b;
    //        btnPrevMonth.Enabled = _b;
    //        btnNextMonth.Enabled = _b;
    //    }
    //    public void SetValue(string _sYearValue, string _sMonthValue)
    //    {
    //        sYearValue = _sYearValue;
    //        sMonthValue = _sMonthValue;
    //        lblYear.Text = sYearValue.ToString();
    //        lblMonth.Text = _arrMonthValue[Convert.ToInt32(sMonthValue) - 1].ToString();
    //    }
    //    public void SetShortName(string _sYearValue, string _sMonthValue)
    //    {
    //        sYearValue = _sYearValue;
    //        sMonthValue = _sMonthValue;
    //        lblYear.Text = sYearValue.ToString();
    //        lblMonth.Text = _arrMonthShortName[Convert.ToInt32(sMonthValue) -1 ].ToString();
    //    }

    //    public void SetLongName(string _sYearValue, string _sMonthValue)
    //    {
    //        sYearValue = _sYearValue;
    //        sMonthValue = _sMonthValue;
    //        lblYear.Text = sYearValue.ToString();
    //        lblMonth.Text = _arrMonthLongName[Convert.ToInt32(sMonthValue) - 1].ToString();
    //    }
    //    public string GetValue()
    //    {
    //        return sValue;
    //    }
    //    public string GetYearValue()
    //    {
    //        return sYearValue;
    //    }

    //    public string GetMonthValue()
    //    {
    //        return sMonthValue;
    //    }

    //    private void lblYear_TextChanged(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            if (DateTime.Now.Year.ToString() == sYearValue && DateTime.Now.Month.ToString("00") == sMonthValue)
    //            {
    //                btnNextYear.Enabled = false;
    //                btnNextMonth.Enabled = false;
    //            }
    //            else
    //            {
    //                btnNextYear.Enabled = true;
    //                btnNextMonth.Enabled = true;
    //            }
    //            EnableControl(false);
    //            if (this.ValueChangeEvent != null)
    //            {
    //                this.ValueChangeEvent(this, e);
    //            }
    //            EnableControl(true);
    //        } catch(Exception ex)
    //        {
    //            EnableControl(true);
    //        }

    //    }

    //    private void btnPrevMonth_Click(object sender, EventArgs e)
    //    {
            
    //        if (Convert.ToInt32(sMonthValue) == 1)
    //        {
    //            sMonthValue = "12";
    //            //DO
    //            sYearValue = (Convert.ToInt32(sYearValue) - 1).ToString();
                
    //        }
    //        else
    //        {
    //            sMonthValue = (Convert.ToInt32(sMonthValue) - 1).ToString("00");
    //        }
    //        sValue = sYearValue + sMonthValue;
    //        SetShortName(sYearValue, sMonthValue);
    //        this.btnPrevMonth.Focus();
            
    //    }

    //    private void btnNextMonth_Click(object sender, EventArgs e)
    //    {
    //        if (Convert.ToDouble(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00")) 
    //               < Convert.ToDouble((Convert.ToInt32(sYearValue)).ToString() + (Convert.ToInt32(sMonthValue) + 1).ToString("00"))) return;

    //        if (Convert.ToInt32(sMonthValue) == 12)
    //        {
    //            sMonthValue = "01";
    //            //DO
    //            sYearValue = (Convert.ToInt32(sYearValue) + 1).ToString();
                
    //        }
    //        else
    //        {
    //            sMonthValue = (Convert.ToInt32(sMonthValue) + 1).ToString("00");
                
    //        }
    //        sValue = sYearValue + sMonthValue;
    //        SetShortName(sYearValue, sMonthValue);
    //        this.btnNextMonth.Focus();
    //    }

    //    private void lblMonth_TextChanged(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            EnableControl(false);
    //            if (this.ValueChangeEvent != null)
    //            {
    //                this.ValueChangeEvent(this, e);
    //            }
    //            EnableControl(true);
    //        }
    //        catch (Exception ex)
    //        {
    //            EnableControl(true);
    //        }
    //    }

    //    private void btnPrevYear_Click(object sender, EventArgs e)
    //    {
    //        btnNextYear.Enabled = true;
    //        sYearValue = (Convert.ToInt32(sYearValue) - 1).ToString();
    //        sValue = sYearValue + sMonthValue;
    //        SetShortName(sYearValue, sMonthValue);
    //        this.btnPrevYear.Focus();
    //    }

    //    private void btnNextYear_Click(object sender, EventArgs e)
    //    {            
    //        if (DateTime.Now.Year < Convert.ToInt32(sYearValue) + 1) return;
    //        if (Convert.ToDouble(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00"))
    //               < Convert.ToDouble((Convert.ToInt32(sYearValue)+1).ToString() + (Convert.ToInt32(sMonthValue)).ToString("00")))
    //        {
    //            sYearValue = (Convert.ToInt32(sYearValue) + 1).ToString();
    //            sMonthValue = "01";
    //            sValue = sYearValue + sMonthValue;
    //            SetShortName(sYearValue, sMonthValue);
    //            this.btnNextYear.Focus();
    //        }
    //        else
    //        {
    //            sYearValue = (Convert.ToInt32(sYearValue) + 1).ToString();
    //            sValue = sYearValue + sMonthValue;
    //            SetShortName(sYearValue, sMonthValue);
    //            this.btnNextYear.Focus();
    //        }
    //        if (DateTime.Now.Year == Convert.ToInt32(sYearValue))
    //        {
    //            btnNextYear.Enabled = false;
    //        }
    //    }

        

        
    //}
    public partial class UC_MONTH_SELECTION : UserControl
    {
        private string sValue = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00");
        private string sYearValue = DateTime.Now.Year.ToString();
        private string sMonthValue = DateTime.Now.Month.ToString("00");
        private string[] _arrMonthValue = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        private string[] _arrMonthShortName = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        private string[] _arrMonthLongName = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "Novvember", "December" };
        private bool isMonthValueChange = false;

        [Browsable(true)]
        public event EventHandler ValueChangeEvent;
        // public event EventHandler ValueYearChangeEvent;
        // public event EventHandler ValueMonthChangeEvent;


        public UC_MONTH_SELECTION()
        {
            InitializeComponent();
            lblYear.Text = sYearValue.ToString();
            lblMonth.Text = _arrMonthShortName[Convert.ToInt32(sMonthValue) - 1].ToString();
            btnNextYear.Enabled = false;
            btnNextMonth.Enabled = false;
        }
        public UC_MONTH_SELECTION(string _sYearValue, string _sMonthValue)
        {
            InitializeComponent();
            sValue = _sYearValue + _sMonthValue;
            lblYear.Text = _sYearValue.ToString();
            lblMonth.Text = _arrMonthShortName[Convert.ToInt32(sMonthValue) - 1].ToString();
        }

        private void SetValue()
        {
            lblYear.Text = sValue.ToString();
        }
        public void EnableControl(bool _b)
        {
            btnPrevYear.Enabled = _b;
            btnNextYear.Enabled = _b;
            btnPrevMonth.Enabled = _b;
            btnNextMonth.Enabled = _b;
        }
        public void SetValue(string _sYearValue, string _sMonthValue)
        {
            sYearValue = _sYearValue;
            sMonthValue = _sMonthValue;
            lblYear.Text = sYearValue.ToString();
            lblMonth.Text = _arrMonthValue[Convert.ToInt32(sMonthValue) - 1].ToString();
        }
        public void SetShortName(string _sYearValue, string _sMonthValue)
        {
            sYearValue = _sYearValue;
            sMonthValue = _sMonthValue;
            lblYear.Text = sYearValue.ToString();
            lblMonth.Text = _arrMonthShortName[Convert.ToInt32(sMonthValue) - 1].ToString();
        }

        public void SetLongName(string _sYearValue, string _sMonthValue)
        {
            sYearValue = _sYearValue;
            sMonthValue = _sMonthValue;
            lblYear.Text = sYearValue.ToString();
            lblMonth.Text = _arrMonthLongName[Convert.ToInt32(sMonthValue) - 1].ToString();
        }
        public string GetValue()
        {
            return sValue;
        }
        public string GetYearValue()
        {
            return sYearValue;
        }

        public string GetMonthValue()
        {
            return sMonthValue;
        }

        private void lblYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EnableControl(false);
                if (this.ValueChangeEvent != null && !isMonthValueChange)
                {
                    this.ValueChangeEvent(this, e);
                    isMonthValueChange = false;
                }
                EnableControl(true);

                if (Convert.ToInt32(sYearValue) >= DateTime.Now.Year)
                {
                    this.btnNextYear.Enabled = false;
                }
                else
                {
                    this.btnNextYear.Enabled = true;
                    this.btnNextYear.Focus();
                }


                if (Convert.ToInt32(sYearValue) >= DateTime.Now.Year && Convert.ToInt32(sMonthValue) >= DateTime.Now.Month)
                {
                    this.btnNextMonth.Enabled = false;
                }
                else
                {
                    this.btnNextMonth.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                EnableControl(true);
            }

        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            isMonthValueChange = true;
            if (Convert.ToInt32(sMonthValue) == 1)
            {
                sMonthValue = "12";
                //DO
                sYearValue = (Convert.ToInt32(sYearValue) - 1).ToString();

            }
            else
            {
                sMonthValue = (Convert.ToInt32(sMonthValue) - 1).ToString("00");
            }
            sValue = sYearValue + sMonthValue;
            SetShortName(sYearValue, sMonthValue);
            this.btnPrevMonth.Focus();

        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {

            isMonthValueChange = true;
            if (Convert.ToInt32(sMonthValue) == 12)
            {
                sMonthValue = "01";
                //DO
                sYearValue = (Convert.ToInt32(sYearValue) + 1).ToString();

            }
            else
            {
                sMonthValue = (Convert.ToInt32(sMonthValue) + 1).ToString("00");

            }
            sValue = sYearValue + sMonthValue;
            SetShortName(sYearValue, sMonthValue);

        }

        private void lblMonth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EnableControl(false);
                if (this.ValueChangeEvent != null)
                {
                    this.ValueChangeEvent(this, e);
                    isMonthValueChange = false;
                }
                EnableControl(true);
                if (Convert.ToInt32(sYearValue) >= DateTime.Now.Year && Convert.ToInt32(sMonthValue) >= DateTime.Now.Month)
                {
                    this.btnNextMonth.Enabled = false;
                    this.btnNextYear.Enabled = false;
                }
                else
                {
                    this.btnNextMonth.Enabled = true;
                    this.btnNextYear.Enabled = true;
                    this.btnNextMonth.Focus();
                }
            }
            catch (Exception ex)
            {
                EnableControl(true);
            }
        }

        private void btnPrevYear_Click(object sender, EventArgs e)
        {

            sYearValue = (Convert.ToInt32(sYearValue) - 1).ToString();
            sValue = sYearValue + sMonthValue;
            SetShortName(sYearValue, sMonthValue);
            this.btnPrevYear.Focus();
        }

        private void btnNextYear_Click(object sender, EventArgs e)
        {

            //sYearValue = (Convert.ToInt32(sYearValue) + 1).ToString();
            //sValue = sYearValue + sMonthValue;
            //SetShortName(sYearValue, sMonthValue);
            if (DateTime.Now.Year < Convert.ToInt32(sYearValue) + 1) return;
            if (Convert.ToDouble(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00"))
                   < Convert.ToDouble((Convert.ToInt32(sYearValue) + 1).ToString() + (Convert.ToInt32(sMonthValue)).ToString("00")))
            {
                sYearValue = (Convert.ToInt32(sYearValue) + 1).ToString();
                sMonthValue = DateTime.Now.Month.ToString("00");
                sValue = sYearValue + sMonthValue;
                SetShortName(sYearValue, sMonthValue);
                this.btnNextYear.Focus();
            }
            else
            {
                sYearValue = (Convert.ToInt32(sYearValue) + 1).ToString();
                sValue = sYearValue + sMonthValue;
                SetShortName(sYearValue, sMonthValue);
                this.btnNextYear.Focus();
            }
            if (DateTime.Now.Year == Convert.ToInt32(sYearValue))
            {
                btnNextYear.Enabled = false;
            }

        }

    }

}
