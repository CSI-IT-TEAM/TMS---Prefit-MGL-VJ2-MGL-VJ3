using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace MAIN
{
    public partial class FRM_MOLD_COATING : Form
    {
        public FRM_MOLD_COATING()
        {
            InitializeComponent();
        }
        #region Variable
        int iCount = 0;
       
        #endregion
        #region Db
        public DataTable SMT_MOLD_COATING_SELECT(string ARG_TYPE, string ARG_DATE1, string ARG_DATE2, string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "PKG_SPB_MOLD_SHOP.SP_SMT_MOLD_COATING_SEL";
                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE";
                MyOraDB.Parameter_Name[2] = "ARG_MLINE";
                MyOraDB.Parameter_Name[3] = "ARG_DATE1";
                MyOraDB.Parameter_Name[4] = "ARG_DATE2";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";
                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = ARG_TYPE;
                MyOraDB.Parameter_Values[1] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[2] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[3] = ARG_DATE1;
                MyOraDB.Parameter_Values[4] = ARG_DATE2;
                MyOraDB.Parameter_Values[5] = "";


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

        private void btnBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "62";
        }

        private void FRM_MOLD_COATING_Load(object sender, EventArgs e)
        {
            dtpDate1.EditValue = DateTime.Now.AddDays(-7);
            dtpDate2.EditValue = DateTime.Now;
        }
       
        private void BindingData()
        {
            try
            {


                this.Cursor = Cursors.WaitCursor;
                 //DateTime date1 = new DateTime(dtpDate1.DateTime.Year, dtpDate1.DateTime.Month,dtpDate1.DateTime.Day, dtpDate1.DateTime.Hour, dtpDate1.DateTime.Minute, dtpDate1.DateTime.Second); 
                 //DateTime date2 = new DateTime(dtpDate2.DateTime.Year, dtpDate2.DateTime.Month,dtpDate2.DateTime.Day, dtpDate2.DateTime.Hour, dtpDate2.DateTime.Minute, dtpDate2.DateTime.Second);
                 //if (DateTime.Compare(date1, date2) <= 0)
                 //{
                 //    MessageBox.Show("Kiểm tra lại Ngày tháng");
                 //    return;
                 //}


                DataTable dt = SMT_MOLD_COATING_SELECT("Q", dtpDate1.DateTime.ToString("yyyyMMdd"), dtpDate2.DateTime.ToString("yyyyMMdd"), ComVar.Var._strValue1, ComVar.Var._strValue2);
                    grdBase.DataSource = dt;
                    FormatGrid();
               
            }
            catch { }
            finally { this.Cursor = Cursors.Default; }
        }

        private void FormatGrid()
        {
            try
            {
                grdView.BeginUpdate();
                for (int i = 0; i < grdView.Columns.Count; i++)
                {

                    grdView.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    grdView.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                    grdView.Columns[i].OptionsColumn.ReadOnly = true;
                    grdView.Columns[i].OptionsColumn.AllowEdit = false;
                    grdView.Columns[i].OptionsFilter.AllowFilter = false;
                    grdView.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    grdView.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 18, FontStyle.Bold);
                    grdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    //if (i > 0)
                    //{
                    //    grdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    //    grdView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    //    grdView.Columns[i].DisplayFormat.FormatString = "#,0.##";
                    //}
                }

              //grdView.SetRowCellValue(0, "DIV", "D.Plan (Prs)");
                grdView.Columns["MODEL_NM"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                grdView.Columns["QTY"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                grdView.Columns["QTY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdView.Columns["QTY"].DisplayFormat.FormatString = "#,0.##";
                grdView.Columns["COSTING"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                grdView.Columns["COSTING"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdView.Columns["COSTING"].DisplayFormat.FormatString = "#,0.##";
                grdView.Columns["TOTAL_USD"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                grdView.Columns["TOTAL_USD"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdView.Columns["TOTAL_USD"].DisplayFormat.FormatString = "#,0.##";
                grdView.EndUpdate();
            }
            catch (Exception ex)
            { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            iCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (iCount >= 30)
            {
                BindingData(); iCount = 0;
            }
        }

        private void FRM_MOLD_COATING_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                dtpDate1.EditValue = DateTime.Now.AddDays(-7);
                dtpDate2.EditValue = DateTime.Now;
                iCount = 29;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void sbtnSearch_Click(object sender, EventArgs e)
        {
            BindingData();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
