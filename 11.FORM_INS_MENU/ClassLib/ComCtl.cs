using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Media;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace FORM.ClassLib
{
	/// <summary>
	/// ComCtl에 대한 요약 설명입니다.
	/// </summary>
    /// 



    public class Class_Sound
    {

        private byte[] m_soundBytes;
        private string m_fileName;

        private enum Flags
        {
            SND_SYNC = 0x0000,     /* play synchronously (default) */
            SND_ASYNC = 0x0001,     /* play asynchronously */
            SND_NODEFAULT = 0x0002,     /* silence (!default) if sound not found */
            SND_MEMORY = 0x0004,     /* pszSound points to a memory file */
            SND_LOOP = 0x0008,     /* loop the sound until next sndPlaySound */
            SND_NOSTOP = 0x0010,     /* don't stop any currently playing sound */
            SND_NOWAIT = 0x00002000, /* don't wait if the driver is busy */
            SND_ALIAS = 0x00010000, /* name is a registry alias */
            SND_ALIAS_ID = 0x00110000, /* alias is a predefined ID */
            SND_FILENAME = 0x00020000, /* name is file name */
            SND_RESOURCE = 0x00040004  /* name is resource name or atom */
        }



        /// <summary>
        /// Construct the Sound object to play sound data from the specified file.
        /// </summary>


       


        public Class_Sound(string fileName)
        {
            //
            // TODO: 여기에 생성자 논리를 추가합니다.
            //

            m_fileName = fileName;
        }

        public Class_Sound(Stream stream)
        {
            //
            // TODO: 여기에 생성자 논리를 추가합니다.
            //

            // read the data from the stream
            m_soundBytes = new byte[stream.Length];
            stream.Read(m_soundBytes, 0, (int)stream.Length);
        }

        /// <summary>
        /// Play the sound
        /// </summary>


        private void playSimpleSound()
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@m_fileName);
                simpleSound.Play();
            }
            catch (Exception)
            {
                
               
            }
           
        }


        /// <summary>
        /// Play Several sound
        /// </summary>
        public void PlaySeveral(int arg_count, int arg_interval)
        {

            for (int i = 0; i < arg_count; i++)
            {
                this.playSimpleSound();
                System.Threading.Thread.Sleep(arg_interval);
            }
        }
    }

	public class ComCtl 
	{
		public ComCtl()
		{
			//
			// TODO: 여기에 생성자 논리를 추가합니다.
			//
		}
        public static void Form_Maximized(Form frm, int monitor)
        {
            int i = 0;
            foreach (Screen s in Screen.AllScreens)
            {
                if (i == monitor)
                {
                    frm.Location = s.Bounds.Location;
                    frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    break;
                }
                i++;
            }
            if (monitor == 0)
            {
                frm.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
                
            }
            frm.WindowState = FormWindowState.Maximized;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
	}
    //public class TransparentPanel : Panel
    //{
    //    protected override CreateParams CreateParams
    //    {
    //        get
    //        {
    //            CreateParams cp = base.CreateParams;
    //            cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
    //            return cp;
    //        }
    //    }
    //    protected override void OnPaintBackground(PaintEventArgs e)
    //    {
    //        //base.OnPaintBackground(e);
    //    }
    //}
    public enum Orientation
    {
        Circle,
        Arc,
        Rotate
    }

    public enum Direction
    {
        Clockwise,
        AntiClockwise
    }



    public class OrientedTextLabel : System.Windows.Forms.Label
    {

        #region Variables

        private double rotationAngle;
        private string text;
        private Orientation textOrientation;
        private Direction textDirection;

        #endregion

        #region Constructor

        public OrientedTextLabel()
        {
            //Setting the initial condition.
            rotationAngle = 0d;
            textOrientation = Orientation.Rotate;
            this.Size = new Size(105, 12);
        }

        #endregion

        #region Properties

        [Description("Rotation Angle"), Category("Appearance")]
        public double RotationAngle
        {
            get
            {
                return rotationAngle;
            }
            set
            {

                rotationAngle = value;
                this.Invalidate();
            }
        }

        [Description("Kind of Text Orientation"), Category("Appearance")]
        public Orientation TextOrientation
        {
            get
            {
                return textOrientation;
            }
            set
            {

                textOrientation = value;
                this.Invalidate();
            }
        }

        [Description("Direction of the Text"), Category("Appearance")]
        public Direction TextDirection
        {
            get
            {
                return textDirection;
            }
            set
            {

                textDirection = value;
                this.Invalidate();
            }
        }

        [Description("Display Text"), Category("Appearance")]
        public override string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                this.Invalidate();
            }
        }

        #endregion

        #region Method

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.Trimming = StringTrimming.None;

            Brush textBrush = new SolidBrush(this.ForeColor);

            //Getting the width and height of the text, which we are going to write
            float width = graphics.MeasureString(text, this.Font).Width;
            float height = graphics.MeasureString(text, this.Font).Height;

            //The radius is set to 0.9 of the width or height, b'cos not to 
            //hide and part of the text at any stage
            float radius = 0f;
            if (ClientRectangle.Width < ClientRectangle.Height)
            {
                radius = ClientRectangle.Width * 0.9f / 2;
            }
            else
            {
                radius = ClientRectangle.Height * 0.9f / 2;
            }

            //Setting the text according to the selection
            switch (textOrientation)
            {
                case Orientation.Arc:
                    {
                        //Arc angle must be get from the length of the text.
                        float arcAngle = (2 * width / radius) / text.Length;
                        if (textDirection == Direction.Clockwise)
                        {
                            for (int i = 0; i < text.Length; i++)
                            {

                                graphics.TranslateTransform(
                                    (float)(radius * (1 - Math.Cos(arcAngle * i + rotationAngle / 180 * Math.PI))),
                                    (float)(radius * (1 - Math.Sin(arcAngle * i + rotationAngle / 180 * Math.PI))));
                                graphics.RotateTransform((-90 + (float)rotationAngle + 180 * arcAngle * i / (float)Math.PI));
                                graphics.DrawString(text[i].ToString(), this.Font, textBrush, 0, 0);
                                graphics.ResetTransform();
                            }
                        }
                        else
                        {
                            for (int i = 0; i < text.Length; i++)
                            {

                                graphics.TranslateTransform(
                                    (float)(radius * (1 - Math.Cos(arcAngle * i + rotationAngle / 180 * Math.PI))),
                                    (float)(radius * (1 + Math.Sin(arcAngle * i + rotationAngle / 180 * Math.PI))));
                                graphics.RotateTransform((-90 - (float)rotationAngle - 180 * arcAngle * i / (float)Math.PI));
                                graphics.DrawString(text[i].ToString(), this.Font, textBrush, 0, 0);
                                graphics.ResetTransform();

                            }
                        }
                        break;
                    }
                case Orientation.Circle:
                    {
                        if (textDirection == Direction.Clockwise)
                        {
                            for (int i = 0; i < text.Length; i++)
                            {
                                graphics.TranslateTransform(
                                    (float)(radius * (1 - Math.Cos((2 * Math.PI / text.Length) * i + rotationAngle / 180 * Math.PI))),
                                    (float)(radius * (1 - Math.Sin((2 * Math.PI / text.Length) * i + rotationAngle / 180 * Math.PI))));
                                graphics.RotateTransform(-90 + (float)rotationAngle + (360 / text.Length) * i);
                                graphics.DrawString(text[i].ToString(), this.Font, textBrush, 0, 0);
                                graphics.ResetTransform();
                            }
                        }
                        else
                        {
                            for (int i = 0; i < text.Length; i++)
                            {
                                graphics.TranslateTransform(
                                    (float)(radius * (1 - Math.Cos((2 * Math.PI / text.Length) * i + rotationAngle / 180 * Math.PI))),
                                    (float)(radius * (1 + Math.Sin((2 * Math.PI / text.Length) * i + rotationAngle / 180 * Math.PI))));
                                graphics.RotateTransform(-90 - (float)rotationAngle - (360 / text.Length) * i);
                                graphics.DrawString(text[i].ToString(), this.Font, textBrush, 0, 0);
                                graphics.ResetTransform();
                            }

                        }
                        break;
                    }
                case Orientation.Rotate:
                    {
                        //For rotation, who about rotation?
                        double angle = (rotationAngle / 180) * Math.PI;
                        graphics.TranslateTransform(
                            (ClientRectangle.Width + (float)(height * Math.Sin(angle)) - (float)(width * Math.Cos(angle))) / 2,
                            (ClientRectangle.Height - (float)(height * Math.Cos(angle)) - (float)(width * Math.Sin(angle))) / 2);
                        graphics.RotateTransform((float)rotationAngle);
                        graphics.DrawString(text, this.Font, textBrush, 0, 0);
                        graphics.ResetTransform();

                        break;
                    }
            }
        }
        #endregion

    }

    public class CustomGrpBox : GroupBox
    {
        private string _Text = "";
        public CustomGrpBox()
        {
            //set the base text to empty 
            //base class will draw empty string
            //in such way we see only text what we draw
            base.Text = "";
        }
        //create a new property a
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue("GroupBoxText")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new string Text
        {
            get
            {

                return _Text;
            }
            set
            {

                _Text = value;
                this.Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            //first let the base class to draw the control 
            base.OnPaint(e);
            //create a brush with fore color
            SolidBrush colorBrush = new SolidBrush(this.ForeColor);
            //create a brush with back color
            var backColor = new SolidBrush(this.BackColor);
            //measure the text size
            var size = TextRenderer.MeasureText(this.Text, this.Font);
            // evaluate the postiong of text from left;
            int left = (this.Width - size.Width) / 2;
            //draw a fill rectangle in order to remove the border
            e.Graphics.FillRectangle(backColor, new Rectangle(left, 0, size.Width, size.Height));
            //draw the text Now
            e.Graphics.DrawString(this.Text, this.Font, colorBrush, new PointF(left, 0));

        }
    }


    public class GroupBoxEx : GroupBox
    {
        //Create the property backing fields 
        private SolidBrush _BackColorBrush;
        private SolidBrush _PanelBrush;
        private PanelType _PanelShape = PanelType.Rounded;
        private Pen _BorderPen;
        private bool _DrawBorder = true;
        private SolidBrush _TextBrush;
        private SolidBrush _TextBackBrush;
        private Pen _TextBorderPen;
        private Image _BackgroundPanelImage;

        private float _BorderPenWith = 1;
        private float _TextBorderPenWith = 1;

        //Create an Enum used for the PanelShape property 
        public enum PanelType : int
        {
            Squared = 0,
            Rounded = 1
        }

        //Set the Styles, pens, brushes, and properties used for the defaults when a new instance is created 
        public GroupBoxEx()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.Size = new Size(180, 100);
            _BackColorBrush = new SolidBrush(Color.Transparent);
            _BorderPen = new Pen(Color.Black, _BorderPenWith);
            _PanelBrush = new SolidBrush(base.BackColor);
            _TextBrush = new SolidBrush(base.ForeColor);
            _TextBackBrush = new SolidBrush(Color.White);
            _TextBorderPen = new Pen(Color.Black, _TextBorderPenWith);
            base.BackColor = Color.Transparent;
        }

        //Create the properties for the control 

        [Category("Appearance"), Description("Gets or sets the Background image.")]
        [Browsable(true)]
        public Image BackgroundPanelImage
        {
            get { return _BackgroundPanelImage; }
            set
            {
                _BackgroundPanelImage = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Gets or sets the color of the text.")]
        [Browsable(true)]
        public override System.Drawing.Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                _TextBrush.Color = value;
            }
        }

        [Category("Appearance"), Description("Gets or sets the Background color.")]
        [Browsable(true)]
        public Color GroupPanelColor
        {
            get { return _PanelBrush.Color; }
            set
            {
                _PanelBrush.Color = value;
                this.Refresh();
            }
        }


        /*******/

        [Category("Appearance"), Description("Gets or sets the Group Panel Line With.")]
        [Browsable(true)]
        public float GroupPanelWith
        {
            get { return _BorderPen.Width; }
            set
            {
                _BorderPen.Width = value;
                //_BorderPenWith = value;
                this.Refresh();
            }
        }


        /****/

        [Category("Appearance"), Description("Gets or sets the shape of the control.")]
        [Browsable(true)]
        public PanelType GroupPanelShape
        {
            get { return _PanelShape; }
            set
            {
                _PanelShape = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Gets or sets if a border is drawn around the control.")]
        [Browsable(true)]
        public bool DrawGroupBorder
        {
            get { return _DrawBorder; }
            set
            {
                _DrawBorder = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Gets or sets the color of the border.")]
        [Browsable(true)]
        public Color GroupBorderColor
        {
            get { return _BorderPen.Color; }
            set
            {
                _BorderPen.Color = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Gets or sets the Background color of the text.")]
        [Browsable(true)]
        public Color TextBackColor
        {
            get { return _TextBackBrush.Color; }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _TextBackBrush.Color;
                    throw new Exception("Color Transparent is not supported");
                }
                _TextBackBrush.Color = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Gets or sets the color of the border around the text.")]
        [Browsable(true)]
        public Color TextBorderColor
        {
            get { return _TextBorderPen.Color; }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _TextBorderPen.Color;
                    throw new Exception("Color Transparent is not supported");
                }
                _TextBorderPen.Color = value;
                this.Refresh();
            }
        }

        /*************/

        [Category("Appearance"), Description("Gets or sets the Text Border With.")]
        [Browsable(true)]
        public float TextBorderWith
        {
            get { return _TextBorderPen.Width; }
            set
            {
                _TextBorderPen.Width = value;
                //_BorderPenWith = value;
                this.Refresh();
            }
        }


        /*************/

        //Used to paint the control according to how the properties are set 
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            var _with1 = e.Graphics;
            _with1.FillRectangle(_BackColorBrush, 0, 0, this.Width, this.Height);
            _with1.SmoothingMode = SmoothingMode.AntiAlias;
            int tw = Convert.ToInt32(_with1.MeasureString(this.Text, this.Font).Width);
            int th = Convert.ToInt32(_with1.MeasureString(this.Text, this.Font).Height);
            Rectangle rec = new Rectangle(0, Convert.ToInt32(th / 2), this.Width - 1, this.Height - 1 - Convert.ToInt32(th / 2));
            using (GraphicsPath gp = new GraphicsPath())
            {
                if (this.GroupPanelShape == PanelType.Rounded)
                {
                    int rad = 14;
                    gp.AddArc(rec.Right - (rad), rec.Y, rad, rad, 270, 90);
                    gp.AddArc(rec.Right - (rad), rec.Bottom - (rad), rad, rad, 0, 90);
                    gp.AddArc(rec.X, rec.Bottom - (rad), rad, rad, 90, 90);
                    gp.AddArc(rec.X, rec.Y, rad, rad, 180, 90);
                    gp.CloseFigure();
                }
                else
                {
                    gp.AddRectangle(rec);
                }

                _with1.FillPath(_PanelBrush, gp);
                if (this.BackgroundPanelImage != null)
                {
                    DrawBackImage(e.Graphics, gp, Convert.ToInt32(th / 2));
                }
                if (this.DrawGroupBorder)
                    _with1.DrawPath(_BorderPen, gp);
            }
            if (tw > 0 & th > 0)
            {
                Rectangle trec = new Rectangle(7, 0, this.Width - 15, th + 2);
                using (GraphicsPath gp = new GraphicsPath())
                {
                    int rad = 6;
                    gp.AddArc(trec.Right - (rad), trec.Y, rad, rad, 270, 90);
                    gp.AddArc(trec.Right - (rad), trec.Bottom - (rad), rad, rad, 0, 90);
                    gp.AddArc(trec.X, trec.Bottom - (rad), rad, rad, 90, 90);
                    gp.AddArc(trec.X, trec.Y, rad, rad, 180, 90);
                    gp.CloseFigure();
                    _with1.FillPath(_TextBackBrush, gp);
                    _with1.DrawPath(_TextBorderPen, gp);
                }
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap })
                {
                    _with1.DrawString(this.Text, this.Font, _TextBrush, trec, sf);
                }
            }
        }

        //A private sub used to position, resize, and draw the BackgroundImage according to the BackgroundImageLayout 
        private void DrawBackImage(Graphics g, GraphicsPath grxpath, int topoffset)
        {
            using (Bitmap bm = new Bitmap(this.Width, this.Height - topoffset))
            {
                using (Graphics grx = Graphics.FromImage(bm))
                {
                    if (this.BackgroundImageLayout == ImageLayout.None)
                    {
                        grx.DrawImage(this.BackgroundPanelImage, 0, 0, this.BackgroundPanelImage.Width, this.BackgroundPanelImage.Height);
                    }
                    else if (this.BackgroundImageLayout == ImageLayout.Tile)
                    {
                        int tc = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(bm.Width / this.BackgroundPanelImage.Width)));
                        int tr = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(bm.Height / this.BackgroundPanelImage.Height)));
                        for (int y = 0; y <= tr; y++)
                        {
                            for (int x = 0; x <= tc; x++)
                            {
                                grx.DrawImage(this.BackgroundPanelImage, (x * this.BackgroundPanelImage.Width), (y * this.BackgroundPanelImage.Height), this.BackgroundPanelImage.Width, this.BackgroundPanelImage.Height);
                            }
                        }
                    }
                    else if (this.BackgroundImageLayout == ImageLayout.Center)
                    {
                        int xx = Convert.ToInt32((this.Width / 2) - (this.BackgroundPanelImage.Width / 2));
                        int yy = Convert.ToInt32(((this.Height - topoffset) / 2) - (this.BackgroundPanelImage.Height / 2));
                        grx.DrawImage(this.BackgroundPanelImage, xx, yy, this.BackgroundPanelImage.Width, this.BackgroundPanelImage.Height);
                    }
                    else if (this.BackgroundImageLayout == ImageLayout.Stretch)
                    {
                        grx.DrawImage(this.BackgroundPanelImage, 0, 0, this.Width, this.Height - topoffset);
                    }
                    else if (this.BackgroundImageLayout == ImageLayout.Zoom)
                    {
                        double meratio = this.Width / (this.Height - topoffset);
                        double imgratio = this.BackgroundPanelImage.Width / this.BackgroundPanelImage.Height;
                        Rectangle imgrect = new Rectangle(0, 0, this.Width, this.Height - topoffset);
                        if (imgratio > meratio)
                        {
                            imgrect.Width = this.Width;
                            imgrect.Height = Convert.ToInt32(this.Width / imgratio);
                        }
                        else if (imgratio < meratio)
                        {
                            imgrect.Height = this.Height - topoffset;
                            imgrect.Width = Convert.ToInt32((this.Height - topoffset) * imgratio);
                        }
                        imgrect.X = Convert.ToInt32((this.Width / 2) - (imgrect.Width / 2));
                        imgrect.Y = Convert.ToInt32(((this.Height - topoffset) / 2) - (imgrect.Height / 2));
                        grx.DrawImage(this.BackgroundPanelImage, imgrect);
                    }
                }
                using (TextureBrush tb = new TextureBrush(bm))
                {
                    if (this.BackgroundImageLayout != ImageLayout.Tile)
                        tb.WrapMode = WrapMode.Clamp;
                    tb.TranslateTransform(0, topoffset);
                    g.FillPath(tb, grxpath);
                }
            }
        }

        //Used to force the control to repaint itself when the text is changed 
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            this.Refresh();
        }

        //Override the BackColor property and hide it from the user 
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.Obsolete("The BackColor property is not implemented.", true)]
        public new System.Drawing.Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                throw new Exception("The BackColor property is not implemented.");
            }
        }

        //Override the BackgroundImage property and hide it from the user 
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.Obsolete("The BackgroundImage property is not implemented.", true)]
        public new Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set
            {
                throw new Exception("The BackgroundImage property is not implemented.");
            }
        }

        //Dispose of all brushes and pens used for the property backing fields 
        protected override void Dispose(bool disposing)
        {
            _BackColorBrush.Dispose();
            _BorderPen.Dispose();
            _PanelBrush.Dispose();
            _TextBrush.Dispose();
            _TextBackBrush.Dispose();
            _TextBorderPen.Dispose();
            base.Dispose(disposing);
        }
    }

    public interface ILoadForm
    {
        void ReLoadData(DataTable[] dtSource);
        void ShowForm();

        string[] GetResourceIds();
    }
}
