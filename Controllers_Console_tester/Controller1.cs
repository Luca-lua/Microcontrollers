using MicrocontrollerLuaCode;
using Microcontrollers.ControllerSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers_Console_tester
{
    internal class Controller1 : IMicrocontroller
    {
        // Variables that remain each run
        private int x = 0;
        private int y = 0;
        LuaExecute luacontext = null;
        public async Task Execute(Controller_Input Input, Controller_Output Output, ControllerGraphics Screen)
        {
            if (luacontext == null)
            {
                LuaConfig config = new LuaConfig()
                {
                    controller = this,
                    ScriptLocation = LuaScriptLocation.Embedded,
                };
                luacontext = new LuaExecute(config,Input,Output,Screen);
            }

            await luacontext.Execute();
            /*// get x and y touch coordiantes of screen
            x = (int)Input.GetNumber(1);
            y = (int)Input.GetNumber(2);
            Screen.setColor(0, 0, 0);
            Screen.drawClear();

            // get OnOff on channel 1
            if (Input.GetBool(1))
            {
                Screen.setColor(255, 255, 255);
            }

            // Draw visual indication of input signals
            Screen.drawCircle(x, y, 10);*/

        }

 
    }
}
