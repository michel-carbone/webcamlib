/*
 * Created by SharpDevelop.
 * User: michel
 * Date: 4/10/2016
 * Time: 17:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Arsalis.WebcamLibrary
{
	/// <summary>
	/// Description of WebcamParameters.
	/// </summary>
	public class WebcamParameters
	{
		/// <summary>
        /// structure containing webcam Exposure parameters
        /// </summary>
        public CameraParam Exposure = new CameraParam(AForge.Video.DirectShow.CameraControlProperty.Exposure);

        /// <summary>
        /// structure containing webcam Focus parameters
        /// </summary>
        public CameraParam Focus = new CameraParam(AForge.Video.DirectShow.CameraControlProperty.Focus);

        /// <summary>
        /// structure containing webcam Iris parameters
        /// </summary>
        public CameraParam Iris = new CameraParam(AForge.Video.DirectShow.CameraControlProperty.Iris);

        /// <summary>
        /// structure containing webcam Pan parameters
        /// </summary>
        public CameraParam Pan = new CameraParam(AForge.Video.DirectShow.CameraControlProperty.Pan);

        /// <summary>
        /// structure containing webcam Roll parameters
        /// </summary>
        public CameraParam Roll = new CameraParam(AForge.Video.DirectShow.CameraControlProperty.Roll);

        /// <summary>
        /// structure containing webcam Tilt parameters
        /// </summary>
        public CameraParam Tilt = new CameraParam(AForge.Video.DirectShow.CameraControlProperty.Tilt);

        /// <summary>
        /// structure containing webcam Zoom parameters
        /// </summary>
        public CameraParam Zoom = new CameraParam(AForge.Video.DirectShow.CameraControlProperty.Zoom);

        /// <summary>
        /// VideoCapabilities of selected webcam
        /// </summary>
        public AForge.Video.DirectShow.VideoCapabilities capabilities;

        /// <summary>
        /// Gets the name of the camera parameters.
        /// </summary>
        /// <returns>string array containing all camera parameters names</returns>
        public string[] getCameraParametersName()
        {

            string[] temp = new string[100];
            int i = 0;
            foreach (AForge.Video.DirectShow.CameraControlProperty param in AForge.Video.DirectShow.CameraControlProperty.GetValues(typeof(AForge.Video.DirectShow.CameraControlProperty)))
            {
                temp[i] = param.ToString();
                i = ++i;
            }
            string[] parameters = new string[i];
            for (i = 0; i < parameters.Length; i++)
            {
                parameters[i] = temp[i];
            }
            return parameters;
        }
	}
}
