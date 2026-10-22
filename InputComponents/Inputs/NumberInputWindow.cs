using Microcontrollers.PartSystem;

namespace InputComponents.Inputs
{
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
        /// <summary>
        /// Create a new Inputwindow with 6 Numeric inputs.
        /// <para></para>
        /// Outputs are 6 NumberNodes
        /// </summary>
        /// <param name="name">How the window will be titled, usefull when multiple exist.</param>
        /// <param name="labels">label the boolean inputs [0] is label 1, [5] is label 6</param>
        /// <param name="defaults">state the number inputs will start in, [0] is number 1, [5] is number 6 </param>
        public NumberInputWindow(string name = "Input panel" , string[]? labels = null, int[]? defaults = null)
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
            NumberNodes.Add(new NumberGateNode(1,true));
            NumberNodes.Add(new NumberGateNode(2, true));
            NumberNodes.Add(new NumberGateNode(3, true));
            NumberNodes.Add(new NumberGateNode(4, true));
            NumberNodes.Add(new NumberGateNode(5, true));
            NumberNodes.Add(new NumberGateNode(6, true));
        }

        public void Execute()
        {


            NumberNodes.Find(c => c._id == 1).value = form.GetInputValue(1);
            NumberNodes.Find(c => c._id == 2).value = form.GetInputValue(2);
            NumberNodes.Find(c => c._id == 3).value = form.GetInputValue(3);
            NumberNodes.Find(c => c._id == 4).value = form.GetInputValue(4);
            NumberNodes.Find(c => c._id == 5).value = form.GetInputValue(5);
            NumberNodes.Find(c => c._id == 6).value = form.GetInputValue(6);
        }
    }
}
