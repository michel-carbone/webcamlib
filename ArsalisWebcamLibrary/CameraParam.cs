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
    }
}
