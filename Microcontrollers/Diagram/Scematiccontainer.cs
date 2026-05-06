using Microcontrollers.PartSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.Diagram
{
    public class Scematiccontainer
    {
        public List<ScematicMicrocontroller> microcontrollerList = new List<ScematicMicrocontroller>();
        public List<ScematicMonitor> scematicMonitors = new List<ScematicMonitor>();
        public List<ScematicNode> GateNodes = new List<ScematicNode>();
    }
}
