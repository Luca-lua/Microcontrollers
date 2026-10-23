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
        private decimal N1_Val = 0;
        private decimal N2_Val = 0;
        private decimal N3_Val = 0;
        private decimal N4_Val = 0;
        private decimal N5_Val = 0;
        private decimal N6_Val = 0;
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
                    return (double)N1_Val;

                case 2:
                    return (double)N2_Val;

                case 3:
                    return (double)N3_Val;

                case 4:
                    return (double)N4_Val;

                case 5:
                    return (double)N5_Val;

                case 6:
                    return (double)N6_Val;

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

        private void N1_ValueChanged(object sender, EventArgs e)
        {
            N1_Val = N1.Value;
        }

        private void N2_ValueChanged(object sender, EventArgs e)
        {
            N2_Val = N2.Value;
        }

        private void N3_ValueChanged(object sender, EventArgs e)
        {
            N3_Val = N3.Value;
        }

        private void N4_ValueChanged(object sender, EventArgs e)
        {
            N4_Val = N4.Value;
        }

        private void N5_ValueChanged(object sender, EventArgs e)
        {
            N5_Val = N5.Value;
        }

        private void N6_ValueChanged(object sender, EventArgs e)
        {
            N6_Val = N6.Value;
        }
    }
}
