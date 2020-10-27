using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.IO;

namespace FORM
{
    public partial class FRM_MODEL_DETAIL_LW : Form
    {
        public FRM_MODEL_DETAIL_LW()
        {
            InitializeComponent();
        }
        string _Line = ComVar.Var._strValue1, _Mline = ComVar.Var._strValue2;
        Dictionary<string, string> _dtnInit = new Dictionary<string, string>();        public FRM_MODEL_DETAIL_LW(string Line,string Mline)
        {
            InitializeComponent();
            _Line = Line;
            _Mline = Mline;//.Substring(2, 1);
            tmr_scroll.Stop();
        }



        public DataTable SEL_MODEL_DELTAI_LW(string ARG_QTYPE, string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_VJ3.SP_SMT_MODEL_DELTAI_LW";

                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[2] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[2] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[3] = "";


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

        public void bindingData(string line,string mLine)
        {
            try
            {

                dt = SEL_MODEL_DELTAI_LW("Q", line, mLine);//.Select("MLINE ='" + mLine + "'").CopyToDataTable();

                if (dt != null && dt.Rows.Count > 0)
                {
                    grdBase.DataSource = dt;
                    lblTitle.Text = dt.Rows[0]["MODEL"].ToString() + ": " + dt.Rows[0]["MONTH"].ToString();
                }
            }
            catch (Exception ex)
            { }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           // ComVar.Var.callForm = _dtnInit["frmHome"];
            this.Close();

        }

        private void DownloadImage()
        {
            string file_path;
            byte[] MyData = new byte[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MyData = (byte[])dt.Rows[i]["PIC"];

                int ArraySize = new int();
                ArraySize = MyData.GetUpperBound(0) + 1;

                file_path = Directory.GetCurrentDirectory() + @"\file\";

                FileStream fs = new FileStream(file_path + i.ToString() + ".jpg", FileMode.OpenOrCreate, FileAccess.Write);

                fs.Write(MyData, 0, ArraySize);
                fs.Close();
            }

        }

        private void FRM_MODEL_DETAIL_LW_Load(object sender, EventArgs e)
        {
            thisMonth = DateTime.Now.ToString("YYYYMM");
            _dtnInit = ComVar.Func.getInitForm(this.GetType().Assembly.GetName().Name, this.GetType().Name);

            bindingData(_Line,_Mline);
        }


      


        int maxrow = 0,rows;
        string thisMonth;
        DataTable dt = null;
        private void tmr_scroll_Tick(object sender, EventArgs e)
        {
            try
            {
                if (rows + 1 > maxrow)
                {
                    try
                    {

                        rows = 1;
                        // dt = SEL_MODEL_DELTAI_LW("Q", "014", "001").Select("MLINE ='" + mLine + "'").CopyToDataTable();
                        bindingData(_Line, _Mline);
                        grdBase.DataSource = dt;


                    }
                    catch (Exception ex)
                    { }
                    finally
                    {
                        maxrow = layoutView1.RowCount;
                        layoutView1.MoveFirst();
                    }
                }
                else
                {
                    rows = rows + 1;
                    layoutView1.MoveNext();

                }
                lblTitle.Text = dt.Rows[rows - 1]["MODEL"].ToString() + ": " + dt.Rows[rows - 1]["MONTH"].ToString();
            }
            catch (Exception ex)
            { }
        }

        private void FRM_MODEL_DETAIL_LW_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                //this.Opacity = 0;
                //for (int i = 0; i < 50; i++)
                //{
                //    this.Opacity = i * 0.02;
                //    Application.DoEvents();
                //    System.Threading.Thread.Sleep(8);
                //}
                tmr_scroll.Start();
            }
            else
            {
                this.Hide();
                tmr_scroll.Stop();
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            
        }

        private void FRM_MODEL_DETAIL_LW_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            DownloadImage();
        }
        int cCountClick = 0;
        private void grdBase_Click(object sender, EventArgs e)
        {
            
           
        }

        private void layoutView1_Click(object sender, EventArgs e)
        {
            if (cCountClick == 0)
            {
                tmr_scroll.Stop();
                cCountClick++;
                lblStatus.Text = "Pause...";
            }
            else
            {
                tmr_scroll.Start();
                cCountClick = 0;
                lblStatus.Text = "";
            }
        }
    }
}
