using Microcontrollers.GUIDrawing;
using OpenTK.Input;
using SkiaSharp;

namespace Microcontrollers.ControllerSystem
{
    public class ControllerGraphics
    {
        private SKCanvas active_buffer;
        private SKBitmap active_bitmap;
        private SKPaint color;
        private readonly SKPaint _black;
        internal int width;
        internal int height;
        internal Pixeltext pixel_text = new Pixeltext();
        internal ControllerGraphics(SKBitmap Controller_Graphics_buffer) 
        {
            active_bitmap = Controller_Graphics_buffer;
            active_buffer = new SKCanvas(Controller_Graphics_buffer);
            width = Controller_Graphics_buffer.Width;
            height = Controller_Graphics_buffer.Height;
            color = new SKPaint();
            color.IsAntialias = false;
            color.Color = new SKColor(255, 255, 255);
            _black = new SKPaint();
            _black.Color = new SKColor(0, 0, 0);
        }
        internal void ChangeCanvas(SKBitmap Controller_Graphics_buffer)
        {
            active_bitmap = Controller_Graphics_buffer;
            active_buffer = new SKCanvas(Controller_Graphics_buffer);
        }
        internal void FillBitmap(SKBitmap bitmap)
        {
            active_buffer.DrawBitmap(bitmap, 0, 0);
        }
        public void setColor(byte r, byte g, byte b, byte a = 255)
        {
            lock (active_buffer)
            {
                color.Color = new SKColor(r, g, b, a);
            }
        }
        public void drawText(int x, int y, string text)
        {

            lock (active_buffer)
            {
                pixel_text.DrawText(active_buffer, color, x, y, text);
            }
        }
        public void drawTextBox(int x, int y, int height, int width, string text, short h_align = -1, short v_align = -1)
        {
            lock (active_buffer)
            {
                float length = width / 5.0f;

                if (length <= 0)
                {
                    length = 2;
                }

                int counter = 1;

                float text_len = text.Count();

                if (text_len > length)
                {
                    text_len = length;
                }

                int diff_LR = (int)Math.Round((width - text_len * 5) * (h_align + 1) / 2);

                int diff_UD = (height - (text.Count() / (int)length + 1) * 7) * (v_align + 1) / 2 - 7;

                while (text.Length != 0)
                {
                    string part = "";
                    if (text.Count() < length - 1)
                    {
                        part = text;
                        text = "";
                    }
                    else
                    {
                        part = text.Substring(0, (int)length - 1);
                        text = text.Remove(0, (int)length - 1);
                    }

                    drawText(x + diff_LR, y + diff_UD + counter * 7, part.ToUpper());
                    counter++;
                }
            }
        }
        public void drawClear()
        {
            lock (active_buffer)
            {
                active_buffer.DrawRect(0, 0, this.width, this.height, _black);
            }
        }
        public void drawCircle(int x, int y, int radius)
        {
            lock (active_buffer)
            {
                for (double r = 0; r < 2 * Math.PI; r = r + Math.PI / 100)
                {
                    int x1 = (int)(Math.Cos(r) * radius + x);
                    int y1 = (int)(Math.Sin(r) * radius + y);
                    int x2 = (int)(Math.Cos(r - Math.PI / 100) * radius + x);
                    int y2 = (int)(Math.Sin(r - Math.PI / 100) * radius + y);

                    active_buffer.DrawLine(x1, y1, x2, y2, color);
                }
            }
        }
        public void drawCircleF(int x, int y, int radius)
        {
            lock (active_buffer)
            {
                active_buffer.DrawCircle(x, y, radius, color);
            }
        }
        public void drawLine(int x1, int y1, int x2, int y2)
        {
            lock (active_buffer)
            {
                active_buffer.DrawLine(x1, y1, x2, y2, color);
            }
        }
        public void drawRect(int x, int y, int width, int height)
        {
            lock (active_buffer)
            {
                active_buffer.DrawLine(x, y, x, y + height, color);
                active_buffer.DrawLine(x, y, x + width, y, color);
                active_buffer.DrawLine(x + width, y, x + width, y + height, color);
                active_buffer.DrawLine(x, y + height, x + width, y + height, color);
            }
        }

        public void drawRectF(int x, int y, int width, int height)
        {
            lock (active_buffer)
            {
                active_buffer.DrawRect(x, y, width, height, color);
            }
        }

        public void drawTriangleF(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            lock (active_buffer)
            {
                var path = new SKPath { FillType = SKPathFillType.EvenOdd };
                path.MoveTo(x1, y1);
                path.LineTo(x2, y2);
                path.LineTo(x3, y3);
                path.LineTo(x1, y1);
                path.Close();
                active_buffer.DrawPath(path, color);
            }
        }
        public void drawTriangle(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            lock (active_buffer)
            {
                active_buffer.DrawLine(x1, y1, x2, y2, color);
                active_buffer.DrawLine(x1, y1, x2, y2, color);
                active_buffer.DrawLine(x1, y1, x2, y2, color);
            }
        }

        public int getWidth()
        {
            return width;
        }
        public int getHeight()
        {
            return height; 
        }

        internal async Task<SKBitmap> getChanged()
        {
            try
            {
                lock (active_buffer)
                {
                    return active_bitmap;
                }
            }
            catch(Exception ex) { }
            return new SKBitmap();
        }
    }
}
