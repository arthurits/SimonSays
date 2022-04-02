using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace System.Windows.Forms;

/// <summary>
/// Custom renderer for ToolBar button checked
/// https://www.discussiongenerator.com/2009/08/22/33/
/// https://stackoverflow.com/questions/2097164/how-to-change-system-windows-forms-toolstripbutton-highlight-background-color-wh
/// https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/walkthrough-creating-a-professionally-styled-toolstrip-control#implementing-a-custom-renderer
/// </summary>
public class customRenderer : ToolStripProfessionalRenderer
{
    private System.Drawing.Brush _border;
    private System.Drawing.Brush _checkedBackground;

    /// <summary>
    /// Class constructor. Sets SteelBlue and LightSkyBlue as defaults colors
    /// </summary>
    public customRenderer()
    {
        _border = System.Drawing.Brushes.SteelBlue;
        _checkedBackground = System.Drawing.Brushes.LightSkyBlue;
    }

    /// <summary>
    /// Class constructor
    /// </summary>
    /// <param name="border">Brush for the checked border</param>
    /// <param name="checkedBackground">Brush for the checked background</param>
    public customRenderer(System.Drawing.Brush border, System.Drawing.Brush checkedBackground)
    {
        _border = border;
        _checkedBackground = checkedBackground;
    }

    /// <summary>
    /// Sets and gets the border color of the checked button
    /// </summary>
    public System.Drawing.Brush BorderColor
    {
        get { return _border; }
        set { _border = value; }
    }

    /// <summary>
    /// Sets and gets the background color of the checked button
    /// </summary>
    public System.Drawing.Brush CheckedColor
    {
        get { return _checkedBackground; }
        set { _checkedBackground = value; }
    }

    protected override void OnRenderButtonBackground(System.Windows.Forms.ToolStripItemRenderEventArgs e)
    {
        // check if the object being rendered is actually a ToolStripButton
        if (e.Item is System.Windows.Forms.ToolStripButton)
        {
            System.Windows.Forms.ToolStripButton button = e.Item as System.Windows.Forms.ToolStripButton;

            // only render checked items differently
            if (button.Checked)
            {
                // fill the entire button with a color (will be used as a border)
                int buttonHeight = button.Size.Height;
                int buttonWidth = button.Size.Width;
                System.Drawing.Rectangle rectButtonFill = new System.Drawing.Rectangle(System.Drawing.Point.Empty, new Size(buttonWidth, buttonHeight));
                e.Graphics.FillRectangle(_border, rectButtonFill);

                // fill the entire button offset by 1,1 and height/width subtracted by 2 used as the fill color
                int backgroundHeight = button.Size.Height - 2;
                int backgroundWidth = button.Size.Width - 2;
                System.Drawing.Rectangle rectBackground = new System.Drawing.Rectangle(1, 1, backgroundWidth, backgroundHeight);
                e.Graphics.FillRectangle(_checkedBackground, rectBackground);
            }
            // if this button is not checked, use the normal render event
            else
                base.OnRenderButtonBackground(e);
        }
        // if this object is not a ToolStripButton, use the normal render event
        else
            base.OnRenderButtonBackground(e);
    }
}

/// <summary>
/// Declare a class that inherits from ToolStripControlHost.
/// https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-wrap-a-windows-forms-control-with-toolstripcontrolhost
/// </summary>
[System.Windows.Forms.Design.ToolStripItemDesignerAvailability(System.Windows.Forms.Design.ToolStripItemDesignerAvailability.ToolStrip)]
public class ToolStripNumericUpDown : System.Windows.Forms.ToolStripControlHost
{
    /// <summary>
    /// // Call the base constructor passing in a NumericUpDown instance.
    /// </summary>
    public ToolStripNumericUpDown() : base(new NumericUpDown())
    {
        this.Margin = new Padding(5, 0, 5, 0);
        this.NumericUpDownControl.DecimalPlaces = 0;
    }

    public NumericUpDown NumericUpDownControl
    {
        get { return Control as NumericUpDown; }
    }

    /// <summary>
    /// Subscribe and unsubscribe the ValueChanged event
    /// </summary>
    /// <param name="control"></param>
    protected override void OnSubscribeControlEvents(Control control)
    {
        base.OnSubscribeControlEvents(control);
        ((NumericUpDown)control).ValueChanged += new EventHandler(OnValueChanged);
    }

    /// <summary>
    /// Unsubscribe and unsubscribe the ValueChanged event
    /// </summary>
    /// <param name="control"></param>
    protected override void OnUnsubscribeControlEvents(Control control)
    {
        base.OnUnsubscribeControlEvents(control);
        ((NumericUpDown)control).ValueChanged -= new EventHandler(OnValueChanged);
    }

    // Declare the ValueChanged event.
    public event EventHandler ValueChanged;

    // Raise the ValueChanged event.
    public void OnValueChanged(object sender, EventArgs e)
    {
        if (ValueChanged != null) ValueChanged(this, e);
    }
}


/// <summary>
/// Subclassed RadioButton to accept double click events
/// </summary>
public class RadioButtonClick : System.Windows.Forms.RadioButton
{
    public RadioButtonClick() : base()
    {
        //InitializeComponent();

        this.SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
    }

    [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
    public new event MouseEventHandler MouseDoubleClick;

    protected override void OnMouseDoubleClick(MouseEventArgs e)
    {
        base.OnMouseDoubleClick(e);

        // raise the event
        if (this.MouseDoubleClick != null)
            this.MouseDoubleClick(this, e);
    }

    private void InitializeComponent()
    {
        this.SuspendLayout();
        this.ResumeLayout(false);

    }
}

/// <summary>
/// Tabless TabControl: shows tabs at design time and hides them at runtime
/// </summary>
public class TablessTabControl : TabControl
{
    protected override void WndProc(ref Message m)
    {
        // Hide tabs by trapping the TCM_ADJUSTRECT message
        if (m.Msg == 0x1328 && !DesignMode)
            m.Result = (IntPtr)1;
        else
            base.WndProc(ref m);
    }
}

/// <summary>
/// https://stackoverflow.com/questions/487661/how-do-i-suspend-painting-for-a-control-and-its-children
/// </summary>
public class DrawingControl
{
    [DllImport("user32.dll")]
    internal static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

    private const int WM_SETREDRAW = 11;

    public static void SuspendDrawing(Control parent)
    {
        SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
    }

    public static void ResumeDrawing(Control parent)
    {
        SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
        parent.Refresh();
    }
}
