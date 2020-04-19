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

namespace CustomBoard
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))] 
    public partial class CustomBoard : UserControl
    {
        #region Variable definitions
        private Int32 _nHighest = 0;
        private Int32 _nScore = 0;
        
        // Definición de los botones
        private Int32 _nDimension = 0;
        private float _fOuterCircle = 0.9f;
        private float _fInnerCircle = 0.35f;
        private Rectangle _OuterRect = new Rectangle();
        private Rectangle _InnerRect = new Rectangle();
        private Rectangle _ButtonRect = new Rectangle();
        private Color _BackgroundColor = new Color();
        private Color _OuterColor = new Color();
        private Color _InnerColor = new Color();
        
        //public ButtonColor _ButtonColor = new ButtonColor();
        //public ButtonRotation _ButtonRotation = new ButtonRotation();
        //public ButtonFrequency _ButtonFrequency = new ButtonFrequency();

        public event EventHandler<ButtonClickEventArgs> ButtonClick;

        #endregion

        #region Public interface

        // Interfaz pública de las propiedades del control
        // https://msdn.microsoft.com/en-us/library/system.componentmodel.notifyparentpropertyattribute.aspx
        [Description("Green button properties"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorButton.SimonButton GreenButton
        {
            get { return this.btnGreen; }
            set { this.btnGreen = value; }
        }

        [Description("Red button properties"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorButton.SimonButton RedButton
        {
            get { return this.btnRed; }
            set { this.btnRed = value; }
        }

        [Description("Yellow button properties"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorButton.SimonButton YellowButton
        {
            get { return this.btnYellow; }
            set { this.btnYellow = value; }
        }

        [Description("Blue button properties"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorButton.SimonButton BlueButton
        {
            get { return this.btnBlue; }
            set { this.btnBlue = value; }
        }


        [TypeConverter(typeof(ButtonColorConverter))]
        public class ButtonColor
        {
            private Color _Green;
            private Color _Red;
            private Color _Blue;
            private Color _Yellow;

            [Description("Numeric value representing the green color"),
            Browsable(true),
            NotifyParentProperty(true),
            EditorBrowsable(EditorBrowsableState.Always),
            DefaultValue(typeof(Color), "Green")]
            public Color Green { get { return _Green; } set { _Green = value; } }
            
            [Description("Numeric value representing the red color"),
            Browsable(true),
            NotifyParentProperty(true),
            EditorBrowsable(EditorBrowsableState.Always),
            DefaultValue(typeof(Color), "Red")]
            public Color Red { get { return _Red; } set { _Red = value; } }

            [Description("Numeric value representing the yellow color"),
            Browsable(true),
            NotifyParentProperty(true),
            EditorBrowsable(EditorBrowsableState.Always),
            DefaultValue(typeof(Color), "")]
            public Color Yellow { get { return _Yellow; } set { _Yellow = value; } }

            [Description("Numeric value representing the blue color"),
            Browsable(true),
            NotifyParentProperty(true),
            EditorBrowsable(EditorBrowsableState.Always),
            DefaultValue(typeof(Color), "")]
            public Color Blue { get { return _Blue; } set { _Blue = value; } }

            public override string ToString()
            {
                return "Button fore colors";
            }
        }

        [TypeConverter(typeof(ButtonColorConverter))]
        public class ButtonRotation
        {
            [Description("Rotation of the green button"),
            Browsable(true),
            NotifyParentProperty(true),
            EditorBrowsable(EditorBrowsableState.Always),
            DefaultValue(typeof(Int32), "")]
            public Int32 Green { get; set; }

            [Description("Rotation of the red button"),
            Browsable(true),
            NotifyParentProperty(true),
            EditorBrowsable(EditorBrowsableState.Always),
            DefaultValue(typeof(Int32), "")]
            public Int32 Red { get; set; }

            [Description("Rotation of the yellow button"),
            Browsable(true),
            NotifyParentProperty(true),
            EditorBrowsable(EditorBrowsableState.Always),
            DefaultValue(typeof(Int32), "")]
            public Int32 Yellow { get; set; }

            [Description("Rotation of the blue button"),
            Browsable(true),
            NotifyParentProperty(true),
            EditorBrowsable(EditorBrowsableState.Always),
            DefaultValue(typeof(Int32), "")]
            public Int32 Blue { get; set; }
        }

        [TypeConverter(typeof(ButtonColorConverter))]
        public class ButtonFrequency
        {
            private Int32 _Green;
            private Int32 _Red;
            private Int32 _Yellow;
            private Int32 _Blue;

            [Description("Frequency of the green button"),
            Browsable(true),
            NotifyParentProperty(true),
            EditorBrowsable(EditorBrowsableState.Always),
            DefaultValue(typeof(Int32), "")]
            public Int32 Green { get { return _Green; } set { _Green = value; } }

            [Description("Frequency of the red button"),
            Browsable(true),
            NotifyParentProperty(true),
            EditorBrowsable(EditorBrowsableState.Always),
            DefaultValue(typeof(Int32), "")]
            public Int32 Red { get { return _Red; } set { _Red = value; } }

            [Description("Frequency of the yellow button"),
            Browsable(true),
            NotifyParentProperty(true),
            EditorBrowsable(EditorBrowsableState.Always),
            DefaultValue(typeof(Int32), "")]
            public Int32 Yellow { get { return _Yellow; } set { _Yellow = value; } }

            [Description("Frequency of the blue button"),
            Browsable(true),
            NotifyParentProperty(true),
            EditorBrowsable(EditorBrowsableState.Always),
            DefaultValue(typeof(Int32), "")]
            public Int32 Blue { get { return _Blue; } set { _Blue = value; } }
        }

        [Description("Percentage of the board outer ratio"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public float PercentOuterRatio
        {
            get { return _fOuterCircle; }
            set { _fOuterCircle = value; AlignControls(); Invalidate(); }
        }

        [Description("Percentage of the board inner ratio"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public float PercentInnerRatio
        {
            get { return _fInnerCircle; }
            set { _fInnerCircle = value; AlignControls(); Invalidate(); }
        }

        [Description("Rectangle defining the outer board circle"),
        Category("Custom"),
        Browsable(true)]
        public Rectangle OuterRectangle
        {
            get { return _OuterRect; }
        }

        [Description("Rectangle defining the inner board circle"),
        Category("Custom"),
        Browsable(true)]
        public Rectangle InnerRectangle
        {
            get { return _InnerRect; }
        }

        [Description("Rectangle defining the boundaries of the button"),
        Category("Custom"),
        Browsable(true)]
        public Rectangle ButtonRectangle
        {
            get { return _ButtonRect; }
        }

        [Description("Minimum dimension (height or width) of the control"),
        Category("Custom"),
        Browsable(true)]
        public int MinimumDimension
        {
            get { return _nDimension; }
        }

        [Description("Background color of the control"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always)]
        public Color ColorBackground
        {
            get { return _BackgroundColor; }
            set { _BackgroundColor = value; Invalidate(); }
        }

        [Description("Outer circle color"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always)]
        public Color ColorOuterCircle
        {
            get { return _OuterColor; }
            set { _OuterColor = value; Invalidate(); }
        }

        [Description("Inner circle color"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always)]
        public Color ColorInnerCircle
        {
            get { return _InnerColor; }
            set { _InnerColor = value; Invalidate(); }
        }

        [Description("Maximum score"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always)]
        public Int32 ScoreHighest
        {
            get { return _nHighest; }
            set { _nHighest = value; lblScoreTotal.Text = String.Concat("Highest: ", value); }
        }

        [Description("Current score"),
        Category("Custom"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always)]
        public Int32 ScoreTotal
        {
            get { return _nScore; }
            set { _nScore = value; lblScoreCurrent.Text = String.Concat("Score: ", value); }
        }
        #endregion

        // Constructor de la clase
        public CustomBoard()
        {

            InitializeComponent();

            this.DoubleBuffered = true;
            // To ensure that your control is redrawn every time it is resized
            // https://msdn.microsoft.com/en-us/library/b818z6z6(v=vs.110).aspx
            SetStyle(ControlStyles.ResizeRedraw, true);

            this.btnGreen.Click += new System.EventHandler(this.CustomButton_Click);
            this.btnRed.Click += new System.EventHandler(this.CustomButton_Click);
            this.btnYellow.Click += new System.EventHandler(this.CustomButton_Click);
            this.btnBlue.Click += new System.EventHandler(this.CustomButton_Click);
            /*
            btnGreen.Clicked = false;
            btnGreen.ColorValue = 0;
            btnGreen.Duration = 400;
            btnGreen.Frequency = 392;
            btnGreen.OuterAngleSpan = 0.0f;
            btnGreen.Rotation = 0;
            btnGreen.WidthPercentage = 0.99f;
            btnGreen.ForeColor = System.Drawing.Color.Green;

            btnRed.Clicked = false;
            btnRed.ColorValue = 1;
            btnRed.Duration = 400;
            btnRed.Frequency = 330;
            btnRed.OuterAngleSpan = 0.0f;
            btnRed.Rotation = 90;
            btnRed.WidthPercentage = 0.5f;
            btnRed.ForeColor = System.Drawing.Color.Red;

            btnBlue.Clicked = false;
            btnBlue.ColorValue = 2;
            btnBlue.Duration = 400;
            btnBlue.Frequency = 196;
            btnBlue.OuterAngleSpan = 0.0f;
            btnBlue.Rotation = 180;
            btnBlue.WidthPercentage = 0.5f;
            btnBlue.ForeColor = System.Drawing.Color.Blue;

            btnYellow.Clicked = false;
            btnYellow.ColorValue = 3;
            btnYellow.Duration = 400;
            btnYellow.Frequency = 262;
            btnYellow.OuterAngleSpan = 0.0f;
            btnYellow.Rotation = 270;
            btnYellow.WidthPercentage = 0.5f;
            btnYellow.ForeColor = System.Drawing.Color.Yellow;
            */
            //_nDimension = Math.Min(this.ClientRectangle.Height, this.ClientRectangle.Width);
            AlignControls();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            AlignControls();
            Rectangle rc = e.ClipRectangle; // This only returns the visible rectangle of the client area!
            Graphics dc = e.Graphics;
            dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            /*
            // Define and calculate size variables
            //Int32 nHeight = rc.Bottom - rc.Top - 50;
            //Int32 nWidth = rc.Width - 50;
            //_nDimension = Math.Min(rc.Width, rc.Height);
            //float _fOuterCircle = 0.9f;
            //float _fInnerCircle = 0.35f;
            Brush solidBrush = new SolidBrush(Color.FromArgb(100, 100, 240));
            
            // Draw back clip rectangle
            dc.FillRectangle(solidBrush, rc);
            ComputeParameters();
            // Draw board elements
            solidBrush = new SolidBrush(Color.FromArgb(40, 40, 40));
            dc.FillEllipse(
                solidBrush,
                (float)((this.ClientRectangle.Width - _fOuterCircle * _nDimension) / 2),
                (float)((this.ClientRectangle.Height - _fOuterCircle * _nDimension) / 2),
                (float)(_fOuterCircle * _nDimension),
                (float)(_fOuterCircle * _nDimension)
                );

            solidBrush = new SolidBrush(Color.FromArgb(240, 240, 240));
            dc.FillEllipse(
                solidBrush,
                (float)((rc.Width - _fInnerCircle * _nDimension) / 2),
                (float)((rc.Height - _fInnerCircle * _nDimension) / 2),
                (float)(_fInnerCircle * _nDimension),
                (float)(_fInnerCircle * _nDimension)
                );*/


            Brush solidBrush;

            // Draw back clip rectangle
            solidBrush = new SolidBrush(_BackgroundColor);
            dc.FillRectangle(solidBrush, rc);

            // Draw outer circle
            ComputeParameters();
            solidBrush = new SolidBrush(_OuterColor);
            dc.FillEllipse(solidBrush, _OuterRect);

            // Draw inner circle
            solidBrush = new SolidBrush(_InnerColor);
            dc.FillEllipse(solidBrush, _InnerRect);

            // Dispose
            solidBrush.Dispose();
            AlignControls();

        }

        protected override void OnResize(EventArgs e)
        {
            //Invalidate();
            //AlignControls();
            Invalidate();
            base.OnResize(e);
            /*
            Int32 _nSize;
            
            _nDimension = Math.Min(this.ClientRectangle.Height, this.ClientRectangle.Width);
            _nSize = (Int32)Math.Round(Math.Sqrt(2.0) * (_fOuterCircle - 0) * _nDimension / 2);
            
            btnGreen.Location = new Point(0, 0);
            btnRed.Location = new Point(this.ClientRectangle.Width - _nDimension / 2, 0);
            btnBlue.Location = new Point(this.ClientRectangle.Width - _nDimension / 2, this.ClientRectangle.Height - _nDimension / 2);
            btnYellow.Location = new Point(0, this.ClientRectangle.Height - _nDimension / 2);

            btnGreen.Height = _nSize;
            btnGreen.Width = _nSize;
            btnRed.Height = _nSize;
            btnRed.Width = _nSize;
            btnYellow.Height = _nSize;
            btnYellow.Width = _nSize;
            btnBlue.Height = _nSize;
            btnBlue.Width = _nSize;

            btnGreen.Location = new Point((Int32)(this.ClientRectangle.Width - _fOuterCircle * _nDimension) / 2 - btnGreen.OffSetX, (Int32)(this.ClientRectangle.Height - _fOuterCircle * _nDimension) / 2 - btnGreen.OffSetY);
            btnRed.Location = new Point((Int32)(this.ClientRectangle.Width - (this.ClientRectangle.Width - _fOuterCircle * _nDimension) / 2 + btnRed.OffSetX - btnRed.Width), (Int32)(this.ClientRectangle.Height - _fOuterCircle * _nDimension) / 2 - btnGreen.OffSetY);
            btnYellow.Location = new Point((Int32)(this.ClientRectangle.Width - _fOuterCircle * _nDimension) / 2 - btnGreen.OffSetX, (Int32)(this.ClientSize.Height - ((this.ClientRectangle.Height - _fOuterCircle * _nDimension) / 2) + btnYellow.OffSetY - btnYellow.Height));
            btnBlue.Location = new Point((Int32)(this.ClientRectangle.Width - (this.ClientRectangle.Width - _fOuterCircle * _nDimension) / 2 + btnBlue.OffSetX - btnBlue.Width), (Int32)(this.ClientSize.Height - ((this.ClientRectangle.Height - _fOuterCircle * _nDimension) / 2) + btnBlue.OffSetY - btnBlue.Height));
            */

            /*
            btnGreen.Size = new Size(_nDimension / 2, _nDimension / 2);
            btnRed.Size = new Size(_nDimension / 2, _nDimension / 2);
            btnYellow.Size = new Size(_nDimension / 2, _nDimension / 2);
            btnBlue.Size = new Size(_nDimension / 2, _nDimension / 2);
            */
        }

        private void CustomButton_Click(object sender, EventArgs e)
        {
            //_Game.OnPress(((ColorButton.customButton)sender).ColorValue);
            //MessageBox.Show("Botón pulsado");
            // Call the function to generate the event
            OnButtonClick(new ButtonClickEventArgs(((ColorButton.SimonButton)sender).ColorValue));
            
        }

        protected virtual void OnButtonClick(ButtonClickEventArgs e)
        {
            if (ButtonClick != null) ButtonClick(this, e);
        }

        /// <summary>
        /// Compute the parameters used to paint the board and buttons within the control
        /// </summary>
        public void ComputeParameters()
        {
            // Get the minimum dimension of the client area
            _nDimension = Math.Min(this.ClientRectangle.Height, this.ClientRectangle.Width);

            // Find out the dimensions of the outer and the inner circle rectangle
            _OuterRect.X = (int)((this.ClientRectangle.Width - _fOuterCircle * _nDimension) / 2);
            _OuterRect.Y = (int)((this.ClientRectangle.Height - _fOuterCircle * _nDimension) / 2);
            _OuterRect.Width = (int)(_fOuterCircle * _nDimension);
            _OuterRect.Height = (int)(_fOuterCircle * _nDimension);
            
            _InnerRect.X = (int)((this.ClientRectangle.Width - _fInnerCircle * _nDimension) / 2);
            _InnerRect.Y = (int)((this.ClientRectangle.Height - _fInnerCircle * _nDimension) / 2);
            _InnerRect.Width = (int)(_fInnerCircle * _nDimension);
            _InnerRect.Height = (int)(_fInnerCircle * _nDimension);

            // Find out the dimensions of the button rectangle
            _ButtonRect.X = _OuterRect.X - this.btnGreen.OffSetX;
            _ButtonRect.Y = _OuterRect.Y - this.btnGreen.OffSetY;
            _ButtonRect.Width = (int)Math.Round(Math.Sqrt(2.0) * _fOuterCircle * _nDimension / 2);
            _ButtonRect.Height = (int)Math.Round(Math.Sqrt(2.0) * _fOuterCircle * _nDimension / 2);

        }

        /// <summary>
        /// Aligns all the controls
        /// </summary>
        private void AlignControls()
        {
            // First compute the location and dimension parameters
            ComputeParameters();

            // Reposition and resize the buttons
            btnGreen.Location = new Point(_ButtonRect.X, _ButtonRect.Y);
            btnGreen.Size = new Size(_ButtonRect.Width, _ButtonRect.Height);

            btnRed.Location = new Point(_ButtonRect.X + (int)(_OuterRect.Width / 2), _ButtonRect.Y);
            btnRed.Size = new Size(_ButtonRect.Width, _ButtonRect.Height);

            btnYellow.Location = new Point(_ButtonRect.X, _ButtonRect.Y + (int)(_OuterRect.Height / 2));
            btnYellow.Size = new Size(_ButtonRect.Width, _ButtonRect.Height);

            btnBlue.Location = new Point(_ButtonRect.X + (int)(_OuterRect.Width / 2), _ButtonRect.Y + (int)(_OuterRect.Height / 2));
            btnBlue.Size = new Size(_ButtonRect.Width, _ButtonRect.Height);

            // Score text boxes
            lblScoreCurrent.Location = new Point((this.ClientRectangle.Width - lblScoreCurrent.Width) / 2, this.ClientRectangle.Height / 2 - lblScoreCurrent.Height);
            lblScoreTotal.Location = new Point((this.ClientRectangle.Width - lblScoreTotal.Width) / 2, this.ClientRectangle.Height / 2 );
        }
        
    }


    /// <summary>
    /// Class to send the event data to the "listener"
    /// </summary>
    public class ButtonClickEventArgs : EventArgs
    {
        public readonly Int32 ButtonValue;
        public ButtonClickEventArgs(Int32 button) { ButtonValue = button; }
    }

    /*
    public class StandardValuesIntConverter : System.ComponentModel.TypeConverter
    {
        public override bool GetPropertiesSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        }
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(CustomBoard.ColoresBotones));
        }
        // This override prevents the PropertyGrid from 
        // displaying the full type name in the value cell.
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return "";
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        
        private ArrayList values;
        public StandardValuesIntConverter()
        {
            // Initializes the standard values list with defaults.
            values = new ArrayList(new Color[] { Color.FromArgb(0, 0, 0), Color.FromArgb(0, 0, 0), Color.FromArgb(0, 0, 0), Color.FromArgb(0, 0, 0) });
        }

        // Indicates this converter provides a list of standard values.
        public override bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        }

        // Returns a StandardValuesCollection of standard value objects.
        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {
            // Passes the local integer array.
            StandardValuesCollection svc =
                new StandardValuesCollection(values);
            return svc;
        }

        // Returns true for a sourceType of string to indicate that 
        // conversions from string to integer are supported. (The 
        // GetStandardValues method requires a string to native type 
        // conversion because the items in the drop-down list are 
        // translated to string.)
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType)
        {
            if (sourceType == typeof())
                return true;
            else
                return base.CanConvertFrom(context, sourceType);
        }

        // If the type of the value to convert is string, parses the string 
        // and returns the integer to set the value of the property to. 
        // This example first extends the integer array that supplies the 
        // standard values collection if the user-entered value is not 
        // already in the array.
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value.GetType() == typeof(string))
            {
                // Parses the string to get the integer to set to the property.
                int newVal = int.Parse((string)value);

                // Tests whether new integer is already in the list.
                if (!values.Contains(newVal))
                {
                    // If the integer is not in list, adds it in order.
                    values.Add(newVal);
                    values.Sort();
                }
                // Returns the integer value to assign to the property.
                return newVal;
            }
            else
                return base.ConvertFrom(context, culture, value);
        }
        */



    public class ButtonColorConverter : ExpandableObjectConverter
    {
        // This override prevents the PropertyGrid from displaying the full type name in the value cell.
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value.GetType() == typeof(CustomBoard.ButtonColor))
                    return "Button fore colors";
                else if (value.GetType() == typeof(CustomBoard.ButtonRotation))
                    return "Rotation angles";
                else if (value.GetType() == typeof(CustomBoard.ButtonFrequency))
                    return "Frequencies (Hz)";
                else
                    return "";
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        /*public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            MessageBox.Show("Propiedad cambiada");
            if (value.GetType() == typeof(CustomBoard.ButtonColor))
                return TypeDescriptor.GetProperties(typeof(CustomBoard.ButtonColor));
            else if (value.GetType() == typeof(CustomBoard.ButtonRotation))
                return TypeDescriptor.GetProperties(typeof(CustomBoard.ButtonRotation));
            else if (value.GetType() == typeof(CustomBoard.ButtonFrequency))
                return TypeDescriptor.GetProperties(typeof(CustomBoard.ButtonFrequency));
            else
                return base.GetProperties(context, value, attributes);            
        }*/
    }


}
