using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using DevExpress.Utils;

namespace FORM
{
    public partial class FRM_TMS_PREFIT_OUTGOING : Form
    {
        public FRM_TMS_PREFIT_OUTGOING()
        {
            InitializeComponent();

        }
        #region Ora
        private DataTable TMS_HOME_OUTGOING_SELECT(string ARG_TYPE, string ARG_FACTORY, string ARG_PROC_CD, string ARG_IS_BOTTOM)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_PREFIT.TMS_HOME_OUTGOING_SELECT";
                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_FACTORY";
                MyOraDB.Parameter_Name[2] = "ARG_PROC_CD";
                MyOraDB.Parameter_Name[3] = "ARG_IS_BOTTOM";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_TYPE;
                MyOraDB.Parameter_Values[1] = ARG_FACTORY;
                MyOraDB.Parameter_Values[2] = ARG_PROC_CD;
                MyOraDB.Parameter_Values[3] = ARG_IS_BOTTOM;
                MyOraDB.Parameter_Values[4] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        #endregion
        private void ClearTextLabel()
        {
            lblDeTotal.Text = "0 Prs";
            lblDeDD.Text = "0 Prs";
            lblDeD1.Text = "0 Prs";
            lblDeD2.Text = "0 Prs";
            lblDeD3.Text = "0 Prs";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "600"; //Back về form MAIN (SEQ: 600)
        }

        private void FRM_TMS_PREFIT_OUTGOING_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                try
                {
                    lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
                    lblTitle.Text = string.Concat(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ComVar.Var._strValue3.ToLower()), " Outgoing Status");
                    //Lấy dữ liệu từ server
                    string Factory = ComVar.Var._strValue1;
                    string ProcCode = ComVar.Var._strValue2;
                    string isBottom = ComVar.Var._bValue1.ToString();

                    if (Convert.ToBoolean(isBottom))
                    {
                        switch (ProcCode)
                        {
                            case "UPP": //Printing xuong Bottom
                                picVJ1.Visible = false; lblVinhCuu.Visible = false;
                                picVJ2.Visible = false; lblLongThanh.Visible = false;
                                picVJ3.Visible = false; lblTanPhu.Visible = false;
                                break;
                        }
                    }
                    else
                    {
                        switch (ProcCode)
                        {
                            case "UPP":
                                picVJ1.Visible = true; lblVinhCuu.Visible = true;
                                picVJ2.Visible = true; lblLongThanh.Visible = true;
                                picVJ3.Visible = true; lblTanPhu.Visible = true;
                                break;
                            case "UPR":
                            case "EMB":
                                picVJ1.Visible = true; lblVinhCuu.Visible = true;
                                picVJ2.Visible = true; lblLongThanh.Visible = true;
                                picVJ3.Visible = false; lblTanPhu.Visible = false;
                                break;
                            case "UPA":
                            case "UPF":
                                picVJ1.Visible = false; lblVinhCuu.Visible = false;
                                picVJ2.Visible = true; lblLongThanh.Visible = true;
                                picVJ3.Visible = true; lblTanPhu.Visible = true;
                                break;
                            default:
                                picVJ1.Visible = false; lblVinhCuu.Visible = false;
                                picVJ2.Visible = false; lblLongThanh.Visible = false;
                                picVJ3.Visible = false; lblTanPhu.Visible = false;
                                break;
                        }
                    }

                    //Chọn Hình nhà máy
                    //Reset Color Truoc Khi Visible lai.
                    lblVinhCuu.BackColor = Color.FromArgb(24, 33, 60);
                    lblVinhCuu.ForeColor = Color.White;
                    lblLongThanh.BackColor = Color.FromArgb(24, 33, 60);
                    lblLongThanh.ForeColor = Color.White;
                    lblTanPhu.BackColor = Color.FromArgb(24, 33, 60);
                    lblTanPhu.ForeColor = Color.White;
                    switch (Factory)
                    {
                        case "1":
                            lblVinhCuu.BackColor = Color.Yellow;
                            lblVinhCuu.ForeColor = Color.Black;
                            break;
                        case "2":
                            lblLongThanh.BackColor = Color.Yellow;
                            lblLongThanh.ForeColor = Color.Black;
                            break;
                        case "3":
                            lblTanPhu.BackColor = Color.Yellow;
                            lblTanPhu.ForeColor = Color.Black;
                            break;
                    }

