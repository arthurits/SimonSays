using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class frmSettings : Form
    {
        // Internal variables
        private ProgramSettings<string, string> _settings;
        private ProgramSettings<string, string> _defaultSettings;

        // Public interface
        public ProgramSettings<string, string> GetSettings => _settings;

        public frmSettings()
        {
            InitializeComponent();

            // Default buttons
            this.AcceptButton = this.btnAccept;
            this.CancelButton = this.btnCancel;

            // Populate the GridView
            List<(int Value, float Frequency, string Color)> lista = new List<(int Value, float Frequency, string Color)>();
            lista.Add((0, 460, "0000FF"));
            lista.Add((1, 460, "FF00FF"));
            lista.Add((2, 460, "00FF00"));
            lista.Add((3, 460, "FF0000"));
            
            List<string> lista2 = new List<string>();
            lista2.Add("algo");
            lista2.Add("para");
            lista2.Add("probar");

            /*
            gridButtons.DataSource = lista.Select(i => new
            {
                i.Value,
                i.Frequency,
                i.Color
            });
            */
            var bindingList = new BindingList<(int Value, float Frequency, string Color)>(lista);
            var source = new BindingSource(bindingList, null);
            gridButtons.DataSource = source;
            //gridButtons.DataSource = lista2;

            //var item = new Tuple<string, string>($"Row : {i}, Col: One", $"Row: {i}, Col: Two");

            DataTable table= new DataTable();
            table.Columns.Add("Value", typeof(Int32));
            table.Columns.Add("Frequency", typeof(float));
            table.Columns.Add("Color", typeof(string));

            var algo = lista.Select(i => new object[]
            {
                i.Value,
                i.Frequency,
                i.Color
            });

            foreach ((int Value, float Frequency, string Color) row in lista)
            {
                table.Rows.Add(new object[]{row.Value, row.Frequency, row.Color});
            }
            /*
            table.Rows.Add(lista.Select(i => new
            {
                i.Value,
                i.Frequency,
                i.Color
            }));*/
            gridButtons.DataSource = table;
        }

        public frmSettings(ProgramSettings<string, string> settings, ProgramSettings<string, string> defSets)
            : this()
        {
            try
            {
                //PlayMode play = (PlayMode)Convert.ToInt32(settings.ContainsKey("PlayMode") ? settings["PlayMode"] : defSets["PlayMode"]);
                //this.radProgressive.Checked = ((play & PlayMode.SequenceProgressive) == PlayMode.SequenceProgressive);
                //this.radRandom.Checked = ((play & PlayMode.SequenceRandom) == PlayMode.SequenceRandom);
                //this.radFixed.Checked = ((play & PlayMode.TimeFixed) == PlayMode.TimeFixed);
                //this.radIncremental.Checked = ((play & PlayMode.TimeIncremental) == PlayMode.TimeIncremental);
                //this.numTimeIncrement.Enabled = this.radIncremental.Checked;
                //this.trackTimeIncrement.Enabled = this.radIncremental.Checked;
                
                this.numButtons.Value = Convert.ToInt32(settings.GetOrDefault("NumberOfButtons", defSets["NumberOfButtons"]));
                this.numButtonMax.Value = Convert.ToDecimal(settings.GetOrDefault("OuterButtonRatio", defSets["OuterButtonRatio"]), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                this.numButtonMin.Value = Convert.ToDecimal(settings.GetOrDefault("InnerButtonRatio", defSets["InnerButtonRatio"]), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                this.numButtonDistance.Value = Convert.ToDecimal(settings.GetOrDefault("CenterButtonRatio", defSets["CenterButtonRatio"]), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

                this.numBoardIn.Value = Convert.ToDecimal(settings.GetOrDefault("InnerBoardRatio", defSets["InnerBoardRatio"]), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                this.numBoardOut.Value = Convert.ToDecimal(settings.GetOrDefault("OuterBoardRatio", defSets["OuterBoardRatio"]), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                this.numBoardRotation.Value = Convert.ToDecimal(settings.GetOrDefault("BoardRotation", defSets["BoardRotation"]), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                this.pctBack.BackColor = Color.FromArgb(Convert.ToInt32(settings.GetOrDefault("ColorBackground", defSets["ColorBackground"])));
                this.pctOut.BackColor = Color.FromArgb(Convert.ToInt32(settings.GetOrDefault("ColorOuterCircle", defSets["ColorOuterCircle"])));
                this.pctIn.BackColor = Color.FromArgb(Convert.ToInt32(settings.GetOrDefault("ColorInnerCircle", defSets["ColorInnerCircle"])));

                this.DemoBoard.Font = new Font(settings.GetOrDefault("FontFamilyName", defSets["FontFamilyName"]), DemoBoard.Font.SizeInPoints);
                this.lblFontFamily.Text = "Font: " + this.DemoBoard.Font.FontFamily.Name;

                this.chkStartUp.Checked = Convert.ToInt32(settings.GetOrDefault("WindowPosition", defSets["WindowPosition"])) == 1 ? true : false;

                /*
                int value = Convert.ToInt32(settings.ContainsKey("MaximumDigit") ? settings["MaximumDigit"] : defSets["MaximumDigit"]);
                this.numMaxDigit.Value = value > numMaxDigit.Maximum ? numMaxDigit.Maximum : (value < numMaxDigit.Minimum ? numMaxDigit.Minimum : value);
                this.numMinDigit.Maximum = this.numMaxDigit.Value;
                value = Convert.ToInt32(settings.ContainsKey("MinimumDigit") ? settings["MinimumDigit"] : defSets["MinimumDigit"]);
                this.numMinDigit.Value = value > numMinDigit.Maximum ? numMinDigit.Maximum : (value < numMinDigit.Minimum ? numMinDigit.Minimum : value);

                this.numMaxAttempts.Value = Convert.ToInt32(settings.ContainsKey("MaximumAttempts") ? settings["MaximumAttempts"] : defSets["MaximumAttempts"]);
                this.numMinLength.Value = Convert.ToInt32(settings.ContainsKey("MinimumLength") ? settings["MinimumLength"] : defSets["MinimumLength"]);

                this.numCountRatio.Value = Convert.ToDecimal(settings.ContainsKey("CountDownRatio") ? settings["CountDownRatio"] : defSets["CountDownRatio"], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                this.numNumbersRatio.Value = Convert.ToDecimal(settings.ContainsKey("NumbersRatio") ? settings["NumbersRatio"] : defSets["NumbersRatio"], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                this.numBorderRatio.Value = Convert.ToDecimal(settings.ContainsKey("BorderRatio") ? settings["BorderRatio"] : defSets["BorderRatio"], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                this.numFontRatio.Value = Convert.ToDecimal(settings.ContainsKey("FontRatio") ? settings["FontRatio"] : defSets["FontRatio"], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                this.numResultsRatio.Value = Convert.ToDecimal(settings.ContainsKey("ResultsRatio") ? settings["ResultsRatio"] : defSets["ResultsRatio"], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                */
                
            }
            catch (KeyNotFoundException ex)
            {
                using (new CenterWinDialog(this))
                    MessageBox.Show(this,
                        "Unexpected error while applying settings.\nPlease report the error to the engineer.\n" + ex.GetType().ToString() + "\n" + ex.Message,
                        "Settings error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }

            //ApplySettings(_settings);
            _settings = settings;
            _defaultSettings = defSets;

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            _settings["NumberOfButtons"] = this.numButtons.Value.ToString();
            _settings["OuterButtonRatio"] = this.numButtonMax.Value.ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            _settings["InnerButtonRatio"] = this.numButtonMin.Value.ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            _settings["CenterButtonRatio"] = this.numButtonDistance.Value.ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

            _settings["InnerBoardRatio"] = this.numBoardIn.Value.ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            _settings["OuterBoardRatio"] = this.numBoardOut.Value.ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            _settings["BoardRotation"] = this.numBoardRotation.Value.ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            _settings["ColorBackground"] = this.pctBack.BackColor.ToArgb().ToString();
            _settings["ColorOuterCircle"] = this.pctOut.BackColor.ToArgb().ToString();
            _settings["ColorInnerCircle"] = this.pctIn.BackColor.ToArgb().ToString();
            _settings["FontFamilyName"] = this.lblFontFamily.Text.Remove(0, 6); // Delete the leading "Font: " characters
            _settings["WindowPosition"] = (this.chkStartUp.Checked ? 1 : 0).ToString();

            /*
            _settings["PlayMode"] = (
                                    (this.radFixed.Checked ? 1 : 0) * 1 +
                                    (this.radIncremental.Checked ? 1 : 0) * 2 +
                                    (this.radProgressive.Checked ? 1 : 0) * 4 +
                                    (this.radRandom.Checked ? 1 : 0) * 8
                                    ).ToString();
            */
            
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void ApplySettings(ProgramSettings<string, string> _settings)
        {
            try
            {
                /*
                PlayMode play = (PlayMode)Convert.ToInt32(_settings["PlayMode"]);
                this.radProgressive.Checked = ((play & PlayMode.SequenceProgressive) == PlayMode.SequenceProgressive);
                this.radRandom.Checked = ((play & PlayMode.SequenceRandom) == PlayMode.SequenceRandom);
                this.radFixed.Checked = ((play & PlayMode.TimeFixed) == PlayMode.TimeFixed);
                this.radIncremental.Checked = ((play & PlayMode.TimeIncremental) == PlayMode.TimeIncremental);
                this.numTimeIncrement.Enabled = this.radIncremental.Checked;
                this.trackTimeIncrement.Enabled = this.radIncremental.Checked;
                */

                this.numButtons.Value = Convert.ToInt32(_settings["NumberOfButtons"]);
                this.numButtonMax.Value = Convert.ToDecimal(_settings.GetOrDefault("OuterButtonRatio"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                this.numButtonMin.Value = Convert.ToDecimal(_settings.GetOrDefault("InnerButtonRatio"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                this.numButtonDistance.Value = Convert.ToDecimal(_settings.GetOrDefault("CenterButtonRatio"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

                this.numBoardIn.Value = Convert.ToDecimal(_settings.GetOrDefault("InnerBoardRatio"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                this.numBoardOut.Value = Convert.ToDecimal(_settings.GetOrDefault("OuterBoardRatio"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                this.numBoardRotation.Value = Convert.ToDecimal(_settings.GetOrDefault("BoardRotation"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                this.pctBack.BackColor = Color.FromArgb(Convert.ToInt32(_settings.GetOrDefault("ColorBackground")));
                this.pctOut.BackColor = Color.FromArgb(Convert.ToInt32(_settings.GetOrDefault("ColorOuterCircle")));
                this.pctIn.BackColor = Color.FromArgb(Convert.ToInt32(_settings.GetOrDefault("ColorInnerCircle")));

                this.DemoBoard.Font = new Font(_settings.GetOrDefault("FontFamilyName"), DemoBoard.Font.SizeInPoints);
                this.lblFontFamily.Text = "Font: " + this.DemoBoard.Font.FontFamily.Name;

                this.chkStartUp.Checked = Convert.ToInt32(_settings.GetOrDefault("WindowPosition")) == 1 ? true : false;

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


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnReset_Click(object sender, EventArgs e)
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
                ApplySettings(_defaultSettings);
                //_settings["SplitterDistance"] = "0.5";
            }
        }



        private void numButtons_ValueChanged(object sender, EventArgs e)
        {
            DemoBoard.NumberOfButtons = (Int32)numButtons.Value;
            if (trackButtons.Value != (Int32)numButtons.Value) trackButtons.Value = Convert.ToInt32(numButtons.Value);
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

        private void numBoardOut_ValueChanged(object sender, EventArgs e)
        {
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
            decimal ratio = Decimal.Round((decimal)trackBoardIn.Value / 100, 2, MidpointRounding.AwayFromZero);
            if (numBoardIn.Value != ratio) numBoardIn.Value = ratio;
        }

        private void numBoardRotation_ValueChanged(object sender, EventArgs e)
        {
            //DemoBoard.PercentInnerRatio = (float)numBoardIn.Value;
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
            ColorDialog ColorPicker = new ColorDialog();
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
            ColorDialog ColorPicker = new ColorDialog();
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
            ColorDialog ColorPicker = new ColorDialog();
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
            FontDialog frmFont = new FontDialog()
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
}
