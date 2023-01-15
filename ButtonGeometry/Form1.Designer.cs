namespace ButtonGeometry
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pctDraw = new System.Windows.Forms.PictureBox();
            this.trackOuterRadius = new System.Windows.Forms.TrackBar();
            this.lblOuterRadius = new System.Windows.Forms.Label();
            this.lblCorner = new System.Windows.Forms.Label();
            this.trackCorner = new System.Windows.Forms.TrackBar();
            this.updOuterRadius = new System.Windows.Forms.NumericUpDown();
            this.updCorner = new System.Windows.Forms.NumericUpDown();
            this.updButtons = new System.Windows.Forms.NumericUpDown();
            this.lblButtons = new System.Windows.Forms.Label();
            this.trackButtons = new System.Windows.Forms.TrackBar();
            this.lblInnerRadius = new System.Windows.Forms.Label();
            this.updInnerRadius = new System.Windows.Forms.NumericUpDown();
            this.trackInnerRadius = new System.Windows.Forms.TrackBar();
            this.lblSeparation = new System.Windows.Forms.Label();
            this.updSeparation = new System.Windows.Forms.NumericUpDown();
            this.trackSeparation = new System.Windows.Forms.TrackBar();
            this.chkPoints = new System.Windows.Forms.CheckBox();
            this.chkRectangles = new System.Windows.Forms.CheckBox();
            this.chkCircles = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctDraw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackOuterRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCorner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updOuterRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updCorner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updInnerRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackInnerRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updSeparation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSeparation)).BeginInit();
            this.SuspendLayout();
            // 
            // pctDraw
            // 
            this.pctDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pctDraw.Location = new System.Drawing.Point(12, 124);
            this.pctDraw.Name = "pctDraw";
            this.pctDraw.Size = new System.Drawing.Size(776, 550);
            this.pctDraw.TabIndex = 0;
            this.pctDraw.TabStop = false;
            // 
            // trackOuterRadius
            // 
            this.trackOuterRadius.Location = new System.Drawing.Point(181, 8);
            this.trackOuterRadius.Name = "trackOuterRadius";
            this.trackOuterRadius.Size = new System.Drawing.Size(206, 45);
            this.trackOuterRadius.TabIndex = 1;
            this.trackOuterRadius.ValueChanged += new System.EventHandler(this.TrackOuterRadius_ValueChanged);
            // 
            // lblOuterRadius
            // 
            this.lblOuterRadius.AutoSize = true;
            this.lblOuterRadius.Location = new System.Drawing.Point(12, 14);
            this.lblOuterRadius.Name = "lblOuterRadius";
            this.lblOuterRadius.Size = new System.Drawing.Size(86, 19);
            this.lblOuterRadius.TabIndex = 2;
            this.lblOuterRadius.Text = "Outer radius";
            // 
            // lblCorner
            // 
            this.lblCorner.AutoSize = true;
            this.lblCorner.Location = new System.Drawing.Point(405, 14);
            this.lblCorner.Name = "lblCorner";
            this.lblCorner.Size = new System.Drawing.Size(92, 19);
            this.lblCorner.TabIndex = 3;
            this.lblCorner.Text = "Corner radius";
            // 
            // trackCorner
            // 
            this.trackCorner.Location = new System.Drawing.Point(574, 14);
            this.trackCorner.Name = "trackCorner";
            this.trackCorner.Size = new System.Drawing.Size(214, 45);
            this.trackCorner.TabIndex = 4;
            this.trackCorner.ValueChanged += new System.EventHandler(this.TrackCorner_ValueChanged);
            // 
            // updOuterRadius
            // 
            this.updOuterRadius.Location = new System.Drawing.Point(110, 12);
            this.updOuterRadius.Name = "updOuterRadius";
            this.updOuterRadius.Size = new System.Drawing.Size(55, 25);
            this.updOuterRadius.TabIndex = 5;
            this.updOuterRadius.ValueChanged += new System.EventHandler(this.UpdOuterRadius_ValueChanged);
            // 
            // updCorner
            // 
            this.updCorner.Location = new System.Drawing.Point(503, 12);
            this.updCorner.Name = "updCorner";
            this.updCorner.Size = new System.Drawing.Size(55, 25);
            this.updCorner.TabIndex = 6;
            this.updCorner.ValueChanged += new System.EventHandler(this.UpdCorner_ValueChanged);
            // 
            // updButtons
            // 
            this.updButtons.Location = new System.Drawing.Point(505, 46);
            this.updButtons.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.updButtons.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.updButtons.Name = "updButtons";
            this.updButtons.Size = new System.Drawing.Size(55, 25);
            this.updButtons.TabIndex = 7;
            this.updButtons.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.updButtons.ValueChanged += new System.EventHandler(this.UpdButtons_ValueChanged);
            // 
            // lblButtons
            // 
            this.lblButtons.AutoSize = true;
            this.lblButtons.Location = new System.Drawing.Point(436, 48);
            this.lblButtons.Name = "lblButtons";
            this.lblButtons.Size = new System.Drawing.Size(57, 19);
            this.lblButtons.TabIndex = 8;
            this.lblButtons.Text = "Buttons";
            // 
            // trackButtons
            // 
            this.trackButtons.Location = new System.Drawing.Point(574, 46);
            this.trackButtons.Maximum = 20;
            this.trackButtons.Minimum = 2;
            this.trackButtons.Name = "trackButtons";
            this.trackButtons.Size = new System.Drawing.Size(214, 45);
            this.trackButtons.TabIndex = 9;
            this.trackButtons.Value = 2;
            this.trackButtons.ValueChanged += new System.EventHandler(this.TrackButtons_ValueChanged);
            // 
            // lblInnerRadius
            // 
            this.lblInnerRadius.AutoSize = true;
            this.lblInnerRadius.Location = new System.Drawing.Point(12, 48);
            this.lblInnerRadius.Name = "lblInnerRadius";
            this.lblInnerRadius.Size = new System.Drawing.Size(82, 19);
            this.lblInnerRadius.TabIndex = 10;
            this.lblInnerRadius.Text = "Inner radius";
            // 
            // updInnerRadius
            // 
            this.updInnerRadius.Location = new System.Drawing.Point(110, 46);
            this.updInnerRadius.Name = "updInnerRadius";
            this.updInnerRadius.Size = new System.Drawing.Size(55, 25);
            this.updInnerRadius.TabIndex = 11;
            this.updInnerRadius.ValueChanged += new System.EventHandler(this.UpdInnerRadius_ValueChanged);
            // 
            // trackInnerRadius
            // 
            this.trackInnerRadius.Location = new System.Drawing.Point(181, 46);
            this.trackInnerRadius.Maximum = 100;
            this.trackInnerRadius.Name = "trackInnerRadius";
            this.trackInnerRadius.Size = new System.Drawing.Size(206, 45);
            this.trackInnerRadius.TabIndex = 12;
            this.trackInnerRadius.ValueChanged += new System.EventHandler(this.TrackInnerRadius_ValueChanged);
            // 
            // lblSeparation
            // 
            this.lblSeparation.AutoSize = true;
            this.lblSeparation.Location = new System.Drawing.Point(12, 82);
            this.lblSeparation.Name = "lblSeparation";
            this.lblSeparation.Size = new System.Drawing.Size(89, 19);
            this.lblSeparation.TabIndex = 13;
            this.lblSeparation.Text = "Button space";
            // 
            // updSeparation
            // 
            this.updSeparation.Location = new System.Drawing.Point(110, 80);
            this.updSeparation.Name = "updSeparation";
            this.updSeparation.Size = new System.Drawing.Size(55, 25);
            this.updSeparation.TabIndex = 14;
            this.updSeparation.ValueChanged += new System.EventHandler(this.UpdSeparation_ValueChanged);
            // 
            // trackSeparation
            // 
            this.trackSeparation.Location = new System.Drawing.Point(181, 84);
            this.trackSeparation.Maximum = 100;
            this.trackSeparation.Name = "trackSeparation";
            this.trackSeparation.Size = new System.Drawing.Size(206, 45);
            this.trackSeparation.TabIndex = 15;
            this.trackSeparation.TickFrequency = 10;
            this.trackSeparation.ValueChanged += new System.EventHandler(this.TrackSeparation_ValueChanged);
            // 
            // chkPoints
            // 
            this.chkPoints.AutoSize = true;
            this.chkPoints.Checked = true;
            this.chkPoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPoints.Location = new System.Drawing.Point(405, 84);
            this.chkPoints.Name = "chkPoints";
            this.chkPoints.Size = new System.Drawing.Size(103, 23);
            this.chkPoints.TabIndex = 16;
            this.chkPoints.Text = "Show points";
            this.chkPoints.UseVisualStyleBackColor = true;
            this.chkPoints.CheckedChanged += new System.EventHandler(this.Show_CheckedChanged);
            // 
            // chkRectangles
            // 
            this.chkRectangles.AutoSize = true;
            this.chkRectangles.Checked = true;
            this.chkRectangles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRectangles.Location = new System.Drawing.Point(534, 84);
            this.chkRectangles.Name = "chkRectangles";
            this.chkRectangles.Size = new System.Drawing.Size(127, 23);
            this.chkRectangles.TabIndex = 17;
            this.chkRectangles.Text = "Show rectangles";
            this.chkRectangles.UseVisualStyleBackColor = true;
            this.chkRectangles.CheckedChanged += new System.EventHandler(this.Show_CheckedChanged);
            // 
            // chkCircles
            // 
            this.chkCircles.AutoSize = true;
            this.chkCircles.Checked = true;
            this.chkCircles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCircles.Location = new System.Drawing.Point(687, 84);
            this.chkCircles.Name = "chkCircles";
            this.chkCircles.Size = new System.Drawing.Size(101, 23);
            this.chkCircles.TabIndex = 18;
            this.chkCircles.Text = "Show circles";
            this.chkCircles.UseVisualStyleBackColor = true;
            this.chkCircles.CheckedChanged += new System.EventHandler(this.Show_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 686);
            this.Controls.Add(this.chkCircles);
            this.Controls.Add(this.chkRectangles);
            this.Controls.Add(this.chkPoints);
            this.Controls.Add(this.trackSeparation);
            this.Controls.Add(this.updSeparation);
            this.Controls.Add(this.lblSeparation);
            this.Controls.Add(this.trackInnerRadius);
            this.Controls.Add(this.updInnerRadius);
            this.Controls.Add(this.lblInnerRadius);
            this.Controls.Add(this.trackButtons);
            this.Controls.Add(this.lblButtons);
            this.Controls.Add(this.updButtons);
            this.Controls.Add(this.updCorner);
            this.Controls.Add(this.updOuterRadius);
            this.Controls.Add(this.trackCorner);
            this.Controls.Add(this.lblCorner);
            this.Controls.Add(this.lblOuterRadius);
            this.Controls.Add(this.trackOuterRadius);
            this.Controls.Add(this.pctDraw);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Button geometry";
            ((System.ComponentModel.ISupportInitialize)(this.pctDraw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackOuterRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCorner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updOuterRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updCorner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updInnerRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackInnerRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updSeparation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSeparation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pctDraw;
        private TrackBar trackOuterRadius;
        private Label lblOuterRadius;
        private Label lblCorner;
        private TrackBar trackCorner;
        private NumericUpDown updOuterRadius;
        private NumericUpDown updCorner;
        private NumericUpDown updButtons;
        private Label lblButtons;
        private TrackBar trackButtons;
        private Label lblInnerRadius;
        private NumericUpDown updInnerRadius;
        private TrackBar trackInnerRadius;
        private Label lblSeparation;
        private NumericUpDown updSeparation;
        private TrackBar trackSeparation;
        private CheckBox chkPoints;
        private CheckBox chkRectangles;
        private CheckBox chkCircles;
    }
}