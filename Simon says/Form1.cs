using howto_arc_between_segments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Get the minimum dimension of the client area
            var _nDimension = Math.Min(this.ClientRectangle.Height, this.ClientRectangle.Width);
            _nDimension = 300;
            var rotation = 360f / 4;
            
            for (int i = 0; i < 4; i++)
            {
                
                SimonSays.SimonButton btn = new SimonSays.SimonButton()
                {
                    Color = Color.DarkBlue,
                    Location = new Point(0, 0),
                    Size = new Size(_nDimension, _nDimension),
                    CenterRotation = new PointF(_nDimension / 2.0f, _nDimension / 2.0f),
                    ClickOffset = new PointF(2, 2),
                    InnerRadius = 0.55f * _nDimension/2.0f,
                    OuterRadius = 0.99f * _nDimension/2.0f,
                    AngleRotation = 45+i * rotation,
                    AngleSwept = 90,
                    Value = i
                };
                
                this.Controls.Add(btn);
            }
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TranslateTransform(ClientSize.Width / 2, ClientSize.Height / 2);

            PointF A = new PointF(0, -40);
            PointF B = new PointF(100, 40);

            e.Graphics.DrawLine(Pens.DarkBlue, A, B);
            DrawPoint(e.Graphics, Brushes.Black, A);
            DrawPoint(e.Graphics, Brushes.Black, B);

            DrawArcBetweenTwoPoints(e.Graphics, Pens.Red, A, B, 100);
            DrawArcBetweenTwoPoints(e.Graphics, Pens.Red, A, B, 100, true);
        }

        public void DrawPoint(Graphics g, Brush brush, PointF A, float size = 8f)
        {
            g.FillEllipse(brush, A.X - size / 2, A.Y - size / 2, size, size);
        }

        public void DrawArcBetweenTwoPoints(Graphics g, Pen pen, PointF a, PointF b, float radius, bool flip = false)
        {
            if (flip)
            {
                PointF temp = b;
                b = a;
                a = temp;
            }

            var to_deg = 180 / Math.PI;

            // get distance components
            double x = b.X - a.X, y = b.Y - a.Y;
            // get orientation angle
            var θ = Math.Atan2(y, x);
            // length between A and B
            var l = Math.Sqrt(x * x + y * y);
            if (2 * radius >= l)
            {
                // find the sweep angle (actually half the sweep angle)
                var φ = Math.Asin(l / (2 * radius));
                // triangle height from the chord to the center
                var h = radius * Math.Cos(φ);
                // get center point. 
                // Use sin(θ)=y/l and cos(θ)=x/l
                PointF C = new PointF(
                    (float)(a.X + x / 2 - h * (y / l)),
                    (float)(a.Y + y / 2 + h * (x / l)));

                g.DrawLine(Pens.DarkGray, C, a);
                g.DrawLine(Pens.DarkGray, C, b);
                DrawPoint(g, Brushes.Orange, C);

                // Draw arc based on square around center and start/sweep angles
                g.DrawArc(pen, C.X - radius, C.Y - radius, 2 * radius, 2 * radius,
                    (float)((θ - φ) * to_deg) - 90, (float)(2 * φ * to_deg));
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frmArc = new Form2();
            frmArc.ShowDialog();
        }
    }
}
