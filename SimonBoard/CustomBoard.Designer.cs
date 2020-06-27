namespace SimonSays
{
    partial class CustomBoard
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBlue = new ColorButton.SimonButton();
            this.btnYellow = new ColorButton.SimonButton();
            this.btnGreen = new ColorButton.SimonButton();
            this.btnRed = new ColorButton.SimonButton();
            this.lblScoreCurrent = new System.Windows.Forms.Label();
            this.lblScoreTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBlue
            // 
            this.btnBlue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBlue.BackColor = System.Drawing.Color.Transparent;
            this.btnBlue.Clicked = false;
            this.btnBlue.ColorValue = 2;
            this.btnBlue.Duration = 400;
            this.btnBlue.ForeColor = System.Drawing.Color.Blue;
            this.btnBlue.Frequency = 165;
            this.btnBlue.Location = new System.Drawing.Point(75, 75);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.OuterAngleSpan = 0F;
            this.btnBlue.Rotation = 0;
            this.btnBlue.Size = new System.Drawing.Size(75, 75);
            this.btnBlue.TabIndex = 0;
            this.btnBlue.UseVisualStyleBackColor = false;
            this.btnBlue.WidthPercentage = 1F;
            // 
            // btnYellow
            // 
            this.btnYellow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnYellow.BackColor = System.Drawing.Color.Transparent;
            this.btnYellow.Clicked = false;
            this.btnYellow.ColorValue = 3;
            this.btnYellow.Duration = 400;
            this.btnYellow.ForeColor = System.Drawing.Color.Yellow;
            this.btnYellow.Frequency = 165;
            this.btnYellow.Location = new System.Drawing.Point(0, 72);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.OuterAngleSpan = 0F;
            this.btnYellow.Rotation = 0;
            this.btnYellow.Size = new System.Drawing.Size(75, 75);
            this.btnYellow.TabIndex = 1;
            this.btnYellow.UseVisualStyleBackColor = false;
            this.btnYellow.WidthPercentage = 1F;
            // 
            // btnGreen
            // 
            this.btnGreen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGreen.BackColor = System.Drawing.Color.Transparent;
            this.btnGreen.Clicked = false;
            this.btnGreen.ColorValue = 0;
            this.btnGreen.Duration = 400;
            this.btnGreen.ForeColor = System.Drawing.Color.Green;
            this.btnGreen.Frequency = 165;
            this.btnGreen.Location = new System.Drawing.Point(0, 0);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.OuterAngleSpan = 0F;
            this.btnGreen.Rotation = 0;
            this.btnGreen.Size = new System.Drawing.Size(75, 75);
            this.btnGreen.TabIndex = 2;
            this.btnGreen.UseVisualStyleBackColor = false;
            this.btnGreen.WidthPercentage = 1F;
            // 
            // btnRed
            // 
            this.btnRed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRed.BackColor = System.Drawing.Color.Transparent;
            this.btnRed.Clicked = false;
            this.btnRed.ColorValue = 1;
            this.btnRed.Duration = 400;
            this.btnRed.ForeColor = System.Drawing.Color.Red;
            this.btnRed.Frequency = 165;
            this.btnRed.Location = new System.Drawing.Point(75, 0);
            this.btnRed.Name = "btnRed";
            this.btnRed.OuterAngleSpan = 0F;
            this.btnRed.Rotation = 0;
            this.btnRed.Size = new System.Drawing.Size(75, 75);
            this.btnRed.TabIndex = 3;
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.WidthPercentage = 1F;
            // 
            // lblScoreCurrent
            // 
            this.lblScoreCurrent.BackColor = System.Drawing.Color.Transparent;
            this.lblScoreCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreCurrent.Location = new System.Drawing.Point(17, 13);
            this.lblScoreCurrent.Name = "lblScoreCurrent";
            this.lblScoreCurrent.Size = new System.Drawing.Size(130, 30);
            this.lblScoreCurrent.TabIndex = 4;
            this.lblScoreCurrent.Text = "Score: 0";
            this.lblScoreCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScoreTotal
            // 
            this.lblScoreTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblScoreTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreTotal.Location = new System.Drawing.Point(16, 81);
            this.lblScoreTotal.Name = "lblScoreTotal";
            this.lblScoreTotal.Size = new System.Drawing.Size(130, 30);
            this.lblScoreTotal.TabIndex = 5;
            this.lblScoreTotal.Text = "Highest: 0";
            this.lblScoreTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustomBoard
            // 
            this.Controls.Add(this.lblScoreTotal);
            this.Controls.Add(this.lblScoreCurrent);
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.btnYellow);
            this.Controls.Add(this.btnGreen);
            this.Controls.Add(this.btnRed);
            this.Name = "CustomBoard";
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.SimonButton btnRed;
        private ColorButton.SimonButton btnGreen;
        private ColorButton.SimonButton btnYellow;
        private ColorButton.SimonButton btnBlue;
        private System.Windows.Forms.Label lblScoreCurrent;
        private System.Windows.Forms.Label lblScoreTotal;
    }
}
