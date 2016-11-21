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

            this.webcam = selectedWebcam;
            this.OpenVideoSource( this.webcam.videoDeviceForCapture);
            //this.webcam.startWebcam(0);
            //this.videoSourcePlayer1.Start();
		}
		
		public WebcamLibrary webcam;
		public string  timeStamps = "";
		
		
		void VideoSourcePlayer1NewFrame(object sender, ref Bitmap image)
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
	}
}
