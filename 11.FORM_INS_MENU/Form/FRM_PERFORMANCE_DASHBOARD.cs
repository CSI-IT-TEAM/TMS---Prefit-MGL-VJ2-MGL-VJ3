using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM
{
    public partial class FRM_PERFORMANCE_DASHBOARD : Form
    {
        public FRM_PERFORMANCE_DASHBOARD()
        {
            InitializeComponent();
        }
        int indexScreen;
        string Lang = ComVar.Var._strValue3;
        string line ="", Mline = "";
        Form[] arrForm = new Form[3];
        Dictionary<string, string> _dtnInit = new Dictionary<string, string>();

        public FRM_PERFORMANCE_DASHBOARD(string Title, int _indexScreen, string _Line, string _Mline, string _Lang)
        {
            InitializeComponent();
            indexScreen = _indexScreen;
            Mline = _Mline;
            line = _Line;
            Lang = _Lang;
            
            tmrDate.Stop();
            lblTitle.Text = Title;

        }

        #region UserControl
        UC.UC_GRID_PERFORMANCE_DASHBOARD UC_PRODUCTION = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Production");
        UC.UC_GRID_PERFORMANCE_DASHBOARD UC_PRODUCTIVE = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Productivity");
        UC.UC_GRID_PERFORMANCE_DASHBOARD UC_INTERNAL = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Internal Defective Return");
        UC.UC_GRID_PERFORMANCE_DASHBOARD UC_EXTERNAL = new UC.UC_GRID_PERFORMANCE_DASHBOARD("External Defective Return");
        UC.UC_GRID_PERFORMANCE_DASHBOARD UC_BTS = new UC.UC_GRID_PERFORMANCE_DASHBOARD("BTS");
        UC.UC_GRID_PERFORMANCE_DASHBOARD UC_LEADTIME_FG = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Lead time (F/G)");
        UC.UC_GRID_PERFORMANCE_DASHBOARD UC_DOWNTIME = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Downtime");
        UC.UC_GRID_PERFORMANCE_DASHBOARD UC_ABSENT = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Absenteeism");
        UC.UC_GRID_PERFORMANCE_DASHBOARD UC_TURNOVER = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Turnover");
        #endregion
        #region UserControl_vn
        UC.UC_GRID_PERFORMANCE_DASHBOARD UC_PRODUCTION_VN = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Sản xuất");
        UC.UC_GRID_PERFORMANCE_DASHBOARD UC_PRODUCTIVE_VN = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Năng suất");
        UC.UC_GRID_PERFORMANCE_DASHBOARD UC_INTERNAL_VN = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Hàng hư nội bộ trả về");
        UC.UC_GRID_PERFORMANCE_DASHBOARD UC_EXTERNAL_VN = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Hàng hư xuởng trả về");
        UC.UC_GRID_PERFORMANCE_DASHBOARD UC_BTS_VN = new UC.UC_GRID_PERFORMANCE_DASHBOARD("BTS");
        UC.UC_GRID_PERFORMANCE_DASHBOARD UC_LEADTIME_FG_VN = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Doanh thu");
        UC.UC_GRID_PERFORMANCE_DASHBOARD UC_DOWNTIME_VN = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Downtime");
        UC.UC_GRID_PERFORMANCE_DASHBOARD UC_ABSENT_VN = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Vắng mặt");
        UC.UC_GRID_PERFORMANCE_DASHBOARD UC_TURNOVER_VN = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Turnover");
        #endregion
        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

        private void FRM_PERFORMANCE_DASHBOARD_Load(object sender, EventArgs e)
        {
         
            this.Cursor = Cursors.WaitCursor;
            GoFullscreen(true);
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));          
            _dtnInit = ComVar.Func.getInitForm(this.GetType().Assembly.GetName().Name, this.GetType().Name);
          
                    this.lblTitle.Text = "Performance Dashboard";
                    this.tableLayoutPanel1.Controls.Add(UC_PRODUCTION, 0, 0);
                    this.tableLayoutPanel1.Controls.Add(UC_PRODUCTIVE, 1, 0);
                    this.tableLayoutPanel1.Controls.Add(UC_INTERNAL, 2, 0);

                    this.tableLayoutPanel1.Controls.Add(UC_EXTERNAL, 0, 1);
                    this.tableLayoutPanel1.Controls.Add(UC_BTS, 1, 1);
                    this.tableLayoutPanel1.Controls.Add(UC_LEADTIME_FG, 2, 1);

                    this.tableLayoutPanel1.Controls.Add(UC_DOWNTIME, 0, 2);
                    this.tableLayoutPanel1.Controls.Add(UC_ABSENT, 1, 2);
                    this.tableLayoutPanel1.Controls.Add(UC_TURNOVER, 2, 2);
            this.Cursor = Cursors.Default;
           
        }
        int cCount = 0;
        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            string Lang = "En";// ComVar.Var._strValue3;
            if (cCount >= 30)            
            {
                
                switch (Lang)
                {
                    case "Vi":
                        //Tieng Anh, TIeng Viet, Line, Mline
                        this.lblTitle.Text = "Bảng hiệu suất";
                        UC_PRODUCTION.BindingData("PRODUCTION", "Sản Xuất", line, Mline);
                        UC_PRODUCTIVE.BindingData("PRODUCTIVITY", "Năng suất", line, Mline);
                        UC_INTERNAL.BindingData("Internal Defective Return", "Hàng hư nội bộ trả về", line, Mline);
                        UC_EXTERNAL.BindingData("External Defective Return", "Hàng hư xuởng trả về", line, Mline);
                        UC_BTS.BindingData("BTS","BTS", line, Mline);
                        UC_LEADTIME_FG.BindingData("LEADTIME_FG", "Doanh thu", line, Mline);
                        UC_DOWNTIME.BindingData("DOWNTIME", "Downtime", line, Mline);
                        UC_ABSENT.BindingData("ABSENT", "Vắng mặt", line, Mline);
                        UC_TURNOVER.BindingData("TURNOVER", "Turnover", line, Mline);
                        break;
                    case "En":
                        //Tieng Anh, TIeng Anh, Line, Mline
                        this.lblTitle.Text = "Performance Dashboard";
                        UC_PRODUCTION.BindingData("PRODUCTION", "Production", line, Mline);
                        UC_PRODUCTIVE.BindingData("PRODUCTIVITY", "Productivity", line, Mline);
                        UC_INTERNAL.BindingData("Internal Defective Return","Internal Defective Return", line, Mline);
                        UC_EXTERNAL.BindingData("External Defective Return","External Defective Return", line, Mline);
                        UC_BTS.BindingData("BTS","BTS", line, Mline);
                        UC_LEADTIME_FG.BindingData("LEADTIME_FG", "Lead time (F/G)", line, Mline);
                        UC_DOWNTIME.BindingData("DOWNTIME", "Downtime", line, Mline);
                        UC_ABSENT.BindingData("ABSENT", "Absenteeism", line, Mline);
                        UC_TURNOVER.BindingData("TURNOVER", "Turnover", line, Mline);
                        break;
                }

                cCount = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FRM_PERFORMANCE_DASHBOARD_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            { 
                cCount = 29;
                string line = ComVar.Var._strValue1,
                       Mline = ComVar.Var._strValue2,
                       Lang = "En";// ComVar.Var._strValue3;                         
                tmrDate.Start();
            }
            else
                tmrDate.Stop();
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = _dtnInit["frmHome"];
        }
    }
}
