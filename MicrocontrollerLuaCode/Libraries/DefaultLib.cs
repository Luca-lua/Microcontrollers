using Lua;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.AxHost;

namespace MicrocontrollerLuaCode.Libraries
{
    internal class DefaultLib
    {
        internal static void MiscLibFunctions(LuaState state)
        {
            // default mapping 
            state.Environment["print"] = new LuaFunction((context, ct) =>
            {
                LuaValue arg0 = context.GetArgument<LuaValue>(0);
                Console.WriteLine(arg0.ToString());
                return new(1);
            });

        }
    }
}
