
using Microcontrollers.ConnectionSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.Diagram
{
    public class ScematicNode
    {
        public string owner {  get; set; }
        public int id { get; set; }
        public bool isOutput { get; set; }
        public NodeType nodeType { get; set; }
        public int ?target_id { get; set; }
        internal object value { get; set; }
        public ScematicNode(string owner,int node_id,bool node_output, NodeType type, int ?connected_node_id = null)
        { 
            this.owner = owner;
            this.id = node_id;
            this.isOutput = node_output;
            this.nodeType = type;
            this.target_id = connected_node_id;
        }
    }
}
