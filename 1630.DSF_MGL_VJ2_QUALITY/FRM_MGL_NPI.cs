﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Controls;
using System.IO;
using System.Diagnostics;

namespace FORM
{
    public partial class FRM_MGL_NPI : Form
    {
        public FRM_MGL_NPI()
        {
            InitializeComponent();

        }

        #region Global Variant
        int _iCountReload = 0;
        Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        #endregion

        #region Load/Visible Change/ Timer Date
        private void Form_Load(object sender, EventArgs e)
        {
            
            pnHeader.BackColor = Color.FromArgb(0, 176, 80);
        }

        void OnUCMenuClick(string TitleCode, string MenuCode)
        {
            MessageBox.Show(TitleCode + " / " + MenuCode);
        }
        private void Form_VisibleChanged(object sender, EventArgs e)
        {

            if (this.Visible)
            {
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
                _iCountReload = 40;
                tmrDate.Start();

            }
            else
                tmrDate.Stop();

        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            _iCountReload++;

            if (_iCountReload >= 40)
            {
                //BindingDataRamUp();
                BindingDataGrid();
                //BindingDataChart();
                _iCountReload = 0;

            }

        }
        #endregion

        #region Ora
        private DataTable SEL_FILE(string arg_file, string arg_plant, string arg_model, string arg_td_code, string arg_season)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "PKG_SQA_NPI_PROJECT_2.SEL_NPI_MR_FILE";
                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_FILE";
                MyOraDB.Parameter_Name[1] = "ARG_PLANT";
                MyOraDB.Parameter_Name[2] = "ARG_MODEL_CD";
                MyOraDB.Parameter_Name[3] = "ARG_TD_CODE";
                MyOraDB.Parameter_Name[4] = "ARG_SEASON";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = arg_file;
                MyOraDB.Parameter_Values[1] = arg_plant;
                MyOraDB.Parameter_Values[2] = arg_model;
                MyOraDB.Parameter_Values[3] = arg_td_code;
                MyOraDB.Parameter_Values[4] = arg_season;
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
        public DataTable SMT_MGL_GRID_MR_SELECT(string ARG_TYPE, string ARG_DATE, string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_MGL_VJ2.MGL_NPI";
                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE";
                MyOraDB.Parameter_Name[2] = "ARG_MLINE";
                MyOraDB.Parameter_Name[3] = "ARG_DATE";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";
                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = ARG_TYPE;
                MyOraDB.Parameter_Values[1] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[2] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[3] = ARG_DATE;
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
        private DataTable SP_SMT_EMD_GRID_DATA_SELECT(string V_P_TYPE, string V_P_FAC)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_PROD_EMD.SP_SMT_EMD_GRID_DATA_SELECT";
                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_FAC";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";
                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = V_P_TYPE;
                MyOraDB.Parameter_Values[1] = V_P_FAC;
                MyOraDB.Parameter_Values[2] = "";
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

        #region Function
        #region  Get Config Data From Database
        /// <summary>
        /// Declare _dtnInit
        /// Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        /// </summary>
        private void setConfigForm()
        {
            try
            {
                System.Collections.Generic.Dictionary<string, string> dtnInit = new System.Collections.Generic.Dictionary<string, string>();
                dtnInit = ComVar.Func.getInitForm(ComVar.Var._Frm_Call + this.GetType().Assembly.GetName().Name, this.GetType().Name);

                for (int i = 0; i < dtnInit.Count; i++)
                {
                    setComValue(dtnInit.ElementAt(i).Key, dtnInit.ElementAt(i).Value);
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setConfigForm-->Err:    " + ex.ToString());
            }
        }

        private void setComValue(string obj, string obj_value)
        {
            try
            {
                if (obj.Contains('.'))
                {
                    string[] strSplit = obj.Split('.');
                    Control[] cnt = this.Controls.Find(strSplit[0], true);

                    for (int i = 0; i < cnt.Length; i++)
                    {
                        System.Reflection.PropertyInfo propertyInfo = cnt[i].GetType().GetProperty(strSplit[1]);
                        propertyInfo.SetValue(cnt[i], Convert.ChangeType(obj_value, propertyInfo.PropertyType), null);
                    }
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setComValue (" + obj + ", " + obj_value + ") Err:    " + ex.ToString());
            }

        }
        #endregion

        #region Method

        private void AddingImage(string Patch, string ColumnName)
        {



        }

        private void AddImageDown()
        {

        }
        private void BindingDataRamUp()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                bandDate.Caption = DateTime.Now.ToString("yyyy");
                DataTable dt = SMT_MGL_GRID_MR_SELECT("RAMUP", "", ComVar.Var._strValue1, "");
                grdView.DataSource = dt;
                FormatGridRamUP();
                this.Cursor = Cursors.Default;
            }
            catch { }
        }

        private void BindingDataGrid()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = SMT_MGL_GRID_MR_SELECT("Q", "", ComVar.Var._strValue1, "");
                gridBase1.DataSource = dt;
                FormatGrid();
                string appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\ICON\\ppt.png";


                RepositoryItemCheckEdit checkEdit = gridBase1.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
                string appPathPPT = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\ICON\\ppt.png";
                string appPathExc = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\ICON\\excel.png";
                string appPathnull = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\ICON\\null.png";
                checkEdit.ValueChecked = "excel.png";
                checkEdit.ValueUnchecked = "ppt.png";

                checkEdit.PictureChecked = Image.FromFile(appPathExc);
                checkEdit.PictureUnchecked = Image.FromFile(appPathPPT);
                checkEdit.PictureGrayed = Image.FromFile(appPathnull);
                checkEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
                gvwView1.Columns["MR2_FILE"].ColumnEdit = checkEdit;
                gvwView1.Columns["MR31_FILE"].ColumnEdit = checkEdit;
                gvwView1.Columns["MR32_FILE"].ColumnEdit = checkEdit;
                gvwView1.Columns["MR33_FILE"].ColumnEdit = checkEdit;
                gvwView1.Columns["TRIAL_FILE"].ColumnEdit = checkEdit;
                gvwView1.Columns["EX_FILE"].ColumnEdit = checkEdit;
                gvwView1.Columns["MR4_FILE"].ColumnEdit = checkEdit;
                gridBase1.RepositoryItems.Add(checkEdit);
                this.Cursor = Cursors.Default;



                //RepositoryItemImageComboBox imageCombo = gridBase1.RepositoryItems.Add("ImageComboBoxEdit") as RepositoryItemImageComboBox;
                //DevExpress.Utils.ImageCollection images = new DevExpress.Utils.ImageCollection();
                //images.AddImage(Image.FromFile(@"D:\hinh\excel.png"));
                //images.AddImage(Image.FromFile(@"D:\hinh\ppt.png"));
                //imageCombo.SmallImages = images;
                //imageCombo.Items.Add(new ImageComboBoxItem("excel.png", (short)1, 0));
                //imageCombo.Items.Add(new ImageComboBoxItem("ppt.png", (short)2, 1));
                //imageCombo.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
                //gvwView1.Columns["MR2_FILE"].ColumnEdit = imageCombo;
                //gridBase1.RepositoryItems.Add(imageCombo);



                //RepositoryItemCheckEdit checkEdit = gridBase1.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
                //string appPathPPT = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\ICON\\ppt.png";
                //string appPathExc = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\ICON\\ppt.png";
                //checkEdit.PictureChecked = Image.FromFile(appPathPPT);
                //checkEdit.PictureUnchecked = Image.FromFile(appPathExc);
                //checkEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
                //gvwView1.Columns["MR2_FILE"].ColumnEdit = checkEdit;
                //gridBase1.RepositoryItems.Add(checkEdit);



                formatBand();
            }
            catch (Exception ex) { }
            finally
            {
                //BindingSummary();
            }
        }

