using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Data.OracleClient;
using System.Runtime.InteropServices;

namespace FORM.UC
{
    public partial class UC_MENU_DSF : UserControl
    {
        public UC_MENU_DSF(string Title, string line)
        {
            InitializeComponent();
            lbl_Line.Text = Title;
            bsVQuality.Selected = true;
            _lineCD = line;
            this.Name = "UC_MENU" + line; 
        }
        #region Variable
        string _MenuName = "";
        string _lineCD = "";
        string _Lang = "";
        ArrayList _al = new ArrayList();
       
        private Database _db = new Database();
       
        #endregion
       
        #region Delegate
        //===menu click


        public delegate void ButtonMenuhandler(string ButtonCap, string ButtonCD);
        public ButtonMenuhandler oMouseLeave = null;

        public delegate void MenuHandler(string MenuName, string ButtonCD);       

        public MenuHandler OnMenuClick = null;
        public MenuHandler MoveLeave = null;


       // public delegate void (string MenuName, string ButtonCD);
        #endregion

        private void btnItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (_MenuName != null)
                {
                    if (OnMenuClick != null)
                    {
                        ComVar.Var._strValue1 = _lineCD;
                        // ComVar.Var._strValue3 = _Lang;

                        OnMenuClick(_lineCD, ((DevExpress.XtraEditors.SimpleButton)sender).Name);
                    }

                }
            }
            catch 
            {}
            finally
            {
                this.Cursor = Cursors.Default;
            }
           
        }


             

        private void btnMoveLeave_Click(object sender, EventArgs e)
        {
            if (_MenuName != null)
            {
                if (MoveLeave != null)
                    MoveLeave(_lineCD, ((DevExpress.XtraEditors.SimpleButton)sender).Name);
            }
        }

        

        private void bsV_ItemPressed(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            _MenuName = e.Item.Name.ToString();
        }


        //==========================================
        public void BindingData(DataTable dt, int i, DataTable dt1)
        {
            try
            { 
                Clear();
                if (dt != null && dt.Rows.Count > 0)
                {  
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j <= 2)                        
                        axfpSpread1.SetText(2, j + 1, Convert.ToDouble(dt.Rows[0][j]).ToString("#,0") + " PRS");
                        else if (j == 3)
                        {
                            Color clrRate = Color.White;
                            if (double.Parse(dt.Rows[0][j].ToString()) > 97)
                                clrRate = Color.Green;
                            else if (double.Parse(dt.Rows[0][j].ToString()) < 94)
                                clrRate = Color.Red;
                            else
                                clrRate = Color.Yellow;                         
                             axfpSpread1.SetText(2, j + 1, Convert.ToDouble(dt.Rows[0][j]).ToString("#0.0") + "%");
                            axfpSpread1.Col = 2;
                            axfpSpread1.Row = j + 1;
                            axfpSpread1.BackColor = clrRate;
                        }
                        else
                        {
                            Color clrRate = Color.White;
                            if (double.Parse(dt.Rows[0][j].ToString()) < 1.15)
                                clrRate = Color.Green;
                            else
                                clrRate = Color.Red;                         
                            axfpSpread1.SetText(2, j + 1, Convert.ToDouble(dt.Rows[0][j]).ToString("#0.00") + "%");
                            axfpSpread1.Col = 2;
                            axfpSpread1.Row = j + 1;
                            axfpSpread1.BackColor = clrRate;

                        }
                    }
                }
                 if (dt1 != null)
                {

                    for (int n = 0; n < FullText.Length; n++)
                    {
                        FullText[n] = dt1.Rows[n]["MODEL"].ToString();
                       // Init(n);
                    }
                    Init(i);
                    //   tmrColor.Enabled = true; 


                }
            }
            catch(Exception ex) { }
        }
      

        private void Clear()
        {
            for (int iRow = 1; iRow <= axfpSpread1.MaxRows; iRow++)
            {
                axfpSpread1.SetText(2, iRow, "clear");
            }
        }
        public void changeColor()
        {
            axfpSpread1.Col = 2;
            axfpSpread1.Row = 4;
            if (axfpSpread1.BackColor == Color.Red)
            {
                axfpSpread1.BackColor = Color.Black;
                axfpSpread1.ForeColor = Color.White;
            }
            else if (axfpSpread1.BackColor == Color.Black)
            {
                axfpSpread1.BackColor = Color.Red;
                axfpSpread1.ForeColor = Color.White;
            }
            else
            {

                axfpSpread1.ForeColor = Color.Black;
            }
        }

        int visibleSymbolsCount = 0;
        int substringStartIndex = 0;
        public void GetImage(DataTable dt, int i)
        {
            try
            {
                if (dt.Rows.Count == 0)

                    return;

                if (dt.Rows[0][0] != null)
                {
                    //   DataTable dtTemp = null;
                    switch (this.Name)
                    {
                        case "UC_MENU001":
                            picture.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\img_F1_001.png");
                            picture.BackgroundImageLayout = ImageLayout.Stretch;
                            lblMLine1.Text = "Lan";
                            //dgModel.Text = new string('b', dgModel.DigitCount);
                            //visibleSymbolsCount = dgModel.DigitCount;
                            //substringStartIndex = 0;
                            break;
                        case "UC_MENU002":
                            picture.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\img_F1_002.png");
                            picture.BackgroundImageLayout = ImageLayout.Stretch;
                            lblMLine1.Text = "Hà";
                           // dgModel.Text = "123456";
                            break;
                        case "UC_MENU003":
                            picture.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\img_F1_003.png");
                            picture.BackgroundImageLayout = ImageLayout.Stretch;
                            lblMLine1.Text = "Tiến";
                           // dgModel.Text = "123456";
                            break;
                        case "UC_MENU004":
                            picture.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\img_F1_004.png");
                            picture.BackgroundImageLayout = ImageLayout.Stretch;
                            lblMLine1.Text = "Vân";
                           // dgModel.Text = "123456";
                            break;
                        case "UC_MENU005":
                            picture.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\img_F1_005.png");
                            picture.BackgroundImageLayout = ImageLayout.Stretch;
                            lblMLine1.Text = "Xinh";
                          //  dgModel.Text = "123456";
                            break;
                        case "UC_MENU006":
                            picture.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\img_F1_006.png");
                            picture.BackgroundImageLayout = ImageLayout.Stretch;
                            lblMLine1.Text = "Bình";
                          //  dgModel.Text = "123456";
                            break;
                    }
                }
            }
            catch
            {
            }
        }

        private void cmdQuarter_Performance_Click(object sender, EventArgs e)
        {
            if (_MenuName != null)
            {
                if (OnMenuClick != null)
                    OnMenuClick(_lineCD, ((DevExpress.XtraEditors.SimpleButton)sender).Name);
            }
        }

