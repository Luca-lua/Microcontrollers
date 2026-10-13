using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.ControllerSystem
{
    public interface IMicrocontroller
    {
        public Task Execute(Controller_Input Input, Controller_Output Output, ControllerGraphics Screen);
    }
}
