using Microcontrollers;
using Microcontrollers.GFX;
using OpenTK.Graphics.OpenGL;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System;
using System.Collections.Generic;
using System.Text;
using static OpenTK.Graphics.OpenGL.GL;

namespace Microcontrollers.ControllerSystem
{
    public class ControllerGraphics
    {
        private SKCanvas active_buffer;
        private SKBitmap active_bitmap;
        private SKPaint color;
        private readonly SKPaint _black;
        private int width;
        private int height;
        internal ControllerGraphics(SKBitmap Controller_Graphics_buffer) 
        {
            active_bitmap = Controller_Graphics_buffer;
            active_buffer = new SKCanvas(Controller_Graphics_buffer);
            width = Controller_Graphics_buffer.Width;
            height = Controller_Graphics_buffer.Height;
            color = new SKPaint();
            color.Color = new SKColor(255, 255, 255);
            _black = new SKPaint();
            _black.Color = new SKColor(0, 0, 0);
        }
        public void setColor(byte r, byte g, byte b, byte a = 255)
        {
            color.Color = new SKColor(r, g, b, a);
        }
        public void drawClear()
        {
            active_buffer.DrawRect(0,0,this.width,this.height, _black);
        }
        public void drawCircle(int x, int y, int radius)
        {
            for (double r = 0; r < 2*Math.PI; r = r + Math.PI / 100)
            {
                int x1 = (int)(Math.Cos(r) * radius + x);
                int y1 = (int)(Math.Sin(r) * radius + y);
                int x2 = (int)(Math.Cos(r - Math.PI / 100) * radius + x);
                int y2 = (int)(Math.Sin(r - Math.PI / 100) * radius + y);

                active_buffer.DrawLine(x1, y1, x2, y2, color);
            }
        }
        public void drawCircleF(int x, int y, int radius)
        {
            active_buffer.DrawCircle(x,y,radius,color);
        }

        public void drawLine(int x1, int y1, int x2, int y2)
        {
            active_buffer.DrawLine(x1, y1, x2, y2, color);
        }

        public void drawRect(int x, int y, int width, int height)
        {
            active_buffer.DrawLine(x, y, x, y+height, color);
            active_buffer.DrawLine(x, y, x+width, y, color);
            active_buffer.DrawLine(x+width, y, x+width, y+height, color);
            active_buffer.DrawLine(x, y+height, x+width, y+height, color);
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
        public void drawTriangle(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            active_buffer.DrawLine(x1,y1,x2,y2,color);
            active_buffer.DrawLine(x1, y1, x2, y2, color);
            active_buffer.DrawLine(x1, y1, x2, y2, color);
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
            try
            {
                return active_bitmap;
            }
            catch(Exception ex) { }
            return new SKBitmap();
        }
    }
}
