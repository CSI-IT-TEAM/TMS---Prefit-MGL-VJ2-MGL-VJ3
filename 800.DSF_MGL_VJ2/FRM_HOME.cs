using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM
{
    public partial class FRM_HOME : Form
    {
        public FRM_HOME()
        {
            InitializeComponent();
        }

        enum RunType
        {
            PROD,
            HR,
        }
        RunType _type = RunType.PROD;
        #region DB
        private DataTable SP_SMT_EMD_MENU_SELECT(string V_P_TYPE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_MGL_VJ2.MGL_MENU_SELECT";
                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";
                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = V_P_TYPE;
                MyOraDB.Parameter_Values[1] = "";
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
        private DataTable SP_MGL_HOME_DATA_SELECT(string V_P_TYPE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "";
                if (_type.ToString() == "HR")
                    process_name = "MES.PKG_SMT_MGL_V2.MGL_HOME_HRVJ2_SELECT";
                else                   
                    process_name = "MES.PKG_MGL_VJ2.MGL_HOME_DATA_SELECT"; 
               
                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";
                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = V_P_TYPE;
                MyOraDB.Parameter_Values[1] = "";
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
        int iDx = 0;
        UC.UC_DSF_MGL_CARD[] UC_MGL_MENU = new UC.UC_DSF_MGL_CARD[6];
        private void InitTableContents()
        {
            try
            {
                string[] FacCode = new string[] { "001", "099", "TOTAL1", "201", "202", "TOTAL2" };
                string[] FacTitle = new string[] { "F1 Support", "NOS N Support", "Total Support", "LD Assembly", "LE Assembly", "Total" };

                DataTable dt = SP_SMT_EMD_MENU_SELECT("Q");
                //for (int j = 0; j < tblContent.RowCount; j++)
                //{
                //    for (int i = 0; i < tblContent.ColumnCount; i++)
                //    {

                //        UC.UC_DSF_MGL_CARD MGL_CARD = new UC.UC_DSF_MGL_CARD();
                //        tblContent.Controls.Add(MGL_CARD, i, j);
                //        MGL_CARD.Tag = FacCode[iDx];
                //        UC_MGL_MENU[iDx] = MGL_CARD;
                //        MGL_CARD.BindingData(FacCode[iDx], FacTitle[iDx], null);
                //        MGL_CARD.BindingTree(dt);
                //        MGL_CARD.Dock = DockStyle.Fill;
                //        iDx++;
                //    }
                //}

                int j = 0;
                for (int i = 0; i < tblContent.ColumnCount; i++)
                {

                    UC.UC_DSF_MGL_CARD MGL_CARD = new UC.UC_DSF_MGL_CARD();
                    tblContent.Controls.Add(MGL_CARD, i, j);
                    MGL_CARD.Tag = FacCode[iDx];
                    UC_MGL_MENU[iDx] = MGL_CARD;
                    MGL_CARD.BindingData(FacCode[iDx], FacTitle[iDx], null, _type.ToString());
                    MGL_CARD.BindingTree(dt);
                    MGL_CARD.Dock = DockStyle.Fill;
                    iDx++;  
                }

                DataTable dt1 = SP_SMT_EMD_MENU_SELECT("Q2");
                j = 1;
                for (int i = 0; i < tblContent.ColumnCount; i++)
                {

                    UC.UC_DSF_MGL_CARD MGL_CARD = new UC.UC_DSF_MGL_CARD();
                    tblContent.Controls.Add(MGL_CARD, i, j);
                    MGL_CARD.Tag = FacCode[iDx];
                    UC_MGL_MENU[iDx] = MGL_CARD;
                    MGL_CARD.BindingData(FacCode[iDx], FacTitle[iDx], null,_type.ToString());
                    MGL_CARD.BindingTree(dt1);
                    MGL_CARD.Dock = DockStyle.Fill;
                    iDx++;
                }
            }
            catch (Exception ex) { }
        }
        Random r = new Random();
        private DataTable getDataforChart()
        {
            DataTable table = new DataTable();
            table.Columns.Add("FACTORY_CODE", typeof(int));
            table.Columns.Add("FACTORY", typeof(string));
            table.Columns.Add("Prod", typeof(int));
            table.Columns.Add("Tar", typeof(int));
            table.Columns.Add("Ratio", typeof(int));
            // Here we add five DataRows.

            table.Rows.Add(0, "VJ1 Support", r.Next(1, 3000), r.Next(1, 3000), r.Next(1, 100));
            table.Rows.Add(1, "VJ2 Support", r.Next(1, 3000), r.Next(1, 3000), r.Next(1, 100));
            table.Rows.Add(2, "Total Support", r.Next(1, 3000), r.Next(1, 3000), r.Next(1, 100));

            return table;
        }

        private void FRM_HOME_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
            InitTableContents();
        }
        int cCount = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            cCount++;
            if (cCount >= 30)
            {
                cCount = 0;
                bindingdata();
                //////string[] FacCode = new string[] { "001", "099", "TOTAL1", "201", "202", "TOTAL2" };
                //////string[] FacTitle = new string[] { "F1 Support", "NOS N Support", "Total VJ1 Support", "LD", "LE", "Total VJ2" };
                //////DataTable dt = SP_MGL_HOME_DATA_SELECT("Q");
                //////if (dt != null && dt.Rows.Count > 0)
                //////{
                //////    for (int i = 0; i < dt.Rows.Count; i++)
                //////    {
                //////        for (int j = 0; j < UC_MGL_MENU.Length; j++)
                //////        {
                //////            if (dt.Rows[i]["LINE_CD"].ToString().Equals(UC_MGL_MENU[j].Tag.ToString()))
                //////            {
                //////                string Factory = UC_MGL_MENU[j].Tag.ToString();
                //////                //UC_MGL_CHART[j].BindingData(dt.Select("LINE_CD = '" + Factory + "'").CopyToDataTable());
                //////                UC_MGL_MENU[j].BindingData(FacCode[j], FacTitle[j], dt.Select("LINE_CD = '" + Factory + "'").CopyToDataTable());
                //////            }
                //////        }

                //////    }
                //////}
                ///
                // DataTable dt = SP_MGL_HOME_DATA_SELECT("Q");
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    for (int j = 0; j < UC_MGL_MENU.Length; j++)
                //    {
                //        if (dt.Rows[i]["LINE_CD"].ToString().Equals(UC_MGL_MENU[j].Tag.ToString()))
                //        {
                //            string Factory = UC_MGL_MENU[j].Tag.ToString();
                //            UC_MGL_MENU[j].BindingData(FacCode[j], FacTitle[j], dt.Select("LINE_CD = '" + Factory + "'").CopyToDataTable());
                //        }
                //    }
                //}

            }
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
        }

        private void bindingdata()
        {
            try
            {
                string[] FacCode = new string[] { "001", "099", "TOTAL1", "201", "202", "TOTAL2" };
                string[] FacTitle = new string[] { "F1 Support", "NOS N Support", "Total VJ1 Support", "LD", "LE", "Total VJ2" };
                DataTable dt = SP_MGL_HOME_DATA_SELECT(_type.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < UC_MGL_MENU.Length; j++)
                        {
                            if (dt.Rows[i]["LINE_CD"].ToString().Equals(UC_MGL_MENU[j].Tag.ToString()))
                            {
                                string Factory = UC_MGL_MENU[j].Tag.ToString();
                                //UC_MGL_CHART[j].BindingData(dt.Select("LINE_CD = '" + Factory + "'").CopyToDataTable());
                                UC_MGL_MENU[j].BindingData(FacCode[j], FacTitle[j], dt.Select("LINE_CD = '" + Factory + "'").CopyToDataTable(), _type.ToString());
                            }
                        }

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (_type == RunType.HR) _type = RunType.PROD;
                else _type = RunType.HR;
            }
        }

        private void btnDSF_Click(object sender, EventArgs e)
        {
            ComVar.Var._IsBack = true;
            ComVar.Var._Value = "back";
            ComVar.Var.callForm = "23";//DSF plant b
        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "minimized";
        }

        private void btnUpstream_Click(object sender, EventArgs e)
        {
            ComVar.Var._IsBack = true;
            ComVar.Var._Value = "back";
            ComVar.Var.callForm = "300";
        }

        private void FRM_HOME_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cCount = 28;
                tmrDate.Start();
            }
            else
                tmrDate.Stop();
        }

        private void btnPrefit_Click(object sender, EventArgs e)
        {
            ComVar.Var._IsBack = true;
            ComVar.Var._Value = "back";
            ComVar.Var.callForm = "1680";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }
    }
}
