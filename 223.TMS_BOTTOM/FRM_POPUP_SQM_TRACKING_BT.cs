using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.Utils;
using System.Linq.Expressions;

namespace FORM
{
    public partial class FRM_POPUP_SQM_TRACKING_BT : Form
    {
        public FRM_POPUP_SQM_TRACKING_BT(Control control, DataTable _dt, bool _isToday)
        {
            InitializeComponent();
            flyoutPanel1.OwnerControl = control;
            dt = _dt;
            isToday = _isToday;
        }
        public FRM_POPUP_SQM_TRACKING_BT(Control control)
        {
            InitializeComponent();
            flyoutPanel1.OwnerControl = control;
        }
        int _start_column;
        DataTable dt;
        bool isToday;
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static DataTable GetInversedDataTable(DataTable table, string columnX,
                                              params string[] columnsToIgnore)
        {
            //Create a DataTable to Return
            DataTable returnTable = new DataTable();

            if (columnX == "")
                columnX = table.Columns[0].ColumnName;

            //Add a Column at the beginning of the table

            returnTable.Columns.Add(columnX);

            //Read all DISTINCT values from columnX Column in the provided DataTale
            List<string> columnXValues = new List<string>();

            //Creates list of columns to ignore
            List<string> listColumnsToIgnore = new List<string>();
            if (columnsToIgnore.Length > 0)
                listColumnsToIgnore.AddRange(columnsToIgnore);

            if (!listColumnsToIgnore.Contains(columnX))
                listColumnsToIgnore.Add(columnX);

            foreach (DataRow dr in table.Rows)
            {
                string columnXTemp = dr[columnX].ToString();
                //Verify if the value was already listed
                if (!columnXValues.Contains(columnXTemp))
                {
                    //if the value id different from others provided, add to the list of 
                    //values and creates a new Column with its value.
                    columnXValues.Add(columnXTemp);
                    returnTable.Columns.Add(columnXTemp);
                }
                else
                {
                    //Throw exception for a repeated value
                    throw new Exception("The inversion used must have " +
                                        "unique values for column " + columnX);
                }
            }

            //Add a line for each column of the DataTable

            foreach (DataColumn dc in table.Columns)
            {
                if (!columnXValues.Contains(dc.ColumnName) &&
                    !listColumnsToIgnore.Contains(dc.ColumnName))
                {
                    DataRow dr = returnTable.NewRow();
                    dr[0] = dc.ColumnName;
                    returnTable.Rows.Add(dr);
                }
            }

            //Complete the datatable with the values
            for (int i = 0; i < returnTable.Rows.Count; i++)
            {
                for (int j = 1; j < returnTable.Columns.Count; j++)
                {
                    returnTable.Rows[i][j] =
                      table.Rows[j - 1][returnTable.Rows[i][0].ToString()].ToString();
                }
            }

            return returnTable;
        }

        private void BindingDataGrid(DataTable dt)
        {
            try
            {
                DataTable dt1 = GetInversedDataTable(dt, "CMP_CD", "START_COLUMN");
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    gridView1.Columns[i].OptionsColumn.ReadOnly = true;
                    gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                    if (gridView1.Columns[i].FieldName == "STYLE_CD")
                    {
                        gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    }
                    else
                    {
                        gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    }
                    if (i > 1)
                    {
                        gridView1.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                        gridView1.Columns[i].DisplayFormat.FormatString = "#,#";
                    }
                    gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                }
                gridView1.Columns["COMP_NM"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                gridView1.Columns["STYLE_CD"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            }
            catch { }
        }

        private void FRM_POPUP_SQM_TRACKING_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void FRM_POPUP_SQM_TRACKING_Load(object sender, EventArgs e)
        {

        }

        private void chartControl1_BoundDataChanged(object sender, EventArgs e)
        {

        }

        public void ShowBeakForm()
        {
            flyoutPanel1.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Default;
            //Cursor = new Cursor(Cursor.Current.Handle);
            //Cursor.Position = new Point(Cursor.Position.X + 40, Cursor.Position.Y);
            flyoutPanel1.ShowBeakForm(Cursor.Position);
            //Cursor.Position = new Point(Cursor.Position.X - 40, Cursor.Position.Y);
            BindingDataGrid(dt);

        }
    }
}
