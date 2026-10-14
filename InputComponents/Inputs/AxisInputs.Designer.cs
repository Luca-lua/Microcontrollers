namespace InputComponents
{
    partial class AxisInputs
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
            AxisUD = new TrackBar();
            AxisLR = new TrackBar();
            Placeholder = new Label();
            ((System.ComponentModel.ISupportInitialize)AxisUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AxisLR).BeginInit();
            SuspendLayout();
            // 
            // AxisUD
            // 
            AxisUD.Cursor = Cursors.SizeNS;
            AxisUD.Location = new Point(12, 0);
            AxisUD.Maximum = 100;
            AxisUD.Minimum = -100;
            AxisUD.Name = "AxisUD";
            AxisUD.Orientation = Orientation.Vertical;
            AxisUD.Size = new Size(56, 250);
            AxisUD.TabIndex = 0;
            AxisUD.TickFrequency = 25;
            AxisUD.ValueChanged += AxisUD_ValueChanged;
            // 
            // AxisLR
            // 
            AxisLR.Cursor = Cursors.SizeWE;
            AxisLR.Location = new Point(74, 114);
            AxisLR.Maximum = 100;
            AxisLR.Minimum = -100;
            AxisLR.Name = "AxisLR";
            AxisLR.Size = new Size(250, 56);
            AxisLR.TabIndex = 1;
            AxisLR.TickFrequency = 25;
            AxisLR.ValueChanged += AxisLR_ValueChanged;
            // 
            // Placeholder
            // 
            Placeholder.AutoSize = true;
            Placeholder.Location = new Point(272, 18);
            Placeholder.Name = "Placeholder";
            Placeholder.Size = new Size(0, 20);
            Placeholder.TabIndex = 2;
            // 
            // AxisInputs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 253);
            Controls.Add(Placeholder);
            Controls.Add(AxisUD);
            Controls.Add(AxisLR);
            Name = "AxisInputs";
            Text = "AxisInputs";
            ((System.ComponentModel.ISupportInitialize)AxisUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)AxisLR).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar AxisUD;
        private TrackBar AxisLR;
        private Label Placeholder;
    }
}