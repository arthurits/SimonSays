using System.Data;

namespace SimonSays;

public partial class frmSettings : Form
{
    // Internal variables
    public ClassSettings Settings { get; private set; }

    private DataTable _table;
    private Color[] _previousColors;        // To be used when the state of radSurpise changes only at radSurprise_CheckedChanged
    private float[] _previousFrequencies;   // To be used when the state of radSurpise changes only at radSurprise_CheckedChanged

    public frmSettings()
    {
        // Set form icon
        var strPath = System.IO.Path.GetDirectoryName(Environment.ProcessPath);
        if (System.IO.File.Exists(strPath + @"\images\settings.ico")) this.Icon = new Icon(strPath + @"\images\settings.ico");

        // General Intellisense initialization
        InitializeComponent();

        // Default buttons
        this.AcceptButton = this.btnAccept;
        this.CancelButton = this.btnCancel;
        
        // Bind data to the GridView control
        _table = new DataTable();
        _table.Columns.Add("Value", typeof(Int32));
        _table.Columns.Add("Frequency", typeof(float));
        _table.Columns.Add("Color", typeof(string));
        _table.ColumnChanged += new DataColumnChangeEventHandler(OnDataGridChanged);

        gridButtons.DataSource = _table;
        gridButtons.Columns[0].ReadOnly = true;
        gridButtons.Columns[2].CellTemplate = new ColorPickerCell();

        // Force the creation of Simon Buttons
        this.numButtons.Value = 2;
        this.numButtons.Minimum = 2;

    }

    public frmSettings(ClassSettings settings)
        : this()
    {
        UpdateControls(settings);
    }

