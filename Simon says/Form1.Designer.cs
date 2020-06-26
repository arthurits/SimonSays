namespace SimonSays
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.simonButton1 = new ColorButton.SimonButton();
            this.button1 = new System.Windows.Forms.Button();
            this.simonButton21 = new SimonSays.SimonButton2();
            this.SuspendLayout();
            // 
            // simonButton1
            // 
            this.simonButton1.BackColor = System.Drawing.Color.Red;
            this.simonButton1.Clicked = false;
            this.simonButton1.ColorValue = 1;
            this.simonButton1.Duration = 420;
            this.simonButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simonButton1.ForeColor = System.Drawing.Color.Aqua;
            this.simonButton1.Frequency = 165;
            this.simonButton1.Location = new System.Drawing.Point(355, 93);
            this.simonButton1.Name = "simonButton1";
            this.simonButton1.OuterAngleSpan = 88F;
            this.simonButton1.Rotation = 0;
            this.simonButton1.Size = new System.Drawing.Size(320, 320);
            this.simonButton1.TabIndex = 0;
            this.simonButton1.Text = "simonButton1";
            this.simonButton1.UseVisualStyleBackColor = false;
            this.simonButton1.WidthPercentage = 50F;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(460, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 55);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // simonButton21
            // 
            this.simonButton21.AngleRotation = 0F;
            this.simonButton21.AngleSwept = 90F;
            this.simonButton21.BackColor = System.Drawing.Color.Transparent;
            this.simonButton21.CenterButton = ((System.Drawing.PointF)(resources.GetObject("simonButton21.CenterButton")));
            this.simonButton21.CenterRotation = ((System.Drawing.PointF)(resources.GetObject("simonButton21.CenterRotation")));
            this.simonButton21.Clicked = false;
            this.simonButton21.ClickOffset = ((System.Drawing.PointF)(resources.GetObject("simonButton21.ClickOffset")));
            this.simonButton21.Color = System.Drawing.Color.DarkRed;
            this.simonButton21.Duration = 350;
            this.simonButton21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simonButton21.Frequency = 432F;
            this.simonButton21.InnerRadius = 75F;
            this.simonButton21.Location = new System.Drawing.Point(23, 23);
            this.simonButton21.Name = "simonButton21";
            this.simonButton21.OutterRadius = 145F;
            this.simonButton21.RegionOffset = 1F;
            this.simonButton21.Size = new System.Drawing.Size(300, 300);
            this.simonButton21.TabIndex = 1;
            this.simonButton21.UseVisualStyleBackColor = false;
            this.simonButton21.Value = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.simonButton21);
            this.Controls.Add(this.simonButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ColorButton.SimonButton simonButton1;
        private SimonButton2 simonButton21;
        private System.Windows.Forms.Button button1;
    }
}