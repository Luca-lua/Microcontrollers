using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace InputComponents
{
    internal partial class NumberInputs : Form
    {
        internal NumberInputs()
        {
            InitializeComponent();
        }
        internal void SetInputName(string name, int input_nr)
        {
            switch (input_nr)
            {
                case 1:
                    L1.Text = name;
                    break;

                case 2:
                    L2.Text = name;
                    break;

                case 3:
                    L3.Text = name;
                    break;

                case 4:
                    L4.Text = name;
                    break;

                case 5:
                    L5.Text = name;
                    break;

                case 6:
                    L6.Text = name;
                    break;

                default:
                    Console.WriteLine("input_nr out of range (1-6)");
                    break;
            }
        }
        internal double GetInputValue(int input_nr)
        {
            switch (input_nr)
            {
                case 1:
                    return (double)N1.Value;

                case 2:
                    return (double)N2.Value;

                case 3:
                    return (double)N3.Value;

                case 4:
                    return (double)N4.Value;

                case 5:
                    return (double)N5.Value;

                case 6:
                    return (double)N6.Value;

                default:
                    Console.WriteLine("input_nr out of range (1-6)");
                    break;
            }
            return 0;
        }
        internal void SetInputValue(double value, int input_nr)
        {
            switch (input_nr)
            {
                case 1:
                    N1.Value = (decimal)value;
                    break;

                case 2:
                    N2.Value = (decimal)value;
                    break;

                case 3:
                    N3.Value = (decimal)value;
                    break;

                case 4:
                    N4.Value = (decimal)value;
                    break;

                case 5:
                    N5.Value = (decimal)value;
                    break;

                case 6:
                    N6.Value = (decimal)value;
                    break;

                default:
                    Console.WriteLine("input_nr out of range (1-6)");
                    break;
            }
        }
    }
}
