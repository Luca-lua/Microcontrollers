using Microcontrollers.ConnectionSystem;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.Parts
{
    [Serializable]
    public class MonitorSizeException : Exception
    {
        public MonitorSizeException(string message) : base(message) { }
    }
    [Serializable]
    public class MonitorLocationException : Exception
    {
        public MonitorLocationException(string message) : base(message) { }
    }
    internal class Monitor
    {
        //Diagram infos
        internal string name;

        internal Size topleft;
        internal Size real_size;
        internal Size output_size;
        internal VideoNode videoIn;

        internal Monitor(string diagram_name,Size resolution_px, Size real_size_px, Size ?top_left_corner_px = null) 
        {
            name = name;
            if (resolution_px.Width < 10 || resolution_px.Height < 10)
            {
                throw new MonitorSizeException("Monitor cannot be smaller than 10 on x or y");
            }
            if (real_size_px.Width < resolution_px.Width || real_size_px.Height < resolution_px.Height)
            {
                throw new MonitorSizeException("Monitor real size cannot be smaller than virtual size");
            }
            if (!topleft.IsEmpty)
            {
                if (top_left_corner_px.Value.Width < 0 || top_left_corner_px.Value.Height < 0)
                {
                    throw new MonitorLocationException("Monitor coordinates cannot be less than 0");
                }
            }
            topleft = top_left_corner_px.HasValue ? top_left_corner_px.Value : new Size(0,0);
            real_size = real_size_px;
            output_size = resolution_px;
            videoIn = new VideoNode(false);
        }
        
        internal SKBitmap ReturnVideo()
        {
            SKBitmap video;
            if (videoIn.connected_node != null || !videoIn.value.IsEmpty)
            {
                 video = videoIn.value;
            }
            else
            {
                video = new SKBitmap(this.output_size.Width,this.output_size.Height);
                SKColor color = new SKColor(0,0,0);
                video.Erase(color);
            }
            return video;
        }
    }
}
