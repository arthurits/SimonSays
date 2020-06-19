﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
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

        private string _path;
        // Program settings
        private ProgramSettings<string, string> _programSettings;
        private ProgramSettings<string, string> _defaultSettings;
        private static readonly string _programSettingsFileName = @"Configuration.xml";

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
            // Set form icon
            _path = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            if (System.IO.File.Exists(_path + @"\images\simon.ico")) this.Icon = new Icon(_path + @"\images\simon.ico");

            // Initialization routines
            InitializeComponent();
            InitializeToolStripPanel();
            InitializeToolStrip();
            //InitializeMenuStrip();
            //InitializeStatusStrip();

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

            // Read the program settings file
            LoadProgramSettings(ref _programSettings);

            // Load defalut settings
            _defaultSettings = new ProgramSettings<string, string>();
            LoadDefaultSettings(_defaultSettings);

            // Apply settings
            if (_programSettings == null) _programSettings = _defaultSettings;
            ApplySettings(_programSettings, _defaultSettings, true);
        }


        #region Initialization routines

        /// <summary>
        /// Initialize the ToolStripPanel component: add the child components to it
        /// </summary>
        private void InitializeToolStripPanel()
        {
            //tspTop = new ToolStripPanel();
            //tspBottom = new ToolStripPanel();
            tspTop.Join(this.toolStripMain);
            //tspTop.Join(mnuMainFrm);
            tspBottom.Join(this.statusStrip);

            // Exit the method
            return;
        }

        /// <summary>
        /// Initialize the ToolStrip component
        /// </summary>
        private void InitializeToolStrip()
        {

            //ToolStripNumericUpDown c = new ToolStripNumericUpDown();
            //this.toolStripMain.Items.Add((ToolStripItem)c);

            toolStripMain.Renderer = new customRenderer(Brushes.SteelBlue, Brushes.LightSkyBlue);

            if (File.Exists(_path + @"\images\exit.ico")) this.toolStripMain_Exit.Image = new Icon(_path + @"\images\exit.ico", 48, 48).ToBitmap();
            if (File.Exists(_path + @"\images\start.ico")) this.toolStripMain_Start.Image = new Icon(_path + @"\images\start.ico", 48, 48).ToBitmap();
            if (File.Exists(_path + @"\images\stop.ico")) this.toolStripMain_Stop.Image = new Icon(_path + @"\images\stop.ico", 48, 48).ToBitmap();
            if (File.Exists(_path + @"\images\soundoff.ico")) this.toolStripMain_Sound.Image = new Icon(_path + @"\images\soundoff.ico", 48, 48).ToBitmap();
            if (File.Exists(_path + @"\images\graph.ico")) this.toolStripMain_Stats.Image = new Icon(_path + @"\images\graph.ico", 48, 48).ToBitmap();
            if (File.Exists(_path + @"\images\settings.ico")) this.toolStripMain_Settings.Image = new Icon(_path + @"\images\settings.ico", 48, 48).ToBitmap();
            if (File.Exists(_path + @"\images\about.ico")) this.toolStripMain_About.Image = new Icon(_path + @"\images\about.ico", 48, 48).ToBitmap();

            /*
            using (Graphics g = Graphics.FromImage(this.toolStripMain_Skeleton.Image))
            {
                g.Clear(Color.PowderBlue);
            }
            */

            // Exit the method
            return;
        }

        /// <summary>
        /// Initialize the MenuStrip component
        /// </summary>
        private void InitializeMenuStrip()
        {
            return;
        }

        /// <summary>
        /// Initialize the StatusStrip component
        /// </summary>
        private void InitializeStatusStrip()
        {
            return;
        }
        #endregion Initialization routines

        #region Events subscription
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

        #endregion Events subscription

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

        #region Form events

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

        #endregion Form events


        #region toolStripMain
        #endregion toolStripMain

        #region Application settings

        /// <summary>
        /// Loads any saved program settings.
        /// </summary>
        private void LoadProgramSettings(ref ProgramSettings<string, string> settings)
        {
            // Load the saved window settings and resize the window.
            TextReader textReader = StreamReader.Null;
            try
            {
                textReader = new StreamReader(_programSettingsFileName);
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ProgramSettings<string, string>));
                settings = (ProgramSettings<string, string>)serializer.Deserialize(textReader);
                textReader.Close();
            }
            catch (Exception ex)
            {

                if (!(ex is FileNotFoundException))
                {
                    using (new CenterWinDialog(this))
                    {
                        MessageBox.Show(this,
                                        "Unexpected error while\nloading settings data.",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
                //LoadDefaultSettings();
            }
            finally
            {
                if (textReader != null) textReader.Close();
            }
        }

        /// <summary>
        /// Saves the current program settings.
        /// </summary>
        private void SaveProgramSettings(ProgramSettings<string, string> settings)
        {
            settings["WindowLeft"] = this.DesktopLocation.X.ToString();
            settings["WindowTop"] = this.DesktopLocation.Y.ToString();
            settings["WindowWidth"] = this.ClientSize.Width.ToString();
            settings["WindowHeight"] = this.ClientSize.Height.ToString();

            //settings["Sound"] = this.toolStripMain_Sound.Checked == true ? "0" : "1";
            //settings["Stats"] = this.toolStripMain_Stats.Checked == true ? "1" : "0";

            /*
            if (settings["SplitterDistance"] == "0.5")
                settings["SplitterDistance"] = ((int)(this.splitStats.Size.Width / 2)).ToString();
            else
                settings["SplitterDistance"] = this.splitStats.SplitterDistance.ToString();
            */

            // Save window settings.
            TextWriter textWriter = StreamWriter.Null;
            try
            {
                textWriter = new StreamWriter(_programSettingsFileName, false);
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ProgramSettings<string, string>));
                serializer.Serialize(textWriter, settings);
                textWriter.Close();
            }
            catch (Exception ex)
            {
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show(this,
                                    "Unexpected error while\nsaving settings data",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            finally
            {
                if (textWriter != null) textWriter.Close();
            }

        }

        /// <summary>
        /// Update UI with settings
        /// </summary>
        /// <param name="WindowSettings">True if the window position and size should be applied. False if omitted</param>
        private void ApplySettings(ProgramSettings<string, string> programSettings, ProgramSettings<string, string> defaultSettings, bool WindowSettings = false)
        {
            if (WindowSettings)
            {
                if (Convert.ToInt32(programSettings.ContainsKey("WindowPosition") ? programSettings["WindowPosition"] : defaultSettings["WindowPosition"]) == 1)
                {
                    //var startPos = this.StartPosition;
                    this.StartPosition = FormStartPosition.Manual;
                    this.DesktopLocation = new Point(Convert.ToInt32(programSettings.ContainsKey("WindowLeft") ? programSettings["WindowLeft"] : defaultSettings["WindowLeft"]),
                                        Convert.ToInt32(programSettings.ContainsKey("WindowTop") ? programSettings["WindowTop"] : defaultSettings["WindowTop"]));
                    this.ClientSize = new Size(Convert.ToInt32(programSettings.ContainsKey("WindowWidth") ? programSettings["WindowWidth"] : defaultSettings["WindowWidth"]),
                                        Convert.ToInt32(programSettings.ContainsKey("WindowHeight") ? programSettings["WindowHeight"] : defaultSettings["WindowHeight"]));
                    //this.StartPosition = startPos;
                    //this.splitStats.SplitterDistance = Convert.ToInt32(programSettings.ContainsKey("SplitterDistance") ? programSettings["SplitterDistance"] : defaultSettings["SplitterDistance"]);
                }
            }
            /*
            this._game.MinimumLength = Convert.ToInt32(programSettings.ContainsKey("MinimumLength") ? programSettings["MinimumLength"] : defaultSettings["MinimumLength"]);
            this._game.MaximumAttempts = Convert.ToInt32(programSettings.ContainsKey("MaximumAttempts") ? programSettings["MaximumAttempts"] : defaultSettings["MaximumAttempts"]);
            this._game.MaximumDigit = Convert.ToInt32(programSettings.ContainsKey("MaximumDigit") ? programSettings["MaximumDigit"] : defaultSettings["MaximumDigit"]);
            this._game.MinimumDigit = Convert.ToInt32(programSettings.ContainsKey("MinimumDigit") ? programSettings["MinimumDigit"] : defaultSettings["MinimumDigit"]);
            this._game.PlayMode = (PlayMode)Enum.Parse(typeof(PlayMode), programSettings.ContainsKey("PlayMode") ? programSettings["PlayMode"] : defaultSettings["PlayMode"]);
            this._game.Time = Convert.ToInt32(programSettings.ContainsKey("Time") ? programSettings["Time"] : defaultSettings["Time"]);
            this._game.TimeIncrement = Convert.ToInt32(programSettings.ContainsKey("TimeIncrement") ? programSettings["TimeIncrement"] : defaultSettings["TimeIncrement"]);
            //this.board1.Time = Convert.ToInt32(programSettings.ContainsKey("Time") ? programSettings["Time"] : defaultSettings["Time"]);
            this.board1.BorderRatio = Convert.ToSingle(programSettings.ContainsKey("BorderRatio") ? programSettings["BorderRatio"] : defaultSettings["BorderRatio"], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            this.board1.CountDownRatio = Convert.ToSingle(programSettings.ContainsKey("CountDownRatio") ? programSettings["CountDownRatio"] : defaultSettings["CountDownRatio"], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            this.board1.NumbersRatio = Convert.ToSingle(programSettings.ContainsKey("NumbersRatio") ? programSettings["NumbersRatio"] : defaultSettings["NumbersRatio"], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            this.board1.FontRatio = Convert.ToSingle(programSettings.ContainsKey("FontRatio") ? programSettings["FontRatio"] : defaultSettings["FontRatio"], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            this.board1.ResultRatio = Convert.ToSingle(programSettings.ContainsKey("ResultsRatio") ? programSettings["ResultsRatio"] : defaultSettings["ResultsRatio"], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            this.board1.BackColor = Color.FromArgb(Convert.ToInt32(programSettings.ContainsKey("BackColor") ? programSettings["BackColor"] : defaultSettings["BackColor"]));
            this.board1.Font = new Font(programSettings.ContainsKey("FontFamilyName") ? programSettings["FontFamilyName"] : defaultSettings["FontFamilyName"], board1.Font.SizeInPoints);

            this.toolStripMain_Sound.Checked = Convert.ToInt32((programSettings.ContainsKey("Sound") ? programSettings["Sound"] : defaultSettings["Sound"])) == 0 ? true : false;
            this.toolStripMain_Stats.Checked = Convert.ToInt32((programSettings.ContainsKey("Stats") ? programSettings["Stats"] : defaultSettings["Stats"])) == 0 ? false : true;
            //this.toolStripMain_Sound.Checked = programSettings.ContainsKey("Sound") ? (Convert.ToInt32(programSettings["Sound"]) == 0 ? true : false) : false;
            this.board1.PlaySounds = !this.toolStripMain_Sound.Checked;
            */
        }

        /// <summary>
        /// Set default settings. This is called when no settings file has been found
        /// </summary>
        private void LoadDefaultSettings(ProgramSettings<string, string> settings)
        {
            // Set default settings
            settings["WindowLeft"] = this.DesktopLocation.X.ToString();    // Get current form coordinates
            settings["WindowTop"] = this.DesktopLocation.Y.ToString();
            settings["WindowWidth"] = this.ClientSize.Width.ToString();    // Get current form size
            settings["WindowHeight"] = this.ClientSize.Height.ToString();

            settings["Time"] = "700";
            settings["TimeIncrement"] = "0";
            settings["MaximumDigit"] = "9";
            settings["MinimumDigit"] = "0";
            settings["MaximumAttempts"] = "10";
            settings["MinimumLength"] = "2";

            settings["CountDownRatio"] = "0.37";
            settings["NumbersRatio"] = "0.25";
            settings["BorderRatio"] = "0.12";
            settings["FontRatio"] = "0.55";
            settings["ResultsRatio"] = "0.56";
            settings["FontFamilyName"] = "Microsoft Sans Serif";
            settings["BackColor"] = Color.White.ToArgb().ToString();
            settings["WindowPosition"] = "0";   // Remember windows position

            settings["PlayMode"] = "9";     //Fixed time (1) & random sequence (8)

            settings["Sound"] = "1";        // Soundoff unchecked
            settings["Stats"] = "0";        // Stats unchecked

            settings["SplitterDistance"] = "265";
        }

        #endregion Application settings
    }
}
