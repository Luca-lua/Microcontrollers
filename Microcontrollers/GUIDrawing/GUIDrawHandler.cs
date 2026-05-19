using Microcontrollers.ControllerSystem;
using Microcontrollers.GFX;
using SkiaSharp;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using SkiaSharp.Views.Desktop;
using System.Numerics;

namespace Microcontrollers.ControllerGUI
{
    internal class GUIDrawHandler
    {
        internal SKBitmap Controller_Graphics_buffer;
        internal static int _window_width;
        internal static int _window_height;
        List<Vector2> presses = new List<Vector2>();
        internal GUIDrawHandler(int window_width, int window_height)
        {
            ControllerGUIHost.Show(window_width,window_height);
            _window_height = window_height;
            _window_width = window_width;
        }
        private void GetClick() 
        {
            ControllerGUIHost.TryGetClick(out Vector2? click);
            if (click != null && click != new Vector2(0, 0))
            {
                presses.Add((Vector2)click);
            }
        }
        internal void DrawMonitor(Microcontrollers.Parts.Monitor monitor,out Vector2? click)
        {
            ControllerGUIHost.OnDraw = canvas =>
            {
                Bitmap bitmap = monitor.ReturnVideo().ToBitmap();
                bitmap = new Bitmap(bitmap,new Size(monitor.real_size.Width,monitor.real_size.Height));
                canvas.DrawBitmap(bitmap.ToSKBitmap(), new SKPoint(monitor.topleft.Width,monitor.topleft.Height), new SKPaint());
            };
            GetClick();
            ControllerGUIHost.Redraw();
            click = null;
            foreach (var p in presses)
            {
                if(p.X >= monitor.topleft.Width && p.Y >= monitor.topleft.Height
                    && p.X <= monitor.topleft.Width+monitor.real_size.Width && p.Y <= monitor.topleft.Height+monitor.real_size.Height)
                {
                    click = p;
                    presses.Remove(p);
                    break;
                }
            }
        }
    }
}
