using System;
using System.Collections.Generic;
using System.Text;

namespace ScematicEditor.Diagram
{
    public class ScematicMonitor
    {
        public static int width = 300;
        public static int height = 100;

        public string name;
        public ScematicNode videoIn;
        public ScematicNode CompositeOut;
        public ScematicMonitor() { }
    }
}
