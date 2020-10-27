using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;

namespace MAIN
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
          
        }
        #region Animation
        const int AW_SLIDE = 0X40000;
        const int AW_HOR_POSITIVE = 0X1;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_BLEND = 0X80000;

        [DllImport("user32")]

        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);
        #endregion
       // Dictionary<string, int> _dtn = new Dictionary<string, int>();
       // int _iFrm = 0;
        DataTable _dt = null;
        DataTable _dtXML = null;
        int _indexList;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                
                _dtXML = ComVar.Func.ReadXML(Application.StartupPath + "\\Config.XML", "MAIN");
                GoFullscreen();
                /// Run 1 form using Test
               //runSingleForm();

                ///Run Group form by Config file
                runGroupForm();
               
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.Name + "/Load_Form :    " + ex.ToString());
            }
            finally
            {
                CloseSplash();
            }
        }

        private void FullScreen(int ArgMonitor)
        {
            this.WindowState = FormWindowState.Normal;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;\
            Screen[] S = Screen.AllScreens;
            if (S.Length > 1)
            {
                this.Bounds = S[ArgMonitor - 1].Bounds;
                this.Height = S[ArgMonitor - 1].WorkingArea.Height + 70;
                this.Width = S[ArgMonitor - 1].WorkingArea.Width + 17;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = S[0].Bounds;
                this.Width = S[0].WorkingArea.Width;
            }
        }
        /// <summary>
        /// Run 1 form using Test
        /// </summary>
        /// 
        /*
        private void runSingleForm()
        {
            Assembly assembly = Assembly.LoadFile(Application.StartupPath + @"\DLL\SMT_DGF_PROD_NOS_L.DLL");
            Type type = assembly.GetType("FORM.FORM_SMT_PROD_DAY");

            Form form = (Form)Activator.CreateInstance(type);

            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.AutoScroll = false;
            pnMain.Controls.Add(form);
            form.Show();
        }
        */

        private void runSingleForm()
        {
            Assembly assembly = Assembly.LoadFile(Application.StartupPath + @"\DLL\TMS_PREFIT.DLL");
            Type type = assembly.GetType("FORM.FRM_VJ_MAPS");
            _dt = SEL_GET_FORM_DLL("FRM_VJ_MAPS");

            //add Event Call Form
            ComVar.Var.ValueChanged += new ComVar.Var.ValueChangedEventHandler(callForm);
            //add Form
            Form form = (Form)Activator.CreateInstance(type);
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.AutoScroll = false;
            pnMain.Controls.Add(form);
            form.Show();
            ComVar.Var._Frm_Curr = pnMain.Controls[0].Name;
        }

        #region Run Group Form

        private void runGroupForm()
        {
            try
            {
                _dtXML = ComVar.Func.ReadXML(Application.StartupPath + "\\Config.XML", "MAIN");
                ComVar.Var._Area = string.Concat(_dtXML.Rows[0]["LOC"].ToString(),"_",_dtXML.Rows[0]["LOCNM"].ToString());
                if (_dtXML.Rows[0]["FlashScreen"].ToString() == "true")
                    ShowSplash();
                if (_dtXML.Rows[0]["Auto_Download"].ToString() == "true")
                {
                    Auto_Download frmDownload = new Auto_Download();
                    frmDownload.DowloadFile();
                }
                ComVar.Var._strValue3 = _dtXML.Rows[0]["OP_CD"].ToString();
                ComVar.Var._strValue4 = _dtXML.Rows[0]["CMP_CD"].ToString();
                ComVar.Var._strValue5 = _dtXML.Rows[0]["CMP_NM"].ToString();
                _dt = SEL_GET_FORM(_dtXML.Rows[0]["grpForm"].ToString());
                ComVar.Var.ValueChanged += new ComVar.Var.ValueChangedEventHandler(callForm);

                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    if (_dt.Rows[i]["SHOW_YN"].ToString() == "Y")
                    {
                        addForm(_dt.Rows[i]["DLL_NM"].ToString(), _dt.Rows[i]["CLASS_NM"].ToString());

                        // pnMain.Controls[i].Show();
                    }
                }
                ComVar.Var._Frm_Curr = pnMain.Controls[0].Name;
                pnMain.Controls[0].Show();
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.Name + "/InitForm  :   " + ex.ToString());
            }
        }

        private void addForm(string argDll, string argClass)
        {
            try
            {
                Assembly assembly = Assembly.LoadFile(Application.StartupPath + @"\DLL\" + argDll + ".DLL");
                Type type = assembly.GetType("FORM." + argClass);
                Form form = (Form)Activator.CreateInstance(type);
                form.Name = argDll.ToUpper() + "." + argClass.ToUpper();
                form.FormBorderStyle = FormBorderStyle.None;
                form.TopLevel = false;
                form.AutoScroll = false;
                pnMain.Controls.Add(form);
               // form.Show();
               // form.Hide();
               // _dtn.Add(argDll.ToUpper() + "." +argClass.ToUpper(), _iFrm);
                
               // _iFrm++;
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.Name + " :  SEPHIROTH.PROC_STB_GET_FORM   " + ex.ToString());
            }
        }
        
        private string getFormName(string argSeq)
        {
            try
            {
                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    if (_dt.Rows[i]["SEQ"].ToString() == argSeq)
                    {
                        return _dt.Rows[i]["DLL_NM"].ToString() + "." + _dt.Rows[i]["CLASS_NM"].ToString();
                    }
                }
                return "";
            }
            catch (Exception)
            {

                return "";
            }
            
            
        }

        #endregion 

        #region Call Form
        private void callForm(string argForm)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string strForm = "";
                switch (argForm.ToLower())
                {
                    case "minimized":
                        this.WindowState = FormWindowState.Minimized;
                        break;
                    case "exit":
                        Application.Exit();
                        break;
                    case "back":
                        showFormBack();
                        break;
                    case "0":
                        break;
                    case "23":
                        //strForm = getFormName("140");
                        //showFormCall(strForm);
                        break;
                    case "":
                        break;
                    default:
                        strForm = getFormName(argForm);
                        showFormCall(strForm);



                        break;
                }
            }
            catch
            { }
            finally
            {
                this.Cursor = Cursors.Arrow;
                ComVar.Var._IsBack = false;
            }
            
        }

        private void showFormCall(string arg_Form_Name)
        {
            Control ctr = null;
            if (arg_Form_Name == "") return;
            if (arg_Form_Name == ComVar.Var._Frm_Curr) return; 
            try
            {
                //search form in exist in pnMain if don't have then add form
                ctr = pnMain.Controls.Find(arg_Form_Name, false).FirstOrDefault();
                if (ctr == null)
                {
                    string[] str = arg_Form_Name.Split('.');
                    addForm(str[0], str[1]);
                    ctr = pnMain.Controls.Find(arg_Form_Name, false).FirstOrDefault();
                }

                //Show form call and then hide form current
               // ctr.Hide();
               //AnimateWindow(ctr.Handle, 500, AW_SLIDE | 0x8);
                ctr.Show();
               
                pnMain.Controls.Find(ComVar.Var._Frm_Curr.ToUpper(), false).FirstOrDefault().Hide();

                //add list Back form
                if (ComVar.Var._IsBack)
                {
                    ComVar.Var._List_Back.Add(Tuple.Create(arg_Form_Name, ComVar.Var._Frm_Curr));
                    ComVar.Var._Frm_Back = ComVar.Var._Frm_Curr;
                }
                else
                    ComVar.Var._List_Back.Add(Tuple.Create(arg_Form_Name, ComVar.Var._Frm_Back));

                //add form current
                ComVar.Var._Frm_Curr = arg_Form_Name;
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.Name + "-->Show_Form_Call-->Err:   " + ex.ToString());
                return;
            }
        }

        private void showFormBack()
        {
            Control ctr = null;

            try
            {
                string strRtn = "";
                int i;

                //search Back form
                for (i = ComVar.Var._List_Back.Count() - 1; i >= 0; i--)
                {
                    if (ComVar.Var._List_Back[i].Item1 == ComVar.Var._Frm_Curr)
                    {
                        strRtn = ComVar.Var._List_Back[i].Item2;
                        break;
                    }
                }
                if (strRtn == "") return;

                //search form in exist in pnMain if don't have then add form
                ctr = pnMain.Controls.Find(strRtn, false).FirstOrDefault();
                if (ctr == null)
                {
                    string[] str = strRtn.Split('.');
                    addForm(str[0], str[1]);
                    ctr = pnMain.Controls.Find(strRtn, false).FirstOrDefault();
                }

                //Show form call and then hide form current
                ctr.Show();
                pnMain.Controls.Find(ComVar.Var._Frm_Curr.ToUpper(), false).FirstOrDefault().Hide();

                //Remove form back in List
                ComVar.Var._List_Back.RemoveAt(i);

                //add form current
                ComVar.Var._Frm_Curr = strRtn;
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.Name + "-->Show_Form_Call-->Err:   " + ex.ToString());
                return;
            }
        }

        private string getFormBack()
        {
            string strRtn = "";
            
            for (int i = ComVar.Var._List_Back.Count(); i >= 0; i--)
            {
                if (ComVar.Var._List_Back[i].Item1 == ComVar.Var._Frm_Curr)
                {
                    strRtn = ComVar.Var._List_Back[i].Item2;
                    _indexList = i;
                }
            }
            return strRtn;
        }


        #endregion

        private void GoFullscreen()
        {
            try
            {
                Screen[] s = Screen.AllScreens;
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                //MessageBox.Show((s.Length).ToString());
                if (s.Length > 1)
                {
                    if (_dtXML.Columns.Contains("SCREEN"))
                    {
                        int iScreen;
                        int.TryParse(_dtXML.Rows[0]["SCREEN"].ToString(), out iScreen);
                        this.Bounds = s[iScreen - 1].Bounds;

                    }
                    else
                        this.Bounds = Screen.PrimaryScreen.Bounds;
                }
                else
                {
                    this.Bounds = Screen.PrimaryScreen.Bounds;
                }
            }
            catch
            {
                // MessageBox.Show(ex.ToString());
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }

        }

        #region DB
        public DataTable SEL_GET_FORM_DLL(string argGrp)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "SEPHIROTH.PROC_STB_GET_FORM_DLL";

                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_GRP";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = argGrp;
                MyOraDB.Parameter_Values[1] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.Name + "/SEL_GET_FORM :  " + ex.ToString());
                return null;
            }
        }

        public DataTable SEL_GET_FORM(string argGrp)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "SEPHIROTH.PROC_STB_GET_FORM";

                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_GRP";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = argGrp;
                MyOraDB.Parameter_Values[1] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                
                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.Name + "/SEL_GET_FORM :  " + ex.ToString());
                return null;
            }
        }
        #endregion DB

        #region Flash Form
        // Thredding.
        private static Thread _splashThread;
        private static FormFlash _splashForm;


        // Show the Splash Screen (Loading...)     
        public static void ShowSplash()
        {
            if (_splashThread == null)
            {
                // show the form in a new thread           
                _splashThread = new Thread(new ThreadStart(DoShowSplash));
                _splashThread.IsBackground = true;
                _splashThread.Start();
            }
        }

        // Called by the thread   
        private static void DoShowSplash()
        {
            if (_splashForm == null)
            {
                _splashForm = new FormFlash();
                _splashForm.StartPosition = FormStartPosition.CenterScreen;
                _splashForm.TopMost = true;
            }
            // create a new message pump on this thread (started from ShowSplash)       
            Application.Run(_splashForm);
        }

        // Close the splash (Loading...) screen   
        public static void CloseSplash()
        {
            try
            {
                if (_splashForm == null) return;
                // Need to call on the thread that launched this splash       
                if (_splashForm.InvokeRequired)
                    _splashForm.Invoke(new MethodInvoker(CloseSplash));
                else
                    Application.ExitThread();
            }
            catch (Exception)
            {}
           
        }

        #endregion 

    }
}
