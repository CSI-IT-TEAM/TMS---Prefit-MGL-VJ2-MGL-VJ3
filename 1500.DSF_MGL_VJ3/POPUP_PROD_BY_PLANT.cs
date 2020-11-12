using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM
{
    public partial class POPUP_PROD_BY_PLANT : Form
    {
        public POPUP_PROD_BY_PLANT()
        {
            InitializeComponent();
        }
        public POPUP_PROD_BY_PLANT(Control control, DataTable _dt)
        {
            InitializeComponent();
            dt = _dt;
        }
        DataTable dt = null;
       
        public void BindingData()
        {
            try
            {
                chartControl1.DataSource = dt;
                chartControl1.Series[1].ArgumentDataMember = "LINE_NM";
                chartControl1.Series[1].ValueDataMembers.AddRange(new string[] { "PROD_QTY" });
                chartControl1.Series[0].ArgumentDataMember = "LINE_NM";
                chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "PLAN_QTY" });
                chartControl1.Series[2].ArgumentDataMember = "LINE_NM";
                chartControl1.Series[2].ValueDataMembers.AddRange(new string[] { "RATE" });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
