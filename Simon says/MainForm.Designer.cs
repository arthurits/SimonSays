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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnBlue = new ColorButton.SimonButton();
            this.btnYellow = new ColorButton.SimonButton();
            this.btnGreen = new ColorButton.SimonButton();
            this.btnRed = new ColorButton.SimonButton();
            this.simonBoard = new CustomBoard.CustomBoard();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.Transparent;
            this.btnBlue.Clicked = false;
            this.btnBlue.ColorValue = 2;
            this.btnBlue.Duration = 400;
            this.btnBlue.ForeColor = System.Drawing.Color.Blue;
            this.btnBlue.Frequency = 196;
            this.btnBlue.Location = new System.Drawing.Point(268, 268);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.OuterAngleSpan = 0F;
            this.btnBlue.Rotation = 180;
            this.btnBlue.Size = new System.Drawing.Size(250, 250);
            this.btnBlue.TabIndex = 3;
            this.btnBlue.UseVisualStyleBackColor = false;
            this.btnBlue.Visible = false;
            this.btnBlue.WidthPercentage = 1F;
            this.btnBlue.Click += new System.EventHandler(this.btnSimon_Click);
            // 
            // btnYellow
            // 
            this.btnYellow.BackColor = System.Drawing.Color.Transparent;
            this.btnYellow.Clicked = false;
            this.btnYellow.ColorValue = 3;
            this.btnYellow.Duration = 400;
            this.btnYellow.ForeColor = System.Drawing.Color.Yellow;
            this.btnYellow.Frequency = 262;
            this.btnYellow.Location = new System.Drawing.Point(12, 268);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.OuterAngleSpan = 5F;
            this.btnYellow.Rotation = 270;
            this.btnYellow.Size = new System.Drawing.Size(250, 250);
            this.btnYellow.TabIndex = 2;
            this.btnYellow.UseVisualStyleBackColor = false;
            this.btnYellow.Visible = false;
            this.btnYellow.WidthPercentage = 1F;
            this.btnYellow.Click += new System.EventHandler(this.btnSimon_Click);
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.Transparent;
            this.btnGreen.Clicked = false;
            this.btnGreen.ColorValue = 0;
            this.btnGreen.Duration = 400;
            this.btnGreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnGreen.Frequency = 392;
            this.btnGreen.Location = new System.Drawing.Point(12, 12);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.OuterAngleSpan = 0F;
            this.btnGreen.Rotation = 0;
            this.btnGreen.Size = new System.Drawing.Size(250, 250);
            this.btnGreen.TabIndex = 1;
            this.btnGreen.UseVisualStyleBackColor = false;
            this.btnGreen.Visible = false;
            this.btnGreen.WidthPercentage = 0.1F;
            this.btnGreen.Click += new System.EventHandler(this.btnSimon_Click);
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.Transparent;
            this.btnRed.Clicked = false;
            this.btnRed.ColorValue = 1;
            this.btnRed.Duration = 400;
            this.btnRed.ForeColor = System.Drawing.Color.Red;
            this.btnRed.Frequency = 330;
            this.btnRed.Location = new System.Drawing.Point(268, 12);
            this.btnRed.Name = "btnRed";
            this.btnRed.OuterAngleSpan = 5F;
            this.btnRed.Rotation = 90;
            this.btnRed.Size = new System.Drawing.Size(250, 250);
            this.btnRed.TabIndex = 0;
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.Visible = false;
            this.btnRed.WidthPercentage = 1F;
            this.btnRed.Click += new System.EventHandler(this.btnSimon_Click);
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
            this.simonBoard.BlueButton.Location = new System.Drawing.Point(200, 185);
            this.simonBoard.BlueButton.Name = "btnBlue";
            this.simonBoard.BlueButton.OuterAngleSpan = 5F;
            this.simonBoard.BlueButton.Rotation = 180;
            this.simonBoard.BlueButton.Size = new System.Drawing.Size(292, 292);
            this.simonBoard.BlueButton.TabIndex = 0;
            this.simonBoard.BlueButton.WidthPercentage = 0.45F;
            this.simonBoard.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(240)))));
            this.simonBoard.ColorInnerCircle = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.simonBoard.ColorOuterCircle = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            // 
            // 
            // 
            this.simonBoard.GreenButton.Clicked = false;
            this.simonBoard.GreenButton.ColorValue = 0;
            this.simonBoard.GreenButton.Duration = 400;
            this.simonBoard.GreenButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.simonBoard.GreenButton.Frequency = 392;
            this.simonBoard.GreenButton.Location = new System.Drawing.Point(-6, -21);
            this.simonBoard.GreenButton.Name = "btnGreen";
            this.simonBoard.GreenButton.OuterAngleSpan = 5F;
            this.simonBoard.GreenButton.Rotation = 0;
            this.simonBoard.GreenButton.Size = new System.Drawing.Size(292, 292);
            this.simonBoard.GreenButton.TabIndex = 2;
            this.simonBoard.GreenButton.WidthPercentage = 0.45F;
            this.simonBoard.Location = new System.Drawing.Point(12, 41);
            this.simonBoard.Name = "simonBoard";
            // 
            // 
            // 
            this.simonBoard.RedButton.Clicked = false;
            this.simonBoard.RedButton.ColorValue = 1;
            this.simonBoard.RedButton.Duration = 400;
            this.simonBoard.RedButton.ForeColor = System.Drawing.Color.Red;
            this.simonBoard.RedButton.Frequency = 330;
            this.simonBoard.RedButton.Location = new System.Drawing.Point(200, -21);
            this.simonBoard.RedButton.Name = "btnRed";
            this.simonBoard.RedButton.OuterAngleSpan = 5F;
            this.simonBoard.RedButton.Rotation = 90;
            this.simonBoard.RedButton.Size = new System.Drawing.Size(292, 292);
            this.simonBoard.RedButton.TabIndex = 3;
            this.simonBoard.RedButton.WidthPercentage = 0.45F;
            this.simonBoard.ScoreHighest = 0;
            this.simonBoard.ScoreTotal = 0;
            this.simonBoard.Size = new System.Drawing.Size(488, 459);
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
            this.simonBoard.YellowButton.Location = new System.Drawing.Point(-6, 185);
            this.simonBoard.YellowButton.Name = "btnYellow";
            this.simonBoard.YellowButton.OuterAngleSpan = 5F;
            this.simonBoard.YellowButton.Rotation = 270;
            this.simonBoard.YellowButton.Size = new System.Drawing.Size(292, 292);
            this.simonBoard.YellowButton.TabIndex = 1;
            this.simonBoard.YellowButton.WidthPercentage = 0.45F;
            // 
            // frmSimon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 513);
            this.Controls.Add(this.simonBoard);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.btnYellow);
            this.Controls.Add(this.btnGreen);
            this.Controls.Add(this.btnRed);
            this.Name = "frmSimon";
            this.Text = "Simon Says — Memory Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSimon_FormClosing);
            this.Load += new System.EventHandler(this.frmSimon_Load);
            this.Resize += new System.EventHandler(this.frmSimon_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.SimonButton btnRed;
        private ColorButton.SimonButton btnGreen;
        private ColorButton.SimonButton btnYellow;
        private ColorButton.SimonButton btnBlue;
        private System.Windows.Forms.Button btnStart;
        private CustomBoard.CustomBoard simonBoard;
    }
}

