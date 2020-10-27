using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using System.Threading;

namespace FORM
{
    public partial class FRM_SMT_EMD_OLD : Form
    {
        public FRM_SMT_EMD_OLD()
        {
            InitializeComponent();
           
        }

        #region Global Variant
        int _iCountReload = 0;
        UC.NavBar nvFactory = new UC.NavBar("Factory");
        UC.NavBar nvBottom = new UC.NavBar("Bottom");
        #endregion
        #region Load/Visible Change/ Timer Date
        private void Form_Load(object sender, EventArgs e)
        {
           
          
            pnHeader.Height = 75;
            pnHeader.BackColor = Color.FromArgb(0, 176, 80);
            //Add UC
            spl1_1.Panel1.Controls.Add(nvFactory);
            nvFactory.Dock = DockStyle.Fill;
            nvFactory.OnMenuClick += OnUCMenuClick;
            spl2_1.Panel1.Controls.Add(nvBottom);
            nvBottom.Dock = DockStyle.Fill;
            nvBottom.OnMenuClick += OnUCMenuClick;
            //Binding Data Grid
           // BindingDataGrid(); KHONG BINDING VI VISIBLE CHANGE DA GOI

        }
        void OnUCMenuClick(string TitleCode,string MenuCode)
        {
            //MessageBox.Show(TitleCode + " / " + MenuCode);
            ComVar.Var._strValue1 = TitleCode;
            ComVar.Var._strValue2 = MenuCode;

            if (!MenuCode.Equals("114"))
                ComVar.Var.callForm = MenuCode;
            else
            {
                FRM_SMT_EMD_UNDER under = new FRM_SMT_EMD_UNDER();
                under.ShowDialog();
               // PictureBox pt = new PictureBox();
                // 
                // pictureBox1
                // 
                //pt.Dock = System.Windows.Forms.DockStyle.Fill;
                //pt.Image = global::FORM.Properties.Resources.undermaintanance;
                //pt.Location = new System.Drawing.Point(0, 0);
                //pt.Name = "pictureBox1";
                //pt.Size = new System.Drawing.Size(759, 393);
                //pt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                //pt.TabIndex = 0;
                //pt.TabStop = false;
                //pt.DoubleClick += pt_DoubleClick;
                //this.Controls.Add(pt);
                //pt.BringToFront();
            }

        }

        void pt_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("db Click");
        }
       
        private void Form_VisibleChanged(object sender, EventArgs e)
        {

            if (this.Visible)
            {
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
                BindingDataGrid();
                _iCountReload = 0;

            }

        }
        #endregion

