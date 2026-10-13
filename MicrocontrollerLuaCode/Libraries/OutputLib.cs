using Lua;
using Microcontrollers.ControllerSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicrocontrollerLuaCode.Libraries
{
    internal class OutputLib
    {
        internal static LuaTable OutputLibFunctions(Controller_Output output)
        {
            LuaTable output_table = new LuaTable();

            output_table["setBool"] = new LuaFunction((context, ct) =>
            {
                int arg0 = (int)System.Math.Round(context.GetArgument<double>(0));
                bool arg1 = context.GetArgument<bool>(1);

                output.SetBool(arg0, arg1);
                return new(1);
            });

            output_table["setNumber"] = new LuaFunction((context, ct) =>
            {
                int arg0 = (int)System.Math.Round(context.GetArgument<double>(0));
                double arg1 = context.GetArgument<double>(1);

                output.SetNumber(arg0, arg1);
                return new(1);
            });

            return output_table;
        }
    }
}
