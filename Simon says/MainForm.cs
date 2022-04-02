using System.Data;

//https://xamlbrewer.wordpress.com/2016/01/23/building-a-custom-uwp-control-with-xaml-and-the-composition-api/
//https://xamlbrewer.wordpress.com/2016/01/04/using-the-composition-api-in-uwp-apps/

namespace SimonSays;

public partial class frmSimon : Form
{
    private SimonGame _Game = new();
    private ClassSettings _settings = new();

    private readonly System.Resources.ResourceManager StringsRM = new("SimonSays.localization.strings", typeof(frmSimon).Assembly);

    public frmSimon()
    {
        // Set form icon
        if (System.IO.File.Exists(_settings.AppPath + @"\images\simon.ico")) this.Icon = new Icon(_settings.AppPath + @"\images\simon.ico");

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

        // Load and apply the program settings
        LoadProgramSettingsJSON();
        
    }

    #region Events subscription
    /// <summary>
    /// Consumes the Tick event of the Game class
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnGameTick(object sender, TickEventArgs e)
    {
        foreach (SimonSays.SimonButton button in simonBoard.Controls.OfType<SimonSays.SimonButton>())
        {
            if (button.Value == e.ButtonValue)
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
        
        if ((this._Game.GameMode & SimonGame.PlayMode.SimonBounce)==SimonGame.PlayMode.SimonBounce)
        {
            this.simonBoard.RandomizeButtons();
        }
        
        /*
        foreach (ColorButton.SimonButton button in simonBoard.Controls.OfType<ColorButton.SimonButton>())
        {
            button.Duration = _Game.DurationFlash;
        }
        */
    }

    private void OnGameOver(object sender, OverEventArgs e)
    {
        MessageBox.Show("Your total score is: " + e.Score.ToString(),"Game over");
        this.simonBoard.ScoreTotal = 0;
    }

    #endregion Events subscription

    #region Form events

    private void frmSimon_Load(object sender, EventArgs e)
    {
        Win32.Win32API.AnimateWindow(this.Handle, 500, Win32.Win32API.AnimateWindowFlags.AW_BLEND);
    }

    private void frmSimon_FormClosing(object sender, FormClosingEventArgs e)
    {
        using (new CenterWinDialog(this))
        {
            if (DialogResult.No == MessageBox.Show(this,
                                                    "Are you sure you want to exit\nthe application?",
                                                    "Exit?",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button2))
            {
                // Cancelar el cierre de la ventana
                e.Cancel = true;
            }
            else
                Win32.Win32API.AnimateWindow(this.Handle, 200, Win32.Win32API.AnimateWindowFlags.AW_BLEND | Win32.Win32API.AnimateWindowFlags.AW_HIDE);
        }

        // Save settings data
        SaveProgramSettingsJSON();
    }

    private void frmSimon_Shown(object sender, EventArgs e)
    {
        // Send Close event to the splash screen
        using var closeSplashEvent = new System.Threading.EventWaitHandle(false, System.Threading.EventResetMode.ManualReset, "CloseSplashScreenEvent");
        closeSplashEvent.Set();
    }

    private void frmSimon_Resize(object sender, EventArgs e)
    {
        // Force the client area to be painted again
        //Invalidate();
        //this.btnGreen.Top = 0;
        //this.btnGreen.Left = 0;
        //this.btnGreen.Height = 400;
        //this.btnGreen.Width = 400;
    }

    private void frmSimon_ResizeBegin(object sender, EventArgs e)
    {
        this.SuspendLayout();
    }

    private void frmSimon_ResizeEnd(object sender, EventArgs e)
    {
        this.ResumeLayout();
    }

    #endregion Form events

}
