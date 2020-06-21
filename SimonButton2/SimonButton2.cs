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

        private float _fAngle = 90f;
        private PointF _fCenterButton;
        private float _fRegionOffset = 1f;
        private PointF _fCenterRotation;
        private float _fRadiusOutter;
        private float _fRadiusInner;

        #endregion Private variables

        #region Public interface
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
            get { return _fAngle; }
            set { _fAngle = value; Invalidate(); }
        }

        /// <summary>
        /// Region offset of the control (typically 1 px)
        /// </summary>
        [Description("Region offset of the control (typically 1 px)"),
        Category("Button properties"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float RegionOffset
        {
            get { return _fRegionOffset; }
            set { _fRegionOffset = value; Invalidate(); }
        }
        #endregion Public interface

        public SimonButton2()
        {
            InitializeComponent();

            // To ensure that your control is redrawn every time it is resized
            // https://msdn.microsoft.com/en-us/library/b818z6z6(v=vs.110).aspx
            SetStyle(ControlStyles.ResizeRedraw, true);

            this.DoubleBuffered = true;
            this.FlatAppearance.MouseOverBackColor = Color.AliceBlue;
            this.FlatAppearance.MouseDownBackColor = Color.DarkSeaGreen;
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
            //_fAngle = 36;

            RectangleF rectOut = new RectangleF(_fRegionOffset / 2, _fRegionOffset / 2, 2*_fRadiusOutter - _fRegionOffset, 2*_fRadiusOutter - _fRegionOffset);
            RectangleF rectIn = RectangleF.Inflate(rectOut, -(_fRadiusOutter - _fRadiusInner), -(_fRadiusOutter - _fRadiusInner));                // Mantains the rectangle's geometric center.
            //RectangleF rectRegion = RectangleF.Inflate(rectOut, 0.5f, 0.5f);
            RectangleF rectRegionOut = RectangleF.Inflate(rectOut, _fRegionOffset / 2, _fRegionOffset / 2);    // Inflates in both + and - directions, hence _fRegionOffset / 2 for a total of _fRegionOffset
            RectangleF rectRegionIn = RectangleF.Inflate(rectIn, -_fRegionOffset / 2, -_fRegionOffset / 2);    // Inflates in both + and - directions, hence _fRegionOffset / 2 for a total of _fRegionOffset

            GraphicsPath path = new GraphicsPath();
            path.AddArc(rectOut, 0, _fAngle);
            path.AddArc(rectIn, _fAngle, -_fAngle);
            path.CloseFigure();

            GraphicsPath pathRegion = new GraphicsPath();
            pathRegion.AddArc(rectRegionOut, 0, _fAngle);
            pathRegion.AddArc(rectRegionIn, _fAngle, -_fAngle);
            pathRegion.CloseFigure();

            dc.FillPath(new SolidBrush(Color.DarkRed), path);
            this.Region = new Region(pathRegion);

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

        /// <summary>
        /// Draw a rectangle in the indicated Rectangle (the container box) rounding the indicated corners.
        /// http://csharphelper.com/blog/2016/01/draw-rounded-rectangles-in-c/
        /// </summary>
        /// <param name="rect">Rectangle structure to be rounded</param>
        /// <param name="xradius">Horizonal radius in pixels</param>
        /// <param name="yradius">Vertical radius in pixels</param>
        /// <param name="round_ul">True (default value) if upper left corner is to be rounded</param>
        /// <param name="round_ur">True (default value) if upper right corner is to be rounded</param>
        /// <param name="round_lr">True (default value) if lower right corner is to be rounded</param>
        /// <param name="round_ll">True (default value) if lower left corner is to be rounded</param>
        /// <returns>The graphic path defining the rounded rectangle</returns>
        private GraphicsPath MakeRoundedRect(RectangleF rect, float xradius, float yradius, bool round_ul = true, bool round_ur = true, bool round_lr = true, bool round_ll = true)
        {
            // Make a GraphicsPath to draw the rectangle.
            PointF point1, point2;
            GraphicsPath path = new GraphicsPath();

            // Upper left corner.
            if (round_ul)
            {
                if (xradius > 0 && yradius > 0)
                {
                    RectangleF corner = new RectangleF(
                        rect.X, rect.Y,
                        2 * xradius, 2 * yradius);
                    path.AddArc(corner, 180, 90);
                }
                point1 = new PointF(rect.X + xradius, rect.Y);
            }
            else point1 = new PointF(rect.X, rect.Y);

            // Top side.
            if (round_ur)
                point2 = new PointF(rect.Right - xradius, rect.Y);
            else
                point2 = new PointF(rect.Right, rect.Y);
            path.AddLine(point1, point2);

            // Upper right corner.
            if (round_ur)
            {
                if (xradius > 0 && yradius > 0)
                {
                    RectangleF corner = new RectangleF(
                        rect.Right - 2 * xradius, rect.Y,
                        2 * xradius, 2 * yradius);
                    path.AddArc(corner, 270, 90);
                }
                point1 = new PointF(rect.Right, rect.Y + yradius);
            }
            else point1 = new PointF(rect.Right, rect.Y);

            // Right side.
            if (round_lr)
                point2 = new PointF(rect.Right, rect.Bottom - yradius);
            else
                point2 = new PointF(rect.Right, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower right corner.
            if (round_lr)
            {
                if (xradius > 0 && yradius > 0)
                {
                    RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius,
                    rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                    path.AddArc(corner, 0, 90);
                }
                point1 = new PointF(rect.Right - xradius, rect.Bottom);
            }
            else point1 = new PointF(rect.Right, rect.Bottom);

            // Bottom side.
            if (round_ll)
                point2 = new PointF(rect.X + xradius, rect.Bottom);
            else
                point2 = new PointF(rect.X, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower left corner.
            if (round_ll)
            {
                if (xradius > 0 && yradius > 0)
                {
                    RectangleF corner = new RectangleF(
                    rect.X, rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                    path.AddArc(corner, 90, 90);
                }
                point1 = new PointF(rect.X, rect.Bottom - yradius);
            }
            else point1 = new PointF(rect.X, rect.Bottom);

            // Left side.
            if (round_ul)
                point2 = new PointF(rect.X, rect.Y + yradius);
            else
                point2 = new PointF(rect.X, rect.Y);
            path.AddLine(point1, point2);

            // Join with the start point.
            path.CloseFigure();

            return path;
        }

    }
}
