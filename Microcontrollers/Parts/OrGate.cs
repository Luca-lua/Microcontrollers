using Microcontrollers.Diagram;
using Microcontrollers.PartSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.Parts
{
    public class OrGate : ILogicGate
    {
        public List<NumberGateNode> NumberNodes { get; } = new List<NumberGateNode>();
        public List<OnOffGateNode> OnOffNodes { get; } = new List<OnOffGateNode> { };
        public List<CompositeGateNode> CompNodes { get; } = new List<CompositeGateNode> { };
        public List<VideoGateNode> VideoNodes { get; } = new List<VideoGateNode> { };

        public void Construct()
        {
            OnOffNodes.Add(new OnOffGateNode(1,false));
            OnOffNodes.Add(new OnOffGateNode(2,false));
            OnOffNodes.Add(new OnOffGateNode(3,true));
        }

        public void Execute()
        {
            if(OnOffNodes.Find(node => node._id == 1).value || OnOffNodes.Find(node => node._id == 2).value)
            {
                OnOffNodes.Find(node => node._id == 3).value = true;
            }
            else
            {
                OnOffNodes.Find(node => node._id == 3).value = false;
            }
        }
    }
}
