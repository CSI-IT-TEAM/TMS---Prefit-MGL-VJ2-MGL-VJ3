using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace FORM.UC
{
    public partial class UC_TOPO_CHART : UserControl
    {
        public UC_TOPO_CHART()
        {
            InitializeComponent();

        }
        #region Variable

        #endregion


        public void BindingChart(DataTable dt, string TITLE)
        {
            try
            {
                DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
                chartControl1.DataSource = dt;
                if (!TITLE.ToUpper().Contains("RATIO"))
                {
                    chartControl1.Series[0].Name = "PO";
                    chartControl1.Series[0].ArgumentDataMember = "DIV";
                    chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "TO_QTY" });
                    chartControl1.Series[1].Name = "TO";
                    chartControl1.Series[1].ArgumentDataMember = "DIV";
                    chartControl1.Series[1].ValueDataMembers.AddRange(new string[] { "PO_QTY" });

                    if (TITLE.ToUpper().Equals("TOTAL"))
                    {
                        chartControl1.BackColor = System.Drawing.Color.FromArgb(253, 234, 218);
                        ((DevExpress.XtraCharts.XYDiagram)chartControl1.Diagram).DefaultPane.BackColor = System.Drawing.Color.FromArgb(253, 234, 218);
                    }
                    else
                    {
                        chartControl1.BackColor = Color.White;
                        ((DevExpress.XtraCharts.XYDiagram)chartControl1.Diagram).DefaultPane.BackColor = Color.White;
                    }
                }
                else
                {
                    chartControl1.CustomDrawSeriesPoint += new DevExpress.XtraCharts.CustomDrawSeriesPointEventHandler(this.chartControl1_CustomDrawSeriesPoint);
                    chartControl1.Series[0].Name = "RATIO";
                    chartControl1.Series[0].View.Color = Color.Green;
                    chartControl1.Series[1].ShowInLegend = false;
                    chartControl1.Series[0].ArgumentDataMember = "DIV";
                    chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "RATE" });
                    chartControl1.BackColor = System.Drawing.Color.FromArgb(253, 234, 218);
                    ((DevExpress.XtraCharts.XYDiagram)chartControl1.Diagram).DefaultPane.BackColor = System.Drawing.Color.FromArgb(253, 234, 218);
                    
                }
                chartControl1.Titles.Clear();
                chartTitle1.Text = TITLE;
            
                this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle1 });
            }
            catch(Exception ex) { }
        }

        private void chartControl1_CustomDrawSeriesPoint(object sender, DevExpress.XtraCharts.CustomDrawSeriesPointEventArgs e)
        {
            BarDrawOptions drawOptions = e.SeriesDrawOptions as BarDrawOptions;
            if (drawOptions == null)
                return;
            double val = e.SeriesPoint[0];
            if (val < 100)
            {
                drawOptions.Color = Color.Red;
            } 
            else
                drawOptions.Color = Color.LimeGreen;
        }
    }
}
