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
            this.button1 = new System.Windows.Forms.Button();
            this.simonButton2 = new SimonSays.SimonButton();
            this.SuspendLayout();
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // simonButton2
            // 
            this.simonButton2.AngleRotation = 0F;
            this.simonButton2.AngleSwept = 90F;
            this.simonButton2.BackColor = System.Drawing.Color.Transparent;
            this.simonButton2.CenterButton = ((System.Drawing.PointF)(resources.GetObject("simonButton2.CenterButton")));
            this.simonButton2.CenterRotation = ((System.Drawing.PointF)(resources.GetObject("simonButton2.CenterRotation")));
            this.simonButton2.Clicked = false;
            this.simonButton2.ClickOffset = ((System.Drawing.PointF)(resources.GetObject("simonButton2.ClickOffset")));
            this.simonButton2.Color = System.Drawing.Color.DarkRed;
            this.simonButton2.Duration = 350;
            this.simonButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simonButton2.Frequency = 432F;
            this.simonButton2.InnerRadius = 75F;
            this.simonButton2.Location = new System.Drawing.Point(23, 23);
            this.simonButton2.Name = "simonButton2";
            this.simonButton2.OuterRadius = 145F;
            this.simonButton2.RegionOffset = 1F;
            this.simonButton2.Size = new System.Drawing.Size(300, 300);
            this.simonButton2.TabIndex = 1;
            this.simonButton2.UseVisualStyleBackColor = false;
            this.simonButton2.Value = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 507);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.simonButton2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private SimonButton simonButton2;
        private System.Windows.Forms.Button button1;
    }
}