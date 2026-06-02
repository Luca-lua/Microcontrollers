using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScematicEditor
{
    internal class Paintbucket
    {
        internal SKPaint BlackTextOutline;
        internal SKPaint WhiteInternal;
        internal SKPaint RedBoolean;
        internal SKPaint GreenNumber;
        internal SKPaint PurpleComposite;
        internal SKPaint BlueVideo;
        internal SKPaint Bluebackground;

        internal Paintbucket()
        {
            BlackTextOutline = new SKPaint() {Color = new SKColor(0,0,0) };
            WhiteInternal = new SKPaint() { Color = new SKColor(255, 255, 255) };
            RedBoolean = new SKPaint() { Color = new SKColor(255, 0, 0) };
            GreenNumber = new SKPaint() { Color = new SKColor(0, 205, 0) };
            PurpleComposite = new SKPaint() { Color = new SKColor(130, 0, 205) };
            Bluebackground = new SKPaint() { Color = new SKColor(130, 200, 255) };
            BlueVideo = new SKPaint() { Color = new SKColor(25, 25, 255) };
            BlackTextOutline.TextSize = 24;
            BlackTextOutline.FakeBoldText = true;
        }
    }
}
