using Microcontrollers.ControllerSystem;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Microcontrollers.GFX
{
    public class ControllerGFX
    {
        public static void DrawControllerGUI()
        {
            var type = typeof(IMicrocontroller);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract);
            foreach (var controller in types)
            {
                var propperties = controller.GetProperties();
            }
        }
    }
}
