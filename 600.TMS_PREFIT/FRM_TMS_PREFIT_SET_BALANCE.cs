using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraCharts;

namespace FORM
{
    public partial class FRM_TMS_PREFIT_SET_BALANCE : Form
    {
        string Factory = "";
        string Plant = "";
        string isBottom = "";

        public FRM_TMS_PREFIT_SET_BALANCE(string plant,string fty,string bottom_yn)
        {
            InitializeComponent();
            Plant = plant;
            Factory = fty;            
            isBottom = bottom_yn;

        }
        #region Ora
        private DataTable TMS_PREFIT_SET_BALANCE(string ARG_TYPE, string ARG_PLANT, string ARG_FACTORY, string ARG_IS_BOTTOM)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_PREFIT.TMS_PREFIT_SET_BALANCE";
                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_PLANT";
                MyOraDB.Parameter_Name[2] = "ARG_FACTORY";
                MyOraDB.Parameter_Name[3] = "ARG_IS_BOTTOM";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_TYPE;
                MyOraDB.Parameter_Values[1] = ARG_PLANT;
                MyOraDB.Parameter_Values[2] = ARG_FACTORY;
                MyOraDB.Parameter_Values[3] = ARG_IS_BOTTOM;
                MyOraDB.Parameter_Values[4] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        #endregion
     
        private void btnBack_Click(object sender, EventArgs e)
        {
            //ComVar.Var.callForm = "601"; //Back về form MAIN (SEQ: 600)
            //ComVar.Var.callForm = "back";
            //FRM_TMS_PREFIT_OUTGOING_SHORTAGE
            this.Close();
            

        }

        private void FRM_TMS_PREFIT_SET_BALANCE_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {

                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
                                                                                             // lblTitle.Text = string.Concat(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ComVar.Var._strValue3.ToLower()), " Outgoing Status");
                lblTitle.Text = "Transportation Management System";
                         
                labelControl1.Text = string.Concat("★ ",  " UPSTREAM SET BALANCE ") +  "FACTORY " + Factory ;//ComVar.Var._strValue3,
                labelControl2.Text = string.Concat("★ ", " UPSTREAM SET BALANCE BY CHART " + " FACTORY " + Factory );// ComVar.Var._strValue3,

                BindingData(Plant,Factory,isBottom);
            }
            else
            {
                //Stop stb
            }
        }

