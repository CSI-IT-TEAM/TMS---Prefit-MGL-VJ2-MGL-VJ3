using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace FORM
{
    public partial class FRM_POPUP_SQM_TRACKING : Form
    {
        public FRM_POPUP_SQM_TRACKING(Control control,DataTable _dt,bool _isToday)
        {
            InitializeComponent();
             flyoutPanel1.OwnerControl = control;
            dt = _dt;
            isToday = _isToday;
        }
        
        DataTable dt;
        bool isToday;
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BindingDataChart(DataTable dt,bool isToday)
        {
            lblSQMPrs.Text = "0 Prs";
            if (isToday)
            {
                btnToday.Appearance.BackColor = Color.Orange;
                btnToday.Appearance.BackColor2 = Color.Orange;
                btnYesterday.Appearance.BackColor = Color.LightSteelBlue;
                btnYesterday.Appearance.BackColor2 = Color.LightSteelBlue;
                if (dt.Select("YT = 'TODAY'").Count() > 0)
                {
                    lblSQMPrs.Text = string.Format("{0:n0}", dt.Compute("SUM(QTY)", "YT='TODAY'")) + " Prs";
                    chartControl1.DataSource = dt.Select("YT = 'TODAY'", "YT,ASY_YMD DESC,TRIP").CopyToDataTable();
                }
                else
                    chartControl1.DataSource = null;
            }
            else
            {
                btnYesterday.Appearance.BackColor = Color.Orange;
                btnYesterday.Appearance.BackColor2 = Color.Orange;
                btnToday.Appearance.BackColor = Color.LightSteelBlue;
                btnToday.Appearance.BackColor2 = Color.LightSteelBlue;
                if (dt.Select("YT = 'YESTERDAY'").Count() > 0)
                {
                    lblSQMPrs.Text = string.Format("{0:n0}", dt.Compute("SUM(QTY)", "YT='YESTERDAY'")) + " Prs";
                    chartControl1.DataSource = dt.Select("YT = 'YESTERDAY'", "YT,ASY_YMD DESC,TRIP").CopyToDataTable();
                }
                else
                    chartControl1.DataSource = null;
            }
            chartControl1.SeriesDataMember = "DAYDAY";
            chartControl1.SeriesTemplate.ArgumentDataMember = "TRIP";
            chartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "QTY" });
            chartControl1.SeriesTemplate.ArgumentScaleType = ScaleType.Qualitative;
            chartControl1.SeriesTemplate.Label.TextPattern = "{V:#,#}";
            chartControl1.SeriesTemplate.Label.Font = new System.Drawing.Font("Calibri", 12, FontStyle.Regular);
            chartControl1.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram)chartControl1.Diagram).AxisY.Label.TextPattern = "{V:#,#}";
            chartControl1.CrosshairOptions.CrosshairLabelMode = CrosshairLabelMode.ShowForEachSeries;
            chartControl1.SeriesTemplate.CrosshairLabelPattern = "{S}: {V:#,#}";
        }

        private void FRM_POPUP_SQM_TRACKING_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                BindingDataChart(dt,isToday);
        }

        private void btnYesterday_Click(object sender, EventArgs e)
        {
            BindingDataChart(dt, false);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            BindingDataChart(dt, true);
        }

        private void FRM_POPUP_SQM_TRACKING_Load(object sender, EventArgs e)
        {

        }

        private void chartControl1_BoundDataChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chartControl1.Series.Count; i++)
            {
                BarSeriesView view = (BarSeriesView)chartControl1.Series[i].View;
                switch (i)
                { 
                    case 0:
                        view.Color = Color.FromArgb(0,192,0);
                        break;
                    case 1:
                        view.Color = Color.Yellow;
                        break;
                    case 2:
                        view.Color = Color.Red;
                        break;
                    case 3:
                        view.Color = Color.Black;
                        break;
                    case 4:
                        view.Color = Color.Blue;
                        break;
                }
               
                view.FillStyle.FillMode = FillMode.Solid;
              //  ((GradientFillOptionsBase)view.FillStyle.Options).Color2 = Color.Beige;
            }
        }

        public void ShowBeakForm()
        {
            flyoutPanel1.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Default;
            //Cursor = new Cursor(Cursor.Current.Handle);
            //Cursor.Position = new Point(Cursor.Position.X + 40, Cursor.Position.Y);
            flyoutPanel1.ShowBeakForm(Cursor.Position);
            //Cursor.Position = new Point(Cursor.Position.X - 40, Cursor.Position.Y);
            BindingDataChart(dt, isToday);

        }
    }
}
