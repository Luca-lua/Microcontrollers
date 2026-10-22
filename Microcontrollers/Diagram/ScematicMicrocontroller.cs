using Microcontrollers.ControllerSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.Diagram
{
    public class ScematicMicrocontroller
    {
        public string name;
        public ScematicNode VideoNodeIn;
        public ScematicNode VideoNodeOut;
        public ScematicNode CompInNode;
        public ScematicNode CompOutNode;
        public ScematicMicrocontroller() { }
        internal ScematicMicrocontroller(Microcontroller controller)
        {
            this.name = controller.name;
            this.VideoNodeIn = new ScematicNode(controller.name, controller.VideoNodeIn.id, controller.VideoNodeIn.IsOutput, NodeType.Video, controller.VideoNodeIn.connected_node?.id);   // VideoMode
            this.VideoNodeOut = new ScematicNode(controller.name,controller.VideoNodeOut.id,controller.VideoNodeOut.IsOutput,NodeType.Video,controller.VideoNodeOut.connected_node?.id);   // VideoMode
            this.CompInNode = new ScematicNode(controller.name, controller.InComp.id,controller.InComp.IsOutput, NodeType.Video, controller.InComp.connected_node?.id);         // CompInNode
            this.CompOutNode = new ScematicNode(controller.name,controller.OutComp.id,controller.OutComp.IsOutput, NodeType.Video, controller.OutComp.connected_node?.id);     // CompOutNode
        }
    }
}
