using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Arsalis.WebcamLibrary
{
    public partial class label_top_value_read_only : UserControl
    {
        public label_top_value_read_only()
        {
            InitializeComponent();
        }

        public void setLabel(string text)
        {
            this.label1.Text = text;
        }

        public void setValue(int value)
        {
            this.textBox1.Text = value.ToString();
        }

        public void setValue(string value)
        {
            this.textBox1.Text = value;
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
