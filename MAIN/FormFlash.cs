using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MAIN
{
    public partial class FormFlash : Form
    {
        public FormFlash()
        {
            InitializeComponent();
        }

        private void FormFlash_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
        }


        
    }
}
