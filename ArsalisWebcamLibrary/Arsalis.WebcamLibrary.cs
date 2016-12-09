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
    /// This library encapsulate the AForge libraries that allow to:
    /// - get and set settings from a video capture device
    /// - keep a copy of these settings
    /// - subscribe to the NewFrameEvent of a video capture device and record time of the event
    /// This library create a new event at each new frame from video capture device
    /// 
    /// This event make the following operations
    /// - create two copies of the frame and a copy of the timestamp of the NewFrame event
    /// - save a copy of the image in JPEG if desired
    /// - show a copy of the frame to a GUI
	/// </summary>
	public class WebcamLibrary
	{
	    /// <summary>
	    /// Constructor of WebcamLibrary object.
        /// Search at construction of webcams connected to the computer and set properties
        /// related to webcams and availability of webcams. Parameters are not yet get from webcam.
	    /// </summary>
		public WebcamLibrary()
		{
			loadWebcamDevices();
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
		}

        /// <summary>
        /// Bool property, TRUE if there is a webcam connected
        /// It is the public field of <see cref="webcamAvailable"/>.
        /// This property is set at construction with <see cref="WebcamLibrary"/> 
        /// and <see cref="loadWebcamDevices"/> and is read-only.
        /// </summary>
        public bool IsAvailable
        {
            get
            {
                return webcamAvailable;
            }
        } 
		
		/// <summary>
		/// Array that contains name of all webcams connected to the computer
		/// </summary>
		public string [] WebcamListNames;
		
		/// <summary>
		/// Array that contains monikerString of all connected webcams to the computer
		/// </summary>
		public string [] webcamListMonikerString;
		
		/// <summary>
		/// Collection of available video devices connected to the computer
		/// </summary>
        private FilterInfoCollection videoDevices;
        
        /// <summary>
        /// Boolean that is set when one or more webcam are detected
        /// </summary>
        private bool webcamAvailable = false;
        
        /// <summary>
        /// Number of frame received from the initialisation of the object. It is not reset
        /// by reading the value like <see cref="AForge.Video.VideoCaptureDevice.FramesReceived"/>.
        /// </summary>
        public int frameCount = 0;
		
        /// <summary>
        /// Name of the selected webcam
        /// </summary>
        public string webcamName = "";

        /// <summary>
        /// video device selected for capture
        /// </summary>
        public VideoCaptureDevice videoDeviceForCapture;

        //public string messages = "";

        /// <summary>
        /// class containing all struct CameraParam objects
        /// </summary>
        public Arsalis.WebcamLibrary.WebcamParameters parameters = new WebcamParameters();

        /// <summary>
        /// Array containing all resolutions of selected webcam
        /// </summary>
        public Size[] webcamResolutions;

        /// <summary>
        /// Dictionnary containing all videoCapabilities of the selected webcam
        /// </summary>
        private Dictionary<string, VideoCapabilities> videoCapabilitiesDictionary = new Dictionary<string, VideoCapabilities>();
        
        /// <summary>
        /// AVIWriter
        /// </summary>
        private AForge.Video.VFW.AVIWriter writer;

        //System.Threading.Thread thread; // not used

        //public Arsalis.WebcamLibrary.WebcamImage lastImage = new WebcamImage(); // not used
        
        //private Arsalis.WebcamLibrary.WebcamImage imageToDisk = new WebcamImage(); // not used
        
        /// <summary>
        /// Instance of ConsoleDebugger for exception print details to Console and colored messages
        /// </summary>
        public Arsalis.WebcamLibrary.ConsoleDebugger ConsoleBuddy = new Arsalis.WebcamLibrary.ConsoleDebugger();

        /// <summary>
        /// Calculated frame rate from webcam on 1 second
        /// </summary>
        public double frameRate;

        private System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private double elapsedTime = 0;
        /*private void WorkThreadFunction(object webcamImage)
		{
            try
            {
                this.lastImage = webcamImage as WebcamImage;
                this.imageToDisk = webcamImage as WebcamImage;
                Bitmap lastBitmap = imageToDisk.image;
                DateTime lastTimestamp = imageToDisk.timestamp;
                int frameCount = imageToDisk.frameCount;
                saveImage(lastBitmap, lastTimestamp);
                ConsoleBuddy.WriteLine("This text was set by WorkThreadFunction, frame number: " + frameCount.ToString());
                //new NewFrameImageEventArgs("New image arrived, number " + this.frameCount.ToString());
            }
            catch (ApplicationException appEx)
            {
                ConsoleBuddy.WriteException(appEx, "WorkThreadFunction");
            }
            catch (SystemException sysEx)
            {
                ConsoleBuddy.WriteException(sysEx, "WorkThreadFunction");
            }
		}*/
        
        /// <summary>
        /// method that search for available webcams
        /// if one or more webcams are available:
        /// - save their name in <see cref="WebcamListNames"/>
        /// - save their monikerName in <see cref="webcamListMonikerString"/>
        /// - set bool <see cref="webcamAvailable"/> to TRUE
        /// </summary>        
		private void loadWebcamDevices()
		{
            try
            {
                // enumerate video devices
                this.videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (this.videoDevices.Count == 0)
                {
                    this.webcamAvailable = false;
                    //throw new ApplicationException();
                }
                else
                {
                    this.webcamAvailable = true;
                }
                // add all devices to array
                WebcamListNames = new string[this.videoDevices.Count];
                webcamListMonikerString = new string[this.videoDevices.Count];
                int i = 0;
                foreach (FilterInfo device in this.videoDevices)
                {
                    WebcamListNames[i] = device.Name;
                    webcamListMonikerString[i] = device.MonikerString;
                    i = ++i;
                }
            }
            catch (ApplicationException appEx)
            {
                ConsoleBuddy.WriteException(appEx, "loadWebcamDevices");
            }
            catch (SystemException sysEx)
            {
                ConsoleBuddy.WriteException(sysEx, "loadWebcamDevices");
            }
		}
		
		/// <summary>
		/// start  capture of selected webcam
		/// </summary>
		///<param name="selectedCamera">
		///	position of selected camera in <see cref="WebcamListNames"></see></param>
		public void startWebcam(int selectedCamera)
		{
            try
            {
                initDevice(selectedCamera, false);
                startAcquisition();
            }
            catch (ApplicationException e)
            {
                System.Console.WriteLine("Exception in startWebcam method:\n" + e.Message);
            }
		}

        /// <summary>
        /// configure selected camera
        /// </summary>
        /// <param name="selectedCamera">integer representing selected webcam</param>
        /// <param name="initVideo">bool, if set: init video</param>
        public void initDevice(int selectedCamera, bool initVideo)
        {
            try
            {
                this.videoDeviceForCapture = new VideoCaptureDevice(webcamListMonikerString[selectedCamera]);
                this.webcamName = WebcamListNames[selectedCamera];

                this.getAllParameters();

                if (initVideo)
                {
                    initSaveVideo();
                }
            }
            catch (ApplicationException appEx)
            {
                ConsoleBuddy.WriteException(appEx, "initDevice");
            }
            catch (SystemException sysEx)
            {
                ConsoleBuddy.WriteException(sysEx, "initDevice");
            }
        }

        /// <summary>
        /// Method that set all parameters of camera into the object
        /// </summary>
        private void getAllParameters()
        {
            try
            {
                this.parameters.Exposure = this.getParameter(this.parameters.Exposure);
                this.parameters.Focus = this.getParameter(this.parameters.Focus);
                this.parameters.Iris = this.getParameter(this.parameters.Iris);
                this.parameters.Pan = this.getParameter(this.parameters.Pan);
                this.parameters.Roll = this.getParameter(this.parameters.Roll);
                this.parameters.Tilt = this.getParameter(this.parameters.Tilt);
                this.parameters.Zoom = this.getParameter(this.parameters.Zoom);
            }
            catch (ApplicationException appEx)
            {
                ConsoleBuddy.WriteException(appEx, "getAllParameters");
            }
            catch (SystemException sysEx)
            {
                ConsoleBuddy.WriteException(sysEx, "getAllParameters");
            }
        }

        /// <summary>
        /// start acquisition of webcam
        /// </summary>
        public void startAcquisition()
        {
            try
            {
                if (videoDeviceForCapture != null)
                {
                    this.videoDeviceForCapture.NewFrame += new NewFrameEventHandler(this.videoDeviceForCapture_NewFrame);
                    this.videoDeviceForCapture.Start();
                }
                else
                {
                    new ApplicationException("videoDeviceForCapture is NULL");
                }
                this.timer.Start();
                this.stopWatch.Start();
            }
            catch (ApplicationException appEx)
            {
                ConsoleBuddy.WriteException(appEx, "startAcquisition");
            }
            catch (SystemException sysEx)
            {
                ConsoleBuddy.WriteException(sysEx, "startAcquisition");
            }
        }

        /// <summary>
        /// method that initialize saving a video file to disk
        /// </summary>
        public void initSaveVideo()
        {
            try
            {
                // instantiate AVI writer, use WMV3 codec
                this.writer = new AForge.Video.VFW.AVIWriter("MSVC");
                // create new AVI file and open it
                string path = "C:/Arsalis/test_" + DateTime.Now.Minute.ToString() + ".avi";
                int width = this.videoDeviceForCapture.VideoResolution.FrameSize.Width;
                int height = this.videoDeviceForCapture.VideoResolution.FrameSize.Height;
                writer.Open(path, width, height);
            }
            catch (ApplicationException appEx)
            {
                ConsoleBuddy.WriteException(appEx, "initSaveVideo");
            }
            catch (SystemException sysEx)
            {
                ConsoleBuddy.WriteException(sysEx, "initSaveVideo");
            }
        }

        void videoDeviceForCapture_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                int videoDeviceFramesReceived = this.videoDeviceForCapture.FramesReceived;
                if (videoDeviceFramesReceived <= 1)
                {
                    ConsoleBuddy.WriteLineGreen("Number of frames received from last NewFrame event: " + videoDeviceFramesReceived.ToString());
                }
                else
                {
                    ConsoleBuddy.WriteLineRed("Number of frames received from last NewFrame event: " + videoDeviceFramesReceived.ToString());
                }
                this.frameCount = ++this.frameCount;
                DateTime now = DateTime.Now;
                //messages += "Event in WebcamLibrary @ " + now.ToString() + "::" + now.Millisecond.ToString() + ";\t frames received:" + this.frameCount.ToString() + "\r\n";
                System.Drawing.Bitmap copy = (System.Drawing.Bitmap)eventArgs.Frame.Clone();
      /*          this.lastImage = new WebcamImage();
                this.lastImage.image = new Bitmap(copy);
                this.lastImage.timestamp = now;*/
                WebcamImage lastImageObj = new WebcamImage();
                lastImageObj.image = new Bitmap(copy);
                lastImageObj.timestamp = now;
                lastImageObj.frameCount = this.frameCount;
                //saveImage(copy, now);
                // 21/11/2016 commented ThreadPool call
                //ThreadPool.QueueUserWorkItem(new WaitCallback(WorkThreadFunction), lastImageObj);
                //
                //this.thread = new Thread(new ThreadStart(WorkThreadFunction));
                //thread.Start();

                NewFrameImageEventArgs e = new NewFrameImageEventArgs(lastImageObj);
                OnNewFrameImage(e);
                copy.Dispose();
            }
            catch (System.NullReferenceException NullEx)
            {
                System.Console.WriteLine("System.NullReferenceException; Message: " + NullEx.Message + "; Source: " + NullEx.Source + "; TargetSite: " + NullEx.TargetSite + ";InnerException: " + NullEx.InnerException + "; Data: " + NullEx.Data + "; HelpLink: " + NullEx.HelpLink + "; StackTrace: " +NullEx.StackTrace);
            }
        }
		
		/// <summary>
		/// stop capture of selected webcam
		/// </summary>
		public void stopWebcam()
		{
            ConsoleBuddy.WriteLineBlue("Enter in stopWebcam method");
            try
            {
                if (this.videoDeviceForCapture != null)
                {
                    videoDeviceForCapture.SignalToStop();
                    videoDeviceForCapture.WaitForStop();
                    ConsoleBuddy.WriteLine(this.videoDeviceForCapture.FramesReceived.ToString() + " frames received after WaitForStop");
                }
                // close AVI writer if open
                if (this.writer != null)
                {
                    this.writer.Close();
                }
                this.timer.Stop();
                ConsoleBuddy.WriteLineBlue("Exit stopWebcam method");
            }
            catch (ApplicationException e)
            {
                System.Console.WriteLine("ApplicationException in stopWebcam method:\n" + e.Message);
            }
            catch (SystemException sysEx)
            {
            	this.ConsoleBuddy.WriteException(sysEx, "stopWebcam");
            }
		}
		
		/// <summary>
		/// get parameters of selected webcam
		/// </summary>
		public CameraParam getParameter(CameraParam property)
		{
            // TODO DEBUG setting is correctly get from webcam but not set to object
			try
			{
	            //get property ranges
				bool success = this.videoDeviceForCapture.GetCameraPropertyRange(property.propertyType, out property.minValue, out property.maxValue, out property.stepSize, out property.defaultValue, out property.ctrFlag);
	            
	            Console.Write("minValue: " + property.minValue.ToString() + "\r\n" +
	                            "maxValue: " + property.maxValue.ToString() + "\r\n" +
	                            "stepSize: " + property.stepSize.ToString() + "\r\n" +
	                            "defaultValue: " + property.defaultValue.ToString() + "\r\n" +   
	                            "CameraControlFlags: " + property.ctrFlag.ToString() + "\r\n" +
                                "returnValue(success): " + success.ToString() + "\r\n");
                // set min & max to ezro if property is not adjustable
                if (property.ctrFlag.ToString().Contains("None"))
                {
                    property.minValue = 0;
                    property.maxValue = 0;
                }
            }
            catch (System.ArgumentException ArgEx)
            {
                Console.WriteLine("System.ArgumentException: Video source is not specified - device moniker is not set. Exception message: " + ArgEx.Message);
            }
            catch (System.ApplicationException AppEx)
            {
                Console.WriteLine("System.ApplicationException: Failed creating device object for moniker. Exception message: "+ AppEx.Message);
            }
            catch(System.NotSupportedException NotSupporterEx)
            {
                Console.WriteLine("System.NotSupportedException: The video source does not support camera control. Exception message: " + NotSupporterEx.Message);
            }
            try
            {
                // get current property values
                this.videoDeviceForCapture.GetCameraProperty(property.propertyType, out property.currentValue, out property.currentCtrlFlag);
                Console.Write("currentValue: " + property.currentValue.ToString() + "\r\n" +
                                 "currentCameraControlFlags: " + property.currentCtrlFlag.ToString() + "\r\n");
                // check if property is adjustable
                Console.WriteLine("IsAvailable " + property.propertyType.ToString() + " is ajustable?: " + property.isAdjustable.ToString());
            }
            catch (ArgumentException argEx)
            {
                ConsoleBuddy.WriteException(argEx, "getParameter");
            }
            catch (ApplicationException appEx)
            {
                ConsoleBuddy.WriteException(appEx, "getParameter");
            }
            catch (NotSupportedException notSuppEx)
            {
                ConsoleBuddy.WriteException(notSuppEx, "getParameter");
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
            try
            {
                this.videoDeviceForCapture.SetCameraProperty(property, propertyValue, CameraControlFlags.Manual);
            }
            catch (ArgumentException argEx)
            {
                ConsoleBuddy.WriteException(argEx, "setCameraParameter");
            }
            catch (ApplicationException appEx)
            {
                ConsoleBuddy.WriteException(appEx, "setCameraParameter");
            }
            catch (NotSupportedException notSuppEx)
            {
                ConsoleBuddy.WriteException(notSuppEx, "setCameraParameter");
            }
        }

        /// <summary>
        /// Set resolution of webcam
        /// </summary>
        /// <param name="resolution">Size of frame</param>
        public void setFrameResolution(Size resolution)
        {
            try
            {
                string key = resolution.Width.ToString() + " x " + resolution.Height.ToString();
                this.parameters.capabilities = videoCapabilitiesDictionary[key];
                this.videoDeviceForCapture.VideoResolution = this.parameters.capabilities;
                System.Console.WriteLine(this.videoDeviceForCapture.VideoResolution.FrameSize.ToString());
            }
            catch(ApplicationException appEx)
            {
                System.Console.WriteLine("Exception in setFrameresolution:\n" + appEx.Message);
            }
        }
		
		/// <summary>
		/// Save image to disk
		/// </summary>
		/// <param name="frameCopy">Bitmap frame to save</param>
		/// <param name="time">time when image is captured</param>
		/*private void saveImage(System.Drawing.Bitmap frameCopy, DateTime time)
		{
            try
            {
                char folderSep = System.IO.Path.DirectorySeparatorChar;
                string path = "C:" + folderSep + "Arsalis" + folderSep;
                if (System.IO.Directory.Exists(path))
                {
                    path += "capture_";
                    path += time.ToLongDateString() + "_";
                    path += time.Hour + "_";
                    path += time.Minute + "_";
                    path += time.Second + "_";
                    path += time.Millisecond + ".jpeg";
                    try
                    {
                        frameCopy.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (System.ArgumentNullException argEx)
                    {
                        throw new System.ArgumentNullException("ArgumentNullException: " + argEx.Message);
                    }
                    catch (System.Runtime.InteropServices.ExternalException extEx)
                    {
                        throw new System.Runtime.InteropServices.ExternalException("System.Runtime.InteropServices.ExternalException: " + extEx.Message);
                    }
                }
                else
                {
                    throw new ApplicationException("File path for saving image does not exist");
                }
                //this.lastImage = new Bitmap(frameCopy);
                //writer.AddFrame(frameCopy);
                //System.Drawing.Image copyCompressed = (System.Drawing.Image)frameCopy.Clone();
                //this.images[frameCount] = new Bitmap(copyCompressed);
            }
            catch (ApplicationException e)
            {
                System.Console.WriteLine("Exception in saveImage method:\n" + e.Message);
            }
		}*/
		
        /// <summary>
        /// Get all available frame resolution from selected webcam
        /// </summary>
		public void GetFrameResolutions()
		{
            try
            {
                VideoCapabilities[] videoCapabilities = this.videoDeviceForCapture.VideoCapabilities;
                this.webcamResolutions = new Size[videoCapabilities.Length];

                for (int i = 0; i < videoCapabilities.Length; i++)
                {
                    int width = videoCapabilities[i].FrameSize.Width;
                    int height = videoCapabilities[i].FrameSize.Height;
                    Console.WriteLine(videoCapabilities[i].FrameSize.ToString());
                    string item = string.Format("{0} x {1}", width, height);

                    if (!videoCapabilitiesDictionary.ContainsKey(item))
                    {
                        videoCapabilitiesDictionary.Add(item, videoCapabilities[i]);
                        this.webcamResolutions[i] = new Size(width, height);
                    }
                }
            }
            catch (ApplicationException appEx)
            {
                ConsoleBuddy.WriteException(appEx, "GetFrameResolutions");
            }
            catch (SystemException sysEx)
            {
                ConsoleBuddy.WriteException(sysEx, "GetFrameResolutions");
            }
		}

        /// <summary>
        /// Public event fired at each new frame image
        /// </summary>
        public event Arsalis.WebcamLibrary.NewFrameImageEventArgs.NewFrameEventImageHandler NewFrameImage;

        /// <summary>
        /// Delegate that handle the NewFrameImage event handler
        /// </summary>
        /// <param name="e">EventArgs that contains the new image</param>
        protected virtual void OnNewFrameImage(NewFrameImageEventArgs e)
        {
            try
            {
                var handler = NewFrameImage;
                if (handler != null)
                    handler(this, e);
            }
            catch (ApplicationException appEx)
            {
                System.Console.WriteLine("Exception in OnNewFrame delegate:\n" + appEx.Message);
            }
            catch (SystemException sysEx)
            {
                System.Console.WriteLine("Exception in OnNwFrame delegate:\n" + sysEx.Message);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ConsoleBuddy.WriteLineYellow("Timer event");
            ConsoleBuddy.WriteLineYellow("Time elapsed: " + this.elapsedTime.ToString() + " s");
            this.elapsedTime = this.stopWatch.ElapsedMilliseconds / 1000.0;
            this.frameRate = this.frameCount / this.elapsedTime;
            ConsoleBuddy.WriteLineYellow("Frame rate: " + this.frameRate.ToString() +" frames/sec");
        }

        /// <summary>
        /// Destructor that write message to console when Arsalis.WebcamLibrary object is destroyed
        /// </summary>
        ~WebcamLibrary()
        {
            System.Console.WriteLine("WebcamLibrary object is destroyed");
            System.Threading.Thread.Sleep(1000);
        }
	}
}
