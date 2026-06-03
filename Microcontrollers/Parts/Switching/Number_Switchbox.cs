using Microcontrollers.PartSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.Parts.Switching
{
    public class Number_Switchbox : ILogicGate
    {
        public List<NumberGateNode> NumberNodes { get; } = new List<NumberGateNode>();
        public List<OnOffGateNode> OnOffNodes { get; } = new List<OnOffGateNode> { };
        public List<CompositeGateNode> CompNodes { get; } = new List<CompositeGateNode> { };
        public List<VideoGateNode> VideoNodes { get; } = new List<VideoGateNode> { };

        public void Construct()
        {
            OnOffNodes.Add(new OnOffGateNode(1, false));
            NumberNodes.Add(new NumberGateNode(2, false));
            NumberNodes.Add(new NumberGateNode(3, false));
            NumberNodes.Add(new NumberGateNode(4, true));
        }

        public void Execute()
        {
            if(OnOffNodes.Find(node => node._id == 1).value == true)
            {
                NumberNodes.Find(node => node._id == 4).value = NumberNodes.Find(node => node._id == 2).value;
            }
            else
            {
                NumberNodes.Find(node => node._id == 4).value = NumberNodes.Find(node => node._id == 3).value;
            }
        }
    }
}
