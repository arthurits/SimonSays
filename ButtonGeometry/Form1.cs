namespace ButtonGeometry;

public partial class Form1 : Form
{
    private readonly List<PointF> points = new() { new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new() };
    private readonly List<RectangleF> rects = new() { new(), new(), new(), new() };
    private readonly List<float> angles = new() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public Form1()
    {
        InitializeComponent();

        SetControlsProperties();

        updOuterRadius.Value = 200;
        updInnerRadius.Value = 60;
        updCorner.Value = 10;
        updButtons.Value = 4;
        updSeparation.Value = 10;
    }

    private void SetControlsProperties()
    {
        this.updOuterRadius.Maximum = pctDraw.Width / 2;
        this.trackOuterRadius.Maximum = (int)this.updOuterRadius.Maximum;
        this.trackOuterRadius.TickFrequency = this.trackOuterRadius.Maximum / 10;
        
        this.updCorner.Maximum = pctDraw.Width / 2;
        this.trackCorner.Maximum = (int)this.updCorner.Maximum;
        this.trackCorner.TickFrequency = this.trackCorner.Maximum / 10;

        this.updButtons.Maximum = 20;
        this.trackButtons.Maximum = 20;
    }

    private bool ComputePoints()
    {
        if (updOuterRadius.Value == 0 || updButtons.Value == 0 || updInnerRadius.Value == 0) return false;

        double Ro = (double)updOuterRadius.Value;
        double Ri = (double)updInnerRadius.Value;
        double Rc = (double)updCorner.Value;
        float Sep = (float)updSeparation.Value;

        double minusRo = (Sep / 2) / Math.Sin((Math.PI / 180) * angles[0] / 2);
        Ro -= minusRo;
        
        angles[0] = 360f / (int)updButtons.Value;

        // Compute the outer points
        points[0] = new(this.pctDraw.Width / 2, this.pctDraw.Height / 2);
        points[1] = new(points[0].X + (float)((Sep / 2) / Math.Tan((Math.PI / 180) * angles[0] / 2)), points[0].Y + Sep / 2);
        points[2] = new(points[1].X + (float)Ro, points[1].Y);
        points[3] = RotatePoint(points[1], points[2], angles[0]);

        // Compute the inner points
        points[4] = new(points[1].X + (float)(Rc / Math.Tan((Math.PI / 180) * angles[0] / 2)), points[1].Y + (float)Rc);
        points[5] = new(points[1].X + (float)Math.Sqrt(Math.Pow(Ro - Rc, 2) - Math.Pow(Rc, 2)), points[4].Y);
        points[6] = RotatePoint(points[4], points[5], angles[0]);

        // Compute the line points
        //points[7] = new(points[4].X, points[1].Y);
        points[8] = new(points[5].X, points[1].Y);
        //points[9] = RotatePoint(points[1], points[7], angles[0]);
        points[10] = RotatePoint(points[1], points[8], angles[0]);

        // Compute the points for the inner radius
        points[11] = new(points[1].X + (float)Math.Sqrt(Math.Pow(Ri + Rc, 2) - Math.Pow(Rc, 2)), points[4].Y);
        points[12] = RotatePoint(points[4], points[11], angles[0]);

        // Compute new line points
        points[13] = new(points[11].X, points[1].Y);
        points[14] = RotatePoint(points[1], points[13], angles[0]);

        // Compute the angles for the drawing of corners
        angles[1] = -90;
        angles[2] = - (180 - angles[0]);

        // Outer corners
        angles[3] = angles[1];
        angles[4] = (float)((180 / Math.PI) * Math.Atan(Rc / (points[5].X - points[1].X))) - angles[3];

        angles[5] = (float)((180 / Math.PI) * Math.Atan2((points[6].Y - points[1].Y), (points[6].X - points[1].X)));
        angles[6] = angles[4];

        // Inner corners
        angles[7] = (float)((180 / Math.PI) * Math.Asin(Rc / (Ri + Rc)));
        angles[8] = angles[0] - 2 * (float)((180 / Math.PI) * Math.Asin(Rc / (Ri + Rc)));

        angles[9] = (float)((180 / Math.PI) * Math.Atan2((points[12].Y - points[1].Y), (points[12].X - points[1].X))) - 180f;
        angles[10] = -(float)((180 / Math.PI) * Math.Acos(Rc / (Ri + Rc)));

        return true;
    }

