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
        
        public int frameCount = 0;
		
        public string webcamName = "";
        /// <summary>
        /// video device selected for capture
        /// </summary>
        public VideoCaptureDevice videoDeviceForCapture;
        
        public string messages = "";
        
        public object [] images = new object [10000];
        
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
		///<param name="selectedCamera">
		///	position of selected camera in <see cref="WebcamListNames"></see></param>
		public void startWebcam(int selectedCamera)
		{
			// TODO allow selection of webcam device if count > 1
			videoDeviceForCapture = new VideoCaptureDevice(webcamListMonikerString[selectedCamera]);
			videoDeviceForCapture.Start();
            videoDeviceForCapture.NewFrame += new NewFrameEventHandler(videoDeviceForCapture_NewFrame);
            this.webcamName = WebcamListNames[selectedCamera];
		}

        void videoDeviceForCapture_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
        	this.frameCount = ++this.frameCount;
            DateTime now = DateTime.Now;
            messages += "Event in WebcamLibrary @ "+ now.ToString() + "::" + now.Millisecond.ToString() + ";\t frames received:" +this.frameCount.ToString()+"\r\n";
            System.Drawing.Bitmap copy = (System.Drawing.Bitmap)eventArgs.Frame.Clone();
            saveImage(copy, now);
        }
		
		/// <summary>
		/// stop capture of selected webcam
		/// </summary>
		public void stopWebcam()
		{
			videoDeviceForCapture.Stop();
		}
		
		private void saveImage(System.Drawing.Bitmap frameCopy, DateTime time)
		{
			string path = @"C:/Arsalis/capture_";
            path += time.ToLongDateString() + "_";
            path += time.Hour + "_";
            path += time.Minute + "_";
            path += time.Second + "_";
            path += time.Millisecond + ".jpeg";
            frameCopy.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            //System.Drawing.Image copyCompressed = (System.Drawing.Image)frameCopy.Clone();
			//this.images[frameCount] = new Bitmap(copyCompressed);
		}
		
		public delegate void WebcamEventsHandler(object source, WebcamEvent e);
		
	}
	
	public class WebcamEvent : EventArgs
	{
		private string EventInfo;
		
		public WebcamEvent(string Text)
		{
			EventInfo = Text;
		}
		
		public string GetInfo()
		{
			return EventInfo;
		}
	}
}
