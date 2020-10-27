// Developer Express Code Central Example:
// How to merge cells horizontally in GridView
// 
// This example demonstrates how to merge cells located in the same row. The main
// idea is to paint merged cell manually.
// You can find a helper class in this
// example, which can be easily connected to your existing GridView.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E2472

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Columns;

namespace FORM
{
    public class MyCellMergeHelper
    {
        private List<MyMergedCell> _MergedCells = new List<MyMergedCell>();
        public List<MyMergedCell> MergedCells
        {
            get { return _MergedCells; }
        }

        MyGridPainter painter;


        GridView _view;

        public MyCellMergeHelper(GridView view)
        {
            _view = view;            
            view.CustomDrawCell += new RowCellCustomDrawEventHandler(view_CustomDrawCell);
            view.GridControl.Paint += new PaintEventHandler(GridControl_Paint);
            view.CellValueChanged += new CellValueChangedEventHandler(view_CellValueChanged);
            painter = new MyGridPainter(view);
        }

        public MyMergedCell AddMergedCell(int rowHandle, GridColumn col1, GridColumn col2)
        {
            MyMergedCell cell = new MyMergedCell(rowHandle, col1, col2);            
            _MergedCells.Add(cell);            
            return cell;
        }

        public void removeMerged()
        {
            for (int i = 0; i < _MergedCells.Count - 1; i++)
                _MergedCells.RemoveAt(i);
        }



        public void AddMergedCell(int rowHandle, int col1, int col2, object value)
        {
            AddMergedCell(rowHandle, _view.Columns[col1], _view.Columns[col2]);
        }
       

        public void AddMergedCell(int rowHandle, GridColumn col1, GridColumn col2, object value)
        {
            MyMergedCell cell = AddMergedCell(rowHandle, col1, col2);
            SafeSetMergedCellValue(cell, value);
        }



        public void SafeSetMergedCellValue(MyMergedCell cell, object value)
        {
            if (cell != null)
            {
                SafeSetCellValue(cell.RowHandle, cell.Column1, value);
                SafeSetCellValue(cell.RowHandle, cell.Column2, value);
            }
        }

        public void SafeSetCellValue(int rowHandle, GridColumn column, object value)
        {
            if (_view.GetRowCellValue(rowHandle, column).ToString() != value.ToString())
                _view.SetRowCellValue(rowHandle, column, value);
        }


        private MyMergedCell GetMergedCell(int rowHandle, GridColumn column)
        {
            foreach (MyMergedCell cell in _MergedCells)
            {
                if (cell.RowHandle == rowHandle && (column == cell.Column1 || column == cell.Column2))
                    return cell;
            }
            return null;
        }

        private bool IsMergedCell(int rowHandle, GridColumn column)
        {
            return GetMergedCell(rowHandle, column) != null;
        }

        private void DrawMergedCells(PaintEventArgs e)
        {
            foreach (MyMergedCell cell in _MergedCells)
            {
                painter.DrawMergedCell(cell, e);
            }
        }


        void view_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            SafeSetMergedCellValue(GetMergedCell(e.RowHandle, e.Column), e.Value);  
        }

        void GridControl_Paint(object sender, PaintEventArgs e)
        {
            DrawMergedCells(e);
        }

        void view_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (IsMergedCell(e.RowHandle, e.Column))
                e.Handled = !painter.IsCustomPainting;
        }
     
    }
}