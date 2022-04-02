namespace SimonSays;

partial class frmSimon
{
    private void OnButtonClick(object sender, CustomBoard.ButtonClickEventArgs e)
    {
        _Game.OnPress(e.ButtonValue);
    }

    private void Exit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void Start_Click(object sender, EventArgs e)
    {
        _Game.NumberOfButtons = this.simonBoard.NumberOfButtons;
        _Game.Start();
    }

    private void Stop_Click(object sender, EventArgs e)
    {
        _Game.Stop();
        string strScore = simonBoard.ScoreTotal.ToString();
        this.simonBoard.Stop();
        MessageBox.Show("Your total score is: " + strScore, "Game stopped");
    }

    private void Settings_Click(object sender, EventArgs e)
    {
        frmSettings frmSettings = new(_settings);
        frmSettings.ShowDialog(this);
        if (frmSettings.DialogResult == DialogResult.OK)
        {
            _settings = frmSettings.Settings;
            ApplySettingsJSON(WindowPosition: false);
        }
    }

    private void About_Click(object sender, EventArgs e)
    {
        frmAbout form = new();
        form.ShowDialog(this);
    }
}
