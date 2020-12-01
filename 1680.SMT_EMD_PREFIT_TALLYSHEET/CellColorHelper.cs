using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FORM
{
    public class CellColorHelper
    {
        Dictionary<MyGridCell, Color> colors = new Dictionary<MyGridCell, Color>();
        private readonly GridView _View;
        /// <summary>
        /// Initializes a new instance of the CellColorHelper class.
        /// </summary>
        public CellColorHelper(GridView view)
        {
            _View = view;
            _View.RowCellStyle += _View_RowCellStyle;
        }

        void _View_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            Color color = GetCellColor(new MyGridCell(e.RowHandle, e.Column));
            if (color.IsEmpty)
                return;
            e.Appearance.BackColor = color;
        }

        public Color GetCellColor(MyGridCell cell)
        {
            Color c = Color.Empty;
            if (colors.TryGetValue(cell, out c))
                return c;
            return Color.Empty;
        }

        public void SetCellColor(int rowHandle, GridColumn column, Color value)
        {
            SetCellColor(new MyGridCell(rowHandle, column), value);
        }

        public void SetCellColor(MyGridCell cell, Color value)
        {
            colors[cell] = value;
            _View.RefreshRowCell(cell.RowHandle, cell.Column);
        }

    }

    public class MyGridCell : GridCell
    {
        public MyGridCell(int rowHandle, GridColumn column)
            : base(rowHandle, column)
        {

        }

        public override int GetHashCode()
        {
            return Column.GetHashCode() + RowHandle.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as GridCell);
        }
    }
}
