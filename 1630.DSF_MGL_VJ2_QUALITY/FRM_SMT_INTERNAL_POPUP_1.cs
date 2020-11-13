using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM.Popup
{
    public partial class FRM_SMT_INTERNAL_POPUP_1 : Form
    {
        public FRM_SMT_INTERNAL_POPUP_1(DataTable _dt)
        {
            InitializeComponent();
            dt = _dt;
        }
        DataTable dt = null;

        private void FRM_SMT_INTERNAL_POPUP_1_Load(object sender, EventArgs e)
        {
            grdBase.DataSource = dt;
            formatColumn();
            //bgGrdView.TopRowIndex = bgGrdView.RowCount - 12;
        }

        private void formatColumn()
        {
            for (int i = 0; i < bgGrdView.Columns.Count; i++)
            {
                if (i == 1 || i == 2)
                    bgGrdView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                else
                    bgGrdView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                bgGrdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                if (i == 3) //|| i == 4 || i == 5
                {
                    bgGrdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                }
                if (i == 7 || i == 8)
                {
                    bgGrdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                }
            }
            bgGrdView.TopRowIndex = bgGrdView.RowCount - 14;
        }

        private void bgGrdView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (!bgGrdView.GetRowCellValue(e.RowHandle, "MLINE_CD").Equals("TOTAL") || !bgGrdView.GetRowCellValue(e.RowHandle, "Line_Name").Equals("G-TOTAL"))
                {
                    if (bgGrdView.Columns[e.Column.AbsoluteIndex].FieldName.Contains("Qty"))
                    {
                        if (!bgGrdView.GetRowCellValue(e.RowHandle, "C_Qty").Equals(bgGrdView.GetRowCellValue(e.RowHandle, "Re_Qty")))
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.White;
                        }
                    }
                }
                
                    if (bgGrdView.GetRowCellValue(e.RowHandle, "MLINE_CD").Equals("TOTAL"))
                    {
                        e.Appearance.BackColor = Color.Yellow;
                        e.Appearance.ForeColor = Color.Black;
                    }

                    if (bgGrdView.GetRowCellValue(e.RowHandle, "Line_Name").Equals("G-TOTAL"))
                    {
                        e.Appearance.BackColor = Color.Gray;
                        e.Appearance.ForeColor = Color.Black;
                    }
            }
            catch { }
            //==============================
            //if (bgGrdView.GetRowCellValue(e.RowHandle, "STYLE_NAME").Equals("TOTAL") && e.Column.ColumnHandle > 0)
            //{
            //    e.Appearance.BackColor = Color.LightYellow;
            //    e.Appearance.ForeColor = Color.Black;
            //}
            //if (bgGrdView.GetRowCellValue(e.RowHandle, "LINE_NAME").Equals("G-TOTAL"))
            //{
            //    e.Appearance.BackColor = Color.LightSalmon;
            //    e.Appearance.ForeColor = Color.Black;
            //}
        }
    }
}
