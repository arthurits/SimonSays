namespace SimonSays
{
    partial class frmSimon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSimon));
            this.tspTop = new System.Windows.Forms.ToolStripPanel();
            this.tspBottom = new System.Windows.Forms.ToolStripPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnYellow = new ColorButton.SimonButton();
            this.simonBoard = new CustomBoard.CustomBoard();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripMain_Exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain_Start = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain_Stop = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain_Sound = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain_Stats = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain_Settings = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain_About = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.btnRed = new ColorButton.SimonButton();
            this.btnBlue = new ColorButton.SimonButton();
            this.btnGreen = new ColorButton.SimonButton();
            this.simonBoard.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tspTop
            // 
            this.tspTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.tspTop.Location = new System.Drawing.Point(0, 0);
            this.tspTop.Name = "tspTop";
            this.tspTop.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.tspTop.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.tspTop.Size = new System.Drawing.Size(538, 0);
            // 
            // tspBottom
            // 
            this.tspBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tspBottom.Location = new System.Drawing.Point(0, 366);
            this.tspBottom.Name = "tspBottom";
            this.tspBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.tspBottom.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.tspBottom.Size = new System.Drawing.Size(538, 0);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(0, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(99, 29);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnYellow
            // 
            this.btnYellow.BackColor = System.Drawing.Color.Transparent;
            this.btnYellow.Clicked = false;
            this.btnYellow.ColorValue = 3;
            this.btnYellow.Duration = 400;
            this.btnYellow.ForeColor = System.Drawing.Color.Yellow;
            this.btnYellow.Frequency = 262;
            this.btnYellow.Location = new System.Drawing.Point(16, 330);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.OuterAngleSpan = 5F;
            this.btnYellow.Rotation = 270;
            this.btnYellow.Size = new System.Drawing.Size(334, 307);
            this.btnYellow.TabIndex = 2;
            this.btnYellow.UseVisualStyleBackColor = false;
            this.btnYellow.Visible = false;
            this.btnYellow.WidthPercentage = 1F;
            this.btnYellow.Click += new System.EventHandler(this.btnSimon_Click);
            // 
            // simonBoard
            // 
            this.simonBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simonBoard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            // 
            // 
            // 
            this.simonBoard.BlueButton.Clicked = false;
            this.simonBoard.BlueButton.ColorValue = 2;
            this.simonBoard.BlueButton.Duration = 400;
            this.simonBoard.BlueButton.ForeColor = System.Drawing.Color.Blue;
            this.simonBoard.BlueButton.Frequency = 196;
            this.simonBoard.BlueButton.Location = new System.Drawing.Point(221, 212);
            this.simonBoard.BlueButton.Name = "btnBlue";
            this.simonBoard.BlueButton.OuterAngleSpan = 5F;
            this.simonBoard.BlueButton.Rotation = 180;
            this.simonBoard.BlueButton.Size = new System.Drawing.Size(333, 333);
            this.simonBoard.BlueButton.TabIndex = 0;
            this.simonBoard.BlueButton.WidthPercentage = 0.45F;
            this.simonBoard.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(240)))));
            this.simonBoard.ColorInnerCircle = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.simonBoard.ColorOuterCircle = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.simonBoard.Controls.Add(this.btnStart);
            // 
            // 
            // 
            this.simonBoard.GreenButton.Clicked = false;
            this.simonBoard.GreenButton.ColorValue = 0;
            this.simonBoard.GreenButton.Duration = 400;
            this.simonBoard.GreenButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.simonBoard.GreenButton.Frequency = 392;
            this.simonBoard.GreenButton.Location = new System.Drawing.Point(-14, -23);
            this.simonBoard.GreenButton.Name = "btnGreen";
            this.simonBoard.GreenButton.OuterAngleSpan = 5F;
            this.simonBoard.GreenButton.Rotation = 0;
            this.simonBoard.GreenButton.Size = new System.Drawing.Size(333, 333);
            this.simonBoard.GreenButton.TabIndex = 2;
            this.simonBoard.GreenButton.WidthPercentage = 0.45F;
            this.simonBoard.Location = new System.Drawing.Point(16, 58);
            this.simonBoard.Name = "simonBoard";
            // 
            // 
            // 
            this.simonBoard.RedButton.Clicked = false;
            this.simonBoard.RedButton.ColorValue = 1;
            this.simonBoard.RedButton.Duration = 400;
            this.simonBoard.RedButton.ForeColor = System.Drawing.Color.Red;
            this.simonBoard.RedButton.Frequency = 330;
            this.simonBoard.RedButton.Location = new System.Drawing.Point(221, -23);
            this.simonBoard.RedButton.Name = "btnRed";
            this.simonBoard.RedButton.OuterAngleSpan = 5F;
            this.simonBoard.RedButton.Rotation = 90;
            this.simonBoard.RedButton.Size = new System.Drawing.Size(333, 333);
            this.simonBoard.RedButton.TabIndex = 3;
            this.simonBoard.RedButton.WidthPercentage = 0.45F;
            this.simonBoard.ScoreHighest = 0;
            this.simonBoard.ScoreTotal = 0;
            this.simonBoard.Size = new System.Drawing.Size(542, 523);
            this.simonBoard.TabIndex = 5;
            this.simonBoard.TabStop = false;
            // 
            // 
            // 
            this.simonBoard.YellowButton.Clicked = false;
            this.simonBoard.YellowButton.ColorValue = 3;
            this.simonBoard.YellowButton.Duration = 400;
            this.simonBoard.YellowButton.ForeColor = System.Drawing.Color.Yellow;
            this.simonBoard.YellowButton.Frequency = 262;
            this.simonBoard.YellowButton.Location = new System.Drawing.Point(-14, 212);
            this.simonBoard.YellowButton.Name = "btnYellow";
            this.simonBoard.YellowButton.OuterAngleSpan = 5F;
            this.simonBoard.YellowButton.Rotation = 270;
            this.simonBoard.YellowButton.Size = new System.Drawing.Size(333, 333);
            this.simonBoard.YellowButton.TabIndex = 1;
            this.simonBoard.YellowButton.WidthPercentage = 0.45F;
            // 
            // toolStripMain
            // 
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMain_Exit,
            this.toolStripMain_Start,
            this.toolStripMain_Stop,
            this.toolStripMain_Sound,
            this.toolStripMain_Stats,
            this.toolStripMain_Settings,
            this.toolStripMain_About});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(570, 55);
            this.toolStripMain.TabIndex = 6;
            this.toolStripMain.Text = "toolStripMain";
            // 
            // toolStripMain_Exit
            // 
            this.toolStripMain_Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMain_Exit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMain_Exit.Image")));
            this.toolStripMain_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMain_Exit.Name = "toolStripMain_Exit";
            this.toolStripMain_Exit.Size = new System.Drawing.Size(52, 52);
            this.toolStripMain_Exit.Text = "toolStripButton1";
            // 
            // toolStripMain_Start
            // 
            this.toolStripMain_Start.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMain_Start.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMain_Start.Image")));
            this.toolStripMain_Start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMain_Start.Name = "toolStripMain_Start";
            this.toolStripMain_Start.Size = new System.Drawing.Size(52, 52);
            this.toolStripMain_Start.Text = "toolStripButton1";
            // 
            // toolStripMain_Stop
            // 
            this.toolStripMain_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMain_Stop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMain_Stop.Image")));
            this.toolStripMain_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMain_Stop.Name = "toolStripMain_Stop";
            this.toolStripMain_Stop.Size = new System.Drawing.Size(52, 52);
            this.toolStripMain_Stop.Text = "toolStripButton1";
            // 
            // toolStripMain_Sound
            // 
            this.toolStripMain_Sound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMain_Sound.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMain_Sound.Image")));
            this.toolStripMain_Sound.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMain_Sound.Name = "toolStripMain_Sound";
            this.toolStripMain_Sound.Size = new System.Drawing.Size(52, 52);
            this.toolStripMain_Sound.Text = "toolStripButton1";
            // 
            // toolStripMain_Stats
            // 
            this.toolStripMain_Stats.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMain_Stats.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMain_Stats.Image")));
            this.toolStripMain_Stats.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMain_Stats.Name = "toolStripMain_Stats";
            this.toolStripMain_Stats.Size = new System.Drawing.Size(52, 52);
            this.toolStripMain_Stats.Text = "toolStripButton1";
            // 
            // toolStripMain_Settings
            // 
            this.toolStripMain_Settings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMain_Settings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMain_Settings.Image")));
            this.toolStripMain_Settings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMain_Settings.Name = "toolStripMain_Settings";
            this.toolStripMain_Settings.Size = new System.Drawing.Size(52, 52);
            this.toolStripMain_Settings.Text = "toolStripButton1";
            // 
            // toolStripMain_About
            // 
            this.toolStripMain_About.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMain_About.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMain_About.Image")));
            this.toolStripMain_About.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMain_About.Name = "toolStripMain_About";
            this.toolStripMain_About.Size = new System.Drawing.Size(52, 52);
            this.toolStripMain_About.Text = "toolStripButton1";
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 584);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.statusStrip.Size = new System.Drawing.Size(570, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip1";
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.Transparent;
            this.btnRed.Clicked = false;
            this.btnRed.ColorValue = 1;
            this.btnRed.Duration = 400;
            this.btnRed.ForeColor = System.Drawing.Color.Red;
            this.btnRed.Frequency = 330;
            this.btnRed.Location = new System.Drawing.Point(358, 15);
            this.btnRed.Name = "btnRed";
            this.btnRed.OuterAngleSpan = 5F;
            this.btnRed.Rotation = 90;
            this.btnRed.Size = new System.Drawing.Size(334, 307);
            this.btnRed.TabIndex = 0;
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.Visible = false;
            this.btnRed.WidthPercentage = 1F;
            this.btnRed.Click += new System.EventHandler(this.btnSimon_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.Transparent;
            this.btnBlue.Clicked = false;
            this.btnBlue.ColorValue = 2;
            this.btnBlue.Duration = 400;
            this.btnBlue.ForeColor = System.Drawing.Color.Blue;
            this.btnBlue.Frequency = 196;
            this.btnBlue.Location = new System.Drawing.Point(358, 330);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.OuterAngleSpan = 0F;
            this.btnBlue.Rotation = 180;
            this.btnBlue.Size = new System.Drawing.Size(334, 307);
            this.btnBlue.TabIndex = 3;
            this.btnBlue.UseVisualStyleBackColor = false;
            this.btnBlue.Visible = false;
            this.btnBlue.WidthPercentage = 1F;
            this.btnBlue.Click += new System.EventHandler(this.btnSimon_Click);
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.Transparent;
            this.btnGreen.Clicked = false;
            this.btnGreen.ColorValue = 0;
            this.btnGreen.Duration = 400;
            this.btnGreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnGreen.Frequency = 392;
            this.btnGreen.Location = new System.Drawing.Point(16, 15);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.OuterAngleSpan = 0F;
            this.btnGreen.Rotation = 0;
            this.btnGreen.Size = new System.Drawing.Size(334, 307);
            this.btnGreen.TabIndex = 1;
            this.btnGreen.UseVisualStyleBackColor = false;
            this.btnGreen.Visible = false;
            this.btnGreen.WidthPercentage = 0.1F;
            this.btnGreen.Click += new System.EventHandler(this.btnSimon_Click);
            // 
            // frmSimon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 606);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.simonBoard);
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.btnYellow);
            this.Controls.Add(this.btnGreen);
            this.Controls.Add(this.btnRed);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmSimon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simon Says — Memory Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSimon_FormClosing);
            this.Load += new System.EventHandler(this.frmSimon_Load);
            this.Resize += new System.EventHandler(this.frmSimon_Resize);
            this.simonBoard.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripPanel tspTop;
        private System.Windows.Forms.ToolStripPanel tspBottom;
        private ColorButton.SimonButton btnYellow;
        private System.Windows.Forms.Button btnStart;
        private CustomBoard.CustomBoard simonBoard;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripButton toolStripMain_Exit;
        private System.Windows.Forms.ToolStripButton toolStripMain_Start;
        private System.Windows.Forms.ToolStripButton toolStripMain_Stop;
        private System.Windows.Forms.ToolStripButton toolStripMain_Sound;
        private System.Windows.Forms.ToolStripButton toolStripMain_Stats;
        private System.Windows.Forms.ToolStripButton toolStripMain_Settings;
        private System.Windows.Forms.ToolStripButton toolStripMain_About;
        private ColorButton.SimonButton btnRed;
        private ColorButton.SimonButton btnBlue;
        private ColorButton.SimonButton btnGreen;
    }
}

