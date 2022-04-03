namespace SimonSays;

class SimonGame
{
    private const int MAX_SEQUENCE = 100000;

    #region Variable definitions
    private Int32 _nNumButts = 0;
    private Int32[] _sequence;
    private Int32 _nCounter = 0;
    private readonly int[,] _arrayTimeSeq;
    private readonly System.Timers.Timer _timer;

    [Flags]
    public enum PlayMode
    {
        TimeIncremental = 1 << 0,   // 1
        TimeWaiting = 1 << 1,       // 2
        SimonClassic = 1 << 2,      // 4
        PlayerAdds = 1 << 3,        // 8
        ChooseYourColor = 1 << 4,   // 16
        SimonBounce = 1 << 5,       // 32
        SimonSurprise = 1 << 6,     // 64
        SimonRewind = 1 << 7,       // 128
        SimonRandom = 1 << 8        // 256
    }

    public event EventHandler<TickEventArgs> Tick;
    public event EventHandler<WrongEventArgs> WrongSequence;
    public event EventHandler<CorrectEventArgs> CorrectSequence;
    public event EventHandler<OverEventArgs> GameOver;
    
    /// <summary>
    /// Number of buttons to generate the random sequence
    /// </summary>
    public Int32 NumberOfButtons
    {
        get => _nNumButts;
        set { _nNumButts = value < 0 ? 0 : value;}
    }

    /// <summary>
    /// The partial score while the user is still reproducing the sequence
    /// </summary>
    public Int32 ScoreTotal { get; private set; } = 0;

    /// <summary>
    /// The highest score during the whole time the user is playing the game
    /// </summary>
    public Int32 ScoreHighest { get; private set; } = 0;

    /// <summary>
    /// Milliseconds for the button flashing and sound
    /// </summary>
    public Int32 DurationFlash { get; private set; } = 420;

    /// <summary>
    /// Milliseconds between each button flashing
    /// </summary>
    public Int32 DurationBetween { get; set; } = 50;

    /// <summary>
    /// True if Simon is playing a sequence, flase otherwise
    /// </summary>
    public bool Play { get; set; } = true;

    /// <summary>
    /// True if the button is flashing
    /// </summary>
    public bool Flash { get; set; } = true;

    /// <summary>
    /// The actual play-mode selected by the user (time and sequence mode).
    /// </summary>
    public PlayMode GameMode { get; set; }

    #endregion Variable definitions


    public SimonGame()
    {
        _timer = new();
        _timer.Elapsed += TimerTick;
        _arrayTimeSeq = new int[3, 2] { { 5, 420 }, { 13, 320 }, { 31, 220 } };
    }

    public void Start()
    {
        GetNewSequence();
        ScoreTotal = 0;
        _nCounter = 0;
        Play = true; // Sets Simon to start reproducing a sequence
        Flash = true;
        DurationFlash = FindTime();
        _timer.Interval = DurationFlash;
        _timer.Enabled = true;
    }

    public void Restart()
    {
        _nCounter = 0;
        Play = true; // Sets Simon to start reproducing a sequence

        // Wait 0.5 seconds before the next sequence is played by Simon
        Task.Run(async () =>
        {
            await Task.Delay(DurationFlash);
            _timer.Interval = DurationFlash;
            _timer.Enabled = true;
        });

        if ((GameMode & PlayMode.SimonRandom) == PlayMode.SimonRandom)
            GetNewSequence(ScoreTotal + 1);

        //_timer.Interval = 200;
        //_timer.Enabled = true;
        //Start();
    }

    public void Stop()
    {
        _timer.Enabled = false; // Stops the internal timer
        Play = false;  // Stops Simon reproducing a sequence
        _nCounter = 0;  // Resets the counter to 0
    }

