using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Arsalis.WebcamLibrary
{
    public partial class label_top_numeric : UserControl
    {
        public label_top_numeric()
        {
            InitializeComponent();
        }

        public label_top_numeric(int min, int max)
        {
            this.numericUpDown1.Minimum = min;
            this.numericUpDown1.Maximum = max;
        }

        public int getIntValue()
        {
            int value;
            int.TryParse(this.numericUpDown1.Value.ToString(), out value);
            return value;
        }

        public string getStringValue()
        {
            return this.numericUpDown1.Value.ToString();
        }

        public void setMinMax(int min, int max)
        {
            this.numericUpDown1.Minimum = min;
            this.numericUpDown1.Maximum = max;
        }

        public bool setValue(int value)
        {
            bool isOK = false;
            if (value <= this.numericUpDown1.Maximum && value >= this.numericUpDown1.Minimum)
            {
                this.numericUpDown1.Value = value;
                isOK = true;
            }
            return isOK;
        }

        public string LabelText
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }
    }
}
