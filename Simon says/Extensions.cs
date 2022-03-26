namespace howto_arc_between_segments;

public static class Extensions
{
    // Return the distance between two points.
    public static float Distance(this PointF p1, PointF p2)
    {
        float dx = p1.X - p2.X;
        float dy = p1.Y - p2.Y;
        return (float)Math.Sqrt(dx * dx + dy * dy);
    }

    // Fill a RectangleF.
    public static void FillRectangle(this Graphics gr,
        Brush brush, RectangleF rect)
    {
        gr.FillRectangle(brush, rect.X, rect.Y,
            rect.Width, rect.Height);
    }

    // Draw a RectangleF.
    public static void DrawRectangle(this Graphics gr,
        Pen pen, RectangleF rect)
    {
        gr.DrawRectangle(pen, rect.X, rect.Y,
            rect.Width, rect.Height);
    }

    // Fill a circle at a PointF.
    public static void FillPoint(this Graphics gr,
        Brush brush, PointF point, float radius)
    {
        gr.FillEllipse(brush,
            point.X - radius,
            point.Y - radius,
            2 * radius, 2 * radius);
    }

    // Draw a circle at a PointF.
    public static void DrawPoint(this Graphics gr,
        Pen pen, PointF point, float radius)
    {
        gr.DrawEllipse(pen,
            point.X - radius,
            point.Y - radius,
            2 * radius, 2 * radius);
    }
}
