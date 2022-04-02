using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace SimonSays;

partial class frmSimon
{
    /// <summary>
    /// Loads all settings from file _sett.FileName into class instance _settings
    /// Shows MessageBox error if unsuccessful
    /// </summary>
    private void LoadProgramSettingsJSON()
    {
        try
        {
            var jsonString = File.ReadAllText(_settings.FileName);
            _settings = JsonSerializer.Deserialize<ClassSettings>(jsonString) ?? _settings;

            ApplySettingsJSON(_settings.WindowPosition);
        }
        catch (FileNotFoundException)
        {
        }
        catch (Exception ex)
        {
            using (new CenterWinDialog(this))
            {
                MessageBox.Show(this,
                    StringsRM.GetString("strErrorDeserialize", _settings.AppCulture) ?? $"Error loading settings file.\n\n{ex.Message}\n\nDefault values will be used instead.",
                    StringsRM.GetString("strErrorDeserializeTitle", _settings.AppCulture) ?? "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>
    /// Saves data from class instance _sett into _sett.FileName
    /// </summary>
    private void SaveProgramSettingsJSON()
    {
        _settings.WindowLeft = DesktopLocation.X;
        _settings.WindowTop = DesktopLocation.Y;
        _settings.WindowWidth = ClientSize.Width;
        _settings.WindowHeight = ClientSize.Height;

        _settings.ButtonColors = String.Join("-", this.simonBoard.ButtonColors.Select(x => x.ToArgb().ToString("X")));
        _settings.ButtonFrequencies = String.Join("-", this.simonBoard.ButtonFrequencies);

        _settings.Sound = this.toolStripMain_Sound.Checked;
        _settings.Stats = this.toolStripMain_Stats.Checked;

        //_settings.SplitterDistance = this.splitStats.SplitterDistance;

        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(_settings, options);
            File.WriteAllText(_settings.FileName, jsonString);
        }
        catch (Exception ex)
        {
            using (new CenterWinDialog(this))
            {
                MessageBox.Show(this,
                                "Unexpected error while\nsaving settings data.\n\n" + ex.GetType().ToString() + "\n" + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error); ;
            }
        }
    }

    /// <summary>
    /// Update UI with settings
    /// </summary>
    /// <param name="WindowSettings">True if the window position and size should be applied. False if omitted</param>
    private void ApplySettingsJSON(bool WindowPosition = false)
    {
        if (WindowPosition)
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.DesktopLocation = new Point(_settings.WindowLeft, _settings.WindowTop);
            this.ClientSize = new Size(_settings.WindowWidth, _settings.WindowHeight);
        }

        this.simonBoard.NumberOfButtons = _settings.NumberOfButtons;
        this.simonBoard.InnerButtonRatio = _settings.InnerButtonRatio;
        this.simonBoard.OuterButtonRatio = _settings.OuterButtonRatio;
        this.simonBoard.CenterButtonRatio = _settings.CenterButtonRatio;
        //this.simonBoard.ButtonClickOffset = Convert.ToSingle(programSettings.GetOrDefault("ButtonClickOffset", defaultSettings["ButtonClickOffset"]), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

        this.simonBoard.PercentInnerRatio = _settings.InnerBoardRatio;
        this.simonBoard.PercentOuterRatio = _settings.OuterBoardRatio;
        this.simonBoard.BoardRotation = _settings.BoardRotation;
        this.simonBoard.ColorBackground = Color.FromArgb(_settings.ColorBackground);
        this.simonBoard.ColorInnerCircle = Color.FromArgb(_settings.ColorInnerCircle);
        this.simonBoard.ColorOuterCircle = Color.FromArgb(_settings.ColorOuterCircle);
        this.simonBoard.Font = new Font(_settings.FontFamilyName, simonBoard.Font.SizeInPoints);

        this.simonBoard.ButtonFrequencies = Array.ConvertAll(_settings.ButtonFrequencies.Split('-'), float.Parse);
        this.simonBoard.ButtonColors = Array.ConvertAll(_settings.ButtonColors.Split('-'), x => Color.FromArgb(int.Parse(x, System.Globalization.NumberStyles.HexNumber)));
        this._Game.GameMode = (SimonGame.PlayMode)_settings.PlayMode;

        this.toolStripMain_Sound.Checked = _settings.Sound;
        this.toolStripMain_Stats.Checked = _settings.Stats;
    }

}

