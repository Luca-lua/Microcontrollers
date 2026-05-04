using Microcontrollers.ControllerSystem;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Text;
using System.Text.Json;
using Newtonsoft;
using Newtonsoft.Json;
using Microcontrollers.ConnectionSystem;
using SkiaSharp;

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

            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(scematiccontainer, Formatting.Indented));
        }
        internal void connectionsFromJson()
        {
            string json = File.ReadAllText(jsonPath);
            Scematiccontainer scematiccontainer = JsonConvert.DeserializeObject<Scematiccontainer> (json);

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
        }
    }
}
