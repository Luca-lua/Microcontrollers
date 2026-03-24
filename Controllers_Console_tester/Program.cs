using Microcontrollers;
using Microcontrollers.ControllerSystem;
using Microcontrollers.Models;

namespace Controllers_Console_tester
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Screen.test();
            SimulationSpace simulation = new SimulationSpace();
            simulation.AddMicrocontroller(new Controller1());
            await simulation.RunControllers(new CancellationToken());
        }
    }
}
