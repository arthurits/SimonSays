using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorButton
{

    public partial class SimonButton : Button //https://msdn.microsoft.com/en-us/library/5h0k2e6x(v=vs.110).aspx
    {
        #region Variable definition

        //Task taskBeep;
        private GraphicsPath path;
        //private GraphicsPath innerPath;
        private Int32 _nColor = 0;
        private Int32 _nRotation = 0;
        private bool _clicked = false;
        private Int32 _nFrequency = 165;
        private Int32 _nDuration = 420;
        //private float _fButtonWidth = 0.55f;
        //private float _fButtonRadius = 0.08f;
        //private float _fDegrees = 1.0f;
        
        //private float _fMaxRadius= 1f;
        //private float _fMinRadius = 0.5f;

        //private float _fWidthFactor = 0.65f;
        //private float _fSideFactor = 1.15f;
        //private float _fAlpha = 0.0f;
        //private float _fBeta = 0.0f;

        private Int32 _nSideLength = 0;
        private Int32 _nXOffset = 0;
        private Int32 _nYOffset = 0;
        private float _fAngleOut = 0.0f;
        private float _fAngleIn = 0.0f;
        private PointF _fPoint0;
        private PointF _fPoint1;
        private PointF _fPoint2;
        private PointF _fPoint3;
        private PointF _fPoint4;
        private PointF _fPoint5;
        private float _fWidth = 1.0f;

        #endregion Variable definition

        #region Public interface

        [Description("Numeric value representing the color"),
        Category("Custom"),
        Browsable(true)]
        public Int32 ColorValue
        {
            get { return _nColor; }
            set { _nColor = value > 3 ? 3 : (value < 0 ? 0 : value); }
        }

        [Description("State of the button"),
        Category("Custom"),
        Browsable(true)]
        public bool Clicked
        {
            get { return _clicked; }
            set
            {
                _clicked = value;
                if (value == true) DoBeep(_nDuration);
                Invalidate();
            }
        }

        [Description("Rotation (degrees) of the button"),
        Category("Custom"),
        Browsable(true)]
        public Int32 Rotation
        {
            get { return _nRotation; }
            set
            {
                _nRotation = value;
                Invalidate();
            }
        }

        [Description("Frequency (Hertz) of the beeping sound"),
        Category("Custom"),
        Browsable(true)]
        public Int32 Frequency
        {
            get { return _nFrequency; }
            set { _nFrequency = value; }
        }

        [Description("Duration (miliseconds) of the beeping sound"),
        Category("Custom"),
        Browsable(true)]
        public Int32 Duration
        {
            get { return _nDuration; }
            set { _nDuration = value; }
        }

        [Description("Button outer envelope radial span (degrees)"),
        Category("Custom"),
        Browsable(true)]
        public float OuterAngleSpan
        {
            get { return _fAngleOut; }
            set { _fAngleOut = value; CalculateFactors(); Invalidate(); }
        }

        [Description("Width percentage of the button"),
        Category("Custom"),
        Browsable(true)]
        public float WidthPercentage
        {
            get { return _fWidth; }
            set { _fWidth = value; CalculateFactors(); Invalidate(); }
        }

        [Description("Gets the button radius"),
        Category("Custom"),
        Browsable(true)]
        public Int32 ButtonRadius
        {
            get { return _nSideLength; }
        }

        [Description("Gets the button X offset"),
        Category("Custom"),
        Browsable(true)]
        public Int32 OffSetX
        { get { return _nXOffset; } }

        [Description("Gets the button Y offset"),
        Category("Custom"),
        Browsable(true)]
        public Int32 OffSetY
        { get { return _nYOffset; } }

        #endregion Public interface

        public SimonButton()
        {
            InitializeComponent();
            //CalculateFactors();

            // To ensure that your control is redrawn every time it is resized
            // https://msdn.microsoft.com/en-us/library/b818z6z6(v=vs.110).aspx
            SetStyle(ControlStyles.ResizeRedraw, true);

            this.DoubleBuffered = true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            DoBeep(350);
            _clicked = true;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _clicked = false;
            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (_clicked == true) { this.Clicked = false; }
            base.OnMouseLeave(e);
        }

        protected override void OnResize(EventArgs e)
        {
            //Invalidate();
            _nSideLength = (Int32)Math.Round(Math.Min(this.Size.Height, this.Size.Width) / Math.Sqrt(2.0));
            //Int32 nXOffset = (Int32)Math.Floor(  (this.Size.Width - nSideLength )   / 2.0);
            //Int32 nYOffset = (Int32)Math.Floor(  (this.Size.Height  - nSideLength)   / 2.0);
            _nXOffset = (Int32)Math.Round(this.Size.Width / 2 - _nSideLength * (1 - 0.5 * Math.Cos(Math.PI / 4.0)));
            _nYOffset = (Int32)Math.Round(this.Size.Height / 2 - _nSideLength * (1 - 0.5 * Math.Cos(Math.PI / 4.0)));

            _nXOffset = (Int32)Math.Floor(0.5 * (this.Size.Width - _nSideLength));
            _nYOffset = (Int32)Math.Floor(0.5 * (this.Size.Height - _nSideLength));
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Create Rectangle To Limit brush area.
            //Rectangle rect = new Rectangle(0, 0, 150, 150);

            path = new GraphicsPath();
            /*GraphicsPath pathRect1 = new GraphicsPath();
            GraphicsPath pathRect2 = new GraphicsPath();

            pathRect1.AddRectangle(new RectangleF(_nXOffset,
                _nYOffset,
                _nSideLength * (1),
                _nSideLength * (1)));

            pathRect2.AddRectangle(new RectangleF(_nXOffset + _nSideLength * (_fPoint5.X ),
                _nYOffset + _nSideLength * (_fPoint5.Y ),
                _nSideLength * (1 - 1 * _fPoint5.Y),
                _nSideLength * (1 - 1 * _fPoint5.Y)));*/
            //g.DrawPath(new Pen(Color.Red, 10), pathPunto);
            

            path.AddArc(_nXOffset + _nSideLength * (_fPoint0.X),
                _nYOffset + _nSideLength * (_fPoint0.Y),
                2 * _nSideLength * (1 - 1 * _fPoint0.X),
                2 * _nSideLength * (1 - 1 * _fPoint0.Y),
                180 + _fAngleOut,
                90 - 2 * _fAngleOut);
            path.AddLine(_nXOffset + _nSideLength * _fPoint2.X,
                _nYOffset + _nSideLength * _fPoint2.Y,
                _nXOffset + _nSideLength * _fPoint3.X,
                _nYOffset + _nSideLength * ( _fPoint3.Y));
            /*path.AddLine(path.GetLastPoint().X, path.GetLastPoint().Y,
                path.GetLastPoint().X,
                path.GetLastPoint().Y+80);*/
            /*path.AddArc(_nXOffset + _nSideLength * (_fPoint0.X + _fPoint1.X + _fPoint4.X),
                _nYOffset + _nSideLength * (_fPoint0.Y + _fPoint2.Y + _fPoint3.Y),
                1 * _nSideLength * (1 - _fPoint5.X),
                1 * _nSideLength * (1 - _fPoint5.X),
                270 - _fAngleIn,
                -(90 - 2 * _fAngleIn));*/
            if (_fPoint5.X<1.0 && _fAngleIn<45.0)
            {
                path.AddArc(_nXOffset + _nSideLength * (_fPoint5.X),
                _nYOffset + _nSideLength * (_fPoint5.Y),
                2 * _nSideLength * (1 - _fPoint5.X),
                2 * _nSideLength * (1 - _fPoint5.X),
                270 - _fAngleIn,
                -(90 - 2 * _fAngleIn));
            }
            
             path.AddLine(_nXOffset + _nSideLength * ( _fPoint4.X),
                _nYOffset + _nSideLength * (0 + _fPoint4.Y),
                _nXOffset + _nSideLength * (_fPoint0.X + _fPoint1.X),
                _nYOffset + _nSideLength * (0 + _fPoint1.Y));
            
            Matrix matrix = new Matrix();
            //matrix.RotateAt(_nRotation, new PointF(_nXOffset + _nSideLength / 2, _nYOffset + _nSideLength / 2));
            matrix.RotateAt(_nRotation, new PointF(this.Size.Width / 2, this.Size.Height / 2));
            path.Transform(matrix);

            LinearGradientBrush linearBrush =
                new LinearGradientBrush(new RectangleF(_nXOffset, _nYOffset, _nSideLength * (1 - (float)Math.Sin(_fAngleOut * Math.PI / 180)), _nSideLength * (1 - (float)Math.Sin(_fAngleOut * Math.PI / 180))),
                this.BackColor,
                this.ForeColor,
                45 + _nRotation);

            g.FillPath(linearBrush, path);
            this.Region = new Region(path);
            //g.DrawPath(new Pen(Color.Red,10), path);
            if (_clicked == true)
            {
                PathGradientBrush pthGrBrush = new PathGradientBrush(path);
                
                pthGrBrush.SurroundColors = new Color[] { this.ForeColor };
                pthGrBrush.CenterColor = Color.FromArgb(220, 255, 255, 255);
                //pthGrBrush.FocusScales = new PointF(0.4f, 0.4f);
                pthGrBrush.CenterPoint = new PointF(_nXOffset + _nSideLength * _fPoint4.X, _nYOffset + _nSideLength * _fPoint3.Y);

                g.FillPath(pthGrBrush, path);
                //g.FillRectangle(pthGrBrush, new Rectangle(0, 0, nSideLength, nSideLength));
                pthGrBrush.Dispose();

            }            


            linearBrush.Dispose();
            //g.FillPath(new SolidBrush(Color.FromArgb(100, 255, 0, 0)), pathRect1);
            //g.FillPath(new SolidBrush(Color.FromArgb(100, 0, 0, 255)), pathRect2);
        }

        private void CalculateFactors()
        {

            // Variable definition
            Double dAngle = _fAngleOut * Math.PI / 180;

            /*
            if (_fAngleOut == 0.0f)
            {
                _fAngleIn = 0.0f;

                if (_fWidth == 1)
                    _fPoint5.X = 0.99999f;
                else
                    _fPoint5.X = _fPoint3.Y;
            }
            else
            {
                _fAngleIn = (float)Math.Atan(Math.Sin(dAngle) / ((1 - _fWidth) * Math.Cos(dAngle) + _fWidth * Math.Sin(dAngle)));

                // Calculate the angle values. If it is full width size, then there is no angle
                if (_fWidth == 1)
                    _fAngleIn = 0.0f;
                else
                    _fAngleIn = (float)Math.Asin(Math.Sin(dAngle) * 1 / ((1 - _fWidth)));
                
            }*/

            // Calculate the angle values
            _fAngleIn = 0.0f;
            if (_fWidth < 1.0)
                _fAngleIn = (float)Math.Asin(Math.Sin(dAngle) * 1 / ((1 - _fWidth)));

            /*
            if (_fWidth==1)
            {
                _fPoint0.X = 0.0f;
            }
            else
            {
                _fPoint0.X = (1 - _fWidth) / 2;
                _fPoint0.X = 0.0f;
            }*/

            // Calculate the point coordinates used to draw the button
            _fPoint0.X = 0.0f;
            _fPoint0.Y = _fPoint0.X;

            _fPoint1.X = 1 - (float)Math.Cos(dAngle);
            _fPoint1.Y = 1 - (float)Math.Sin(dAngle);

            _fPoint2.X = _fPoint1.Y;
            _fPoint2.Y = _fPoint1.X;

            _fPoint3.X = _fPoint2.X;
            //_fPoint3.Y = 1 - (float)Math.Cos(_fAngleIn * Math.PI / 180);
            //_fPoint3.Y = 1 + (_fWidth - 1) * (float)Math.Cos(dAngle) - _fWidth * (float)Math.Sin(dAngle);
            _fPoint3.Y = _fWidth;
            _fPoint3.Y = (float)(1 - (1 - _fWidth) * Math.Cos(_fAngleIn));

            _fPoint4.X = _fPoint3.Y;
            _fPoint4.Y = _fPoint1.Y;


            //_fPoint5.X = _fPoint3.Y - (float)Math.Sin(_fAngleIn);
            //_fPoint5.Y = _fPoint4.X - (float)Math.Sin(_fAngleIn);            

            //_fPoint5.X = 1 - (float)(Math.Sin(dAngle) / Math.Sin(_fAngleIn));
            _fPoint5.X = _fWidth;
            _fPoint5.Y = _fPoint5.X;

            // Convert the angle value to degrees
            _fAngleIn = _fAngleIn * 180 / (float)Math.PI;


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
    }


    //
    //
    //
    //
    //
    //
    //
    //
    //
    //
    //
    //

    public enum WaveType
    {
        SineWave = 0,
        CosineWave = 1,
        SquareWave = 2,
        SawtoothWave = 3,
        TriangleWave = 4,
        WhiteNoiseWave = 5
    }
    public class WaveHeader
    {
        public string sGroupID; // RIFF
        public uint dwFileLength; // total file length minus 8, which is taken up by RIFF
        public string sRiffType; // always WAVE

        /// <summary>
        /// Initializes a WaveHeader object with the default values.
        /// </summary>
        public WaveHeader()
        {
            dwFileLength = 0;
            sGroupID = "RIFF";
            sRiffType = "WAVE";
        }
    }

    public class WaveFormatChunk
    {
        public string sChunkID;         // Four bytes: "fmt "
        public uint dwChunkSize;        // Length of header in bytes
        public ushort wFormatTag;       // 1 (MS PCM)
        public ushort wChannels;        // Number of channels
        public uint dwSamplesPerSec;    // Frequency of the audio in Hz... 44100
        public uint dwAvgBytesPerSec;   // for estimating RAM allocation
        public ushort wBlockAlign;      // sample frame size, in bytes
        public ushort wBitsPerSample;    // bits per sample

        /// <summary>
        /// Initializes a format chunk with the following properties:
        /// Sample rate: 44100 Hz
        /// Channels: Stereo
        /// Bit depth: 16-bit
        /// </summary>
        public WaveFormatChunk()
        {
            sChunkID = "fmt ";
            dwChunkSize = 16;
            wFormatTag = 1;
            wChannels = 2;
            dwSamplesPerSec = 44100;
            wBitsPerSample = 16;
            wBlockAlign = (ushort)(wChannels * (wBitsPerSample / 8));
            dwAvgBytesPerSec = dwSamplesPerSec * wBlockAlign;
        }
    }

    public class WaveDataChunk
    {
        public string sChunkID;     // "data"
        public uint dwChunkSize;    // Length of header in bytes
        public short[] shortArray;  // 16-bit audio  If you want to change to 8-bit audio, use an array of bytes. If you want to use 32-bit audio, use an array of floats.

        /// <summary>
        /// Initializes a new data chunk with default values.
        /// </summary>
        public WaveDataChunk()
        {
            shortArray = new short[0];
            dwChunkSize = 0;
            sChunkID = "data";
        }
    }

    public class WaveGenerator
    {
        // Header, Format, Data chunks
        WaveHeader header;
        WaveFormatChunk format;
        WaveDataChunk data;
        System.IO.MemoryStream audioStream;

        // Variables to construct the waveform
        uint numSamples;
        int amplitude;
        int msFade;
        double frequency;
        double tau;


        public WaveGenerator()
        {
            // Init chunks
            header = new WaveHeader();
            format = new WaveFormatChunk();
            data = new WaveDataChunk();

            // Initialize stream
            audioStream = new System.IO.MemoryStream();
        }

        /// <snip>
        public WaveGenerator(double freq, int msDuration, WaveType type, short volume = 16383, int milisecondsFade = 30)
        {
            // Init chunks
            header = new WaveHeader();
            format = new WaveFormatChunk();
            data = new WaveDataChunk();

            // Other data
            // Number of samples = sample rate * channels * bytes per sample
            numSamples = (uint)(format.dwSamplesPerSec * format.wChannels * msDuration / 1000);

            // Initialize the 16-bit array
            data.shortArray = new short[numSamples];

            //amplitude = 32760;  // Max amplitude for 16-bit audio
            amplitude = Math.Abs(volume);
            frequency = freq;
            msFade = milisecondsFade;

            // The "angle" used in the function, adjusted for the number of channels and sample rate.
            // This value is like the period of the wave.
            tau = (Math.PI * 2 * frequency) / (format.dwSamplesPerSec * format.wChannels);
            //t = (Math.PI * 2 * frequency) / (numSamples);

            // Fill the data array with sample data
            switch (type)
            {
                case WaveType.SineWave:
                    GenerateSineWave();
                    break;
                case WaveType.CosineWave:
                    GenerateCosineWave();
                    break;
                case WaveType.SquareWave:
                    GenerateSquareWave();
                    break;
                case WaveType.SawtoothWave:
                    GenerateSawToothWave();
                    break;
                case WaveType.TriangleWave:
                    GenerateTriangleWave();
                    break;
                case WaveType.WhiteNoiseWave:
                    GenerateWhiteNoiseWave();
                    break;
            }

            // Calculate data chunk size in bytes
            data.dwChunkSize = (uint)(data.shortArray.Length * (format.wBitsPerSample / 8));

        }
                
        public void PlaySound()
        {
            // write data to a MemoryStream with BinaryWriter
            // System.IO.MemoryStream audioStream = new System.IO.MemoryStream();
            audioStream = new System.IO.MemoryStream();
            System.IO.BinaryWriter writer = new System.IO.BinaryWriter(audioStream);

            // Write the header
            writer.Write(header.sGroupID.ToCharArray());
            writer.Write(header.dwFileLength);
            writer.Write(header.sRiffType.ToCharArray());

            // Write the format chunk
            writer.Write(format.sChunkID.ToCharArray());
            writer.Write(format.dwChunkSize);
            writer.Write(format.wFormatTag);
            writer.Write(format.wChannels);
            writer.Write(format.dwSamplesPerSec);
            writer.Write(format.dwAvgBytesPerSec);
            writer.Write(format.wBlockAlign);
            writer.Write(format.wBitsPerSample);

            // Write the data chunk
            writer.Write(data.sChunkID.ToCharArray());
            writer.Write(data.dwChunkSize);
            foreach (short dataPoint in data.shortArray)
            {
                writer.Write(dataPoint);
            }
            writer.Seek(4, System.IO.SeekOrigin.Begin);
            uint filesize = (uint)writer.BaseStream.Length;
            writer.Write(filesize - 8);

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(audioStream);
            if (player != null)
            {
                player.Stream.Seek(0, System.IO.SeekOrigin.Begin); // rewind stream
                player.Play();
            }
            writer.Close();
            audioStream.Close();
        }

        public void Save(string filePath)
        {
            // Create a file (it always overwrites)
            System.IO.FileStream fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create);

            // Use BinaryWriter to write the bytes to the file
            System.IO.BinaryWriter writer = new System.IO.BinaryWriter(fileStream);

            // Write the header
            writer.Write(header.sGroupID.ToCharArray());
            writer.Write(header.dwFileLength);
            writer.Write(header.sRiffType.ToCharArray());

            // Write the format chunk
            writer.Write(format.sChunkID.ToCharArray());
            writer.Write(format.dwChunkSize);
            writer.Write(format.wFormatTag);
            writer.Write(format.wChannels);
            writer.Write(format.dwSamplesPerSec);
            writer.Write(format.dwAvgBytesPerSec);
            writer.Write(format.wBlockAlign);
            writer.Write(format.wBitsPerSample);

            // Write the data chunk
            writer.Write(data.sChunkID.ToCharArray());
            writer.Write(data.dwChunkSize);
            foreach (short dataPoint in data.shortArray)
            {
                writer.Write(dataPoint);
            }

            writer.Seek(4, System.IO.SeekOrigin.Begin);
            uint filesize = (uint)writer.BaseStream.Length;
            writer.Write(filesize - 8);

            // Clean up
            writer.Close();
            fileStream.Close();

            return;
        }

        private void GenerateSineWave()
        {
            double tempSample;
            uint fadeIn = (uint)(format.dwSamplesPerSec * format.wChannels * msFade / 1000);
            uint fadeOut = numSamples - fadeIn;
            for (uint i = 0; i < numSamples; i += format.wChannels)
            {
                if (i < fadeIn)
                {
                    //tempSample = (i / (double)fadeIn) * amplitude * Math.Sin(tau * i);
                    tempSample = EaseInOutCubic(i, fadeIn, 0, 1) * amplitude * Math.Sin(tau * i);
                }
                else if (i > fadeOut)
                {
                    //tempSample = ((numSamples - i) / (double)fadeIn) * amplitude * Math.Sin(tau * i);
                    tempSample = (1 - EaseInOutCubic(i - fadeOut, fadeIn, 0, 1)) * amplitude * Math.Sin(tau * i);
                }
                else
                {
                    tempSample = amplitude * Math.Sin(tau * i);
                }

                // Fill with a simple sine wave at max amplitude
                for (int channel = 0; channel < format.wChannels; channel++)
                {
                    data.shortArray[i + channel] = Convert.ToInt16(tempSample);
                }
            }

            return;
        }

        private void GenerateCosineWave()
        {
            double tempSample;

            for (int i = 0; i < numSamples; i += format.wChannels)
            {
                tempSample = amplitude * Math.Cos(tau * i);
                // Fill with a simple cosine wave at max amplitude
                for (int channel = 0; channel < format.wChannels; channel++)
                {
                    data.shortArray[i + channel] = Convert.ToInt16(tempSample);
                }
            }

            return;
        }

        private void GenerateSquareWave()
        {
            double tempSample;

            for (int i = 0; i < numSamples - 1; i += format.wChannels)
            {
                tempSample = amplitude * Math.Sign(Math.Sin(tau * i));

                for (int channel = 0; channel < format.wChannels; channel++)
                {
                    data.shortArray[i + channel] = Convert.ToInt16(tempSample);
                }
            }
            return;
        }

        private void GenerateSawToothWave()
        {
            // Determine the number of samples per wavelength
            int samplesPerWavelength = Convert.ToInt32(format.dwSamplesPerSec / (frequency / format.wChannels));

            // Determine the amplitude step for consecutive samples
            short ampStep = Convert.ToInt16((amplitude * 2) / samplesPerWavelength);

            // Temporary sample value, added to as we go through the loop
            short tempSample = (short)-amplitude;

            // Total number of samples written so we know when to stop
            int totalSamplesWritten = 0;

            while (totalSamplesWritten < numSamples)
            {
                tempSample = (short)-amplitude;

                for (uint i = 0; i < samplesPerWavelength && totalSamplesWritten < numSamples; i++)
                {
                    tempSample += ampStep;

                    for (int channel = 0; channel < format.wChannels; channel++)
                    {
                        data.shortArray[totalSamplesWritten] = tempSample;
                        totalSamplesWritten++;
                    }
                }
            }
        }

        private void GenerateTriangleWave()
        {
            // Determine the number of samples per wavelength
            int samplesPerWavelength = Convert.ToInt32(format.dwSamplesPerSec / (frequency / format.wChannels));

            // Determine the amplitude step for consecutive samples
            short ampStep = Convert.ToInt16((amplitude * 2) / samplesPerWavelength);

            // Temporary sample value, added to as we go through the loop
            short tempSample = (short)-amplitude;

            for (int i = 0; i < numSamples - 1; i += format.wChannels)
            {
                for (int channel = 0; channel < format.wChannels; channel++)
                {
                    // Negate ampstep whenever it hits the amplitude boundary
                    if (Math.Abs(tempSample) > amplitude)
                        ampStep = (short)-ampStep;

                    tempSample += ampStep;
                    data.shortArray[i + channel] = tempSample;
                }
            }
        }

        private void GenerateWhiteNoiseWave()
        {
            Random rnd = new Random();
            short randomValue = 0;

            for (int i = 0; i < numSamples; i++)
            {
                randomValue = Convert.ToInt16(rnd.Next(-amplitude, amplitude));
                data.shortArray[i] = randomValue;
            }
        }

        public static void PlayBeep(ushort frequency, int msDuration, UInt16 volume = 16383)
        {
            System.IO.MemoryStream mStrm = new System.IO.MemoryStream();
            System.IO.BinaryWriter writer = new System.IO.BinaryWriter(mStrm);

            const double TAU = 2 * Math.PI;
            int formatChunkSize = 16;
            int headerSize = 8;
            short formatType = 1;
            short tracks = 1;
            int samplesPerSecond = 44100;
            short bitsPerSample = 16;
            short frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
            int bytesPerSecond = samplesPerSecond * frameSize;
            int waveSize = 4;
            int samples = (int)((decimal)samplesPerSecond * msDuration / 1000);
            int dataChunkSize = samples * frameSize;
            int fileSize = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize;
            // var encoding = new System.Text.UTF8Encoding();
            writer.Write(0x46464952); // = encoding.GetBytes("RIFF")
            writer.Write(fileSize);
            writer.Write(0x45564157); // = encoding.GetBytes("WAVE")
            writer.Write(0x20746D66); // = encoding.GetBytes("fmt ")
            writer.Write(formatChunkSize);
            writer.Write(formatType);
            writer.Write(tracks);
            writer.Write(samplesPerSecond);
            writer.Write(bytesPerSecond);
            writer.Write(frameSize);
            writer.Write(bitsPerSample);
            writer.Write(0x61746164); // = encoding.GetBytes("data")
            writer.Write(dataChunkSize);
            {
                double theta = frequency * TAU / (double)samplesPerSecond;
                // 'volume' is UInt16 with range 0 thru Uint16.MaxValue ( = 65 535)
                // we need 'amp' to have the range of 0 thru Int16.MaxValue ( = 32 767)
                double amp = volume >> 2; // so we simply set amp = volume / 2
                for (int step = 0; step < samples; step++)
                {
                    short s = (short)(amp * Math.Sin(theta * (double)step));
                    writer.Write(s);
                }
            }

            mStrm.Seek(0, System.IO.SeekOrigin.Begin);
            new System.Media.SoundPlayer(mStrm).Play();
            writer.Close();
            mStrm.Close();
        }

        /// <summary>
        /// Linear tween equation
        /// </summary>
        /// <param name="nTimeCurrent">The current time (starting at zero) we are in and want to calculate for</param>
        /// <param name="nTimeDuration">The easing/tween duration</param>
        /// <param name="nStartingValue">The starting value at the beginning of the easing/tween</param>
        /// <param name="nEndingValue">The starting value at the ending of the easing/tween</param>
        /// <returns>The linear factor between nStartingValue and nEndingValue</returns>
        private double LinearTween(uint nTimeCurrent, uint nTimeDuration, uint nStartingValue, uint nEndingValue)
        {
            return nEndingValue * nTimeCurrent / nTimeDuration + nStartingValue;
        }


        /// <summary>
        /// Easing-in cubic equation
        /// </summary>
        /// <param name="nTimeCurrent">The current time (starting at zero) we are in and want to calculate for</param>
        /// <param name="nTimeDuration">The easing duration</param>
        /// <param name="nStartingValue">The starting value at the beginning of the easing</param>
        /// <param name="nEndingValue">The starting value at the ending of the easing</param>
        /// <returns>The cubic easing-in factor between nStartingValue and nEndingValue</returns>
        private double EaseInCubic(uint nTimeCurrent, uint nTimeDuration, uint nStartingValue, uint nEndingValue)
        {
            double dTime = (double)nTimeCurrent / nTimeDuration;
            return nEndingValue * dTime * dTime * dTime + nStartingValue;
        }

        /// <summary>
        /// Easing-out cubic equation
        /// </summary>
        /// <param name="nTimeCurrent">The current time (starting at zero) we are in and want to calculate for</param>
        /// <param name="nTimeDuration">The easing duration</param>
        /// <param name="nStartingValue">The starting value at the beginning of the easing</param>
        /// <param name="nEndingValue">The starting value at the ending of the easing</param>
        /// <returns>The cubic easing-out factor between nStartingValue and nEndingValue</returns>
        private double EaseOutCubic(uint nTimeCurrent, uint nTimeDuration, uint nStartingValue, uint nEndingValue)
        {
            double dTime = (double)nTimeCurrent / nTimeDuration;
            dTime--;
            return nEndingValue * (dTime * dTime * dTime + 1) + nStartingValue;

        }

        /// <summary>
        /// Easing-in-out cubic equation
        /// </summary>
        /// <param name="nTimeCurrent">The current time (starting at zero) we are in and want to calculate for</param>
        /// <param name="nTimeDuration">The easing duration</param>
        /// <param name="nStartingValue">The starting value at the beginning of the easing</param>
        /// <param name="nEndingValue">The starting value at the ending of the easing</param>
        /// <returns>The cubic easing-in-out factor between nStartingValue and nEndingValue</returns>
        private double EaseInOutCubic(uint nTimeCurrent, uint nTimeDuration, uint nStartingValue, uint nEndingValue)
        {
            double dTime = (double)nTimeCurrent / nTimeDuration;
            dTime *= 2;
            if (dTime < 1) return (nEndingValue / 2.0) * dTime * dTime * dTime + nStartingValue;
            dTime -= 2;
            return (nEndingValue / 2.0) * (dTime * dTime * dTime + 2) + nStartingValue;
        }

        /// <summary>
        /// Easing-in quadratic equation
        /// </summary>
        /// <param name="nTimeCurrent">The current time (starting at zero) we are in and want to calculate for</param>
        /// <param name="nTimeDuration">The easing duration</param>
        /// <param name="nStartingValue">The starting value at the beginning of the easing</param>
        /// <param name="nEndingValue">The starting value at the ending of the easing</param>
        /// <returns>The quadratic easing-in factor between nStartingValue and nEndingValue</returns>
        private double EaseInQuad(uint nTimeCurrent, uint nTimeDuration, uint nStartingValue, uint nEndingValue)
        {
            double dTime = (double)nTimeCurrent / nTimeDuration;
            return nEndingValue * dTime * dTime + nStartingValue;
        }

        /// <summary>
        /// Easing-out quadratic equation
        /// </summary>
        /// <param name="nTimeCurrent">The current time (starting at zero) we are in and want to calculate for</param>
        /// <param name="nTimeDuration">The easing duration</param>
        /// <param name="nStartingValue">The starting value at the beginning of the easing</param>
        /// <param name="nEndingValue">The starting value at the ending of the easing</param>
        /// <returns>The quadratic easing-out factor between nStartingValue and nEndingValue</returns>
        private double EaseOutQuad(uint nTimeCurrent, uint nTimeDuration, uint nStartingValue, uint nEndingValue)
        {
            double dTime = (double)nTimeCurrent / nTimeDuration;
            return -nEndingValue * dTime * (dTime - 2) + nStartingValue;
        }

        private double EaseInOutQuad(uint nTimeCurrent, uint nTimeDuration, uint nStartingValue, uint nEndingValue)
        {
            double dTime = (double)nTimeCurrent / nTimeDuration;
            dTime *= 2;
            if (dTime < 1) return nEndingValue / 2.0 * dTime * dTime + nStartingValue;
            dTime--;
            return -nEndingValue / 2.0 * (dTime * (dTime - 2) - 1) + nStartingValue;
        }

        // http://gizma.com/easing/#cub3
        // http://joshondesign.com/2013/03/01/improvedEasingEquations

    }


}
