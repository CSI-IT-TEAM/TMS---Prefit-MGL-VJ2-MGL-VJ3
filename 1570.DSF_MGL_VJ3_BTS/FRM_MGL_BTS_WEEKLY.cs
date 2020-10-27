using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace FORM
{
    public partial class FRM_MGL_BTS_WEEKLY : Form
    {
        public FRM_MGL_BTS_WEEKLY()
        {
            InitializeComponent();
           
        }

        #region Global Variant
        int _iCountReload = 0;
        UC.NavBar nvFactory = new UC.NavBar("Factory");
        UC.NavBar nvBottom = new UC.NavBar("Bottom");
        UC.UC_DWMY DWMY = new UC.UC_DWMY();
        Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        #endregion

        #region Load/Visible Change/ Timer Date
        private void Form_Load(object sender, EventArgs e)
        {
          //  pnHeader.Height = 75;
            pnHeader.BackColor = Color.FromArgb(0, 176, 80);
            pnYMD.Controls.Add(DWMY);
          
            DWMY.OnDWMYClick += DWMYClick;
           
        }
       
        void OnUCMenuClick(string TitleCode,string MenuCode)
        {
            MessageBox.Show(TitleCode + " / " + MenuCode);

        }
        private void Form_VisibleChanged(object sender, EventArgs e)
        {

            if (this.Visible)
            {
                DWMY.YMD_Change(2);
                _iCountReload = 40;
                tmrDate.Start();
                    
            }
            else
                tmrDate.Stop();
           
        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            _iCountReload++;

            if (_iCountReload >= 40)
            {
                BindingDataGrid();
                BindingDataChart();
                _iCountReload = 0;

            }

        }
        #endregion

        #region Ora
        public DataTable SMT_EMD_BTS_MONTHLY_SELECT(string ARG_TYPE, string ARG_DATE, string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_MGL_VJ3.MGL_BTS_WEEK_DATA_SELECT";
                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE";
                MyOraDB.Parameter_Name[2] = "ARG_MLINE";
                MyOraDB.Parameter_Name[3] = "ARG_DATE";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";
                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = ARG_TYPE;
                MyOraDB.Parameter_Values[1] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[2] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[3] = ARG_DATE;
                MyOraDB.Parameter_Values[4] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Function
        #region  Get Config Data From Database
        /// <summary>
        /// Declare _dtnInit
        /// Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        /// </summary>
        private void setConfigForm()
        {
            try
            {
                System.Collections.Generic.Dictionary<string, string> dtnInit = new System.Collections.Generic.Dictionary<string, string>();
                dtnInit = ComVar.Func.getInitForm(ComVar.Var._Frm_Call + this.GetType().Assembly.GetName().Name, this.GetType().Name);

                for (int i = 0; i < dtnInit.Count; i++)
                {
                    setComValue(dtnInit.ElementAt(i).Key, dtnInit.ElementAt(i).Value);
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setConfigForm-->Err:    " + ex.ToString());
            }
        }

        private void setComValue(string obj, string obj_value)
        {
            try
            {
                if (obj.Contains('.'))
                {
                    string[] strSplit = obj.Split('.');
                    Control[] cnt = this.Controls.Find(strSplit[0], true);

                    for (int i = 0; i < cnt.Length; i++)
                    {
                        System.Reflection.PropertyInfo propertyInfo = cnt[i].GetType().GetProperty(strSplit[1]);
                        propertyInfo.SetValue(cnt[i], Convert.ChangeType(obj_value, propertyInfo.PropertyType), null);
                    }
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setComValue (" + obj + ", " + obj_value + ") Err:    " + ex.ToString());
            }

        }
        #endregion 

        #region Method
        private void formatband()
        {
            try
            {
                int n;
                DataTable dtsource = null;

                //SMT_PROD_MONTHLY_SELECT("H", uc_month.GetValue().ToString(), line, mline); //
                dtsource = SMT_EMD_BTS_MONTHLY_SELECT("H", uc_month.GetValue().ToString(), ComVar.Var._strValue1, "");
                if (dtsource != null && dtsource.Rows.Count > 0)
                {
                    bandMon.Caption = dtsource.Rows[0]["MON"].ToString();
                    if (dtsource.Rows.Count > 0)
                    {
                        foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand band in gvwView.Bands[1].Children)
                        {
                            double num;

                            if (double.TryParse(band.Name.Substring(4, 2), out num))
                            {
                                
                                for (int i = 0; i < dtsource.Rows.Count; i++)
                                {
                                    if (band.Name.Contains(dtsource.Rows[i][0].ToString().Substring(dtsource.Rows[i][0].ToString().Length - 2)))
                                    {
                                        band.Visible = true;
                                        if (dtsource.Rows[i]["CAPTION"].ToString().Contains("CURR"))
                                        {
                                            band.AppearanceHeader.BackColor = Color.Salmon;
                                            band.AppearanceHeader.BackColor2 = Color.Salmon;
                                            band.AppearanceHeader.ForeColor = Color.White;
                                           
                                        }
                                        else
                                        {
                                            band.AppearanceHeader.BackColor = Color.FromArgb(197, 224, 180);
                                            band.AppearanceHeader.BackColor2 = Color.FromArgb(197, 224, 180);
                                            band.AppearanceHeader.ForeColor = Color.Black;
                                        }

                                        band.Caption = dtsource.Rows[i]["CAPTION"].ToString().Replace("_", "\n").Replace("CURR","");
                                        band.RowCount = 2;
                                        band.AppearanceHeader.Font = new Font("Calibri", 18, FontStyle.Bold);
                                        break;
                                    }
                                    if (i == dtsource.Rows.Count - 1)
                                    {
                                        band.Visible = false;
                                    }
                                }
                            }
                        }
                    }
                    //bandDate.Width = 140;
                    //bandAVG.Width = 80;
                    //bandMon.Width = (grdView.Width - 220) / dtsource.Rows.Count;
                    //gvwView.OptionsView.ColumnAutoWidth = false;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        //private void BindingDataChart()
        //{
        //    try
        //    {
        //        DataTable dt = SMT_EMD_BTS_MONTHLY_SELECT("C", uc_month.GetValue().ToString(), ComVar.Var._strValue1, "");
        //        ChartVSM.DataSource = dt;
        //        ChartVSM.Series[0].ArgumentDataMember = "DD";
        //        ChartVSM.Series[0].ValueDataMembers.AddRange(new string[] { "VJ1" });
        //        ChartVSM.Series[1].ArgumentDataMember = "DD";
        //        ChartVSM.Series[1].ValueDataMembers.AddRange(new string[] { "VJ2" });
        //    }
        //    catch { }
        //}

        private void BindingDataChart()
        {
            try
            {
                DataTable dt = SMT_EMD_BTS_MONTHLY_SELECT("C", uc_month.GetValue().ToString(), ComVar.Var._strValue1, "");
                DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
                ChartVSM.DataSource = dt;
                ChartVSM.SeriesDataMember = "DIV";
                ChartVSM.SeriesTemplate.ArgumentDataMember = "YMD";
                ChartVSM.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "BTS" });
                ChartVSM.SeriesTemplate.View = lineSeriesView1;
                ChartVSM.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;

            }
            catch { }
        }

        private void BindingDataGrid()
        {
            try
            {
                //grdView.ShowLoadingPanel();
                //grdViewB1.ShowLoadingPanel();
                DataTable dt = SMT_EMD_BTS_MONTHLY_SELECT("Q", uc_month.GetValue().ToString(), ComVar.Var._strValue1, "");
                grdView.DataSource =  dt;
                formatband();
                FormatGrid();
                //FormatGridB();
                //grdView.HideLoadingPanel();
                //grdViewB1.HideLoadingPanel();
            }
            catch { }
            finally
            { 
            //BindingSummary();
            }
        }

        private void BindingSummary()
        { 
            //try
            //{ 
            //DataTable dt = SP_SMT_EMD_GRID_DATA_SELECT("ALL", "VJ");
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    lblDplan_Qty.Text = string.Format("{0:0,0}", dt.Rows[0]["D_PLAN"]);
            //    lblRplan_Qty.Text = string.Format("{0:0,0}", dt.Rows[0]["R_PLAN"]);
            //    lblAct_Qty.Text   = string.Format("{0:0,0}", dt.Rows[0]["PROD"]);
            //    lblPRate_Per.Text = string.Format("{0:0.0}", dt.Rows[0]["P_RATE"]);
            //}
            //    }
            //catch { }
        }
        private void FormatGrid()
        {
            try
            {

                for (int i = 0; i < gvwView.Columns.Count; i++)
                {

                    gvwView.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvwView.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                    gvwView.Columns[i].OptionsColumn.ReadOnly = true;
                    gvwView.Columns[i].OptionsColumn.AllowEdit = false;
                    gvwView.Columns[i].OptionsFilter.AllowFilter = false;
                    gvwView.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    gvwView.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 18, FontStyle.Regular);
                    gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    if (i > 0)
                    {
                        gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        gvwView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gvwView.Columns[i].DisplayFormat.FormatString = "#,0.##";
                    }
                }
                gvwView.Columns["DIV"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

            }
            catch (Exception ex)
            { }
        }
        private void FormatGridB()
        {
            //try
            //{
            //    grdViewB1.BeginUpdate();
            //    for (int i = 0; i < grdViewB1.Columns.Count; i++)
            //    {

            //        grdViewB1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //        grdViewB1.Columns[i].AppearanceCell.Options.UseTextOptions = true;
            //        grdViewB1.Columns[i].OptionsColumn.ReadOnly = true;
            //        grdViewB1.Columns[i].OptionsColumn.AllowEdit = false;
            //        grdViewB1.Columns[i].OptionsFilter.AllowFilter = false;
            //        grdViewB1.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            //        grdViewB1.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 14f, FontStyle.Regular ^ FontStyle.Bold);
            //        grdViewB1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //        if (i > 0)
            //        {
            //            grdViewB1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            //            grdViewB1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //            grdViewB1.Columns[i].DisplayFormat.FormatString = "#,0.##";
            //        }
            //    }
            //    grdViewB1.Columns["DIV"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            //    grdViewB1.EndUpdate();
            //}
            //catch (Exception ex)
            //{ }
        }
        private void gvw_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //try
            //{
            //    if (e.RowHandle < 0)
            //        return;
            //    if (grdView.GetRowCellValue(e.RowHandle, grdView.Columns["DIV"]).ToString().Contains("PLAN"))
            //       e.Appearance.BackColor = Color.FromArgb(228, 255, 211);
            //    if (grdView.GetRowCellValue(e.RowHandle, grdView.Columns["DIV"]).ToString().Contains("R.PLAN"))
            //        e.Appearance.BackColor = Color.White;
            //    if (grdView.GetRowCellValue(e.RowHandle, grdView.Columns["DIV"]).ToString().Contains("PROD"))
            //        e.Appearance.BackColor = Color.FromArgb(214, 252, 246);
            //    if (grdView.GetRowCellValue(e.RowHandle, grdView.Columns["DIV"]).ToString().Contains("D.RATE"))
            //        e.Appearance.BackColor = Color.FromArgb(252, 231, 207);
            //    if (grdView.GetRowCellValue(e.RowHandle, grdView.Columns["DIV"]).ToString().Contains("P.RATE"))
            //        //e.Appearance.BackColor = Color.White;

            //    if (e.CellValue.ToString().Contains("GREEN"))
            //    {
            //        { e.Appearance.BackColor = Color.LimeGreen; e.Appearance.ForeColor = Color.White;
            //         e.Appearance.BackColor2 = Color.LimeGreen; 
            //        }
            //    }
            //    if (e.CellValue.ToString().Contains("YELLOW"))
            //    {
            //        e.Appearance.BackColor = Color.Yellow; e.Appearance.BackColor2 = Color.Yellow; e.Appearance.ForeColor = Color.Black;
            //    }
            //    if (e.CellValue.ToString().Contains("RED"))
            //    {
            //        e.Appearance.BackColor = Color.Red; e.Appearance.BackColor2 = Color.Red; e.Appearance.ForeColor = Color.White;
            //    }
            //    if (e.CellValue.ToString().Contains("GREY"))
            //    {
            //        e.Appearance.BackColor = Color.SlateGray; e.Appearance.BackColor2 = Color.SlateGray;
            //    }

            //}
            //catch (Exception ex)
            //{

            //}
        }

        #endregion

        #endregion

        #region Event
        void DWMYClick(string argButtonText, string argButtonTag)
        {
            ComVar.Var.callForm = argButtonTag;
        }

        private void menuEvent_Click(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            ComVar.Var.callForm = cnt.Tag == null ? "" : cnt.Tag.ToString();
        }
        
        #endregion

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void uc_month_ValueChangeEvent(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            BindingDataGrid(); BindingDataChart();
            this.Cursor = Cursors.Default;
        }

        private void gvwView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (gvwView.GetRowCellValue(e.RowHandle, "DIV").ToString().Equals("VJ"))
            {
                e.Appearance.BackColor = Color.FromArgb(241, 255, 211); e.Appearance.BackColor2 = Color.FromArgb(241, 255, 211); e.Appearance.ForeColor = Color.Black;
            }
            if (e.CellValue.ToString().Contains("GREEN"))
            {
                {
                    e.Appearance.BackColor = Color.LimeGreen; e.Appearance.ForeColor = Color.White;
                    e.Appearance.BackColor2 = Color.LimeGreen;
                }
            }
            if (e.CellValue.ToString().Contains("YELLOW"))
            {
                e.Appearance.BackColor = Color.Yellow; e.Appearance.BackColor2 = Color.Yellow; e.Appearance.ForeColor = Color.Black;
            }
            if (e.CellValue.ToString().Contains("RED"))
            {
                e.Appearance.BackColor = Color.Red; e.Appearance.BackColor2 = Color.Red; e.Appearance.ForeColor = Color.White;
            }
            if (e.CellValue.ToString().Contains("GREY"))
            {
                e.Appearance.BackColor = Color.SlateGray; e.Appearance.BackColor2 = Color.SlateGray;
            }
            if (e.CellValue.ToString().Contains("NAVY"))
            {
                e.Appearance.BackColor = Color.Navy; e.Appearance.BackColor2 = Color.Navy; e.Appearance.ForeColor = Color.White;
            }
        }

    }
}
