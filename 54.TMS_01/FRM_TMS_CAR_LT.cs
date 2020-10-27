using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;
using System.Drawing.Drawing2D;
using System.Data.OracleClient;
using System.Reflection;
//using DevExpress.XtraCharts;
//using DevExpress.XtraGauges.Core.Model;



namespace FORM
{
    public partial class FRM_TMS_CAR_LT : Form
    {
        public FRM_TMS_CAR_LT()
        {
            InitializeComponent();
        }

        #region Define Global Variant
       // string _Lang;
        int _iStartText = 0;
        Dictionary<string, Tuple<string, string, string, string, string, string>> _dtnInit = new Dictionary<string, Tuple<string, string, string, string, string, string>>();
        int _Loc_X, _maxRow = 1;
        int _Time_Reload = 0;
       // int _GridTrip = 0;
        //DataTable _dtGrid;
        DataTable _dtData;
        int _Trip = 1, _Min;
      //  Dictionary<string,string> _dtnTrip = new Dictionary<string,string>();
        Dictionary<string, Tuple<string, string, string>> _dtn_Trip = new Dictionary<string,Tuple<string,string,string>>();
        bool _estimated = false;
        const int _LimitRow = 14;
        enum gridColum : int
        {
            Trip = 1,
            Start = 2,
            Arrival = 3,
            Line = 4,
            Style_Cd = 5,          
            Status = 6,
            Mat = 7,
            Qty = 8,
            
        }

        #endregion

        #region Event

        #region Load/Visible
        private void FRM_SMT_LEADTIME_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cbdate.DateTime = DateTime.Now;
            GoFullscreen();
         //   initForm();
            _Loc_X = pic_Car.Location.X;
            load_Data();

        }

