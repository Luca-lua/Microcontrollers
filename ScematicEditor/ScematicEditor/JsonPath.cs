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
                Console.WriteLine("JSONDiagramPath.txt created please insert path to scematic.json and restart");
                throw new Exception("JSONDiagramPath.txt created please insert path to scematic.json and restart");
            }
            else
            {
                string path = File.ReadAllText(".\\JSONDiagramPath.txt").Replace("\"","");
                Console.WriteLine(path);
                if(!File.Exists(path))
                {
                    Console.WriteLine("Invalid path to scematic.json in .\\JSONDiagramPath.txt");
                    throw new FileFormatException("Invalid path to scematic.json in .\\JSONDiagramPath.txt");
                }
                return path.Replace("scematic.json","");
            }
        }
    }
}
