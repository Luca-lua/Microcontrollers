using Microcontrollers.PartSystem;

namespace InputComponents.Inputs
{
    public class OnOffValueWindowConfig
    {
        public int Input1OutChannel { get; set; } = 1;
        public int Input2OutChannel { get; set; } = 2;
        public int Input3OutChannel { get; set; } = 3;
        public int Input4OutChannel { get; set; } = 4;
        public int Input5OutChannel { get; set; } = 5;
        public int Input6OutChannel { get; set; } = 6;
    }
    /// <summary>
    /// "LogicGate" -> Creates a Window with 6 Boolean inputs.
    /// </summary>
    public class OnOffValueWindowComp : ILogicGate
    {
        public List<NumberGateNode> NumberNodes { get; } = new List<NumberGateNode>();
        public List<OnOffGateNode> OnOffNodes { get; } = new List<OnOffGateNode> { };
        public List<CompositeGateNode> CompNodes { get; } = new List<CompositeGateNode> { };
        public List<VideoGateNode> VideoNodes { get; } = new List<VideoGateNode> { };

        private OnOffInput form;
        private OnOffValueWindowConfig config;
        /// <summary>
        /// Create a new Inputwindow with 6 Boolean inputs.
        /// <para></para>
        /// Output is a single Comp node with the channels specified in the config
        /// </summary>
        /// <param name="name">How the window will be titled, usefull when multiple exist.</param>
        /// <param name="config">configuration. if null, defaults will be used.</param>
        /// <param name="labels">label the boolean inputs [0] is label 1, [5] is label 6</param>
        /// <param name="defaults">state the boolean inputs will start in, [0] is boolean 1, [5] is boolean 6 </param>
        public OnOffValueWindowComp(string name = "Input panel", OnOffValueWindowConfig? config = null , string[]? labels = null, bool[]? defaults = null)
        {
            if (config == null)
                config = new OnOffValueWindowConfig();

            this.config = config;

            form = new OnOffInput();
            form.Text = name;

            if(labels != null)
            {
                for(int i = 0; i < labels.Count(); i++)
                {
                    form.SetInputName(labels[i], i+1);
                }
            }

            if(defaults != null)
            {
                for (int i = 0; i < defaults.Count(); i++)
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
            compnode.OnOffValues[config.Input1OutChannel] = form.GetInputValue(1);
            compnode.OnOffValues[config.Input2OutChannel] = form.GetInputValue(2);
            compnode.OnOffValues[config.Input3OutChannel] = form.GetInputValue(3);
            compnode.OnOffValues[config.Input4OutChannel] = form.GetInputValue(4);
            compnode.OnOffValues[config.Input5OutChannel] = form.GetInputValue(5);
            compnode.OnOffValues[config.Input6OutChannel] = form.GetInputValue(6);
        }
    }
}
