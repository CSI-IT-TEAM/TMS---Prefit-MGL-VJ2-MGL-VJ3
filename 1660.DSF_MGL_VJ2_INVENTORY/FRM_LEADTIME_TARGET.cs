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
    public partial class FRM_LEADTIME_TARGET : Form
    {
        string _CON_GRP = null, _CON_CD = null, _LINE_CD;
        string TempMin = null, TempMax = null;
        public delegate void ButtonOKHandler();
        public ButtonOKHandler OnConfirm = null;
        public FRM_LEADTIME_TARGET()
        {
            InitializeComponent();
        }

        public FRM_LEADTIME_TARGET(string ARG_LINE,string ARG_CON_GRP, string ARG_CON_CD)
        {
            InitializeComponent();
            _CON_GRP = ARG_CON_GRP;
            _CON_CD = ARG_CON_CD;
            _LINE_CD = ARG_LINE;
        }

        #region DB
        private DataTable SEL_DATA_STAND(string ARG_QTYPE, string ARG_LINE_CD, string ARG_GRP, string ARG_CON_CD)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_SMT_TRI.SEL_LEADTIME_STAND";
                //ARGMODE
                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[2] = "ARG_GRP";
                MyOraDB.Parameter_Name[3] = "ARG_CON_CD";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[2] = ARG_GRP;
                MyOraDB.Parameter_Values[3] = ARG_CON_CD;
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
        private Boolean UPDATE_STAND_VALUE(string ARG_QTYPE, string ARG_MIN, string ARG_MAX, string ARG_LINE_CD, string ARG_GRP, string ARG_CON_CD)
        {

            System.Data.DataSet retDS;
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(6);
            MyOraDB.Process_Name = "MES.PKG_SMT_TRI.UPDATE_LEADTIME_STAND";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "ARG_MIN";
            MyOraDB.Parameter_Name[2] = "ARG_MAX";
            MyOraDB.Parameter_Name[3] = "ARG_LINE_CD";
            MyOraDB.Parameter_Name[4] = "ARG_GRP";
            MyOraDB.Parameter_Name[5] = "ARG_CON_CD";

            for (int i = 0; i <= 5; i++)
                MyOraDB.Parameter_Type[i] = (char)OracleType.VarChar;


            MyOraDB.Parameter_Values[0] = ARG_QTYPE;
            MyOraDB.Parameter_Values[1] = ARG_MIN;
            MyOraDB.Parameter_Values[2] = ARG_MAX;
            MyOraDB.Parameter_Values[3] = ARG_LINE_CD;
            MyOraDB.Parameter_Values[4] = ARG_GRP;
            MyOraDB.Parameter_Values[5] = ARG_CON_CD;
            MyOraDB.Add_Modify_Parameter(true);

            retDS = MyOraDB.Exe_Modify_Procedure();

            if (retDS == null) return false;

            return true;
        }
        #endregion


        private void BindingData()
        {
            DataTable dt = SEL_DATA_STAND("Q",_LINE_CD, _CON_GRP, _CON_CD);
            txtMin.Clear();
            txtMax.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                TempMin = dt.Rows[0]["MIN"].ToString(); txtMin.Text = dt.Rows[0]["MIN"].ToString();
                TempMax = dt.Rows[0]["MAX"].ToString(); txtMax.Text = dt.Rows[0]["MAX"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Would you like to save this value?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dl == DialogResult.Yes)
            {
                if (Convert.ToInt32(txtMax.Text) < Convert.ToInt32(txtMin.Text))
                {
                    MessageBox.Show("Kiểm tra lại giá trị Max - Min");
                    return;
                }
                else
                {

                    if (UPDATE_STAND_VALUE("U", txtMin.Text, txtMax.Text,_LINE_CD, _CON_GRP, _CON_CD))
                    {
                        //MessageBox.Show("Data Has Been Updated!");
                        if (OnConfirm != null)
                            OnConfirm();

                        this.Close();
                    }
                }
            }
            else
                this.Close();
        }

        private void FRM_LEADTIME_TARGET_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            BindingData();
            button2.Enabled = false;
            this.Cursor = Cursors.Default;
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
               // if (!txtMax.Text.Equals(TempMax) || !txtMin.Text.Equals(TempMin))
                    button2.Enabled = true;
               

              //  else
               //     button2.Enabled = false;
            }
            catch (Exception ex)
            { 
            
            }
        }
    }
}
