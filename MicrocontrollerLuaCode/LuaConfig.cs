using System;
using System.Collections.Generic;
using System.Text;
using Microcontrollers;
using Microcontrollers.ControllerSystem;

namespace MicrocontrollerLuaCode
{
    /// <summary>
    /// Decides where Lua File will be saved to and read from.
    /// </summary>
    /// <remarks>
    /// Embedded => Lua in Project directory. The name of the file in this example is "Controllers_Console_tester.Controller1.lua".
    /// <para></para>
    /// ManualPath => Lua in Specified ManualLuaPath.
    /// </remarks>
    public enum LuaScriptLocation
    {
        ManualPath,
        Embedded
    }
    public class LuaConfig
    {
        /// <summary>
        /// Decides where Lua File will be saved to and read from.
        /// </summary>
        public LuaScriptLocation ScriptLocation { get; set; } = LuaScriptLocation.Embedded;
        /// <summary>
        /// The Parent controller of the Lua file.
        /// </summary>
        public IMicrocontroller controller { get; set; } = null;
        /// <summary>
        /// The path Lua files will be opened and saved from in "LuaScriptLocation.ManualPath" mode.
        /// </summary>
        public string ManualLuaPath { get; set; } = string.Empty;

        static readonly internal string CreationTemplate = @"

function onTick()
    -- your code
end

function onDraw()
    -- your code
end

";
    }
}
