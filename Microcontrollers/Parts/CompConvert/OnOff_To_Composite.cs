using Microcontrollers.PartSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.Parts.CompConvert
{
    public class OnOff_To_Composite(int start, int length) : ILogicGate
    {
        public List<NumberGateNode> NumberNodes { get; } = new List<NumberGateNode>();
        public List<OnOffGateNode> OnOffNodes { get; } = new List<OnOffGateNode> { };
        public List<CompositeGateNode> CompNodes { get; } = new List<CompositeGateNode> { };
        public List<VideoGateNode> VideoNodes { get; } = new List<VideoGateNode> { };

        public void Construct()
        {
            CompNodes.Add(new CompositeGateNode(1, true));
            CompNodes.Add(new CompositeGateNode(2, false));
            for (int i = start; i <= start+length-1; i++)
            {
                OnOffNodes.Add(new OnOffGateNode(i + 2, false));
            }
        }

        public void Execute()
        {
            CompNodes.Find(node => node._id == 1).value = CompNodes.Find(node => node._id == 2).value;
            for (int i = start; i <= start+ length-1; i++)
            {
                CompNodes.Find(node => node._id == 1).value.OnOffValues[i] = OnOffNodes.Find(node => node._id == i + 2).value;
            }
        }
    }
}
