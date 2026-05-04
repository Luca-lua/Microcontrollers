using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.Diagram
{
    public class ScematicMonitor
    {
        public string name;
        public ScematicNode videoIn;
        public ScematicMonitor() { }
        internal ScematicMonitor(Microcontrollers.Parts.Monitor monitor)
        {
            int? id = null;
            if (monitor.videoIn.connected_node != null)
            {
                id = monitor.videoIn.connected_node.id;
            }

            this.videoIn = new ScematicNode(monitor.videoIn.id,false,NodeType.Video,id);
            this.name = monitor._name;
        }


    }
}
