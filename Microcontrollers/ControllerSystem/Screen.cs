using Microcontrollers;
using Microcontrollers.GFX;
using OpenTK.Graphics.OpenGL;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.ControllerSystem
{
    public class Screen
    {
        private SKCanvas active_buffer;
        private SKPaint color;
        private int width;
        private int height;
        internal Screen(SKBitmap screen_buffer) 
        {
            active_buffer = new SKCanvas(screen_buffer);
            width = screen_buffer.Width;
            height = screen_buffer.Height;
            color = new SKPaint();
            color.Color = new SKColor(255, 255, 255);
        }

        public void setColor(byte r, byte g, byte b, byte a = 255)
        {
            color.Color = new SKColor(r, g, b, a);
        }
        
        public void drawCircleF(int x, int y, int radius)
        {
            active_buffer.DrawCircle(x,y,radius,color);
        }

        public void drawLine(int x1, int y1, int x2, int y2)
        {
            active_buffer.DrawLine(x1, y1, x2, y2, color);
        }

        public void drawRectF(int x, int y, int width, int height)
        {
            active_buffer.DrawRect(x,y, width, height, color);
        }

        public void drawTriangleF(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            var path = new SKPath { FillType = SKPathFillType.EvenOdd };
            path.MoveTo(x1, y1);
            path.LineTo(x2, y2);
            path.LineTo(x3, y3);
            path.LineTo(x1, y1);
            path.Close();
            active_buffer.DrawPath(path, color);
        }

        public int getWidth()
        {
            return width;
        }
        public int getHeight()
        {
            return height; 
        }

        internal SKBitmap getChanged()
        {
            return active_buffer.Surface.Snapshot().ToBitmap().ToSKBitmap();
        }
    }
}
