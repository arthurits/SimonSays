using System.Text.Json.Serialization;

namespace SimonSays;

public class ClassSettings
{
    /// <summary>
    /// Stores the settings file name
    /// </summary>
    [JsonIgnore]
    public string FileName { get; set; } = "configuration.json";

    /// <summary>
    /// Remember window position on start up
    /// </summary>
    [JsonPropertyName("Window position")]
    public bool WindowPosition { get; set; } = false;

    /// <summary>
    /// Window top-left x coordinate
    /// </summary>
    [JsonPropertyName("Window left")]
    public int WindowLeft { get; set; } = 0;
    /// <summary>
    /// Window top-left y coordinate
    /// </summary>
    [JsonPropertyName("Window top")]
    public int WindowTop { get; set; } = 0;
    /// <summary>
    /// Window width
    /// </summary>
    [JsonPropertyName("Window width")]
    public int WindowWidth { get; set; } = 644;
    /// <summary>
    /// Window height
    /// </summary>
    [JsonPropertyName("Window height")]
    public int WindowHeight { get; set; } = 461;

    /// <summary>
    /// Number of buttons
    /// </summary>
    [JsonPropertyName("Number of buttons")]
    public int NumberOfButtons { get; set; } = 4;

    /// <summary>
    /// Button colors
    /// </summary>
    [JsonPropertyName("Button colors")]
    public string ButtonColors { get; set; } = "FF0000FF-FFFFEC00-FF009540-FFFF0000";   // Blue-Yellow-Green-Red

    /// <summary>
    /// Button frequencies
    /// </summary>
    [JsonPropertyName("Button frequencies")]
    public string ButtonFrequencies { get; set; } = "196-262-392-330";

    /// <summary>
    /// Inner button ratio
    /// </summary>
    [JsonPropertyName("Inner button ratio")]
    public float InnerButtonRatio { get; set; } = 0.55f;

    /// <summary>
    /// Outer button ratio
    /// </summary>
    [JsonPropertyName("Outer button ratio")]
    public float OuterButtonRatio { get; set; } = 0.90f;

    /// <summary>
    /// Center button ratio
    /// </summary>
    [JsonPropertyName("Center button ratio")]
    public float CenterButtonRatio { get; set; } = 0.20f;

    /// <summary>
    /// Button click offset
    /// </summary>
    [JsonPropertyName("Button click offset")]
    public float ButtonClickOffset { get; set; } = 0.05f;

    /// <summary>
    /// Inner board ratio
    /// </summary>
    [JsonPropertyName("Inner board ratio")]
    public float InnerBoardRatio { get; set; } = 0.35f;

    /// <summary>
    /// Outer board ratio
    /// </summary>
    [JsonPropertyName("Outer board ratio")]
    public float OuterBoardRatio { get; set; } = 0.90f;

    /// <summary>
    /// Board rotation
    /// </summary>
    [JsonPropertyName("Board rotation")]
    public float BoardRotation { get; set; } = 0f;

    /// <summary>
    /// Background color
    /// </summary>
    [JsonPropertyName("Background color")]
    public int ColorBackground { get; set; } = System.Drawing.Color.Transparent.ToArgb();

    /// <summary>
    /// Inner circle color
    /// </summary>
    [JsonPropertyName("Inner circle color")]
    public int ColorInnerCircle { get; set; } = System.Drawing.Color.WhiteSmoke.ToArgb();

    /// <summary>
    /// Outer circle color
    /// </summary>
    [JsonPropertyName("Outer circle color")]
    public int ColorOuterCircle { get; set; } = System.Drawing.Color.Black.ToArgb();

    /// <summary>
    /// Font family name
    /// </summary>
    [JsonPropertyName("Font family")]
    public string FontFamilyName { get; set; } = "Microsoft Sans Serif";

    /// <summary>
    /// Playing mode settings
    /// </summary>
    [JsonPropertyName("Playing mode")]
    public int PlayMode { get; set; } = 7;     // TimeIncremental (1) & TimeWaiting (2) & SimonClassic (4)

    /// <summary>
    /// Sound ToolStrip button cheched?
    /// </summary>
    [JsonPropertyName("Sound checked")]
    public bool Sound { get; set; } = true;        // Soundoff unchecked
    /// <summary>
    /// Stats ToolStrip button cheched?
    /// </summary>
    [JsonPropertyName("Stats checked")]
    public bool Stats { get; set; } = false;        // Stats unchecked

    /// <summary>
    /// Default splitter distance
    /// </summary>
    [JsonPropertyName("Splitter distance")]
    public int SplitterDistance { get; set; } = 265;

    /// <summary>
    /// Time waiting
    /// </summary>
    [JsonPropertyName("Time waiting")]
    public int TimeWaiting { get; set; } = 5;

    /// <summary>
    /// Culture used throughout the app
    /// </summary>
    [JsonIgnore]
    public System.Globalization.CultureInfo AppCulture { get; set; } = System.Globalization.CultureInfo.CurrentCulture;
    /// <summary>
    /// Define the culture used throughout the app by asigning a culture string name
    /// </summary>
    [JsonPropertyName("Culture name")]
    public string AppCultureName
    {
        get { return AppCulture.Name; }
        set { AppCulture = new System.Globalization.CultureInfo(value); }
    }
    [JsonIgnore]
    public string? AppPath { get; set; } = Path.GetDirectoryName(Environment.ProcessPath);

    public ClassSettings()
    {
    }
}