//==============================================================================================================
      
         public string[] FullText = new string[]
        {
            "Not Found, Please Close Program and Open Again!",
            "Not Found, Please Close Program and Open Again!",
            "Not Found, Please Close Program and Open Again!",
            "Not Found, Please Close Program and Open Again!",
            "Not Found, Please Close Program and Open Again!",
            "Not Found, Please Close Program and Open Again!"
        };

        public static char[] specChars = new char[] { '.', '\'', ',', '-', ')', '(' };
       // int lockTimerCounter;
        public int visibleSymbolsCount1 = 0;
        public int substringStartIndex1 = 0;
        public bool IsSpecialCharacter(char character)
        {
            return Array.IndexOf(specChars, character) != -1;
        }
      
        public void Init(int index)
        {
            try
            {
                FullText[index] = FullText[index] + new string(' ', dgModel.DigitCount) + FullText[index] + new string(' ', dgModel.DigitCount);
                visibleSymbolsCount1 = dgModel.DigitCount;
                substringStartIndex1 = 0;

            }
            catch { }


        }
        public void UpdateText(int index)
        {
            try
            {
                int additionalSymbolsCount1 = 0;

                additionalSymbolsCount1 = Array.FindAll(FullText[index].Substring(substringStartIndex1, visibleSymbolsCount1).ToCharArray(), IsSpecialCharacter).Length;
                dgModel.Text = FullText[index].Substring(substringStartIndex1, visibleSymbolsCount1 + additionalSymbolsCount1);
                substringStartIndex1 += 1;
                if (substringStartIndex1 < 0)
                    substringStartIndex1 = FullText[index].Length - visibleSymbolsCount1;
                else if (substringStartIndex1 > FullText[index].Length - visibleSymbolsCount1)
                    substringStartIndex1 = 0;
                if (IsSpecialCharacter(FullText[index][substringStartIndex1]))
                    substringStartIndex1 += 1;

            }
            catch { }
        }
         int index;
         private void timer1_Tick(object sender, EventArgs e)
         {

             try
             {
                 
             }
             catch { }
         }


