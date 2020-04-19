using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

//https://xamlbrewer.wordpress.com/2016/01/23/building-a-custom-uwp-control-with-xaml-and-the-composition-api/
//https://xamlbrewer.wordpress.com/2016/01/04/using-the-composition-api-in-uwp-apps/

namespace SimonSays
{
    public partial class frmSimon : Form
    {
        [DllImport("user32.dll")]
        static extern bool AnimateWindow(IntPtr hWnd, int time, AnimateWindowFlags flags);
        [Flags]
        private enum AnimateWindowFlags
        {
            AW_HOR_POSITIVE = 0x00000001,
            AW_HOR_NEGATIVE = 0x00000002,
            AW_VER_POSITIVE = 0x00000004,
            AW_VER_NEGATIVE = 0x00000008,
            AW_CENTER = 0x00000010,
            AW_HIDE = 0x00010000,
            AW_ACTIVATE = 0x00020000,
            AW_SLIDE = 0x00040000,
            AW_BLEND = 0x00080000
        }
        private SimonGame _Game;

        public frmSimon()
        {
            InitializeComponent();
            
            // Set form icon
            var path = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            if (System.IO.File.Exists(path + @"\images\simon.ico")) this.Icon = new Icon(path + @"\images\simon.ico");

            _Game = new SimonGame();
            _Game.Tick += new EventHandler<TickEventArgs>(OnGameTick);
            _Game.GameOver += new EventHandler<OverEventArgs>(OnGameOver);
            _Game.CorrectSequence += new EventHandler<CorrectEventArgs>(OnCorrectSequence);
            this.simonBoard.ButtonClick += new EventHandler<CustomBoard.ButtonClickEventArgs>(OnButtonClick);
            this.DoubleBuffered = true;
            //this.customBoard1.Size = new Size(300, 300);
            //this.customBoard1.Invalidate();

            //WaveGenerator sound = new WaveGenerator(440f, 200, WaveType.SineWave, 32767, 30);
            //sound.Save(@"C:\Users\Arthurit\Desktop\sine.wav");
            //sound.PlaySound();
            //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\Arthurit\Desktop\sine.wav");
            //player.Play();
        }


        /// <summary>
        /// Consumes the Tick event of the Game class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGameTick(object sender, TickEventArgs e)
        {
            foreach (ColorButton.SimonButton button in simonBoard.Controls.OfType<ColorButton.SimonButton>())
            {
                if (button.ColorValue == e.ButtonValue)
                    button.Clicked = e.Flash;
            }

            /*
            switch (e.ButtonValue)
            {
                case 0:
                    //btnGreen.Clicked = e.Flash;
                    this.simonBoard.GreenButton.Clicked = e.Flash;
                    break;
                case 1:
                    //btnRed.Clicked = e.Flash;
                    this.simonBoard.RedButton.Clicked = e.Flash;
                    break;
                case 2:
                    //btnBlue.Clicked = e.Flash;
                    this.simonBoard.BlueButton.Clicked = e.Flash;
                    break;
                case 3:
                    //btnYellow.Clicked = e.Flash;
                    this.simonBoard.YellowButton.Clicked = e.Flash;
                    break;
                default:
                    break;
            }*/
        }

        private void OnCorrectSequence(object sender, CorrectEventArgs e)
        {
            //MessageBox.Show("Well done!\nTotal score: " + e.Score.ToString());
            this.simonBoard.ScoreTotal = _Game.ScoreTotal;
            this.simonBoard.ScoreHighest = _Game.ScoreHighest;
            foreach (ColorButton.SimonButton button in simonBoard.Controls.OfType<ColorButton.SimonButton>())
            {
                button.Duration = _Game.DurationFlash;
            }
        }

        private void OnGameOver(object sender, OverEventArgs e)
        {
            MessageBox.Show("Game over.\nTotal score: " + e.Score.ToString());
            this.simonBoard.ScoreTotal = 0;
        }
        
        /*protected override void OnPaint(PaintEventArgs e)
        {
            
            Rectangle rc = e.ClipRectangle;
            Graphics dc = e.Graphics;
            dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Define and calculate size variables
            Int32 nHeight = rc.Bottom - rc.Top - 50;
            Int32 nWidth = rc.Width - 50;
            Int32 nRadius = Math.Min(rc.Width, rc.Height);
            float factorBoard = (float)0.9;
            float factorCenter = (float)0.35;
            Brush solidBrush = new SolidBrush(Color.FromArgb(100, 100, 240));

            // Draw back clip rectangle
            dc.FillRectangle(solidBrush, rc);

            // Draw board elements
            solidBrush = new SolidBrush(Color.FromArgb(40, 40, 40));
            dc.FillEllipse(
                solidBrush,
                (float)((rc.Width - factorBoard * nRadius) / 2),
                (float)((rc.Height - factorBoard * nRadius) / 2),
                (float)(factorBoard * nRadius),
                (float)(factorBoard * nRadius)
                );

                        // Create a path that consists of a single ellipse.
                        //GraphicsPath path = new GraphicsPath();
                        //path.AddEllipse(0, 0, 140, 70);

                        // Use the path to construct a brush.
                        //PathGradientBrush pthGrBrush = new PathGradientBrush(path);

                        // Set the color at the center of the path to blue.
                        //pthGrBrush.CenterColor = Color.FromArgb(255, 0, 0, 255);

                        // Set the color along the entire boundary  
                        // of the path to aqua.
                        //Color[] colors = { Color.FromArgb(255, 0, 255, 255) };
                        //pthGrBrush.SurroundColors = colors;

                        //e.Graphics.FillEllipse(pthGrBrush, 0, 0, 140, 70);


            solidBrush = new SolidBrush(Color.FromArgb(240, 240, 240));
            dc.FillEllipse(
                solidBrush,
                (float)((rc.Width - factorCenter * nRadius) / 2),
                (float)((rc.Height - factorCenter * nRadius) / 2),
                (float)(factorCenter * nRadius),
                (float)(factorCenter * nRadius)
                );

            Pen BluePen = new Pen(Color.Blue, 3);
            dc.DrawRectangle(BluePen, nWidth / 2, nHeight / 2, 50, 50);
            Pen RedPen = new Pen(Color.Red, 2);
            dc.DrawEllipse(RedPen, nWidth / 2, nHeight / 2, 80, 60);

            // Dispose
            solidBrush.Dispose();
            BluePen.Dispose();
            RedPen.Dispose();
            
            // Call the OnPaint method of the base class
            base.OnPaint(e);
        }*/

        private void frmSimon_Resize(object sender, EventArgs e)
        {
            // Force the client area to be painted again
            Invalidate();
            this.btnGreen.Top = 0;
            this.btnGreen.Left = 0;
            this.btnGreen.Height = 400;
            this.btnGreen.Width = 400;
        }

        private void frmSimon_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_BLEND);
        }

        private void frmSimon_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _Game.Start();
        }
        private void btnSimon_Click(object sender, EventArgs e)
        {
            _Game.OnPress(((ColorButton.SimonButton)sender).ColorValue);
        }
        private void OnButtonClick(object sender, CustomBoard.ButtonClickEventArgs e)
        {
            _Game.OnPress(e.ButtonValue);
        }

    }
}
