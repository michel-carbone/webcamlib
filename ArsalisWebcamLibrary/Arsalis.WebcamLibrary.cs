/*
 * Created by SharpDevelop.
 * User: michel
 * Date: 9/09/2016
 * Time: 17:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Controls;
using AForge.Math;
using System.Threading;

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
        private FilterInfoCollection videoDevices;
        
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

        /// <summary>
        /// class containing all struct CameraParam objects
        /// </summary>
        public Arsalis.WebcamLibrary.WebcamParameters parameters = new WebcamParameters();

        public Size[] webcamResolutions;

        private Dictionary<string, VideoCapabilities> videoCapabilitiesDictionary = new Dictionary<string, VideoCapabilities>();
        
        
        private AForge.Video.VFW.AVIWriter writer;

        System.Threading.Thread thread;

        private Arsalis.WebcamLibrary.WebcamImage lastImage;

        private void WorkThreadFunction(object webcamImage)
		{
            WebcamImage lastImageObj = webcamImage as WebcamImage;
            Bitmap lastBitmap = lastImageObj.image;
            DateTime lastTimestamp = lastImageObj.timestamp;
            int frameCount = lastImageObj.frameCount;
            saveImage(lastBitmap, lastTimestamp);
            this.messages += "This text was set by WorkThreadFunction, frame number: " + frameCount.ToString() + ".\r\n";
		}
        
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
            initDevice(selectedCamera);
            startAcquisition();
            //initSaveVideo();
		}

        public void initDevice(int selectedCamera)
        {
            // TODO allow selection of webcam device if count > 1
            videoDeviceForCapture = new VideoCaptureDevice(webcamListMonikerString[selectedCamera]);
            this.webcamName = WebcamListNames[selectedCamera];
        }

        public void startAcquisition()
        {
            videoDeviceForCapture.Start();
            videoDeviceForCapture.NewFrame += new NewFrameEventHandler(videoDeviceForCapture_NewFrame);
        }

        public void initSaveVideo()
        {
            // instantiate AVI writer, use WMV3 codec
            this.writer = new AForge.Video.VFW.AVIWriter("MSVC");
            // create new AVI file and open it
            string path = "C:/Arsalis/test_" + DateTime.Now.Minute.ToString() + ".avi";
            int width = this.videoDeviceForCapture.VideoResolution.FrameSize.Width;
            int height = this.videoDeviceForCapture.VideoResolution.FrameSize.Height;
            writer.Open(path, width, height);
        }

        void videoDeviceForCapture_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
        	this.frameCount = ++this.frameCount;
            DateTime now = DateTime.Now;
            messages += "Event in WebcamLibrary @ "+ now.ToString() + "::" + now.Millisecond.ToString() + ";\t frames received:" +this.frameCount.ToString()+"\r\n";
            System.Drawing.Bitmap copy = (System.Drawing.Bitmap)eventArgs.Frame.Clone();
            this.lastImage.image = new Bitmap(copy);
            this.lastImage.timestamp = now;
            WebcamImage lastImageObj = new WebcamImage();
            lastImageObj.image = new Bitmap(copy);
            lastImageObj.timestamp = now;
            lastImageObj.frameCount = this.frameCount;
            //saveImage(copy, now);

            ThreadPool.QueueUserWorkItem(new WaitCallback(WorkThreadFunction), lastImageObj);
            //this.thread = new Thread(new ThreadStart(WorkThreadFunction));
            thread.Start();
        }
		
		/// <summary>
		/// stop capture of selected webcam
		/// </summary>
		public void stopWebcam()
		{
			messages += this.videoDeviceForCapture.FramesReceived.ToString() + " frames received before SignalToStop\r\n";
			videoDeviceForCapture.SignalToStop();
			Console.WriteLine("Height of last Image: " +this.lastImage.image.Height.ToString());
			Console.WriteLine("Width of last Image: " +this.lastImage.image.Width.ToString());
			Console.WriteLine("PropertyItems of last Image: ");
			for(int j=0; j<this.lastImage.image.PropertyItems.Length;j++)
			{	
				Console.WriteLine(this.lastImage.image.PropertyItems[j].ToString());
			}
			videoDeviceForCapture.WaitForStop();
			messages += this.videoDeviceForCapture.FramesReceived.ToString() + " frames received after WaitForStop\r\n";
            if (this.writer != null)
            {
                this.writer.Close();
            }
		}
		
		/// <summary>
		/// get Exposure parameters of selected webcam
		/// </summary>
		public void getExposureParameters()
		{
            // set property type of structure
            this.parameters.Exposure.propertyType = CameraControlProperty.Exposure;
            //get property ranges
			this.videoDeviceForCapture.GetCameraPropertyRange(this.parameters.Exposure.propertyType, out this.parameters.Exposure.minValue, out this.parameters.Exposure.maxValue, out this.parameters.Exposure.stepSize, out this.parameters.Exposure.defaultValue, out this.parameters.Exposure.ctrFlag);
            
            Console.Write("minValue: " + this.parameters.Exposure.minValue.ToString() + "\r\n" +
                            "maxValue: " + this.parameters.Exposure.maxValue.ToString() + "\r\n" +
                            "stepSize: " + this.parameters.Exposure.stepSize.ToString() + "\r\n" +
                            "defaultValue: " + this.parameters.Exposure.defaultValue.ToString() + "\r\n" +   
                            "CameraControlFlags: " + this.parameters.Exposure.ctrFlag.ToString() + "\r\n");
            // get current property values
            this.videoDeviceForCapture.GetCameraProperty(this.parameters.Exposure.propertyType, out this.parameters.Exposure.currentValue, out this.parameters.Exposure.currentCtrlFlag);
            Console.Write("currentValue: " + this.parameters.Exposure.currentValue.ToString() + "\r\n" +
                             "currentCameraControlFlags: " + this.parameters.Exposure.currentCtrlFlag.ToString() + "\r\n");
            // check if property is adjustable
            Console.WriteLine("Property "+ this.parameters.Exposure.propertyType.ToString() + " is ajustable?: " + this.parameters.Exposure.isAdjustable.ToString());
		}

		/// <summary>
		/// get parameters of selected webcam
		/// </summary>
		public CameraParam getParameter(CameraParam property)
		{
			try
			{
	            //get property ranges
				this.videoDeviceForCapture.GetCameraPropertyRange(property.propertyType, out property.minValue, out property.maxValue, out property.stepSize, out property.defaultValue, out property.ctrFlag);
	            
	            Console.Write("minValue: " + property.minValue.ToString() + "\r\n" +
	                            "maxValue: " + property.maxValue.ToString() + "\r\n" +
	                            "stepSize: " + property.stepSize.ToString() + "\r\n" +
	                            "defaultValue: " + property.defaultValue.ToString() + "\r\n" +   
	                            "CameraControlFlags: " + property.ctrFlag.ToString() + "\r\n");
	            // get current property values
	            this.videoDeviceForCapture.GetCameraProperty(property.propertyType, out property.currentValue, out property.currentCtrlFlag);
	            Console.Write("currentValue: " + property.currentValue.ToString() + "\r\n" +
	                             "currentCameraControlFlags: " + property.currentCtrlFlag.ToString() + "\r\n");
	            // check if property is adjustable
	            Console.WriteLine("Property "+ property.propertyType.ToString() + " is ajustable?: " + property.isAdjustable.ToString());
			}
			catch
			{
				throw new Exception("Error in type");
			}
			return property;
		}
		
        /// <summary>
        /// set webcam property
        /// </summary>
        /// <param name="property">property to adjust</param>
        /// <param name="propertyValue">desired value of property</param>
        public void setCameraParameter(CameraControlProperty property, int propertyValue)
        {
            this.videoDeviceForCapture.SetCameraProperty(property, propertyValue, CameraControlFlags.Manual);
        }

        public void setFrameResolution(Size resolution)
        {
            //VideoCapabilities caps = this.videoDeviceForCapture.VideoCapabilities;
            string key = resolution.Width.ToString() + " x " + resolution.Height.ToString();

            this.parameters.capabilities = videoCapabilitiesDictionary[key];
            //caps.FrameSize = resolution;
            // TODO DEBUG: this.videoDeviceForCapture.VideoResolution is null when get parameter is called a second time
            Console.WriteLine("Frame size: " + this.videoDeviceForCapture.VideoResolution.FrameSize.ToString());

            //this.videoDeviceForCapture.VideoResolution = this.videoDeviceForCapture.VideoCapabilities[3];
            this.videoDeviceForCapture.VideoResolution = this.parameters.capabilities;
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Frame size: " + this.videoDeviceForCapture.VideoResolution.FrameSize.ToString());
        }
		
		/// <summary>
		/// Save image to disk
		/// </summary>
		/// <param name="frameCopy">Bitmap frame to save</param>
		/// <param name="time">time when image is captured</param>
		private void saveImage(System.Drawing.Bitmap frameCopy, DateTime time)
		{
			string path = @"C:/Arsalis/capture_";
            path += time.ToLongDateString() + "_";
            path += time.Hour + "_";
            path += time.Minute + "_";
            path += time.Second + "_";
            path += time.Millisecond + ".jpeg";
            frameCopy.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            //this.lastImage = new Bitmap(frameCopy);
            //writer.AddFrame(frameCopy);
            //System.Drawing.Image copyCompressed = (System.Drawing.Image)frameCopy.Clone();
			//this.images[frameCount] = new Bitmap(copyCompressed);
		}
		
		public void GetFrameResolutions()
		{
            
			try
            {
				VideoCapabilities [] videoCapabilities = this.videoDeviceForCapture.VideoCapabilities;
                this.webcamResolutions = new Size[videoCapabilities.Length];

				for(int i = 0; i < videoCapabilities.Length; i++)
                {
                    int width = videoCapabilities[i].FrameSize.Width;
                    int height = videoCapabilities[i].FrameSize.Height;
                    Console.WriteLine(videoCapabilities[i].FrameSize.ToString());
                    string item = string.Format("{0} x {1}", width,height );
                	Console.WriteLine(item);
                
                    if (!videoCapabilitiesDictionary.ContainsKey(item))
                    {
                        videoCapabilitiesDictionary.Add(item, videoCapabilities[i]);
                        this.webcamResolutions[i] = new Size(width, height);
                    }
                }
			}
			catch
            {
                messages += "Exception in GetFrameResolutions method";
            }
            this.videoDeviceForCapture.VideoResolution = videoCapabilitiesDictionary["640 x 480"];
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
