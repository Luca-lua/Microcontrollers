using Microcontrollers;
using Microcontrollers.ControllerSystem;
using Microcontrollers.Parts;

namespace Controllers_Console_tester
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            SimulationSpace simulation = new SimulationSpace(500,500);
            simulation.addMonitor("Screen1",new System.Drawing.Size(64,64),new System.Drawing.Size(250,250));
            simulation.AddMicrocontroller("Controller1",new Controller1());
            simulation.AddMicrocontroller("MasterController", new MasterController());
            
            await simulation.RunControllers(new CancellationToken());
        }
    }
}
