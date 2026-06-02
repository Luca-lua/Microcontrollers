
using System;
using System.Collections.Generic;
using System.Text;

namespace ScematicEditor.Diagram
{
    public class ScematicNode
    {
        public string owner {  get; set; }
        public int id { get; set; }
        public bool isOutput { get; set; }
        public NodeType nodeType { get; set; }
        public int ?target_id { get; set; }
        internal object value { get; set; }
        public ScematicNode() { }
    }
}
