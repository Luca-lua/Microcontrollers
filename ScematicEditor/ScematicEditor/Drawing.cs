using ScematicEditor.Diagram;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ScematicEditor
{
    internal class Drawing
    {
        internal static List<ScematicNode> nodes = new List<ScematicNode>();
        internal static readonly Paintbucket paintbucket = new Paintbucket();
        internal static Dictionary<string,PartPosition> partPositions = new Dictionary<string, PartPosition>();
        internal static SKCanvas activecanvas;
        private static List<string> covered_owners = new List<string>();
        private static SKFont font;

        private static int zoom(int var)
        {
            return (int)(var / MainForm.zoom);
        }
        internal static void DrawDiagram(Form form,SKCanvas canvas, Scematiccontainer scematiccontainer)
        {
            font = new SKFont();
            font.Size = zoom(30);
            nodes.Clear();
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
                    DrawNodes(node,scematiccontainer);
            }
        }
        private static void DrawMonitor(ScematicMonitor scematicMonitor)
        {
            if (Position.GetPosition(scematicMonitor.name) == null)
            {
                Position.WritePosition(scematicMonitor.name, new Vector2(0, 0));
            }
            Vector2 position = (Vector2)Position.GetPosition(scematicMonitor.name);

            position = new Vector2((int)((position.X+MainForm.offset_x)/MainForm.zoom), (int)((position.Y+MainForm.offset_y) / MainForm.zoom));
            int width = (int)(ScematicMonitor.width / MainForm.zoom);
            int height = (int)(ScematicMonitor.height / MainForm.zoom);

            activecanvas.DrawRect(position.X, position.Y, width, height,Drawing.paintbucket.BlackTextOutline);
            activecanvas.DrawRect(position.X+ (int)(5 / MainForm.zoom), position.Y+ (int)(5 / MainForm.zoom), width- (int)(10 / MainForm.zoom), height - (int)(10/MainForm.zoom), Drawing.paintbucket.WhiteInternal);
            activecanvas.DrawText(scematicMonitor.name, position.X + (int)(30 / MainForm.zoom), position.Y + (int)(30 / MainForm.zoom),SKTextAlign.Left,font, paintbucket.BlackTextOutline);
            activecanvas.DrawText("Type: Monitor", position.X + (int)(10 / MainForm.zoom), position.Y + (int)(60 / MainForm.zoom), SKTextAlign.Left, font, paintbucket.BlackTextOutline);

            partPositions[scematicMonitor.name] = new PartPosition(position, new Vector2(width, height), scematicMonitor.name);

            DrawNode(new Vector2(position.X,position.Y+height/2), scematicMonitor.videoIn);
            DrawNode(new Vector2(position.X+width, position.Y + height / 2), scematicMonitor.CompositeOut);
        }
        private static void DrawNode(Vector2 position,ScematicNode node)
        {
            nodes.Add(node);
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

            int radius = (int)(15 /MainForm.zoom);

            if(node.isOutput)
            {
                radius = (int)(8/MainForm.zoom);
            }
            activecanvas.DrawCircle(position.X, position.Y, radius,paint);
            partPositions[node.id.ToString()] = new PartPosition(new Vector2(position.X - zoom(15), position.Y - zoom(15)), new Vector2(zoom(30), zoom(30)), node.id.ToString());
        }
        private static void DrawController(ScematicMicrocontroller scematicMicrocontroller)
        {
            if (Position.GetPosition(scematicMicrocontroller.name) == null)
            {
                Position.WritePosition(scematicMicrocontroller.name, new Vector2(0, 0));
            }
            Vector2 position = (Vector2)Position.GetPosition(scematicMicrocontroller.name);

            position = new Vector2((int)((position.X + MainForm.offset_x) / MainForm.zoom), (int)((position.Y + MainForm.offset_y) / MainForm.zoom));
            int width = (int)(ScematicMicrocontroller.width / MainForm.zoom);
            int height = (int)(ScematicMicrocontroller.height / MainForm.zoom);

            scematicMicrocontroller.CompOutNode.nodeType = NodeType.Composite;
            scematicMicrocontroller.CompInNode.nodeType = NodeType.Composite;
            activecanvas.DrawRect(position.X, position.Y, width, height, paintbucket.BlackTextOutline);
            activecanvas.DrawRect(position.X + zoom(5), position.Y + zoom(5), width - zoom(10), height - zoom(10), paintbucket.WhiteInternal);
            activecanvas.DrawText(scematicMicrocontroller.name, position.X + zoom(10), position.Y + zoom(30), SKTextAlign.Left, font, paintbucket.BlackTextOutline);
            activecanvas.DrawText("Type: Controller", position.X + zoom(10), position.Y + zoom(60), SKTextAlign.Left, font, paintbucket.BlackTextOutline);

            partPositions[scematicMicrocontroller.name] = new PartPosition(position, new Vector2(width, height), scematicMicrocontroller.name);

            DrawNode(new Vector2(position.X, position.Y + height / 2),scematicMicrocontroller.CompInNode);
            DrawNode(new Vector2(position.X+ width, position.Y + width / 3), scematicMicrocontroller.VideoNode);
            DrawNode(new Vector2(position.X + width, position.Y + height / 3*2), scematicMicrocontroller.CompOutNode);
        }
        private static void DrawNodes(ScematicNode node,Scematiccontainer container)
        {
            if (Position.GetPosition(node.owner.ToString()+"_") == null)
            {
                Position.WritePosition(node.owner.ToString()+"_", new Vector2(0, 0));
            }
            List<ScematicNode> nodes_in = new List<ScematicNode>();
            List<ScematicNode> nodes_out = new List<ScematicNode>();
            Vector2 position = (Vector2)Position.GetPosition(node.owner.ToString() + "_");

            position = new Vector2((int)((position.X + MainForm.offset_x) / MainForm.zoom), (int)((position.Y + MainForm.offset_y) / MainForm.zoom));


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
            int height = zoom(((int)Math.Round(Math.Max(nodes_in.Count,nodes_out.Count)+0.5))*100);
            int width = zoom(Math.Min(300, height));
            activecanvas.DrawRect(position.X, position.Y, width, height, paintbucket.BlackTextOutline);
            activecanvas.DrawRect(position.X + zoom(5), position.Y + zoom(5), width - zoom(10), height - zoom(10), paintbucket.WhiteInternal);
            activecanvas.DrawText($"ID: {node.owner}", position.X + zoom(10), position.Y + zoom(30), SKTextAlign.Left, font, paintbucket.BlackTextOutline);
            activecanvas.DrawText("Type: Logicgate", position.X + zoom(10), position.Y + zoom(60), SKTextAlign.Left, font, paintbucket.BlackTextOutline);
            partPositions[node.owner.ToString()+"_"] = new PartPosition(position, new Vector2(width,height),node.owner.ToString()+"_");
            nodes_in.Sort((x, y) => x.id.CompareTo(y.id));
            nodes_out.Sort((x, y) => x.id.CompareTo(y.id));
            int counter = 0;
            foreach (ScematicNode in_node in nodes_in)
            {
                counter++;
                DrawNode(new Vector2(position.X,position.Y + height / (nodes_in.Count+1) * counter) ,in_node);
            }
            counter = 0;
            foreach (ScematicNode out_node in nodes_out)
            {
                counter++;
                DrawNode(new Vector2(position.X + width, position.Y + height / (nodes_out.Count+1) * counter), out_node);
            }
        }
        internal static void DebugView()
        {
            foreach (PartPosition pos in partPositions.Values)
            {
                activecanvas.DrawRect(pos.position.X, pos.position.Y, pos.size.X, pos.size.Y,paintbucket.DebugColor);
            }
        }
    }
}