    private void ComputeRects()
    {
        float Ro = (float)updOuterRadius.Value;
        float Rc = (float)updCorner.Value;
        float Ri = (float)updInnerRadius.Value;
        float smallR = points[5].X - points[4].X;
        float Sep = (float)updSeparation.Value;

        rects[0] = new(points[0].X, points[0].Y, Ro, Ro);
        Ro -= (float)((Sep / 2) / Math.Sin((Math.PI / 180) * angles[0] / 2));

        rects[1] = new(points[1].X - Ro, points[1].Y - Ro, 2 * Ro, 2 * Ro);
        //rects[1] = new(points[4].X - smallR, points[4].Y - smallR, 2 * smallR, 2 * smallR);
        rects[2] = new(points[4].X - Rc, points[4].Y - Rc, 2 * Rc, 2 * Rc);
        rects[3] = new(points[1].X - Ri, points[1].Y - Ri, 2 * Ri, 2 * Ri);
    }

    private void DrawCurves(int total, List<float> angles, List<PointF> points, List<RectangleF> rects, bool drawPoints = true, bool drawRectangles = true, bool drawCircles = true)
    {
        using Pen penBlack = new(Color.Black);
        using Pen penGray = new(Color.Gray);

        Bitmap canvas = new(this.pctDraw.Width, this.pctDraw.Height);
        using Graphics gfx= Graphics.FromImage(canvas);
        gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        if (drawPoints)
            DrawPoints(points.Where((x, i) => i != 7 && i != 9).ToList(), gfx);

        if (drawRectangles)
        {
            gfx.DrawRectangle(penGray, points[0].X, points[0].Y, rects[0].Width, rects[0].Height);
            gfx.DrawRectangle(penGray, points[1].X, points[1].Y, rects[1].Width / 2, rects[1].Height / 2);
        }

        if (drawCircles)
        {
            DrawCircles(points.Where((x, i) => i == 5 || i == 6 || i == 11 || i == 12).ToList(), gfx, (float)updCorner.Value);
            DrawCircles(points.Where((x, i) => i == 1).ToList(), gfx, (float)updInnerRadius.Value);
            DrawCircles(points.Where((x, i) => i == 1).ToList(), gfx, rects[1].Width/2);
        }

        using Bitmap curve = new(this.pctDraw.Width, this.pctDraw.Height);
        using Graphics g = Graphics.FromImage(curve);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        g.DrawLine(penBlack, points[13], points[8]);
        g.DrawLine(penBlack, points[14], points[10]);
        g.DrawArc(penBlack, rects[1], angles[4] + angles[3], angles[5] - angles[4] - angles[3]);
        g.DrawArc(penBlack, rects[3], angles[7], angles[8]);

        // Draw corners
        if (rects[2].Width > 0 && rects[2].Height > 0)
        {
            //g.DrawArc(penBlack, rects[2], angles[1], angles[2]);

            RectangleF rectCorner = rects[2];
            rectCorner.X = points[5].X - (float)updCorner.Value;
            g.DrawArc(penBlack, rectCorner, angles[3], angles[4]);

            rectCorner.X = points[6].X - (float)updCorner.Value;
            rectCorner.Y = points[6].Y - (float)updCorner.Value;
            g.DrawArc(penBlack, rectCorner, angles[5], angles[6]);

            rectCorner.X = points[11].X - (float)updCorner.Value;
            rectCorner.Y = points[11].Y - (float)updCorner.Value;
            g.DrawArc(penBlack, rectCorner, angles[3], angles[10]);

            rectCorner.X = points[12].X - (float)updCorner.Value;
            rectCorner.Y = points[12].Y - (float)updCorner.Value;
            g.DrawArc(penBlack, rectCorner, angles[9], angles[10]);
        }

        for (int i = 0; i < total; i++)
        {
            RotateImage(gfx, (float)this.pctDraw.Width / 2, (float)this.pctDraw.Height / 2, angles[0]);
            gfx.DrawImage(curve, new Point(0, 0));
        }

        // 
        var oldBmp = this.pctDraw.Image;
        oldBmp?.Dispose();
        this.pctDraw.Image = canvas;
        //this.pctDraw.Image = RotateImage(canvas, 30);
    }

