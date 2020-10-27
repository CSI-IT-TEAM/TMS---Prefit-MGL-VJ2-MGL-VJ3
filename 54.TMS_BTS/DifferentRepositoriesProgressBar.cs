using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;

namespace FORM
{
    class DifferentRepositoriesProgressBar
    {
        GridColumn Column;
        GridView View;

        RepositoryItemProgressBar prbLess0;
        RepositoryItemProgressBar prbLess68;
        RepositoryItemProgressBar prbLess70;
        RepositoryItemProgressBar prbLess72;

        public DifferentRepositoriesProgressBar(GridColumn column)
        {
            PrbInit();
            Column = column;
            View = Column.View as GridView;
            View.CustomRowCellEdit +=new CustomRowCellEditEventHandler(View_CustomRowCellEdit);

        }
        void PrbInit()
        {
            prbLess0 = new RepositoryItemProgressBar();
            prbLess0.StartColor = Color.Black;
            prbLess0.EndColor = Color.Black;
            prbLess0.ShowTitle = true;
            prbLess0.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            prbLess0.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            prbLess0.LookAndFeel.UseDefaultLookAndFeel = false;

            prbLess68 = new RepositoryItemProgressBar();
            prbLess68.StartColor = Color.Red;
            prbLess68.EndColor = Color.Red;
            prbLess68.ShowTitle = true;
            prbLess68.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            prbLess68.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            prbLess68.LookAndFeel.UseDefaultLookAndFeel = false;

            prbLess72 = new RepositoryItemProgressBar();
            prbLess72.StartColor = Color.Green;
            prbLess72.EndColor = Color.Green;
            prbLess72.ShowTitle = true;
            prbLess72.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            prbLess72.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            prbLess72.LookAndFeel.UseDefaultLookAndFeel = false;

            prbLess70 = new RepositoryItemProgressBar();
            prbLess70.StartColor = Color.Yellow;
            prbLess70.EndColor = Color.Yellow;
            prbLess70.ShowTitle = true;
            prbLess70.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            prbLess70.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            prbLess70.LookAndFeel.UseDefaultLookAndFeel = false;

        }

        private void View_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column == Column)
            {
                int percent = Convert.ToInt16(e.CellValue);
                if (percent > 72)
                    e.RepositoryItem = prbLess72;
                else if (percent > 70)
                    e.RepositoryItem = prbLess70;
                else if (percent > 68)
                    e.RepositoryItem = prbLess68;
                else if (percent > 0)
                    e.RepositoryItem = prbLess0;
            }
        }
    }
}
