using InputComponents;
using InputComponents.Inputs;
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
            // Create new Monitor with Resolution 64x64px, taking up 400x400 px of the simulation window
            simulation.addMonitor("Display",new System.Drawing.Size(64,64),new System.Drawing.Size(400,400));

            // Initialize controller with name "Controller1"
            simulation.AddMicrocontroller("Controller1", new Controller1());

            // Add some logic gates -> these both offer composite connections to simulate OnOff/Numeric inputs
            simulation.addLogicGate(1, new NumberInputWindow(name: "1-6 Numeric"));
            //simulation.addLogicGate(2, new OnOffValueWindow(name: "1-6 OnOff"));
            //simulation.addLogicGate(3, new AxisInputWindow(name: "Joystick"));
            
            // Run the simulation
            await simulation.RunControllers(new CancellationToken());
        }
    }
}
