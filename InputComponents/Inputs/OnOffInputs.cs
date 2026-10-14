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
    internal partial class OnOffInput : Form
    {
        internal OnOffInput()
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
        internal bool GetInputValue(int input_nr)
        {
            switch (input_nr)
            {
                case 1:
                    return B1.Checked;

                case 2:
                    return B2.Checked;

                case 3:
                    return B3.Checked;

                case 4:
                    return B4.Checked;

                case 5:
                    return B5.Checked;

                case 6:
                    return B6.Checked;

                default:
                    Console.WriteLine("input_nr out of range (1-6)");
                    break;
            }
            return false;
        }
        internal void SetInputValue(bool value, int input_nr)
        {
            switch (input_nr)
            {
                case 1:
                    B1.Checked = value;
                    break;

                case 2:
                    B2.Checked = value;
                    break;

                case 3:
                    B3.Checked = value;
                    break;

                case 4:
                    B4.Checked = value;
                    break;

                case 5:
                    B5.Checked = value;
                    break;

                case 6:
                    B6.Checked = value;
                    break;

                default:
                    Console.WriteLine("input_nr out of range (1-6)");
                    break;
            }
        }
    }
}
