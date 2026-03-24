using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.ControllerSystem
{
    public interface IMicrocontroller
    {
        public void Execute(Controller_Input Input, Controller_Output Output, );
    }
}
