using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.GUIDrawing
{
    internal class Pixeltext
    {
        internal static Dictionary<char, FontLetter> font = null;

        internal Pixeltext()
        {
            // Create Font
            if(font == null)
            {
                font = new Dictionary<char, FontLetter>();

                // Alphabet
                bool[] letter = [
                    false,true,true,false,
                    true,false,false,true,
                    true,true,true,true,
                    true,false,false,true,
                    true,false,false,true
                    ];
                font.Add('A', new FontLetter(letter));

                letter = [
                    true,true,true,false,
                    true,false,false,true,
                    true,true,true,false,
                    true,false,false,true,
                    true,true,true,false
                    ];
                font.Add('B', new FontLetter(letter));

                letter = [
                    false,true,true,false,
                    true,false,false,true,
                    true,false,false,false,
                    true,false,false,true,
                    false,true,true,false
                    ];
                font.Add('C', new FontLetter(letter));

                letter = [
                    true,true,true,false,
                    true,false,false,true,
                    true,false,false,true,
                    true,false,false,true,
                    true,true,true,false
                    ];
                font.Add('D', new FontLetter(letter));

                letter = [
                    true,true,true,true,
                    true,false,false,false,
                    true,true,true,false,
                    true,false,false,false,
                    true,true,true,true
                    ];
                font.Add('E', new FontLetter(letter));

                letter = [
                    true,true,true,true,
                    true,false,false,false,
                    true,true,true,false,
                    true,false,false,false,
                    true,false,false,false
                    ];
                font.Add('F', new FontLetter(letter));

                letter = [
                    false,true,true,false,
                    true,false,false,false,
                    true,false,true,true,
                    true,false,false,true,
                    false,true,true,false
                    ];
                font.Add('G', new FontLetter(letter));

                letter = [
                    true,false,false,true,
                    true,false,false,true,
                    true,true,true,true,
                    true,false,false,true,
                    true,false,false,true
                    ];
                font.Add('H', new FontLetter(letter));

                letter = [
                    false,true,false,false,
                    false,true,false,false,
                    false,true,false,false,
                    false,true,false,false,
                    false,true,false,false
                    ];
                font.Add('I', new FontLetter(letter));

                letter = [
                    false,false,false,true,
                    false,false,false,true,
                    false,false,false,true,
                    true,false,false,true,
                    false,true,true,false
                    ];
                font.Add('J', new FontLetter(letter));

                letter = [
                    true,false,false,true,
                    true,false,true,false,
                    true,true,false,false,
                    true,false,true,false,
                    true,false,false,true
                    ];
                font.Add('K', new FontLetter(letter));

                letter = [
                    true,false,false,false,
                    true,false,false,false,
                    true,false,false,false,
                    true,false,false,false,
                    true,true,true,true
                    ];
                font.Add('L', new FontLetter(letter));

                letter = [
                    true,false,false,true,
                    true,true,true,true,
                    true,false,false,true,
                    true,false,false,true,
                    true,false,false,true
                    ];
                font.Add('M', new FontLetter(letter));

                letter = [
                    true,false,false,true,
                    true,true,false,true,
                    true,false,true,true,
                    true,false,false,true,
                    true,false,false,true
                    ];
                font.Add('N', new FontLetter(letter));

                letter = [
                    false,true,true,false,
                    true,false,false,true,
                    true,false,false,true,
                    true,false,false,true,
                    false,true,true,false
                    ];
                font.Add('O', new FontLetter(letter));

                letter = [
                    true,true,true,false,
                    true,false,false,true,
                    true,true,true,false,
                    true,false,false,false,
                    true,false,false,false
                    ];
                font.Add('P', new FontLetter(letter));

                letter = [
                    false,true,true,false,
                    true,false,false,true,
                    true,false,false,true,
                    true,false,true,true,
                    false,true,true,true
                    ];
                font.Add('Q', new FontLetter(letter));

                letter = [
                    true,true,true,false,
                    true,false,false,true,
                    true,true,true,false,
                    true,false,true,false,
                    true,false,false,true
                    ];
                font.Add('R', new FontLetter(letter));

                letter = [
                    false,true,true,true,
                    true,false,false,false,
                    false,true,true,false,
                    false,false,false,true,
                    true,true,true,false
                    ];
                font.Add('S', new FontLetter(letter));

                letter = [
                    true,true,true,false,
                    false,true,false,false,
                    false,true,false,false,
                    false,true,false,false,
                    false,true,false,false
                    ];
                font.Add('T', new FontLetter(letter));

                letter = [
                    true,false,false,true,
                    true,false,false,true,
                    true,false,false,true,
                    true,false,false,true,
                    false,true,true,false
                    ];
                font.Add('U', new FontLetter(letter));

                letter = [
                    true,false,true,false,
                    true,false,true,false,
                    true,false,true,false,
                    true,false,true,false,
                    false,true,false,false
                    ];
                font.Add('V', new FontLetter(letter));

                letter = [
                    true,false,false,true,
                    true,false,false,true,
                    true,false,false,true,
                    true,true,true,true,
                    true,false,false,true
                    ];
                font.Add('W', new FontLetter(letter));

                letter = [
                    true,false,false,true,
                    true,false,false,true,
                    false,true,true,false,
                    true,false,false,true,
                    true,false,false,true
                    ];
                font.Add('X', new FontLetter(letter));

                letter = [
                    true,false,true,false,
                    true,false,true,false,
                    false,true,false,false,
                    false,true,false,false,
                    false,true,false,false
                    ];
                font.Add('Y', new FontLetter(letter));

                letter = [
                    true,true,true,true,
                    false,false,false,true,
                    false,true,true,false,
                    true,false,false,false,
                    true,true,true,true
                    ];
                font.Add('Z', new FontLetter(letter));

                letter = [
                    false,false,false,false,
                    false,false,false,false,
                    false,false,false,false,
                    false,false,false,false,
                    false,false,false,false
                    ];
                font.Add(' ', new FontLetter(letter));

                // Numbers
                letter = [
                    false,true,true,false,
                    true,false,true,true,
                    true,true,false,true,
                    true,false,false,true,
                    false,true,true,false
                    ];
                font.Add('0', new FontLetter(letter));

                letter = [
                    false,false,true,false,
                    false,true,true,false,
                    false,false,true,false,
                    false,false,true,false,
                    false,false,true,false
                    ];
                font.Add('1', new FontLetter(letter));

                letter = [
                    false,true,true,false,
                    true,false,false,true,
                    false,false,true,false,
                    false,true,false,false,
                    true,true,true,true
                    ];
                font.Add('2', new FontLetter(letter));

                letter = [
                    true,true,true,false,
                    false,false,false,true,
                    false,true,true,false,
                    false,false,false,true,
                    true,true,true,false
                    ];
                font.Add('3', new FontLetter(letter));

                letter = [
                    true,false,false,true,
                    true,false,false,true,
                    true,true,true,true,
                    false,false,false,true,
                    false,false,false,true
                    ];
                font.Add('4', new FontLetter(letter));

                letter = [
                    true,true,true,true,
                    true,false,false,false,
                    true,true,true,false,
                    false,false,false,true,
                    true,true,true,false
                    ];
                font.Add('5', new FontLetter(letter));

                letter = [
                    false,true,true,false,
                    true,false,false,false,
                    true,true,true,false,
                    true,false,false,true,
                    false,true,true,false
                    ];
                font.Add('6', new FontLetter(letter));

                letter = [
                    true,true,true,true,
                    false,false,false,true,
                    false,false,true,false,
                    false,false,true,false,
                    false,false,true,false
                    ];
                font.Add('7', new FontLetter(letter));

                letter = [
                    false,true,true,false,
                    true,false,false,true,
                    false,true,true,false,
                    true,false,false,true,
                    false,true,true,false
                    ];
                font.Add('8', new FontLetter(letter));

                letter = [
                    false,true,true,false,
                    true,false,false,true,
                    false,true,true,true,
                    false,false,false,true,
                    false,true,true,false
                    ];
                font.Add('9', new FontLetter(letter));

                // Special
                letter = [
                    false,true,false,false,
                    false,false,true,false,
                    false,false,false,false,
                    false,false,false,false,
                    false,false,false,false
                    ];
                font.Add('`', new FontLetter(letter));

                letter = [
                    false,true,false,false,
                    true,false,true,false,
                    false,false,false,false,
                    false,false,false,false,
                    false,false,false,false
                    ];
                font.Add('^', new FontLetter(letter));

                letter = [
                    false,true,true,false,
                    true,false,false,true,
                    true,false,true,true,
                    true,false,false,false,
                    false,true,true,true
                    ];
                font.Add('@', new FontLetter(letter));

                letter = [
                    false,false,false,false,
                    false,false,false,false,
                    false,false,false,false,
                    false,false,false,false,
                    false,true,false,false
                    ];
                font.Add('.', new FontLetter(letter));

                letter = [
                    false,false,false,false,
                    false,false,false,false,
                    false,false,false,false,
                    false,false,true,false,
                    false,true,false,false
                    ];
                font.Add(',', new FontLetter(letter));

                letter = [
                    true,true,false,false,
                    false,false,true,false,
                    false,true,false,false,
                    false,false,false,false,
                    false,true,false,false
                    ];
                font.Add('?', new FontLetter(letter));

                letter = [
                    false,true,false,false,
                    false,true,false,false,
                    false,false,false,false,
                    false,true,false,false,
                    false,true,false,false
                    ];
                font.Add('|', new FontLetter(letter));

                letter = [
                    true,false,false,false,
                    false,true,false,false,
                    false,false,true,false,
                    false,true,false,false,
                    true,false,false,false
                    ];
                font.Add('>', new FontLetter(letter));

                letter = [
                    false,false,true,false,
                    false,true,false,false,
                    true,false,false,false,
                    false,true,false,false,
                    false,false,true,false
                    ];
                font.Add('<', new FontLetter(letter));

                letter = [
                    false,false,false,false,
                    false,true,false,true,
                    true,false,true,false,
                    false,false,false,false,
                    false,false,false,false
                    ];
                font.Add('~', new FontLetter(letter));

                letter = [
                    false,true,false,false,
                    true,false,true,false,
                    false,true,false,false,
                    true,false,true,false,
                    false,true,false,true
                    ];
                font.Add('&', new FontLetter(letter));

                letter = [
                    true,true,false,false,
                    false,false,false,true,
                    false,true,true,false,
                    true,false,false,false,
                    false,false,true,true
                    ];
                font.Add('%', new FontLetter(letter));

                letter = [
                    false,true,true,true,
                    true,false,true,false,
                    false,true,true,false,
                    false,true,false,true,
                    true,true,true,false
                    ];
                font.Add('$', new FontLetter(letter));

                letter = [
                    false,true,false,false,
                    false,true,false,false,
                    false,true,false,false,
                    false,false,false,false,
                    false,true,false,false
                    ];
                font.Add('!', new FontLetter(letter));

                letter = [
                    false,true,true,false,
                    false,true,false,false,
                    true,true,false,false,
                    false,true,false,false,
                    false,true,true,false
                    ];
                font.Add('{', new FontLetter(letter));

                letter = [
                    false,true,true,false,
                    false,false,true,false,
                    false,false,true,true,
                    false,false,true,false,
                    false,true,true,false
                    ];
                font.Add('}', new FontLetter(letter));

                letter = [
                    false,true,true,false,
                    false,true,false,false,
                    false,true,false,false,
                    false,true,false,false,
                    false,true,true,false
                    ];
                font.Add('[', new FontLetter(letter));

                letter = [
                    false,true,true,false,
                    false,false,true,false,
                    false,false,true,false,
                    false,false,true,false,
                    false,true,true,false
                    ];
                font.Add(']', new FontLetter(letter));

                letter = [
                    false,false,true,false,
                    false,true,false,false,
                    false,true,false,false,
                    false,true,false,false,
                    false,false,true,false
                    ];
                font.Add('(', new FontLetter(letter));

                letter = [
                    false,true,false,false,
                    false,false,true,false,
                    false,false,true,false,
                    false,false,true,false,
                    false,true,false,false
                    ];
                font.Add(')', new FontLetter(letter));

                letter = [
                    false,true,false,false,
                    false,true,false,false,
                    false,false,false,false,
                    false,false,false,false,
                    false,false,false,false
                    ];
                font.Add('\'', new FontLetter(letter));

                letter = [
                    true,false,true,false,
                    true,false,true,false,
                    false,false,false,false,
                    false,false,false,false,
                    false,false,false,false
                    ];
                font.Add('\"', new FontLetter(letter));

                letter = [
                    true,false,false,true,
                    false,true,true,false,
                    true,true,true,true,
                    false,true,true,false,
                    true,false,false,true
                    ];
                font.Add('*', new FontLetter(letter));

                letter = [
                    true,false,true,false,
                    true,true,true,true,
                    true,false,true,false,
                    true,true,true,true,
                    true,false,true,false
                    ];
                font.Add('#', new FontLetter(letter));

                letter = [
                    false,false,true,false,
                    false,false,true,false,
                    false,true,false,false,
                    true,false,false,false,
                    true,false,false,false
                    ];
                font.Add('/', new FontLetter(letter));

                letter = [
                    true,false,false,false,
                    true,false,false,false,
                    false,true,false,false,
                    false,false,true,false,
                    true,false,true,false
                    ];
                font.Add('\\', new FontLetter(letter));

                letter = [
                    false,false,false,false,
                    false,true,false,false,
                    true,true,true,false,
                    false,true,false,false,
                    false,false,false,false
                    ];
                font.Add('+', new FontLetter(letter));

                letter = [
                    false,false,false,false,
                    false,false,false,false,
                    true,true,true,false,
                    false,false,false,false,
                    false,false,false,false
                    ];
                font.Add('-', new FontLetter(letter));

                letter = [
                    false,false,false,false,
                    false,false,false,false,
                    false,false,false,false,
                    false,false,false,false,
                    true,true,true,true
                    ];
                font.Add('_', new FontLetter(letter));

                letter = [
                    false,false,false,false,
                    true,true,true,false,
                    false,false,false,false,
                    true,true,true,false,
                    false,false,false,false
                    ];
                font.Add('=', new FontLetter(letter));

                letter = [
                    false,false,false,false,
                    false,true,false,false,
                    false,false,false,false,
                    false,true,false,false,
                    false,false,false,false
                    ];
                font.Add(':', new FontLetter(letter));
            }
        }
        internal void DrawText(SKCanvas canvas, SKPaint paint, int x, int y, string text)
        {
            char[] chars = text.ToUpper().ToCharArray();
            int counter = 0;
            foreach(char letter in chars)
            {
                font[letter].drawLetter(canvas,x+counter*5,y,paint);
                counter++;
            }
        }
    }
}
