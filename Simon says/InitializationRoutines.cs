namespace SimonSays;

partial class FrmSimon
{
    /// <summary>
    /// Initialize the ToolStripPanel component: add the child components to it
    /// </summary>
    private void InitializeToolStripPanel()
    {
        //tspTop = new ToolStripPanel();
        //tspBottom = new ToolStripPanel();
        tspTop.Join(this.toolStripMain);
        //tspTop.Join(mnuMainFrm);
        tspBottom.Join(this.statusStrip);

        // Exit the method
        return;
    }

    /// <summary>
    /// Initialize the ToolStrip component
    /// </summary>
    private void InitializeToolStrip()
    {
        //ToolStripNumericUpDown c = new ToolStripNumericUpDown();
        //this.toolStripMain.Items.Add((ToolStripItem)c);

        toolStripMain.Renderer = new customRenderer(Brushes.SteelBlue, Brushes.LightSkyBlue);

        if (File.Exists(_settings.AppPath + @"\images\exit.ico")) this.toolStripMain_Exit.Image = new Icon(_settings.AppPath + @"\images\exit.ico", 48, 48).ToBitmap();
        if (File.Exists(_settings.AppPath + @"\images\start.ico")) this.toolStripMain_Start.Image = new Icon(_settings.AppPath + @"\images\start.ico", 48, 48).ToBitmap();
        if (File.Exists(_settings.AppPath + @"\images\stop.ico")) this.toolStripMain_Stop.Image = new Icon(_settings.AppPath + @"\images\stop.ico", 48, 48).ToBitmap();
        if (File.Exists(_settings.AppPath + @"\images\soundoff.ico")) this.toolStripMain_Sound.Image = new Icon(_settings.AppPath + @"\images\soundoff.ico", 48, 48).ToBitmap();
        if (File.Exists(_settings.AppPath + @"\images\graph.ico")) this.toolStripMain_Stats.Image = new Icon(_settings.AppPath + @"\images\graph.ico", 48, 48).ToBitmap();
        if (File.Exists(_settings.AppPath + @"\images\settings.ico")) this.toolStripMain_Settings.Image = new Icon(_settings.AppPath + @"\images\settings.ico", 48, 48).ToBitmap();
        if (File.Exists(_settings.AppPath + @"\images\about.ico")) this.toolStripMain_About.Image = new Icon(_settings.AppPath + @"\images\about.ico", 48, 48).ToBitmap();

    }

    /// <summary>
    /// Initialize the MenuStrip component
    /// </summary>
    private void InitializeMenuStrip()
    {
        return;
    }

    /// <summary>
    /// Initialize the StatusStrip component
    /// </summary>
    private void InitializeStatusStrip()
    {
        return;
    }
}
