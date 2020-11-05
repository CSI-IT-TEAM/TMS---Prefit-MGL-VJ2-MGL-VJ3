using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM.UC
{
    public partial class UC_CHART_PROD : UserControl
    {
        public UC_CHART_PROD()
        {
            InitializeComponent();
        }
        public void BindingData(DataTable dt)
        {
            chartControl1.DataSource = dt;
            chartControl1.Series[1].ArgumentDataMember = "LINE_CD";
            chartControl1.Series[1].ValueDataMembers.AddRange(new string[] { "PROD_QTY" });
            chartControl1.Series[0].ArgumentDataMember = "LINE_CD";
            chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "PLAN_QTY" });
            chartControl1.Series[2].ArgumentDataMember = "LINE_CD";
            chartControl1.Series[2].ValueDataMembers.AddRange(new string[] { "RATE" });

        }
    }
}
