using Lua;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicrocontrollerLuaCode.Libraries
{
    internal class Mathlib
    {
        internal static LuaTable MathLibFunctions(Random random)
        {
            LuaTable math_table = new LuaTable();

            math_table["abs"] = new LuaFunction((context, ct) =>
            {
                double arg0 = context.GetArgument<double>(0);

                context.Return(Math.Abs(arg0));
                return new(1);
            });

            math_table["acos"] = new LuaFunction((context, ct) =>
            {
                double arg0 = context.GetArgument<double>(0);

                context.Return(Math.Acos(arg0));
                return new(1);
            });

            math_table["asin"] = new LuaFunction((context, ct) =>
            {
                double arg0 = context.GetArgument<double>(0);

                context.Return(Math.Asin(arg0));
                return new(1);
            });

            math_table["atan"] = new LuaFunction((context, ct) =>
            {
                double arg0 = context.GetArgument<double>(0);

                if (context.ArgumentCount < 2)
                {
                    context.Return(Math.Atan(arg0));
                    return new(1);
                }

                double arg1 = context.GetArgument<double>(1);


                context.Return(Math.Atan2(arg0, arg1));
                return new(1);
            });

            math_table["ceil"] = new LuaFunction((context, ct) =>
            {
                double arg0 = context.GetArgument<double>(0);

                context.Return(Math.Ceiling(arg0));
                return new(1);
            });

            math_table["cos"] = new LuaFunction((context, ct) =>
            {
                double arg0 = context.GetArgument<double>(0);

                context.Return(Math.Cos(arg0));
                return new(1);
            });

            math_table["deg"] = new LuaFunction((context, ct) =>
            {
                double arg0 = context.GetArgument<double>(0);

                context.Return(arg0 * (180 / Math.PI));
                return new(1);
            });

            math_table["exp"] = new LuaFunction((context, ct) =>
            {
                double arg0 = context.GetArgument<double>(0);

                context.Return(Math.Exp(arg0));
                return new(1);
            });

            math_table["floor"] = new LuaFunction((context, ct) =>
            {
                double arg0 = context.GetArgument<double>(0);

                context.Return(Math.Floor(arg0));
                return new(1);
            });

            math_table["fmod"] = new LuaFunction((context, ct) =>
            {
                double arg0 = context.GetArgument<double>(0);
                double arg1 = context.GetArgument<double>(1);

                context.Return(arg0 - Math.Truncate(arg0 / arg1) * arg1);
                return new(1);
            });

            math_table["huge"] = new LuaFunction((context, ct) =>
            {
                context.Return(double.MaxValue);
                return new(1);
            });

            math_table["log"] = new LuaFunction((context, ct) =>
            {
                double arg0 = context.GetArgument<double>(0);

                context.Return(Math.Log(arg0));
                return new(1);
            });

            math_table["max"] = new LuaFunction((context, ct) =>
            {
                List<double> values = new List<double>();

                for (int i = 0; i < context.ArgumentCount; i++)
                {
                    values.Add(context.GetArgument<double>(i));
                }

                context.Return(values.Max());
                return new(1);
            });

            math_table["maxinteger"] = new LuaFunction((context, ct) =>
            {
                context.Return(int.MaxValue);
                return new(1);
            });

            math_table["min"] = new LuaFunction((context, ct) =>
            {
                List<double> values = new List<double>();

                for (int i = 0; i < context.ArgumentCount; i++)
                {
                    values.Add(context.GetArgument<double>(i));
                }

                context.Return(values.Min());
                return new(1);
            });

            math_table["mininteger"] = new LuaFunction((context, ct) =>
            {
                context.Return(int.MinValue);
                return new(1);
            });

            math_table["modf"] = new LuaFunction((context, ct) =>
            {
                double arg0 = context.GetArgument<double>(0);

                context.Return(arg0 % 1, Math.Round(arg0));
                return new(1);
            });

            math_table["rad"] = new LuaFunction((context, ct) =>
            {
                double arg0 = context.GetArgument<double>(0);

                context.Return(arg0 * (Math.PI / 180));
                return new(1);
            });

            math_table["random"] = new LuaFunction((context, ct) =>
            {
                double arg0 = 1;
                double arg1 = context.GetArgument<double>(0);

                if (context.ArgumentCount >= 2)
                {
                    arg0 = context.GetArgument<double>(0);
                    arg1 = context.GetArgument<double>(1);
                }

                if (arg1 - arg0 < 0)
                {
                    context.Return(LuaValue.Nil);
                }
                else
                {
                    context.Return(arg0 + random.Next((int)(arg1 - arg0)));
                }
                return new(1);
            });

            math_table["randomseed"] = new LuaFunction((context, ct) =>
            {
                int arg0 = (int)Math.Round(context.GetArgument<double>(0));

                random = new Random(arg0);
                return new(0);
            });

            math_table["sin"] = new LuaFunction((context, ct) =>
            {
                double arg0 = context.GetArgument<double>(0);

                context.Return(Math.Sin(arg0));
                return new(1);
            });

            math_table["sqrt"] = new LuaFunction((context, ct) =>
            {
                double arg0 = context.GetArgument<double>(0);

                context.Return(Math.Sqrt(arg0));
                return new(1);
            });

            math_table["tan"] = new LuaFunction((context, ct) =>
            {
                double arg0 = context.GetArgument<double>(0);

                context.Return(Math.Tan(arg0));
                return new(1);
            });

            math_table["tointeger"] = new LuaFunction((context, ct) =>
            {
                int arg0 = (int)Math.Round(context.GetArgument<double>(0));

                context.Return(arg0);
                return new(1);
            });

            math_table["type"] = new LuaFunction((context, ct) =>
            {
                LuaValue arg0 = context.GetArgument<LuaValue>(0);

                context.Return(arg0.Type.ToString());

                return new(1);
            });

            math_table["ult"] = new LuaFunction((context, ct) =>
            {
                int arg0 = (int)context.GetArgument<double>(0);
                int arg1 = (int)context.GetArgument<double>(0);

                context.Return(arg0 < arg1 && arg0 > 0 && arg1 > 0 ? true : false);

                return new(1);
            });

            math_table["pi"] = Math.PI;

            return math_table;
        }
    }
}
