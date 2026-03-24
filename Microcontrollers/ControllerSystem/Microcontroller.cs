using System;
using System.Collections.Generic;
using System.Text;
using Microcontrollers.ConnectionSystem;

namespace Microcontrollers.ControllerSystem
{
    internal class Microcontroller
    {
        private IMicrocontroller controller;

        internal CompNode InComp;
        internal CompNode OutComp;

        internal Bitmap video_buffer;

        internal Microcontroller(IMicrocontroller controller)
        {
            this.controller = controller;
            InComp = new CompNode();
            OutComp = new CompNode();
        }

        internal void ScreenSetup(Size size)
        {
            video_buffer = new Bitmap(size.Width, size.Height);
        }

        internal void Execute()
        {
            Controller_Input input = new Controller_Input(this.InComp.value.OnOffValues, this.InComp.value.NumberValues);
            Controller_Output output = new Controller_Output(this.OutComp.value.OnOffValues, this.OutComp.value.NumberValues);

            controller.Execute(input,output);
        }
    }
}
