using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimonSays
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class CustomBoard : UserControl
    {
        #region Variable definitions

        private Int32 _nHighest = 0;
        private Int32 _nScore = 0;
        private Int32 _nButtons = 4;

        private SimonSays.SimonButton[] _buttons;
        private Color[] _colors;
        private float[] _frequencies;

        // Definición de los botones
        private Int32 _nMinDimension = 0;
        private float _fApothem = 0f;
        private float _fPolySide = 0f;
        private float _fRadiusOffset = 0f;
        private float _fOuterCircle = 0.9f;
        private float _fInnerCircle = 0.35f;
        private float _fRotation = 0f;
        private Rectangle _OuterRect;
        private Rectangle _InnerRect;
        private Rectangle _ButtonRect;
        private Color _BackgroundColor = Color.Transparent;
        private Color _OuterColor = Color.Black;
        private Color _InnerColor = Color.White;
        
        private bool _sound = true;

        // Ratios
        private float _fCenterButton = 0.0f;
        private float _fOuterButton = 0.95f;
        private float _fInnerButton = 0.55f;
        private float _fButtonClickOffset = 0.0f;

        // Default buttons list
        private List<(int Value, float Frequency, string Color)> _defButtons;

        //public ButtonColor _ButtonColor = new ButtonColor();
        //public ButtonRotation _ButtonRotation = new ButtonRotation();
        //public ButtonFrequency _ButtonFrequency = new ButtonFrequency();

        #endregion Variable definitions

        #region Events
        public event EventHandler<ButtonClickEventArgs> ButtonClick;
        protected virtual void OnButtonClick(ButtonClickEventArgs e)
        {
            //if (ButtonClick != null) ButtonClick(this, e);
            ButtonClick?.Invoke(this, e);
        }
        /// <summary>
        /// Class to send the event data to the "listener"
        /// </summary>
        public class ButtonClickEventArgs : EventArgs
        {
            public readonly Int32 ButtonValue;
            public ButtonClickEventArgs(Int32 button) { ButtonValue = button; }
        }
        #endregion Events

        #region Public interface
        // Interfaz pública de las propiedades del control
        // https://msdn.microsoft.com/en-us/library/system.componentmodel.notifyparentpropertyattribute.aspx     

        /// <summary>
        /// Ratio (range 0 to 1) of the outermost board circle with respecto to the MinDimension property
        /// </summary>
        [Description("Ratio (range 0 to 1) of the outermost board circle with respecto to the MinDimension property"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float PercentOuterRatio
        {
            get => _fOuterCircle;
            set
            {
                _fOuterCircle = value < 0 ? 0 : (value > 1 ? 1 : value);
                ComputeBoardRectangles();
                Invalidate();
            }
        }

        /// <summary>
        /// Ratio (range 0 to 1) of the innermost board circle with respecto to the MinDimension property
        /// </summary>
        [Description("Ratio (range 0 to 1) of the innermost board circle with respecto to the MinDimension property"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float PercentInnerRatio
        {
            get => _fInnerCircle;
            set
            {
                _fInnerCircle = value < 0 ? 0 : (value > 1 ? 1 : value);
                ComputeBoardRectangles();
                Invalidate();
            }
        }

        /// <summary>
        /// (Read only) Rectangle defining the outermost board circle
        /// </summary>
        [Description("Rectangle defining the outermost board circle"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Rectangle OuterRectangle
        {
            get => _OuterRect;
        }

        [Description("Rectangle defining the inner board circle"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Rectangle InnerRectangle
        {
            get => _InnerRect;
        }

        [Description("Rectangle defining the boundaries of the button"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Rectangle ButtonRectangle
        {
            get => _ButtonRect;
        }

        [Description("Minimum dimension (height or width) of the control"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int MinimumDimension
        {
            get => _nMinDimension;
        }

        [Description("Background color of the control"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ColorBackground
        {
            get => _BackgroundColor;
            set { _BackgroundColor = value; Invalidate(); }
        }

        [Description("Outer circle color"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ColorOuterCircle
        {
            get { return _OuterColor; }
            set { _OuterColor = value; Invalidate(); }
        }

        [Description("Inner circle color"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ColorInnerCircle
        {
            get { return _InnerColor; }
            set { _InnerColor = value; Invalidate(); }
        }

        [Description("Maximum score"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Int32 ScoreHighest
        {
            get { return _nHighest; }
            set { _nHighest = value; lblScoreTotal.Text = String.Concat("Highest: ", value); }
        }

        [Description("Current score"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Int32 ScoreTotal
        {
            get { return _nScore; }
            set { _nScore = value; lblScoreCurrent.Text = String.Concat("Score: ", value); }
        }

        /// <summary>
        /// Number of buttons shown in the board
        /// </summary>
        [Description("Number of buttons shown in the board"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 NumberOfButtons
        {
            get { return _nButtons; }
            set { _nButtons = value < 0 ? 0 : value; CreateButtons(); }
        }

        /// <summary>
        /// Ratio (range 0 to 1) with respect the outer circle radius of the board
        /// </summary>
        [Description("Ratio (range 0 to 1) with respect the outer circle radius of the board"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float CenterButtonRatio
        {
            get => _fCenterButton;
            set
            {
                _fCenterButton = value < 0 ? 0 : (value > 1 ? 1 : value);
                //_fApothem = _fCenterButton * _fOuterCircle * _nMinDimension;
                ButtonsOffsetParameters();
                ResizeButtons();
            }
        }

        /// <summary>
        /// Ratio (range 0 to 1) of the outer button with respect of outer circle radius of the board
        /// </summary>
        [Description("Ratio (range 0 to 1) of the outer button with respect of outer circle radius of the board"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float OuterButtonRatio
        {
            get => _fOuterButton;
            set
            {
                _fOuterButton = value < 0 ? 0 : (value > 1 ? 1 : value);
                ResizeButtons();
            }
        }
        /// <summary>
        /// Ratio (range 0 to 1) of the inner button with respect of outer circle radius of the board
        /// </summary>
        [Description("Ratio (range 0 to 1) of the outer button with respect of outer circle radius of the board"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float InnerButtonRatio
        {
            get => _fInnerButton;
            set
            {
                _fInnerButton = value < 0 ? 0 : (value > 1 ? 1 : value);
                ResizeButtons();
            }
        }

        /// <summary>
        /// Ratio (range 0 to 1) of the click offset
        /// </summary>
        [Description("Ratio (range 0 to 1) of the click offset"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float ButtonClickOffset
        {
            get => _fButtonClickOffset;
            set
            {
                _fButtonClickOffset = value < 0 ? 0 : (value > 1 ? 1 : value);
            }
        }

        /// <summary>
        /// Rotation (in sexagesimal degrees) of the board
        /// </summary>
        [Description("Rotation (in sexagesimal degrees) of the board"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float BoardRotation
        {
            get => _fRotation;
            set
            {
                _fRotation = value < 0 ? 0 : (value >= 360 ? 0 : value);
                for (int i = 0; i < _buttons.Length; i++)
                    _buttons[i].AngleRotation = _buttons[i].Value * _buttons[i].AngleSwept + _fRotation;
                ResizeButtons();
                Invalidate();
            }
        }

        /// <summary>
        /// Colors used to draw the buttons
        /// </summary>
        [Description("Colors used to draw the buttons"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color[] ButtonColors
        {
            get => _colors;
            set
            {
                _colors = value;
                for (int i = 0; i < _buttons.Length; i++)
                    _buttons[i].Color = _colors.Length == 0 ? Color.White : (_colors.Length > i ? _colors[i] : Color.White);
            }
        }

        /// <summary>
        /// Frequencies used for the buttons
        /// </summary>
        [Description("Frequencies used for the buttons"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float[] ButtonFrequencies
        {
            get => _frequencies;
            set
            {
                _frequencies = value;
                for (int i = 0; i < _buttons.Length; i++)
                    _buttons[i].Frequency = _frequencies.Length == 0 ? 0.0f : (_frequencies.Length > i ? _frequencies[i] : 0.0f);
            }
        }

        /// <summary>
        /// List with default color and frequency values for buttons
        /// </summary>
        [Description("List with default color and frequency values for buttons"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public List<(int Value, float Frequency, string Color)> DefaultButtonList
        {
            get => _defButtons;
            set => _defButtons = value;
        }

        #endregion

        /*
            Blue 	2	400	196
            Green	0	400	392
            Red 	1	400	330
            Yellow	3	400	262
         */

        // Constructor de la clase
        public CustomBoard()
        {

            InitializeComponent();

            this.DoubleBuffered = true;
            // To ensure that your control is redrawn every time it is resized
            // https://msdn.microsoft.com/en-us/library/b818z6z6(v=vs.110).aspx
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //SetStyle(ControlStyles.ResizeRedraw, true);
            this.ResizeRedraw = false;

            // Get the minimum dimension of the client area
            // Set the array of buttons to 0 elements
            _buttons = new SimonSays.SimonButton[0];
            _colors = new Color[0];
            _frequencies = new float[0];
            //CreateButtons();

            //_nDimension = Math.Min(this.ClientRectangle.Height, this.ClientRectangle.Width);
            //AlignControls();

            _defButtons = new List<(int Value, float Frequency, string Color)>
            {
                (0, 196, "FF0000FF"),   // Blue
                (1, 262, "FFFFFF00"),   // Yellow
                (2, 392, "FF00FF00"),   // Green
                (3, 330, "FFFF0000"),   // Red
                (4, 275, "FFc71585"),
                (5, 275, "FF800080"),
                (6, 275, "FF8a2be2"),
                (7, 275, "FF0d98ba"),
                (8, 275, "FF9acd32"),
                (9, 275, "FFffa500")
            };

        }

        private void CreateButtons()
        {
            // Delete previous buttons if any
            this.SuspendLayout();
            DeleteButtons();

            _buttons = new SimonSays.SimonButton[_nButtons];

            // Get the minimum dimension of the client area
            _nMinDimension = Math.Min(this.ClientRectangle.Height, this.ClientRectangle.Width);
            ButtonsOffsetParameters();

            var rotation = 360f / _nButtons;
            var location = new Point((this.Width - _nMinDimension) / 2, (this.Height - _nMinDimension) / 2);        // The top-left coordinate of the buttons
            //var centerRot = new PointF(location.X + _nMinDimension / 2.0f, location.Y + _nMinDimension / 2.0f);
            var centerRot = new PointF(_nMinDimension / 2.0f, _nMinDimension / 2.0f);
            var centerBut = new PointF(_fApothem + centerRot.X, _fPolySide / 2.0f + centerRot.Y);

            for (int i = 0; i < _nButtons; i++)
            {
                _buttons[i] = new SimonSays.SimonButton()
                {
                    //Anchor = AnchorStyles.Top | AnchorStyles.Left |AnchorStyles.Right |AnchorStyles.Bottom,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    AutoSize =false,     // https://www.techrepublic.com/article/manage-winform-controls-using-the-anchor-and-dock-properties/
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Color = _colors.Length == 0 ? Color.White : (_colors.Length > i ? _colors[i] : Color.White),
                    Frequency = _frequencies.Length == 0 ? 0.0f : (_frequencies.Length > i ? _frequencies[i] : 0.0f),
                    Location = location,
                    Size = new Size(_nMinDimension, _nMinDimension),
                    //CenterRotation = new PointF(this.Width / 2.0f, this.Height / 2.0f),
                    CenterRotation = centerRot,
                    //CenterButton = new PointF(this.Width / 2.0f, this.Height / 2.0f),
                    CenterButton = centerBut,
                    ClickOffset = new PointF(2 * (float)Math.Cos((rotation / 2) * Math.PI / 180), 2 * (float)Math.Sin((rotation / 2) * Math.PI / 180)),
                    InnerRadius = (_fInnerButton * _fOuterCircle * _nMinDimension / 2f) - (_fRadiusOffset),
                    OuterRadius = (_fOuterButton * _fOuterCircle * _nMinDimension / 2f) - (_fRadiusOffset),
                    AngleRotation = i * rotation + _fRotation,
                    AngleSwept = rotation,
                    Value = i
                };
                //_buttons[i].Size = new Size(this.Width, this.Height);
                _buttons[i].Click += new System.EventHandler(this.CustomButton_Click);
                //_buttons[i].Frequency = 0;
                //_buttons[i].Color = Color.White;
                this.Controls.Add(_buttons[i]);
            }

            this.ResumeLayout();

        }

        private void DeleteButtons()
        {
            // Delete previous buttons if any
            // https://stackoverflow.com/questions/4630391/get-all-controls-of-a-specific-type

            int i = 0;

            while (i < _buttons.Length)
            {
                _buttons[i].Click -= new System.EventHandler(this.CustomButton_Click);
                this.Controls.Remove(_buttons[i]);
                _buttons[i].Dispose();
                i++;
            }

            //Array.Clear(_buttons, 0, _buttons.Length);
            //_buttons = new SimonSays.SimonButton[0];
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //AlignControls();
            Rectangle rc = e.ClipRectangle; // This only returns the visible rectangle of the client area!
            Graphics dc = e.Graphics;
            dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Brush solidBrush;

            // Draw back clip rectangle
            solidBrush = new SolidBrush(_BackgroundColor);
            dc.FillRectangle(solidBrush, rc);

            ComputeBoardRectangles();

            // Draw outer circle
            solidBrush = new SolidBrush(_OuterColor);
            dc.FillEllipse(solidBrush, _OuterRect);

            // Draw inner circle
            solidBrush = new SolidBrush(_InnerColor);
            dc.FillEllipse(solidBrush, _InnerRect);

            // Dispose
            solidBrush.Dispose();
            //AlignControls();

        }

        protected override void OnResize(EventArgs e)
        {
            //this.SuspendLayout();

            base.OnResize(e);

            System.Diagnostics.Debug.WriteLine("Board OnResize 1 — Values: "+ String.Join(", ", _buttons.Select(c => c.Value).ToArray()));
            //System.Diagnostics.Debug.WriteLine("Board OnResize 1 — AngleRotation: " + String.Join(", ", _buttons.Select(c => c.AngleRotation).ToArray()));
            
            //Invalidate();
            AlignLabels();

            // Get the minimum dimension of the client area
            _nMinDimension = Math.Min(this.ClientRectangle.Height, this.ClientRectangle.Width);
            //ComputeBoardRectangles();

            ButtonsOffsetParameters();
            if (this.Handle != null) BeginInvoke(new MethodInvoker(ResizeButtons));
            //ResizeButtons();
            // https://sysadmins.lv/retired-msft-blogs/alejacma/controls-wont-get-resized-once-the-nesting-hierarchy-of-windows-exceeds-a-certain-depth-x64.aspx
            // https://docs.microsoft.com/es-es/archive/blogs/alejacma/controls-wont-get-resized-once-the-nesting-hierarchy-of-windows-exceeds-a-certain-depth-x64

            Invalidate();
            //Update();
            this.ResumeLayout();

            System.Diagnostics.Debug.WriteLine("Board OnResize 2 — Values: " + String.Join(", ", _buttons.Select(c => c.Value).ToArray()));
            //System.Diagnostics.Debug.WriteLine("Board OnResize 2 — AngleRotation: " + String.Join(", ", _buttons.Select(c => c.AngleRotation).ToArray()));
        }

        /// <summary>
        /// Computes the offset parameters for the buttons
        /// </summary>
        private void ButtonsOffsetParameters()
        {
            _fApothem = _fCenterButton * _fOuterCircle * _nMinDimension / 2;
            _fPolySide = SideLength(_nButtons, _fApothem);
            _fRadiusOffset = (float)Math.Sqrt(Math.Pow(_fApothem, 2) + Math.Pow(_fPolySide / 2, 2));
        }

        /// <summary>
        /// Resizes and repositions the buttons
        /// </summary>
        private void ResizeButtons()
        {
            var location = new Point((this.Width - _nMinDimension) / 2, (this.Height - _nMinDimension) / 2);        // The top-left coordinate of the buttons
            //var centerRot = new PointF(location.X + _nMinDimension / 2.0f, location.Y + _nMinDimension / 2.0f);
            var centerRot = new PointF(_nMinDimension / 2.0f, _nMinDimension / 2.0f);
            //var centerBut = new PointF(_fApothem + centerRot.X, SideLength(_nButtons, _fApothem) / 2.0f + centerRot.Y);
            var centerBut = new PointF(_fApothem + centerRot.X, _fPolySide / 2.0f + centerRot.Y);
            float outRad = (_fOuterButton * _fOuterCircle * _nMinDimension / 2f) - (_fRadiusOffset);
            float inRad = (_fInnerButton * _fOuterCircle * _nMinDimension / 2f) - (_fRadiusOffset);

            //this.SuspendLayout();
            
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].Location = location;
                //_buttons[i].Left = location.X;
                //_buttons[i].Top = location.Y;
                _buttons[i].Size = new Size(_nMinDimension, _nMinDimension);
                //_buttons[i].Width = _nMinDimension;
                //_buttons[i].Height = _nMinDimension;
                _buttons[i].OuterRadius = outRad;
                _buttons[i].InnerRadius = inRad;
                _buttons[i].CenterRotation = centerRot;
                _buttons[i].CenterButton = centerBut;
                
                // Force rapainting. Otherwise region might be outside ClientRectangle and thus the OnPaint event is not fired.
                _buttons[i].RePaint();
            }
            
            this.ResumeLayout();

        }

        private void CustomButton_Click(object sender, EventArgs e)
        {
            //_Game.OnPress(((ColorButton.customButton)sender).ColorValue);
            //MessageBox.Show("Botón pulsado");
            // Call the function to generate the event
            OnButtonClick(new ButtonClickEventArgs(((SimonSays.SimonButton)sender).Value));
            
        }

        /// <summary>
        /// Compute the parameters used to paint the board and buttons within the control
        /// </summary>
        public void ComputeBoardRectangles()
        {
            // Get the minimum dimension of the client area
            _nMinDimension = Math.Min(this.ClientRectangle.Height, this.ClientRectangle.Width);

            // Find out the dimensions of the outer and the inner circle rectangle
            _OuterRect.X = (int)((this.ClientRectangle.Width - _fOuterCircle * _nMinDimension) / 2);
            _OuterRect.Y = (int)((this.ClientRectangle.Height - _fOuterCircle * _nMinDimension) / 2);
            _OuterRect.Width = (int)(_fOuterCircle * _nMinDimension);
            _OuterRect.Height = (int)(_fOuterCircle * _nMinDimension);
            
            _InnerRect.X = (int)((this.ClientRectangle.Width - _fInnerCircle * _nMinDimension) / 2);
            _InnerRect.Y = (int)((this.ClientRectangle.Height - _fInnerCircle * _nMinDimension) / 2);
            _InnerRect.Width = (int)(_fInnerCircle * _nMinDimension);
            _InnerRect.Height = (int)(_fInnerCircle * _nMinDimension);

            // Find out the dimensions of the button rectangle
            //_ButtonRect.X = _OuterRect.X - this.btnGreen.OffSetX;
            //_ButtonRect.Y = _OuterRect.Y - this.btnGreen.OffSetY;
            _ButtonRect.Width = (int)Math.Round(Math.Sqrt(2.0) * _fOuterCircle * _nMinDimension / 2);
            _ButtonRect.Height = (int)Math.Round(Math.Sqrt(2.0) * _fOuterCircle * _nMinDimension / 2);

        }

        /// <summary>
        /// Aligns all the controls
        /// </summary>
        private void AlignLabels()
        {
            // First compute the location and dimension parameters
            // ComputeBoardRectangles();

            // Score text boxes
            lblScoreCurrent.Location = new Point((this.ClientRectangle.Width - lblScoreCurrent.Width) / 2, this.ClientRectangle.Height / 2 - lblScoreCurrent.Height);
            lblScoreTotal.Location = new Point((this.ClientRectangle.Width - lblScoreTotal.Width) / 2, this.ClientRectangle.Height / 2 );
        }

        /// <summary>
        /// Computes the apothem of a n-sided regular polygon
        /// </summary>
        /// <param name="Sides">Number of sides of the regular polygon</param>
        /// <param name="SideLength">Length (pixels) of each side</param>
        /// <returns></returns>
        private float Apothem(int Sides, float SideLength)
        {
            return SideLength / (float)(2.0 * Math.Tan(Math.PI / Sides));
        }

        /// <summary>
        /// Computes the side-length of a n-sided regular polygon
        /// </summary>
        /// <param name="Sides">Number of sides of the regular polygon</param>
        /// <param name="Apothem">Apothem of the n-sided regular polygon</param>
        /// <returns></returns>
        private float SideLength(int Sides, float Apothem)
        {
            return Apothem * (float)(2.0 * Math.Tan(Math.PI / Sides));
        }

    }

}
