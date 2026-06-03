using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Numerics;
using System.Text;

namespace ScematicEditor
{
    internal class Camera
    {
        private static Vector2 startPos = new Vector2(0,0);
        internal static void MoveCamera(List<MouseButtons> mouse, Vector2 mouse_pos)
        {
            if(mouse.Contains(MouseButtons.Right) && startPos == new Vector2(0,0))
            {
                startPos = mouse_pos;
            }
            if(mouse.Contains(MouseButtons.Right))
            {
                MainForm.offset_x += (int)((mouse_pos.X - startPos.X)*MainForm.zoom);  
                MainForm.offset_y += (int)((mouse_pos.Y - startPos.Y)*MainForm.zoom);
                startPos = mouse_pos;
            }
            else
            {
                startPos = new Vector2(0,0);
            }
        }
    }
}
