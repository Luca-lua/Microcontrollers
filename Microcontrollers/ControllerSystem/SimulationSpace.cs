using Microcontrollers.ConnectionSystem;
using Microcontrollers.ControllerGUI;
using Microcontrollers.Diagram;
using Microcontrollers.PartSystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace Microcontrollers.ControllerSystem
{
    /// <summary>
    /// Container Class for the whole Microcontroller simulation.
    /// </summary>
    public class SimulationSpace
    {
        internal readonly List<Microcontroller> controllers;
        internal readonly List<Microcontrollers.Parts.Monitor> monitors;
        internal List<Linker> gates = new List<Linker>();
        private static GUIDrawHandler drawingHandler;
        private Stopwatch stopwatch;
        internal Nodes nodecollection;
        /// <summary>
        /// Create the top level Simulation container.
        /// </summary>
        /// <param name="editor_width">Gamespace width. Your Monitors show up in this "container"</param>
        /// <param name="editor_height">Gamespace height. Your Monitors show up in this "container"</param>
        public SimulationSpace(int editor_width, int editor_height)
        {
            controllers = new List<Microcontroller>();
            drawingHandler = new GUIDrawHandler(editor_width,editor_height);
            monitors = new List<Parts.Monitor>();
            stopwatch = new Stopwatch();
            nodecollection = new Nodes();
        }
        /// <summary>
        /// Add a logicgate into the sketch. Use the "ScematicEditor" tool to edit connections.
        /// </summary>
        /// <param name="id">Has to be unique. The ScematicParser connects by id, changing it without deleting scematic.json may lead to unwanted consequences.</param>
        /// <param name="gate">ILogicGate instance</param>
        public void addLogicGate(int id,ILogicGate gate)
        {
            gate.Construct();
            gates.Add(new Linker(id,gate, nodecollection));
        }
        /// <summary>
        /// Add a Monitor into the Sketch. Thats right, multi Monitor support is here :sunglasses: V 0.8.
        /// </summary>
        /// <param name="diagram_name"></param>
        /// <param name="resolution_px">The resolution size. Normal values: 32x32, 64x64, 96x96 ...</param>
        /// <param name="real_size_px">The size the monitor should take up on your screen. This CANNOT exceed the Simulationspace size.</param>
        /// <param name="top_left_corner_px">Position of the top left corner in simulationspace container.</param>
        public void addMonitor(string diagram_name, Size resolution_px, Size real_size_px, Size? top_left_corner_px = null)
        {
            Microcontrollers.Parts.Monitor monitor = new Microcontrollers.Parts.Monitor(diagram_name,nodecollection,diagram_name,resolution_px, real_size_px,top_left_corner_px);
            monitors.Add(monitor);
        }
        /// <summary>
        /// Add a microcontroller into the sketch. Add your controllers before any Logicgates are added, the other way is inconsistent.
        /// </summary>
        /// <param name="diagram_name">The name of the controller in the Diagrameditor. Also used as a UID for connections.</param>
        /// <param name="microcontroller">Your custom IMicrocontroller class.</param>
        public void AddMicrocontroller(string diagram_name,IMicrocontroller microcontroller)
        {
            Size buffer_size = new Size(0,0);
            foreach (Microcontrollers.Parts.Monitor monitor in monitors)
            {
                if(monitor.output_size.Width * monitor.output_size.Height > buffer_size.Width * buffer_size.Height)
                {
                    buffer_size = monitor.output_size;
                }
            }
            controllers.Add( new Microcontroller(buffer_size, microcontroller,diagram_name, nodecollection));
        }
        /// <summary>
        /// Call this Method after setup. This acts as a while(true) loop.
        /// </summary>
        /// <param name="cts">This is here more as a formality. Good luck acually cancelling this loop.</param>
        /// <returns></returns>
        public async Task RunControllers(CancellationToken cts)
        {
            JsonDiagramHandler diagramHandler = new JsonDiagramHandler(".\\scematic.json",this);
            diagramHandler.connectionsFromJson();
            gates.ForEach(a => a.Link(nodecollection));
            diagramHandler.writeJson(this);

            stopwatch.Reset();
            stopwatch.Start();

            uint tick = 1;

            while (!cts.IsCancellationRequested)
            {
                foreach (var controller in controllers)
                {
                    controller.Execute();
                }

                foreach (var gate in gates)
                {
                    gate.ExecuteLogic(nodecollection);
                }

                foreach (var monitor in monitors)
                {
                    monitor.videoIn.Transfer();
                    drawingHandler.DrawMonitor(monitor,out Vector2? click);
                    
                    if (click != null)
                    {
                        monitor.touchInfo.value.OnOffValues[1] = true;
                        monitor.touchInfo.value.NumberValues[1] = click.Value.X/monitor.real_size.Width*monitor.output_size.Width;
                        monitor.touchInfo.value.NumberValues[2] = click.Value.Y/monitor.real_size.Height*monitor.output_size.Height;
                        monitor.touchInfo.Transfer();
                    }
                    else
                    {
                        monitor.touchInfo.value.OnOffValues[1] = false;
                        monitor.touchInfo.value.NumberValues[1] = 0;
                        monitor.touchInfo.value.NumberValues[2] = 0;
                        monitor.touchInfo.Transfer();
                    }
                }

                ulong targetMS = tick * 17;

                while ((ulong)stopwatch.ElapsedMilliseconds < targetMS)
                {
                    Task.Delay(1).Wait();
                }

                tick++;
                if(tick == uint.MaxValue)
                {
                    stopwatch.Reset();
                    tick = 0;
                    stopwatch.Start();
                }
            }

            diagramHandler.writeJson(this);
        }
    }
}
