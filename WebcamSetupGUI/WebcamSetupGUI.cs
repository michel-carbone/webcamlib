using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AForge.Video;

namespace Arsalis.WebcamLibrary
{
    public partial class WebcamSetupGUI : Form
    {
        private Arsalis.WebcamLibrary.WebcamLibrary webcamClass;
        
        /// <summary>
        /// default constructor
        /// </summary>
        public WebcamSetupGUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method called at load of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebcamSetupGUI_Load(object sender, EventArgs e)
        {
            initWebcamSetupGUI();
        }

        /// <summary>
        /// Method that create a new webcam object and update the form
        /// </summary>
        private void initWebcamSetupGUI()
        {
            this.webcamClass = new Arsalis.WebcamLibrary.WebcamLibrary();
            	
            if(this.webcamClass.WebcamListNames.Length == 0)
            {
            	comboBox1.Items.Add("No webcam");
            	select_webcam_button.Enabled = false;
            	comboBox1.Enabled = false;
                displayState();
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
                
                displayState();
            }
            comboBox1.SelectedIndex = 0;
        }

        /// <summary>
        /// method that enable or disable parts of GUI upon webcam presence
        /// </summary>
        private void displayState()
        {
            bool enabled = this.webcamClass.IsAvailable;
            this.select_webcam_button.Enabled = enabled;
            this.comboBox1.Enabled = enabled;
            this.comboBox3.Enabled = enabled;
            this.comboBox2.Enabled = enabled;
            this.comboBox4.Enabled = enabled;
            this.get_parameters_button.Enabled = enabled;
            this.set_parameter_button.Enabled = enabled;
        }

        /// <summary>
        /// Method that clear all field of the GUI before an update of selected webcam
        /// </summary>
        private void clearFields()
        {
            clearComboBox(this.comboBox1);
            clearComboBox(this.comboBox2);
            clearComboBox(this.comboBox3);
            clearComboBox(this.comboBox4);
            clearComboBox(this.comboBox5);
            this.label_top_value_read_only7.textBox1.Clear();
        }

        /// <summary>
        /// Method that clear items and text of a comboBox
        /// </summary>
        /// <param name="combo">The comboBox to clear</param>
        private void clearComboBox(ComboBox combo)
        {
            combo.Items.Clear();
            combo.Text = "";
        }

        /// <summary>
        /// Select a webcam, add parameter to comboBoxes and init selected webcam
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void select_webcam_button_Click(object sender, EventArgs e)
        {
            // TODO select webcam
            displayState();
            // TODO get parameters from either Arsalis lib or AForge lib

            string [] cameraParameters = this.webcamClass.parameters.getCameraParametersName();
            clearComboBox(comboBox2);
            clearComboBox(comboBox4);
            for (int i = 0; i < cameraParameters.Length; i++)
            {
                comboBox2.Items.Add(cameraParameters[i]);
                comboBox4.Items.Add(cameraParameters[i]);
            }
            comboBox2.Sorted = true;
            comboBox4.Sorted = true;
            this.webcamClass.initDevice(comboBox1.SelectedIndex, false);
        }