    private void DrawButton(List<float> angles, List<PointF> points, List<RectangleF> rects)
    {
        using Pen penBlack = new(Color.Black);
        using Pen penGray = new(Color.Gray);

        Bitmap canvas = new(this.pctDraw.Width, this.pctDraw.Height);
        using Graphics gfx = Graphics.FromImage(canvas);

        gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        gfx.DrawLine(penBlack, points[7], points[8]);
        gfx.DrawLine(penBlack, points[9], points[10]);
        gfx.DrawArc(penBlack, rects[1], angles[4] + angles[3], angles[5] - angles[4] - angles[3]);

        if (rects[2].Width > 0 && rects[2].Height > 0)
        {
            gfx.DrawArc(penBlack, rects[2], angles[1], angles[2]);

            RectangleF rectCorner = rects[2];
            rectCorner.X = points[5].X - (float)updCorner.Value;
            gfx.DrawArc(penBlack, rectCorner, angles[3], angles[4]);

            rectCorner.X = points[6].X - (float)updCorner.Value;
            rectCorner.Y = points[6].Y - (float)updCorner.Value;
            gfx.DrawArc(penBlack, rectCorner, angles[5], angles[6]);
        }

        this.pctDraw.Image = canvas;
        //this.pctDraw.Image = RotateImage(canvas, 30);
    }

    private void DrawPoints(List<PointF> points, Graphics gfx, float radius = 2f)
    {
        foreach (PointF point in points)
            gfx.FillEllipse(new SolidBrush(Color.Red), point.X - radius, point.Y - radius, 2 * radius, 2 * radius);
    }

    private void DrawCircles(List<PointF> points, Graphics gfx, float radius, Color? color = null)
    {
        if (radius == 0) return;
        color ??= Color.Blue;
        foreach (PointF point in points)
            gfx.DrawArc(new((Color)color), point.X - radius, point.Y - radius, 2 * radius, 2 * radius, 0, 360);
    }

        /// <summary>
        /// Rotates the specified point around another center.
        /// </summary>
        /// <param name="center">Center point to rotate around.</param>
        /// <param name="pt">Point to rotate.</param>
        /// <param name="degrees">Rotation degree. A value between 1 to 360.</param>
        private static PointF RotatePoint(PointF center, PointF pt, double degrees)
    {
        double x1, x2, y1, y2;
        x1 = center.X;
        y1 = center.Y;
        x2 = pt.X;
        y2 = pt.Y;
        double distance = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        degrees *= Math.PI / 180;
        float x3, y3;
        x3 = (float)(distance * Math.Cos(degrees) + x1);
        y3 = (float)(distance * Math.Sin(degrees) + y1);
        
        return new PointF(x3, y3);
    }

    public static Bitmap RotateImage(Bitmap b, float angle)
    {
        //create a new empty bitmap to hold rotated image
        Bitmap returnBitmap = new(b.Width, b.Height);
        //make a graphics object from the empty bitmap
        using (Graphics g = Graphics.FromImage(returnBitmap))
        {
            //move rotation point to center of image
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            //rotate
            g.RotateTransform(angle);
            //move image back
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            //draw passed in image onto graphics object
            g.DrawImage(b, new Point(0, 0));
        }
        return returnBitmap;
    }

