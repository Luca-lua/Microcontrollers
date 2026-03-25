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
            List<ScematicMicrocontroller> scematiclist = new List<ScematicMicrocontroller>();
            foreach(Microcontroller controller in sim.controllers)
            {
                scematiclist.Add(new ScematicMicrocontroller(controller));
            }
            Scematiccontainer scematiccontainer = new Scematiccontainer();
            scematiccontainer.microcontrollerList = scematiclist;
            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(scematiccontainer,Formatting.Indented));
        }
        internal void connectionsFromJson()
        {
            string json = File.ReadAllText(jsonPath);
            Scematiccontainer scematiccontainer = JsonConvert.DeserializeObject<Scematiccontainer> (json);
            foreach(VideoNode node in sim.nodecollection.VideoNodes)
            {
                //implement rest here node import
            }
        }
    }
}
