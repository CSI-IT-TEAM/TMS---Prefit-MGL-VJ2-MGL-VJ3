using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGauges.Core.Model;
using DevExpress.Skins;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;

namespace FORM.UC
{
    public partial class UC_DSF_MGL_CARD : UserControl
    {
        public UC_DSF_MGL_CARD()
        {
            InitializeComponent();
        }
        DataTable table;
        DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("PARENTID", typeof(int));
            table.Columns.Add("Drug", typeof(int));
            table.Columns.Add("MENU_NM", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            // Here we add five DataRows.
            table.Rows.Add(1, 1, 25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(2, 2, 50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(3, 2, 10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(4, 2, 21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(5, 3, 300, "Dilantin", "Melanie", DateTime.Now);
            return table;
        }
        string _FacCode;
        public void BindingData(string FacCode,string FacTitle,DataTable dt)
        {
            lblFac.Text = FacTitle;
            _FacCode = FacCode;
            lblDplan.Text = "0 Prs";
            lblRplan.Text = "0 Prs";
            lblAct.Text = "0 Prs";
            lblRate.Text = "0%";

            if (dt!=null && dt.Rows.Count>0)
            {
                lblDplan.Text =string.Concat(string.Format("{0:n0}", dt.Rows[0]["PLAN_QTY"])," Prs");
                lblRplan.Text = string.Concat(string.Format("{0:n0}", dt.Rows[0]["RPLAN_QTY"]), " Prs");
                lblAct.Text = string.Concat(string.Format("{0:n0}", dt.Rows[0]["PROD_QTY"]), " Prs");
                lblRate.Text = string.Concat(string.Format("{0:n1}", dt.Rows[0]["RATE"]), "%");
            }
        }
        public void BindingTree(DataTable dt)
        {
            treeList1.DataSource = dt;
            treeList1.KeyFieldName = "ID";
            treeList1.ParentFieldName = "PARENTID";
            Skin skin = GridSkins.GetSkin(treeList1.LookAndFeel);
            skin.Properties[GridSkins.OptShowTreeLine] = true;

            foreach (TreeListNode node in treeList1.Nodes)
            {
                var dataRow = treeList1.GetDataRecordByNode(node);
                node.Tag = dataRow;
                if (node.Id <= 4)
                    node.Expanded = true;
            }
        }
        private void treeList1_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            e.NodeImageIndex = e.Node.Id;
           // e.Node.Expanded = false;
            //if (e.Node.Id <= 1 || e.Node.Id == 3)
            //    e.Node.Expanded = true;
        }

        private void treeList1_CustomDrawNodeButton(object sender, DevExpress.XtraTreeList.CustomDrawNodeButtonEventArgs e)
        {
            Brush backBrush = e.Cache.GetSolidBrush(Color.White);
            e.Graphics.FillRectangle(backBrush, e.Bounds);
            ControlPaint.DrawBorder(e.Graphics, e.Bounds, Color.Gray, ButtonBorderStyle.Solid);
            string displayCharacter = e.Expanded ? "-" : "+";
            StringFormat outCharacterFormat = new StringFormat();
            outCharacterFormat.Alignment = StringAlignment.Center;
            outCharacterFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(displayCharacter, new Font("Tahoma", 11),
              new SolidBrush(Color.Black), e.Bounds, outCharacterFormat);
            e.Handled = true;
        }
        private string GetSelectedNode(TreeList trvTreeList)
        {
            return trvTreeList.FocusedNode[trvTreeList.Columns["SEQ_FORM"]].ToString();
        }
        private void treeList1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeListHitInfo hitInfo = treeList1.CalcHitInfo(e.Location);
            if (hitInfo.HitInfoType != HitInfoType.Button)
            {
                TreeListMultiSelection selectedNodes = treeList1.Selection;
                if (!selectedNodes[0].HasChildren)
                    if (GetSelectedNode(treeList1).Length > 3)
                    {
                        //   FRM_SMT_EMD_UNDER under = new FRM_SMT_EMD_UNDER();
                        //  under.ShowDialog();
                    }
                    else
                        //MessageBox.Show(GetSelectedNode(treeList1) + " " + _FacCode);
                        MessageBox.Show(this,"Under Contruction!","Warning!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        //ComVar.Var.callForm = GetSelectedNode(treeList1);
            }

        }
        private void treeList1_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Node.HasChildren)
                // --if (e.Node.Id % 2 == 0)
                e.Appearance.BackColor = Color.FromArgb(233, 255, 201); //Color.FromArgb(228, 250, 185);
            else
                e.Appearance.Font = new Font("Calibri", 18, FontStyle.Regular);
            // else
            //    e.Appearance.BackColor = Color.FromArgb(228, 250, 185);
        }

        private void treeList1_Load(object sender, EventArgs e)
        {
            foreach (TreeListNode node in treeList1.Nodes)
            {
                node.Expanded = false;
                // The left image displayed when the node is NOT focused.
                node.ImageIndex = 0;
                // The left image displayed when the node is focused.
                node.SelectImageIndex = 1;
                // The right image that does not depend on the focus.
                node.StateImageIndex = 2;
            }
        }

        private void treeList1_NodeCellStyle_1(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {

            if (e.Node.HasChildren)
                // --if (e.Node.Id % 2 == 0)
                e.Appearance.BackColor = Color.FromArgb(233, 255, 201); //Color.FromArgb(228, 250, 185);
            else
                e.Appearance.Font = new Font("Calibri", 18, FontStyle.Regular);
            // else
            //    e.Appearance.BackColor = Color.FromArgb(228, 250, 185);
        }

        #region Variable
        #endregion
    }
}
