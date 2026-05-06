using Microcontrollers.ConnectionSystem;
using Microcontrollers.ControllerSystem;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Microcontrollers.PartSystem
{
    public class Linker
    {
        public Linker() { }
        public int id;
        public ILogicGate gate { get; set; }
        public List<Tuple<int, int>> links { get; set; } = new List<Tuple<int, int>>();
        internal Linker(int id,ILogicGate gate,Nodes logicnodes) 
        {
            this.gate = gate;
            this.id = id;

            // link comp nodes
            foreach (CompositeGateNode cmpNode in gate.CompNodes)
            {
                Tuple<int, int> link = new Tuple<int, int>(cmpNode._id, logicnodes.node_id_counter);
                logicnodes.addCompositeNode(new CompNode(cmpNode._isOutput));
                links.Add(link);
            }

            // link number nodes
            foreach (NumberGateNode numNode in gate.NumberNodes)
            {
                Tuple<int, int> link = new Tuple<int, int>(numNode._id, logicnodes.node_id_counter);
                logicnodes.addNumberNode(new NumberNode(numNode._isOutput));
                links.Add(link);
            }

            // link on/off nodes
            foreach (OnOffGateNode onoNode in gate.OnOffNodes)
            {
                Tuple<int, int> link = new Tuple<int, int>(onoNode._id, logicnodes.node_id_counter);
                logicnodes.addOnOffNode(new OnOffNode(onoNode._isOutput));
                links.Add(link);
            }

            // link video nodes
            foreach (VideoGateNode vidNode in gate.VideoNodes)
            {
                Tuple<int, int> link = new Tuple<int, int>(vidNode._id, logicnodes.node_id_counter);
                logicnodes.addVideoNode(new VideoNode(vidNode._isOutput));
                links.Add(link);
            }
            
        }
        private void ExecuteInputs(Nodes logicnodes)
        {
            // Comp Nodes
            foreach(CompositeGateNode cmpNode in gate.CompNodes )
            {
                if(!cmpNode._isOutput)
                {
                    var real_node = logicnodes.CompositeNodes.FindLast(c => c.id == links.FindLast(l => l.Item1 == cmpNode._id).Item2);
                    cmpNode.value = real_node.value;
                } 
            }
            // Number Nodes
            foreach (NumberGateNode numNode in gate.NumberNodes)
            {
                if (!numNode._isOutput)
                {
                    var real_node = logicnodes.NumberNodes.FindLast(c => c.id == links.FindLast(l => l.Item1 == numNode._id).Item2);
                    numNode.value = real_node.value;
                }
            }
            // OnOff Nodes
            foreach (OnOffGateNode onoNode in gate.OnOffNodes)
            {
                if (!onoNode._isOutput)
                {
                    if(links.Find(l => l.Item1 == onoNode._id).Item2 == 8)
                    {
                        var brk = 3;
                    }
                    var real_node = logicnodes.OnOffNodes.FindLast(c => c.id == links.Find(l => l.Item1 == onoNode._id).Item2);
                    onoNode.value = real_node.value;
                }
            }
            // VideoNodes
            foreach (VideoGateNode vidNode in gate.VideoNodes)
            {
                if (!vidNode._isOutput)
                {
                    var real_node = logicnodes.VideoNodes.FindLast(c => c.id == links.Find(l => l.Item1 == vidNode._id).Item2);
                    vidNode.value = real_node.value;
                }
            }
        }
        private void ExecuteOutputs(Nodes logicnodes)
        {
            // Comp Nodes
            foreach (CompositeGateNode cmpNode in gate.CompNodes)
            {
                if (cmpNode._isOutput)
                {
                    var real_node = logicnodes.CompositeNodes.FindLast(c => c.id == links.Find(l => l.Item1 == cmpNode._id).Item2);
                    real_node.value = cmpNode.value;
                    if (real_node.connected_node != null)
                    {
                        real_node.connected_node.value = real_node.value;
                    }
                }
            }
            // Number Nodes
            foreach (NumberGateNode numNode in gate.NumberNodes)
            {
                if (numNode._isOutput)
                {
                    var real_node = logicnodes.NumberNodes.FindLast(c => c.id == links.Find(l => l.Item1 == numNode._id).Item2);
                    real_node.value = numNode.value;
                    if (real_node.connected_node != null)
                    {
                        real_node.connected_node.value = real_node.value;
                    }
                }
            }
            // OnOff Nodes
            foreach (OnOffGateNode onoNode in gate.OnOffNodes)
            {
                if (onoNode._isOutput)
                {
                    if(links.Find(l => l.Item1 == onoNode._id).Item2 == 10)
                    {
                        var brk2 = 3;
                    }
                    var real_node = logicnodes.OnOffNodes.FindLast(c => c.id == links.Find(l => l.Item1 == onoNode._id).Item2);
                    real_node.value = onoNode.value;
                    if (real_node.connected_node != null)
                    {
                        real_node.connected_node.value = real_node.value;
                    }
                }
            }
            // VideoNodes
            foreach (VideoGateNode vidNode in gate.VideoNodes)
            {
                if (vidNode._isOutput)
                {
                    var real_node = logicnodes.VideoNodes.FindLast(c => c.id == links.Find(l => l.Item1 == vidNode._id).Item2);
                    real_node.value = vidNode.value;
                    if (real_node.connected_node != null)
                    {
                        real_node.connected_node.value = real_node.value;
                        real_node.screen_size_return = logicnodes.VideoNodes.Find(g => g.id == real_node.connected_node.id).screen_size_return;
                    }
                }
            }
        }
        internal void Link(Nodes logicnodes)
        {
            foreach (Tuple<int,int> link in links)
            {
                var cmpNode = gate.CompNodes.Find(g => g._id == link.Item1);
                if(cmpNode != null)
                {
                    var real_node = logicnodes.CompositeNodes.Find(g => g.id == link.Item2);
                    cmpNode.target_id = real_node.connected_node?.id;
                }
                var numNode = gate.NumberNodes.Find(g => g._id == link.Item1);
                if (numNode != null)
                {
                    var real_node = logicnodes.NumberNodes.Find(g => g.id == link.Item2);
                    numNode.target_id = real_node.connected_node?.id;
                }
                var onoNode = gate.OnOffNodes.Find(g => g._id == link.Item1);
                if(onoNode != null)
                {
                    var real_node = logicnodes.OnOffNodes.Find(g => g.id == link.Item2);
                    onoNode.target_id = real_node.connected_node?.id;
                }
                var vidNode = gate.VideoNodes.Find(g => g._id == link.Item2);
                if(vidNode != null)
                {
                    var real_node = logicnodes.VideoNodes.Find(g => g.id == link.Item2);
                    vidNode.target_id = real_node.connected_node?.id;
                }
            }
        }
        internal void ExecuteLogic(Nodes logicnodes)
        {
            ExecuteInputs(logicnodes);
            gate.Execute();
            ExecuteOutputs(logicnodes);
        }
    }
}
