using Microcontrollers.ControllerSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Controllers_Console_tester
{
    internal class Controller1 : IMicrocontroller
    {
        public void Execute(Controller_Input Input, Controller_Output Output, ControllerGraphics Screen)
        {
            Output.SetNumber(1, 16/1.5);
        }
    }
}
