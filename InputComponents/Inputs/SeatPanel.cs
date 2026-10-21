using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InputComponents.Inputs
{

    public partial class SeatPanel : Form
    {
        public enum SeatAxisMode
        {
            normal,
            sticky
        }
        public enum SeatButton
        {
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Zero,
            Space,
            Occupied
        }
        public enum SeatAxis
        {
            WS,
            AD,
            UD,
            LR,
            VX,
            VY
        }

        private int value_W_S = 0;
        private int value_A_D = 0;
        private int value_U_D = 0;
        private int value_L_R = 0;
        private int value_V_Y = 0;
        private int value_V_X = 0;

        private SeatAxisMode main_axis_mode;
        private SeatAxisMode secondary_axis_mode;
        private int main_sensitivity;
        private int secondary_sensitivity;
        private System.Windows.Forms.Timer timer;

        internal SeatPanel(int main_sensitivity = 10, int secondary_sensitivity = 10, SeatAxisMode main_axis_mode = SeatAxisMode.normal, SeatAxisMode secondary_axis_mode = SeatAxisMode.normal)
        {
            this.main_sensitivity = main_sensitivity;
            this.secondary_sensitivity = secondary_sensitivity;
            this.main_axis_mode = main_axis_mode;
            this.secondary_axis_mode = secondary_axis_mode;

            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        internal double GetAxisValue(SeatAxis axis)
        {
            switch (axis)
            {
                case SeatAxis.WS:
                    return value_W_S / 100.0;

                case SeatAxis.AD:
                    return value_A_D / 100.0;

                case SeatAxis.UD:
                    return value_U_D / 100.0;

                case SeatAxis.LR:
                    return value_L_R / 100.0;

                case SeatAxis.VX:
                    return value_V_X / 100.0;

                case SeatAxis.VY:
                    return value_V_Y / 100.0;
            }
            return 0;
        }

        internal bool GetButtonValue(SeatButton btn)
        {
            switch (btn)
            {
                case SeatButton.One:
                    return B1.Checked;

                case SeatButton.Two:
                    return B2.Checked;

                case SeatButton.Three:
                    return B3.Checked;

                case SeatButton.Four:
                    return B4.Checked;

                case SeatButton.Five:
                    return B5.Checked;

                case SeatButton.Six:
                    return B6.Checked;

                case SeatButton.Seven:
                    return B7.Checked;

                case SeatButton.Eight:
                    return B8.Checked;

                case SeatButton.Nine:
                    return B9.Checked;

                case SeatButton.Zero:
                    return B0.Checked;

                case SeatButton.Space:
                    return BSPACE.Checked;

                case SeatButton.Occupied:
                    return BOCCUPIED.Checked;
            }
            return false;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (main_axis_mode == SeatAxisMode.sticky && secondary_axis_mode == SeatAxisMode.sticky)
            {
                timer.Stop();
                timer.Dispose();
                return;
            }

            if (main_axis_mode == SeatAxisMode.normal)
            {
                Track_A_D.Value -= Track_A_D.Value / 100 * main_sensitivity;
                Track_W_S.Value -= Track_W_S.Value / 100 * main_sensitivity;
            }

            if (secondary_axis_mode == SeatAxisMode.normal)
            {
                Track_U_D.Value -= Track_U_D.Value / 100 * secondary_sensitivity;
                Track_L_R.Value -= Track_L_R.Value / 100 * secondary_sensitivity;
            }
        }

        private void Reset_A_D_Click(object sender, EventArgs e)
        {
            Track_A_D.Value = 0;
        }

        private void Reset_W_S_Click(object sender, EventArgs e)
        {
            Track_W_S.Value = 0;
        }

        private void Reset_L_R_Click(object sender, EventArgs e)
        {
            Track_L_R.Value = 0;
        }

        private void Reset_U_D_Click(object sender, EventArgs e)
        {
            Track_U_D.Value = 0;
        }

        private void SeatPanel_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.W:
                    Track_W_S.Value += main_sensitivity;
                    break;

                case Keys.S:
                    Track_W_S.Value -= main_sensitivity;
                    break;

                case Keys.A:
                    Track_A_D.Value -= main_sensitivity;
                    break;

                case Keys.D:
                    Track_A_D.Value += main_sensitivity;
                    break;


                case Keys.Up:
                    Track_U_D.Value += secondary_sensitivity;
                    break;

                case Keys.Down:
                    Track_U_D.Value -= secondary_sensitivity;
                    break;

                case Keys.Left:
                    Track_L_R.Value -= secondary_sensitivity;
                    break;

                case Keys.Right:
                    Track_L_R.Value += secondary_sensitivity;
                    break;


                case Keys.D1:
                    B1.Checked = !B1.Checked;
                    break;

                case Keys.D2:
                    B2.Checked = !B2.Checked;
                    break;

                case Keys.D3:
                    B3.Checked = !B3.Checked;
                    break;

                case Keys.D4:
                    B4.Checked = !B4.Checked;
                    break;

                case Keys.D5:
                    B5.Checked = !B5.Checked;
                    break;

                case Keys.D6:
                    B6.Checked = !B6.Checked;
                    break;

                case Keys.D7:
                    B7.Checked = !B7.Checked;
                    break;

                case Keys.D8:
                    B8.Checked = !B8.Checked;
                    break;

                case Keys.D9:
                    B9.Checked = !B9.Checked;
                    break;

                case Keys.D0:
                    B0.Checked = !B0.Checked;
                    break;

                case Keys.Space:
                    BSPACE.Checked = !BSPACE.Checked;
                    break;
            }
        }

        private void Track_W_S_ValueChanged(object sender, EventArgs e)
        {
            value_W_S = Track_W_S.Value;
        }

        private void Track_A_D_ValueChanged(object sender, EventArgs e)
        {
            value_A_D = Track_A_D.Value;
        }

        private void Track_L_R_ValueChanged(object sender, EventArgs e)
        {
            value_L_R = Track_L_R.Value;
        }

        private void Track_U_D_ValueChanged(object sender, EventArgs e)
        {
            value_U_D = Track_U_D.Value;
        }

        private void Track_View_Y_ValueChanged(object sender, EventArgs e)
        {
            value_V_Y = Track_View_Y.Value;
        }

        private void Track_View_X_ValueChanged(object sender, EventArgs e)
        {
            value_V_X = Track_View_X.Value;
        }
    }
}
