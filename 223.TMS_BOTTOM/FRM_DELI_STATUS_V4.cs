using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using System.Globalization;

namespace FORM
{
    public partial class FRM_DELI_STATUS_V4 : Form
    {
        public FRM_DELI_STATUS_V4()
        {
            InitializeComponent();
        }
        int iCount = 0;
        DataSet ds = new DataSet();
        private void FRM_DELI_STATUS_V3_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                splashScreenManager1.ShowWaitForm();
                lblTitle.Text = "OUTSOLE TMS - " + ComVar.Var._strValue2 + " DELIVERY STATUS";
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
                
                iCount = 60;
                tmrDate.Start();
                splashScreenManager1.CloseWaitForm();

            }
            else
            { tmrDate.Stop(); }
        }

        private void GetDataGridSetBalanceChart()
        {
            DatabaseTMS db = new DatabaseTMS();
            try
            {
                lblOS_SetAVG.Text ="0%";
                DataTable dt = db.GetDeliveryDetail("VJ", "NoNeed", ComVar.Var._strValue1);
                if (dt != null && dt.Rows.Count>0)
                    lblOS_SetAVG.Text = Math.Round(Convert.ToDouble(dt.Compute("AVG(RATIO)", "")),1).ToString() + "%";
               
                gridControl4.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    gridView4.Columns[i].OptionsColumn.ReadOnly = true;
                    gridView4.Columns[i].OptionsColumn.AllowEdit = false;
                    if (gridView4.Columns[i].FieldName == "STYLE_CD")
                    {
                        gridView4.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    }
                    else
                    {
                        gridView4.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    }
                    if (i > 1)
                    {
                        gridView4.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                        gridView4.Columns[i].DisplayFormat.FormatString = "#,#";
                    }
                    gridView4.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                }
                gridView4.Columns["COMP_NM"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                gridView4.Columns["STYLE_CD"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

                //BindingChart
                chartControl3.DataSource = dt;
                chartControl3.SeriesDataMember = "COMP_NM";
                chartControl3.SeriesTemplate.ArgumentDataMember = "STYLE_CD";
                chartControl3.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "RATIO" });
                chartControl3.SeriesTemplate.Label.TextPattern = "{S}: {V:#,#}";
                chartControl3.SeriesTemplate.Label.Font = new System.Drawing.Font("Calibri", 11, FontStyle.Bold);
                chartControl3.CrosshairOptions.CrosshairLabelMode = CrosshairLabelMode.ShowCommonForAllSeries;
                chartControl3.SeriesTemplate.CrosshairLabelPattern = "{S}: {V:#,#}";

              //  chartControl3.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
               // chartControl3.SeriesTemplate.Label.TextOrientation = TextOrientation.Horizontal;

                chartControl3.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
                ((XYDiagram)chartControl3.Diagram).AxisY.Title.Visibility = DefaultBoolean.True;
                ((XYDiagram)chartControl3.Diagram).AxisY.Title.Text = "Percentage";
            }
            catch(Exception ex) { }
        }

        private void GetDataOutgoing_Chart()
        {
            DatabaseTMS db = new DatabaseTMS();
            DataTable dtTemp = new DataTable();
            DataTable dt =  db.GetOutScnByDay("VJ", "OS", DateTime.Now.ToString("yyyyMMdd"), ComVar.Var._strValue1);
            lblOS_Outgoing.Text = "0 Prs";
            if (dt.Rows.Count>0)
                lblOS_Outgoing.Text =string.Format("{0:n0}", dt.Rows[dt.Rows.Count-1]["O_QTY"]) + " Prs";

            if (dt.Select("DAYDAY IS NOT NULL").Count() > 0)
            {
                dtTemp = dt.Select("DAYDAY IS NOT NULL","DD").CopyToDataTable();
            }
            chartControl1.DataSource = dtTemp;
            chartControl1.Series[0].ArgumentDataMember = "DAYDAY";
            chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "O_QTY" });

        }



        private void GetDataOutgoing_Grid()
        { 
            DataTable dt = ds.Tables[1];
            gridControl1.DataSource = dt;
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].OptionsColumn.ReadOnly = true;
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                if (i < 2)
                    gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                else
                    gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                if (i > 2)
                {
                    gridView1.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                    gridView1.Columns[i].DisplayFormat.FormatString = "#,#";
                }
                gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            }
            gridView1.Columns["DAYDAY"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gridView1.Columns["STYLE_CD"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gridView1.Columns["MODEL"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
        }

        private void GetDataINV_Chart()
        {
            try
            {
                DatabaseTMS db = new DatabaseTMS();
                DataTable dtTemp = new DataTable();
                DataTable dtLabel = new DataTable();
                lblOS_INV.Text = "0 Prs";
                int InvQty = 0;
                DataTable dt = ds.Tables[2];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Select("STYLE_CD <> 'TOTAL'").Count() > 0)
                        dtTemp = dt.Select("STYLE_CD <> 'TOTAL'").CopyToDataTable();

                    if (dt.Select("STYLE_CD = 'TOTAL'").Count() > 0)
                    {
                        dtLabel = dt.Select("STYLE_CD = 'TOTAL'").CopyToDataTable();
                        for (int i = 0; i < dtLabel.Rows.Count; i++)
                        {
                            InvQty += Convert.ToInt32(dtLabel.Rows[i]["WIP_QTY"]);
                        }
                    }

                    lblOS_INV.Text = string.Format("{0:n0}", InvQty) + " Prs";
                }
                chartControl2.DataSource = dtTemp;
                chartControl2.Series[0].ArgumentDataMember = "STYLE_CD";
                chartControl2.Series[0].ValueDataMembers.AddRange(new string[] { "WIP_QTY" });

                gridControl2.DataSource = dt;
                for (int i = 0; i < gridView2.Columns.Count; i++)
                {
                    gridView2.Columns[i].OptionsColumn.ReadOnly = true;
                    gridView2.Columns[i].OptionsColumn.AllowEdit = false;
                    if (i < 2)
                        gridView2.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    else
                        gridView2.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    if (i > 1)
                    {
                        gridView2.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                        gridView2.Columns[i].DisplayFormat.FormatString = "#,#";
                    }
                    gridView2.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                }
                gridView2.Columns["STYLE_CD"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                gridView2.Columns["MODEL"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;


            }
            catch (Exception ex) { chartControl2.DataSource = null; gridControl2.DataSource = null; }
        }

        private void GetChartShortageByComponent()
        {
            try
            {
                gridControl3.DataSource = ds.Tables[4];
                for (int i = 0; i < gridView3.Columns.Count; i++)
                {
                    gridView3.Columns[i].OptionsColumn.ReadOnly = true;
                    gridView3.Columns[i].OptionsColumn.AllowEdit = false;
                    if (i < 2)
                        gridView3.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    else
                        gridView3.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    if (i > 2)
                    {
                        gridView3.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                        gridView3.Columns[i].DisplayFormat.FormatString = "#,#";
                    }
                    gridView3.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                }
                gridView3.Columns["ASY_YMD"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                gridView3.Columns["STYLE_CD"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                gridView3.Columns["MODEL"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                lblPlan_Qty.Text = "0 Prs";
                lblSHR_Qty.Text = "0 Prs";
                if (ds.Tables[4].Rows.Count > 0)
                {
                    lblPlan_Qty.Text = string.Format("{0:n0}", ds.Tables[4].Rows[ds.Tables[4].Rows.Count - 1]["PLAN_QTY"]) + " Prs";
                    lblSHR_Qty.Text = string.Format("{0:n0}", ds.Tables[4].Rows[ds.Tables[4].Rows.Count - 1]["SHR_QTY"]) + " Prs";
                }
            }
            catch (Exception ex)
            { }
        }
        private void GetChartShortageByAsyDate()
        {
            try
            {
                chartControl5.DataSource = ds.Tables[5];
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
        private void GetData()
        {
            DatabaseTMS db = new DatabaseTMS();
            GetDataGridSetBalanceChart();
            ds = db.TMS_DELIVERY_DETAIL("MES.PKG_TMS_DASHBOARD.TMS_DELIVERY_DETAIL", "VJ", "20190927", ComVar.Var._strValue1);
            GetDataOutgoing_Chart(); GetDataOutgoing_Grid();
            GetDataINV_Chart();
            GetChartShortageByAsyDate(); GetChartShortageByComponent();
        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
                iCount++;
                if (iCount >= 60)
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormCaption("Load " + ComVar.Var._strValue2);
                    GetData();
                    iCount = 0;
                    splashScreenManager1.CloseWaitForm();

                }
            }
            catch { iCount = 0; }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "223";
        }

        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string tomau_row_g = gridView2.GetRowCellDisplayText(e.RowHandle, "STYLE_CD");

            if (tomau_row_g.Contains("TOTAL"))
            {
                e.Appearance.BackColor = Color.FromArgb(255, 255, 214);

            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string tomau_row_g = gridView1.GetRowCellDisplayText(e.RowHandle, "STYLE_CD");

            if (tomau_row_g.Contains("TOTAL"))
            {
                e.Appearance.BackColor = Color.FromArgb(255, 255, 214);

            }
        }

        private void gridView3_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string tomau_row_g = gridView3.GetRowCellDisplayText(e.RowHandle, "ASY_YMD");

            if (tomau_row_g.Contains("TOTAL"))
            {
                e.Appearance.BackColor = Color.FromArgb(255, 255, 214);

            }
        }
    }
}
