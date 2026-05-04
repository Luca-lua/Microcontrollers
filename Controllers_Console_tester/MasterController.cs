using Microcontrollers.ControllerSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers_Console_tester
{
    internal class MasterController : IMicrocontroller
    {
        public void Execute(Controller_Input Input, Controller_Output Output, ControllerGraphics Screen)
        {
            Screen.setColor(0,0,0);
            Screen.drawClear();
            Screen.setColor(255, 255, 255);
            Screen.drawCircleF(16,16,(int)Input.GetNumber(1));
        }
    }
}
