using Microcontrollers.Diagram;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.PartSystem
{
    internal class GateScematicConvert
    {
        // Gate to Scematic
        internal static ScematicNode NodeToScematic(CompositeGateNode node,Linker linker)
        {
            return new ScematicNode(linker.id.ToString(),linker.links.FindLast(l => l.Item1 == node._id).Item2, node._isOutput, NodeType.Composite, node.target_id);
        }
        internal static ScematicNode NodeToScematic(NumberGateNode node,Linker linker)
        {
            return new ScematicNode(linker.id.ToString(), linker.links.FindLast(l => l.Item1 == node._id).Item2, node._isOutput, NodeType.Number, node.target_id);
        }
        internal static ScematicNode NodeToScematic(OnOffGateNode node, Linker linker)
        {
            return new ScematicNode(linker.id.ToString(), linker.links.FindLast(l => l.Item1 == node._id).Item2, node._isOutput, NodeType.OnOff, node.target_id);
        }
        internal static ScematicNode NodeToScematic(VideoGateNode node, Linker linker)
        {
            return new ScematicNode(linker.id.ToString(), linker.links.FindLast(l => l.Item1 == node._id).Item2, node._isOutput, NodeType.Video, node.target_id);
        }

        // Scematic to Gate
        internal static CompositeGateNode ScematicToCmpNode(ScematicNode node)
        {
            if(node.nodeType != NodeType.Composite)
            {
                throw new Exception($"Conversion from Scematic failed. Wrong Type of scematic. NodeID: [{node.id}] expected Composite Node");
            }
            return new CompositeGateNode(node.id,node.isOutput,node.target_id);
        }
        internal static NumberGateNode ScematicToNumNode(ScematicNode node)
        {
            if (node.nodeType != NodeType.Number)
            {
                throw new Exception($"Conversion from Scematic failed. Wrong Type of scematic. NodeID: [{node.id}] expected Number Node");
            }
            return new NumberGateNode(node.id, node.isOutput, node.target_id);
        }
        internal static OnOffGateNode ScematicToOnoNode(ScematicNode node)
        {
            if (node.nodeType != NodeType.OnOff)
            {
                throw new Exception($"Conversion from Scematic failed. Wrong Type of scematic. NodeID: [{node.id} expected OnOff Node]");
            }
            return new OnOffGateNode(node.id, node.isOutput, node.target_id);
        }
        internal static VideoGateNode ScematicToVidNode(ScematicNode node)
        {
            if (node.nodeType != NodeType.Video)
            {
                throw new Exception($"Conversion from Scematic failed. Wrong Type of scematic. NodeID: [{node.id}] expected Video Node");
            }
            return new VideoGateNode(node.id, node.isOutput, node.target_id);
        }
    }
}