    /// <summary>
    /// Handle the player's button-pressing logic 
    /// </summary>
    /// <param name="buttonValue">The internal value of the button pressed by the user</param>
    public void OnPress(Int32 buttonValue)
    {
        if (Play == true) return; // If Simon is playing then exit the function

        Int32 length = _sequence.Length;
        Int32 sequence = _sequence[_nCounter];
        
        if ((GameMode & PlayMode.SimonRewind) == PlayMode.SimonRewind)
        {
            sequence = _sequence[ScoreTotal - _nCounter];
        }

        if (buttonValue == sequence)
        {
            if (_nCounter < ScoreTotal) _nCounter++;
            else
            {
                // Update the total score and find the time for the next sequence
                ScoreTotal++;
                ScoreHighest = (ScoreTotal > ScoreHighest) ? ScoreTotal : ScoreHighest;
                DurationFlash = FindTime();

                // Fire the event
                if (CorrectSequence != null) OnCorrectSequence(new CorrectEventArgs(ScoreTotal));
                // _nPlaySimon = true; // Quit control from player and pass it to Simon
                Restart();  // Pass the control to Simon and restart the sequence reproduction
            }
        }
        else // If the button pressed is incorrect
        {
            // Fire the event to finish the game
            if (GameOver != null) OnGameOver(new OverEventArgs(ScoreTotal));
            Play = true; // Quit control from player and pass it to Simon
        }
    }

    /// <summary>
    /// Internal event of the timer
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TimerTick(object sender, EventArgs e)
    {
        //Console.WriteLine("Time: {0}, ms: {1}, pause: {2}, interval: {3}", DateTime.Now.ToString("hh:mm:sss"), DateTime.Now.Millisecond.ToString(), Pause.ToString(), _timer.Interval.ToString());
        // Fire the event
        if (Tick != null) OnTick(new TickEventArgs(Flash, _sequence[_nCounter]));
        
        // The counter only increases after the light has been switched off. So does the finishing
        if (Flash == false)
        {
            _nCounter++;
            if (_nCounter > ScoreTotal) Stop();
        }

        // Change the status of the flash light and the corresponding timer interval
        Flash = !Flash;
        _timer.Interval = (Flash == false) ? DurationFlash : DurationBetween;   // 420 miliseconds flashlight and 50 miliseconds between flashes/beeps
    }

    /// <summary>
    /// Gets a new sequence of colors to be played by Simon and reproduced by the player
    /// </summary>
    private void GetNewSequence(int optionalLength = MAX_SEQUENCE)
    {
        _sequence = new int[optionalLength];

        Random rnd = new();
        for (Int32 i = 0; i < optionalLength; i++) { _sequence[i] = rnd.Next(0, _nNumButts); } // Random numbers between 0 and 3

    }

    /// <summary>
    /// Loops through the time-sequence array to determine the time for the sequence
    /// </summary>
    /// <returns>The time that corresponds to the actual score</returns>
    private int FindTime()
    {
        if ((GameMode & PlayMode.TimeIncremental) != PlayMode.TimeIncremental)
        {
            return _arrayTimeSeq[0, 1];
        }

        uint i;
        for (i = 0; i < _arrayTimeSeq.GetLength(0); i++)
        {
            if (ScoreTotal < _arrayTimeSeq[i, 0]) break;
        }
        return _arrayTimeSeq[i, 1];
    }

    // Events
    protected virtual void OnTick(TickEventArgs e)
    {
        Tick?.Invoke(this, e);
    }
    protected virtual void OnWrongSequence(WrongEventArgs e)
    {
        WrongSequence?.Invoke(this, e);
    }
    protected virtual void OnCorrectSequence(CorrectEventArgs e)
    {
        CorrectSequence?.Invoke(this, e);
    }
    protected virtual void OnGameOver(OverEventArgs e)
    {
        GameOver?.Invoke(this, e);
    }

}

/// <summary>
/// Class to send the event data to the "listener"
/// </summary>
public class TickEventArgs : EventArgs
{
    public readonly bool Flash;
    public readonly Int32 ButtonValue;
    public TickEventArgs(bool flash, Int32 button)
    {
        Flash = flash;
        ButtonValue = button;
    }
}

public class WrongEventArgs : EventArgs
{
    public readonly Int32 Score;
    public WrongEventArgs(Int32 value) { Score = value; }
}
public class CorrectEventArgs : EventArgs
{
    public readonly Int32 Score;
    public CorrectEventArgs(Int32 value) { Score = value; }
}
public class OverEventArgs : EventArgs
{
    public readonly Int32 Score;
    public OverEventArgs(Int32 value) { Score = value; }
}