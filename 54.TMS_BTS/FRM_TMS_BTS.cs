using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;

namespace FORM
{
    public partial class FRM_TMS_BTS : Form
    {
        public FRM_TMS_BTS()
        {
            InitializeComponent();
           
        }

        #region Variable
        int iCount = 0;
        #endregion

        //Datatable Test Của Phước
        DataTable GetData(int rows)
        {
           
            DataTable dt = new DataTable();
            dt.Columns.Add("LINE", typeof(string));
            dt.Columns.Add("MLINE", typeof(string));
            dt.Columns.Add("STYLE_CD", typeof(string));
            dt.Columns.Add("BTS", typeof(float));
            for (int i = 0; i < rows; i++)
            {
                Random r = new Random();
                dt.Rows.Add((i + 1).ToString().PadLeft(3, '0'), "Mini Line: " + i.ToString(), i.ToString().PadLeft(9, '0'), r.Next(1, 40) * (i + 1));
            }
            return dt;
        }
        DataTable GetDataMixVolumn(int rows)
        {
            Random r = new Random();
            DataTable dt = new DataTable();
            dt.Columns.Add("LINE", typeof(string));
            dt.Columns.Add("MIX", typeof(float));
            dt.Columns.Add("VOLUMN", typeof(float));
            for (int i = 0; i < rows; i++)
            {
               
                dt.Rows.Add((i+1).ToString().PadLeft(3,'0'), r.Next(1, 40) * (i + 1), r.Next(1, 40) * (i + 1));
            }
            return dt;
        }
        RepositoryItemProgressBar ritem = new RepositoryItemProgressBar();
        private void BindingDataGrid()
        {
            gridControl1.DataSource = GetData(6);
            // ritem.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            // ritem.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            // ritem.LookAndFeel.UseDefaultLookAndFeel = false;
            //ritem.ShowTitle =true;
            //ritem.PercentView = false;  
            //ritem.DisplayFormat.FormatType = FormatType.Numeric  ;
            //ritem.DisplayFormat.FormatString = "n1"  ;
            //ritem.Appearance.ForeColor = Color.Yellow;
            //ritem.Appearance.ForeColor2 = Color.Yellow;
            //ritem.Appearance.Options.UseForeColor = true;
            //ritem.Appearance.Options.UseForeColor2 = true;
            // ritem.Minimum = 0;
            //ritem.Maximum = 100;
            //ritem.StartColor = Color.Red;
            //ritem.EndColor = Color.Red;
            //bandedGridView1.Columns["BTS"].ColumnEdit = ritem;
            DifferentRepositoriesProgressBar drHelper = new DifferentRepositoriesProgressBar(bandedGridView1.Columns["BTS"]);
        }

        private void BindingChart1()
        {
            chartControl1.DataSource = GetData(6).AsEnumerable()
                 .OrderByDescending(r => r.Field<float>("BTS"))
                 .CopyToDataTable();
            chartControl1.Series[0].ArgumentDataMember = "LINE";
            chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "BTS" });
        }

        private void BindingChart2_3()
        {
            chartControl2.DataSource = GetDataMixVolumn(6);
            chartControl2.Series[0].ArgumentDataMember = "LINE";
            chartControl2.Series[0].ValueDataMembers.AddRange(new string[] { "MIX" });
            chartControl2.Series[1].ArgumentDataMember = "LINE";
            chartControl2.Series[1].ValueDataMembers.AddRange(new string[] { "VOLUMN" });
        }

        private void tmrLoad_Tick(object sender, EventArgs e)
        {
            iCount++;
            if (iCount >= 30)
            {
                BindingDataGrid();
                BindingChart1();
                BindingChart2_3();
                iCount = 0;
            }
        }

        private void FRM_TMS_BTS_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                iCount = 30;
                tmrLoad.Start();
            }
            else
                tmrLoad.Stop();
        }
      
        private void btnBack_Click(object sender, EventArgs e)
        {
            iCount = 30;
        }
      
    }
}
