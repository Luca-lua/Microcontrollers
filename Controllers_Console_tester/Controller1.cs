using MicrocontrollerLuaCode;
using Microcontrollers.ControllerSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers_Console_tester
{
    internal class Controller1 : IMicrocontroller
    {
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
                luacontext = new LuaExecute(config, Input,Output,Screen);
            }

            await luacontext.Execute(Input, Output, Screen);
            //Screen.setColor(255, 255, 255);
            //Screen.drawLine(5, (int)(Input.GetNumber(11) * 32) + 10, Screen.getWidth() - 10, (int)(Input.GetNumber(11) * 32)+10);
        }
    }
}
