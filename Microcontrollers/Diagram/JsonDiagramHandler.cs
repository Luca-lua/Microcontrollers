using Microcontrollers.ConnectionSystem;
using Microcontrollers.ControllerSystem;
using Microcontrollers.PartSystem;
using Newtonsoft;
using Newtonsoft.Json;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Text;
using System.Text.Json;

namespace Microcontrollers.Diagram
{
    internal class JsonDiagramHandler
    {
        private string jsonPath {  get; set; }
        private SimulationSpace sim {  get; set; }
        internal JsonDiagramHandler(string path,SimulationSpace simulator)
        {
            jsonPath = path;
            if(!File.Exists(jsonPath))
            {
                FileStream file = File.Create(jsonPath);
                file.Close();
            }
            sim = simulator;
        }
        internal void writeJson()
        {

            // Microcontroller
            List<ScematicMicrocontroller> scematiclist = new List<ScematicMicrocontroller>();
            foreach(Microcontroller controller in sim.controllers)
            {
                scematiclist.Add(new ScematicMicrocontroller(controller));
            }
            Scematiccontainer scematiccontainer = new Scematiccontainer();
            scematiccontainer.microcontrollerList = scematiclist;

            // Monitors
            List<ScematicMonitor> scematicMonitors = new List<ScematicMonitor>();
            foreach(Microcontrollers.Parts.Monitor monitor in sim.monitors)
            {
                scematicMonitors.Add(new ScematicMonitor(monitor));
            }
            scematiccontainer.scematicMonitors = scematicMonitors;

            scematiccontainer.GateNodes = new List<ScematicNode>();

            foreach(var linker in sim.gates)
            {
                // Comp
                foreach(CompositeGateNode cmpNode in linker.gate.CompNodes)
                {
                    scematiccontainer.GateNodes.Add(GateScematicConvert.NodeToScematic(cmpNode, linker));
                }
                // Vid
                foreach (VideoGateNode vidNode in linker.gate.VideoNodes)
                {
                    scematiccontainer.GateNodes.Add(GateScematicConvert.NodeToScematic(vidNode, linker));
                }
                // number
                foreach (NumberGateNode numNode in linker.gate.NumberNodes)
                {
                    scematiccontainer.GateNodes.Add(GateScematicConvert.NodeToScematic(numNode, linker));
                }
                // Vid
                foreach (OnOffGateNode onoNode in linker.gate.OnOffNodes)
                {
                    scematiccontainer.GateNodes.Add(GateScematicConvert.NodeToScematic(onoNode, linker));
                }
            }

            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(scematiccontainer, Formatting.Indented));
        }
        internal void connectionsFromJson()
        {
            string json = File.ReadAllText(jsonPath);
            Scematiccontainer scematiccontainer = JsonConvert.DeserializeObject<Scematiccontainer> (json);

            if(scematiccontainer == null)
            {
                return;
            }

            // VideoNodes
            foreach(VideoNode node in sim.nodecollection.VideoNodes)
            {
                foreach(ScematicMicrocontroller scematicMicrocontroller in scematiccontainer.microcontrollerList)
                {
                    if(scematicMicrocontroller.VideoNode.id == node.id)
                    {
                        ScematicNode scematicNode = scematicMicrocontroller.VideoNode;
                        node.IsOutput = scematicNode.isOutput;
                        foreach(VideoNode target in sim.nodecollection.VideoNodes)
                        {
                            if(target.id == scematicNode.target_id)
                            {
                                node.connected_node = target;
                                target.connected_node = node;
                            }
                        }
                    }
                }
            }

            // CompInNodes
            foreach (CompNode node in sim.nodecollection.CompositeNodes)
            {
                foreach (ScematicMicrocontroller scematicMicrocontroller in scematiccontainer.microcontrollerList)
                {
                    if (scematicMicrocontroller.CompInNode.id == node.id)
                    {
                        ScematicNode scematicNode = scematicMicrocontroller.CompInNode;
                        node.IsOutput = scematicNode.isOutput;
                        foreach (CompNode target in sim.nodecollection.CompositeNodes)
                        {
                            if (target.id == scematicNode.target_id)
                            {
                                node.connected_node = target;
                                target.connected_node = node;
                            }
                        }
                    }
                }
            }

            // CompOutNodes
            foreach (CompNode node in sim.nodecollection.CompositeNodes)
            {
                foreach (ScematicMicrocontroller scematicMicrocontroller in scematiccontainer.microcontrollerList)
                {
                    if (scematicMicrocontroller.CompOutNode.id == node.id)
                    {
                        ScematicNode scematicNode = scematicMicrocontroller.CompOutNode;
                        node.IsOutput = scematicNode.isOutput;
                        foreach (CompNode target in sim.nodecollection.CompositeNodes)
                        {
                            if (target.id == scematicNode.target_id)
                            {
                                node.connected_node = target;
                                target.connected_node = node;
                            }
                        }
                    }
                }
            }

            // OnOffNodes
            foreach(OnOffNode node in sim.nodecollection.OnOffNodes)
            {
                foreach (ScematicMicrocontroller scematicMicrocontroller in scematiccontainer.microcontrollerList)
                {
                    if (scematicMicrocontroller.CompOutNode.id == node.id)
                    {
                        ScematicNode scematicNode = scematicMicrocontroller.CompOutNode;
                        node.IsOutput = scematicNode.isOutput;
                        foreach (OnOffNode target in sim.nodecollection.OnOffNodes)
                        {
                            if (target.id == scematicNode.target_id)
                            {
                                node.connected_node = target;
                                target.connected_node = node;
                            }
                        }
                    }
                }
            }

            // NumberNodes
            foreach (NumberNode node in sim.nodecollection.NumberNodes)
            {
                foreach (ScematicMicrocontroller scematicMicrocontroller in scematiccontainer.microcontrollerList)
                {
                    if (scematicMicrocontroller.CompOutNode.id == node.id)
                    {
                        ScematicNode scematicNode = scematicMicrocontroller.CompOutNode;
                        node.IsOutput = scematicNode.isOutput;
                        foreach (NumberNode target in sim.nodecollection.NumberNodes)
                        {
                            if (target.id == scematicNode.target_id)
                            {
                                node.connected_node = target;
                                target.connected_node = node;
                            }
                        }
                    }
                }
            }

            // Logic Gates
            foreach(ScematicNode node in scematiccontainer.GateNodes)
            {
                if (node.target_id != null)
                {
                    //CMP
                    if(node.nodeType == NodeType.Composite)
                    {
                        var target_node = sim.nodecollection.CompositeNodes.FindLast(ln => ln.id == node.target_id);
                        var own_node = sim.nodecollection.CompositeNodes.FindLast(ln => ln.id == node.id);
                        if (target_node == null)
                        {
                            throw new ConfigurationException($"scematic.json references not existing target id.\n NodeId: [{target_node}] referenced from Node [{node.id}] does not exist!");
                        }
                        if (own_node == null)
                        {
                            throw new ConfigurationException($"scematic.json references not existing node id.\n NodeId: [{target_node}]");
                        }
                        own_node.connected_node = target_node;
                        target_node.connected_node = own_node;
                    }

                    //NMB
                    if (node.nodeType == NodeType.Number)
                    {
                        var target_node = sim.nodecollection.NumberNodes.FindLast(ln => ln.id == node.target_id);
                        var own_node = sim.nodecollection.NumberNodes.FindLast(ln => ln.id == node.id);
                        if (target_node == null)
                        {
                            throw new ConfigurationException($"scematic.json references not existing target id.\n NodeId: [{target_node}] referenced from Node [{node.id}] does not exist!");
                        }
                        if (own_node == null)
                        {
                            throw new ConfigurationException($"scematic.json references not existing node id.\n NodeId: [{target_node}]");
                        }
                        own_node.connected_node = target_node;
                        target_node.connected_node = own_node;
                    }

                    //ONO
                    if (node.nodeType == NodeType.OnOff)
                    {
                        var target_node = sim.nodecollection.OnOffNodes.FindLast(ln => ln.id == node.target_id);
                        var own_node = sim.nodecollection.OnOffNodes.FindLast(ln => ln.id == node.id);
                        if (target_node == null)
                        {
                            throw new ConfigurationException($"scematic.json references not existing target id.\n NodeId: [{target_node}] referenced from Node [{node.id}] does not exist!");
                        }
                        if (own_node == null)
                        {
                            throw new ConfigurationException($"scematic.json references not existing node id.\n NodeId: [{target_node}]");
                        }
                        own_node.connected_node = target_node;
                        target_node.connected_node = own_node;
                    }

                    //VID
                    if (node.nodeType == NodeType.Video)
                    {
                        var target_node = sim.nodecollection.VideoNodes.FindLast(ln => ln.id == node.target_id);
                        var own_node = sim.nodecollection.VideoNodes.FindLast(ln => ln.id == node.id);
                        if (target_node == null)
                        {
                            throw new ConfigurationException($"scematic.json references not existing target id.\n NodeId: [{target_node}] referenced from Node [{node.id}] does not exist!");
                        }
                        if (own_node == null)
                        {
                            throw new ConfigurationException($"scematic.json references not existing node id.\n NodeId: [{target_node}]");
                        }
                        own_node.connected_node = target_node;
                        target_node.connected_node = own_node;
                    }
                }
            }
        }
    }
}