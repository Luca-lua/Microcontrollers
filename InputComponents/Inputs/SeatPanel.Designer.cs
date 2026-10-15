namespace InputComponents.Inputs
{
    partial class SeatPanel
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
            Track_A_D = new TrackBar();
            ADL = new Label();
            fontDialog1 = new FontDialog();
            Track_W_S = new TrackBar();
            Reset_A_D = new Button();
            WSL = new Label();
            Reset_W_S = new Button();
            Reset_U_D = new Button();
            UDL = new Label();
            Reset_L_R = new Button();
            Track_U_D = new TrackBar();
            LRL = new Label();
            Track_L_R = new TrackBar();
            B1 = new CheckBox();
            B2 = new CheckBox();
            B3 = new CheckBox();
            B4 = new CheckBox();
            B5 = new CheckBox();
            B6 = new CheckBox();
            B7 = new CheckBox();
            B8 = new CheckBox();
            B9 = new CheckBox();
            B0 = new CheckBox();
            BSPACE = new CheckBox();
            progressBar1 = new ProgressBar();
            BOCCUPIED = new CheckBox();
            Track_View_X = new TrackBar();
            Track_View_Y = new TrackBar();
            VXL = new Label();
            VYL = new Label();
            ((System.ComponentModel.ISupportInitialize)Track_A_D).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Track_W_S).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Track_U_D).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Track_L_R).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Track_View_X).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Track_View_Y).BeginInit();
            SuspendLayout();
            // 
            // Track_A_D
            // 
            Track_A_D.Location = new Point(12, 133);
            Track_A_D.Maximum = 100;
            Track_A_D.Minimum = -100;
            Track_A_D.Name = "Track_A_D";
            Track_A_D.Size = new Size(200, 56);
            Track_A_D.TabIndex = 0;
            Track_A_D.TickStyle = TickStyle.Both;
            Track_A_D.ValueChanged += Track_A_D_ValueChanged;
            // 
            // ADL
            // 
            ADL.AutoSize = true;
            ADL.Location = new Point(76, 110);
            ADL.Name = "ADL";
            ADL.Size = new Size(70, 20);
            ADL.TabIndex = 1;
            ADL.Text = "Axis: A/D";
            // 
            // Track_W_S
            // 
            Track_W_S.BackColor = SystemColors.ButtonFace;
            Track_W_S.Location = new Point(218, 56);
            Track_W_S.Maximum = 100;
            Track_W_S.Minimum = -100;
            Track_W_S.Name = "Track_W_S";
            Track_W_S.Orientation = Orientation.Vertical;
            Track_W_S.Size = new Size(56, 200);
            Track_W_S.TabIndex = 2;
            Track_W_S.TickStyle = TickStyle.Both;
            Track_W_S.ValueChanged += Track_W_S_ValueChanged;
            // 
            // Reset_A_D
            // 
            Reset_A_D.Location = new Point(64, 184);
            Reset_A_D.Name = "Reset_A_D";
            Reset_A_D.Size = new Size(94, 29);
            Reset_A_D.TabIndex = 3;
            Reset_A_D.Text = "Reset: A/D";
            Reset_A_D.UseVisualStyleBackColor = true;
            Reset_A_D.Click += Reset_A_D_Click;
            // 
            // WSL
            // 
            WSL.AutoSize = true;
            WSL.Location = new Point(209, 33);
            WSL.Name = "WSL";
            WSL.Size = new Size(71, 20);
            WSL.TabIndex = 4;
            WSL.Text = "Axis: W/S";
            // 
            // Reset_W_S
            // 
            Reset_W_S.Location = new Point(194, 251);
            Reset_W_S.Name = "Reset_W_S";
            Reset_W_S.Size = new Size(94, 29);
            Reset_W_S.TabIndex = 5;
            Reset_W_S.Text = "Reset: W/S";
            Reset_W_S.UseVisualStyleBackColor = true;
            Reset_W_S.Click += Reset_W_S_Click;
            // 
            // Reset_U_D
            // 
            Reset_U_D.Location = new Point(519, 251);
            Reset_U_D.Name = "Reset_U_D";
            Reset_U_D.Size = new Size(94, 29);
            Reset_U_D.TabIndex = 11;
            Reset_U_D.Text = "Reset: U/D";
            Reset_U_D.UseVisualStyleBackColor = true;
            Reset_U_D.Click += Reset_U_D_Click;
            // 
            // UDL
            // 
            UDL.AutoSize = true;
            UDL.Location = new Point(534, 33);
            UDL.Name = "UDL";
            UDL.Size = new Size(70, 20);
            UDL.TabIndex = 10;
            UDL.Text = "Axis: U/D";
            // 
            // Reset_L_R
            // 
            Reset_L_R.Location = new Point(389, 184);
            Reset_L_R.Name = "Reset_L_R";
            Reset_L_R.Size = new Size(94, 29);
            Reset_L_R.TabIndex = 9;
            Reset_L_R.Text = "Reset: L/R";
            Reset_L_R.UseVisualStyleBackColor = true;
            Reset_L_R.Click += Reset_L_R_Click;
            // 
            // Track_U_D
            // 
            Track_U_D.BackColor = SystemColors.ButtonFace;
            Track_U_D.Location = new Point(543, 56);
            Track_U_D.Maximum = 100;
            Track_U_D.Minimum = -100;
            Track_U_D.Name = "Track_U_D";
            Track_U_D.Orientation = Orientation.Vertical;
            Track_U_D.Size = new Size(56, 200);
            Track_U_D.TabIndex = 8;
            Track_U_D.TickStyle = TickStyle.Both;
            Track_U_D.ValueChanged += Track_U_D_ValueChanged;
            // 
            // LRL
            // 
            LRL.AutoSize = true;
            LRL.Location = new Point(401, 110);
            LRL.Name = "LRL";
            LRL.Size = new Size(65, 20);
            LRL.TabIndex = 7;
            LRL.Text = "Axis: L/R";
            // 
            // Track_L_R
            // 
            Track_L_R.Location = new Point(337, 133);
            Track_L_R.Maximum = 100;
            Track_L_R.Minimum = -100;
            Track_L_R.Name = "Track_L_R";
            Track_L_R.Size = new Size(200, 56);
            Track_L_R.TabIndex = 6;
            Track_L_R.TickStyle = TickStyle.Both;
            Track_L_R.ValueChanged += Track_L_R_ValueChanged;
            // 
            // B1
            // 
            B1.AutoSize = true;
            B1.Location = new Point(12, 339);
            B1.Name = "B1";
            B1.Size = new Size(82, 24);
            B1.TabIndex = 12;
            B1.Text = "Key: \"1\"";
            B1.UseVisualStyleBackColor = true;
            // 
            // B2
            // 
            B2.AutoSize = true;
            B2.Location = new Point(100, 339);
            B2.Name = "B2";
            B2.Size = new Size(82, 24);
            B2.TabIndex = 13;
            B2.Text = "Key: \"2\"";
            B2.UseVisualStyleBackColor = true;
            // 
            // B3
            // 
            B3.AutoSize = true;
            B3.Location = new Point(188, 339);
            B3.Name = "B3";
            B3.Size = new Size(82, 24);
            B3.TabIndex = 14;
            B3.Text = "Key: \"3\"";
            B3.UseVisualStyleBackColor = true;
            // 
            // B4
            // 
            B4.AutoSize = true;
            B4.Location = new Point(12, 369);
            B4.Name = "B4";
            B4.Size = new Size(82, 24);
            B4.TabIndex = 15;
            B4.Text = "Key: \"4\"";
            B4.UseVisualStyleBackColor = true;
            // 
            // B5
            // 
            B5.AutoSize = true;
            B5.Location = new Point(100, 369);
            B5.Name = "B5";
            B5.Size = new Size(82, 24);
            B5.TabIndex = 16;
            B5.Text = "Key: \"5\"";
            B5.UseVisualStyleBackColor = true;
            // 
            // B6
            // 
            B6.AutoSize = true;
            B6.Location = new Point(188, 369);
            B6.Name = "B6";
            B6.Size = new Size(82, 24);
            B6.TabIndex = 17;
            B6.Text = "Key: \"6\"";
            B6.UseVisualStyleBackColor = true;
            // 
            // B7
            // 
            B7.AutoSize = true;
            B7.Location = new Point(12, 399);
            B7.Name = "B7";
            B7.Size = new Size(82, 24);
            B7.TabIndex = 18;
            B7.Text = "Key: \"7\"";
            B7.UseVisualStyleBackColor = true;
            // 
            // B8
            // 
            B8.AutoSize = true;
            B8.Location = new Point(100, 399);
            B8.Name = "B8";
            B8.Size = new Size(82, 24);
            B8.TabIndex = 19;
            B8.Text = "Key: \"8\"";
            B8.UseVisualStyleBackColor = true;
            // 
            // B9
            // 
            B9.AutoSize = true;
            B9.Location = new Point(188, 399);
            B9.Name = "B9";
            B9.Size = new Size(82, 24);
            B9.TabIndex = 20;
            B9.Text = "Key: \"9\"";
            B9.UseVisualStyleBackColor = true;
            // 
            // B0
            // 
            B0.AutoSize = true;
            B0.Location = new Point(100, 429);
            B0.Name = "B0";
            B0.Size = new Size(82, 24);
            B0.TabIndex = 21;
            B0.Text = "Key: \"0\"";
            B0.UseVisualStyleBackColor = true;
            // 
            // BSPACE
            // 
            BSPACE.AutoSize = true;
            BSPACE.Location = new Point(343, 429);
            BSPACE.Name = "BSPACE";
            BSPACE.Size = new Size(116, 24);
            BSPACE.TabIndex = 22;
            BSPACE.Text = "Key: \"SPACE\"";
            BSPACE.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.BackColor = SystemColors.GradientActiveCaption;
            progressBar1.Location = new Point(312, -18);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(10, 498);
            progressBar1.TabIndex = 23;
            // 
            // BOCCUPIED
            // 
            BOCCUPIED.AutoSize = true;
            BOCCUPIED.Location = new Point(476, 429);
            BOCCUPIED.Name = "BOCCUPIED";
            BOCCUPIED.Size = new Size(144, 24);
            BOCCUPIED.TabIndex = 24;
            BOCCUPIED.Text = "Key: \"OCCUPIED\"";
            BOCCUPIED.UseVisualStyleBackColor = true;
            // 
            // Track_View_X
            // 
            Track_View_X.Location = new Point(406, 287);
            Track_View_X.Maximum = 50;
            Track_View_X.Minimum = -50;
            Track_View_X.Name = "Track_View_X";
            Track_View_X.Size = new Size(200, 56);
            Track_View_X.TabIndex = 25;
            Track_View_X.TickStyle = TickStyle.Both;
            Track_View_X.ValueChanged += Track_View_X_ValueChanged;
            // 
            // Track_View_Y
            // 
            Track_View_Y.BackColor = SystemColors.ButtonFace;
            Track_View_Y.Location = new Point(360, 215);
            Track_View_Y.Maximum = 50;
            Track_View_Y.Minimum = -50;
            Track_View_Y.Name = "Track_View_Y";
            Track_View_Y.Orientation = Orientation.Vertical;
            Track_View_Y.Size = new Size(56, 200);
            Track_View_Y.TabIndex = 26;
            Track_View_Y.TickStyle = TickStyle.Both;
            Track_View_Y.ValueChanged += Track_View_Y_ValueChanged;
            // 
            // VXL
            // 
            VXL.AutoSize = true;
            VXL.Location = new Point(464, 339);
            VXL.Name = "VXL";
            VXL.Size = new Size(88, 20);
            VXL.TabIndex = 27;
            VXL.Text = "Axis: View X";
            // 
            // VYL
            // 
            VYL.AutoSize = true;
            VYL.Location = new Point(343, 405);
            VYL.Name = "VYL";
            VYL.Size = new Size(87, 20);
            VYL.TabIndex = 28;
            VYL.Text = "Axis: View Y";
            // 
            // SeatPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 469);
            Controls.Add(VYL);
            Controls.Add(VXL);
            Controls.Add(Track_View_Y);
            Controls.Add(Track_View_X);
            Controls.Add(BOCCUPIED);
            Controls.Add(progressBar1);
            Controls.Add(BSPACE);
            Controls.Add(B0);
            Controls.Add(B9);
            Controls.Add(B8);
            Controls.Add(B7);
            Controls.Add(B6);
            Controls.Add(B5);
            Controls.Add(B4);
            Controls.Add(B3);
            Controls.Add(B2);
            Controls.Add(B1);
            Controls.Add(Reset_U_D);
            Controls.Add(UDL);
            Controls.Add(Reset_L_R);
            Controls.Add(Track_U_D);
            Controls.Add(LRL);
            Controls.Add(Track_L_R);
            Controls.Add(Reset_W_S);
            Controls.Add(WSL);
            Controls.Add(Reset_A_D);
            Controls.Add(Track_W_S);
            Controls.Add(ADL);
            Controls.Add(Track_A_D);
            Name = "SeatPanel";
            Text = "Form1";
            KeyDown += SeatPanel_KeyDown;
            ((System.ComponentModel.ISupportInitialize)Track_A_D).EndInit();
            ((System.ComponentModel.ISupportInitialize)Track_W_S).EndInit();
            ((System.ComponentModel.ISupportInitialize)Track_U_D).EndInit();
            ((System.ComponentModel.ISupportInitialize)Track_L_R).EndInit();
            ((System.ComponentModel.ISupportInitialize)Track_View_X).EndInit();
            ((System.ComponentModel.ISupportInitialize)Track_View_Y).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar Track_A_D;
        private Label ADL;
        private FontDialog fontDialog1;
        private TrackBar Track_W_S;
        private Button Reset_A_D;
        private Label WSL;
        private Button Reset_W_S;
        private Button Reset_U_D;
        private Label UDL;
        private Button Reset_L_R;
        private TrackBar Track_U_D;
        private Label LRL;
        private TrackBar Track_L_R;
        private CheckBox B1;
        private CheckBox B2;
        private CheckBox B3;
        private CheckBox B4;
        private CheckBox B5;
        private CheckBox B6;
        private CheckBox B7;
        private CheckBox B8;
        private CheckBox B9;
        private CheckBox B0;
        private CheckBox BSPACE;
        private ProgressBar progressBar1;
        private CheckBox BOCCUPIED;
        private TrackBar Track_View_X;
        private TrackBar Track_View_Y;
        private Label VXL;
        private Label VYL;
    }
}