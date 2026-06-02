using Newtonsoft;
using Newtonsoft.Json;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Text;
using System.Text.Json;

namespace ScematicEditor.Diagram
{
    internal class JsonDiagramHandler
    {
        private string jsonPath {  get; set; }
        internal JsonDiagramHandler(string path)
        {
            jsonPath = path;
            if(!File.Exists(jsonPath))
            {
                FileStream file = File.Create(jsonPath);
                file.Close();
            }
        }
        internal void writeJsonFromScematiccontainer(Scematiccontainer scematiccontainer)
        {


            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(scematiccontainer, Formatting.Indented));
        }

        internal Scematiccontainer? CreateScematicContainer()
        {
            string json = File.ReadAllText(jsonPath);
            Scematiccontainer scematiccontainer = JsonConvert.DeserializeObject<Scematiccontainer> (json);

            return scematiccontainer;
        }
    }
}