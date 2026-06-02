using Microcontrollers.ControllerSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers_Console_tester
{
    internal class MasterController : IMicrocontroller
    {
        private int x = 0;
        private int y = 0;
        public void Execute(Controller_Input Input, Controller_Output Output, ControllerGraphics Screen)
        {
            x = (int)Input.GetNumber(1);
            y = (int)Input.GetNumber(2);
            Screen.setColor(0, 0, 0);
            Screen.drawClear();
            Screen.setColor(255, 255, 255);
            Screen.drawCircle(x, y, 10);
        }

 
    }
}
