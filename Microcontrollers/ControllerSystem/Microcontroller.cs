using System;
using System.Collections.Generic;
using System.Text;
using Microcontrollers.ConnectionSystem;
using SkiaSharp;

namespace Microcontrollers.ControllerSystem
{
    internal class Microcontroller
    {
        private IMicrocontroller controller;

        // Diagram infos
        internal string name;

        internal CompNode InComp;
        internal CompNode OutComp;
        internal VideoNode VideoNode;

        internal SKBitmap video_buffer;

        internal Microcontroller(IMicrocontroller controller, string diagram_name, Nodes nodecollection)
        {
            this.controller = controller;
            InComp = nodecollection.addCompositeNode(new CompNode(false));
            OutComp = nodecollection.addCompositeNode(new CompNode(true));
            VideoNode = nodecollection.addVideoNode(new VideoNode(true));
            video_buffer = new SKBitmap();
            name = diagram_name;
            
        }

        internal void Controller_GraphicsSetup(Size size)
        {
            video_buffer = new SKBitmap(size.Width, size.Height);
        }

        internal void Execute()
        {
            Controller_Input input = new Controller_Input(this.InComp.value.OnOffValues, this.InComp.value.NumberValues);
            Controller_Output output = new Controller_Output(this.OutComp.value.OnOffValues, this.OutComp.value.NumberValues);
            ControllerGraphics screen = new ControllerGraphics(video_buffer);

            controller.Execute(input,output,screen);

            video_buffer = screen.getChanged();
            OutComp.Transfer();
            VideoNode.Transfer();
        }
    }
}
