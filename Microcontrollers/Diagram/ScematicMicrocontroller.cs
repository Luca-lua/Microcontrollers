using Microcontrollers.ControllerSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.Diagram
{
    public class ScematicMicrocontroller
    {
        public string name;
        public ScematicNode VideoNode;
        public ScematicNode CompInNode;
        public ScematicNode CompOutNode;
        public ScematicMicrocontroller() { }
        internal ScematicMicrocontroller(Microcontroller controller)
        {
            this.name = controller.name;
            this.VideoNode = new ScematicNode(controller.name,controller.VideoNode.id,controller.VideoNode.IsOutput,NodeType.Video,controller.VideoNode.connected_node?.id);   // VideoMode
            this.CompInNode = new ScematicNode(controller.name, controller.InComp.id,controller.InComp.IsOutput, NodeType.Video, controller.InComp.connected_node?.id);         // CompInNode
            this.CompOutNode = new ScematicNode(controller.name,controller.OutComp.id,controller.OutComp.IsOutput, NodeType.Video, controller.OutComp.connected_node?.id);     // CompOutNode
        }
    }
}
