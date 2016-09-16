/*
 * Created by SharpDevelop.
 * User: michel
 * Date: 9/09/2016
 * Time: 17:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Controls;

namespace Arsalis.WebcamLibrary.Test
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			Arsalis.WebcamLibrary.WebcamLibrary test = new WebcamLibrary();
			
			if(test.webcamAvailable)
			{
    			for(int i = 0; i<test.WebcamListNames.Length; i++)
    			{
    				Console.WriteLine(i.ToString() + ": " + test.WebcamListNames[i]);
    			}
			}
			test.startWebcam();
			Console.WriteLine("Open GUI...");
			Arsalis.WebcamLibrary.Test.GUI testGUI = new GUI();
			//testGUI.webcam.startWebcam();
			testGUI.OpenVideoSource(test.videoDeviceForCapture);
			testGUI.ShowDialog();
			//CameraImaging cameraImg = new CameraImaging(test.videoDeviceForCapture);
			//cameraImg.videoSource.NewFrame
			//testGUI.videoSourcePlayer1.NewFrame += VideoSourcePlayer.NewFrameHandler(cameraImg.videoSource_NewFrame);
			testGUI.videoSourcePlayer1.VideoSource.Start();
			Console.WriteLine("Press any key to continue . . . ");
			Console.ReadKey(true);
			testGUI.CloseCurrentVideoSource();
			test.stopWebcam();
			Console.Write(testGUI.timeStamps);
			Console.WriteLine("Press any key to continue . . . ");
			Console.ReadKey(true);
			
			//testGUI.Dispose();

			
			//CameraImaging cameraImg = new CameraImaging(test.videoDeviceForCapture);
			
		}
	}
}