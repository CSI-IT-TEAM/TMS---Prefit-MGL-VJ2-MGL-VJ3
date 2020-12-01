using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.OracleClient;
using System.Data;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;

namespace FORM
{
    public partial class frm_msg_confirm_ups : Form
    {
        //public IPEX_Monitor.ClassLib.Class_Sound sound = new IPEX_Monitor.ClassLib.Class_Sound("waterdrop.wav");
       
        public frm_msg_confirm_ups(string ARG_STYLE,string ARG_SIZE,string ARG_PROD)
        {
            InitializeComponent();
            Prod = ARG_PROD;
        }

        public frm_msg_confirm_ups(string _sDate, string _sLineCD, string _sUPCMLineCD, string _sUPSMLineCD, string _sStyleCD, string _sCS_Size, string _sPrio_Input, string _sQty, string _sOPCD)
        {
            InitializeComponent();
            sDate = _sDate;
            sLineCD = _sLineCD;
            sUPCMLineCD = _sUPCMLineCD;
            sUPSMLineCD = _sUPSMLineCD;
            sStyleCD = _sStyleCD;
            sCS_Size = _sCS_Size;
            sPrio_Input = _sPrio_Input;
            Prod = _sQty;
            sOPCD = _sOPCD;
            if (_sOPCD.Equals("UPS"))
                btnStopAll.Visible = true;
            else
                btnStopAll.Visible = false;
        }
        private static int iTotalPC =  20;
        private bool sSearchAgain = false;

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        #region variable
        //string Style, Size ;
        private CellColorHelper _CellColorHelper;
        DataTable dt_color, dt_save;        

        public delegate void ButtonCloseHandler(bool sSearchAgain);
        public delegate void ButtonOKHandler(DataTable dt);
        public delegate void ButtonReasonHandler(DataTable dt);
        public delegate void ButtonTransferHandler(DataTable dt);
        string sDate, sOPCD, sLineCD, sUPCMLineCD, sUPSMLineCD, sStyleCD, sCS_Size, sPrio_Input, Prod, sReason = "";
        #endregion
        public event ButtonCloseHandler OnClosing = null;
        public event ButtonOKHandler OnConfirm = null;
        public event ButtonReasonHandler OnConfirmReason = null;
        public event ButtonTransferHandler OnConfirmTransfer = null;

        #region DB
        public DataTable SELECT_STITCHING_REASON()
        {

            System.Data.DataSet retDS;
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(1);
            MyOraDB.Process_Name = "MES.PKG_SMT_EMD.SELECT_STITCHING_REASON";

            MyOraDB.Parameter_Name[0] = "CV_1";

            MyOraDB.Parameter_Type[0] = (char)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = "";

            MyOraDB.Add_Select_Parameter(true);

            retDS = MyOraDB.Exe_Select_Procedure();

            if (retDS == null) return null;

            return retDS.Tables[MyOraDB.Process_Name];
        }

        public DataTable SELECT_STITCHING_LINE_CHANGE(string ARG_PLANT)
        {

            System.Data.DataSet retDS;
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(2);
            MyOraDB.Process_Name = "MES.PKG_SMT_EMD.SELECT_STIT_LINE_CHANGE";

            MyOraDB.Parameter_Name[0] = "ARG_PLANT";
            MyOraDB.Parameter_Name[1] = "CV_1";

            MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (char)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = ARG_PLANT;
            MyOraDB.Parameter_Values[1] = "";

            MyOraDB.Add_Select_Parameter(true);

            retDS = MyOraDB.Exe_Select_Procedure();

            if (retDS == null) return null;

            return retDS.Tables[MyOraDB.Process_Name];
        }

        #endregion

