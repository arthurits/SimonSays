using System.Drawing;

namespace SimonSays
{
    partial class frmSettings
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
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabPlayMode = new System.Windows.Forms.TabPage();
            this.chkWaiting = new System.Windows.Forms.CheckBox();
            this.chkSpeed = new System.Windows.Forms.CheckBox();
            this.numWaiting = new System.Windows.Forms.NumericUpDown();
            this.trackWaiting = new System.Windows.Forms.TrackBar();
            this.groupMode = new System.Windows.Forms.GroupBox();
            this.radRewind = new System.Windows.Forms.RadioButton();
            this.radSurprise = new System.Windows.Forms.RadioButton();
            this.radBounce = new System.Windows.Forms.RadioButton();
            this.radChoose = new System.Windows.Forms.RadioButton();
            this.radAdds = new System.Windows.Forms.RadioButton();
            this.radClassic = new System.Windows.Forms.RadioButton();
            this.tabInterface = new System.Windows.Forms.TabPage();
            this.trackButtonClick = new System.Windows.Forms.TrackBar();
            this.numButtonClick = new System.Windows.Forms.NumericUpDown();
            this.lblButtonClick = new System.Windows.Forms.Label();
            this.trackButtonDistance = new System.Windows.Forms.TrackBar();
            this.trackButtonInner = new System.Windows.Forms.TrackBar();
            this.trackButtonOuter = new System.Windows.Forms.TrackBar();
            this.numButtonDistance = new System.Windows.Forms.NumericUpDown();
            this.lblButtonDistance = new System.Windows.Forms.Label();
            this.numButtonMin = new System.Windows.Forms.NumericUpDown();
            this.numButtonMax = new System.Windows.Forms.NumericUpDown();
            this.lblButtonMin = new System.Windows.Forms.Label();
            this.lblButtonMax = new System.Windows.Forms.Label();
            this.trackButtons = new System.Windows.Forms.TrackBar();
            this.numButtons = new System.Windows.Forms.NumericUpDown();
            this.lblButtons = new System.Windows.Forms.Label();
            this.tabBoard = new System.Windows.Forms.TabPage();
            this.trackBoardRotation = new System.Windows.Forms.TrackBar();
            this.numBoardRotation = new System.Windows.Forms.NumericUpDown();
            this.lblBoardRotation = new System.Windows.Forms.Label();
            this.chkStartUp = new System.Windows.Forms.CheckBox();
            this.btnFontFamily = new System.Windows.Forms.Button();
            this.pctIn = new System.Windows.Forms.PictureBox();
            this.pctOut = new System.Windows.Forms.PictureBox();
            this.pctBack = new System.Windows.Forms.PictureBox();
            this.lblFontFamily = new System.Windows.Forms.Label();
            this.lblInColor = new System.Windows.Forms.Label();
            this.lblOutColor = new System.Windows.Forms.Label();
            this.lblBoardBackground = new System.Windows.Forms.Label();
            this.trackBoardIn = new System.Windows.Forms.TrackBar();
            this.trackBoardOut = new System.Windows.Forms.TrackBar();
            this.numBoardIn = new System.Windows.Forms.NumericUpDown();
            this.numBoardOut = new System.Windows.Forms.NumericUpDown();
            this.lblBoardMin = new System.Windows.Forms.Label();
            this.lblBoardMax = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gridButtons = new System.Windows.Forms.DataGridView();
            this.ColValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DemoBoard = new SimonSays.CustomBoard();
            this.tabSettings.SuspendLayout();
            this.tabPlayMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWaiting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackWaiting)).BeginInit();
            this.groupMode.SuspendLayout();
            this.tabInterface.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtonClick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numButtonClick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtonDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtonInner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtonOuter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numButtonDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numButtonMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numButtonMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numButtons)).BeginInit();
            this.tabBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBoardRotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoardRotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBoardIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBoardOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoardIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoardOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridButtons)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabPlayMode);
            this.tabSettings.Controls.Add(this.tabInterface);
            this.tabSettings.Controls.Add(this.tabBoard);
            this.tabSettings.Location = new System.Drawing.Point(13, 13);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(4);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(468, 386);
            this.tabSettings.TabIndex = 0;
            // 
            // tabPlayMode
            // 
            this.tabPlayMode.Controls.Add(this.chkWaiting);
            this.tabPlayMode.Controls.Add(this.chkSpeed);
            this.tabPlayMode.Controls.Add(this.numWaiting);
            this.tabPlayMode.Controls.Add(this.trackWaiting);
            this.tabPlayMode.Controls.Add(this.groupMode);
            this.tabPlayMode.Location = new System.Drawing.Point(4, 25);
            this.tabPlayMode.Margin = new System.Windows.Forms.Padding(4);
            this.tabPlayMode.Name = "tabPlayMode";
            this.tabPlayMode.Padding = new System.Windows.Forms.Padding(4);
            this.tabPlayMode.Size = new System.Drawing.Size(460, 357);
            this.tabPlayMode.TabIndex = 0;
            this.tabPlayMode.Text = "Play mode";
            this.tabPlayMode.UseVisualStyleBackColor = true;
            // 
            // chkWaiting
            // 
            this.chkWaiting.AutoSize = true;
            this.chkWaiting.Location = new System.Drawing.Point(30, 246);
            this.chkWaiting.Name = "chkWaiting";
            this.chkWaiting.Size = new System.Drawing.Size(219, 20);
            this.chkWaiting.TabIndex = 5;
            this.chkWaiting.Text = "Maximum waiting time (seconds)";
            this.chkWaiting.UseVisualStyleBackColor = true;
            this.chkWaiting.CheckedChanged += new System.EventHandler(this.chkWaiting_CheckedChanged);
            // 
            // chkSpeed
            // 
            this.chkSpeed.AutoSize = true;
            this.chkSpeed.Location = new System.Drawing.Point(30, 200);
            this.chkSpeed.Name = "chkSpeed";
            this.chkSpeed.Size = new System.Drawing.Size(283, 20);
            this.chkSpeed.TabIndex = 4;
            this.chkSpeed.Text = "Speed up Simon flashing (currently 5-13-31)";
            this.chkSpeed.UseVisualStyleBackColor = true;
            // 
            // numWaiting
            // 
            this.numWaiting.Location = new System.Drawing.Point(59, 290);
            this.numWaiting.Name = "numWaiting";
            this.numWaiting.Size = new System.Drawing.Size(47, 22);
            this.numWaiting.TabIndex = 3;
            this.numWaiting.ValueChanged += new System.EventHandler(this.numWaiting_ValueChanged);
            // 
            // trackWaiting
            // 
            this.trackWaiting.BackColor = System.Drawing.Color.White;
            this.trackWaiting.Location = new System.Drawing.Point(121, 290);
            this.trackWaiting.Maximum = 100;
            this.trackWaiting.Name = "trackWaiting";
            this.trackWaiting.Size = new System.Drawing.Size(315, 45);
            this.trackWaiting.TabIndex = 2;
            this.trackWaiting.TickFrequency = 10;
            this.trackWaiting.ValueChanged += new System.EventHandler(this.trackWaiting_ValueChanged);
            // 
            // groupMode
            // 
            this.groupMode.Controls.Add(this.radRewind);
            this.groupMode.Controls.Add(this.radSurprise);
            this.groupMode.Controls.Add(this.radBounce);
            this.groupMode.Controls.Add(this.radChoose);
            this.groupMode.Controls.Add(this.radAdds);
            this.groupMode.Controls.Add(this.radClassic);
            this.groupMode.Location = new System.Drawing.Point(30, 30);
            this.groupMode.Name = "groupMode";
            this.groupMode.Size = new System.Drawing.Size(406, 136);
            this.groupMode.TabIndex = 0;
            this.groupMode.TabStop = false;
            this.groupMode.Text = "Game mode";
            // 
            // radRewind
            // 
            this.radRewind.AutoSize = true;
            this.radRewind.Location = new System.Drawing.Point(243, 88);
            this.radRewind.Name = "radRewind";
            this.radRewind.Size = new System.Drawing.Size(106, 20);
            this.radRewind.TabIndex = 5;
            this.radRewind.TabStop = true;
            this.radRewind.Text = "Simon rewind";
            this.radRewind.UseVisualStyleBackColor = true;
            // 
            // radSurprise
            // 
            this.radSurprise.AutoSize = true;
            this.radSurprise.Location = new System.Drawing.Point(243, 59);
            this.radSurprise.Name = "radSurprise";
            this.radSurprise.Size = new System.Drawing.Size(115, 20);
            this.radSurprise.TabIndex = 4;
            this.radSurprise.TabStop = true;
            this.radSurprise.Text = "Simon surprise";
            this.radSurprise.UseVisualStyleBackColor = true;
            this.radSurprise.CheckedChanged += new System.EventHandler(this.radSurprise_CheckedChanged);
            // 
            // radBounce
            // 
            this.radBounce.AutoSize = true;
            this.radBounce.Location = new System.Drawing.Point(243, 30);
            this.radBounce.Name = "radBounce";
            this.radBounce.Size = new System.Drawing.Size(112, 20);
            this.radBounce.TabIndex = 3;
            this.radBounce.TabStop = true;
            this.radBounce.Text = "Simon bounce";
            this.radBounce.UseVisualStyleBackColor = true;
            // 
            // radChoose
            // 
            this.radChoose.AutoSize = true;
            this.radChoose.Enabled = false;
            this.radChoose.Location = new System.Drawing.Point(29, 88);
            this.radChoose.Name = "radChoose";
            this.radChoose.Size = new System.Drawing.Size(135, 20);
            this.radChoose.TabIndex = 2;
            this.radChoose.TabStop = true;
            this.radChoose.Text = "Choose your color";
            this.radChoose.UseVisualStyleBackColor = true;
            // 
            // radAdds
            // 
            this.radAdds.AutoSize = true;
            this.radAdds.Enabled = false;
            this.radAdds.Location = new System.Drawing.Point(29, 59);
            this.radAdds.Name = "radAdds";
            this.radAdds.Size = new System.Drawing.Size(99, 20);
            this.radAdds.TabIndex = 1;
            this.radAdds.TabStop = true;
            this.radAdds.Text = "Player adds";
            this.radAdds.UseVisualStyleBackColor = true;
            // 
            // radClassic
            // 
            this.radClassic.AutoSize = true;
            this.radClassic.Location = new System.Drawing.Point(29, 30);
            this.radClassic.Name = "radClassic";
            this.radClassic.Size = new System.Drawing.Size(147, 20);
            this.radClassic.TabIndex = 0;
            this.radClassic.TabStop = true;
            this.radClassic.Text = "Simon classic mode";
            this.radClassic.UseVisualStyleBackColor = true;
            // 
            // tabInterface
            // 
            this.tabInterface.Controls.Add(this.trackButtonClick);
            this.tabInterface.Controls.Add(this.numButtonClick);
            this.tabInterface.Controls.Add(this.lblButtonClick);
            this.tabInterface.Controls.Add(this.trackButtonDistance);
            this.tabInterface.Controls.Add(this.trackButtonInner);
            this.tabInterface.Controls.Add(this.trackButtonOuter);
            this.tabInterface.Controls.Add(this.numButtonDistance);
            this.tabInterface.Controls.Add(this.lblButtonDistance);
            this.tabInterface.Controls.Add(this.numButtonMin);
            this.tabInterface.Controls.Add(this.numButtonMax);
            this.tabInterface.Controls.Add(this.lblButtonMin);
            this.tabInterface.Controls.Add(this.lblButtonMax);
            this.tabInterface.Controls.Add(this.trackButtons);
            this.tabInterface.Controls.Add(this.numButtons);
            this.tabInterface.Controls.Add(this.lblButtons);
            this.tabInterface.Location = new System.Drawing.Point(4, 25);
            this.tabInterface.Margin = new System.Windows.Forms.Padding(4);
            this.tabInterface.Name = "tabInterface";
            this.tabInterface.Padding = new System.Windows.Forms.Padding(4);
            this.tabInterface.Size = new System.Drawing.Size(460, 357);
            this.tabInterface.TabIndex = 1;
            this.tabInterface.Text = "Interface";
            this.tabInterface.UseVisualStyleBackColor = true;
            // 
            // trackButtonClick
            // 
            this.trackButtonClick.BackColor = System.Drawing.Color.White;
            this.trackButtonClick.Location = new System.Drawing.Point(222, 234);
            this.trackButtonClick.Maximum = 100;
            this.trackButtonClick.Name = "trackButtonClick";
            this.trackButtonClick.Size = new System.Drawing.Size(200, 45);
            this.trackButtonClick.TabIndex = 21;
            this.trackButtonClick.TickFrequency = 10;
            this.trackButtonClick.ValueChanged += new System.EventHandler(this.trackButtonClick_ValueChanged);
            // 
            // numButtonClick
            // 
            this.numButtonClick.DecimalPlaces = 2;
            this.numButtonClick.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numButtonClick.Location = new System.Drawing.Point(152, 234);
            this.numButtonClick.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numButtonClick.Name = "numButtonClick";
            this.numButtonClick.Size = new System.Drawing.Size(47, 22);
            this.numButtonClick.TabIndex = 20;
            this.numButtonClick.ValueChanged += new System.EventHandler(this.numButtonClick_ValueChanged);
            // 
            // lblButtonClick
            // 
            this.lblButtonClick.AutoSize = true;
            this.lblButtonClick.Location = new System.Drawing.Point(30, 237);
            this.lblButtonClick.Name = "lblButtonClick";
            this.lblButtonClick.Size = new System.Drawing.Size(110, 16);
            this.lblButtonClick.TabIndex = 19;
            this.lblButtonClick.Text = "Button click offset";
            // 
            // trackButtonDistance
            // 
            this.trackButtonDistance.BackColor = System.Drawing.Color.White;
            this.trackButtonDistance.Location = new System.Drawing.Point(222, 189);
            this.trackButtonDistance.Maximum = 100;
            this.trackButtonDistance.Name = "trackButtonDistance";
            this.trackButtonDistance.Size = new System.Drawing.Size(200, 45);
            this.trackButtonDistance.TabIndex = 17;
            this.trackButtonDistance.TickFrequency = 10;
            this.trackButtonDistance.ValueChanged += new System.EventHandler(this.trackButtonDistance_ValueChanged);
            // 
            // trackButtonInner
            // 
            this.trackButtonInner.BackColor = System.Drawing.Color.White;
            this.trackButtonInner.Location = new System.Drawing.Point(222, 144);
            this.trackButtonInner.Maximum = 100;
            this.trackButtonInner.Name = "trackButtonInner";
            this.trackButtonInner.Size = new System.Drawing.Size(200, 45);
            this.trackButtonInner.TabIndex = 16;
            this.trackButtonInner.TickFrequency = 10;
            this.trackButtonInner.ValueChanged += new System.EventHandler(this.trackButtonInner_ValueChanged);
            // 
            // trackButtonOuter
            // 
            this.trackButtonOuter.BackColor = System.Drawing.Color.White;
            this.trackButtonOuter.Location = new System.Drawing.Point(222, 97);
            this.trackButtonOuter.Maximum = 100;
            this.trackButtonOuter.Name = "trackButtonOuter";
            this.trackButtonOuter.Size = new System.Drawing.Size(200, 45);
            this.trackButtonOuter.TabIndex = 15;
            this.trackButtonOuter.TickFrequency = 10;
            this.trackButtonOuter.ValueChanged += new System.EventHandler(this.trackButtonOuter_ValueChanged);
            // 
            // numButtonDistance
            // 
            this.numButtonDistance.DecimalPlaces = 2;
            this.numButtonDistance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numButtonDistance.Location = new System.Drawing.Point(152, 189);
            this.numButtonDistance.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numButtonDistance.Name = "numButtonDistance";
            this.numButtonDistance.Size = new System.Drawing.Size(47, 22);
            this.numButtonDistance.TabIndex = 14;
            this.numButtonDistance.ValueChanged += new System.EventHandler(this.numButtonDistance_ValueChanged);
            // 
            // lblButtonDistance
            // 
            this.lblButtonDistance.AutoSize = true;
            this.lblButtonDistance.Location = new System.Drawing.Point(30, 191);
            this.lblButtonDistance.Name = "lblButtonDistance";
            this.lblButtonDistance.Size = new System.Drawing.Size(99, 16);
            this.lblButtonDistance.TabIndex = 13;
            this.lblButtonDistance.Text = "Button distance";
            // 
            // numButtonMin
            // 
            this.numButtonMin.DecimalPlaces = 2;
            this.numButtonMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numButtonMin.Location = new System.Drawing.Point(152, 144);
            this.numButtonMin.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numButtonMin.Name = "numButtonMin";
            this.numButtonMin.Size = new System.Drawing.Size(47, 22);
            this.numButtonMin.TabIndex = 9;
            this.numButtonMin.ValueChanged += new System.EventHandler(this.numButtonMin_ValueChanged);
            // 
            // numButtonMax
            // 
            this.numButtonMax.DecimalPlaces = 2;
            this.numButtonMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numButtonMax.Location = new System.Drawing.Point(152, 97);
            this.numButtonMax.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numButtonMax.Name = "numButtonMax";
            this.numButtonMax.Size = new System.Drawing.Size(47, 22);
            this.numButtonMax.TabIndex = 8;
            this.numButtonMax.ValueChanged += new System.EventHandler(this.numButtonMax_ValueChanged);
            // 
            // lblButtonMin
            // 
            this.lblButtonMin.AutoSize = true;
            this.lblButtonMin.Location = new System.Drawing.Point(30, 144);
            this.lblButtonMin.Name = "lblButtonMin";
            this.lblButtonMin.Size = new System.Drawing.Size(109, 16);
            this.lblButtonMin.TabIndex = 5;
            this.lblButtonMin.Text = "Button min radius";
            // 
            // lblButtonMax
            // 
            this.lblButtonMax.AutoSize = true;
            this.lblButtonMax.Location = new System.Drawing.Point(30, 97);
            this.lblButtonMax.Name = "lblButtonMax";
            this.lblButtonMax.Size = new System.Drawing.Size(113, 16);
            this.lblButtonMax.TabIndex = 4;
            this.lblButtonMax.Text = "Button max radius";
            // 
            // trackButtons
            // 
            this.trackButtons.BackColor = System.Drawing.Color.White;
            this.trackButtons.Location = new System.Drawing.Point(137, 45);
            this.trackButtons.Minimum = 2;
            this.trackButtons.Name = "trackButtons";
            this.trackButtons.Size = new System.Drawing.Size(285, 45);
            this.trackButtons.TabIndex = 3;
            this.trackButtons.Value = 2;
            this.trackButtons.ValueChanged += new System.EventHandler(this.trackButtons_ValueChanged);
            // 
            // numButtons
            // 
            this.numButtons.Location = new System.Drawing.Point(89, 49);
            this.numButtons.Margin = new System.Windows.Forms.Padding(4);
            this.numButtons.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numButtons.Name = "numButtons";
            this.numButtons.Size = new System.Drawing.Size(41, 22);
            this.numButtons.TabIndex = 2;
            this.numButtons.ValueChanged += new System.EventHandler(this.numButtons_ValueChanged);
            // 
            // lblButtons
            // 
            this.lblButtons.AutoSize = true;
            this.lblButtons.Location = new System.Drawing.Point(30, 50);
            this.lblButtons.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblButtons.Name = "lblButtons";
            this.lblButtons.Size = new System.Drawing.Size(52, 16);
            this.lblButtons.TabIndex = 1;
            this.lblButtons.Text = "Buttons";
            // 
            // tabBoard
            // 
            this.tabBoard.Controls.Add(this.trackBoardRotation);
            this.tabBoard.Controls.Add(this.numBoardRotation);
            this.tabBoard.Controls.Add(this.lblBoardRotation);
            this.tabBoard.Controls.Add(this.chkStartUp);
            this.tabBoard.Controls.Add(this.btnFontFamily);
            this.tabBoard.Controls.Add(this.pctIn);
            this.tabBoard.Controls.Add(this.pctOut);
            this.tabBoard.Controls.Add(this.pctBack);
            this.tabBoard.Controls.Add(this.lblFontFamily);
            this.tabBoard.Controls.Add(this.lblInColor);
            this.tabBoard.Controls.Add(this.lblOutColor);
            this.tabBoard.Controls.Add(this.lblBoardBackground);
            this.tabBoard.Controls.Add(this.trackBoardIn);
            this.tabBoard.Controls.Add(this.trackBoardOut);
            this.tabBoard.Controls.Add(this.numBoardIn);
            this.tabBoard.Controls.Add(this.numBoardOut);
            this.tabBoard.Controls.Add(this.lblBoardMin);
            this.tabBoard.Controls.Add(this.lblBoardMax);
            this.tabBoard.Location = new System.Drawing.Point(4, 25);
            this.tabBoard.Name = "tabBoard";
            this.tabBoard.Padding = new System.Windows.Forms.Padding(3);
            this.tabBoard.Size = new System.Drawing.Size(460, 357);
            this.tabBoard.TabIndex = 3;
            this.tabBoard.Text = "Board UI";
            this.tabBoard.UseVisualStyleBackColor = true;
            // 
            // trackBoardRotation
            // 
            this.trackBoardRotation.BackColor = System.Drawing.Color.White;
            this.trackBoardRotation.Location = new System.Drawing.Point(213, 141);
            this.trackBoardRotation.Maximum = 360;
            this.trackBoardRotation.Name = "trackBoardRotation";
            this.trackBoardRotation.Size = new System.Drawing.Size(231, 45);
            this.trackBoardRotation.TabIndex = 29;
            this.trackBoardRotation.TickFrequency = 30;
            this.trackBoardRotation.ValueChanged += new System.EventHandler(this.trackBoardRotation_ValueChanged);
            // 
            // numBoardRotation
            // 
            this.numBoardRotation.DecimalPlaces = 2;
            this.numBoardRotation.Location = new System.Drawing.Point(148, 141);
            this.numBoardRotation.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numBoardRotation.Name = "numBoardRotation";
            this.numBoardRotation.Size = new System.Drawing.Size(47, 22);
            this.numBoardRotation.TabIndex = 28;
            this.numBoardRotation.ValueChanged += new System.EventHandler(this.numBoardRotation_ValueChanged);
            // 
            // lblBoardRotation
            // 
            this.lblBoardRotation.AutoSize = true;
            this.lblBoardRotation.Location = new System.Drawing.Point(30, 144);
            this.lblBoardRotation.Name = "lblBoardRotation";
            this.lblBoardRotation.Size = new System.Drawing.Size(107, 16);
            this.lblBoardRotation.TabIndex = 27;
            this.lblBoardRotation.Text = "Board rotation (°)";
            // 
            // chkStartUp
            // 
            this.chkStartUp.AutoSize = true;
            this.chkStartUp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkStartUp.Location = new System.Drawing.Point(27, 314);
            this.chkStartUp.Name = "chkStartUp";
            this.chkStartUp.Size = new System.Drawing.Size(242, 20);
            this.chkStartUp.TabIndex = 26;
            this.chkStartUp.Text = "Remeber window position on startup";
            this.chkStartUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkStartUp.UseVisualStyleBackColor = true;
            // 
            // btnFontFamily
            // 
            this.btnFontFamily.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFontFamily.Location = new System.Drawing.Point(203, 268);
            this.btnFontFamily.Name = "btnFontFamily";
            this.btnFontFamily.Size = new System.Drawing.Size(76, 21);
            this.btnFontFamily.TabIndex = 25;
            this.btnFontFamily.Text = "Select font...";
            this.btnFontFamily.UseVisualStyleBackColor = true;
            this.btnFontFamily.Click += new System.EventHandler(this.btnFontFamily_Click);
            // 
            // pctIn
            // 
            this.pctIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctIn.Location = new System.Drawing.Point(353, 219);
            this.pctIn.Name = "pctIn";
            this.pctIn.Size = new System.Drawing.Size(50, 25);
            this.pctIn.TabIndex = 24;
            this.pctIn.TabStop = false;
            this.pctIn.BackColorChanged += new System.EventHandler(this.pctIn_BackColorChanged);
            this.pctIn.Click += new System.EventHandler(this.pctIn_Click);
            // 
            // pctOut
            // 
            this.pctOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctOut.Location = new System.Drawing.Point(211, 219);
            this.pctOut.Name = "pctOut";
            this.pctOut.Size = new System.Drawing.Size(50, 25);
            this.pctOut.TabIndex = 23;
            this.pctOut.TabStop = false;
            this.pctOut.BackColorChanged += new System.EventHandler(this.pctOut_BackColorChanged);
            this.pctOut.Click += new System.EventHandler(this.pctOut_Click);
            // 
            // pctBack
            // 
            this.pctBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctBack.Location = new System.Drawing.Point(62, 219);
            this.pctBack.Name = "pctBack";
            this.pctBack.Size = new System.Drawing.Size(50, 25);
            this.pctBack.TabIndex = 22;
            this.pctBack.TabStop = false;
            this.pctBack.BackColorChanged += new System.EventHandler(this.pctBack_BackColorChanged);
            this.pctBack.Click += new System.EventHandler(this.pctBack_Click);
            // 
            // lblFontFamily
            // 
            this.lblFontFamily.AutoSize = true;
            this.lblFontFamily.Location = new System.Drawing.Point(30, 271);
            this.lblFontFamily.Name = "lblFontFamily";
            this.lblFontFamily.Size = new System.Drawing.Size(78, 16);
            this.lblFontFamily.TabIndex = 21;
            this.lblFontFamily.Text = "Font family: ";
            // 
            // lblInColor
            // 
            this.lblInColor.AutoSize = true;
            this.lblInColor.Location = new System.Drawing.Point(343, 195);
            this.lblInColor.Name = "lblInColor";
            this.lblInColor.Size = new System.Drawing.Size(70, 16);
            this.lblInColor.TabIndex = 20;
            this.lblInColor.Text = "Inner color";
            // 
            // lblOutColor
            // 
            this.lblOutColor.AutoSize = true;
            this.lblOutColor.Location = new System.Drawing.Point(198, 195);
            this.lblOutColor.Name = "lblOutColor";
            this.lblOutColor.Size = new System.Drawing.Size(76, 16);
            this.lblOutColor.TabIndex = 19;
            this.lblOutColor.Text = "Outter color";
            // 
            // lblBoardBackground
            // 
            this.lblBoardBackground.AutoSize = true;
            this.lblBoardBackground.Location = new System.Drawing.Point(30, 195);
            this.lblBoardBackground.Name = "lblBoardBackground";
            this.lblBoardBackground.Size = new System.Drawing.Size(114, 16);
            this.lblBoardBackground.TabIndex = 18;
            this.lblBoardBackground.Text = "Background color";
            // 
            // trackBoardIn
            // 
            this.trackBoardIn.BackColor = System.Drawing.Color.White;
            this.trackBoardIn.Location = new System.Drawing.Point(213, 94);
            this.trackBoardIn.Maximum = 100;
            this.trackBoardIn.Name = "trackBoardIn";
            this.trackBoardIn.Size = new System.Drawing.Size(231, 45);
            this.trackBoardIn.TabIndex = 17;
            this.trackBoardIn.TickFrequency = 10;
            this.trackBoardIn.ValueChanged += new System.EventHandler(this.trackBoardIn_ValueChanged);
            // 
            // trackBoardOut
            // 
            this.trackBoardOut.BackColor = System.Drawing.Color.White;
            this.trackBoardOut.Location = new System.Drawing.Point(213, 47);
            this.trackBoardOut.Maximum = 100;
            this.trackBoardOut.Name = "trackBoardOut";
            this.trackBoardOut.Size = new System.Drawing.Size(231, 45);
            this.trackBoardOut.TabIndex = 16;
            this.trackBoardOut.TickFrequency = 10;
            this.trackBoardOut.ValueChanged += new System.EventHandler(this.trackBoardOut_ValueChanged);
            // 
            // numBoardIn
            // 
            this.numBoardIn.DecimalPlaces = 2;
            this.numBoardIn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numBoardIn.Location = new System.Drawing.Point(148, 94);
            this.numBoardIn.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBoardIn.Name = "numBoardIn";
            this.numBoardIn.Size = new System.Drawing.Size(47, 22);
            this.numBoardIn.TabIndex = 15;
            this.numBoardIn.ValueChanged += new System.EventHandler(this.numBoardIn_ValueChanged);
            // 
            // numBoardOut
            // 
            this.numBoardOut.DecimalPlaces = 2;
            this.numBoardOut.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numBoardOut.Location = new System.Drawing.Point(148, 47);
            this.numBoardOut.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBoardOut.Name = "numBoardOut";
            this.numBoardOut.Size = new System.Drawing.Size(47, 22);
            this.numBoardOut.TabIndex = 14;
            this.numBoardOut.ValueChanged += new System.EventHandler(this.numBoardOut_ValueChanged);
            // 
            // lblBoardMin
            // 
            this.lblBoardMin.AutoSize = true;
            this.lblBoardMin.Location = new System.Drawing.Point(30, 97);
            this.lblBoardMin.Name = "lblBoardMin";
            this.lblBoardMin.Size = new System.Drawing.Size(98, 16);
            this.lblBoardMin.TabIndex = 13;
            this.lblBoardMin.Text = "Board in radius";
            // 
            // lblBoardMax
            // 
            this.lblBoardMax.AutoSize = true;
            this.lblBoardMax.Location = new System.Drawing.Point(30, 50);
            this.lblBoardMax.Name = "lblBoardMax";
            this.lblBoardMax.Size = new System.Drawing.Size(106, 16);
            this.lblBoardMax.TabIndex = 12;
            this.lblBoardMax.Text = "Board out radius";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(13, 406);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(110, 30);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(253, 406);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 30);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "&Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(369, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gridButtons
            // 
            this.gridButtons.AllowUserToAddRows = false;
            this.gridButtons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridButtons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColValue,
            this.ColFrequency,
            this.ColColor});
            this.gridButtons.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridButtons.Location = new System.Drawing.Point(488, 38);
            this.gridButtons.Name = "gridButtons";
            this.gridButtons.Size = new System.Drawing.Size(287, 192);
            this.gridButtons.TabIndex = 21;
            // 
            // ColValue
            // 
            this.ColValue.DataPropertyName = "Value";
            this.ColValue.HeaderText = "Value";
            this.ColValue.Name = "ColValue";
            this.ColValue.ReadOnly = true;
            this.ColValue.Width = 50;
            // 
            // ColFrequency
            // 
            this.ColFrequency.DataPropertyName = "Frequency";
            this.ColFrequency.HeaderText = "Frequency";
            this.ColFrequency.Name = "ColFrequency";
            this.ColFrequency.Width = 80;
            // 
            // ColColor
            // 
            this.ColColor.DataPropertyName = "Color";
            this.ColColor.HeaderText = "Color";
            this.ColColor.Name = "ColColor";
            // 
            // DemoBoard
            // 
            this.DemoBoard.BoardRotation = 0F;
            this.DemoBoard.ButtonClickOffset = 0F;
            this.DemoBoard.ButtonColors = new System.Drawing.Color[0];
            this.DemoBoard.ButtonFrequencies = new float[0];
            this.DemoBoard.CenterButtonRatio = 0F;
            this.DemoBoard.ColorBackground = System.Drawing.Color.Transparent;
            this.DemoBoard.ColorInnerCircle = System.Drawing.Color.White;
            this.DemoBoard.ColorOuterCircle = System.Drawing.Color.LightGray;
            this.DemoBoard.InnerButtonRatio = 0.55F;
            this.DemoBoard.Location = new System.Drawing.Point(531, 236);
            this.DemoBoard.Name = "DemoBoard";
            this.DemoBoard.NumberOfButtons = 4;
            this.DemoBoard.OuterButtonRatio = 0.95F;
            this.DemoBoard.PercentInnerRatio = 0.35F;
            this.DemoBoard.PercentOuterRatio = 0.9F;
            this.DemoBoard.Size = new System.Drawing.Size(200, 200);
            this.DemoBoard.TabIndex = 20;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 448);
            this.Controls.Add(this.gridButtons);
            this.Controls.Add(this.DemoBoard);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.tabSettings);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSettings";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSettings";
            this.tabSettings.ResumeLayout(false);
            this.tabPlayMode.ResumeLayout(false);
            this.tabPlayMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWaiting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackWaiting)).EndInit();
            this.groupMode.ResumeLayout(false);
            this.groupMode.PerformLayout();
            this.tabInterface.ResumeLayout(false);
            this.tabInterface.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtonClick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numButtonClick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtonDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtonInner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtonOuter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numButtonDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numButtonMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numButtonMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numButtons)).EndInit();
            this.tabBoard.ResumeLayout(false);
            this.tabBoard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBoardRotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoardRotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBoardIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBoardOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoardIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoardOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridButtons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabPlayMode;
        private System.Windows.Forms.TabPage tabInterface;
        private System.Windows.Forms.TrackBar trackButtons;
        private System.Windows.Forms.NumericUpDown numButtons;
        private System.Windows.Forms.Label lblButtons;
        private System.Windows.Forms.NumericUpDown numButtonMin;
        private System.Windows.Forms.NumericUpDown numButtonMax;
        private System.Windows.Forms.Label lblButtonMin;
        private System.Windows.Forms.Label lblButtonMax;
        private System.Windows.Forms.NumericUpDown numButtonDistance;
        private System.Windows.Forms.Label lblButtonDistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnColor;
        private System.Windows.Forms.TabPage tabBoard;
        private System.Windows.Forms.Label lblBoardBackground;
        private System.Windows.Forms.TrackBar trackBoardIn;
        private System.Windows.Forms.TrackBar trackBoardOut;
        private System.Windows.Forms.NumericUpDown numBoardIn;
        private System.Windows.Forms.NumericUpDown numBoardOut;
        private System.Windows.Forms.Label lblBoardMin;
        private System.Windows.Forms.Label lblBoardMax;
        private System.Windows.Forms.TrackBar trackButtonDistance;
        private System.Windows.Forms.TrackBar trackButtonInner;
        private System.Windows.Forms.TrackBar trackButtonOuter;
        private System.Windows.Forms.PictureBox pctIn;
        private System.Windows.Forms.PictureBox pctOut;
        private System.Windows.Forms.PictureBox pctBack;
        private System.Windows.Forms.Label lblFontFamily;
        private System.Windows.Forms.Label lblInColor;
        private System.Windows.Forms.Label lblOutColor;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFontFamily;
        private System.Windows.Forms.CheckBox chkStartUp;
        private System.Windows.Forms.TrackBar trackBoardRotation;
        private System.Windows.Forms.NumericUpDown numBoardRotation;
        private System.Windows.Forms.Label lblBoardRotation;
        private System.Windows.Forms.TrackBar trackButtonClick;
        private System.Windows.Forms.NumericUpDown numButtonClick;
        private System.Windows.Forms.Label lblButtonClick;
        private System.Windows.Forms.NumericUpDown numWaiting;
        private System.Windows.Forms.TrackBar trackWaiting;
        private System.Windows.Forms.GroupBox groupMode;
        private System.Windows.Forms.RadioButton radClassic;
        private System.Windows.Forms.RadioButton radChoose;
        private System.Windows.Forms.RadioButton radAdds;
        private System.Windows.Forms.RadioButton radSurprise;
        private System.Windows.Forms.RadioButton radBounce;
        private System.Windows.Forms.RadioButton radRewind;
        private System.Windows.Forms.CheckBox chkWaiting;
        private System.Windows.Forms.CheckBox chkSpeed;
        private CustomBoard DemoBoard;
        private System.Windows.Forms.DataGridView gridButtons;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColColor;
    }
}