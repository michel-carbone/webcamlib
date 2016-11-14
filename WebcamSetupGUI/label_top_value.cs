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
    public partial class label_top_value : label_top_value_read_only
    {
        public label_top_value()
        {
            InitializeComponent();
            this.textBox1.ReadOnly = false;
        }

        public int getIntValue()
        {
            int value;
            int.TryParse(this.textBox1.Text, out value);
            return value;
        }

        public string getStringValue()
        {
            return this.textBox1.Text;
        }
    }
}
