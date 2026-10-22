using Lua;
using Microcontrollers.ControllerSystem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using static Lua.CodeAnalysis.Syntax.DisplayStringSyntaxVisitor;

namespace MicrocontrollerLuaCode.Libraries
{
    internal class ScreenLib
    {
        internal static LuaTable ScreenLibFunctions(ControllerGraphics screen)
        {

            LuaTable screen_table = new LuaTable();

            screen_table["getWidth"] = new LuaFunction((context, ct) =>
                {
                    context.Return(screen.getWidth());
                    return new(1);
                });

            screen_table["getHeight"] = new LuaFunction((context, ct) =>
            {
                context.Return(screen.getHeight());
                return new(1);
            });

            screen_table["drawCircle"] = new LuaFunction((context, ct) =>
            {
                int arg0 = (int)System.Math.Round(context.GetArgument<double>(0));
                int arg1 = (int)System.Math.Round(context.GetArgument<double>(1));
                int arg2 = (int)System.Math.Round(context.GetArgument<double>(2));

                screen.drawCircle(arg0, arg1, arg2);
                return new(0);
            });

            screen_table["drawCircleF"] = new LuaFunction((context, ct) =>
            {
                int arg0 = (int)System.Math.Round(context.GetArgument<double>(0));
                int arg1 = (int)System.Math.Round(context.GetArgument<double>(1));
                int arg2 = (int)System.Math.Round(context.GetArgument<double>(2));

                screen.drawCircleF(arg0, arg1, arg2);
                return new(0);
            });

            screen_table["drawClear"] = new LuaFunction((context, ct) =>
            {
                screen.drawClear();
                return new(0);
            });

            screen_table["drawLine"] = new LuaFunction((context, ct) =>
            {
                int arg0 = (int)System.Math.Round(context.GetArgument<double>(0));
                int arg1 = (int)System.Math.Round(context.GetArgument<double>(1));
                int arg2 = (int)System.Math.Round(context.GetArgument<double>(2));
                int arg3 = (int)System.Math.Round(context.GetArgument<double>(3));

                screen.drawLine(arg0, arg1, arg2, arg3);
                return new(0);
            });

            // drawMap Missing

            screen_table["drawRect"] = new LuaFunction((context, ct) =>
            {
                int arg0 = (int)System.Math.Round(context.GetArgument<double>(0));
                int arg1 = (int)System.Math.Round(context.GetArgument<double>(1));
                int arg2 = (int)System.Math.Round(context.GetArgument<double>(2));
                int arg3 = (int)System.Math.Round(context.GetArgument<double>(3));

                screen.drawRect(arg0, arg1, arg2, arg3);
                return new(0);
            });

            screen_table["drawRectF"] = new LuaFunction((context, ct) =>
            {
                int arg0 = (int)System.Math.Round(context.GetArgument<double>(0));
                int arg1 = (int)System.Math.Round(context.GetArgument<double>(1));
                int arg2 = (int)System.Math.Round(context.GetArgument<double>(2));
                int arg3 = (int)System.Math.Round(context.GetArgument<double>(3));

                screen.drawRectF(arg0, arg1, arg2, arg3);
                return new(0);
            });

            screen_table["drawText"] = new LuaFunction((context, ct) =>
            {
                int arg0 = (int)System.Math.Round(context.GetArgument<double>(0));
                int arg1 = (int)System.Math.Round(context.GetArgument<double>(1));
                string arg2 = context.GetArgument<string>(2);

                screen.drawText(arg0, arg1, arg2);
                return new(0);
            });

            screen_table["drawTextBox"] = new LuaFunction((context, ct) =>
            {
                int arg0 = (int)System.Math.Round(context.GetArgument<double>(0));
                int arg1 = (int)System.Math.Round(context.GetArgument<double>(1));
                int arg2 = (int)System.Math.Round(context.GetArgument<double>(2));
                int arg3 = (int)System.Math.Round(context.GetArgument<double>(3));
                string arg4 = context.GetArgument<string>(4);

                short arg5 = -1;
                short arg6 = -1;

                if (context.ArgumentCount > 5)
                {
                    arg5 = (short)System.Math.Round(context.GetArgument<double>(5));
                    arg6 = (short)System.Math.Round(context.GetArgument<double>(6));
                }

                screen.drawTextBox(arg0, arg1, arg2, arg3, arg4,arg5, arg6);
                return new(0);
            });

            screen_table["drawTriangle"] = new LuaFunction((context, ct) =>
            {
                int arg0 = (int)System.Math.Round(context.GetArgument<double>(0));
                int arg1 = (int)System.Math.Round(context.GetArgument<double>(1));
                int arg2 = (int)System.Math.Round(context.GetArgument<double>(2));
                int arg3 = (int)System.Math.Round(context.GetArgument<double>(3));
                int arg4 = (int)System.Math.Round(context.GetArgument<double>(4));
                int arg5 = (int)System.Math.Round(context.GetArgument<double>(5));

                screen.drawTriangle(arg0, arg1, arg2, arg3, arg4, arg5);
                return new(0);
            });

            screen_table["drawTriangleF"] = new LuaFunction((context, ct) =>
            {
                int arg0 = (int)System.Math.Round(context.GetArgument<double>(0));
                int arg1 = (int)System.Math.Round(context.GetArgument<double>(1));
                int arg2 = (int)System.Math.Round(context.GetArgument<double>(2));
                int arg3 = (int)System.Math.Round(context.GetArgument<double>(3));
                int arg4 = (int)System.Math.Round(context.GetArgument<double>(4));
                int arg5 = (int)System.Math.Round(context.GetArgument<double>(5));

                screen.drawTriangleF(arg0, arg1, arg2, arg3, arg4, arg5);
                return new(0);
            });

            screen_table["setColor"] = new LuaFunction((context, ct) =>
            {
                int arg0 = (int)System.Math.Round(context.GetArgument<double>(0));
                int arg1 = (int)System.Math.Round(context.GetArgument<double>(1));
                int arg2 = (int)System.Math.Round(context.GetArgument<double>(2));

                screen.setColor((byte)(arg0 % 256), (byte)(arg1 % 256), (byte)(arg2 % 256));
                return new(0);
            });

            // setMapColorGrass missing

            // setMapColorGravel missing

            // setMapColorLand missing

            // setMapColorOcean missing

            // setMapColorRock missing

            // setMapColorSand missing

            // setMapColorShallows missing

            // setMapColorSnow missing
            return screen_table;
        }
    }
}
