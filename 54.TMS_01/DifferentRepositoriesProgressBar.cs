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
        RepositoryItemProgressBar prbLess50;
        RepositoryItemProgressBar prbLess70;
        RepositoryItemProgressBar prbLess90;

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

            prbLess50 = new RepositoryItemProgressBar();
            prbLess50.StartColor = Color.Red;
            prbLess50.EndColor = Color.Red;
            prbLess50.ShowTitle = true;
            prbLess50.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            prbLess50.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            prbLess50.LookAndFeel.UseDefaultLookAndFeel = false;

            prbLess70 = new RepositoryItemProgressBar();
            prbLess70.StartColor = Color.Gold;
            prbLess70.EndColor = Color.Gold;
            prbLess70.Appearance.ForeColor = Color.Blue;
            prbLess70.Appearance.ForeColor2 = Color.Blue;
            prbLess70.ShowTitle = true;
            prbLess70.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            prbLess70.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            prbLess70.LookAndFeel.UseDefaultLookAndFeel = false;

            prbLess90 = new RepositoryItemProgressBar();
            prbLess90.StartColor = Color.Yellow;
            prbLess90.EndColor = Color.Yellow;
            prbLess90.Appearance.ForeColor = Color.Black;
            prbLess90.Appearance.ForeColor2 = Color.Black;
            prbLess90.ShowTitle = true;
            prbLess90.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            prbLess90.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            prbLess90.LookAndFeel.UseDefaultLookAndFeel = false;

        }

        private void View_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column == Column)
            {
                int percent = Convert.ToInt16(e.CellValue);
                if (percent > 90)
                    e.RepositoryItem = prbLess90;
                else if (percent > 70)
                    e.RepositoryItem = prbLess70;
                else if (percent > 50)
                    e.RepositoryItem = prbLess50;
                else if (percent > 0)
                    e.RepositoryItem = prbLess0;
            }
        }
    }
}
