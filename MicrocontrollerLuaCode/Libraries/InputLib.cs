using Lua;
using Microcontrollers.ControllerSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicrocontrollerLuaCode.Libraries
{
    internal class InputLib
    {
        internal static LuaTable InputLibFunctions(Controller_Input input)
        {
            LuaTable input_table = new LuaTable();

            input_table["getBool"] = new LuaFunction((context, ct) =>
            {
                int arg0 = (int)System.Math.Round(context.GetArgument<double>(0));
                context.Return(input.GetBool(arg0));
                return new(1);
            });

            input_table["getNumber"] = new LuaFunction((context, ct) =>
            {
                int arg0 = (int)System.Math.Round(context.GetArgument<double>(0));
                context.Return(input.GetNumber(arg0));
                return new(1);
            });

            return input_table;
        }
    }
}
