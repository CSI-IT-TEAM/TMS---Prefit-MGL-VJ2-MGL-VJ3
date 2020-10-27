using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Data.OracleClient;
using System.Collections;


namespace FORM
{
    public partial class DSF_VJ3_MENU : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool turnon);
        MODEL_LINE lineInstance = new MODEL_LINE();

        public string sLine = ComVar.Var._strValue1, sMline = ComVar.Var._strValue2, lang = ComVar.Var._strValue3;
        int ccountN = 0;
        int ccount = 0;
        bool _fac = true;
        DataTable dtModel = null;
        private const int SW_MAXIMIZE = 3;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        DataTable _dtGMES = null, _dtQMS = null;

        public DSF_VJ3_MENU()
        {
            InitializeComponent();   
           // this.Text = "Insole";
            Init_Form();
        }        
       
         private Database _db = new Database();

        // production / plant
         private DataTable SEL_PROD_MDI(string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_VJ3.SP_SMT_PROD_MDI";

                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[1] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[1] = ARG_MLINE_CD;
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

         private DataTable dtPUPLayout()
         {
             DataTable dt = new DataTable();
             dt.Columns.Add("LINE_CD");
             dt.Columns.Add("LINE_CD1");
             dt.Columns.Add("LINE_NM");
             dt.Columns.Add("LOC_ROW");
             dt.Columns.Add("LOC_COL"); 
              
             dt.Rows.Add("099", "001", "Plant  N\n(1 - 2)", "0", "0");
             dt.Rows.Add("015", "002", "Plant I\n(3 - 4)", "0", "1");
             dt.Rows.Add("202", "002", "Plant LE\n(3 - 4)", "0", "2");
             dt.Rows.Add("205", "111", "No Plant", "0", "3");
             dt.Rows.Add("205", "111", "No Plant", "1", "0");
             dt.Rows.Add("205", "111", "No Plant", "1", "1");
             dt.Rows.Add("205", "111", "No Plant", "1", "2");
             dt.Rows.Add("205", "111", "No Plant", "1", "3");

             return dt;
         }

        //=======================show hinh clik gauge===============
        public DataTable SEL_MODEL_NAME(string ARG_QTYPE, string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_VJ3.SP_SMT_TEST";

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
        //===============================================================


      

        /// <summary>
        /// khi báo User control
       
        #region Variable Global
         
        DataTable _dtXML = null;
        int _iCount = 0;
        int _iStartText = 0;
        Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        #endregion

        /// <summary>
        /// Init form lúc ban đầu khởi động form
        /// </summary>
        private void Init_Form()
        {
            
          //  cmd_Fac1.BackgroundImage = Image.FromFile(Application.StartupPath + @"\IMG\img_F1.png");
          //  cmd_NosN.BackgroundImage = Image.FromFile(Application.StartupPath + @"\IMG\img_NOS_N.png");
           // cmd_EMD.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\EMD.png");          
            pn_Menu_Header.Visible = true;
            cmdBack.Visible = false;
            simpleButton29.Visible = false;
            btn_WS3.Visible = false;
            btn_WS2.Visible = false;
            btnLang.Visible = false;
            btnBack.Visible = true;
            pn_Main.Visible = false;
            tblMain2.Visible = true;
            tblMain1.Visible = false;
            
        }                
      
        #region Load/ Visible Change/ Close/ Minimized
        private void DIGITAL_SHOP_FLOOR_OS_Load(object sender, EventArgs e)
        {
            try
            {                
               // down_img("fac_1.PNG");
               // down_img("nos_n1.PNG");
               // cmdBack.Visible = true;
                _dtnInit = ComVar.Func.getInitForm(this.GetType().Assembly.GetName().Name, this.GetType().Name);
                _dtGMES = ComVar.Func.ReadXML(Application.StartupPath + @"\Config.xml", "GMES");
               
                    this.Cursor = Cursors.WaitCursor;
                  //line_cd =  ComVar.Var._strValue1;
                    lang = ComVar.Var._strValue3;
                    lblTitle.Text = _dtnInit["Title"];
                    if (ComVar.Var._strValue3 == "Vi")
                    {
                        btnLang.BackgroundImage = Properties.Resources.VieSel;
                      //  ComVar.Var._strValue3 = "Vi";
                    }
                    else
                    {
                        btnLang.BackgroundImage = Properties.Resources.enSel;
                        ComVar.Var._strValue3 = "En";
                    }

                    DataTable dt = dtPUPLayout();
                    DataTable dtModel = SEL_MODEL_NAME("Q", "", ""); // "202", "000");
                    if (ccountN == 0)
                    {
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                              //  if (i == 0 || i == 1)
                              //  {
                                    DataTable dtOS = SEL_PROD_MDI(dt.Rows[i]["LINE_CD"].ToString(), dt.Rows[i]["LINE_CD1"].ToString());
                                    UC.UC_MENU_DSF_2 MENU_WS = new UC.UC_MENU_DSF_2(dt.Rows[i]["LINE_NM"].ToString(), dt.Rows[i]["LINE_CD"].ToString(), dt.Rows[i]["LINE_CD1"].ToString(), ComVar.Var._strValue3);
                                    MENU_WS.Animation(lang, MENU_WS);
                                    tblMain2.Controls.Add(MENU_WS, Convert.ToInt32(dt.Rows[i]["LOC_COL"]), Convert.ToInt32(dt.Rows[i]["LOC_ROW"]));
                                    
                                    MENU_WS.BindingData(dtOS, i, dtModel);
                                    dtOS = null;
                                    MENU_WS.OnMenuClick += MenuOnClick;
                                    MENU_WS.MoveLeave += MoveLeaveClick;
                                    MENU_WS.Dock = DockStyle.Fill;
                                    MENU_WS.GetImage(dt, i);
                                //}
                                //else //Khong can Binding.
                                //{
                                //    UC.UC_MENU_DSF_2 MENU_WS = new UC.UC_MENU_DSF_2();
                                //    tblMain2.Controls.Add(MENU_WS, Convert.ToInt32(dt.Rows[i]["LOC_COL"]), Convert.ToInt32(dt.Rows[i]["LOC_ROW"]));
                                //    MENU_WS.OnMenuClick += MenuOnClick;
                                //    MENU_WS.MoveLeave += MoveLeaveClick;
                                //    MENU_WS.GetImage(dt, i);
                                //    MENU_WS.Dock = DockStyle.Fill;
                                //}
                            }
                        }
                    }
                    else
                    {

                        foreach (UserControl c in this.tblMain2.Controls)
                        {
                            UC.UC_MENU_DSF_2 MENU_WS = null;
                            MENU_WS = (UC.UC_MENU_DSF_2)c;
                            MENU_WS.Animation(lang, c);
                        }
                    }

                    ccountN++;
                    selectNos();
               
             
                
            
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.Name + "/Form_Load  :   " + ex.ToString());
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private void SMT_B_INSOLE_MAIN_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (!string.IsNullOrEmpty(ComVar.Var._Value))
                    btnBack.Visible = true;
                else
                    btnBack.Visible = false;
                timer1.Start();
                _iCount = 0;
            }
            else
            {
                timer1.Stop();
            }

        }

        private void lblDateTime_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTitle2_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
        }

        #endregion Load/ Visible Change/ Close/ Minimized
        
        /// <summary>
        /// menu ở phía trong từn line
        /// </summary>
        #region Menu Line Click
        private void add_Event_Click_Menu_Line()
        {            
        }

        private void callForm(string argMenu)
        {                              
            if(_dtnInit[argMenu].ToString() != "")
                ComVar.Var.callForm = _dtnInit[argMenu];

            else
                pic_under.Visible = true;

        }

        void MenuOnClick(string MenuName, string BtnName)
        {
            try
            {
                if (ComVar.Var._strValue1 == "099" || ComVar.Var._strValue1 == "015" || ComVar.Var._strValue1 == "202")
                {
                    ComVar.Var._strValue2 = MenuName;
                }

                else
                {
                    return;
                    //ComVar.Var._strValue1 = MenuName;
                    //ComVar.Var._strValue2 = "000";
                }
                
                

                if (_dtnInit[BtnName] == "under")
                {
                    pic_under.Visible = true;
                    pic_under.BringToFront();
                }
                else
                    ComVar.Var.callForm = _dtnInit[BtnName];
            }

            catch (Exception ex)
            { ComVar.Var.writeToLog(this.Name + "/call_Form  :   " + ex.ToString()); }
        }

        void MoveLeaveClick(string MenuName, string BtnCD)
        {
            if (pic_under.Visible == true)
            {
                pic_under.SendToBack();
                pic_under.Visible = false;
            }
        }

        #endregion Menu Line Click

        /// <summary>
        /// những control ở phía trên header
        /// </summary>
        #region Menu Header     

        //private void cmdBack_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        lblTitle.Text = "Digital Shop Floor For Long Thanh";
        //        ComVar.Var._strValue1 = "005";            
        //        selectNos();             
        //    }
        //    catch
        //    {

        //    }
        //}

        #endregion Menu Header

        #region Timer
        int lockTimerCounter;
        int lockTimerCounterN;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDateTime.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
                _iCount++;
                if (_iCount >= 30)
                {
                    DataTable dt = dtPUPLayout();
                    DataTable dtModel = SEL_MODEL_NAME("Q", "", "");

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int iLine = 0;
                        foreach (UserControl c in this.tblMain2.Controls)
                        {
                            if (iLine > 2)
                            {
                                break;
                            }
                            else
                            {

                                DataTable dtOS = SEL_PROD_MDI(dt.Rows[iLine]["LINE_CD"].ToString(), dt.Rows[iLine]["LINE_CD1"].ToString());
                                UC.UC_MENU_DSF_2 MENU_WS = null;
                                MENU_WS = (UC.UC_MENU_DSF_2)c;
                                MENU_WS.BindingData(dtOS, iLine, dtModel);
                            }
                           
                            iLine++;
                        }
                        _iCount = 0;
                    }

                    else
                    {
                        Init_Form();
                    }
                    _iCount = 0;
                }
            }
            catch
            {
            }
        }
        #endregion Timer

        /// <summary>
        /// text model chạy
        /// </summary>
        #region runTextModel
        private void runTextModel()
        {          
            _iStartText++;
        }
        private void addTextGauge(string arg_str, DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge gauge)
        {

            if (arg_str.Length < 20)
            {
                arg_str = arg_str.PadRight(20, ' ');
            }

            if (_iStartText + 1 >= arg_str.Length)
            {
                _iStartText = 0;  
            }

            gauge.Text += arg_str.Substring(_iStartText, 1);
        }

        #endregion runTextModel

        /// <summary>
        /// button Factory 1 ở màn hình ban đầu khi load form
        /// </summary>
      

        /// <summary>
        /// button NOS N ở màn hình ban đầu khi load form
        /// </summary>
      
       
        #region Read File XML
        private DataTable ReadXML(string file)
        {
            DataTable table = new DataTable(this.GetType().Name);
            try
            {
                DataSet lstNode = new DataSet();
                lstNode.ReadXml(file);
                table = lstNode.Tables[this.GetType().Name];
                return table;
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.Name + "/ReadXML  :   " + ex.ToString());
                return table;
            }
        }
        #endregion Read File XML
        private void selectNos()
        {
            pn_Main.Visible = false;
            lang = ComVar.Var._strValue3;
            
                tblMain2.Visible = true;
                tblMain1.Visible = false;
                pn_Menu_Header.Visible = true;
                cmdBack.Visible = false;
                btnLang.Visible = true;
                btnBack.Visible = false;           
        }      

        private string GetIP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            return addr[addr.Length - 1].ToString();
        }

        //Click Andon button 
        private void btn_WS1_Click(object sender, EventArgs e)
        {
            string Caption = "Andon by Day";           
            ComVar.Var.callForm = _dtnInit["frmMonth"];          
        }

      
        private void btn_WS3_Click(object sender, EventArgs e)
        {
           pic_under.BringToFront();  
           pic_under.Visible = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {               
                if (lockTimerCounterN == 0)
                {
                    int iLine = 0;
                    foreach (UserControl c in this.tblMain2.Controls)
                    {
                        if (iLine > 2)
                        {
                            break;
                        }
                        else
                        {
                            UC.UC_MENU_DSF_2 MENU_WS = null;
                            MENU_WS = (UC.UC_MENU_DSF_2)c;
                            MENU_WS.changeColor();
                            MENU_WS.UpdateText(iLine);
                            lockTimerCounter--;
                        }

                        iLine++;

                    }
                }
                
            }
            catch
            {
            }
        }

        private void btn_WS3_MouseLeave(object sender, EventArgs e)
        {
            pic_under.SendToBack();
            pic_under.Visible = false;
        }
