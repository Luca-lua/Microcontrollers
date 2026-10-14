using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.ControllerSystem
{
    /// <summary>
    /// Your Controller needs this Interface to be executed and to be added to Gamespace.
    /// </summary>
    public interface IMicrocontroller
    {
        /// <summary>
        /// Your logic goes inside here. This is the "onTick" and "onDraw" equivalent in c#.
        /// </summary>
        /// <param name="Input">Custom Lua like "input" class</param>
        /// <param name="Output">Custom Lua like "output" class</param>
        /// <param name="Screen">Custom Lua like "screen" class</param>
        /// <returns></returns>
        public Task Execute(Controller_Input Input, Controller_Output Output, ControllerGraphics Screen);
    }
}
