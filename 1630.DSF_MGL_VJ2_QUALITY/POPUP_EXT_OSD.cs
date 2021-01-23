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
    public partial class POPUP_EXT_OSD : Form
    {
        private string line_cd, mline_cd, date_from, date_to;
        public POPUP_EXT_OSD()
        {
            InitializeComponent();
        }
        public POPUP_EXT_OSD(string _line_cd, string _mline_cd, string _date_from, string _date_to)
        {
            InitializeComponent();
            line_cd = _line_cd;
            mline_cd = _mline_cd;
            date_from = _date_from;
            date_to = _date_to;
            lblTitle.Text = "External OS&&D Detail (" + _date_from.Substring(0, 4) + "-" + _date_from.Substring(4, 2) +"-"+_date_from.Substring(6,2) +")";

        }

        private void FRM_EXTERNAL_OSND_POP_Load(object sender, EventArgs e)
        {

            DataTable dt = this.SP_SMT_OSD_DETAIL(line_cd, mline_cd, date_from, date_to, "", "Y");
           
            if (dt != null)
            {
                //MessageBox.Show(dt.Rows.Count.ToString());
               BindingGrid(dt);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void CLearGrid()
        {
            for (int iRow = 2; iRow <= axfpOSD.MaxRows; iRow++)
            {
                for (int iCol = 2; iCol <= axfpOSD.MaxCols; iCol++)
                {
                    axfpOSD.SetText(iCol, iRow, "");
                    axfpOSD.Row = iRow;
                    axfpOSD.Col = iCol;
                    
                }
            }
        }

        private void BindingGrid(DataTable dt)
        {

            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                  
                    CLearGrid();
                    for (int iRow = 2; iRow < dt.Rows.Count; iRow++)
                    {
                        axfpOSD.SetText(1, iRow, dt.Rows[iRow-2]["OSD_Date"].ToString());
                        axfpOSD.SetText(2, iRow, dt.Rows[iRow - 2]["Time"].ToString());
                        axfpOSD.SetText(3, iRow, dt.Rows[iRow - 2]["Comp"].ToString());
                        axfpOSD.SetText(4, iRow, dt.Rows[iRow - 2]["Model_Name"].ToString());
                        axfpOSD.SetText(5, iRow, dt.Rows[iRow - 2]["Style_Code"].ToString());
                        axfpOSD.SetText(6, iRow, dt.Rows[iRow - 2]["Reason"].ToString());
                        axfpOSD.SetText(7, iRow, dt.Rows[iRow - 2]["CS_SIZE"].ToString());
                        axfpOSD.SetText(8, iRow, dt.Rows[iRow - 2]["LR"].ToString());
                        axfpOSD.SetText(9, iRow, dt.Rows[iRow - 2]["C_Qty"].ToString());
                    }
                  
                }
                catch 
                { }
            }
        }


        public DataTable SP_SMT_OSD_DETAIL(string V_P_OSD_LINE, string V_P_MLINE_CD, string V_P_DATE_FROM, string V_P_DATE_TO, string V_P_OP_CD, string V_P_CONFIRM_CHK)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_PHUOC.SP_SMT_OSD_DETAIL";

                MyOraDB.ReDim_Parameter(7);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_OSD_LINE";
                MyOraDB.Parameter_Name[1] = "V_P_MLINE_CD";
                MyOraDB.Parameter_Name[2] = "V_P_DATE_FROM";
                MyOraDB.Parameter_Name[3] = "V_P_DATE_TO";
                MyOraDB.Parameter_Name[4] = "V_P_OP_CD";
                MyOraDB.Parameter_Name[5] = "V_P_CONFIRM_CHK";
                MyOraDB.Parameter_Name[6] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.VarChar;               
                MyOraDB.Parameter_Type[6] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = V_P_OSD_LINE;
                MyOraDB.Parameter_Values[1] = V_P_MLINE_CD;
                MyOraDB.Parameter_Values[2] = V_P_DATE_FROM;
                MyOraDB.Parameter_Values[3] = V_P_DATE_TO;
                MyOraDB.Parameter_Values[4] = V_P_OP_CD;
                MyOraDB.Parameter_Values[5] = V_P_CONFIRM_CHK;
                MyOraDB.Parameter_Values[6] = "";


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
    }
}
