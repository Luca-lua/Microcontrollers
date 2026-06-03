using Microcontrollers.PartSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.Parts.ConsoleIO
{
    public class OnOff_From_Console(ConsoleKey onKey, ConsoleKey offKey) : ILogicGate
    {
        public List<NumberGateNode> NumberNodes { get; } = new List<NumberGateNode>();
        public List<OnOffGateNode> OnOffNodes { get; } = new List<OnOffGateNode> { };
        public List<CompositeGateNode> CompNodes { get; } = new List<CompositeGateNode> { };
        public List<VideoGateNode> VideoNodes { get; } = new List<VideoGateNode> { };
        private bool state = false;

        public void Construct()
        {
            OnOffNodes.Add(new OnOffGateNode(1, true));
        }

        public void Execute()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey();
                if(key.Key == onKey)
                {
                    state = true;
                }
                if (key.Key == offKey)
                {
                    state = false;
                }
                OnOffNodes.Find(node => node._id == 1).value = state;
            }
        }
    }
}
