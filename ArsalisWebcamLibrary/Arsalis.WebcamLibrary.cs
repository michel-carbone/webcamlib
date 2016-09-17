/*
 * Created by SharpDevelop.
 * User: michel
 * Date: 9/09/2016
 * Time: 17:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Controls;
using AForge.Math;

namespace Arsalis.WebcamLibrary
{
	/// <summary>
	/// Description of Arsalis_WebcamLibrary.
	/// </summary>
	public class WebcamLibrary
	{
	    /// <summary>
	    /// default constructor
	    /// </summary>
		public WebcamLibrary()
		{
			loadWebcamDevices();
		} 
		
		/// <summary>
		/// array that contains name of all webcams connected to the computer
		/// </summary>
		public string [] WebcamListNames;
		
		/// <summary>
		/// array that contains monikerString
		/// </summary>
		public string [] webcamListMonikerString;
		
		/// <summary>
		/// collection of available video devices
		/// </summary>
        public FilterInfoCollection videoDevices;
        
        /// <summary>
        /// boolean that is set when one or more webcam are detected
        /// </summary>
        public bool webcamAvailable = false;
		
        
        /// <summary>
        /// video device selected for capture
        /// </summary>
        public VideoCaptureDevice videoDeviceForCapture;
        
        /// <summary>
        /// method that search for available webcams
        /// </summary>        
		private void loadWebcamDevices()
		{
			try
			{
                // enumerate video devices
                this.videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if ( this.videoDevices.Count == 0 )
                {
                    throw new ApplicationException( );
                }

                // add all devices to array
                WebcamListNames = new string[this.videoDevices.Count];
                webcamListMonikerString = new string[this.videoDevices.Count];
                int i = 0;
                foreach ( FilterInfo device in this.videoDevices )
                {
                	WebcamListNames[i] = device.Name;
                	webcamListMonikerString[i] = device.MonikerString;
                	i=++i;
                }
                
                this.webcamAvailable = true;
            }
            catch ( ApplicationException )
            {
                System.Console.WriteLine("No webcam found");
            }
		}
		
		/// <summary>
		/// start  capture of selected webcam
		/// </summary>
		public void startWebcam()
		{
			// TODO allow selection of webcam device if count > 1
			videoDeviceForCapture = new VideoCaptureDevice(webcamListMonikerString[0]);
    		videoDeviceForCapture.Start();
		}
		
		/// <summary>
		/// stop capture of selected webcam
		/// </summary>
		public void stopWebcam()
		{
			videoDeviceForCapture.Stop();
		}
	}
}
