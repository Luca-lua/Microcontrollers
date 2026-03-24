using System;
using System.Collections.Generic;
using System.Text;

namespace Microcontrollers.ConnectionSystem
{
    internal class Composite
    {
        internal Dictionary<int ,bool?> OnOffValues = new Dictionary<int ,bool?>();
        internal Dictionary<int, double?> NumberValues = new Dictionary<int, double?>();
        internal Composite()
        {
            for (int i = 0; i <= 32; i++)
            {
                OnOffValues[i] = null;
                NumberValues[i] = null;
            }
        }
    }
}
