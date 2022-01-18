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
                string process_name = "MES.PKG_MGL_VJ3.MGL_MENU_SELECT";
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
                    process_name = "MES.PKG_SMT_MGL_V2.MGL_HOME_HRVJ3_SELECT";
                else
                    process_name = "MES.PKG_MGL_VJ3.MGL_HOME_DATA_SELECT";

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
        private DataTable SP_MGL_HOME_DATA_CHART_SELECT(string V_P_TYPE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_MGL_VJ3.MGL_HOME_DATA_SELECT";

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
        UC.UC_DSF_MGL_CARD[] UC_MGL_MENU = new UC.UC_DSF_MGL_CARD[3];
        private void InitTableContents()
        {
            string[] FacCode = new string[] { "VJ1", "VJ2", "TOT" };
            string[] FacTitle = new string[] { "VJ1 Support", "VJ2 Support", "Total Support" };
            DataTable dt = SP_SMT_EMD_MENU_SELECT("Q");

            for (int i = 0; i < tblContent.ColumnCount; i++)
            {
                UC.UC_DSF_MGL_CARD MGL_CARD = new UC.UC_DSF_MGL_CARD();
                tblContent.Controls.Add(MGL_CARD, i, 0);
                UC_MGL_MENU[i] = MGL_CARD;
                MGL_CARD.BindingTree(dt);
                MGL_CARD.Dock = DockStyle.Fill;
            }
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
        UC.UC_CHART_PROD[] UC_MGL_CHART = new UC.UC_CHART_PROD[3];
        private void InitTableChart()
        {
            string[] UCtag = new string[] { "VJ1", "VJ2", "TOTAL" };
            for (int i = 0; i < tblChart.ColumnCount; i++) //3
            {
                UC.UC_CHART_PROD MGL_CHART = new UC.UC_CHART_PROD();
                MGL_CHART.Tag = UCtag[i];
                UC_MGL_CHART[i] = MGL_CHART;
                tblChart.Controls.Add(MGL_CHART, i, 0);
                MGL_CHART.Dock = DockStyle.Fill;
            }
        }

        private void FRM_HOME_Load(object sender, EventArgs e)
        {
            btnBack.Visible = ComVar.Var._IsBack;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
            InitTableContents();
            InitTableChart();
        }
        int cCount = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            cCount++;
            if (cCount >= 30)
            {
                cCount = 0;
                bindingdata();
                //////string[] FacCode = new string[] { "VJ1", "VJ2", "TOT" };
                //////string[] FacTitle = new string[] { "VJ1 Support", "VJ2 Support", "Total Support" };
                //////DataTable dt = SP_MGL_HOME_DATA_SELECT("Q");
                //////for (int i = 0; i < dt.Rows.Count; i++)
                //////{
                //////    for (int j = 0; j < UC_MGL_CHART.Length; j++)
                //////    {
                //////        if (dt.Rows[i]["LINE_CD"].ToString().Equals(UC_MGL_CHART[j].Tag.ToString()))
                //////        {
                //////            string Factory = UC_MGL_CHART[j].Tag.ToString();
                //////            UC_MGL_CHART[j].BindingData(dt.Select("LINE_CD = '" + Factory + "'").CopyToDataTable());
                //////            UC_MGL_MENU[j].BindingData(FacCode[j], FacTitle[j], dt.Select("LINE_CD = '" + Factory + "'").CopyToDataTable());
                //////        }
                //////    }

                //////}
                //for (int i = 0; i < UC_MGL_CHART.Length; i++)
                //{


                //    UC_MGL_CHART[i].BindingDataChart(getDataforChart().Select("FACTORY_CODE = '" + i + "'").CopyToDataTable());
                //}
            }
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
        }

        private void bindingdata()
        {
            try
            {
                string[] FacCode = new string[] { "VJ1", "VJ2", "TOT" };
                string[] FacTitle = new string[] { "VJ1 Support", "VJ2 Support", "Total Support" };
                DataTable dt = SP_MGL_HOME_DATA_SELECT(_type.ToString());
                //DataTable dtchart = SP_MGL_HOME_DATA_CHART_SELECT("Q");
               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < UC_MGL_CHART.Length; j++)
                    {
                        if (dt.Rows[i]["LINE_CD"].ToString().Equals(UC_MGL_CHART[j].Tag.ToString()))
                        {
                            string Factory = UC_MGL_CHART[j].Tag.ToString();
                            UC_MGL_CHART[j].BindingData(dt.Select("LINE_CD = '" + Factory + "'").CopyToDataTable(), _type.ToString());
                            UC_MGL_MENU[j].BindingData(FacCode[j], FacTitle[j], dt.Select("LINE_CD = '" + Factory + "'").CopyToDataTable(), _type.ToString());
                        }
                    }

                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (_type == RunType.HR) _type = RunType.PROD;
                else _type = RunType.HR;
            }
        }

        private void btnPrefit_Cockpit_MouseEnter(object sender, EventArgs e)
        {
            btnDSF.BackgroundImage = Properties.Resources.FtyButtonHover;
        }

        private void btnPrefit_Cockpit_MouseLeave(object sender, EventArgs e)
        {
            btnDSF.BackgroundImage = Properties.Resources.FtyButton;
        }

        private void btnDSF_Click(object sender, EventArgs e)
        {
            ComVar.Var._IsBack = true;
            ComVar.Var._Value = "back";
            ComVar.Var.callForm = "538";//DSF plant b
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
            ComVar.Var.callForm = "375";
            //MessageBox.Show(this, "Under Contruction!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpstream_MouseEnter(object sender, EventArgs e)
        {
            btnUpstream.BackgroundImage = Properties.Resources.FtyButtonHover;
        }

        private void btnUpstream_MouseLeave(object sender, EventArgs e)
        {
            btnUpstream.BackgroundImage = Properties.Resources.FtyButton;
        }

        private void FRM_HOME_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cCount = 29;
                tmrDate.Start();
            }
            else
                tmrDate.Stop();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }
    }
}
