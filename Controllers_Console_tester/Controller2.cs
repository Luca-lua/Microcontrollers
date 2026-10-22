using Microcontrollers.ControllerSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers_Console_tester
{
    internal class Controller2 : IMicrocontroller
    {
        internal bool clk = false;
        internal int tick = 0;
        public async Task Execute(Controller_Input Input, Controller_Output Output, ControllerGraphics Screen)
        {
            int w = Screen.getWidth();
            int h = Screen.getHeight();
            Screen.setColor(100, 100, 100);
            Screen.drawRectF(0, 0, w, h);
            Screen.setColor(0, 0, 0);
            Screen.drawRectF(5, 5, w - 10, h - 10);
        }
    }
}