        #region Ora
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
        private void BindingDataGrid()
        {
            try
            {
                grdView.ShowLoadingPanel();
                grdViewB1.ShowLoadingPanel();
                DataTable dt = SP_SMT_EMD_GRID_DATA_SELECT("Q", "VJ");
                grdBase.DataSource = grdBaseB1.DataSource = dt;
                FormatGrid();
                FormatGridB();
                grdView.HideLoadingPanel();
                grdViewB1.HideLoadingPanel();
            }
            catch { }
            finally
            { 
            BindingSummary();
            }
        }
        private void BindingSummary()
        { 
            try
            { 
            DataTable dt = SP_SMT_EMD_GRID_DATA_SELECT("ALL", "VJ");
            if (dt != null && dt.Rows.Count > 0)
            {
                lblDplan_Qty.Text = string.Format("{0:0,0}", dt.Rows[0]["D_PLAN"]);
                lblRplan_Qty.Text = string.Format("{0:0,0}", dt.Rows[0]["R_PLAN"]);
                lblAct_Qty.Text   = string.Format("{0:0,0}", dt.Rows[0]["PROD"]);
                if (Convert.ToDouble(dt.Rows[0]["P_RATE"]) >= 97)
                {  lblPRate_Per.BackColor = Color.Green;
                    lblPRate_Per.ForeColor = Color.White;
                }
                else if (Convert.ToDouble(dt.Rows[0]["P_RATE"]) >= 94)
                {
                    lblPRate_Per.BackColor = Color.Yellow;
                    lblPRate_Per.ForeColor = Color.Black;
                }
                else if (Convert.ToDouble(dt.Rows[0]["P_RATE"]) < 94)
                {
                    lblPRate_Per.BackColor = Color.Red;
                    lblPRate_Per.ForeColor = Color.White;
                }
                else
                {
                    lblPRate_Per.BackColor = Color.Transparent;
                    lblPRate_Per.ForeColor = Color.Orange;
                }
                    lblPRate_Per.Text = string.Format("{0:0.0}", dt.Rows[0]["P_RATE"]);
            }
                }
            catch { }
        }
        private void FormatGrid()
        {
            try
            {
                grdView.BeginUpdate();
                for (int i = 0; i < grdView.Columns.Count; i++)
                {

                    grdView.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    grdView.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                    grdView.Columns[i].OptionsColumn.ReadOnly = true;
                    grdView.Columns[i].OptionsColumn.AllowEdit = false;
                    grdView.Columns[i].OptionsFilter.AllowFilter = false;
                    grdView.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    grdView.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 14f, FontStyle.Regular ^ FontStyle.Bold);
                    grdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    if (i > 0)
                    {
                        grdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        //grdView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        //grdView.Columns[i].DisplayFormat.FormatString = "#,0.##";
                    }
                }
                grdView.Columns["DIV"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                grdView.EndUpdate();
            }
            catch (Exception ex)
            { }
        }
        private void FormatGridB()
        {
            try
            {
                grdViewB1.BeginUpdate();
                for (int i = 0; i < grdViewB1.Columns.Count; i++)
                {

                    grdViewB1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    grdViewB1.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                    grdViewB1.Columns[i].OptionsColumn.ReadOnly = true;
                    grdViewB1.Columns[i].OptionsColumn.AllowEdit = false;
                    grdViewB1.Columns[i].OptionsFilter.AllowFilter = false;
                    grdViewB1.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    grdViewB1.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 14f, FontStyle.Regular ^ FontStyle.Bold);
                    grdViewB1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    if (i > 0)
                    {
                        grdViewB1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        //grdViewB1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        //grdViewB1.Columns[i].DisplayFormat.FormatString = "#,0.##";
                    }
                }
                grdViewB1.Columns["DIV"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                grdViewB1.EndUpdate();
            }
            catch (Exception ex)
            { }
        }
        private void gvw_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0)
                    return;
                //if (grdView.GetRowCellValue(e.RowHandle, grdView.Columns["DIV"]).ToString().Contains("PLAN"))
                //    e.Appearance.BackColor = Color.FromArgb(228, 255, 211);
                //if (grdView.GetRowCellValue(e.RowHandle, grdView.Columns["DIV"]).ToString().Contains("R.PLAN"))
                //    e.Appearance.BackColor = Color.White;
                //if (grdView.GetRowCellValue(e.RowHandle, grdView.Columns["DIV"]).ToString().Contains("PROD"))
                //    e.Appearance.BackColor = Color.FromArgb(214, 252, 246);
                //if (grdView.GetRowCellValue(e.RowHandle, grdView.Columns["DIV"]).ToString().Contains("D.RATE"))
                //    e.Appearance.BackColor = Color.FromArgb(252, 231, 207);
                //if (grdView.GetRowCellValue(e.RowHandle, grdView.Columns["DIV"]).ToString().Contains("P.RATE"))
                    //e.Appearance.BackColor = Color.White;

                if (e.CellValue.ToString().Contains("GREEN"))
                {
                    { e.Appearance.BackColor = Color.LimeGreen; e.Appearance.ForeColor = Color.White;
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
                if (e.CellValue.ToString().Contains("GREY"))
                {
                    e.Appearance.BackColor = Color.SlateGray; e.Appearance.BackColor2 = Color.SlateGray;
                }

            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #endregion

        #region Event
        private void DWMYClick(string argButtonText, string argButtonTag)
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
            //WindowState = FormWindowState.Minimized;
            ComVar.Var.callForm = lblTitle.Tag.ToString();

        }

        private void grdViewB1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {

        }
    }
}
