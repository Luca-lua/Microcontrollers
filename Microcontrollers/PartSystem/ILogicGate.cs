using Microcontrollers.ConnectionSystem;
using Microcontrollers.Diagram;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.PartSystem
{
    public interface ILogicGate
    {
        /// <summary>
        /// Nodes to be Constructed
        /// </summary>
        public List<NumberGateNode> NumberNodes { get; }
        public List<OnOffGateNode> OnOffNodes { get; }
        public List<CompositeGateNode> CompNodes { get; }
        public List<VideoGateNode> VideoNodes { get; }

        /// <summary>
        /// Construct nodes on creation
        /// </summary>
        public void Construct();

        /// <summary>
        /// Use nodes to execute logic
        /// </summary>
        public void Execute();
    }
}
