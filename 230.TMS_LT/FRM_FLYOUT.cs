using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM
{
    public partial class FRM_FLYOUT : Form
    {
        public FRM_FLYOUT()
        {
            InitializeComponent();
          
        }
    
        public void ShowBeakForm()
        {
            flyoutPanel1.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Left;
            Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X + 40, Cursor.Position.Y);
            flyoutPanel1.ShowBeakForm(Cursor.Position);
            Cursor.Position = new Point(Cursor.Position.X - 40, Cursor.Position.Y);

        }
    }
}