        private void formatBand()
        {
            int i = 0;
            foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand band in gvwView1.Bands)
            {
                
                if (i > 2 && (!band.Name.Equals("gridBand41")))
                band.Width = 215;
                i++;
 
            }
            gridBand4.Width = 120;
            gridBand5.Width = 80;
            gridBand7.Width = 300; //MODEL NAME
            gridBand41.Width = 100;
        }
        private void BindingSummary()
        {
            //try
            //{ 
            //DataTable dt = SP_SMT_EMD_GRID_DATA_SELECT("ALL", "VJ");
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    lblDplan_Qty.Text = string.Format("{0:0,0}", dt.Rows[0]["D_PLAN"]);
            //    lblRplan_Qty.Text = string.Format("{0:0,0}", dt.Rows[0]["R_PLAN"]);
            //    lblAct_Qty.Text   = string.Format("{0:0,0}", dt.Rows[0]["PROD"]);
            //    lblPRate_Per.Text = string.Format("{0:0.0}", dt.Rows[0]["P_RATE"]);
            //}
            //    }
            //catch { }
        }
        private void FormatGrid()
        {
            try
            {
                //grdView.BeginUpdate();
                gvwView1.OptionsView.AllowCellMerge = true;
                for (int i = 0; i < gvwView1.Columns.Count; i++)
                {
                    gvwView1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvwView1.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                    gvwView1.Columns[i].OptionsColumn.ReadOnly = true;
                    gvwView1.Columns[i].OptionsColumn.AllowEdit = false;
                    gvwView1.Columns[i].OptionsFilter.AllowFilter = false;
                    gvwView1.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    gvwView1.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 18, FontStyle.Bold);
                    gvwView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    //if (i==6)
                    //    gvwView1.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 12, FontStyle.Regular ^ FontStyle.Bold);
                    if (i > 5)
                    {
                        gvwView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        gvwView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    }
                    else if (i == 5)
                        gvwView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    else
                        gvwView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;

                }
                gvwView1.Columns["MODEL_NAME"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                gvwView1.Columns["SEASON_NAME"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                //grdView.EndUpdate();
            }
            catch (Exception ex)
            { }
        }
        private void FormatGridRamUP()
        {
            try
            {
                gvwView.BeginUpdate();

                for (int i = 0; i < gvwView.Columns.Count; i++)
                {

                    gvwView.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvwView.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                    gvwView.Columns[i].OptionsColumn.ReadOnly = true;

                    gvwView.Columns[i].OptionsColumn.AllowEdit = false;
                    gvwView.Columns[i].OptionsFilter.AllowFilter = false;
                    gvwView.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    gvwView.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 23, FontStyle.Bold);
                    gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    if (i > 0)
                    {
                        gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        gvwView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gvwView.Columns[i].DisplayFormat.FormatString = "#,0.##";
                    }


                }
                gvwView.Columns["DIV"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvwView.EndUpdate();
            }
            catch (Exception ex)
            { }
        }
        private void gvw_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

        }

        #endregion

        #endregion

        #region Event
        void DWMYClick(string argButtonText, string argButtonTag)
        {
            ComVar.Var.callForm = argButtonTag;
        }

        private void menuEvent_Click(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            ComVar.Var.callForm = cnt.Tag == null ? "" : cnt.Tag.ToString();
        }

        #endregion

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void uc_month_ValueChangeEvent(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            BindingDataGrid();
            //BindingDataChart();
            this.Cursor = Cursors.Default;
        }

        private void gvwView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.CellValue.ToString().Contains("GREEN"))
                {
                    {
                        e.Appearance.BackColor = Color.LimeGreen; e.Appearance.ForeColor = Color.White;
                        e.Appearance.BackColor2 = Color.LimeGreen;
                    }
                }
                if (e.CellValue.ToString().Contains("YELLOW"))
                {
                    e.Appearance.BackColor = Color.Yellow; e.Appearance.BackColor2 = Color.Yellow; e.Appearance.ForeColor = Color.Black;
                }
                if (e.CellValue.ToString().Contains("RED"))
                {
                    e.Appearance.BackColor = Color.Red; e.Appearance.BackColor2 = Color.Red; e.Appearance.ForeColor = Color.White;
                }
            }
            catch { }
        }

        private void gvwView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (e.Column.FieldName.Equals("MR2_FILE") ||
                    e.Column.FieldName.Equals("MR31_FILE") ||
                    e.Column.FieldName.Equals("MR32_FILE") ||
                    e.Column.FieldName.Equals("MR33_FILE") ||
                    e.Column.FieldName.Equals("TRIAL_FILE") ||
                    e.Column.FieldName.Equals("EX_FILE") ||
                    e.Column.FieldName.Equals("MR4_FILE"))
                {

                    string FileName = gvwView1.GetRowCellDisplayText(e.RowHandle, gvwView1.Columns[e.Column.FieldName + "_NM"]);
                    if (!FileName.Equals(""))
                    {
                        string fileTemp = e.Column.FieldName.Split('_')[0].ToString();

                        string DPA = gvwView1.GetRowCellDisplayText(e.RowHandle, gvwView1.Columns["DPA"]);
                        string TD_Code = gvwView1.GetRowCellDisplayText(e.RowHandle, gvwView1.Columns["TD_CODE"]);
                        string MODEL_CD = gvwView1.GetRowCellDisplayText(e.RowHandle, gvwView1.Columns["MODEL_CD"]);
                        string SEASON = gvwView1.GetRowCellDisplayText(e.RowHandle, gvwView1.Columns["SEASON"]);
                        ProceesingFile(FileName, fileTemp, DPA, MODEL_CD, TD_Code, SEASON);
                    }
                }
            }
            catch (Exception ex)
            { }

        }

        private void ProceesingFile(string FileName, string Filetemp, string DPA, string Model_Code, string TD_code, string Season)
        {
            string file_path = "";
            try
            {
               
                byte[] MyData = new byte[0];
                DataTable dt = SEL_FILE(Filetemp, DPA
                                             , Model_Code
                                             , TD_code
                                             , Season);
                if (dt == null || dt.Rows[0]["MR_FILE"].ToString() == "" || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Can't show file .! ");
                    return;
                }
                MyData = (byte[])dt.Rows[0]["MR_FILE"];

                int ArraySize = new int();
                ArraySize = MyData.GetUpperBound(0) + 1;
               
                CheckingFolder("file");
                file_path = Directory.GetCurrentDirectory() + @"\file\";
                //deleteFilesInDirectory(file_path);
                var dir = new DirectoryInfo(file_path);
                foreach (var file in dir.GetFiles())
                {
                    try
                    {
                        file.Delete();
                    }
                    catch (IOException)
                    {
                       // MessageBox.Show("This file is opening! Please close it!");
                    }
                }

                // if (!File.Exists(file_path + FileName)) Neu chua co thi lam
                // {
                //FileStream fs = new FileStream(file_path + FileName, FileMode.OpenOrCreate, FileAccess.Write);
                //fs.Write(MyData, 0, ArraySize);
                //fs.Close();
                //  }
                // Open File
                //Process.Start(file_path + FileName);
                using (FileStream fs = new FileStream(file_path + FileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fs.Write(MyData, 0, ArraySize);
                    fs.Close();
                    Process.Start(file_path + FileName);
                   
                }
            }
            catch(Exception ex) { }
            

            
        }

        public static void deleteFilesInDirectory(string folderPath)
        {
            try
            {
                var dir = new DirectoryInfo(folderPath);
                dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                dir.Delete(true);
                MessageBox.Show(folderPath + " has been cleaned.");
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show(ex.Message);
                return;

            }
        }     
        public void CheckingFolder(string arg_folder)
        {
            if (!Directory.Exists(Environment.CurrentDirectory + "\\" + arg_folder))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\" + arg_folder);
        }

        RepositoryItemTextEdit repositoryItemTextEditReadOnly = new RepositoryItemTextEdit();

        private void gvwView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {

            try
            {
                //if (gvwView1.GetRowCellValue(e.RowHandle, gvwView1.Columns["MR2_FILE"]).ToString().Equals(""))
                //{
                //    this.repositoryItemTextEditReadOnly.ReadOnly = true;
                //    e.RepositoryItem = repositoryItemTextEditReadOnly;
                //}


            }
            catch { }
        }

        private void gvwView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            { }
        }

        private void gvwView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {

            string tomau_row = gvwView1.GetRowCellDisplayText(e.RowHandle, "SEASON_NAME");
            if (tomau_row.Contains("TOTAL"))
            {
                e.Appearance.BackColor = Color.FromArgb(188, 188, 188);
                e.Appearance.ForeColor = Color.Yellow;
            }

        }

    }
}