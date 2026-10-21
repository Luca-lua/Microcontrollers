using Microcontrollers.PartSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace InputComponents.Inputs
{
    public class AxisInputWindowConfig
    {
        public int VerticalAxisOutChannel { get; set; } = 1;
        public int HorizontalAxisOutChannel { get; set; } = 2;
    }
    /// <summary>
    /// "LogicGate" -> Creates a window with 2 axis sliders for live data input.
    /// <para></para>
    /// Raw input is -1 to 1 with Top beeing 1 and Right beeing 1 respectivly.
    /// </summary>
    public class AxisInputWindow : ILogicGate
    {
        public List<NumberGateNode> NumberNodes { get; } = new List<NumberGateNode>();
        public List<OnOffGateNode> OnOffNodes { get; } = new List<OnOffGateNode> { };
        public List<CompositeGateNode> CompNodes { get; } = new List<CompositeGateNode> { };
        public List<VideoGateNode> VideoNodes { get; } = new List<VideoGateNode> { };

        private AxisInputs form;
        private Task<DialogResult> thread;
        private AxisInputWindowConfig config;

        //private double axisValueHorizontal { get => form.Invoke(new Func<double>(() => ));}
        //private double axisValueVertical { get => form.Invoke(new Func<double>(() => form.GetAxisValue(true))); }

        public AxisInputWindow(string name = "Input panel", AxisInputWindowConfig? config = null)
        {
            if (config == null)
                config = new AxisInputWindowConfig();

            this.config = config;

            form = new AxisInputs();
            form.Text = name;

            thread = Task.Run(() => form.ShowDialog());

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
                compnode.NumberValues[config.VerticalAxisOutChannel] = form.AxisUD_Value;
                compnode.NumberValues[config.HorizontalAxisOutChannel] = form.AxisLR_Value;
        }
    }
}