        private void frm_msg_Load(object sender, EventArgs e)
        {
            lblDate.Text = ": " + sDate.ToString().Substring(0, 4) + "-" + sDate.ToString().Substring(4, 2) + "-" + sDate.ToString().Substring(6, 2);
            lblLine.Text = ": " + sUPCMLineCD;
            lblStyle.Text = ": " + sStyleCD;
            lblSize.Text = ": " + sCS_Size;
            lblHH.Text = ": " + sPrio_Input;
            lblQty.Text = ": " + Prod;
            _CellColorHelper = new CellColorHelper(gvwView);
            DataTable DT = SELECT_STITCHING_REASON();
            if (DT != null && DT.Rows.Count > 0)
            {
                ComboBox_Setting(cboReason, DT, 0, 1, 1);
                cboReason.SelectedValue = sReason;
            }
            //Search_Data();
            DT = null;
            if (sLineCD == "51LG")
                DT = SELECT_STITCHING_LINE_CHANGE(sLineCD + sUPSMLineCD);
            else
                DT = SELECT_STITCHING_LINE_CHANGE(sLineCD);
            if (DT != null && DT.Rows.Count > 0)
            {
                ComboBox_Setting(cboUPSLine, DT, 0, 1, 1);
                cboUPSLine.SelectedValue = sUPSMLineCD;
            }
        }

        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
        private void formatgrid()
        {
            for (int i = 0; i < gvwView.Columns.Count; i++)
            {
                gvwView.Columns[i].OptionsColumn.ReadOnly = true;
                gvwView.Columns[i].OptionsColumn.AllowEdit = false;
                gvwView.Columns[i].OptionsFilter.AllowFilter = false;
                gvwView.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                gvwView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
               
                gvwView.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 10, FontStyle.Bold);
                gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvwView.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                if (gvwView.Columns[i].FieldName.Contains("QTY") || gvwView.Columns[i].FieldName.Contains("CONFIRM"))
                {                     
                    if (gvwView.Columns[i].FieldName.Contains("QTY"))
                    {
                        gvwView.Columns[i].ColumnEdit = this.repositoryItemMemoEdit1;
                        gvwView.Columns[i].Width = 159;
                        gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    }
                    else
                    {
                        gvwView.Columns[i].Width = 65;
                        gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    }
                }
                else
                {
                    gvwView.Columns[i].Visible = false;
                }
                              
            }
            gvwView.RowHeight = 50;
            grdView.Height = gvwView.RowCount * 50 + 10;
            if (gvwView.RowCount < 3)
            {                
                pnlMain.Height = 420;
                this.Height = 431;
            }
            else
            {
                pnlMain.Height = 265 + grdView.Height;
                this.Height = 276 + grdView.Height;
            }
        }

