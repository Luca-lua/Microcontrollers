using Lua;
using MicrocontrollerLuaCode.Libraries;
using Microcontrollers.ControllerSystem;

namespace MicrocontrollerLuaCode
{
    public class LuaExecute
    {
        public LuaExecute(LuaConfig config, Controller_Input input, Controller_Output output, ControllerGraphics screen)
        {
            this.input = input;
            this.output = output;
            this.screen = screen;

            this.config = config;
            if(config.ScriptLocation == LuaScriptLocation.Embedded)
            {
                path = $"./{config.controller.GetType().ToString()}.lua";
            }
            else
            {
                if (config.ManualLuaPath == string.Empty)
                {
                    throw new ArgumentException("ManualLuaPath cannot be empty when ScriptLocation is set to ManualPath.");
                }

                if(config.ManualLuaPath.Contains(".lua"))
                    path = config.ManualLuaPath;

                else
                    path = $"{config.ManualLuaPath}.lua";
            }

            if(!File.Exists(path))
            {
                File.Create(path).Close();
                File.WriteAllText(path, LuaConfig.CreationTemplate);
                Console.WriteLine($"[!!] Lua script file created at: [{path}] for controller [{config.controller.GetType().ToString()}]");
            }

            state = LuaState.Create();
            DefaultLib.MiscLibFunctions(state);

            // input Lib mapping
            LuaTable input_table = InputLib.InputLibFunctions(input);
            state.Environment["input"] = input_table;

            // screen Lib mapping
            LuaTable screen_table = ScreenLib.ScreenLibFunctions(screen);
            state.Environment["screen"] = screen_table;

            // output lib mapping
            LuaTable output_table = OutputLib.OutputLibFunctions(output);
            state.Environment["output"] = output_table;

            // math lib mapping
            LuaTable math_table = Mathlib.MathLibFunctions(random);
            state.Environment["math"] = math_table;

            file_loaded = false;
        }

        private Random random = new Random();

        private bool file_loaded;

        private LuaState state;

        internal LuaConfig config;

        private Controller_Input input;
        private Controller_Output output;
        private ControllerGraphics screen;

        public async Task Execute()
        {
            if(!file_loaded)
            {
                await this.state.DoFileAsync(path);
                file_loaded = true;
            }
            var onTickFunction = this.state.Environment["onTick"];
            await this.state.CallAsync(onTickFunction, []);

            var onDrawFunction = this.state.Environment["onDraw"];
            await this.state.CallAsync(onDrawFunction, []);
        }

        internal string path;
    }
}
