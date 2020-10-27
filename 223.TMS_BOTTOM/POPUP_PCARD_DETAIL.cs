using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;

namespace FORM
{
    public partial class POPUP_PCARD_DETAIL : Form
    {
        public POPUP_PCARD_DETAIL()
        {
            InitializeComponent();
        }

        private void PivotDataTable(DataTable dt)
        {
            DataTable dtNew = new DataTable();
            Create_DataTable(dt, dtNew);
        }

        private void Create_DataTable(DataTable dtSource, DataTable dtNew)
        {
            string NRowTemp = "";
            dtNew.Columns.Add("PCARD_NM");
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                if (!dtSource.Rows[i]["CMP_NM"].ToString().Equals(NRowTemp))
                {
                    dtNew.Columns.Add(dtSource.Rows[i]["CMP_NM"].ToString());
                    NRowTemp = dtSource.Rows[i]["CMP_NM"].ToString();
                }
            }

            for (int j = 0; j < dtNew.Columns.Count; j++)
            {
                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    if (dtNew.Rows.Count != dtSource.Rows.Count)
                         dtNew.Rows.Add();
                    dtNew.Rows[i][j] = dtSource.Rows[i][j>1?1:j].ToString();
                }
            }


            MessageBox.Show("Finished!");
        }

        public void BingdingData(string Style_Cd, string Cs_size, string Line_Cd)
        {
            DatabaseTMS db = new DatabaseTMS();
            DataTable dt = db.getSetDetailPopupV1("POPPUP", "",ComVar.Var._strValue3,ComVar.Var._strValue4, Line_Cd, Style_Cd, Cs_size);
        //    PivotDataTable(dt);
            if (dt.Rows.Count > 0)
                lblTotal.Text = string.Concat("Total: ", string.Format("{0:n0}", Math.Round(Convert.ToDouble(dt.Compute("SUM(QTY)", "")), 1)), " Prs");
            else
                lblTotal.Text = "Total: 0 Prs";

            gridControl1.DataSource = dt;
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].OptionsColumn.ReadOnly = true;
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                if (i > 1)
                {
                    gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                    gridView1.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                    gridView1.Columns[i].DisplayFormat.FormatString = "#,#";
                }
                else if (i == 0)
                {
                    gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                }
            }
        }

        private void POPUP_PCARD_DETAIL_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                //notthing
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string tomau_row_g = gridView1.GetRowCellDisplayText(e.RowHandle, "PCARD_NM");

            if (tomau_row_g.Contains("TOTAL"))
            {
                e.Appearance.BackColor = Color.FromArgb(255, 255, 214);

            }
        }
    }
}
