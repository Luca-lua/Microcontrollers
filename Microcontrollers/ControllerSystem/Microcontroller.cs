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
        internal VideoNode VideoNodeOut;
        internal VideoNode VideoNodeIn;

        private Controller_Input input = null;
        private Controller_Output output = null;
        private ControllerGraphics screen = null;

        internal Size screensize = new Size(5, 5);

        internal SKBitmap video_buffer;
        internal SKBitmap recieved_buffer;

        internal Microcontroller(Size internal_screen_buffer,IMicrocontroller controller, string diagram_name, Nodes nodecollection)
        {
            this.controller = controller;
            InComp = nodecollection.addCompositeNode(new CompNode(false));
            OutComp = nodecollection.addCompositeNode(new CompNode(true));
            VideoNodeIn = nodecollection.addVideoNode(new VideoNode(false));
            VideoNodeOut = nodecollection.addVideoNode(new VideoNode(true));
            Controller_GraphicsSetup(new Size(internal_screen_buffer.Width, internal_screen_buffer.Height));
            name = diagram_name;
            
        }

        internal void Controller_GraphicsSetup(Size size)
        {
            if (size != screensize)
            {
                video_buffer = new SKBitmap(size.Width, size.Height);
                recieved_buffer = new SKBitmap(size.Width, size.Height);
            }
        }

        internal async Task Execute()
        {
            if (VideoNodeIn.value.ByteCount != 0)
            {
                recieved_buffer = VideoNodeIn.value;
            }

            if (input == null)
                input = new Controller_Input(this.InComp.value.OnOffValues, this.InComp.value.NumberValues);
            else
            {
                input.NumberInputs = this.InComp.value.NumberValues;
                input.BoolInputs = this.InComp.value.OnOffValues;
            }

            if (output == null)
                output = new Controller_Output(this.OutComp.value.OnOffValues, this.OutComp.value.NumberValues);
            else
            {
                output.BoolOutputs = this.OutComp.value.OnOffValues;
                output.NumberOutputs = this.OutComp.value.NumberValues;
            }

            if (screen == null)
                screen = new ControllerGraphics(video_buffer);
            else
                screen.ChangeCanvas(video_buffer);

            screen.FillBitmap(recieved_buffer);

            await controller.Execute(input,output,screen);

            video_buffer = await screen.getChanged();
            VideoNodeOut.value = video_buffer;
            OutComp.Transfer();
            InComp.Transfer();
            VideoNodeOut.Transfer();
            Controller_GraphicsSetup(VideoNodeOut.screen_size_return == null ? screensize : (Size)VideoNodeOut.screen_size_return);
            VideoNodeIn.screen_size_return = VideoNodeOut.screen_size_return;
        }
    }
}
