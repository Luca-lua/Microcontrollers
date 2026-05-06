using Microcontrollers.ConnectionSystem;
using Microcontrollers.ControllerGUI;
using Microcontrollers.Diagram;
using Microcontrollers.PartSystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Microcontrollers.ControllerSystem
{
    public class SimulationSpace
    {
        internal readonly List<Microcontroller> controllers;
        internal readonly List<Microcontrollers.Parts.Monitor> monitors;
        internal List<Linker> gates = new List<Linker>();
        private static GUIDrawHandler drawingHandler;
        private Stopwatch stopwatch;
        internal Nodes nodecollection;
        public SimulationSpace(int editor_width, int editor_height)
        {
            controllers = new List<Microcontroller>();
            drawingHandler = new GUIDrawHandler(editor_width,editor_height);
            monitors = new List<Parts.Monitor>();
            stopwatch = new Stopwatch();
            nodecollection = new Nodes();
        }
        public void addLogicGate(int id,ILogicGate gate)
        {
            gate.Construct();
            gates.Add(new Linker(id,gate, nodecollection));
        }
        public void addMonitor(string diagram_name, Size resolution_px, Size real_size_px, Size? top_left_corner_px = null)
        {
            Microcontrollers.Parts.Monitor monitor = new Microcontrollers.Parts.Monitor(diagram_name,nodecollection,diagram_name,resolution_px, real_size_px,top_left_corner_px);
            monitors.Add(monitor);
        }

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

        public async Task RunControllers(CancellationToken cts)
        {
            JsonDiagramHandler diagramHandler = new JsonDiagramHandler("./scematic.json",this);
            diagramHandler.connectionsFromJson();
            gates.ForEach(a => a.Link(nodecollection));
            diagramHandler.writeJson();

            while (!cts.IsCancellationRequested)
            {
                stopwatch.Reset();
                stopwatch.Start();
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
                    drawingHandler.DrawMonitor(monitor);
                }
                stopwatch.Stop();
                await Task.Delay(Math.Clamp(17 - (int)stopwatch.ElapsedTicks, 0, 100));
            }

            diagramHandler.writeJson();
        }
    }
}
