using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraNavBar;
using System.Data.OracleClient;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.Skins;

namespace FORM.UC
{
    public partial class NavBarTree : UserControl
    {
        public NavBarTree()
        {
            InitializeComponent();
        }
        public NavBarTree(string Title)
        {
            InitializeComponent();

        }
        #region Variable
        public delegate void ButtonMenuHandler(string TitleCode, string MenuCode);
        public ButtonMenuHandler OnMenuClick = null;
        DataTable table;
        #endregion
        #region Event
        private void navBarControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NavBarControl navBar = sender as NavBarControl;
                NavBarHitInfo hitInfo = navBar.CalcHitInfo(new Point(e.X, e.Y));
                if (hitInfo.InGroupCaption && !hitInfo.InGroupButton)
                    hitInfo.Group.Expanded = !hitInfo.Group.Expanded;
            }

        }
        #endregion
        #region Ora

        #endregion
        private void nvItem_LinkPressed(object sender, NavBarLinkEventArgs e)
        {
            if (OnMenuClick != null)
                OnMenuClick("F", ((DevExpress.XtraNavBar.NavBarItem)sender).Tag.ToString());
        }
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

        private void nvbMenu_Click(object sender, EventArgs e)
        {

        }

        private void treeList1_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            e.NodeImageIndex = e.Node.Id;
            //if (e.Node.Id <= 1 || e.Node.Id ==3)
            //    e.Node.Expanded = true;
        }

        private void treeList1_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            //if (Convert.ToBoolean(e.Node.GetValue("Mark")))
            //    e.NodeImageIndex = 0;
            //else
            //    e.NodeImageIndex = -1;
        }

        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void treeList1_Click(object sender, EventArgs e)
        {

        }
        private string GetSelectedNode(TreeList trvTreeList)
        {
            return trvTreeList.FocusedNode[trvTreeList.Columns["SEQ_FORM"]].ToString();
        }
        private void treeList1_MouseClick(object sender, MouseEventArgs e)
        {

            // MessageBox.Show(selectedNodes[0].GetValue(treeList1.Columns[1]).ToString());
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
                        FRM_SMT_EMD_UNDER under = new FRM_SMT_EMD_UNDER();
                        under.ShowDialog();
                    }
                    else
                        ComVar.Var.callForm = GetSelectedNode(treeList1);
            }

        }

        private void treeList1_CustomDrawNodeButton(object sender, CustomDrawNodeButtonEventArgs e)
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

        private void treeList1_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Node.HasChildren)
                // --if (e.Node.Id % 2 == 0)
                e.Appearance.BackColor = Color.FromArgb(233, 255, 201); //Color.FromArgb(228, 250, 185);
            else
                e.Appearance.Font = new Font("Calibri", 18, FontStyle.Regular);
            // else
            //    e.Appearance.BackColor = Color.FromArgb(228, 250, 185);
        }
    }
}
