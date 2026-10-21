using SkiaSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Microcontrollers.GUIDrawing
{
    internal class FontLetter
    {
        private int letter = 0;
        internal FontLetter(bool[] template)
        {
            for(int x = 0; x < 20; x++)
            {
                if (x != 0)
                {
                    letter = letter << 1;
                }
                if (template[x])
                {
                    letter += 1;
                }
            }
        }
        internal void drawLetter(SKCanvas canvas, int x, int y,SKPaint color)
        {
            for (int i = 0; i < 20; i++)
            {
                bool bit = (letter & (1 << i)) != 0;
                
                if (bit)
                {
                
                    canvas.DrawPoint(new SKPoint(x+4-i%4,y+5-i/4),color);
                
                }
            }
        }
    }
}
