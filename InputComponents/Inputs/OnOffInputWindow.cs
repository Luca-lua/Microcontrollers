using Microcontrollers.PartSystem;

namespace InputComponents.Inputs
{
    /// <summary>
    /// "LogicGate" -> Creates a Window with 6 Boolean inputs.
    /// </summary>
    public class OnOffValueWindow : ILogicGate
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
        /// Outputs are 6 OnOffNodes
        /// </summary>
        /// <param name="name">How the window will be titled, usefull when multiple exist.</param>
        /// <param name="config">configuration. if null, defaults will be used.</param>
        /// <param name="labels">label the boolean inputs [0] is label 1, [5] is label 6</param>
        /// <param name="defaults">state the boolean inputs will start in, [0] is boolean 1, [5] is boolean 6 </param>
        public OnOffValueWindow(string name = "Input panel" , string[]? labels = null, bool[]? defaults = null)
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
            OnOffNodes.Add(new OnOffGateNode(1,true));
            OnOffNodes.Add(new OnOffGateNode(2, true));
            OnOffNodes.Add(new OnOffGateNode(3, true));
            OnOffNodes.Add(new OnOffGateNode(4, true));
            OnOffNodes.Add(new OnOffGateNode(5, true));
            OnOffNodes.Add(new OnOffGateNode(6, true));
        }

        public void Execute()
        {
            OnOffNodes.Find(c => c._id == 1).value = form.GetInputValue(1);
            OnOffNodes.Find(c => c._id == 2).value = form.GetInputValue(2);
            OnOffNodes.Find(c => c._id == 3).value = form.GetInputValue(3);
            OnOffNodes.Find(c => c._id == 4).value = form.GetInputValue(4);
            OnOffNodes.Find(c => c._id == 5).value = form.GetInputValue(5);
            OnOffNodes.Find(c => c._id == 6).value = form.GetInputValue(6);
        }
    }
}
