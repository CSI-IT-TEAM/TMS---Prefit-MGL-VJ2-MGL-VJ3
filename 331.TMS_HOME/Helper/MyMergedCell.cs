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
using DevExpress.XtraGrid.Columns;

namespace FORM
{
    public class MyMergedCell
    {

        public MyMergedCell(int rowHandle, GridColumn col1, GridColumn col2)
        {
            _RowHandle = rowHandle;
            _Column1 = col1;
            _Column2 = col2;
        }

        private GridColumn _Column2;
private GridColumn _Column1;
        private int _RowHandle;
        public int RowHandle
        {
            get { return _RowHandle; }
            set { _RowHandle = value; }
        }


        public GridColumn Column1
        {
            get { return _Column1; }
            set
            {
                _Column1 = value;

            }
        }


        public GridColumn Column2
        {
            get { return _Column2; }
            set
            {
                _Column2 = value;

            }
        }


    }
}