                    BindingData(Factory, ProcCode, isBottom);

                }
                catch (Exception ex) { }
            }
        }

        private void BindingData(string Factory, string ProcCode, string isBottom)
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                ClearTextLabel();
                DataTable dt = TMS_HOME_OUTGOING_SELECT("Q1", Factory, ProcCode, isBottom.Equals("False") ? "0" : "1");
                DataTable dtG = TMS_HOME_OUTGOING_SELECT("Q2", Factory, ProcCode, isBottom.Equals("False") ? "0" : "1");
                DataTable dtC = TMS_HOME_OUTGOING_SELECT("Q3", Factory, ProcCode, isBottom.Equals("False") ? "0" : "1");
                if (dt != null)
                {
                    lblDeTotal.Text = string.Concat(string.Format("{0:n0}", dt.Rows[0]["PS_QTY"]), " Prs");
                    lblDeDD.Text = string.Concat(string.Format("{0:n0}", dt.Rows[1]["PS_QTY"]), " Prs");
                    lblDeD1.Text = string.Concat(string.Format("{0:n0}", dt.Rows[2]["PS_QTY"]), " Prs");
                    lblDeD2.Text = string.Concat(string.Format("{0:n0}", dt.Rows[3]["PS_QTY"]), " Prs");
                    lblDeD3.Text = string.Concat(string.Format("{0:n0}", dt.Rows[4]["PS_QTY"]), " Prs");
                }
                else
                    ClearTextLabel();
                if (dtG != null)
                {
                    gridControl1.DataSource = dtG;
                    
                    //FORMAT
                    for (int i = 0; i < gridView1.Columns.Count; i++)
                    {
                        gridView1.Columns[i].OptionsColumn.ReadOnly = true;
                        gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                        if (i < 1)
                            gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                        else
                            gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                        if (i == gridView1.Columns.Count - 1)
                        {
                            gridView1.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                            gridView1.Columns[i].DisplayFormat.FormatString = "#,#";
                        }
                        gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    }
                    gridView1.Columns["MODEL_NM"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                    gridView1.Columns["PFC_PART_NM"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                    gridView1.Columns["PFC_PART_NM"].VisibleIndex = 3;
                    gridView1.Columns["PFC_PART_NO"].VisibleIndex = 4;
                    gridView1.Columns["PS_QTY"].VisibleIndex = 5;
                    gridView1.Columns["PFC_PART_NO"].Visible = ComVar.Var._bValue2;
                    gridView1.Columns["PFC_PART_NM"].Visible = ComVar.Var._bValue2;
                    
                }
                else
                    gridControl1.DataSource = null;

                if (dtC != null)
                {
                    chartControl1.DataSource = dtC;
                    chartControl1.Series[0].ArgumentDataMember = "LINE_NM";
                    chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "PS_QTY" });
                }
                else
                    chartControl1.DataSource = null;
                splashScreenManager1.CloseWaitForm();
            }
            catch { splashScreenManager1.CloseWaitForm(); }
        }

        private void picVJ_Click(object sender, EventArgs e)
        {
            //Reset Color Truoc Khi load lai.
            string Factory = ((PictureBox)sender).Tag.ToString();
            string ProcCode = ComVar.Var._strValue2;
            string isBottom = ComVar.Var._bValue1.ToString();
            lblVinhCuu.BackColor = Color.FromArgb(24, 33, 60);
            lblVinhCuu.ForeColor = Color.White;
            lblLongThanh.BackColor = Color.FromArgb(24, 33, 60);
            lblLongThanh.ForeColor = Color.White;
            lblTanPhu.BackColor = Color.FromArgb(24, 33, 60);
            lblTanPhu.ForeColor = Color.White;
            switch (Factory)
            {
                case "1":
                    lblVinhCuu.BackColor = Color.Yellow;
                    lblVinhCuu.ForeColor = Color.Black;
                    break;
                case "2":
                    lblLongThanh.BackColor = Color.Yellow;
                    lblLongThanh.ForeColor = Color.Black;
                    break;
                case "3":
                    lblTanPhu.BackColor = Color.Yellow;
                    lblTanPhu.ForeColor = Color.Black;
                    break;
            }
            BindingData(Factory, ProcCode, isBottom);
        }
        private void tmrDate_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
        }

     

    }
}
