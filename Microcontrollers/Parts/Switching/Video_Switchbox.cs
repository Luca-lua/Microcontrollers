using Microcontrollers.ConnectionSystem;
using Microcontrollers.PartSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.Parts.Switching
{
    public class Video_Switchbox : ILogicGate
    {
        public List<NumberGateNode> NumberNodes { get; } = new List<NumberGateNode>();
        public List<OnOffGateNode> OnOffNodes { get; } = new List<OnOffGateNode> { };
        public List<CompositeGateNode> CompNodes { get; } = new List<CompositeGateNode> { };
        public List<VideoGateNode> VideoNodes { get; } = new List<VideoGateNode> { };

        public void Construct()
        {
            OnOffNodes.Add(new OnOffGateNode(1, false));
            VideoNodes.Add(new VideoGateNode(2, false));
            VideoNodes.Add(new VideoGateNode(3, false));
            VideoNodes.Add(new VideoGateNode(4, true));
        }

        public void Execute()
        {
            if (OnOffNodes.Find(node => node._id == 1).value == true)
            {
                VideoNodes.Find(node => node._id == 4).value = VideoNodes.Find(node => node._id == 2).value;
            }
            else
            {
                VideoNodes.Find(node => node._id == 4).value = VideoNodes.Find(node => node._id == 3).value;
            }
        }
    }
}