        private void BindingData(string Plant, string Factory, string isBottom)
        {
            try
            {
              //  splashScreenManager2.ShowWaitForm();

                DataTable dtLabel = new DataTable();
                DataTable dttemp = new DataTable();
                int col_date = 0;
          

                while (gvwBase.Columns.Count > 0)
                {
                    gvwBase.Columns.RemoveAt(0);
                }
                grdBase.DataSource = null;
                chartControl1.DataSource = null;
                vScrollBar1.Value = 0;
                hScrollBar1.Value = 0;


               
                // grid----
                DataTable dtHeader = TMS_PREFIT_SET_BALANCE("QH", Plant,Factory,  isBottom.Equals("False") ? "0" : "1");
                if (dtHeader != null && dtHeader.Rows.Count > 0)
                {
                    sbHeader(grdBase, gvwBase, dtHeader);
                    DataTable dtData = TMS_PREFIT_SET_BALANCE("Q",Plant, Factory,  isBottom.Equals("False") ? "0" : "1");
                    //binding data//
                    if (dtData != null && dtData.Rows.Count > 0)
                    {
                        for (int i = 0; i < gvwBase.Columns.Count; i++)
                        {
                            if (i > 2)
                            {
                                dttemp.Columns.Add(gvwBase.Columns[i].FieldName, typeof(decimal));
                            }
                            else
                            {
                                dttemp.Columns.Add(gvwBase.Columns[i].FieldName);
                            }

                        }

                        for (int j = 0; j <= dtData.Rows.Count - 1; j++)
                        {
                            if (j <= 1)
                            {
                                dttemp.Rows.Add();
                            }
                            else if (j > 1)
                            {
                                if (dtData.Rows[j]["LINE_NM"].ToString() + dtData.Rows[j]["MLINE"].ToString() != dtData.Rows[j - 1]["LINE_NM"].ToString() + dtData.Rows[j - 1]["MLINE"].ToString())
                                {
                                    dttemp.Rows.Add();
                                }
                            }

                        


                            dttemp.Rows[dttemp.Rows.Count - 1]["LINE_NM"] = dtData.Rows[j]["LINE_NM"].ToString();
                            dttemp.Rows[dttemp.Rows.Count - 1]["MLINE"] = dtData.Rows[j]["MLINE"].ToString();
                            

                            for (int i = 2; i <= dttemp.Columns.Count - 2; i++)
                            {
                                if (dttemp.Columns[i].ColumnName == dtData.Rows[j]["OP_CD"].ToString())
                                {
                                    col_date = i;
                                    break;
                                }

                            }
                            dttemp.Rows[dttemp.Rows.Count - 1][col_date] = dtData.Rows[j]["QTY"].ToString();

                            dttemp.Rows[dttemp.Rows.Count - 1]["SET_QTY"] = dtData.Rows[j]["SET_QTY"].ToString();
                            dttemp.Rows[dttemp.Rows.Count - 1]["SET_RATE"] = dtData.Rows[j]["SET_RATE"].ToString();
                            

                        }
                        dttemp.Rows[0][0] = "Average";
                        grdBase.DataSource = dttemp;
                        sbFormatGrid();

                        //----set chart---


                        //chartControl1.DataSource = dtData;
                        //chartControl1.Series[0].ArgumentDataMember = "LINE_NAME";
                        //chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "PER_CHART" });


                        chartControl1.Series[0].Points.Clear();

                        chartControl1.Series[0].ArgumentScaleType = ScaleType.Qualitative;

                        if (dtData == null) return;
                        for (int i = 0; i <= dtData.Rows.Count - 1; i++)
                        {
                            chartControl1.Series[0].Points.Add(new SeriesPoint(dtData.Rows[i]["LINE_NM"].ToString() + " " + dtData.Rows[i]["MLINE"].ToString(), dtData.Rows[i]["SET_RATE"]));

                            double rate;
                            double.TryParse(dtData.Rows[i]["SET_RATE"].ToString(), out rate); //out

                            if (rate < 70)
                            {
                                chartControl1.Series[0].Points[i].Color = Color.Red;
                            }
                            else if ((rate >= 70) && (rate <= 90))
                            {
                                chartControl1.Series[0].Points[i].Color = Color.Yellow;
                            }
                            else if (rate > 90)
                            {
                                chartControl1.Series[0].Points[i].Color = Color.Green;
                            }
                        }
                    }
                
                }

                #region old

                //if (dtData != null && dtData.Rows.Count > 0)
                //{
                //    //BindingData(dtData1);
                //   // SetChart(dtData1);

                //    //lblDeTotal.Text = string.Concat(string.Format("{0:n0}", dt.Rows[0]["PS_QTY"]), " Prs");

                //    //lblDeD1.Text = string.Concat(string.Format("{0:n0}", dt.Rows[2]["PS_QTY"]), " Prs");
                //    //lblDeD2.Text = string.Concat(string.Format("{0:n0}", dt.Rows[3]["PS_QTY"]), " Prs");
                //    //lblDeD3.Text = string.Concat(string.Format("{0:n0}", dt.Rows[4]["PS_QTY"]), " Prs");
                //}
                //else
                //    ClearTextLabel();
                ////if (dtG != null)
                ////{
                ////    grdBase.DataSource = dtG;

                ////    //FORMAT
                ////    for (int i = 0; i < gvwBase.Columns.Count; i++)
                ////    {
                ////        gvwBase.Columns[i].OptionsColumn.ReadOnly = true;
                ////        gvwBase.Columns[i].OptionsColumn.AllowEdit = false;
                ////        if (i < 1)
                ////            gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                ////        else
                ////            gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                ////        if (i == gvwBase.Columns.Count - 1)
                ////        {
                ////            gvwBase.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                ////            gvwBase.Columns[i].DisplayFormat.FormatString = "#,#";
                ////        }
                ////        gvwBase.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                ////    }
                ////    gvwBase.Columns["MODEL_NM"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                ////    gvwBase.Columns["PFC_PART_NM"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                ////    gvwBase.Columns["PFC_PART_NM"].VisibleIndex = 3;
                ////    gvwBase.Columns["PFC_PART_NO"].VisibleIndex = 4;
                ////    gvwBase.Columns["PS_QTY"].VisibleIndex = 5;
                ////    gvwBase.Columns["PFC_PART_NO"].Visible = ComVar.Var._bValue2;
                ////    gvwBase.Columns["PFC_PART_NM"].Visible = ComVar.Var._bValue2;

                ////}
                ////else
                ////    grdBase.DataSource = null;

                ////if (dtC != null)
                ////{
                ////    chartControl1.DataSource = dtC;
                ////    chartControl1.Series[0].ArgumentDataMember = "LINE_NM";
                ////    chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "PS_QTY" });
                ////}
                ////else
                ////    chartControl1.DataSource = null;
                #endregion old
               // splashScreenManager2.CloseWaitForm();
            }
            catch
            {
               // splashScreenManager2.CloseWaitForm();
            }
        }

       
        private void tmrDate_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
        }
         

        public void sbHeader(GridControl gridControl, BandedGridView gridView, DataTable dt)
        {
            //gridControl.Hide();
            gvwBase.BeginDataUpdate();
            try
            {
                gvwBase.OptionsView.ShowGroupPanel = false;

                gvwBase.Bands.Clear();
                gvwBase.OptionsView.ShowColumnHeaders = false;

                GridBand band = null;

                
                band = new GridBand() { Caption = "Plant" };
                gvwBase.Bands.Add(band);
                band.Columns.Add(new BandedGridColumn() { FieldName = "LINE_NM", Visible = true, Caption = "Plant" });


                band = new GridBand() { Caption = "Mini Line" };
                gvwBase.Bands.Add(band);
                band.Columns.Add(new BandedGridColumn() { FieldName = "MLINE", Visible = true, Caption = "Mini Line" });



                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    band = new GridBand() { Caption = dt.Rows[i]["DIV_INF"].ToString() };
                    gvwBase.Bands.Add(band);
                    band.Columns.Add(new BandedGridColumn() { FieldName = dt.Rows[i]["OP_CD"].ToString(), Visible = true, Caption = dt.Rows[i]["DIV_INF"].ToString() });
                }
                band = new GridBand() { Caption = "Set" };
                gvwBase.Bands.Add(band);
                band.Columns.Add(new BandedGridColumn() { FieldName = "SET_QTY", Visible = true, Caption = "Set" });

                band = new GridBand() { Caption = "%" };
                gvwBase.Bands.Add(band);
                band.Columns.Add(new BandedGridColumn() { FieldName = "SET_RATE", Visible = true, Caption = "%" });

                



                foreach (GridBand gb in gvwBase.Bands)
                {
                    FormatBand(gb);

                }
                gvwBase.OptionsView.ColumnAutoWidth = false;



            }
            catch (Exception EX)
            {
                //throw EX;
            }
            //gridControl.Show();
            gvwBase.EndDataUpdate();
            gvwBase.ExpandAllGroups();
        }
        public void FormatBand(GridBand root)
        {
            root.AppearanceHeader.Options.UseTextOptions = true;
            root.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            root.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            root.AppearanceHeader.Font = new Font("Calibri", 12);
            root.OptionsBand.FixedWidth = true;

            if (root.Children.Count > 0)
            {
                foreach (GridBand child in root.Children)
                {
                    FormatBand(child);
                }
            }
        }
        private void sbFormatGrid()
        {
            // format grid
            for (int i = 0; i < gvwBase.Columns.Count; i++)
            {

                gvwBase.Columns[i].AppearanceCell.Font = new Font("Calibri", 12, FontStyle.Regular);
                gvwBase.Columns[i].AppearanceCell.Options.UseTextOptions = true;

                if (i < 2)
                {
                    gvwBase.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                   
                }
                else 
                {
                    gvwBase.Columns[i].Width = 90;
                    gvwBase.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                }
                if (i < 2)
                {
                    gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

                }
                else if (i >= 2)
                {
                    gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;

                    gvwBase.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gvwBase.Columns[i].DisplayFormat.FormatString = "#,###.##";
                }

                gvwBase.Columns[i].OptionsFilter.AllowFilter = false;
                gvwBase.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                gvwBase.Columns[i].OptionsColumn.AllowEdit = false;
                gvwBase.Columns[i].OptionsColumn.ReadOnly = true;
                gvwBase.BandPanelRowHeight = 40;
                gvwBase.ColumnPanelRowHeight = 40;
                gvwBase.RowHeight = 40;
                gvwBase.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvwBase.Columns["SET_RATE"].DisplayFormat.FormatString = "#,##0.##";
                

                //gvwBase.Columns[i].AppearanceHeader.Fonts

            }

            gvwBase.Columns[0].Width =90 ;
            gvwBase.Columns[1].Width = 90;
          
          
            gvwBase.Columns[gvwBase.Columns.Count - 2].Width = 90;
            gvwBase.Columns[gvwBase.Columns.Count - 1].Width = 90;

            gvwBase.Columns[0].OwnerBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gvwBase.Columns[1].OwnerBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
    


        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

            if (gvwBase.DataRowCount > 0)
            {
                gvwBase.TopRowIndex = (int)(
                          (gvwBase.RowCount)
                          *
                          (1 + (1.0 * vScrollBar1.LargeChange / vScrollBar1.Maximum)) * vScrollBar1.Value / vScrollBar1.Maximum
                         );
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (gvwBase.Columns.Count > 0)
            {
                gvwBase.LeftCoord = (int)(
                          (gvwBase.Columns.Count)
                          *
                          (70 + (1.0 * hScrollBar1.LargeChange / hScrollBar1.Maximum)) * hScrollBar1.Value / hScrollBar1.Maximum
                         );
            }
        }

        private void gvwBase_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            
            try
            {

                string strcolor = gvwBase.GetRowCellDisplayText(e.RowHandle, gvwBase.Columns[0]).ToString();
                if (strcolor.Contains("Average"))
                {
                    e.Appearance.BackColor = Color.Cyan;
                }



                if (e.Column.FieldName.ToString() == "SET_RATE")
                {

                    if (e.CellValue.ToString() != "")
                    {
                        if (double.Parse(e.CellValue.ToString()) > 90)
                        {
                            e.Appearance.BackColor = Color.Green;
                            
                        }
                        else if ((double.Parse(e.CellValue.ToString()) >= 70 ) && (double.Parse(e.CellValue.ToString()) <= 90))
                        {
                            e.Appearance.BackColor = Color.Yellow;
                        }
                        else if (double.Parse(e.CellValue.ToString()) < 70)
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.White;
                        }
                    }

                }


            }
            catch
            {
            }

        }
    }
}