        public void BingDingData(DataTable dt)
        {
            try
            {
                //grdView.Visible = false;
                //splashScreenManager1.ShowWaitForm();
                grdView.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    sReason = dt.Rows[0]["REASON"].ToString();
                }
                //AddUnboundColumn(gvwView);
                //gvwView.CustomUnboundColumnData += gvwView_CustomUnboundColumnData;
                dt_save = dt.Copy();
                dt_color = dt.Copy();
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["FLAG"].ToString().Equals("FINISH"))
                    {
                        btnOK.Enabled = false;
                        btnApply.Enabled = false;
                        btnUpdate.Enabled = false;
                        btnTransfer.Enabled = false;
                    }
                    else if (dt.Rows[0]["FLAG"].ToString().Equals("HIDE"))
                    {
                        btnOK.Enabled = false;
                        btnTransfer.Enabled = false;
                    }
                }
                //cach 1
                RepositoryItemCheckEdit checkEdit = grdView.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
                checkEdit.ValueUnchecked = "_";
                checkEdit.ValueChecked = "Y";
                checkEdit.ValueGrayed = "N";

                checkEdit.PictureUnchecked = Properties.Resources._null;
                checkEdit.PictureChecked = Properties.Resources.E_OK;
                checkEdit.PictureGrayed = Properties.Resources.E_Confirm;
                checkEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;

                gvwView.Columns["C1_CONFIRM_YN"].ColumnEdit = checkEdit;
                gvwView.Columns["C2_CONFIRM_YN"].ColumnEdit = checkEdit;
                grdView.RepositoryItems.Add(checkEdit);



                // cach 2
                //RepositoryItemImageComboBox imageCombo = grdView1.RepositoryItems.Add("ImageComboBoxEdit") as RepositoryItemImageComboBox;

                //DevExpress.Utils.ImageCollection images = new DevExpress.Utils.ImageCollection();

                //images.AddImage(Properties.Resources.E_OK2);
                //images.AddImage(Properties.Resources.E_Cancel2);
                //images.AddImage(Properties.Resources.E_Confirm2);
                //images.AddImage(Properties.Resources._null);
                //images.ImageSize = new System.Drawing.Size(50, 50);
                //imageCombo.LargeImages = images;

                //imageCombo.Items.Add(new ImageComboBoxItem("Y", (string)"Y", 0));
                //imageCombo.Items.Add(new ImageComboBoxItem("I", (string)"I", 1));
                //imageCombo.Items.Add(new ImageComboBoxItem("N", (string)"N", 2));
                //imageCombo.Items.Add(new ImageComboBoxItem("", (string)"", 3));
                //imageCombo.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;

                //gvwView.Columns["C1_CONFIRM_YN"].ColumnEdit = imageCombo;
                //gvwView.Columns["C2_CONFIRM_YN"].ColumnEdit = imageCombo;
                //grdView1.RepositoryItems.Add(imageCombo);   


                formatgrid();
                //grdView.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //grdView.Visible = true;
            }
            finally
            {
                //splashScreenManager1.CloseWaitForm();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (OnClosing != null)
                OnClosing(sSearchAgain);
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {               
            DataTable SelectDT = new DataTable();
            SelectDT.Columns.Add("ITPO_TYPE");
            SelectDT.Columns.Add("FA_DATE");
            SelectDT.Columns.Add("PLANT_CD");
            SelectDT.Columns.Add("FGA_MLINE");
            SelectDT.Columns.Add("UPS_MLINE");
            SelectDT.Columns.Add("STYLE_CD");
            SelectDT.Columns.Add("SIZE_CD");
            SelectDT.Columns.Add("PCARD_NAME");
            SelectDT.Columns.Add("PCARD_QTY");
            SelectDT.Columns.Add("REASON_PAUSE");
            for (int i_row = 0; i_row < dt_save.Rows.Count; i_row++)
            {                
                for (int i_col = 0; i_col < dt_save.Columns.Count; i_col++)
                {
                    if (dt_save.Columns[i_col].ColumnName.Contains("PCARD_NAME"))
                    {
                        if (dt_save.Rows[i_row][i_col - 1].ToString().Equals("N") || dt_save.Rows[i_row][i_col - 1].ToString().Equals("D"))
                        {
                            DataRow vDr = SelectDT.NewRow();
                            vDr["ITPO_TYPE"] = dt_save.Rows[i_row][i_col - 1].ToString();
                            vDr["FA_DATE"] = sDate;
                            vDr["PLANT_CD"] = sLineCD;
                            vDr["FGA_MLINE"] = sUPCMLineCD;
                            vDr["UPS_MLINE"] = sUPSMLineCD;
                            vDr["STYLE_CD"] = sStyleCD;
                            vDr["SIZE_CD"] = sCS_Size;
                            vDr["PCARD_NAME"] = dt_save.Rows[i_row][i_col].ToString();
                            vDr["PCARD_QTY"] = dt_save.Rows[i_row][i_col - 2].ToString().Split('\n')[1].Split(':')[1].Replace(" ","");
                            vDr["REASON_PAUSE"] = "";
                            SelectDT.Rows.InsertAt(vDr, SelectDT.Rows.Count);
                        }
                    }
                }                
            }
            if (SelectDT.Rows.Count > 0)
            {
                sSearchAgain = true;
                if (OnConfirm != null)
                    OnConfirm(SelectDT);
            }
            else
            {
                AutoClosingMessageBox.Show("Not set! Can not save Pcard", "Warning!", 2000);
            }
            button1_Click_1(null, null);
        }

        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }


        private void btnApply_Click(object sender, EventArgs e)
        {
            string sReason = "000";
            if(cboReason.SelectedValue != null)
            {
                sReason = cboReason.SelectedValue.ToString();
            }
            if (sReason == "000")
            {
                cboReason.DroppedDown = true;
                return;
            }
            else
            {
                DataTable SelectDT = new DataTable();
                SelectDT.Columns.Add("ITPO_TYPE");
                SelectDT.Columns.Add("FA_DATE");
                SelectDT.Columns.Add("PLANT_CD");
                SelectDT.Columns.Add("FGA_MLINE");
                SelectDT.Columns.Add("UPS_MLINE");
                SelectDT.Columns.Add("STYLE_CD");
                SelectDT.Columns.Add("SIZE_CD");
                SelectDT.Columns.Add("PCARD_NAME");
                SelectDT.Columns.Add("PCARD_QTY");
                SelectDT.Columns.Add("REASON_PAUSE");
                for (int i_row = 0; i_row < dt_save.Rows.Count; i_row++)
                {
                    for (int i_col = 0; i_col < dt_save.Columns.Count; i_col++)
                    {
                        if (dt_save.Columns[i_col].ColumnName.Contains("PCARD_NAME"))
                        {
                            
                            if (!dt_color.Rows[i_row][i_col - 2].ToString().Equals(dt_save.Rows[i_row][i_col - 2].ToString()) && sOPCD.Equals("UPS"))
                            {
                                DataRow vDr = SelectDT.NewRow();
                                vDr["ITPO_TYPE"] = dt_save.Rows[i_row][i_col - 1].ToString();
                                vDr["FA_DATE"] = sDate;
                                vDr["PLANT_CD"] = sLineCD;
                                vDr["FGA_MLINE"] = sUPCMLineCD;
                                vDr["UPS_MLINE"] = sUPSMLineCD;
                                vDr["STYLE_CD"] = sStyleCD;
                                vDr["SIZE_CD"] = sCS_Size;
                                vDr["PCARD_NAME"] = dt_save.Rows[i_row][i_col].ToString();
                                vDr["PCARD_QTY"] = dt_save.Rows[i_row][i_col - 2].ToString().Split('\n')[1].Split(':')[1].Replace(" ", "");
                                vDr["REASON_PAUSE"] = cboReason.SelectedValue.ToString();
                                SelectDT.Rows.InsertAt(vDr, SelectDT.Rows.Count);
                            }
                            else if (!dt_color.Rows[i_row][i_col - 1].ToString().Equals(dt_save.Rows[i_row][i_col - 1].ToString()) && !sOPCD.Equals("UPS"))
                            {
                                DataRow vDr = SelectDT.NewRow();
                                vDr["ITPO_TYPE"] = dt_save.Rows[i_row][i_col - 1].ToString();
                                vDr["FA_DATE"] = sDate;
                                vDr["PLANT_CD"] = sLineCD;
                                vDr["FGA_MLINE"] = sUPCMLineCD;
                                vDr["UPS_MLINE"] = sUPSMLineCD;
                                vDr["STYLE_CD"] = sStyleCD;
                                vDr["SIZE_CD"] = sCS_Size;
                                vDr["PCARD_NAME"] = dt_save.Rows[i_row][i_col].ToString();
                                vDr["PCARD_QTY"] = dt_save.Rows[i_row][i_col - 2].ToString().Split('\n')[1].Split(':')[1].Replace(" ", "");
                                vDr["REASON_PAUSE"] = cboReason.SelectedValue.ToString();
                                SelectDT.Rows.InsertAt(vDr, SelectDT.Rows.Count);
                            }
                        }
                    }
                }
                if (SelectDT.Rows.Count > 0)
                {
                    sSearchAgain = true;
                    if (OnConfirm != null)
                        OnConfirm(SelectDT);
                    button1_Click_1(null, null);
                }
                else
                {
                    AutoClosingMessageBox.Show("Please Select Pcard!", "Warning!", 2000);
                }                
            }
        }

        private void btnStopAll_Click(object sender, EventArgs e)
        {
            string sReason = "000";
            if (cboReason.SelectedValue != null)
            {
                sReason = cboReason.SelectedValue.ToString();
            }
            if (sReason == "000")
            {
                cboReason.DroppedDown = true;
                return;
            }
            else
            {
                DataTable SelectDT = new DataTable();
                SelectDT.Columns.Add("ITPO_TYPE");
                SelectDT.Columns.Add("FA_DATE");
                SelectDT.Columns.Add("PLANT_CD");
                SelectDT.Columns.Add("FGA_MLINE");
                SelectDT.Columns.Add("UPS_MLINE");
                SelectDT.Columns.Add("STYLE_CD");
                SelectDT.Columns.Add("SIZE_CD");
                SelectDT.Columns.Add("PCARD_NAME");
                SelectDT.Columns.Add("PCARD_QTY");
                SelectDT.Columns.Add("REASON_PAUSE");
                for (int i_row = 0; i_row < dt_save.Rows.Count; i_row++)
                {
                    for (int i_col = 0; i_col < dt_save.Columns.Count; i_col++)
                    {
                        if (dt_save.Columns[i_col].ColumnName.Contains("PCARD_NAME"))
                        {
                            if (dt_save.Rows[i_row][i_col - 1].ToString().Equals("T"))
                            {
                                DataRow vDr = SelectDT.NewRow();
                                vDr["ITPO_TYPE"] = dt_save.Rows[i_row][i_col - 1].ToString();
                                vDr["FA_DATE"] = sDate;
                                vDr["PLANT_CD"] = sLineCD;
                                vDr["FGA_MLINE"] = sUPCMLineCD;
                                vDr["UPS_MLINE"] = sUPSMLineCD;
                                vDr["STYLE_CD"] = sStyleCD;
                                vDr["SIZE_CD"] = sCS_Size;
                                vDr["PCARD_NAME"] = dt_save.Rows[i_row][i_col].ToString();
                                vDr["PCARD_QTY"] = dt_save.Rows[i_row][i_col - 2].ToString().Split('\n')[1].Split(':')[1].Replace(" ", "");
                                vDr["REASON_PAUSE"] = cboReason.SelectedValue.ToString();
                                SelectDT.Rows.InsertAt(vDr, SelectDT.Rows.Count);
                            }
                        }
                    }
                }
                if (SelectDT.Rows.Count > 0)
                {
                    sSearchAgain = true;
                    if (OnConfirm != null)
                        OnConfirm(SelectDT);
                }
                button1_Click_1(null, null);
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            DataTable SelectDT = new DataTable();
            SelectDT.Columns.Add("ITPO_TYPE");
            SelectDT.Columns.Add("FA_DATE");
            SelectDT.Columns.Add("PLANT_CD");
            SelectDT.Columns.Add("FGA_MLINE");
            SelectDT.Columns.Add("UPS_MLINE");
            SelectDT.Columns.Add("STYLE_CD");
            SelectDT.Columns.Add("SIZE_CD");
            SelectDT.Columns.Add("PCARD_NAME");
            SelectDT.Columns.Add("LINE_CHANGE");
            if (cboUPSLine.SelectedValue == null) return;
            for (int i_row = 0; i_row < dt_save.Rows.Count; i_row++)
            {
                for (int i_col = 0; i_col < dt_save.Columns.Count; i_col++)
                {
                    if (dt_save.Columns[i_col].ColumnName.Contains("PCARD_NAME"))
                    {
                        if (dt_save.Rows[i_row][i_col - 1].ToString().Equals("N"))
                        {
                            DataRow vDr = SelectDT.NewRow();
                            vDr["ITPO_TYPE"] = dt_save.Rows[i_row][i_col - 1].ToString();
                            vDr["FA_DATE"] = sDate;
                            vDr["PLANT_CD"] = sLineCD;
                            vDr["FGA_MLINE"] = sUPCMLineCD;
                            vDr["UPS_MLINE"] = sUPSMLineCD;
                            vDr["STYLE_CD"] = sStyleCD;
                            vDr["SIZE_CD"] = sCS_Size;
                            vDr["PCARD_NAME"] = dt_save.Rows[i_row][i_col].ToString();
                            vDr["LINE_CHANGE"] = cboUPSLine.SelectedValue.ToString();
                            SelectDT.Rows.InsertAt(vDr, SelectDT.Rows.Count);
                        }
                    }
                }
            }
            if (SelectDT.Rows.Count > 0)
            {
                sSearchAgain = true;
                if (OnConfirmTransfer != null)
                    OnConfirmTransfer(SelectDT);                
            }
            button1_Click_1(null, null);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //string sReason = cboReason.SelectedValue.ToString();
            string sReason = "000";
            if (cboReason.SelectedValue != null)
            {
                sReason = cboReason.SelectedValue.ToString();
            }
            if (sReason == "000")
            {
                cboReason.DroppedDown = true;
                return;
            }
            else
            {
                DataTable SelectDT = new DataTable();
                SelectDT.Columns.Add("ITPO_TYPE");
                SelectDT.Columns.Add("FA_DATE");
                SelectDT.Columns.Add("PLANT_CD");
                SelectDT.Columns.Add("FGA_MLINE");
                SelectDT.Columns.Add("UPS_MLINE");
                SelectDT.Columns.Add("STYLE_CD");
                SelectDT.Columns.Add("SIZE_CD");
                SelectDT.Columns.Add("PCARD_NAME");
                SelectDT.Columns.Add("REASON_CD");
                for (int i_row = 0; i_row < dt_save.Rows.Count; i_row++)
                {
                    for (int i_col = 0; i_col < dt_save.Columns.Count; i_col++)
                    {
                        if (dt_save.Columns[i_col].ColumnName.Contains("PCARD_NAME"))
                        {
                            DataRow vDr = SelectDT.NewRow();
                            vDr["ITPO_TYPE"] = dt_save.Rows[i_row][i_col - 1].ToString();
                            vDr["FA_DATE"] = sDate;
                            vDr["PLANT_CD"] = sLineCD;
                            vDr["FGA_MLINE"] = sUPCMLineCD;
                            vDr["UPS_MLINE"] = sUPSMLineCD;
                            vDr["STYLE_CD"] = sStyleCD;
                            vDr["SIZE_CD"] = sCS_Size;
                            vDr["PCARD_NAME"] = dt_save.Rows[i_row][i_col].ToString();
                            vDr["REASON_CD"] = cboReason.SelectedValue.ToString();
                            SelectDT.Rows.InsertAt(vDr, SelectDT.Rows.Count);
                        }
                    }
                }                
                if (SelectDT.Rows.Count > 0)
                {
                    sSearchAgain = true;
                    if (OnConfirmReason != null)
                        OnConfirmReason(SelectDT);
                }
                button1_Click_1(null, null);
            }
            button1_Click_1(null, null);
        }

        public void ComboBox_Setting(ComboBox sComboBox, DataTable dt_ret, int sValueIndex, int sDisplayMemberIndex, int DisplayType)
        {
            try
            {
                sComboBox.SelectedIndex = -1;
                sComboBox.ValueMember = "CODE";
                sComboBox.DisplayMember = "NAME";
                if (dt_ret == null || dt_ret.Rows.Count == 0) return;
                sComboBox.DataSource = dt_ret;

                if (sComboBox.Items.Count > 0) sComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                // Db.ComFunction.User_Message(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Color preverBackgroundColor(Color c)
        {
            if(c.Equals(Color.Orange))
            {
                return Color.CornflowerBlue;
            }
            return Color.Orange;
        }

        private void gvwView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName.Contains("QTY") && e.CellValue.ToString() != "")
            {
                if (sOPCD.Equals("UPS"))
                {
                    if (dt_color.Rows[e.RowHandle][e.Column.FieldName].ToString().Contains("_G"))
                    {
                        e.Appearance.BackColor = Color.LimeGreen;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else if (dt_color.Rows[e.RowHandle][e.Column.FieldName].ToString().Contains("_O"))
                    {
                        e.Appearance.BackColor = Color.Orange;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else if (dt_color.Rows[e.RowHandle][e.Column.FieldName].ToString().Contains("_R"))
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else if (dt_color.Rows[e.RowHandle][e.Column.FieldName].ToString().Contains("_B"))
                    {
                        e.Appearance.BackColor = Color.DodgerBlue;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.White;
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
                else
                {
                    e.Appearance.Font = new Font("Calibri", 13, FontStyle.Bold);
                    if (dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "CONFIRM_YN"].ToString().Contains("Y"))
                    {
                        e.Appearance.BackColor = Color.LimeGreen;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else if (dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "CONFIRM_YN"].ToString().Contains("I"))
                    {
                        e.Appearance.BackColor = Color.Orange;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else if (dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "CONFIRM_YN"].ToString().Contains("N"))
                    {
                        e.Appearance.BackColor = Color.DodgerBlue;
                        e.Appearance.ForeColor = Color.White;
                    }

                }
            }
        }

        private void gvwView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.FieldName.Contains("CONFIRM_YN") && e.CellValue.ToString() != "")
            {
                if (sOPCD.Equals("UPS"))
                {
                    if (dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"].ToString().Contains("_B"))
                    {
                        dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"] = gvwView.GetRowCellDisplayText(e.RowHandle, e.Column.FieldName.Substring(0, 3) + "QTY").Replace("_B", "_O");
                        _CellColorHelper.SetCellColor(e.RowHandle, gvwView.Columns[e.Column.FieldName.Substring(0, 3) + "QTY"], Color.Orange);
                    }
                    else if (dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"].ToString().Contains("_O")
                        && dt_save.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"].ToString().Contains("_O"))
                    {
                        dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"] = gvwView.GetRowCellDisplayText(e.RowHandle, e.Column.FieldName.Substring(0, 3) + "QTY").Replace("_O", "_B");
                        _CellColorHelper.SetCellColor(e.RowHandle, gvwView.Columns[e.Column.FieldName.Substring(0, 3) + "QTY"], Color.DodgerBlue);

                    }
                    else if (dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"].ToString().Contains("_O")
                            && dt_save.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"].ToString().Contains("_B"))
                    {
                        dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"] = gvwView.GetRowCellDisplayText(e.RowHandle, e.Column.FieldName.Substring(0, 3) + "QTY").Replace("_O", "_B");
                        _CellColorHelper.SetCellColor(e.RowHandle, gvwView.Columns[e.Column.FieldName.Substring(0, 3) + "QTY"], Color.DodgerBlue);

                    }
                    else if (dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"].ToString().Contains("_O")
                        && dt_save.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"].ToString().Contains("_R"))
                    {
                        dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"] = gvwView.GetRowCellDisplayText(e.RowHandle, e.Column.FieldName.Substring(0, 3) + "QTY").Replace("_O", "_R");
                        _CellColorHelper.SetCellColor(e.RowHandle, gvwView.Columns[e.Column.FieldName.Substring(0, 3) + "QTY"], Color.Red);

                    }
                    else if (dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"].ToString().Contains("_R"))
                    {
                        dt_color.Rows[e.RowHandle][e.Column.FieldName.Substring(0, 3) + "QTY"] = gvwView.GetRowCellDisplayText(e.RowHandle, e.Column.FieldName.Substring(0, 3) + "QTY").Replace("_R", "_O");
                        _CellColorHelper.SetCellColor(e.RowHandle, gvwView.Columns[e.Column.FieldName.Substring(0, 3) + "QTY"], Color.Orange);
                    }
                }
                else
                {
                    if (dt_color.Rows[e.RowHandle][e.Column.FieldName].ToString().Contains("N"))
                    {
                        dt_color.Rows[e.RowHandle][e.Column.FieldName] = gvwView.GetRowCellValue(e.RowHandle, e.Column.FieldName).ToString().Replace("N", "I");
                        _CellColorHelper.SetCellColor(e.RowHandle, gvwView.Columns[e.Column.FieldName.Substring(0, 3) + "QTY"], Color.Orange);
                    }
                    else if (dt_color.Rows[e.RowHandle][e.Column.FieldName].ToString().Contains("I"))
                    {
                        dt_color.Rows[e.RowHandle][e.Column.FieldName] = gvwView.GetRowCellDisplayText(e.RowHandle, e.Column.FieldName).ToString().Replace("I", "N");
                        _CellColorHelper.SetCellColor(e.RowHandle, gvwView.Columns[e.Column.FieldName.Substring(0, 3) + "QTY"], Color.DodgerBlue);

                    }
                }
            }
        }

        private void gvwView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (e.Column.FieldName.Contains("CONFIRM_YN"))
            //{
            //e.Appearance.FillRectangle(e.Cache, e.Bounds) ; 
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo  cellInfo = new DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo(); 
            
            //DevExpress.Utils.ImageCollection.DrawImageListImage(e.Cache, ImageCollection32onSoftwareXtraForm, index, cellInfo.CellValueRect)  
            //e.Handled = True  
       
            //}
        }

        void gvwView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int imageIndex = e.ListSourceRowIndex % 3;
            e.Value = GetImageByImageIndex(imageIndex);
        }

        private object GetImageByImageIndex(int imageIndex)
        {
            switch (imageIndex)
            {
                case 0: return Properties.Resources._null;
                case 1: return Properties.Resources.E_OK;
                case 2: return Properties.Resources.E_Confirm;
                case 3: return Properties.Resources.E_Confirm;
            }
            return null;
        }

        private void AddUnboundColumn(DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            view.Columns["C1_CONFIRM_YN"].UnboundType = DevExpress.Data.UnboundColumnType.Object;
            RepositoryItemPictureEdit ri1 = new RepositoryItemPictureEdit();
            ri1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            view.Columns["C1_CONFIRM_YN"].ColumnEdit = ri1;

            view.Columns["C2_CONFIRM_YN"].UnboundType = DevExpress.Data.UnboundColumnType.Object;
            RepositoryItemPictureEdit ri2 = new RepositoryItemPictureEdit();
            ri2.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            view.Columns["C2_CONFIRM_YN"].ColumnEdit = ri2;
            //DevExpress.XtraGrid.Columns.GridColumn col1 = view.Columns.AddVisible("C1_CONFIRM_YN");
            //col1.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            //RepositoryItemPictureEdit ri1 = new RepositoryItemPictureEdit();
            //ri1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            //col1.ColumnEdit = ri1;

            //DevExpress.XtraGrid.Columns.GridColumn col2 = view.Columns.AddVisible("C2_CONFIRM_YN");
            //col2.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            //RepositoryItemPictureEdit ri2 = new RepositoryItemPictureEdit();
            //ri2.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            //col2.ColumnEdit = ri2;
        }
    }
}