        /// <summary>
        /// Get parameters from selected combo box item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void get_parameters_button_Click(object sender, EventArgs e)
        {
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
            this.set_resolution_button.Enabled = true;
            // test if combobox was not populated before by another get_parameters_button_Click
            if (comboBox3.Items.Count == 0)
            {
                this.webcamClass.GetFrameResolutions();
                for (int i = 0; i < this.webcamClass.webcamResolutions.Length; i++)
                {
                    comboBox3.Items.Add(this.webcamClass.webcamResolutions[i].ToString());
                }
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

        private void set_resolution_button_Click(object sender, EventArgs e)
        {
            this.webcamClass.setFrameResolution(this.webcamClass.webcamResolutions[comboBox3.SelectedIndex]);
            string newResolution = this.webcamClass.videoDeviceForCapture.VideoResolution.FrameSize.ToString();
            this.label_top_value_read_only7.setValue(newResolution);
        }

        private void start_webcam_button_Click(object sender, EventArgs e)
        {
            this.stop_webcam_button.Enabled = true;
            this.start_webcam_button.Enabled = false;
            this.webcamClass.startAcquisition();
        }

        private void stop_webcam_button_Click(object sender, EventArgs e)
        {
            this.stop_webcam_button.Enabled = false;
            this.start_webcam_button.Enabled = true;
            this.webcamClass.stopWebcam();
        }

        //public delegate void WebcamEventsHandler(object source, NewFrameImageEventArgs e);

        private void refresh_webcamList_button_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            clearFields();
            initWebcamSetupGUI();
        }

        private void set_parameter_button_Click(object sender, EventArgs e)
        {
            this.label2.Text = this.comboBox4.SelectedItem.ToString();
            switch (comboBox4.SelectedIndex)
            {
                case 0:
                    {
                        this.webcamClass.setCameraParameter(AForge.Video.DirectShow.CameraControlProperty.Exposure, this.label_top_numeric1.getIntValue());
                        break;
                    }
                case 1:
                    {
                        this.webcamClass.setCameraParameter(AForge.Video.DirectShow.CameraControlProperty.Focus, this.label_top_numeric1.getIntValue());
                        break;
                    }
                case 2:
                    {
                        this.webcamClass.setCameraParameter(AForge.Video.DirectShow.CameraControlProperty.Iris, this.label_top_numeric1.getIntValue());
                        break;
                    }
                case 3:
                    {
                        this.webcamClass.setCameraParameter(AForge.Video.DirectShow.CameraControlProperty.Pan, this.label_top_numeric1.getIntValue());
                        break;
                    }
                case 4:
                    {
                        this.webcamClass.setCameraParameter(AForge.Video.DirectShow.CameraControlProperty.Roll, this.label_top_numeric1.getIntValue());
                        break;
                    }
                case 5:
                    {
                        this.webcamClass.setCameraParameter(AForge.Video.DirectShow.CameraControlProperty.Tilt, this.label_top_numeric1.getIntValue());
                        break;
                    }
                case 6:
                    {
                        this.webcamClass.setCameraParameter(AForge.Video.DirectShow.CameraControlProperty.Zoom, this.label_top_numeric1.getIntValue());
                        break;
                    }
                default:
                    {
                        throw new ApplicationException("Not implemented");
                    }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox5.Items.Clear();
                switch (comboBox4.SelectedIndex)
                {
                    case 0:
                        {
                            this.comboBox5.Items.Add(this.webcamClass.parameters.Exposure.ctrFlag);
                            this.label_top_numeric1.setMinMax(this.webcamClass.parameters.Exposure.minValue,
                                this.webcamClass.parameters.Exposure.maxValue);
                            this.label_top_numeric1.setValue(this.webcamClass.parameters.Exposure.currentValue);
                            break;
                        }
                    case 1:
                        {
                            this.comboBox5.Items.Add(this.webcamClass.parameters.Focus.ctrFlag);
                            this.label_top_numeric1.setMinMax(this.webcamClass.parameters.Focus.minValue,
                                this.webcamClass.parameters.Focus.maxValue);
                            this.label_top_numeric1.setValue(this.webcamClass.parameters.Focus.currentValue);
                            break;
                        }
                    case 2:
                        {
                            this.comboBox5.Items.Add(this.webcamClass.parameters.Iris.ctrFlag);
                            this.label_top_numeric1.setMinMax(this.webcamClass.parameters.Iris.minValue,
                                this.webcamClass.parameters.Iris.maxValue);
                            this.label_top_numeric1.setValue(this.webcamClass.parameters.Iris.currentValue);
                            break;
                        }
                    case 3:
                        {
                            this.comboBox5.Items.Add(this.webcamClass.parameters.Pan.ctrFlag);
                            this.label_top_numeric1.setMinMax(this.webcamClass.parameters.Pan.minValue,
                                this.webcamClass.parameters.Pan.maxValue);
                            this.label_top_numeric1.setValue(this.webcamClass.parameters.Pan.currentValue);
                            break;
                        }
                    case 4:
                        {
                            this.comboBox5.Items.Add(this.webcamClass.parameters.Roll.ctrFlag);
                            this.label_top_numeric1.setMinMax(this.webcamClass.parameters.Roll.minValue,
                                this.webcamClass.parameters.Roll.maxValue);
                            this.label_top_numeric1.setValue(this.webcamClass.parameters.Roll.currentValue);
                            break;
                        }
                    case 5:
                        {
                            this.comboBox5.Items.Add(this.webcamClass.parameters.Tilt.ctrFlag);
                            this.label_top_numeric1.setMinMax(this.webcamClass.parameters.Tilt.minValue,
                                this.webcamClass.parameters.Tilt.maxValue);
                            this.label_top_numeric1.setValue(this.webcamClass.parameters.Tilt.currentValue);
                            break;
                        }
                    case 6:
                        {
                            this.comboBox5.Items.Add(this.webcamClass.parameters.Zoom.ctrFlag);
                            this.label_top_numeric1.setMinMax(this.webcamClass.parameters.Zoom.minValue,
                                this.webcamClass.parameters.Zoom.maxValue);
                            this.label_top_numeric1.setValue(this.webcamClass.parameters.Zoom.currentValue);
                            break;
                        }
                    default:
                        {
                            throw new ApplicationException("Not implemented");
                        }
                }
                this.comboBox5.SelectedIndex = 0;
            }
            catch (ApplicationException appEx)
            {
                MessageBox.Show("Error in comboBox4_SelectedIndexChanged\n" + appEx.Message);
            }
        }

        private void show_button_Click(object sender, EventArgs e)
        {
            Arsalis.WebcamLibrary.Test.GUI testGUI = new Arsalis.WebcamLibrary.Test.GUI(this.webcamClass);
            // set GUI videoDevice to selected videoDevice of test webcam class
            //testGUI.OpenVideoSource(this.webcamClass.videoDeviceForCapture);
            testGUI.Show();
        }
    }
}
