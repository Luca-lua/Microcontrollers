using Microcontrollers.ControllerSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Controllers_Console_tester
{
    internal class Controller1 : IMicrocontroller
    {
        static int counter = 1;
        static bool state = false;
        public void Execute(Controller_Input Input, Controller_Output Output, ControllerGraphics Screen)
        {
            counter++;
            if(counter % 50 == 0)
            {
                state = !state;
            }
            Output.SetBool(1, state);
        }
    }
}
