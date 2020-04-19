namespace CustomBoard
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
            this.btnBlue = new ColorButton.customButton();
            this.btnYellow = new ColorButton.customButton();
            this.btnGreen = new ColorButton.customButton();
            this.btnRed = new ColorButton.customButton();
            this.SuspendLayout();
            // 
            // btnBlue
            // 
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
            // CustomBoard
            // 
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.btnYellow);
            this.Controls.Add(this.btnGreen);
            this.Controls.Add(this.btnRed);
            this.Name = "CustomBoard";
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.customButton btnRed;
        private ColorButton.customButton btnGreen;
        private ColorButton.customButton btnYellow;
        private ColorButton.customButton btnBlue;


    }
}
