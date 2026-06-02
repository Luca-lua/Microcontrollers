using System;
using System.Collections.Generic;
using System.Text;

namespace ScematicEditor.Diagram
{
    public class ScematicMicrocontroller
    {
        internal static int width = 300;
        internal static int height = 200;
        public string name;
        public ScematicNode VideoNode;
        public ScematicNode CompInNode;
        public ScematicNode CompOutNode;
        public ScematicMicrocontroller() { }
    }
}
