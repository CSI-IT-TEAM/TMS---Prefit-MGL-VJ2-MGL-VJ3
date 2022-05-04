using DevExpress.Skins;
using DevExpress.XtraCharts;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM
{
    public partial class POPUP_PROD_BY_PLANT : Form
    {
        public POPUP_PROD_BY_PLANT()
        {
            InitializeComponent();
        }
        public delegate void OnDateChangeHandler(string date);
        public OnDateChangeHandler OnDateChange = null;
        public POPUP_PROD_BY_PLANT(Control control, DataTable _dt, DataTable _dtTreeChartDetail)
        {
            InitializeComponent();
            dt = _dt;
            dtTreeChartDetail = _dtTreeChartDetail;
            dateEdit1.EditValue = DateTime.Now;
            dateEdit1.EditValueChanged += new System.EventHandler(dateEdit1_EditValueChanged);

        }
        DataTable dt = null, dtTreeChartDetail = null, dtTreeChartDetailCopy = null;

        public void BindingTreeView(DataTable dt)
        {
            try
            {
                treeList.DataSource = dt;
                treeList.KeyFieldName = "ID";
                treeList.ParentFieldName = "PARENTID";
                treeList.Columns["ID_NAME"].Visible = false;

                Skin skin = GridSkins.GetSkin(treeList.LookAndFeel);
                skin.Properties[GridSkins.OptShowTreeLine] = true;
                chkAll.Checked = true;
                foreach (TreeListNode node in treeList.Nodes)
                {
                    var dataRow = treeList.GetDataRecordByNode(node);
                    node.Tag = dataRow;
                    node.Checked = true;
                    node.Expanded = true;
                    foreach (TreeListNode node1 in node.RootNode.Nodes)
                    {
                        if (node.Checked)
                            node1.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void BindingData()
        {
            try
            {
                chartControl1.DataSource = dt;
                chartControl1.Series[1].ArgumentDataMember = "LINE_NM";
                chartControl1.Series[1].ValueDataMembers.AddRange(new string[] { "PROD_QTY" });
                chartControl1.Series[0].ArgumentDataMember = "LINE_NM";
                chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "PLAN_QTY" });
                chartControl1.Series[2].ArgumentDataMember = "LINE_NM";
                chartControl1.Series[2].ValueDataMembers.AddRange(new string[] { "RATE" });
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                foreach (TreeListNode node in treeList.Nodes)
                {
                    node.Checked = true;
                    foreach (TreeListNode node1 in node.RootNode.Nodes)
                    {
                        node1.Checked = true;
                    }
                }
            }
            else
            {
                foreach (TreeListNode node in treeList.Nodes)
                {
                    node.Checked = false;
                    foreach (TreeListNode node1 in node.RootNode.Nodes)
                    {
                        node1.Checked = false;
                    }
                }
            }
            dtTreeChartDetailCopy = dtTreeChartDetail.Copy();
            BindingTree_Detail_Chart(dtTreeChartDetailCopy);
        }

        private void treeList_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Node.GetValue("PARENTID").ToString() == "000")
            {
                e.Appearance.BackColor = Color.Black;
                e.Appearance.ForeColor = Color.Yellow;
                e.Appearance.Font = new Font("Times New Roman", 13, FontStyle.Bold ^ FontStyle.Italic);
            }
        }

        private void treeList_MouseUp(object sender, MouseEventArgs e)
        {
            TreeList tree = sender as TreeList;
            Point pt = new Point(e.X, e.Y);
            TreeListHitInfo hit = tree.GetHitInfo(pt);
            int cnt = 0;
            if (hit.Column != null)
            {
                foreach (TreeListNode node in treeList.Nodes)
                {
                    foreach (TreeListNode node1 in node.RootNode.Nodes)
                    {
                        if (node1.Checked)
                        {
                            cnt++;
                        }
                    }
                }

                if (cnt == 0)
                {
                    foreach (TreeListNode node in treeList.Nodes)
                    {
                        node.Checked = true;
                        foreach (TreeListNode node1 in node.RootNode.Nodes)
                        {
                            node1.Checked = true;
                        }
                    }
                }
                else
                {
                    foreach (TreeListNode node in treeList.Nodes)
                    {
                        node.Checked = false;
                        foreach (TreeListNode node1 in node.RootNode.Nodes)
                        {
                            node1.Checked = false;
                        }
                    }
                }
            }
        }
        private void SetCheckedChildNodes(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
                node.Checked = node.ParentNode.Checked;
        }

        private bool IsAllChecked(DevExpress.XtraTreeList.Nodes.TreeListNodes nodes)
        {
            bool value = true;
            foreach (TreeListNode node in nodes)
            {
                if (!node.Checked)
                {
                    value = false;
                    break;
                }
            }
            return value;
        }

        public void BindingDataWhenDateChanged(DataTable dt)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtTreeChartDetail = dt;
                dtTreeChartDetailCopy = dtTreeChartDetail.Copy();
                BindingTree_Detail_Chart(dtTreeChartDetailCopy);
                this.Cursor = Cursors.Default;
            }
            catch
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (OnDateChange != null)
            {
                OnDateChange(dateEdit1.DateTime.ToString("yyyyMMdd"));
            }
        }

        private void treeList_AfterCheckNode(object sender, NodeEventArgs e)
        {
            if (e.Node.ParentNode != null)
                e.Node.ParentNode.Checked = IsAllChecked(e.Node.ParentNode.Nodes);
            else
                SetCheckedChildNodes(e.Node.Nodes);
            dtTreeChartDetailCopy = dtTreeChartDetail.Copy();
            BindingTree_Detail_Chart(dtTreeChartDetailCopy);
        }

        private void BindingTree_Detail_Chart(DataTable dt)
        {
            try
            {
                List<string> nodeTextList = new List<string>();
                foreach (TreeListNode node in treeList.Nodes)
                {
                    //nodeTextList.Add(node.GetDisplayText(1));
                    foreach (TreeListNode node1 in node.Nodes)
                    {
                        if (node1.Checked)
                            nodeTextList.Add(node1.GetDisplayText(1));
                        else
                        {
                            DataRow[] drr = dt.Select("LINE_NM ='" + node1.GetDisplayText(1) + "'");
                            for (int i = 0; i < drr.Length; i++)
                                dt.Rows.Remove(drr[i]);
                            dt.AcceptChanges();
                        }
                    }
                }

                chartControl2.DataSource = dt;
                chartControl2.SeriesDataMember = "LINE_NM";
                chartControl2.SeriesTemplate.ArgumentDataMember = "HMS";
                chartControl2.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "QTY" });
                LineSeriesView lineseriesView = new LineSeriesView();
                DevExpress.XtraCharts.XYMarkerSlideAnimation xyMarkerSlideAnimation2 = new DevExpress.XtraCharts.XYMarkerSlideAnimation();
                DevExpress.XtraCharts.CircleEasingFunction easingfunc = new DevExpress.XtraCharts.CircleEasingFunction();
                xyMarkerSlideAnimation2.Direction = DevExpress.XtraCharts.XYMarkerSlideAnimationDirection.FromBottomCenter;
                xyMarkerSlideAnimation2.EasingFunction = easingfunc;
                lineseriesView.SeriesPointAnimation = xyMarkerSlideAnimation2;
                chartControl2.SeriesTemplate.CrosshairLabelPattern = "{S}:{V:#,#}";
                chartControl2.SeriesTemplate.View = lineseriesView;
                lineseriesView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                lineseriesView.SeriesPointAnimation.EasingFunction.EasingMode = EasingMode.InOut;
                lineseriesView.SeriesPointAnimation.Enabled = true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}