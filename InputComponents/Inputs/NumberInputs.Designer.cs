namespace InputComponents
{
    partial class NumberInputs
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
            L1 = new Label();
            L2 = new Label();
            L3 = new Label();
            L4 = new Label();
            L5 = new Label();
            L6 = new Label();
            N6 = new NumericUpDown();
            N5 = new NumericUpDown();
            N4 = new NumericUpDown();
            N3 = new NumericUpDown();
            N2 = new NumericUpDown();
            N1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)N6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)N5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)N4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)N3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)N2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)N1).BeginInit();
            SuspendLayout();
            // 
            // L1
            // 
            L1.AutoSize = true;
            L1.Location = new Point(155, 4);
            L1.Name = "L1";
            L1.Size = new Size(12, 15);
            L1.TabIndex = 6;
            L1.Text = "-";
            // 
            // L2
            // 
            L2.AutoSize = true;
            L2.Location = new Point(155, 28);
            L2.Name = "L2";
            L2.RightToLeft = RightToLeft.Yes;
            L2.Size = new Size(12, 15);
            L2.TabIndex = 7;
            L2.Text = "-";
            // 
            // L3
            // 
            L3.AutoSize = true;
            L3.Location = new Point(155, 53);
            L3.Name = "L3";
            L3.RightToLeft = RightToLeft.No;
            L3.Size = new Size(12, 15);
            L3.TabIndex = 8;
            L3.Text = "-";
            // 
            // L4
            // 
            L4.AutoSize = true;
            L4.Location = new Point(155, 78);
            L4.Name = "L4";
            L4.Size = new Size(12, 15);
            L4.TabIndex = 9;
            L4.Text = "-";
            // 
            // L5
            // 
            L5.AutoSize = true;
            L5.Location = new Point(155, 103);
            L5.Name = "L5";
            L5.Size = new Size(12, 15);
            L5.TabIndex = 10;
            L5.Text = "-";
            // 
            // L6
            // 
            L6.AutoSize = true;
            L6.Location = new Point(155, 128);
            L6.Name = "L6";
            L6.Size = new Size(12, 15);
            L6.TabIndex = 11;
            L6.Text = "-";
            // 
            // N6
            // 
            N6.DecimalPlaces = 2;
            N6.Location = new Point(18, 126);
            N6.Margin = new Padding(3, 2, 3, 2);
            N6.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            N6.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            N6.Name = "N6";
            N6.Size = new Size(131, 23);
            N6.TabIndex = 3;
            N6.ValueChanged += N6_ValueChanged;
            // 
            // N5
            // 
            N5.DecimalPlaces = 2;
            N5.Location = new Point(18, 101);
            N5.Margin = new Padding(3, 2, 3, 2);
            N5.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            N5.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            N5.Name = "N5";
            N5.Size = new Size(131, 23);
            N5.TabIndex = 2;
            N5.ValueChanged += N5_ValueChanged;
            // 
            // N4
            // 
            N4.DecimalPlaces = 2;
            N4.Location = new Point(18, 76);
            N4.Margin = new Padding(3, 2, 3, 2);
            N4.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            N4.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            N4.Name = "N4";
            N4.Size = new Size(131, 23);
            N4.TabIndex = 1;
            N4.ValueChanged += N4_ValueChanged;
            // 
            // N3
            // 
            N3.DecimalPlaces = 2;
            N3.Location = new Point(18, 52);
            N3.Margin = new Padding(3, 2, 3, 2);
            N3.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            N3.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            N3.Name = "N3";
            N3.Size = new Size(131, 23);
            N3.TabIndex = 4;
            N3.ValueChanged += N3_ValueChanged;
            // 
            // N2
            // 
            N2.DecimalPlaces = 2;
            N2.Location = new Point(18, 27);
            N2.Margin = new Padding(3, 2, 3, 2);
            N2.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            N2.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            N2.Name = "N2";
            N2.Size = new Size(131, 23);
            N2.TabIndex = 0;
            N2.ValueChanged += N2_ValueChanged;
            // 
            // N1
            // 
            N1.DecimalPlaces = 2;
            N1.Location = new Point(18, 2);
            N1.Margin = new Padding(3, 2, 3, 2);
            N1.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            N1.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            N1.Name = "N1";
            N1.Size = new Size(131, 23);
            N1.TabIndex = 5;
            N1.ValueChanged += N1_ValueChanged;
            // 
            // NumberInputs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(347, 147);
            Controls.Add(L6);
            Controls.Add(L5);
            Controls.Add(L4);
            Controls.Add(L3);
            Controls.Add(L2);
            Controls.Add(L1);
            Controls.Add(N1);
            Controls.Add(N3);
            Controls.Add(N6);
            Controls.Add(N5);
            Controls.Add(N4);
            Controls.Add(N2);
            Margin = new Padding(3, 2, 3, 2);
            Name = "NumberInputs";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)N6).EndInit();
            ((System.ComponentModel.ISupportInitialize)N5).EndInit();
            ((System.ComponentModel.ISupportInitialize)N4).EndInit();
            ((System.ComponentModel.ISupportInitialize)N3).EndInit();
            ((System.ComponentModel.ISupportInitialize)N2).EndInit();
            ((System.ComponentModel.ISupportInitialize)N1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label L1;
        private Label L2;
        private Label L3;
        private Label L4;
        private Label L5;
        private Label L6;
        private NumericUpDown N6;
        private NumericUpDown N5;
        private NumericUpDown N4;
        private NumericUpDown N3;
        private NumericUpDown N2;
        private NumericUpDown N1;
    }
}