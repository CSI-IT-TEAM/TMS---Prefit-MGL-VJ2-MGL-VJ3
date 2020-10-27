using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace FORM
{
    public partial class GradientLabel : Label {

    protected override void OnPaint(PaintEventArgs e) {
        Font font = new Font("Calibri", 15, FontStyle.Bold);
        LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height + 5), Color.BlueViolet, Color.Yellow, LinearGradientMode.Horizontal);
        e.Graphics.DrawString(Text, font, brush, 0, 0);
    }

    }
}