//=============================PFC==========================================

         private void CreateAndOpenFolder(string LineName)
         {
             if (!Directory.Exists(@"C:\\PFC_Nos_" + LineName))
             {
                 DialogResult dl = MessageBox.Show(this, "Can't find this folder, would you like to create folder PFC (Không tìm thấy thư mục PFC, tạo mới folder PFC không?)", "Warring!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (dl == DialogResult.Yes)
                     Directory.CreateDirectory(@"C:\\PFC_Nos_" + LineName);
             }

             OpenFileDialog theDialog = new OpenFileDialog();
             theDialog.Title = "Open PFC File";
             theDialog.Filter = "PDF files|*.pdf";
             theDialog.InitialDirectory = @"C:\PFC_Nos_" + LineName;

             if (theDialog.ShowDialog() == DialogResult.OK)
             {
                 if (!theDialog.FileName.ToString().Equals(""))
                 {
                     var process = new System.Diagnostics.Process
                     {
                         StartInfo = new System.Diagnostics.ProcessStartInfo(theDialog.FileName)
                     };
                     process.Start();
                 }
             }
         }

       

         private void mnQua1_Click(object sender, EventArgs e)
         {
             CreateAndOpenFolder(_lineCD);
         }

 //================================== LANG================================================      

        const int AW_SLIDE = 0X40000;
        const int AW_HOR_POSITIVE = 0X4;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_BLEND = 0X80000;
        const int AW_HIDE = 0x00010000;
        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);
         public void Animation(string Qtype, Control Grid)
         {
             string[] EN = new string[] { "Quality", "Production", "Equipment", "Inventory", "Human\nResource",
                                          "Quality", "Production", "Equipment", "Inventory", "Human\nResource",
                                          "Quality", "Production", "Equipment", "Inventory", "Human\nResource",
                                          "Quality", "Production", "Equipment", "Inventory", "Human\nResource",
                                          "Quality", "Production", "Equipment", "Inventory", "Human\nResource",
                                          "Quality", "Production", "Equipment", "Inventory", "Human\nResource" };
             string[] VIE = new string[] { "Chất lượng", "Sản Xuất", "Thiết bị", "Tồn kho", "Nguồn\nNhân Lực",
                                           "Chất lượng", "Sản Xuất", "Thiết bị", "Tồn kho", "Nguồn\nNhân Lực",
                                           "Chất lượng", "Sản Xuất", "Thiết bị", "Tồn kho", "Nguồn\nNhân Lực",
                                           "Chất lượng", "Sản Xuất", "Thiết bị", "Tồn kho", "Nguồn\nNhân Lực",
                                           "Chất lượng", "Sản Xuất", "Thiết bị", "Tồn kho", "Nguồn\nNhân Lực",
                                           "Chất lượng", "Sản Xuất", "Thiết bị", "Tồn kho", "Nguồn\nNhân Lực"};

             string[] GbEx_VIE = new string[] { "Tình trạng sản xuất", "Tình trạng sản xuất", "Tình trạng sản xuất", "Tình trạng sản xuất", "Tình trạng sản xuất", "Tình trạng sản xuất" };
             string[] GbEx_EN = new string[] { "Production Status", "Production Status", "Production Status", "Production Status", "Production Status", "Production Status" };

             string[] btn_VIE = new string[]{
            "PFC","NPI","Uper Return","Hàng Hư Trả Về","Kết Quả\nSản Xuất","BTS","Năng Suất","Down Time","Lead Time","Tồn Kho","Vắng Mặt","Relief Man","Đa Kỹ Năng",
            "PFC","NPI","Uper Return","Hàng Hư Trả Về","Kết Quả\nSản Xuất","BTS","Năng Suất","Down Time","Lead Time","Tồn Kho","Vắng Mặt","Relief Man","Đa Kỹ Năng",
            "PFC","NPI","Uper Return","Hàng Hư Trả Về","Kết Quả\nSản Xuất","BTS","Năng Suất","Down Time","Lead Time","Tồn Kho","Vắng Mặt","Relief Man","Đa Kỹ Năng",
            "PFC","NPI","Uper Return","Hàng Hư Trả Về","Kết Quả\nSản Xuất","BTS","Năng Suất","Down Time","Lead Time","Tồn Kho","Vắng Mặt","Relief Man","Đa Kỹ Năng",
            "PFC","NPI","Uper Return","Hàng Hư Trả Về","Kết Quả\nSản Xuất","BTS","Năng Suất","Down Time","Lead Time","Tồn Kho","Vắng Mặt","Relief Man","Đa Kỹ Năng",
            "PFC","NPI","Uper Return","Hàng Hư Trả Về","Kết Quả\nSản Xuất","BTS","Năng Suất","Down Time","Lead Time","Tồn Kho","Vắng Mặt","Relief Man","Đa Kỹ Năng"

            };
             string[] btn_EN = new string[]{
            "PFC","NPI","Uper Return","External OS&&D","Prod. Result","BTS","Productivity","Down Time","Lead Time","Outgoing\nInventory","Absenteeism","Relief Man","Multi Skill",
            "PFC","NPI","Uper Return","External OS&&D","Prod. Result","BTS","Productivity","Down Time","Lead Time","Outgoing\nInventory","Absenteeism","Relief Man","Multi Skill",
            "PFC","NPI","Uper Return","External OS&&D","Prod. Result","BTS","Productivity","Down Time","Lead Time","Outgoing\nInventory","Absenteeism","Relief Man","Multi Skill",
            "PFC","NPI","Uper Return","External OS&&D","Prod. Result","BTS","Productivity","Down Time","Lead Time","Outgoing\nInventory","Absenteeism","Relief Man","Multi Skill",
            "PFC","NPI","Uper Return","External OS&&D","Prod. Result","BTS","Productivity","Down Time","Lead Time","Outgoing\nInventory","Absenteeism","Relief Man","Multi Skill",
            "PFC","NPI","Uper Return","External OS&&D","Prod. Result","BTS","Productivity","Down Time","Lead Time","Outgoing\nInventory","Absenteeism","Relief Man","Multi Skill"

            };

             DevExpress.XtraEditors.SimpleButton[] btn = new DevExpress.XtraEditors.SimpleButton[] { 
                 mnQua1,mnQua2,mnQua3,mnQua4, mnPro1,mnPro2,mn6, mnEqu1, mnInv1, mn11, mnHR1,mnHR2, mnHR3                   
            };
             DevExpress.XtraBars.Ribbon.BackstageViewTabItem[] tabItem = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem[]
            {
                bsVQuality, bsVProduction, bsVEquipment, bsVInventory, bsVHumanResource               
            };
             FORM.GroupBoxEx[] gbEX = new FORM.GroupBoxEx[] { grpProd };
            Grid.Hide();
            this.Cursor = Cursors.WaitCursor;
            AnimateWindow(Grid.Handle, 400, AW_SLIDE | 0X4); //IPEX_Monitor.ClassLib.WinAPI.getSlidType("2")
            //BindingGrid(dt);
            switch (Qtype)
            {
                case "En":
                    for (int i = 0; i < tabItem.Length; i++)
                    {
                        tabItem[i].Caption = EN[i];
                    }
                    for (int j = 0; j < gbEX.Length; j++)
                    {
                        gbEX[j].Text = GbEx_EN[j];
                    }
                    for (int k = 0; k < btn.Length; k++)
                    {
                        btn[k].Text = btn_EN[k];
                    }
                    break;
                case "Vi":
                    for (int i = 0; i < tabItem.Length; i++)
                    {
                        tabItem[i].Caption = VIE[i];
                    }
                    for (int j = 0; j < gbEX.Length; j++)
                    {
                        gbEX[j].Text = GbEx_VIE[j];
                    }
                    for (int k = 0; k < btn.Length; k++)
                    {
                        btn[k].Text = btn_VIE[k];
                    }
                    break;
            }
            Grid.Show();
            this.Cursor = Cursors.Default;

        }

         private void gauC_Click(object sender, EventArgs e)
         {
             Form fc = Application.OpenForms["FRM_MODEL_DETAIL_LW"];
             if (fc != null)
                 fc.Close();
             FRM_MODEL_DETAIL_LW f = new FRM_MODEL_DETAIL_LW(_lineCD, "");
             f.ShowDialog();
         }

       
        

//==============END=====================================================

    }
}
