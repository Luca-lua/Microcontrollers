using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.Diagram
{
    public class ScematicMonitor
    {
        public string name;
        public ScematicNode videoIn;
        public ScematicNode CompositeOut;
        public ScematicMonitor() { }
        internal ScematicMonitor(Microcontrollers.Parts.Monitor monitor)
        {
            int? id_Vid = null;
            int? id_Com = null;
            if (monitor.videoIn.connected_node != null)
            {
                id_Vid = monitor.videoIn.connected_node.id;
            }
            if(monitor.touchInfo.connected_node != null)
            {
                id_Com = monitor.touchInfo.connected_node.id;
            }

            this.videoIn = new ScematicNode(monitor._name,monitor.videoIn.id,false, NodeType.Video,id_Vid);
            this.CompositeOut = new ScematicNode(monitor._name,monitor.touchInfo.id,true,NodeType.Composite,id_Com);
            this.name = monitor._name;
        }


    }
}
