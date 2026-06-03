using ScematicEditor.Diagram;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Xml.Linq;

namespace ScematicEditor
{
    internal class ScreenInterraction
    {
        private static int offsetX = 0;
        private static int offsetY = 0;
        private static PartPosition active = null;
        internal static void MoveParts(List<MouseButtons> buttons, Vector2 mouse_pos,Scematiccontainer container) 
        {
            Vector2 mouse_pos2 = new Vector2((int)((mouse_pos.X) * MainForm.zoom), (int)((mouse_pos.Y) * MainForm.zoom));
            DrawConnections();
            foreach (KeyValuePair<string,PartPosition> part in Drawing.partPositions)
            {
                if (active == null)
                {
                    if (mouse_pos.X > part.Value.position.X && mouse_pos.Y > part.Value.position.Y
                    && mouse_pos.X < part.Value.position.X + part.Value.size.X
                    && mouse_pos.Y < part.Value.position.Y + part.Value.size.Y
                    && buttons.Contains(MouseButtons.Left))
                    {
                        offsetX = (int)(mouse_pos.X - part.Value.position.X);
                        offsetY = (int)(mouse_pos.Y - part.Value.position.Y);
                        active = part.Value;
                    }
                }
            }
            if (active != null)
            {
                if (!buttons.Contains(MouseButtons.Left))
                {
                    ConnectionJoin(active.id, mouse_pos);
                    active = null;
                }
                else
                {
                    if (int.TryParse(active.id, out int attempt))
                    {
                        Connector(active.id, mouse_pos);
                    }
                    else
                    {
                        Position.WritePosition(active.id,           new Vector2(mouse_pos2.X - (int)(offsetX * MainForm.zoom) - (int)(MainForm.offset_x)  , mouse_pos2.Y - (int)(offsetY * MainForm.zoom) - (int)(MainForm.offset_y)));
                        Drawing.partPositions[active.id].position = new Vector2(mouse_pos2.X - (int)(offsetX * MainForm.zoom) - (int)(MainForm.offset_x), mouse_pos2.Y - (int)(offsetY * MainForm.zoom) - (int)(MainForm.offset_y));
                    }
                }
            }
        }
        internal static void ConnectionJoin(string id, Vector2 mouse)
        {
            ScematicNode own = null;
            foreach (ScematicNode node in Drawing.nodes)
            {
                try
                {
                    if (node.id == int.Parse(id))
                    {
                        own = node;
                    }
                }
                catch (Exception ex)
                {
                    return;
                }
            }
            foreach (PartPosition pos in Drawing.partPositions.Values)
            {
                if(mouse.X > pos.position.X && mouse.Y > pos.position.Y && mouse.X < pos.position.X+pos.size.X && mouse.Y < pos.position.Y+pos.size.Y)
                {
                    foreach(ScematicNode node in Drawing.nodes)
                    {
                        try
                        {
                            if (node.id.ToString() == pos.id && pos.id != own.id.ToString() && own.isOutput != node.isOutput && own.nodeType == node.nodeType)
                            {
                                if (node.target_id == own.id || own.id == node.target_id)
                                {
                                    node.target_id = null;
                                    own.target_id = null;
                                }
                                else
                                {
                                    node.target_id = int.Parse(id);
                                    own.target_id = node.id;
                                }
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            return;
                        }
                    }
                }
            }
            
        }

        internal static void Connector(string id, Vector2 mouse)
        {
            ScematicNode node = null;
            foreach(ScematicNode search_node in Drawing.nodes)
            {
                if(search_node.id == int.Parse(id))
                {
                    node = search_node;
                }
            }
            SKPaint paint = null;
            switch (node.nodeType)
            {
                case NodeType.OnOff:
                    paint = Drawing.paintbucket.RedBoolean;
                    break;
                case NodeType.Number:
                    paint = Drawing.paintbucket.GreenNumber;
                    break;
                case NodeType.Composite:
                    paint = Drawing.paintbucket.PurpleComposite;
                    break;
                case NodeType.Video:
                    paint = Drawing.paintbucket.BlueVideo;
                    break;
            }
            Vector2 position = new Vector2();
            foreach (KeyValuePair<string, PartPosition> part in Drawing.partPositions)
            {
                if(part.Key == id)
                {
                    position = new Vector2(part.Value.position.X+(int)(15 / MainForm.zoom), part.Value.position.Y + (int)(15 / MainForm.zoom));
                }
            }
            Drawing.activecanvas.DrawLine(position,mouse,paint);
        }

        internal static void DrawConnections()
        {
            foreach (ScematicNode search_node in Drawing.nodes)
            {
                foreach (ScematicNode target_node in Drawing.nodes)
                {
                    if(search_node.target_id == target_node.id)
                    {
                        SKPaint paint = null;
                        switch (search_node.nodeType)
                        {
                            case NodeType.OnOff:
                                paint = Drawing.paintbucket.RedBoolean;
                                break;
                            case NodeType.Number:
                                paint = Drawing.paintbucket.GreenNumber;
                                break;
                            case NodeType.Composite:
                                paint = Drawing.paintbucket.PurpleComposite;
                                break;
                            case NodeType.Video:
                                paint = Drawing.paintbucket.BlueVideo;
                                break;
                        }
                        Vector2 search_pos = Drawing.partPositions[search_node.id.ToString()].position;
                        Vector2 target_pos = Drawing.partPositions[target_node.id.ToString()].position;
                        search_pos = new Vector2(search_pos.X+(int)(15 / MainForm.zoom), search_pos.Y+(int)(15 / MainForm.zoom));
                        target_pos = new Vector2(target_pos.X+(int)(15 / MainForm.zoom), target_pos.Y+(int)(15 / MainForm.zoom));
                        Drawing.activecanvas.DrawLine(search_pos, target_pos,paint);
                    }
                }
            }
        }
    }
}
