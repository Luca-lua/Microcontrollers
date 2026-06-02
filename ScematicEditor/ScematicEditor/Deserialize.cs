using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ScematicEditor.Diagram;

namespace ScematicEditor
{
    internal class Deserialize
    {
        internal static void deserializeScematic(string ScematicPath)
        {
            string lines = File.ReadAllText(ScematicPath);
            var test = JsonConvert.DeserializeObject<List<ScematicMicrocontroller>>(lines);
        }
    }
}
