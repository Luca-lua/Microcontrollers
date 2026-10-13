using System;
using System.Collections.Generic;
using System.Text;
using Microcontrollers;
using Microcontrollers.ControllerSystem;

namespace MicrocontrollerLuaCode
{
    public enum LuaScriptLocation
    {
        ManualPath,
        Embedded
    }
    public class LuaConfig
    {
        public LuaScriptLocation ScriptLocation { get; set; } = LuaScriptLocation.Embedded;
        public IMicrocontroller controller { get; set; } = null;
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
