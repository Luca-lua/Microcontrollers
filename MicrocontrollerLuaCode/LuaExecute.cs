using Lua;
using MicrocontrollerLuaCode.Libraries;
using Microcontrollers.ControllerSystem;

namespace MicrocontrollerLuaCode
{
    /// <summary>
    /// Main Class for the Lua emulation
    /// </summary>
    public class LuaExecute
    {
        /// <summary>
        /// Initializes all of the Lua commands and checks if file exist.
        /// <para></para>
        /// Call this Method once, the first time Execute runs.
        /// </summary>
        /// <param name="config">Your LuaConfig. Fill the Controller for minimum Setup.</param>
        /// <param name="input">From the Execute loop of your controller.</param>
        /// <param name="output">From the Execute loop of your controller.</param>
        /// <param name="screen">From the Execute loop of your controller.</param>
        /// <exception cref="ArgumentException"></exception>
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
            LuaTable input_table = InputLib.InputLibFunctions(() => input);
            state.Environment["input"] = input_table;

            // screen Lib mapping
            LuaTable screen_table = ScreenLib.ScreenLibFunctions( screen);
            state.Environment["screen"] = screen_table;

            // output lib mapping
            LuaTable output_table = OutputLib.OutputLibFunctions( output);
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

        /// <summary>
        /// Calls the typical onTick() and onDraw() functions aswell as refreshing input and output data.
        /// <para></para>
        /// Call this Method every Tick.
        /// </summary>
        /// <param name="input">From the Execute loop of your controller.</param>
        /// <param name="output">From the Execute loop of your controller.</param>
        /// <param name="screen">From the Execute loop of your controller.</param>
        /// <returns></returns>
        public async Task Execute(Controller_Input input, Controller_Output output, ControllerGraphics screen)
        {
            this.input = input;
            this.output = output;
            this.screen = screen;

            if (!file_loaded)
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
