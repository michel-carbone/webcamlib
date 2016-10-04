using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;

namespace Arsalis.WebcamLibrary
{
    public partial class WebcamSetupGUI : Form
    {
        private Arsalis.WebcamLibrary.WebcamLibrary webcamClass;
        public WebcamSetupGUI()
        {
            InitializeComponent();
        }

        private void WebcamSetupGUI_Load(object sender, EventArgs e)
        {
            this.webcamClass = new Arsalis.WebcamLibrary.WebcamLibrary();
            for(int i = 0; i < this.webcamClass.WebcamListNames.Length; i++)
            {
                comboBox1.Items.Add(this.webcamClass.WebcamListNames[i]);
            }
            this.label_top_value_read_only1.setLabel("min");
            this.label_top_value_read_only2.setLabel("default");
            this.label_top_value_read_only3.setLabel("max");
            this.label_top_value_read_only4.setLabel("flags");
            this.label_top_value_read_only5.setLabel("current value");
            this.label_top_value_read_only6.setLabel("current flag");
        }

        private void select_webcam_button_Click(object sender, EventArgs e)
        {
            // TODO select webcam
            this.comboBox2.Enabled = true;
            this.get_parameters_button.Enabled = true;
            // TODO get parameters from either Arsalis lib or AForge lib
            string [] cameraParameters = {"Exposure", "Focus", "Iris", "Pan", "Roll", "Tilt", "Zoom"};
            for (int i = 0; i < cameraParameters.Length; i++)
            {
                comboBox2.Items.Add(cameraParameters[i]);
            }
        }

        private void get_parameters_button_Click(object sender, EventArgs e)
        {
            this.webcamClass.initDevice(comboBox1.SelectedIndex);
            switch(comboBox2.SelectedIndex)
            {
                case 0:
                {
                    this.webcamClass.getExposureParameters();
                    this.label_top_value_read_only1.setValue(this.webcamClass.Exposure.minValue);
                    this.label_top_value_read_only2.setValue(this.webcamClass.Exposure.defaultValue);
                    this.label_top_value_read_only3.setValue(this.webcamClass.Exposure.maxValue);
                    this.label_top_value_read_only4.setValue(this.webcamClass.Exposure.ctrFlag.ToString());
                    this.label_top_value_read_only5.setValue(this.webcamClass.Exposure.currentValue);
                    this.label_top_value_read_only6.setValue(this.webcamClass.Exposure.currentCtrlFlag.ToString());
                    break;
                }
                default :
                {
                    throw new ApplicationException("Not implemented");
                }
            }
        }

        private void WebcamSetupGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.webcamClass.stopWebcam();
        }
    }
}