    /// <summary>
    /// Updates the form's controls with values from the settings class
    /// </summary>
    /// <param name="settings">Class containing the values to show on the form's controls</param>
    private void UpdateControls(ClassSettings settings)
    {
        Settings = settings;

        try
        {
            SimonGame.PlayMode play = (SimonGame.PlayMode)Settings.PlayMode;
            this.radClassic.Checked = ((play & SimonGame.PlayMode.SimonClassic) == SimonGame.PlayMode.SimonClassic);
            this.radAdds.Checked = ((play & SimonGame.PlayMode.PlayerAdds) == SimonGame.PlayMode.PlayerAdds);
            this.radChoose.Checked = ((play & SimonGame.PlayMode.ChooseYourColor) == SimonGame.PlayMode.ChooseYourColor);
            this.radBounce.Checked = ((play & SimonGame.PlayMode.SimonBounce) == SimonGame.PlayMode.SimonBounce);
            this.radSurprise.Checked = ((play & SimonGame.PlayMode.SimonSurprise) == SimonGame.PlayMode.SimonSurprise);
            this.radRewind.Checked = ((play & SimonGame.PlayMode.SimonRewind) == SimonGame.PlayMode.SimonRewind);
            this.radRandom.Checked = ((play & SimonGame.PlayMode.SimonRandom) == SimonGame.PlayMode.SimonRandom);
            this.chkSpeed.Checked = ((play & SimonGame.PlayMode.TimeIncremental) == SimonGame.PlayMode.TimeIncremental);
            this.chkWaiting.Checked = ((play & SimonGame.PlayMode.TimeWaiting) == SimonGame.PlayMode.TimeWaiting);
            this.numWaiting.Value = Settings.TimeWaiting;
            this.numWaiting.Enabled = this.chkWaiting.Checked;
            this.trackWaiting.Enabled = this.chkWaiting.Checked;

            this.numButtons.Value = Settings.NumberOfButtons;
            this.numButtonMax.Value = Convert.ToDecimal(Settings.OuterButtonRatio, Settings.AppCulture);
            this.numButtonMin.Value = Convert.ToDecimal(Settings.InnerButtonRatio, Settings.AppCulture);
            this.numButtonDistance.Value = Convert.ToDecimal(Settings.CenterButtonRatio, Settings.AppCulture);
            this.numButtonClick.Value = Convert.ToDecimal(Settings.ButtonClickOffset);

            this.numBoardIn.Value = Convert.ToDecimal(Settings.InnerBoardRatio);
            this.numBoardOut.Value = Convert.ToDecimal(Settings.OuterBoardRatio);
            this.numBoardRotation.Value = Convert.ToDecimal(Settings.BoardRotation);
            this.pctBack.BackColor = Color.FromArgb(Settings.ColorBackground);
            this.pctOut.BackColor = Color.FromArgb(Settings.ColorOuterCircle);
            this.pctIn.BackColor = Color.FromArgb(Settings.ColorInnerCircle);

            this.DemoBoard.Font = new Font(Settings.FontFamilyName, DemoBoard.Font.SizeInPoints);
            this.lblFontFamily.Text = "Font: " + this.DemoBoard.Font.FontFamily.Name;

            this.chkStartUp.Checked = Settings.WindowPosition;

            this.DemoBoard.ButtonColors = Array.ConvertAll(Settings.ButtonColors.Split('-'), x => Color.FromArgb(int.Parse(x, System.Globalization.NumberStyles.HexNumber)));
            this.DemoBoard.ButtonFrequencies = Array.ConvertAll(Settings.ButtonFrequencies.Split('-'), float.Parse);
            ModifyTable();
        }
        catch (Exception)
        {
            using (new CenterWinDialog(this))
                MessageBox.Show(this, "Unexpected error while applying settings.\nPlease report the error to the engineer.", "Settings error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }



    private void Accept_Click(object sender, EventArgs e)
    {
        Settings.NumberOfButtons = Convert.ToInt32(this.numButtons.Value);
        Settings.ButtonColors = String.Join("-", this.DemoBoard.ButtonColors.Select(x => x.ToArgb().ToString("X")));
        Settings.ButtonFrequencies = String.Join("-", this.DemoBoard.ButtonFrequencies);
        Settings.OuterButtonRatio = Convert.ToSingle(this.numButtonMax.Value, Settings.AppCulture);
        Settings.InnerButtonRatio = Convert.ToSingle(this.numButtonMin.Value, Settings.AppCulture);
        Settings.CenterButtonRatio = Convert.ToSingle(this.numButtonDistance.Value, Settings.AppCulture);

        Settings.InnerBoardRatio = Convert.ToSingle(this.numBoardIn.Value, Settings.AppCulture);
        Settings.OuterBoardRatio = Convert.ToSingle(this.numBoardOut.Value, Settings.AppCulture);
        Settings.BoardRotation = Convert.ToSingle(this.numBoardRotation.Value, Settings.AppCulture);
        Settings.ColorBackground = this.pctBack.BackColor.ToArgb();
        Settings.ColorOuterCircle = this.pctOut.BackColor.ToArgb();
        Settings.ColorInnerCircle = this.pctIn.BackColor.ToArgb();
        Settings.FontFamilyName = this.lblFontFamily.Text.Remove(0, 6); // Delete the leading "Font: " characters
        Settings.WindowPosition = this.chkStartUp.Checked;

        Settings.PlayMode = (this.chkSpeed.Checked ? (int)SimonGame.PlayMode.TimeIncremental : 0) +
                            (this.chkWaiting.Checked ? (int)SimonGame.PlayMode.TimeWaiting : 0)  +
                            (this.radClassic.Checked ? (int)SimonGame.PlayMode.SimonClassic : 0) +
                            (this.radAdds.Checked ? (int)SimonGame.PlayMode.PlayerAdds : 0)  +
                            (this.radChoose.Checked ? (int)SimonGame.PlayMode.ChooseYourColor : 0) +
                            (this.radBounce.Checked ? (int)SimonGame.PlayMode.SimonBounce : 0) +
                            (this.radSurprise.Checked ? (int)SimonGame.PlayMode.SimonSurprise : 0) +
                            (this.radRewind.Checked ? (int)SimonGame.PlayMode.SimonRewind : 0) +
                            (this.radRandom.Checked ? (int)SimonGame.PlayMode.SimonRandom : 0);

        Settings.TimeWaiting = Convert.ToInt32(numWaiting.Value);

        this.DialogResult = DialogResult.OK;
        Close();
    }

    private void ApplySettings(ProgramSettings<string, string> _settings)
    {
        try
        {
            // tabPlayMode
            SimonGame.PlayMode play = (SimonGame.PlayMode)Convert.ToInt32(_settings.ContainsKey("PlayMode"));
            this.radClassic.Checked = ((play & SimonGame.PlayMode.SimonClassic) == SimonGame.PlayMode.SimonClassic);
            this.radAdds.Checked = ((play & SimonGame.PlayMode.PlayerAdds) == SimonGame.PlayMode.PlayerAdds);
            this.radChoose.Checked = ((play & SimonGame.PlayMode.ChooseYourColor) == SimonGame.PlayMode.ChooseYourColor);
            this.radBounce.Checked = ((play & SimonGame.PlayMode.SimonBounce) == SimonGame.PlayMode.SimonBounce);
            this.radSurprise.Checked = ((play & SimonGame.PlayMode.SimonSurprise) == SimonGame.PlayMode.SimonSurprise);
            this.radRewind.Checked = ((play & SimonGame.PlayMode.SimonRewind) == SimonGame.PlayMode.SimonRewind);
            this.radRandom.Checked = ((play & SimonGame.PlayMode.SimonRandom) == SimonGame.PlayMode.SimonRandom);
            this.chkSpeed.Checked = ((play & SimonGame.PlayMode.TimeIncremental) == SimonGame.PlayMode.TimeIncremental);
            this.chkWaiting.Checked = ((play & SimonGame.PlayMode.TimeWaiting) == SimonGame.PlayMode.TimeWaiting);
            this.numWaiting.Value = Convert.ToInt32(_settings.GetOrDefault("TimeWaiting"));
            this.numWaiting.Enabled = this.chkWaiting.Checked;
            this.trackWaiting.Enabled = this.chkWaiting.Checked;

            // tabInterface
            this.numButtons.Value = Convert.ToInt32(_settings["NumberOfButtons"]);
            this.DemoBoard.ButtonColors = Array.ConvertAll(_settings["ButtonColors"].Split('-'), x => Color.FromArgb(int.Parse(x, System.Globalization.NumberStyles.HexNumber)));
            this.DemoBoard.ButtonFrequencies = Array.ConvertAll(_settings["ButtonFrequencies"].Split('-'), float.Parse);
            this.numButtonMax.Value = Convert.ToDecimal(_settings.GetOrDefault("OuterButtonRatio"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            this.numButtonMin.Value = Convert.ToDecimal(_settings.GetOrDefault("InnerButtonRatio"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            this.numButtonDistance.Value = Convert.ToDecimal(_settings.GetOrDefault("CenterButtonRatio"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            this.numButtonClick.Value = Convert.ToDecimal(_settings.GetOrDefault("ButtonClickOffset"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

            // tabBoard
            this.numBoardIn.Value = Convert.ToDecimal(_settings.GetOrDefault("InnerBoardRatio"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            this.numBoardOut.Value = Convert.ToDecimal(_settings.GetOrDefault("OuterBoardRatio"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            this.numBoardRotation.Value = Convert.ToDecimal(_settings.GetOrDefault("BoardRotation"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            this.pctBack.BackColor = Color.FromArgb(Convert.ToInt32(_settings.GetOrDefault("ColorBackground")));
            this.pctOut.BackColor = Color.FromArgb(Convert.ToInt32(_settings.GetOrDefault("ColorOuterCircle")));
            this.pctIn.BackColor = Color.FromArgb(Convert.ToInt32(_settings.GetOrDefault("ColorInnerCircle")));

            this.DemoBoard.Font = new Font(_settings.GetOrDefault("FontFamilyName"), DemoBoard.Font.SizeInPoints);
            this.lblFontFamily.Text = "Font: " + this.DemoBoard.Font.FontFamily.Name;

            this.chkStartUp.Checked = Convert.ToInt32(_settings.GetOrDefault("WindowPosition")) == 1;

        }
        catch (KeyNotFoundException e)
        {
            using (new CenterWinDialog(this))
            {
                MessageBox.Show(this,
                    "Unexpected error while applying settings.\nPlease report the error to the engineer.",
                    "Settings error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }


    private void Cancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
    }

    private void Reset_Click(object sender, EventArgs e)
    {
        // Ask for overriding confirmation
        DialogResult result;
        using (new CenterWinDialog(this))
        {
            result = MessageBox.Show(this, "You are about to override the actual settings\n" +
                                            "with the default values.\n\n" +
                                            "Are you sure you want to continue?",
                                            "Override settings",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        }

        // If "Yes", then reset values to default
        if (result == DialogResult.Yes)
        {
            UpdateControls(new ClassSettings());
            Settings.SplitterDistance = this.Parent.Width / 2;
            //_settings["SplitterDistance"] = "0.5";
        }
    }

    private void OnDataGridChanged(object sender, DataColumnChangeEventArgs e)
    {
        this.DemoBoard.ButtonFrequencies = Array.ConvertAll(_table.Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray(), float.Parse);
        this.DemoBoard.ButtonColors = Array.ConvertAll(_table.Rows.OfType<DataRow>().Select(k => k[2].ToString()).ToArray(), x => Color.FromArgb(int.Parse(x, System.Globalization.NumberStyles.HexNumber)));
        //SendKeys.Send("{TAB}");
        //SendKeys.Send("+{TAB}");
    }

    private void gridButtons_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex != 2) return;

        //You can check for e.ColumnIndex to limit this to your specific column
        this.gridButtons.BeginEdit(false);
        var editingControl = (ColorPickerControl)this.gridButtons.EditingControl;
        if (editingControl != null)
            editingControl.ColorEditingControl_Click(null, null);
        //editingControl.DroppedDown = true;
        this.gridButtons.EndEdit();
        this.gridButtons.CurrentCell = null;
    }


    /// <summary>
    /// Update the table, gridButtons and DemoBoard
    /// </summary>
    private void ModifyTable()
    {
        var list = this.DemoBoard.DefaultButtonList;
        var numColors = this.DemoBoard.ButtonColors.Length;
        var numFreq = this.DemoBoard.ButtonFrequencies.Length;
        var colors = this.DemoBoard.ButtonColors;
        var freq = this.DemoBoard.ButtonFrequencies;
        int nRows = _table.Rows.Count;

        for (int i = 0; i < nRows; i++)
        {
            if (this.radSurprise.Checked == true)
            {
                this._table.Rows[i]["Frequency"] = list[3].Frequency;
                this._table.Rows[i]["Color"] = list[3].Color;
            }
            else
            {
                this._table.Rows[i]["Frequency"] = i < numFreq ? freq[i] : list[i].Frequency;
                this._table.Rows[i]["Color"] = i < numColors ? colors[i].ToArgb().ToString("X") : list[i].Color;
            }
        }

        _table.AcceptChanges();

        OnDataGridChanged(null, null);
    }

    private void radSurprise_CheckedChanged(object sender, EventArgs e)
    {
        if (this.radSurprise.Checked == false)
        {
            //var list = this.DemoBoard.DefaultButtonList;
            //this.DemoBoard.ButtonFrequencies = list.Select(x => x.Frequency).ToArray();
            //this.DemoBoard.ButtonColors = Array.ConvertAll(list.Select(x => x.Color).ToArray(), x => Color.FromArgb(int.Parse(x, System.Globalization.NumberStyles.HexNumber)));

            this.DemoBoard.ButtonFrequencies = _previousFrequencies;
            this.DemoBoard.ButtonColors = _previousColors;
            this.gridButtons.Enabled = true;
        }
        else
        {
            _previousFrequencies = (float[])this.DemoBoard.ButtonFrequencies.Clone();
            _previousColors = (Color[])this.DemoBoard.ButtonColors.Clone();
            this.gridButtons.Enabled = false;

        }

        // Update the Table Grid and the DemoBoard
        ModifyTable();
    }

    private void chkWaiting_CheckedChanged(object sender, EventArgs e)
    {
        var state = chkWaiting.Checked;
        numWaiting.Enabled = state;
        trackWaiting.Enabled = state;
    }

    private void numWaiting_ValueChanged(object sender, EventArgs e)
    {
        int ratio = Convert.ToInt32(numWaiting.Value);
        if (trackWaiting.Value != ratio) trackWaiting.Value = ratio;
    }

    private void trackWaiting_ValueChanged(object sender, EventArgs e)
    {
        int ratio = trackWaiting.Value;
        if (numWaiting.Value != ratio) numWaiting.Value = ratio;
    }

    private void numButtons_ValueChanged(object sender, EventArgs e)
    {
        DemoBoard.NumberOfButtons = (Int32)numButtons.Value;
        if (trackButtons.Value != (Int32)numButtons.Value) trackButtons.Value = Convert.ToInt32(numButtons.Value);

        // Update the table, gridButtons and DemoBoard
        int nButtons = (Int32)numButtons.Value;
        int nRows = _table.Rows.Count;
        int nDiff = nButtons - nRows;

        if (nDiff > 0)
        {
            var list = this.DemoBoard.DefaultButtonList;
            var numColors = this.DemoBoard.ButtonColors.Length;
            var numFreq = this.DemoBoard.ButtonFrequencies.Length;

            for (int i = 0; i < nDiff; i++)
                this._table.Rows.Add(new object[] {
                    list[nRows + i].Value,
                    list[nRows + i].Frequency,
                    list[nRows + i].Color
                });

        }
        else if (nDiff < 0)
        {
            for (int i = 0; i < -nDiff; i++)
            {
                this._table.Rows.RemoveAt(nRows - 1 - i);
            }
        }
        _table.AcceptChanges();

        OnDataGridChanged(null, null);
    }

    private void trackButtons_ValueChanged(object sender, EventArgs e)
    {
        if (numButtons.Value != trackButtons.Value) numButtons.Value = trackButtons.Value;
    }

    private void numButtonMax_ValueChanged(object sender, EventArgs e)
    {
        DemoBoard.OuterButtonRatio = (float)numButtonMax.Value;
        int ratio = Convert.ToInt32(100 * numButtonMax.Value);
        if (trackButtonOuter.Value != ratio) trackButtonOuter.Value = ratio;
    }

    private void trackButtonOuter_ValueChanged(object sender, EventArgs e)
    {
        decimal ratio = Decimal.Round((decimal)trackButtonOuter.Value / 100, 2, MidpointRounding.AwayFromZero);
        if (numButtonMax.Value != ratio) numButtonMax.Value = ratio;
    }

    private void numButtonMin_ValueChanged(object sender, EventArgs e)
    {
        DemoBoard.InnerButtonRatio = (float)numButtonMin.Value;
        int ratio = Convert.ToInt32(100 * numButtonMin.Value);
        if (trackButtonInner.Value != ratio) trackButtonInner.Value = ratio;
    }

    private void trackButtonInner_ValueChanged(object sender, EventArgs e)
    {
        decimal ratio = Decimal.Round((decimal)trackButtonInner.Value / 100, 2, MidpointRounding.AwayFromZero);
        if (numButtonMin.Value != ratio) numButtonMin.Value = ratio;
    }

    private void numButtonDistance_ValueChanged(object sender, EventArgs e)
    {
        DemoBoard.CenterButtonRatio = (float)numButtonDistance.Value;
        int ratio = Convert.ToInt32(100 * numButtonDistance.Value);
        if (trackButtonDistance.Value != ratio) trackButtonDistance.Value = ratio;
    }

    private void trackButtonDistance_ValueChanged(object sender, EventArgs e)
    {
        decimal ratio = Decimal.Round((decimal)trackButtonDistance.Value / 100, 2, MidpointRounding.AwayFromZero);
        if (numButtonDistance.Value != ratio) numButtonDistance.Value = ratio;
    }

    private void numButtonClick_ValueChanged(object sender, EventArgs e)
    {
        //DemoBoard.ButtonClickOffset = (float)numButtonClick.Value;
        int ratio = Convert.ToInt32(100 * numButtonClick.Value);
        if (trackButtonClick.Value != ratio) trackButtonClick.Value = ratio;
    }

    private void trackButtonClick_ValueChanged(object sender, EventArgs e)
    {
        decimal ratio = Decimal.Round((decimal)trackButtonClick.Value / 100, 2, MidpointRounding.AwayFromZero);
        if (numButtonClick.Value != ratio) numButtonClick.Value = ratio;
    }

    private void numBoardOut_ValueChanged(object sender, EventArgs e)
    {
        numBoardIn.Maximum = numBoardOut.Value;
        DemoBoard.PercentOuterRatio = (float)numBoardOut.Value;
        int ratio = Convert.ToInt32(100 * numBoardOut.Value);
        if (trackBoardOut.Value != ratio) trackBoardOut.Value = ratio;
    }

    private void trackBoardOut_ValueChanged(object sender, EventArgs e)
    {
        decimal ratio = Decimal.Round((decimal)trackBoardOut.Value / 100, 2, MidpointRounding.AwayFromZero);
        if (numBoardOut.Value != ratio) numBoardOut.Value = ratio;
    }

    private void numBoardIn_ValueChanged(object sender, EventArgs e)
    {
        DemoBoard.PercentInnerRatio = (float)numBoardIn.Value;
        int ratio = Convert.ToInt32(100 * numBoardIn.Value);
        if (trackBoardIn.Value != ratio) trackBoardIn.Value = ratio;
    }

    private void trackBoardIn_ValueChanged(object sender, EventArgs e)
    {
        int value = Convert.ToInt32(100 * numBoardIn.Maximum);
        if (trackBoardIn.Value > value)
        {
            trackBoardIn.Value = value;
            return;
        }

        decimal ratio = Decimal.Round((decimal)trackBoardIn.Value / 100, 2, MidpointRounding.AwayFromZero);
        if (numBoardIn.Value != ratio) numBoardIn.Value = ratio;
    }

    private void numBoardRotation_ValueChanged(object sender, EventArgs e)
    {
        DemoBoard.BoardRotation = (float)numBoardRotation.Value;
        int value = Convert.ToInt32(numBoardRotation.Value);
        if (trackBoardRotation.Value != value) trackBoardRotation.Value = value;
    }

    private void trackBoardRotation_ValueChanged(object sender, EventArgs e)
    {
        var value = trackBoardRotation.Value;
        if (numBoardRotation.Value != value) numBoardRotation.Value = value;
    }

    
    private void pctBack_Click(object sender, EventArgs e)
    {
        ColorDialog ColorPicker = new();
        ColorPicker.AllowFullOpen = true;
        ColorPicker.AnyColor = true;
        ColorPicker.FullOpen = true;
        ColorPicker.SolidColorOnly = false;
        ColorPicker.ShowHelp = true;

        // Sets the initial color select to the current text color.
        ColorPicker.Color = pctBack.BackColor;
        using (new CenterWinDialog(this.Owner))
        {
            // Update the text box color if the user clicks OK 
            if (ColorPicker.ShowDialog() == DialogResult.OK)
                pctBack.BackColor = ColorPicker.Color;
        }
    }

    private void pctBack_BackColorChanged(object sender, EventArgs e)
    {
        DemoBoard.ColorBackground = pctBack.BackColor;
        //pctBack.BackColor = pctBack.BackColor;
    }

    private void pctOut_Click(object sender, EventArgs e)
    {
        ColorDialog ColorPicker = new();
        ColorPicker.AllowFullOpen = true;
        ColorPicker.AnyColor = true;
        ColorPicker.FullOpen = true;
        ColorPicker.SolidColorOnly = false;
        ColorPicker.ShowHelp = true;

        // Sets the initial color select to the current text color.
        ColorPicker.Color = pctOut.BackColor;
        using (new CenterWinDialog(this.Owner))
        {
            // Update the text box color if the user clicks OK 
            if (ColorPicker.ShowDialog() == DialogResult.OK)
                pctOut.BackColor = ColorPicker.Color;
        }
    }
    
    private void pctOut_BackColorChanged(object sender, EventArgs e)
    {
        DemoBoard.ColorOuterCircle = pctOut.BackColor;
        //pctBack.BackColor = pctBack.BackColor;
    }

    private void pctIn_Click(object sender, EventArgs e)
    {
        ColorDialog ColorPicker = new();
        ColorPicker.AllowFullOpen = true;
        ColorPicker.AnyColor = true;
        ColorPicker.FullOpen = true;
        ColorPicker.SolidColorOnly = false;
        ColorPicker.ShowHelp = true;

        // Sets the initial color select to the current text color.
        ColorPicker.Color = pctIn.BackColor;
        using (new CenterWinDialog(this.Owner))
        {
            // Update the text box color if the user clicks OK 
            if (ColorPicker.ShowDialog() == DialogResult.OK)
                pctIn.BackColor = ColorPicker.Color;
        }
    }

    private void pctIn_BackColorChanged(object sender, EventArgs e)
    {
        DemoBoard.ColorInnerCircle = pctIn.BackColor;
        //pctBack.BackColor = pctBack.BackColor;
    }

    private void btnFontFamily_Click(object sender, EventArgs e)
    {
        FontDialog frmFont = new()
        {
            FontMustExist = true,
            Font = this.DemoBoard.Font,
            ShowApply = false,
            ShowColor = false,
            ShowEffects = false,
            ShowHelp = false
        };

        using (new CenterWinDialog(this))
        {
            if (frmFont.ShowDialog() == DialogResult.OK)
            {
                this.DemoBoard.Font = new Font(frmFont.Font.FontFamily, this.DemoBoard.Font.SizeInPoints);
                this.lblFontFamily.Text = "Font: " + frmFont.Font.FontFamily.Name;
            }
        }
        // https://stackoverflow.com/questions/2207709/convert-font-to-string-and-back-again
    }


}
