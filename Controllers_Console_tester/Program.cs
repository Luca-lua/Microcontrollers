using Microcontrollers;
using Microcontrollers.ControllerSystem;

namespace Controllers_Console_tester
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            SimulationSpace simulation = new SimulationSpace(500,500);
            simulation.addMonitor("mostunepicscreen",new System.Drawing.Size(32,32),new System.Drawing.Size(250,250));
            simulation.AddMicrocontroller("Mostepiccontroller",new Controller1());
            simulation.AddMicrocontroller("MasterController", new MasterController());
            
            await simulation.RunControllers(new CancellationToken());
        }
    }
}
