using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.ControllerSystem
{
    public class SimulationSpace
    {
        private readonly List<Microcontroller> controllers;

        public SimulationSpace()
        {
            controllers = new List<Microcontroller>();
        }

        public void AddMicrocontroller(IMicrocontroller microcontroller)
        {
            controllers.Add( new Microcontroller(microcontroller));
        }

        public async Task RunControllers(CancellationToken cts)
        {
            while (!cts.IsCancellationRequested)
            {
                foreach (var controller in controllers)
                {
                    controller.Execute();
                }
            }
        }
    }
}
