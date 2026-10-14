using Microcontrollers.PartSystem;

namespace InputComponents.Inputs
{
    public class NumberValueWindowConfig
    {
        public int Input1OutChannel { get; set; } = 1;
        public int Input2OutChannel { get; set; } = 2;
        public int Input3OutChannel { get; set; } = 3;
        public int Input4OutChannel { get; set; } = 4;
        public int Input5OutChannel { get; set; } = 5;
        public int Input6OutChannel { get; set; } = 6;
    }
    /// <summary>
    /// "LogicGate" -> Creates a Window with 6 Number inputs.
    /// </summary>
    public class NumberInputWindow : ILogicGate
    {
        public List<NumberGateNode> NumberNodes { get; } = new List<NumberGateNode>();
        public List<OnOffGateNode> OnOffNodes { get; } = new List<OnOffGateNode> { };
        public List<CompositeGateNode> CompNodes { get; } = new List<CompositeGateNode> { };
        public List<VideoGateNode> VideoNodes { get; } = new List<VideoGateNode> { };

        private NumberInputs form;
        private NumberValueWindowConfig config;

        public NumberInputWindow(string name = "Input panel", NumberValueWindowConfig? config = null , string[]? labels = null, int[]? defaults = null)
        {
            if (config == null)
                config = new NumberValueWindowConfig();

            this.config = config;

            form = new NumberInputs();
            form.Text = name;

            if(labels != null)
            {
                for(int i = 0; i < labels.Count()-1; i++)
                {
                    form.SetInputName(labels[i], i+1);
                }
            }

            if(defaults != null)
            {
                for (int i = 0; i < defaults.Count() - 1; i++)
                {
                    form.SetInputValue(defaults[i], i+1);
                }
            }

            Task.Run(() => form.ShowDialog());

            form.FormClosed += Form_FormClosed;
        }

        private void Form_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void Construct()
        {
            CompNodes.Add(new CompositeGateNode(1,true));
        }

        public void Execute()
        {
            
            var compnode = CompNodes.Find(c => c._id == 1).value;
            compnode.NumberValues[config.Input1OutChannel] = form.GetInputValue(1);
            compnode.NumberValues[config.Input2OutChannel] = form.GetInputValue(2);
            compnode.NumberValues[config.Input3OutChannel] = form.GetInputValue(3);
            compnode.NumberValues[config.Input4OutChannel] = form.GetInputValue(4);
            compnode.NumberValues[config.Input5OutChannel] = form.GetInputValue(5);
            compnode.NumberValues[config.Input6OutChannel] = form.GetInputValue(6);
        }
    }
}