    public static void RotateImage(Graphics g, float centerX, float centerY, float angle)
    {
        //move rotation point to center of image
        g.TranslateTransform(centerX, centerY);
        //rotate
        g.RotateTransform(angle);
        //move image back
        g.TranslateTransform(-centerX, -centerY);

        return;
    }

    private void UpdButtons_ValueChanged(object sender, EventArgs e)
    {
        if (ComputePoints())
        {
            ComputeRects();
            DrawCurves((int)updButtons.Value, angles, points, rects, chkPoints.Checked, chkRectangles.Checked, chkCircles.Checked);
        }

        int ratio = Convert.ToInt32(updButtons.Value);
        if (trackButtons.Value != ratio) trackButtons.Value = ratio;
    }

    private void TrackButtons_ValueChanged(object sender, EventArgs e)
    {
        decimal ratio = (decimal)trackButtons.Value;
        if (updButtons.Value != ratio) updButtons.Value = ratio;
    }

    private void UpdCorner_ValueChanged(object sender, EventArgs e)
    {
        int ratio = Convert.ToInt32(updCorner.Value);
        if (trackCorner.Value != ratio) trackCorner.Value = ratio;

        if (ComputePoints())
        {
            ComputeRects();
            DrawCurves((int)updButtons.Value, angles, points, rects, chkPoints.Checked, chkRectangles.Checked, chkCircles.Checked);
        }
    }

    private void TrackCorner_ValueChanged(object sender, EventArgs e)
    {
        decimal ratio = (decimal)trackCorner.Value;
        if (updCorner.Value != ratio) updCorner.Value = ratio;
    }

    private void UpdOuterRadius_ValueChanged(object sender, EventArgs e)
    {
        int ratio = Convert.ToInt32(updOuterRadius.Value);
        if (trackOuterRadius.Value != ratio) trackOuterRadius.Value = ratio;

        if (ComputePoints())
        {
            ComputeRects();
            DrawCurves((int)updButtons.Value, angles, points, rects, chkPoints.Checked, chkRectangles.Checked, chkCircles.Checked);
        }
    }

    private void TrackOuterRadius_ValueChanged(object sender, EventArgs e)
    {
        decimal ratio = (decimal)trackOuterRadius.Value;
        if (updOuterRadius.Value != ratio) updOuterRadius.Value = ratio;
    }

    private void UpdInnerRadius_ValueChanged(object sender, EventArgs e)
    {
        int ratio = Convert.ToInt32(updInnerRadius.Value);
        if (trackInnerRadius.Value != ratio) trackInnerRadius.Value = ratio;

        if (ComputePoints())
        {
            ComputeRects();
            DrawCurves((int)updButtons.Value, angles, points, rects, chkPoints.Checked, chkRectangles.Checked, chkCircles.Checked);
        }
    }

    private void TrackInnerRadius_ValueChanged(object sender, EventArgs e)
    {
        decimal ratio = (decimal)trackInnerRadius.Value;
        if (updInnerRadius.Value != ratio) updInnerRadius.Value = ratio;
    }

    private void UpdSeparation_ValueChanged(object sender, EventArgs e)
    {
        int ratio = Convert.ToInt32(updSeparation.Value);
        if (trackSeparation.Value != ratio) trackSeparation.Value = ratio;

        if (ComputePoints())
        {
            ComputeRects();
            DrawCurves((int)updButtons.Value, angles, points, rects, chkPoints.Checked, chkRectangles.Checked, chkCircles.Checked);
        }
    }

    private void TrackSeparation_ValueChanged(object sender, EventArgs e)
    {
        decimal ratio = (decimal)trackSeparation.Value;
        if (updSeparation.Value != ratio) updSeparation.Value = ratio;
    }

    private void Show_CheckedChanged(object sender, EventArgs e)
    {
        DrawCurves((int)updButtons.Value, angles, points, rects, chkPoints.Checked, chkRectangles.Checked, chkCircles.Checked);
    }
}