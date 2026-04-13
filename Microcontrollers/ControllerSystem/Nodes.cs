using Microcontrollers.ConnectionSystem;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.ControllerSystem
{
    internal class Nodes
    {
        internal List<OnOffNode> OnOffNodes;
        internal List<NumberNode> NumberNodes;
        internal List<VideoNode> VideoNodes;
        internal List<CompNode> CompositeNodes;
        internal int node_id_counter = 0;
        internal Nodes() 
        {
            OnOffNodes = new List<OnOffNode>();
            NumberNodes = new List<NumberNode>();
            VideoNodes = new List<VideoNode>();
            CompositeNodes = new List<CompNode>();
        }   
        internal VideoNode addVideoNode(VideoNode node)
        {
            node.id = node_id_counter;
            node_id_counter++;
            VideoNodes.Add(node);
            return node;
        }
        internal CompNode addCompositeNode(CompNode node)
        {
            node.id = node_id_counter;
            node_id_counter++;
            CompositeNodes.Add(node);
            return node;
        }
        internal OnOffNode addOnOffNode(OnOffNode node)
        {
            node.id = node_id_counter;
            node_id_counter++;
            OnOffNodes.Add(node);
            return node;
        }
        internal NumberNode addNumberNode(NumberNode node)
        {
            node.id = node_id_counter;
            node_id_counter++;
            NumberNodes.Add(node);
            return node;
        }
    }
}
