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
    public partial class FRM_LINE : Form
    {
        public FRM_LINE()
        {
            InitializeComponent();
           
        }

       

        private DataSet Sel_Mline(string Proc_Name,string ARG_PLANT)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = Proc_Name;
                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_PLANT";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";
              

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.Cursor;


                MyOraDB.Parameter_Values[0] = ARG_PLANT;
                MyOraDB.Parameter_Values[1] = "";

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

        private void BindingLine(string PLANT_CD)
        {

            DataSet ds = Sel_Mline("MES.SP_GET_NOS_MLINE", PLANT_CD);
            cboLine.Properties.DataSource = ds.Tables[0];
            cboLine.Properties.DisplayMember = "MLINE_NM";
            cboLine.Properties.ValueMember = "MLINE_CD";
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn)
            {
                BindingLine("099");
                cboLine.Properties.DropDownRows = 9; //8 line
            }
            else
            {
                BindingLine("FTY01");
                cboLine.Properties.DropDownRows = 7; //6 line
            }
        }

        private void FRM_LINE_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible)
                BindingLine(ComVar.Var._strValue1);
        }

        private void cboLine_EditValueChanged(object sender, EventArgs e)
        {
            
        }


    }
}
