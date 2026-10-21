using Microcontrollers.PartSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace InputComponents.Inputs
{
    public class SeatPanelWindowConfig
    {
        /// <summary>
        /// Left Stick contains W/S & A/D
        /// </summary>
        public SeatPanel.SeatAxisMode LeftStickMode = SeatPanel.SeatAxisMode.normal;
        /// <summary>
        /// Min 0 Max 100 -> controlls value increase and decrease
        /// </summary>
        public int LeftStickSensitivity = 10;
        /// <summary>
        /// Right Stick contains U/D & L/R
        /// </summary>
        public SeatPanel.SeatAxisMode RightStickMode = SeatPanel.SeatAxisMode.normal;
        /// <summary>
        /// Min 0 Max 100 -> controlls value increase and decrease
        /// </summary>
        public int RightStickSensivity = 10;
    }
    /// <summary>
    /// Represents logic parts of stormworks helm / seat
    /// </summary>
    public class SeatPanelWindow : ILogicGate
    {
        public List<NumberGateNode> NumberNodes { get; } = new List<NumberGateNode>();
        public List<OnOffGateNode> OnOffNodes { get; } = new List<OnOffGateNode> { };
        public List<CompositeGateNode> CompNodes { get; } = new List<CompositeGateNode> { };
        public List<VideoGateNode> VideoNodes { get; } = new List<VideoGateNode> { };

        private SeatPanel form;
        private SeatPanelWindowConfig config;
        /// <summary>
        /// Create new Stormworks helm / seat input instance
        /// <para></para>
        /// Axis (+/-) : 1 D/A | 2 W/S | 3 r_arr/l_arr | 4 u_arr/d_arr | 9 view_right/view_left | 10 view_up/view_down
        /// <para></para>
        /// OnOff: 0-9 Number keys | 31 trigger / space | 32 seat occupied
        /// </summary>
        /// <param name="name">name of the window, usefull if multiple are used</param>
        /// <param name="config">configuration. if not given, defaults will be used</param>
        public SeatPanelWindow(string name = "Composite Seat Panel", SeatPanelWindowConfig config = null)
        {
            if (config != null)
                this.config = config;
            else
                this.config = new SeatPanelWindowConfig();

            form = new SeatPanel(this.config.LeftStickSensitivity, this.config.RightStickSensivity, this.config.LeftStickMode, this.config.RightStickMode);
            form.Name = name;

            Task.Run(() => form.ShowDialog());

            form.FormClosed += Form_FormClosed;
        }
        private void Form_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        public void Construct()
        {
            CompNodes.Add(new CompositeGateNode(1, true));
        }

        public void Execute()
        {

            var compnode = CompNodes.Find(c => c._id == 1).value;
            compnode.OnOffValues[1] = form.GetButtonValue(SeatPanel.SeatButton.One);
            compnode.OnOffValues[2] = form.GetButtonValue(SeatPanel.SeatButton.Two);
            compnode.OnOffValues[3] = form.GetButtonValue(SeatPanel.SeatButton.Three);
            compnode.OnOffValues[4] = form.GetButtonValue(SeatPanel.SeatButton.Four);
            compnode.OnOffValues[5] = form.GetButtonValue(SeatPanel.SeatButton.Five);
            compnode.OnOffValues[6] = form.GetButtonValue(SeatPanel.SeatButton.Six);
            compnode.OnOffValues[7] = form.GetButtonValue(SeatPanel.SeatButton.Seven);
            compnode.OnOffValues[8] = form.GetButtonValue(SeatPanel.SeatButton.Eight);
            compnode.OnOffValues[9] = form.GetButtonValue(SeatPanel.SeatButton.Nine);
            compnode.OnOffValues[0] = form.GetButtonValue(SeatPanel.SeatButton.Zero);
            compnode.OnOffValues[31] = form.GetButtonValue(SeatPanel.SeatButton.Space);
            compnode.OnOffValues[32] = form.GetButtonValue(SeatPanel.SeatButton.Occupied);

            compnode.NumberValues[1] = form.GetAxisValue(SeatPanel.SeatAxis.AD);
            compnode.NumberValues[2] = form.GetAxisValue(SeatPanel.SeatAxis.WS);
            compnode.NumberValues[3] = form.GetAxisValue(SeatPanel.SeatAxis.UD);
            compnode.NumberValues[4] = form.GetAxisValue(SeatPanel.SeatAxis.LR);
            compnode.NumberValues[9] = form.GetAxisValue(SeatPanel.SeatAxis.VX);
            compnode.NumberValues[10] = form.GetAxisValue(SeatPanel.SeatAxis.VY);
        }
    }
}
