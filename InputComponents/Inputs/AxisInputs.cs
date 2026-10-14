using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InputComponents
{
    internal partial class AxisInputs : Form
    {
        internal AxisInputs()
        {
            InitializeComponent();
        }

        internal double AxisUD_Value = 0;
        internal double AxisLR_Value = 0;

        private void AxisLR_ValueChanged(object sender, EventArgs e)
        {
            AxisLR_Value = AxisLR.Value / 100.0;
        }

        private void AxisUD_ValueChanged(object sender, EventArgs e)
        {
            AxisUD_Value = AxisUD.Value / 100.0;
        }
    }
}
