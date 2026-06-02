using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Text;

namespace ScematicEditor
{
    internal class Position
    {
        private static Dictionary<string,Vector2> PositionID;
        private static string save_file;
        internal static void Position_setup(string savefile)
        {
            if (!File.Exists(savefile))
            {
                var block = File.Create(savefile);
                block.Close();
            }
            save_file = savefile;
            Position.PositionID = new Dictionary<string, Vector2>();
        }

        internal static void WritePosition(string id, Vector2 position)
        {
            Position.PositionID[id] = position;
        }

        internal static Vector2? GetPosition(string id)
        {
            try
            {
                return Position.PositionID[id];
            }
            catch(Exception e)
            {
                return null;
            }
        }

        internal static void WriteJson()
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            string Json_string = JsonConvert.SerializeObject(Position.PositionID,settings);
            File.WriteAllText(save_file,Json_string);
        }

        internal static void ReadJson()
        {
            string text = File.ReadAllText(save_file);
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            var result = (Dictionary<string, Vector2>)JsonConvert.DeserializeObject(text,settings);
            if (result != null)
                Position.PositionID = result;
        }
    }
}