        private void FRM_SMT_LEADTIME_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                _Time_Reload = 20;
                tmr_Time.Enabled = true;
                FinishedCarLocation();
            }
            else
            {
                tmr_Time.Enabled = false;
                // HidePic();
            }
        }
        #endregion

        #region Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            runTextModel();
        }

        private void tmr_Time_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            TimerReloadData();
            imgCarRun();
        }
        #endregion

        #region Click
        private void lblDate_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void callForm_Click(object sender, EventArgs e)
        {

            ComVar.Var.callForm = ((Control)sender).TabIndex.ToString();
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "Minimized";
        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "Closed";
        }
        #endregion

        private void lineArrow_Paint(object sender, PaintEventArgs e)
        {
            LineShape line = (LineShape)sender;
            Pen pen = new Pen(Color.FromArgb(66, 134, 244), 5);
            pen.StartCap = LineCap.ArrowAnchor;
            pen.EndCap = LineCap.ArrowAnchor;
            e.Graphics.DrawLine(pen, line.EndPoint, line.StartPoint);
        }

        #endregion Event

        #region DB
        private System.Data.DataSet Select_Ora_Grid()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.SP_TMS_LT_VC";
                //ARGMODE
                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "V_P_LINE";
                MyOraDB.Parameter_Name[1] = "V_P_YMD";
                MyOraDB.Parameter_Name[2] = "CV_1";
               // MyOraDB.Parameter_Name[3] = "OUT_CURSOR";
      
                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
               // MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;    
                MyOraDB.Parameter_Type[2] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = "001" ;
                MyOraDB.Parameter_Values[1] = cbdate.DateTime.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[2] = "";
               // MyOraDB.Parameter_Values[3] = "";


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

        private System.Data.DataSet Select_Ora_Gauge()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS.TMS_SEQ_SUM_SEL";
                //ARGMODE
                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_DATE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE";
                MyOraDB.Parameter_Name[2] = "ARG_SEQ";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = DateTime.Now.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[1] = "014";
                MyOraDB.Parameter_Values[2] = "1";
                MyOraDB.Parameter_Values[3] = "";


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

        public static Dictionary<string, Tuple<string, string, string, string, string, string>> getInitForm2(string dll_name, string class_name)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            DataTable dt;
            Dictionary<string, Tuple<string, string, string, string, string, string>> dtn = null;
            string process_name = "SEPHIROTH.PROC_STB_GET_FORM_INIT";

            MyOraDB.ReDim_Parameter(3);
            MyOraDB.Process_Name = process_name;

            MyOraDB.Parameter_Name[0] = "ARG_DLL_NM";
            MyOraDB.Parameter_Name[1] = "ARG_CLASS_NM";
            MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = dll_name;
            MyOraDB.Parameter_Values[1] = class_name;
            MyOraDB.Parameter_Values[2] = "";

            MyOraDB.Add_Select_Parameter(true);
            ds_ret = MyOraDB.Exe_Select_Procedure();

            if (ds_ret != null)
            {
                dt = ds_ret.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    dtn = new Dictionary<string, Tuple<string, string, string, string, string, string>>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dtn.Add(dt.Rows[i]["COM_NM"].ToString()
                               , new Tuple<string, string, string, string, string, string>(dt.Rows[i]["COM_VL"].ToString(), dt.Rows[i]["VALUE2"].ToString(), dt.Rows[i]["VALUE3"].ToString()
                                                                                         , dt.Rows[i]["VALUE4"].ToString(), dt.Rows[i]["VALUE5"].ToString(), dt.Rows[i]["VALUE6"].ToString()));
                    }
                }
            }
            return dtn;
        }
        #endregion DB

        #region Function

        #region initForm
        /// <summary>
        /// Set giá trị của 1 cotrol bất kì trong form
        /// </summary>
        /// <param name="obj">tên và property của label, button,...  cần set</param>
        /// <param name="obj_value">giá trị cần set</param>
        private void setComValue(string obj, string obj_value)
        {
            try
            {
                if (obj.Contains('.'))
                {
                    string[] strSplit = obj.Split('.');
                    Control cnt = this.Controls.Find(strSplit[0], true).FirstOrDefault();

                    PropertyInfo propertyInfo = cnt.GetType().GetProperty(strSplit[1]);
                    propertyInfo.SetValue(cnt, Convert.ChangeType(obj_value, propertyInfo.PropertyType), null);
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + " ---> Void SetValue(string obj_name, string obj_value):    " + ex.ToString());
            }

        }

        //private string getValueByLang(string arg_en, string arg_vi)
        //{
        //    if (arg_vi == "") return arg_en;
        //    if (_Lang.ToUpper() == "EN")
        //    {
        //        return arg_en;
        //    }
        //    else
        //    {
        //        return arg_vi;
        //    }
        //}

        private void initForm()
        {
            GoFullscreen();
            

            _dtnInit = getInitForm2(this.GetType().Assembly.GetName().Name, this.GetType().Name);

            for (int i = 0; i < _dtnInit.Count; i++)
            {
                setComValue(_dtnInit.ElementAt(i).Key, _dtnInit.ElementAt(i).Value.Item1);
            }

            if (ComVar.Var._strValue1 == null || ComVar.Var._strValue1 == "")
            {
                cmdBack.TabIndex = 53;
                cmdBack.Visible = false;
            }
            else
            {
                cmdBack.TabIndex = 15;
                cmdBack.Visible = true;
            }
        }

        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }
        #endregion

        #region image Car Run
        private void imgCarRun()
        {
            if (!_estimated) return;
            if (pic_Car.Location.X >= 1350)
            {
                DefaultCarLocation();
            }
            else
            {
                pic_Car.Location = new Point(pic_Car.Location.X + 4, pic_Car.Location.Y);
                CheckCycle();
            }
            
        }

        private void DefaultCarLocation()
        {
            pic_Car.Location = new Point(_Loc_X, pic_Car.Location.Y);
            oval1.FillColor = Color.Orange;
            oval1.FillGradientColor = Color.Orange;
            oval1.BorderColor = Color.Orange;
            oval2.FillColor = Color.Orange;
            oval2.FillGradientColor = Color.Orange;
            oval2.BorderColor = Color.Orange;
            oval3.FillColor = Color.Orange;
            oval3.FillGradientColor = Color.Orange;
            oval3.BorderColor = Color.Orange;
            oval4.FillColor = Color.Orange;
            oval4.FillGradientColor = Color.Orange;
            oval4.BorderColor = Color.Orange;
            oval5.FillColor = Color.Orange;
            oval5.FillGradientColor = Color.Orange;
            oval5.BorderColor = Color.Orange;
        }

        private void FinishedCarLocation()
        {
            pic_Car.Location = new Point(1350, pic_Car.Location.Y);
            oval1.FillColor = Color.Green;
            oval1.FillGradientColor = Color.Green;
            oval1.BorderColor = Color.Green;
            oval2.FillColor = Color.Green;
            oval2.FillGradientColor = Color.Green;
            oval2.BorderColor = Color.Green;
            oval3.FillColor = Color.Green;
            oval3.FillGradientColor = Color.Green;
            oval3.BorderColor = Color.Green;
            oval4.FillColor = Color.Green;
            oval4.FillGradientColor = Color.Green;
            oval4.BorderColor = Color.Green;
            oval5.FillColor = Color.Green;
            oval5.FillGradientColor = Color.Green;
            oval5.BorderColor = Color.Green;
        }

        private void CheckCycle()
        {
            int Loc_Car = pic_Car.Location.X + 80;
            if (Loc_Car >= oval1.Location.X )
            {
                oval1.FillColor = Color.Green;
                oval1.FillGradientColor = Color.Green;
                oval1.BorderColor = Color.Green;
                _Min = 1;
            }
            if (Loc_Car >= oval2.Location.X)
            {
                oval2.FillColor = Color.Green;
                oval2.FillGradientColor = Color.Green;
                oval2.BorderColor = Color.Green;
                _Min = 2;
            }
            if (Loc_Car >= oval3.Location.X)
            {
                oval3.FillColor = Color.Green;
                oval3.FillGradientColor = Color.Green;
                oval3.BorderColor = Color.Green;
                _Min = 3;
            }
            if (Loc_Car >= oval4.Location.X)
            {
                oval4.FillColor = Color.Green;
                oval4.FillGradientColor = Color.Green;
                oval4.BorderColor = Color.Green;
                _Min = 4;
            }
            if (Loc_Car >= oval5.Location.X)
            {
                oval5.FillColor = Color.Green;
                oval5.FillGradientColor = Color.Green;
                oval5.BorderColor = Color.Green;
            }
            

        }
        #endregion

        #region Load data
        private void load_Data()
        {
            try
            {
                DataTable data = null;
                data = Select_Ora_Grid().Tables[0];

                grdBase.DataSource = data;

                for (int i = 0; i < gvwBase.Columns.Count; i++)
                {
                    if (i == 0 || i == 4 || i == 5 )
                    {
                        gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    }
                    else
                    {
                        gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    }
                gvwBase.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvwBase.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gvwBase.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvwBase.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                gvwBase.Columns["TRIP"].Width = 30;
                gvwBase.Columns["START TIME"].Width = 50;
                gvwBase.Columns["ARRIVAL TIME"].Width = 50;

              
                }
                gvwBase.OptionsView.AllowCellMerge = true;
            }
            catch
            { }
        }

        private void TimerReloadData()
        {
            try
            {
                _Time_Reload++;

                if (_Time_Reload >= 15)
                {
                    load_Data();
                    if (_maxRow <= 16)                   
                        Load_Data_Grid();
                    Load_Data_Gauge();

                    _Time_Reload = 0;
                  //  _iStartText = 0;
                }
                if (_maxRow > 16)
                {
                    if (_Time_Reload % 2 == 0)
                        AutoScrollGrid();
                }
            }
            catch (Exception)
            {}
            
        }

        private void AutoScrollGrid()
        {
            //try
            //{
            //    if (axGrid.MaxRows > _LimitRow)
            //    {
            //        axGrid.DeleteRows(2, 1);
            //        axGrid.MaxRows = axGrid.MaxRows - 1;
            //    }
            //    else
            //        Load_Data_Grid();
            //}
            //catch (Exception)
            //{}
            
        }
       
        private void Load_Data_Gauge()
        {
            try
            {
                Gauge_Start.Text = "";
                Gauge_Arrival.Text = "";

                if (_dtn_Trip.Count == 0) return;
               // if (_Trip > _dtn_Trip.Count()) _Trip = 1;
                _Trip = _dtn_Trip.Count;
                Gauge_Trip.Text = _Trip.ToString("00");
                Gauge_Start.Text = _dtn_Trip[_Trip.ToString()].Item1;
                Gauge_Arrival.Text = _dtn_Trip[_Trip.ToString()].Item3;

                if (_dtn_Trip[_Trip.ToString()].Item2 != "" && _dtn_Trip[_Trip.ToString()].Item1 == "" && _dtn_Trip[_Trip.ToString()].Item3 == "")
                {
                    DefaultCarLocation();
                }
                else if (_dtn_Trip[_Trip.ToString()].Item1 != "" && _dtn_Trip[_Trip.ToString()].Item3 == "" )
                {
                    
                    timer1.Start();
                    //if (!_estimated )
                    //    DefaultCarLocation();
                    _estimated = true;
                }
                else
                {
                    timer1.Stop();
                    Gauge_Estimate.Text = "";
                    FinishedCarLocation();
                    _iStartText = 0;
                    _Min = 0;
                   // _Trip++;
                    _estimated = false;
                }
            }
            catch (Exception)
            {}
        }

        private void Load_Data_Grid()
        {
            //try
            //{
            //    DataTable dt = _dtData.Select("OUT_QTY IS NOT NULL", "TRIP, MATERIAL_NAME").CopyToDataTable();
            //    axGrid.MaxRows = 1;
            //    axGrid.MaxRows = 100;
            //    int iRow = 2;
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        axGrid.SetText((int)gridColum.Trip, iRow, dt.Rows[i]["TRIP"].ToString());
            //        axGrid.SetText((int)gridColum.Start, iRow, dt.Rows[i]["LEAVE_LAMI"].ToString());
            //        axGrid.SetText((int)gridColum.Arrival, iRow, dt.Rows[i]["ARIVAL_TIME"].ToString());
            //        axGrid.SetText((int)gridColum.Line, iRow, dt.Rows[i]["LINE_NM"].ToString());
            //        axGrid.SetText((int)gridColum.Style_Cd, iRow, dt.Rows[i]["STYLE_CD"].ToString());
            //        axGrid.SetText((int)gridColum.Mat, iRow, dt.Rows[i]["MATERIAL_NAME"].ToString());
            //        axGrid.SetText((int)gridColum.Qty, iRow, dt.Rows[i]["OUT_QTY"].ToString());

            //        axGrid.Row = iRow;
            //        axGrid.Col = (int)gridColum.Status;
            //        axGrid.TypePictPicture = axGrid.LoadPicture(Application.StartupPath + "\\img" + "\\GreenStatus.jpg", FPUSpreadADO.PictureTypeConstants.PictureTypeJPEG);

            //        iRow++;
            //        //if (!_dtnTrip.ContainsKey(dt.Rows[i]["TRIP"].ToString()))
            //        //{
            //        //    _dtnTrip.Add(dt.Rows[i]["TRIP"].ToString(), "ORD" + dt.Rows[i]["TRIP"].ToString());
            //        //}
            //    }
            //    axGrid.MaxRows = iRow - 1;
            //    //for (int i = 1; i <= 4; i++)
            //    //{
            //    //    axGrid.Col = i;
            //    //    axGrid.ColMerge = FPUSpreadADO.MergeConstants.MergeAlways;
            //    //}
            // //   axGrid.SetCellBorder((int)gridColum.Trip, 2, (int)gridColum.Trip, axGrid.MaxRows, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                
            //    _maxRow = iRow - 1;
            //}
            //catch (Exception)
            //{
            //}
            
        }

        #endregion

        #region runTextModel
        private void runTextModel()
        {
            string blank = "          ";
            addTextGauge("Lamination left " + (5 - _Min).ToString() + " minutes ago to NOS H" + blank, Gauge_Estimate);
            _iStartText++;
        }

        private void addTextGauge(string arg_str, DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge gauge)
        {

            if (arg_str.Length <= 20)
            {
                arg_str = arg_str.PadRight(20, ' ');
            }

            if (_iStartText + 1 > arg_str.Length)
            {
                _iStartText = 0;
            }

            gauge.Text += arg_str.Substring(_iStartText, 1);
        }

        #endregion runTextModel

        private void gvwBase_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (gvwBase.GetRowCellValue(e.RowHandle, gvwBase.Columns["DIVISION"]).ToString() == "READY SET" &&
                gvwBase.GetRowCellValue(e.RowHandle, gvwBase.Columns["QTY"]).ToString() != "0")
            {
                e.Appearance.BackColor = Color.LightSkyBlue;

            }
            if (gvwBase.GetRowCellValue(e.RowHandle, gvwBase.Columns["DIVISION"]).ToString() == "READY SET" &&
                gvwBase.GetRowCellValue(e.RowHandle, gvwBase.Columns["QTY"]).ToString() == "0")
            {
                e.Appearance.BackColor = Color.Red;

            }
        }

    

        #endregion Function

        private void cbdate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                load_Data();
            }
            catch
            {

            }
        }

        

    








    }
}
