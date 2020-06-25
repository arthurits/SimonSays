using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

// https://stackoverflow.com/questions/58803957/creating-an-arc-between-two-points-with-arc-radius-and-rotation
// http://csharphelper.com/blog/2019/10/connect-two-line-segments-with-a-circular-arc-in-c/

namespace SimonSays
{
    public partial class SimonButton2 : Button
    {
        #region Private variables
        
        private bool _clicked = false;
        private Int32 _nColor = 0;
        private Point _clickPoint;
        private PointF _clickOffset;
        private RectangleF _rectDefaultClickPoint;
        private float _fAngleSwept = 90f;
        private float _fAngleRotation = 90f;
        private PointF _fCenterButton;
        private float _fRegionOffset = 1f;
        private PointF _fCenterRotation;
        private float _fRadiusOutter;
        private float _fRadiusInner;

        #endregion Private variables

        #region Public interface
        /// <summary>
        /// Numeric value representing the color
        /// </summary>
        [Description("Numeric value representing the color"),
        Category("Button properties"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 ColorValue
        {
            get { return _nColor; }
            set { _nColor = value > 3 ? 3 : (value < 0 ? 0 : value); }
        }

        /// <summary>
        /// State of the button
        /// </summary>
        [Description("State of the button"),
        Category("Button properties"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Clicked
        {
            get { return _clicked; }
            set
            {
                _clicked = value;
                //if (value == true) DoBeep(_nDuration);
                Invalidate();
            }
        }

        /// <summary>
        /// Angle swept in degrees
        /// </summary>
        [Description("Angle swept in degrees"),
        Category("Button properties"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float AngleSwept
        {
            get { return _fAngleSwept; }
            set { _fAngleSwept = value; Invalidate(); }
        }

        /// <summary>
        /// Rotation angle in degrees
        /// </summary>
        [Description("Rotation angle in degrees"),
        Category("Button properties"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float AngleRotation
        {
            get { return _fAngleRotation; }
            set { _fAngleRotation = value; Invalidate(); }
        }

        /// <summary>
        /// Region offset in pixels of the control to allocate the antialias rendering (typically 1 px)
        /// </summary>
        [Description("Region offset in pixels of the control to allocate the antialias rendering (typically 1 px)"),
        Category("Button properties"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float RegionOffset
        {
            get { return _fRegionOffset; }
            set { _fRegionOffset = value; Invalidate(); }
        }

        /// <summary>
        /// The center (axis) location of all the buttons
        /// </summary>
        [Description("The center (axis) location of all the buttons"),
        Category("Button properties"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
        TypeConverter(typeof(PointFConverter))]
        public PointF CenterButton
        {
            get { return _fCenterButton; }
            set { _fCenterButton = value; Invalidate(); }
        }

        /// <summary>
        /// The location of the rotation axis
        /// </summary>
        [Description("The location of the rotation axis"),
        Category("Button properties"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
        TypeConverter(typeof(PointFConverter))]
        public PointF CenterRotation
        {
            get { return _fCenterRotation; }
            set { _fCenterRotation = value; Invalidate(); }
        }

        /// <summary>
        /// The location of the rotation axis
        /// </summary>
        [Description("The location of the rotation axis"),
        Category("Button properties"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
        TypeConverter(typeof(PointFConverter))]
        public PointF ClickOffset
        {
            get { return _clickOffset; }
            set { _clickOffset = value; }
        }

        #endregion Public interface

        public SimonButton2()
        {
            InitializeComponent();

            // To ensure that your control is redrawn every time it is resized
            // https://msdn.microsoft.com/en-us/library/b818z6z6(v=vs.110).aspx
            SetStyle(ControlStyles.ResizeRedraw, true);

            this.DoubleBuffered = true;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        protected override void OnMouseHover(EventArgs e)
        {
            //base.OnMouseHover(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            //DoBeep(350);
            _clicked = true;
            _clickPoint = e.Location;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _clicked = false;
            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (_clicked == true) _clicked = false;
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Overrides the paint event. Comprises 3 parts: the fill, the border, and the definition of the control's region
        /// </summary>
        /// <param name="e">Paint event argument</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            Graphics dc = e.Graphics;
            dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            _fRadiusOutter = this.ClientRectangle.Width/2;
            _fRadiusInner = 0.65f*_fRadiusOutter;
            //_fAngleSwept = 36;
            _fCenterRotation = new PointF(this.ClientRectangle.Width / 2, this.ClientRectangle.Height / 2);
            //_rectDefaultClickPoint;

            float TotalRadiusOutter = _fRadiusOutter - _fRegionOffset / 2;
            float TotalRadiusInner = _fRadiusInner + _fRegionOffset / 2;
            float AngleOffsetOutter = (180 * 0.5f * _fRegionOffset / TotalRadiusOutter) / (float)Math.PI;
            float AngleOffsetInner = (180 * 0.5f * _fRegionOffset / TotalRadiusInner) / (float)Math.PI;
            
            RectangleF rectOut = new RectangleF(_fRegionOffset / 2, _fRegionOffset / 2, 2 * TotalRadiusOutter, 2 * TotalRadiusOutter);
            //RectangleF rectIn = new RectangleF(_fRegionOffset / 2, _fRegionOffset / 2, 2 * _fRadiusInner + _fRegionOffset, 2 * _fRadiusInner + _fRegionOffset);
            //RectangleF rectIn = RectangleF.Inflate(rectOut, -(_fRadiusOutter - _fRadiusInner) + _fRegionOffset, -(_fRadiusOutter - _fRadiusInner) + _fRegionOffset);                // Mantains the rectangle's geometric center.
            RectangleF rectIn = RectangleF.Inflate(rectOut, -(TotalRadiusOutter - TotalRadiusInner), -(TotalRadiusOutter - TotalRadiusInner));                // Mantains the rectangle's geometric center.
            //RectangleF rectRegion = RectangleF.Inflate(rectOut, 0.5f, 0.5f);
            RectangleF rectRegionOut = RectangleF.Inflate(rectOut, _fRegionOffset / 2, _fRegionOffset / 2);    // Inflates in both + and - directions, hence _fRegionOffset / 2 for a total of _fRegionOffset
            RectangleF rectRegionIn = RectangleF.Inflate(rectIn, -_fRegionOffset / 2, -_fRegionOffset / 2);    // Inflates in both + and - directions, hence _fRegionOffset / 2 for a total of _fRegionOffset

            GraphicsPath path = new GraphicsPath();
            path.AddArc(rectOut, AngleOffsetOutter, _fAngleSwept - 2 * AngleOffsetOutter);
            path.AddArc(rectIn, _fAngleSwept - AngleOffsetInner, -_fAngleSwept + 2 * AngleOffsetInner);
            path.CloseFigure();

            /*
            GraphicsPath pathRegion = new GraphicsPath();
            pathRegion.AddArc(rectRegionOut, 0 - AngleOffsetOutter, _fAngleSwept + 2 * AngleOffsetOutter);
            pathRegion.AddArc(rectRegionIn, _fAngleSwept + AngleOffsetOutter, -_fAngleSwept - 2 * AngleOffsetOutter);
            pathRegion.CloseFigure();
            */

            GraphicsPath pathRegion = new GraphicsPath();
            pathRegion.AddArc(rectRegionOut, 0, _fAngleSwept);
            pathRegion.AddArc(rectRegionIn, _fAngleSwept, -_fAngleSwept);
            pathRegion.CloseFigure();

            if (_fAngleRotation > 0 && _fAngleRotation < 360)
            {
                Matrix matrix = new Matrix();
                matrix.RotateAt(_fAngleRotation, _fCenterRotation);

                path.Transform(matrix);
                pathRegion.Transform(matrix);
            }

            dc.FillPath(new SolidBrush(Color.DarkRed), path);
            this.Region = new Region(pathRegion);

            if (_clicked == true)
            {
                PathGradientBrush pthGrBrush = new PathGradientBrush(path)
                {
                    SurroundColors = new Color[] { Color.DarkRed },
                    CenterColor = Color.FromArgb(220, 255, 255, 255),
                    //pthGrBrush.FocusScales = new PointF(0.4f, 0.4f);
                    CenterPoint = _clickPoint
                };

                dc.FillPath(pthGrBrush, path);
                //g.FillRectangle(pthGrBrush, new Rectangle(0, 0, nSideLength, nSideLength));
                pthGrBrush.Dispose();
            }

                /*
                if (_showBorder)
                {
                    path.AddPath(MakeRoundedRect(rectIn, _xRadius - _fBorderWidth, _yRadius - _fBorderWidth), false);
                    dc.FillPath(new SolidBrush(_cBorderColor), path);
                }

                //this.Region = new Region(MakeRoundedRect(rectRegion, _xRadius + 0.5f, _yRadius + 0.5f));
                this.Region = new Region(MakeRoundedRect(rectRegion, _xRadius + _fRegionOffset / 2, _yRadius + _fRegionOffset / 2));

                // Draw text
                if (_showText) DrawText(dc);
                */

                //base.OnPaint(e);
            }

        protected virtual void DrawText(Graphics g)
        {
            if (Text == string.Empty) return;

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // The upper left corner coordinates and the size of the rectangle where the text will be drawn
            var point = PointF.Empty;
            SizeF size = this.Size;

            //point.X += Font.Size * _fTextLeftPaddingPercentage + _fRegionOffset + _fBorderWidth;
            //point.Y += Font.Size * _fTextTopPaddingPercentage + _fRegionOffset + _fBorderWidth;
            //size.Width -= 2 * (_fRegionOffset + _fBorderWidth);
            //size.Height -= 2 * (_fRegionOffset + _fBorderWidth);

            // Compute the dimensions based on the text size
            var stringFormat =
                new StringFormat(RightToLeft == RightToLeft.Yes ? StringFormatFlags.DirectionRightToLeft : 0)
                {
                    Alignment = StringAlignment.Near,     // Horizontal alignment
                    LineAlignment = StringAlignment.Near  // Vertical alignment
                };
            var textSize = g.MeasureString(Text, Font);
            var textPoint = new PointF(
                point.X + (size.Width - textSize.Width) / 2,
                point.Y + (size.Height - textSize.Height) / 2);

            // Draw the text
            g.DrawString(
                Text,
                Font,
                new SolidBrush(ForeColor),
                new RectangleF(textPoint, textSize),
                stringFormat);
            //g.DrawRectangle(new Pen(Color.Red, 3), textPoint.X, textPoint.Y, textSize.Width, textSize.Height);
        }


    }

    public class PointFConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return ((sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType));
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return ((destinationType == typeof(System.ComponentModel.Design.Serialization.InstanceDescriptor)) || base.CanConvertTo(context, destinationType));
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            string str = value as string;
            if (value == null) return base.ConvertFrom(context, culture, value);
            str = str.Trim();
            if (str.Length == 0) return null;
            if (culture == null) culture = System.Globalization.CultureInfo.CurrentCulture;
            char ch = culture.TextInfo.ListSeparator[0];
            string[] strArray = str.Split(new char[] { ch });
            float[] numArray = new float[strArray.Length];
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(float));
            for (int i = 0; i < numArray.Length; i++)
            {
                numArray[i] = (float)converter.ConvertFromString(context, culture, strArray[i]);
            }
            if (numArray.Length != 2) throw new ArgumentException("Invalid format");
            return new PointF(numArray[0], numArray[1]);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null) throw new ArgumentNullException("destinationType");
            if (value is PointF)
            {
                if (destinationType == typeof(string))
                {
                    PointF point = (PointF)value;
                    if (culture == null) culture = System.Globalization.CultureInfo.CurrentCulture;
                    string separator = culture.TextInfo.ListSeparator + " ";
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(float));
                    string[] strArray = new string[2];
                    int num = 0;
                    strArray[num++] = converter.ConvertToString(context, culture, point.X);
                    strArray[num++] = converter.ConvertToString(context, culture, point.Y);
                    return string.Join(separator, strArray);
                }
                if (destinationType == typeof(System.ComponentModel.Design.Serialization.InstanceDescriptor))
                {
                    PointF point2 = (PointF)value;
                    System.Reflection.ConstructorInfo constructor = typeof(PointF).GetConstructor(new Type[] { typeof(float), typeof(float) });
                    if (constructor != null) return new System.ComponentModel.Design.Serialization.InstanceDescriptor(constructor, new object[] { point2.X, point2.Y });
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object CreateInstance(ITypeDescriptorContext context, System.Collections.IDictionary propertyValues)
        {
            if (propertyValues == null) throw new ArgumentNullException("propertyValues");
            object xvalue = propertyValues["X"];
            object yvalue = propertyValues["Y"];
            if (((xvalue == null) || (yvalue == null)) || (!(xvalue is float) || !(yvalue is float)))
            {
                throw new ArgumentException("Invalid property value entry");
            }
            return new PointF((float)xvalue, (float)yvalue);
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(PointF), attributes).Sort(new string[] { "X", "Y" });
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
