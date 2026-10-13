using Microcontrollers;
using Microcontrollers.ControllerSystem;
using Microcontrollers.Parts;
using Microcontrollers.Parts.CompConvert;
using Microcontrollers.Parts.ConsoleIO;

namespace Controllers_Console_tester
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Create new simulation window to display monitors etc on ex(500x500px)
            SimulationSpace simulation = new SimulationSpace(500,500);
            // Create new Monitor with Resolution 64x64px, taking up 250x250 px of the simulation window
            simulation.addMonitor("Display",new System.Drawing.Size(32,32),new System.Drawing.Size(250,250));

            // Initialize controller with name "Controller1"
            simulation.AddMicrocontroller("Controller1", new Controller1());

            // Add some logic gates -> OnOff where key D1 turns it to "true" and Do to "false"
            // And a OnOff to Comp converter with start channel 1 and 1 total channel
            simulation.addLogicGate(1, new OnOff_From_Console(ConsoleKey.D1,ConsoleKey.D0));
            simulation.addLogicGate(2, new OnOff_To_Composite(1, 1));
            
            // Run the simulation
            await simulation.RunControllers(new CancellationToken());
        }
    }
}
