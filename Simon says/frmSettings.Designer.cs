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
            this.tabGame = new System.Windows.Forms.TabPage();
            this.tabInterface = new System.Windows.Forms.TabPage();
            this.DemoBoard = new SimonSays.CustomBoard();
            this.trackButtonDistance = new System.Windows.Forms.TrackBar();
            this.trackButtonInner = new System.Windows.Forms.TrackBar();
            this.trackButtonOuttter = new System.Windows.Forms.TrackBar();
            this.numButtonDistance = new System.Windows.Forms.NumericUpDown();
            this.lblButtonDistance = new System.Windows.Forms.Label();
            this.gridButtons = new System.Windows.Forms.DataGridView();
            this.ColValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numButtonMin = new System.Windows.Forms.NumericUpDown();
            this.numButtonMax = new System.Windows.Forms.NumericUpDown();
            this.lblButtonMin = new System.Windows.Forms.Label();
            this.lblButtonMax = new System.Windows.Forms.Label();
            this.trackButtons = new System.Windows.Forms.TrackBar();
            this.numButtons = new System.Windows.Forms.NumericUpDown();
            this.lblButtons = new System.Windows.Forms.Label();
            this.tabBoard = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.tabSettings.SuspendLayout();
            this.tabInterface.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtonDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtonInner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtonOuttter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numButtonDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numButtonMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numButtonMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numButtons)).BeginInit();
            this.tabBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBoardIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBoardOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoardIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoardOut)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabPlayMode);
            this.tabSettings.Controls.Add(this.tabGame);
            this.tabSettings.Controls.Add(this.tabInterface);
            this.tabSettings.Controls.Add(this.tabBoard);
            this.tabSettings.Location = new System.Drawing.Point(13, 13);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(4);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(618, 386);
            this.tabSettings.TabIndex = 0;
            // 
            // tabPlayMode
            // 
            this.tabPlayMode.Location = new System.Drawing.Point(4, 25);
            this.tabPlayMode.Margin = new System.Windows.Forms.Padding(4);
            this.tabPlayMode.Name = "tabPlayMode";
            this.tabPlayMode.Padding = new System.Windows.Forms.Padding(4);
            this.tabPlayMode.Size = new System.Drawing.Size(610, 357);
            this.tabPlayMode.TabIndex = 0;
            this.tabPlayMode.Text = "Play mode";
            this.tabPlayMode.UseVisualStyleBackColor = true;
            // 
            // tabGame
            // 
            this.tabGame.Location = new System.Drawing.Point(4, 25);
            this.tabGame.Name = "tabGame";
            this.tabGame.Padding = new System.Windows.Forms.Padding(3);
            this.tabGame.Size = new System.Drawing.Size(610, 357);
            this.tabGame.TabIndex = 2;
            this.tabGame.Text = "Game";
            this.tabGame.UseVisualStyleBackColor = true;
            // 
            // tabInterface
            // 
            this.tabInterface.Controls.Add(this.DemoBoard);
            this.tabInterface.Controls.Add(this.trackButtonDistance);
            this.tabInterface.Controls.Add(this.trackButtonInner);
            this.tabInterface.Controls.Add(this.trackButtonOuttter);
            this.tabInterface.Controls.Add(this.numButtonDistance);
            this.tabInterface.Controls.Add(this.lblButtonDistance);
            this.tabInterface.Controls.Add(this.gridButtons);
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
            this.tabInterface.Size = new System.Drawing.Size(610, 357);
            this.tabInterface.TabIndex = 1;
            this.tabInterface.Text = "Interface";
            this.tabInterface.UseVisualStyleBackColor = true;
            // 
            // DemoBoard
            // 
            this.DemoBoard.Location = new System.Drawing.Point(403, 150);
            this.DemoBoard.Name = "DemoBoard";
            this.DemoBoard.NumberOfButtons = 5;
            this.DemoBoard.OuterButtonRatio = 0.9F;
            this.DemoBoard.Size = new System.Drawing.Size(200, 200);
            this.DemoBoard.TabIndex = 18;
            // 
            // trackButtonDistance
            // 
            this.trackButtonDistance.BackColor = System.Drawing.Color.White;
            this.trackButtonDistance.Location = new System.Drawing.Point(229, 160);
            this.trackButtonDistance.Name = "trackButtonDistance";
            this.trackButtonDistance.Size = new System.Drawing.Size(174, 45);
            this.trackButtonDistance.TabIndex = 17;
            // 
            // trackButtonInner
            // 
            this.trackButtonInner.BackColor = System.Drawing.Color.White;
            this.trackButtonInner.Location = new System.Drawing.Point(229, 119);
            this.trackButtonInner.Name = "trackButtonInner";
            this.trackButtonInner.Size = new System.Drawing.Size(200, 45);
            this.trackButtonInner.TabIndex = 16;
            // 
            // trackButtonOuttter
            // 
            this.trackButtonOuttter.BackColor = System.Drawing.Color.White;
            this.trackButtonOuttter.Location = new System.Drawing.Point(229, 71);
            this.trackButtonOuttter.Name = "trackButtonOuttter";
            this.trackButtonOuttter.Size = new System.Drawing.Size(242, 45);
            this.trackButtonOuttter.TabIndex = 15;
            // 
            // numButtonDistance
            // 
            this.numButtonDistance.DecimalPlaces = 2;
            this.numButtonDistance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numButtonDistance.Location = new System.Drawing.Point(159, 160);
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
            this.lblButtonDistance.Location = new System.Drawing.Point(37, 162);
            this.lblButtonDistance.Name = "lblButtonDistance";
            this.lblButtonDistance.Size = new System.Drawing.Size(99, 16);
            this.lblButtonDistance.TabIndex = 13;
            this.lblButtonDistance.Text = "Button distance";
            // 
            // gridButtons
            // 
            this.gridButtons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridButtons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColValue,
            this.ColFrequency,
            this.ColColor});
            this.gridButtons.Location = new System.Drawing.Point(23, 203);
            this.gridButtons.Name = "gridButtons";
            this.gridButtons.Size = new System.Drawing.Size(287, 134);
            this.gridButtons.TabIndex = 12;
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
            // numButtonMin
            // 
            this.numButtonMin.DecimalPlaces = 2;
            this.numButtonMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numButtonMin.Location = new System.Drawing.Point(159, 119);
            this.numButtonMin.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numButtonMin.Name = "numButtonMin";
            this.numButtonMin.Size = new System.Drawing.Size(47, 22);
            this.numButtonMin.TabIndex = 9;
            // 
            // numButtonMax
            // 
            this.numButtonMax.DecimalPlaces = 2;
            this.numButtonMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numButtonMax.Location = new System.Drawing.Point(159, 81);
            this.numButtonMax.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numButtonMax.Name = "numButtonMax";
            this.numButtonMax.Size = new System.Drawing.Size(47, 22);
            this.numButtonMax.TabIndex = 8;
            // 
            // lblButtonMin
            // 
            this.lblButtonMin.AutoSize = true;
            this.lblButtonMin.Location = new System.Drawing.Point(37, 119);
            this.lblButtonMin.Name = "lblButtonMin";
            this.lblButtonMin.Size = new System.Drawing.Size(109, 16);
            this.lblButtonMin.TabIndex = 5;
            this.lblButtonMin.Text = "Button min radius";
            // 
            // lblButtonMax
            // 
            this.lblButtonMax.AutoSize = true;
            this.lblButtonMax.Location = new System.Drawing.Point(37, 81);
            this.lblButtonMax.Name = "lblButtonMax";
            this.lblButtonMax.Size = new System.Drawing.Size(113, 16);
            this.lblButtonMax.TabIndex = 4;
            this.lblButtonMax.Text = "Button max radius";
            // 
            // trackButtons
            // 
            this.trackButtons.BackColor = System.Drawing.Color.White;
            this.trackButtons.Location = new System.Drawing.Point(144, 30);
            this.trackButtons.Minimum = 2;
            this.trackButtons.Name = "trackButtons";
            this.trackButtons.Size = new System.Drawing.Size(285, 45);
            this.trackButtons.TabIndex = 3;
            this.trackButtons.Value = 2;
            // 
            // numButtons
            // 
            this.numButtons.Location = new System.Drawing.Point(96, 34);
            this.numButtons.Margin = new System.Windows.Forms.Padding(4);
            this.numButtons.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numButtons.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numButtons.Name = "numButtons";
            this.numButtons.Size = new System.Drawing.Size(41, 22);
            this.numButtons.TabIndex = 2;
            this.numButtons.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numButtons.ValueChanged += new System.EventHandler(this.numButtons_ValueChanged);
            // 
            // lblButtons
            // 
            this.lblButtons.AutoSize = true;
            this.lblButtons.Location = new System.Drawing.Point(37, 35);
            this.lblButtons.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblButtons.Name = "lblButtons";
            this.lblButtons.Size = new System.Drawing.Size(52, 16);
            this.lblButtons.TabIndex = 1;
            this.lblButtons.Text = "Buttons";
            // 
            // tabBoard
            // 
            this.tabBoard.Controls.Add(this.pictureBox3);
            this.tabBoard.Controls.Add(this.pictureBox2);
            this.tabBoard.Controls.Add(this.pictureBox1);
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
            this.tabBoard.Size = new System.Drawing.Size(610, 357);
            this.tabBoard.TabIndex = 3;
            this.tabBoard.Text = "Board UI";
            this.tabBoard.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(181, 237);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(46, 30);
            this.pictureBox3.TabIndex = 24;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(188, 190);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 30);
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(199, 144);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 31);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // lblFontFamily
            // 
            this.lblFontFamily.AutoSize = true;
            this.lblFontFamily.Location = new System.Drawing.Point(52, 278);
            this.lblFontFamily.Name = "lblFontFamily";
            this.lblFontFamily.Size = new System.Drawing.Size(85, 16);
            this.lblFontFamily.TabIndex = 21;
            this.lblFontFamily.Text = "Font famnily: ";
            // 
            // lblInColor
            // 
            this.lblInColor.AutoSize = true;
            this.lblInColor.Location = new System.Drawing.Point(52, 240);
            this.lblInColor.Name = "lblInColor";
            this.lblInColor.Size = new System.Drawing.Size(70, 16);
            this.lblInColor.TabIndex = 20;
            this.lblInColor.Text = "Inner color";
            // 
            // lblOutColor
            // 
            this.lblOutColor.AutoSize = true;
            this.lblOutColor.Location = new System.Drawing.Point(52, 195);
            this.lblOutColor.Name = "lblOutColor";
            this.lblOutColor.Size = new System.Drawing.Size(76, 16);
            this.lblOutColor.TabIndex = 19;
            this.lblOutColor.Text = "Outter color";
            // 
            // lblBoardBackground
            // 
            this.lblBoardBackground.AutoSize = true;
            this.lblBoardBackground.Location = new System.Drawing.Point(52, 148);
            this.lblBoardBackground.Name = "lblBoardBackground";
            this.lblBoardBackground.Size = new System.Drawing.Size(114, 16);
            this.lblBoardBackground.TabIndex = 18;
            this.lblBoardBackground.Text = "Background color";
            // 
            // trackBoardIn
            // 
            this.trackBoardIn.BackColor = System.Drawing.Color.White;
            this.trackBoardIn.Location = new System.Drawing.Point(248, 96);
            this.trackBoardIn.Name = "trackBoardIn";
            this.trackBoardIn.Size = new System.Drawing.Size(282, 45);
            this.trackBoardIn.TabIndex = 17;
            // 
            // trackBoardOut
            // 
            this.trackBoardOut.BackColor = System.Drawing.Color.White;
            this.trackBoardOut.Location = new System.Drawing.Point(248, 51);
            this.trackBoardOut.Name = "trackBoardOut";
            this.trackBoardOut.Size = new System.Drawing.Size(283, 45);
            this.trackBoardOut.TabIndex = 16;
            // 
            // numBoardIn
            // 
            this.numBoardIn.DecimalPlaces = 2;
            this.numBoardIn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numBoardIn.Location = new System.Drawing.Point(183, 96);
            this.numBoardIn.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBoardIn.Name = "numBoardIn";
            this.numBoardIn.Size = new System.Drawing.Size(47, 22);
            this.numBoardIn.TabIndex = 15;
            // 
            // numBoardOut
            // 
            this.numBoardOut.DecimalPlaces = 2;
            this.numBoardOut.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numBoardOut.Location = new System.Drawing.Point(183, 51);
            this.numBoardOut.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBoardOut.Name = "numBoardOut";
            this.numBoardOut.Size = new System.Drawing.Size(47, 22);
            this.numBoardOut.TabIndex = 14;
            // 
            // lblBoardMin
            // 
            this.lblBoardMin.AutoSize = true;
            this.lblBoardMin.Location = new System.Drawing.Point(52, 101);
            this.lblBoardMin.Name = "lblBoardMin";
            this.lblBoardMin.Size = new System.Drawing.Size(98, 16);
            this.lblBoardMin.TabIndex = 13;
            this.lblBoardMin.Text = "Board in radius";
            // 
            // lblBoardMax
            // 
            this.lblBoardMax.AutoSize = true;
            this.lblBoardMax.Location = new System.Drawing.Point(52, 54);
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
            this.btnAccept.Location = new System.Drawing.Point(401, 406);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 30);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "&Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(517, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 448);
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
            this.tabInterface.ResumeLayout(false);
            this.tabInterface.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtonDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtonInner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtonOuttter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numButtonDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numButtonMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numButtonMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numButtons)).EndInit();
            this.tabBoard.ResumeLayout(false);
            this.tabBoard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBoardIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBoardOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoardIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoardOut)).EndInit();
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
        private System.Windows.Forms.TabPage tabGame;
        private System.Windows.Forms.DataGridView gridButtons;
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
        private System.Windows.Forms.TrackBar trackButtonOuttter;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblFontFamily;
        private System.Windows.Forms.Label lblInColor;
        private System.Windows.Forms.Label lblOutColor;
        private SimonSays.CustomBoard DemoBoard;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColColor;
    }
}