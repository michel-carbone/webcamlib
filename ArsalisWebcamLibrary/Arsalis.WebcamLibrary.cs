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

        public System.Drawing.Bitmap lastImage = new System.Drawing.Bitmap(640, 480, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        
        public DateTime lastTimestamp;
        
        private AForge.Video.VFW.AVIWriter writer;
        
        System.Threading.Thread thread;

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
			videoDeviceForCapture.Start();
            videoDeviceForCapture.NewFrame += new NewFrameEventHandler(videoDeviceForCapture_NewFrame);
            initSaveVideo();
		}

        public void initDevice(int selectedCamera)
        {
            // TODO allow selection of webcam device if count > 1
            videoDeviceForCapture = new VideoCaptureDevice(webcamListMonikerString[selectedCamera]);
            this.webcamName = WebcamListNames[selectedCamera];
        }

        public void initSaveVideo()
        {
            // instantiate AVI writer, use WMV3 codec
            this.writer = new AForge.Video.VFW.AVIWriter("MSVC");
            // create new AVI file and open it
            string path = "C:/Arsalis/test_" + DateTime.Now.Minute.ToString() + ".avi";
            writer.Open(path, 640, 480);
        }

        void videoDeviceForCapture_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
        	this.frameCount = ++this.frameCount;
            DateTime now = DateTime.Now;
            messages += "Event in WebcamLibrary @ "+ now.ToString() + "::" + now.Millisecond.ToString() + ";\t frames received:" +this.frameCount.ToString()+"\r\n";
            System.Drawing.Bitmap copy = (System.Drawing.Bitmap)eventArgs.Frame.Clone();
            this.lastImage = new Bitmap(copy);
            this.lastTimestamp = now;
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
			Console.WriteLine("Height of last Image: " +this.lastImage.Height.ToString());
			Console.WriteLine("Width of last Image: " +this.lastImage.Width.ToString());
			Console.WriteLine("PropertyItems of last Image: ");
			for(int j=0; j<this.lastImage.PropertyItems.Length;j++)
			{	
				Console.WriteLine(this.lastImage.PropertyItems[j].ToString());
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
            this.Exposure.propertyType = CameraControlProperty.Exposure;
            //get property ranges
			this.videoDeviceForCapture.GetCameraPropertyRange(Exposure.propertyType, out Exposure.minValue, out Exposure.maxValue, out Exposure.stepSize, out Exposure.defaultValue, out Exposure.ctrFlag);
            
            Console.Write("minValue: " + Exposure.minValue.ToString() + "\r\n" +
                            "maxValue: " + Exposure.maxValue.ToString() + "\r\n" +
                            "stepSize: " + Exposure.stepSize.ToString() + "\r\n" +
                            "defaultValue: " + Exposure.defaultValue.ToString() + "\r\n" +   
                            "CameraControlFlags: " + Exposure.ctrFlag.ToString() + "\r\n");
            // get current property values
            this.videoDeviceForCapture.GetCameraProperty(Exposure.propertyType, out Exposure.currentValue, out Exposure.currentCtrlFlag);
            Console.Write("currentValue: " + Exposure.currentValue.ToString() + "\r\n" +
                             "currentCameraControlFlags: " + Exposure.currentCtrlFlag.ToString() + "\r\n");
            // check if property is adjustable
            Console.WriteLine("Property "+ Exposure.propertyType.ToString() + " is ajustable?: " + this.Exposure.isAdjustable.ToString());
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
