using Microcontrollers.ControllerSystem;
using Microcontrollers.GFX;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.ControllerGUI
{
    internal class ControllerGUI
    {
        internal Bitmap screen_buffer;
        internal ControllerGUI(int window_width, int window_height)
        {
            ControllerGUIHost.Show(window_width,window_height);
        }
        internal void DrawMonitor()
        {
            ControllerGUIHost.OnDraw = canvas =>
            {
                SKPaint paint = new SKPaint();
                paint.Color = SkiaSharp.SKColor.FromHsl(130, 100, 40);
                canvas.DrawLine(5, 5, 100, 100, paint);
            };
        }
    }
}
