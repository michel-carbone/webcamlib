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
            	
            if(this.webcamClass.WebcamListNames.Length == 0)
            {
            	comboBox1.Items.Add("No webcam");
            	select_webcam_button.Enabled = false;
            	comboBox1.Enabled = false;
            }
            else
            {
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
                this.label_top_value_read_only7.setLabel("New resolution");
            }
            comboBox1.SelectedIndex = 0;
        }

        private void select_webcam_button_Click(object sender, EventArgs e)
        {
            // TODO select webcam
            this.comboBox2.Enabled = true;
            this.get_parameters_button.Enabled = true;
            // TODO get parameters from either Arsalis lib or AForge lib
            string [] cameraParameters = {"Exposure", "Focus", "Iris", "Pan", "Roll", "Tilt", "Zoom"};
            if(comboBox2.Items.Count == 0)
            {
	            for (int i = 0; i < cameraParameters.Length; i++)
	            {
	                comboBox2.Items.Add(cameraParameters[i]);
	            }
            }
        }

        private void get_parameters_button_Click(object sender, EventArgs e)
        {
            this.webcamClass.initDevice(comboBox1.SelectedIndex);
            switch(comboBox2.SelectedIndex)
            {
                case 0:
                {
            		show_param_values(this.webcamClass.parameters.Exposure);
            		break;
                }
            	case 1:
                {
					show_param_values(this.webcamClass.parameters.Focus);
            		break;                }
            	case 2:
                {
					show_param_values(this.webcamClass.parameters.Iris);
            		break;
            	}
            	case 3:
                {
					show_param_values(this.webcamClass.parameters.Pan);
            		break;
                }
            		case 4:
                {
					show_param_values(this.webcamClass.parameters.Roll);
            		break;
                }
            	case 5:
                {
					show_param_values(this.webcamClass.parameters.Tilt);
            		break;
                }
				case 6:
                {
					show_param_values(this.webcamClass.parameters.Zoom);
            		break;
                }
            	default :
                {
                    throw new ApplicationException("Not implemented");
                }
            }
            this.comboBox3.Enabled = true;
            this.button1.Enabled = true;
            this.webcamClass.GetFrameResolutions();
            for (int i = 0; i < this.webcamClass.webcamResolutions.Length; i++)
            {
                comboBox3.Items.Add(this.webcamClass.webcamResolutions[i].ToString());
            }
        }

        private void show_param_values(CameraParam webcamParam)
        {
        	webcamParam = this.webcamClass.getParameter(webcamParam);
            this.label_top_value_read_only1.setValue(webcamParam.minValue);
            this.label_top_value_read_only2.setValue(webcamParam.defaultValue);
            this.label_top_value_read_only3.setValue(webcamParam.maxValue);
            this.label_top_value_read_only4.setValue(webcamParam.ctrFlag.ToString());
            this.label_top_value_read_only5.setValue(webcamParam.currentValue);
            this.label_top_value_read_only6.setValue(webcamParam.currentCtrlFlag.ToString());
            this.label1.Text = webcamParam.propertyType.ToString();
        }

        private void WebcamSetupGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.webcamClass.stopWebcam();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.webcamClass.setFrameResolution(this.webcamClass.webcamResolutions[comboBox3.SelectedIndex]);
            string newResolution = this.webcamClass.videoDeviceForCapture.VideoResolution.FrameSize.ToString();
            this.label_top_value_read_only7.setValue(newResolution);
        }
    }
}
