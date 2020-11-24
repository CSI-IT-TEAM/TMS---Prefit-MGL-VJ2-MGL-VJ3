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
    public partial class FRM_MGL_PREFIT_TALLYSHEET : Form
    {
        public FRM_MGL_PREFIT_TALLYSHEET()
        {
            InitializeComponent();

        }
        private int cCount = 0;
        const int TimeRefresh = 60; //60 sec
        DataTable _dtXML = null;
        string _PLANT_CD = "", _LINE = "", _LINENAME = "", _MLINE = "", _OPCD = "", _DIV = "";
        public string _lang = "";
        FRM_STITCHING frm_stit = new FRM_STITCHING();
        #region DB

        #endregion

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "minimized";           
        }

        public void getConfigInfor()
        {
            try
            {
                _dtXML = ComVar.Func.ReadXML(Application.StartupPath + "\\Config.XML", "MAIN");

                string sFocus = "";               
                _lang = "EN";
                _OPCD = "UPS";
                SetForm("STIT");
            }
            catch
            {
            }
        }

        private void SetForm(string _PROCESS)
        {
            try
            {
                cCount = 0;
                foreach (Button btn in pnProcess.Controls)
                {
                    if (!string.IsNullOrEmpty(btn.Tag.ToString()))
                    {
                        btn.BackgroundImage = Properties.Resources.BtnImage;
                        btn.ForeColor = Color.Yellow;
                    }
                }
                switch (_PROCESS)
                { 
                    case "CUT":
                        btnCutting.BackgroundImage = Properties.Resources.BtnImageHover;
                        btnCutting.ForeColor = Color.Blue;
                        navFrame.SelectedPage = navigationPage1;
                        ComVar.Var._strValue1 = "CUT";
                        lblTitle.Text = "Cutting Tally Sheet ";// + _LINENAME;
                        break;
                    case "NOSEW":
                        btnNosew.BackgroundImage = Properties.Resources.BtnImageHover;
                        btnNosew.ForeColor = Color.Blue;
                        navFrame.SelectedPage = navigationPage2;
                        ComVar.Var._strValue1 = "UPN";
                        lblTitle.Text = "Nosew Set Balance ";// + _LINENAME;
                        break;
                    case "HF":
                        btnHF.BackgroundImage = Properties.Resources.BtnImageHover;
                        btnHF.ForeColor = Color.Blue;
                        navFrame.SelectedPage = navigationPage3;
                        ComVar.Var._strValue1 = "UPF";
                        lblTitle.Text = "H/F Set Balance ";// + _LINENAME;
                        break;
                    case "SET":
                        btnSet.BackgroundImage = Properties.Resources.BtnImageHover;
                        btnSet.ForeColor = Color.Blue;
                        navFrame.SelectedPage = navigationPage4;
                        ComVar.Var._strValue1 = "SET";
                        lblTitle.Text = "Stitching Set Balance ";// + _LINENAME;
                        break;
                    case "STIT":
                        btnStitching.BackgroundImage = Properties.Resources.BtnImageHover;
                        btnStitching.ForeColor = Color.Blue;
                        navFrame.SelectedPage = navigationPage5;
                        ComVar.Var._strValue1 = "UPS";
                        lblTitle.Text = "Prefit Tally Sheet ";// + _LINENAME;
                        break;
                }
            }
            catch
            {

            }
        }

        private void AddForm()
        {
            frm_stit.FormBorderStyle = FormBorderStyle.None;
            frm_stit.TopLevel = false;
            frm_stit.AutoScroll = false;
            frm_stit.Dock = DockStyle.Fill;
            pnPage5.Controls.Add(frm_stit);
            pnPage5.Controls[0].Show();
        }

        DataTable Pivot(DataTable dt, DataColumn pivotColumn, DataColumn pivotValue)
        {
            // find primary key columns 
            //(i.e. everything but pivot column and pivot value)
            DataTable temp = dt.Copy();
            temp.Columns.Remove(pivotColumn.ColumnName);
            temp.Columns.Remove(pivotValue.ColumnName);
            string[] pkColumnNames = temp.Columns.Cast<DataColumn>()
            .Select(c => c.ColumnName)
            .ToArray();

            // prep results table
            DataTable result = temp.DefaultView.ToTable(true, pkColumnNames).Copy();
            result.PrimaryKey = result.Columns.Cast<DataColumn>().ToArray();
            dt.AsEnumerable()
            .Select(r => r[pivotColumn.ColumnName].ToString())
            .Distinct().ToList()
            .ForEach(c => result.Columns.Add(c, pivotValue.DataType));
            //.ForEach(c => result.Columns.Add(c, pivotColumn.DataType));

            // load it
            foreach (DataRow row in dt.Rows)
            {
                // find row to update
                DataRow aggRow = result.Rows.Find(
                pkColumnNames
                .Select(c => row[c])
                .ToArray());
                // the aggregate used here is LATEST 
                // adjust the next line if you want (SUM, MAX, etc...)
                aggRow[row[pivotColumn.ColumnName].ToString()] = row[pivotValue.ColumnName];


            }

            return result;
        }

        private void FRM_HOME_Load(object sender, EventArgs e)
        {
            try
            {
                ComVar.Var._Area = "VN";
                getConfigInfor();
                AddForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            try
            {
                cCount++;
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
                if (cCount >= TimeRefresh)
                {
                    cCount = 0;
                    splashScreenManager1.ShowWaitForm();
                    //BindingDataOutByAsy();
                    splashScreenManager1.CloseWaitForm();
                }
            }
            catch
            {
                cCount = 0;
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void FRM_HOME_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cCount = TimeRefresh - 1;
                tmr.Start();
            }
            else
                tmr.Stop();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            //Khởi tạo giao diện Button về ban đầu
            foreach (Button btn in pnProcess.Controls)
            {
                if (!string.IsNullOrEmpty(btn.Tag.ToString()))
                {
                    btn.BackgroundImage = Properties.Resources.BtnImage;
                    btn.ForeColor = Color.Yellow;
                }
            }
            ((Button)sender).BackgroundImage = Properties.Resources.BtnImageHover;
            ((Button)sender).ForeColor = Color.Blue;

            try
            {
                //CallForm(_dtXML.Rows[0]["GROUPNAME"].ToString(), ((DevExpress.XtraEditors.SimpleButton)sender).Tag.ToString());
                //Trỏ vào page
                switch (((Button)sender).Tag.ToString())
                {
                    case "Cutting":
                        lblTitle.Text = "Cutting Tally Sheet ";
                        ComVar.Var._strValue1 = "CUT";
                        navFrame.SelectedPage = navigationPage1;                        
                        break;
                    case "Nosew":
                        lblTitle.Text = "Nosew Set Balance ";
                        ComVar.Var._strValue1 = "UPN";
                        navFrame.SelectedPage = navigationPage2;                        
                        break;
                    case "H/F":
                        lblTitle.Text = "H/F Set Balance ";
                        ComVar.Var._strValue1 = "UPF";
                        navFrame.SelectedPage = navigationPage3;                        
                        break;
                    case "Set Balance":
                        lblTitle.Text = "Stitching Set Balance ";
                        ComVar.Var._strValue1 = "SET";
                        navFrame.SelectedPage = navigationPage4;                       
                        break;
                    case "Stitching Input":
                        lblTitle.Text = "Prefit Tally Sheet ";
                        ComVar.Var._strValue1 = "UPS";
                        navFrame.SelectedPage = navigationPage5;                      
                        break;

                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void lblDate_DoubleClick_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVN_EN_Click(object sender, EventArgs e)
        {
            if (ComVar.Var._Area == "VN")
                ComVar.Var._Area = "EN";
            else
                ComVar.Var._Area = "VN";
            _lang = ComVar.Var._Area;            
            frm_stit.langue_chang(_lang);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "1";
        }
    }
}
