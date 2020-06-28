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
                
                SimonSays.SimonButton2 btn = new SimonSays.SimonButton2()
                {
                    Color = Color.DarkBlue,
                    Location = new Point(0, 0),
                    Size = new Size(_nDimension, _nDimension),
                    CenterRotation = new PointF(_nDimension / 2.0f, _nDimension / 2.0f),
                    CenterButton = new PointF(_nDimension / 2.0f, _nDimension / 2.0f),
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
    }
}
