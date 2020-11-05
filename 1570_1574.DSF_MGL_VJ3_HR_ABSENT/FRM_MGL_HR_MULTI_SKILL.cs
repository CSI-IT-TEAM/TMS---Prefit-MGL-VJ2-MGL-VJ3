using DevExpress.XtraTab;
using System;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FORM
{
    public partial class FRM_MGL_HR_MULTI_SKILL : Form
    {
        public FRM_MGL_HR_MULTI_SKILL()
        {
            InitializeComponent();
        }
        #region Variant
        private string Line, Mline,Lang;
        int cCount = 0;
        string[] _Arr_Pic;
        #endregion Variant

        #region Event

        #region Load/VisibleChanged/Timer
        private void FRM_MUILTI_SKILL_V2_Load(object sender, EventArgs e)
        {
            GoFullscreen();
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
         //   axfpHR.Hide();
            SetConfigForm();
            setGrid();
           // axfpHR.Show();
        }

        private void FRM_MUILTI_SKILL_V2_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                InitForm();
                cCount = 0;
                tmrDate.Start();
                
            }
            else
            {
                tmrDate.Stop();
            }
        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            if (cCount == 1)
            {

                xtraTabControl1_MouseUp(xtraTabControl1,null);
            }
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        #endregion Load/VisibleChanged/Timer

        private void lbltitle_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "Minimized";
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void xtraTabControl1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                
                progressPanel1.Visible = true;
                this.Cursor = Cursors.WaitCursor;
                //XtraTabControl xtc = sender as XtraTabControl;

                //Point pos = new Point(e.X, e.Y);

                //DevExpress.XtraTab.ViewInfo.XtraTabHitInfo xthi = xtc.CalcHitInfo(pos);

                //string tp = xthi.Page.Name;

                string tp = xtraTabControl1.SelectedTabPage.Name;
                //  MessageBox.Show(tp + " is clicked!", "xtraTabControl1_MouseUp");
               // axfpHR.Hide();
                switch (tp)
                {
                    case "Cutting":

                        BindingData("001", Line, Mline);
                        break;
                    case "Nosew":
                        BindingData("005", Line, Mline);
                        break;
                    case "HF":
                        BindingData("028", Line, Mline);
                        break;
                    case "Stitching":
                        BindingData("002", Line, Mline);
                        break;
                    case "Stockfit":
                        BindingData("003", Line, Mline);
                        break;
                    case "Assembly":
                        BindingData("004", Line, Mline);
                        break;
                    default:
                        break;
                }

               // axfpHR.Show();
              //  xthi.Page.Controls.Add(axfpHR);
                xtraTabControl1.SelectedTabPage.Controls.Add(axfpHR);
                axfpHR.Dock = DockStyle.Fill;
                this.Cursor = Cursors.Default;
                progressPanel1.Visible = false;

            }
            catch 
            {
                this.Cursor = Cursors.Default;
                progressPanel1.Visible = false;
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.AbsoluteIndex >= 2)
                e.DisplayText = "";
        }

        #endregion Event


        #region DB

        public DataTable SEL_MULTI_SKILL_V2(string Qtype, string ARG_PROCESS, string ARG_LINE, string ARG_MLINE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
               // ARG_LINE = "008";
                string process_name = "MES.PKG_SMT_PHUOC.SP_SMT_MULTI_SKILL_V2";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_PROCESS_CD";
                MyOraDB.Parameter_Name[2] = "ARG_LINE";
                MyOraDB.Parameter_Name[3] = "ARG_MLINE";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = "E";
                MyOraDB.Parameter_Values[1] = ARG_PROCESS;
                MyOraDB.Parameter_Values[2] = ComVar.Var._strValue1;
                MyOraDB.Parameter_Values[3] = "001";
                MyOraDB.Parameter_Values[4] = "";
                

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }

        #endregion DB


        #region Func
        private void BindingData(string ARG_PROCESS, string ARG_LINE, string ARG_MLINE)
        {
            try
            {
                axfpHR.Visible = false;
                this.Cursor = Cursors.WaitCursor;

                DataTable dt = SEL_MULTI_SKILL_V2("Q", ARG_PROCESS, ARG_LINE, ARG_MLINE);

                axfpHR.MaxCols = 4;
                axfpHR.MaxRows = 3;

                if (dt == null ||  dt.Rows.Count == 0) return;

                int iRows = dt.Rows.Count;
                int iColumns = dt.Columns.Count;

                //for (int i = 0; i < iColumns; i++)
                //{
                //    dt.Columns[i].ColumnName = dt.Columns[i].ColumnName.Replace("'", "").Trim();
                //}

                // gridControl1.DataSource = dt;


                //GridFormatRule gridFormatRule = new GridFormatRule();
                //FormatConditionRuleIconSet formatConditionRuleIconSet = new FormatConditionRuleIconSet();
                //FormatConditionIconSet iconSet = formatConditionRuleIconSet.IconSet = new FormatConditionIconSet();
                //FormatConditionIconSetIcon icon1 = new FormatConditionIconSetIcon();
                //FormatConditionIconSetIcon icon2 = new FormatConditionIconSetIcon();
                //FormatConditionIconSetIcon icon3 = new FormatConditionIconSetIcon();
                //FormatConditionIconSetIcon icon4 = new FormatConditionIconSetIcon();
                //FormatConditionIconSetIcon icon5 = new FormatConditionIconSetIcon();

                ////Choose predefined icons.
                //icon1.PredefinedName = "Quarters5_1.png ";
                //icon2.PredefinedName = "Quarters5_2.png ";
                //icon3.PredefinedName = "Quarters5_3.png ";
                //icon4.PredefinedName = "Quarters5_4.png ";
                //icon5.PredefinedName = "Quarters5_5.png ";

                ////Specify the type of threshold values.
                //iconSet.ValueType = FormatConditionValueType.Percent;

                ////Define ranges to which icons are applied by setting threshold values.
                //icon1.Value = 100; // target range: 67% <= value
                //icon1.ValueComparison = FormatConditionComparisonType.GreaterOrEqual;
                //icon2.Value = 75; // target range: 33% <= value < 67%
                //icon2.ValueComparison = FormatConditionComparisonType.GreaterOrEqual;
                //icon3.Value = 50; // target range: 0% <= value < 33%
                //icon3.ValueComparison = FormatConditionComparisonType.GreaterOrEqual;
                //icon4.Value = 25; // target range: 0% <= value < 33%
                //icon4.ValueComparison = FormatConditionComparisonType.GreaterOrEqual;
                //icon5.Value = 0; // target range: 0% <= value < 25%
                //icon5.ValueComparison = FormatConditionComparisonType.GreaterOrEqual;

                //Add icons to the icon set.
                //iconSet.Icons.Add(icon1);
                //iconSet.Icons.Add(icon2);
                //iconSet.Icons.Add(icon3);
                //iconSet.Icons.Add(icon4);
                //iconSet.Icons.Add(icon5);

                //Specify the rule type.
                // gridFormatRule.Rule = formatConditionRuleIconSet;
                //formatConditionRuleIconSet.IconSet = iconSet;
                // gridFormatRule.Rule = formatConditionRuleIconSet;
                //Specify the column to which formatting is applied.
                //for (int i = 3; i < gridView1.Columns.Count; i++)
                //{
                //gridFormatRule.Column = gridView1.Columns[i];
                //gridFormatRule.Column = gridView1.Columns[3];
                //gridFormatRule.ApplyToRow = true;
                //gridView1.FormatRules.Add(gridFormatRule);
                //}
                //Add the formatting rule to the GridView.




                if (iRows > 0)
                {

                    axfpHR.MaxCols = iColumns + 5;
                    axfpHR.MaxRows = iRows + 8;

                    int iGridMaxRow1 = axfpHR.MaxRows - 1, iGridMaxRow2 = axfpHR.MaxRows - 2,
                        iGridMaxRow3 = axfpHR.MaxRows - 3, iGridMaxRow4 = axfpHR.MaxRows - 4;

                    int iGridMaxCol1 = axfpHR.MaxCols - 1, iGridMaxCol2 = axfpHR.MaxCols - 2,
                        iGridMaxCol3 = axfpHR.MaxCols - 3, iGridMaxCol4 = axfpHR.MaxCols - 4;

                    string YN = null;
                    int CountTotOver = 0, STT = 0;
                    int countStar = 0, countStartTot = 0;
                    int Count75Over = 0, iR25 = 0, iR50 = 0, iR75 = 0, iR100 = 0;


                    //
                    axfpHR.set_ColWidth(iGridMaxCol3, 6);
                    axfpHR.set_ColWidth(iGridMaxCol2, 6);
                    axfpHR.set_ColWidth(iGridMaxCol1, 6);
                    axfpHR.set_ColWidth(axfpHR.MaxCols, 6);

                    for (int i = 0; i < iRows; i++)
                    {
                        STT++;
                        axfpHR.SetText(1, i + 4, STT);
                        Count75Over = 0; iR25 = 0; iR50 = 0; iR75 = 0; iR100 = 0;

                        axfpHR.set_RowHeight(i + 4, 20);

                        for (int j = 0; j < iColumns; j++)
                        {
                            if (i == iRows - 1)
                            {
                                axfpHR.Row = iGridMaxRow4;
                                axfpHR.Col = j + 2;
                                axfpHR.BackColor = Color.FromArgb(253, 255, 219);
                                axfpHR.AddCellSpan(5, iGridMaxRow4, iColumns - 3, 1);
                                axfpHR.AddCellSpan(iGridMaxCol3, iGridMaxRow4, 4, 1);

                                axfpHR.SetText(5, iGridMaxRow4, "Tỉ lệ đa kỹ năng hiện tại");

                            }
                            if (j >= 3)
                            {
                                if (i == 0 || i == 1)
                                {

                                    axfpHR.Row = i + 1;
                                    axfpHR.Col = j + 2;
                                    axfpHR.BackColor = Color.FromArgb(233, 255, 219);
                                    axfpHR.ForeColor = Color.Black;
                                    if (dt.Columns[j].Caption.Replace("'", "").Contains('_'))
                                    {
                                        if (i == 0 || i == 1)
                                        {
                                            countStartTot++;
                                            YN = null;
                                            axfpHR.SetText(j + 2, 1, dt.Columns[j].Caption.Replace("'", "").Split('_')[0]);
                                            YN = dt.Columns[j].Caption.Replace("'", "").Split('_')[1];
                                            switch (YN)
                                            {
                                                case "Y":
                                                    YN = "*";
                                                    axfpHR.BackColor = Color.Orange;
                                                    axfpHR.ForeColor = Color.Black;

                                                    countStar++;

                                                    break;
                                                case "N":
                                                    YN = null;
                                                    axfpHR.BackColor = Color.FromArgb(79, 157, 157);
                                                    axfpHR.ForeColor = Color.White;
                                                    //   countStartTot++;
                                                    break;
                                                default:
                                                    YN = null;
                                                    axfpHR.BackColor = Color.FromArgb(79, 157, 157);
                                                    axfpHR.ForeColor = Color.White;
                                                    //countStartTot++;
                                                    break;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (i == 0 || i == 1)
                                        {
                                            axfpHR.SetText(j + 2, 1, dt.Columns[j].Caption.Replace("'", ""));
                                            YN = null;
                                            axfpHR.BackColor = Color.FromArgb(79, 157, 157);
                                            axfpHR.ForeColor = Color.White;

                                        }
                                    }
                                    axfpHR.SetText(j + 2, 2, YN);
                                    if (i==0)
                                        axfpHR.set_ColWidth(j + 2, 4);
                                    //  axfpHR.Font = new Font("Calibri", 11, FontStyle.Bold);
                                    axfpHR.TypeTextOrient = FPUSpreadADO.TypeTextOrientConstants.TypeTextOrientUp;
                                    axfpHR.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                                    if (i == 0)
                                        axfpHR.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignBottom;
                                    else
                                        axfpHR.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                                }
                            }


                            axfpHR.Row = i + 4;
                            axfpHR.Col = j + 1;
                            //    axfpHR.Font = new Font("Calibri", 11, FontStyle.Bold);
                            if (j + 1 != 1 && j + 1 != 4)
                            {
                                axfpHR.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignLeft;
                            }
                            else
                                axfpHR.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                            axfpHR.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignBottom;
                            

                            axfpHR.SetText(j + 2, i + 4, dt.Rows[i][j].ToString());

                            switch (dt.Rows[i][j].ToString())
                            {
                                case "0":
                                    axfpHR.SetText(j + 2, i + 4, "");
                                    break;
                                case "25":
                                    LoadSmile(i + 4, j + 2, _Arr_Pic[1]);
                                    iR25++;
                                    break;
                                case "50":
                                    LoadSmile(i + 4, j + 2, _Arr_Pic[2]);
                                    iR50++;

                                    break;
                                case "75":
                                    LoadSmile(i + 4, j + 2, _Arr_Pic[3]);
                                    if (GetText(axfpHR, j + 2, 2).Equals("*"))
                                        Count75Over = Count75Over + 1;
                                    iR75++;
                                    break;
                                case "100":
                                    LoadSmile(i + 4, j + 2, _Arr_Pic[4]);
                                    iR100++;
                                    break;
                                default:

                                    break;
                            }
                        }
                        //Dem over 75
                        if (Count75Over >= 2)
                        {
                            axfpHR.SetText(4, i + 4, "*");
                            axfpHR.Col = 4;
                            axfpHR.Row = i + 4;
                            axfpHR.BackColor = Color.Orange;

                            CountTotOver++;
                        }
                        else
                            axfpHR.SetText(4, i + 4, null);

                        axfpHR.SetText(iGridMaxCol3, i + 4, iR25);
                        axfpHR.SetText(iGridMaxCol2, i + 4, iR50);
                        axfpHR.SetText(iGridMaxCol1, i + 4, iR75);
                        axfpHR.SetText(axfpHR.MaxCols, i + 4, iR100);
                    }

                    axfpHR.SetText(iGridMaxCol3, 1, "Số kỹ năng có thể làm được");
                    axfpHR.AddCellSpan(iGridMaxCol3, 1, 4, 1);
                    LoadSmile(2, iGridMaxCol3, _Arr_Pic[1]);
                    LoadSmile(2, iGridMaxCol2, _Arr_Pic[2]);
                    LoadSmile(2, iGridMaxCol1, _Arr_Pic[3]);
                    LoadSmile(2, axfpHR.MaxCols, _Arr_Pic[4]);


                    axfpHR.Row = 1;
                    axfpHR.Col = iGridMaxCol3;
                    //      axfpHR.Font = new Font("Calibri", 11, FontStyle.Bold);
                    axfpHR.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                    axfpHR.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignBottom;
                    //for (int k = iGridMaxCol3; k <= axfpHR.MaxCols; k++)
                    //{
                    //    for (int i = 4; i <= axfpHR.MaxRows; i++)
                    //    {
                    //        axfpHR.Row = i;
                    //        axfpHR.Col = k;
                    //        //       axfpHR.Font = new Font("Calibri", 11, FontStyle.Bold);
                    //        axfpHR.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                    //        axfpHR.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignBottom;

                    //    }
                    //    axfpHR.set_ColWidth(k, 6);
                    //}
                    //Total
                    axfpHR.set_RowHeight(iGridMaxRow4, 20);
                    axfpHR.SetText(1, iGridMaxRow4, "Tổng");
                    axfpHR.AddCellSpan(1, iGridMaxRow4, 2, 1);
                    axfpHR.SetText(3, iGridMaxRow4, iRows.ToString());
                    axfpHR.SetText(4, iGridMaxRow4, CountTotOver);
                    double NumA = Convert.ToDouble(GetText(this.axfpHR, 4, iGridMaxRow4));
                    double NumB = Convert.ToDouble(GetText(this.axfpHR, 3, iGridMaxRow4));
                    axfpHR.SetText(iGridMaxCol3, iGridMaxRow4, (Math.Round((NumA / NumB) * 100, 1) + "%").ToString());
                    axfpHR.set_RowHeight(1, 130); axfpHR.set_RowHeight(2, 30);

                    axfpHR.Row = iGridMaxRow4;
                    axfpHR.Col = 1;
                    //   axfpHR.Font = new Font("Calibri", 14, FontStyle.Bold);
                    axfpHR.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                    axfpHR.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignCenter;


                    //Muc do
                    axfpHR.set_RowHeight(iGridMaxRow3, 30);
                    axfpHR.set_RowHeight(iGridMaxRow2, 30);
                    axfpHR.set_RowHeight(iGridMaxRow1, 30);
                    axfpHR.set_RowHeight(axfpHR.MaxRows, 30);

                    axfpHR.SetText(1, iGridMaxRow3, "Mức Độ");
                    axfpHR.AddCellSpan(1, iGridMaxRow3, 3, 4);

                    axfpHR.Row = iGridMaxRow3;
                    axfpHR.Col = 1;
                    //    axfpHR.Font = new Font("Calibri", 14, FontStyle.Bold);
                    axfpHR.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                    axfpHR.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignCenter;


                    //Load Image Muc Do
                    LoadSmile(iGridMaxRow3, 4, _Arr_Pic[1]);
                    LoadSmile(iGridMaxRow2, 4, _Arr_Pic[2]);
                    LoadSmile(iGridMaxRow1, 4, _Arr_Pic[3]);
                    LoadSmile(axfpHR.MaxRows, 4, _Arr_Pic[4]);

                    for (int iCol = 0; iCol < iColumns; iCol++)
                    {
                        int iC25 = 0, iC50 = 0, iC75 = 0, iC100 = 0;
                        for (int iRow = 0; iRow < iRows; iRow++)
                        {
                            if (iCol >= 3)
                            {
                                switch (dt.Rows[iRow][iCol].ToString())
                                {
                                    case "0":
                                        break;
                                    case "25":
                                        iC25++;
                                        break;
                                    case "50":
                                        iC50++;
                                        break;
                                    case "75":
                                        iC75++;
                                        break;
                                    case "100":
                                        iC100++;
                                        break;
                                    default:
                                        break;
                                }
                            }


                        }


                        axfpHR.SetText(iCol + 2, iGridMaxRow3, iC25);
                        axfpHR.SetText(iCol + 2, iGridMaxRow2, iC50);
                        axfpHR.SetText(iCol + 2, iGridMaxRow1, iC75);
                        axfpHR.SetText(iCol + 2, axfpHR.MaxRows, iC100);
                    }

                    axfpHR.SetText(3, 2, countStar + "/" + countStartTot);




                    axfpHR.SetCellBorder(0, 0, axfpHR.MaxCols, axfpHR.MaxRows, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexTop, 0x000000, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);

                    axfpHR.SetCellBorder(0, 0, axfpHR.MaxCols, axfpHR.MaxRows, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0x000000, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);

                    axfpHR.SetCellBorder(0, 0, axfpHR.MaxCols, axfpHR.MaxRows, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexRight, 0x000000, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);

                    axfpHR.SetCellBorder(0, 0, axfpHR.MaxCols, axfpHR.MaxRows, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0x000000, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);



                    axfpHR.SetCellBorder(0, 0, axfpHR.MaxCols, iGridMaxRow4, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexTop, 0x000000, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

                    axfpHR.SetCellBorder(0, 0, axfpHR.MaxCols, iGridMaxRow4, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0x000000, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

                    axfpHR.SetCellBorder(0, 0, axfpHR.MaxCols, iGridMaxRow4, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexRight, 0x000000, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

                    axfpHR.SetCellBorder(0, 0, axfpHR.MaxCols, iGridMaxRow4, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0x000000, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

                    axfpHR.SetCellBorder(0, 0, axfpHR.MaxCols, iGridMaxRow3, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexTop, 0x000000, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

                    axfpHR.SetCellBorder(0, 0, axfpHR.MaxCols, iGridMaxRow3, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0x000000, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

                    axfpHR.SetCellBorder(0, 0, iGridMaxCol4, axfpHR.MaxRows, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexTop, 0x000000, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

                    axfpHR.SetCellBorder(0, 0, iGridMaxCol4, axfpHR.MaxRows, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0x000000, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

                    axfpHR.SetCellBorder(0, 0, iGridMaxCol3, axfpHR.MaxRows, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0x000000, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);


                    axfpHR.SetCellBorder(0, 0, iGridMaxCol3, axfpHR.MaxRows, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexRight, 0x000000, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                }
            }
            catch
            {

            }
            finally
            {
                this.Cursor = Cursors.Arrow;
                axfpHR.Visible = true;
            }

        }

        private void setGrid()
        {
            try
            {
                axfpHR.Font = new Font("Calibri", 11, FontStyle.Bold);
                axfpHR.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                axfpHR.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                axfpHR.RowsFrozen = 3;
                axfpHR.ColsFrozen = 4;

                string Per0 = null, Per25 = null, Per50 = null, Per75 = null, Per100 = null;
                Per0 = Application.StartupPath + "\\smile\\0.png";
                Per25 = Application.StartupPath + "\\smile\\25.png";
                Per50 = Application.StartupPath + "\\smile\\50.png";
                Per75 = Application.StartupPath + "\\smile\\75.png";
                Per100 = Application.StartupPath + "\\smile\\100.png";
                _Arr_Pic = new string[] { Per0, Per25, Per50, Per75, Per100 };
            }
            catch 
            {}
            
        }

        private string GetText(AxFPUSpreadADO.AxfpSpread spread, int col, int row)
        {
            try
            {
                object data = null;
                spread.GetText(col, row, ref data);
                return data.ToString();
            }
            catch 
            {
                //return "";
                //log.Error(ex);
                return null;
            }

        }

        private void LoadSmile(int Row, int Col, string Picture)
        {
            try
            {
                axfpHR.Row = Row;
                axfpHR.Col = Col;
                axfpHR.CellType = FPUSpreadADO.CellTypeConstants.CellTypePicture;
                axfpHR.TypePictPicture = axfpHR.LoadPicture(Picture, FPUSpreadADO.PictureTypeConstants.PictureTypePNG);
                axfpHR.TypePictStretch = true;
            }
            catch 
            {}
           
            //axfpSpread1.TypePictCenter = true;
        }
        
        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }

        private void InitForm()
        {
            Line = ComVar.Var._strValue1;
            Mline = ComVar.Var._strValue2;
            Lang = ComVar.Var._strValue3;
            if (Line == "099" || Line == "001" || Line == "002" || Line == "003" || Line == "004" || Line == "005" || Line == "006")
            {
                Cutting.PageVisible = false;
                Nosew.PageVisible = false;
                HF.PageVisible = false;
                Stitching.PageVisible = false;
               
            }
            if (ComVar.Var._strValue1 == "Vn")
                lblTitle.Text = "Tỉ lệ nhân lực đa kỹ năng";
            else
                lblTitle.Text = "Multi-Skill Ratio";
        }

        #endregion Func


        #region  Get Config Data From Database
        /// <summary>
        /// Declare _dtnInit
        /// Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        /// </summary>
        private void SetConfigForm()
        {
            try
            {
                System.Collections.Generic.Dictionary<string, string> dtnInit = new System.Collections.Generic.Dictionary<string, string>();
                dtnInit = ComVar.Func.getInitForm(ComVar.Var._Area + this.GetType().Assembly.GetName().Name, this.GetType().Name);
                if (dtnInit == null) return;
                for (int i = 0; i < dtnInit.Count; i++)
                {
                    SetComValue(dtnInit.ElementAt(i).Key, dtnInit.ElementAt(i).Value);
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setConfigForm-->Err:    " + ex.ToString());
            }
        }

        private void SetComValue(string obj, string obj_value)
        {
            try
            {
                if (obj.Contains('.'))
                {
                    string[] strSplit = obj.Split('.');
                    Control[] cnt = this.Controls.Find(strSplit[0], true);

                    for (int i = 0; i < cnt.Length; i++)
                    {
                        System.Reflection.PropertyInfo propertyInfo = cnt[i].GetType().GetProperty(strSplit[1]);
                        propertyInfo.SetValue(cnt[i], Convert.ChangeType(obj_value, propertyInfo.PropertyType), null);
                    }
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setComValue (" + obj + ", " + obj_value + ") Err:    " + ex.ToString());
            }

        }
        #endregion 
        

       

        

        

        

        

        


        
    }
}
