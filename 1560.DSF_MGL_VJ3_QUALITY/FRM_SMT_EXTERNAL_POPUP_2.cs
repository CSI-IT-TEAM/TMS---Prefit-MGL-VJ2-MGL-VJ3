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
    public partial class FRM_SMT_EXTERNAL_POPUP_2 : Form
    {
        public FRM_SMT_EXTERNAL_POPUP_2(DataTable _dt)
        {
            InitializeComponent();
            dt = _dt;
        }
        DataTable dt = null;

        private void FRM_SMT_INTERNAL_POPUP_1_Load(object sender, EventArgs e)
        {
            grdBase.DataSource = dt;
            formatColumn();
            bgGrdView.TopRowIndex = bgGrdView.RowCount - 12;
        }

        private void formatColumn()
        {
            for (int i = 0; i < bgGrdView.Columns.Count; i++)
            {
                if (i == 0 || i == 1)
                    bgGrdView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                else
                    bgGrdView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;


                if (bgGrdView.Columns[i].FieldName.Equals("STYLE_NAME"))
                {
                    bgGrdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                }
                else
                {
                    bgGrdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
                //if (i == 4)
                //{
                //    bgGrdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                //}

                if (i == 4)
                {
                    bgGrdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    bgGrdView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    bgGrdView.Columns[i].DisplayFormat.FormatString = "#,0";

                }
                if (i == 5 || i == 6)
                {
                    bgGrdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    bgGrdView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    bgGrdView.Columns[i].DisplayFormat.FormatString = "#,0.##";
                }
            }   
        }

        private void bgGrdView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (bgGrdView.GetRowCellValue(e.RowHandle, "MLINE_CD").Equals("TOTAL") && e.Column.ColumnHandle > 0)
                {
                    e.Appearance.BackColor = Color.Yellow;
                    e.Appearance.ForeColor = Color.Black;
                }
                if (bgGrdView.GetRowCellValue(e.RowHandle, "LINE_NAME").Equals("G-TOTAL"))
                {
                    e.Appearance.BackColor = Color.Gray;
                    e.Appearance.ForeColor = Color.Black;
                }
            }
            catch { }
            
        }
    }
}
