using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace FORM
{
    public partial class FRM_BT_SET_BALANCE : Form
    {
        public FRM_BT_SET_BALANCE()
        {
            InitializeComponent();
        }
        int cCount = 0;
        DataTable data_set_bl = null;
        private System.Data.DataSet Select_Ora_Grid_Set()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_VC_TO_LT_V1.SP_TMS_VC_TO_LT_SET";
                //ARGMODE
                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "CV_1";


                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.Cursor;
                // MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = "";
                MyOraDB.Parameter_Values[1] = "";
                // MyOraDB.Parameter_Values[3] = "";
                // MyOraDB.Parameter_Values[3] = "";


                MyOraDB.Add_Select_Parameter(true);

                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret;


            }
            catch
            {
                return null;
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "342";
        }

        private void FRM_BT_SET_BALANCE_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
                cCount = 60;
                tmrLoad.Start();
            }
            else
            {
                tmrLoad.Stop();
            }
        }
        private void BindingData()
        {
            data_set_bl = Select_Ora_Grid_Set().Tables[0];
            grdBase_set.DataSource = data_set_bl;

            for (int i = 0; i < gvwBase_set.Columns.Count; i++)
            {
                gvwBase_set.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvwBase_set.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gvwBase_set.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvwBase_set.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                gvwBase_set.Columns["PLANT"].Width = 50;
                gvwBase_set.Columns["MODEL"].Width = 120;
                gvwBase_set.Columns["STYLE"].Width = 80;
                gvwBase_set.Columns["CMP"].Width = 80;
                gvwBase_set.Columns["QTY"].Width = 50;
                gvwBase_set.Columns["SET"].Width = 80;

            }
            gvwBase_set.Columns["QTY"].AppearanceHeader.BackColor = Color.FromArgb(57, 190, 29);
            gvwBase_set.Columns["QTY"].AppearanceHeader.BackColor2 = Color.FromArgb(57, 190, 29);
            gvwBase_set.Columns["QTY"].AppearanceHeader.ForeColor = Color.White;
            gvwBase_set.Columns["SET"].AppearanceHeader.BackColor = Color.Orange;
            gvwBase_set.Columns["SET"].AppearanceHeader.BackColor2 = Color.Orange;
            gvwBase_set.Columns["SET"].AppearanceHeader.ForeColor = Color.White;

            gvwBase_set.Columns["QTY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvwBase_set.Columns["QTY"].DisplayFormat.FormatString = "#,###";

            gvwBase_set.OptionsView.AllowCellMerge = true;
        }
        private void tmrLoad_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
            if (cCount >= 60)
            {
                BindingData();
                cCount = 0;
            }
        }
    }
}
