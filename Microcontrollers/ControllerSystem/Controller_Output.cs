using Microcontrollers.ConnectionSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.ControllerSystem
{
    public class Controller_Output
    {
        internal Dictionary<int, double> NumberOutputs = new Dictionary<int, double>();
        internal Dictionary<int, bool> BoolOutputs = new Dictionary<int, bool>();

        internal Controller_Output(Dictionary<int, bool> bool_outputs, Dictionary<int, double> number_outputs) 
        {
            BoolOutputs = bool_outputs;
            NumberOutputs = number_outputs;
        }

        public void SetNumber(int index, double value)
        {
            if (index > 32 || index < 0)
            {
                throw new CompositeOutOfRangeException($"valid indices range 0-32 not [{index}]");
            }
            NumberOutputs[index] = value;
        }
        public void SetBool(int index, bool value)
        {
            if (index > 32 || index < 0)
            {
                throw new CompositeOutOfRangeException($"valid indices range 0-32 not [{index}]");
            }
            BoolOutputs[index] = value;
        }
    }
}
