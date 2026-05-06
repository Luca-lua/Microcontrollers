using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Microcontrollers.ConnectionSystem
{
    [Serializable]
    public class CompositeOutOfRangeException : Exception
    {
        public CompositeOutOfRangeException(string message) : base(message) { }
    }
    [Serializable]
    public class CompositeInvalidNumberException : Exception
    {
        public CompositeInvalidNumberException(string message) : base(message) { }
    }
    public class Composite
    {
        public Dictionary<int ,bool> OnOffValues { get; set; } = new Dictionary<int ,bool>();
        public Dictionary<int, double> NumberValues { get; set; } = new Dictionary<int, double>();
        public Composite()
        {
            for (int i = 0; i <= 32; i++)
            {
                OnOffValues[i] = false;
                NumberValues[i] = 0;
            }
        }
    }
}
