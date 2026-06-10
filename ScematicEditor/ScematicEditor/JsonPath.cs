using System;
using System.Collections.Generic;
using System.Text;

namespace ScematicEditor
{
    internal class JsonPath
    {
        internal static string readFile()
        { 
            if(!File.Exists(".\\JSONDiagramPath.txt"))
            {
                var file = File.Create(".\\JSONDiagramPath.txt");
                file.Close();
                throw new Exception("JSONDiagramPath.txt created please insert path to scematic.json and restart");
            }
            else
            {
                string path = File.ReadAllText(".\\JSONDiagramPath.txt").Replace("\"","");
                if(!File.Exists(path))
                {
                    throw new FileFormatException("Invalid path to scematic.json in .\\JSONDiagramPath.txt");
                }
                return path.Replace("scematic.json","");
            }
        }
    }
}
