/*
 * Created by SharpDevelop.
 * User: michel
 * Date: 27/09/2016
 * Time: 17:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Arsalis.WebcamLibrary
{
    /// <summary>
    /// structure that contains all parameters returned by GetCameraPropertyRange for a parameter
    /// </summary>
    public struct CameraParam
    {
        /// <summary>
        /// minimum value of the parameter
        /// </summary>
        public int minValue;

        /// <summary>
        /// maximum value of the parameter
        /// </summary>
        public int maxValue;

        /// <summary>
        /// increment allowed between min and max values
        /// </summary>
        public int stepSize;

        /// <summary>
        /// default value of the specified parameter
        /// </summary>
        public int defaultValue;

        /// <summary>
        /// available control flag for the specified parameter
        /// </summary>
        public AForge.Video.DirectShow.CameraControlFlags ctrFlag;

        /// <summary>
        /// The current value of the parameter
        /// </summary>
        public int currentValue;

        /// <summary>
        /// current control flag of the specified parameter
        /// if "None", the parameter cannot be changed manually
        /// if "Auto", the parameter is changed by the webcam automatically
        /// if "Manual", a value has been set by the user
        /// </summary>
        public AForge.Video.DirectShow.CameraControlFlags currentCtrlFlag;

        /// <summary>
        /// property type of current structure
        /// </summary>
        public AForge.Video.DirectShow.CameraControlProperty propertyType;

        /// <summary>
        /// bool that say if selected parameter is ajustable
        /// </summary>
        public bool isAdjustable
        {
            get
            {
                if (this.ctrFlag != AForge.Video.DirectShow.CameraControlFlags.None)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CameraParam"/> struct.
        /// </summary>
        /// <param name="property">Set type of camera control property.</param>
        public CameraParam(AForge.Video.DirectShow.CameraControlProperty property)
        {
            this.propertyType = property;
            this.minValue = int.MinValue;
            this.maxValue = int.MaxValue;
            this.defaultValue = 0;
            this.stepSize = 0;
            this.ctrFlag = AForge.Video.DirectShow.CameraControlFlags.None;
            this.currentCtrlFlag = AForge.Video.DirectShow.CameraControlFlags.None;
            this.currentValue = 0;
        }
    }
}
