using ScematicEditor.Diagram;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ScematicEditor
{
    internal class Drawing
    {
        private static readonly Paintbucket paintbucket = new Paintbucket();
        internal static Dictionary<string,PartPosition> partPositions = new Dictionary<string, PartPosition>();
        private static SKCanvas activecanvas;
        private static List<string> covered_owners = new List<string>();

        internal static void DrawDiagram(Form form,SKCanvas canvas, Scematiccontainer scematiccontainer)
        {
            covered_owners.Clear();
            activecanvas = canvas;
            activecanvas.DrawRect(0, 0, form.Width, form.Height, paintbucket.Bluebackground);

            foreach (ScematicMonitor monitor in scematiccontainer.scematicMonitors)
            {
                DrawMonitor(monitor);
            }
            foreach (ScematicMicrocontroller microcontroller in scematiccontainer.microcontrollerList)
            {
                DrawController(microcontroller);
            }
            foreach (ScematicNode node in scematiccontainer.GateNodes)
            {
                if(!covered_owners.Contains(node.owner))
                    DrawNode(node,scematiccontainer);
            }
        }
        private static void DrawMonitor(ScematicMonitor scematicMonitor)
        {
            if (Position.GetPosition(scematicMonitor.name) == null)
            {
                Position.WritePosition(scematicMonitor.name, new Vector2(0, 0));
            }
            Vector2 position = (Vector2)Position.GetPosition(scematicMonitor.name);
            activecanvas.DrawRect(position.X, position.Y, ScematicMonitor.width, ScematicMonitor.height,Drawing.paintbucket.BlackTextOutline);
            activecanvas.DrawRect(position.X+5, position.Y+5, ScematicMonitor.width-10, ScematicMonitor.height-10, Drawing.paintbucket.WhiteInternal);
            activecanvas.DrawText(scematicMonitor.name, position.X + 10, position.Y + 30, paintbucket.BlackTextOutline);
            activecanvas.DrawText("Type: Monitor", position.X + 10, position.Y + 60, paintbucket.BlackTextOutline);

            if (!partPositions.ContainsKey(scematicMonitor.name))
            {
                partPositions[scematicMonitor.name] = new PartPosition(position, new Vector2(ScematicMonitor.width, ScematicMonitor.height), scematicMonitor.name);
            }

            DrawNode(new Vector2(position.X,position.Y+ScematicMonitor.height/2), scematicMonitor.videoIn);
            DrawNode(new Vector2(position.X+ScematicMonitor.width, position.Y + ScematicMonitor.height / 2), scematicMonitor.CompositeOut);
        }
        private static void DrawNode(Vector2 position,ScematicNode node)
        {
            SKPaint paint = new SKPaint();
            switch(node.nodeType)
            {
                case NodeType.OnOff:
                    paint = paintbucket.RedBoolean;
                    break;

                case NodeType.Number:
                    paint = paintbucket.GreenNumber;
                    break;

                case NodeType.Composite:
                    paint = paintbucket.PurpleComposite;
                    break;

                case NodeType.Video:
                    paint = paintbucket.BlueVideo;
                    break;
            }
            activecanvas.DrawCircle(position.X, position.Y, 15,paint);
            if (!partPositions.ContainsKey(node.id.ToString()))
            {
                partPositions[node.id.ToString()] = new PartPosition(new Vector2(position.X - 15, position.Y - 15), new Vector2(30, 30), node.id.ToString());
            }
        }
        private static void DrawController(ScematicMicrocontroller scematicMicrocontroller)
        {
            if (Position.GetPosition(scematicMicrocontroller.name) == null)
            {
                Position.WritePosition(scematicMicrocontroller.name, new Vector2(0, 0));
            }
            Vector2 position = (Vector2)Position.GetPosition(scematicMicrocontroller.name);
            scematicMicrocontroller.CompOutNode.nodeType = NodeType.Composite;
            scematicMicrocontroller.CompInNode.nodeType = NodeType.Composite;
            activecanvas.DrawRect(position.X, position.Y, ScematicMicrocontroller.width, ScematicMicrocontroller.height, paintbucket.BlackTextOutline);
            activecanvas.DrawRect(position.X + 5, position.Y + 5, ScematicMicrocontroller.width - 10, ScematicMicrocontroller.height - 10, paintbucket.WhiteInternal);
            activecanvas.DrawText(scematicMicrocontroller.name, position.X + 10, position.Y + 30, paintbucket.BlackTextOutline);
            activecanvas.DrawText("Type: Controller", position.X + 10, position.Y + 60, paintbucket.BlackTextOutline);

            if (!partPositions.ContainsKey(scematicMicrocontroller.name)) {
                partPositions[scematicMicrocontroller.name] = new PartPosition(position, new Vector2(ScematicMicrocontroller.width, ScematicMicrocontroller.width), scematicMicrocontroller.name);
            }

            DrawNode(new Vector2(position.X, position.Y + ScematicMicrocontroller.height / 2),scematicMicrocontroller.CompInNode);
            DrawNode(new Vector2(position.X+ScematicMicrocontroller.width, position.Y + ScematicMicrocontroller.height / 3), scematicMicrocontroller.VideoNode);
            DrawNode(new Vector2(position.X + ScematicMicrocontroller.width, position.Y + ScematicMicrocontroller.height / 3*2), scematicMicrocontroller.CompOutNode);
        }
        private static void DrawNode(ScematicNode node,Scematiccontainer container)
        {
            if (Position.GetPosition(node.id.ToString()+"_") == null)
            {
                Position.WritePosition(node.owner.ToString()+"_", new Vector2(0, 0));
            }
            List<ScematicNode> nodes_in = new List<ScematicNode>();
            List<ScematicNode> nodes_out = new List<ScematicNode>();
            Vector2 position = (Vector2)Position.GetPosition(node.id.ToString()+"_");
            foreach(ScematicNode gateNode in container.GateNodes)
            {
                if(gateNode.owner == node.owner)
                {
                    if (gateNode.isOutput)
                    {
                        nodes_out.Add(gateNode);
                    }
                    else
                    {
                        nodes_in.Add(gateNode);
                    }
                }
            }
            covered_owners.Add(node.owner);
            int height = ((int)Math.Round(Math.Max(nodes_in.Count,nodes_out.Count)+0.5))*100;
            int width = Math.Max(200, height);
            activecanvas.DrawRect(position.X, position.Y, width, height, paintbucket.BlackTextOutline);
            activecanvas.DrawRect(position.X + 5, position.Y + 5, width - 10, height - 10, paintbucket.WhiteInternal);
            activecanvas.DrawText(node.owner, position.X + 10, position.Y + 30, paintbucket.BlackTextOutline);
            activecanvas.DrawText("Type: Node", position.X + 10, position.Y + 60, paintbucket.BlackTextOutline);
            partPositions[node.owner.ToString()+"_"] = new PartPosition(position, new Vector2(width,height),node.owner.ToString()+"_");
            // Draw Rest OF NODES
        }
    }
}