//==============================================================================================================
        private void btn_WS2_Click(object sender, EventArgs e)
        {
            string path = _dtGMES.Rows[0]["path"].ToString();
            string str_ProcessName = _dtGMES.Rows[0]["PROCESS_NAME"].ToString();

            if (!ProgramIsRunning(path))
            //Process.Start(patch);
            {
                Process p = Process.Start(path);
                p.WaitForInputIdle();
                Thread.Sleep(2005);
                SendKeys.SendWait("1{enter}"); //VJIT{tab}
            }
            else
            {
                var ipex = Process.GetProcesses().Where(pr => pr.ProcessName == str_ProcessName);
                foreach (var process in ipex)
                {
                    //process.Kill();
                    var p = System.Diagnostics.Process.GetProcessesByName(str_ProcessName).FirstOrDefault();
                    ShowWindow(p.MainWindowHandle, SW_MAXIMIZE);
                }
            }
        }

        private bool ProgramIsRunning(string FullPath)
        {
            string FilePath = Path.GetDirectoryName(FullPath);
            string FileName = Path.GetFileNameWithoutExtension(FullPath).ToLower();
            bool isRunning = false;

            Process[] pList = Process.GetProcessesByName(FileName);
            foreach (Process p in pList)
                if (p.MainModule.FileName.StartsWith(FilePath, StringComparison.InvariantCultureIgnoreCase))
                {
                    isRunning = true;
                    break;
                }

            return isRunning;
        }

//=====================================================================================================================
        private void btn_WS2_MouseLeave(object sender, EventArgs e)
        {
            pic_under.SendToBack();
            pic_under.Visible = false;
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "Mini";
        }
        int btnLangClick = 0;
        private void btnLang_Click(object sender, EventArgs e)
        {
          
            if (ComVar.Var._strValue3 == "Vi")
            {
                btnLang.BackgroundImage = Properties.Resources.enSel;
                btnLangClick = 0;
                ComVar.Var._strValue3 = "En";
                foreach (UserControl c in this.tblMain2.Controls)
                {
                    UC.UC_MENU_DSF_2 MENU_WS = null;
                    MENU_WS = (UC.UC_MENU_DSF_2)c;
                    MENU_WS.Animation("En", c);
                }
            }
            else
            {

                btnLang.BackgroundImage = Properties.Resources.VieSel;
                ComVar.Var._strValue3 = "Vi";
                foreach (UserControl c in this.tblMain2.Controls)
                {
                    UC.UC_MENU_DSF_2 MENU_WS = null;
                    MENU_WS = (UC.UC_MENU_DSF_2)c;
                    MENU_WS.Animation("Vi", c);
                }
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
         
                ComVar.Var.callForm = "back";
            
        }

      
        


        
    }
}
