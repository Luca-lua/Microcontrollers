using Microcontrollers.ControllerSystem;
using Microcontrollers.GFX;
using SkiaSharp;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using SkiaSharp.Views.Desktop;

namespace Microcontrollers.ControllerGUI
{
    internal class GUIDrawHandler
    {
        internal SKBitmap Controller_Graphics_buffer;
        internal GUIDrawHandler(int window_width, int window_height)
        {
            ControllerGUIHost.Show(window_width,window_height);
        }
        internal void DrawMonitor(Microcontrollers.Parts.Monitor monitor)
        {
            ControllerGUIHost.OnDraw = canvas =>
            {
                Bitmap bitmap = monitor.ReturnVideo().ToBitmap();
                bitmap = new Bitmap(bitmap,new Size(monitor.real_size.Width,monitor.real_size.Height));
                canvas.DrawBitmap(bitmap.ToSKBitmap(), new SKPoint(monitor.topleft.Width,monitor.topleft.Height), new SKPaint());
            };
        }
    }
}
