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
// https://stackoverflow.com/questions/32418695/windows-forms-splash-screen-show-a-form-while-loading-main-form

// https://computergraphics.stackexchange.com/questions/6028/rounding-a-corner-formed-by-arc-and-line
// https://stackoverflow.com/questions/49436868/algorithm-for-rounding-a-corner-between-line-and-arc
// https://stackoverflow.com/questions/24771828/how-to-calculate-rounded-corners-for-a-polygon
// https://www.codeproject.com/Articles/128705/WPF-rounded-corners-polygon
// https://docs.microsoft.com/en-us/windows/apps/desktop/modernize/apply-rounded-corners

namespace SimonSays
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(System.ComponentModel.Design.IDesigner))]
    public partial class SimonButton : Button
    {
        private const int MAX_BUTTONS = 10;

        #region Private variables
        private Color _color;
        private bool _clicked = false;
        private Int32 _nValue = 0;
        private PointF _clickPoint;
        private PointF _clickMidPoint;
        private PointF _clickOffset;
        private RectangleF _rectDefaultClickPoint;
        private float _fAngleSwept = 90f;
        private float _fAngleRotation = 0f;
        private float _fAngleOffsetOuter = 0f;
        private float _fAngleOffsetInner = 0f;
        private PointF _fCenterButton;          // Center for drawing the button. It's equal to CenterRotation plus an offset
        private float _fRegionOffset = 1f;
        private PointF _fCenterRotation;        // Center around which the rotation is done. Typically it's the center of the controls
        private float _fRadiusOuter = 1f;
        private float _fRadiusInner = 1f;
        
        // Sound-related properties
        private float _nFrequency = 165f;
        private Int32 _nDuration = 350;

        #endregion Private variables

        #region Public interface
        /// <summary>
        /// Color used to draw the button
        /// </summary>
        [Description("Color used to draw the button"),
        Category("Button properties"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color Color
        {
            get { return _color; }
            set { _color = value; Invalidate();
            }
        }

        /// <summary>
        /// Numeric value representing the button
        /// </summary>
        [Description("Numeric value representing the button"),
        Category("Button properties"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 Value
        {
            get { return _nValue; }
            set { _nValue = value > MAX_BUTTONS ? MAX_BUTTONS : (value < 0 ? 0 : value); }
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
                if (value == true)
                {
                    DoBeep(_nDuration);
                    CalculateMidPoint();
                    _clickPoint = _clickMidPoint;
                }
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
            set
            {
                _fAngleSwept = value;
                CalculateMidPoint();
                Invalidate(); 
            }
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
            set
            {
                _fAngleRotation = value;
                CalculateMidPoint();
                //if (this.Handle != null) BeginInvoke(new MethodInvoker(Invalidate));
                Invalidate();
            }
        }

        /// <summary>
        /// Angle in degrees to be trimmed off from the outer button arc and from both ends in order to create a space separating the buttons
        /// </summary>
        [Description("Angle in degrees to be trimmed from both ends in order to create a space separating the buttons"),
        Category("Button properties"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float AngleOffsetOuter
        {
            get { return _fAngleOffsetOuter; }
            set
            {
                _fAngleOffsetOuter = value;
                //CalculateMidPoint();
                Invalidate();
            }
        }

        /// <summary>
        /// Angle in degrees to be trimmed off from the inner button arc and from both ends in order to create a space separating the buttons
        /// </summary>
        [Description("Angle in degrees to be trimmed from both ends in order to create a space separating the buttons"),
        Category("Button properties"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float AngleOffsetInner
        {
            get { return _fAngleOffsetInner; }
            set
            {
                _fAngleOffsetInner = value;
                //CalculateMidPoint();
                Invalidate();
            }
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
            set
            {
                _fRegionOffset = value;
                Invalidate(); 
            }
        }

        /// <summary>
        /// The location of the rotation axis (typically the center of the control)
        /// </summary>
        [Description("The location of the rotation axis (typically the center of the control)"),
        Category("Button properties"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
        TypeConverter(typeof(PointFConverter))]
        public PointF CenterRotation
        {
            get { return _fCenterRotation; }
            set
            {
                _fCenterRotation = value;
                CalculateMidPoint();
                //Invalidate();
            }
        }

        /// <summary>
        /// Offset when the button is clicked
        /// </summary>
        [Description("Offset when the button is clicked"),
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

        /// <summary>
        /// The button outter radius in pixels
        /// </summary>
        [Description("The button outter radius in pixels"),
        Category("Button properties"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float OuterRadius
        {
            get { return _fRadiusOuter; }
            set
            {
                _fRadiusOuter = value < 0 ? 0 : value;
                CalculateMidPoint();
                //Invalidate(); 
            }
        }

        /// <summary>
        /// The button inner radius in pixels
        /// </summary>
        [Description("The button inner radius in pixels"),
        Category("Button properties"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float InnerRadius
        {
            get { return _fRadiusInner; }
            set
            {
                _fRadiusInner = value < 0 ? 0 : value;
                CalculateMidPoint();
                //Invalidate(); 
            }
        }

        /// <summary>
        /// Frequency (Hertz) of the beeping sound
        /// </summary>
        [Description("Frequency (Hertz) of the beeping sound"),
        Category("Button properties"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float Frequency
        {
            get { return _nFrequency; }
            set { _nFrequency = value < 0 ? Math.Abs(value) : value; }
        }

        /// <summary>
        /// Duration (miliseconds) of the beeping sound
        /// </summary>
        [Description("Duration (miliseconds) of the beeping sound"),
        Category("Button properties"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 Duration
        {
            get { return _nDuration; }
            set { _nDuration = value < 0 ? 0 : value; }
        }

        #endregion Public interface


        public SimonButton()
        {
            InitializeComponent();

            // To ensure that your control is redrawn every time it is resized
            // https://msdn.microsoft.com/en-us/library/b818z6z6(v=vs.110).aspx
            //SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.ResizeRedraw = true;
            //this.DoubleBuffered = true;

            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;

            this.AutoSize = false;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.Dock = DockStyle.None;
            
            CalculateMidPoint();
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            //base.OnMouseHover(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            DoBeep(_nDuration);
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
            //base.OnPaint(e);
            System.Diagnostics.Debug.WriteLine("SimonButton - OnPaint event. Button: " + _nValue.ToString());
            Graphics dc = e.Graphics;
            dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            float TotalRadiusOutter = _fRadiusOuter - _fRegionOffset / 2;
            float TotalRadiusInner = _fRadiusInner + _fRegionOffset / 2;
            float AngleOffsetOutter = (180 * 0.5f * _fRegionOffset / TotalRadiusOutter) / (float)Math.PI;
            float AngleOffsetInner = (180 * 0.5f * _fRegionOffset / TotalRadiusInner) / (float)Math.PI;

            //RectangleF rectOut = new RectangleF(_fRegionOffset / 2, _fRegionOffset / 2, 2 * TotalRadiusOutter, 2 * TotalRadiusOutter);
            RectangleF rectCenterButton = new RectangleF(_fCenterRotation.X, _fCenterRotation.Y, 0, 0);
            RectangleF rectOut = RectangleF.Inflate(rectCenterButton, TotalRadiusOutter, TotalRadiusOutter);
            RectangleF rectIn = RectangleF.Inflate(rectCenterButton, TotalRadiusInner, TotalRadiusInner);
            
            RectangleF rectRegionOut = RectangleF.Inflate(rectOut, _fRegionOffset / 2, _fRegionOffset / 2);    // Inflates in both + and - directions, hence _fRegionOffset / 2 for a total of _fRegionOffset
            RectangleF rectRegionIn = RectangleF.Inflate(rectIn, -_fRegionOffset / 2, -_fRegionOffset / 2);    // Inflates in both + and - directions, hence _fRegionOffset / 2 for a total of _fRegionOffset

            GraphicsPath path = new GraphicsPath();
            path.AddArc(rectOut, AngleOffsetOutter + _fAngleOffsetOuter, _fAngleSwept - 2 * AngleOffsetOutter - 2 * _fAngleOffsetOuter);
            path.AddArc(rectIn, _fAngleSwept - AngleOffsetInner - _fAngleOffsetInner, -_fAngleSwept + 2 * AngleOffsetInner + 2 * _fAngleOffsetInner);
            path.CloseFigure();
            
            GraphicsPath pathRegion = new GraphicsPath();
            pathRegion.AddArc(rectRegionOut, 0 + _fAngleOffsetOuter, _fAngleSwept - 2 * _fAngleOffsetOuter);
            pathRegion.AddArc(rectRegionIn, _fAngleSwept - _fAngleOffsetInner, -_fAngleSwept + 2 * _fAngleOffsetInner);
            pathRegion.CloseFigure();

            Matrix matrix = new Matrix();
            if (_clicked == true) matrix.Translate(_clickOffset.X, _clickOffset.Y);
            if (_fAngleRotation > 0 && _fAngleRotation <= 720) matrix.RotateAt(_fAngleRotation, _fCenterRotation, MatrixOrder.Append);  // Maximum rotation angle is 2*360

            path.Transform(matrix);
            pathRegion.Transform(matrix);
            dc.FillPath(new SolidBrush(_color), path);

            _clickMidPoint = new PointF(
                (float)(Math.Cos((_fAngleRotation / 2) * Math.PI / 180) * (_fRadiusOuter - _fRadiusInner) / 2) + _fCenterRotation.X,
                (float)(Math.Sin((_fAngleRotation / 2) * Math.PI / 180) * (_fRadiusOuter - _fRadiusInner) / 2) + _fCenterRotation.Y
                );

            if (_clicked == true)
            {
                Matrix scale = new Matrix();
                scale.Scale(0.99f, 0.99f);

                GraphicsPath pathClicked = (GraphicsPath)path.Clone();
                pathClicked.Transform(scale);

                using (PathGradientBrush pthGrBrush = new PathGradientBrush(path)
                {
                    SurroundColors = new Color[] { _color },
                    CenterColor = Color.FromArgb(220, 255, 255, 255),
                    FocusScales = new PointF(0.1f, 0.1f),
                    CenterPoint = _clickPoint
                })
                    dc.FillPath(pthGrBrush, pathClicked);
                
                
                using (Pen pen = new Pen(Color.FromArgb(255, _color), 2))
                {
                    pen.Alignment = PenAlignment.Inset;
                    //dc.DrawPath(pen, path);
                }
            }
            else
            {
                dc.FillPath(new SolidBrush(_color), path);
            }

            this.Region = new Region(pathRegion);

        }

        /// <summary>
        /// Force the drawing of the control. This is only called when Invalidate won't raise the OnPaint event due to the control region being outside the ClientRectangle
        /// </summary>
        public void RePaint()
        {
            using (var g = this.CreateGraphics())
            {
                System.Windows.Forms.PaintEventArgs e = new System.Windows.Forms.PaintEventArgs(g, this.ClientRectangle);
                OnPaint(e);
            }
            

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

        private void DoBeep(int nDuration)
        {
            /*
            E-note (blue, lower right); 329.6 Hz
            C♯-note (yellow, lower left); 277.2 Hz
            A-note (red, upper right); 220 Hz
            E-note (green, upper left, an octave lower than blue); 164.8 Hz
             */
            //http://social.msdn.microsoft.com/Forums/vstudio/en-US/18fe83f0-5658-4bcf-bafc-2e02e187eb80/beep-beep?forum=csharpgeneral          
            //Task.Run(() => Console.Beep(_nFrequency, nDuration));

            WaveGenerator sound = new WaveGenerator(_nFrequency, nDuration, WaveType.SineWave, 32767, 30);
            sound.PlaySound();

        }

        /// <summary>
        /// Calculates the mid point of the button. This is used to simulate the click at the button's center
        /// </summary>
        private void CalculateMidPoint()
        {
            double midAngle = ((_fAngleSwept / 2) + _fAngleRotation) * Math.PI / 180.0f;
            float midLength = _fRadiusInner + ((_fRadiusOuter - _fRadiusInner) / 2.0f);
            
            _clickMidPoint = new PointF(
                (float)(Math.Cos(midAngle) * midLength) + _fCenterRotation.X,
                (float)(Math.Sin(midAngle) * midLength) + _fCenterRotation.Y
                );
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
