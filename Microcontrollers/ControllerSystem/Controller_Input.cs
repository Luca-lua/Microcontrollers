using Microcontrollers.ConnectionSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.ControllerSystem
{
    public class Controller_Input
    {
        internal Dictionary<int, double> NumberInputs = new Dictionary<int, double>();
        internal Dictionary<int, bool> BoolInputs = new Dictionary<int, bool>();

        internal Controller_Input(Dictionary<int,bool> bool_inputs,Dictionary<int,double> number_inputs) 
        {
            NumberInputs = number_inputs;
            BoolInputs = bool_inputs;
        }

        public double GetNumber(int index)
        {
            if (index > 32 || index < 0)
            {
                throw new CompositeOutOfRangeException($"valid indices range 0-32 not [{index}]");
            }
            return (double)(NumberInputs[index] == null ? 0 : NumberInputs[index]);
        }
        public bool GetBool(int index)
        {
            if (index > 32 || index < 0)
            {
                throw new CompositeOutOfRangeException($"valid indices range 0-32 not [{index}]");
            }
            return (bool)(BoolInputs[index] == null ? false : BoolInputs[index]);
        }
    }
}
