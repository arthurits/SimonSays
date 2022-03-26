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
            this.lblScoreCurrent = new System.Windows.Forms.Label();
            this.lblScoreTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblScoreCurrent
            // 
            this.lblScoreCurrent.AutoSize = true;
            this.lblScoreCurrent.BackColor = System.Drawing.Color.Transparent;
            this.lblScoreCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreCurrent.Location = new System.Drawing.Point(17, 13);
            this.lblScoreCurrent.Name = "lblScoreCurrent";
            this.lblScoreCurrent.Size = new System.Drawing.Size(93, 26);
            this.lblScoreCurrent.TabIndex = 4;
            this.lblScoreCurrent.Text = "Score: 0";
            this.lblScoreCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScoreTotal
            // 
            this.lblScoreTotal.AutoSize = true;
            this.lblScoreTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblScoreTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreTotal.Location = new System.Drawing.Point(16, 81);
            this.lblScoreTotal.Name = "lblScoreTotal";
            this.lblScoreTotal.Size = new System.Drawing.Size(110, 26);
            this.lblScoreTotal.TabIndex = 5;
            this.lblScoreTotal.Text = "Highest: 0";
            this.lblScoreTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustomBoard
            // 
            this.Controls.Add(this.lblScoreTotal);
            this.Controls.Add(this.lblScoreCurrent);
            this.DoubleBuffered = true;
            this.Name = "CustomBoard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblScoreCurrent;
        private System.Windows.Forms.Label lblScoreTotal;
    }
}
