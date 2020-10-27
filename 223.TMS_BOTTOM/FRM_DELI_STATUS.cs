using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DevExpress.XtraCharts;
using DevExpress.Utils;

namespace FORM
{
    public partial class FRM_DELI_STATUS : Form
    {
        public FRM_DELI_STATUS()
        {
            InitializeComponent();
        }

        #region Animation
        const int AW_SLIDE = 0X40000;
        const int AW_HOR_POSITIVE = 0X1;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_BLEND = 0X80000;

        [DllImport("user32")]

        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);
        #endregion

        #region Variable
        DataSet ds = new DataSet();
        int iCount = 0;
        #endregion
        private DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Value1", typeof(int));
            table.Columns.Add("Value2", typeof(int));
            table.Columns.Add("Value3", typeof(int));
            table.Columns.Add("Value4", typeof(int));
            table.Columns.Add("Name", typeof(string));
            Random r = new Random();

            // Here we add DataRows.
            for (int i = 0; i < 5; i++)
            {
                table.Rows.Add(r.Next(10, 100), r.Next(10, 100), r.Next(10, 100), r.Next(10, 100), "DAY " + (i + 1).ToString());
            }

            return table;
        }

        private void GetData()
        {
            DatabaseTMS db = new DatabaseTMS();
            ds = db.TMS_DELIVERY_GETDATA("MES.PKG_TMS_DASHBOARD.TMS_DELIVERY_SEL", "VJ", "20190927", ComVar.Var._strValue1);
            BindingDataInfoTop(); //LẤY DỮ LIỆU CHO INFO TOP
            
            GetChartComponentByStyle(true); //LẤY DỮ LIỆU CHO CHART COMPONENT SET BY STYLE.
            GetChartRatoComponentByStyle(true);
            GetChartShortageByComponent();
            GetChartShortageByAsyDate();
        }

        //1 
        private void BindingDataInfoTop()
        {
            try
            {
                lblOSPlan.Text = "0 Prs";
                lblOSInv.Text = "0 Prs";
                lblOSLT.Text = "0 Day(s)";
                lblSTKInv.Text = "0 Prs";
                lblWSLT.Text = "0 Day(s)";
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblOSPlan.Text = string.Format("{0:n0}", dt.Rows[0]["PLAN_QTY"]) + " Prs";
                    lblOSInv.Text = string.Format("{0:n0}", dt.Rows[0]["WIP_QTY"]) + " Prs";
                    lblOSLT.Text = Convert.ToDouble(dt.Rows[0]["LT"]).ToString() + " Day(s)";
                    lblSTKInv.Text = string.Format("{0:n0}", dt.Rows[0]["STK_INV"]) + " Prs";
                    lblWSLT.Text = Convert.ToDouble(dt.Rows[0]["LT_STK"]).ToString() + " Day(s)";
                }
            }
            catch { }
        }
        //2-3
        private void GetChartComponentByStyle(bool isStockfit)
        {
            try
            {
                chartControl3.DataSource = isStockfit? ds.Tables[1]:ds.Tables[2];
                chartControl3.SeriesDataMember = "COMP_NM";
                chartControl3.SeriesTemplate.ArgumentDataMember = "STYLE_CD";
                chartControl3.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "PCARD_QTY" });
                chartControl3.SeriesTemplate.Label.TextPattern = "{S}: {V:#,#}";
                chartControl3.SeriesTemplate.Label.Font = new System.Drawing.Font("Calibri", 11, FontStyle.Bold);
                chartControl3.CrosshairOptions.CrosshairLabelMode = CrosshairLabelMode.ShowCommonForAllSeries;
                chartControl3.SeriesTemplate.CrosshairLabelPattern = "{S}: {V:#,#}";
                chartControl3.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
                chartControl3.SeriesTemplate.Label.TextOrientation = TextOrientation.BottomToTop;
                chartControl3.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
                ((XYDiagram)chartControl3.Diagram).AxisY.Title.Visibility = DefaultBoolean.True;
                ((XYDiagram)chartControl3.Diagram).AxisY.Title.Text = "Prs";
            }
            catch { }
        }

        //4-5
        private void GetChartRatoComponentByStyle(bool isStockfit)
        {
            try
            {
                chartControl2.DataSource = isStockfit? ds.Tables[3] : ds.Tables[4];
                chartControl2.Series[0].ArgumentDataMember = "STYLE_CD";
                chartControl2.Series[0].ValueDataMembers.AddRange(new string[] { "RATIO" });
            }
            catch { }
        }


        private void GetChartShortageByComponent()
        {
            try
            {
                //out_cursor6
                chartControl4.DataSource = ds.Tables[5];
                chartControl4.Series[0].ArgumentDataMember = "CMP_CD";
                chartControl4.Series[0].ValueDataMembers.AddRange(new string[] { "PL" });
                chartControl4.Series[1].ArgumentDataMember = "CMP_CD";
                chartControl4.Series[1].ValueDataMembers.AddRange(new string[] { "SHR" });
            }
            catch (Exception ex)
            { }
        }
        private void GetChartShortageByAsyDate()
        {
            try
            {
                chartControl5.DataSource = ds.Tables[6];
                chartControl5.SeriesDataMember = "DIV";
                chartControl5.SeriesTemplate.ArgumentDataMember = "ASY_YMD";
                chartControl5.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "QTY" });
                chartControl5.SeriesTemplate.Label.TextPattern = "{S}: {V:#,#}";
                chartControl5.SeriesTemplate.Label.Font = new System.Drawing.Font("Calibri", 11, FontStyle.Bold);
                chartControl5.CrosshairOptions.CrosshairLabelMode = CrosshairLabelMode.ShowCommonForAllSeries;
                chartControl5.SeriesTemplate.CrosshairLabelPattern = "{S}: {V:#,#}";
                
                chartControl5.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                chartControl5.SeriesTemplate.Label.TextOrientation = TextOrientation.Horizontal;
                
                chartControl5.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
                ((XYDiagram)chartControl5.Diagram).AxisY.Title.Visibility = DefaultBoolean.True;
                ((XYDiagram)chartControl5.Diagram).AxisY.Title.Text = "Prs";
            }
            catch { }
        }

        //private void BindingDataGrid()
        //{
        //    try
        //    {
        //        DatabaseTMS db = new DatabaseTMS();
        //        DataTable dt = db.GetDeliveryDetail("VJ", "20190927", ComVar.Var._strValue1);
        //        gridControl1.DataSource = dt;
        //        for (int i = 0; i < gridView1.Columns.Count; i++)
        //        {
        //            gridView1.Columns[i].OptionsColumn.ReadOnly = true;
        //            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
        //            if (gridView1.Columns[i].FieldName == "STYLE_CD")
        //            {
        //                gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
        //            }
        //            else
        //            {
        //                gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
        //            }
        //            if (i > 1)
        //            {
        //                gridView1.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
        //                gridView1.Columns[i].DisplayFormat.FormatString = "#,#";
        //            }
        //            gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
        //        }
        //        gridView1.Columns["COMP_NM"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
        //        gridView1.Columns["STYLE_CD"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
        //    }
        //    catch { }
        //}

        private void btnBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "223";
        }



        private void BindingChart()
        {
            
            try
            {
                //XONG CHART 3
                chartControl3.DataSource = GetTable();
                chartControl3.Series[0].ArgumentDataMember = "Name";
                chartControl3.Series[0].ValueDataMembers.AddRange(new string[] { "Value1" });
                chartControl3.Series[1].ArgumentDataMember = "Name";
                chartControl3.Series[1].ValueDataMembers.AddRange(new string[] { "Value2" });
                chartControl3.Series[2].ArgumentDataMember = "Name";
                chartControl3.Series[2].ValueDataMembers.AddRange(new string[] { "Value3" });
             
            }
            catch { }
            try
            {
                chartControl2.DataSource = GetTable();
                chartControl2.Series[0].ArgumentDataMember = "Name";
                chartControl2.Series[0].ValueDataMembers.AddRange(new string[] { "Value1" });
            }
            catch { }

            try
            {
                chartControl5.DataSource = GetTable();
                chartControl5.Series[0].ArgumentDataMember = "Name";
                chartControl5.Series[0].ValueDataMembers.AddRange(new string[] { "Value1" });

            }
            catch { }
            try
            {
                //chartControl4.DataSource = GetTable();
                //chartControl4.Series[0].ArgumentDataMember = "Name";
                //chartControl4.Series[0].ValueDataMembers.AddRange(new string[] { "Value1" });
                //chartControl4.Series[1].ArgumentDataMember = "Name";
                //chartControl4.Series[1].ValueDataMembers.AddRange(new string[] { "Value2" });

            }
            catch { }

            try
            {
                //chartControl1.DataSource = GetTable();
                //chartControl1.Series[0].ArgumentDataMember = "Name";
                //chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "Value3" });
                //chartControl1.Series[1].ArgumentDataMember = "Name";
                //chartControl1.Series[1].ValueDataMembers.AddRange(new string[] { "Value2" });
            }
            catch { }
          

        }

        private void FRM_DELI_STATUS_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
            //Button Stockfit mặc định được nhấn đầu tiên.
            btnStockfit.Appearance.BackColor = Color.Orange;
            btnStockfit.Appearance.BackColor2 = Color.Orange;
            btnUpper.Appearance.BackColor = Color.LightSteelBlue;
            btnUpper.Appearance.BackColor2 = Color.LightSteelBlue;
        }
        private void labelControl1_DoubleClick(object sender, EventArgs e)
        {

            GetData();
            BindingChart();
           
        }

        private void FRM_DELI_STATUS_VisibleChanged(object sender, EventArgs e)
        {
          
            if (this.Visible)
            {
                splashScreenManager1.ShowWaitForm();
                lblTitle.Text = "OUTSOLE TMS - " +ComVar.Var._strValue2+ " DELIVERY STATUS";
                //GetData();
                iCount = 30;
                tmrDate.Start();
                splashScreenManager1.CloseWaitForm();
               
            }
            else
            { tmrDate.Stop(); }
           
        }

        private void btnDetailSet_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DatabaseTMS db = new DatabaseTMS();
            DataTable dt = db.GetDeliveryDetail("VJ","20190927",ComVar.Var._strValue1);
            FRM_POPUP_SQM_TRACKING_BT POPUP = new FRM_POPUP_SQM_TRACKING_BT(((DevExpress.XtraEditors.SimpleButton)sender), dt,true);
            POPUP.ShowBeakForm();
            this.Cursor = Cursors.Default;
        }

        private void btnStockfit_Click(object sender, EventArgs e)
        {
          //  lblYesterday_Label.BackColor = Color.Transparent;
            btnStockfit.Appearance.BackColor = Color.Orange;
            btnStockfit.Appearance.BackColor2 = Color.Orange;
            btnUpper.Appearance.BackColor = Color.LightSteelBlue;
            btnUpper.Appearance.BackColor2 = Color.LightSteelBlue;
            this.Cursor = Cursors.WaitCursor;
            splashScreenManager1.ShowWaitForm();
           // BindingChart1(dsToday, 1);
            GetChartComponentByStyle(true);
            GetChartRatoComponentByStyle(true);
           // cCount = 0;
            splashScreenManager1.CloseWaitForm();
            this.Cursor = Cursors.Default;
        }

        private void btnUpper_Click(object sender, EventArgs e)
        {
            //  lblYesterday_Label.BackColor = Color.Transparent;
            btnUpper.Appearance.BackColor = Color.Orange;
            btnUpper.Appearance.BackColor2 = Color.Orange;
            btnStockfit.Appearance.BackColor = Color.LightSteelBlue;
            btnStockfit.Appearance.BackColor2 = Color.LightSteelBlue;
            this.Cursor = Cursors.WaitCursor;
             splashScreenManager1.ShowWaitForm();
            // BindingChart1(dsToday, 1);
             GetChartComponentByStyle(false);
             GetChartRatoComponentByStyle(false);
            // cCount = 0;
             splashScreenManager1.CloseWaitForm();
            this.Cursor = Cursors.Default;
        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
                iCount++;
                if (iCount >= 30)
                {
                    splashScreenManager1.ShowWaitForm();
                    GetData();
                    iCount = 0;
                    splashScreenManager1.CloseWaitForm();

                }
            }
            catch { iCount = 0; }
          
        }
    }
}
