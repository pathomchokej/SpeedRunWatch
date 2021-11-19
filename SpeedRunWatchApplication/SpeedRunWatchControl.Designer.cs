
namespace SpeedRunWatchApplication
{
    partial class SpeedRunWatchControl
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
            this.labelRealTime = new System.Windows.Forms.Label();
            this.labelSpeedRunTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelRealTime
            // 
            this.labelRealTime.BackColor = System.Drawing.Color.Black;
            this.labelRealTime.ForeColor = System.Drawing.Color.White;
            this.labelRealTime.Location = new System.Drawing.Point(0, 0);
            this.labelRealTime.Name = "labelRealTime";
            this.labelRealTime.Size = new System.Drawing.Size(484, 84);
            this.labelRealTime.TabIndex = 0;
            this.labelRealTime.Text = "label1";
            this.labelRealTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelRealTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnLabelMouseDown);
            this.labelRealTime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnLabelMouseUp);
            // 
            // labelSpeedRunTime
            // 
            this.labelSpeedRunTime.BackColor = System.Drawing.Color.Black;
            this.labelSpeedRunTime.ForeColor = System.Drawing.Color.White;
            this.labelSpeedRunTime.Location = new System.Drawing.Point(0, 78);
            this.labelSpeedRunTime.Name = "labelSpeedRunTime";
            this.labelSpeedRunTime.Size = new System.Drawing.Size(484, 84);
            this.labelSpeedRunTime.TabIndex = 1;
            this.labelSpeedRunTime.Text = "label1";
            this.labelSpeedRunTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSpeedRunTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnLabelMouseDown);
            this.labelSpeedRunTime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnLabelMouseUp);
            // 
            // SpeedRunWatchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelSpeedRunTime);
            this.Controls.Add(this.labelRealTime);
            this.Name = "SpeedRunWatchControl";
            this.Size = new System.Drawing.Size(484, 241);
            this.Load += new System.EventHandler(this.SpeedRunWatchControl_Load);
            this.Resize += new System.EventHandler(this.SpeedRunWatchControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelRealTime;
        private System.Windows.Forms.Label labelSpeedRunTime;
    }
}
