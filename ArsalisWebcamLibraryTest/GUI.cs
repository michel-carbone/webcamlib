/*
 * Created by SharpDevelop.
 * User: michel
 * Date: 12/09/2016
 * Time: 16:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Arsalis.WebcamLibrary;
using AForge;
using AForge.Controls;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Arsalis.WebcamLibrary.Test
{
	/// <summary>
	/// Description of GUI.
	/// </summary>
	public partial class GUI : Form
	{
		public GUI(Arsalis.WebcamLibrary.WebcamLibrary selectedWebcam)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

            // optimise display speed in order to avoid flicker
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            
            this.webcam = selectedWebcam;
            // TODO check if VideoResolution can be set all the time at initialisation 
            // of WebcamLibrary or define a new parameter in WebcamLibrary
            
            
            try
            {
            	if (this.webcam.videoDeviceForCapture.VideoResolution != null)
            	{
                	this.pictureBox1.Size = this.webcam.videoDeviceForCapture.VideoResolution.FrameSize;
            	}
            }
            catch(SystemException ex)
            {
                ConsoleBuddy.WriteException(ex, "GUI(Arsalis.WebcamLibrary.WebcamLibrary selectedWebcam)");
            }
            //this.OpenVideoSource( this.webcam.videoDeviceForCapture);
            //this.webcam.startWebcam(0);
            //this.videoSourcePlayer1.Start();
            SubscribeToEvent(selectedWebcam);
		}
		
		public WebcamLibrary webcam;
		public string  timeStamps = "";

        internal ConsoleDebugger ConsoleBuddy = new ConsoleDebugger();
		
		void VideoSourcePlayer1NewFrame(object sender, ref Bitmap image)
		{
            try
            {
                //Create Bitmap from frame
                System.Drawing.Bitmap FrameData = (System.Drawing.Bitmap)image.Clone();
                //Add to PictureBox
                //pictureBox1.Image = FrameData;
                //pictureBox1.Invalidate();

                DateTime now = DateTime.Now;
                //int frameCount = this.webcam.videoDeviceForCapture.FramesReceived;
                this.timeStamps += now.ToString() + "::" + now.Millisecond.ToString() + "\r\n";
                //this.Invalidate();
            }
            catch (SystemException sysEx)
            {
                ConsoleBuddy.WriteException(sysEx, "VideoSourcePlayer1NewFrame");
            }
            catch (ApplicationException appEx)
            {
                ConsoleBuddy.WriteException(appEx, "VideoSourcePlayer1NewFrame");
            }
		}
		
		public void OpenVideoSource( IVideoSource source )
        {
        	
            // set busy cursor
            this.Cursor = Cursors.WaitCursor;

            // stop current video source
            CloseCurrentVideoSource( );

            // start new video source
            this.videoSourcePlayer1.VideoSource = source;
            this.videoSourcePlayer1.Start( );
            System.Threading.Thread.Sleep(500);
            this.Cursor = Cursors.Default;
        }
		
		// Close video source if it is running
        public void CloseCurrentVideoSource( )
        {
            if ( this.videoSourcePlayer1.VideoSource != null )
            {
                this.videoSourcePlayer1.SignalToStop( );

                // wait ~ 3 seconds
                for ( int i = 0; i < 30; i++ )
                {
                    if ( !this.videoSourcePlayer1.IsRunning )
                        break;
                    System.Threading.Thread.Sleep( 100 );
                }

                if ( this.videoSourcePlayer1.IsRunning )
                {
                    this.videoSourcePlayer1.Stop( );
                }

                this.videoSourcePlayer1.VideoSource = null;
            }
        }

        public event Arsalis.WebcamLibrary.NewFrameImageEventArgs.NewFrameEventImageHandler NewFrameImage;


        protected virtual void OnNewFrameImage(NewFrameImageEventArgs e)
        {
            Arsalis.WebcamLibrary.NewFrameImageEventArgs.NewFrameEventImageHandler handler = NewFrameImage;
            if (handler != null)
            {
                handler(this, e);
                //this.pictureBox1.Image = (System.Drawing.Bitmap) e.getImageToGui().image.Clone();
                //this.pictureBox1.Invalidate();
            }
        }

        void SubscribeToEvent(Arsalis.WebcamLibrary.WebcamLibrary webcam)
        {
            try
            {
                webcam.NewFrameImage += this.GrabNewFrame;
            }
            catch (SystemException sysEx)
            {
                ConsoleBuddy.WriteException(sysEx, "SubscribeToEvent");
            }
            catch (ApplicationException appEx)
            {
                ConsoleBuddy.WriteException(appEx, "SubscribeToEvent");
            }
        }

        void GrabNewFrame(object sender, NewFrameImageEventArgs args)
        {
            try
            {
                System.Drawing.Image frame = DrawText((System.Drawing.Image)args.getImageToGui().image, args.timestamp);
                //this.pictureBox1.Image = frame;
                SetControlPropertyThreadSafe(this.pictureBox1, "Image", frame);
                //this.pictureBox1.Update();
            }
            catch (SystemException sysEx)
            {
                ConsoleBuddy.WriteException(sysEx, "GrabNewFrame");
            }
            catch (ApplicationException appEx)
            {
                ConsoleBuddy.WriteException(appEx, "GrabNewFrame");
            }

        }

        private System.Drawing.Image DrawText(System.Drawing.Image image, string text)
        {
            try
            {
                Graphics g = Graphics.FromImage(image);

                // paint current time
                SolidBrush brush = new SolidBrush(Color.Red);
                g.DrawString(text, this.Font, brush, new PointF(5, 5));
                brush.Dispose();
            }
            catch (SystemException sysEx)
            {
                ConsoleBuddy.WriteException(sysEx, "DrawText");
            }
            catch (ApplicationException appEx)
            {
                ConsoleBuddy.WriteException(appEx, "DrawText");
            }
            return image;
        }

        private void GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CloseCurrentVideoSource();
        }

        private int previousFrameCount = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                toolStripStatusLabel1.Text = "Frames received: " + this.webcam.frameCount.ToString();
                int frameRate = 0;
                int currentFrameCount = this.webcam.frameCount;
                frameRate = currentFrameCount - previousFrameCount;
                toolStripStatusLabel2.Text = "Frame rate: " + frameRate.ToString();
                previousFrameCount = this.webcam.frameCount;
            }
            catch (SystemException sysEx)
            {
                ConsoleBuddy.WriteException(sysEx, "timer1_Tick");
            }
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate
                (SetControlPropertyThreadSafe),
                new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, System.Reflection.BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }
	}
}
